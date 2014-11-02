using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Timers;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace labMonitoring
{
    public class serverd
    {
        public static bool running = false;
        static TcpClient cl;

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        private static void handler(Object o, ElapsedEventArgs e)
        {
            NetworkStream ns = cl.GetStream();
            String req_str = "sendSS";
            byte[] byte_arr = GetBytes(req_str);
            ns.Write(byte_arr, 0, byte_arr.Length);
            Console.Write("sent request for screen shot \n " + byte_arr.Length + "\n");
        }

        private static void childFunc(Object o)
        {
            TcpClient clientSocket = (TcpClient)o;
            cl = clientSocket;
            byte[] arr = new byte[200000];
            running = true;
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(handler);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            aTimer.Start();

            NetworkStream ns = clientSocket.GetStream();

            //get MAC address 

            while (running)
            {
                ns.Read(arr, 0, arr.Length);
                //need to save the image
                Bitmap bmp;
                using (var ms = new MemoryStream(arr))
                {
                    bmp = new Bitmap(ms);
                }
                //save the image the conversion having done
                bmp.Save(@"C:\Users\Student\Desktop\tmp.png", ImageFormat.Png);
            }
        }

        public static void Run()
        {
            //the function below is deprecated and will be replaced eventuallys
            IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
            TcpListener server_soc = new TcpListener(ipAddress, 8002);
            server_soc.Start();
            while( true )
            {
                TcpClient clientSocket = server_soc.AcceptTcpClient();
                Console.Write("got connection");
                Thread th = new Thread(new ParameterizedThreadStart(childFunc));
                th.Start(clientSocket);
            }
        }
    }
    
}