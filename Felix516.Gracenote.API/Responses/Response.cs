using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    [XmlRoot("RESPONSE")]
    public class Response
    {
        public Response()
        {
        }

        [XmlAttribute("STATUS")]
        public string Status { get; set; }

        [XmlElement("MESSAGE")]
        public string StatusMessage { get; set; }

        [XmlElement("ALBUM")]
        public List<Album> Albums { get; set; }

        [XmlElement("USER")]
        public string User { get; set; }
    }
}
