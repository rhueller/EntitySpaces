using BusinessObjects;
using EntitySpaces.Interfaces;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // ReSharper disable once ArrangeTypeModifiers
    // ReSharper disable once ClassNeverInstantiated.Global
    [SuppressMessage("ReSharper", "UnusedVariable")]
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Maind(string[] args)
        {
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();

            // Add a connection
            var conn = new esConnectionElement
            {
                Provider = "EntitySpaces.MySQLProvider",
                DatabaseVersion = "2012",
                ConnectionString = "Database=Northwind;Data Source=Localhost;Port=3306;User Id=root;Password=root"
            };

            esConfigSettings.ConnectionInfo.Connections.Add(conn);

            GroupBy();
            Concatenation();
            Paging();
            WhereExists();
            CorrelatedSubQuery();
            CorrelatedSubQueryEmbeddedSubQuery();
            SelectAllExcept();
            SelectDistinctTop();
            AliasColumn();
            AndOr();
            Filter();

            Query_Join();
            Subquery();
            CaseWhenThenEnd();
            HavingClause();

            //SumOver();
            //OverAndAliasQuerySimple();
            //OverAndAliasQuery();
            //OverMashup();

            GetEmployees(1, 2);
        }

        private static void GroupBy()
        {
            
            var coll = new OrderDetailsQuery("od", out var od)
            .Select(od.OrderID, (od.UnitPrice * od.Quantity).Sum().As("OrderTotal"))
            .GroupBy(od.OrderID)
            .ToCollection<OrderDetailsCollection>();

            if (coll.Count > 0)
            {
               
            }
        }

        private static void Concatenation()
        {
            var coll = new EmployeesQuery("e", out var q)
            .Select(q.EmployeeID, (q.LastName + ", " + q.FirstName).As("FullName"))
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {
                
            }
        }

        private static void Query_Join()
        {
            var coll = new OrdersQuery("oq", out var oq)
            .InnerJoin<OrderDetailsQuery>("odq", out var odq).On(oq.OrderID == odq.OrderID)
            .Select(oq.OrderID, odq.Discount)
            .Where(odq.Discount > 0)
            .ToCollection<OrdersCollection>();

            if (coll.Count <= 0) return;
            
            // Lazy loads ...
            foreach (var order in coll)
            {
                Debug.Assert(order != null, "order != null");
            }
        }

        private static void AndOr()
        {
            var coll = new EmployeesQuery("e", out var q)
            .Select(q.EmployeeID, (q.LastName + ", " + q.FirstName).As("FullName"))
            .Where(q.EmployeeID > 4 && (q.EmployeeID < 10 || q.EmployeeID == 100))
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {

            }
        }

        private static void Paging()
        {
            {
                // PageSize and PageNumber
                var coll = new EmployeesQuery("e", out var q)
                .OrderBy(q.HireDate.Descending).PageSize(5).PageNumber(2)
                .ToCollection<EmployeesCollection>();

                if (coll.Count > 0)
                {

                }
            }

            {
                // Skip and Take
                var coll = new EmployeesQuery("e", out var q)
                .OrderBy(q.HireDate.Descending).Skip(5).Take(20)
                .ToCollection<EmployeesCollection>();

                if (coll.Count > 0)
                {

                }
            }
        }

        private static void SelectAllExcept()
        {
            // We don't want to bring back the huge image every time
            var coll = new EmployeesQuery("e", out var q)
            .SelectAllExcept(q.Photo)
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {

            }
        }

        private static void SelectDistinctTop()
        {
            var coll = new EmployeesQuery("e", out var q)
            .Select(q.EmployeeID).Top(5).Distinct()
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {
 
            }
        }

        private static void WhereExists()
        {
            // Find all Employees who have no ReportsTo. We could do this via a simple
            // join as well but are demonstrating the Exists() functionality
            var coll = new EmployeesQuery("e", out var eq)
            .Select(eq.EmployeeID, eq.ReportsTo)
            .Where(eq.Exists(() => new EmployeesQuery("s", out var subquery)
                .Select(subquery.EmployeeID)
                .Where(subquery.ReportsTo.IsNotNull() && subquery.EmployeeID == eq.EmployeeID)
                .Distinct())
            )
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {
                // Then we loaded at least one record
            }
        }

        private static void AliasColumn()
        {
            var coll = new EmployeesQuery("e", out var q)
            .Select(q.FirstName.As("MyAlias"))
            .ToCollection<EmployeesCollection>();

            if (coll.Count > 0)
            {

            }
        }

        private static void Filter()
        {
            var coll = new EmployeesCollection();
            if (!coll.LoadAll()) return;
            
            // Filter on FirstName containing an "a"
            coll.Filter = coll.AsQueryable().Where(d => d.FirstName.Contains("a"));

            foreach (var employee in coll)
            {
                // Each employee's FirstName has an 'a' in
            }

            // Clear the filter
            coll.Filter = null;

            foreach (var employee in coll)
            {
                // All employees are now back in the list
            }
        }

        private static void Subquery()
        {
            var orders = new OrdersQuery("o");
            var details = new OrderDetailsQuery("oi");

            orders.Select
            (
                orders.OrderID,
                orders.OrderDate,
                details.Select
                (
                    details.UnitPrice.Max()
                )
                .Where(orders.OrderID == details.OrderID).As("MaxUnitPrice")
            );

            var coll = new OrdersCollection();
            if (!coll.Load(orders)) return;
            
            foreach (var order in coll)
            {

            }
        }

        private static void CorrelatedSubQuery()
        {
            var oiq = new OrderDetailsQuery("oi");
            var pq = new ProductsQuery("p");

            oiq.Select(oiq.OrderID, (oiq.Quantity * oiq.UnitPrice).Sum().As("Total"))
            .Where(oiq.ProductID
                .In(
                    pq.Select(pq.ProductID).Where(oiq.ProductID == pq.ProductID).Distinct()
                )
            )
            .GroupBy(oiq.OrderID);

            var coll = new OrderDetailsCollection();
            if (coll.Load(oiq))
            {

            }
        }

        private static void CorrelatedSubQueryEmbeddedSubQuery()
        {
            var oiq = new OrderDetailsQuery("oi");
            oiq.Select(oiq.OrderID, (oiq.Quantity * oiq.UnitPrice).Sum().As("Total"))
            .Where(oiq.ProductID.In(() =>
                {
                    var pq = new ProductsQuery("p");
                    pq.Select(pq.ProductID).Where(oiq.ProductID == pq.ProductID)
                    .Distinct();
                    return pq;
                })
            )
            .GroupBy(oiq.OrderID);

            var coll = new OrderDetailsCollection();
            if (coll.Load(oiq))
            {

            }
        }

        private static void CaseWhenThenEnd()
        {
            var oq = new OrderDetailsQuery();

            oq.Select
            (
                oq.Quantity,
                oq.UnitPrice,
                oq.UnitPrice
                    .Case()
                        .When(oq.Quantity < 50).Then(oq.UnitPrice)
                        .When(oq.Quantity >= 50 && oq.Quantity < 70).Then(oq.UnitPrice * .90)
                        .When(oq.Quantity >= 70 && oq.Quantity < 99).Then(oq.UnitPrice * .80)
                        .Else(oq.UnitPrice * .70)
                    .End().As("Adjusted Unit Price")
            ).OrderBy(oq.Quantity.Descending);

            var coll = new OrderDetailsCollection();
            if (coll.Load(oq))
            {

            }

        }

        private static void HavingClause()
        {
            var coll = new OrderDetailsQuery("q", out var q)
                .Select(q.OrderID, q.UnitPrice.Sum().As("TotalUnitPrice"))
                .Where(q.Discount.IsNotNull())
                .GroupBy(q.OrderID)
                .Having(q.UnitPrice.Sum() > 100)
                .OrderBy(q.OrderID.Descending)
                .ToCollection<OrderDetailsCollection>();

            if (coll.Count > 0)
            {

            }
        }

        //private static void SumOver()
        //{
        //    /*

        //    SELECT 
        //        SUM(o.[Freight]) OVER( PARTITION BY o.[EmployeeID] ) AS 'FreightByEmployee',
        //        SUM(o.[Freight]) OVER( PARTITION BY o.[EmployeeID], o.[ShipCountry] ) AS 'FreightByEmployeeAndCountry'  
        //    FROM [Orders] o 
        //    ORDER BY o.[EmployeeID] ASC,o.[ShipCountry] ASC

        //    */

        //    //var coll = new OrdersQuery("o", out var o)
        //    //.Select
        //    //(
        //    //    o.Over.Sum(o.Freight).PartitionBy(o.EmployeeID).As("FreightByEmployee"),
        //    //    o.Over.Sum(o.Freight).PartitionBy(o.EmployeeID, o.ShipCountry).As("FreightByEmployeeAndCountry")
        //    //)
        //    //.OrderBy(o.EmployeeID.Ascending, o.ShipCountry.Ascending)
        //    //.ToCollection<OrdersCollection>();

        //    //if (coll.Count > 0)
        //    //{
        //    //    // Then we loaded at least one record
        //    //}

        //}

        //private static void OverAndAliasQuerySimple()
        //{
        //    esAlias rowNumber = null;

        //    var coll = new OrdersQuery("o", out var o)
        //    .From<OrderDetailsQuery>(out var od, () =>
        //    {
        //        // Nested Query
        //        return new OrderDetailsQuery("od", out var subQuery)
        //        .Select
        //        (
        //            subQuery.Over.RowNumber().OrderBy(subQuery.OrderID.Descending).As("RowNumber", out rowNumber)
        //        )
        //        .GroupBy(subQuery.OrderID);
        //    }).As("sub")
        //    .Select(rowNumber())
        //    .Where(rowNumber() > 5)
        //    .ToCollection<OrdersCollection>();

        //    if (coll.Count > 0)
        //    {
        //        // Then we loaded at least one record
        //    }
        //}

        //private static void OverAndAliasQuery()
        //{
        //    esAlias aliasCompany = null, aliasPeriod = null, aliasAmount = null, aliasItemCount = null;

        //    var coll = new OrdersQuery("q", out var q)
        //    .From<OrdersQuery>(out var sub, () => // mimic a CTE
        //    {
        //        // Nested Query
        //        return new OrdersQuery("o", out var o)
        //        .InnerJoin<CustomersQuery>("c", out var c).On(c.CustomerID == o.CustomerID)
        //        .InnerJoin<OrderDetailsQuery>("od", out var od).On(od.OrderID == o.OrderID)
        //        .Select
        //        (
        //            // We're going to grab the aliased columns here for re-use in the outer query later
        //            o.Count().As("TotalItems", out aliasItemCount),
        //            c.CompanyName.As("CompanyName", out aliasCompany),
        //            o.OrderDate.DatePart("year").As("Period", out aliasPeriod),
        //            ((1.00M - od.Discount) * od.UnitPrice * od.Quantity).Cast(esCastType.Decimal, 19, 2).Sum().Round(2).As("Amount", out aliasAmount)
        //        )
        //        .GroupBy(c.CompanyName, o.OrderDate.DatePart("year"));
        //    }).As("sub")
        //    // Now act on "sub" query columns
        //    .Select(
        //        aliasCompany(), aliasPeriod(), aliasAmount(), aliasItemCount(),
        //        q.Over.Sum(aliasAmount()).PartitionBy(aliasCompany()).OrderBy(aliasPeriod().Ascending).Rows.UnBoundedPreceding.As("CumulativeAmount"),
        //        q.Over.Sum(aliasAmount()).PartitionBy(aliasCompany()).As("TotalAmount")
        //    )
        //    .OrderBy(aliasCompany().Ascending, aliasPeriod().Ascending)
        //    .ToCollection<OrdersCollection>();

        //    if(coll.Count > 0)
        //    {
        //        // we loaded data
        //    }
        //}

        //private static void OverMashup()
        //{
        //    // This query is nonsense, it's here just to test the syntax ...

        //    var coll = new OrdersQuery("q", out var q)
        //    .Select
        //    (
        //        // Ranking Methods ...
        //        q.Over.RowNumber().OrderBy(q.EmployeeID.Descending).As("RowNumber1"),
        //        q.Over.RowNumber().PartitionBy(q.Freight.Sum() * 10).OrderBy(q.EmployeeID.Descending).As("RowNumber2"),
        //        q.Over.Rank().OrderBy(q.EmployeeID.Descending).As("Rank"),
        //        q.Over.DenseRank().OrderBy(q.EmployeeID.Descending).As("DensRank"),
        //        q.Over.PercentRank().OrderBy(q.EmployeeID.Descending).As("PercentRank"),
        //        q.Over.Ntile(4).OrderBy(q.EmployeeID.Descending).As("NTile"),

        //        // Aggregate Methods
        //        q.Over.Avg(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Avg"),
        //        q.Over.Count(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Count"),
        //        q.Over.CountBig(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("CountBig"),
        //        q.Over.Max(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Max"),
        //        q.Over.Min(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Min"),
        //        q.Over.StdDev(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("StdDev"),
        //        q.Over.StdDevP(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("StdDevP"),
        //        q.Over.Var(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Var"),
        //        q.Over.VarP(q.Freight).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("VarP"),

        //        // Analytical Methods
        //        q.Over.CumeDist().PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("CumeDist"),
        //        q.Over.FirstValue(q.EmployeeID).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("FirstValue"),
        //        q.Over.LastValue(q.EmployeeID).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("LastValue"),
        //        q.Over.Lag(q.EmployeeID, 0.05M).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Lag"),
        //        q.Over.Lead(q.EmployeeID, 0.05M).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("Lead"),
        //        q.Over.PercentileCont(0.05M).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("PercentileCont"),
        //        q.Over.PercentileDisc(0.02M).PartitionBy(q.EmployeeID).OrderBy(q.EmployeeID.Descending).As("PercentileDisc")
        //    )
        //    .GroupBy(q.EmployeeID, q.Freight)
        //    .ToCollection<OrdersCollection>();

        //    if (coll.Count > 0)
        //    {
        //        // Then we loaded at least one record
        //    }
        //}

        private static void GetEmployees(int skip, int take)
        {
            Parallel.Invoke(
                () =>
                {
                    // Get the total count
                    var count = new EmployeesQuery("e", out var q)
                        .Select(q.Count())
                        .ExecuteScalar<int>();
                },
                () =>
                {
                    // Get "paged" list, must order by when paging 
                    var coll = new EmployeesQuery("e", out var q)
                        .Select(q.EmployeeID, q.LastName).Skip(skip).Take(take)
                        .OrderBy(q.LastName.Ascending)
                        .ToCollection<EmployeesCollection>();
                });
        }
    }
}
