using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
	public partial class DeviceSecurity : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {

            }
            
		}

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            int search = System.Convert.ToInt32(txtSearch.Text);


            using (var db = new FacilityReservationKioskEntities())
            {
                //Basic select query from a single table
                var Search = from b in db.Devices where b.DeviceID == search orderby b.DeviceID select new { b.DeviceID, b.Status, b.ApprovedDateTime, b.RejectedOrRevokedDateTime, b.RejectedOrRevokedReason, b.Description };

                //Loop through to print out 
                GridViewSearch.DataSource = Search.ToList();
                GridViewSearch.DataBind();

            }
        }

        protected void GridViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridViewSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("Approve") == 0)
            {
                Response.Redirect("ApprovalPage.aspx");
            }
            
            if (e.CommandName.CompareTo("Reject") == 0)
            {
                Response.Redirect("RejectPage.aspx");
            }

        }
	}
}