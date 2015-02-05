using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    [Serializable]
    public class Query_Toc : Query
    {
        public enum Modes { NONE, SINGLE_BEST_COVER, SINGLE_BEST }

        internal Query_Toc(Modes mode, string toc)
        {
            this.Toc = new Toc(toc);
            this.SetMode(mode);
            this.Cmd = "ALBUM_TOC";
        }

        private Query_Toc()
        {
        }

        [XmlElement("MODE")]
        public string Mode { get; set; }

        [XmlElement("TOC")]
        public Toc Toc { get; set; }

        internal void SetMode(Modes m)
        {
            switch (m)
            {
                case Modes.NONE:
                    this.Mode = null;
                    break;

                case Modes.SINGLE_BEST:
                    this.Mode = "SINGLE_BEST";
                    break;

                case Modes.SINGLE_BEST_COVER:
                    this.Mode = "SINGLE_BEST_COVER";
                    break;
            }
        }
    }
}
