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
            log.Debug("{0} LeTcpClient(form, {0}, {1})", logPrefix, onConnectMessage);
        }
        ~LeTcpClient()
        {
            log.Debug("{0} ~LeTcpClient()", logPrefix);
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

            log.Info("{0} Connect({1}, {2})", logPrefix, myIp, myPort);
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(myIp);
                log.Debug("{0} Connect Ping returns {1}", logPrefix, PR.Status);
            }
            catch
            {
                log.Error("{0} Ping {1} failed", logPrefix, myIp);
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
                log.Error("{0} Could not connect", logPrefix);
                return 2;
            }

            log.Debug("Connected");
            if(onConnectMessage.Length>0) Send(onConnectMessage);
            return 0;
        }
        public int Disconnect()
        {
            log.Info("{0} Disconnect()", logPrefix);

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
                log.Error("{0} Not connected... stream==null", logPrefix);
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    log.Error("{0} Trying to bounce socket 1", logPrefix);
                    Disconnect();
                    Connect(myIp, myPort);
                    sendErrorCount = 0;
                }
                fSendBusy = false;
                return 1;
            }

            log.Info("{0} ==> {1}", logPrefix, request);
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(request + "\n"), 0, request.Length + 1);
            }
            catch
            {
                log.Error("{0} Send(...) failed", logPrefix);
                ++sendErrorCount;
                if (sendErrorCount > 5)
                {
                    log.Error("{0} Trying to bounce socket 2", logPrefix);
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
                            log.Info("{0} <== {0} Line {1}", logPrefix, cleanLine, lineNo);

                            if (receiveCallback != null)
                                receiveCallback(cleanLine, logPrefix);
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
