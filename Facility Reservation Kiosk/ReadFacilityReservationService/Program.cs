using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace ReadFacilityReservationService
{
    class Program
    {
        static void Main(string[] args)
        {
            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();


            //if (args[0] == "getFRSLocationXML")
            //{
            //    Console.WriteLine(args[0]);
            //    Console.WriteLine("Result:");
            //    Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSLocationXML(args[1])));
            //}
            //if (args[0] == "getFRSListXML")
            //{
            //    Console.WriteLine(args[0]);
            //    Console.WriteLine("Result:");
            //    Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSListXML(
            //        args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10])));
            //}
            //if (args[0] == "getFRSEntriesXML")
            //{
            //    Console.WriteLine(args[0]);
            //    Console.WriteLine("Result:");
            //    Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSEntriesXML(
            //        args[1], args[2], args[3], args[4], args[5], args[6])));
            //}
            //if (args[0] == "getFRSBookingXML")
            //{
            //    Console.WriteLine(args[0]);
            //    Console.WriteLine("Result:");
            //    Console.WriteLine(HttpUtility.UrlDecode(ws.getFRSBookingXML(
            //        args[1], args[2], args[3], args[4])));
            //}
        }
    }
}
