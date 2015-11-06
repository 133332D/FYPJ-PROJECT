using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CameraWebService
{
    public partial class GetCameraID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FacilityID = Request.QueryString["FacilityID"];

            using (var db = new FacilityReservationKioskEntities())
            {
                //select from camera where FacilityID = L.431 [QueryString]
                var camera = from cam in db.Cameras
                             where cam.FacilityID == FacilityID
                             select new { cam.FacilityID};

                //var c = db.Cameras.ToList();
                //int[] array = { 1, 3, 6, 7 };
                
            }
            
        }
    }
}