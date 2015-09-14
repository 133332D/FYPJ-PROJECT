using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Xml;

namespace ReadFacilityService
{
    class Program
    {
        static void Main(string[] args)
        {
            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();


            if (args[0] == "getFRSLocationXML")
            {
                Console.WriteLine(args[0]);
                Console.WriteLine("Result:");
                //Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSLocationXML(args[1])));

                //create an xml to store the XML document from the web service
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(docNode);

                //load xml to xml doc object
                doc.LoadXml(HttpUtility.UrlDecode(ws.getFRSLocationXML(args[1])));

                //set settings to indent the output
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                //save document to a file
                XmlWriter writer = XmlWriter.Create("GetFRSLocation.xml", settings);
                doc.Save(writer);
                doc.Save(@"C:\test\GetFRSLocation.xml");
                //Console.WriteLine(writer);

            }
            if (args[0] == "getFRSListXML")
            {
                Console.WriteLine(args[0]);
                Console.WriteLine("Result:");
                Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSListXML(
                    args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10])));
            }
        }
    }
}
