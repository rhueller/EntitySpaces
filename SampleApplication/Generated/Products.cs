
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
	/// Encapsulates the 'products' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Products))]	
	[XmlType("Products")]
	public partial class Products : esProducts
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Products();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 productID)
		{
			var obj = new Products();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new Products();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductsCollection")]
	public partial class ProductsCollection : esProductsCollection, IEnumerable<Products>
	{
		public Products FindByPrimaryKey(System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.ProductID == productID);
		}

		
				
	}



	[Serializable]	
	public partial class ProductsQuery : esProductsQuery
	{
		public ProductsQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public ProductsQuery(string joinAlias, out ProductsQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "ProductsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ProductsQuery query)
		{
			return ProductsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductsQuery(string query)
		{
			return (ProductsQuery)ProductsQuery.SerializeHelper.FromXml(query, typeof(ProductsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esProducts : esEntity
	{
		public esProducts()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 productID)
		{
			ProductsQuery query = new ProductsQuery();
			query.Where(query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 productID)
		{
			esParameters parms = new esParameters();
			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to products.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? ProductID
		{
			get => GetSystemInt32(ProductsMetadata.ColumnNames.ProductID);
			
			set
			{
				if (!SetSystemInt32(ProductsMetadata.ColumnNames.ProductID, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.ProductID);
			}
		}		
		
		/// <summary>
		/// Maps to products.ProductName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ProductName
		{
			get => GetSystemString(ProductsMetadata.ColumnNames.ProductName);
			
			set
			{
				if (!SetSystemString(ProductsMetadata.ColumnNames.ProductName, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.ProductName);
			}
		}		
		
		/// <summary>
		/// Maps to products.SupplierID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? SupplierID
		{
			get => GetSystemInt32(ProductsMetadata.ColumnNames.SupplierID);
			
			set
			{
				if (!SetSystemInt32(ProductsMetadata.ColumnNames.SupplierID, value)) return;
				
				_UpToSuppliersBySupplierID = null;
				OnPropertyChanged("UpToSuppliersBySupplierID");
				OnPropertyChanged(ProductsMetadata.PropertyNames.SupplierID);
			}
		}		
		
		/// <summary>
		/// Maps to products.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? CategoryID
		{
			get => GetSystemInt32(ProductsMetadata.ColumnNames.CategoryID);
			
			set
			{
				if (!SetSystemInt32(ProductsMetadata.ColumnNames.CategoryID, value)) return;
				
				_UpToCategoriesByCategoryID = null;
				OnPropertyChanged("UpToCategoriesByCategoryID");
				OnPropertyChanged(ProductsMetadata.PropertyNames.CategoryID);
			}
		}		
		
		/// <summary>
		/// Maps to products.QuantityPerUnit
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String QuantityPerUnit
		{
			get => GetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit);
			
			set
			{
				if (!SetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.QuantityPerUnit);
			}
		}		
		
		/// <summary>
		/// Maps to products.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Decimal? UnitPrice
		{
			get => GetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice);
			
			set
			{
				if (!SetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.UnitPrice);
			}
		}		
		
		/// <summary>
		/// Maps to products.UnitsInStock
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int16? UnitsInStock
		{
			get => GetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock);
			
			set
			{
				if (!SetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsInStock);
			}
		}		
		
		/// <summary>
		/// Maps to products.UnitsOnOrder
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int16? UnitsOnOrder
		{
			get => GetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder);
			
			set
			{
				if (!SetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsOnOrder);
			}
		}		
		
		/// <summary>
		/// Maps to products.ReorderLevel
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int16? ReorderLevel
		{
			get => GetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel);
			
			set
			{
				if (!SetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.ReorderLevel);
			}
		}		
		
		/// <summary>
		/// Maps to products.Discontinued
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.SByte? Discontinued
		{
			get => GetSystemSByte(ProductsMetadata.ColumnNames.Discontinued);
			
			set
			{
				if (!SetSystemSByte(ProductsMetadata.ColumnNames.Discontinued, value)) return;
				
				OnPropertyChanged(ProductsMetadata.PropertyNames.Discontinued);
			}
		}		
		
		
		protected internal Categories _UpToCategoriesByCategoryID;
		
		protected internal Suppliers _UpToSuppliersBySupplierID;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => ProductsMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public ProductsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new ProductsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(ProductsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(ProductsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ProductsQuery query;		
	}



	[Serializable]
	public abstract class esProductsCollection : esEntityCollection<Products>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => ProductsMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "ProductsCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public ProductsQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new ProductsQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(ProductsQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new ProductsQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(ProductsQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((ProductsQuery)paraQuery);
		}

		#endregion
		
		private ProductsQuery query;
	}



	[Serializable]
	public abstract class esProductsQuery : esDynamicQuery
	{
		protected override IMetadata Meta => ProductsMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "ProductID" => ProductID,
              "ProductName" => ProductName,
              "SupplierID" => SupplierID,
              "CategoryID" => CategoryID,
              "QuantityPerUnit" => QuantityPerUnit,
              "UnitPrice" => UnitPrice,
              "UnitsInStock" => UnitsInStock,
              "UnitsOnOrder" => UnitsOnOrder,
              "ReorderLevel" => ReorderLevel,
              "Discontinued" => Discontinued,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ProductID => new (this, ProductsMetadata.ColumnNames.ProductID, esSystemType.Int32);
		
		public esQueryItem ProductName => new (this, ProductsMetadata.ColumnNames.ProductName, esSystemType.String);
		
		public esQueryItem SupplierID => new (this, ProductsMetadata.ColumnNames.SupplierID, esSystemType.Int32);
		
		public esQueryItem CategoryID => new (this, ProductsMetadata.ColumnNames.CategoryID, esSystemType.Int32);
		
		public esQueryItem QuantityPerUnit => new (this, ProductsMetadata.ColumnNames.QuantityPerUnit, esSystemType.String);
		
		public esQueryItem UnitPrice => new (this, ProductsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal);
		
		public esQueryItem UnitsInStock => new (this, ProductsMetadata.ColumnNames.UnitsInStock, esSystemType.Int16);
		
		public esQueryItem UnitsOnOrder => new (this, ProductsMetadata.ColumnNames.UnitsOnOrder, esSystemType.Int16);
		
		public esQueryItem ReorderLevel => new (this, ProductsMetadata.ColumnNames.ReorderLevel, esSystemType.Int16);
		
		public esQueryItem Discontinued => new (this, ProductsMetadata.ColumnNames.Discontinued, esSystemType.SByte);
		
		#endregion
		
	}


	
	public partial class Products : esProducts
	{

				
				
		#region UpToCategoriesByCategoryID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Products_Categories
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToCategoriesByCategoryID()
		{
				return _UpToCategoriesByCategoryID != null;
		}
		

		[DataMember(Name="UpToCategoriesByCategoryID", EmitDefaultValue = false)]
					
		public Categories UpToCategoriesByCategoryID
		{
			get
			{
				if (_UpToCategoriesByCategoryID != null) return _UpToCategoriesByCategoryID;
				
				_UpToCategoriesByCategoryID = new Categories();
				_UpToCategoriesByCategoryID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToCategoriesByCategoryID", _UpToCategoriesByCategoryID);

				if (_UpToCategoriesByCategoryID == null && CategoryID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToCategoriesByCategoryID;
					
					_UpToCategoriesByCategoryID.Query.Where(_UpToCategoriesByCategoryID.Query.CategoryID == CategoryID);
					_UpToCategoriesByCategoryID.Query.Load();
				}
				return _UpToCategoriesByCategoryID;
			}
			
			set
			{
				RemovePreSave("UpToCategoriesByCategoryID");
				
				var changed = _UpToCategoriesByCategoryID != value;

				if (value == null)
				{
					CategoryID = null;
					_UpToCategoriesByCategoryID = null;
				}
				else
				{
					CategoryID = value.CategoryID;
					_UpToCategoriesByCategoryID = value;
					SetPreSave("UpToCategoriesByCategoryID", _UpToCategoriesByCategoryID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToCategoriesByCategoryID");
				}
			}
		}
		#endregion
		

				
				
		#region UpToSuppliersBySupplierID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Products_Suppliers
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToSuppliersBySupplierID()
		{
				return _UpToSuppliersBySupplierID != null;
		}
		

		[DataMember(Name="UpToSuppliersBySupplierID", EmitDefaultValue = false)]
					
		public Suppliers UpToSuppliersBySupplierID
		{
			get
			{
				if (_UpToSuppliersBySupplierID != null) return _UpToSuppliersBySupplierID;
				
				_UpToSuppliersBySupplierID = new Suppliers();
				_UpToSuppliersBySupplierID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToSuppliersBySupplierID", _UpToSuppliersBySupplierID);

				if (_UpToSuppliersBySupplierID == null && SupplierID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToSuppliersBySupplierID;
					
					_UpToSuppliersBySupplierID.Query.Where(_UpToSuppliersBySupplierID.Query.SupplierID == SupplierID);
					_UpToSuppliersBySupplierID.Query.Load();
				}
				return _UpToSuppliersBySupplierID;
			}
			
			set
			{
				RemovePreSave("UpToSuppliersBySupplierID");
				
				var changed = _UpToSuppliersBySupplierID != value;

				if (value == null)
				{
					SupplierID = null;
					_UpToSuppliersBySupplierID = null;
				}
				else
				{
					SupplierID = value.SupplierID;
					_UpToSuppliersBySupplierID = value;
					SetPreSave("UpToSuppliersBySupplierID", _UpToSuppliersBySupplierID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToSuppliersBySupplierID");
				}
			}
		}
		#endregion
		

		#region UpToOrdersByOrderDetails - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToOrdersByOrderDetails()
		{
			return _UpToOrdersByOrderDetails is { Count: > 0 };
		}
		

		[DataMember(Name="UpToOrdersByOrderDetails", EmitDefaultValue = false)]
		public OrdersCollection UpToOrdersByOrderDetails
		{
			get
			{
				if (_UpToOrdersByOrderDetails != null) return _UpToOrdersByOrderDetails;

				_UpToOrdersByOrderDetails = new OrdersCollection();
				_UpToOrdersByOrderDetails.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToOrdersByOrderDetails", _UpToOrdersByOrderDetails);

				if (es.IsLazyLoadDisabled || ProductID == null) return _UpToOrdersByOrderDetails;

				var m = new OrdersQuery("m");
				var j = new OrderDetailsQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.OrderID == j.OrderID);
				m.Where(j.ProductID == ProductID);

				_UpToOrdersByOrderDetails.Load(m);

				return _UpToOrdersByOrderDetails;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToOrdersByOrderDetails != null) 
				{ 
					RemovePostSave("UpToOrdersByOrderDetails"); 
					_UpToOrdersByOrderDetails = null;
					OnPropertyChanged("UpToOrdersByOrderDetails");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		public void AssociateOrdersByOrderDetails(Orders entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.ProductID = this.ProductID;
			obj.OrderID = entity.OrderID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		public void DissociateOrdersByOrderDetails(Orders entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.ProductID = this.ProductID;
						obj.OrderID = entity.OrderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private OrdersCollection _UpToOrdersByOrderDetails;
		private OrderDetailsCollection _OrderDetailsCollection;
		#endregion

		#region OrderDetailsByProductID - Zero To Many
		
		public static esPrefetchMap Prefetch_OrderDetailsByProductID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = OrderDetailsByProductID_Delegate,
					PropertyName = "OrderDetailsByProductID",
					MyColumnName = "ProductID",
					ParentColumnName = "ProductID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void OrderDetailsByProductID_Delegate(esPrefetchParameters data)
		{
			var parent = new ProductsQuery(data.NextAlias());
			var me = data.You != null ? data.You as OrderDetailsQuery : new OrderDetailsQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.ProductID == me?.ProductID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeOrderDetailsByProductID()
		{
			return _OrderDetailsByProductID is { Count: > 0 };
		}	
		

		[DataMember(Name="OrderDetailsByProductID", EmitDefaultValue = false)]
		public OrderDetailsCollection OrderDetailsByProductID
		{
			get
			{
				if (_OrderDetailsByProductID != null) return _OrderDetailsByProductID;
				
				_OrderDetailsByProductID = new OrderDetailsCollection();
				_OrderDetailsByProductID.es.Connection.Name = es.Connection.Name;
				SetPostSave("OrderDetailsByProductID", _OrderDetailsByProductID);
				
				// ReSharper disable once InvertIf
				if (ProductID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_OrderDetailsByProductID.Query.Where(_OrderDetailsByProductID.Query.ProductID == ProductID);
						_OrderDetailsByProductID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_OrderDetailsByProductID.fks.Add(OrderDetailsMetadata.ColumnNames.ProductID, this.ProductID);
				}

				return _OrderDetailsByProductID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_OrderDetailsByProductID == null) return;
				RemovePostSave("OrderDetailsByProductID"); 
				_OrderDetailsByProductID = null;
				OnPropertyChanged("OrderDetailsByProductID");
			} 			
		}
		
			
		
		private OrderDetailsCollection _OrderDetailsByProductID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderDetailsByProductID":
					coll = this.OrderDetailsByProductID;
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
			props.Add(new esPropertyDescriptor(this, "OrderDetailsByProductID", typeof(OrderDetailsCollection), new OrderDetails()));
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!es.IsDeleted && _UpToCategoriesByCategoryID != null)
			{
				CategoryID = _UpToCategoriesByCategoryID.CategoryID;
			}
			if(!es.IsDeleted && _UpToSuppliersBySupplierID != null)
			{
				SupplierID = _UpToSuppliersBySupplierID.SupplierID;
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
				Apply(this._OrderDetailsCollection, "ProductID", this.ProductID);
			}
			if(this._OrderDetailsByProductID != null)
			{
				Apply(this._OrderDetailsByProductID, "ProductID", this.ProductID);
			}
		}
		
	}
	



	[Serializable]
	public partial class ProductsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.ProductID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ProductName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.ProductName;
			c.CharacterMaxLength = 40;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.SupplierID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.SupplierID;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.CategoryID, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.CategoryID;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.QuantityPerUnit, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.QuantityPerUnit;
			c.CharacterMaxLength = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.UnitPrice, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = PropertyNames.UnitPrice;
			c.NumericPrecision = 10;
			c.NumericScale = 4;
			c.HasDefault = true;
			c.Default = @"0.0000";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.UnitsInStock, 6, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = PropertyNames.UnitsInStock;
			c.NumericPrecision = 2;
			c.HasDefault = true;
			c.Default = @"0";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.UnitsOnOrder, 7, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = PropertyNames.UnitsOnOrder;
			c.NumericPrecision = 2;
			c.HasDefault = true;
			c.Default = @"0";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ReorderLevel, 8, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = PropertyNames.ReorderLevel;
			c.NumericPrecision = 2;
			c.HasDefault = true;
			c.Default = @"0";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Discontinued, 9, typeof(System.SByte), esSystemType.SByte);
			c.PropertyName = PropertyNames.Discontinued;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"b'0'";
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static ProductsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string SupplierID = "SupplierID";
			 public const string CategoryID = "CategoryID";
			 public const string QuantityPerUnit = "QuantityPerUnit";
			 public const string UnitPrice = "UnitPrice";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string ReorderLevel = "ReorderLevel";
			 public const string Discontinued = "Discontinued";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string SupplierID = "SupplierID";
			 public const string CategoryID = "CategoryID";
			 public const string QuantityPerUnit = "QuantityPerUnit";
			 public const string UnitPrice = "UnitPrice";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string ReorderLevel = "ReorderLevel";
			 public const string Discontinued = "Discontinued";
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
			lock (typeof(ProductsMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new ProductsMetadata();
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


				specMeta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("ProductName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("QuantityPerUnit", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"));
				specMeta.AddTypeMap("UnitsInStock", new esTypeMap("SMALLINT", "System.Int16"));
				specMeta.AddTypeMap("UnitsOnOrder", new esTypeMap("SMALLINT", "System.Int16"));
				specMeta.AddTypeMap("ReorderLevel", new esTypeMap("SMALLINT", "System.Int16"));
				specMeta.AddTypeMap("Discontinued", new esTypeMap("BIT", "System.SByte"));			
				
				
				
				specMeta.Source = "products";
				specMeta.Destination = "products";
				
				specMeta.spInsert = "proc_productsInsert";				
				specMeta.spUpdate = "proc_productsUpdate";		
				specMeta.spDelete = "proc_productsDelete";
				specMeta.spLoadAll = "proc_productsLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_productsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static ProductsMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
