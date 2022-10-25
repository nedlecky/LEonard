// File: LeSerial.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: RS-232 Device

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeSerial : LeDeviceBase, LeDeviceInterface
    {

        public SerialPort port;
        string myPortname;
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; } = null;
        bool fConnected = false;

        public LeSerial(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeSerial(form, {0}, {1})", logPrefix, execLEonardMessageOnConnect);
        }

        ~LeSerial()
        {
            log.Debug("{0} ~LeSerial() {1}", logPrefix, myPortname);
        }
        public int Connect(string portname)
        {
            fConnected = false;
            if (port != null)
                Disconnect();

            myPortname = portname;
            log.Debug("{0} Connect({1})", logPrefix, myPortname);

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.NewLine = "\r";
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEvent);

            try
            {
                port.Open();

                if (!port.IsOpen)
                {
                    log.Error("{0} Port {1} did not open", logPrefix, portname);
                    return 2;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "{0} port.Open() failed {1}", logPrefix, portname);
                return 1;
            }


            fConnected = true;

            if (execLEonardMessageOnConnect.Length > 0)
                if (!myForm.ExecuteLEonardMessage(logPrefix, execLEonardMessageOnConnect, this))
                    Send(execLEonardMessageOnConnect);

            return 0;
        }

        public bool IsConnected()
        {
            return fConnected;
        }

        public int Disconnect()
        {
            log.Info("{0} Disconnect(): {1}", logPrefix, myPortname);

            if (port != null)
                port.Close();
            port = null;

            fConnected = false;
            return 0;
        }

        public int Send(string message)
        {
            log.Info("{0} ==> {1}", logPrefix, message);
            port.Write(message);
            return 0;
        }
        public string Receive(bool fProcessCallbackOnly = false)
        {
            //log.Error("NOT IMPLEMENTED Receive(): " + myPortname);
            // TODO: Currently this is only done through callback and it gets called constantly for serial devices
            return "";
            /*
            if (port.BytesToRead > 0)
                return port.ReadLine();
            else
                return "";
            */
        }
        public void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            if (receiveCallback != null)
            {
                string data = "";
                // Read all lines in the buffer
                // TODO: Doesn't this block and timeout if there are bytes but no newline?
                int lineNo = 1;
                while (port.BytesToRead > 0)
                {
                    // TODO: if the port.NewLine isn't in the buffer this blocks... needs to timeout almost instantly?
                    data = port.ReadLine();
                    log.Info("{0} <== {1} Line {2}", logPrefix, data, lineNo);
                    receiveCallback(logPrefix, data, this);
                    lineNo++;
                }
            }
        }
    }
}
