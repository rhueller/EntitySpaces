using System.Data;
using System.Data.Common;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlIndexes : Indexes
	{
        internal override void LoadAll()
		{
			try
			{
				string query = @"SHOW INDEX FROM `" + Table.Name + "`";

				DataTable metaData = new DataTable();
				DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, dbRoot.ConnectionString);

				adapter.Fill(metaData);

				metaData.Columns["Key_name"].ColumnName		= "INDEX_NAME";
				metaData.Columns["Index_type"].ColumnName	= "TYPE";
				metaData.Columns["Non_unique"].ColumnName   = "UNIQUE";
			
				PopulateArray(metaData);


			}
			catch {}
		}
	}
}
