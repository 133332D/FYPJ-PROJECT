using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class Revoke : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDeviceID.Text = Request.QueryString["searchID"];
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int ID = System.Convert.ToInt32(lblDeviceID.Text);

            using (var db = new FacilityReservationKioskEntities())
            {
                Device device = db.Devices.Find(ID);

                //Modify fields
                device.Status = "Revoked";
                device.RejectedOrRevokedDateTime = DateTime.Now;
                device.RejectedOrRevokedReason = tbReason.Text;


                db.SaveChanges();
            }
        }
    }
}