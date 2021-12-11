using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public class BarcodeReaderThread : GeneralThreadBase
    {
        LeDeviceInterface[] myDevices;

        public BarcodeReaderThread(MainForm form, LeDeviceInterface[] devices) : base(form, "BARCODE:")
        {
            Crawl("BarcodeReaderThread.BarcodeReaderThread(...)");
            myDevices = devices;
            WorkerFunction = BarcodeWorker;
        }
        ~BarcodeReaderThread()
        {
            Crawl("BarcodeReaderThread.~BarcodeReaderThread()");
        }

        void BarcodeWorker()
        {
            int index = 0;
            foreach (LeDeviceInterface device in myDevices)
            {
                if (device != null)
                {
                    string command="";
                    switch(index)
                    {
                        case 0:
                            command = "Hi client";
                            break;
                        case 1:
                            command = "(1,0,0,0,0)";
                            break;
                        case 2:
                            command = "Hi Sherlock";
                            break;
                        case 3:
                            command = "Hi HALCON";
                            break;
                        case 4:
                        case 5:
                            command = "+";
                            break;
                    }
                    device.Send(command);
                }
                index++;
            }
        }
    }
}
