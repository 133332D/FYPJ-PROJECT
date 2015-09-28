using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReservationListWebService
{
    public partial class UpdateFacility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentID = Request.QueryString["DepartmentID"];
            string json = Request.Form["Json"];
        }
    }
}