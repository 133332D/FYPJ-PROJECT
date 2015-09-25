using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
            ddlFacilityID.DataTextField = "facilityName";
            ddlFacilityID.DataValueField = "facilityID";
            ddlFacilityID.DataBind();
           
        }

        protected void ddlFacilityID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=L33525;Database=FacilityReservationKiosk;User Id=FRS;Password=123456";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO Camera(FacilityID, IPAddress,MinimumDensity,MaximumDensity) VALUES (" + txtIPAddress.Text + "," + txtMinDensity.Text + "," + txtMaxDensity.Text + ");";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            string facilityID = ddlFacilityID.SelectedValue;
            string ipAddress = txtIPAddress.Text;
            decimal minDensity = Convert.ToDecimal(txtMinDensity.Text);
            decimal maxDensity = Convert.ToDecimal(txtMaxDensity.Text);

            lblDisplay.Text = "Data has been inserted";
          
        }

       
       
    }
}