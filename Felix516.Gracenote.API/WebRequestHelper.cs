using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// Helper class to POST requests to the Gracenote web API
    /// </summary>
    public static class WebRequestHelper
    {
        private static string requestUrl = "https://c13047040.web.cddbp.net/webapi/xml/1.0/";

        public static Response Get(Request r)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            string xmlString = Utility.SerializeRequest(r);
            request.Method = "POST";
            using (var requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write(xmlString);
                requestStream.Close();
            }

            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new NullReferenceException(Localization.Messages.StreamIsEmpty);
                    }

                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return Utility.DeserializeResponse(responseStr);
                }
            }
            return null;
        }
    }
}
