using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;
using System.Configuration;

namespace labMonitoring
{
    public partial class Output_Page : System.Web.UI.Page
    {
        public static string image_path = @"~\Images\"; 
        public static string xmlPATH = @"~\XML\";
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
             * Check the session
             */
            if (Session["sessID"] == null)
            {
                Response.Redirect("Faculty_login.aspx");
            }
             

        }


        private Boolean isImageExpired(ClientNode associated_node)
        {
            Random mRnd = new Random();
            int mRandomNumber = mRnd.Next(0, 99999);
            //calculate time diff
            double now_sec = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            double last_sec = associated_node.last_time.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

            if (now_sec - last_sec < 5)
            {
                //return old image, so nothing to do
                image.Src = image_path + associated_node.mac+".png?"+mRandomNumber;
                return false;
            }
            return true;

        }


        protected void getScreenShot(object sender, EventArgs e)
        {
            Random mRnd = new Random();
            int mRandomNumber = mRnd.Next(0, 99999);
            //this function is called every 5 secs

            //this is the preliminary check to get old or new image
            ClientNode associated_node=null;

            LabList lablist = Global.labListGlobal;
            foreach(ClientNodeList complist in lablist.lab_list)
            {
                if (complist.lab_name.Equals(Session["labname"]))
                {
                    //got the lab

                    bool over = false;
                    foreach (ClientNode node in complist.list)
                    {
                        //got the computer

                        if (node.name.Equals(Session["compname"]))
                        {
                            associated_node = node;
                            break;
                        }
                    }
                    if (over)
                    {
                        break;
                    }   
                }
            }

            if (!isImageExpired(associated_node))
            {
                image.Src = image_path + associated_node.mac + ".png?"+mRandomNumber;
                return;
            }
            
            //image invalid so entering into critical section 
            associated_node._lock.WaitOne(60000);

                 //this is for handing queued cleint whos resource is available
                 if (!isImageExpired(associated_node))
                 {
                     image.Src = image_path + associated_node.mac + ".png?" + mRandomNumber;
                    return;
                 }

                 //will tell daemon to initiate image fetch
                 associated_node.node_mode = 1;

                 while (associated_node.node_mode == 1)
                 { 
                    //wait for the daemon to get over with the image
                 }

                 //will tell daemon to initiate process stat fetch
                 associated_node.node_mode = 2;

                 while (associated_node.node_mode == 2)
                 {
                     //wait for the daemon to get over with the process stat
                 }

                 //Set the image back, so that the client can fetch it now.
                 image.Src = image_path + associated_node.mac + ".png?" + mRandomNumber;
                 image.Alt = "CANT LOAD";
                 // Set the Process stats
                 setStats(associated_node);
                 //labely.Text = "PATH : " + image.Src+ associated_node.last_time + " MAC IS " + associated_node.mac;
            // Release the mutex
            
            associated_node._lock.ReleaseMutex();
            UpdatePanel1.Update();
        }

        public void setStats(ClientNode node)
        {
            XDocument doc = XDocument.Load(@"" + ConfigurationManager.AppSettings["XMLURL"].ToString()+ node.mac.ToString() + ".xml");
            // Set the labels
            //iptb.Text = "IP : "+(string)doc.Root.Attribute("IP");
           // Gateway.Text = "Gateway : "+(string)doc.Root.Attribute("Gateway");
           // hostName.Text = "Hostname : "+(string)doc.Root.Attribute("HostName"); 
            // Now create a list of the processes
            Label1.Text = "Screenshot at " + DateTime.Now;
            title.Text = "Processes Running on " + (string)doc.Root.Attribute("HostName");

            DataSet s = new DataSet();
            DataTable table1 = new DataTable("processes");
            table1.Columns.Add("Process Name");
            table1.Columns.Add("Process ID");
            table1.Columns.Add("Threads Running");

            foreach (XElement xe in doc.Descendants("process"))
            {
                table1.Rows.Add(xe.Element("name").Value, xe.Element("id").Value, xe.Element("threads").Value);
            }
            s.Tables.Add(table1);
            // Done adding
            // Now set it to the front end
            GridView1.DataSource = s;
            this.DataBind();
        }
    }
}