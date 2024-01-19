
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
	/// Encapsulates the 'employeeterritories' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Employeeterritories))]	
	[XmlType("Employeeterritories")]
	public partial class Employeeterritories : esEmployeeterritories
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Employeeterritories();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 employeeID, System.String territoryID)
		{
			var obj = new Employeeterritories();
			obj.EmployeeID = employeeID;
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 employeeID, System.String territoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new Employeeterritories();
			obj.EmployeeID = employeeID;
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EmployeeterritoriesCollection")]
	public partial class EmployeeterritoriesCollection : esEmployeeterritoriesCollection, IEnumerable<Employeeterritories>
	{
		public Employeeterritories FindByPrimaryKey(System.Int32 employeeID, System.String territoryID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID && e.TerritoryID == territoryID);
		}

		
				
	}



	[Serializable]	
	public partial class EmployeeterritoriesQuery : esEmployeeterritoriesQuery
	{
		public EmployeeterritoriesQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public EmployeeterritoriesQuery(string joinAlias, out EmployeeterritoriesQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "EmployeeterritoriesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EmployeeterritoriesQuery query)
		{
			return EmployeeterritoriesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EmployeeterritoriesQuery(string query)
		{
			return (EmployeeterritoriesQuery)EmployeeterritoriesQuery.SerializeHelper.FromXml(query, typeof(EmployeeterritoriesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esEmployeeterritories : esEntity
	{
		public esEmployeeterritories()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 employeeID, System.String territoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID, territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID, territoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 employeeID, System.String territoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID, territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID, territoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 employeeID, System.String territoryID)
		{
			EmployeeterritoriesQuery query = new EmployeeterritoriesQuery();
			query.Where(query.EmployeeID == employeeID, query.TerritoryID == territoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 employeeID, System.String territoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("EmployeeID", employeeID);			parms.Add("TerritoryID", territoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to employeeterritories.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? EmployeeID
		{
			get => GetSystemInt32(EmployeeterritoriesMetadata.ColumnNames.EmployeeID);
			
			set
			{
				if (!SetSystemInt32(EmployeeterritoriesMetadata.ColumnNames.EmployeeID, value)) return;
				
				_UpToEmployeesByEmployeeID = null;
				OnPropertyChanged("UpToEmployeesByEmployeeID");
				OnPropertyChanged(EmployeeterritoriesMetadata.PropertyNames.EmployeeID);
			}
		}		
		
		/// <summary>
		/// Maps to employeeterritories.TerritoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String TerritoryID
		{
			get => GetSystemString(EmployeeterritoriesMetadata.ColumnNames.TerritoryID);
			
			set
			{
				if (!SetSystemString(EmployeeterritoriesMetadata.ColumnNames.TerritoryID, value)) return;
				
				_UpToTerritoriesByTerritoryID = null;
				OnPropertyChanged("UpToTerritoriesByTerritoryID");
				OnPropertyChanged(EmployeeterritoriesMetadata.PropertyNames.TerritoryID);
			}
		}		
		
		
		protected internal Employees _UpToEmployeesByEmployeeID;
		
		protected internal Territories _UpToTerritoriesByTerritoryID;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => EmployeeterritoriesMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public EmployeeterritoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new EmployeeterritoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(EmployeeterritoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(EmployeeterritoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private EmployeeterritoriesQuery query;		
	}



	[Serializable]
	public abstract class esEmployeeterritoriesCollection : esEntityCollection<Employeeterritories>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => EmployeeterritoriesMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "EmployeeterritoriesCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public EmployeeterritoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new EmployeeterritoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(EmployeeterritoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new EmployeeterritoriesQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(EmployeeterritoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((EmployeeterritoriesQuery)paraQuery);
		}

		#endregion
		
		private EmployeeterritoriesQuery query;
	}



	[Serializable]
	public abstract class esEmployeeterritoriesQuery : esDynamicQuery
	{
		protected override IMetadata Meta => EmployeeterritoriesMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "EmployeeID" => EmployeeID,
              "TerritoryID" => TerritoryID,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem EmployeeID => new (this, EmployeeterritoriesMetadata.ColumnNames.EmployeeID, esSystemType.Int32);
		
		public esQueryItem TerritoryID => new (this, EmployeeterritoriesMetadata.ColumnNames.TerritoryID, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Employeeterritories : esEmployeeterritories
	{

				
				
		#region UpToEmployeesByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_EmployeeTerritories_Employees
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
		

				
				
		#region UpToTerritoriesByTerritoryID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_EmployeeTerritories_Territories
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToTerritoriesByTerritoryID()
		{
				return _UpToTerritoriesByTerritoryID != null;
		}
		

		[DataMember(Name="UpToTerritoriesByTerritoryID", EmitDefaultValue = false)]
					
		public Territories UpToTerritoriesByTerritoryID
		{
			get
			{
				if (_UpToTerritoriesByTerritoryID != null) return _UpToTerritoriesByTerritoryID;
				
				_UpToTerritoriesByTerritoryID = new Territories();
				_UpToTerritoriesByTerritoryID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToTerritoriesByTerritoryID", _UpToTerritoriesByTerritoryID);

				if (_UpToTerritoriesByTerritoryID == null && TerritoryID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToTerritoriesByTerritoryID;
					
					_UpToTerritoriesByTerritoryID.Query.Where(_UpToTerritoriesByTerritoryID.Query.TerritoryID == TerritoryID);
					_UpToTerritoriesByTerritoryID.Query.Load();
				}
				return _UpToTerritoriesByTerritoryID;
			}
			
			set
			{
				RemovePreSave("UpToTerritoriesByTerritoryID");
				
				var changed = _UpToTerritoriesByTerritoryID != value;

				if (value == null)
				{
					TerritoryID = null;
					_UpToTerritoriesByTerritoryID = null;
				}
				else
				{
					TerritoryID = value.TerritoryID;
					_UpToTerritoriesByTerritoryID = value;
					SetPreSave("UpToTerritoriesByTerritoryID", _UpToTerritoriesByTerritoryID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToTerritoriesByTerritoryID");
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
			if(!es.IsDeleted && _UpToEmployeesByEmployeeID != null)
			{
				EmployeeID = _UpToEmployeesByEmployeeID.EmployeeID;
			}
		}
		
	}
	



	[Serializable]
	public partial class EmployeeterritoriesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EmployeeterritoriesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.EmployeeID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.EmployeeID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.TerritoryID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.TerritoryID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 20;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static EmployeeterritoriesMetadata Meta()
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
			 public const string TerritoryID = "TerritoryID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string EmployeeID = "EmployeeID";
			 public const string TerritoryID = "TerritoryID";
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
			lock (typeof(EmployeeterritoriesMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new EmployeeterritoriesMetadata();
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
				specMeta.AddTypeMap("TerritoryID", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				specMeta.Source = "employeeterritories";
				specMeta.Destination = "employeeterritories";
				
				specMeta.spInsert = "proc_employeeterritoriesInsert";				
				specMeta.spUpdate = "proc_employeeterritoriesUpdate";		
				specMeta.spDelete = "proc_employeeterritoriesDelete";
				specMeta.spLoadAll = "proc_employeeterritoriesLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_employeeterritoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static EmployeeterritoriesMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
