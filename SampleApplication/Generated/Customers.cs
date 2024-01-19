
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
	/// Encapsulates the 'customers' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Customers))]	
	[XmlType("Customers")]
	public partial class Customers : esCustomers
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Customers();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.String customerID)
		{
			var obj = new Customers();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.String customerID, esSqlAccessType sqlAccessType)
		{
			var obj = new Customers();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomersCollection")]
	public partial class CustomersCollection : esCustomersCollection, IEnumerable<Customers>
	{
		public Customers FindByPrimaryKey(System.String customerID)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID);
		}

		
				
	}



	[Serializable]	
	public partial class CustomersQuery : esCustomersQuery
	{
		public CustomersQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public CustomersQuery(string joinAlias, out CustomersQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "CustomersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomersQuery query)
		{
			return CustomersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomersQuery(string query)
		{
			return (CustomersQuery)CustomersQuery.SerializeHelper.FromXml(query, typeof(CustomersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esCustomers : esEntity
	{
		public esCustomers()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerID)
		{
			CustomersQuery query = new CustomersQuery();
			query.Where(query.CustomerID == customerID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to customers.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CustomerID
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.CustomerID);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.CustomerID, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.CustomerID);
			}
		}		
		
		/// <summary>
		/// Maps to customers.CompanyName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String CompanyName
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.CompanyName);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.CompanyName, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.CompanyName);
			}
		}		
		
		/// <summary>
		/// Maps to customers.ContactName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ContactName
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.ContactName);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.ContactName, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.ContactName);
			}
		}		
		
		/// <summary>
		/// Maps to customers.ContactTitle
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String ContactTitle
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.ContactTitle);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.ContactTitle, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.ContactTitle);
			}
		}		
		
		/// <summary>
		/// Maps to customers.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Address
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.Address);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.Address, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.Address);
			}
		}		
		
		/// <summary>
		/// Maps to customers.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String City
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.City);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.City, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.City);
			}
		}		
		
		/// <summary>
		/// Maps to customers.Region
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Region
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.Region);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.Region, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.Region);
			}
		}		
		
		/// <summary>
		/// Maps to customers.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String PostalCode
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.PostalCode);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.PostalCode, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.PostalCode);
			}
		}		
		
		/// <summary>
		/// Maps to customers.Country
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Country
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.Country);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.Country, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.Country);
			}
		}		
		
		/// <summary>
		/// Maps to customers.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Phone
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.Phone);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.Phone, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.Phone);
			}
		}		
		
		/// <summary>
		/// Maps to customers.Fax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Fax
		{
			get => GetSystemString(CustomersMetadata.ColumnNames.Fax);
			
			set
			{
				if (!SetSystemString(CustomersMetadata.ColumnNames.Fax, value)) return;
				
				OnPropertyChanged(CustomersMetadata.PropertyNames.Fax);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => CustomersMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public CustomersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(CustomersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomersQuery query;		
	}



	[Serializable]
	public abstract class esCustomersCollection : esEntityCollection<Customers>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => CustomersMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "CustomersCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public CustomersQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new CustomersQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(CustomersQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new CustomersQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(CustomersQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((CustomersQuery)paraQuery);
		}

		#endregion
		
		private CustomersQuery query;
	}



	[Serializable]
	public abstract class esCustomersQuery : esDynamicQuery
	{
		protected override IMetadata Meta => CustomersMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "CustomerID" => CustomerID,
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
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID => new (this, CustomersMetadata.ColumnNames.CustomerID, esSystemType.String);
		
		public esQueryItem CompanyName => new (this, CustomersMetadata.ColumnNames.CompanyName, esSystemType.String);
		
		public esQueryItem ContactName => new (this, CustomersMetadata.ColumnNames.ContactName, esSystemType.String);
		
		public esQueryItem ContactTitle => new (this, CustomersMetadata.ColumnNames.ContactTitle, esSystemType.String);
		
		public esQueryItem Address => new (this, CustomersMetadata.ColumnNames.Address, esSystemType.String);
		
		public esQueryItem City => new (this, CustomersMetadata.ColumnNames.City, esSystemType.String);
		
		public esQueryItem Region => new (this, CustomersMetadata.ColumnNames.Region, esSystemType.String);
		
		public esQueryItem PostalCode => new (this, CustomersMetadata.ColumnNames.PostalCode, esSystemType.String);
		
		public esQueryItem Country => new (this, CustomersMetadata.ColumnNames.Country, esSystemType.String);
		
		public esQueryItem Phone => new (this, CustomersMetadata.ColumnNames.Phone, esSystemType.String);
		
		public esQueryItem Fax => new (this, CustomersMetadata.ColumnNames.Fax, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Customers : esCustomers
	{

		#region UpToCustomerdemographicsByCustomercustomerdemo - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToCustomerdemographicsByCustomercustomerdemo()
		{
			return _UpToCustomerdemographicsByCustomercustomerdemo is { Count: > 0 };
		}
		

		[DataMember(Name="UpToCustomerdemographicsByCustomercustomerdemo", EmitDefaultValue = false)]
		public CustomerdemographicsCollection UpToCustomerdemographicsByCustomercustomerdemo
		{
			get
			{
				if (_UpToCustomerdemographicsByCustomercustomerdemo != null) return _UpToCustomerdemographicsByCustomercustomerdemo;

				_UpToCustomerdemographicsByCustomercustomerdemo = new CustomerdemographicsCollection();
				_UpToCustomerdemographicsByCustomercustomerdemo.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToCustomerdemographicsByCustomercustomerdemo", _UpToCustomerdemographicsByCustomercustomerdemo);

				if (es.IsLazyLoadDisabled || CustomerID == null) return _UpToCustomerdemographicsByCustomercustomerdemo;

				var m = new CustomerdemographicsQuery("m");
				var j = new CustomercustomerdemoQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.CustomerTypeID == j.CustomerTypeID);
				m.Where(j.CustomerID == CustomerID);

				_UpToCustomerdemographicsByCustomercustomerdemo.Load(m);

				return _UpToCustomerdemographicsByCustomercustomerdemo;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToCustomerdemographicsByCustomercustomerdemo != null) 
				{ 
					RemovePostSave("UpToCustomerdemographicsByCustomercustomerdemo"); 
					_UpToCustomerdemographicsByCustomercustomerdemo = null;
					OnPropertyChanged("UpToCustomerdemographicsByCustomercustomerdemo");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		public void AssociateCustomerdemographicsByCustomercustomerdemo(Customerdemographics entity)
		{
			if (this._CustomercustomerdemoCollection == null)
			{
				this._CustomercustomerdemoCollection = new CustomercustomerdemoCollection();
				this._CustomercustomerdemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomercustomerdemoCollection", this._CustomercustomerdemoCollection);
			}

			Customercustomerdemo obj = this._CustomercustomerdemoCollection.AddNew();
			obj.CustomerID = this.CustomerID;
			obj.CustomerTypeID = entity.CustomerTypeID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		public void DissociateCustomerdemographicsByCustomercustomerdemo(Customerdemographics entity)
		{
			if (this._CustomercustomerdemoCollection == null)
			{
				this._CustomercustomerdemoCollection = new CustomercustomerdemoCollection();
				this._CustomercustomerdemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomercustomerdemoCollection", this._CustomercustomerdemoCollection);
			}

			Customercustomerdemo obj = this._CustomercustomerdemoCollection.AddNew();
			obj.CustomerID = this.CustomerID;
						obj.CustomerTypeID = entity.CustomerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private CustomerdemographicsCollection _UpToCustomerdemographicsByCustomercustomerdemo;
		private CustomercustomerdemoCollection _CustomercustomerdemoCollection;
		#endregion

		#region CustomercustomerdemoByCustomerID - Zero To Many
		
		public static esPrefetchMap Prefetch_CustomercustomerdemoByCustomerID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = CustomercustomerdemoByCustomerID_Delegate,
					PropertyName = "CustomercustomerdemoByCustomerID",
					MyColumnName = "CustomerID",
					ParentColumnName = "CustomerID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void CustomercustomerdemoByCustomerID_Delegate(esPrefetchParameters data)
		{
			var parent = new CustomersQuery(data.NextAlias());
			var me = data.You != null ? data.You as CustomercustomerdemoQuery : new CustomercustomerdemoQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.CustomerID == me?.CustomerID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeCustomercustomerdemoByCustomerID()
		{
			return _CustomercustomerdemoByCustomerID is { Count: > 0 };
		}	
		

		[DataMember(Name="CustomercustomerdemoByCustomerID", EmitDefaultValue = false)]
		public CustomercustomerdemoCollection CustomercustomerdemoByCustomerID
		{
			get
			{
				if (_CustomercustomerdemoByCustomerID != null) return _CustomercustomerdemoByCustomerID;
				
				_CustomercustomerdemoByCustomerID = new CustomercustomerdemoCollection();
				_CustomercustomerdemoByCustomerID.es.Connection.Name = es.Connection.Name;
				SetPostSave("CustomercustomerdemoByCustomerID", _CustomercustomerdemoByCustomerID);
				
				// ReSharper disable once InvertIf
				if (CustomerID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_CustomercustomerdemoByCustomerID.Query.Where(_CustomercustomerdemoByCustomerID.Query.CustomerID == CustomerID);
						_CustomercustomerdemoByCustomerID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_CustomercustomerdemoByCustomerID.fks.Add(CustomercustomerdemoMetadata.ColumnNames.CustomerID, this.CustomerID);
				}

				return _CustomercustomerdemoByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_CustomercustomerdemoByCustomerID == null) return;
				RemovePostSave("CustomercustomerdemoByCustomerID"); 
				_CustomercustomerdemoByCustomerID = null;
				OnPropertyChanged("CustomercustomerdemoByCustomerID");
			} 			
		}
		
			
		
		private CustomercustomerdemoCollection _CustomercustomerdemoByCustomerID;
		#endregion

		#region OrdersByCustomerID - Zero To Many
		
		public static esPrefetchMap Prefetch_OrdersByCustomerID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = OrdersByCustomerID_Delegate,
					PropertyName = "OrdersByCustomerID",
					MyColumnName = "CustomerID",
					ParentColumnName = "CustomerID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void OrdersByCustomerID_Delegate(esPrefetchParameters data)
		{
			var parent = new CustomersQuery(data.NextAlias());
			var me = data.You != null ? data.You as OrdersQuery : new OrdersQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.CustomerID == me?.CustomerID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Orders_Customers
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeOrdersByCustomerID()
		{
			return _OrdersByCustomerID is { Count: > 0 };
		}	
		

		[DataMember(Name="OrdersByCustomerID", EmitDefaultValue = false)]
		public OrdersCollection OrdersByCustomerID
		{
			get
			{
				if (_OrdersByCustomerID != null) return _OrdersByCustomerID;
				
				_OrdersByCustomerID = new OrdersCollection();
				_OrdersByCustomerID.es.Connection.Name = es.Connection.Name;
				SetPostSave("OrdersByCustomerID", _OrdersByCustomerID);
				
				// ReSharper disable once InvertIf
				if (CustomerID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_OrdersByCustomerID.Query.Where(_OrdersByCustomerID.Query.CustomerID == CustomerID);
						_OrdersByCustomerID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_OrdersByCustomerID.fks.Add(OrdersMetadata.ColumnNames.CustomerID, this.CustomerID);
				}

				return _OrdersByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_OrdersByCustomerID == null) return;
				RemovePostSave("OrdersByCustomerID"); 
				_OrdersByCustomerID = null;
				OnPropertyChanged("OrdersByCustomerID");
			} 			
		}
		
			
		
		private OrdersCollection _OrdersByCustomerID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomercustomerdemoByCustomerID":
					coll = this.CustomercustomerdemoByCustomerID;
					break;
				case "OrdersByCustomerID":
					coll = this.OrdersByCustomerID;
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
			props.Add(new esPropertyDescriptor(this, "CustomercustomerdemoByCustomerID", typeof(CustomercustomerdemoCollection), new Customercustomerdemo()));
			props.Add(new esPropertyDescriptor(this, "OrdersByCustomerID", typeof(OrdersCollection), new Orders()));
			return props;
		}
		
	}
	



	[Serializable]
	public partial class CustomersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.CustomerID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
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
				
		}
		#endregion	
	
		public static CustomersMetadata Meta()
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
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
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
			lock (typeof(CustomersMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new CustomersMetadata();
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
				
				
				
				specMeta.Source = "customers";
				specMeta.Destination = "customers";
				
				specMeta.spInsert = "proc_customersInsert";				
				specMeta.spUpdate = "proc_customersUpdate";		
				specMeta.spDelete = "proc_customersDelete";
				specMeta.spLoadAll = "proc_customersLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_customersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static CustomersMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
