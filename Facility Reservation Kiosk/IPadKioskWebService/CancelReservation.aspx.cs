using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class CancelReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string to cancel reservation table
            string userID = Request.QueryString["UserID"];
            string facilityResevationID = Request.QueryString["FacilityReservationID"];
            string reason = Request.QueryString["Reason"];

            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();

            //call the NYP delFRSEntries method to insert to database
            string result = HttpUtility.UrlDecode(ws.delFRSEntries(facilityResevationID, "S1999557YF", "S1999557YF", reason));

            //split the string result
            //if 0~ , success
            //else -1~ERRORMESSAGE....., error
            string[] tokens = result.Split(new[] { "~" }, StringSplitOptions.None);
            //if successfully return OK
            if (tokens[0] == "0")
            {
                //trigger a refresh of the cache database!!! **

                //returns ok/error message to caller
                Response.Write("{");
                Response.Write("    \"Result: OK\",");
                Response.Write("    \"Message: The facility reservation is cancelled from NYP's database successfully.\"");
                Response.Write("}");
                Response.End();
            }
            else
            {
                Response.Write("{");
                //returns ok/error message to caller
                Response.Write("     Result: \"ERROR\",");
                Response.Write("     Message: \"" + tokens[1] + "\"");
                Response.Write("}");
                Response.End();
            }
        }
    }
}