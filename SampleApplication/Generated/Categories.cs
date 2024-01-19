
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
	/// Encapsulates the 'categories' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Categories))]	
	[XmlType("Categories")]
	public partial class Categories : esCategories
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Categories();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 categoryID)
		{
			var obj = new Categories();
			obj.CategoryID = categoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 categoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new Categories();
			obj.CategoryID = categoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CategoriesCollection")]
	public partial class CategoriesCollection : esCategoriesCollection, IEnumerable<Categories>
	{
		public Categories FindByPrimaryKey(System.Int32 categoryID)
		{
			return this.SingleOrDefault(e => e.CategoryID == categoryID);
		}

		
				
	}



	[Serializable]	
	public partial class CategoriesQuery : esCategoriesQuery
	{
		public CategoriesQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public CategoriesQuery(string joinAlias, out CategoriesQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "CategoriesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CategoriesQuery query)
		{
			return CategoriesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CategoriesQuery(string query)
		{
			return (CategoriesQuery)CategoriesQuery.SerializeHelper.FromXml(query, typeof(CategoriesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esCategories : esEntity
	{
		public esCategories()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 categoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(categoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(categoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 categoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(categoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(categoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 categoryID)
		{
			CategoriesQuery query = new CategoriesQuery();
			query.Where(query.CategoryID == categoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 categoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("CategoryID", categoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to categories.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? CategoryID
		{
			get => GetSystemInt32(CategoriesMetadata.ColumnNames.CategoryID);
			
			set
			{
				if (!SetSystemInt32(CategoriesMetadata.ColumnNames.CategoryID, value)) return;
				
				OnPropertyChanged(CategoriesMetadata.PropertyNames.CategoryID);
			}
		}		
		
		/// <summary>
		/// Maps to categories.CategoryName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CategoryName
		{
			get => GetSystemString(CategoriesMetadata.ColumnNames.CategoryName);
			
			set
			{
				if (!SetSystemString(CategoriesMetadata.ColumnNames.CategoryName, value)) return;
				
				OnPropertyChanged(CategoriesMetadata.PropertyNames.CategoryName);
			}
		}		
		
		/// <summary>
		/// Maps to categories.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Description
		{
			get => GetSystemString(CategoriesMetadata.ColumnNames.Description);
			
			set
			{
				if (!SetSystemString(CategoriesMetadata.ColumnNames.Description, value)) return;
				
				OnPropertyChanged(CategoriesMetadata.PropertyNames.Description);
			}
		}		
		
		/// <summary>
		/// Maps to categories.Picture
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Byte[] Picture
		{
			get => GetSystemByteArray(CategoriesMetadata.ColumnNames.Picture);
			
			set
			{
				if (!SetSystemByteArray(CategoriesMetadata.ColumnNames.Picture, value)) return;
				
				OnPropertyChanged(CategoriesMetadata.PropertyNames.Picture);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => CategoriesMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public CategoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CategoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CategoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(CategoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CategoriesQuery query;		
	}



	[Serializable]
	public abstract class esCategoriesCollection : esEntityCollection<Categories>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => CategoriesMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "CategoriesCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public CategoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CategoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CategoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new CategoriesQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(CategoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((CategoriesQuery)paraQuery);
		}

		#endregion
		
		private CategoriesQuery query;
	}



	[Serializable]
	public abstract class esCategoriesQuery : esDynamicQuery
	{
		protected override IMetadata Meta => CategoriesMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "CategoryID" => CategoryID,
              "CategoryName" => CategoryName,
              "Description" => Description,
              "Picture" => Picture,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CategoryID => new (this, CategoriesMetadata.ColumnNames.CategoryID, esSystemType.Int32);
		
		public esQueryItem CategoryName => new (this, CategoriesMetadata.ColumnNames.CategoryName, esSystemType.String);
		
		public esQueryItem Description => new (this, CategoriesMetadata.ColumnNames.Description, esSystemType.String);
		
		public esQueryItem Picture => new (this, CategoriesMetadata.ColumnNames.Picture, esSystemType.ByteArray);
		
		#endregion
		
	}


	
	public partial class Categories : esCategories
	{

		#region ProductsByCategoryID - Zero To Many
		
		public static esPrefetchMap Prefetch_ProductsByCategoryID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = ProductsByCategoryID_Delegate,
					PropertyName = "ProductsByCategoryID",
					MyColumnName = "CategoryID",
					ParentColumnName = "CategoryID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void ProductsByCategoryID_Delegate(esPrefetchParameters data)
		{
			var parent = new CategoriesQuery(data.NextAlias());
			var me = data.You != null ? data.You as ProductsQuery : new ProductsQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.CategoryID == me?.CategoryID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Products_Categories
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeProductsByCategoryID()
		{
			return _ProductsByCategoryID is { Count: > 0 };
		}	
		

		[DataMember(Name="ProductsByCategoryID", EmitDefaultValue = false)]
		public ProductsCollection ProductsByCategoryID
		{
			get
			{
				if (_ProductsByCategoryID != null) return _ProductsByCategoryID;
				
				_ProductsByCategoryID = new ProductsCollection();
				_ProductsByCategoryID.es.Connection.Name = es.Connection.Name;
				SetPostSave("ProductsByCategoryID", _ProductsByCategoryID);
				
				// ReSharper disable once InvertIf
				if (CategoryID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_ProductsByCategoryID.Query.Where(_ProductsByCategoryID.Query.CategoryID == CategoryID);
						_ProductsByCategoryID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_ProductsByCategoryID.fks.Add(ProductsMetadata.ColumnNames.CategoryID, this.CategoryID);
				}

				return _ProductsByCategoryID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_ProductsByCategoryID == null) return;
				RemovePostSave("ProductsByCategoryID"); 
				_ProductsByCategoryID = null;
				OnPropertyChanged("ProductsByCategoryID");
			} 			
		}
		
			
		
		private ProductsCollection _ProductsByCategoryID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "ProductsByCategoryID":
					coll = this.ProductsByCategoryID;
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
			props.Add(new esPropertyDescriptor(this, "ProductsByCategoryID", typeof(ProductsCollection), new Products()));
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
			if(this._ProductsByCategoryID != null)
			{
				Apply(this._ProductsByCategoryID, "CategoryID", this.CategoryID);
			}
		}
		
	}
	



	[Serializable]
	public partial class CategoriesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CategoriesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.CategoryID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.CategoryID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CategoryName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CategoryName;
			c.CharacterMaxLength = 15;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Description;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Picture, 3, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = PropertyNames.Picture;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static CategoriesMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string CategoryID = "CategoryID";
			 public const string CategoryName = "CategoryName";
			 public const string Description = "Description";
			 public const string Picture = "Picture";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CategoryID = "CategoryID";
			 public const string CategoryName = "CategoryName";
			 public const string Description = "Description";
			 public const string Picture = "Picture";
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
			lock (typeof(CategoriesMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new CategoriesMetadata();
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


				specMeta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("CategoryName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Description", new esTypeMap("MEDIUMTEXT", "System.String"));
				specMeta.AddTypeMap("Picture", new esTypeMap("LONGBLOB", "System.Byte[]"));			
				
				
				
				specMeta.Source = "categories";
				specMeta.Destination = "categories";
				
				specMeta.spInsert = "proc_categoriesInsert";				
				specMeta.spUpdate = "proc_categoriesUpdate";		
				specMeta.spDelete = "proc_categoriesDelete";
				specMeta.spLoadAll = "proc_categoriesLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_categoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static CategoriesMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
