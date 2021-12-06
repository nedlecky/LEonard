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
        LeDeviceInterface[] myDevices = { null, null };

        public BarcodeReaderThread(MainForm form, LeDeviceInterface device1, LeDeviceInterface device2) : base(form)
        {
            myForm.CrawlBarcode("BarcodeReaderThread.BarcodeReaderThread(...)");
            myDevices[0] = device1;
            myDevices[1] = device2;
            WorkerFunction = BarcodeWorker;
        }
        ~BarcodeReaderThread()
        {
            myForm.CrawlBarcode("BarcodeReaderThread.~BarcodeReaderThread()");
        }

        void BarcodeWorker()
        {
            myDevices[0].Send("+");
            myDevices[1].Send("+");
        }
    }
}
