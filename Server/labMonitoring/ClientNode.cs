using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using System.Net;
using System.Drawing;
using System.Net.Sockets;

namespace labMonitoring
{
    
    public class ClientNode
    {
        public PhysicalAddress mac;
        public Bitmap img;
        public TcpClient client_soc;
        public String name;

        public ClientNode(String name)
        {
            this.name = name;
        }

        public string getMACAddress()
        {
            return mac.ToString();
        }
    }
}