using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class VerifyIpad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!VerifyData.Verify(Request["_DeviceID"], Request.RawUrl, Request["_SIGN"], Request["_DT"]))
            {
                Response.Write("{");
                Response.Write("     Result: \"ERROR\",");
                Response.Write("     Message: \"" + "Unable to verify iPad" + "\"");
                Response.Write("}");
                Response.End();

                return;
            }
        }
    }
}