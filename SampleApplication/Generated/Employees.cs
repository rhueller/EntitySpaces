
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
	/// Encapsulates the 'employees' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Employees))]	
	[XmlType("Employees")]
	public partial class Employees : esEmployees
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Employees();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 employeeID)
		{
			var obj = new Employees();
			obj.EmployeeID = employeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 employeeID, esSqlAccessType sqlAccessType)
		{
			var obj = new Employees();
			obj.EmployeeID = employeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EmployeesCollection")]
	public partial class EmployeesCollection : esEmployeesCollection, IEnumerable<Employees>
	{
		public Employees FindByPrimaryKey(System.Int32 employeeID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID);
		}

		
				
	}



	[Serializable]	
	public partial class EmployeesQuery : esEmployeesQuery
	{
		public EmployeesQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public EmployeesQuery(string joinAlias, out EmployeesQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "EmployeesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EmployeesQuery query)
		{
			return EmployeesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EmployeesQuery(string query)
		{
			return (EmployeesQuery)EmployeesQuery.SerializeHelper.FromXml(query, typeof(EmployeesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esEmployees : esEntity
	{
        protected esEmployees()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 employeeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 employeeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 employeeID)
		{
			EmployeesQuery query = new EmployeesQuery();
			query.Where(query.EmployeeID == employeeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 employeeID)
		{
			esParameters parms = new esParameters();
			parms.Add("EmployeeID", employeeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to employees.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? EmployeeID
		{
			get => GetSystemInt32(EmployeesMetadata.ColumnNames.EmployeeID);
			
			set
			{
				if (!SetSystemInt32(EmployeesMetadata.ColumnNames.EmployeeID, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.EmployeeID);
			}
		}		
		
		/// <summary>
		/// Maps to employees.LastName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String LastName
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.LastName);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.LastName, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.LastName);
			}
		}		
		
		/// <summary>
		/// Maps to employees.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String FirstName
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.FirstName);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.FirstName, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.FirstName);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Title
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Title
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Title);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Title, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Title);
			}
		}		
		
		/// <summary>
		/// Maps to employees.TitleOfCourtesy
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String TitleOfCourtesy
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.TitleOfCourtesy);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.TitleOfCourtesy, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.TitleOfCourtesy);
			}
		}		
		
		/// <summary>
		/// Maps to employees.BirthDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.DateTime? BirthDate
		{
			get => GetSystemDateTime(EmployeesMetadata.ColumnNames.BirthDate);
			
			set
			{
				if (!SetSystemDateTime(EmployeesMetadata.ColumnNames.BirthDate, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.BirthDate);
			}
		}		
		
		/// <summary>
		/// Maps to employees.HireDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.DateTime? HireDate
		{
			get => GetSystemDateTime(EmployeesMetadata.ColumnNames.HireDate);
			
			set
			{
				if (!SetSystemDateTime(EmployeesMetadata.ColumnNames.HireDate, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.HireDate);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Address
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Address);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Address, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Address);
			}
		}		
		
		/// <summary>
		/// Maps to employees.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String City
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.City);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.City, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.City);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Region
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Region
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Region);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Region, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Region);
			}
		}		
		
		/// <summary>
		/// Maps to employees.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String PostalCode
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.PostalCode);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.PostalCode, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.PostalCode);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Country
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Country
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Country);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Country, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Country);
			}
		}		
		
		/// <summary>
		/// Maps to employees.HomePhone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String HomePhone
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.HomePhone);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.HomePhone, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.HomePhone);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Extension
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Extension
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Extension);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Extension, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Extension);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Photo
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Byte[] Photo
		{
			get => GetSystemByteArray(EmployeesMetadata.ColumnNames.Photo);
			
			set
			{
				if (!SetSystemByteArray(EmployeesMetadata.ColumnNames.Photo, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Photo);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Notes
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String Notes
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.Notes);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.Notes, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Notes);
			}
		}		
		
		/// <summary>
		/// Maps to employees.ReportsTo
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? ReportsTo
		{
			get => GetSystemInt32(EmployeesMetadata.ColumnNames.ReportsTo);
			
			set
			{
				if (!SetSystemInt32(EmployeesMetadata.ColumnNames.ReportsTo, value)) return;
				
				_UpToEmployeesByReportsTo = null;
				OnPropertyChanged("UpToEmployeesByReportsTo");
				OnPropertyChanged(EmployeesMetadata.PropertyNames.ReportsTo);
			}
		}		
		
		/// <summary>
		/// Maps to employees.PhotoPath
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String PhotoPath
		{
			get => GetSystemString(EmployeesMetadata.ColumnNames.PhotoPath);
			
			set
			{
				if (!SetSystemString(EmployeesMetadata.ColumnNames.PhotoPath, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.PhotoPath);
			}
		}		
		
		/// <summary>
		/// Maps to employees.Salary
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Single? Salary
		{
			get => GetSystemSingle(EmployeesMetadata.ColumnNames.Salary);
			
			set
			{
				if (!SetSystemSingle(EmployeesMetadata.ColumnNames.Salary, value)) return;
				
				OnPropertyChanged(EmployeesMetadata.PropertyNames.Salary);
			}
		}		
		
		
		protected internal Employees _UpToEmployeesByReportsTo;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => EmployeesMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public EmployeesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new EmployeesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(EmployeesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(EmployeesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private EmployeesQuery query;		
	}



	[Serializable]
	public abstract class esEmployeesCollection : esEntityCollection<Employees>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => EmployeesMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "EmployeesCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public EmployeesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new EmployeesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(EmployeesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new EmployeesQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(EmployeesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((EmployeesQuery)paraQuery);
		}

		#endregion
		
		private EmployeesQuery query;
	}



	[Serializable]
	public abstract class esEmployeesQuery : esDynamicQuery
	{
		protected override IMetadata Meta => EmployeesMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "EmployeeID" => EmployeeID,
              "LastName" => LastName,
              "FirstName" => FirstName,
              "Title" => Title,
              "TitleOfCourtesy" => TitleOfCourtesy,
              "BirthDate" => BirthDate,
              "HireDate" => HireDate,
              "Address" => Address,
              "City" => City,
              "Region" => Region,
              "PostalCode" => PostalCode,
              "Country" => Country,
              "HomePhone" => HomePhone,
              "Extension" => Extension,
              "Photo" => Photo,
              "Notes" => Notes,
              "ReportsTo" => ReportsTo,
              "PhotoPath" => PhotoPath,
              "Salary" => Salary,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem EmployeeID => new (this, EmployeesMetadata.ColumnNames.EmployeeID, esSystemType.Int32);
		
		public esQueryItem LastName => new (this, EmployeesMetadata.ColumnNames.LastName, esSystemType.String);
		
		public esQueryItem FirstName => new (this, EmployeesMetadata.ColumnNames.FirstName, esSystemType.String);
		
		public esQueryItem Title => new (this, EmployeesMetadata.ColumnNames.Title, esSystemType.String);
		
		public esQueryItem TitleOfCourtesy => new (this, EmployeesMetadata.ColumnNames.TitleOfCourtesy, esSystemType.String);
		
		public esQueryItem BirthDate => new (this, EmployeesMetadata.ColumnNames.BirthDate, esSystemType.DateTime);
		
		public esQueryItem HireDate => new (this, EmployeesMetadata.ColumnNames.HireDate, esSystemType.DateTime);
		
		public esQueryItem Address => new (this, EmployeesMetadata.ColumnNames.Address, esSystemType.String);
		
		public esQueryItem City => new (this, EmployeesMetadata.ColumnNames.City, esSystemType.String);
		
		public esQueryItem Region => new (this, EmployeesMetadata.ColumnNames.Region, esSystemType.String);
		
		public esQueryItem PostalCode => new (this, EmployeesMetadata.ColumnNames.PostalCode, esSystemType.String);
		
		public esQueryItem Country => new (this, EmployeesMetadata.ColumnNames.Country, esSystemType.String);
		
		public esQueryItem HomePhone => new (this, EmployeesMetadata.ColumnNames.HomePhone, esSystemType.String);
		
		public esQueryItem Extension => new (this, EmployeesMetadata.ColumnNames.Extension, esSystemType.String);
		
		public esQueryItem Photo => new (this, EmployeesMetadata.ColumnNames.Photo, esSystemType.ByteArray);
		
		public esQueryItem Notes => new (this, EmployeesMetadata.ColumnNames.Notes, esSystemType.String);
		
		public esQueryItem ReportsTo => new (this, EmployeesMetadata.ColumnNames.ReportsTo, esSystemType.Int32);
		
		public esQueryItem PhotoPath => new (this, EmployeesMetadata.ColumnNames.PhotoPath, esSystemType.String);
		
		public esQueryItem Salary => new (this, EmployeesMetadata.ColumnNames.Salary, esSystemType.Single);
		
		#endregion
		
	}


	
	public partial class Employees : esEmployees
	{

		#region EmployeesCollectionByReportsTo - Zero To Many
		
		public static esPrefetchMap Prefetch_EmployeesCollectionByReportsTo
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = EmployeesCollectionByReportsTo_Delegate,
					PropertyName = "EmployeesCollectionByReportsTo",
					MyColumnName = "EmployeeID",
					ParentColumnName = "ReportsTo",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void EmployeesCollectionByReportsTo_Delegate(esPrefetchParameters data)
		{
			var parent = new EmployeesQuery(data.NextAlias());
			var me = data.You != null ? data.You as EmployeesQuery : new EmployeesQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.ReportsTo == me?.EmployeeID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Employees_Employees
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeEmployeesCollectionByReportsTo()
		{
			return _EmployeesCollectionByReportsTo is { Count: > 0 };
		}	
		

		[DataMember(Name="EmployeesCollectionByReportsTo", EmitDefaultValue = false)]
		public EmployeesCollection EmployeesCollectionByReportsTo
		{
			get
			{
				if (_EmployeesCollectionByReportsTo != null) return _EmployeesCollectionByReportsTo;
				
				_EmployeesCollectionByReportsTo = new EmployeesCollection();
				_EmployeesCollectionByReportsTo.es.Connection.Name = es.Connection.Name;
				SetPostSave("EmployeesCollectionByReportsTo", _EmployeesCollectionByReportsTo);
				
				// ReSharper disable once InvertIf
				if (EmployeeID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_EmployeesCollectionByReportsTo.Query.Where(_EmployeesCollectionByReportsTo.Query.ReportsTo == EmployeeID);
						_EmployeesCollectionByReportsTo.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_EmployeesCollectionByReportsTo.fks.Add(EmployeesMetadata.ColumnNames.ReportsTo, this.EmployeeID);
				}

				return _EmployeesCollectionByReportsTo;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_EmployeesCollectionByReportsTo == null) return;
				RemovePostSave("EmployeesCollectionByReportsTo"); 
				_EmployeesCollectionByReportsTo = null;
				OnPropertyChanged("EmployeesCollectionByReportsTo");
			} 			
		}
		
			
		
		private EmployeesCollection _EmployeesCollectionByReportsTo;
		#endregion

				
				
		#region UpToEmployeesByReportsTo - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Employees_Employees
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToEmployeesByReportsTo()
		{
				return _UpToEmployeesByReportsTo != null;
		}
		

		[DataMember(Name="UpToEmployeesByReportsTo", EmitDefaultValue = false)]
					
		public Employees UpToEmployeesByReportsTo
		{
			get
			{
				if (_UpToEmployeesByReportsTo != null) return _UpToEmployeesByReportsTo;
				
				_UpToEmployeesByReportsTo = new Employees();
				_UpToEmployeesByReportsTo.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToEmployeesByReportsTo", _UpToEmployeesByReportsTo);

				if (_UpToEmployeesByReportsTo == null && ReportsTo != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToEmployeesByReportsTo;
					
					_UpToEmployeesByReportsTo.Query.Where(_UpToEmployeesByReportsTo.Query.EmployeeID == ReportsTo);
					_UpToEmployeesByReportsTo.Query.Load();
				}
				return _UpToEmployeesByReportsTo;
			}
			
			set
			{
				RemovePreSave("UpToEmployeesByReportsTo");
				
				var changed = _UpToEmployeesByReportsTo != value;

				if (value == null)
				{
					ReportsTo = null;
					_UpToEmployeesByReportsTo = null;
				}
				else
				{
					ReportsTo = value.EmployeeID;
					_UpToEmployeesByReportsTo = value;
					SetPreSave("UpToEmployeesByReportsTo", _UpToEmployeesByReportsTo);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToEmployeesByReportsTo");
				}
			}
		}
		#endregion
		

		#region UpToTerritoriesByEmployeeterritories - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_EmployeeTerritories_Employees
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToTerritoriesByEmployeeterritories()
		{
			return _UpToTerritoriesByEmployeeterritories is { Count: > 0 };
		}
		

		[DataMember(Name="UpToTerritoriesByEmployeeterritories", EmitDefaultValue = false)]
		public TerritoriesCollection UpToTerritoriesByEmployeeterritories
		{
			get
			{
				if (_UpToTerritoriesByEmployeeterritories != null) return _UpToTerritoriesByEmployeeterritories;

				_UpToTerritoriesByEmployeeterritories = new TerritoriesCollection();
				_UpToTerritoriesByEmployeeterritories.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToTerritoriesByEmployeeterritories", _UpToTerritoriesByEmployeeterritories);

				if (es.IsLazyLoadDisabled || EmployeeID == null) return _UpToTerritoriesByEmployeeterritories;

				var m = new TerritoriesQuery("m");
				var j = new EmployeeterritoriesQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.TerritoryID == j.TerritoryID);
				m.Where(j.EmployeeID == EmployeeID);

				_UpToTerritoriesByEmployeeterritories.Load(m);

				return _UpToTerritoriesByEmployeeterritories;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToTerritoriesByEmployeeterritories != null) 
				{ 
					RemovePostSave("UpToTerritoriesByEmployeeterritories"); 
					_UpToTerritoriesByEmployeeterritories = null;
					OnPropertyChanged("UpToTerritoriesByEmployeeterritories");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_EmployeeTerritories_Employees
		/// </summary>
		public void AssociateTerritoriesByEmployeeterritories(Territories entity)
		{
			if (this._EmployeeterritoriesCollection == null)
			{
				this._EmployeeterritoriesCollection = new EmployeeterritoriesCollection();
				this._EmployeeterritoriesCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeterritoriesCollection", this._EmployeeterritoriesCollection);
			}

			Employeeterritories obj = this._EmployeeterritoriesCollection.AddNew();
			obj.EmployeeID = this.EmployeeID;
			obj.TerritoryID = entity.TerritoryID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_EmployeeTerritories_Employees
		/// </summary>
		public void DissociateTerritoriesByEmployeeterritories(Territories entity)
		{
			if (this._EmployeeterritoriesCollection == null)
			{
				this._EmployeeterritoriesCollection = new EmployeeterritoriesCollection();
				this._EmployeeterritoriesCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeterritoriesCollection", this._EmployeeterritoriesCollection);
			}

			Employeeterritories obj = this._EmployeeterritoriesCollection.AddNew();
			obj.EmployeeID = this.EmployeeID;
						obj.TerritoryID = entity.TerritoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private TerritoriesCollection _UpToTerritoriesByEmployeeterritories;
		private EmployeeterritoriesCollection _EmployeeterritoriesCollection;
		#endregion

		#region EmployeeterritoriesByEmployeeID - Zero To Many
		
		public static esPrefetchMap Prefetch_EmployeeterritoriesByEmployeeID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = EmployeeterritoriesByEmployeeID_Delegate,
					PropertyName = "EmployeeterritoriesByEmployeeID",
					MyColumnName = "EmployeeID",
					ParentColumnName = "EmployeeID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void EmployeeterritoriesByEmployeeID_Delegate(esPrefetchParameters data)
		{
			var parent = new EmployeesQuery(data.NextAlias());
			var me = data.You != null ? data.You as EmployeeterritoriesQuery : new EmployeeterritoriesQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.EmployeeID == me?.EmployeeID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_EmployeeTerritories_Employees
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeEmployeeterritoriesByEmployeeID()
		{
			return _EmployeeterritoriesByEmployeeID is { Count: > 0 };
		}	
		

		[DataMember(Name="EmployeeterritoriesByEmployeeID", EmitDefaultValue = false)]
		public EmployeeterritoriesCollection EmployeeterritoriesByEmployeeID
		{
			get
			{
				if (_EmployeeterritoriesByEmployeeID != null) return _EmployeeterritoriesByEmployeeID;
				
				_EmployeeterritoriesByEmployeeID = new EmployeeterritoriesCollection();
				_EmployeeterritoriesByEmployeeID.es.Connection.Name = es.Connection.Name;
				SetPostSave("EmployeeterritoriesByEmployeeID", _EmployeeterritoriesByEmployeeID);
				
				// ReSharper disable once InvertIf
				if (EmployeeID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_EmployeeterritoriesByEmployeeID.Query.Where(_EmployeeterritoriesByEmployeeID.Query.EmployeeID == EmployeeID);
						_EmployeeterritoriesByEmployeeID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_EmployeeterritoriesByEmployeeID.fks.Add(EmployeeterritoriesMetadata.ColumnNames.EmployeeID, this.EmployeeID);
				}

				return _EmployeeterritoriesByEmployeeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_EmployeeterritoriesByEmployeeID == null) return;
				RemovePostSave("EmployeeterritoriesByEmployeeID"); 
				_EmployeeterritoriesByEmployeeID = null;
				OnPropertyChanged("EmployeeterritoriesByEmployeeID");
			} 			
		}
		
			
		
		private EmployeeterritoriesCollection _EmployeeterritoriesByEmployeeID;
		#endregion

		#region OrdersByEmployeeID - Zero To Many
		
		public static esPrefetchMap Prefetch_OrdersByEmployeeID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = OrdersByEmployeeID_Delegate,
					PropertyName = "OrdersByEmployeeID",
					MyColumnName = "EmployeeID",
					ParentColumnName = "EmployeeID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void OrdersByEmployeeID_Delegate(esPrefetchParameters data)
		{
			var parent = new EmployeesQuery(data.NextAlias());
			var me = data.You != null ? data.You as OrdersQuery : new OrdersQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.EmployeeID == me?.EmployeeID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Orders_Employees
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeOrdersByEmployeeID()
		{
			return _OrdersByEmployeeID is { Count: > 0 };
		}	
		

		[DataMember(Name="OrdersByEmployeeID", EmitDefaultValue = false)]
		public OrdersCollection OrdersByEmployeeID
		{
			get
			{
				if (_OrdersByEmployeeID != null) return _OrdersByEmployeeID;
				
				_OrdersByEmployeeID = new OrdersCollection();
				_OrdersByEmployeeID.es.Connection.Name = es.Connection.Name;
				SetPostSave("OrdersByEmployeeID", _OrdersByEmployeeID);
				
				// ReSharper disable once InvertIf
				if (EmployeeID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_OrdersByEmployeeID.Query.Where(_OrdersByEmployeeID.Query.EmployeeID == EmployeeID);
						_OrdersByEmployeeID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_OrdersByEmployeeID.fks.Add(OrdersMetadata.ColumnNames.EmployeeID, this.EmployeeID);
				}

				return _OrdersByEmployeeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_OrdersByEmployeeID == null) return;
				RemovePostSave("OrdersByEmployeeID"); 
				_OrdersByEmployeeID = null;
				OnPropertyChanged("OrdersByEmployeeID");
			} 			
		}
		
			
		
		private OrdersCollection _OrdersByEmployeeID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "EmployeesCollectionByReportsTo":
					coll = this.EmployeesCollectionByReportsTo;
					break;
				case "EmployeeterritoriesByEmployeeID":
					coll = this.EmployeeterritoriesByEmployeeID;
					break;
				case "OrdersByEmployeeID":
					coll = this.OrdersByEmployeeID;
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
			props.Add(new esPropertyDescriptor(this, "EmployeesCollectionByReportsTo", typeof(EmployeesCollection), new Employees()));
			props.Add(new esPropertyDescriptor(this, "EmployeeterritoriesByEmployeeID", typeof(EmployeeterritoriesCollection), new Employeeterritories()));
			props.Add(new esPropertyDescriptor(this, "OrdersByEmployeeID", typeof(OrdersCollection), new Orders()));
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!es.IsDeleted && _UpToEmployeesByReportsTo != null)
			{
				ReportsTo = _UpToEmployeesByReportsTo.EmployeeID;
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
			if(this._EmployeesCollectionByReportsTo != null)
			{
				Apply(this._EmployeesCollectionByReportsTo, "ReportsTo", this.EmployeeID);
			}
			if(this._EmployeeterritoriesCollection != null)
			{
				Apply(this._EmployeeterritoriesCollection, "EmployeeID", this.EmployeeID);
			}
			if(this._EmployeeterritoriesByEmployeeID != null)
			{
				Apply(this._EmployeeterritoriesByEmployeeID, "EmployeeID", this.EmployeeID);
			}
			if(this._OrdersByEmployeeID != null)
			{
				Apply(this._OrdersByEmployeeID, "EmployeeID", this.EmployeeID);
			}
		}
		
	}
	



	[Serializable]
	public partial class EmployeesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EmployeesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.EmployeeID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.EmployeeID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.LastName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.LastName;
			c.CharacterMaxLength = 20;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.FirstName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.FirstName;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Title, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Title;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.TitleOfCourtesy, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.TitleOfCourtesy;
			c.CharacterMaxLength = 25;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.BirthDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PropertyNames.BirthDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.HireDate, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PropertyNames.HireDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Address, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Address;
			c.CharacterMaxLength = 60;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.City, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.City;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Region, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Region;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.PostalCode, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.PostalCode;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Country, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Country;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.HomePhone, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.HomePhone;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Extension, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Extension;
			c.CharacterMaxLength = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Photo, 14, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = PropertyNames.Photo;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Notes, 15, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.Notes;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.ReportsTo, 16, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.ReportsTo;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.PhotoPath, 17, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.PhotoPath;
			c.CharacterMaxLength = 255;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.Salary, 18, typeof(System.Single), esSystemType.Single);
			c.PropertyName = PropertyNames.Salary;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static EmployeesMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string EmployeeID = "EmployeeID";
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
			 public const string Title = "Title";
			 public const string TitleOfCourtesy = "TitleOfCourtesy";
			 public const string BirthDate = "BirthDate";
			 public const string HireDate = "HireDate";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string HomePhone = "HomePhone";
			 public const string Extension = "Extension";
			 public const string Photo = "Photo";
			 public const string Notes = "Notes";
			 public const string ReportsTo = "ReportsTo";
			 public const string PhotoPath = "PhotoPath";
			 public const string Salary = "Salary";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string EmployeeID = "EmployeeID";
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
			 public const string Title = "Title";
			 public const string TitleOfCourtesy = "TitleOfCourtesy";
			 public const string BirthDate = "BirthDate";
			 public const string HireDate = "HireDate";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string HomePhone = "HomePhone";
			 public const string Extension = "Extension";
			 public const string Photo = "Photo";
			 public const string Notes = "Notes";
			 public const string ReportsTo = "ReportsTo";
			 public const string PhotoPath = "PhotoPath";
			 public const string Salary = "Salary";
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
			lock (typeof(EmployeesMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new EmployeesMetadata();
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


				specMeta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("LastName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("FirstName", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Title", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("TitleOfCourtesy", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("BirthDate", new esTypeMap("DATETIME", "System.DateTime"));
				specMeta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"));
				specMeta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("HomePhone", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Extension", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Photo", new esTypeMap("LONGBLOB", "System.Byte[]"));
				specMeta.AddTypeMap("Notes", new esTypeMap("MEDIUMTEXT", "System.String"));
				specMeta.AddTypeMap("ReportsTo", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("PhotoPath", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("Salary", new esTypeMap("FLOAT", "System.Single"));			
				
				
				
				specMeta.Source = "employees";
				specMeta.Destination = "employees";
				
				specMeta.spInsert = "proc_employeesInsert";				
				specMeta.spUpdate = "proc_employeesUpdate";		
				specMeta.spDelete = "proc_employeesDelete";
				specMeta.spLoadAll = "proc_employeesLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_employeesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static EmployeesMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
