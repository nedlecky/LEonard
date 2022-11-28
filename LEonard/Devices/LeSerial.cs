// File: LeSerial.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: RS-232 Device

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeSerial : LeDeviceBase, LeDeviceInterface
    {

        public SerialPort port;
        string myPortname;
        //private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public Action<string, string, LeDeviceInterface> receiveCallback { get; set; } = null;
        bool fConnected = false;

        public LeSerial(MainForm form, string prefix = "", string connectExec = "") : base(form, prefix, connectExec)
        {
            log.Debug($"{prefix} LeSerial(form, {prefix}, {connectExec})");
        }

        ~LeSerial()
        {
            log.Debug($"{LogPrefix} ~LeSerial() {myPortname}");
        }
        public override int Connect(string portname)
        {
            fConnected = false;
            if (port != null)
                Disconnect();

            myPortname = portname;
            log.Info("{0} Connect({1})", LogPrefix, myPortname);

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.NewLine = RxTerminator;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEvent);
            port.ReadTimeout = 1000;

            try
            {
                port.Open();

                if (!port.IsOpen)
                {
                    log.Error("{0} Port {1} did not open", LogPrefix, portname);
                    return 2;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "{0} port.Open() failed {1}", LogPrefix, portname);
                return 1;
            }


            fConnected = true;

            if (execLEonardMessageOnConnect.Length > 0)
            {
                myForm.SetMeDevice(this);
                if (!myForm.ExecuteLEonardMessage(LogPrefix, execLEonardMessageOnConnect))
                    return 1;
            }

            return base.Connect(portname);
        }

        public bool IsConnected()
        {
            return fConnected;
        }

        public override int Disconnect()
        {
            log.Info("{0} Disconnect(): {1}", LogPrefix, myPortname);

            if (port != null)
                port.Close();
            port = null;

            fConnected = false;
            return base.Disconnect();
        }

        public int Send(string message)
        {
            log.Debug("{0} ==> {1}", LogPrefix, message);
            port.Write(TxPrefix + message + TxSuffix);
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
        public string Ask(string message, int timeoutMs = 50)
        {
            log.Error($"{LogPrefix} LeSerial::Ask({message}, {timeoutMs}) NOT IMPLEMENTED");

            return null;
        }

        public void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            if (receiveCallback != null)
            {
                string data = "";
                // Read all lines in the buffer
                // TODO: Doesn't this block and timeout if there are bytes but no newline?
                int lineNo = 1;
                while (port.IsOpen && port.BytesToRead > 0)
                {
                    // TODO: if the port.NewLine isn't in the buffer this blocks... needs to timeout almost instantly?
                    try
                    {
                        data = port.ReadLine();
                        log.Debug("{0} <== {1} Line {2}", LogPrefix, data, lineNo);
                        receiveCallback(LogPrefix, data, this);
                        lineNo++;
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
