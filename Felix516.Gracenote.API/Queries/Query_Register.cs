using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
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
