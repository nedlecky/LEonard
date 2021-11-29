using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {

        public bool TestThreadAbort { get; set; } = false;
        public bool TestThreadRunning { get; set; } = false;
        public bool TestThreadEnabled { get; set; } = true;
        

        int loopCount = 0;
        private void TestThread()
        {
            TestThreadAbort = false;
            TestThreadRunning = true;
            Crawl("TestThread starting...");

            while (!TestThreadAbort)
            {
                if (!TestThreadEnabled)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    loopCount++;
                    dms[0].Trigger();
                    Thread.Sleep(100);
                    dms[1].Trigger();
                    Thread.Sleep(100);

                    watch.Stop();
                    CrawlVision("TestThread execution time: " + watch.ElapsedMilliseconds.ToString() + "mS abort=" + TestThreadAbort);
                }
            }

            Crawl("TestThread ends.");
            TestThreadRunning = false;
        }
    }
}
