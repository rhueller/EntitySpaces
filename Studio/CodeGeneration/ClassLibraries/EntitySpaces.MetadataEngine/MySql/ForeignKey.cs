namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlForeignKey : ForeignKey
	{
        public override ITable ForeignTable
		{
			get
			{
				string catalog = ForeignKeys.Table.Database.Name;
				string schema  = GetString(ForeignKeys.f_FKTableSchema);

				return dbRoot.Databases[catalog].Tables[GetString(ForeignKeys.f_FKTableName)];
			}
		}
	
		public override string PrimaryKeyName
		{
			get
            {
                if(PrimaryTable.Indexes["PRIMARY"] != null)
					return "PRIMARY";
                return base.PrimaryKeyName;
            }
		}
	}
}
