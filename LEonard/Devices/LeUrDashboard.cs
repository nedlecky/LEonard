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
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public string UrProgramFilename { get; set; } = "";
        public enum DashboardStatus
        {
            OFF,
            ERROR,
            OK
        }

        public LeUrDashboard(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeUrDashboard(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);

        }
        ~LeUrDashboard()
        {
            log.Debug("{0} ~LeUrDashboard()", logPrefix);
        }

        public override int Connect(string dashIP, string dashPort)
        {
            log.Debug($"{logPrefix} LeUrDashboard::Connect({dashIP}, {dashPort})");

            log.Debug($"{logPrefix} Connect Dashboard({dashIP}, {dashPort})");
            log.Debug($"{logPrefix} Connect Dashboard");
            int ret = base.Connect(dashIP, dashPort);
            if (ret != 0)
            {
                myForm.UrDashboardAnnounce(DashboardStatus.OFF);
                myForm.ErrorMessageBox($"Cannot start UR dashboard on {dashIP}:{dashPort}");
                return ret;
            }
            log.Info("Dashboard connection ready");
            Thread.Sleep(50);
            string response = Receive();
            if (response != "Connected: Universal Robots Dashboard Server")
            {
                myForm.UrDashboardAnnounce(DashboardStatus.ERROR);
                myForm.ErrorMessageBox($"Dashboard connection returned {response}");
            }
            myForm.UrDashboardAnnounce(DashboardStatus.OK);

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardStatement(logPrefix, execLEonardMessageOnConnect, this))
                    Send(execLEonardMessageOnConnect);

            // TODO all the below could be in this onConnectExec
            string closeSafetyPopupResponse = InquiryResponse("close safety popup", 1000);
            string isInRemoteControlResponse = InquiryResponse("is in remote control", 1000);
            if (isInRemoteControlResponse == null)
            {
                myForm.ErrorMessageBox("Failed to check remote control mode. No response.");
                return 2;
            }
            if (isInRemoteControlResponse != "true")
            {
                myForm.ErrorMessageBox("Robot not in remote control mode!");
                return 3;
            }
            string loadedProgramResponse = InquiryResponse("load " + UrProgramFilename, 1000);
            if (loadedProgramResponse == null)
            {
                myForm.ErrorMessageBox($"Failed to load {UrProgramFilename}. No response.");
                return 4;
            }
            if (loadedProgramResponse.StartsWith("File not found"))
            {
                myForm.ErrorMessageBox($"Failed to load {UrProgramFilename}. Response was \"{loadedProgramResponse}\"");
                return 5;
            }

            string getLoadedProgramResponse = InquiryResponse("get loaded program", 1000);
            if (getLoadedProgramResponse == null)
            {
                myForm.ErrorMessageBox($"Failed to verify loading {UrProgramFilename}. No response");
                return 6;
            }

            if (!getLoadedProgramResponse.Contains(UrProgramFilename))
            {
                myForm.ErrorMessageBox($"Failed to verify loading {UrProgramFilename}. Response was \"{getLoadedProgramResponse}\"");
                return 7;
            }

            string playResponse = InquiryResponse("play", 1000);
            if (!playResponse.StartsWith("Starting program"))
            {
                myForm.ErrorMessageBox($"Failed to start program playing. Response was \"{playResponse}\"");
                return 8;
            }

            return 0;
        }

        public override int Disconnect()
        {
            myForm.WriteVariable("robot_ready", false, true);

            int ret = 0;
            if (IsConnected())
            {
                InquiryResponse("stop");
                InquiryResponse("quit");
                ret = base.Disconnect();
            }
            myForm.UrDashboardAnnounce(DashboardStatus.OFF);

            return ret;
        }
    }
}
