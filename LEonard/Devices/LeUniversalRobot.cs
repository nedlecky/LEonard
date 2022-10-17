// File: LeUniversalRobot.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Custom interface to Universal Robot

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static IronPython.Modules._ast;
using static IronPython.Modules.PythonWeakRef;

namespace LEonard
{
    public class LeUniversalRobot : LeTcpClient
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public LeTcpServer commandServer = null;
        public string UrProgramFilename { get; set; } = "";

        public LeUniversalRobot(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeUniversalRobot(form, {0}, {1})", logPrefix, onConnectMessage);

        }
        ~LeUniversalRobot()
        {
            log.Debug("{0} ~LeUniversalRobot()", logPrefix);
        }

        public enum DashboardStatus
        {
            OFF,
            ERROR,
            OK
        }
        public enum CommandStatus
        {
            OFF,
            ERROR,
            OK
        }

        public override int Connect(string IPport)
        {
            log.Debug($"{logPrefix} LeUniversalRobot::Connect({IPport})");
            string[] addresses = IPport.Split('#');
            if (addresses.Length != 2)
            {
                myForm.ErrorMessageBox($"UR needs IP:port#IP:port not {IPport}");
                return 1;
            }

            // Dashboard
            string[] ip_port = addresses[0].Split(':');
            if (ip_port.Length != 2)
            {
                myForm.ErrorMessageBox($"UR needs IP:port#IP:port not {IPport}");
                return 2;
            }

            // Robot Command Server
            if (0 == Connect(ip_port[0], ip_port[1]))
            {
                // Setup Command Server
                ip_port = addresses[1].Split(':');
                if (ip_port.Length != 2)
                {
                    myForm.ErrorMessageBox($"UR needs IP:port#IP:port not {IPport}");
                    return 3;
                }
                commandServer = new LeTcpServer(myForm, logPrefix, "");
                int ret = commandServer.Connect(ip_port[0], ip_port[1]);
                if (ret != 0)
                {
                    myForm.UrCommandAnnounce(LeUniversalRobot.CommandStatus.ERROR);
                    return 4;
                }
                else
                {
                    // Commands will return general LEonard responses
                    commandServer.receiveCallback = myForm.GeneralCallback;
                    log.Info("Universal Robot connection ready");
                    myForm.WriteVariable("robot_ready", true, true);
                    myForm.UrCommandAnnounce(LeUniversalRobot.CommandStatus.OK);
                }
            }
            return 0;
        }
        public override int Connect(string dashIP, string dashPort)
        {
            log.Debug($"{logPrefix} LeUniversalRobot::Connect({dashIP}, {dashPort})");

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

            if (commandServer != null)
            {
                commandServer.Disconnect();
                commandServer = null;
            }
            myForm.UrCommandAnnounce(LeUniversalRobot.CommandStatus.OFF);

            int ret = 0;
            if (IsConnected())
            {
                InquiryResponse("stop");
                InquiryResponse("quit");
                ret = base.Disconnect();
            }
            myForm.UrDashboardAnnounce(LeUniversalRobot.DashboardStatus.OFF);

            return ret;
        }


    }
}
