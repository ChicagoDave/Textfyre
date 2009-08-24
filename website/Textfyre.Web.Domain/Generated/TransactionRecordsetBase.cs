/*
 *  DO NOT EDIT THIS CLASS.
 * 
 *  This class is generated by a tool and should not be edited. If you need to change the functionality of 
 *  this class, you should discuss your changes with the team and they should be implemented in the
 *  appropriate template.
 *  
 */
using System;

namespace Textfyre.TextfyreWeb.BusinessLayer {   
    /// <summary>
    /// TransactionRecordsetBase class.
    /// </summary>
    [Serializable()]
    public abstract class TransactionRecordsetBase { 
      #region Members

			/// <summary>
			/// TransactionId field.
			/// </summary>
			private Int32 _TransactionId;
			/// <summary>
			/// PayerEmail field.
			/// </summary>
			private string _PayerEmail;
			/// <summary>
			/// EJTransactionId field.
			/// </summary>
			private string _EJTransactionId;
			/// <summary>
			/// FirstName field.
			/// </summary>
			private string _FirstName;
			/// <summary>
			/// LastName field.
			/// </summary>
			private string _LastName;
			/// <summary>
			/// MCGross field.
			/// </summary>
			private decimal? _MCGross = null;
			/// <summary>
			/// Shipping field.
			/// </summary>
			private decimal? _Shipping = null;
			/// <summary>
			/// Tax field.
			/// </summary>
			private decimal? _Tax = null;
			/// <summary>
			/// InvoiceId field.
			/// </summary>
			private string _InvoiceId;
			/// <summary>
			/// Street field.
			/// </summary>
			private string _Street;
			/// <summary>
			/// City field.
			/// </summary>
			private string _City;
			/// <summary>
			/// State field.
			/// </summary>
			private string _State;
			/// <summary>
			/// ZipCode field.
			/// </summary>
			private string _ZipCode;
			/// <summary>
			/// CountryCode field.
			/// </summary>
			private string _CountryCode;
			/// <summary>
			/// Phone field.
			/// </summary>
			private string _Phone;
			/// <summary>
			/// PayerPhone field.
			/// </summary>
			private string _PayerPhone;
      /// <summary>
      /// _isDirty field.
      /// </summary>
      private bool _isDirty = false;
      /// <summary>
      /// _isDeleted field.
      /// </summary>
      private bool _isDeleted = false;
      /// <summary>
      /// _isInserted field.
      /// </summary>
      private bool _isInserted = false;
      #endregion 

      #region Properties
        

		public Int32 TransactionId {
			get { return _TransactionId; }
			set {
				if(_TransactionId != value) {
					_isDirty = true;
					_TransactionId = value;
				}
			}
		}

		public string PayerEmail {
			get { return _PayerEmail; }
			set {
				if(_PayerEmail != value) {
					_isDirty = true;
					_PayerEmail = value;
				}
			}
		}

		public string EJTransactionId {
			get { return _EJTransactionId; }
			set {
				if(_EJTransactionId != value) {
					_isDirty = true;
					_EJTransactionId = value;
				}
			}
		}

		public string FirstName {
			get { return _FirstName; }
			set {
				if(_FirstName != value) {
					_isDirty = true;
					_FirstName = value;
				}
			}
		}

		public string LastName {
			get { return _LastName; }
			set {
				if(_LastName != value) {
					_isDirty = true;
					_LastName = value;
				}
			}
		}

		public decimal? MCGross {
			get { return _MCGross; }
			set {
				if(_MCGross != value) {
					_isDirty = true;
					_MCGross = value;
				}
			}
		}

		public decimal? Shipping {
			get { return _Shipping; }
			set {
				if(_Shipping != value) {
					_isDirty = true;
					_Shipping = value;
				}
			}
		}

		public decimal? Tax {
			get { return _Tax; }
			set {
				if(_Tax != value) {
					_isDirty = true;
					_Tax = value;
				}
			}
		}

		public string InvoiceId {
			get { return _InvoiceId; }
			set {
				if(_InvoiceId != value) {
					_isDirty = true;
					_InvoiceId = value;
				}
			}
		}

		public string Street {
			get { return _Street; }
			set {
				if(_Street != value) {
					_isDirty = true;
					_Street = value;
				}
			}
		}

		public string City {
			get { return _City; }
			set {
				if(_City != value) {
					_isDirty = true;
					_City = value;
				}
			}
		}

		public string State {
			get { return _State; }
			set {
				if(_State != value) {
					_isDirty = true;
					_State = value;
				}
			}
		}

		public string ZipCode {
			get { return _ZipCode; }
			set {
				if(_ZipCode != value) {
					_isDirty = true;
					_ZipCode = value;
				}
			}
		}

		public string CountryCode {
			get { return _CountryCode; }
			set {
				if(_CountryCode != value) {
					_isDirty = true;
					_CountryCode = value;
				}
			}
		}

		public string Phone {
			get { return _Phone; }
			set {
				if(_Phone != value) {
					_isDirty = true;
					_Phone = value;
				}
			}
		}

		public string PayerPhone {
			get { return _PayerPhone; }
			set {
				if(_PayerPhone != value) {
					_isDirty = true;
					_PayerPhone = value;
				}
			}
		}

        
      /// <summary>
      /// Flag for when recordset data has changed.
      /// </summary>
      public bool IsDirty { 
          get { return _isDirty; } 
          set { _isDirty = value; } 
      } 
        
      /// <summary>
      /// Delete flag.
      /// </summary>
      public bool IsDeleted { 
          get { return _isDeleted; } 
          set { _isDeleted = value; } 
      }

      /// <summary>
      /// Insert flag for composite keys only.
      /// </summary>
      public bool IsInserted {
          get { return _isInserted; }
          set { _isInserted = value; }
      }
        
      #endregion 
        
      /// <summary>
      /// Empty constructor.
      /// </summary>
      public TransactionRecordsetBase() {
      } 

      /// <summary>
      /// Returns a new instance of the current recordset.
      /// </summary>
      /// <returns></returns>
      public virtual TransactionRecordset Clone() {
          TransactionRecordset newTransactionRS = new TransactionRecordset(); 
          newTransactionRS.TransactionId = _TransactionId;
					newTransactionRS.PayerEmail = _PayerEmail;
					newTransactionRS.EJTransactionId = _EJTransactionId;
					newTransactionRS.FirstName = _FirstName;
					newTransactionRS.LastName = _LastName;
					newTransactionRS.MCGross = _MCGross;
					newTransactionRS.Shipping = _Shipping;
					newTransactionRS.Tax = _Tax;
					newTransactionRS.InvoiceId = _InvoiceId;
					newTransactionRS.Street = _Street;
					newTransactionRS.City = _City;
					newTransactionRS.State = _State;
					newTransactionRS.ZipCode = _ZipCode;
					newTransactionRS.CountryCode = _CountryCode;
					newTransactionRS.Phone = _Phone;
					newTransactionRS.PayerPhone = _PayerPhone;
					
          newTransactionRS.IsDirty = _isDirty;
          newTransactionRS.IsDeleted = _isDeleted;
          return newTransactionRS; 
      }

      /// <summary>
      /// Sets the identity column.
      /// </summary>
      /// <param name="IdentityValue"></param>
		public void SetIdentity(Int32 IdentityValue) {
			_TransactionId = IdentityValue;
		}

    } 
} 