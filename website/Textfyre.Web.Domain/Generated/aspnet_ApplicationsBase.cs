/*
 *  DO NOT EDIT THIS CLASS.
 * 
 *  This class is generated by a tool and should not be edited. If you need to change the functionality of 
 *  this class, you should discuss your changes with the team and they should be implemented in the
 *  appropriate template.
 *  
 */
using System; 
using System.Data; 
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using Textfyre.TextfyreWeb.DataLayer;

namespace Textfyre.TextfyreWeb.BusinessLayer { 
    
    /// <summary>
    /// Base aspnet_Applications domain class. This class is generated for each build and should never be modified
    /// directly. To change the functionality, the domainBase.cs template should be modified and related code
    /// generations tested.
    /// </summary>
    [Serializable()]
    public abstract class aspnet_ApplicationsBase : INotifyPropertyChanged {

        #region Members
        /// <summary>
        /// Internal items collection for the aspnet_Applications domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsCollection _items = new aspnet_ApplicationsCollection();
        /// <summary>
        /// Internal recordset for the aspnet_Applications domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset _recordset = new aspnet_ApplicationsRecordset();

        /// <summary>
        /// Non-serialized instance of the aspnet_Applications data layer class.
        /// </summary>
        [NonSerialized]
        private Textfyre.TextfyreWeb.DataLayer.aspnet_ApplicationsData _dataFactory;

        /// <summary>
        /// String constant containing 'aspnet_Applications'.
        /// </summary>
        private const string TABLE_NAME = "aspnet_Applications";

        /// <summary>
        /// Property Changed event definition.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify Property changed event handler.
        /// </summary>
        private void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
        
        #region Constructors
        /// <summary> 
        /// Empty default constructor. 
        /// </summary> 
        public aspnet_ApplicationsBase() {
            _dataFactory = new aspnet_ApplicationsData();
        }

        public aspnet_ApplicationsBase(Guid ApplicationId) : this() {
				Load(ApplicationId);
		}                     
        
        /// <summary> 
        /// Recordset constructor. 
        /// </summary> 
        public aspnet_ApplicationsBase(Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset Recordset) : this() {             
            _recordset = Recordset; 
            _recordset.IsDirty = false; 
        }
        #endregion 
        
        #region Methods
        
        /// <summary>
        /// Load method that retrieves a record from the aspnet_Applications table by the primary key id.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset Load(Guid ApplicationId) {
            _recordset = DataFactory.Getaspnet_ApplicationsById(ApplicationId);
            return _recordset;
        }

