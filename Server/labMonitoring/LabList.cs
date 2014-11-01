using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace labMonitoring
{
    public class LabList
    {
        List<ClientNodeList> lab_list;
        ReaderWriterLock mutex;

        public LabList()
        {
            lab_list = new List<ClientNodeList>();
            mutex = new ReaderWriterLock();
        }

        public void addLab(String name) {
            mutex.AcquireWriterLock(60000);
            ClientNodeList tmp = new ClientNodeList();
            lab_list.Add(tmp);
            mutex.ReleaseLock();
        }

        public ClientNodeList getLabComputers(String name){
            mutex.AcquireReaderLock(81640);
            foreach (ClientNodeList list in lab_list)
            {
                if (list.lab_name == name)
                {
                    return list;
                }
            }
            mutex.ReleaseLock();
            return null;
        }
    }
}