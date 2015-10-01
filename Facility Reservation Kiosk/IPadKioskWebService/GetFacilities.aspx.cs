using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class GetFacilities : System.Web.UI.Page
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

        public class FacList
        {
            public List<FacObject> Facilities;
        }

        public class FacObject
        {
            public string facilityID { get; set; }
            public string departmentID { get; set; }
            public string description { get; set; }
            public string block { get; set; }
            public string level { get; set; }
            public string name { get; set; }
            public string openHours { get; set; }
            public string closeHours { get; set; }
            public string maxBkTime { get; set; }
            public string maxBkUnits { get; set; }
            public string minBkTime { get; set; }
            public string minBkUnits { get; set; }

            public FacObject(string facid, string depid, string desc, string b, string l, string n
                ,string o ,string c, string maxt, string maxu, string mint, string minu)
            {
                this.facilityID = facid;
                this.departmentID = depid;
                this.description = desc;
                this.block = b;
                this.level = l;
                this.name = n;
                this.openHours = o;
                this.closeHours = c;
                this.maxBkTime = maxt;
                this.maxBkUnits = maxu;
                this.minBkTime = mint;
                this.minBkUnits = minu;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string to search in facility table
            string departmentID = Request.QueryString["DepartmentID"];
            string block = Request.QueryString["Block"];
            string level = Request.QueryString["Level"];
            string name = Request.QueryString["Name"];

            //test if correct 
            //Only select from a certain department
            //select the database for the list of facility that contains 
            //block, level, name (%)
            var sqlFacList = new FacList();
            sqlFacList.Facilities = new List<FacObject>();

            using (var db = new KioskContext())
            {
                var facilitys = from f in db.Facilitys
                                where f.Department.DepartmentID == departmentID
                                && (f.Block.Contains(block) && f.Level.Contains(level)
                                && f.Name.Contains(name))
                                
                                orderby f.FacilityID
                                select new { f.FacilityID, f.DepartmentID, f.Description, f.Block,
                                f.Level, f.Name, f.OpenHours, f.CloseHours, f.MaxBkTime, f.MaxBkUnits, f.MinBkTime, f.MinBkUnits};
                
                foreach (var fac in facilitys)
                {
                    FacObject facobject = new FacObject(fac.FacilityID, fac.DepartmentID, fac.Description, fac.Block, fac.Level,
                        fac.Name, fac.OpenHours, fac.CloseHours, fac.MaxBkTime, fac.MaxBkUnits, fac.MinBkTime, fac.MinBkUnits);
                    
                    sqlFacList.Facilities.Add(facobject);
                }
            }

            //Serialize into json format output (string)
            string json = JsonConvert.SerializeObject(sqlFacList, Formatting.Indented);


            //codes to pass back the json string to the iPad
            Response.Write(json);
        }
    }
}