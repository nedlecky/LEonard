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
    public class LeGocator : LeTcpClient, LeDeviceInterface
    {
        public static int nInstances = 0;
        public static int nConnected = 0;
        public static LeGocator uiFocusInstance = null;

        public enum Status
        {
            OFF,
            ERROR,
            OK
        }
        public Status status = Status.OFF;

        public LeGocator(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeGocator(form, \"{prefix}\", \"{connectExec}\") nInstances will be {nInstances + 1}");

            uiFocusInstance = this;
            nInstances++;
            status = Status.OFF;
            myForm.GocatorAnnounce();
        }
        ~LeGocator()
        {
            log.Debug($"{logPrefix} ~LeGocator() nInstances={nInstances}");

            nInstances--;
            if (nInstances == 0 || uiFocusInstance == this) uiFocusInstance = null;
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

        public override int Connect(string IP, string port)
        {
            log.Debug($"{logPrefix} LeGocator::Connect({IP}, {port})");
            int ret = base.Connect(IP, port);
            if (ret != 0)
            {
                status = Status.ERROR;
                myForm.GocatorAnnounce();
            }
            else
            {
                if (execLEonardMessageOnConnect.Length > 0)
                    if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                        return 1;

                // TODO all the below init should be in onConnectExec
                InquiryResponse("stop");
                InquiryResponse("clearalignment");
                InquiryResponse("loadjob,LM01");
                InquiryResponse("start");
                myForm.WriteVariable("gocator_ready", true, true);
                log.Info("Gocator connection ready");

                // Bump up the connected count and set UI focus to this
                nConnected++;
                status = Status.OK;
                myForm.GocatorAnnounce();
            }
            return ret;
        }

        public override int Disconnect()
        {
            log.Debug("{logPrefix} LeGocator::Disconnect()");
            InquiryResponse("stop");
            myForm.WriteVariable("gocator_ready", false, true);
            status = Status.OFF;
            myForm.GocatorAnnounce();

            // Drop the connected count and remove this one from focus if it is not connected
            nConnected--;
            if (uiFocusInstance == this) uiFocusInstance = null;

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
