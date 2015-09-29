using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data.Entity;

namespace ReservationListWebService
{
    public partial class UpdateFacility : System.Web.UI.Page
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
            public DbSet<FacilityReservation> Reservations { get; set; }
        }
        public class ReservationList
        {
            public string facilityReservationID { get; set; }
            public string facilityID { get; set; }
            public DateTime startDateTime { get; set; }
            public DateTime endDateTime { get; set; }
            public string useShortDescription { get; set; }
            public string useDescription { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentID = Request.QueryString["DepartmentID"];
            string json = Request.Form["Json"];

            ReservationList list = JsonConvert.DeserializeObject<ReservationList>(json);

            using (var db = new KioskContext())
            {
                db.Database.ExecuteSqlCommand(
                    "DELETE FacilityReservation FROM Department INNER JOIN Facility ON Department.DepartmentID = Facility.DepartmentID" +
                        "INNER JOIN FacilityReservation ON Facility.FacilityID = FacilityReservation.FacilityID WHERE Department.DepartmentID = '" + departmentID + "'");

                //foreach(....)
                {
                    FacilityReservation res = new FacilityReservation();

                    //set all fields here
                    res.FacilityReservationID = list.facilityReservationID;

                    db.Reservations.Add(res);
                }
                db.SaveChanges();
            }
        }
    }
}