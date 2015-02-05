using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    [XmlRoot("GENRE")]
    public class Genre
    {
        private Genre()
        {
        }

        [XmlAttribute("NUM")]
        public int GenreNum { get; set; }

        [XmlAttribute("ID")]
        public int GenreId { get; set; }

        [XmlText]
        public string GenreName { get; set; }
    }
}
