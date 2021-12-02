using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEonard
{
    public class GeneralThreadBase : GeneralThreadInterface
    {
        protected MainForm myForm;
        protected Thread thread = null;
        protected Action WorkerFunction;
        protected bool isRunning = false;
        protected bool fAbort = false;
        protected bool fEnabled = true;

        public GeneralThreadBase(MainForm form)
        {
            myForm = form;
            myForm.CrawlBarcode("GeneralThreadBase.GeneralThreadBase(...)");
            WorkerFunction = DefaultWorker;
        }
        ~GeneralThreadBase()
        {
            myForm.CrawlBarcode("GeneralThreadBase.~GeneralThreadBase()");
            if(IsRunning())
            {
                End();
            }
        }

        public void Start()
        {
            myForm.CrawlBarcode("GeneralThreadBase.Start()");
            if (IsRunning())
            {
                End();
                while(IsRunning())
                {
                    Thread.Sleep(100);
                }
            }

            thread = new Thread(new ThreadStart(Runtime));
            thread.Start();
        }

        public void End()
        {
            myForm.CrawlBarcode("GeneralThreadBase.End()");
            fAbort = true;
        }

        public void Enable(bool f)
        {
            myForm.CrawlBarcode(String.Format("GeneralThreadBase.Enable({0})", f));
            fEnabled = f;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void DefaultWorker()
        {
            myForm.CrawlBarcode("GeneralThreadBase.DefaultWorker()");
        }

        void Runtime()
        {
            fAbort = false;
            isRunning = true;
            myForm.CrawlBarcode("GeneralThreadBase.Runtime() starting...");

            while (!fAbort)
            {
                if (!fEnabled)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    WorkerFunction();
                    Thread.Sleep(1000);
                }
            }

            myForm.CrawlBarcode("GeneralThreadBase.Runtime() ends.");
            isRunning = false;
        }

    }
}
