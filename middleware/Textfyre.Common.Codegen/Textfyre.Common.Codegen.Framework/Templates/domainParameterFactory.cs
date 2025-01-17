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

namespace #rootNamespace#.DataLayer { 
    /// <summary>
    /// Factory class that auto-builds SqlParameters.
    /// </summary>
    [Serializable()]
    public class #tableName#ParameterFactory {
        /// <summary>
        /// GetParameter method returns a SqlParameter.
        /// </summary>
        public SqlParameter GetParameter(#rootNamespace#.DataLayer.#tableName#Fields FieldIdentity, object FieldValue) { 
            SqlParameter param = null;
            switch (FieldIdentity) {#parameterFactoryFields#
            }

            if(param == null)
                throw new Exception("Unknown parameter identifier.");

            return param;
        }
    }
}