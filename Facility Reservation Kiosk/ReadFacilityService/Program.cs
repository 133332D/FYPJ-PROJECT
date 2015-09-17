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
    public class KioskContext : DbContext
    {
        //using the FacilityReservationKioskEntities Connection string
        public KioskContext()
            : base("name=FacilityReservationKioskEntities")
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facility> Facilitys { get; set; }
    }

    //establish a generic department & facility class, and define necessary methods
    class DepartmentObject
    {
        public string code { get; set; }
        public string desc { get; set; }
 
        public DepartmentObject(string c, string d)
        {
            this.code = c;
            this.desc = d;
        }
    }
    class FacilityObject
    {
        public string faccode { get; set; }
        public string facdesc { get; set; }
        public string openhrs { get; set; }
        public string closehrs { get; set; }
        public string maxbktime { get; set; }
        public string maxbkunits { get; set; }
        public string minbktime { get; set; }
        public string minbkunits { get; set; }

        public FacilityObject(string fc, string fd, string open, string close, 
            string maxbt, string maxbu, string minbt, string minbu)
        {
            this.faccode = fc;
            this.facdesc = fd;
            this.openhrs = open;
            this.closehrs = close;
            this.maxbktime = maxbt;
            this.maxbkunits = maxbu;
            this.minbktime = minbt;
            this.minbkunits = minbu;
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
                List<DepartmentObject> DepartmentList = new List<DepartmentObject>();

                // Loop through the nodes, extracting Facility information.
                // We can then define a facility object and add it to the list.
                foreach (XmlNode node in XmlDocNodes)
                {
                    DepartmentObject obj = new DepartmentObject(node["code"].InnerText,
                                                        node["desc"].InnerText);
                    DepartmentList.Add(obj);
                }

                // Loop through the list, and print all the FacilityObjects to screen
                int ListSize = DepartmentList.Count;
                for (int i = 0; i < ListSize; i++)
                {
                    //Console.WriteLine("------------------------------------------");
                    Console.WriteLine(DepartmentList[i].code);
                    Console.WriteLine(DepartmentList[i].desc);
                    Console.Write("\n");

                    //insert the facility codes into the database dbo.department (DepartmentID)
                    using (var db = new KioskContext())
                    {
                        var departmentID = DepartmentList[i].code;
                        var description = DepartmentList[i].desc;

                        var department = new Department { DepartmentID = departmentID, Description = description};
                        db.Departments.Add(department);
                        db.SaveChanges();
                    }

                }
            }
            if (args[0] == "getFRSListXML")
            {
                Console.WriteLine(args[0]);
                Console.WriteLine("Result:");
                //Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSListXML(
                    //args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10])));

                //create an xml to store the XML document from the web service
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(docNode);

                //hardcode default to SIT
                string school = "SIT";
                //load xml to xml doc object
                //args[4] is the date in format DD-MMM-YYYY 09-SEP-2015
                string xml = HttpUtility.UrlDecode(ws.getFRSListXML(
                    "STAFF", school, "", args[4], "", "", "", "", "", "Y"));
                doc.LoadXml(xml);


                //set settings to indent the output
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                //save document to a file
                //XmlWriter writer = XmlWriter.Create("GetFRSLocation.xml", settings);
                //doc.Save(writer);
                doc.Save(@"C:\test\GetFRSList.xml");
                //Console.WriteLine();

                //**Extract the values from XML
                // Declare the xpath for finding objects inside the XML file
                XmlNodeList XmlDocNodes = doc.SelectNodes("/facility/list");

                // Define a new List, to store the objects we pull out of the XML
                List<FacilityObject> FacilityList = new List<FacilityObject>();

                // Loop through the nodes, extracting Facility information.
                // We can then define a facility object and add it to the list.
                //ERROR!!!!!!******
                List<string> listFac = new List<string>();
                foreach (XmlNode node in XmlDocNodes)
                {
                    XmlNode xmlNodeFac = node.SelectSingleNode("faccode");
                    string innerText = xmlNodeFac.InnerText;

                    if (listFac.Contains(innerText) == false)
                    {
                        listFac.Add(innerText);

                        FacilityObject obj = new FacilityObject(node["faccode"].InnerText, node["facdesc"].InnerText,
                            node["openhrs"].InnerText, node["closehrs"].InnerText, node["maxbktme"].InnerText, node["maxbkunits"].InnerText,
                            node["minbktme"].InnerText, node["minbkunits"].InnerText);
                        FacilityList.Add(obj);
                    }

                }

                // Loop through the list, and print all the FacilityObjects to screen
                int ListSize = FacilityList.Count;
                for (int i = 0; i < ListSize; i++)
                {
                    //Console.WriteLine("------------------------------------------");
                    //Console.WriteLine(FacilityList[i].faccode);
                    //Console.WriteLine(FacilityList[i].facdesc);
                    //Console.WriteLine(FacilityList[i].openhrs);
                    //Console.WriteLine(FacilityList[i].closehrs);
                    //Console.WriteLine(FacilityList[i].maxbktime);
                    //Console.WriteLine(FacilityList[i].maxbkunits);
                    //Console.WriteLine(FacilityList[i].minbktime);
                    //Console.WriteLine(FacilityList[i].minbkunits);
                    //Console.Write("\n");

                    //Get substring char eg: L.425
                    string facname = FacilityList[i].faccode;
                    string blockname = facname.Substring(0, 1);
                    string levelname = facname.Substring(0, 3);
                    string levelnum;

                    //if is LTL theatre = level 3
                    if (levelname == "LTL")
                    {
                        levelnum = "3";
                    }
                    else
                    {
                        levelnum = facname.Substring(2, 1);
                    }

                    //insert the facility codes into the database dbo.department (DepartmentID)
                    using (var db = new KioskContext())
                    {
                        var facilityID = FacilityList[i].faccode;
                        var departmentID = school;
                        var description = FacilityList[i].facdesc;
                        var block = blockname;
                        var level = levelnum;
                        var name = FacilityList[i].faccode;
                        var openhrs = FacilityList[i].openhrs;
                        var closehrs = FacilityList[i].closehrs;
                        var maxbktime = FacilityList[i].maxbktime;
                        var maxbkunits = FacilityList[i].maxbkunits;
                        var minbktime = FacilityList[i].minbktime;
                        var minbkunits = FacilityList[i].minbkunits;

                        var facility = new Facility { FacilityID = facilityID, DepartmentID = departmentID, Description = description, 
                            OpenHours = openhrs, CloseHours = closehrs, MaxBkTime = maxbktime, MaxBkUnits = maxbkunits,
                        MinBkTime = minbktime, MinBkUnits = minbkunits, Name = name, Block = block, Level = level};
                        db.Facilitys.Add(facility);
                        db.SaveChanges();
                    }

                }
            }
        }
    }
}
