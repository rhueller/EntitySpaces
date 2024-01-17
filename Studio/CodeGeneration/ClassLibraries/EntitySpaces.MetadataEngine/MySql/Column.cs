using System;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlColumn : Column
	{
		static char[] chars = {' ', '('};

		private int numericScale;
		private int precision;
		private int characterLength;
		private string dataType = "";

        internal override Column Clone()
		{
			Column c = base.Clone();

			return c;
		}

		public override Boolean IsNullable
		{
			get
			{
				MySqlColumns cols = Columns as MySqlColumns;
				string s = GetString(cols.f_IsNullable);
				return (s == "YES") ? true : false;
			}
		}

		public override Boolean HasDefault
		{
			get
			{
				return (Default == "") ? false : true;
			}
		}

		public override string DataTypeName
		{
			get
			{
				if(dataType == "")
				{
					MySqlColumns cols = Columns as MySqlColumns;
					string type = GetString(cols.f_DataType).ToUpper();

					string[] data = type.Split(' ');
					string[] typeandsize = data[0].Split('(', ')', ',');

					dataType = typeandsize[0];

					if(dataType != "ENUM")
					{
						if(-1 != type.IndexOf("UNSIGNED"))
						{
							dataType += " UNSIGNED";
						}

						int parts = typeandsize.Length;

						if(parts >= 2)
						{
							if(dataType == "VARCHAR" || dataType == "CHAR")
							{
								characterLength = Convert.ToInt32(typeandsize[1]);
							}
							else
							{
								precision = Convert.ToInt32(typeandsize[1]);
							}
						}

						if(parts >= 3)
						{
							if(typeandsize[2].Length > 0)
							{
								numericScale = Convert.ToInt32(typeandsize[2]);
							}
						}
					}
				}

				return dataType;
			}
		}

		public override string DataTypeNameComplete
		{
			get
			{
                string dataTypeNameComplete = "";

				try
				{
					MySqlColumns cols = Columns as MySqlColumns;
					string origType = GetString(cols.f_DataType);
					string type = origType.ToUpper();

					string[] data = type.Split(' ');

					if(data[0].StartsWith("ENUM"))
					{
						dataTypeNameComplete = "ENUM" + origType.Substring(4, origType.Length - 4);
					}
					else
					{
						if(-1 != type.IndexOf("UNSIGNED"))
						{
							dataTypeNameComplete = data[0] + " UNSIGNED";
						}
						else
						{
							dataTypeNameComplete = data[0];
						}
					}
				}
				catch
				{
					dataTypeNameComplete = "ERROR";
				}

                return dataTypeNameComplete.Replace("\'", string.Empty);
			}
		}

		public override Int32 NumericPrecision
		{
			get
			{
				return precision;
			}
		}

		public override Int32 NumericScale
		{
			get
			{
				return numericScale;
			}
		}

		public override Int32 CharacterMaxLength
		{
			get
			{
				return characterLength;
			}
		}
	}
}
