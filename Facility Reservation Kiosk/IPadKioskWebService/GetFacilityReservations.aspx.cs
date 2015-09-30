using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class GetFacilityReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //To get the string to search in facility table
            string departmentID = Request.QueryString["DepartmentID"];
            string block = Request.QueryString["Block"];
            string level = Request.QueryString["Level"];
            string name = Request.QueryString["Name"];
            //format of date yyyy-MM-dd
            string date = Request.QueryString["Date"];

            //if date is blank, return current system date
            if( date == null )
            {
                int dateCurrentYear = DateTime.Now.Year;
                int dateCurrentMonth = DateTime.Now.Month;
                int dateCurrentDay = DateTime.Now.Day;
            }
            //else return only specified date
            else
            {

            }
        }
    }
}