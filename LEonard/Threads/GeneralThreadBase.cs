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
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        public GeneralThreadBase(MainForm form, string prefix="")
        {
            myForm = form;
            crawlPrefix = prefix;
            log.Info("GeneralThreadBase(form, {0})",prefix);
            WorkerFunction = DefaultWorker;
        }
        ~GeneralThreadBase()
        {
            log.Info("~GeneralThreadBase()");
            if(IsRunning())
            {
                End();
            }
        }

        public void Start()
        {
            log.Info("Start()");
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
            log.Info("End()");
            fAbort = true;
        }

        public void Enable(bool f)
        {
            log.Info("Enable({0})", f);
            fEnabled = f;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void DefaultWorker()
        {
            log.Info("DefaultWorker()");
        }

        void Runtime()
        {
            fAbort = false;
            isRunning = true;
            log.Info("Runtime() starting...");

            while (!fAbort)
            {
                if (!fEnabled)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    WorkerFunction();
                    Thread.Sleep(5000);
                }
            }

            log.Info("Runtime() ends");
            isRunning = false;
        }
    }
}
