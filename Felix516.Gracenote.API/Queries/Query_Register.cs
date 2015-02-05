using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// Wrapper for the Gracenote REGISTER Query that requests a User ID 
    /// Used for authentication
    /// For more info see "https://developer.gracenote.com/sites/default/files/web/webapi/index.html#music-web-api/Registration and Authentication.html#kanchor47"
    /// </summary>
    [Serializable]
    public class Query_Register : Query
    {
        internal Query_Register(string clientId)
        {
            this.Cmd = "REGISTER";
            this.Client = clientId;
        }

        private Query_Register()
        {
        }

        [XmlElement("CLIENT")]
        public string Client { get; set; }
    }
}
