using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class GetCameraID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FacilityID = Request.QueryString["FacilityID"];

            using (var db = new FacilityReservationKioskEntities())
            {
                //select from camera where FacilityID = L.424[QueryString]
                var camera = from c in db.Cameras
                             where c.FacilityID == FacilityID
                             select new { c.CameraID };

                List<string> cameraIDs = new List<string>();

                foreach (var cam in camera)
                {
                    cameraIDs.Add(cam.CameraID.ToString());
                }

                string cameraIDString = String.Join(",", cameraIDs.ToArray());

                //return result
                Response.Write(cameraIDString);
                Response.End();
            }
        }
    }
}