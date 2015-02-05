using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
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
