
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2024.1.4.0
EntitySpaces Driver  : MySql
Date Generated       : 19.01.2024 22:09:28
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



// ReSharper disable InconsistentNaming

namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'suppliers' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Suppliers))]	
	[XmlType("Suppliers")]
	public partial class Suppliers : esSuppliers
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Suppliers();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 supplierID)
		{
			var obj = new Suppliers();
			obj.SupplierID = supplierID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 supplierID, esSqlAccessType sqlAccessType)
		{
			var obj = new Suppliers();
			obj.SupplierID = supplierID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("SuppliersCollection")]
	public partial class SuppliersCollection : esSuppliersCollection, IEnumerable<Suppliers>
	{
		public Suppliers FindByPrimaryKey(System.Int32 supplierID)
		{
			return this.SingleOrDefault(e => e.SupplierID == supplierID);
		}

		
				
	}



	[Serializable]	
	public partial class SuppliersQuery : esSuppliersQuery
	{
		public SuppliersQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public SuppliersQuery(string joinAlias, out SuppliersQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "SuppliersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SuppliersQuery query)
		{
			return SuppliersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SuppliersQuery(string query)
		{
			return (SuppliersQuery)SuppliersQuery.SerializeHelper.FromXml(query, typeof(SuppliersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esSuppliers : esEntity
	{
		public esSuppliers()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 supplierID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(supplierID);
			else
				return LoadByPrimaryKeyStoredProcedure(supplierID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 supplierID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(supplierID);
			else
				return LoadByPrimaryKeyStoredProcedure(supplierID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 supplierID)
		{
			SuppliersQuery query = new SuppliersQuery();
			query.Where(query.SupplierID == supplierID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 supplierID)
		{
			esParameters parms = new esParameters();
			parms.Add("SupplierID", supplierID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to suppliers.SupplierID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? SupplierID
		{
			get => GetSystemInt32(SuppliersMetadata.ColumnNames.SupplierID);
			
			set
			{
				if (!SetSystemInt32(SuppliersMetadata.ColumnNames.SupplierID, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.SupplierID);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.CompanyName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CompanyName
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.CompanyName);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.CompanyName, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.CompanyName);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.ContactName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ContactName
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.ContactName);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.ContactName, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.ContactName);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.ContactTitle
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ContactTitle
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.ContactTitle);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.ContactTitle, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.ContactTitle);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Address
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.Address);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.Address, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.Address);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String City
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.City);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.City, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.City);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.Region
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Region
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.Region);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.Region, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.Region);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String PostalCode
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.PostalCode);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.PostalCode, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.PostalCode);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.Country
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Country
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.Country);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.Country, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.Country);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Phone
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.Phone);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.Phone, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.Phone);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.Fax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Fax
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.Fax);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.Fax, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.Fax);
			}
		}		
		
		/// <summary>
		/// Maps to suppliers.HomePage
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String HomePage
		{
			get => GetSystemString(SuppliersMetadata.ColumnNames.HomePage);
			
			set
			{
				if (!SetSystemString(SuppliersMetadata.ColumnNames.HomePage, value)) return;
				
				OnPropertyChanged(SuppliersMetadata.PropertyNames.HomePage);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => SuppliersMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public SuppliersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new SuppliersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(SuppliersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(SuppliersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SuppliersQuery query;		
	}



	[Serializable]
	public abstract class esSuppliersCollection : esEntityCollection<Suppliers>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => SuppliersMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "SuppliersCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public SuppliersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new SuppliersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(SuppliersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new SuppliersQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(SuppliersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((SuppliersQuery)paraQuery);
		}

		#endregion
		
		private SuppliersQuery query;
	}



	[Serializable]
	public abstract class esSuppliersQuery : esDynamicQuery
	{
		protected override IMetadata Meta => SuppliersMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "SupplierID" => SupplierID,
              "CompanyName" => CompanyName,
              "ContactName" => ContactName,
              "ContactTitle" => ContactTitle,
              "Address" => Address,
              "City" => City,
              "Region" => Region,
              "PostalCode" => PostalCode,
              "Country" => Country,
              "Phone" => Phone,
              "Fax" => Fax,
              "HomePage" => HomePage,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem SupplierID => new (this, SuppliersMetadata.ColumnNames.SupplierID, esSystemType.Int32);
		
		public esQueryItem CompanyName => new (this, SuppliersMetadata.ColumnNames.CompanyName, esSystemType.String);
		
		public esQueryItem ContactName => new (this, SuppliersMetadata.ColumnNames.ContactName, esSystemType.String);
		
		public esQueryItem ContactTitle => new (this, SuppliersMetadata.ColumnNames.ContactTitle, esSystemType.String);
		
		public esQueryItem Address => new (this, SuppliersMetadata.ColumnNames.Address, esSystemType.String);
		
		public esQueryItem City => new (this, SuppliersMetadata.ColumnNames.City, esSystemType.String);
		
		public esQueryItem Region => new (this, SuppliersMetadata.ColumnNames.Region, esSystemType.String);
		
		public esQueryItem PostalCode => new (this, SuppliersMetadata.ColumnNames.PostalCode, esSystemType.String);
		
		public esQueryItem Country => new (this, SuppliersMetadata.ColumnNames.Country, esSystemType.String);
		
		public esQueryItem Phone => new (this, SuppliersMetadata.ColumnNames.Phone, esSystemType.String);
		
		public esQueryItem Fax => new (this, SuppliersMetadata.ColumnNames.Fax, esSystemType.String);
		
		public esQueryItem HomePage => new (this, SuppliersMetadata.ColumnNames.HomePage, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Suppliers : esSuppliers
	{

		#region ProductsBySupplierID - Zero To Many
		
		public static esPrefetchMap Prefetch_ProductsBySupplierID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = ProductsBySupplierID_Delegate,
					PropertyName = "ProductsBySupplierID",
					MyColumnName = "SupplierID",
					ParentColumnName = "SupplierID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void ProductsBySupplierID_Delegate(esPrefetchParameters data)
		{
			var parent = new SuppliersQuery(data.NextAlias());
			var me = data.You != null ? data.You as ProductsQuery : new ProductsQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.SupplierID == me?.SupplierID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Products_Suppliers
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeProductsBySupplierID()
		{
			return _ProductsBySupplierID is { Count: > 0 };
		}	
		

		[DataMember(Name="ProductsBySupplierID", EmitDefaultValue = false)]
		public ProductsCollection ProductsBySupplierID
		{
			get
			{
				if (_ProductsBySupplierID != null) return _ProductsBySupplierID;
				
				_ProductsBySupplierID = new ProductsCollection();
				_ProductsBySupplierID.es.Connection.Name = es.Connection.Name;
				SetPostSave("ProductsBySupplierID", _ProductsBySupplierID);
				
				// ReSharper disable once InvertIf
				if (SupplierID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_ProductsBySupplierID.Query.Where(_ProductsBySupplierID.Query.SupplierID == SupplierID);
						_ProductsBySupplierID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_ProductsBySupplierID.fks.Add(ProductsMetadata.ColumnNames.SupplierID, this.SupplierID);
				}

				return _ProductsBySupplierID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_ProductsBySupplierID == null) return;
				RemovePostSave("ProductsBySupplierID"); 
				_ProductsBySupplierID = null;
				OnPropertyChanged("ProductsBySupplierID");
			} 			
		}
		
			
		
		private ProductsCollection _ProductsBySupplierID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "ProductsBySupplierID":
					coll = this.ProductsBySupplierID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			var props = new List<esPropertyDescriptor>();
			props.Add(new esPropertyDescriptor(this, "ProductsBySupplierID", typeof(ProductsCollection), new Products()));
			return props;
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._ProductsBySupplierID != null)
			{
				Apply(this._ProductsBySupplierID, "SupplierID", this.SupplierID);
			}
		}
		
	}
	



	[Serializable]
	public partial class SuppliersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SuppliersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.SupplierID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.SupplierID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CompanyName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CompanyName;
			c.CharacterMaxLength = 40;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ContactName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ContactName;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ContactTitle, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ContactTitle;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Address, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Address;
			c.CharacterMaxLength = 60;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.City, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.City;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Region, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Region;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.PostalCode, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.PostalCode;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Country, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Country;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Phone, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Phone;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Fax, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Fax;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.HomePage, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.HomePage;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static SuppliersMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string SupplierID = "SupplierID";
			 public const string CompanyName = "CompanyName";
			 public const string ContactName = "ContactName";
			 public const string ContactTitle = "ContactTitle";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string Phone = "Phone";
			 public const string Fax = "Fax";
			 public const string HomePage = "HomePage";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string SupplierID = "SupplierID";
			 public const string CompanyName = "CompanyName";
			 public const string ContactName = "ContactName";
			 public const string ContactTitle = "ContactTitle";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string Phone = "Phone";
			 public const string Fax = "Fax";
			 public const string HomePage = "HomePage";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			var mapMethod = mapDelegates[mapName];
      return mapMethod?.Invoke(mapName);
		}
		
		#region MAP esDefault
		
		private static int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(SuppliersMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new SuppliersMetadata();
				var mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			// ReSharper disable once InvertIf
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				var specMeta = new esProviderSpecificMetadata();			


				specMeta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("CompanyName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ContactName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ContactTitle", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Phone", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Fax", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("HomePage", new esTypeMap("MEDIUMTEXT", "System.String"));			
				
				
				
				specMeta.Source = "suppliers";
				specMeta.Destination = "suppliers";
				
				specMeta.spInsert = "proc_suppliersInsert";				
				specMeta.spUpdate = "proc_suppliersUpdate";		
				specMeta.spDelete = "proc_suppliersDelete";
				specMeta.spLoadAll = "proc_suppliersLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_suppliersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static SuppliersMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
