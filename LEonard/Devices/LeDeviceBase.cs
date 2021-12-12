using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeDeviceBase
    {
        protected MainForm myForm;
        protected string myPrefix;
        protected string onConnectMessage;
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        protected LeDeviceBase(MainForm form, string prefix, string connectMessage)
        {
            myForm = form;  
            myPrefix = prefix;
            onConnectMessage = connectMessage;   
            log.Info(string.Format("LeDeviceBase(form, {0}, {1})", prefix, connectMessage));

        }
        /*
        protected void Crawl(string s)
        {
            myForm.Crawl(crawlPrefix + " " + s);
        }
        protected void CrawlError(string s)
        {
            myForm.Crawl(crawlPrefix + " ERROR " + s);
        }
        */
    }
}
