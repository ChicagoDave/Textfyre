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
    /// Base Platform domain class. This class is generated for each build and should never be modified
    /// directly. To change the functionality, the domainBase.cs template should be modified and related code
    /// generations tested.
    /// </summary>
    [Serializable()]
    public abstract class PlatformBase : INotifyPropertyChanged {

        #region Members
        /// <summary>
        /// Internal items collection for the Platform domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.PlatformCollection _items = new PlatformCollection();
        /// <summary>
        /// Internal recordset for the Platform domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset _recordset = new PlatformRecordset();

        /// <summary>
        /// Non-serialized instance of the Platform data layer class.
        /// </summary>
        [NonSerialized]
        private Textfyre.TextfyreWeb.DataLayer.PlatformData _dataFactory;

        /// <summary>
        /// String constant containing 'Platform'.
        /// </summary>
        private const string TABLE_NAME = "Platform";

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
        public PlatformBase() {
            _dataFactory = new PlatformData();
        }

        public PlatformBase(Int32 PlatformId) : this() {
				Load(PlatformId);
		}                     
        
        /// <summary> 
        /// Recordset constructor. 
        /// </summary> 
        public PlatformBase(Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset Recordset) : this() {             
            _recordset = Recordset; 
            _recordset.IsDirty = false; 
        }
        #endregion 
        
        #region Methods
        
        /// <summary>
        /// Load method that retrieves a record from the Platform table by the primary key id.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset Load(Int32 PlatformId) {
            _recordset = DataFactory.GetPlatformById(PlatformId);
            return _recordset;
        }

        /// <summary>
        /// LoadAll function that will load all records from the Platform table.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.PlatformCollection LoadAll() {
            Fill(DataFactory.GetAllPlatform());
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
            Int32 newPrimaryKey;
            return Save(out newPrimaryKey);
        }

        /// <summary>
        /// Save the current record to the database.
        /// </summary>
        public virtual int Save(out Int32 newPrimaryKey)
        {
            int ReturnValue = -1;
            newPrimaryKey = -1;
            
            if (_recordset.IsDeleted) {
                ReturnValue = DataFactory.DeletePlatform(_recordset.PlatformId);                
            } else {
                if (_recordset.PlatformId == -1) {
                    newPrimaryKey = _dataFactory.InsertPlatform(_recordset);
					if (newPrimaryKey != -1)
						ReturnValue = -1;
					else
						ReturnValue = 0;;                    
                } else {
                    if(_recordset.IsDirty) {    
                        ReturnValue = DataFactory.UpdatePlatform(_recordset);                        
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
        protected void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset> recs) {
            Items.Fill(recs);
            _items.IsCollectionDirty = false;
        }
        #endregion

        #region Properties


		public virtual Int32 PlatformId {
			get { return _recordset.PlatformId; }
			set {
				if (_recordset.PlatformId != value) {
					_recordset.PlatformId = value;
					NotifyPropertyChanged("PlatformId");
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
        public virtual Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset Recordset { 
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
        protected Textfyre.TextfyreWeb.DataLayer.PlatformData DataFactory { 
            get {
                if (_dataFactory == null)
                    _dataFactory = new PlatformData();
                return _dataFactory;
            } 
        }

        /// <summary>
        /// Collection of records.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.PlatformCollection Items {
            get {
                if (_items == null)
                    _items = new Textfyre.TextfyreWeb.BusinessLayer.PlatformCollection();
                return _items;
            }
            set {
                _items = value;
            }
        }

        /// <summary>
        /// Collection of recordsets.
        /// </summary>
        public List<Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset> ItemsData {
            get {
                List<Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset> recs = new List<Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset>();
                foreach(Textfyre.TextfyreWeb.BusinessLayer.Platform entity in Items) {
                    recs.Add((Textfyre.TextfyreWeb.BusinessLayer.PlatformRecordset)entity.Recordset.Clone());
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
			public static Comparison<Platform> PlatformIdColumnASC =
					delegate(Platform o1, Platform o2)
					{
						return Nullable.Compare<Int32>(o1.PlatformId, o2.PlatformId);
					};

			public static Comparison<Platform> PlatformIdColumnDESC =
					delegate(Platform o1, Platform o2)
					{
						return Nullable.Compare<Int32>(o2.PlatformId, o1.PlatformId);
					};

			public static Comparison<Platform> DescriptionColumnASC =
				delegate(Platform o1, Platform o2)
				{
					return o1.Description.CompareTo(o2.Description);
				};

			public static Comparison<Platform> DescriptionColumnDESC =
				delegate(Platform o1, Platform o2)
				{
					return o2.Description.CompareTo(o1.Description);
				};


        }

        #endregion
    } 
} 