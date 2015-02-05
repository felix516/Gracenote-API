using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Felix516.Gracenote.API.Entites
{
    /// <summary>
    /// Wrapper for a Gracenote Table of contents definition
    /// </summary>
    [Serializable]
    public class Toc
    {
        internal Toc(string toc_Offsets)
        {
            this.offsets = toc_Offsets;
        }

        private Toc()
        {
        }

        [XmlElement("OFFSETS")]
        public string offsets { get; set; }
    }
}
