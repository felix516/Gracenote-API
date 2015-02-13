using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// Class that deals with authentication with the gracenote WebAPI
    /// </summary>
    [Serializable]
    public class Auth
    {
        private const string URL_START = "https://";
        private const string URL_END = ".web.cddbp.net/webapi/xml/1.0/";

        public Auth(string clientID, string userID)
        {
            this.Client = clientID;
            this.User = userID;
            this.PostUrl = generatePostUrl(clientID);
        }

        private Auth()
        {
        }

        /// <summary>
        /// Generates the url to post to Gracenote based on gracenote clientID
        /// </summary>
        /// <param name="clientID">Gracenode Client ID</param>
        /// <returns>a string containing the url the client should post to</returns>
        private static string generatePostUrl(string clientID)
        {
            StringBuilder urlBuilder = new StringBuilder();

            string client = clientID.Split('-')[0];

            urlBuilder.Append(URL_START);
            urlBuilder.Append(client);
            urlBuilder.Append(URL_END);

            return urlBuilder.ToString();
        }

        /// <summary>
        /// Generate a new UserID
        /// This should only be done once per Install and the 
        /// UserID stored somewhere for subsequent Queries
        /// For more info see "https://developer.gracenote.com/sites/default/files/web/webapi/index.html#music-web-api/Registration and Authentication.html#kanchor47"
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static string GenerateUserId(string clientID)
        {
            Query_Register query = new Query_Register(clientID);
            Request r = new Request(query);
            Response res = WebRequestHelper.Get(r,generatePostUrl(clientID));
            return res.User;
        }

        public string Client { get; set; }
        public string User { get; set; }

        [XmlIgnore]
        public string PostUrl { get; set; }
    }
}
