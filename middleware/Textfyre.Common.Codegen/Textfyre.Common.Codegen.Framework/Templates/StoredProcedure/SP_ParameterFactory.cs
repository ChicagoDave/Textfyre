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
using System.Data.SqlClient;

namespace #rootNamespace#.DataLayer { 
    [Serializable()]
    public class #spName#ParameterFactory { 
        public SqlParameter GetParameter(#spName#Params ParamIdentity, object ParamValue) { 
            SqlParameter param = null;
            switch (ParamIdentity) {#parameterFactoryFields#
            }

            if(param == null)
                throw new Exception("Unknown parameter identifier.");

            return param;
        } 
    } 
} 