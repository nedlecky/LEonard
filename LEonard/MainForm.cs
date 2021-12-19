using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;
using System.Text.RegularExpressions;
using NLog;
using System.Runtime.InteropServices;

namespace LEonard
{
    public partial class MainForm : Form
    {
        static string LEonardRoot = "./";
        static DataTable devices;
        static DataTable variables;

        static SplashForm splashForm;

        BarcodeReaderThread bcrt;

        // TODO: This needs to dynamically resize!
        LeDeviceInterface[] interfaces = { null };//, null, null, null, null, null, null, null };

        private static NLog.Logger log;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string companyName = Application.CompanyName;
            string appName = Application.ProductName;
            string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string executable = Application.ExecutablePath;
            string filename = Path.GetFileName(executable);
            string directory = Path.GetDirectoryName(executable);
            string caption = companyName + " " + appName + " " + productVersion;
#if DEBUG
            caption += " RUNNING IN DEBUG MODE";
#endif
            this.Text = caption;

            log = NLog.LogManager.GetCurrentClassLogger();

            LoadConfigBtn_Click(null, null);

            for (int i = 0; i < 3; i++)
                log.Info("==============================================================================================");
            log.Info(string.Format("Starting {0} in [{1}]", filename, directory));


            if (StartupJavaScriptLbl.Text.Length > 0)
            {
                LoadDevicesFile(StartupDevicesLbl.Text);
            }
            if (StartupJavaScriptLbl.Text.Length > 0)
            {
                LoadJavaScriptProgramFile(StartupJavaScriptLbl.Text);
            }

            HeartbeatTmr.Interval = 1000;
            HeartbeatTmr.Enabled = true;
            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;
            StartupTmr.Interval = 200;
            StartupTmr.Enabled = true;
        }

