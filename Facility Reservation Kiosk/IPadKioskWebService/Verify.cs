using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Globalization;

namespace IPadKioskWebService
{
    public class VerifyData
    {
        public static bool Verify(string deviceID, string url, string signature, string date)
        {
            bool verify = false;

            if (deviceID == null || deviceID == "")
            {
                return false;
            }

            if (url == null || url == "")
            {
                return false;
            }

            if (signature == null || signature == "")
            {
                return false;
            }

            if (date == null || date == "")
            {
                return false;
            }

            DateTime D = DateTime.ParseExact(date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            DateTime currentTime = DateTime.Now;

            if (currentTime.AddMinutes(-3) <= D && D <= currentTime.AddMinutes(3))
            {

                using (var db = new FacilityReservationKioskEntities())
                {
                    //Load up and update 

                    var device = from b in db.Devices where b.DeviceGeneratedUniqueID == deviceID select new { b.PublicKey, b.Status };

                    foreach (var d in device)
                    {
                        if (d.Status == "APP")
                        {
                            RSACryptoServiceProvider rsaProvider = null;

                            rsaProvider = new RSACryptoServiceProvider();
                            rsaProvider.FromXmlString(d.PublicKey);

                            int position = url.IndexOf("&_SIGN");

                            if (position >= 0)
                            {
                                url = url.Substring(0, position);
                            }

                            byte[] array = System.Text.UTF8Encoding.UTF8.GetBytes(url);
                            byte[] arraySignature = new byte[signature.Length / 2];

                            for (int i = 0; i < signature.Length; i += 2)
                            {
                                string Hex = "" + signature[i] + signature[i + 1];
                                byte b = (byte)Convert.ToInt32(Hex, 16);
                                arraySignature[i / 2] = b;
                            }

                            verify = rsaProvider.VerifyData(array, "SHA256", arraySignature);
                        }
                        break;
                    }

                }
            }

            return verify;

        }


    }
}