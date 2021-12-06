using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    internal class LeSerialDataman : LeSerial
    {
        //MainForm myForm;
        LeSerialDataman(MainForm form) : base(form)
        {
            //myForm = form;
            myForm.CrawlBarcode("LeSerialDataman()");
        }

    }
}
