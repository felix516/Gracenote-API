using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// Base class for a Gracenote Query
    /// </summary>
    [XmlInclude(typeof(Query_Toc))]
    [XmlInclude(typeof(Query_Fetch))]
    [XmlInclude(typeof(Query_Register))]
    [Serializable]
    public class Query
    {
        public Query()
        {
        }

        /// <summary>
        /// Query command to executes
        /// </summary>
        [XmlAttribute("CMD")]
        public string Cmd { get; set; }
    }
}
