using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Felix516.Gracenote.API.Entites;

namespace Felix516.Gracenote.API
{
    /// <summary>
    /// General Utility class
    /// Currently deals with XML Serialization and Deserialization
    /// </summary>
    public static class Utility
    {
        private static XmlSerializer ser;
        private static XmlSerializerNamespaces ns;
        private static bool initialized = false;

        internal static string SerializeRequest(Request r)
        {
            if (!initialized)
            {
                Initialize();
            }

            StringWriter swriter = new StringWriter();
            XmlWriter writer = XmlWriter.Create(swriter, new XmlWriterSettings { OmitXmlDeclaration = true });
            ser.Serialize(writer, r, ns);
            string xmlString = swriter.ToString();
            writer.Close();
            swriter.Close();
            return xmlString;
        }

        private static void Initialize()
        {
            ser = new XmlSerializer(typeof(Request));
            ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            initialized = true;
        }

        internal static Response DeserializeResponse(string data)
        {
            ResponseContainer returned;
            StringReader sr = new StringReader(data);
            XmlRootAttribute xmlRoot = new XmlRootAttribute();
            xmlRoot.ElementName = "RESPONSES";
            XmlSerializer serializer = new XmlSerializer(typeof(ResponseContainer), xmlRoot);
            returned = (ResponseContainer)serializer.Deserialize(sr);
            return returned.response;
        }
    }
}
