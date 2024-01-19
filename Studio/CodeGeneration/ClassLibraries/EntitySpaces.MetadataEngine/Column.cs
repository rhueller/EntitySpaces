using System;
using System.ComponentModel;
using System.Xml;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace EntitySpaces.MetadataEngine
{
	public class Column : Single, IColumn, INameValueItem
	{
        protected Column()
		{

		}

		internal virtual Column Clone()
		{
			var c = (Column)dbRoot.ClassFactory.CreateColumn();

			c.dbRoot	= dbRoot;
			c.Columns	= Columns;
			c._row		= _row;

			c._foreignKeys	= _emptyForeignKeys;

			return c;
        }

        #region Code Generation Properties

        [Category("Code Generation")]
        public virtual string PropertyName => dbRoot.esPlugIn.PropertyName(this);

        [Category("Code Generation")]
        public virtual string CSharpToSystemType => esPlugIn.CSharpToSystemType(this);

        [Category("Code Generation")]
        public virtual string VBToSystemType => dbRoot.esPlugIn.VBToSystemType(this);

        [Category("Code Generation")]
        public virtual string esSystemType => dbRoot.esPlugIn.esSystemType(this);

        [Category("Code Generation")]
        public virtual string ParameterName => dbRoot.esPlugIn.ParameterName(this);

        [Category("Code Generation")]
        public virtual bool IsArrayType => dbRoot.esPlugIn.IsArrayType(this);

        [Category("Code Generation")]
        public virtual bool IsObjectType => dbRoot.esPlugIn.IsObjectType(this);

        [Category("Code Generation")]
        public virtual bool IsNullableType => dbRoot.esPlugIn.IsNullableType(this);

        [Category("Code Generation")]
        public virtual string NullableType => dbRoot.esPlugIn.NullableType(this);

        [Category("Code Generation")]
        public virtual string NullableTypeVB => dbRoot.esPlugIn.NullableTypeVB(this);

        [Category("Code Generation")]
        public virtual string SetRowAccessor => dbRoot.esPlugIn.SetRowAccessor(this);

        [Category("Code Generation")]
        public virtual string GetRowAccessor => dbRoot.esPlugIn.GetRowAccessor(this);

        #endregion

        #region Objects

        [Browsable(false)]
		public ITable Table
		{
			get
			{
				ITable theTable = null;

				if(null != Columns.Table)
				{
					theTable = Columns.Table;
				}
				else if(null != Columns.Index)
				{
					theTable =  Columns.Index.Indexes.Table;
				}
				else if(null != Columns.ForeignKey)
				{
					theTable =  Columns.ForeignKey.ForeignKeys.Table;
				}

				return theTable;
			}
		}

        [Browsable(false)]
		public IView View
		{
			get
			{
				IView theView = null;

				if(null != Columns.View)
				{
					theView = Columns.View;
				}

				return theView;
			}
		}

        [Category("Domain")]
		public IDomain Domain
		{
			get
			{
				IDomain theDomain = null;

				if(HasDomain)
				{
					theDomain = Columns.GetDatabase().Domains[DomainName];
				}

				return theDomain;
			}
		}

		#endregion

		#region Properties

        [Category("Name")]
		public override string Name => GetString(Columns.f_Name);

        [Browsable(false)]
		public virtual Guid Guid => GetGuid(Columns.f_Guid);

        [Browsable(false)]
		public virtual int PropID => GetInt32(Columns.f_PropID);

        [Browsable(false)]
		public virtual int Ordinal => GetInt32(Columns.f_Ordinal);

        [Category("Default Value")]
		public virtual bool HasDefault => GetBool(Columns.f_HasDefault);

        [Category("Default Value")]
		public virtual string Default => GetString(Columns.f_Default);

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int Flags => GetInt32(Columns.f_Flags);

        [Category("Flags")]
		public virtual bool IsNullable => GetBool(Columns.f_IsNullable);

        [Browsable(false)]
		public virtual int DataType => GetInt32(Columns.f_DataType);

        [Category("Data Type")]
        public virtual bool IsNonSystemType
        {
            get
            {
                if (dbRoot.LanguageNode == null) return false;
                
                // First Let's try the 'DataTypeNameComplete' or char(1)
                var xPath = "./Type[@From='" + DataTypeNameComplete + "']";
                var node = dbRoot.LanguageNode.SelectSingleNode(xPath, null);

                if (node != null)
                {
                    if (GetUserData(node, "NonSystemType", out var flag))
                    {
                        return flag == "true";
                    }
                }

                // No match, so lets just try the 'DataTypeName' or char
                xPath = @"./Type[@From='" + DataTypeName + "']";
                node = dbRoot.LanguageNode.SelectSingleNode(xPath, null);

                if (node == null) return false;
                
                {
                    if (GetUserData(node, "NonSystemType", out var flag))
                    {
                        return flag == "true";
                    }
                }

                return false;
            }
        }

        [Browsable(false)]
		public virtual Guid TypeGuid => GetGuid(Columns.f_TypeGuid);

        [Category("Character")]
		public virtual int CharacterMaxLength => GetInt32(Columns.f_MaxLength);

        [Browsable(false)]
		public virtual int CharacterOctetLength => GetInt32(Columns.f_OctetLength);

        [Category("Numeric")]
		public virtual int NumericPrecision => GetInt32(Columns.f_NumericPrecision);

        [Category("Numeric")]
		public virtual int NumericScale => GetInt32(Columns.f_NumericScale);

        [Browsable(false)]
		public virtual int DateTimePrecision => GetInt32(Columns.f_DatetimePrecision);

        [Browsable(false)]
		public virtual string CharacterSetCatalog => GetString(Columns.f_CharSetCatalog);

        [Browsable(false)]
		public virtual string CharacterSetSchema => GetString(Columns.f_CharSetSchema);

        [Browsable(false)]
		public virtual string CharacterSetName => GetString(Columns.f_CharSetName);

        [Category("Domain")]
		public virtual string DomainCatalog => GetString(Columns.f_DomainCatalog);

        [Category("Domain")]
		public virtual string DomainSchema => GetString(Columns.f_DomainSchema);

        [Category("Domain")]
		public virtual string DomainName => GetString(Columns.f_DomainName);

        public virtual string Description => GetString(Columns.f_Description);

        [Browsable(false)]
		public virtual int LCID => GetInt32(Columns.f_LCID);

        [Browsable(false)]
		public virtual int CompFlags => GetInt32(Columns.f_CompFlags);

        [Browsable(false)]
		public virtual int SortID => GetInt32(Columns.f_SortID);

        [Browsable(false)]
		public virtual byte[] TDSCollation => GetByteArray(Columns.f_TDSCollation);

        [Category("Flags")]
		public virtual bool IsComputed
		{
			get
			{
                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if (GetUserData(node, "IsComputed", out theOut))
                    {
                        return Convert.ToBoolean(theOut);
                    }
                }

				return GetBool(Columns.f_IsComputed);
			}

            //set
            //{
            //    XmlNode node = null;
            //    if (this.GetXmlNode(out node, true))
            //    {
            //        this.SetUserData(node, "IsComputed", value.ToString());
            //    }
            //}
		}

        [Category("Flags")]
		public virtual bool IsInPrimaryKey
		{
			get
			{
                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if (GetUserData(node, "IsInPrimaryKey", out theOut))
                    {
                        return Convert.ToBoolean(theOut);
                    }
                }

				var isPrimaryKey = false;

				if(null != Columns.Table)
				{
					var c = Columns.Table.PrimaryKeys[Name];

					if(null != c)
					{
						isPrimaryKey = true;
					}
				}

				return isPrimaryKey;
			}

            //set
            //{
            //    XmlNode node = null;
            //    if (this.GetXmlNode(out node, true))
            //    {
            //        this.SetUserData(node, "IsInPrimaryKey", value.ToString());
            //    }
            //}
		}

        [Category("Auto Key")]
		public virtual bool IsAutoKey
		{
			get
			{
                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if (GetUserData(node, "IsAutoKey", out theOut))
                    {
                        return Convert.ToBoolean(theOut);
                    }
                }

				return GetBool(Columns.f_IsAutoKey);
			}

            set
            {
                XmlNode node = null;
                if (GetXmlNode(out node, true))
                {
                    SetUserData(node, "IsAutoKey", value.ToString());
                }
            }
		}

        [Category("Data Type")]
		public virtual string DataTypeName
		{
			get
			{
				if(dbRoot.DomainOverride)
				{
					if(HasDomain)
					{
						if(Domain != null)
						{
							return Domain.DataTypeName;
						}
					}
				}

				return GetString(null);
			}
		}

        [Category("Data Type")]
		public virtual string LanguageType
		{
			get
			{
				if(dbRoot.DomainOverride)
				{
					if(HasDomain)
					{
						if(Domain != null)
						{
							return Domain.LanguageType;
						}
					}
				}

                if (dbRoot.LanguageNode != null)
                {
                    // First Let's try the 'DataTypeNameComplete' or char(1)
                    var xPath = @"./Type[@From='" + DataTypeNameComplete + "']";

                    XmlNode node = null;

                    try
                    {
                        node = dbRoot.LanguageNode.SelectSingleNode(xPath, null);
                    }
                    catch { }

                    if (node != null)
                    {
                        var languageType = "";
                        if (GetUserData(node, "To", out languageType))
                        {
                            return languageType;
                        }
                    }

                    // No match, so lets just try the 'DataTypeName' or char
					xPath = @"./Type[@From='" + DataTypeName + "']";
					node = dbRoot.LanguageNode.SelectSingleNode(xPath, null);

					if(node != null)
					{
						var languageType = "";
						if(GetUserData(node, "To", out languageType))
						{
							return languageType;
						}
					}
				}

				return "Unknown";
			}
		}

        [Category("Data Type")]
		public virtual string DataTypeNameComplete
		{
			get
			{
				if(dbRoot.DomainOverride)
				{
					if(HasDomain)
					{
						if(Domain != null)
						{
                            return Domain.DataTypeNameComplete.Replace("\'", string.Empty);
						}
					}
				}

				return "Unknown";
			}
		}

        [Category("Flags")]
		public virtual bool IsInForeignKey
		{
			get
			{
				if(ForeignKeys == _emptyForeignKeys)
					return true;
				else
					return ForeignKeys.Count > 0 ? true : false;
			}
		}

        [Category("Auto Key")]
		public virtual int AutoKeySeed => GetInt32(Columns.f_AutoKeySeed);

        [Category("Auto Key")]
        [Description("Typically the name of a sequence")]
        public virtual string AutoKeyText
        {
            get
            {
                var customAutoKeyText = "";

                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if (GetUserData(node, "AutoKeyText", out theOut))
                    {
                        customAutoKeyText = theOut;
                    }
                }

                // There was no nice name
                return customAutoKeyText;
            }

            set
            {
                XmlNode node = null;
                if (GetXmlNode(out node, true))
                {
                    SetUserData(node, "AutoKeyText", value.ToString());
                }
            }
        }

        [Category("Auto Key")]
		public virtual int AutoKeyIncrement => GetInt32(Columns.f_AutoKeyIncrement);

        [Category("Domain")]
		public virtual bool HasDomain
		{
			get
			{
				if(_row.Table.Columns.Contains("DOMAIN_NAME"))
				{
					var o = _row["DOMAIN_NAME"];

					if(o != null && o != DBNull.Value)
					{
						return true;
					}
				}
				return false;
			}
        }

        #region DateAdded Properties

        [Category("DateAdded")]
        public virtual bool IsDateAddedColumn
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateAdded.IsEnabled && driverInfo.DateAdded.ColumnName == Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("DateAdded")]
        public virtual esSettingsDriverInfo.DateType DateAddedType
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateAdded.IsEnabled && driverInfo.DateAdded.ColumnName == Name)
                {
                    return driverInfo.DateAdded.Type;
                }
                else
                {
                    return esSettingsDriverInfo.DateType.Unassigned;
                }
            }
        }

        [Category("DateAdded")]
        public virtual string DateAddedServerSideText
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateAdded.IsEnabled && driverInfo.DateAdded.ColumnName == Name && 
                    driverInfo.DateAdded.Type == esSettingsDriverInfo.DateType.ServerSide)
                {
                    return driverInfo.DateAdded.ServerSideText;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Category("DateAdded")]
        public virtual esSettingsDriverInfo.ClientType DateAddedClientType
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateAdded.IsEnabled && driverInfo.DateAdded.ColumnName == Name &&
                    driverInfo.DateAdded.Type == esSettingsDriverInfo.DateType.ClientSide)
                {
                    return driverInfo.DateAdded.ClientType;
                }
                else
                {
                    return esSettingsDriverInfo.ClientType.Unassigned;
                }
            }
        }

        #endregion

        #region DateModified Properties

        [Category("DateModified")]
        public virtual bool IsDateModifiedColumn
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateModified.IsEnabled && driverInfo.DateModified.ColumnName == Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("DateModified")]
        public virtual esSettingsDriverInfo.DateType DateModifiedType
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateModified.IsEnabled && driverInfo.DateModified.ColumnName == Name)
                {
                    return driverInfo.DateModified.Type;
                }
                else
                {
                    return esSettingsDriverInfo.DateType.Unassigned;
                }
            }
        }

        [Category("DateModified")]
        public virtual string DateModifiedServerSideText
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateModified.IsEnabled && driverInfo.DateModified.ColumnName == Name &&
                    driverInfo.DateModified.Type == esSettingsDriverInfo.DateType.ServerSide)
                {
                    return driverInfo.DateModified.ServerSideText;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Category("DateModified")]
        public virtual esSettingsDriverInfo.ClientType DateModifiedClientType
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.DateModified.IsEnabled && driverInfo.DateModified.ColumnName == Name &&
                    driverInfo.DateModified.Type == esSettingsDriverInfo.DateType.ClientSide)
                {
                    return driverInfo.DateModified.ClientType;
                }
                else
                {
                    return esSettingsDriverInfo.ClientType.Unassigned;
                }
            }
        }

        #endregion

        #region AddedBy Properties

        [Category("AddedBy")]
        public virtual bool IsAddedByColumn
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.AddedBy.IsEnabled && driverInfo.AddedBy.ColumnName == Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("AddedBy")]
        public virtual bool UseAddedByEventHandler
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.AddedBy.IsEnabled && driverInfo.AddedBy.UseEventHandler == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("AddedBy")]
        public virtual string AddedByServerSideText
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.AddedBy.IsEnabled && driverInfo.AddedBy.ColumnName == Name)
                {
                    return driverInfo.AddedBy.ServerSideText;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region ModifiedBy Properties

        [Category("ModifiedBy")]
        public virtual bool IsModifiedByColumn
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.ModifiedBy.IsEnabled && driverInfo.ModifiedBy.ColumnName == Name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("ModifiedBy")]
        public virtual bool UseModifiedByEventHandler
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.ModifiedBy.IsEnabled && driverInfo.ModifiedBy.UseEventHandler == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Category("ModifiedBy")]
        public virtual string ModifiedByServerSideText
        {
            get
            {
                var driverInfo = dbRoot.SettingsDriverInfo;
                if (driverInfo.ModifiedBy.IsEnabled && driverInfo.ModifiedBy.ColumnName == Name)
                {
                    return driverInfo.ModifiedBy.ServerSideText;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #endregion

        #region EntitySpaces Extended Properties

        [Category("Name")]
        [Description("Provide your Column with an Alias")]
        public override string Alias
        {
            get
            {
                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    string niceName = null;

                    if (GetUserData(node, "Alias", out niceName))
                    {
                        if (string.Empty != niceName)
                            return niceName;
                    }
                }

                // There was no nice name
                return Name;
            }

            set
            {
                XmlNode node = null;
                if (GetXmlNode(out node, true))
                {
                    SetUserData(node, "Alias", value);
                }
            }
        }

        [Category("Flags")]
        [Description("Exlude this column from code generation")]
        public bool Exclude
        {
            get
            {
                var exclude = "False";

                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if(GetUserData(node, "Exclude", out theOut))
                    {
                        exclude = theOut;
                    }
                }

                // There was no nice name
                return Convert.ToBoolean(exclude);
            }

            //set
            //{
            //    XmlNode node = null;
            //    if (this.GetXmlNode(out node, true))
            //    {
            //        this.SetUserData(node, "Exclude", value.ToString());
            //    }
            //}
        }

        [Category("Concurrency")]
        [Description("Use this integer field for Concurrency management")]
        public virtual bool IsEntitySpacesConcurrency
        {
            get
            {
                var isEntitySpacesConcurrency = "False";

                var driverInfo = dbRoot.SettingsDriverInfo;

                if (driverInfo.ConcurrencyColumnEnabled && driverInfo.ConcurrencyColumn != null && driverInfo.ConcurrencyColumn == Name)
                {
                    isEntitySpacesConcurrency = "True";
                }

                XmlNode node = null;
                if (GetXmlNode(out node, false))
                {
                    var theOut = "";
                    if (GetUserData(node, "IsEntitySpacesConcurrency", out theOut))
                    {
                        isEntitySpacesConcurrency = theOut;
                    }
                }

                // There was no nice name
                return Convert.ToBoolean(isEntitySpacesConcurrency);
            }

            set
            {
                XmlNode node = null;
                if (GetXmlNode(out node, true))
                {
                    SetUserData(node, "IsEntitySpacesConcurrency", value.ToString());
                }
            }
        }

        [Category("Concurrency")]
        [Description("True if this is the Native type for a Database's concurrency handling")]
        public virtual bool IsConcurrency => GetBool(Columns.f_IsConcurrency);

        #endregion

        #region Collections

        [Browsable(false)]
        public IForeignKeys ForeignKeys
		{
			get
			{
				if(null == _foreignKeys)
				{
					_foreignKeys = (ForeignKeys)dbRoot.ClassFactory.CreateForeignKeys();
					_foreignKeys.dbRoot = dbRoot;

					if(Columns.Table != null)
					{
						var fk = Columns.Table.ForeignKeys;
					}
				}
				return _foreignKeys;
			}
		}

		protected internal virtual void AddForeignKey(ForeignKey fk)
		{
			if(null == _foreignKeys)
			{
				_foreignKeys = (ForeignKeys)dbRoot.ClassFactory.CreateForeignKeys();
				_foreignKeys.dbRoot = dbRoot;
			}

			_foreignKeys.AddForeignKey(fk);
		}

		internal PropertyCollectionAll _allProperties = null;

		#endregion

		#region XML User Data

        [Browsable(false)]
		public override string UserDataXPath => Columns.UserDataXPath + @"/Column[@Name='" + Name + "']";

        internal override bool GetXmlNode(out XmlNode node, bool forceCreate)
		{
			node = null;
			var success = false;

			if(null == _xmlNode)
			{
				// Get the parent node
				XmlNode parentNode = null;
				if(Columns.GetXmlNode(out parentNode, forceCreate))
				{
					// See if our user data already exists
					var xPath = @"./Column[@Name='" + Name + "']";
					if(!GetUserData(xPath, parentNode, out _xmlNode) && forceCreate)
					{
						// Create it, and try again
						CreateUserMetaData(parentNode);
						GetUserData(xPath, parentNode, out _xmlNode);
					}
				}
			}

			if(null != _xmlNode)
			{
				node = _xmlNode;
				success = true;
			}

			return success;
		}

		public override void CreateUserMetaData(XmlNode parentNode)
		{
			var myNode = parentNode.OwnerDocument.CreateNode(XmlNodeType.Element, "Column", null);
			parentNode.AppendChild(myNode);

			XmlAttribute attr;

			attr = parentNode.OwnerDocument.CreateAttribute("Name");
			attr.Value = Name;
			myNode.Attributes.Append(attr);
		}

		#endregion

		#region INameValueCollection Members

        [Browsable(false)]
		public string ItemName => Name;

        [Browsable(false)]
		public string ItemValue => Name;

        #endregion

		internal Columns Columns = null;
		protected ForeignKeys _foreignKeys = null;
		private static ForeignKeys _emptyForeignKeys = new ForeignKeys();
	}
}
