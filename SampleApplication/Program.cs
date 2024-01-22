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

            HavingClause();

            //SumOver();
            //OverAndAliasQuerySimple();
            //OverAndAliasQuery();
            //OverMashup();

            GetEmployees(1, 2);
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
