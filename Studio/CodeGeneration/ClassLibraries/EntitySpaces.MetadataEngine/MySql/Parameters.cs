namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlParameters : Parameters
	{
        internal override void LoadAll()
		{
			try
			{
//				DataTable metaData = this.LoadData(OleDbSchemaGuid.Procedure_Parameters, 
//					new object[]{this.Procedure.Database.Name, null, this.Procedure.Name});
//
//				PopulateArray(metaData);
			}
			catch {}
		}
	}
}
