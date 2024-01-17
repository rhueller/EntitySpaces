using System.Data;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class ClassFactory : IClassFactory
	{
        public ITables CreateTables()
		{
			return new MySqlTables();
		}

		public ITable CreateTable()
		{
			return new MySqlTable();
		}

		public IColumn CreateColumn()
		{
			return new MySqlColumn();
		}

		public IColumns CreateColumns()
		{
			return new MySqlColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new MySqlDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new MySqlDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new MySqlProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new MySqlProcedures();
		}

		public IView CreateView()
		{
			return new MySqlView();
		}

		public IViews CreateViews()
		{
			return new MySqlViews();
		}

		public IParameter CreateParameter()
		{
			return new MySqlParameter();
		}

		public IParameters CreateParameters()
		{
			return new MySqlParameters();
		}

		public IForeignKey CreateForeignKey()
		{
			return new MySqlForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new MySqlForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new MySqlIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new MySqlIndexes();
		}

		public IResultColumn CreateResultColumn()
		{
			return new MySqlResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new MySqlResultColumns();
		}

		public IDomain CreateDomain()
		{
			return new MySqlDomain();
		}

		public IDomains CreateDomains()
		{
			return new MySqlDomains();
		}

		public IProviderType CreateProviderType()
		{
			return new ProviderType();
		}

		public IProviderTypes CreateProviderTypes()
		{
			return new ProviderTypes();
		}

        public IDbConnection CreateConnection()
        {
            return MySqlDatabases.CreateConnection("");
        }
	}
}
