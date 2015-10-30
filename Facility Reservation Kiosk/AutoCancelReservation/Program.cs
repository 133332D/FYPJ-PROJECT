using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;


namespace AutoCancelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FacilityReservationKioskEntities())
            {
                var reservations = from r in db.FacilityReservations
                          where r.StartDateTime<DateTime.Now.AddMinutes(-15) && DateTime.Now < r.EndDateTime
                          select r;

                foreach (var facreservation in db.FacilityReservations)
                {
                    var listofcameras = from c in db.Cameras
                                        where c.FacilityID == facreservation.FacilityID
                                        select c;

                    foreach (var camera in listofcameras)
                    {
                        var video = from v in db.VideoAnalytics
                                    where v.CameraID == camera.CameraID && v.DateTime >= DateTime.Now.AddMinutes(-15)
                                    select v;   

                    }

                    var avg = (from video in db.VideoAnalytics
                               select video.CrowdDensity).Average();

                   
                                        
                }
                

                          
                        
                                     
            }

            DateTime time = DateTime.Now;
            string format = "d MMM yyyy ddd HH:mm";
            Console.WriteLine(time.ToString(format));

            //Logging 
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            string datetime = DateTime.Now.ToString();
            string full = "[Executed on " + datetime + " ]";

            string path = "c:\\Log\\AutoCancelReservation-" + year + "-" + month + "-" + day + ".txt";

            StreamWriter log;

            if (!File.Exists("AutoCancelReservation-" + year + "-" + month + "-" + day + ".txt"))
            {
                log = new StreamWriter("AutoCancelReservation-" + year + "-" + month + "-" + day + ".txt");
            }
            else
            {
                log = File.AppendText("AutoCancelReservation-" + year + "-" + month + "-" + day + ".txt");
            }

            log.WriteLine(DateTime.Now);
            log.WriteLine();

            log.Close();
        }
    }
}
