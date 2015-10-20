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
                if( !db.FacilityReservations.Any())
                {

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
