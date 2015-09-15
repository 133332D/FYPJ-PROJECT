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

        private void BindGridView()
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GrdCamera_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCamera.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}