using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LE_MCP
{
    public partial class MainForm : Form
    {

        static public bool fAbortTestThread = false;
        static public bool fTestThreadRunning = false;

        static int loopCount = 0;
        private void TestThread()
        {
            fAbortTestThread = false;
            fTestThreadRunning = true;
            Crawl("TestThread starting...");

            while (!fAbortTestThread)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                loopCount++;
                dms[0].Trigger();
                Thread.Sleep(100);
                dms[1].Trigger();
                Thread.Sleep(100);

                watch.Stop();
                CrawlVision("TestThread execution time: " + watch.ElapsedMilliseconds.ToString() + "mS abort=" + fAbortTestThread);
            }

            Crawl("TestThread ends.");
        }
    }
}
