// File: LeDevNull.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Null (Examaple) LEonard device

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

        public Action<string, string> receiveCallback { get; set; } = null;

        public LeDevNull(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeDevNull(form, {0}, {1})", logPrefix, onConnectMessage);
        }

        ~LeDevNull()
        {
            log.Debug("{0} ~LeDevNull()", logPrefix);
        }
        public int Connect(string portname)
        {
            log.Debug("{0} Connect({1})", logPrefix, portname);
            return 0;
        }
        public bool IsConnected()
        {
            log.Debug("{0} IsConnected()", logPrefix);
            return false;
        }

        public int Disconnect()
        {
            log.Info("{0} Disconnect()", logPrefix);
            return 0;
        }

        public int Send(string message)
        {
            log.Info("{0} ==> {1}", logPrefix, message);
            return 0;
        }
        public string Receive(bool fProcessCallbackOnly = false)
        {
            return "";
        }
    }
}

