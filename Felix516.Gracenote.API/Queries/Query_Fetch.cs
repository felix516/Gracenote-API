using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
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
