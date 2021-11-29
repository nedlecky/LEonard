using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LEonard
{
    public partial class MainForm : Form
    {
        TcpServer commandServer;
        TcpServer robotServer;

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
                                    "LEonard Confirmation",
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

            // This will launch the TCP command server
            CommandServerChk.Checked = true;
            RobotServerChk.Checked = true;
        }

        private void StopProcessing()
        {
            Crawl("StopProcessing()...");

            CommandServerChk.Checked = false;

            if (testThread != null)
            {
                TestThreadAbort = true;

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
            string companyName = Application.CompanyName;
            string appName = Application.ProductName;
            string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string executable = Application.ExecutablePath;
            string filename = Path.GetFileName(executable);
            string directory = Path.GetDirectoryName(executable);
            string caption = companyName + " " + appName + " " + productVersion;
#if DEBUG
            caption += " RUNNING IN DEBUG MODE";
#endif
            this.Text = caption;
            Crawl(string.Format("Starting {0} in [{1}]", filename, directory));
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

        private void RobotClearBtn_Click(object sender, EventArgs e)
        {
            RobotCrawlRTB.Clear();
        }

        private void VisionClearBtn_Click(object sender, EventArgs e)
        {
            VisionCrawlRTB.Clear();
        }

        private void ErrorClearBtn_Click(object sender, EventArgs e)
        {
            ErrorCrawlRTB.Clear();
        }

        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            // First time this fires, tell all the threads to stop
            if (testThread != null)
                StopProcessing();
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
            // TODO how to wait here for lonmg enough? Wait for some response or timeout
            DM1DataLbl.Text = dms[0].ReadIndex + " " + dms[0].Value;
        }

        private void TriggerDM2Btn_Click(object sender, EventArgs e)
        {
            dms[1].Trigger();
            // TODO how to wait here for lonmg enough? Wait for some response or timeout
            DM2DataLbl.Text = dms[1].ReadIndex + " " + dms[1].Value;
        }

        private void TriggerDM2Btn_Click_1(object sender, EventArgs e)
        {

        }

        private void TestThreadEnabledChk_CheckedChanged(object sender, EventArgs e)
        {
            // TODO This shold be in the thread class
            TestThreadEnabled = TestThreadEnabledChk.Checked;
        }

        private void CommandServerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (CommandServerChk.Checked)
            {
                commandServer = new TcpServer(this);
                commandServer.StartServer("192.168.0.252", "1000");
            }
            else
            {
                if (commandServer != null)
                {
                    commandServer.StopServer();
                    commandServer = null;
                }
            }
        }
        private void RobotServerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (RobotServerChk.Checked)
            {
                robotServer = new TcpServer(this);
                robotServer.StartServer("192.168.0.252", "30000");
            }
            else
            {
                if (robotServer != null)
                {
                    robotServer.StopServer();
                    robotServer = null;
                }
            }
        }

        // Launch command tester to assist in debugging
        Process proc;
        private void StartTestClientBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "";
#if DEBUG
            start.FileName = "C:\\Users\\nedlecky\\source\\repos\\LEonard\\InterfaceTester\\bin\\Debug\\LEonardInterfaceTester.exe";
#else
            start.FileName = "C:\\Users\\nedlecky\\source\\repos\\LEonard\\InterfaceTester\\bin\\Release\\LEonardInterfaceTester.exe";
#endif
            Crawl("Starting " + start.FileName);
            try
            {
                proc = Process.Start(start);
            }
            catch
            {
                CrawlError("Could not start " + start.FileName);
            }

        }

        private void RobotSendBtn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send(RobotCommandTxt.Text);
        }

        private void RobotCommandTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
