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

namespace LEonard
{
    public partial class MainForm : Form
    {
        static string LEonardRoot = "./";
        static DataTable devices;
        static DataTable variables;

        static SplashForm splashForm;

        BarcodeReaderThread bcrt;

        LeDeviceInterface[] interfaces = { null, null, null, null, null, null };

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

            LoadConfigBtn_Click(null, null);

            Crawl(string.Format("Starting {0} in [{1}]", filename, directory));


            if (AutoLoadChk.Checked)
            {
                LoadDevicesFile(StartupDevicesLbl.Text);
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
                CloseTmr.Interval = 500;
                CloseTmr.Enabled = true;
                e.Cancel = true; // Let the close out timer shut us down
                Crawl("Shutting down...");
            }
        }

        private void StartThreads()
        {
            Crawl("StartThreads()...");

            //bcrt = new BarcodeReaderThread(this, interfaces[4], interfaces[5]);
            //bcrt.Enable(BarcodeReaderThreadChk.Checked);
            //bcrt.Start();
        }
        private void EndThreads()
        {
            Crawl("EndThreads()...");

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

            Crawl("StartupTmr()...");
            StartupTmr.Enabled = false;

            StartThreads();
            StartJint();
            Crawl("System ready.");


            if (AutoStartChk.Checked)
            {
                Crawl("Autostaring all devices");
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
            FlushCrawl();

            // TODO is this a poor place to check for commands from above??
            for (int i = 0; i < 4; i++)
                if (interfaces[i] != null) interfaces[i].Receive();
        }


        private void CrawlerClearBtn_Click(object sender, EventArgs e)
        {
            AllCrawlRTB.Clear();
        }

        private void ErrorClearBtn_Click(object sender, EventArgs e)
        {
            ErrorCrawlRTB.Clear();
        }

        private void CommandClearBtn_Click(object sender, EventArgs e)
        {
            CommandCrawlRTB.Clear();
        }
        private void RobotClearBtn_Click(object sender, EventArgs e)
        {
            RobotCrawlRTB.Clear();
        }

        private void VisionClearBtn_Click(object sender, EventArgs e)
        {
            VisionCrawlRTB.Clear();
        }
        private void BarcodeClearBtn_Click(object sender, EventArgs e)
        {
            BarcodeCrawlRTB.Clear();
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
                this.Close();
            }
        }

        // TODO: Clean these up, use consistent string formatting ideas, and the variables
        // TODO All of these... the variable name should be prefixed with the unique device name not the message prefix
        void GeneralCallBack(string data, string prefix)
        {
            Crawl(string.Format("{0} GCB<=={1}", prefix, data));
            WriteVariable(prefix + ".return", data);

            // TODO: this is whjere some standard response codes should be parsed
        }

        void CommandCallBack(string message, string prefix)
        {
            Crawl(string.Format("{0} CCB<=={1}", prefix, message));

            if (message.Length>3 && message.StartsWith("JS{"))
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

                    WriteVariable(prefix + ".name", name);
                    WriteVariable(prefix + ".sequence", sequence);
                    WriteVariable(prefix + ".params", parameters);

                    // TODO: Execute

                    response = string.Format("{0},{1},{2}", name, sequence, "RESPONSE");
                }

