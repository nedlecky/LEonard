// File: LeDeviceInterface.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Interface for all devices- children must follow this and inherit LeDeviceBase

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    public interface LeDeviceInterface
    {
        string Name { get; set; }

        string TxPrefix { get; set; }
        string TxSuffix { get; set; }
        string RxTerminator { get; set; }
        string RxSeparator { get; set; }

        Process runtimeProcess { get; set; }
        Process setupProcess { get; set; }

        int Connect(string address);
        bool IsConnected();
        int Disconnect();
        int Send(string message);
        string Receive(bool fProcessCallBackOnly = false);
        string Ask(string inquiry, int timeoutMs = 50);

        int StartRuntimeProcess(ProcessStartInfo start);
        int EndRuntimeProcess();
        int StartSetupProcess(ProcessStartInfo start);
        int EndSetupProcess();

        Action<string, string, LeDeviceInterface> receiveCallback { get; set; }
    }
}
