using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    [XmlRoot("QUERIES", Namespace = "")]
    [Serializable]
    public class Request
    {
        internal Request(Auth authentication, string language, string country, Query query)
        {
            this.Authentication = authentication;
            this.Language = language;
            this.Country = country;
            this.Query = query;
        }

        internal Request(Query query)
        {
            this.Query = query;
        }

        private Request()
        {
        }

        [XmlElement("AUTH")]
        public Auth Authentication { get; set; }

        [XmlElement("LANG")]
        public string Language { get; set; }

        [XmlElement("COUNTRY")]
        public string Country { get; set; }

        [XmlElement("QUERY")]
        public Query Query { get; set; }
    }
}
