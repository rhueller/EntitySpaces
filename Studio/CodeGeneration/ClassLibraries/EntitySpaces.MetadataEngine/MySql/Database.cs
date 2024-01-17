namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlDatabase : Database
	{
        public override string Alias
		{
			get
			{
				return _name;
			}
		}

		public override string Name
		{
			get
			{
				return _name;
			}
		}

		public override string Description
		{
			get
			{
				return _desc;
			}
		}

		internal string _name = "";
		internal string _desc = "";

		internal bool _FKsInLoad = false;
	}
}
