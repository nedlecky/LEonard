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
    public class LeTcpClient
    {
        MainForm myForm;
        string crawlPrefix;
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];

        public LeTcpClient(MainForm form, string prefix)
        {
            myForm = form;
            crawlPrefix = prefix;
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

        public bool Connect(string IP, string port)
        {
            myIp = IP;
            myPort = port;

            myForm.Crawl(crawlPrefix + "Connect(" + myIp.ToString() + ", " + myPort.ToString() + ")");
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(myIp);
                myForm.Crawl(crawlPrefix + "Connect Ping: " + PR.Status.ToString());
            }
            catch
            {
                myForm.CrawlError(crawlPrefix + "Ping failed");
                return false;
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
                myForm.CrawlError(crawlPrefix + "Could not connect");
                return false;
            }

            myForm.Crawl(crawlPrefix + "Connected");
            return true;

        }
        public void Disconnect()
        {
            myForm.Crawl(crawlPrefix + "Disconnect()");

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
        public void Send(string request)
        {
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;
            if (stream == null)
            {
                myForm.CrawlError(crawlPrefix + "Not connected... stream==null");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    myForm.CrawlError(crawlPrefix + "Trying to bounce socket to LEonard");
                    Disconnect();
                    Connect(myIp, myPort);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return;
            }

            myForm.Crawl(crawlPrefix + "==> " + request.ToString());
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(request + "\r\n"), 0, request.Length + 2);
            }
            catch
            {
                myForm.CrawlError(crawlPrefix + "Send() failed");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    myForm.CrawlError(crawlPrefix + "Trying to bounce socket to LEonard");
                    Disconnect();
                    Connect(myIp, myPort);
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
                    myForm.Crawl(crawlPrefix + "<== " + response);

                    // TODO Analyze the response!
                }
            }
        }

    }
}
