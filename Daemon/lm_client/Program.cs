using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSService
{
    class Program
    {
        static void Main(string[] args)
        {
            //don't remove the follwoing comment
           // ScreenShot.CaptureAndSave(0, 0, 1000, 1000, @"C:\Users\Student\Desktop\Capture.png");
            Sender.connect();
            Sender.listen();
        }
    }
}
