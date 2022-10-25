// File: MainForm.Devices.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: MainForm functions supporting Devices

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNORMAL = 5;
        private const int SW_RESTORE = 9;

        private void ClearAndInitializeDevices()
        {
            devices = new DataTable("Devices");

            DataColumn id = devices.Columns.Add("ID", typeof(System.Int32));
            devices.Columns.Add("Name", typeof(System.String));
            devices.Columns.Add("Enabled", typeof(System.Boolean));
            devices.Columns.Add("Connected", typeof(System.Boolean));
            devices.Columns.Add("DeviceType", typeof(System.String));
            devices.Columns.Add("Address", typeof(System.String));
            devices.Columns.Add("MessageTag", typeof(System.String));
            devices.Columns.Add("CallBack", typeof(System.String));
            devices.Columns.Add("OnConnectSend", typeof(System.String));
            devices.Columns.Add("OnDisconnectSend", typeof(System.String));
            devices.Columns.Add("RuntimeAutostart", typeof(System.Boolean));
            devices.Columns.Add("RuntimeWorkingDirectory", typeof(System.String));
            devices.Columns.Add("RuntimeFileName", typeof(System.String));
            devices.Columns.Add("RuntimeArguments", typeof(System.String));
            devices.Columns.Add("SetupWorkingDirectory", typeof(System.String));
            devices.Columns.Add("SetupFileName", typeof(System.String));
            devices.Columns.Add("SetupArguments", typeof(System.String));
            devices.Columns.Add("SpeedSendButtons", typeof(System.String));
            devices.Columns.Add("Jobfile", typeof(System.String));
            devices.Columns.Add("Model", typeof(System.String));
            devices.Columns.Add("Serial", typeof(System.String));
            devices.Columns.Add("Version", typeof(System.String));

            //devices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //devices.Columns[0].

            devices.PrimaryKey = new DataColumn[] { id };
            DevicesGrd.DataSource = devices;
        }
        private void CreateDefaultDevices()
        {
            devices.Rows.Add(new object[] {
                0, "Command", true, false, "TcpServer", "127.0.0.1:1000",
                "CTL", "command", "Hello!", "exit()",
                true,
                "C:\\Users\\nedlecky\\GitHub\\LEonard\\LEonardClient\\bin\\Debug",
                "LEonardClient.exe",
                "",
                "",
                "",
                "",
                "test()|exit()",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                1, "UR-5eDash", true, false, "UrDashboard", "192.168.0.2:29999",
                "UR", "", "", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files\\RealVNC\\VNC Viewer",
                "vncviewer.exe",
                "C:\\Users\\nedlecky\\Desktop\\LEonardFiles\\VNC\\UR-5E.vnc",
                "stop",
                "LEonard/LEonard01.urp",
                "","","",
            });
            devices.Rows.Add(new object[] {
                2, "UR-5eCommand", true, false, "UrCommand", "192.168.0.252:30000",
                "UR", "general", "", "(999)",
                false,
                "",
                "",
                "",
                "C:\\Program Files\\RealVNC\\VNC Viewer",
                "vncviewer.exe",
                "C:\\Users\\nedlecky\\Desktop\\LEonardFiles\\VNC\\UR-5E.vnc",
                "(3,7,10,17)|(3,5,12,25000,0,0,0,0,0,0,0,25017)|(20)|(21)|(30)|(31)|(50)|(98)|(99)",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                3, "Gocator", true, false, "Gocator", "192.168.0.3:8190",
                "GO", "gocator", "", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files\\RealVNC\\VNC Viewer",
                "vncviewer.exe",
                "C:\\Users\\nedlecky\\Desktop\\LEonardFiles\\VNC\\UR-5E.vnc",
                "trigger|stop|start|loadjob,LM01|clearalignment",
                "","","",
                ""
            });
            devices.Rows.Add(new object[] {
                4, "GocatorAcc", false, false, "Gocator", "192.168.0.252:8190",
                "GO", "gocator", "", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files\\RealVNC\\VNC Viewer",
                "vncviewer.exe",
                "C:\\Users\\nedlecky\\Desktop\\LEonardFiles\\VNC\\UR-5E.vnc",
                "trigger|stop|start|loadjob,LM01|clearalignment",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                5, "Sherlock", false, false, "TcpServer", "127.0.0.1:20000",
                "AUX2S", "general", "init()", "",
                false,
                "C:\\Program Files\\Teledyne DALSA\\Sherlockx64\\Bin",
                "IpeStudio.exe",
                "",
                "",
                "",
                "",
                "GO",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                6, "HALCON", false, false, "TcpClient", "127.0.0.1:21000",
                "AUX2H", "general", "init()", "",
                true,
                "C:\\Users\\nedlecky\\AppData\\Local\\Programs\\MVTec\\HALCON-21.11-Progress\\bin\\x64-win64",
                "hdevelop.exe",
                "\"C:\\Users\\nedlecky\\Documents\\GitHub\\MVTech\\HALCON\\LE01 Socket Test (Auto).hdev\" -run",
                "",
                "",
                "",
                "GO",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                7, "Keyence", false, false, "TcpClient", "192.168.0.10:8500",
                "AUX2K", "general", "TE", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files (x86)\\KEYENCE\\CV-X Series Terminal-Software\\bin",
                "CV-X Series Terminal-Software.exe",
                "C:\\Users\\nedlecky\\Desktop\\Keyence\\ned1.cxn",
                "T1|T2",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                8, "Dataman1", true, false, "Serial", "COM3",
                "AUX31", "general", "+", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files (x86)\\Cognex\\DataMan\\DataMan Software v6.1.10_SR3",
                "SetupTool.exe",
                "",
                "+",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                9, "Dataman2", true, false, "Serial", "COM4",
                "AUX32", "general", "+", "",
                false,
                "",
                "",
                "",
                "C:\\Program Files (x86)\\Cognex\\DataMan\\DataMan Software v6.1.10_SR3",
                "SetupTool.exe",
                "",
                "+",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                10, "Chrome", false, false, "Null", "",
                "CTL", "general", "", "",
                true,
                "",
                "Chrome.exe",
                "/incognito 192.168.0.171",
                "",
                "",
                "",
                "",
                "",
                "","","",
            });
        }

        private void ClearDevicesBtn_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == ConfirmMessageBox("This will clear all existing devices. Proceed?"))
            {
                DeviceDisconnectAllBtn_Click(null, null);

                ClearAndInitializeDevices();
                if (DialogResult.OK == ConfirmMessageBox("Would you like to create the default devices?"))
                    CreateDefaultDevices();
            }
        }
        private void ReloadDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("ReloadDevicesBtn_Click");

            if (DevicesFilenameLbl.Text != "Untitled" && DevicesFilenameLbl.Text.Length > 2)
                LoadDevicesFile(DevicesFilenameLbl.Text);
        }
        int LoadDevicesFile(string name)
        {
            DeviceDisconnectAllBtn_Click(null, null);
            log.Info($"LoadDevices from {name}");
            devices = new DataTable("Devices");
            try
            {
                devices.ReadXml(name);
                DevicesGrd.DataSource = devices;
                foreach (DataGridViewColumn col in DevicesGrd.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DevicesFilenameLbl.Text = name;

                // Mark all as not connected
                foreach (DataRow row in devices.Rows)
                {
                    row["Connected"] = false;
                }
                //currentDeviceRowIndex = 0;

                // TODO this needs to be re-enabled AND needs a fail safe
                if (AutoConnectOnLoadChk.Checked)
                {
                    log.Info("Autoconnecting all devices");
                    DeviceConnectAllBtn_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Can't load {0}", name);
            }

            return 0;
        }

        private void LoadDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadDevicesBtn_Click(...)");

            string initialDirectory;
            if (DevicesFilenameLbl.Text != "Untitled" && DevicesFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(DevicesFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Devices");

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Device File",
                Filter = "*.ldev",
                InitialDirectory = initialDirectory
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadDevicesFile(dialog.FileName);
        }

        private void SaveDevicesBtn_Click(object sender, EventArgs e)
        {
            devices.AcceptChanges();

            if (DevicesFilenameLbl.Text == "Untitled" || DevicesFilenameLbl.Text == "")
                SaveAsDevicesBtn_Click(null, null);
            else
            {
                log.Info($"SaveDevices to {DevicesFilenameLbl.Text}");
                devices.WriteXml(DevicesFilenameLbl.Text, XmlWriteMode.WriteSchema, true);
            }
        }

        private void SaveAsDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveAsDevicesBtn_Click(...)");

            string initialDirectory;
            if (DevicesFilenameLbl.Text != "Untitled" && DevicesFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(DevicesFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Devices");

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Device File As...",
                Filter = "*.ldev",
                InitialDirectory = initialDirectory,
                FileName = DevicesFilenameLbl.Text,
                Extension = ".ldev"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".ldev")) filename += ".ldev";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox($"File {filename} already exists. Overwrite?"))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        DevicesFilenameLbl.Text = filename;
                        SaveDevicesBtn_Click(null, null);
                    }
                }
            }
        }

        private void SetStartupDevicesFileBtn_Click(object sender, EventArgs e)
        {
            StartupDevicesLbl.Text = DevicesFilenameLbl.Text;
            log.Info("Startup Devices file set to {0}", DevicesFilenameLbl.Text);
        }

        private void DeviceConnectAllBtn_Click(object sender, EventArgs e)
        {
            log.Info("DeviceConnectAllBtn_Click");

            for (int i = 0; i < devices.Rows.Count; i++)
            {
                DataRow row = devices.Rows[i];
                if (!(bool)row["Connected"] && (bool)row["Enabled"])
                {
                    log.Info("AUX3 Connecting {0} {1}", i, row["Name"]);
                    DeviceConnect(row);
                }
            }
        }

        private void DeviceDisconnectAllBtn_Click(object sender, EventArgs e)
        {
            log.Info("DeviceDisconnectAllBtn_Click");

            if (devices == null) return;
            for (int i = devices.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = devices.Rows[i];
                if ((bool)row["Connected"])
                {
                    log.Info("Disconnecting {0} {1}", currentDeviceRowIndex, row["Name"]);

                    DeviceDisconnect(row);
                }
            }
        }
        private int DeviceConnect(DataRow row)
        {
            int ID = (int)row["ID"];
            bool enabled = (bool)row["Enabled"];
            string name = (string)row["Name"];
            string deviceType = (string)row["DeviceType"];
            string address = (string)row["Address"];
            string messageTag = (string)row["MessageTag"];
            string callBack = (string)row["CallBack"];
            string onConnectSend = (string)row["OnConnectSend"];
            bool connected = (bool)row["Connected"];
            string jobFile = (string)row["Jobfile"];

            if (connected)
            {
                //ErrorMessageBox($"Device {name} already connected");
                return 1;
            }

            if (!enabled)
            {
                DialogResult result = ConfirmMessageBox($"Device {name} is not enabled. Enable?");
                if (result != DialogResult.OK)
                    return 2;
                row["Enabled"] = true;
            }

            log.Info($"Connect {ID}:{name} as {deviceType} at {address} with {messageTag}, {callBack}");

            // Runtime needed to start up first?
            void StartOptionalRuntime()
            {
                if ((bool)row["RuntimeAutostart"])
                    DeviceRuntimeStartBtn_Click(null, null);
            }

            // Instantiate device interface object
            switch (deviceType)
            {
                case "TcpServer":
                    interfaces[ID] = new LeTcpServer(this, messageTag, onConnectSend);
                    StartOptionalRuntime();
                    interfaces[ID].Connect(address);
                    break;
                case "TcpClient":
                    interfaces[ID] = new LeTcpClient(this, messageTag, onConnectSend);
                    StartOptionalRuntime();
                    interfaces[ID].Connect(address);
                    break;
                case "TcpClientAsync":
                    interfaces[ID] = new LeTcpClientAsync(this, messageTag, onConnectSend);
                    StartOptionalRuntime();
                    interfaces[ID].Connect(address);
                    break;
                case "UrDashboard":
                    LeUrDashboard robot = new LeUrDashboard(this, messageTag, onConnectSend);
                    robot.UrProgramFilename = jobFile;
                    interfaces[ID] = robot;
                    StartOptionalRuntime();
                    if (focusLeUrDashboard == null)
                    {
                        log.Info($"Setting focusLeUrDashboard to {name} in row {currentDeviceRowIndex}");
                        focusLeUrDashboard = robot;
                    }
                    if (0 == robot.Connect(address))
                    {
                        row["Model"] = UrDashboardInquiryResponse("get robot model", 200);
                        row["Serial"] = UrDashboardInquiryResponse("get serial number", 200);
                        row["Version"] = UrDashboardInquiryResponse("PolyscopeVersion", 200);
                        //focusLeUrDashboard.InquiryResponse("stop", 200);
                    }
                    break;
                case "UrCommand":
                    LeUrCommand command = new LeUrCommand(this, messageTag, onConnectSend);
                    interfaces[ID] = command;
                    StartOptionalRuntime();
                    if (focusLeUrCommand == null)
                    {
                        log.Info($"Setting focusLeUrCommand to {name} in row {currentDeviceRowIndex}");
                        focusLeUrCommand = command;
                    }
                    command.Connect(address);
                    break;
                case "Gocator":
                    LeGocator gocator = new LeGocator(this, messageTag, onConnectSend);
                    interfaces[ID] = gocator;
                    StartOptionalRuntime();
                    if (focusLeGocator == null)
                    {
                        log.Info($"Setting focusGocator to {name} in row {currentDeviceRowIndex}");
                        focusLeGocator = gocator;
                    }
                    gocator.Connect(address);
                    break;
                case "Serial":
                    interfaces[ID] = new LeSerial(this, messageTag, onConnectSend);
                    StartOptionalRuntime();
                    interfaces[ID].Connect(address);
                    break;
                case "Null":
                    interfaces[ID] = new LeDevNull(this, messageTag, onConnectSend);
                    StartOptionalRuntime();
                    interfaces[ID].Connect(address);
                    break;
                default:
                    ErrorMessageBox($"Device {deviceType} does not exist");
                    return 3;
            }

            if (!interfaces[ID].IsConnected())
                return 4;

            // Install desired callback
            switch (callBack)
            {
                case "":
                    break;
                case "command":
                    interfaces[ID].receiveCallback = CommandCallback;
                    break;
                case "general":
                    interfaces[ID].receiveCallback = GeneralCallback;
                    break;
                case "gocator":
                    if (deviceType != "Gocator")
                        ErrorMessageBox($"Device {deviceType} can't use callback {callBack}");
                    else
                        interfaces[ID].receiveCallback = ((LeGocator)(interfaces[ID])).Callback;
                    break;
                case "alt1":
                    interfaces[ID].receiveCallback = AlternateCallback1;
                    break;
                default:
                    ErrorMessageBox($"Device {deviceType} callback {callBack} does not exist.");
                    break;
            }

            row["Connected"] = true;

            return 0;
        }
        private void DeviceConnectBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            DeviceConnect(row);
        }

        private void DeviceDisconnect(DataRow row)
        {
            if (!(bool)row["Connected"])
            {
                //ErrorMessageBox($"Device {row["Name"]} already disconnected.");
                return;
            }

            int ID = (int)row["ID"];

            log.Info("Disconnecting {0}", (string)row["Name"]); ;
            row["Connected"] = false;
            if (interfaces[ID] != null)
            {
                string onDisconnectSend = (string)row["OnDisconnectSend"];
                if (onDisconnectSend.Length > 0)
                    try
                    {
                        interfaces[ID].Send(onDisconnectSend);
                    }
                    catch
                    {

                    }

                interfaces[ID].Disconnect();

                // Clear out any focus devices
                if (focusLeUrDashboard == interfaces[ID]) focusLeUrDashboard = null;
                if (focusLeUrCommand == interfaces[ID]) focusLeUrCommand = null;
                if (focusLeGocator == interfaces[ID]) focusLeGocator = null;

                interfaces[ID] = null;
                GC.Collect();
            }
        }
        private void DeviceDisconnectBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            DeviceDisconnect(row);
        }

        private void DeviceReconnectBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];


            string name = (string)row["Name"];
            bool connected = (bool)row["Connected"];
            string address = (string)row["Address"];

            if (!connected)
            {
                ErrorMessageBox($"Device {name} already disconnected");
                return;
            }

            log.Info($"Reconnecting {name}"); ;
            if (interfaces[currentDeviceRowIndex] != null)
            {
                interfaces[currentDeviceRowIndex].Connect(address);
            }
        }
        void SetWindowOnTop(IntPtr hWnd)
        {
            log.Info("SetWindowOnTop({0})", hWnd);
            // TODO: The SetWindowPos constants below should be defined!
            SetWindowPos(hWnd, (System.IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0040);
        }

        private void DeviceRuntimeStartBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            ProcessStartInfo start = new ProcessStartInfo();

            start.WorkingDirectory = (string)row["RuntimeWorkingDirectory"];
            start.FileName = (string)row["RuntimeFileName"];
            start.Arguments = (string)row["RuntimeArguments"];

            if (interfaces[currentDeviceRowIndex] == null)
                log.Error("Device not connected");
            else
            {
                interfaces[currentDeviceRowIndex].StartRuntimeProcess(start);

                // TODO: This wait for start is a little kludgey
                //PromptOperator("Waiting for app to start...", false, false);


                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    try
                    {
                        // TODO
                        //log.Error($"ERROR UNKNOWN HERE");

                        IntPtr hWnd = interfaces[currentDeviceRowIndex].runtimeProcess.MainWindowHandle;
                        Application.DoEvents();
                        if (hWnd != (IntPtr)0)
                        {
                            SetWindowOnTop(hWnd);
                            break;
                        }

                    }
                    catch
                    {
                        log.Error($"Cannot find hWnd");
                    }
                }

                //waitingForOperatorMessageForm.Close();
                //waitingForOperatorMessageForm = null;
            }
        }

        private void DeviceRuntimeRestoreBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            if (interfaces[currentDeviceRowIndex] != null)
                if (interfaces[currentDeviceRowIndex].runtimeProcess != null)
                {
                    ShowWindowAsync(interfaces[currentDeviceRowIndex].runtimeProcess.MainWindowHandle, SW_RESTORE);
                    SetWindowOnTop(interfaces[currentDeviceRowIndex].runtimeProcess.MainWindowHandle);
                }
        }

        private void DeviceRuntimeMinimizeBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];
            if (interfaces[currentDeviceRowIndex] != null)
                if (interfaces[currentDeviceRowIndex].runtimeProcess != null)
                    ShowWindowAsync(interfaces[currentDeviceRowIndex].runtimeProcess.MainWindowHandle, SW_SHOWMINIMIZED);
        }

        private void DeviceRuntimeExitBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }

            if (interfaces[currentDeviceRowIndex] != null)
                interfaces[currentDeviceRowIndex].EndRuntimeProcess();
        }

        private void DeviceSetupStartBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            ProcessStartInfo start = new ProcessStartInfo();

            start.WorkingDirectory = (string)row["SetupWorkingDirectory"];
            start.FileName = (string)row["SetupFileName"];
            start.Arguments = (string)row["SetupArguments"];

            if (interfaces[currentDeviceRowIndex] == null)
                log.Error("Device not running");
            else
            {
                interfaces[currentDeviceRowIndex].StartSetupProcess(start);

                // TODO: This wait for start is a little kludgey
                PromptOperator("Waiting for app to start...", false, false);
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(100);
                    IntPtr hWnd = interfaces[currentDeviceRowIndex].setupProcess.MainWindowHandle;
                    Application.DoEvents();
                    if (hWnd != (IntPtr)0)
                    {
                        SetWindowOnTop(hWnd);
                        break;
                    }
                }
                waitingForOperatorMessageForm.Close();
                waitingForOperatorMessageForm = null;
            }


        }

        private void DeviceSetupRestoreBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            if (interfaces[currentDeviceRowIndex] != null)
                if (interfaces[currentDeviceRowIndex].setupProcess != null)
                {
                    ShowWindowAsync(interfaces[currentDeviceRowIndex].setupProcess.MainWindowHandle, SW_RESTORE);
                    SetWindowOnTop(interfaces[currentDeviceRowIndex].setupProcess.MainWindowHandle);
                }
        }

        private void DeviceSetupMinimizeBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            DataRow row = devices.Rows[currentDeviceRowIndex];

            if (interfaces[currentDeviceRowIndex] != null)
                if (interfaces[currentDeviceRowIndex].setupProcess != null)
                    ShowWindowAsync(interfaces[currentDeviceRowIndex].setupProcess.MainWindowHandle, SW_SHOWMINIMIZED);
        }

        private void DeviceSetupExitBtn_Click(object sender, EventArgs e)
        {
            if (currentDeviceRowIndex < 0)
            {
                ErrorMessageBox("Please select a device in the device table.");
                return;
            }
            if (interfaces[currentDeviceRowIndex] != null)
                interfaces[currentDeviceRowIndex].EndSetupProcess();
        }
        private void SpeedSendBtn1_Click(object sender, EventArgs e)
        {
            log.Info($"Clicked {((Button)sender).Text}");
            if (interfaces[currentDeviceRowIndex] == null) return;

            interfaces[currentDeviceRowIndex].Send(((Button)sender).Text);
        }

        private void DevicesGrd_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Minimize old apps
            //MinimizeRuntimeBtn_Click(null, null);
            //MinimizeSetupBtn_Click(null, null);

            currentDeviceRowIndex = e.RowIndex;

            // Clear existing SendSpeed buttons except first
            for (int i = 1; i < speedSendBtns.Count; i++)
                speedSendBtns[i].Dispose();

            speedSendBtns.Clear();

            // Nothing specified: leave the anchor button on the screen blank and disabled
            string speedButtons = (string)(devices.Rows[currentDeviceRowIndex])["SpeedSendButtons"];
            if (speedButtons.Length < 1)
            {
                SpeedSendBtn1.Text = "";
                SpeedSendBtn1.Enabled = false;

                return;
            }

            // Multiple buttons text specified as str1|str2|str3...
            string[] buttonTextArray = speedButtons.Split('|');

            int x = SpeedSendBtn1.Left;
            int y = SpeedSendBtn1.Top;
            int width = SpeedSendBtn1.Width;
            int height = SpeedSendBtn1.Height;
            int tabStart = SpeedSendBtn1.TabIndex;
            speedSendBtns.Add(SpeedSendBtn1);
            SpeedSendBtn1.Text = buttonTextArray[0];
            SpeedSendBtn1.Enabled = true;
            for (int i = 1; i < buttonTextArray.Length; i++)
            {
                Button b = new Button();
                b.Location = new System.Drawing.Point(x + (width + 5) * i, y);
                b.Name = "SpeedSendBtn" + i + 1;
                b.Size = new System.Drawing.Size(width, height);
                b.TabIndex = tabStart + i;
                b.Text = buttonTextArray[i];
                b.UseVisualStyleBackColor = true;
                b.Click += new System.EventHandler(SpeedSendBtn1_Click);

                // TODO does this set the correct size??
                ControlInfo controlInfo = new ControlInfo();
                controlInfo.originalFont = SpeedSendBtn1.Font;
                b.Tag = controlInfo;

                speedSendBtns.Add(b);
                speedBtnsGrp.Controls.Add(b);
            }

            // Bring apps to fore
            DeviceRuntimeRestoreBtn_Click(null, null);
            DeviceSetupRestoreBtn_Click(null, null);

        }

        // Standard callback supporting executing all languages
        // Multiple Statements:
        //          statement1#statement2#statement3
        // Statements
        //      LE:command      Sent to LEscript ExecuteLine
        //      JE:command      Sent to ExecuteJavaScript
        //      PE:command      Sent to ExecutePythonScript
        //      name = value    Sent to WriteVariable
        //      SET name value  Sent to WriteVariable
        public void GeneralCallback(string prefix, string message, LeDeviceInterface dev)
        {
            log.Info($"GeneralCallback({prefix},{message},{dev})");

            // TODO This gets broken if the user tries to do anything else with '#'
            string[] statements = message.Split('#');
            foreach (string statement in statements)
                GeneralCallbackStatementExecute(prefix, statement, dev);
        }

        void DashboardCallback(string prefix, string message)
        {
            log.Debug($"{prefix}<== {message}");
        }

        // Callback used for LEonardClient and remote control
        void CommandCallback(string prefix, string message, LeDeviceInterface dev)
        {
            log.Info($"CCB<==({prefix}, {message})");
            // Nothing special for now
            GeneralCallback(prefix, message, dev);
        }

        void AlternateCallback1(string message, string prefix, LeDeviceInterface dev)
        {
            log.Info($"DCB<==({prefix},{message})");
            string[] s = message.Split(',');
            if (s.Length == 3)
            {
                string name = s[0];
                string sequence = s[1];
                string value = s[2];
                WriteVariable(prefix + "_name", name);
                WriteVariable(prefix + "_sequence", sequence);
                WriteVariable(prefix + "_value", value);
            }
            else
                log.Error("{0} ERROR unexpected string received: {1}", prefix, message);
        }

    }
}
