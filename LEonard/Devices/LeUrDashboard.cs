// File: LeUrDashboard.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Custom LeTcpClient interface to Universal Robot Dashboard


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeUrDashboard : LeTcpClient
    {
        //private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static int nInstances = 0;
        public static int nConnected = 0;
        public static LeUrDashboard uiFocusInstance = null;

        public enum Status
        {
            OFF,
            ERROR,
            OK
        }
        public Status status = Status.OFF;

        public string UrProgramFilename { get; set; } = "";

        public LeUrDashboard(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeUrDashboard(form, \"{prefix}\", \"{connectExec}\") nInstances will be {nInstances+1}");

            uiFocusInstance = this;
            nInstances++;
            status = Status.OFF;
            myForm.UrDashboardAnnounce();
        }
        ~LeUrDashboard()
        {
            log.Debug($"{logPrefix} ~LeUrDashboard() nInstances={nInstances}");

            nInstances--;
            if (nInstances == 0 || uiFocusInstance == this) uiFocusInstance = null;
        }

        public override int Connect(string dashIP, string dashPort)
        {
            log.Debug($"{logPrefix} LeUrDashboard::Connect({dashIP}, {dashPort})");
            int ret = base.Connect(dashIP, dashPort);
            if (ret != 0)
            {
                status = Status.OFF;
                myForm.UrDashboardAnnounce();
                myForm.ErrorMessageBox($"Cannot start UR dashboard on {dashIP}:{dashPort}");
                return ret;
            }
            log.Info($"{logPrefix} Dashboard connection ready");
            Thread.Sleep(50);
            string response = Receive();
            if (response != "Connected: Universal Robots Dashboard Server")
            {
                status = Status.ERROR;
                myForm.UrDashboardAnnounce();
                myForm.ErrorMessageBox($"Dashboard connection returned {response}");
            }
            status = Status.OK;
            myForm.UrDashboardAnnounce();

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardStatement(logPrefix, execLEonardMessageOnConnect, this))
                    return 1;

            // TODO all the below could be in this onConnectExec
            string closeSafetyPopupResponse = InquiryResponse("close safety popup", 1000);
            string isInRemoteControlResponse = InquiryResponse("is in remote control", 1000);
            if (isInRemoteControlResponse == null)
            {
                myForm.ErrorMessageBox("Failed to check remote control mode. No response.");
                return 0;
            }
            if (isInRemoteControlResponse != "true")
            {
                myForm.ErrorMessageBox("Robot not in remote control mode!");
                return 0;
            }
            string loadedProgramResponse = InquiryResponse("load " + UrProgramFilename, 1000);
            if (loadedProgramResponse == null)
            {
                myForm.ErrorMessageBox($"Failed to load {UrProgramFilename}. No response.");
                return 0;
            }
            if (loadedProgramResponse.StartsWith("File not found"))
            {
                myForm.ErrorMessageBox($"Failed to load {UrProgramFilename}. Response was \"{loadedProgramResponse}\"");
                return 0;
            }

            string getLoadedProgramResponse = InquiryResponse("get loaded program", 1000);
            if (getLoadedProgramResponse == null)
            {
                myForm.ErrorMessageBox($"Failed to verify loading {UrProgramFilename}. No response");
                return 0;
            }

            if (!getLoadedProgramResponse.Contains(UrProgramFilename))
            {
                myForm.ErrorMessageBox($"Failed to verify loading {UrProgramFilename}. Response was \"{getLoadedProgramResponse}\"");
                return 0;
            }

            string playResponse = InquiryResponse("play", 1000);
            if (!playResponse.StartsWith("Starting program"))
            {
                myForm.ErrorMessageBox($"Failed to start program playing. Response was \"{playResponse}\"");
                return 0;
            }

            return 0;
        }

        public override int Disconnect()
        {
            myForm.WriteVariable("robot_ready", false, true);

            if (IsConnected())
            {
                InquiryResponse("stop");
                InquiryResponse("quit");
            }
            status = Status.OFF;
            myForm.UrDashboardAnnounce();

            return base.Disconnect();
        }
    }
}
