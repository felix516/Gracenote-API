using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    /// <summary>
    /// XML Wrapper class for a Gracenote Album
    /// For more info on values see "https://developer.gracenote.com/sites/default/files/web/webapi/index.html#music-overview/Album Data.html#kanchor25"
    /// </summary>
    [XmlRoot("ALBUM")]
    public class Album
    {
        private Album()
        {
        }

        /// <summary>
        /// What position album appears in list of results
        /// if multiple albums are found
        /// </summary>
        [XmlAttribute("ORD")]
        public int Order { get; set; }

        /// <summary>
        /// Unique Gracenote ID of album
        /// </summary>
        [XmlElement("GN_ID")]
        public string Gn_Id { get; set; }

        /// <summary>
        /// Album artist
        /// </summary>
        [XmlElement("ARTIST")]
        public string Artist { get; set; }

        /// <summary>
        /// Album title
        /// </summary>
        [XmlElement("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// Language of the album
        /// </summary>
        [XmlElement("PKG_LANG")]
        public string Language { get; set; }

        /// <summary>
        /// Release year of album
        /// </summary>
        [XmlElement("DATE")]
        public string Date { get; set; }

        /// <summary>
        /// Genre of album
        /// </summary>
        [XmlElement("GENRE")]
        public Genre Genre { get; set; }

        /// <summary>
        /// Number of audio Tracks in the album
        /// </summary>
        [XmlElement("TRACK_COUNT")]
        public int Track_Count { get; set; }

        /// <summary>
        /// List containing track data for album
        /// </summary>
        [XmlElement("TRACK")]
        public List<Track> Tracks { get; set; }

        /// <summary>
        /// Url to cover art of album
        /// </summary>
        [XmlElement("URL")]
        public string CoverartUrl { get; set; }
    }
}
