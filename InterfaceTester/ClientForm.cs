using Google.Protobuf;
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

namespace LEonardInterfaceTester
{
    public partial class ClientForm : Form
    {
        static ManualResetEvent allDone = new ManualResetEvent(false);
        TcpClient client;
        NetworkStream stream;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];

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
            Crawl(string.Format("Starting {0} in [{1}]", filename, directory));

            Left = 0;
            Top = 50;

            // Pull setup info from registry.... these are overwritten with the Save button on the maintenance screen!
            // Note default values are specified here as well
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");
            InterfaceTesterIpTxt.Text = (string)AppNameKey.GetValue("InterfaceTesterIp", "192.168.0.252");
            InterfaceTesterPortTxt.Text = (string)AppNameKey.GetValue("InterfaceTesterPort", "1000");

            Crawl("READY");

            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;

            InitTmr.Interval = 400;
            InitTmr.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Disconnect();
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
                    Connect(InterfaceTesterIpTxt.Text, InterfaceTesterPortTxt.Text);
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
                    Connect(InterfaceTesterIpTxt.Text, InterfaceTesterPortTxt.Text);
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
                    // Lazy bytes? since we can't resync.......
                    Thread.Sleep(50);
                    while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                }

                if (length > 0)
                {
                    string response = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    Crawl("<== " + response);

                    // TODO Analyze the response!
                }
            }
        }

        static Queue<string> crawlMessages = new Queue<string>();

        static void Crawl(string message)
        {
            string datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            crawlMessages.Enqueue(datetime + " " + message);
        }

        static void CrawlError(string message)
        {
            Crawl("ERROR: " + message);
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

                try
                {
                    File.AppendAllText(LogfileTxt.Text, message + "\r\n");
                }
                catch
                {

                }

                // Add message to CommRTB as well if it begins with <== or ==>
                if (message.Contains("<==") || message.Contains("==>"))
                {
                    LimitRTBLength(CommRTB, 1000000);
                    //CommRTB.AppendText(datetime);
                    CommRTB.AppendText(message + "\n");
                    CommRTB.ScrollToCaret();
                }
            }
        }

        const int autoGetStatusIntervalMs = 1000;
        int nSinceLastAutoGetStatus = 0;
        bool autoGetStatus = true;

        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            Receive();
            if (autoGetStatus && !pauseAutoGetStatus)
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
                if (Connect(InterfaceTesterIpTxt.Text, InterfaceTesterPortTxt.Text))
                    ConnectBtn.Text = "Disconnect";
            }
            else
            {
                ConnectBtn.Text = "Connect";
                Disconnect();
            }
        }

        int messageIndex = 1;
        private void CommandOne_Click(object sender, EventArgs e)
        {
            string request = "command1," + messageIndex++.ToString("00000") + ",params";

            Send(request);
        }

        
        private void GetStatus()
        {
            string request = "status," + messageIndex++.ToString("00000") + ",params";

            Send(request);
        }

        private void GetStatusBtn_Click(object sender, EventArgs e)
        {
            GetStatus();
            //fShowNextGetStatus = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");

            AppNameKey.SetValue("InterfaceTesterIp", InterfaceTesterIpTxt.Text);
            AppNameKey.SetValue("InterfaceTesterPort", InterfaceTesterPortTxt.Text);
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
            //fAbort = true;
            Crawl("Abort");
        }
    }
}
