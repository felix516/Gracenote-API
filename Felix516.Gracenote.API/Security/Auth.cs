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
        public Auth(string clientID, string userID)
        {
            this.Client = clientID;
            this.User = userID;
        }

        private Auth()
        {
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
            Response res = WebRequestHelper.Get(r);
            return res.User;
        }

        public string Client { get; set; }
        public string User { get; set; }
    }
}
