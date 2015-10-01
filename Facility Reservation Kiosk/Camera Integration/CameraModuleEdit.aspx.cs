using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Camera_Integration
{
    public partial class CameraModuleEdit : System.Web.UI.Page
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
                var facility = (from b in db.Cameras
                                select new { b.FacilityID }).ToList();

                ddlFacilityID.DataValueField = "FacilityID";
                ddlFacilityID.DataTextField = "FacilityID";
                ddlFacilityID.DataSource = facility;
                ddlFacilityID.DataBind();
            }
                     
        }
      
        protected void ddlFacilityID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //ddlFacilityID.DataTextField = "FacilityID";
           // string CameraIPAddress = txtIPAddress.Text;
            //float MinimumDensity = float.Parse(txtMinDensity.Text);
            //float MaximumDensity = float.Parse(txtMaxDensity.Text);

            Camera camera;
            
            using (var db = new FacilityReservationKioskEntities())
            {
                camera = db.Cameras.Where(b => b.IPAddress == "New IPAddress").FirstOrDefault<Camera>();
                        
                   
            }

            if (camera != null)
            {
                camera.IPAddress = "Updated New IPAddress";
            }


            

            lblDisplay.Text = "Update Record Successful!";
     
        }
          
           
          
        }

       
       
    }
