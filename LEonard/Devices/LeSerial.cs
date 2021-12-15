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

        public Action<string, string> receiveCallback { get; set; } = null;

        public LeSerial(MainForm form, string prefix = "", string connectMsg = "") : base(form, prefix, connectMsg)
        {
            log.Debug("{0} LeSerial(form, {0}, {1})", logPrefix, onConnectMessage);
        }

        ~LeSerial()
        {
            log.Debug("{0} ~LeSerial() {1}", logPrefix, myPortname);
        }
        public int Connect(string portname)
        {
            myPortname = portname;
            log.Debug("{0} Connect({1})", logPrefix, myPortname);

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEvent);

            try
            {
                port.Open();

                if (port.IsOpen)
                {
                    if (onConnectMessage.Length > 0) Send(onConnectMessage);
                }
                else
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

            return 0;
        }

        public int Disconnect()
        {
            log.Info("{0} Disconnect(): {1}", logPrefix, myPortname);

            port.Close();

            return 0;
        }

        public int Send(string message)
        {
            log.Info("{0} ==> {1}", logPrefix, message);
            port.Write(message);
            return 0;
        }
        public string Receive()
        {
            //log.Info("Receive(): " + myPortname);
            if (port.BytesToRead > 0)
                return port.ReadLine();
            else
                return "";
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
                    data = port.ReadLine();
                    log.Info("{0} <== {1} Line {2}", logPrefix, data, lineNo);
                    receiveCallback(data, logPrefix);
                    lineNo++;
                }
            }
        }
    }
}
