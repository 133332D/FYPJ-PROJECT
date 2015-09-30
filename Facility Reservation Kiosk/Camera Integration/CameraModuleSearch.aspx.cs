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
                
                BindGridView();
           }
        }

        public void BindGridView()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var result = from b in db.Cameras
                             select new { b.FacilityID, b.IPAddress, b.MinimumDensity, b.MaximumDensity };

                grdCamera.DataSource = result.ToList();
                grdCamera.DataBind();

           }
           
        }

   
        protected void GrdCamera_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           // grdCamera.PageIndex = e.NewPageIndex;
           // BindGridView();
        }

        protected void GrdCamera_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int selectedRow = e.RowIndex;
            //Label FacilityID = (Label)grdCamera.Rows[selectedRow].FindControl("cameraID1");
            //string facilityID = FacilityID.Text;
          //  BindGridView();
        }

        protected void GrdCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cameraIDText = "";
            int selectedRow = grdCamera.SelectedIndex;

            Label cameraID = (Label)grdCamera.Rows[selectedRow].FindControl("cameraID1");
            Label ipAddress = (Label)grdCamera.Rows[selectedRow].FindControl("ipAddress1");
            cameraIDText = cameraID.Text;
            string ippad = ipAddress.Text;
            Session["cameraID"] = cameraIDText;
            Session["ipAddress"] = ippad;
             
        }

        protected void GrdCamera_Sorting(object sender, GridViewSortEventArgs e)
        {
           // grdCamera.PageIndex = 0;
           // BindGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           string search  = txtSearch.Text;
           using ( var db = new FacilityReservationKioskEntities())
           {
               var result = from b in db.Cameras
                            where b.FacilityID == search 
                           select new { b.FacilityID,b.IPAddress, b.MinimumDensity, b.MaximumDensity};

               //loop through to print out
               grdCamera.DataSource = result.ToList();
               grdCamera.DataBind();
           }

           
        }

        protected void GrdCamera_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grdCamera.EditIndex = -1;
            //BindGridView();
        }

        protected void GrdCamera_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Label IDcamera = (Label)grdCamera.Rows[e.NewEditIndex].FindControl("cameraID1");
            //string camID = IDcamera.Text;
            //Session["cameraIDEdit"] = camID;

            //grdCamera.EditIndex = e.NewEditIndex;
            // BindGridView();
        }
       

        protected void GrdCamera_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CameraModuleEdit.aspx");

        }

        protected void grdCamera_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
             
       }

   }
}   

 