                interfaces[0].Send(response);
            }
        }

        void DatamanCallBack(string data, string prefix)
        {
            Crawl(string.Format("{0} DCB<=={1}", prefix, data));
            string[] s = data.Split(',');
            if (s.Length == 3)
            {
                string name = s[0];
                string sequence = s[1];
                string value = s[2];
                WriteVariable(prefix + ".name", name);
                WriteVariable(prefix + ".sequence", sequence);
                WriteVariable(prefix + ".value", value);
            }
            else
                Crawl(prefix + "ERROR unexpected string received: " + data);
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
            Crawl("LoadPersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");
            LEonardRoot = (string)AppNameKey.GetValue("LEonardRoot", "\\");
            LEonardRootLbl.Text = LEonardRoot;
            StartupDevicesLbl.Text = (string)AppNameKey.GetValue("StartupDevicesLbl.Text", "");
            AutoLoadChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoLoadChk.Checked", "False"));
            AutoStartChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoStartChk.Checked", "False"));
            UtcTimeChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("UtcTimeChk.Checked", "True"));

            PersonalityTabs.SelectedIndex = (Int32)AppNameKey.GetValue("PersonalityTabs.SelectedIndex", 0);

            LoadVariablesBtn_Click(null, null);
        }

        void SavePersistent()
        {
            Crawl("SavePersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");
            AppNameKey.SetValue("LEonardRoot", LEonardRoot);
            AppNameKey.SetValue("StartupDevicesLbl.Text", StartupDevicesLbl.Text);
            AppNameKey.SetValue("AutoLoadChk.Checked", AutoLoadChk.Checked);
            AppNameKey.SetValue("AutoStartChk.Checked", AutoStartChk.Checked);
            AppNameKey.SetValue("UtcTimeChk.Checked", UtcTimeChk.Checked);

            AppNameKey.SetValue("PersonalityTabs.SelectedIndex", PersonalityTabs.SelectedIndex);

            SaveVariablesBtn_Click(null, null);
        }
        private void ChangeLEonardRootBtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Crawl(String.Format("You selected ERROR LEonardRoot={0}", dialog.SelectedPath));
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
                Crawl("Startup Devices file set to " + StartupDevicesLbl.Text);

                if (MessageBox.Show("Load this file now?", "LEonard Confiormation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LoadDevicesFile(StartupDevicesLbl.Text);
            }
        }

        private void DefaultConfigBtn_Click(object sender, EventArgs e)
        {
            LEonardRoot = "";
            LEonardRootLbl.Text = LEonardRoot;
            StartupDevicesLbl.Text = "";
            AutoLoadChk.Checked = false;
            AutoStartChk.Checked = false;
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

            //devices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //devices.Columns[0].

            devices.PrimaryKey = new DataColumn[] { id };

            devices.Rows.Add(new object[] { 0, "Command", false, "TcpServer", "127.0.0.1:1000", "COMM", "command", "Hello!", "exit()" });
            devices.Rows.Add(new object[] { 1, "UR-5e", false, "TcpServer", "192.168.0.252:30000", "ROB", "general", "", "(98,0,0,0,0)" });
            devices.Rows.Add(new object[] { 2, "Sherlock", false, "TcpServer", "127.0.0.1:20000", "VISS", "general", "iint()", "" });
            devices.Rows.Add(new object[] { 3, "HALCON", false, "TcpClient", "127.0.0.1:21000", "VISH", "general", "init()", "" });
            devices.Rows.Add(new object[] { 4, "Dataman 1", false, "Serial", "COM3", "BAR1", "dataman", "+", "" });
            devices.Rows.Add(new object[] { 5, "Dataman 2", false, "Serial", "COM4", "BAR2", "dataman", "+", "" });

            DevicesGrid.DataSource = devices;
        }

        int LoadDevicesFile(string name)
        {
            Crawl("LoadDevices from " + name);
            devices = new DataTable("Devices");
            devices.ReadXml(name);
            DevicesGrid.DataSource = devices;
            DevicesFilenameLbl.Text = name;

            return 0;
        }
        private void LoadDevicesBtn_Click(object sender, EventArgs e)
        {
            // TODO: Need to close everyone down!

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
                Crawl("SaveDevices to " + DevicesFilenameLbl.Text);
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
            Crawl("StartAllDevices");
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
            Crawl("StopAllDevices");
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
            Crawl("Deleting Row");

            DefaultDevicesBtn.Enabled = true;
            LoadDevicesBtn.Enabled = true;
            SaveDevicesBtn.Enabled = true;
            SaveAsDevicesBtn.Enabled = true;

        }

        int currentDevice = -1;
        private void DeviceGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentDevice = e.RowIndex;

            Crawl("Enter Row  " + currentDevice.ToString());


            // TODO: Setup style for entire DeviceControlGrp
            // TODO: Don't like the fixed column number 1 for Name below
            //DeviceControlGrp.Text = devices.Rows[currentDevice].ItemArray[1].ToString();
        }

        private void DeviceGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            int index = Convert.ToInt32(devices.Rows[row].ItemArray[0].ToString());
            string name = devices.Rows[row].ItemArray[1].ToString();
            string type = devices.Rows[row].ItemArray[3].ToString();
            string address = devices.Rows[row].ItemArray[4].ToString();
            string prefix = devices.Rows[row].ItemArray[5].ToString();
            string callback = devices.Rows[row].ItemArray[6].ToString();

            Crawl("Changed Value: " + devices.Rows[row].ItemArray[col].ToString());

            // TODO: Don't like this index == 2 below... how to use column name Running?
            if (col == 2)
            {
                if (devices.Rows[row].ItemArray[col].ToString() == "True")
                {
                    Crawl(string.Format("Start {0}:{1} as {2} at {3} with {4}, {5}", index, name, type, address, prefix, callback));
                    switch (type)
                    {
                        case @"TcpServer":
                            interfaces[index] = new LeTcpServer(this, prefix);
                            interfaces[index].Connect(address);
                            break;
                        case @"TcpClient":
                            interfaces[index] = new LeTcpClient(this, prefix);
                            interfaces[index].Connect(address);
                            break;
                        case @"Serial":
                            interfaces[index] = new LeSerial(this, prefix);
                            interfaces[index].Connect(address);
                            break;
                        default:
                            CrawlError("Illegal interface type: " + type);
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
                            CrawlError("Illegal callback type: " + type);
                            break;
                    }

                    // TODO: Magic column number 7 is horrible
                    // TODO: DOESN'T WORK for a connect in the case of TcpServer which must happen at connect
                    string onConnectSend = devices.Rows[row].ItemArray[7].ToString();
                    if (onConnectSend.Length > 0)
                        try
                        {
                            interfaces[index].Send(onConnectSend);
                        }
                        catch
                        {

                        }
                }
                else
                {
                    Crawl("Stop " + name);
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

            Crawl("CellBeginEdit: " + devices.Rows[row].ItemArray[col].ToString());

        }
        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            if (interfaces[currentDevice] != null)
                interfaces[currentDevice].Send(MessageToSendTxt.Text);
        }
        // Launch command tester to assist in debugging
        Process proc;
        private void StartTestClientBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "";
