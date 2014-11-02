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
            lab_name = name;
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

            list.Add(n);

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