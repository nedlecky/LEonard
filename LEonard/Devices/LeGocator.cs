// File: LeGocator.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Specialized child of LeTcpClient for Gocator interface

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeGocator : LeTcpClient
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public LeGocator(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeGocator(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);

        }
        ~LeGocator()
        {
            log.Debug("{0} ~LeGocator()", logPrefix);
        }

        public void Callback(string prefix, string message, LeDeviceInterface dev)
        {
            // Gocator sends back OK which we just ignore
            if (message.StartsWith("OK"))
            {
                log.Info($"LeGocator::Callback({prefix},{message})");
                return;
            }

            myForm.GeneralCallback(prefix, message, this);
        }

        public enum Status
        {
            OFF,
            ERROR,
            OK
        }

        public override int Connect(string IPport)
        {
            log.Debug($"{logPrefix} LeGocator::Connect({IPport})");
            string[] s = IPport.Split(':');
            return Connect(s[0], s[1]);
        }
        public override int Connect(string IP, string port)
        {
            log.Debug($"{logPrefix} LeGocator::Connect({IP},{port})");
            int ret = base.Connect(IP, port);
            if (ret != 0)
                myForm.GocatorAnnounce(LeGocator.Status.ERROR);
            else
            {
                if (execLEonardMessageOnConnect.Length > 0)
                    if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                        Send(execLEonardMessageOnConnect);

                // TODO all the below init should be in onConnectExec
                InquiryResponse("stop");
                InquiryResponse("clearalignment");
                InquiryResponse("loadjob,LM01");
                InquiryResponse("start");
                myForm.WriteVariable("gocator_ready", true, true);
                log.Info("Gocator connection ready");
                myForm.GocatorAnnounce(LeGocator.Status.OK);
            }
            return ret;
        }

        public override int Disconnect()
        {
            log.Debug("{logPrefix} LeGocator::Disconnect()");
            InquiryResponse("stop");
            myForm.WriteVariable("gocator_ready", false, true);
            myForm.GocatorAnnounce(LeGocator.Status.OFF);
            return base.Disconnect();
        }

        public void PrepareToRun()
        {
            if (IsConnected())
            {
                InquiryResponse("start");
                myForm.WriteVariable("gocator_ready", true, true);
            }
        }

        private string InquiryResponse(string inquiry)
        {
            string response = "ERROR";
            response = InquiryResponse(inquiry, 1000);
            log.Info($"{logPrefix}: {inquiry} GETS {response}");
            return response;
        }

        public void Trigger(int preDelay_ms = 0, int postDelay_ms = 0)
        {
            Thread.Sleep(preDelay_ms);
            Send("trigger");
            Thread.Sleep(postDelay_ms);
            myForm.WriteVariable("gocator_ready", false, true);
        }
    }
}
