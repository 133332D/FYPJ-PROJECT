using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class Security : System.Web.UI.Page
    {
        string country;
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
             if (txtSearch.Text == "")
            {

                using (var db = new FacilityReservationKioskEntities())
                {
                    //Basic select query from a single table 
                    var Search = from b in db.Devices select new { b.DeviceID, b.DeviceGeneratedUniqueID, b.Status, b.Description, b.ApprovedDateTime, b.RejectedOrRevokedDateTime, b.RejectedOrRevokedReason };

                    //Loop through to print out
                    GridViewSearch.DataSource = Search.ToList();
                    GridViewSearch.DataBind();
                }
            }

            else
            {
                {
                    int search = System.Convert.ToInt32(txtSearch.Text);

                    using (var db = new FacilityReservationKioskEntities())
                    {
                        //Basic select query from a single table
                        var Search = from b in db.Devices where b.DeviceID == search orderby b.DeviceID select new { b.DeviceID, b.DeviceGeneratedUniqueID, b.Status, b.ApprovedDateTime, b.RejectedOrRevokedDateTime, b.RejectedOrRevokedReason, b.Description };

                        //Loop through to print out 
                        GridViewSearch.DataSource = Search.ToList();
                        GridViewSearch.DataBind();
                    }
                }
            }
        }

        protected void GridViewSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
              string status = e.Row.Cells[1].Text;
              string deviceID = e.Row.Cells[6].Text;

            if (status == "NEW")
            {
                LinkButton lbapp = (LinkButton)(e.Row.FindControl("lbapp"));
                LinkButton lbrej = (LinkButton)(e.Row.FindControl("lbrej"));
                LinkButton lbedit = (LinkButton)(e.Row.FindControl("lbedit"));
                LinkButton lbrevoke = (LinkButton)(e.Row.FindControl("lbrevoke"));
                lbapp.Visible = true;
                lbrej.Visible = true;
            }
            else if (status == "APP")
            {
                LinkButton lbapp = (LinkButton)(e.Row.FindControl("lbapp"));
                LinkButton lbrej = (LinkButton)(e.Row.FindControl("lbrej"));
                LinkButton lbedit = (LinkButton)(e.Row.FindControl("lbedit"));
                LinkButton lbrevoke = (LinkButton)(e.Row.FindControl("lbrevoke"));
                lbedit.Visible = true;
                lbrevoke.Visible = true;
            }
            else
            {

            }
          
            }

        protected void lbapp_Click(object sender, EventArgs e)
        {
            var clocklink = (Control) sender;
            GridViewRow row = (GridViewRow)clocklink.NamingContainer;
             string deviceID = row.Cells[0].Text;
             Response.Redirect("ApprovalPage.aspx?searchID=" + deviceID);
            //GridViewRow row = GridViewSearch.SelectedRow;
            //Label lblValue = (Label)row.FindControl("lblUniqueID");
            //GridViewRow row = GridViewSearch.SelectedRow;
            //Label MyLabel = (Label)row.FindControl("lblUniqueID");
            //deviceID = MyLabel.ToString();
            
            /*foreach (GridViewRow row in GridViewSearch.Rows)
            {
                Label lbl = (Label)row.FindControl("lblUniqueID");
               
                deviceID = lbl.Text;

                //deviceID = ((Label)row.FindControl("lblUniqueID")).Text;
            }*/
             
         
            //I don't know how to do, please help me!
        }

        /*protected void GridViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing BoundField Column
            name = GridViewSearch.SelectedRow.Cells[0].Text;

            //Accessing TemplateField Column controls
            //country = (GridViewSearch.SelectedRow.FindControl("lblUniqueID") as Label).Text;

            Response.Redirect("ApprovalPage.aspx?searchID=" + name);
            
            //Response.Redirect("RevokePage.aspx?searchID=" + country);

            //Response.Redirect("EditPage.aspx?searchID=" + country);      

        }*/

        protected void lbrej_Click(object sender, EventArgs e)
        {
            var clocklink = (Control)sender;
            GridViewRow row = (GridViewRow)clocklink.NamingContainer;
            string deviceID = row.Cells[0].Text;
            Response.Redirect("RejectPage.aspx?searchID=" + deviceID);
        }

        protected void lbedit_Click(object sender, EventArgs e)
        {
            var clocklink = (Control)sender;
            GridViewRow row = (GridViewRow)clocklink.NamingContainer;
            string deviceID = row.Cells[0].Text;
            Response.Redirect("EditPage.aspx?searchID=" + deviceID);
        }

        protected void lbrevoke_Click(object sender, EventArgs e)
        {
            var clocklink = (Control)sender;
            GridViewRow row = (GridViewRow)clocklink.NamingContainer;
            string deviceID = row.Cells[0].Text;
            Response.Redirect("RevokePage.aspx?searchID=" + deviceID);
        }
    }
}