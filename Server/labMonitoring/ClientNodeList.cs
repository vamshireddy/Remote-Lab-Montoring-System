using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Threading;

namespace labMonitoring
{
    public class ClientNodeList
    {
        public String lab_name;
        public List<ClientNode> list;
        private ReaderWriterLock mutex;

        public  ClientNodeList(string name)
        {
            lab_name = name.Trim();
            list = new List<ClientNode>();
            mutex = new ReaderWriterLock();
        }
        /*
         * This is called by the ASP.NET page 
         */
        public ClientNode getClientNode(PhysicalAddress p)
        {
            mutex.AcquireReaderLock(60000);
            
            foreach (ClientNode n in list)
            {
               if (n.mac == p)
               {
                   return n;
               }
            }

            mutex.ReleaseReaderLock();
            return null;
        }

        public void addClient(ClientNode n)
        {
            mutex.AcquireWriterLock(60000);

            ClientNode found_node = null;

            foreach (ClientNode node in list)
            {
                // Check if node is already there
                if (node.mac.Equals(n.mac))
                {
                    found_node = node;
                }
            }

            // If node is already present, then overwrite the values
            if (found_node != null)
            {
                found_node.name = n.name;
                found_node.mac = n.mac;
                found_node.last_time = DateTime.Now;
                found_node.node_mode = 0;
            }
            else
            {
                list.Add(n);
            }

            mutex.ReleaseWriterLock();
        }

        public void removeClient(ClientNode n)
        {
            mutex.AcquireWriterLock(60000);

            list.Remove(n);

            mutex.ReleaseWriterLock();
        }

    }
}