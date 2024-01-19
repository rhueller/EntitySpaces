
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
	/// Encapsulates the 'customerdemographics' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Customerdemographics))]	
	[XmlType("Customerdemographics")]
	public partial class Customerdemographics : esCustomerdemographics
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Customerdemographics();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.String customerTypeID)
		{
			var obj = new Customerdemographics();
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.String customerTypeID, esSqlAccessType sqlAccessType)
		{
			var obj = new Customerdemographics();
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerdemographicsCollection")]
	public partial class CustomerdemographicsCollection : esCustomerdemographicsCollection, IEnumerable<Customerdemographics>
	{
		public Customerdemographics FindByPrimaryKey(System.String customerTypeID)
		{
			return this.SingleOrDefault(e => e.CustomerTypeID == customerTypeID);
		}

		
				
	}



	[Serializable]	
	public partial class CustomerdemographicsQuery : esCustomerdemographicsQuery
	{
		public CustomerdemographicsQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public CustomerdemographicsQuery(string joinAlias, out CustomerdemographicsQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "CustomerdemographicsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerdemographicsQuery query)
		{
			return CustomerdemographicsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerdemographicsQuery(string query)
		{
			return (CustomerdemographicsQuery)CustomerdemographicsQuery.SerializeHelper.FromXml(query, typeof(CustomerdemographicsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esCustomerdemographics : esEntity
	{
		public esCustomerdemographics()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerTypeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerTypeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerTypeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerTypeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerTypeID)
		{
			CustomerdemographicsQuery query = new CustomerdemographicsQuery();
			query.Where(query.CustomerTypeID == customerTypeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerTypeID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerTypeID", customerTypeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to customerdemographics.CustomerTypeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerTypeID
		{
			get => GetSystemString(CustomerdemographicsMetadata.ColumnNames.CustomerTypeID);
			
			set
			{
				if (!SetSystemString(CustomerdemographicsMetadata.ColumnNames.CustomerTypeID, value)) return;
				
				OnPropertyChanged(CustomerdemographicsMetadata.PropertyNames.CustomerTypeID);
			}
		}		
		
		/// <summary>
		/// Maps to customerdemographics.CustomerDesc
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerDesc
		{
			get => GetSystemString(CustomerdemographicsMetadata.ColumnNames.CustomerDesc);
			
			set
			{
				if (!SetSystemString(CustomerdemographicsMetadata.ColumnNames.CustomerDesc, value)) return;
				
				OnPropertyChanged(CustomerdemographicsMetadata.PropertyNames.CustomerDesc);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => CustomerdemographicsMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public CustomerdemographicsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomerdemographicsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomerdemographicsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(CustomerdemographicsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomerdemographicsQuery query;		
	}



	[Serializable]
	public abstract class esCustomerdemographicsCollection : esEntityCollection<Customerdemographics>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => CustomerdemographicsMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "CustomerdemographicsCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public CustomerdemographicsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomerdemographicsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomerdemographicsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new CustomerdemographicsQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(CustomerdemographicsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((CustomerdemographicsQuery)paraQuery);
		}

		#endregion
		
		private CustomerdemographicsQuery query;
	}



	[Serializable]
	public abstract class esCustomerdemographicsQuery : esDynamicQuery
	{
		protected override IMetadata Meta => CustomerdemographicsMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "CustomerTypeID" => CustomerTypeID,
              "CustomerDesc" => CustomerDesc,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerTypeID => new (this, CustomerdemographicsMetadata.ColumnNames.CustomerTypeID, esSystemType.String);
		
		public esQueryItem CustomerDesc => new (this, CustomerdemographicsMetadata.ColumnNames.CustomerDesc, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Customerdemographics : esCustomerdemographics
	{

		#region UpToCustomersByCustomercustomerdemo - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToCustomersByCustomercustomerdemo()
		{
			return _UpToCustomersByCustomercustomerdemo is { Count: > 0 };
		}
		

		[DataMember(Name="UpToCustomersByCustomercustomerdemo", EmitDefaultValue = false)]
		public CustomersCollection UpToCustomersByCustomercustomerdemo
		{
			get
			{
				if (_UpToCustomersByCustomercustomerdemo != null) return _UpToCustomersByCustomercustomerdemo;

				_UpToCustomersByCustomercustomerdemo = new CustomersCollection();
				_UpToCustomersByCustomercustomerdemo.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToCustomersByCustomercustomerdemo", _UpToCustomersByCustomercustomerdemo);

				if (es.IsLazyLoadDisabled || CustomerTypeID == null) return _UpToCustomersByCustomercustomerdemo;

				var m = new CustomersQuery("m");
				var j = new CustomercustomerdemoQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.CustomerID == j.CustomerID);
				m.Where(j.CustomerTypeID == CustomerTypeID);

				_UpToCustomersByCustomercustomerdemo.Load(m);

				return _UpToCustomersByCustomercustomerdemo;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToCustomersByCustomercustomerdemo != null) 
				{ 
					RemovePostSave("UpToCustomersByCustomercustomerdemo"); 
					_UpToCustomersByCustomercustomerdemo = null;
					OnPropertyChanged("UpToCustomersByCustomercustomerdemo");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		public void AssociateCustomersByCustomercustomerdemo(Customers entity)
		{
			if (this._CustomercustomerdemoCollection == null)
			{
				this._CustomercustomerdemoCollection = new CustomercustomerdemoCollection();
				this._CustomercustomerdemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomercustomerdemoCollection", this._CustomercustomerdemoCollection);
			}

			Customercustomerdemo obj = this._CustomercustomerdemoCollection.AddNew();
			obj.CustomerTypeID = this.CustomerTypeID;
			obj.CustomerID = entity.CustomerID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		public void DissociateCustomersByCustomercustomerdemo(Customers entity)
		{
			if (this._CustomercustomerdemoCollection == null)
			{
				this._CustomercustomerdemoCollection = new CustomercustomerdemoCollection();
				this._CustomercustomerdemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomercustomerdemoCollection", this._CustomercustomerdemoCollection);
			}

			Customercustomerdemo obj = this._CustomercustomerdemoCollection.AddNew();
			obj.CustomerTypeID = this.CustomerTypeID;
						obj.CustomerID = entity.CustomerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private CustomersCollection _UpToCustomersByCustomercustomerdemo;
		private CustomercustomerdemoCollection _CustomercustomerdemoCollection;
		#endregion

		#region CustomercustomerdemoByCustomerTypeID - Zero To Many
		
		public static esPrefetchMap Prefetch_CustomercustomerdemoByCustomerTypeID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = CustomercustomerdemoByCustomerTypeID_Delegate,
					PropertyName = "CustomercustomerdemoByCustomerTypeID",
					MyColumnName = "CustomerTypeID",
					ParentColumnName = "CustomerTypeID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void CustomercustomerdemoByCustomerTypeID_Delegate(esPrefetchParameters data)
		{
			var parent = new CustomerdemographicsQuery(data.NextAlias());
			var me = data.You != null ? data.You as CustomercustomerdemoQuery : new CustomercustomerdemoQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.CustomerTypeID == me?.CustomerTypeID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeCustomercustomerdemoByCustomerTypeID()
		{
			return _CustomercustomerdemoByCustomerTypeID is { Count: > 0 };
		}	
		

		[DataMember(Name="CustomercustomerdemoByCustomerTypeID", EmitDefaultValue = false)]
		public CustomercustomerdemoCollection CustomercustomerdemoByCustomerTypeID
		{
			get
			{
				if (_CustomercustomerdemoByCustomerTypeID != null) return _CustomercustomerdemoByCustomerTypeID;
				
				_CustomercustomerdemoByCustomerTypeID = new CustomercustomerdemoCollection();
				_CustomercustomerdemoByCustomerTypeID.es.Connection.Name = es.Connection.Name;
				SetPostSave("CustomercustomerdemoByCustomerTypeID", _CustomercustomerdemoByCustomerTypeID);
				
				// ReSharper disable once InvertIf
				if (CustomerTypeID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_CustomercustomerdemoByCustomerTypeID.Query.Where(_CustomercustomerdemoByCustomerTypeID.Query.CustomerTypeID == CustomerTypeID);
						_CustomercustomerdemoByCustomerTypeID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_CustomercustomerdemoByCustomerTypeID.fks.Add(CustomercustomerdemoMetadata.ColumnNames.CustomerTypeID, this.CustomerTypeID);
				}

				return _CustomercustomerdemoByCustomerTypeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_CustomercustomerdemoByCustomerTypeID == null) return;
				RemovePostSave("CustomercustomerdemoByCustomerTypeID"); 
				_CustomercustomerdemoByCustomerTypeID = null;
				OnPropertyChanged("CustomercustomerdemoByCustomerTypeID");
			} 			
		}
		
			
		
		private CustomercustomerdemoCollection _CustomercustomerdemoByCustomerTypeID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomercustomerdemoByCustomerTypeID":
					coll = this.CustomercustomerdemoByCustomerTypeID;
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
			props.Add(new esPropertyDescriptor(this, "CustomercustomerdemoByCustomerTypeID", typeof(CustomercustomerdemoCollection), new Customercustomerdemo()));
			return props;
		}
		
	}
	



	[Serializable]
	public partial class CustomerdemographicsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerdemographicsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.CustomerTypeID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerTypeID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CustomerDesc, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerDesc;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static CustomerdemographicsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string CustomerTypeID = "CustomerTypeID";
			 public const string CustomerDesc = "CustomerDesc";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerTypeID = "CustomerTypeID";
			 public const string CustomerDesc = "CustomerDesc";
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
			lock (typeof(CustomerdemographicsMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new CustomerdemographicsMetadata();
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


				specMeta.AddTypeMap("CustomerTypeID", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("CustomerDesc", new esTypeMap("MEDIUMTEXT", "System.String"));			
				
				
				
				specMeta.Source = "customerdemographics";
				specMeta.Destination = "customerdemographics";
				
				specMeta.spInsert = "proc_customerdemographicsInsert";				
				specMeta.spUpdate = "proc_customerdemographicsUpdate";		
				specMeta.spDelete = "proc_customerdemographicsDelete";
				specMeta.spLoadAll = "proc_customerdemographicsLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_customerdemographicsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static CustomerdemographicsMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
