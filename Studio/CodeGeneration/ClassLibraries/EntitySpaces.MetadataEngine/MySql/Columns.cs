using System;
using System.Data;
using System.Data.Common;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlColumns : Columns
	{
        internal override void LoadForTable()
		{
			var query = @"SHOW COLUMNS FROM `" + Table.Name + "`";

			var metaData = new DataTable();
			var adapter = MySqlDatabases.CreateAdapter(query, dbRoot.ConnectionString);

			adapter.Fill(metaData);

			metaData.Columns["Field"].ColumnName   = "COLUMN_NAME";
			metaData.Columns["Type"].ColumnName    = "DATA_TYPE";
			metaData.Columns["Null"].ColumnName    = "IS_NULLABLE";
			metaData.Columns["Default"].ColumnName = "COLUMN_DEFAULT";

            if (metaData.Columns.Contains("Extra"))
            {
                if (!metaData.Columns.Contains("IS_AUTO_KEY"))
                {
                    f_IsAutoKey = metaData.Columns.Add("IS_AUTO_KEY", typeof(bool));
                }

                foreach (DataRow row in metaData.Rows)
                {
                    var extra = (string)row["extra"];

                    if (extra != null && extra.Contains("autoincrement"))
                    {
                        row["IS_AUTO_KEY"] = true;
                    }
                    else
                    {
                        row["IS_AUTO_KEY"] = false;
                    }
                }
            }
			
			PopulateArray(metaData);

			LoadTableColumnDescriptions();
		}

		internal override void LoadForView()
		{
			var db   = View.Database as MySqlDatabase;
			var dbs = db.Databases as MySqlDatabases;
			if(dbs.Version.StartsWith("5"))
			{
				var query = @"SHOW COLUMNS FROM `" + View.Name + "`";

				var metaData = new DataTable();
				var adapter = MySqlDatabases.CreateAdapter(query, dbRoot.ConnectionString);

				adapter.Fill(metaData);

				metaData.Columns["Field"].ColumnName   = "COLUMN_NAME";
				metaData.Columns["Type"].ColumnName    = "DATA_TYPE";
				metaData.Columns["Null"].ColumnName    = "IS_NULLABLE";
				metaData.Columns["Default"].ColumnName = "COLUMN_DEFAULT";

                if (metaData.Columns.Contains("IS_AUTO_KEY")) f_IsAutoKey = metaData.Columns["IS_AUTO_KEY"];
			
				PopulateArray(metaData);
			}
		}

		private void LoadTableColumnDescriptions()
		{
			try
			{
				var query = @"SELECT TABLE_NAME, COLUMN_NAME, COLUMN_COMMENT FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = '" + 
                            Table.Database.Name + "' AND TABLE_NAME ='" + Table.Name + "'";

				var metaData = new DataTable();
				var adapter = MySqlDatabases.CreateAdapter(query, dbRoot.ConnectionString);

				adapter.Fill(metaData);

				if(metaData.Rows.Count > 0)
				{
					foreach(DataRow row in metaData.Rows)
					{
						var c = this[row["COLUMN_NAME"] as string] as Column;

						if(!c._row.Table.Columns.Contains("DESCRIPTION"))
						{
							c._row.Table.Columns.Add("DESCRIPTION", Type.GetType("System.String"));
							f_Description = c._row.Table.Columns["DESCRIPTION"];
						}

                        c._row["DESCRIPTION"] = row["COLUMN_COMMENT"] as string;

                        // We now set the AutoKey flag here ...
                        var extra = (string)c._row["Extra"];

                        if(extra != null && extra.Length > 0)
                        {
                            if (-1 != extra.IndexOf("auto_increment"))
                            {
                                c._row["IS_AUTO_KEY"] = true;
                            }
                        }
					}
				}
			}
			catch {}
		}
	}
}
