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
    public class LeTcpServer : LeDeviceInterface
    {
        static MainForm myForm;
        TcpListener server;
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        string crawlPrefix;
        public Action<string> receiveCallback { get;  set; }

        public bool DryRun { get; set; } = false;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];
        public int nGetStatusRequests = 0;
        public int nGetStatusResponses = 0;
        public int nBadCommLenErrors = 0;

        public LeTcpServer(MainForm form, string prefix)
        {
            myForm = form;
            crawlPrefix = prefix;
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

            myForm.Crawl(crawlPrefix + "Connect(" + IP + ", " + port + ")");
            if (server != null) Disconnect();

            IPAddress ipAddress = IPAddress.Parse(IP);
            IPEndPoint remoteEP = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(port));
            try
            {
                server = new TcpListener(remoteEP);
                server.Start();
                server.BeginAcceptTcpClient(ClientConnected, server);
            }
            catch
            {
                myForm.CrawlError(crawlPrefix + "Couldn't start server");
                return 1;
            }
            myForm.Crawl(crawlPrefix + "Server: Waiting for client...");
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
            myForm.Crawl(crawlPrefix + "Disconnect()");
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
                        myForm.Crawl(crawlPrefix + "Client connected");
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
            myForm.Crawl(crawlPrefix + "CloseConnection()");

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
                    myForm.CrawlError(crawlPrefix + "Lost connection");
                    Disconnect();
                    Connect(myIp, myPort);
                    return "";
                }

                int length = 0;
                while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                if (length > 0)
                {
                    // Lazy bytes? since we can't resync.......
                    Thread.Sleep(50);
                    while (stream.DataAvailable) inputBuffer[length++] = (byte)stream.ReadByte();
                }

                if (length > 0)
                {
                    string input = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    myForm.Crawl(crawlPrefix + "<== " + input);

                    if (receiveCallback != null)
                        receiveCallback(input);

                    return input;

                    //string response = "response to: " + command;
                    //Send(response);
                }
            }
            return "";
        }

        bool fSendBusy = false;
        public int Send(string response)
        {
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;
            // Show responses other than GetStatus
            myForm.Crawl(crawlPrefix + "==> " + response.ToString());
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(response + "\r\n"), 0, response.Length + 2);
            }
            catch
            {
                myForm.CrawlError(crawlPrefix + "TcpServer.Send() could not write to socket");
            }
            fSendBusy = false;
            return 0;
        }
    }

}
