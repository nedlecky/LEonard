using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeSerial : LeDeviceInterface
    {
        MainForm myForm;
        string myPortname;
        SerialPort port;
        public string Index { get; set; }
        public string Value { get; set; }

        public Action<string> receiveCallback { get; set; }

        public LeSerial(MainForm form) 
        {
            myForm = form;
            myForm.CrawlBarcode("LeSerial()");
        }

        ~LeSerial()
        {
            myForm.CrawlBarcode("~LeSerial(): " + myPortname);
        }
        public int Connect(string portname)
        {
            myPortname = portname;
            myForm.CrawlBarcode("LeSerial.Connect(" + myPortname + ")");

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.Open();

            myForm.CrawlBarcode("IsOpen=" + port.IsOpen);

            return 0;
        }

        public int Disconnect()
        {
            myForm.CrawlBarcode("LeSerial.Disconnect(): " + myPortname);

            port.Close();

            return 0;
        }

        public int Send(string message)
        {
            //myForm.CrawlBarcode("Trigger(): " + myPortname);
            port.Write(message);
            return 0;
        }
        public string Receive()
        {
            //myForm.CrawlBarcode("Trigger(): " + myPortname);
            if(port.BytesToRead > 0)
                return port.ReadLine();
            else
                return "";
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadLine();
            myForm.CrawlBarcode(data);
            string[] s = data.Split(',');
            if (s.Length == 3)
            {
                Index = s[1];
                Value = s[2];
            }
            else
                myForm.CrawlBarcode("Barcode ERROR");
        }

    }
}
