// File: LeTcpClientAsync.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Async TCP Client Device (WIP)

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
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    internal class LeTcpClientAsync : LeDeviceBase, LeDeviceInterface
    {
        static Socket client;
        string myIp;
        string myPort;
        //private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; }
        private bool fConnected = false;


        public LeTcpClientAsync(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeTcpClientAsync(form, \"{prefix}\", \"{connectExec}\")");
        }
        ~LeTcpClientAsync()
        {
            log.Debug($"{logPrefix} ~LeTcpClientAsync()");
        }

        public int Connect(string IPport)
        {
            string[] s = IPport.Split(':');
            return Connect(s[0], s[1]);
        }
        public int Connect(string IP, string port)
        {
            fConnected = false;
            myIp = IP;
            myPort = port;

            // Connect to a remote device.  
            log.Info("{0} Connect({1}, {2})", logPrefix, myIp, myPort);
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


            try
            {
                IPAddress ipAddress = IPAddress.Parse(myIp);
                IPEndPoint remoteEP = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(myPort));


                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

            }
            catch (Exception ex)
            {
                log.Error(ex, ex.ToString());
                return 3;
            }

            fConnected = true;

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                    return 1;

            return 0;
        }
        public bool IsConnected()
        {
            return fConnected;
        }
        public int Disconnect()
        {
            log.Info("{0} Disconnect()", logPrefix);

            // Release the socket.  
            if (client != null)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client = null;
            }
            fConnected = false;
            return 0;
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                log.Info("{0} Socket connected to {1}", logPrefix, client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();

                Receive();
            }
            catch (Exception ex)
            {
                log.Info(ex, ex.ToString());
            }
        }

        public string Receive(bool fProcessCallbackOnly=false)
        {
            // If only supposed to process callbacks and there is no callback, ignore
            if (fProcessCallbackOnly && receiveCallback == null) return "";

            if (client == null) return "";

            log.Info("{0} Receive()", logPrefix);

            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);

                return "";
            }
            catch (Exception ex)
            {
                log.Error(ex, "{0} {1}", logPrefix, ex.ToString());
                return "";
            }
        }

        public string InquiryResponse(string message, int timeoutMs = 50)
        {
            log.Error($"{logPrefix} LeTcpClientAsync::InquiryResponse({message}, {timeoutMs}) NOT IMPLEMENTED");

            return null;
        }


        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                log.Info("{0} Received {1} bytes", logPrefix, bytesRead.ToString());
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    log.Info("{0} <== {1} Line", logPrefix, state.sb);

                    if (receiveCallback != null)
                        receiveCallback(state.sb.ToString(), logPrefix, this);

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        log.Info("{0} <== {1} Line", logPrefix, state.sb);

                        if (receiveCallback != null)
                            receiveCallback(state.sb.ToString(), logPrefix, this);
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();

                    Receive();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        public int Send(String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(TxPrefix + data + TxSuffix);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);

            return 0;
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                log.Info("{0} Sent {1} bytes to server.", logPrefix, bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception ex)
            {
                log.Error(ex, "{0} {1}", logPrefix, ex.ToString());
            }
        }
    }
}
