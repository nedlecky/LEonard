using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public interface LeDeviceInterface
    {
        int Connect(string address);
        int Disconnect();
        int Send(string message);
        string Receive();

        Action<string, string> receiveCallback { get; set; }
    }
}
