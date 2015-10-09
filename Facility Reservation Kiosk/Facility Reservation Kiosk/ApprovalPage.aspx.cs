using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Facility_Reservation_Kiosk
{
    public partial class ApprovalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDeviceID.Text = Request.QueryString["searchID"];
            lblDateTime.Text = DateTime.Now.ToString("M/dd/yy");
         
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int ID = System.Convert.ToInt32(lblDeviceID.Text);
          
            using (var db = new FacilityReservationKioskEntities())
            {
                //Load up and update 

                try
                {
                    Device device = db.Devices.Find(ID);

                    //Modify fields
                    device.Description = tbDescription.Text;
                    device.DepartmentID = ddlDepartment.SelectedValue.ToString();
                    device.DefaultDepartmentFilterID = System.Convert.ToInt32(tbDefaultFilter.Text);
                    device.Status = "APP";
                    device.ApprovedDateTime = DateTime.Now;
                 
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }

                lblUpdate.Text = "Update Successfully";
                
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}