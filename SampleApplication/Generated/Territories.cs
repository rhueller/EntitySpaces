
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
	/// Encapsulates the 'territories' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Territories))]	
	[XmlType("Territories")]
	public partial class Territories : esTerritories
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Territories();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.String territoryID)
		{
			var obj = new Territories();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.String territoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new Territories();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("TerritoriesCollection")]
	public partial class TerritoriesCollection : esTerritoriesCollection, IEnumerable<Territories>
	{
		public Territories FindByPrimaryKey(System.String territoryID)
		{
			return this.SingleOrDefault(e => e.TerritoryID == territoryID);
		}

		
				
	}



	[Serializable]	
	public partial class TerritoriesQuery : esTerritoriesQuery
	{
		public TerritoriesQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public TerritoriesQuery(string joinAlias, out TerritoriesQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "TerritoriesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TerritoriesQuery query)
		{
			return TerritoriesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TerritoriesQuery(string query)
		{
			return (TerritoriesQuery)TerritoriesQuery.SerializeHelper.FromXml(query, typeof(TerritoriesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esTerritories : esEntity
	{
		public esTerritories()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String territoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String territoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String territoryID)
		{
			TerritoriesQuery query = new TerritoriesQuery();
			query.Where(query.TerritoryID == territoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String territoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("TerritoryID", territoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to territories.TerritoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String TerritoryID
		{
			get => GetSystemString(TerritoriesMetadata.ColumnNames.TerritoryID);
			
			set
			{
				if (!SetSystemString(TerritoriesMetadata.ColumnNames.TerritoryID, value)) return;
				
				OnPropertyChanged(TerritoriesMetadata.PropertyNames.TerritoryID);
			}
		}		
		
		/// <summary>
		/// Maps to territories.TerritoryDescription
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String TerritoryDescription
		{
			get => GetSystemString(TerritoriesMetadata.ColumnNames.TerritoryDescription);
			
			set
			{
				if (!SetSystemString(TerritoriesMetadata.ColumnNames.TerritoryDescription, value)) return;
				
				OnPropertyChanged(TerritoriesMetadata.PropertyNames.TerritoryDescription);
			}
		}		
		
		/// <summary>
		/// Maps to territories.RegionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? RegionID
		{
			get => GetSystemInt32(TerritoriesMetadata.ColumnNames.RegionID);
			
			set
			{
				if (!SetSystemInt32(TerritoriesMetadata.ColumnNames.RegionID, value)) return;
				
				_UpToRegionByRegionID = null;
				OnPropertyChanged("UpToRegionByRegionID");
				OnPropertyChanged(TerritoriesMetadata.PropertyNames.RegionID);
			}
		}		
		
		
		protected internal Region _UpToRegionByRegionID;
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => TerritoriesMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public TerritoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new TerritoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(TerritoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(TerritoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TerritoriesQuery query;		
	}



	[Serializable]
	public abstract class esTerritoriesCollection : esEntityCollection<Territories>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => TerritoriesMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "TerritoriesCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public TerritoriesQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new TerritoriesQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(TerritoriesQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new TerritoriesQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(TerritoriesQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((TerritoriesQuery)paraQuery);
		}

		#endregion
		
		private TerritoriesQuery query;
	}



	[Serializable]
	public abstract class esTerritoriesQuery : esDynamicQuery
	{
		protected override IMetadata Meta => TerritoriesMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "TerritoryID" => TerritoryID,
              "TerritoryDescription" => TerritoryDescription,
              "RegionID" => RegionID,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TerritoryID => new (this, TerritoriesMetadata.ColumnNames.TerritoryID, esSystemType.String);
		
		public esQueryItem TerritoryDescription => new (this, TerritoriesMetadata.ColumnNames.TerritoryDescription, esSystemType.String);
		
		public esQueryItem RegionID => new (this, TerritoriesMetadata.ColumnNames.RegionID, esSystemType.Int32);
		
		#endregion
		
	}


	
	public partial class Territories : esTerritories
	{

				
				
		#region UpToRegionByRegionID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Territories_Region
		/// </summary>
			[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToRegionByRegionID()
		{
				return _UpToRegionByRegionID != null;
		}
		

		[DataMember(Name="UpToRegionByRegionID", EmitDefaultValue = false)]
					
		public Region UpToRegionByRegionID
		{
			get
			{
				if (_UpToRegionByRegionID != null) return _UpToRegionByRegionID;
				
				_UpToRegionByRegionID = new Region();
				_UpToRegionByRegionID.es.Connection.Name = es.Connection.Name;
				SetPreSave("UpToRegionByRegionID", _UpToRegionByRegionID);

				if (_UpToRegionByRegionID == null && RegionID != null)
				{
					if (es.IsLazyLoadDisabled) return _UpToRegionByRegionID;
					
					_UpToRegionByRegionID.Query.Where(_UpToRegionByRegionID.Query.RegionID == RegionID);
					_UpToRegionByRegionID.Query.Load();
				}
				return _UpToRegionByRegionID;
			}
			
			set
			{
				RemovePreSave("UpToRegionByRegionID");
				
				var changed = _UpToRegionByRegionID != value;

				if (value == null)
				{
					RegionID = null;
					_UpToRegionByRegionID = null;
				}
				else
				{
					RegionID = value.RegionID;
					_UpToRegionByRegionID = value;
					SetPreSave("UpToRegionByRegionID", _UpToRegionByRegionID);
				}
				
				if (changed)
				{
					OnPropertyChanged("UpToRegionByRegionID");
				}
			}
		}
		#endregion
		

		#region UpToEmployeesByEmployeeterritories - Many To Many

		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_EmployeeTerritories_Territories
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToEmployeesByEmployeeterritories()
		{
			return _UpToEmployeesByEmployeeterritories is { Count: > 0 };
		}
		

		[DataMember(Name="UpToEmployeesByEmployeeterritories", EmitDefaultValue = false)]
		public EmployeesCollection UpToEmployeesByEmployeeterritories
		{
			get
			{
				if (_UpToEmployeesByEmployeeterritories != null) return _UpToEmployeesByEmployeeterritories;

				_UpToEmployeesByEmployeeterritories = new EmployeesCollection();
				_UpToEmployeesByEmployeeterritories.es.Connection.Name = es.Connection.Name;
				SetPostSave("UpToEmployeesByEmployeeterritories", _UpToEmployeesByEmployeeterritories);

				if (es.IsLazyLoadDisabled || TerritoryID == null) return _UpToEmployeesByEmployeeterritories;

				var m = new EmployeesQuery("m");
				var j = new EmployeeterritoriesQuery("j");
				m.Select(m);
				m.InnerJoin(j).On(m.EmployeeID == j.EmployeeID);
				m.Where(j.TerritoryID == TerritoryID);

				_UpToEmployeesByEmployeeterritories.Load(m);

				return _UpToEmployeesByEmployeeterritories;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (_UpToEmployeesByEmployeeterritories != null) 
				{ 
					RemovePostSave("UpToEmployeesByEmployeeterritories"); 
					_UpToEmployeesByEmployeeterritories = null;
					OnPropertyChanged("UpToEmployeesByEmployeeterritories");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_EmployeeTerritories_Territories
		/// </summary>
		public void AssociateEmployeesByEmployeeterritories(Employees entity)
		{
			if (this._EmployeeterritoriesCollection == null)
			{
				this._EmployeeterritoriesCollection = new EmployeeterritoriesCollection();
				this._EmployeeterritoriesCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeterritoriesCollection", this._EmployeeterritoriesCollection);
			}

			Employeeterritories obj = this._EmployeeterritoriesCollection.AddNew();
			obj.TerritoryID = this.TerritoryID;
			obj.EmployeeID = entity.EmployeeID;
		}
		
		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_EmployeeTerritories_Territories
		/// </summary>
		public void DissociateEmployeesByEmployeeterritories(Employees entity)
		{
			if (this._EmployeeterritoriesCollection == null)
			{
				this._EmployeeterritoriesCollection = new EmployeeterritoriesCollection();
				this._EmployeeterritoriesCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeterritoriesCollection", this._EmployeeterritoriesCollection);
			}

			Employeeterritories obj = this._EmployeeterritoriesCollection.AddNew();
			obj.TerritoryID = this.TerritoryID;
						obj.EmployeeID = entity.EmployeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private EmployeesCollection _UpToEmployeesByEmployeeterritories;
		private EmployeeterritoriesCollection _EmployeeterritoriesCollection;
		#endregion

		#region EmployeeterritoriesByTerritoryID - Zero To Many
		
		public static esPrefetchMap Prefetch_EmployeeterritoriesByTerritoryID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = EmployeeterritoriesByTerritoryID_Delegate,
					PropertyName = "EmployeeterritoriesByTerritoryID",
					MyColumnName = "TerritoryID",
					ParentColumnName = "TerritoryID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void EmployeeterritoriesByTerritoryID_Delegate(esPrefetchParameters data)
		{
			var parent = new TerritoriesQuery(data.NextAlias());
			var me = data.You != null ? data.You as EmployeeterritoriesQuery : new EmployeeterritoriesQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.TerritoryID == me?.TerritoryID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_EmployeeTerritories_Territories
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeEmployeeterritoriesByTerritoryID()
		{
			return _EmployeeterritoriesByTerritoryID is { Count: > 0 };
		}	
		

		[DataMember(Name="EmployeeterritoriesByTerritoryID", EmitDefaultValue = false)]
		public EmployeeterritoriesCollection EmployeeterritoriesByTerritoryID
		{
			get
			{
				if (_EmployeeterritoriesByTerritoryID != null) return _EmployeeterritoriesByTerritoryID;
				
				_EmployeeterritoriesByTerritoryID = new EmployeeterritoriesCollection();
				_EmployeeterritoriesByTerritoryID.es.Connection.Name = es.Connection.Name;
				SetPostSave("EmployeeterritoriesByTerritoryID", _EmployeeterritoriesByTerritoryID);
				
				// ReSharper disable once InvertIf
				if (TerritoryID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_EmployeeterritoriesByTerritoryID.Query.Where(_EmployeeterritoriesByTerritoryID.Query.TerritoryID == TerritoryID);
						_EmployeeterritoriesByTerritoryID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_EmployeeterritoriesByTerritoryID.fks.Add(EmployeeterritoriesMetadata.ColumnNames.TerritoryID, this.TerritoryID);
				}

				return _EmployeeterritoriesByTerritoryID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_EmployeeterritoriesByTerritoryID == null) return;
				RemovePostSave("EmployeeterritoriesByTerritoryID"); 
				_EmployeeterritoriesByTerritoryID = null;
				OnPropertyChanged("EmployeeterritoriesByTerritoryID");
			} 			
		}
		
			
		
		private EmployeeterritoriesCollection _EmployeeterritoriesByTerritoryID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "EmployeeterritoriesByTerritoryID":
					coll = this.EmployeeterritoriesByTerritoryID;
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
			props.Add(new esPropertyDescriptor(this, "EmployeeterritoriesByTerritoryID", typeof(EmployeeterritoriesCollection), new Employeeterritories()));
			return props;
		}
		
	}
	



	[Serializable]
	public partial class TerritoriesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TerritoriesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.TerritoryID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.TerritoryID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 20;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.TerritoryDescription, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.TerritoryDescription;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.RegionID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.RegionID;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static TerritoriesMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string TerritoryID = "TerritoryID";
			 public const string TerritoryDescription = "TerritoryDescription";
			 public const string RegionID = "RegionID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TerritoryID = "TerritoryID";
			 public const string TerritoryDescription = "TerritoryDescription";
			 public const string RegionID = "RegionID";
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
			lock (typeof(TerritoriesMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new TerritoriesMetadata();
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


				specMeta.AddTypeMap("TerritoryID", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("TerritoryDescription", new esTypeMap("VARCHAR", "System.String"));
				specMeta.AddTypeMap("RegionID", new esTypeMap("INT", "System.Int32"));			
				
				
				
				specMeta.Source = "territories";
				specMeta.Destination = "territories";
				
				specMeta.spInsert = "proc_territoriesInsert";				
				specMeta.spUpdate = "proc_territoriesUpdate";		
				specMeta.spDelete = "proc_territoriesDelete";
				specMeta.spLoadAll = "proc_territoriesLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_territoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static TerritoriesMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
