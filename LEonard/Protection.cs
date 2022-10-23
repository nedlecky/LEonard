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
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    [Serializable()]
    public class License : ISerializable
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public string version;
        public DateTime createdDateTime;
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
            version = "";
            createdDateTime = new DateTime(0);
            cpuInfo = "";
            machineGuid = "";
            expirationDateTime = new DateTime(0);

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
                version = (string)info.GetValue("version", typeof(string));
                createdDateTime = (DateTime)info.GetValue("createdDateTime", typeof(DateTime));
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
                log.Error($"License: input serializer error");
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            try
            {
                info.AddValue("version", version);
                info.AddValue("createdDateTime", createdDateTime);
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
                log.Error($"License: output serializer error");
            }
        }
        public void ToggleJava()
        {
            hasJava = !hasJava;
        }
        public void TogglePython()
        {
            hasPython = !hasPython;
        }
        public void ToggleUR()
        {
            hasUR = !hasUR;
        }
        public void ToggleGrinding()
        {
            hasGrinding = !hasGrinding;
        }
        public void ToggleGocator()
        {
            hasGocator = !hasGocator;
        }
    }
    public class Protection
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private static string machineGuid = "";
        private static string cpuInfo = "";
        private static DateTime dateTime;
        private static string version = "";
        public static License license;
        private static MainForm mainForm;

        byte[] key = { 8, 17, 62, 44, 53, 67, 130, 78 };
        byte[] iv = { 9, 14, 27, 84, 100, 12, 7, 123 };

        public Protection(LEonard.MainForm mf, string filename)
        {
            log.Info($"Protection::Protection(...,{filename})");

            mainForm = mf;

            cpuInfo = GetCpuInfo();
            machineGuid = GetMachineGuid();
            dateTime = DateTime.Now;
            version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            LoadLicense(filename);
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

        public void CreateNewLicense()
        {
            license.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            license.createdDateTime = DateTime.Now;
            license.machineGuid = machineGuid;
            license.cpuInfo = cpuInfo;
            license.expirationDateTime = new DateTime(0);

            license.hasJava = true;
            license.hasPython = true;
            license.hasUR = true;
            license.hasGrinding = true;
            license.hasGocator = true;
        }
        public void CreateTrialLicense(int nDays)
        {
            CreateNewLicense();

            license.expirationDateTime = dateTime + TimeSpan.FromDays(nDays);
        }


        private bool HasGoodGuid()
        {
            return (machineGuid == license.machineGuid);
        }
        private bool HasGoodCpuInfo()
        {
            return (cpuInfo == license.cpuInfo);
        }
        private bool HasGoodDateTime()
        {
            bool goodDateTime = true;
            if (license.expirationDateTime != new DateTime(0))
                goodDateTime = (dateTime < license.expirationDateTime);

            return goodDateTime;
        }
        private bool HasGoodVersion()
        {
            return true;
        }

        private string BoolOkFail(bool b)
        {
            return b ? "OK" : "FAIL";
        }
        private string BoolEnabledDisabled(bool b)
        {
            return b ? "ENABLED" : "DISABLED";
        }
        public string GetStatus()
        {
            // Reset Protection object to current time!
            dateTime = DateTime.Now;

            bool goodGuid = HasGoodGuid();
            bool goodCpuInfo = HasGoodCpuInfo();
            bool goodDateTime = HasGoodDateTime();
            bool goodVersion = HasGoodVersion();

            string ret = "LEonard License File\nLecky Engineering LLC c. 2021-2023\n";
            ret += $"Created: {license.createdDateTime}\n\n";

            ret += $"LEONARD VERSION {BoolOkFail(goodVersion)}\n  LICENSED: {license.version}\n  CURRENT: {version}\n\n";

            ret += $"CPU SERIAL NUMBER {BoolOkFail(goodCpuInfo)}\n  {license.cpuInfo}\n\n";

            ret += $"WINDOWS GUID {BoolOkFail(goodGuid)}\n  {license.machineGuid}\n\n";

            ret += $"DAYS REMAINING {BoolOkFail(goodDateTime)}\n";
            if (license.expirationDateTime == new DateTime(0))
                ret += $"  PERPETUAL\n";
            else
                ret += $"  {(license.expirationDateTime - dateTime).TotalDays:0.0000} days\n";

            ret += $"\nOPTIONS:\n";
            ret += $"  Java: {BoolEnabledDisabled(license.hasJava)}\n";
            ret += $"  Python: {BoolEnabledDisabled(license.hasPython)}\n";
            ret += $"  Universal Robots: {BoolEnabledDisabled(license.hasUR)}\n";
            ret += $"  Grinding Package: {BoolEnabledDisabled(license.hasGrinding)}\n";
            ret += $"  Gocator: {BoolEnabledDisabled(license.hasGocator)}\n";

            return ret;
        }

        public bool RunLEonard()
        {
            dateTime = DateTime.Now;

            bool goodGuid = HasGoodGuid();
            bool goodCpuInfo = HasGoodCpuInfo();
            bool goodDateTime = HasGoodDateTime();
            bool goodVersion = HasGoodVersion();

            log.Info($"cpuInfo = {cpuInfo}   expectedCpuInfo = {license.cpuInfo}");
            log.Info($"machineGUID = {machineGuid}   expectedMachineGUID = {license.machineGuid}");
            log.Info($"now = {dateTime}   expiration = {license.version}");
            log.Info($"version = {version}   expectedVersion = {license.version}");
            log.Info($"Good? {goodGuid} {goodCpuInfo} {goodDateTime} {goodVersion}");

            return goodGuid && goodCpuInfo && goodDateTime && goodVersion;
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

    }
}
