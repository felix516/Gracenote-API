using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// Wrapper for the Gracenote ALBUM_FETCH Query that retrieves an album using a gracenote ID
    /// For more info see "https://developer.gracenote.com/sites/default/files/web/html/Content/Music%20Web%20API/ALBUM_FETCH.html"
    /// </summary>
    [Serializable]
    public class Query_Fetch : Query
    {
        internal Query_Fetch(String gn_Id)
        {
            this.GnId = gn_Id;
            this.Cmd = "ALBUM_FETCH";
        }

        private Query_Fetch()
        {
        }

        [XmlElement("GN_ID")]
        public string GnId { get; set; }
    }
}
