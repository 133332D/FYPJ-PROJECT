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
        public class Reservation
        {
            public string facilityReservationID { get; set; }
            public string facilityID { get; set; }
            public DateTime startDateTime { get; set; }
            public DateTime endDateTime { get; set; }
            public string useShortDescription { get; set; }
            public string useDescription { get; set; }
        }
        public class ReservationList
        {
            public List<Reservation> Reservations { get; set; }
        }

        //******write codes to return OK/Error Message to the Mr Chow's console app!!!!!!****

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the department ID and json string pass to my webservice
            string departmentID = Request.QueryString["DepartmentID"];
            string json = Request.Form["Json"];
           
            //store the deserialized json array to a list of reservations
            ReservationList list = JsonConvert.DeserializeObject<ReservationList>(json);

            using (var db = new KioskContext())
            {
                //delete the whole FacilityReservation Table
                db.Database.ExecuteSqlCommand(
                    "DELETE FacilityReservation FROM Department INNER JOIN Facility ON Department.DepartmentID = Facility.DepartmentID" +
                        "INNER JOIN FacilityReservation ON Facility.FacilityID = FacilityReservation.FacilityID WHERE Department.DepartmentID = '" + departmentID + "'");

                //loop through each reservations and insert into the database
                //record by record
                foreach(Reservation res in list.Reservations)
                {
                    FacilityReservation reser = new FacilityReservation();

                    //set all fields here
                    reser.FacilityReservationID = res.facilityReservationID;
                    reser.FacilityID = res.facilityID;
                    reser.StartDateTime = res.startDateTime;
                    reser.EndDateTime = res.endDateTime;
                    reser.UseShortDescription = res.useShortDescription;
                    reser.UseDescription = res.useDescription;

                    db.Reservations.Add(reser);
                }

                db.SaveChanges();
            }
        }
    }
}