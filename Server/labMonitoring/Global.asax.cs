using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Configuration;

namespace labMonitoring
{
    public class Global : System.Web.HttpApplication
    {
        public static LabList labListGlobal = new LabList();

        private static bool isPresent(string labname)
        {
            foreach( ClientNodeList l in labListGlobal.lab_list )
            {
                if (l.lab_name.Equals(labname))
                {
                    return true;
                }
            }
            return false;
        }

        public static void populateLabs()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select labID from Computer group by labID", con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (!isPresent((string)reader["labID"]))
                {
                    labListGlobal.addLab((string)reader["labID"]);
                }
            }
            con.Close();
        }
        protected void Application_Start(object sender, EventArgs e)
        {  
            Thread th = new Thread(new ThreadStart(serverd.Run));
            th.Start();
            populateLabs();
            ClientNodeList list = labListGlobal.getLabComputers("CG");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            serverd.running = true;
        }
    }
}