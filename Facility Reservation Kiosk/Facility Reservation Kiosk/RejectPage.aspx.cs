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
            lblDateTime.Text = DateTime.Now.ToString("M/dd/yy");

            int ID = System.Convert.ToInt32(lbDeviceID.Text);

           
            using (var db = new FacilityReservationKioskEntities())
            {
                //Basic select query from a single table 
                //var description = from b in db.Devices
                //                  where b.DeviceID == ID
                //                  select new { b.Description };
                string strConnectionString = ConfigurationManager.ConnectionStrings["FacilityReservationKioskEntities"].ConnectionString;
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                string strCommandText = "Select description from Devices where DeviceID= "+lbDeviceID.Text +"";
                //Loop through to print out
                //lbDescription.Text = description.ToString();

                //string sDescription = db.Devices.FirstOrDefault().Description.ToString();
                

           }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            int ID = System.Convert.ToInt32(lbDeviceID.Text);

            using (var db = new FacilityReservationKioskEntities())
            {
            Device device = db.Devices.Find(ID);

            //Modify fields
            device.Status = "Reject";
            device.RejectedOrRevokedDateTime = DateTime.Now;
            device.RejectedOrRevokedReason = tbReason.Text;


            db.SaveChanges();
            }
        }

        //protected void btnConfirm_Click(object sender, EventArgs e)
        //{

        //}
    }
}