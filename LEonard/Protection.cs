// File: Protection.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Software copy protection scheme

using Microsoft.Win32;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Leonard
{
    public class License
    {
        public string cpuInfo { get; set; } = "BFEBFBFF000A0652";
        public string machineGuid { get; set; } = "2bdc9592-e3ab-4669-a866-af6652c76935";

        // Yesterday, all my licenses seemed so OK...
        public DateTime expirationDateTime { get; set; } = DateTime.Now - TimeSpan.FromDays(1);

        public bool Load()
        {
            return true;
        }
        public bool Save()
        {
            return true;
        }
    }
    public class Protection
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private static string machineGuid = "";
        private static string cpuInfo = "";
        private static DateTime dateTime;

        private static License license;

        public Protection()
        {
            log.Info("Protection::Protection()");

            cpuInfo = GetCpuInfo();
            machineGuid = GetMachineGuid();
            dateTime = DateTime.Now;
            log.Info($"cpuInfo = {cpuInfo}");
            log.Info($"machineGuid = {machineGuid}");
            log.Info($"dateTime = {dateTime.ToString()}");

            license = new License();
            license.Load();
        }

        private string GetCpuInfo()
        {
            string cpuInfo = "";

            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                log.Info($"mo =  {mo.ToString()}");
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return cpuInfo;
        }

        public string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        log.Error($"Protection::GetMachineGUID Key {location} not found");
                    else
                    {
                        object machineGuid = rk.GetValue(name);
                        if (machineGuid == null)
                            log.Error($"Protection::GetMachineGUID Index {name} not found");
                        else
                            return machineGuid.ToString();
                    }
                }
                return "";
            }
        }

        public bool RunLEonard()
        {
            // License Info

            DateTime datetime = DateTime.Now;


            bool goodGUID = (machineGuid == license.machineGuid);
            bool goodCpuInfo = (cpuInfo == license.cpuInfo);
            bool goodDateTime = (dateTime < license.expirationDateTime);
            log.Info($"Good? {goodGUID} {goodCpuInfo} {goodDateTime}");
            log.Info($"cpuInfo = \"{cpuInfo}\" len={cpuInfo.Length}");
            log.Info($"machineGUID = \"{machineGuid}\" len={machineGuid.Length}");
            log.Info($"expectedCpuInfo = \"{license.cpuInfo}\" len={license.cpuInfo.Length}");
            log.Info($"expectedMachineGUID = \"{license.machineGuid}\" len ={license.machineGuid.Length}");

            return goodGUID && goodCpuInfo && goodDateTime;
        }
    }
}
