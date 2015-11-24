﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class CreateReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!VerifyData.Verify(Request["_DeviceID"], Request.RawUrl, Request["_SIGN"], Request["_DT"]))
            {
                Response.Write("{");
                Response.Write("     Result: \"ERROR\",");
                Response.Write("     Message: \"" + "Unable to verify iPad" + "\"");
                Response.Write("}");
                Response.End();

                return;
            }*/

            //To get the string to create new reservation table
            string userType = Request.QueryString["UserType"];
            string userID = Request.QueryString["UserID"];
            string facilityID = Request.QueryString["FacilityID"];
            string startDateTime = Request.QueryString["StartDateTime"];
            string endDateTime = Request.QueryString["EndDateTime"];
            string description = Request.QueryString["Description"];
            
            //change the date and time info if necessary
            // see what is passed in to to the startDateTime & endDateTime
            DateTime startDate = DateTime.ParseExact(startDateTime, "dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endDateTime, "dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture);

            string startDateString = startDate.ToString("dd-MMM-yyyy");
            string startTimeString = startDate.ToString("HH:mm");
            string endDateString = endDate.ToString("dd-MMM-yyyy");
            string endTimeString = endDate.ToString("HH:mm");

            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();

            //call the NYP saveFRSEntries method to insert to database
            string result = HttpUtility.UrlDecode(ws.saveFRSEntries("STAFF", "S1999557YF", "STAFF", "S1999557YF", facilityID, "", "",
                startDateString, endDateString, startTimeString, endTimeString, "Y", "Y", description, "N", "", "", "", "", "", ""));
            
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
                Response.Write("     Result: \"OK\",");
                Response.Write("     Message: \"The facility reservation is received and inserted into NYP's database successfully.\"");
                Response.Write("}");
                Response.End();
            }
            else
            {
                //returns ok/error message to caller
                Response.Write("{");
                Response.Write("     Result: \"ERROR\",");
                Response.Write("     Message: \"" + tokens[1] + "\"");
                Response.Write("}");
                Response.End();
            }
        }
    }
}