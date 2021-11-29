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
    internal class TcpServer
    {
        static MainForm myForm;
        TcpListener server;
        TcpClient client;
        NetworkStream stream;
        string myIp;
        string myPort;
        int messageIdIndex = 1; // increments for every messageId
        public bool DryRun { get; set; } = false;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];
        public int nGetStatusRequests = 0;
        public int nGetStatusResponses = 0;
        public int nBadCommLenErrors = 0;

        public TcpServer(MainForm form)
        {
            myForm = form;
        }

        public bool StartServer(string IP, string port)
        {
            myIp = IP;
            myPort = port;

            myForm.Crawl("StartServer(" + IP + ", " + port + ")");
            if (server != null) StopServer();

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
                myForm.CrawlError("Couldn't start server");
                return false;
            }
            myForm.Crawl("Server: Waiting for client...");
            return true;
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

        public void StopServer()
        {
            myForm.Crawl("StopServer()");
            CloseConnection();
            if (server != null)
            {
                server.Stop();
                server = null;
            }
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
                        myForm.Crawl("Client connected");
                    }
                    catch
                    {
                        ;// myForm.CrawlError("Client connection error");
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
            myForm.Crawl("CloseConnection()");

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

        public void ReceiveCommand()
        {
            if (stream != null)
            {
                if (!IsConnected())
                {
                    myForm.CrawlError("Have lost connection");
                    StopServer();
                    StartServer(myIp, myPort);
                    return;
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
                    string command = Encoding.UTF8.GetString(inputBuffer, 0, length).Trim('\r', '\n');
                    myForm.Crawl("<== " + command);

                    // TODO Execute the command!


                    string response = "response to: " + command;
                    Send(response);
                }
            }
        }

        bool fSendBusy = false;
        void Send(string response)
        {
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;
            // Show responses other than GetStatus
            myForm.Crawl("==> " + response.ToString());
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(response + "\r\n"), 0, response.Length + 2);
            }
            catch
            {
                myForm.CrawlError("TcpServer.Send() could not write to socket");
            }
            fSendBusy = false;
        }
    }

}