        /// <summary>
        /// LoadAll function that will load all records from the aspnet_Applications table.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsCollection LoadAll() {
            Fill(DataFactory.GetAllaspnet_Applications());
            return _items;
        }

        /// <summary>
        /// Mark a record for deletion. Record is not physically deleted until .Save() is called.
        /// </summary>
        public virtual void Delete() {
            _recordset.IsDeleted = true;
        }

        /// <summary>
        /// Delete a record and commit the deletion to the database.
        /// </summary>
        public virtual void DeleteNow() {
            _recordset.IsDeleted = true;
            Save();
        }

        /// <summary>
        /// Overload for calling save without concern for the new primary key on insert.
        /// </summary>
        public virtual int Save() {
            Guid newPrimaryKey;
            return Save(out newPrimaryKey);
        }

        /// <summary>
        /// Save the current record to the database.
        /// </summary>
        public virtual int Save(out Guid newPrimaryKey)
        {
            int ReturnValue = -1;
            newPrimaryKey = Guid.Empty;
            
            if (_recordset.IsDeleted) {
                ReturnValue = DataFactory.Deleteaspnet_Applications(_recordset.ApplicationId);                
            } else {
                if (_recordset.ApplicationId == Guid.Empty) {
                    newPrimaryKey = _dataFactory.Insertaspnet_Applications(_recordset);
					if (newPrimaryKey != Guid.Empty)
						ReturnValue = -1;
					else
						ReturnValue = 0;;                    
                } else {
                    if(_recordset.IsDirty) {    
                        ReturnValue = DataFactory.Updateaspnet_Applications(_recordset);                        
                    }
                }

                _recordset.IsDirty = false;
            }

            if (DataFactory.CacheManager != null) {
                string cacheKey = DataFactory.CacheManager.CreateCacheKey(TABLE_NAME, null);
                DataFactory.CacheManager.Remove2(cacheKey);
            }

            return ReturnValue;
        }


        /// <summary>
        /// Fill a collection of recordsets from the data layer list.
        /// </summary>
        protected void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset> recs) {
            Items.Fill(recs);
            _items.IsCollectionDirty = false;
        }
        #endregion

        #region Properties


		public virtual string ApplicationName {
			get { return _recordset.ApplicationName; }
			set {
				if (_recordset.ApplicationName != value) {
					_recordset.ApplicationName = value;
					NotifyPropertyChanged("ApplicationName");
				}
			}
		}

		public virtual string LoweredApplicationName {
			get { return _recordset.LoweredApplicationName; }
			set {
				if (_recordset.LoweredApplicationName != value) {
					_recordset.LoweredApplicationName = value;
					NotifyPropertyChanged("LoweredApplicationName");
				}
			}
		}

		public virtual Guid ApplicationId {
			get { return _recordset.ApplicationId; }
			set {
				if (_recordset.ApplicationId != value) {
					_recordset.ApplicationId = value;
					NotifyPropertyChanged("ApplicationId");
				}
			}
		}

		public virtual string Description {
			get { return _recordset.Description; }
			set {
				if (_recordset.Description != value) {
					_recordset.Description = value;
					NotifyPropertyChanged("Description");
				}
			}
		}


        /// <summary>
        /// Current recordset.
        /// </summary>
        public virtual Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset Recordset { 
            get { return _recordset; } 
            set { _recordset = value; } 
        } 
        
        /// <summary>
        /// Flag that identifies a modified record.
        /// </summary>
        public virtual bool IsDirty { 
            get { return _recordset.IsDirty; } 
            set { _recordset.IsDirty = value; } 
        } 

        /// <summary>
        /// Instance of DataBase class to enable data layer execution.
        /// </summary>
        protected Textfyre.TextfyreWeb.DataLayer.aspnet_ApplicationsData DataFactory { 
            get {
                if (_dataFactory == null)
                    _dataFactory = new aspnet_ApplicationsData();
                return _dataFactory;
            } 
        }

        /// <summary>
        /// Collection of records.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsCollection Items {
            get {
                if (_items == null)
                    _items = new Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsCollection();
                return _items;
            }
            set {
                _items = value;
            }
        }

        /// <summary>
        /// Collection of recordsets.
        /// </summary>
        public List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset> ItemsData {
            get {
                List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset> recs = new List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset>();
                foreach(Textfyre.TextfyreWeb.BusinessLayer.aspnet_Applications entity in Items) {
                    recs.Add((Textfyre.TextfyreWeb.BusinessLayer.aspnet_ApplicationsRecordset)entity.Recordset.Clone());
                }

                return recs;
            }
        }
        #endregion

        #region Sorting Delegates
        /// <summary>
        /// Internal class containing sorting delegates.
        /// </summary>
        public class SortBy
        {
			public static Comparison<aspnet_Applications> ApplicationNameColumnASC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o1.ApplicationName.CompareTo(o2.ApplicationName);
				};

			public static Comparison<aspnet_Applications> ApplicationNameColumnDESC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o2.ApplicationName.CompareTo(o1.ApplicationName);
				};

			public static Comparison<aspnet_Applications> LoweredApplicationNameColumnASC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o1.LoweredApplicationName.CompareTo(o2.LoweredApplicationName);
				};

			public static Comparison<aspnet_Applications> LoweredApplicationNameColumnDESC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o2.LoweredApplicationName.CompareTo(o1.LoweredApplicationName);
				};

			public static Comparison<aspnet_Applications> ApplicationIdColumnASC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o1.ApplicationId.CompareTo(o2.ApplicationId);
				};

			public static Comparison<aspnet_Applications> ApplicationIdColumnDESC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o2.ApplicationId.CompareTo(o1.ApplicationId);
				};

			public static Comparison<aspnet_Applications> DescriptionColumnASC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o1.Description.CompareTo(o2.Description);
				};

			public static Comparison<aspnet_Applications> DescriptionColumnDESC =
				delegate(aspnet_Applications o1, aspnet_Applications o2)
				{
					return o2.Description.CompareTo(o1.Description);
				};


        }

        #endregion
    } 
} 