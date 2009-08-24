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
    /// Collection class for aspnet_Membership domain class.
    /// </summary>
    [Serializable()]
    public class aspnet_MembershipCollection : List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership> {
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
        new public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership aspnet_Membership) {
            base.Add(aspnet_Membership);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Add method to add a new record to the collection by passing a recordset.
        /// </summary>
        public void Add(Textfyre.TextfyreWeb.BusinessLayer.aspnet_MembershipRecordset recordset) {
            this.Add(new aspnet_Membership(recordset));
        }

        /// <summary>
        /// Remove method to remove a record from the collection by passing a domain object.
        /// </summary>
        new public void Remove(Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership aspnet_Membership) {
            base.Remove(aspnet_Membership);
            _isCollectionDirty = true;
        }

        /// <summary>
        /// Fill a recordset with cloned objects from internal recordset.
        /// </summary>
        public void Fill(List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_MembershipRecordset> aspnet_MembershipRecs) {
            this.Clear();            
            foreach (Textfyre.TextfyreWeb.BusinessLayer.aspnet_MembershipRecordset rec in aspnet_MembershipRecs)
                Add((Textfyre.TextfyreWeb.BusinessLayer.aspnet_MembershipRecordset)rec.Clone());
        }

        public void Sort(Textfyre.TextfyreWeb.DataLayer.aspnet_MembershipFields sortField, SortDirection sortDirection)
        {
            switch (sortField)
            {
				case DataLayer.aspnet_MembershipFields.ApplicationId:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.ApplicationIdColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.ApplicationIdColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.UserId:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.UserIdColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.UserIdColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.Password:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.PasswordColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.PasswordColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.PasswordFormat:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.PasswordFormatColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.PasswordFormatColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.PasswordSalt:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.PasswordSaltColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.PasswordSaltColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.MobilePIN:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.MobilePINColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.MobilePINColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.Email:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.EmailColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.EmailColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.LoweredEmail:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.LoweredEmailColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.LoweredEmailColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.PasswordQuestion:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.PasswordQuestionColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.PasswordQuestionColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.PasswordAnswer:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.PasswordAnswerColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.PasswordAnswerColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.IsApproved:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.IsApprovedColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.IsApprovedColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.IsLockedOut:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.IsLockedOutColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.IsLockedOutColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.CreateDate:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.CreateDateColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.CreateDateColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.LastLoginDate:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.LastLoginDateColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.LastLoginDateColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.LastPasswordChangedDate:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.LastPasswordChangedDateColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.LastPasswordChangedDateColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.LastLockoutDate:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.LastLockoutDateColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.LastLockoutDateColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.FailedPasswordAttemptCount:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.FailedPasswordAttemptCountColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.FailedPasswordAttemptCountColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.FailedPasswordAttemptWindowStart:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.FailedPasswordAttemptWindowStartColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.FailedPasswordAttemptWindowStartColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.FailedPasswordAnswerAttemptCount:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.FailedPasswordAnswerAttemptCountColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.FailedPasswordAnswerAttemptCountColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.FailedPasswordAnswerAttemptWindowStart:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.FailedPasswordAnswerAttemptWindowStartColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.FailedPasswordAnswerAttemptWindowStartColumnASC);
					break;
				case DataLayer.aspnet_MembershipFields.Comment:
					if (sortDirection == SortDirection.Descending)
						Sort(aspnet_Membership.SortBy.CommentColumnDESC);
					else
						Sort(aspnet_Membership.SortBy.CommentColumnASC);
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

        public List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership> GetPage(int pageSize, int pageNumber)
        {
            int beginIndex = ((pageNumber - 1) * pageSize); // start at 0 so pages are offset -1
            int endIndex = beginIndex + pageSize - 1;

            List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership> returnCollection = new List<Textfyre.TextfyreWeb.BusinessLayer.aspnet_Membership>();

            for (int row = beginIndex; row < endIndex; row++)
            {
                returnCollection.Add(this[row]);
            }

            return returnCollection;
        }
    }

}