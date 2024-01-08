using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlDatabases : Databases
	{
        internal const string NameSpace = "MySqlConnector.";

        //static internal string nameSpace = "MySql.Data.MySqlClient."; 
        private static Assembly _asm;
        private static Module   _mod;

		static internal ConstructorInfo IDbConnectionCtor = null;
		static internal ConstructorInfo IDbDataAdapterCtor = null;
        static internal ConstructorInfo IDbDataAdapterCtor2 = null;

		internal string Version = "";

		public MySqlDatabases()
		{
			LoadAssembly();
		}

		static MySqlDatabases()
		{
			LoadAssembly();
		}

        static public void LoadAssembly()
        {
            if (_asm != null) return;
            try
            {
                _asm = Assembly.Load("MySqlConnector");
                var mods = _asm.GetModules(false);
                _mod = mods[0];
            }
            catch
            {
                throw new Exception(
                    "Make sure the MySqlConnector.dll is registered in the Gac or is located in the MyGeneration folder.");
            }
        }

		internal override void LoadAll()
		{
			try
			{
				var name = "";

                // test


                // test

				// We add our one and only Database
				var conn = CreateConnection(dbRoot.ConnectionString);
				conn.Open();
				name = conn.Database;
				conn.Close();
				conn.Dispose();

				var database = (MySqlDatabase)this.dbRoot.ClassFactory.CreateDatabase();
				database._name = name;
				database.dbRoot = this.dbRoot;
				database.Databases = this;
				_array.Add(database);

				try
				{
					var metaData = new DataTable();
					var adapter = CreateAdapter("SELECT VERSION()", dbRoot.ConnectionString);

					adapter.Fill(metaData);

					Version = metaData.Rows[0][0] as string;
				}
                catch
                {
                    // ignored
                }
            }
            catch
            {
                // ignored
            }
        }

        static internal IDbConnection CreateConnection(string connStr)
        {
            if (IDbConnectionCtor == null)
            {
                var type = _mod.GetType(NameSpace + "MySqlConnection");

                IDbConnectionCtor = type.GetConstructor(new[] { typeof(string) });
            }

            var obj = IDbConnectionCtor.Invoke(
                BindingFlags.CreateInstance,
                null, 
                new object[] { connStr }, 
                CultureInfo.InvariantCulture);

            return obj as IDbConnection;
        }

		static internal DbDataAdapter CreateAdapter(string query, string connStr)
		{
			if(IDbDataAdapterCtor2 == null)
			{
				var type = _mod.GetType(NameSpace + "MySqlDataAdapter");

				IDbDataAdapterCtor2 = type.GetConstructor(new[] {typeof(string), typeof(string)} );
			}

			var obj =  IDbDataAdapterCtor2.Invoke
				(BindingFlags.CreateInstance | BindingFlags.OptionalParamBinding, null, 
				new object[] {query, connStr}, null);

			return obj as DbDataAdapter;
		}
	}
}
