using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Camera_Integration
{
    public partial class ModuleSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindGridView();
            }
        }

        public void BindGridView()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var result = from b in db.Cameras
                             select new {b.CameraID, b.FacilityID, b.IPAddress, b.MinimumDensity, b.MaximumDensity };

                grdCamera.DataSource = result.ToList();
                grdCamera.DataBind();

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string  search = txtSearch.Text;
            using (var db = new FacilityReservationKioskEntities())
            {
                var result = from b in db.Cameras
                             where b.FacilityID == search
                             select new {b.CameraID, b.FacilityID, b.IPAddress, b.MinimumDensity, b.MaximumDensity };

                //loop through to print out
                grdCamera.DataSource = result.ToList();
                grdCamera.DataBind();
            }
        }

        protected void grdCamera_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("Update") == 0)
            {
                string Row = (string)e.CommandArgument;
                string CamID = grdCamera.DataKeys[Convert.ToInt32(Row)][0].ToString();
                Response.Redirect("UpdateDetailsPage.aspx?CameraID=" + CamID);

            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateDetailsPage.aspx");
        }

        protected void GrdCamera_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GrdCamera_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grdCamera.EditIndex = -1;
            //BindGridView();
        }

        protected void GrdCamera_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int selectedRow = e.RowIndex;
            //Label FacilityID = (Label)grdCamera.Rows[selectedRow].FindControl("cameraID1");
            //string facilityID = FacilityID.Text;
             // BindGridView();
        }

        protected void GrdCamera_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Label IDcamera = (Label)grdCamera.Rows[e.NewEditIndex].FindControl("cameraID1");
            //string camID = IDcamera.Text;
            //Session["cameraIDEdit"] = camID;
        }

        protected void GrdCamera_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GrdCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GrdCamera_Sorting(object sender, GridViewSortEventArgs e)
        {
            // grdCamera.PageIndex = 0;
            // BindGridView();
        }

    }
}