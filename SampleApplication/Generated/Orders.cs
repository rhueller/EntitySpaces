
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
	/// Encapsulates the 'orders' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Orders))]	
	[XmlType("Orders")]
	public partial class Orders : esOrders
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Orders();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 orderID)
		{
			var obj = new Orders();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 orderID, esSqlAccessType sqlAccessType)
		{
			var obj = new Orders();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OrdersCollection")]
	public partial class OrdersCollection : esOrdersCollection, IEnumerable<Orders>
	{
		public Orders FindByPrimaryKey(System.Int32 orderID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID);
		}

		
				
	}



	[Serializable]	
	public partial class OrdersQuery : esOrdersQuery
	{
		public OrdersQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public OrdersQuery(string joinAlias, out OrdersQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "OrdersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrdersQuery query)
		{
			return OrdersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrdersQuery(string query)
		{
			return (OrdersQuery)OrdersQuery.SerializeHelper.FromXml(query, typeof(OrdersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esOrders : esEntity
	{
		public esOrders()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 orderID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 orderID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 orderID)
		{
			OrdersQuery query = new OrdersQuery();
			query.Where(query.OrderID == orderID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 orderID)
		{
			esParameters parms = new esParameters();
			parms.Add("OrderID", orderID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to orders.OrderID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? OrderID
		{
			get => GetSystemInt32(OrdersMetadata.ColumnNames.OrderID);
			
			set
			{
				if (!SetSystemInt32(OrdersMetadata.ColumnNames.OrderID, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.OrderID);
			}
		}		
		
		/// <summary>
		/// Maps to orders.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerID
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.CustomerID);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.CustomerID, value)) return;
				
				_UpToCustomersByCustomerID = null;
				OnPropertyChanged("UpToCustomersByCustomerID");
				OnPropertyChanged(OrdersMetadata.PropertyNames.CustomerID);
			}
		}		
		
		/// <summary>
		/// Maps to orders.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? EmployeeID
		{
			get => GetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID);
			
			set
			{
				if (!SetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID, value)) return;
				
				_UpToEmployeesByEmployeeID = null;
				OnPropertyChanged("UpToEmployeesByEmployeeID");
				OnPropertyChanged(OrdersMetadata.PropertyNames.EmployeeID);
			}
		}		
		
		/// <summary>
		/// Maps to orders.OrderDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.DateTime? OrderDate
		{
			get => GetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate);
			
			set
			{
				if (!SetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.OrderDate);
			}
		}		
		
		/// <summary>
		/// Maps to orders.RequiredDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.DateTime? RequiredDate
		{
			get => GetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate);
			
			set
			{
				if (!SetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.RequiredDate);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShippedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.DateTime? ShippedDate
		{
			get => GetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate);
			
			set
			{
				if (!SetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShippedDate);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipVia
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? ShipVia
		{
			get => GetSystemInt32(OrdersMetadata.ColumnNames.ShipVia);
			
			set
			{
				if (!SetSystemInt32(OrdersMetadata.ColumnNames.ShipVia, value)) return;
				
				_UpToShippersByShipVia = null;
				OnPropertyChanged("UpToShippersByShipVia");
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipVia);
			}
		}		
		
		/// <summary>
		/// Maps to orders.Freight
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Decimal? Freight
		{
			get => GetSystemDecimal(OrdersMetadata.ColumnNames.Freight);
			
			set
			{
				if (!SetSystemDecimal(OrdersMetadata.ColumnNames.Freight, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.Freight);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipName
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipName);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipName, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipName);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipAddress
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipAddress
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipAddress);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipAddress, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipAddress);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipCity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipCity
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipCity);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipCity, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCity);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipRegion
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipRegion
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipRegion);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipRegion, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipRegion);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipPostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipPostalCode
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipPostalCode);
			}
		}		
		
		/// <summary>
		/// Maps to orders.ShipCountry
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ShipCountry
		{
			get => GetSystemString(OrdersMetadata.ColumnNames.ShipCountry);
			
			set
			{
				if (!SetSystemString(OrdersMetadata.ColumnNames.ShipCountry, value)) return;
				
				OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCountry);
			}
		}		
		
		
		protected internal Customers _UpToCustomersByCustomerID;
		
		protected internal Employees _UpToEmployeesByEmployeeID;
		
		protected internal Shippers _UpToShippersByShipVia;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => OrdersMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public OrdersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new OrdersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(OrdersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(OrdersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OrdersQuery query;		
	}



	[Serializable]
	public abstract class esOrdersCollection : esEntityCollection<Orders>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => OrdersMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "OrdersCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public OrdersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new OrdersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(OrdersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new OrdersQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(OrdersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((OrdersQuery)paraQuery);
		}

		#endregion
		
		private OrdersQuery query;
	}



	[Serializable]
	public abstract class esOrdersQuery : esDynamicQuery
	{
		protected override IMetadata Meta => OrdersMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "OrderID" => OrderID,
              "CustomerID" => CustomerID,
              "EmployeeID" => EmployeeID,
              "OrderDate" => OrderDate,
              "RequiredDate" => RequiredDate,
              "ShippedDate" => ShippedDate,
              "ShipVia" => ShipVia,
              "Freight" => Freight,
              "ShipName" => ShipName,
              "ShipAddress" => ShipAddress,
              "ShipCity" => ShipCity,
              "ShipRegion" => ShipRegion,
              "ShipPostalCode" => ShipPostalCode,
              "ShipCountry" => ShipCountry,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem OrderID => new (this, OrdersMetadata.ColumnNames.OrderID, esSystemType.Int32);
		
		public esQueryItem CustomerID => new (this, OrdersMetadata.ColumnNames.CustomerID, esSystemType.String);
		
		public esQueryItem EmployeeID => new (this, OrdersMetadata.ColumnNames.EmployeeID, esSystemType.Int32);
		
		public esQueryItem OrderDate => new (this, OrdersMetadata.ColumnNames.OrderDate, esSystemType.DateTime);
		
		public esQueryItem RequiredDate => new (this, OrdersMetadata.ColumnNames.RequiredDate, esSystemType.DateTime);
		
		public esQueryItem ShippedDate => new (this, OrdersMetadata.ColumnNames.ShippedDate, esSystemType.DateTime);
		
		public esQueryItem ShipVia => new (this, OrdersMetadata.ColumnNames.ShipVia, esSystemType.Int32);
		
		public esQueryItem Freight => new (this, OrdersMetadata.ColumnNames.Freight, esSystemType.Decimal);
		
		public esQueryItem ShipName => new (this, OrdersMetadata.ColumnNames.ShipName, esSystemType.String);
		
		public esQueryItem ShipAddress => new (this, OrdersMetadata.ColumnNames.ShipAddress, esSystemType.String);
		
		public esQueryItem ShipCity => new (this, OrdersMetadata.ColumnNames.ShipCity, esSystemType.String);
		
		public esQueryItem ShipRegion => new (this, OrdersMetadata.ColumnNames.ShipRegion, esSystemType.String);
		
		public esQueryItem ShipPostalCode => new (this, OrdersMetadata.ColumnNames.ShipPostalCode, esSystemType.String);
		
		public esQueryItem ShipCountry => new (this, OrdersMetadata.ColumnNames.ShipCountry, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Orders : esOrders
	{

				
				
		#region UpToCustomersByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Customers
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
		

				
				
		#region UpToEmployeesByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Employees
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToEmployeesByEmployeeID()
		{
				return _UpToEmployeesByEmployeeID != null;
		}
		

		[DataMember(Name="UpToEmployeesByEmployeeID", EmitDefaultValue = false)]
					
		public Employees UpToEmployeesByEmployeeID
		{
			get
			{
				if (_UpToEmployeesByEmployeeID != null) return _UpToEmployeesByEmployeeID;
				
				_UpToEmployeesByEmployeeID = new Employees();
				_UpToEmployeesByEmployeeID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToEmployeesByEmployeeID", _UpToEmployeesByEmployeeID);

				if (_UpToEmployeesByEmployeeID == null && EmployeeID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToEmployeesByEmployeeID;
					
					_UpToEmployeesByEmployeeID.Query.Where(_UpToEmployeesByEmployeeID.Query.EmployeeID == EmployeeID);
					_UpToEmployeesByEmployeeID.Query.Load();
				}
				return _UpToEmployeesByEmployeeID;
			}
			
			set
			{
				RemovePreSave("UpToEmployeesByEmployeeID");
				
				var changed = _UpToEmployeesByEmployeeID != value;

				if (value == null)
				{
					EmployeeID = null;
					_UpToEmployeesByEmployeeID = null;
				}
				else
				{
					EmployeeID = value.EmployeeID;
					_UpToEmployeesByEmployeeID = value;
					SetPreSave("UpToEmployeesByEmployeeID", _UpToEmployeesByEmployeeID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToEmployeesByEmployeeID");
				}
			}
		}
		#endregion
		

				
				
		#region UpToShippersByShipVia - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Shippers
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToShippersByShipVia()
		{
				return _UpToShippersByShipVia != null;
		}
		

		[DataMember(Name="UpToShippersByShipVia", EmitDefaultValue = false)]
					
		public Shippers UpToShippersByShipVia
		{
			get
			{
				if (_UpToShippersByShipVia != null) return _UpToShippersByShipVia;
				
				_UpToShippersByShipVia = new Shippers();
				_UpToShippersByShipVia.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToShippersByShipVia", _UpToShippersByShipVia);

				if (_UpToShippersByShipVia == null && ShipVia != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToShippersByShipVia;
					
					_UpToShippersByShipVia.Query.Where(_UpToShippersByShipVia.Query.ShipperID == ShipVia);
					_UpToShippersByShipVia.Query.Load();
				}
				return _UpToShippersByShipVia;
			}
			
			set
			{
				RemovePreSave("UpToShippersByShipVia");
				
				var changed = _UpToShippersByShipVia != value;

				if (value == null)
				{
					ShipVia = null;
					_UpToShippersByShipVia = null;
				}
				else
				{
					ShipVia = value.ShipperID;
					_UpToShippersByShipVia = value;
					SetPreSave("UpToShippersByShipVia", _UpToShippersByShipVia);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToShippersByShipVia");
				}
			}
		}
		#endregion
		

		#region UpToProductsByOrderDetails - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToProductsByOrderDetails()
		{
			return _UpToProductsByOrderDetails is { Count: > 0 };
		}
		

		[DataMember(Name="UpToProductsByOrderDetails", EmitDefaultValue = false)]
		public ProductsCollection UpToProductsByOrderDetails
		{
			get
			{
				if (_UpToProductsByOrderDetails != null) return _UpToProductsByOrderDetails;

				_UpToProductsByOrderDetails = new ProductsCollection();
				_UpToProductsByOrderDetails.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToProductsByOrderDetails", _UpToProductsByOrderDetails);

				if (es.IsLazyLoadDisabled || OrderID == null) return _UpToProductsByOrderDetails;

				var m = new ProductsQuery("m");
				var j = new OrderDetailsQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.ProductID == j.ProductID);
				m.Where(j.OrderID == OrderID);

				_UpToProductsByOrderDetails.Load(m);

				return _UpToProductsByOrderDetails;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToProductsByOrderDetails != null) 
				{ 
					RemovePostSave("UpToProductsByOrderDetails"); 
					_UpToProductsByOrderDetails = null;
					OnPropertyChanged("UpToProductsByOrderDetails");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		public void AssociateProductsByOrderDetails(Products entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.OrderID = this.OrderID;
			obj.ProductID = entity.ProductID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		public void DissociateProductsByOrderDetails(Products entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.OrderID = this.OrderID;
						obj.ProductID = entity.ProductID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private ProductsCollection _UpToProductsByOrderDetails;
		private OrderDetailsCollection _OrderDetailsCollection;
		#endregion

		#region OrderDetailsByOrderID - Zero To Many
		
		public static esPrefetchMap Prefetch_OrderDetailsByOrderID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = OrderDetailsByOrderID_Delegate,
					PropertyName = "OrderDetailsByOrderID",
					MyColumnName = "OrderID",
					ParentColumnName = "OrderID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void OrderDetailsByOrderID_Delegate(esPrefetchParameters data)
		{
			var parent = new OrdersQuery(data.NextAlias());
			var me = data.You != null ? data.You as OrderDetailsQuery : new OrderDetailsQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.OrderID == me?.OrderID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeOrderDetailsByOrderID()
		{
			return _OrderDetailsByOrderID is { Count: > 0 };
		}	
		

		[DataMember(Name="OrderDetailsByOrderID", EmitDefaultValue = false)]
		public OrderDetailsCollection OrderDetailsByOrderID
		{
			get
			{
				if (_OrderDetailsByOrderID != null) return _OrderDetailsByOrderID;
				
				_OrderDetailsByOrderID = new OrderDetailsCollection();
				_OrderDetailsByOrderID.es.Connection.Name = es.Connection.Name;
				SetPostSave("OrderDetailsByOrderID", _OrderDetailsByOrderID);
				
				// ReSharper disable once InvertIf
				if (OrderID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_OrderDetailsByOrderID.Query.Where(_OrderDetailsByOrderID.Query.OrderID == OrderID);
						_OrderDetailsByOrderID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_OrderDetailsByOrderID.fks.Add(OrderDetailsMetadata.ColumnNames.OrderID, this.OrderID);
				}

				return _OrderDetailsByOrderID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_OrderDetailsByOrderID == null) return;
				RemovePostSave("OrderDetailsByOrderID"); 
				_OrderDetailsByOrderID = null;
				OnPropertyChanged("OrderDetailsByOrderID");
			} 			
		}
		
			
		
		private OrderDetailsCollection _OrderDetailsByOrderID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderDetailsByOrderID":
					coll = this.OrderDetailsByOrderID;
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
			props.Add(new esPropertyDescriptor(this, "OrderDetailsByOrderID", typeof(OrderDetailsCollection), new OrderDetails()));
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!es.IsDeleted && _UpToEmployeesByEmployeeID != null)
			{
				EmployeeID = _UpToEmployeesByEmployeeID.EmployeeID;
			}
			if(!es.IsDeleted && _UpToShippersByShipVia != null)
			{
				ShipVia = _UpToShippersByShipVia.ShipperID;
			}
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
			if(this._OrderDetailsCollection != null)
			{
				Apply(this._OrderDetailsCollection, "OrderID", this.OrderID);
			}
			if(this._OrderDetailsByOrderID != null)
			{
				Apply(this._OrderDetailsByOrderID, "OrderID", this.OrderID);
			}
		}
		
	}
	



	[Serializable]
	public partial class OrdersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrdersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CustomerID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerID;
			c.CharacterMaxLength = 5;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.EmployeeID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.EmployeeID;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.OrderDate, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PropertyNames.OrderDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.RequiredDate, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PropertyNames.RequiredDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShippedDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PropertyNames.ShippedDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipVia, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.ShipVia;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Freight, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = PropertyNames.Freight;
			c.NumericPrecision = 10;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"0.0000";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipName, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipName;
			c.CharacterMaxLength = 40;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipAddress, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipAddress;
			c.CharacterMaxLength = 60;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipCity, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipCity;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipRegion, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipRegion;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipPostalCode, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipPostalCode;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ShipCountry, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ShipCountry;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static OrdersMetadata Meta()
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
			 public const string CustomerID = "CustomerID";
			 public const string EmployeeID = "EmployeeID";
			 public const string OrderDate = "OrderDate";
			 public const string RequiredDate = "RequiredDate";
			 public const string ShippedDate = "ShippedDate";
			 public const string ShipVia = "ShipVia";
			 public const string Freight = "Freight";
			 public const string ShipName = "ShipName";
			 public const string ShipAddress = "ShipAddress";
			 public const string ShipCity = "ShipCity";
			 public const string ShipRegion = "ShipRegion";
			 public const string ShipPostalCode = "ShipPostalCode";
			 public const string ShipCountry = "ShipCountry";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string CustomerID = "CustomerID";
			 public const string EmployeeID = "EmployeeID";
			 public const string OrderDate = "OrderDate";
			 public const string RequiredDate = "RequiredDate";
			 public const string ShippedDate = "ShippedDate";
			 public const string ShipVia = "ShipVia";
			 public const string Freight = "Freight";
			 public const string ShipName = "ShipName";
			 public const string ShipAddress = "ShipAddress";
			 public const string ShipCity = "ShipCity";
			 public const string ShipRegion = "ShipRegion";
			 public const string ShipPostalCode = "ShipPostalCode";
			 public const string ShipCountry = "ShipCountry";
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
			lock (typeof(OrdersMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new OrdersMetadata();
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
				specMeta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("OrderDate", new esTypeMap("DATETIME", "System.DateTime"));
				specMeta.AddTypeMap("RequiredDate", new esTypeMap("DATETIME", "System.DateTime"));
				specMeta.AddTypeMap("ShippedDate", new esTypeMap("DATETIME", "System.DateTime"));
				specMeta.AddTypeMap("ShipVia", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("Freight", new esTypeMap("DECIMAL", "System.Decimal"));
				specMeta.AddTypeMap("ShipName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ShipAddress", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ShipCity", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ShipRegion", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ShipPostalCode", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("ShipCountry", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				specMeta.Source = "orders";
				specMeta.Destination = "orders";
				
				specMeta.spInsert = "proc_ordersInsert";				
				specMeta.spUpdate = "proc_ordersUpdate";		
				specMeta.spDelete = "proc_ordersDelete";
				specMeta.spLoadAll = "proc_ordersLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_ordersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static OrdersMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
