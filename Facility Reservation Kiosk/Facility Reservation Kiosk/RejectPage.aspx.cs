using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class RejectPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbDeviceID.Text = Request.QueryString["searchID"];
            lblDateTime.Text = DateTime.Now.ToString("M/dd/yy");
        }
    }
}