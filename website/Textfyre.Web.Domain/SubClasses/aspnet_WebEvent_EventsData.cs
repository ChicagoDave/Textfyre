using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Textfyre.Common.DataLayer;
using Textfyre.TextfyreWeb.BusinessLayer;

namespace Textfyre.TextfyreWeb.DataLayer {

    /// <summary>
    /// Original base data class where custom queries are implemented. This class
    /// is generated once and is not over-written by the code generation tool.
    /// </summary>
    [DataSource("TextfyreWeb", "TextfyreWebErrors"),Serializable()]
    public class aspnet_WebEvent_EventsData : Textfyre.TextfyreWeb.DataLayer.aspnet_WebEvent_EventsDataBase {
        /// <summary>
        /// Empty default constructor.
        /// </summary>
        public aspnet_WebEvent_EventsData() : base() {
        }
    }
}