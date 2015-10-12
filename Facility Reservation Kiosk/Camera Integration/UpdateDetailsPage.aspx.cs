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

            if (Request.QueryString["CameraID"] != null)
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
                        //lblFacilityID.Text = camera.FacilityID;
                       // ddlFacility.Items.FindByValue(camera.FacilityID);
                        ddlFacility.SelectedValue = camera.FacilityID;
                    }

                }
            }
            //else
            //{

            //}

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
        protected void btnConfirm_Click1(object sender, EventArgs e)
        {
            string ID = Request.QueryString["CameraID"];

            if (Request.QueryString["CameraID"] != null)
            {
                using (var db = new FacilityReservationKioskEntities())
                {
                    //update

                    Camera camera = db.Cameras.Find(Convert.ToInt32(ID));

                    //modify fields
                    camera.FacilityID = ddlFacility.SelectedValue;
                    camera.IPAddress = txtIpAddress.Text;
                    camera.MinimumDensity = float.Parse(txtMinDensity.Text);
                    camera.MaximumDensity = float.Parse(txtMaxDensity.Text);

                    db.SaveChanges();


                }

                lblUpdate.Text = "Record Update Successfully";
            }
            else
            {
                using (var db = new FacilityReservationKioskEntities())
                {
                    Camera camera = new Camera();
                    camera.FacilityID = ddlFacility.SelectedValue;
                    camera.IPAddress = txtIpAddress.Text;
                    camera.MinimumDensity = float.Parse(txtMinDensity.Text);
                    camera.MaximumDensity = float.Parse(txtMaxDensity.Text);
                    db.Cameras.Add(camera);
                    db.SaveChanges();

                }
                lblUpdate.Text = "Record Update Successfully";
            }


        }
    }
}