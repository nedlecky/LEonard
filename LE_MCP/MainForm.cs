using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LE_MCP
{
    public partial class MainForm : Form
    {
        Thread testThread;

        int nDatamanSerial = 2;
        DatamanSerial[] dms = new DatamanSerial[2];

        public MainForm()
        {
            InitializeComponent();
        }

        bool forceClose = false;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (forceClose) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you want to close the application?",
                                    "LE MCP Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
                e.Cancel = (result == DialogResult.No);
            }

            if (!e.Cancel)
            {
                CloseTmr.Interval = 500;
                CloseTmr.Enabled = true;
                e.Cancel = true; // Let the close out timer shut us down
                Crawl("Shutting down...");
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Connect()
        {
            Crawl("Connect()...");
            HeartbeatTmr.Interval = 1000;
            HeartbeatTmr.Enabled = true;
            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;

            dms[0] = new DatamanSerial(this);
            dms[1] = new DatamanSerial(this);
            dms[0].Open("COM3");
            dms[1].Open("COM4");

            testThread = new Thread(new ThreadStart(TestThread));
            testThread.Start();

            Crawl("System ready.");
        }

        private void StopThreads()
        {
            Crawl("Stopping threads...");
            if (testThread != null)
            {
                fAbortTestThread = true;

                testThread = null;
            }
        }

        private void Disconnect()
        {
            Crawl("Disconnect()...");
            //HeartbeatTmr.Enabled = false;
            for (int i = 0; i < nDatamanSerial; i++)
            {
                dms[i].Close();
                dms[i] = null;
            }
            Crawl("Disconnect() complete");

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string text = "Lecky Engineering MCP 0.1 2021-11-27";
            this.Text = text;
            Crawl(text + " starting...");
            Connect();
        }

        private void HeartbeatTmr_Tick(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("s");
            TimeLbl.Text = now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fixed1Pic.Image = new Bitmap("../../images/Robots-Square-610x610.jpg");
            Crawl("Btn1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fixed2Pic.Image = new Bitmap("../../images/Robots-Square-610x610.jpg");
            Crawl("Btn2");
            CrawlError("Btn2 Error");
            CrawlRobot("Btn2 Robot");
            CrawlVision("Btn2 Vision");
        }

        private void CrawlerClearBtn_Click(object sender, EventArgs e)
        {
            AllCrawlRTB.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RobotCrawlRTB.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VisionCrawlRTB.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ErrorCrawlRTB.Clear();
        }

        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            // First time this fires, tell all the threads to stop
            if (testThread != null)
                StopThreads();
            else
            {
                // Second time it fires, we can disconnect and shut down!
                Disconnect();
                MessageTmr_Tick(null, null);
                CloseTmr.Enabled = false;
                forceClose = true;
                this.Close();
            }
        }

        private void TriggerDM1Btn_Click(object sender, EventArgs e)
        {
            dms[0].Trigger();
        }

        private void TriggerDM2Btn_Click(object sender, EventArgs e)
        {
            dms[1].Trigger();
        }
    }
}
