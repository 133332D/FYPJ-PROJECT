using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class GetFacilityReservations : System.Web.UI.Page
    {
        public class KioskContext : DbContext
        {
            //using the FacilityReservationKioskEntities Connection string
            public KioskContext()
                : base("name=FacilityReservationKioskEntities")
            {
            }
            public DbSet<FacilityReservation> FacilityReservations { get; set; }
        }

        public class ResList
        {
            public List<ResObject> Reservations;
        }

        public class ResObject
        {
            public string facilityReservationID { get; set; }
            public string facilityID { get; set; }
            public DateTime startDateTime { get; set; }
            public DateTime endDateTime { get; set; }
            public string useShortDescription { get; set; }
            public string useDescription { get; set; }

            public ResObject(string facrid, string facid, DateTime sdate, DateTime edate, string usd, string ud)
            {
                this.facilityReservationID = facrid;
                this.facilityID = facid;
                this.startDateTime = sdate;
                this.endDateTime = edate;
                this.useShortDescription = usd;
                this.useDescription = ud;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string to search in facility table
            string departmentID = Request.QueryString["DepartmentID"];
            string block = Request.QueryString["Block"];
            string level = Request.QueryString["Level"];
            string name = Request.QueryString["Name"];
            //format of date yyyy-MMM-dd
            string date = Request.QueryString["Date"];

            var sqlResList = new ResList();
            sqlResList.Reservations = new List<ResObject>();

            //if date is blank, return current system date
            if( date == "" )
            {
                DateTime dateToday = DateTime.Today;

                //not sure if it really retuns a result
                //don't work
                using (var db = new KioskContext())
                {
                    var facilityRes = from fr in db.FacilityReservations
                                    where fr.Facility.Department.DepartmentID == departmentID
                                    && fr.Facility.Block.Contains(block) && fr.Facility.Level.Contains(level)
                                    && fr.Facility.Name.Contains(name)
                                    && DbFunctions.TruncateTime(fr.StartDateTime) <= dateToday
                                    && DbFunctions.TruncateTime(fr.EndDateTime) >= dateToday

                                    orderby fr.FacilityReservationID
                                    select new
                                    {
                                        fr.FacilityReservationID,
                                        fr.FacilityID,
                                        fr.StartDateTime,
                                        fr.EndDateTime,
                                        fr.UseShortDescription,
                                        fr.UseDescription
                                    };

                    foreach (var res in facilityRes)
                    {
                        ResObject resobject = new ResObject(res.FacilityReservationID, res.FacilityID, res.StartDateTime.Value, res.EndDateTime.Value, 
                            res.UseShortDescription, res.UseDescription);

                        sqlResList.Reservations.Add(resobject);
                    }
                }

                //Serialize into json format output (string)
                string json = JsonConvert.SerializeObject(sqlResList, Formatting.Indented);


                //codes to pass back the json string to the iPad
                Response.Write(json);
                Response.End();

            }
            //else return only specified date
            else
            {
                //convert string date to datetime
                DateTime datePass = DateTime.ParseExact(date, "yyyy-MMM-dd", CultureInfo.InvariantCulture);

                using (var db = new KioskContext())
                {
                    var facilityRes = from fr in db.FacilityReservations
                                      where fr.Facility.Department.DepartmentID == departmentID
                                      && fr.Facility.Block.Contains(block) && fr.Facility.Level.Contains(level)
                                      && fr.Facility.Name.Contains(name)
                                      && DbFunctions.TruncateTime(fr.StartDateTime) <= datePass
                                      && DbFunctions.TruncateTime(fr.EndDateTime) >= datePass

                                      orderby fr.FacilityReservationID
                                      select new
                                      {
                                          fr.FacilityReservationID,
                                          fr.FacilityID,
                                          fr.StartDateTime,
                                          fr.EndDateTime,
                                          fr.UseShortDescription,
                                          fr.UseDescription
                                      };

                    foreach (var res in facilityRes)
                    {
                        ResObject resobject = new ResObject(res.FacilityReservationID, res.FacilityID, res.StartDateTime.Value, res.EndDateTime.Value,
                            res.UseShortDescription, res.UseDescription);

                        sqlResList.Reservations.Add(resobject);
                    }
                }

                //Serialize into json format output (string)
                string json = JsonConvert.SerializeObject(sqlResList, Formatting.Indented);


                //codes to pass back the json string to the iPad
                Response.Write(json);
                Response.End();
            }
        }
    }
}