        bool forceClose = false;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (forceClose) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you want to close the application?",
                                    "LEonard Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
                e.Cancel = (result == DialogResult.No);
            }

            if (!e.Cancel)
            {
                // Check on dirty JavaScript program
                if (JavaScriptCodeRTB.Modified)
                {
                    var result = MessageBox.Show("JavaScript modified. Save before closing?",
                                        "LEonard Confirmation",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SaveJavaProgramBtn_Click(null, null);
                    }
                }

                CloseTmr.Interval = 500;
                CloseTmr.Enabled = true;
                e.Cancel = true; // Cancel this shutdown- we'll let the close out timer shut us down
                log.Info("Shutting down in 500mS...");
            }
        }

        private void StartThreads()
        {
            log.Info("StartThreads()...");

            //bcrt = new BarcodeReaderThread(this, interfaces[4], interfaces[5]);
            //bcrt.Enable(BarcodeReaderThreadChk.Checked);
            //bcrt.Start();
        }
        private void EndThreads()
        {
            log.Info("EndThreads()...");

            if (bcrt != null)
            {
                bcrt.End();
                bcrt = null;
            }
        }
        private void StartupTmr_Tick(object sender, EventArgs e)
        {
            splashForm = new SplashForm();
            splashForm.Show();

            log.Info("StartupTmr()...");
            StartupTmr.Enabled = false;

            StartThreads();
            StartJint();
            log.Info("System ready.");


            if (AutoStartChk.Checked)
            {
                log.Info("Autostarting all devices");
                StartAllDevicesBtn_Click(null, null);
            }
        }

        private void HeartbeatTmr_Tick(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("s");
            //TimeLbl.Text = now;
            toolStripStatusLabel1.Text = now;
        }
        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            // TODO: do we really need to keep polling for message receipt?
            if (interfaces.Length == 0) return;

            foreach (LeDeviceInterface device in interfaces)
                if (device != null) device.Receive();
        }

        private void AllLogClearBtn_Click(object sender, EventArgs e)
        {
            AllLogRTB.Clear();
        }

        private void ErrorLogClearBtn_Click(object sender, EventArgs e)
        {
            ErrorLogRTB.Clear();
        }

        private void ControlLogClearBtn_Click(object sender, EventArgs e)
        {
            ControlLogRTB.Clear();
        }
        private void Aux1ClearBtn_Click(object sender, EventArgs e)
        {
            Aux1LogRTB.Clear();
        }

        private void Aux2ClearBtn_Click(object sender, EventArgs e)
        {
            Aux2LogRTB.Clear();
        }
        private void Aux3ClearBtn_Click(object sender, EventArgs e)
        {
            Aux3LogRTB.Clear();
        }
        private void JavaScriptConsoleClearRTB_Click(object sender, EventArgs e)
        {
            JavaScriptConsoleRTB.Clear();
        }


        int fireCounter = 0;
        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            // First time this fires, tell all the threads to stop
            if (++fireCounter == 1)
                EndThreads();
            else
            {
                // Second time it fires, we can disconnect and shut down!
                CloseTmr.Enabled = false;
                StopAllDevicesBtn_Click(null, null);
                StopJint();
                MessageTmr_Tick(null, null);
                forceClose = true;
                SaveConfigBtn_Click(null, null);
                NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
                this.Close();
            }
        }

        // TODO: Clean these up, use consistent string formatting ideas, and the variables
        // TODO All of these... the variable name should be prefixed with the unique device name not the message prefix
        // Currently expect 0 or more comma-=separated {script} or name=value sequences
        // Examples:
        // return1=abc
        // return1=abc#return2=xyz
        // {print('received it');}
        // {print('received it');}#var2=50
        // SET name value
        void GeneralCallBack(string message, string prefix)
        {
            //log.Info("GCB<==({0},{1})", message, prefix);

            string[] requests = message.Split('#');
            foreach (string request in requests)
            {
                // {script.....}
                if (request.StartsWith("{") && request.EndsWith("}"))
                    ExecuteJavaScript(request.Substring(1, request.Length - 2));
                else
                {
                    // name=value
                    // TODO not clear what happens if you have
                    //      name = value
                    //      name = this is a test
                    //      name = "this is a test"
                    if (request.Contains("="))
                        WriteVariable(request);
                    else
                    {
                        // SET name value
                        if (request.StartsWith("SET "))
                        {
                            string[] s = request.Split(' ');
                            if (s.Length == 3)
                                WriteVariable(s[1], s[2]);
                            else
                                log.Error("{0} Illegal SET statement: {1}", prefix, request);
                        }
                        else
                            log.Error("{0} Illegal GCB command: {1}", prefix, request);
                    }
                }
            }
        }

        void CommandCallBack(string message, string prefix)
        {
            //log.Info("CCB<==({0},{1})", message, prefix);

            if (message.Length > 3 && message.StartsWith("JS:"))
                ExecuteJavaScript(message.Substring(3));
            else
            {

                string[] s = message.Split(',');
                string response = "INVALID COMMAND";
                if (s.Length == 3)
                {
                    string name = s[0];
                    string sequence = s[1];
                    string parameters = s[2];

                    WriteVariable(prefix + "_name", name);
                    WriteVariable(prefix + "_sequence", sequence);
                    WriteVariable(prefix + "_params", parameters);

                    // TODO: Execute

                    response = string.Format("{0},{1},{2}", name, sequence, "RESPONSE");
                }

                interfaces[0].Send(response);
            }
        }

        void DatamanCallBack(string message, string prefix)
        {
            //log.Info("DCB<==({0},{1})", message, prefix);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ***********************************************************************
        // CONFIG UI
        // ***********************************************************************

        void LoadPersistent()
        {
            // Pull setup info from registry.... these are overwritten on exit or with various config save operations
            // Note default values are specified here as well
            log.Info("LoadPersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");

            Left = (Int32)AppNameKey.GetValue("Left", 0);
            Top = (Int32)AppNameKey.GetValue("Top", 100);

            LEonardRoot = (string)AppNameKey.GetValue("LEonardRoot", "\\");
            LEonardRootLbl.Text = LEonardRoot;

            StartupDevicesLbl.Text = (string)AppNameKey.GetValue("StartupDevicesLbl.Text", "");
            AutoStartChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoStartChk.Checked", "False"));

            StartupJavaScriptLbl.Text = (string)AppNameKey.GetValue("StartupJavaScriptLbl.Text", "");

            UtcTimeChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("UtcTimeChk.Checked", "True"));

            PersonalityTabs.SelectedIndex = (Int32)AppNameKey.GetValue("PersonalityTabs.SelectedIndex", 0);

            // Also load the variables table
            LoadVariablesBtn_Click(null, null);
        }

        void SavePersistent()
        {
            log.Info("SavePersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");

            AppNameKey.SetValue("Left", Left);
            AppNameKey.SetValue("Top", Top);

            AppNameKey.SetValue("LEonardRoot", LEonardRoot);

            AppNameKey.SetValue("StartupDevicesLbl.Text", StartupDevicesLbl.Text);
            AppNameKey.SetValue("AutoStartChk.Checked", AutoStartChk.Checked);

            AppNameKey.SetValue("StartupJavaScriptLbl.Text", StartupJavaScriptLbl.Text);

            AppNameKey.SetValue("UtcTimeChk.Checked", UtcTimeChk.Checked);

            AppNameKey.SetValue("PersonalityTabs.SelectedIndex", PersonalityTabs.SelectedIndex);

            // Also save the variables table
            SaveVariablesBtn_Click(null, null);
        }
        private void ChangeLEonardRootBtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                log.Info("New LEonardRoot={0}", dialog.SelectedPath);
                LEonardRoot = dialog.SelectedPath;
                LEonardRootLbl.Text = LEonardRoot;
            }

        }

        private void ChangeStartupDevicesBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Startup LEonard Devices File";
            dialog.Filter = "Device files|*.dev";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StartupDevicesLbl.Text = dialog.FileName;
                log.Info("Startup Devices file set to {0}", StartupDevicesLbl.Text);

                if (MessageBox.Show("Load this file now?", "LEonard Confiormation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LoadDevicesFile(StartupDevicesLbl.Text);
            }
        }

        private void ChangeStartupJavaScriptBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Startup LEonard Program File";
            dialog.Filter = "Program files|*.js";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StartupJavaScriptLbl.Text = dialog.FileName;
                log.Info("Startup JavaScript program set to {0}", StartupJavaScriptLbl.Text);

                if (MessageBox.Show("Load this program now?", "LEonard Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LoadJavaScriptProgramFile(StartupJavaScriptLbl.Text);
            }
        }



        private void DefaultConfigBtn_Click(object sender, EventArgs e)
        {
            LEonardRoot = "";
            LEonardRootLbl.Text = LEonardRoot;
            StartupDevicesLbl.Text = "";
            AutoStartChk.Checked = false;
            StartupJavaScriptLbl.Text = "";
            UtcTimeChk.Checked = true;
        }

        private void LoadConfigBtn_Click(object sender, EventArgs e)
        {
            LoadPersistent();
        }

        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            SavePersistent();
        }

        // ***********************************************************************
        // END CONFIG UI
        // ***********************************************************************




        // ***********************************************************************
        // DEVICES UI
        // ***********************************************************************
        private void DefaultDevicesBtn_Click(object sender, EventArgs e)
        {
            devices = new DataTable("Devices");

            DataColumn id = devices.Columns.Add("ID", typeof(System.Int32));
            devices.Columns.Add("Name", typeof(System.String));
            devices.Columns.Add("Running", typeof(System.Boolean));
            devices.Columns.Add("DeviceType", typeof(System.String));
            devices.Columns.Add("Address", typeof(System.String));
            devices.Columns.Add("MessageTag", typeof(System.String));
            devices.Columns.Add("CallBack", typeof(System.String));
            devices.Columns.Add("OnConnectSend", typeof(System.String));
            devices.Columns.Add("OnDisconnectSend", typeof(System.String));
            devices.Columns.Add("RuntimeWorkingDirectory", typeof(System.String));
            devices.Columns.Add("RuntimeFileName", typeof(System.String));
            devices.Columns.Add("RuntimeArguments", typeof(System.String));
            devices.Columns.Add("SetupWorkingDirectory", typeof(System.String));
            devices.Columns.Add("SetupFileName", typeof(System.String));
            devices.Columns.Add("SetupArguments", typeof(System.String));

            //devices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //devices.Columns[0].

            devices.PrimaryKey = new DataColumn[] { id };

            // HALCON Direct WORKS
            // start.FileName = "C:\\Users\\nedlecky\\AppData\\Local\\Programs\\MVTec\\HALCON-21.11-Progress\\bin\\x64-win64\\hdevelop.exe";
            // start.Arguments = "\"C:\\Users\\nedlecky\\Documents\\GitHub\\MVTech\\HALCON\\LE01 Socket Test (Auto).hdev\" -run";

            // DATAMAN Direct WORKS
            //start.WorkingDirectory = "C:\\Program Files (x86)\\Cognex\\DataMan\\DataMan Software v6.1.10_SR3";
            //start.FileName = "SetupTool.exe";
            //start.Arguments = "";

            // HALCON Through Link WORKS
            //start.FileName = Path.Combine(LEonardRoot, "Shortcuts", "MVTec HDevelop XL 21.11 Progress (user).lnk");

            // DATAMAN Through Link WORKS
            //start.FileName = Path.Combine(LEonardRoot, "Shortcuts", "v6.1.10_SR3 Setup Tool.lnk");

            // Sherlock Through Link MIN/REST/Exit don't work
            //start.FileName = Path.Combine(LEonardRoot, "Shortcuts", "Sherlockx64.lnk");

            // Sherlock Direct MIN/REST/Exit don't work
            //start.WorkingDirectory = "C:\\Program Files\\Teledyne DALSA\\Sherlockx64\\Bin";
            //start.FileName = "IpeStudio.exe";

            // KEYENCE Simulator Direct WORKS
            //start.WorkingDirectory = "C:\\Program Files (x86)\\KEYENCE\\CV-X Series Simulation-Software\\bin_X400";
            //start.FileName = "CV-X Series Workspace-Software.exe";

            // KEYENCE Terminal Direct WORKS
            //start.WorkingDirectory = "C:\\Program Files (x86)\\KEYENCE\\CV-X Series Terminal-Software\\bin";
            //start.FileName = "CV-X Series Terminal-Software.exe";
            //start.Arguments = "C:\\Users\\nedlecky\\Desktop\\Keyence\\ned1.cxn";

            devices.Rows.Add(new object[] {
                0, "Command", false, "TcpServer", "127.0.0.1:1000",
                "CTL", "general", "Hello!", "exit()",
                "C:\\Users\\nedlecky\\Documents\\GitHub\\LEonard\\LEonardClient\\bin\\Debug",
                "LEonardClient.exe",
                "",
                "",
                "",
                ""});
            devices.Rows.Add(new object[] {
                1, "UR-5e", false, "TcpServer", "192.168.0.252:30000",
                "AUX1", "general", "", "(98,0,0,0,0)",
                "",
                "",
                "",
                "",
                "",
                ""});
            devices.Rows.Add(new object[] {
                2, "Sherlock", false, "TcpServer", "127.0.0.1:20000",
                "AUX2S", "general", "init()", "",
                "C:\\Program Files\\Teledyne DALSA\\Sherlockx64\\Bin",
                "IpeStudio.exe",
                "",
                "",
                "",
                ""});
            devices.Rows.Add(new object[] {
                3, "HALCON", false, "TcpClient", "127.0.0.1:21000",
                "AUX2H", "general", "init()", "",
                "C:\\Users\\nedlecky\\AppData\\Local\\Programs\\MVTec\\HALCON-21.11-Progress\\bin\\x64-win64",
                "hdevelop.exe",
                "\"C:\\Users\\nedlecky\\Documents\\GitHub\\MVTech\\HALCON\\LE01 Socket Test (Auto).hdev\" -run",
                "",
                "",
                ""});
            devices.Rows.Add(new object[] {
                4, "Keyence", false, "TcpClient", "192.168.0.10:8500",
                "AUX2K", "general", "TE", "",
                "",
                "",
                "",
                "C:\\Program Files (x86)\\KEYENCE\\CV-X Series Terminal-Software\\bin",
                "CV-X Series Terminal-Software.exe",
                "C:\\Users\\nedlecky\\Desktop\\Keyence\\ned1.cxn" });
            devices.Rows.Add(new object[] {
                5, "Dataman 1", false, "Serial", "COM3",
                "AUX31", "general", "+", "",
                "",
                "",
                "",
                "C:\\Program Files (x86)\\Cognex\\DataMan\\DataMan Software v6.1.10_SR3",
                "SetupTool.exe",
                ""});
            devices.Rows.Add(new object[] {
                6, "Dataman 2", false, "Serial", "COM4",
                "AUX32", "general", "+", "",
                "",
                "",
                "",
                "C:\\Program Files (x86)\\Cognex\\DataMan\\DataMan Software v6.1.10_SR3",
                "SetupTool.exe",
                ""});

            DevicesGrid.DataSource = devices;
        }

        int LoadDevicesFile(string name)
        {
            log.Info("LoadDevices from {0}", name);
            devices = new DataTable("Devices");
            devices.ReadXml(name);
            DevicesGrid.DataSource = devices;
            DevicesFilenameLbl.Text = name;

            return 0;
        }
        private void LoadDevicesBtn_Click(object sender, EventArgs e)
        {
            // TODO: Need to close everyone down!
            // TODOP: Does the call below handle it?
            StopAllDevicesBtn_Click(null, null);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open a LEonard Devices File";
            dialog.Filter = "Device files|*.dev";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadDevicesFile(dialog.FileName);
            }
        }
        private void SaveDevicesBtn_Click(object sender, EventArgs e)
        {
            devices.AcceptChanges();

            if (DevicesFilenameLbl.Text == "Untitled" || DevicesFilenameLbl.Text == "")
                SaveAsDevicesBtn_Click(null, null);
            else
            {
                log.Info("SaveDevices to {0}", DevicesFilenameLbl.Text);
                devices.WriteXml(DevicesFilenameLbl.Text, XmlWriteMode.WriteSchema, true);
            }
        }
        private void SaveAsDevicesBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "LEonard Devices|*.dev";
            dialog.Title = "Save a LEonard devices File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    DevicesFilenameLbl.Text = dialog.FileName;
                    SaveDevicesBtn_Click(null, null);
                }
            }
        }
        private void StartAllDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("StartAllDevices_Click(...)");
            foreach (DataRow row in devices.Rows)
            {
                row["Running"] = true;

                int rowIndex = (int)row["ID"];
                // TODO: Don't like the fixed column number 2 for Running below
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(2, rowIndex);
                DeviceGrid_CellValueChanged(null, e2);
                Application.DoEvents();
            }
        }

        private void StopAllDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("StopAllDevices_Click(...)");
            foreach (DataRow row in devices.Rows)
            {
                row["Running"] = false;
                int rowIndex = (int)row["ID"];

                // TODO: Don't like the fixed column number 2 for Running below
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(2, rowIndex);
                DeviceGrid_CellValueChanged(null, e2);
                Application.DoEvents();
            }
        }

        private void DeviceGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            log.Debug("Deleting Row");

            DefaultDevicesBtn.Enabled = true;
            LoadDevicesBtn.Enabled = true;
            SaveDevicesBtn.Enabled = true;
            SaveAsDevicesBtn.Enabled = true;

        }

        int currentDevice = -1;
        private void DeviceGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentDevice = e.RowIndex;
        }

        private void DeviceGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            // TODO: Magic column numbers below are horrible
            int index = Convert.ToInt32(devices.Rows[row].ItemArray[0].ToString());
            string name = devices.Rows[row].ItemArray[1].ToString();
            string type = devices.Rows[row].ItemArray[3].ToString();
            string address = devices.Rows[row].ItemArray[4].ToString();
            string prefix = devices.Rows[row].ItemArray[5].ToString();
            string callback = devices.Rows[row].ItemArray[6].ToString();
            string connectMessage = devices.Rows[row].ItemArray[7].ToString();

            log.Debug("Changed Value: {0}", devices.Rows[row].ItemArray[col].ToString());

            // Make sure array is large enough
            while (index > interfaces.Length - 1)
            {
                log.Debug("Appending {0} {1}", index, interfaces.Length);
                interfaces.Append(new LeTcpServer(this, prefix));
            }

            // TODO: Don't like this index == 2 below... how to use column name Running?
            if (col == 2)
            {
                if (devices.Rows[row].ItemArray[col].ToString() == "True")
                {
                    log.Info("Start {0}:{1} as {2} at {3} with {4}, {5}", index, name, type, address, prefix, callback);
                    switch (type)
                    {
                        case @"TcpServer":
                            interfaces[index] = new LeTcpServer(this, prefix, connectMessage);
                            interfaces[index].Connect(address);
                            break;
                        case @"TcpClient":
                            interfaces[index] = new LeTcpClient(this, prefix, connectMessage);
                            interfaces[index].Connect(address);
                            break;
                        case @"Serial":
                            interfaces[index] = new LeSerial(this, prefix, connectMessage);
                            interfaces[index].Connect(address);
                            break;
                        default:
                            log.Error("Illegal interface type: {0}", type);
                            break;
                    }

                    // TODO: Callbacks
                    switch (callback)
                    {
                        case "":
                            break;
                        case "general":
                            interfaces[index].receiveCallback = GeneralCallBack;
                            break;
                        case "command":
                            interfaces[index].receiveCallback = CommandCallBack;
                            break;
                        case "dataman":
                            interfaces[index].receiveCallback = DatamanCallBack;

                            break;
                        default:
                            log.Error("Illegal callback type: {0}", type);
                            break;
                    }
                }
                else
                {
                    log.Info("Stop {0}", name);
                    if (interfaces[index] != null)
                    {
                        // TODO: Magic column number 8 is horrible
                        string onDisconnectSend = devices.Rows[row].ItemArray[8].ToString();
                        if (onDisconnectSend.Length > 0)
                            try
                            {
                                interfaces[index].Send(onDisconnectSend);
                            }
                            catch
                            {

                            }

                        interfaces[index].Disconnect();
                        interfaces[index] = null;
                        GC.Collect();
                    }
                }
            }

        }


        private void DeviceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeviceGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            log.Debug("CellBeginEdit: {0}", devices.Rows[row].ItemArray[col].ToString());

        }

         private void LaunchRuntimeBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];

            ProcessStartInfo start = new ProcessStartInfo();

            start.WorkingDirectory = (string)row["RuntimeWorkingDirectory"];
            start.FileName = (string)row["RuntimeFileName"]; 
            start.Arguments = (string)row["RuntimeArguments"];

            if (interfaces[ID] == null)
                log.Error("Device not running");
            else
                interfaces[ID].StartRuntimeProcess(start);
        }

        /*
        #define SW_HIDE             0
        #define SW_SHOWNORMAL       1
        #define SW_NORMAL           1
        #define SW_SHOWMINIMIZED    2
        #define SW_SHOWMAXIMIZED    3
        #define SW_MAXIMIZE         3
        #define SW_SHOWNOACTIVATE   4
        #define SW_SHOW             5
        #define SW_MINIMIZE         6
        #define SW_SHOWMINNOACTIVE  7
        #define SW_SHOWNA           8
        #define SW_RESTORE          9
        #define SW_SHOWDEFAULT      10
        #define SW_FORCEMINIMIZE    11
        #define SW_MAX              11
        */
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNORMAL = 5;
        private const int SW_RESTORE = 9;

        private void MinimizeRuntimeBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                if(interfaces[ID].runtimeProcess != null)
                    ShowWindowAsync(interfaces[ID].runtimeProcess.MainWindowHandle, SW_SHOWMINIMIZED);
        }

        private void RestoreRuntimeBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                if(interfaces[ID].runtimeProcess != null)
                    ShowWindowAsync(interfaces[ID].runtimeProcess.MainWindowHandle, SW_RESTORE);
        }

        private void ExitRuntimeBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                interfaces[ID].EndRuntimeProcess();
        }

        private void LaunchSetupBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];

            ProcessStartInfo start = new ProcessStartInfo();

            start.WorkingDirectory = (string)row["SetupWorkingDirectory"];
            start.FileName = (string)row["SetupFileName"];
            start.Arguments = (string)row["SetupArguments"];

            if (interfaces[ID] == null)
                log.Error("Device not running");
            else
                interfaces[ID].StartSetupProcess(start);

        }

        private void MinimizeSetupBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                if (interfaces[ID].setupProcess != null)
                    ShowWindowAsync(interfaces[ID].setupProcess.MainWindowHandle, SW_SHOWMINIMIZED);
        }

        private void RestoreSetupBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                if (interfaces[ID].setupProcess != null)
                    ShowWindowAsync(interfaces[ID].setupProcess.MainWindowHandle, SW_RESTORE);
        }

        private void ExitSetupBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];
            int ID = (int)row["ID"];
            if (interfaces[ID] != null)
                interfaces[ID].EndSetupProcess();
        }

        private void CurrentSendMessageBtn_Click(object sender, EventArgs e)
        {
            if (interfaces[currentDevice] != null)
                interfaces[currentDevice].Send(MessageToSendTxt.Text);
        }

        private void CurrentSendMessageMultipleBtn_Click(object sender, EventArgs e)
        {
            if (interfaces[currentDevice] == null) return;

            int n = Int32.Parse(SendMultipleTxt.Text);
            int delay = Int32.Parse(DelayMsTxt.Text);

            if (delay == 0)
                for (int i = 0; i < n; i++)
                    interfaces[currentDevice].Send(MessageToSendTxt.Text);
            else
                for (int i = 0; i < n; i++)
                {
                    interfaces[currentDevice].Send(MessageToSendTxt.Text);
                    Thread.Sleep(delay);
                }
        }
        private void CurrentConnectBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];

            // TODO: this code is unnecessarily replicated from StartAll
            row["Running"] = true;

            int rowIndex = (int)row["ID"];
            // TODO: Don't like the fixed column number 2 for Running below
            DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(2, rowIndex);
            DeviceGrid_CellValueChanged(null, e2);
            Application.DoEvents();
        }

        private void CurrentDisconnectBtn_Click(object sender, EventArgs e)
        {
            DataRow row = devices.Rows[currentDevice];

            // TODO: this code is unnecessarily replicated from StopAll
            row["Running"] = false;
            int rowIndex = (int)row["ID"];

            // TODO: Don't like the fixed column number 2 for Running below
            DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(2, rowIndex);
            DeviceGrid_CellValueChanged(null, e2);
            Application.DoEvents();

        }

        private void Robot1Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
                interfaces[1].Send("(1,0,0,0,0)");
        }

        private void Robot2Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
                interfaces[1].Send("(2,0,0,0,0)");
        }

        private void Robot3Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
                interfaces[1].Send("(3,0,0,0,0)");
        }

        private void Robot4Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
                interfaces[1].Send("(4,0,0,0,0)");
        }

        private void Robot50Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
                interfaces[1].Send("(50,0,0,0,0)");
        }

        private void Robot98Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[1] != null)
            {
                interfaces[1].Send("(98,0,0,0,0)");

                // All shoud be wrapped in nice RobotServer class
                Thread.Sleep(100);
                interfaces[1].Disconnect();
                //robotServer = new TcpServer(this, "ROBOT: ");
                interfaces[1].Connect("192.168.0.252:30000");
            }
        }

        private void Robot99Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
            {
                interfaces[1].Send("(99,0,0,0,0)");

                Thread.Sleep(100);
                interfaces[1].Disconnect();
                interfaces[1].Connect("192.168.0.252:30000");
            }
        }

        private void BcrtCreateBtn_Click(object sender, EventArgs e)
        {
            if (bcrt != null)
                bcrt.End();
            GC.Collect();
            bcrt = new BarcodeReaderThread(this, interfaces);
        }

        private void BcrtDestroyBtn_Click(object sender, EventArgs e)
        {
            bcrt.End();
            bcrt = null;
            GC.Collect();
        }

        private void BcrtStartBtn_Click(object sender, EventArgs e)
        {
            bcrt.Enable(BarcodeReaderThreadChk.Checked);
            bcrt.Start();
        }

        private void BcrtEndBtn_Click(object sender, EventArgs e)
        {
            bcrt.End();
        }
        private void BarcodeReaderThreadChk_CheckedChanged(object sender, EventArgs e)
        {
            bcrt.Enable(BarcodeReaderThreadChk.Checked);
        }
        private void TriggerDm1Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[5] != null)
                interfaces[5].Send("+");
        }

        private void TriggerDm2Btn_Click(object sender, EventArgs e)
        {
            // TODO: These can't be hardcoded
            if (interfaces[6] != null)
                interfaces[6].Send("+");
        }
        // ***********************************************************************
        // END DEVICES UI
        // ***********************************************************************

        // ***********************************************************************
        // START VARIABLES UI
        // ***********************************************************************
        private void ClearVariablesBtn_Click(object sender, EventArgs e)
        {
            variables = new DataTable("Variables");
            DataColumn name = variables.Columns.Add("Name", typeof(System.String));
            variables.Columns.Add("Value", typeof(System.String));
            variables.Columns.Add("IsNew", typeof(System.Boolean));
            variables.Columns.Add("TimeStamp", typeof(System.String));
            variables.PrimaryKey = new DataColumn[] { name };
            VariablesGrd.DataSource = variables;
        }

        string variablesFilename = "Variables.var";
        private void LoadVariablesBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, variablesFilename);
            log.Info("LoadVariables from {0}", filename);
            ClearVariablesBtn_Click(null, null);
            try
            {
                variables.ReadXml(filename);
            }
            catch
            { }

            VariablesGrd.DataSource = variables;
            foreach (DataRow row in variables.Rows)
            {
                row["IsNew"] = false;
            }
        }

        private void SaveVariablesBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, variablesFilename);
            log.Info("SaveVariables to {0}", filename);
            variables.AcceptChanges();
            variables.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private void ReadVariableBtn_Click(object sender, EventArgs e)
        {
            string name = VariableNameTxt.Text;
            log.Debug("Read {0}" + name);

            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Info("Found {0} = {1}", row["Name"], row["Value"]);
                    row["IsNew"] = false;
                    return;
                }
            }
            log.Error("Can't find {0}", name);
        }


        // Update variable 'name' with 'value' if it exists otherwise add it
        // TODO: we're duping to jint... is this the right idea?
        static readonly object lockObject = new object();
        public void WriteVariable(string name, string value)
        {
            Monitor.Enter(lockObject);
            log.Info("WriteVariable({0}, {1})", name, value);
            if (variables == null)
            {
                log.Error("variables=null!");
                return;
            }
            string datetime;
            if (UtcTimeChk.Checked)
                datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            else
                datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            // Faster way to set variables in jint
            jintEngine.SetValue(name, value);
            jintEngine.SetValue(name + "_isnew", true);
            jintEngine.SetValue(name + "_timestamp", datetime);

            bool foundVariable = false;
            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    // TODO: This is where it breaks prior to Thread Safety work
                    row["Value"] = value;
                    row["IsNew"] = true;
                    row["TimeStamp"] = datetime;
                    foundVariable = true;
                    break;
                }
            }

            if (!foundVariable)
                variables.Rows.Add(new object[] { name, value, true, datetime });

            variables.AcceptChanges();
            Monitor.Exit(lockObject);
        }
        // This is the "variablename=value" single string version
        public void WriteVariable(string assignment)
        {
            string[] s = assignment.Split('=');
            if (s.Length != 2)
            {
                log.Error("WriteVariable({0} is invalid", assignment);
            }
            else
            {
                WriteVariable(s[0], s[1]);
            }

        }
        private void WriteStringValueTxt_Click(object sender, EventArgs e)
        {
            string name = VariableNameTxt.Text;
            string value = WriteStringValueTxt.Text;
            WriteVariable(name, value);
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        // ***********************************************************************
        // END VARIABLES UI
        // ***********************************************************************

        // ***********************************************************************
        // START JINT ENGINE
        // ***********************************************************************
        Engine jintEngine;
        void StartJint()
        {
            log.Trace("StartJint()");
            jintEngine = new Engine()
                    // Expose various C# functions in JS
                    .SetValue("alert", new Action<string>(JsAlert))
                    .SetValue("crawl", new Action<string>(log.Info))
                    .SetValue("print", new Action<string>(JsPrint))
                    .SetValue("clear", new Action(JsClear))
                    .SetValue("send", new Action<int, string>(JsSend))
                    .SetValue("write_variable", new Action<string, string>(WriteVariable))
                    .SetValue("wv", new Action<string>(WriteVariable))
                    .SetValue("sleep", new Action<int>(x => Thread.Sleep(x)));
            ;
        }
        void StopJint()
        {
            log.Trace("StopJint()");

            jintEngine = null;

        }

        private void JsAlert(string message)
        {
            MessageBox.Show(message, "Window Alert", MessageBoxButtons.OK);
        }
        private void JsPrint(string message)
        {
            log.Info("JSP {0}", message);
        }

        static readonly object lockJsObject = new object();
        private void JsSend(int index, string message)
        {
            Monitor.Enter(lockJsObject);
            log.Info("JsSend({0}, {1})", index, message);
            if (interfaces[index] != null)
                interfaces[index].Send(message);
            Application.DoEvents();
            Monitor.Exit(lockJsObject);
        }
        private void JsClear()
        {
            JavaScriptConsoleRTB.Clear();
        }

        void ExecuteJavaScript(string code)
        {
            log.Info("Execute: {0}", code);
            try
            {
                jintEngine.Execute(code);
            }
            catch (Exception ex)
            {
                log.Error(ex, "ExecuteJavaScript Error {0}", code);
            }
        }
        // ***********************************************************************
        // END JINT ENGINE
        // ***********************************************************************

        // ***********************************************************************
        // START JAVA PROGRAM
        // ***********************************************************************

        private void NewJavaProgramBtn_Click(object sender, EventArgs e)
        {
            JavaScriptFilenameLbl.Text = "Untitled";
            JavaScriptCodeRTB.Clear();
        }

        void LoadJavaScriptProgramFile(string file)
        {
            JavaScriptFilenameLbl.Text = file;
            JavaScriptCodeRTB.LoadFile(file);
            JavaScriptCodeRTB.Modified = false;
        }
        private void LoadJavaProgramBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open a LEonard JavaScript Program";
            dialog.Filter = "JavaScript Files|*.js";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
                LoadJavaScriptProgramFile(dialog.FileName);
        }

        private void SaveJavaProgramBtn_Click(object sender, EventArgs e)
        {
            if (JavaScriptFilenameLbl.Text == "Untitled" || JavaScriptFilenameLbl.Text == "")
                SaveAsJavaProgramBtn_Click(null, null);
            else
            {
                log.Info("Save JavaScript program to {0}", JavaScriptFilenameLbl.Text);
                JavaScriptCodeRTB.SaveFile(JavaScriptFilenameLbl.Text);
                JavaScriptCodeRTB.Modified = false;
            }
        }

        private void SaveAsJavaProgramBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "LEonard JavaScript Programs|*.js";
            dialog.Title = "Save a LEonard JavaScript Program";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    JavaScriptFilenameLbl.Text = dialog.FileName;
                    SaveJavaProgramBtn_Click(null, null);
                }
            }
        }
        private void SetAutoloadFileBtn_Click(object sender, EventArgs e)
        {
            StartupJavaScriptLbl.Text = JavaScriptFilenameLbl.Text;
        }

        private void RunJavaProgramBtn_Click(object sender, EventArgs e)
        {
            try
            {
                jintEngine.Execute(JavaScriptCodeRTB.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Program Execution Error: {0}", JavaScriptCodeRTB.Text);
            }
        }

        private void ExecJavaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                jintEngine.Execute(JavaCommandTxt.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Command Execution Error: {0}", JavaCommandTxt.Text);
            }
        }

        private void JavaVariablesRefreshBtn_Click(object sender, EventArgs e)
        {
            string finalUpdate = "";

            foreach (KeyValuePair<string, Jint.Runtime.Descriptors.PropertyDescriptor> kp in jintEngine.Global.GetOwnProperties())
            {

                string varType = "";
                if (kp.Value.Value.IsString()) varType = "S";
                if (kp.Value.Value.IsNumber()) varType = "N";
                if (kp.Value.Value.IsBoolean()) varType = "B";
                if (varType.Length > 0)
                {
                    //Crawl(kp.Value.Value.IsNumber().ToString());
                    //finalUpdate += kp.Key.ToString() + "\n";
                    //finalUpdate += kp.Value.Value.ToString() + "\n";
                    finalUpdate += varType + " " + kp.Key.ToString() + " = " + kp.Value.Value.ToString() + "\n";
                }
            }
            JavaScriptVariablesRTB.Text = finalUpdate;
        }


        // ***********************************************************************
        // END JAVA PROGRAM
        // ***********************************************************************
    }
}