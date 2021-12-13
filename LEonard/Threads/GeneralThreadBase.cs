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
        protected string logPrefix;
        protected Thread thread = null;
        protected Action WorkerFunction;
        protected bool isRunning = false;
        protected bool fAbort = false;
        protected bool fEnabled = true;
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        public GeneralThreadBase(MainForm form, string prefix="")
        {
            myForm = form;
            logPrefix = prefix;
            log.Info("{0} GeneralThreadBase(form, {0})", logPrefix);
            WorkerFunction = DefaultWorker;
        }
        ~GeneralThreadBase()
        {
            log.Info("{0} ~GeneralThreadBase()", logPrefix);
            if(IsRunning())
            {
                End();
            }
        }

        public void Start()
        {
            log.Info("{0} Start()", logPrefix);
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
            log.Info("{0} End()", logPrefix);
            fAbort = true;
        }

        public void Enable(bool f)
        {
            log.Info("{0} Enable({1})", logPrefix, f);
            fEnabled = f;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void DefaultWorker()
        {
            log.Info("{0} DefaultWorker()", logPrefix);
        }

        Random rand = new Random();
        void Runtime()
        {
            fAbort = false;
            isRunning = true;
            log.Info("{0} Runtime() starting...", logPrefix);

            while (!fAbort)
            {
                if (!fEnabled)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    WorkerFunction();
                    Thread.Sleep(rand.Next(2500,2800));
                }
            }

            log.Info("{0} Runtime() ends", logPrefix);
            isRunning = false;
        }
    }
}
