using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    /// <summary>
    /// Wrapper for a Gracenote Track
    /// For more info on values see "https://developer.gracenote.com/sites/default/files/web/webapi/index.html#music-overview/Track Data.html#kanchor29"
    /// </summary>
    [XmlRoot("Track")]
    public class Track
    {
        private Track()
        {
        }

        /// <summary>
        /// The track's number in the album
        /// </summary>
        [XmlElement("TRACK_NUM")]
        public int Track_number { get; set; }

        /// <summary>
        /// The track's Gracenote ID
        /// </summary>
        [XmlElement("GN_ID")]
        public string Gn_Id { get; set; }

        /// <summary>
        /// The track's Artist
        /// </summary>
        [XmlElement("ARTIST")]
        public string Artist { get; set; }

        /// <summary>
        /// The track's Title
        /// </summary>
        [XmlElement("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// The tracks Genre
        /// </summary>
        [XmlElement("GENRE")]
        public Genre Genre { get; set; }
    }
}
