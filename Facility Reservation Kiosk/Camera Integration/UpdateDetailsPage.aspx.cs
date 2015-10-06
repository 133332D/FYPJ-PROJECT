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
            if (!IsPostBack)
            {
                lblCam.Text = Request.QueryString["CameraID"];

                BindDDL();

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

        private void BindDDL()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var facility = (from b in db.Cameras
                                select new { b.FacilityID }).ToList();

                ddl1.DataValueField = "FacilityID";
                ddl1.DataTextField = "FacilityID";
                ddl1.DataSource = facility;
                ddl1.DataBind();
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