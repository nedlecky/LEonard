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
        DatamanSerial[] myDms;

        public BarcodeReaderThread(MainForm form, DatamanSerial[] dms) : base(form)
        {
            myForm.CrawlBarcode("BarcodeReaderThread.BarcodeReaderThread(...)");
            myDms = dms;
            WorkerFunction = BarcodeWorker;
        }
        ~BarcodeReaderThread()
        {
            myForm.CrawlBarcode("BarcodeReaderThread.~BarcodeReaderThread()");
        }

        void BarcodeWorker()
        {
            myDms[0].Send("+");
            myDms[1].Send("+");
        }
    }
}
