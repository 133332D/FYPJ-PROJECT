using System;
using System.Linq;
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
                var Search = from b in db.Devices where b.DeviceID == search orderby b.DeviceID + "%" select new { b.DeviceID, b.Status, b.ApprovedDateTime, b.RejectedOrRevokedDateTime, b.RejectedOrRevokedReason, b.Description };

                //Loop through to print out 
                GridViewSearch.DataSource = Search.ToList();
                GridViewSearch.DataBind();

            }
        }

        protected void GridViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        
       
        protected void LinkBtnRevoke_Click(object sender, EventArgs e)
        {
            Response.Redirect("Revoke.aspx?searchID=" + txtSearch.Text);
        }
        protected void GridViewSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*if (e.CommandName.CompareTo("Approve") == 0)
            {
                Response.Redirect("ApprovalPage.aspx?searchID=" + txtSearch.Text);
               
            }
            
            if (e.CommandName.CompareTo("Reject") == 0)
            {
                Response.Redirect("RejectPage.aspx?searchID=" + txtSearch.Text);
            }*/

        }
        protected void lbapp (object sender, GridViewRowEventArgs e) 
        {

            Response.Redirect("ApprovalPage.aspx?searchID=" + txtSearch.Text);
        }

        protected void lbrej (object sender, GridViewRowEventArgs e)
        {
            Response.Redirect("RejectPage.aspx?searchID=" + txtSearch.Text);
        }

        /*protected void lbedit (object sender, GridViewRowEventArgs e)
        {
            Response.Redirect("");
        }*/

        protected void lbrevoke (object sender, GridViewRowEventArgs e)
        {
            Response.Redirect("Revoke.aspx?searchID=" + txtSearch.Text);
        }

        protected void GridViewSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string status = e.Row.Cells[1].Text;
        
            if (status == "New") 
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

       /* protected void GridViewSearch_DataBound(object sender, EventArgs e)
        {
            if (GridViewSearch.Columns.Count > 0)
            {
                foreach (GridViewRow gvr in GridViewSearch.Rows)
                {
                    if (gvr.Cells[1].Text == "New")
                    {
                        gvr.Cells[6].Text = "Approve";
                        gvr.Cells[7].Text = "Reject";
                    }
                    else if (gvr.Cells[1].Text == "APP")
                    {
                        gvr.Cells[6].Text = "Edit";
                        gvr.Cells[7].Text = "Revoke";
                    }
                    else
                    {
                        gvr.Cells[6].Text = "";
                        gvr.Cells[7].Text = "";
                    }
                }
            }
        }*/



        //protected void GridViewSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    LinkButton lnk2 = (LinkButton)e.Row.FindControl("LinkButton2");
        //    LinkButton lnk1 = (LinkButton)e.Row.FindControl("LinkButton1");
        //    LinkButton lnk3 = (LinkButton)e.Row.FindControl("LinkButton3");
        //    LinkButton lnk4 = (LinkButton)e.Row.FindControl("LinkButton4");

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        {
                    
        //            foreach (GridViewRow row in GridViewSearch.Rows)
        //            {
                        
        //                if (row.Cells[1].Text == "New")
        //                {
        //                    lnk1.Enabled = true;
        //                    lnk3.Visible = false;
        //                    //lnk3.Enabled = false;
        //                    lnk2.Enabled = true;
        //                    lnk4.Enabled = false;
        //                }
        //                else if (row.Cells[1].Text == "APP")
        //                {
        //                    lnk1.Enabled = false;
        //                    lnk3.Enabled = true;
        //                    lnk2.Enabled = false;
        //                    lnk4.Enabled = true;
        //                }
        //                else
        //                {
        //                    lnk1.Enabled = false;
        //                    lnk3.Enabled = false;
        //                    lnk2.Enabled = false;
        //                    lnk4.Enabled = false;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}