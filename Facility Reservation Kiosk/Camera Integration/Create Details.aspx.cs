using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Camera_Integration
{
    public partial class Create_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
           
        }

        private void BindDDL()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var facility = (from b in db.Facilities
                                select new { b.FacilityID }).ToList();

                ddlFacility.DataValueField = "FacilityID";
                ddlFacility.DataTextField = "FacilityID";
                ddlFacility.DataSource = facility;
                ddlFacility.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
          
            using (var db = new FacilityReservationKioskEntities())
            {
                //create new camera
                Camera camera = new Camera();
                camera.FacilityID = ddlFacility.SelectedValue;
                camera.IPAddress = txtIpAddress.Text;
                camera.MinimumDensity = float.Parse(txtMinDensity.Text);
                camera.MaximumDensity = float.Parse(txtMaxDensity.Text);
                db.Cameras.Add(camera);
                db.SaveChanges();
            }
            lblCreate.Text = "Create Record Successful";
        }

       
      
        
     
        
    }
}