using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Camera_Integration
{
    public partial class UpdateDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFacilityID.Text = Request.QueryString["facility"];
         
        }

        protected void btnConfirm_Click1(object sender, EventArgs e)
        {
            string FacilityID = lblFacilityID.Text;
           
           
            using (var db = new FacilityReservationKioskEntities())
            {
                //update
                 try
                 {
                     Camera camera = db.Cameras.Find(FacilityID);

                    //modify fields
                    camera.IPAddress = txtIpAddress.Text;
                    camera.MinimumDensity = float.Parse(txtMinDensity.Text);
                    camera.MaximumDensity = float.Parse(txtMaxDensity.Text);

                    db.SaveChanges();

                 }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                 {
                    //retrieve error messages
                    var errMessage = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);

                    //join list to a single string
                    var fullerrMessage = string.Join(";", errMessage);

                    //combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullerrMessage);
                 }

                 lblUpdate.Text = "Record Update Successfully";
                
            }
        }
    }
}