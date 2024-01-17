using System.Data;
using System.Data.Common;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlViews : Views
	{
        internal override void LoadAll()
		{
			try
			{
				MySqlDatabases db = Database.Databases as MySqlDatabases;
				if(db.Version.StartsWith("5"))
				{
					string query = @"SHOW FULL TABLES WHERE Table_type = 'VIEW'";

					DataTable metaData = new DataTable();
					DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, dbRoot.ConnectionString);

					adapter.Fill(metaData);

					metaData.Columns[0].ColumnName = "TABLE_NAME";

					PopulateArray(metaData);
				}
			}
			catch {}
		}
	}
}
