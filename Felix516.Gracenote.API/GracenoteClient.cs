using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    public class GracenoteClient
    {
        public enum Language { ENGLISH }

        public enum Country { US }

        private string lang = "eng";
        private Auth authentication;
        private string country;

        /// <summary>
        /// Sets the language preference used in the 
        /// Gracenote XML Query. Currently only Enlish
        /// is supported in this API bu others could 
        /// easily be added. Uses ISO 639-2 three character
        /// language codes
        /// </summary>
        /// <param name="language">language prefrence to set the query to</param>
        public void SetLanguage(Language language)
        {
            switch (language)
            {
                case Language.ENGLISH:
                    this.lang = "eng";
                    break;
            }
        }

        /// <summary>
        /// Sets the country used in the Gracenote XML Query.
        /// Currently only usa is supported in this API but 
        /// others could be easily added. Uses ISO 3166-1 
        /// alpha-3 country codes.
        /// </summary>
        /// <param name="country">country to set the query to</param>
        public void SetCountry(Country country)
        {
            switch (country)
            {
                case Country.US:
                    this.country = "usa";
                    break;
            }
        }

        /// <summary>
        /// Instantiates a new instance of GracenoteClient
        /// </summary>
        /// <param name="authentication">ClientID and UserID to be used for subsequent Queries</param>
        /// <param name="language">Language preference for Queries</param>
        /// <param name="country">Country preferece for Queries</param>
        public GracenoteClient(Auth authentication, Language language, Country country)
        {
            this.authentication = authentication;
            this.SetLanguage(language);
            this.SetCountry(country);
        }

        /// <summary>
        /// Initiates an ALBUM_TOC Query which retrieves one or more albums
        /// based on a disc's table of contents
        /// </summary>
        /// <param name="mode">Single-Best mode of Query</param>
        /// <param name="toc">Table of contents lookup string</param>
        /// <returns>A Gracenote response containing one or more albums</returns>
        public Response Album_ToC(Query_Toc.Modes mode, string toc)
        {
            Query_Toc query = new Query_Toc(mode, toc);
            Request r = new Request(this.authentication, this.lang, this.country, query);
            return WebRequestHelper.Get(r, this.authentication.PostUrl);
        }

        /// <summary>
        /// Initiates an ALBUM_FETCH Query which retrieves a single album given 
        /// a Gracenote Identifier.
        /// </summary>
        /// <param name="gn_Id">Gracenote ID of Album</param>
        /// <returns>A Gracenote response containing a single album</returns>
        public Response Album_Fetch(string gn_Id)
        {
            Query_Fetch query = new Query_Fetch(gn_Id);
            Request r = new Request(this.authentication, this.lang, this.country, query);
            return WebRequestHelper.Get(r,this.authentication.PostUrl);
        }
    }
}
