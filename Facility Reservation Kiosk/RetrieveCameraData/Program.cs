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
                  // var video = from b in db.VideoAnalytics;
               }
           }
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
