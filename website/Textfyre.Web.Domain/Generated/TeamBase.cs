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
    /// Base Team domain class. This class is generated for each build and should never be modified
    /// directly. To change the functionality, the domainBase.cs template should be modified and related code
    /// generations tested.
    /// </summary>
    [Serializable()]
    public abstract class TeamBase : INotifyPropertyChanged {

        #region Members
        /// <summary>
        /// Internal items collection for the Team domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.TeamCollection _items = new TeamCollection();
        /// <summary>
        /// Internal recordset for the Team domain class.
        /// </summary>
        private Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset _recordset = new TeamRecordset();

        /// <summary>
        /// Non-serialized instance of the Team data layer class.
        /// </summary>
        [NonSerialized]
        private Textfyre.TextfyreWeb.DataLayer.TeamData _dataFactory;

        /// <summary>
        /// String constant containing 'Team'.
        /// </summary>
        private const string TABLE_NAME = "Team";

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
        public TeamBase() {
            _dataFactory = new TeamData();
        }

        public TeamBase(Int32 TeamId) : this() {
				Load(TeamId);
		}                     
        
        /// <summary> 
        /// Recordset constructor. 
        /// </summary> 
        public TeamBase(Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset Recordset) : this() {             
            _recordset = Recordset; 
            _recordset.IsDirty = false; 
        }
        #endregion 
        
        #region Methods
        
        /// <summary>
        /// Load method that retrieves a record from the Team table by the primary key id.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset Load(Int32 TeamId) {
            _recordset = DataFactory.GetTeamById(TeamId);
            return _recordset;
        }

        /// <summary>
        /// LoadAll function that will load all records from the Team table.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.TeamCollection LoadAll() {
            Fill(DataFactory.GetAllTeam());
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
                ReturnValue = DataFactory.DeleteTeam(_recordset.TeamId);                
            } else {
                if (_recordset.TeamId == -1) {
                    newPrimaryKey = _dataFactory.InsertTeam(_recordset);
					if (newPrimaryKey != -1)
						ReturnValue = -1;
					else
						ReturnValue = 0;;                    
                } else {
                    if(_recordset.IsDirty) {    
                        ReturnValue = DataFactory.UpdateTeam(_recordset);                        
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
        protected void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset> recs) {
            Items.Fill(recs);
            _items.IsCollectionDirty = false;
        }
        #endregion

        #region Properties


		public virtual Int32 TeamId {
			get { return _recordset.TeamId; }
			set {
				if (_recordset.TeamId != value) {
					_recordset.TeamId = value;
					NotifyPropertyChanged("TeamId");
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
        public virtual Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset Recordset { 
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
        protected Textfyre.TextfyreWeb.DataLayer.TeamData DataFactory { 
            get {
                if (_dataFactory == null)
                    _dataFactory = new TeamData();
                return _dataFactory;
            } 
        }

        /// <summary>
        /// Collection of records.
        /// </summary>
        public Textfyre.TextfyreWeb.BusinessLayer.TeamCollection Items {
            get {
                if (_items == null)
                    _items = new Textfyre.TextfyreWeb.BusinessLayer.TeamCollection();
                return _items;
            }
            set {
                _items = value;
            }
        }

        /// <summary>
        /// Collection of recordsets.
        /// </summary>
        public List<Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset> ItemsData {
            get {
                List<Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset> recs = new List<Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset>();
                foreach(Textfyre.TextfyreWeb.BusinessLayer.Team entity in Items) {
                    recs.Add((Textfyre.TextfyreWeb.BusinessLayer.TeamRecordset)entity.Recordset.Clone());
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
			public static Comparison<Team> TeamIdColumnASC =
					delegate(Team o1, Team o2)
					{
						return Nullable.Compare<Int32>(o1.TeamId, o2.TeamId);
					};

			public static Comparison<Team> TeamIdColumnDESC =
					delegate(Team o1, Team o2)
					{
						return Nullable.Compare<Int32>(o2.TeamId, o1.TeamId);
					};

			public static Comparison<Team> DescriptionColumnASC =
				delegate(Team o1, Team o2)
				{
					return o1.Description.CompareTo(o2.Description);
				};

			public static Comparison<Team> DescriptionColumnDESC =
				delegate(Team o1, Team o2)
				{
					return o2.Description.CompareTo(o1.Description);
				};


        }

        #endregion
    } 
} 