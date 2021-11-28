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

        public bool AbortTestThread { get; set; } = false;
        public bool TestThreadRunning { get; set; } = false;
        public bool Enabled { get; set; } = true;
        

        int loopCount = 0;
        private void TestThread()
        {
            AbortTestThread = false;
            TestThreadRunning = true;
            Crawl("TestThread starting...");

            while (!AbortTestThread)
            {
                if (!Enabled)
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
                    CrawlVision("TestThread execution time: " + watch.ElapsedMilliseconds.ToString() + "mS abort=" + AbortTestThread);
                }
            }

            Crawl("TestThread ends.");
            TestThreadRunning = false;
        }
    }
}
