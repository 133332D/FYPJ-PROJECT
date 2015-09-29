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
            using (var db = new KioskContext())
            {
                var facilitys = from f in db.Facilitys
                                where f.Department.DepartmentID.Contains(departmentID)
                                && (f.Block.Contains("%" + block + "%") || f.Level.Contains("%" + level + "%")
                                || f.Name.Contains("%" + name + "%"))
                                
                                orderby f.FacilityID
                                select new { f.FacilityID, f.DepartmentID, f.Description, f.Block,
                                f.Level, f.Name, f.Map, f.MapPositionX, f.MapPositionY, f.OpenHours,
                                f.CloseHours, f.MaxBkTime, f.MaxBkUnits, f.MinBkTime, f.MinBkUnits};
            }
        }
    }
}