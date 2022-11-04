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
        //private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static int nInstances = 0;
        public static int nConnected = 0;
        public static LeUrCommand uiFocusInstance = null;

        public enum Status
        {
            OFF,
            ERROR,
            WAITING,
            OK
        }
        public Status status = Status.OFF;


        public LeUrCommand(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeUrCommand(form, \"{prefix}\", \"{connectExec}\")");

            uiFocusInstance = this;
            nInstances++;
            status = Status.OFF;
            myForm.UrCommandAnnounce();
        }
        ~LeUrCommand()
        {
            log.Debug($"{logPrefix} ~LeUrCommand() nInstances={nInstances}");

            nInstances--;
            if (nInstances == 0 || uiFocusInstance == this) uiFocusInstance = null;
        }

        public override int Connect(string IP, string port)
        {
            int ret = base.Connect(IP, port);
            if (ret != 0)
            {
                status = Status.ERROR;
                myForm.UrCommandAnnounce();
                return 4;
            }
            else
            {
                log.Info("Universal Robot connection waiting for robot to connect");
                myForm.WriteVariable("robot_ready", true, true);
                status = Status.WAITING;
                myForm.UrCommandAnnounce();
                nConnected++;
            }
            return 0;
        }
        public override int Disconnect()
        {
            myForm.WriteVariable("robot_ready", false, true);

            status = Status.OFF;
            myForm.UrCommandAnnounce();
            nConnected--;
            return base.Disconnect();
        }
    }
}