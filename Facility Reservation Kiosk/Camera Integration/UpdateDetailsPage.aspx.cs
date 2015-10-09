using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Camera_Integration
{
    public partial class UpdateDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDDL();

            if (Request.QueryString["CameraID"] == null)
            {
                if (!IsPostBack)
                {
                    lblCam.Text = Request.QueryString["CameraID"];

                   
                    using (var db = new FacilityReservationKioskEntities())
                    {
                        Camera camera = db.Cameras.Find(Convert.ToInt32(lblCam.Text));
                        txtIpAddress.Text = camera.IPAddress;
                        txtMinDensity.Text = camera.MinimumDensity.ToString();
                        txtMaxDensity.Text = camera.MaximumDensity.ToString();
                        lblFacilityID.Text = camera.FacilityID;

                    }

                }
            }
            else
            {

            }
            
        }

        private void BindDDL()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var facility = (from b in db.Cameras
                                select new { b.FacilityID }).ToList();

                ddlFacility.DataValueField = "FacilityID";
                ddlFacility.DataTextField = "FacilityID";
                ddlFacility.DataSource = facility;
                ddlFacility.DataBind();
            }

        }
        protected void btnConfirm_Click1(object sender, EventArgs e)
        {
            string ID = Request.QueryString["CameraID"];
        
           
            using (var db = new FacilityReservationKioskEntities())
            {
                //update
                
                 Camera camera = db.Cameras.Find(Convert.ToInt32(ID));

                  //modify fields
                  camera.IPAddress = txtIpAddress.Text;
                  camera.MinimumDensity = float.Parse(txtMinDensity.Text);
                  camera.MaximumDensity = float.Parse(txtMaxDensity.Text);

                  db.SaveChanges();
                

                 }              

                 lblUpdate.Text = "Record Update Successfully";
                
            }
        }
    }