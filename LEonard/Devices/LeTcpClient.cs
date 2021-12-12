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
    public class LeTcpClient : LeDeviceBase, LeDeviceInterface
    {
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public Action<string, string> receiveCallback { get; set; }

        public LeTcpClient(MainForm form, string prefix = "", string connectMsg="") : base(form, prefix, connectMsg)
        {
            log.Debug("LeTcpClient(form, {0}, {1})", prefix, connectMsg);
        }
        ~LeTcpClient()
        {
            log.Debug("~LeTcpClient()");
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

            log.Info("Connect({0}. {1})", myIp, myPort);
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(myIp);
                log.Debug("Connect Ping returns {0}", PR.Status);
            }
            catch
            {
                log.Error("Ping {0} failed", myIp);
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
                log.Error("Could not connect");
                return 2;
            }

            log.Debug("Connected");
            if(onConnectMessage.Length>0) Send(onConnectMessage);
            return 0;
        }
        public int Disconnect()
        {
            log.Debug("Disconnect()");

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
                log.Error("Not connected... stream==null");
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    log.Error("Trying to bounce socket 1");
                    Disconnect();
                    Connect(myIp, myPort);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return 1;
            }

            log.Info("Send({0})", request);
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
                    string input = Encoding.UTF8.GetString(inputBuffer, 0, length);
                    string[] inputLines = input.Split('\n');
                    int lineNo = 1;
                    foreach (string line in inputLines)
                    {
                        string cleanLine = line.Trim('\r');
                        if (cleanLine.Length > 0)
                        {
                            log.Info("Receive({0}) Line {1}", cleanLine, lineNo);

                            if (receiveCallback != null)
                                receiveCallback(cleanLine, crawlPrefix);
                        }
                        lineNo++;
                    }
                }

                // TODO: I think all these returns are ignored
                return "";
            }
            return "";
        }
    }
}
