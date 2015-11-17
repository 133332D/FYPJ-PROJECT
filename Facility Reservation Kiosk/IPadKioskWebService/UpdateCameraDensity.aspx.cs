using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPadKioskWebService
{
    public partial class UpdateCameraDensity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cameraID = Request["cameraID"];
                string density = Request["density"];

                 using (var db = new FacilityReservationKioskEntities())
                 {

                    var cam =  db.Cameras.Find(Convert.ToInt32(cameraID));
                     if(cam != null)
                     {
                         cam.CurrentDensity = Convert.ToDouble(density);
                         db.SaveChanges();
                     }
                 }
            }
        }
    }
}