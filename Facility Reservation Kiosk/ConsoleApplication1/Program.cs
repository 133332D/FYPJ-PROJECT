using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FRSWS.WSfrsClient ws = new FRSWS.WSfrsClient();

            string result = HttpUtility.UrlDecode(ws.saveFRSEntries("STAFF", "chowkf", "STAFF", "chowkf", "L.509A", "", "",
                "02-OCT-2015", "03-OCT-2015", "1300", "1500", "Y", "Y", "descrishfvishvs", "N", "", "", "", "", "", ""));
            Console.WriteLine(result);
        }
    }
}
