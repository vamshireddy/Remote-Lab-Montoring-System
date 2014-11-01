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

namespace labMonitoring

{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["labs"] = new LabList();    
            Thread th = new Thread(new ThreadStart(serverd.Run));
            Console.Write("HELOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO----------------\n\n\n\n\n\n\n");
            th.Start();
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