#if DEBUG
            start.FileName = "C:\\Users\\nedlecky\\Documents\\GitHub\\LEonard\\LEonardClient\\bin\\Debug\\LEonardClient.exe";
#else
            start.FileName = "C:\\Users\\nedlecky\\Documents\\GitHub\\LEonard\\LEonardClient\\bin\\Release\\LEonardClient.exe";
#endif
            Crawl("Starting " + start.FileName);
            try
            {
                proc = Process.Start(start);
            }
            catch
            {
                CrawlError("Could not start " + start.FileName);
            }

        }


        private void Robot1Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
                interfaces[1].Send("(1,0,0,0,0)");
        }

        private void Robot2Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
                interfaces[1].Send("(2,0,0,0,0)");
        }

        private void Robot3Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
                interfaces[1].Send("(3,0,0,0,0)");
        }

        private void Robot4Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
                interfaces[1].Send("(4,0,0,0,0)");
        }

        private void Robot50Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[1] != null)
                interfaces[1].Send("(50,0,0,0,0)");
        }

        private void Robot98Btn_Click(object sender, EventArgs e)
        {
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

                // All shoud be wrapped in nice RobotServer class
                Thread.Sleep(100);
                interfaces[1].Disconnect();
                //robotServer = new TcpServer(this, "ROBOT: ");
                interfaces[1].Connect("192.168.0.252:30000");
            }
        }

        private void BcrtCreateBtn_Click(object sender, EventArgs e)
        {
            if (bcrt != null)
                bcrt.End();
            GC.Collect();
            bcrt = new BarcodeReaderThread(this, interfaces[4], interfaces[5]);
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
            if (interfaces[4] != null)
                interfaces[4].Send("+");
        }

        private void TriggerDm2Btn_Click(object sender, EventArgs e)
        {
            if (interfaces[5] != null)
                interfaces[5].Send("+");
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
            Crawl("LoadVariables from " + filename);
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
            Crawl("SaveVariables to " + filename);
            variables.AcceptChanges();
            variables.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private void ReadVariableBtn_Click(object sender, EventArgs e)
        {
            string name = VariableNameTxt.Text;
            Crawl("Read " + name);

            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    Crawl(String.Format("Found {0} = {1}", row["Name"], row["Value"]));
                    row["IsNew"] = false;
                    return;
                }
            }
            CrawlError("Can't find " + name);
        }


        // Update variable 'name' with 'value' if it exists otherwise add it
        public void WriteVariable(string name, string value)
        {
            Crawl(string.Format("WriteVariable({0}, {1})", name, value));
            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    row["Value"] = value;
                    row["IsNew"] = true;
                    string datetime;
                    if (UtcTimeChk.Checked)
                        datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    else
                        datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

                    row["TimeStamp"] = datetime;

                    return;
                }
            }
            variables.Rows.Add(new object[] { name, value });
            variables.AcceptChanges();
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
            Crawl("Start Jint");
            jintEngine = new Engine()
                    // Expose various C# functions in JS
                    .SetValue("alert", new Action<string>(AlertJ))
                    .SetValue("crawl", new Action<string>(CrawlJ))
                ;
        }
        void StopJint()
        {
            Crawl("Stop Jint");

        }

        private void AlertJ(string Message)
        {
            MessageBox.Show(Message, "Window Alert", MessageBoxButtons.OK);
        }
        private void CrawlJ(string message)
        {
            Crawl(message);
        }

        void ExecuteJavaScript(string code)
        {
            Crawl("Execute: " + code);
            jintEngine.Execute(code);
        }

        // ***********************************************************************
        // END JINT ENGINE
        // ***********************************************************************
    }
}