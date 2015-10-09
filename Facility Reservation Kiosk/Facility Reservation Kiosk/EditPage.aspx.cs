using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDeviceID.Text = Request.QueryString["searchID"];

            int ID = System.Convert.ToInt32(lblDeviceID.Text);

            using (var db = new FacilityReservationKioskEntities())
            {
                //Basic select query from a single table 
                var device = db.Devices.Find(ID);

                //Loop through to print out
                tbDescription.Text = device.Description;
                ddlDepartment.Text = device.DepartmentID;
                tbFilter.Text = device.DefaultDepartmentFilterID.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            int ID = System.Convert.ToInt32(lblDeviceID.Text);

            using (var db = new FacilityReservationKioskEntities())
            {
                Device device = db.Devices.Find(ID);

                //Modify fields
                device.Description = tbDescription.Text;
                device.DepartmentID = ddlDepartment.SelectedValue.ToString();
                device.DefaultDepartmentFilterID = System.Convert.ToInt32(tbFilter.Text); 

                db.SaveChanges();
            }

            lbUpdate.Text = "Records update successfully";
        }
    }
}