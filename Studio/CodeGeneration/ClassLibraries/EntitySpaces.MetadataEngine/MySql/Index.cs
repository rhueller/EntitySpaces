using System;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlIndex : Index
	{
        public override string Type
		{
			get
			{
				return GetString(Indexes.f_Type);
			}
		}

		public override Boolean Unique
		{
			get
			{
				// We have to reverse the meaning
				return (base.Unique) ? false : true;
			}
		}

		public override string Collation
		{
			get
			{
				string s = GetString(Indexes.f_Collation);

				switch(s)
				{
					case "A":
						return "ASCENDING";
					case "D":
						return "DECENDING";
					default:
						return "UNKNOWN";
				}
			}
		}
	}
}
