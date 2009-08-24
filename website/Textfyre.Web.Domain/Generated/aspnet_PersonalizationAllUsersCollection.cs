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
using System.Configuration;
using System.Collections.Generic;
using Textfyre.Common.BusinessLayer;

namespace Textfyre.TextfyreWeb.BusinessLayer {

    /// <summary>
    /// Collection class for aspnet_PersonalizationAllUsers domain class.
    /// </summary>
    [Serializable()]
    public class aspnet_PersonalizationAllUsersCollection : List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers> {
        /// <summary>
        /// Flag identifies when collection has been modified (updated record, added record, deleted record).
        /// </summary>
        private bool _isCollectionDirty;
        /// <summary>
        /// Public property for _isCollectionDirty.
        /// </summary>
        public bool IsCollectionDirty { get { return _isCollectionDirty; } set { _isCollectionDirty = value; } }

        /// <summary>
        /// Add method to add a new record to the collection by passing a domain object.
        /// </summary>
        new public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers) {
            base.Add(aspnet_PersonalizationAllUsers);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Add method to add a new record to the collection by passing a recordset.
        /// </summary>
        public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsersRecordset recordset) {
            this.Add(new aspnet_PersonalizationAllUsers(recordset));
        }

        /// <summary>
        /// Remove method to remove a record from the collection by passing a domain object.
        /// </summary>
        new public void Remove(Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers) {
            base.Remove(aspnet_PersonalizationAllUsers);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Fill a recordset with cloned objects from internal recordset.
        /// </summary>
        public void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsersRecordset> aspnet_PersonalizationAllUsersRecs) {
            this.Clear();            
            foreach (Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsersRecordset rec in aspnet_PersonalizationAllUsersRecs)
                Add((Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsersRecordset)rec.Clone());
        }

        public void Sort(Textfyre.TextfyreWeb.DataLayer.aspnet_PersonalizationAllUsersFields sortField, SortDirection sortDirection)
        {
            switch (sortField)
            {
				case DataLayer.aspnet_PersonalizationAllUsersFields.PathId:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_PersonalizationAllUsers.SortBy.PathIdColumnDESC);
					else
						Sort(aspnet_PersonalizationAllUsers.SortBy.PathIdColumnASC);
					break;
				case DataLayer.aspnet_PersonalizationAllUsersFields.LastUpdatedDate:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_PersonalizationAllUsers.SortBy.LastUpdatedDateColumnDESC);
					else
						Sort(aspnet_PersonalizationAllUsers.SortBy.LastUpdatedDateColumnASC);
					break;

            }
        }

        public int PageCount(int pageSize)
        {
            int pageCount = this.Count / pageSize;
            if ((int)(this.Count / pageSize * pageSize) == this.Count)
                return pageCount;
            else
                return pageCount + 1;
        }

        public List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers> GetPage(int pageSize, int pageNumber)
        {
            int beginIndex = ((pageNumber - 1) * pageSize); // start at 0 so pages are offset -1
            int endIndex = beginIndex + pageSize - 1;

            List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers> returnCollection = new List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_PersonalizationAllUsers>();

            for (int row = beginIndex; row < endIndex; row++)
            {
                returnCollection.Add(this[row]);
            }

            return returnCollection;
        }
    }

}
