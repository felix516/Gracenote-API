using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    [XmlRoot("Track")]
    public class Track
    {
        private Track()
        {
        }

        [XmlElement("TRACK_NUM")]
        public int Track_number { get; set; }

        [XmlElement("GN_ID")]
        public string Gn_Id { get; set; }

        [XmlElement("ARTIST")]
        public string Artist { get; set; }

        [XmlElement("TITLE")]
        public string Title { get; set; }

        [XmlElement("GENRE")]
        public Genre Genre { get; set; }
    }
}
