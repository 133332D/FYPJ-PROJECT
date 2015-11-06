using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Configuration;

namespace RetrieveCameraImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = ConfigurationManager.AppSettings["SaveFolder"];

            using (var db = new FacilityReservationKioskEntities())
            {
                var camera = db.Cameras.ToList();

                foreach(var cam in camera)
                {
                    try
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile("http://" + cam.IPAddress   + "/snap.jpg?JpegSize=M",folder + "image-" + cam.CameraID  + ".jpg");
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    

                    
                }
                


            }
        }
    }
}
