using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSocketTester
{
    internal class AsynchronousSocketListener
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        string logPrefix;

        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public long IPAddressToLong(IPAddress address)
        {
            byte[] byteIP = address.GetAddressBytes();

            long ip = (long)byteIP[3] << 24;
            ip += (long)byteIP[2] << 16;
            ip += (long)byteIP[1] << 8;
            ip += (long)byteIP[0];
            return ip;
        }

        public AsynchronousSocketListener(string prefix)
        {
            logPrefix = prefix;
        }
        public int StartListening(string IPport)
        {
            string[] s = IPport.Split(':');
            return StartListening(s[0], s[1]);
        }
        public int StartListening(string myIp, string myPort)
        {
            log.Info("{0} Connect({1}, {2})", logPrefix, myIp, myPort);

            IPAddress ipAddress = IPAddress.Parse(myIp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddressToLong(ipAddress), Int32.Parse(myPort));

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    log.Info("{0} Waiting for a connection...", logPrefix);
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    //allDone.WaitOne();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex, "{0} StartListening error:", logPrefix, ex.ToString());
                return 3;
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            SocketState state = new SocketState();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            SocketState state = (SocketState)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));
                log.Info("==> Listener Read {0} bytes from socket. Data : {1}", "L??", content.Length, content);

                // Check for end-of-file tag. If it is not there, read
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("\n") > -1)
                {
                    // All the data has been read from the
                    // client. Display it on the console.  
                    log.Info("==> Listener Message Complete: {0}", content);
                    handler.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    // Echo the data back to the client.  
                    //Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, SocketState.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                log.Info("{0} Sent {1} bytes to client.", "L??", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception ex)
            {
                log.Error(ex, "Sendcallback error: {0}",ex.ToString());
            }
        }
    }
}
