using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Net.Http;

namespace Test
{
    class Program
    {

        static Hashtable cameraRtspClient = new Hashtable();

        static void CreateRTSPThreadForCamera(int cameraID, string rtspUrl)
        {
            if (cameraRtspClient[cameraID] != null)
                return;

            Media.Rtsp.RtspClient rc = new Media.Rtsp.RtspClient(rtspUrl,
                Media.Rtsp.RtspClient.ClientProtocolType.Tcp);

            cameraRtspClient[cameraID] = rc;

            rc.Client.RtpPacketReceieved += Client_RtpPacketReceieved;

            rc.StartPlaying();
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }
            rc.StopPlaying();
        }

        static void Main(string[] args)
        {
            CreateRTSPThreadForCamera(1, "rtsp://172.20.134.2/?vcd=1");
        }



        static byte GetByte(System.IO.MemoryStream ms)
        {
            return (byte)ms.ReadByte();
        }

        static ushort GetUShort(System.IO.MemoryStream ms)
        {
            return (ushort)((ms.ReadByte() << 8) + ms.ReadByte());
        }

        static int GetInt(System.IO.MemoryStream ms)
        {
            return (ms.ReadByte() << 24) + (ms.ReadByte() << 16) + (ms.ReadByte() << 8) + ms.ReadByte();
        }

        static void Client_RtpPacketReceieved(object sender, Media.Rtp.RtpPacket packet)
        {
            if (packet.PayloadType != 35)
            {
                int ptr = 0;
                byte[] payload = new byte[packet.Length];
                foreach (byte b in packet.PayloadData)
                    payload[ptr++] = b;

                System.IO.MemoryStream s = new System.IO.MemoryStream(payload);

                while (s.Position < packet.Length)
                {

                    int tag = GetUShort(s) & 0x3fff;
                    int taglength = GetUShort(s) & 0x0fff;

                    /*if (tag == 0x0000)
                    {
                        Console.WriteLine("layer_info_tag");
                    }
                    else if (tag == 0x0001)
                    {
                        Console.WriteLine("frame_info_tag");
                    }
                    else if (tag == 0x0002)
                    {
                        Console.WriteLine("alarm_flags_tag");
                    }
                    else if (tag == 0x0004)
                    {
                        Console.WriteLine("object_properties_tag");
                    }
                    else if (tag == 0x0030)
                    {
                        Console.WriteLine("config_info_tag");
                    }
                    else if (tag == 0x0032)
                    {
                        Console.WriteLine("alarm_flags_tag");
                    }
                    else if (tag == 0x0038)
                    {
                        Console.WriteLine("crowd_density_tag");
                    }
                    else
                    {
                        Console.WriteLine("tag: {0:X4}", tag);
                    }*/

                    for (int i = 0; i < taglength; i++)
                    {
                        int b = GetByte(s);

                        if (tag == 0x0038)
                        {
                            // Process the first crowd density tag
                            //
                            if (i == 1)
                            {
                                int density = (int)(b & 0x7f) * 10;

                                if (density < 0)
                                    density = 0;
                                if (density > 100)
                                    density = 100;

                                // Determine which camera ID is using this RtspClient.
                                //
                                int actualCameraID = 0;
                                foreach (int cameraID in cameraRtspClient.Keys)
                                {
                                    Media.Rtsp.RtspClient rtspClient = cameraRtspClient[cameraID] as Media.Rtsp.RtspClient;
                                    if (rtspClient.Client == sender)
                                    {
                                        actualCameraID = cameraID;
                                        break;
                                    }
                                }

                                WebClient wc = new WebClient();
                                wc.DownloadStringCompleted += (dSender, e) =>
                                {
                                };
                                wc.DownloadStringAsync(new Uri("http://crowd.sit.nyp.edu.sg/FRSIpad/UpdateCameraDensity.aspx?cameraID=" + actualCameraID + "&density=" + ((int)density).ToString()));

                                Console.WriteLine("CameraID = {0}, Density = {1}", actualCameraID, density);

                            }
                        }
                    }
                }
            }

        }

    }
}
