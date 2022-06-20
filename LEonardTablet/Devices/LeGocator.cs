// File: LeGocator.cs
// Project: LEonardTablet
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Custom Directory Select dialog with large buttons for use with touch screen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonardTablet
{
    public class LeGocator : LeDeviceBase, LeDeviceInterface
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public Action<string, string> receiveCallback { get; set; } = null;

        LeTcpClient tcpClient = null;


        public LeGocator(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeGocator(form, {0}, {1})", logPrefix, onConnectMessage);
            tcpClient = new LeTcpClient(form, prefix, connectMsg);
            tcpClient.receiveCallback = myForm.CommandCallback;

        }

        ~LeGocator()
        {
            log.Debug("{0} ~LeGocator()", logPrefix);
            tcpClient = null;
        }

        public int Connect(string IPport)
        {
            log.Debug($"{logPrefix} Connect({IPport})");
            string[] s = IPport.Split(':');
            return Connect(s[0], s[1]);
        }
        public int Connect(string IP, string port)
        {
            log.Debug($"{logPrefix} Connect({IP},{port})");
            int ret = tcpClient.Connect(IP, port);
            if (ret == 0)
            {
                InquiryResponse("stop");
                InquiryResponse("clearalignment");
                InquiryResponse("loadjob,LM01");
                InquiryResponse("start");
                myForm.WriteVariable("gocator_ready", true, true);
            }
            return ret;
        }
        public bool IsConnected()
        {
            return tcpClient.IsConnected();
        }

        public int Disconnect()
        {
            InquiryResponse("stop");
            myForm.WriteVariable("gocator_ready", false, true);
            return tcpClient.Disconnect();
        }

        public int Send(string message)
        {
            return tcpClient.Send(message);
        }
        public string Receive()
        {
            return tcpClient.Receive();
        }

        public void PrepareToRun()
        {
            if (tcpClient != null)
                if (tcpClient.IsConnected())
                {
                    tcpClient.InquiryResponse("start");
                    myForm.WriteVariable("gocator_ready", true, true);
                }
        }

        private string InquiryResponse(string inquiry)
        {
            string response = "ERROR";
            response = tcpClient?.InquiryResponse(inquiry, 500);
            log.Info($"{logPrefix}: {inquiry} GETS {response}");
            return response;
        }

        public void Trigger()
        {
            Send("trigger");
            myForm.WriteVariable("gocator_ready", false, true);
        }
    }
}
