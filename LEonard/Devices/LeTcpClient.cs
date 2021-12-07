using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeTcpClient :LeDeviceBase, LeDeviceInterface
    {
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];

        public Action<string> receiveCallback { get; set; }

        public LeTcpClient(MainForm form, string prefix="") : base(form, prefix)
        {
            Crawl(String.Format("LeTcpClient(form, {0})", prefix));
        }
        ~LeTcpClient()
        {
            Crawl("~LeTcpClient()");
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

        public int Connect(string IPport)
        {
            string[] s = IPport.Split(':');
            return Connect(s[0], s[1]);
        }
        public int Connect(string IP, string port)
        {
            myIp = IP;
            myPort = port;

            Crawl("Connect(" + myIp.ToString() + ", " + myPort.ToString() + ")");
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(myIp);
                Crawl("Connect Ping: " + PR.Status.ToString());
            }
            catch
            {
                CrawlError("Ping failed");
                return 1;
            }

            IPAddress ipAddress = IPAddress.Parse(myIp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(myPort));

            try
            {
                client = new TcpClient();
                client.Connect(remoteEP);
                stream = client.GetStream();
            }
            catch
            {
                CrawlError("Could not connect");
                return 2;
            }

            Crawl("Connected");
            return 0;

        }
        public int Disconnect()
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
            return 0;
        }

        int sendErrorCount = 0;
        bool fSendBusy = false;
        public int Send(string request)
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
                    Connect(myIp, myPort);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return 1;
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
                    Connect(myIp, myPort);
                    sendErrorCount = 0;
                }
            }
            fSendBusy = false;
            return 0;
        }

        public string Receive()
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
                    return response;
                }
            }
            return "";
        }

    }
}
