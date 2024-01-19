
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
	/// Encapsulates the 'shippers' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Shippers))]	
	[XmlType("Shippers")]
	public partial class Shippers : esShippers
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Shippers();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 shipperID)
		{
			var obj = new Shippers();
			obj.ShipperID = shipperID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 shipperID, esSqlAccessType sqlAccessType)
		{
			var obj = new Shippers();
			obj.ShipperID = shipperID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ShippersCollection")]
	public partial class ShippersCollection : esShippersCollection, IEnumerable<Shippers>
	{
		public Shippers FindByPrimaryKey(System.Int32 shipperID)
		{
			return this.SingleOrDefault(e => e.ShipperID == shipperID);
		}

		
				
	}



	[Serializable]	
	public partial class ShippersQuery : esShippersQuery
	{
		public ShippersQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public ShippersQuery(string joinAlias, out ShippersQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "ShippersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ShippersQuery query)
		{
			return ShippersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ShippersQuery(string query)
		{
			return (ShippersQuery)ShippersQuery.SerializeHelper.FromXml(query, typeof(ShippersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esShippers : esEntity
	{
		public esShippers()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 shipperID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(shipperID);
			else
				return LoadByPrimaryKeyStoredProcedure(shipperID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 shipperID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(shipperID);
			else
				return LoadByPrimaryKeyStoredProcedure(shipperID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 shipperID)
		{
			ShippersQuery query = new ShippersQuery();
			query.Where(query.ShipperID == shipperID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 shipperID)
		{
			esParameters parms = new esParameters();
			parms.Add("ShipperID", shipperID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to shippers.ShipperID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? ShipperID
		{
			get => GetSystemInt32(ShippersMetadata.ColumnNames.ShipperID);
			
			set
			{
				if (!SetSystemInt32(ShippersMetadata.ColumnNames.ShipperID, value)) return;
				
				OnPropertyChanged(ShippersMetadata.PropertyNames.ShipperID);
			}
		}		
		
		/// <summary>
		/// Maps to shippers.CompanyName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CompanyName
		{
			get => GetSystemString(ShippersMetadata.ColumnNames.CompanyName);
			
			set
			{
				if (!SetSystemString(ShippersMetadata.ColumnNames.CompanyName, value)) return;
				
				OnPropertyChanged(ShippersMetadata.PropertyNames.CompanyName);
			}
		}		
		
		/// <summary>
		/// Maps to shippers.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Phone
		{
			get => GetSystemString(ShippersMetadata.ColumnNames.Phone);
			
			set
			{
				if (!SetSystemString(ShippersMetadata.ColumnNames.Phone, value)) return;
				
				OnPropertyChanged(ShippersMetadata.PropertyNames.Phone);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => ShippersMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public ShippersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new ShippersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(ShippersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(ShippersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ShippersQuery query;		
	}



	[Serializable]
	public abstract class esShippersCollection : esEntityCollection<Shippers>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => ShippersMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "ShippersCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public ShippersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new ShippersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(ShippersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new ShippersQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(ShippersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((ShippersQuery)paraQuery);
		}

		#endregion
		
		private ShippersQuery query;
	}



	[Serializable]
	public abstract class esShippersQuery : esDynamicQuery
	{
		protected override IMetadata Meta => ShippersMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "ShipperID" => ShipperID,
              "CompanyName" => CompanyName,
              "Phone" => Phone,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ShipperID => new (this, ShippersMetadata.ColumnNames.ShipperID, esSystemType.Int32);
		
		public esQueryItem CompanyName => new (this, ShippersMetadata.ColumnNames.CompanyName, esSystemType.String);
		
		public esQueryItem Phone => new (this, ShippersMetadata.ColumnNames.Phone, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Shippers : esShippers
	{

		#region OrdersByShipVia - Zero To Many
		
		public static esPrefetchMap Prefetch_OrdersByShipVia
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = OrdersByShipVia_Delegate,
					PropertyName = "OrdersByShipVia",
					MyColumnName = "ShipVia",
					ParentColumnName = "ShipperID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void OrdersByShipVia_Delegate(esPrefetchParameters data)
		{
			var parent = new ShippersQuery(data.NextAlias());
			var me = data.You != null ? data.You as OrdersQuery : new OrdersQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.ShipperID == me?.ShipVia);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Orders_Shippers
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeOrdersByShipVia()
		{
			return _OrdersByShipVia is { Count: > 0 };
		}	
		

		[DataMember(Name="OrdersByShipVia", EmitDefaultValue = false)]
		public OrdersCollection OrdersByShipVia
		{
			get
			{
				if (_OrdersByShipVia != null) return _OrdersByShipVia;
				
				_OrdersByShipVia = new OrdersCollection();
				_OrdersByShipVia.es.Connection.Name = es.Connection.Name;
				SetPostSave("OrdersByShipVia", _OrdersByShipVia);
				
				// ReSharper disable once InvertIf
				if (ShipperID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_OrdersByShipVia.Query.Where(_OrdersByShipVia.Query.ShipVia == ShipperID);
						_OrdersByShipVia.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_OrdersByShipVia.fks.Add(OrdersMetadata.ColumnNames.ShipVia, this.ShipperID);
				}

				return _OrdersByShipVia;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_OrdersByShipVia == null) return;
				RemovePostSave("OrdersByShipVia"); 
				_OrdersByShipVia = null;
				OnPropertyChanged("OrdersByShipVia");
			} 			
		}
		
			
		
		private OrdersCollection _OrdersByShipVia;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrdersByShipVia":
					coll = this.OrdersByShipVia;
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
			props.Add(new esPropertyDescriptor(this, "OrdersByShipVia", typeof(OrdersCollection), new Orders()));
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
			if(this._OrdersByShipVia != null)
			{
				Apply(this._OrdersByShipVia, "ShipVia", this.ShipperID);
			}
		}
		
	}
	



	[Serializable]
	public partial class ShippersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ShippersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.ShipperID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.ShipperID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CompanyName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CompanyName;
			c.CharacterMaxLength = 40;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Phone, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Phone;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static ShippersMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string ShipperID = "ShipperID";
			 public const string CompanyName = "CompanyName";
			 public const string Phone = "Phone";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ShipperID = "ShipperID";
			 public const string CompanyName = "CompanyName";
			 public const string Phone = "Phone";
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
			lock (typeof(ShippersMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new ShippersMetadata();
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


				specMeta.AddTypeMap("ShipperID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("CompanyName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Phone", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				specMeta.Source = "shippers";
				specMeta.Destination = "shippers";
				
				specMeta.spInsert = "proc_shippersInsert";				
				specMeta.spUpdate = "proc_shippersUpdate";		
				specMeta.spDelete = "proc_shippersDelete";
				specMeta.spLoadAll = "proc_shippersLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_shippersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static ShippersMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
