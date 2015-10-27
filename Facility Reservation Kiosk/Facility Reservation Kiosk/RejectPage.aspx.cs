using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class RejectPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbDeviceID.Text = Request.QueryString["searchID"];

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbReason.Text == "")
            {
                lblMsg.Text = "Please enter reject reason!";
            }

            else
            {
                int ID = System.Convert.ToInt32(lbDeviceID.Text);

                using (var db = new FacilityReservationKioskEntities())
                {
                    Device device = db.Devices.Find(ID);

                    //Modify fields
                    device.Status = "REJ";
                    device.RejectedOrRevokedDateTime = DateTime.Now;
                    device.RejectedOrRevokedReason = tbReason.Text;


                    db.SaveChanges();
                }

                lblMsg.Text = "Device rejected";
            }
            
        }
    }
}
       