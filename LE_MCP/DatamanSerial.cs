using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    internal class TestClass
    {
        public TestClass()
        {

        }
    }

    internal class DatamanSerial
    {
        MainForm myForm;
        string myPortname;
        SerialPort port;
        public string ReadIndex { get; set; }
        public string Value { get; set; }


        public DatamanSerial(MainForm form)
        {
            myForm = form;
            myForm.Crawl("DatamanSerial()");
        }

        ~DatamanSerial()
        {
            myForm.Crawl("~DatamanSerial(): " + myPortname);
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadLine();
            myForm.CrawlVision("Barcode: " + data);
            string[] s = data.Split(',');
            if (s.Length == 3)
            {
                ReadIndex = s[1];
                Value = s[2];
            }
            else
                myForm.CrawlVision("Barode ERROR");
        }
        public int Open(string portname)
        {
            myPortname = portname;
            myForm.Crawl("DatamanSerial.Open(" + myPortname + ")");

            port = new SerialPort(myPortname, 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.XOnXOff;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            //port.Encoding = Encoding.ASCII;
            port.WriteTimeout = 100;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.Open();

            myForm.Crawl("IsOpen=" + port.IsOpen);

            return 0;
        }

        public int Close()
        {
            myForm.Crawl("DatamanSerial.Close(): " + myPortname);

            port.Close();

            return 0;
        }

        public void Trigger()
        {
            //myForm.Crawl("Trigger(): " + myPortname);
            port.Write("+");
        }

    }
}
