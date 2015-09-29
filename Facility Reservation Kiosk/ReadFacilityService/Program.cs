using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Xml;
using System.Data.Entity;
using System.IO;
using System.Configuration;

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

    class SqlObject
    {
        public string departmentID { get; set; }

        public SqlObject(string id)
        {
            this.departmentID = id;
        }
    }

    class SqlFacObject
    {
        public string facilityID { get; set; }

        public SqlFacObject(string id)
        {
            this.facilityID = id;
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
        public static int depinsertCount = 0;
        public static int depupdateCount = 0;
        public static int depdeleteCount = 0;

        public static int facinsertCount = 0;
        public static int facupdateCount = 0;
        public static int facdeleteCount = 0;

        static void Main(string[] args)
        {
            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();

            string exerror = "";
            string exline = "";

            //if (args[0] == "getFRSLocationXML")
            try
            {
                //Console.WriteLine(args[0]);
                Console.WriteLine("Result:");
                //Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSLocationXML(args[1])));

                //create an xml to store the XML document from the web service
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(docNode);

                //load xml to xml doc object
                string xml = HttpUtility.UrlDecode(ws.getFRSLocationXML("STAFF"));
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
                //create a list of DepartmentID (Identifier) MSSQL database eg. SIT
                //A
                List<string> DepartmentListString = new List<string>();
                List<DepartmentObject> DepartmentList = new List<DepartmentObject>();

                // Loop through the nodes, extracting Facility information.
                // We can then define a facility object and add it to the list.
                foreach (XmlNode node in XmlDocNodes)
                {
                    DepartmentObject obj = new DepartmentObject(node["code"].InnerText,
                                                        node["desc"].InnerText);
                    DepartmentList.Add(obj);
                    DepartmentListString.Add(node["code"].InnerText);
                }

                //checks database and synchronise data by comparing
                //the rows
                //Insert, update and delete accordingly
                //B
                //create a list of string of department object
                List<string> sqlDepartmentListString = new List<string>();
                //create a list of object (SQL database)
                List<SqlObject> sqlDepartmentList = new List<SqlObject>();

                //select from the database to insert to sqlDepartmentList
                using (var db = new KioskContext())
                {
                    var listofdep = from d in db.Departments
                                    select new { d.DepartmentID };

                    foreach (var department in listofdep)
                    {
                        SqlObject sqlObject = new SqlObject(department.DepartmentID);
                        sqlDepartmentList.Add(sqlObject);
                        sqlDepartmentListString.Add(department.DepartmentID);
                    }
                }

                // Loop through the list, and print all the FacilityObjects to screen
                int ListSize = DepartmentList.Count;
                for (int i = 0; i < ListSize; i++)
                {
                    //Console.WriteLine("------------------------------------------");
                    Console.WriteLine(DepartmentList[i].code);
                    Console.WriteLine(DepartmentList[i].desc);
                    Console.Write("\n");


                    if (sqlDepartmentListString.Contains(DepartmentList[i].code) == false)
                    {
                        //insert the facility codes into the database dbo.department (DepartmentID)
                        depinsertCount = depinsertCount + 1;
                        using (var db = new KioskContext())
                        {
                            var departmentID = DepartmentList[i].code;
                            var description = DepartmentList[i].desc;

                            var department = new Department { DepartmentID = departmentID, Description = description };
                            db.Departments.Add(department);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        depupdateCount = depupdateCount + 1;
                        //update the record
                        using (var db = new KioskContext())
                        {
                            Department department = db.Departments.Find(DepartmentList[i].code);

                            department.DepartmentID = DepartmentList[i].code;
                            department.Description = DepartmentList[i].desc;
                            db.SaveChanges();
                        }
                    }
                }

                //loop throught the sql list and find extra records to delete
                int ListSizeSQL = sqlDepartmentList.Count;
                for (int i = 0; i < ListSizeSQL; i++)
                {
                    if (DepartmentListString.Contains(sqlDepartmentList[i].departmentID) == false)
                    {
                        depdeleteCount = depdeleteCount + 1;
                        //delete the extra record found
                        using (var db = new KioskContext())
                        {
                            Department department = db.Departments.Find(sqlDepartmentList[i].departmentID);

                            db.Departments.Remove(department);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                exerror = "[Department] Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString();
                exline = Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine;
            }

            string ecerror = "";
            string ecline = "";

            //if (args[0] == "getFRSListXML")
            try
            {
                //Console.WriteLine(args[0]);
                Console.WriteLine("Result:");
                //Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSListXML(
                //args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10])));

                //create an xml to store the XML document from the web service
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(docNode);

                //hardcode default to SIT
                string school = System.Configuration.ConfigurationManager.AppSettings["mySIT"]; ;
                //load xml to xml doc object
                //args[4] is the date in format DD-MMM-YYYY 09-SEP-2015
                string xml = HttpUtility.UrlDecode(ws.getFRSListXML(
                    "STAFF", school, "", "09-SEP-2015", "", "", "", "", "", "Y"));
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
                List<string> FacilityListString = new List<string>();

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

                        FacilityListString.Add(node["faccode"].InnerText);
                    }

                }

                //checks database and synchronise data by comparing
                //the rows
                //Insert, update and delete accordingly
                //B
                //create a list of string of facility object
                List<string> sqlFacilityListString = new List<string>();
                //create a list of object (SQL database)
                List<SqlFacObject> sqlFacilityList = new List<SqlFacObject>();

                //select from the database to insert to sqlFacilityList
                using (var db = new KioskContext())
                {
                    var listoffac = from f in db.Facilitys
                                    select new { f.FacilityID };

                    foreach (var facility in listoffac)
                    {
                        SqlFacObject sqlObject = new SqlFacObject(facility.FacilityID);
                        sqlFacilityList.Add(sqlObject);
                        sqlFacilityListString.Add(facility.FacilityID);
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

                    if (sqlFacilityListString.Contains(FacilityList[i].faccode) == false)
                    {
                        //insert the facility codes into the database dbo.department (DepartmentID)
                        facinsertCount = facinsertCount + 1;
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

                            var facility = new Facility
                            {
                                FacilityID = facilityID,
                                DepartmentID = departmentID,
                                Description = description,
                                OpenHours = openhrs,
                                CloseHours = closehrs,
                                MaxBkTime = maxbktime,
                                MaxBkUnits = maxbkunits,
                                MinBkTime = minbktime,
                                MinBkUnits = minbkunits,
                                Name = name,
                                Block = block,
                                Level = level
                            };
                            db.Facilitys.Add(facility);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        //update the record
                        facupdateCount = facupdateCount + 1;
                        using (var db = new KioskContext())
                        {
                            Facility facility = db.Facilitys.Find(FacilityList[i].faccode);

                            facility.FacilityID = FacilityList[i].faccode;
                            facility.DepartmentID = school;
                            facility.Description = FacilityList[i].facdesc;
                            facility.Block = blockname;
                            facility.Level = levelnum;
                            facility.Name = FacilityList[i].faccode;
                            facility.OpenHours = FacilityList[i].openhrs;
                            facility.CloseHours = FacilityList[i].closehrs;
                            facility.MaxBkTime = FacilityList[i].maxbktime;
                            facility.MaxBkUnits = FacilityList[i].maxbkunits;
                            facility.MinBkTime = FacilityList[i].minbktime;
                            facility.MinBkUnits = FacilityList[i].minbkunits;
                            db.SaveChanges();
                        }
                    }
                }
                //loop throught the sql list and find extra records to delete
                int ListSizeSQL = sqlFacilityList.Count;
                for (int i = 0; i < ListSizeSQL; i++)
                {
                    if (FacilityListString.Contains(sqlFacilityList[i].facilityID) == false)
                    {
                        facdeleteCount = facdeleteCount + 1;
                        //delete the extra record found
                        using (var db = new KioskContext())
                        {
                            Facility facility = db.Facilitys.Find(sqlFacilityList[i].facilityID);

                            db.Facilitys.Remove(facility);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ec) 
            {
                ecerror = "[Facility] Message :" + ec.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ec.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString();
                ecline = Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine;
            }
            
            //logging
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            string fulldateTime = DateTime.Now.ToString();
            string full = "[Executed on " + fulldateTime + " ]";

            string path = "c:\\Log\\ReadFacilityService-" + year + "-" + month + "-" + day + ".txt";

            string facinsertRecord = facinsertCount.ToString();
            string facupdateRecord = facupdateCount.ToString();
            string facdeleteRecord = facdeleteCount.ToString();

            string depinsertRecord = depinsertCount.ToString();
            string depupdateRecord = depupdateCount.ToString();
            string depdeleteRecord = depdeleteCount.ToString();

            string facinsert = "[FacilityTable] " + facinsertRecord + " rows are inserted to database.";
            string facupdate = "[FacilityTable] " + facupdateRecord + " rows are updated to database.";
            string facdelete = "[FacilityTable] " + facdeleteRecord + " rows are deleted from database.";

            string depinsert = "[DepartmentTable] " + depinsertRecord + " rows are inserted to database.";
            string depupdate = "[DepartmentTable] " + depupdateRecord + " rows are updated to database.";
            string depdelete = "[DepartmentTable] " + depdeleteRecord + " rows are deleted from database.";

            string line = "-----------------------------------------------------";

            using (StreamWriter file = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                file.WriteLine(full);
                file.WriteLine(depinsert);
                file.WriteLine(depupdate);
                file.WriteLine(depdelete);
                file.WriteLine(facinsert);
                file.WriteLine(facupdate);
                file.WriteLine(facdelete);
                file.WriteLine(line);
                file.WriteLine(exerror);
                file.WriteLine(exline);
                file.WriteLine(ecerror);
                file.WriteLine(ecline);

                file.Close();
            }
        }            
    }
}
