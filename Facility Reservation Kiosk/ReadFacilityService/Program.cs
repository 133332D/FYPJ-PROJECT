using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Xml;
using System.Data.Entity;

namespace ReadFacilityService
{
    public class DepartmentContext : DbContext
    {
        //using the FacilityReservationKioskEntities Connection string
        public DepartmentContext()
            : base("name=FacilityReservationKioskEntities")
        {
        }
        public DbSet<Department> Departments { get; set; }
    }

    //establish a generic facility class, and define necessary methods
    class FacilityObject
    {
        public string code { get; set; }
        public string desc { get; set; }
 
        public FacilityObject(string c, string d)
        {
            this.code = c;
            this.desc = d;
        }
    }
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
                string xml = HttpUtility.UrlDecode(ws.getFRSLocationXML(args[1]));
                doc.LoadXml(xml);

                //set settings to indent the output
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                //save document to a file
                //XmlWriter writer = XmlWriter.Create("GetFRSLocation.xml", settings);
                //doc.Save(writer);
                doc.Save(@"C:\test\GetFRSLocation.xml");
                //Console.WriteLine();


                //**Extract the values from XML
                // Declare the xpath for finding objects inside the XML file
                XmlNodeList XmlDocNodes = doc.SelectNodes("/facility/faclocation");

                // Define a new List, to store the objects we pull out of the XML
                List<FacilityObject> FacilityList = new List<FacilityObject>();

                // Loop through the nodes, extracting Facility information.
                // We can then define a facility object and add it to the list.
                foreach (XmlNode node in XmlDocNodes)
                {
                    FacilityObject obj = new FacilityObject(node["code"].InnerText,
                                                        node["desc"].InnerText);
                    FacilityList.Add(obj);
                }

                // Loop through the list, and print all the FacilityObjects to screen
                int ListSize = FacilityList.Count;
                for (int i = 0; i < ListSize; i++)
                {
                    //Console.WriteLine("------------------------------------------");
                    Console.WriteLine(FacilityList[i].code);
                    Console.WriteLine(FacilityList[i].desc);
                    Console.Write("\n");

                    //insert the facility codes into the database dbo.department (DepartmentID)
                    using (var db = new DepartmentContext())
                    {
                        var departmentID = FacilityList[i].code;

                        var department = new Department { DepartmentID = departmentID };
                        db.Departments.Add(department);
                        db.SaveChanges();
                    }

                }
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
