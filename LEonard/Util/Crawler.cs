using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
        Queue<string> crawlMessages = new Queue<string>();
        const int maxRtbLength = 1000000;

        // Schedule a standard message
        private static AutoResetEvent m_AutoReset = new AutoResetEvent(true);

        bool fEnqueueing = false;
        int crawlDelayCount = 0;
        public void Crawl(string message)
        {
            while(fEnqueueing)
            {
                crawlDelayCount++;
                Thread.Sleep(1);
            }
            fEnqueueing = true;
            string datetime;
            if(UtcTimeChk.Checked)
                datetime= DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            else
                datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            string line = datetime + " " + message;

            // Add "Realtime:" into message to get immediate append/flush/close to file without scroll... intended for high-speed problematic bugs
            // This has rarely caused file open collisions, so should only be enabled when trying to debug highspeed issues
            //if (message.Contains("Realtime:"))
            //{
            //    m_AutoReset.WaitOne();
            //    FileStream fs = File.Open(LogfileTxt.Text, FileMode.Append);
            //    byte[] bytes = Encoding.ASCII.GetBytes(line + "\n");
            //    fs.Write(bytes, 0, bytes.Length);
            //    fs.Flush();
            //    fs.Close();
            //    m_AutoReset.Set();
            //}
            //else
            crawlMessages.Enqueue(line);
            fEnqueueing = false;
        }

        // Schedule an error message
        public void CrawlError(string message)
        {
            Crawl("ERROR " + message);
        }

        // The scrolls can't grow (successfully) without bound. Cut them to maxLength chars
        private void LimitRTBLength(RichTextBox rtb, int maxLength)
        {
            int currentLength = rtb.TextLength;

            if (currentLength > maxLength)
            {
                rtb.Select(0, currentLength - maxLength);
                rtb.SelectedText = "";
            }
        }

        public void FlushCrawl()
        {
            while (crawlMessages.Count() > 0)
            {
                string message = crawlMessages.Dequeue();

                if(message==null)
                {
                    CrawlError("FlushCrawl found a null message");
                    continue;
                }

                // Append to logfile
                try
                {
                    File.AppendAllText(Path.Combine(LEonardRoot,"LEonard.log"), message + "\r\n");
                }
                catch
                {

                }

                // Add message to ErrorCrawlRTB and make color red if it contains "ERROR"
                Color messageColor = Color.Black;
                if (message.Contains("ERROR"))
                {
                    messageColor = Color.Red;
                    LimitRTBLength(ErrorCrawlRTB, maxRtbLength);
                    ErrorCrawlRTB.SelectionColor = messageColor;
                    ErrorCrawlRTB.AppendText(message + "\n");
                    ErrorCrawlRTB.ScrollToCaret();
                }

                // Add message to AllCrawlRTB
                LimitRTBLength(AllCrawlRTB, maxRtbLength);
                AllCrawlRTB.SelectionColor = messageColor;
                AllCrawlRTB.AppendText(message + "\n");
                AllCrawlRTB.ScrollToCaret();
                
                // Add message to CommandCrawlRTB well if it contains "COMM"
                if (message.Contains("COMM"))
                {
                    LimitRTBLength(CommandCrawlRTB, maxRtbLength);
                    CommandCrawlRTB.SelectionColor = messageColor;
                    CommandCrawlRTB.AppendText(message + "\n");
                    CommandCrawlRTB.ScrollToCaret();
                }

                // Add message to RobotCrawlRTB well if it contains "ROB"
                if (message.Contains("ROB"))
                {
                    LimitRTBLength(RobotCrawlRTB, maxRtbLength);
                    RobotCrawlRTB.SelectionColor = messageColor;
                    RobotCrawlRTB.AppendText(message + "\n");
                    RobotCrawlRTB.ScrollToCaret();
                }

                // Add message to VisionCrawlRTB well if it contains "VIS"
                if (message.Contains("VIS"))
                {
                    LimitRTBLength(VisionCrawlRTB, maxRtbLength);
                    VisionCrawlRTB.SelectionColor = messageColor;
                    VisionCrawlRTB.AppendText(message + "\n");
                    VisionCrawlRTB.ScrollToCaret();
                }

                // Add message to BarcodeCrawlRTB well if it contains "BAR"
                if (message.Contains("BAR"))
                {
                    LimitRTBLength(BarcodeCrawlRTB, maxRtbLength);
                    BarcodeCrawlRTB.SelectionColor = messageColor;
                    BarcodeCrawlRTB.AppendText(message + "\n");
                    BarcodeCrawlRTB.ScrollToCaret();
                }

                // Add message to JavaScriptCrawlRTB well if it contains "JAVA"
                if (message.Contains("JAVA"))
                {
                    LimitRTBLength(JavaScriptCrawlRTB, maxRtbLength);
                    JavaScriptCrawlRTB.SelectionColor = messageColor;
                    JavaScriptCrawlRTB.AppendText(message + "\n");
                    JavaScriptCrawlRTB.ScrollToCaret();
                }
            }
        }

    }
}
