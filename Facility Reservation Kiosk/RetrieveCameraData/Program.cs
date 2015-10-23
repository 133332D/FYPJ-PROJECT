using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;
using System.Data.Entity;

namespace RetrieveCameraData
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            using (var db = new FacilityReservationKioskEntities1())
           {
               var camera = db.Cameras.ToList();
               foreach (var cam in camera)
               {
                   Console.WriteLine("CameraID:" + cam.CameraID);

                   //insert into VideoAnalytics Table                
                   VideoAnalytic video = new VideoAnalytic();
                   video.CameraID = cam.CameraID;
                   video.IPAddress = cam.IPAddress;
                   float CrowdDensity = rnd.Next((int)(cam.MinimumDensity ?? 0) , (int)(cam.MaximumDensity ?? 0));
                   video.SnapshotFile = "";
                   db.VideoAnalytics.Add(video);
                   db.SaveChanges();
                   

               }
               Console.WriteLine("VideoAnalytics Record Added");


           }


           
            DateTime time = DateTime.Now; 
            string format = "d MMM yyyy ddd HH:mm"; 
            Console.WriteLine(time.ToString(format));

             //Logging 
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            string datetime =  DateTime.Now.ToString();
            string full = "[Executed on " + datetime + " ]";

            string path = "c:\\Log\\RetrieveCameraData-" + year + "-" + month + "-" + day + ".txt";

            StreamWriter log;

            if (!File.Exists("RetrieveCameraData-" + year + "-" + month + "-" + day + ".txt") )
            {
                log = new StreamWriter("RetrieveCameraData-" + year + "-" + month + "-" + day + ".txt");
            }
            else
            {
                log = File.AppendText("RetrieveCameraData-" + year + "-" + month + "-" + day + ".txt");
            }

            log.WriteLine(DateTime.Now);
            log.WriteLine();

            log.Close();
        }

        //public class KioskContext : DbContext
        //{
        //    //using FacilityReservationKioskEntities Connection String
        //    public KioskContext()
        //    :base("name = FacilityReservationKioskEntities")
        //    {
        //    }
        //    public DbSet<Camera> Cameras { get; set; }
        //    public DbSet<VideoAnalytic> VideoAnalytics { get; set; }
        //    public DbSet<CameraReferenceImage> CameraReferenceImages { get; set; }


        //}

        //public class Camera
        //{
        //    public int CameraID { get; set; }
        //    public string ipAddress { get; set; }
        //}
        //public class VideoAnalytic
        //{
        //    public string IPAddress { get; set; }
        //    public float CrowdDensity { get; set; }
        //    public string SnapshotFile { get; set; }
        //}
        //public class CameraReferenceImage
        //{ 

        //}
        

    }
}
