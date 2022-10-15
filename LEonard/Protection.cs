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
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public string cpuInfo;
        public string machineGuid;
        public DateTime expirationDateTime;

        // Options
        public bool hasJava;
        public bool hasPython;
        public bool hasUR;
        public bool hasGrinding;
        public bool hasGocator;

        public License()
        {
            cpuInfo = "";
            machineGuid = "";
            expirationDateTime = DateTime.Now - TimeSpan.FromDays(1);

            // Options
            hasJava = false;
            hasPython = false;
            hasUR = false;
            hasGrinding = false;
            hasGocator = false;
        }

        //Serialization functions
        public License(SerializationInfo info, StreamingContext ctxt)
        {
            try
            {
                cpuInfo = (string)info.GetValue("cpuInfo", typeof(string));
                machineGuid = (string)info.GetValue("machineGuid", typeof(string));
                expirationDateTime = (DateTime)info.GetValue("expirationDateTime", typeof(DateTime));
                hasJava = (bool)info.GetValue("hasJava", typeof(bool));
                hasPython = (bool)info.GetValue("hasPython", typeof(bool));
                hasUR = (bool)info.GetValue("hasUR", typeof(bool));
                hasGrinding = (bool)info.GetValue("hasGrinding", typeof(bool));
                hasGocator = (bool)info.GetValue("hasGocator", typeof(bool));
            }
            catch 
            {
                //mainForm.ErrorMessageBox($"License: input serializer");
                log.Error($"License: input serializer");
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            try
            {
                info.AddValue("cpuInfo", cpuInfo);
                info.AddValue("machineGuid", machineGuid);
                info.AddValue("expirationDateTime", expirationDateTime);
                info.AddValue("hasJava", hasJava);
                info.AddValue("hasPython", hasPython);
                info.AddValue("hasUR", hasUR);
                info.AddValue("hasGrinding", hasGrinding);
                info.AddValue("hasGocator", hasGocator);
            }
            catch
            {
                //mainForm.ErrorMessageBox($"License: output serializer");
                log.Error($"License: output serializer");
            }
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

        byte[] key = { 1, 2, 7, 4, 5, 6, 13, 8 };
        byte[] iv = { 1, 2, 7, 4, 5, 6, 9, 8 };

        public Protection(LEonard.MainForm mf, string filename)
        {
            log.Info($"Protection::Protection(...,{filename})");

            mainForm = mf;

            cpuInfo = GetCpuInfo();
            machineGuid = GetMachineGuid();
            dateTime = DateTime.Now;

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

            license.hasJava = true;
            license.hasPython = true;
            license.hasUR = true;
            license.hasGrinding = true;
            license.hasGocator = true;
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
            dateTime = DateTime.Now;

            bool goodGuid = (machineGuid == license.machineGuid);
            bool goodCpuInfo = (cpuInfo == license.cpuInfo);
            bool goodDateTime = (dateTime < license.expirationDateTime);

            string ret = $"CPU ID OK: {goodCpuInfo}\n";
            ret += $"WINDOWS ID OK: {goodGuid}\n";
            ret += $"DAYS REMAINING: {(license.expirationDateTime - dateTime).TotalDays:0.0000} days\n\n";

            ret += $"OPTIONS\n";
            ret += $"  Java: {license.hasJava}\n";
            ret += $"  Python: {license.hasPython}\n";
            ret += $"  Universal Robots: {license.hasUR}\n";
            ret += $"  Grinding Package: {license.hasGrinding}\n";
            ret += $"  Gocator: {license.hasGocator}\n";

            return ret;
        }

        public bool RunLEonard()
        {
            dateTime = DateTime.Now;

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
