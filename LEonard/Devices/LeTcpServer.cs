// File: LeTcpServer.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: TCP Server Device

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
        TcpListener server = null;
        TcpClient client = null;
        NetworkStream stream = null;
        string myIp;
        string myPort;

        public bool DryRun { get; set; } = false;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];
        public int nGetStatusRequests = 0;
        public int nGetStatusResponses = 0;
        public int nBadCommLenErrors = 0;
        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; }
        public bool IsClientConnected { get; set; } = false;


        public LeTcpServer(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeTcpServer(form, {prefix}, {connectExec})");
        }

        ~LeTcpServer()
        {
            log.Debug($"{logPrefix} ~LeTcpServer()");
        }

        public override int Connect(string IP, string port)
        {
            myIp = IP;
            myPort = port;

            log.Info($"{logPrefix} LeTcpServer::Connect({IP}, {port})");
            if (server != null) Disconnect();
            IsClientConnected = false;

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
                log.Error("{0} Couldn't start server", logPrefix);
                return 1;
            }
            log.Info($"{logPrefix} Server: Waiting for client...");
            return base.Connect(IP,port);
        }
        public virtual bool IsConnected()
        {
            if (server == null) return false;
            try
            {
                return !(server.Server.Poll(1, SelectMode.SelectRead) && (server.Server.Available == 0));
            }
            catch (SocketException) { return false; }
        }

        public override int Disconnect()
        {
            log.Info("{0} Disconnect()", logPrefix);
            CloseConnection();
            if (server != null)
            {
                server.Stop();
                server = null;
            }
            return base.Disconnect();
        }

        void ClientConnected(IAsyncResult result)
        {
            try
            {
                //TcpListener server = (TcpListener)result.AsyncState;
                if (server != null)
                {
                    try
                    {
                        client = server.EndAcceptTcpClient(result);
                        stream = client.GetStream();
                        log.Info("{0} Client connected", logPrefix);
                        IsClientConnected = true;

                        if (execLEonardMessageOnConnect.Length > 0)
                            if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                                log.Error($"{logPrefix} Client connected but bad exec: {execLEonardMessageOnConnect}");
                    }
                    catch
                    {
                        log.Error($"{logPrefix} Client connection error");
                    }
                }
            }
            catch
            {
            }
        }
        void CloseConnection()
        {
            log.Debug("{0} CloseConnection()", logPrefix);

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
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        bool fSendBusy = false;
        public int Send(string message)
        {
            if (stream == null) return 1;
            while (fSendBusy)
                Thread.Sleep(10);
            fSendBusy = true;

            log.Debug($"{logPrefix}==> {message}");
            try
            {
                string msg = TxPrefix + message + TxSuffix;
                stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
            }
            catch
            {
                log.Error($"{logPrefix} Send({message}) could not write to socket");
            }
            fSendBusy = false;
            return 0;
        }

        int addingAt = 0;
        private Queue<string> inputQueue = new Queue<string>();
        public string Receive(bool fProcessCallBackOnly = false)
        {
            // If only supposed to process callbacks and there is no callback, ignore
            if (fProcessCallBackOnly && receiveCallback == null) return "";

            if (stream == null) return "";
            if (!IsConnected())
            {
                log.Error($"Lost {logPrefix} connection");
                Disconnect();
                Connect(myIp, myPort);
                return "";
            }

            // Read any available characters and RxTerminator[0] delimit them as strings into the queue
            // If a string is started but has no RxTerminator[0], it will be completed and queued in a later call!
            int totalChars = 0;
            while (stream.DataAvailable)
            {
                int c = stream.ReadByte();
                totalChars++;
                if (c == RxTerminator[0])
                {
                    inputQueue.Enqueue(Encoding.UTF8.GetString(inputBuffer, 0, addingAt));
                    addingAt = 0;
                }
                else
                    inputBuffer[addingAt++] = (byte)c;
            }
            // This can be used to see how frequently incomplete lines are received... about once an hour in normal testing
            if (addingAt > 0)
                log.Debug("UR<== incomplete line received (will get rest later) totalChars={0} addingAt={1} [{2}]", totalChars, addingAt, Encoding.UTF8.GetString(inputBuffer, 0, addingAt - 1));

            // Now execute any completed lines that have been received
            int lineNo = 1;
            int nLines = inputQueue.Count;
            while (inputQueue.Count > 0)
            {
                string line = inputQueue.Dequeue();
                if (line.Length > 0)
                {
                    if (nLines > 1)
                        log.Debug($"{logPrefix}<== {line} Line {lineNo} of {nLines}");
                    else
                        log.Debug($"{logPrefix}<== {line}");
                    if (receiveCallback == null)
                        return line;
                    else
                        receiveCallback?.Invoke(logPrefix, line, this);
                }
                lineNo++;
            }
            return "";
        }

        public string Ask(string message, int timeoutMs = 50)
        {
            log.Error($"{logPrefix} LeTcpServer::InquiryResponse({message}, {timeoutMs}) NOT IMPLEMENTED");

            return null;
        }

    }
}
