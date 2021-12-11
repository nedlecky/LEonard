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

        public Action<string, string> receiveCallback { get; set; } = null;

        public LeSerial(MainForm form, string prefix) : base(form, prefix)
        {
            Crawl("LeSerial()");
        }

        ~LeSerial()
        {
            Crawl("~LeSerial() " + myPortname);
        }
        public int Connect(string portname)
        {
            myPortname = portname;
            Crawl("LeSerial.Connect(" + myPortname + ")");

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEvent);

            port.Open();

            Crawl("IsOpen=" + port.IsOpen);

            return 0;
        }

        public int Disconnect()
        {
            Crawl("LeSerial.Disconnect(): " + myPortname);

            port.Close();

            return 0;
        }

        public int Send(string message)
        {
            Crawl("==>" + message);
            port.Write(message);
            return 0;
        }
        public string Receive()
        {
            //Crawl("Trigger(): " + myPortname);
            if(port.BytesToRead > 0)
                return port.ReadLine();
            else
                return "";
        }
        public void DataReceivedEvent(object sender, SerialDataReceivedEventArgs e)
        {
            if (receiveCallback != null)
            {
                string data = "";
                data = port.ReadLine();
                Crawl("LeSerial.DataReceivedEvent "+ data);
                receiveCallback(data, crawlPrefix);
            }
        }


    }
}
