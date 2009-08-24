﻿/*
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
using #systemNamespace#.Common.BusinessLayer;

namespace #rootNamespace#.BusinessLayer {

    /// <summary>
    /// Collection class for #tableName# domain class.
    /// </summary>
    [Serializable()]
    public class #tableName#Collection : List<#rootNamespace#.BusinessLayer.#tableName#> {
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
        new public void Add(#rootNamespace#.BusinessLayer.#tableName# #tableName#) {
            base.Add(#tableName#);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Add method to add a new record to the collection by passing a recordset.
        /// </summary>
        public void Add(#rootNamespace#.BusinessLayer.#tableName#Recordset recordset) {
            this.Add(new #tableName#(recordset));
        }

        /// <summary>
        /// Remove method to remove a record from the collection by passing a domain object.
        /// </summary>
        new public void Remove(#rootNamespace#.BusinessLayer.#tableName# #tableName#) {
            base.Remove(#tableName#);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Fill a recordset with cloned objects from internal recordset.
        /// </summary>
        public void Fill(List<#rootNamespace#.BusinessLayer.#tableName#Recordset> #tableName#Recs) {
            this.Clear();            
            foreach (#rootNamespace#.BusinessLayer.#tableName#Recordset rec in #tableName#Recs)
                Add((#rootNamespace#.BusinessLayer.#tableName#Recordset)rec.Clone());
        }

        public void Sort(#rootNamespace#.DataLayer.#tableName#Fields sortField, SortDirection sortDirection)
        {
            switch (sortField)
            {
#sortingCases#
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

        public List<#rootNamespace#.BusinessLayer.#tableName#> GetPage(int pageSize, int pageNumber)
        {
            int beginIndex = ((pageNumber - 1) * pageSize); // start at 0 so pages are offset -1
            int endIndex = beginIndex + pageSize - 1;

            List<#rootNamespace#.BusinessLayer.#tableName#> returnCollection = new List<#rootNamespace#.BusinessLayer.#tableName#>();

            for (int row = beginIndex; row < endIndex; row++)
            {
                returnCollection.Add(this[row]);
            }

            return returnCollection;
        }
    }

}
