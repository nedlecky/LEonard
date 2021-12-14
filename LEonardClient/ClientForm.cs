using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;
using NLog;


namespace LEonardClient
{
    public partial class ClientForm : Form
    {
        static ManualResetEvent allDone = new ManualResetEvent(false);
        TcpClient client;
        NetworkStream stream;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];

        private static NLog.Logger log;

        //string softwareVersion = "unknown";

        public ClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            Left = 0;
            Top = 50;

            log = NLog.LogManager.GetCurrentClassLogger();


            LoadPersistent();

            log.Info(string.Format("Starting {0} in [{1}]", filename, directory));
            log.Info("READY");

            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;

            GetStatusTmr.Interval = 1000;
            GetStatusTmr.Enabled = true;

            InitTmr.Interval = 400;
            InitTmr.Enabled = true;
        }

        void LoadPersistent()
        {
            log.Trace("LoadPersistent()");
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonardClient");
            ClientIpTxt.Text = (string)AppNameKey.GetValue("ClientIpTxt.Text", "127.0.0.1");
            ClientPortTxt.Text = (string)AppNameKey.GetValue("ClientPortTxt.Text", "1000");
        }
        void SavePersistent()
        {
            log.Trace("LoadPersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonardClient");
            AppNameKey.SetValue("ClientIpTxt.Text", ClientIpTxt.Text);
            AppNameKey.SetValue("ClientPortTxt.Text", ClientPortTxt.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Disconnect();
            NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
        }

        private long IPAddressToLong(IPAddress address)
        {
            byte[] byteIP = address.GetAddressBytes();

            long ip = (long)byteIP[3] << 24;
            ip += (long)byteIP[2] << 16;
            ip += (long)byteIP[1] << 8;
            ip += (long)byteIP[0];
            return ip;
        }

        bool Connect(string IP, string port)
        {
            log.Trace("Connect({0}, {1}", IP, port);
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(IP);
                log.Trace("Ping returns {0}", PR.Status);
            }
            catch
            {
                log.Error("Ping failed");
                return false;
            }

            IPAddress ipAddress = IPAddress.Parse(IP);
            IPEndPoint remoteEP = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(port));

            try
            {
                client = new TcpClient();
                client.Connect(remoteEP);
                stream = client.GetStream();
            }
            catch
            {
                log.Error("Could not connect");
                return false;
            }

            log.Info("Connected");
            ConnectBtn.Text = "Disconnect";
            return true;

        }
        void Disconnect()
        {
            log.Trace("Disconnect()");

            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
            }
            ConnectBtn.Text = "Connect";
        }

        int sendErrorCount = 0;
        bool fSendBusy = false;
        void Send(string request)
        {
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;
            if (stream == null)
            {
                log.Error("Not connected... stream==null");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    log.Error("Trying to bounce socket 1");
                    Disconnect();
                    Connect(ClientIpTxt.Text, ClientPortTxt.Text);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return;
            }

            log.Info("==> {0}", request);
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(request + "\n"), 0, request.Length + 1);
            }
            catch
            {
                log.Error("Send(...) failed");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    log.Error("Trying to bounce socket 2");
                    Disconnect();
                    Connect(ClientIpTxt.Text, ClientPortTxt.Text);
                    sendErrorCount = 0;
                }
            }
            fSendBusy = false;
        }

        public void Receive()
        {
            if (stream != null)
            {
                int length = 0;
                while (stream.DataAvailable && length < inputBufferLen) inputBuffer[length++] = (byte)stream.ReadByte();

                if (length > 0)
                {
                    string message = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    log.Info("<== {0}", message);

                    // Server can close this client with "exit()"
                    if (message == "exit()")
                        ExitBtn_Click(null, null);
                }
            }
        }

        static Queue<string> crawlMessages = new Queue<string>();

        static NLog.LogLevel INFO = NLog.LogLevel.Info;
        static NLog.LogLevel ERROR = NLog.LogLevel.Error;


        Random rand = new Random();
        private void InitTmr_Tick(object sender, EventArgs e)
        {
            ConnectBtn_Click(null, null);
            InitTmr.Enabled = false;
        }
        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            Receive();
        }
        private void GetStatusTmr_Tick(object sender, EventArgs e)
        {
            if (AutoGetStatusChk.Checked)
                GetStatusBtn_Click(null, null);

            GetStatusTmr.Interval = rand.Next(800, 1200);
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectBtn.Text == "Connect")
                Connect(ClientIpTxt.Text, ClientPortTxt.Text);
            else
                Disconnect();
        }

        int messageIndex = 1;
        private void SendBtn_Click(object sender, EventArgs e)
        {
            string request = MessageTxt.Text + messageIndex++.ToString("00000") + ",params";
            Send(request);
        }

        private void GetStatus()
        {
            //string request = string.Format("command=status#command_index={0}#{print('do status operation');}", ++messageIndex);
            string request = string.Format("command=status#command_index={0}#{{print('do status operation {0}');send(0,'Status OK');}}", ++messageIndex);
            Send(request);
        }

        private void GetStatusBtn_Click(object sender, EventArgs e)
        {
            GetStatus();
            //fShowNextGetStatus = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SavePersistent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stress1Btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
                GetStatus();
        }
        private void StressLogBtn_Click(object sender, EventArgs e)
        {
            AllLogRTB.Enabled = false;
            CommLogRTB.Enabled = false;
            ErrorLogRTB.Enabled = false;

            for (int i = 0; i < 100; i++)
            {
                log.Info("Info {0}", i);
                log.Info("==> {0}", i);
                log.Info("<== {0}", i);
                log.Error("Error {0}", i);
            }

            AllLogRTB.Enabled = true;
            CommLogRTB.Enabled = true;
            ErrorLogRTB.Enabled = true;
        }

        private void AbortBtn_Click(object sender, EventArgs e)
        {
            string request = "abort," + messageIndex++.ToString("00000") + ",params";
            Send(request);
        }

        private void Java1Btn_Click(object sender, EventArgs e)
        {
            Send("{" +
                "crawl('COMM what does it do?');" +
                "if (typeof a == 'undefined') a = 5;" +
                "else a = a + 1;" +
                "b=8; c=a*b;" +
                "crawl('COMM ' + c);" +
                "for(name in this)" +
                    "crawl('COMM ' + name + ' ' + typeof name + ' ' + this[name]);}"
                );
        }

        private void SendJsBtn_Click(object sender, EventArgs e)
        {
            Send("{" + JavaScriptTxt.Text + "}");
        }

    }
}
