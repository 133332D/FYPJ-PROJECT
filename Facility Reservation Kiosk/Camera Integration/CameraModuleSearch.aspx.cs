using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Camera_Integration
{
    public partial class CameraModuleSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPages.Text = "";
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "facilityName"; 
                BindGridView();
            }
        }

        private void BindGridView()
        {
         
            string sortExpression = String.Format ("{0} {1}",ViewState["SortExpression"]);
           
        }

   
        protected void GrdCamera_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCamera.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GrdCamera_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;
            Label FacilityID = (Label)GrdCamera.Rows[selectedRow].FindControl("cameraID1");
            string facilityID = FacilityID.Text;
        }

        protected void GrdCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cameraIDText = "";
            int selectedRow = GrdCamera.SelectedIndex;

            Label cameraID = (Label)GrdCamera.Rows[selectedRow].FindControl("cameraID1");
            Label ipAddress = (Label)GrdCamera.Rows[selectedRow].FindControl("ipAddress1");
            cameraIDText = cameraID.Text;
            string ippad = ipAddress.Text;
            Session["cameraID"] = cameraIDText;
            Session["ipAddress"] = ippad;
             
        }

        protected void GrdCamera_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void GrdCamera_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GrdCamera_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GrdCamera_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CameraModuleEdit.aspx");

        }
    }
}