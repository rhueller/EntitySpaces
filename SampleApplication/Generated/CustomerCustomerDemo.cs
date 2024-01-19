
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
	/// Encapsulates the 'customercustomerdemo' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Customercustomerdemo))]	
	[XmlType("Customercustomerdemo")]
	public partial class Customercustomerdemo : esCustomercustomerdemo
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Customercustomerdemo();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.String customerID, System.String customerTypeID)
		{
			var obj = new Customercustomerdemo();
			obj.CustomerID = customerID;
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.String customerID, System.String customerTypeID, esSqlAccessType sqlAccessType)
		{
			var obj = new Customercustomerdemo();
			obj.CustomerID = customerID;
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomercustomerdemoCollection")]
	public partial class CustomercustomerdemoCollection : esCustomercustomerdemoCollection, IEnumerable<Customercustomerdemo>
	{
		public Customercustomerdemo FindByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID && e.CustomerTypeID == customerTypeID);
		}

		
				
	}



	[Serializable]	
	public partial class CustomercustomerdemoQuery : esCustomercustomerdemoQuery
	{
		public CustomercustomerdemoQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public CustomercustomerdemoQuery(string joinAlias, out CustomercustomerdemoQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "CustomercustomerdemoQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomercustomerdemoQuery query)
		{
			return CustomercustomerdemoQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomercustomerdemoQuery(string query)
		{
			return (CustomercustomerdemoQuery)CustomercustomerdemoQuery.SerializeHelper.FromXml(query, typeof(CustomercustomerdemoQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esCustomercustomerdemo : esEntity
	{
		public esCustomercustomerdemo()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerID, System.String customerTypeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerID, System.String customerTypeID)
		{
			CustomercustomerdemoQuery query = new CustomercustomerdemoQuery();
			query.Where(query.CustomerID == customerID, query.CustomerTypeID == customerTypeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerID, System.String customerTypeID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);			parms.Add("CustomerTypeID", customerTypeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to customercustomerdemo.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerID
		{
			get => GetSystemString(CustomercustomerdemoMetadata.ColumnNames.CustomerID);
			
			set
			{
				if (!SetSystemString(CustomercustomerdemoMetadata.ColumnNames.CustomerID, value)) return;
				
				_UpToCustomersByCustomerID = null;
				OnPropertyChanged("UpToCustomersByCustomerID");
				OnPropertyChanged(CustomercustomerdemoMetadata.PropertyNames.CustomerID);
			}
		}		
		
		/// <summary>
		/// Maps to customercustomerdemo.CustomerTypeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerTypeID
		{
			get => GetSystemString(CustomercustomerdemoMetadata.ColumnNames.CustomerTypeID);
			
			set
			{
				if (!SetSystemString(CustomercustomerdemoMetadata.ColumnNames.CustomerTypeID, value)) return;
				
				_UpToCustomerdemographicsByCustomerTypeID = null;
				OnPropertyChanged("UpToCustomerdemographicsByCustomerTypeID");
				OnPropertyChanged(CustomercustomerdemoMetadata.PropertyNames.CustomerTypeID);
			}
		}		
		
		
		protected internal Customerdemographics _UpToCustomerdemographicsByCustomerTypeID;
		
		protected internal Customers _UpToCustomersByCustomerID;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => CustomercustomerdemoMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public CustomercustomerdemoQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomercustomerdemoQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomercustomerdemoQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(CustomercustomerdemoQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomercustomerdemoQuery query;		
	}



	[Serializable]
	public abstract class esCustomercustomerdemoCollection : esEntityCollection<Customercustomerdemo>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => CustomercustomerdemoMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "CustomercustomerdemoCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public CustomercustomerdemoQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomercustomerdemoQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomercustomerdemoQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new CustomercustomerdemoQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(CustomercustomerdemoQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((CustomercustomerdemoQuery)paraQuery);
		}

		#endregion
		
		private CustomercustomerdemoQuery query;
	}



	[Serializable]
	public abstract class esCustomercustomerdemoQuery : esDynamicQuery
	{
		protected override IMetadata Meta => CustomercustomerdemoMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "CustomerID" => CustomerID,
              "CustomerTypeID" => CustomerTypeID,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID => new (this, CustomercustomerdemoMetadata.ColumnNames.CustomerID, esSystemType.String);
		
		public esQueryItem CustomerTypeID => new (this, CustomercustomerdemoMetadata.ColumnNames.CustomerTypeID, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Customercustomerdemo : esCustomercustomerdemo
	{

				
				
		#region UpToCustomerdemographicsByCustomerTypeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToCustomerdemographicsByCustomerTypeID()
		{
				return _UpToCustomerdemographicsByCustomerTypeID != null;
		}
		

		[DataMember(Name="UpToCustomerdemographicsByCustomerTypeID", EmitDefaultValue = false)]
					
		public Customerdemographics UpToCustomerdemographicsByCustomerTypeID
		{
			get
			{
				if (_UpToCustomerdemographicsByCustomerTypeID != null) return _UpToCustomerdemographicsByCustomerTypeID;
				
				_UpToCustomerdemographicsByCustomerTypeID = new Customerdemographics();
				_UpToCustomerdemographicsByCustomerTypeID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToCustomerdemographicsByCustomerTypeID", _UpToCustomerdemographicsByCustomerTypeID);

				if (_UpToCustomerdemographicsByCustomerTypeID == null && CustomerTypeID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToCustomerdemographicsByCustomerTypeID;
					
					_UpToCustomerdemographicsByCustomerTypeID.Query.Where(_UpToCustomerdemographicsByCustomerTypeID.Query.CustomerTypeID == CustomerTypeID);
					_UpToCustomerdemographicsByCustomerTypeID.Query.Load();
				}
				return _UpToCustomerdemographicsByCustomerTypeID;
			}
			
			set
			{
				RemovePreSave("UpToCustomerdemographicsByCustomerTypeID");
				
				var changed = _UpToCustomerdemographicsByCustomerTypeID != value;

				if (value == null)
				{
					CustomerTypeID = null;
					_UpToCustomerdemographicsByCustomerTypeID = null;
				}
				else
				{
					CustomerTypeID = value.CustomerTypeID;
					_UpToCustomerdemographicsByCustomerTypeID = value;
					SetPreSave("UpToCustomerdemographicsByCustomerTypeID", _UpToCustomerdemographicsByCustomerTypeID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToCustomerdemographicsByCustomerTypeID");
				}
			}
		}
		#endregion
		

				
				
		#region UpToCustomersByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToCustomersByCustomerID()
		{
				return _UpToCustomersByCustomerID != null;
		}
		

		[DataMember(Name="UpToCustomersByCustomerID", EmitDefaultValue = false)]
					
		public Customers UpToCustomersByCustomerID
		{
			get
			{
				if (_UpToCustomersByCustomerID != null) return _UpToCustomersByCustomerID;
				
				_UpToCustomersByCustomerID = new Customers();
				_UpToCustomersByCustomerID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToCustomersByCustomerID", _UpToCustomersByCustomerID);

				if (_UpToCustomersByCustomerID == null && CustomerID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToCustomersByCustomerID;
					
					_UpToCustomersByCustomerID.Query.Where(_UpToCustomersByCustomerID.Query.CustomerID == CustomerID);
					_UpToCustomersByCustomerID.Query.Load();
				}
				return _UpToCustomersByCustomerID;
			}
			
			set
			{
				RemovePreSave("UpToCustomersByCustomerID");
				
				var changed = _UpToCustomersByCustomerID != value;

				if (value == null)
				{
					CustomerID = null;
					_UpToCustomersByCustomerID = null;
				}
				else
				{
					CustomerID = value.CustomerID;
					_UpToCustomersByCustomerID = value;
					SetPreSave("UpToCustomersByCustomerID", _UpToCustomersByCustomerID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToCustomersByCustomerID");
				}
			}
		}
		#endregion
		

		
		
	}
	



	[Serializable]
	public partial class CustomercustomerdemoMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomercustomerdemoMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.CustomerID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CustomerTypeID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerTypeID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static CustomercustomerdemoMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CustomerTypeID = "CustomerTypeID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CustomerTypeID = "CustomerTypeID";
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
			lock (typeof(CustomercustomerdemoMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new CustomercustomerdemoMetadata();
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


				specMeta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("CustomerTypeID", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				specMeta.Source = "customercustomerdemo";
				specMeta.Destination = "customercustomerdemo";
				
				specMeta.spInsert = "proc_customercustomerdemoInsert";				
				specMeta.spUpdate = "proc_customercustomerdemoUpdate";		
				specMeta.spDelete = "proc_customercustomerdemoDelete";
				specMeta.spLoadAll = "proc_customercustomerdemoLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_customercustomerdemoLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static CustomercustomerdemoMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
