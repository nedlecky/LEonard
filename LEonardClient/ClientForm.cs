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

            Crawl(string.Format("Starting {0} in [{1}]", filename, directory));
            Crawl("READY");

            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;

            InitTmr.Interval = 400;
            InitTmr.Enabled = true;
        }

        void LoadPersistent()
        {
            Crawl("LoadPersistent()");
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonardClient");
            ClientIpTxt.Text = (string)AppNameKey.GetValue("ClientIpTxt.Text", "127.0.0.1");
            ClientPortTxt.Text = (string)AppNameKey.GetValue("ClientPortTxt.Text", "1000");
        }
        void SavePersistent()
        {
            Crawl("LoadPersistent()");

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
            Crawl("Connect(" + IP.ToString() + ", " + port.ToString() + ")");
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(IP);
                Crawl("Connect Ping: " + PR.Status.ToString());
            }
            catch
            {
                CrawlError("Ping failed");
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
                CrawlError("Could not connect");
                return false;
            }

            Crawl("Connected");
            return true;

        }
        void Disconnect()
        {
            Crawl("Disconnect()");

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
                CrawlError("Not connected... stream==null");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    CrawlError("Trying to bounce socket to LEonard");
                    Disconnect();
                    Connect(ClientIpTxt.Text, ClientPortTxt.Text);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return;
            }

            Crawl("==> " + request.ToString());
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(request + "\r\n"), 0, request.Length + 2);
            }
            catch
            {
                CrawlError("Send() failed");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    CrawlError("Trying to bounce socket to LEonard");
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
                /*
                if (length > 0)
                {
                    // Lazy bytes? since we can't resync.......
                    Thread.Sleep(50);
                    while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                }
                */

                if (length > 0)
                {
                    string message = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    Crawl("<== " + message);

                    // Server can close this client with "exit()"
                    if (message == "exit()")
                        ExitBtn_Click(null, null);
                }
            }
        }

        static Queue<string> crawlMessages = new Queue<string>();

        static NLog.LogLevel INFO = NLog.LogLevel.Info;
        static NLog.LogLevel ERROR = NLog.LogLevel.Error;

        static void Log(string message)
        {
            log.Info(message);
        }
        static void Log(NLog.LogLevel level, string message)
        {
            log.Log(level, message);
        }
        static void Crawl(string message)
        {
            Log(message);
            string datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            crawlMessages.Enqueue(datetime + " " + message);
        }

        static void CrawlError(string message)
        {
            Log(ERROR, message);
        }
        private void LimitRTBLength(RichTextBox rtb, int maxLength)
        {
            int currentLength = rtb.TextLength;

            if (currentLength > maxLength)
            {
                rtb.Select(0, currentLength - maxLength);
                rtb.SelectedText = "";
            }
        }

        void FlushCrawl()
        {
            while (crawlMessages.Count() > 0)
            {
                string message = crawlMessages.Dequeue();

                if (message.Contains("ERROR:"))
                {
                    CrawlerRTB.SelectionColor = Color.Red;
                }
                LimitRTBLength(CrawlerRTB, 1000000);
                CrawlerRTB.AppendText(message + "\n");
                CrawlerRTB.ScrollToCaret();
                CrawlerRTB.SelectionColor = System.Drawing.Color.Black;

                /*
                try
                {
                    File.AppendAllText(LogfileTxt.Text, message + "\r\n");
                }
                catch
                {

                }
                */

                // Add message to CommRTB as well if it begins with <== or ==>
                if (message.Contains("<==") || message.Contains("==>"))
                {
                    LimitRTBLength(CommRTB, 1000000);
                    CommRTB.AppendText(message + "\n");
                    CommRTB.ScrollToCaret();
                }
            }
        }

        const int autoGetStatusIntervalMs = 1000;
        int nSinceLastAutoGetStatus = 0;

        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            Receive();

            if (AutoGetStatusChk.Checked && !pauseAutoGetStatus)
            {
                if (nSinceLastAutoGetStatus++ > autoGetStatusIntervalMs / MessageTmr.Interval) // GetStatus automatically every autoGetStatusIntervalMs Ms
                {
                    GetStatus();
                    nSinceLastAutoGetStatus = 0;
                }
            }
            FlushCrawl();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectBtn.Text == "Connect")
            {
                if (Connect(ClientIpTxt.Text, ClientPortTxt.Text))
                    ConnectBtn.Text = "Disconnect";
            }
            else
            {
                ConnectBtn.Text = "Connect";
                Disconnect();
            }
        }

        int messageIndex = 1;
        private void SendBtn_Click(object sender, EventArgs e)
        {
            string request = MessageTxt.Text + messageIndex++.ToString("00000") + ",params";
            Send(request);
        }

        
        private void GetStatus()
        {
            string request = "command=status#command_index=" + messageIndex++ + "#{print('do status operation');}";
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

        private void InitTmr_Tick(object sender, EventArgs e)
        {
            ConnectBtn_Click(null, null);

            InitTmr.Enabled = false;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stress1Btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
                GetStatusBtn_Click(null, null);
        }

        bool pauseAutoGetStatus = false;
        
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
