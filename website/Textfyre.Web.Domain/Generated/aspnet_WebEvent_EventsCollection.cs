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
    /// Collection class for aspnet_WebEvent_Events domain class.
    /// </summary>
    [Serializable()]
    public class aspnet_WebEvent_EventsCollection : List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events> {
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
        new public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events aspnet_WebEvent_Events) {
            base.Add(aspnet_WebEvent_Events);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Add method to add a new record to the collection by passing a recordset.
        /// </summary>
        public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_EventsRecordset recordset) {
            this.Add(new aspnet_WebEvent_Events(recordset));
        }

        /// <summary>
        /// Remove method to remove a record from the collection by passing a domain object.
        /// </summary>
        new public void Remove(Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events aspnet_WebEvent_Events) {
            base.Remove(aspnet_WebEvent_Events);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Fill a recordset with cloned objects from internal recordset.
        /// </summary>
        public void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_EventsRecordset> aspnet_WebEvent_EventsRecs) {
            this.Clear();            
            foreach (Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_EventsRecordset rec in aspnet_WebEvent_EventsRecs)
                Add((Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_EventsRecordset)rec.Clone());
        }

        public void Sort(Textfyre.TextfyreWeb.DataLayer.aspnet_WebEvent_EventsFields sortField, SortDirection sortDirection)
        {
            switch (sortField)
            {
				case DataLayer.aspnet_WebEvent_EventsFields.EventId:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventIdColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventIdColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventTimeUtc:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventTimeUtcColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventTimeUtcColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventTime:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventTimeColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventTimeColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventType:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventTypeColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventTypeColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventSequence:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventSequenceColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventSequenceColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventOccurrence:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventOccurrenceColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventOccurrenceColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventCode:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventCodeColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventCodeColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.EventDetailCode:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.EventDetailCodeColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.EventDetailCodeColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.Message:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.MessageColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.MessageColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.ApplicationPath:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.ApplicationPathColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.ApplicationPathColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.ApplicationVirtualPath:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.ApplicationVirtualPathColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.ApplicationVirtualPathColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.MachineName:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.MachineNameColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.MachineNameColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.RequestUrl:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.RequestUrlColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.RequestUrlColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.ExceptionType:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.ExceptionTypeColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.ExceptionTypeColumnASC);
					break;
				case DataLayer.aspnet_WebEvent_EventsFields.Details:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_WebEvent_Events.SortBy.DetailsColumnDESC);
					else
						Sort(aspnet_WebEvent_Events.SortBy.DetailsColumnASC);
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

        public List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events> GetPage(int pageSize, int pageNumber)
        {
            int beginIndex = ((pageNumber - 1) * pageSize); // start at 0 so pages are offset -1
            int endIndex = beginIndex + pageSize - 1;

            List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events> returnCollection = new List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_WebEvent_Events>();

            for (int row = beginIndex; row < endIndex; row++)
            {
                returnCollection.Add(this[row]);
            }

            return returnCollection;
        }
    }

}