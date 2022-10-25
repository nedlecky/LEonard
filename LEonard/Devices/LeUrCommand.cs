// File: LeUrCommand.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Custom LeTcpServer child to handle Universal Robot command interface from PolyScope/URScript

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LEonard;
using NLog.Fluent;

namespace LEonard
{
    public class LeUrCommand : LeTcpServer
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public enum CommandStatus
        {
            OFF,
            ERROR,
            OK
        }

        public LeUrCommand(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeUrCommand(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);

        }
        ~LeUrCommand()
        {
            log.Debug("{0} ~LeUrCommand()", logPrefix);
        }

        public override int Connect(string IPport)
        {
            string[] ip_port = IPport.Split(':');
            if (ip_port.Length != 2)
            {
                myForm.ErrorMessageBox($"UR needs IP:port not {IPport}");
                return 2;
            }

            // Robot Command Server
            int ret = Connect(ip_port[0], ip_port[1]);
            if (ret != 0)
            {
                myForm.UrCommandAnnounce(CommandStatus.ERROR);
                return 4;
            }
            else
            {
                // Commands will return general LEonard responses
                log.Info("Universal Robot connection ready");
                myForm.WriteVariable("robot_ready", true, true);
                myForm.UrCommandAnnounce(CommandStatus.OK);
            }
            return 0;
        }
        public override int Disconnect()
        {
            myForm.WriteVariable("robot_ready", false, true);

            myForm.UrCommandAnnounce(CommandStatus.OFF);
            return 0;
        }
    }
}