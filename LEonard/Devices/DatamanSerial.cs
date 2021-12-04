using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class DatamanSerial : LeDeviceInterface
    {
        MainForm myForm;
        string myPortname;
        SerialPort port;
        public string ReadIndex { get; set; }
        public string Value { get; set; }


        public DatamanSerial(MainForm form) 
        {
            myForm = form;
            myForm.CrawlBarcode("DatamanSerial()");
        }

        ~DatamanSerial()
        {
            myForm.CrawlBarcode("~DatamanSerial(): " + myPortname);
        }
        public int Connect(string portname)
        {
            myPortname = portname;
            myForm.CrawlBarcode("DatamanSerial.Connect(" + myPortname + ")");

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
            myForm.CrawlBarcode("DatamanSerial.Disconnect(): " + myPortname);

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
            return port.ReadLine();
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadLine();
            myForm.CrawlBarcode(data);
            string[] s = data.Split(',');
            if (s.Length == 3)
            {
                ReadIndex = s[1];
                Value = s[2];
            }
            else
                myForm.CrawlBarcode("Barcode ERROR");
        }

    }
}
