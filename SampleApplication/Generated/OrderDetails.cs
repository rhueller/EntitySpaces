
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
	/// Encapsulates the 'order details' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(OrderDetails))]	
	[XmlType("OrderDetails")]
	public partial class OrderDetails : esOrderDetails
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new OrderDetails();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 orderID, System.Int32 productID)
		{
			var obj = new OrderDetails();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 orderID, System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new OrderDetails();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OrderDetailsCollection")]
	public partial class OrderDetailsCollection : esOrderDetailsCollection, IEnumerable<OrderDetails>
	{
		public OrderDetails FindByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID && e.ProductID == productID);
		}

		
				
	}



	[Serializable]	
	public partial class OrderDetailsQuery : esOrderDetailsQuery
	{
		public OrderDetailsQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public OrderDetailsQuery(string joinAlias, out OrderDetailsQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "OrderDetailsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrderDetailsQuery query)
		{
			return OrderDetailsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrderDetailsQuery(string query)
		{
			return (OrderDetailsQuery)OrderDetailsQuery.SerializeHelper.FromXml(query, typeof(OrderDetailsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esOrderDetails : esEntity
	{
		public esOrderDetails()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID, productID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID, productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 orderID, System.Int32 productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID, productID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID, productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 orderID, System.Int32 productID)
		{
			OrderDetailsQuery query = new OrderDetailsQuery();
			query.Where(query.OrderID == orderID, query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 orderID, System.Int32 productID)
		{
			esParameters parms = new esParameters();
			parms.Add("OrderID", orderID);			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to order details.OrderID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? OrderID
		{
			get => GetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID);
			
			set
			{
				if (!SetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID, value)) return;
				
				_UpToOrdersByOrderID = null;
				OnPropertyChanged("UpToOrdersByOrderID");
				OnPropertyChanged(OrderDetailsMetadata.PropertyNames.OrderID);
			}
		}		
		
		/// <summary>
		/// Maps to order details.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? ProductID
		{
			get => GetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID);
			
			set
			{
				if (!SetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID, value)) return;
				
				_UpToProductsByProductID = null;
				OnPropertyChanged("UpToProductsByProductID");
				OnPropertyChanged(OrderDetailsMetadata.PropertyNames.ProductID);
			}
		}		
		
		/// <summary>
		/// Maps to order details.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Decimal? UnitPrice
		{
			get => GetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice);
			
			set
			{
				if (!SetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice, value)) return;
				
				OnPropertyChanged(OrderDetailsMetadata.PropertyNames.UnitPrice);
			}
		}		
		
		/// <summary>
		/// Maps to order details.Quantity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int16? Quantity
		{
			get => GetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity);
			
			set
			{
				if (!SetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity, value)) return;
				
				OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Quantity);
			}
		}		
		
		/// <summary>
		/// Maps to order details.Discount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Double? Discount
		{
			get => GetSystemDouble(OrderDetailsMetadata.ColumnNames.Discount);
			
			set
			{
				if (!SetSystemDouble(OrderDetailsMetadata.ColumnNames.Discount, value)) return;
				
				OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Discount);
			}
		}		
		
		
		protected internal Orders _UpToOrdersByOrderID;
		
		protected internal Products _UpToProductsByProductID;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => OrderDetailsMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public OrderDetailsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new OrderDetailsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(OrderDetailsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(OrderDetailsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OrderDetailsQuery query;		
	}



	[Serializable]
	public abstract class esOrderDetailsCollection : esEntityCollection<OrderDetails>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => OrderDetailsMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "OrderDetailsCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public OrderDetailsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new OrderDetailsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(OrderDetailsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new OrderDetailsQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(OrderDetailsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((OrderDetailsQuery)paraQuery);
		}

		#endregion
		
		private OrderDetailsQuery query;
	}



	[Serializable]
	public abstract class esOrderDetailsQuery : esDynamicQuery
	{
		protected override IMetadata Meta => OrderDetailsMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "OrderID" => OrderID,
              "ProductID" => ProductID,
              "UnitPrice" => UnitPrice,
              "Quantity" => Quantity,
              "Discount" => Discount,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem OrderID => new (this, OrderDetailsMetadata.ColumnNames.OrderID, esSystemType.Int32);
		
		public esQueryItem ProductID => new (this, OrderDetailsMetadata.ColumnNames.ProductID, esSystemType.Int32);
		
		public esQueryItem UnitPrice => new (this, OrderDetailsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal);
		
		public esQueryItem Quantity => new (this, OrderDetailsMetadata.ColumnNames.Quantity, esSystemType.Int16);
		
		public esQueryItem Discount => new (this, OrderDetailsMetadata.ColumnNames.Discount, esSystemType.Double);
		
		#endregion
		
	}


	
	public partial class OrderDetails : esOrderDetails
	{

				
				
		#region UpToOrdersByOrderID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToOrdersByOrderID()
		{
				return _UpToOrdersByOrderID != null;
		}
		

		[DataMember(Name="UpToOrdersByOrderID", EmitDefaultValue = false)]
					
		public Orders UpToOrdersByOrderID
		{
			get
			{
				if (_UpToOrdersByOrderID != null) return _UpToOrdersByOrderID;
				
				_UpToOrdersByOrderID = new Orders();
				_UpToOrdersByOrderID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToOrdersByOrderID", _UpToOrdersByOrderID);

				if (_UpToOrdersByOrderID == null && OrderID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToOrdersByOrderID;
					
					_UpToOrdersByOrderID.Query.Where(_UpToOrdersByOrderID.Query.OrderID == OrderID);
					_UpToOrdersByOrderID.Query.Load();
				}
				return _UpToOrdersByOrderID;
			}
			
			set
			{
				RemovePreSave("UpToOrdersByOrderID");
				
				var changed = _UpToOrdersByOrderID != value;

				if (value == null)
				{
					OrderID = null;
					_UpToOrdersByOrderID = null;
				}
				else
				{
					OrderID = value.OrderID;
					_UpToOrdersByOrderID = value;
					SetPreSave("UpToOrdersByOrderID", _UpToOrdersByOrderID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToOrdersByOrderID");
				}
			}
		}
		#endregion
		

				
				
		#region UpToProductsByProductID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToProductsByProductID()
		{
				return _UpToProductsByProductID != null;
		}
		

		[DataMember(Name="UpToProductsByProductID", EmitDefaultValue = false)]
					
		public Products UpToProductsByProductID
		{
			get
			{
				if (_UpToProductsByProductID != null) return _UpToProductsByProductID;
				
				_UpToProductsByProductID = new Products();
				_UpToProductsByProductID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToProductsByProductID", _UpToProductsByProductID);

				if (_UpToProductsByProductID == null && ProductID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToProductsByProductID;
					
					_UpToProductsByProductID.Query.Where(_UpToProductsByProductID.Query.ProductID == ProductID);
					_UpToProductsByProductID.Query.Load();
				}
				return _UpToProductsByProductID;
			}
			
			set
			{
				RemovePreSave("UpToProductsByProductID");
				
				var changed = _UpToProductsByProductID != value;

				if (value == null)
				{
					ProductID = null;
					_UpToProductsByProductID = null;
				}
				else
				{
					ProductID = value.ProductID;
					_UpToProductsByProductID = value;
					SetPreSave("UpToProductsByProductID", _UpToProductsByProductID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToProductsByProductID");
				}
			}
		}
		#endregion
		

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!es.IsDeleted && _UpToOrdersByOrderID != null)
			{
				OrderID = _UpToOrdersByOrderID.OrderID;
			}
			if(!es.IsDeleted && _UpToProductsByProductID != null)
			{
				ProductID = _UpToProductsByProductID.ProductID;
			}
		}
		
	}
	



	[Serializable]
	public partial class OrderDetailsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrderDetailsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ProductID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.UnitPrice, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = PropertyNames.UnitPrice;
			c.NumericPrecision = 10;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"0.0000";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Quantity, 3, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = PropertyNames.Quantity;
			c.NumericPrecision = 2;
			c.HasDefault = true;
			c.Default = @"1";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Discount, 4, typeof(System.Double), esSystemType.Double);
			c.PropertyName = PropertyNames.Discount;
			c.NumericPrecision = 8;
			c.HasDefault = true;
			c.Default = @"0";
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static OrderDetailsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string ProductID = "ProductID";
			 public const string UnitPrice = "UnitPrice";
			 public const string Quantity = "Quantity";
			 public const string Discount = "Discount";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string ProductID = "ProductID";
			 public const string UnitPrice = "UnitPrice";
			 public const string Quantity = "Quantity";
			 public const string Discount = "Discount";
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
			lock (typeof(OrderDetailsMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new OrderDetailsMetadata();
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


				specMeta.AddTypeMap("OrderID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"));
				specMeta.AddTypeMap("Quantity", new esTypeMap("SMALLINT", "System.Int16"));
				specMeta.AddTypeMap("Discount", new esTypeMap("DOUBLE", "System.Double"));			
				
				
				
				specMeta.Source = "order details";
				specMeta.Destination = "order details";
				
				specMeta.spInsert = "proc_order detailsInsert";				
				specMeta.spUpdate = "proc_order detailsUpdate";		
				specMeta.spDelete = "proc_order detailsDelete";
				specMeta.spLoadAll = "proc_order detailsLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_order detailsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static OrderDetailsMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
