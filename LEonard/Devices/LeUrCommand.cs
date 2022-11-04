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
        public static int nInstances = 0;
        public static int nConnected = 0;
        public static LeUrCommand focusLeUrCommand = null;

        public enum Status
        {
            OFF,
            ERROR,
            WAITING,
            OK
        }
        public LeUrCommand.Status status = Status.OFF;


        public LeUrCommand(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeUrCommand(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);

            focusLeUrCommand = this;
            nInstances++;
            status = Status.OFF;
            myForm.UrCommandAnnounce();
        }
        ~LeUrCommand()
        {
            log.Debug("{0} ~LeUrCommand()", logPrefix);

            nInstances--;
            if (focusLeUrCommand == this) focusLeUrCommand = null;
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
            return 0;
        }
    }
}