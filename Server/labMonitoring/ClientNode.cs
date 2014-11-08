using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using System.Net;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Linq;

namespace labMonitoring
{
    
    public class ClientNode
    {
        public PhysicalAddress mac;
        public TcpClient client_soc;
        public String name;
        public DateTime last_time;
        public Mutex _lock;
        public short node_mode;     //if 0-> means will sit idle
                                    // if 1-> will request img
                                    // if 2-> will request stats

        public static byte[] hexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public ClientNode(String name,TcpClient client, String mac)
        {
            this.name = name;
            client_soc = client;
            node_mode = 0;
            _lock = new Mutex();
            this.mac = new PhysicalAddress(hexToByteArray(mac));
            last_time = DateTime.Now;
        }

        public void updateTime()
        {
            last_time = DateTime.Now;
        }

        public string getMACAddress()
        {
            return mac.ToString();
        }
    }
}