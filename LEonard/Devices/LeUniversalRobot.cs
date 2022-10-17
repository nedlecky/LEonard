// File: LeUniversalRobot.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Custom interface to Universal Robot

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static IronPython.Modules._ast;

namespace LEonard
{
    public class LeUniversalRobot : LeTcpClient
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        LeTcpServer commandServer;

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
            string[] s = IPport.Split(':');
            return Connect(s[0], s[1]);
        }
        public override int Connect(string IP, string port)
        {
            log.Debug($"{logPrefix} LeUniversalRobot::Connect({IP}, {port})");

            string dashIP = "192.168.0.2";
            string dashPort = "29999";
            log.Debug($"{logPrefix} Connect Dashboard({dashIP}, {dashPort})");
            log.Debug($"{logPrefix} Connect Dashboard");
            int ret = base.Connect(dashIP, dashPort);
            if (ret != 0)
            {
                myForm.UrDashboardAnnounce(DashboardStatus.OFF);
                myForm.ErrorMessageBox($"Cannot start UR dashboard on {dashIP}:{dashPort}");
                return ret;
            }
            else
            {
                log.Info("Dashboard connection ready");
                Thread.Sleep(50);
                string response = Receive();
                if (response != "Connected: Universal Robots Dashboard Server")
                {
                    myForm.UrDashboardAnnounce(DashboardStatus.ERROR);
                    myForm.ErrorMessageBox($"Dashboard connection returned {response}");
                }
                myForm.UrDashboardAnnounce(DashboardStatus.OK);

                commandServer = new LeTcpServer(myForm, logPrefix, "");
                ret = commandServer.Connect(IP, port);
                if (ret != 0)
                    myForm.UrCommandAnnounce(LeUniversalRobot.CommandStatus.ERROR);
                else
                {
                    log.Info("Universal Robot connection ready");
                    myForm.WriteVariable("robot_ready", true, true);
                    myForm.UrCommandAnnounce(LeUniversalRobot.CommandStatus.OK);
                }
            }
            return ret;
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
