using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeTcpServer : LeDeviceBase, LeDeviceInterface
    {
        TcpListener server;
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        public Action<string, string> receiveCallback { get;  set; }

        public bool DryRun { get; set; } = false;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];
        public int nGetStatusRequests = 0;
        public int nGetStatusResponses = 0;
        public int nBadCommLenErrors = 0;

        public LeTcpServer(MainForm form, string prefix="") : base(form, prefix)
        {
            Crawl(string.Format("LeTcpServer(form, {0})", prefix));
        }

        ~LeTcpServer()
        {
            Crawl(string.Format("~LeTcpServer()"));
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

            Crawl("Connect(" + IP + ", " + port + ")");
            if (server != null) Disconnect();

            IPAddress ipAddress = IPAddress.Parse(IP);
            IPEndPoint remoteEP = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(port));
            Crawl("EP: " + remoteEP.ToString());
            try
            {
                server = new TcpListener(remoteEP);
                server.Start();
                server.BeginAcceptTcpClient(ClientConnected, server);
            }
            catch
            {
                CrawlError("Couldn't start server");
                return 1;
            }
            Crawl("Server: Waiting for client...");
            return 0;
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

        public int Disconnect()
        {
            Crawl("Disconnect()");
            CloseConnection();
            if (server != null)
            {
                server.Stop();
                server = null;
            }
            return 0;
        }

        void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                if (server != null)
                {
                    try
                    {
                        client = server.EndAcceptTcpClient(result);
                        stream = client.GetStream();
                        Crawl("Client connected");
                    }
                    catch
                    {
                        ;// myForm.CrawlError(crawlPrefix + "Client connection error");
                    }
                }
            }
            catch
            {
            }
        }

        public bool IsConnected()
        {
            try
            {
                return !(server.Server.Poll(1, SelectMode.SelectRead) && (server.Server.Available == 0));
            }
            catch (SocketException) { return false; }
        }

        void CloseConnection()
        {
            Crawl("CloseConnection()");

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

        public string Receive()
        {
            if (stream != null)
            {
                if (!IsConnected())
                {
                    CrawlError("Lost connection");
                    Disconnect();
                    Connect(myIp, myPort);
                    return "";
                }

                int length = 0;
                while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                /*
                // TODO: Need to figure out resync on \r\n!
                if (length > 0)
                {
                    // Lazy bytes? since we can't resync.......
                    Thread.Sleep(50);
                    while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                }
                */

                if (length > 0)
                {
                    //string input = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    string input = Encoding.UTF8.GetString(inputBuffer, 0, length);
                    string[] inputLines = input.Split('\n');
                    foreach (string line in inputLines)
                    {
                        string cleanLine = line.Trim('\r');
                        if (cleanLine.Length > 0)
                        {
                            Crawl("SR<== " + cleanLine);

                            if (receiveCallback != null)
                                receiveCallback(cleanLine, crawlPrefix);
                        }
                    }
                    return input;
                }
            }
            return "";
        }

        bool fSendBusy = false;
        public int Send(string response)
        {
            if (stream == null) return 1;
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;
            // Show responses other than GetStatus
            Crawl("==> " + response.ToString());
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(response + "\r\n"), 0, response.Length + 2);
                //stream.Write(Encoding.ASCII.GetBytes(response), 0, response.Length);
            }
            catch
            {
                CrawlError("TcpServer.Send() could not write to socket");
            }
            fSendBusy = false;
            return 0;
        }
    }

}
