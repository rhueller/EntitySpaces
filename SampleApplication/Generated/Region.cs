
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
	/// Encapsulates the 'region' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Region))]	
	[XmlType("Region")]
	public partial class Region : esRegion
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug => base.Debug;

		public override esEntity CreateInstance()
		{
			return new Region();
		}
		
		#region Static Quick Access Methods
		public static void Delete(System.Int32 regionID)
		{
			var obj = new Region();
			obj.RegionID = regionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    public static void Delete(System.Int32 regionID, esSqlAccessType sqlAccessType)
		{
			var obj = new Region();
			obj.RegionID = regionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("RegionCollection")]
	public partial class RegionCollection : esRegionCollection, IEnumerable<Region>
	{
		public Region FindByPrimaryKey(System.Int32 regionID)
		{
			return this.SingleOrDefault(e => e.RegionID == regionID);
		}

		
				
	}



	[Serializable]	
	public partial class RegionQuery : esRegionQuery
	{
		public RegionQuery(string joinAlias)
		{
			es.JoinAlias = joinAlias;
		}	

    public RegionQuery(string joinAlias, out RegionQuery query)
		{
      query = this;
			es.JoinAlias = joinAlias;
		}	

		protected override string GetQueryName()
		{
			return "RegionQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(RegionQuery query)
		{
			return RegionQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator RegionQuery(string query)
		{
			return (RegionQuery)RegionQuery.SerializeHelper.FromXml(query, typeof(RegionQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	public abstract partial class esRegion : esEntity
	{
		public esRegion()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 regionID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(regionID);
			else
				return LoadByPrimaryKeyStoredProcedure(regionID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 regionID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(regionID);
			else
				return LoadByPrimaryKeyStoredProcedure(regionID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 regionID)
		{
			RegionQuery query = new RegionQuery();
			query.Where(query.RegionID == regionID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 regionID)
		{
			esParameters parms = new esParameters();
			parms.Add("RegionID", regionID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to region.RegionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.Int32? RegionID
		{
			get => GetSystemInt32(RegionMetadata.ColumnNames.RegionID);
			
			set
			{
				if (!SetSystemInt32(RegionMetadata.ColumnNames.RegionID, value)) return;
				
				OnPropertyChanged(RegionMetadata.PropertyNames.RegionID);
			}
		}		
		
		/// <summary>
		/// Maps to region.RegionDescription
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		public virtual System.String RegionDescription
		{
			get => GetSystemString(RegionMetadata.ColumnNames.RegionDescription);
			
			set
			{
				if (!SetSystemString(RegionMetadata.ColumnNames.RegionDescription, value)) return;
				
				OnPropertyChanged(RegionMetadata.PropertyNames.RegionDescription);
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		protected override IMetadata Meta => RegionMetadata.Meta();

		#endregion		
		
		#region Query Logic

		public RegionQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new RegionQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(RegionQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}
		
		protected void InitQuery(RegionQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private RegionQuery query;		
	}



	[Serializable]
	public abstract class esRegionCollection : esEntityCollection<Region>
	{
		#region Housekeeping methods
		protected override IMetadata Meta => RegionMetadata.Meta();
		protected override string GetCollectionName()
		{
			return "RegionCollection";
		}
		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[Browsable(false)]
	#endif
		public RegionQuery Query
		{
			get
			{
				if (query != null) return query;
				query = new RegionQuery();
				InitQuery(query);
				return query;
			}
		}

		public bool Load(RegionQuery paraQuery)
		{
			query = paraQuery;
			InitQuery(query);
			return Query.Load();
		}

		protected override esDynamicQuery GetDynamicQuery()
		{
			if (query != null) return query;
			query = new RegionQuery();
			InitQuery(query);
			return query;
		}

		protected void InitQuery(RegionQuery paraQuery)
		{
			paraQuery.OnLoadDelegate = OnQueryLoaded;
			
			if (!paraQuery.es2.HasConnection)
			{
				paraQuery.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery paraQuery)
		{
			InitQuery((RegionQuery)paraQuery);
		}

		#endregion
		
		private RegionQuery query;
	}



	[Serializable]
	public abstract class esRegionQuery : esDynamicQuery
	{
		protected override IMetadata Meta => RegionMetadata.Meta();
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            return name switch
            {
              "RegionID" => RegionID,
              "RegionDescription" => RegionDescription,
              _ => null
            };
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem RegionID => new (this, RegionMetadata.ColumnNames.RegionID, esSystemType.Int32);
		
		public esQueryItem RegionDescription => new (this, RegionMetadata.ColumnNames.RegionDescription, esSystemType.String);
		
		#endregion
		
	}


	
	public partial class Region : esRegion
	{

		#region TerritoriesByRegionID - Zero To Many
		
		public static esPrefetchMap Prefetch_TerritoriesByRegionID
		{
			get
			{
				var map = new esPrefetchMap
				{
					PrefetchDelegate = TerritoriesByRegionID_Delegate,
					PropertyName = "TerritoriesByRegionID",
					MyColumnName = "RegionID",
					ParentColumnName = "RegionID",
					IsMultiPartKey = false
				};
				return map;
			}
		}		
		
		private static void TerritoriesByRegionID_Delegate(esPrefetchParameters data)
		{
			var parent = new RegionQuery(data.NextAlias());
			var me = data.You != null ? data.You as TerritoriesQuery : new TerritoriesQuery(data.NextAlias());

			data.Root ??= me;
			data.Root?.InnerJoin(parent).On(parent.RegionID == me?.RegionID);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Territories_Region
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeTerritoriesByRegionID()
		{
			return _TerritoriesByRegionID is { Count: > 0 };
		}	
		

		[DataMember(Name="TerritoriesByRegionID", EmitDefaultValue = false)]
		public TerritoriesCollection TerritoriesByRegionID
		{
			get
			{
				if (_TerritoriesByRegionID != null) return _TerritoriesByRegionID;
				
				_TerritoriesByRegionID = new TerritoriesCollection();
				_TerritoriesByRegionID.es.Connection.Name = es.Connection.Name;
				SetPostSave("TerritoriesByRegionID", _TerritoriesByRegionID);
				
				// ReSharper disable once InvertIf
				if (RegionID != null)
				{
					if (!es.IsLazyLoadDisabled)
					{
						_TerritoriesByRegionID.Query.Where(_TerritoriesByRegionID.Query.RegionID == RegionID);
						_TerritoriesByRegionID.Query.Load();
					}

					// Auto-hookup Foreign Keys
					_TerritoriesByRegionID.fks.Add(TerritoriesMetadata.ColumnNames.RegionID, this.RegionID);
				}

				return _TerritoriesByRegionID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
				if (_TerritoriesByRegionID == null) return;
				RemovePostSave("TerritoriesByRegionID"); 
				_TerritoriesByRegionID = null;
				OnPropertyChanged("TerritoriesByRegionID");
			} 			
		}
		
			
		
		private TerritoriesCollection _TerritoriesByRegionID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "TerritoriesByRegionID":
					coll = this.TerritoriesByRegionID;
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
			props.Add(new esPropertyDescriptor(this, "TerritoriesByRegionID", typeof(TerritoriesCollection), new Territories()));
			return props;
		}
		
	}
	



	[Serializable]
	public partial class RegionMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected RegionMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ColumnNames.RegionID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = PropertyNames.RegionID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ColumnNames.RegionDescription, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = PropertyNames.RegionDescription;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
		}
		#endregion	
	
		public static RegionMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID => m_dataID;

		public bool MultiProviderMode => false;

		public esColumnMetadataCollection Columns => m_columns;
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string RegionID = "RegionID";
			 public const string RegionDescription = "RegionDescription";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string RegionID = "RegionID";
			 public const string RegionDescription = "RegionDescription";
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
			lock (typeof(RegionMetadata))
			{
				mapDelegates ??= new Dictionary<string, MapToMeta>();
				meta ??= new RegionMetadata();
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


				specMeta.AddTypeMap("RegionID", new esTypeMap("INT", "System.Int32"));
				specMeta.AddTypeMap("RegionDescription", new esTypeMap("VARCHAR", "System.String"));			
				
				
				
				specMeta.Source = "region";
				specMeta.Destination = "region";
				
				specMeta.spInsert = "proc_regionInsert";				
				specMeta.spUpdate = "proc_regionUpdate";		
				specMeta.spDelete = "proc_regionDelete";
				specMeta.spLoadAll = "proc_regionLoadAll";
				specMeta.spLoadByPrimaryKey = "proc_regionLoadByPrimaryKey";
				
				m_providerMetadataMaps["esDefault"] = specMeta;
			}
			
			return m_providerMetadataMaps["esDefault"];
		}

		#endregion

		private static RegionMetadata meta;
		protected static Dictionary<string, MapToMeta> mapDelegates;
		private static int _esDefault = RegisterDelegateesDefault();
	}
}
