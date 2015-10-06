using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Camera_Integration
{
    public partial class CameraModuleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        private void BindDDL()
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var facility = (from b in db.Cameras
                                select new { b.FacilityID }).ToList();

                ddlName.DataValueField = "FacilityID";
                ddlName.DataTextField = "FacilityID";
                ddlName.DataSource = facility;
                ddlName.DataBind();
            }

        }
      
      
        protected void ddlFacilityID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string IPAddress = txtIPAddress.Text;
            float MinDensity = float.Parse(txtMinDensity.Text);
            float MaxDensity = float.Parse(txtMaxDensity.Text);

           
            using (var db = new FacilityReservationKioskEntities())
            {
               
                    Camera c = new Camera();

                    c.CameraID = 1;
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
            
     
         
          
           
          
       

       
       
    
