using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API
{
    [XmlRoot("RESPONSES")]
    public class ResponseContainer
    {
        public ResponseContainer()
        {
        }

        [XmlElement("RESPONSE")]
        public Response response { get; set; }
    }
}
