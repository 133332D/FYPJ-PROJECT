using System;
using System.Collections;
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

            //count the number of exception catch from db.SaveChanges
            int exceptionCount = 0;

            if (departmentID != null && json != null)
            {

                //store the deserialized json array to a list of reservations
                ReservationList list = JsonConvert.DeserializeObject<ReservationList>(json);

                using (var db = new KioskContext())
                {
                    //delete the whole FacilityReservation Table
                    //db.Database.ExecuteSqlCommand(
                    //    "DELETE FacilityReservation");
                        //FROM Department INNER JOIN Facility ON Department.DepartmentID = Facility.DepartmentID " +
                            //"INNER JOIN FacilityReservation ON Facility.FacilityID = FacilityReservation.FacilityID WHERE Department.DepartmentID = '" + departmentID + "'");

                    
                    // DELETE reservations records not found in the list
                    //
                    Hashtable listOfReservationIDs = new Hashtable();
                    var reservationIDs = from r in db.Reservations
                                         select new { r.FacilityReservationID };

                    foreach(var reservationID in reservationIDs)
                        listOfReservationIDs[reservationID.FacilityReservationID] = 1;

                    foreach (Reservation res in list.Reservations)
                        listOfReservationIDs.Remove(res.facilityReservationID);

                    foreach (string reservationIDToDelete in listOfReservationIDs.Keys)
                    {
                        db.Database.ExecuteSqlCommand(
                        "DELETE FacilityReservation WHERE FacilityReservationID = '" + reservationIDToDelete + "'");
                    }
                    db.SaveChanges();


                    //loop through each reservations and insert into the database
                    //record by record
                    foreach (Reservation res in list.Reservations)
                    {
                        var reservations = from r in db.Reservations
                                           where r.FacilityReservationID == res.facilityReservationID
                                           select r;

                        if (reservations.Count() > 0)
                        {
                            // Record exists, just update.

                            foreach(var reservation in reservations)
                            {
                                reservation.FacilityID = res.facilityID;
                                reservation.StartDateTime = res.startDateTime;
                                reservation.EndDateTime = res.endDateTime;
                                reservation.UseDescription = res.useDescription;
                                reservation.UseShortDescription = res.useShortDescription;

                                break;
                            }

                        }
                        else
                        {
                            // Record does not exist, insert.

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

                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        exceptionCount += 1;
                    }
                }


                //returns in Json format
                Response.Write("{");
                Response.Write("     Result: \"OK\"");
                Response.Write("     Message: \"The record is received and inserted into database successfully. " +
                    exceptionCount + " records not inserted possibly due to duplicate primary key or some other errors.\"");
                Response.Write("}");
                Response.End();
            }
            else 
            {
                Response.Write("{");
                Response.Write("     Result: \"ERROR\"");
                Response.Write("     Message: \"There is an error occured and data cannot be received.\"");
                Response.Write("}");
                Response.End();
            }
        }
    }
};