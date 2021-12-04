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
        DataTable devices;
        LeTcpServer commandServer;
        LeTcpServer robotServer;
        LeTcpServer visionServer;
        LeTcpClient visionClient;

        BarcodeReaderThread bcrt;

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

            StartThreads();

            // This will launch the TCP command servers
            CommandServerChk.Checked = true;
            RobotServerChk.Checked = true;
            VisionServerChk.Checked = true;
            VisionClientChk.Checked = true;

            Crawl("System ready.");
        }

        private void StartThreads()
        {
            Crawl("StartThreads()...");

            bcrt = new BarcodeReaderThread(this, dms);
            bcrt.Enable(BarcodeReaderThreadChk.Checked);
            bcrt.Start();
        }
        private void EndThreads()
        {
            Crawl("EndThreads()...");

            if (bcrt != null)
            {
                bcrt.End();
                bcrt = null;
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

            // Close the TCP connections
            // TODO this is a hoakey way to do that
            CommandServerChk.Checked = false;
            RobotServerChk.Checked = false;
            VisionServerChk.Checked = false;
            VisionClientChk.Checked = false;

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
            //TimeLbl.Text = now;
            toolStripStatusLabel1.Text = now;
        }

        private void CrawlerClearBtn_Click(object sender, EventArgs e)
        {
            AllCrawlRTB.Clear();
        }

        private void ErrorClearBtn_Click(object sender, EventArgs e)
        {
            ErrorCrawlRTB.Clear();
        }

        private void CommandClearBtn_Click(object sender, EventArgs e)
        {
            CommandCrawlRTB.Clear();
        }
        private void RobotClearBtn_Click(object sender, EventArgs e)
        {
            RobotCrawlRTB.Clear();
        }

        private void VisionClearBtn_Click(object sender, EventArgs e)
        {
            VisionCrawlRTB.Clear();
        }
        private void BarcodeClearBtn_Click(object sender, EventArgs e)
        {
            BarcodeCrawlRTB.Clear();
        }

        int fireCounter = 0;
        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            // First time this fires, tell all the threads to stop
            if (++fireCounter == 1)
                EndThreads();
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

        void CommandCallback(string s)
        {
            CrawlCommand("Execute: " + s);

            string response = "response to " + s;
            commandServer.Send(response);

        }
        private void CommandServerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (CommandServerChk.Checked)
            {
                commandServer = new LeTcpServer(this, "COMMAND: ");
                commandServer.StartServer("192.168.0.252", "1000");
                commandServer.receiveCallback = CommandCallback;
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


        // Launch command tester to assist in debugging
        Process proc;
        private void StartTestClientBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "";
#if DEBUG
            start.FileName = "C:\\Users\\nedlecky\\Documents\\GitHub\\LEonard\\InterfaceTester\\bin\\Debug\\LEonardInterfaceTester.exe";
#else
            start.FileName = "C:\\Users\\nedlecky\\Documents\\GitHub\\LEonard\\InterfaceTester\\bin\\Release\\LEonardInterfaceTester.exe";
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

        private void RobotServerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (RobotServerChk.Checked)
            {
                robotServer = new LeTcpServer(this, "ROBOT: ");
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
        private void RobotSendBtn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send(RobotCommandTxt.Text);
        }

        private void Robot1Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send("(1,0,0,0,0)");
        }

        private void Robot2Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send("(2,0,0,0,0)");
        }

        private void Robot3Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send("(3,0,0,0,0)");
        }

        private void Robot4Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send("(4,0,0,0,0)");
        }

        private void Robot50Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
                robotServer.Send("(50,0,0,0,0)");
        }

        private void Robot98Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
            {
                robotServer.Send("(98,0,0,0,0)");

                // All shoud be wrapped in nice RobotServer class
                Thread.Sleep(100);
                robotServer.StopServer();
                //robotServer = new TcpServer(this, "ROBOT: ");
                robotServer.StartServer("192.168.0.252", "30000");
            }
        }

        private void Robot99Btn_Click(object sender, EventArgs e)
        {
            if (robotServer != null)
            {
                robotServer.Send("(99,0,0,0,0)");

                // All shoud be wrapped in nice RobotServer class
                Thread.Sleep(100);
                robotServer.StopServer();
                //robotServer = new TcpServer(this, "ROBOT: ");
                robotServer.StartServer("192.168.0.252", "30000");
            }
        }
        private void VisionServerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (VisionServerChk.Checked)
            {
                visionServer = new LeTcpServer(this, "VISION: ");
                visionServer.StartServer("192.168.0.252", "20000");
            }
            else
            {
                if (visionServer != null)
                {
                    visionServer.StopServer();
                    visionServer = null;
                }
            }
        }
        private void VisionSendBtn_Click(object sender, EventArgs e)
        {
            if (visionServer != null)
                visionServer.Send(VisionCommandTxt.Text);
        }

        private void VisionClientChk_CheckedChanged(object sender, EventArgs e)
        {
            if (VisionClientChk.Checked)
            {
                visionClient = new LeTcpClient(this, "VISION: ");
                visionClient.Connect("192.168.0.252", "21000");
            }
            else
            {
                if (visionServer != null)
                {
                    visionClient.Disconnect();
                    visionClient = null;
                }
            }
        }
        private void VisionClientSendBtn_Click(object sender, EventArgs e)
        {
            if (visionClient != null)
                visionClient.Send(VisionClientCommandTxt.Text);
        }

        private void BcrtCreateBtn_Click(object sender, EventArgs e)
        {
            if (bcrt != null)
                bcrt.End();
            GC.Collect();
            bcrt = new BarcodeReaderThread(this, dms);
        }

        private void BcrtDestroyBtn_Click(object sender, EventArgs e)
        {
            bcrt.End();
            bcrt = null;
            GC.Collect();
        }

        private void BcrtStartBtn_Click(object sender, EventArgs e)
        {
            bcrt.Enable(BarcodeReaderThreadChk.Checked);
            bcrt.Start();
        }

        private void BcrtEndBtn_Click(object sender, EventArgs e)
        {
            bcrt.End();
        }
        private void BarcodeReaderThreadChk_CheckedChanged(object sender, EventArgs e)
        {
            bcrt.Enable(BarcodeReaderThreadChk.Checked);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefaultDevicesBtn_Click(object sender, EventArgs e)
        {
            devices = new DataTable("Devices");

            DataColumn nameColumn = devices.Columns.Add("Name", typeof(System.String));
            devices.Columns.Add("Enabled", typeof(System.Boolean));
            devices.Columns.Add("Running", typeof(System.Boolean));
            devices.Columns.Add("DeviceType", typeof(System.String));
            devices.Columns.Add("Address", typeof(System.String));

            devices.PrimaryKey = new DataColumn[] { nameColumn };


            devices.Rows.Add(new object[] { "UR-5e", true, false, "Socket", "192.168.0.2:30000" });
            devices.Rows.Add(new object[] { "Sherlock", true, false, "TCPserver", "192.168.0.2:20000" });
            devices.Rows.Add(new object[] { "HALCON", true, false, "TCPclient", "192.168.0.2:21000" });
            devices.Rows.Add(new object[] { "Command", true, false, "TCPserver", "192.168.0.2:1000" });
            devices.Rows.Add(new object[] { "Dataman 1", true, false, "Serial", "COM3" });
            devices.Rows.Add(new object[] { "Dataman 2", true, false, "Serial", "COM4" });

            DeviceGrid.DataSource = devices;
        }

        private void ReloadDevicesBtn_Click(object sender, EventArgs e)
        {
            devices.Clear();
            devices.ReadXmlSchema("devices_schema.xml");
            devices.ReadXml("devices.xml");
        }
        private void SaveDevicesBtn_Click(object sender, EventArgs e)
        {
            devices.AcceptChanges();
            devices.WriteXmlSchema("devices_schema.xml");
            devices.WriteXml("devices.xml");
        }

    }
}
