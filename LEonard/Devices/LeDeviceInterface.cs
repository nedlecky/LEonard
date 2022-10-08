using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonardTablet
{
    public interface LeDeviceInterface
    {
        Process runtimeProcess { get; set; }
        Process setupProcess { get; set; }

        int Connect(string address);
        bool IsConnected();
        int Disconnect();
        int Send(string message);
        string Receive();

        int StartRuntimeProcess(ProcessStartInfo start);
        int EndRuntimeProcess();
        int StartSetupProcess(ProcessStartInfo start);
        int EndSetupProcess();

        Action<string, string> receiveCallback { get; set; }
    }
}
