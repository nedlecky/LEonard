using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeDeviceBase
    {
        protected MainForm myForm;
        protected string logPrefix;
        protected string onConnectMessage;
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        public LeDeviceBase(MainForm form, string prefix="", string connectMessage="")
        {
            myForm = form;  
            logPrefix = prefix;
            onConnectMessage = connectMessage;   
            log.Info(string.Format("LeDeviceBase(form, {0}, {1})", logPrefix, onConnectMessage));

        }

        public long IPAddressToLong(IPAddress address)
        {
            byte[] byteIP = address.GetAddressBytes();

            long ip = (long)byteIP[3] << 24;
            ip += (long)byteIP[2] << 16;
            ip += (long)byteIP[1] << 8;
            ip += (long)byteIP[0];
            return ip;
        }

    }
}
