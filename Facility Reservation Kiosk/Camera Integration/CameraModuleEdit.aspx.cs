using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text;
            decimal minimumDensity = Convert.ToDecimal(txtMinDensity);
            decimal maximumDensity = Convert.ToDecimal(txtMaxDensity);
        }
    }
}