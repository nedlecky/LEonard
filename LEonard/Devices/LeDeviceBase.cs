using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public class LeDeviceBase
    {
        MainForm myForm;
        string crawlPrefix;
     
        protected LeDeviceBase(MainForm form, string prefix)
        {
            myForm = form;  
            crawlPrefix = prefix;
            Crawl(string.Format("LeDeviceBase(form, {0})", prefix));

        }
        protected void Crawl(string s)
        {
            myForm.Crawl(crawlPrefix + " " + s);
        }
        protected void CrawlError(string s)
        {
            myForm.Crawl(crawlPrefix + " ERROR " + s);
        }
    }
}
