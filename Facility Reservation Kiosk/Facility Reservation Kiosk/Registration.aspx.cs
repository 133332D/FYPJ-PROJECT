using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facility_Reservation_Kiosk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Message;

            //To get the string and register device 
            string UniqueID = Request.QueryString["UniqueID"];
            string PublicKey = Request.QueryString["PublicKey"];

            //If DeviceID not registered, insert new record 
            using (var db = new FacilityReservationKioskEntities())
            {
                    var register = new Device { Status = "NEW", DeviceGeneratedUniqueID = UniqueID, PublicKey = PublicKey };
                    db.Devices.Add(register);
                    //db.SaveChanges();

                    try { 

                    db.SaveChanges();

                    Response.Write("{");
                    Response.Write("     Result: \"OK\",");
                    Response.Write("     Message: \"This iPad have been registered in the system database, awaiting for approval\"");
                    Response.Write("}");
                    Response.End();

                    }

                catch (Exception ex)
                    {

                      Message = ex.Message;

                      //returns ok/error message to caller
                      Response.Write("{");
                      Response.Write("     Result: \"ERROR\",");
                      Response.Write("     Message: \"" + Message + "\"");
                      Response.Write("}");
                      Response.End();
                }
                
            }

           }
        }
    }
