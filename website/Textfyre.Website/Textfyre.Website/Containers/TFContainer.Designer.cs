﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Textfyre.Website.Containers
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class TFWebEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new TFWebEntities object using the connection string found in the 'TFWebEntities' section of the application configuration file.
        /// </summary>
        public TFWebEntities() : base("name=TFWebEntities", "TFWebEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TFWebEntities object.
        /// </summary>
        public TFWebEntities(string connectionString) : base(connectionString, "TFWebEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TFWebEntities object.
        /// </summary>
        public TFWebEntities(EntityConnection connection) : base(connection, "TFWebEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
    }
    

    #endregion
    
    
}
