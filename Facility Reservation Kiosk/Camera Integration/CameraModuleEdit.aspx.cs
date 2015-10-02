using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Camera_Integration
{
    public partial class CameraModuleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        
      
      
        protected void ddlFacilityID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string facilityname = txtFacilityName.Text;
            string IPAddress = txtIPAddress.Text;
            float MinDensity = float.Parse(txtMinDensity.Text);
            float MaxDensity = float.Parse(txtMaxDensity.Text);
            
            using (var db = new FacilityReservationKioskEntities())
            {

                Camera c = new Camera();

                        c.CameraID = 1;
                        c.FacilityID = facilityname;
                        c.IPAddress = IPAddress;
                        c.MinimumDensity = MinDensity;
                        c.MaximumDensity = MaxDensity;
                        c.DepartmentID = "SIT";
                        db.Cameras.Add(c);
                        db.SaveChanges();
             }         
                  
         }                     

                     
       }      
 
}
            
     
         
          
           
          
       

       
       
    
