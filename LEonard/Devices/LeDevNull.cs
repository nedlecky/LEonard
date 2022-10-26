// File: LeDevNull.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Null device for tyesting


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeDevNull : LeDeviceBase, LeDeviceInterface
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        bool fConnected = false;

        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; } = null;

        public LeDevNull(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeDevNull(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);
        }

        ~LeDevNull()
        {
            log.Debug("{0} ~LeDevNull()", logPrefix);
        }
        public int Connect(string portname)
        {
            log.Debug("{0} Connect({1})", logPrefix, portname);

            fConnected = true;

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                    Send(execLEonardMessageOnConnect);

            return 0;
        }
        public bool IsConnected()
        {
            log.Debug("{0} IsConnected()", logPrefix);
            return fConnected;
        }

        public int Disconnect()
        {
            log.Info("{0} Disconnect()", logPrefix);

            
            fConnected = false;
            return 0;
        }

        public int Send(string message)
        {
            log.Debug($"{logPrefix} DevNull::Send({message})");

            return 0;
        }
        public string Receive(bool fProcessCallbackOnly = false)
        {
            log.Debug($"{logPrefix} DevNull::Receive()");
            return "";
        }
        public string InquiryResponse(string message, int timeoutMs = 50)
        {
            log.Debug($"{logPrefix} DevNull::InquiryResponse({message}, {timeoutMs})");

            return null;
        }
    }
}

