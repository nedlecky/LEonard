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
        protected string crawlPrefix;
        protected Thread thread = null;
        protected Action WorkerFunction;
        protected bool isRunning = false;
        protected bool fAbort = false;
        protected bool fEnabled = true;

        public GeneralThreadBase(MainForm form, string prefix="")
        {
            myForm = form;
            crawlPrefix = prefix;
            Crawl("GeneralThreadBase.GeneralThreadBase(...)");
            WorkerFunction = DefaultWorker;
        }
        ~GeneralThreadBase()
        {
            Crawl("GeneralThreadBase.~GeneralThreadBase()");
            if(IsRunning())
            {
                End();
            }
        }

        public void Crawl(string s)
        {
            myForm.Crawl(crawlPrefix + s);
        }
        public void CrawlError(string s)
        {
            myForm.CrawlError(crawlPrefix + s);
        }

        public void Start()
        {
            Crawl("GeneralThreadBase.Start()");
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
            Crawl("GeneralThreadBase.End()");
            fAbort = true;
        }

        public void Enable(bool f)
        {
            Crawl(String.Format("GeneralThreadBase.Enable({0})", f));
            fEnabled = f;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void DefaultWorker()
        {
            Crawl("GeneralThreadBase.DefaultWorker()");
        }

        void Runtime()
        {
            fAbort = false;
            isRunning = true;
            Crawl("GeneralThreadBase.Runtime() starting...");

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

            Crawl("GeneralThreadBase.Runtime() ends.");
            isRunning = false;
        }

    }
}
