// File: LeDeviceBase.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Base class for all devices- children must inherit this and follow LeDeviceInterface

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeDeviceBase
    {
        protected MainForm myForm;
        protected string logPrefix;
        protected string execLEonardMessageOnConnect;

        public string TxPrefix { get; set; } = "";
        public string TxSuffix { get; set; } = "";
        public string RxTerminator { get; set; } = "";
        public string RxSeparator { get; set; } = "";
        public Process runtimeProcess { get; set; } = null;
        public Process setupProcess { get; set; } = null;

        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public LeDeviceBase(MainForm form, string prefix = "", string connectExec = "")
        {
            myForm = form;
            logPrefix = prefix;
            execLEonardMessageOnConnect = connectExec;
            log.Info($"LeDeviceBase(form, \"{logPrefix}\", \"{execLEonardMessageOnConnect}\")");
        }

        ~LeDeviceBase()
        {
            EndSetupProcess();
            EndRuntimeProcess();
        }

        public int StartRuntimeProcess(ProcessStartInfo start)
        {
            if (runtimeProcess != null)
            {
                log.Error("Runtime process already running: {0}", start);
                return 1;
            }

            log.Info("Starting {0}", start.FileName);
            try
            {
                runtimeProcess = Process.Start(start);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not start {0}", start.FileName);
            }

            return 0;
        }
        public int EndRuntimeProcess()
        {
            if (runtimeProcess == null)
            {
                return 1;
            }

            try
            {
                runtimeProcess.CloseMainWindow();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Couldn't CloseMainWindow()");
            }
            runtimeProcess = null;
            return 0;
        }
        public int StartSetupProcess(ProcessStartInfo start)
        {
            if (setupProcess != null)
            {
                log.Error("Setup process already running: {0}", start);
                return 1;
            }

            log.Info("Starting {0}", start.FileName);
            try
            {
                setupProcess = Process.Start(start);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Couldn't start {0}", start.FileName);
            }

            return 0;
        }
        public int EndSetupProcess()
        {
            if (setupProcess == null)
            {
                return 1;
            }

            try
            {
                setupProcess.CloseMainWindow();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Couldn't CloseMainWindow()");
            }
            setupProcess = null;
            return 0;
        }

        public long IPAddressToLong(IPAddress address)
        {
            byte[] byteIP = address.GetAddressBytes();

            long ip = (long)byteIP[3] << 24;
            ip += (long)byteIP[2] << 16;
            ip += (long)byteIP[1] << 8;
            ip += (long)byteIP[0];
            return ip;
        }

    }
}
