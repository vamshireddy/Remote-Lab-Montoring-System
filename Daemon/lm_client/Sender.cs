using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace SSService
{
    class Sender
    {
            static TcpClient clientSocket;
            static bool running = true;


            public static void connect(){
                clientSocket = new TcpClient();
                clientSocket.Connect("localhost", 8778);
                Console.Write("connection made to the server");
            }

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

            public static string GetMACAddress()
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }


            //Network IO functions 


            private static String ReadLine(NetworkStream ns,int length)
            {
                //receiving 
                byte[] arr = new byte[length];
                ns.Read(arr, 0, length);
                //now need to extract the line
                String tmp = GetString(arr);
                return tmp;
            }

            private static void WriteLine(NetworkStream ns, String command)
            {
                //sending
                byte[] arr = GetBytes(command);
                ns.Write(arr, 0, arr.Length);
            }

            private static void WriteLength(NetworkStream ns, String command)
            {
                String len_str = command.Length + "";
                String output = String.Format("{0,10}", len_str);
                byte[] arr = GetBytes(output);
                ns.Write(arr, 0, arr.Length);
                Console.WriteLine("SENT LENGTH : " + output);
            }

            public static void WriteMessage(NetworkStream ns, String command)
            {
                WriteLength(ns, command);
                Thread.Sleep(2);
                WriteLine(ns, command);
            }

            public static string ReadMessage(NetworkStream ns)
            {
                string s = ReadLine(ns, sizeof(char)*10);
                s = s.TrimStart();
                int length = Int32.Parse(s);
                string output = ReadLine(ns, sizeof(char)*length);
                return output;
            }
         
            public static XDocument getProcessesXML()
            {
                Process[] processlist = Process.GetProcesses();

                // Create XML Document class
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XComment("Process data"));

                XElement xele = new XElement("ProcessesRunning",
                 new XAttribute("IP", getIP()),
                 new XAttribute("Gateway", GetDefaultGateway()),
                 new XAttribute("HostName", getHostName()));

                foreach(Process theprocess in processlist){

                    string p_name = theprocess.ProcessName;
                    string p_thrds = theprocess.Threads.Count+"";
                    string p_id = theprocess.Id.ToString();

                    Console.WriteLine("{0} Threads:{1}", p_name, p_thrds);
                
                    // Add xml element to the document
                     xele.Add(new XElement("process",
                     new XElement("name", p_name),
                     new XElement("threads", p_thrds),
                     new XElement("id", p_id)));
                }

                doc.Add(xele);
                return doc;
            }

            // Network helper functions
            public static string getIP()
            {
                string hostName = Dns.GetHostName();
                Console.WriteLine(hostName);
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                return myIP;
            }
            public static string getHostName()
            {
                return  Dns.GetHostName();
            }
            public static IPAddress GetDefaultGateway()
            {
                var card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
                if (card == null) return null;
                var address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
                return address.Address;
            }

            public static void run()
            {
                NetworkStream ns = clientSocket.GetStream();
                byte[] outstream = null;

                //sent mac now running loop until termination

                while (running)
                {
                    String line = ReadMessage(ns);
                    Console.WriteLine("Got " + line);
                    Console.WriteLine("Read someting : "+line);


                    if (line.Equals("getSS"))
                    {
                            string len_str = null;
                            Boolean flaggy = true;
                            Console.WriteLine("Got screenshot request");
                            //server asking for image , ironic that the client is serving.lol
                            Bitmap img = null;
                            try
                            {
                                img = ScreenShot.Capture(0, 0, 1366, 768);
                                outstream = img.ToByteArray(ImageFormat.Png);
                                //sending image length
                                Console.WriteLine("LENGTH:" + outstream.Length);
                                //Sending length
                                len_str = outstream.Length + "";
                                flaggy = true;
                            }
                            catch (Exception)
                            {
                                flaggy = false;
                                len_str = -1+"";
                            }
                            String output = String.Format("{0,10}", len_str);
                            byte[] arr = GetBytes(output);
                            ns.Write(arr, 0, arr.Length);
                            //Sending image
                            Thread.Sleep(1);
                            // Write only if the image is captured properly
                            if (flaggy == true)
                            {
                                ns.Write(outstream, 0, outstream.Length);
                            }
                    }
                    else if (line.Equals("getStat"))
                    {   
                        XDocument doc = getProcessesXML();
                        string s = doc.ToString();
                        WriteMessage(ns,s);
                    }
                    else if (line.Equals("getMAC"))
                    {
                        //sending MAC address
                        string mac = GetMACAddress();
                        Console.Write("MAC IS : "+mac);// \n for delimiting the strings
                        WriteMessage(ns, mac);
                    }
                }
            }

            public static void listen(){
                //loop that will parse prompts from the server
                //the threadstart delegate takes in the name of the function that needs to be run on a separate thread
                //just like the POSIX threads
                ThreadStart child = new ThreadStart(run);
                Thread th = new Thread(child);
                th.Start();
            }
    }
}
