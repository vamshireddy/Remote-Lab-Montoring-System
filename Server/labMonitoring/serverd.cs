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
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace labMonitoring
{
    public class serverd
    {
        public static bool running = false;
        public static string xmlURL = (string)ConfigurationManager.AppSettings["XMLURL"].ToString();
        public static string imgURL = (string)ConfigurationManager.AppSettings["ImageURL"].ToString();

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

        public static Bitmap ByteToImage(byte[] blob)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                mStream.Write(blob, 0, blob.Length);
                mStream.Seek(0, SeekOrigin.Begin);

                Bitmap bm = new Bitmap(mStream);
                return bm;
            }
        }

        public static Image ByteToImageNew(byte[] blob)
        {
            MemoryStream ms = new MemoryStream(blob);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        static void updateImageInNode(NetworkStream ns,ClientNode node)
        {
           
            // Tell the computer daemon to fetch the screenshot!
            WriteMessage(ns,"getSS");
            //Fetch the image
            int len = ReadLength(ns);
            if (len == -1)
            {
                // Error in image retrieval
                node.node_mode = 0;
                return;
            }
            byte[] arr = new byte[len];
            ns.Read(arr, 0, len);
            //got the image
            //making a new bmp obejct can we modify the old one ?  FIXME#
            var fs = new BinaryWriter(new FileStream(@""+imgURL + node.mac + ".png", FileMode.Create, FileAccess.Write));
            fs.Write(arr);
            fs.Close();
            
            //updated image 
            //Hasta la vista, baby
            //no no update date time
            node.last_time = DateTime.Now;
            //Finally,Hasta la vista, baby
        }

        static void updateStatInNode(NetworkStream ns, ClientNode node)
        {
            // Tell the computer daemon to fetch the stat!
            WriteMessage(ns, "getStat");
            // Get the XML string and convert it to XML document
            string xmlString = ReadMessage(ns);
            // Store the XML string
            var fs = new BinaryWriter(new FileStream(@""+xmlURL + node.mac + ".xml", FileMode.Create, FileAccess.Write));
            fs.Write(GetBytes(xmlString));
            fs.Close();
        }

        static String[] getLabDetail(String mac)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select labID,ComputerID from Computer where MAC='"+mac+"'", con);
            con.Open();
            //made connection now need data
            SqlDataReader reader = cmd.ExecuteReader();
            String [] detail=new String[2];

            if (reader.Read())
            {
                detail[0] = (String)reader["labID"];
                detail[1] = (String)reader["ComputerID"];
                return detail;
            }
            return null;
        }

        //Network IO functions 

        //Network IO functions 


        private static String ReadLine(NetworkStream ns, int length)
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
        }

        public static void WriteMessage(NetworkStream ns, String command)
        {
            WriteLength(ns, command);
            WriteLine(ns, command);
        }

        public static string ReadMessage(NetworkStream ns)
        {
            int length = ReadLength(ns);
            string output = ReadLine(ns, sizeof(char)*length);
            return output;
        }

        public static int ReadLength(NetworkStream ns)
        {
            string s = ReadLine(ns, sizeof(char) * 10);
            s = s.TrimStart();
            int length;
            try
            {
                // Check if the image length is sent properly from client
                length = (int)Int64.Parse(s);
            }
            catch (Exception e)
            {
                // Else return error and set mode back
                return -1;
            }
            return length;
        }


        //this is what will happen in the thread
        private static void childFunc(Object o)
        {
            TcpClient clientSocket = (TcpClient)o;

            running = true;

            NetworkStream ns = clientSocket.GetStream();

            //get MAC address 
            //stream_writer.WriteLine("getMAC");
            String command = "getMAC";
            WriteMessage(ns, command);
            String mac = ReadMessage(ns);
            String [] detail =  getLabDetail(mac);
            String lab_name = detail[0];
            String comp_name = detail[1];

            /*
             * Add the client node to the list 
             */
            ClientNodeList comp_list = Global.labListGlobal.getLabComputers(lab_name);
            ClientNode associated_node = null;
            associated_node = new ClientNode(comp_name,clientSocket, mac);
            comp_list.addClient(associated_node);

            /*
             * Loop until thread end
             */
            while (running)
            {
                /*
                 * If the ASP.NET thread wants an image, then fetch it
                 */
                if (associated_node.node_mode == 1)
                {
                    //expired image , request new
                    updateImageInNode(ns, associated_node);
                    //done with the job time to change node state          
                    associated_node.node_mode = 0;
                }
                /*
                 * If ASP.NET thread wants process stats, then fetch those.
                 */
                if (associated_node.node_mode == 2)
                {
                    updateStatInNode(ns,associated_node);
                    //done with the job time to change node state    
                    associated_node.node_mode = 0;
                }
            }
        }

        public static void Run()
        {
            //the function below is deprecated and will be replaced eventuallys
            IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
            TcpListener server_soc = new TcpListener(ipAddress, 8778);
            server_soc.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
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