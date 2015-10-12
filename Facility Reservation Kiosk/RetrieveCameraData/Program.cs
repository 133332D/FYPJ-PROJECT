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
           using (var db = new RetrieveCameraData.FacilityReservationKioskEntities1())
           {
               var camera = db.Cameras.ToList();
               foreach (var cam in camera)
               {
                   Console.WriteLine(cam.CameraID);

                   //insert into VideoAnalytics Table
                   VideoAnalytic video = new VideoAnalytic();
                   video.VideoAnalyticsID = 1;
                   video.CameraID = 1;
                   video.IPAddress = "12.213.10.1";
                   video.CrowdDensity = 0;
                   video.SnapshotFile = "";
                   db.VideoAnalytics.Add(video);
                                
                                        
               }
               Console.WriteLine("VideoAnalytics Record Added");
           }



            DateTime time = DateTime.Now; //use current time 
            string format = "d MMM yyyy ddd HH:mm"; //use this format
            Console.WriteLine(time.ToString(format));
            
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
