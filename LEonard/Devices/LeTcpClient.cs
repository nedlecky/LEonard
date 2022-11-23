// File: LeTcpClient.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: TCP Client Device

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        TcpClient client = null;
        NetworkStream stream = null;
        string myIp;
        string myPort;
        const int inputBufferLen = 128000;
        byte[] inputBuffer = new byte[inputBufferLen];

        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; }
        private bool fConnected = false;

        public LeTcpClient(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeTcpClient(form, \"{prefix}\", \"{connectExec}\")");
        }
        ~LeTcpClient()
        {
            log.Debug($"{logPrefix} ~LeTcpClient()");
            inputBuffer = null;
        }
        public override int Connect(string IP, string port)
        {
            fConnected = false;
            myIp = IP;
            myPort = port;

            log.Info("{0} LeTcpClient::Connect({1}, {2})", logPrefix, myIp, myPort);
            if (client != null) Disconnect();

            try
            {
                Ping ping = new Ping();
                PingReply PR = ping.Send(myIp, 500);
                log.Debug("{0} Connect Ping returns {1}", logPrefix, PR.Status);
                if (PR.Status != IPStatus.Success)
                {
                    log.Error("{0} Could not ping {1}: {2}", logPrefix, myIp, PR.Status);
                    return 2;
                }
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


            fConnected = true;

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                    return 1;

            return base.Connect(IP, port);
        }
        public virtual bool IsConnected()
        {
            return fConnected;
        }

        public override int Disconnect()
        {
            log.Info("{0} LeTcpClient::Disconnect()", logPrefix);

            if (stream != null)
            {
                stream.Flush();
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
            }
            fConnected = false;
            return base.Disconnect(); ;
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

            log.Debug("{0} ==> {1}", logPrefix, request);
            try
            {
                string sendMessage = TxPrefix + request + TxSuffix;
                stream.Write(Encoding.ASCII.GetBytes(sendMessage), 0, sendMessage.Length);
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
        public string Receive(bool fProcessCallBackOnly = false)
        {
            // If only supposed to process callbacks and there is no callback, ignore
            if (fProcessCallBackOnly && receiveCallback == null) return "";

            if (stream == null) return null;
            int length = 0;
            while (stream.DataAvailable && length < inputBufferLen) inputBuffer[length++] = (byte)stream.ReadByte();

            if (length == 0) return null;
            string input = Encoding.UTF8.GetString(inputBuffer, 0, length);
            string[] inputLines = input.Split(RxTerminator[0]);
            int lineNo = 1;
            foreach (string line in inputLines)
            {
                string cleanLine = line.Trim();
                if (cleanLine.Length > 0)
                {
                    log.Debug("{0} <== {1} Line {2}", logPrefix, cleanLine, lineNo);

                    if (receiveCallback != null)
                        receiveCallback(logPrefix, cleanLine, this);
                }
                lineNo++;
            }
            return input.Trim();
        }

        public string Ask(string inquiry, int timeoutMs = 50)
        {
            // Purge any remaining responses
            string response = Receive();
            if (response != null)
            {
                log.Warn("{0} Already had a response waiting: {1}", logPrefix, response.Replace(RxTerminator[0], ' '));
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Send(inquiry);

            // Wait for awhile for the response!
            while ((response = Receive()) == null && timer.ElapsedMilliseconds < timeoutMs) ;

            if (response == null)
            {
                log.Info("{0} IR({1}) waited {2} mS. Retrying...", logPrefix, inquiry, timeoutMs);

                // Let's just wait a bit more?
                while ((response = Receive()) == null && timer.ElapsedMilliseconds < timeoutMs * 2) ;
                timer.Stop();
                if (response != null)
                {
                    log.Info("{0} IR({1}) Retry succeeded = {2}. [{3} mS]", logPrefix, inquiry, response, timer.ElapsedMilliseconds);
                    return response;
                }
                log.Warn("{0} IR({1}) Retry failed. [{2} mS]", logPrefix, inquiry, timer.ElapsedMilliseconds);
                return null;
            }
            timer.Stop();

            log.Trace("{0} {1}={2} [{3} mS]", logPrefix, inquiry, response, timer.ElapsedMilliseconds);
            return response;
        }
    }
}
