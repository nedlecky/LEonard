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

        public void Crawl(string message)
        {
            string datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
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
        }

        // Schedule an error message
        public void CrawlError(string message)
        {
            Crawl("ERROR: " + message);
        }
        public void CrawlCommand(string message)
        {
            Crawl("COMMAND: " + message);
        }

        // Schedule a Robot message
        public void CrawlRobot(string message)
        {
            Crawl("ROBOT: " + message);
        }

        // Schedule a vision message
        public void CrawlVision(string message)
        {
            Crawl("VISION: " + message);
        }

        // Schedule a vision message
        public void CrawlBarcode(string message)
        {
            Crawl("BARCODE: " + message);
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

                // Add message to ErrorCrawlRTB and make color red if it contains "ERROR"
                if (message.Contains("ERROR"))
                {
                    LimitRTBLength(ErrorCrawlRTB, maxRtbLength);
                    AllCrawlRTB.SelectionColor = Color.Red;
                    ErrorCrawlRTB.AppendText(message + "\n");
                }

                // Add message to AllCrawlRTB
                AllCrawlRTB.AppendText(message + "\n");
                AllCrawlRTB.ScrollToCaret();
                AllCrawlRTB.SelectionColor = System.Drawing.Color.Black;
                LimitRTBLength(AllCrawlRTB, maxRtbLength);
                
                // Append to logfile
                try
                {
                    File.AppendAllText(LogfileTxt.Text, message + "\r\n");
                }
                catch
                {

                }

                // Add message to CommandCrawlRTB well if it contains "ROBOT:"
                if (message.Contains("COMMAND:"))
                {
                    LimitRTBLength(CommandCrawlRTB, maxRtbLength);
                    CommandCrawlRTB.AppendText(message + "\n");
                    CommandCrawlRTB.ScrollToCaret();
                }

                // Add message to RobotCrawlRTB well if it contains "ROBOT:"
                if (message.Contains("ROBOT:"))
                {
                    LimitRTBLength(RobotCrawlRTB, maxRtbLength);
                    RobotCrawlRTB.AppendText(message + "\n");
                    RobotCrawlRTB.ScrollToCaret();
                }

                // Add message to VisionCrawlRTB well if it contains "VISION:"
                if (message.Contains("VISION:"))
                {
                    LimitRTBLength(VisionCrawlRTB, maxRtbLength);
                    VisionCrawlRTB.AppendText(message + "\n");
                    VisionCrawlRTB.ScrollToCaret();
                }

                // Add message to BarcodeCrawlRTB well if it contains "BARCODE:"
                if (message.Contains("BARCODE:"))
                {
                    LimitRTBLength(BarcodeCrawlRTB, maxRtbLength);
                    BarcodeCrawlRTB.AppendText(message + "\n");
                    BarcodeCrawlRTB.ScrollToCaret();
                }
            }
        }
        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            FlushCrawl();

            // TODO is this a poor place to check for commands from above??
            if (commandServer != null) commandServer.Receive();
            if (robotServer != null) robotServer.Receive();
            if (visionServer != null) visionServer.Receive();
        }

    }
}
