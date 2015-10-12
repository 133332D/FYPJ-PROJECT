using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net; //For email use 
using System.Net.Mail; //For email use

namespace Facility_Reservation_Kiosk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string and register device 
            string UniqueID = Request.QueryString["UniqueID"];
            string PublicKey = Request.QueryString["PublicKey"];

            //If DeviceID not registered, insert new record 
            using (var db = new FacilityReservationKioskEntities())
            {
                var register = new Device { Status = "NEW", DeviceGeneratedUniqueID = UniqueID, PublicKey = PublicKey };
                db.Devices.Add(register);
                db.SaveChanges();
            }

            //Send verification email to user 
        }
    }
}