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
using System.Data;
using System.Data.SqlClient;

namespace labMonitoring
{
    public class Global : System.Web.HttpApplication
    {
        public static LabList labListGlobal = new LabList();

        private void populateLabs()
        {
            SqlConnection con = new SqlConnection("data source=.;initial catalog=vamshi;user id=sa;password=sajalsuraj;integrated security=true");
            SqlCommand cmd = new SqlCommand("select labID from Computers group by labID", con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                labListGlobal.addLab((string)reader["labID"]);
            }
            con.Close();

        }
        protected void Application_Start(object sender, EventArgs e)
        {  
            Thread th = new Thread(new ThreadStart(serverd.Run));
            th.Start();
            populateLabs();
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