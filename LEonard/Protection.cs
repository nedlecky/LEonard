// File: Protection.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Software copy protection scheme

using LEonard;
using Microsoft.Scripting.Actions;
using Microsoft.Win32;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LEonard.MainForm;

namespace Leonard
{
    [Serializable()]
    public class License : ISerializable
    {
        public string cpuInfo;
        public string machineGuid;
        public DateTime expirationDateTime;

        public License()
        {
        cpuInfo = "BFEBFBFF000A0652";
        machineGuid = "2bdc9592-e3ab-4669-a866-af6652c76935";
        // Yesterday, all my licenses seemed so OK...
        expirationDateTime = DateTime.Now - TimeSpan.FromDays(1);
    }

    //Serialization functions
    public License(SerializationInfo info, StreamingContext ctxt)
        {
            cpuInfo = (string)info.GetValue("CpuInfo", typeof(string));
            machineGuid = (string)info.GetValue("MachineGuid", typeof(string));
            expirationDateTime = (DateTime)info.GetValue("ExpirationDateTime", typeof(DateTime));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("CpuInfo", cpuInfo);
            info.AddValue("MachineGuid", machineGuid);
            info.AddValue("ExpirationDateTime", expirationDateTime);
        }
    }
    public class Protection
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private static string machineGuid = "";
        private static string cpuInfo = "";
        private static DateTime dateTime;
        private static License license;
        private static MainForm mainForm;

        byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
                                                 // you may need to obfuscate them or get the user to input a password each time
        byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

        public Protection(LEonard.MainForm mf, string filename)
        {
            log.Info($"Protection::Protection(...,{filename})");

            mainForm = mf;

            cpuInfo = GetCpuInfo();
            machineGuid = GetMachineGuid();
            dateTime = DateTime.Now;
            //log.Info($"cpuInfo = {cpuInfo}");
            //log.Info($"machineGuid = {machineGuid}");
            //log.Info($"dateTime = {dateTime.ToString()}");

            LoadLicense(filename);
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

        public bool LoadLicense(string filename)
        {
            log.Info($"LoadLicense({filename})");
            license = new License();

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {

                using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    license = (License)formatter.Deserialize(cryptoStream);
                }
                return true;
            }
            catch
            {
                mainForm.ErrorMessageBox($"LoadLicense: Cannot load {filename}");
                log.Error($"LoadLicense: Cannot load {filename}");
                return false;
            }
        }

        public bool SaveLicense(string filename)
        {
            log.Info($"SaveLicense({filename})");
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(cryptoStream, license);
                }
                return true;
            }
            catch
            {
                mainForm.ErrorMessageBox($"SaveLicense: Cannot save {filename}");
                log.Error($"SaveLicense: Cannot save {filename}");
                return false;
            }
        }

        public void CreateTrialLicense()
        {
            license.machineGuid = machineGuid;
            license.cpuInfo = cpuInfo;
            license.expirationDateTime = dateTime + TimeSpan.FromDays(30);
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

        public string GetStatus()
        {
            bool goodGuid = (machineGuid == license.machineGuid);
            bool goodCpuInfo = (cpuInfo == license.cpuInfo);
            bool goodDateTime = (dateTime < license.expirationDateTime);

            string ret = $"CPU ID OK: {goodCpuInfo}";
            ret += $"\nWINDOWS ID OK: {goodGuid}";
            ret += $"\nDAYS REMAINING: {(license.expirationDateTime - dateTime).TotalDays:0.00} days";

            return ret;
        }

        public bool RunLEonard()
        {
            // License Info

            DateTime datetime = DateTime.Now;


            bool goodGuid = (machineGuid == license.machineGuid);
            bool goodCpuInfo = (cpuInfo == license.cpuInfo);
            bool goodDateTime = (dateTime < license.expirationDateTime);
            log.Info($"Good? {goodGuid} {goodCpuInfo} {goodDateTime}");
            log.Info($"cpuInfo = \"{cpuInfo}\" len={cpuInfo.Length}");
            log.Info($"machineGUID = \"{machineGuid}\" len={machineGuid.Length}");
            log.Info($"expectedCpuInfo = \"{license.cpuInfo}\" len={license.cpuInfo.Length}");
            log.Info($"expectedMachineGUID = \"{license.machineGuid}\" len ={license.machineGuid.Length}");

            return goodGuid && goodCpuInfo && goodDateTime;
        }
    }
}
