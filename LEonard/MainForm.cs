// File: MainForm.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: The main UI form and the bulk of the UI code for LEonard

#region USING
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using IronPython.Hosting;
using Jint;
using Jint.Native;
using Microsoft.Win32;
using NLog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static IronPython.Modules._ast;
#endregion

namespace LEonard
{
    public partial class MainForm : Form
    {
        #region ===== MAINFORM VARIABLES                ==============================================================================================================================
        private static NLog.Logger log;
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        enum LEonardLanguages
        {
            LEScript,
            Java,
            Python
        };

        // Root and Folder Constants
        static public string LEonardRoot = null;
        static LEonardLanguages LEonardLanguage = LEonardLanguages.LEScript;
        const string ConfigFolder = "Config";
        const string CodeFolder = "Code";
        const string DataFolder = "Data";
        const string LogsFolder = "Logs";

        Jint.Engine javaEngine;
        Microsoft.Scripting.Hosting.ScriptEngine pythonEngine;
        Microsoft.Scripting.Hosting.ScriptScope pythonScope;
        Protection protection;

        FileManager fileManager = null;

        // TODO: This needs to dynamically resize and the code that does it doesn't!!
        // These map 1:1 with the rows in devices.... I hope (Using ID field in row but this is a bit fragile)
        LeDeviceInterface[] interfaces = { null, null, null, null, null, null, null, null, null, null, null, null, null };
        int currentDeviceRowIndex = -1;
        List<Button> speedSendBtns = new List<Button>();


        MessageDialog waitingForOperatorMessageForm = null;
        bool closeOperatorFormOnIndex = false;
        SplashForm splashForm = null;
        string licenseFilename;

        static DataTable devices;
        static DataTable displays;
        static DataTable variables;
        static DataTable tools;
        static DataTable positions;
        static string[] diameterDefaults = { "0.00", "77.2", "81.9" };

        // MainForm size as designed in Visual Studio
        public const int screenDesignWidth = 1920;
        public const int screenDesignHeight = 1080;

        private enum RunState
        {
            INIT,
            IDLE,
            READY,
            RUNNING,
            PAUSED
        }
        RunState runState = RunState.INIT;

        private enum OperatorMode
        {
            OPERATOR,
            EDITOR,
            ENGINEERING
        }
        OperatorMode operatorMode = OperatorMode.OPERATOR;

        string executionRoot = "";

        // System Defaults
        const string DEFAULT_LEonardRoot = @"C:\Users\Public\LEonard";
        const double maxFontScaleUpPct = 125;

        // I/O Defaults
        const string DEFAULT_door_closed_input = "1,1";
        const string DEFAULT_footswitch_pressed_input = "7,1";

        // Non-grinding Motion Defaults
        const double DEFAULT_linear_speed = 200;
        const double DEFAULT_linear_accel = 500;
        const double DEFAULT_blend_radius = 3;
        const double DEFAULT_joint_speed = 20;
        const double DEFAULT_joint_accel = 30;

        // Grinding Motion Defaults
        const double DEFAULT_grind_trial_speed = 40;
        const double DEFAULT_grind_linear_accel = 400;
        const double DEFAULT_grind_jog_speed = 100;
        const double DEFAULT_grind_jog_accel = 400;
        const double DEFAULT_grind_max_blend_radius = 2;
        const double DEFAULT_grind_touch_speed = 5;
        const double DEFAULT_grind_touch_retract = 3;
        const double DEFAULT_grind_force_dwell = 500;
        const double DEFAULT_grind_max_wait = 1500;
        const double DEFAULT_grind_point_frequency = 2;
        const double DEFAULT_grind_force_mode_damping = 0.1;
        const double DEFAULT_grind_force_mode_gain_scaling = 1.0;

        const double DEFAULT_max_allowable_relative_move_mm = 150;

        // Lists of all controls that get tweaked in UI management
        IEnumerable<Control> allFontResizableList;

        ConsoleForm consoleForm = null;

        #endregion ===== MAINFORM VARIABLES                =============================================================================================================================

        #region ===== MAINFORM EVENTS                   ==============================================================================================================================
        OperatorMode operatorModeOverride = OperatorMode.OPERATOR;
        bool useOperatorModeOverride = false;


        // TODO is this worth expanding???
        private void TextLargerButtonHandler(object sender, EventArgs e)
        {

        }
        void SetupRTB(RichTextBox rtb)
        {
            // This is handled in the Designer
            //rtb.DetectUrls= false;

            /*
                Button b = new Button();
                b.Location = new System.Drawing.Point(100, 100);
                b.Name = rtb.Name + "UpBtn";
                b.Size = new System.Drawing.Size(100, 100);
                b.TabIndex = rtb.TabIndex + 1;
                b.Text = "UP";
                b.UseVisualStyleBackColor = true;
                b.Click += new System.EventHandler(TextLargerButtonHandler);

                this.Controls.Add(b);
            */
        }

        public MainForm(string[] args)
        {
            if (args.Length > 1)
            {
                switch (args[0])
                {
                    case "OperatorMode":
                        try
                        {
                            operatorModeOverride = (OperatorMode)(int)Convert.ToInt32(args[1]);
                        }
                        catch { }
                        useOperatorModeOverride = true;
                        break;
                }
            }

            InitializeComponent();

            SetupRTB(SequenceRTB);
            SetupRTB(SequenceRTBCopy);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            consoleForm = new ConsoleForm(this);

            // Startup logging system (which also displays messages)
            log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("MainForm_Load(...)");

            string companyName = Application.CompanyName;
            string appName = Application.ProductName;
            string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string executable = Application.ExecutablePath;
            string filename = System.IO.Path.GetFileName(executable);
            executionRoot = System.IO.Path.GetDirectoryName(executable);
            string caption = appName + " Rev " + productVersion;
#if DEBUG
            caption += " DEBUG";
#endif
            this.Text = caption;
            VersionLbl.Text = caption;

            LoadRootDirectory();

            // Set logfile variable in NLog
            LogManager.Configuration.Variables["LogfileName"] = System.IO.Path.Combine(LEonardRoot, LogsFolder, "LEonard.log");
            LogManager.ReconfigExistingLoggers();

            allFontResizableList = TakeControlInventory(this);

            LoadPersistent();

            // Suppress all the optional controls!
            UpdateAnnunciators();

            splashForm = new SplashForm(this)
            {
                AutoClose = true,
            };

            InitializeJavaEngine();
            InitializePythonEngine();
            SetLEonardRoot(LEonardRoot);

            // Flag that we're starting
            log.Info("================================================================");
            log.Info(string.Format("Starting {0} in [{1}]", filename, executionRoot));
            log.Info(caption);
            log.Info("================================================================");

            licenseFilename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, "license.lic");
            protection = new Protection(this, licenseFilename);

            UserModeBox.SelectedIndex = (int)operatorMode;

            // 1-second tick
            HeartbeatTmr.Interval = 1000;
            HeartbeatTmr.Enabled = true;

            // Real start of everyone will happen shortly
            StartupTmr.Interval = 2000;
            StartupTmr.Enabled = true;

            SetSequenceState(SequenceState.NEW);
            SetState(RunState.IDLE);
            // TODO Is this OK... how do we get to READY!
            SetState(RunState.READY);

            ResumeLayout();

            // Make fonts scale as they should!
            //MainForm_Resize(null, null);
        }
        // Function key shortcut handling (primarily for development testing assistance)
        public bool IsConsoleVisible = false;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //log.Trace("MainForm_KeyDown: {0}", e.KeyData);
            switch (e.KeyData)
            {
                case Keys.F5:
                    if (StartBtn.Enabled)
                    {
                        StartBtn_Click(null, null);
                        e.Handled = true;
                    }
                    break;
                case Keys.F6:
                    if (StepBtn.Enabled)
                    {
                        StepBtn_Click(null, null);
                        e.Handled = true;
                    }
                    break;
                case Keys.F7:
                    if (PauseBtn.Enabled)
                    {
                        PauseBtn_Click(null, null);
                        e.Handled = true;
                    }
                    break;
                case Keys.F8:
                    if (StopBtn.Enabled)
                    {
                        StopBtn_Click(null, null);
                        e.Handled = true;
                    }
                    break;
                case Keys.F12:
                    IsConsoleVisible = !IsConsoleVisible;
                    if (IsConsoleVisible)
                        consoleForm.Show();
                    else
                        consoleForm.Hide();
                    break;
            }
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (!uiUpdatesAreLive) return;

            suggestedSystemScalePct = ScaleRecommender(Width, screenDesignWidth, Height, screenDesignHeight);

            log?.Info($"MainForm Resize to {Width} x {Height}");
            log?.Info($"Resizing font to {suggestedSystemScalePct}%");

            ScaleUiText(suggestedSystemScalePct);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (forceClose) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = ConfirmMessageBox("Do you want to close the application?");
                e.Cancel = (result != DialogResult.OK);
            }

            if (!e.Cancel)
            {
                if (SequenceWasModified())
                {
                    var result = ConfirmMessageBox($"Closing Application!\nSequence [{LoadSequenceBtn.Text}] has changed.\nSave changes before exit?");
                    if (result == DialogResult.OK)
                        SaveSequenceBtn_Click(null, null);
                }

                if (JavaCodeRTB.Modified)
                {
                    var result = ConfirmMessageBox($"Closing Application!\nJava code [{JavaFilenameLbl.Text}] has changed.\nSave changes before exit?");
                    if (result == DialogResult.OK)
                        JavaSaveBtn_Click(null, null);
                }

                if (PythonCodeRTB.Modified)
                {
                    var result = ConfirmMessageBox($"Closing Application!\nPython code [{PythonFilenameLbl.Text}] has changed.\nSave changes before exit?");
                    if (result == DialogResult.OK)
                        PythonSaveBtn_Click(null, null);
                }

                CloseTmr.Interval = 500;
                CloseTmr.Enabled = true;
                e.Cancel = true; // Cancel this shutdown- we'll let the close out timer shut us down
                log.Info("Shutting down in 500mS...");
            }
        }
        #endregion ===== MAINFORM EVENTS                   ==============================================================================================================================

        #region ===== TIMERS                            ==============================================================================================================================
        private void StartupTmr_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(250);
            splashForm.Show();

            log.Info("StartupTmr()...");
            StartupTmr.Enabled = false;

            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;


            // Load the last Sequence if there was one loaded in LoadPersistent()
            if (sequenceFileToAutoload != "")
                if (LoadSequenceFile(sequenceFileToAutoload))
                {
                    SetSequenceState(SequenceState.LOADED);
                    SetState(RunState.READY);
                }

            // Load devices... if none specified, offer to create defaults
            int ret = 1;
            if (StartupDevicesLbl.Text.Length > 0)
            {
                ret = LoadDevicesFile(StartupDevicesLbl.Text);
            }

            if (ret != 0)
            {
                DialogResult result = ConfirmMessageBox("Could not load devices. Create some defaults?");
                if (result == DialogResult.OK)
                {
                    ClearAndInitializeDevices();
                    CreateDefaultDevices();
                    DevicesFilenameLbl.Text = System.IO.Path.Combine(LEonardRoot, "Config", "Default.ldev");
                    SaveDevicesBtn_Click(null, null);
                    SetStartupDevicesFileBtn_Click(null, null);
                    AutoConnectOnLoadChk.Checked = false;
                    SavePersistentStartupDevices();
                }
            }

            log.Info("StartupTmr complete");
            uiUpdatesAreLive = true;
        }
        bool forceClose = false;
        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            CloseTmr.Enabled = false;
            DeviceDisconnectAllBtn_Click(null, null);
            MessageTmr_Tick(null, null);
            forceClose = true;
            SavePersistent();
            NLog.LogManager.Shutdown(); // Flush and close down internal threads and timers
            consoleForm.Close();
            this.Close();
        }
        private string TimeSpanFormat(TimeSpan elapsed)
        {
            int hrs = Math.Abs(elapsed.Days * 24 + elapsed.Hours);
            int mins = Math.Abs(elapsed.Minutes);
            int secs = Math.Abs(elapsed.Seconds);
            int msecs = Math.Abs(elapsed.Milliseconds);
            return String.Format("{0:00}h {1:00}m {2:00.0}s", hrs, mins, secs + msecs / 1000.0) + ((elapsed < TimeSpan.Zero && secs > 0.1) ? " OVER" : "");
        }
        private void RecomputeTimes()
        {
            DateTime now = DateTime.Now;
            TimeSpan elapsed = now - runStartedTime;
            RunElapsedTimeLbl.Text = TimeSpanFormat(elapsed);

            TimeSpan stepElapsed = now - stepStartedTime;
            StepElapsedTimeLbl.Text = TimeSpanFormat(stepElapsed);

            TimeSpan timeRemaining = stepEndTimeEstimate - now;
            StepTimeRemainingLbl.Text = TimeSpanFormat(timeRemaining);
        }

        static bool robotReady = false;
        static DateTime runStartedTime;   // When did the user hit run?
        static DateTime stepStartedTime;  // When did the current Sequence line start executing?
        static DateTime stepEndTimeEstimate;  // When do we think it will end?
        private void HeartbeatTmr_Tick(object sender, EventArgs e)
        {
            // Update current time
            Time2Lbl.Text = TimeLbl.Text = DateTime.Now.ToString();

            // Update elapsed time panel
            if (runState == RunState.RUNNING || runState == RunState.PAUSED)
                RecomputeTimes();

            // DASHBOARD Handler: Round-robin sending the Dashboard monitoring commands
            if (LeUrDashboard.uiFocusInstance != null)
                if (!LeUrDashboard.uiFocusInstance.IsConnected())
                {
                    RobotConnectBtn.Text = "Dashboard ERROR";
                    RobotConnectBtn.BackColor = Color.Red;
                }
                else
                {
                    // Any responses received?
                    string dashResponse = LeUrDashboard.uiFocusInstance.Receive();
                    if (dashResponse != null)
                    {
                        log.Trace("DASH received {0}", dashResponse.Replace('\n', ' '));
                        string[] responses = dashResponse.Split('\n');
                        foreach (string response in responses)
                        {
                            log.Trace("DASH parsing {0}", response);
                            if (response.StartsWith("Robotmode: "))
                            {
                                nUnansweredRobotmodeRequests = 0;
                                HandleRobotmodeResponse(response);
                            }
                            else if (response.StartsWith("Safetystatus: "))
                            {
                                nUnansweredSafetystatusRequests = 0;
                                HandleSafetystatusResponse(response);
                            }
                            else
                            {
                                ProgramState programState = IsProgramstateResponse(response);
                                if (programState != ProgramState.UNKNOWN)
                                {
                                    nUnansweredProgramstateRequests = 0;
                                    HandleProgramstateResponse(programState, response);
                                }
                            }
                        }
                    }

                    // Check for unanswered requests
                    if (nUnansweredRobotmodeRequests > 2)
                    {
                        log.Error("Too many sequential missed responses from robotmode");
                        EnsureStopped();
                    }
                    else if (nUnansweredRobotmodeRequests > 0)
                        log.Warn("Missed {0} responses from robotmode", nUnansweredRobotmodeRequests);

                    if (nUnansweredSafetystatusRequests > 2)
                    {
                        log.Error("Too many sequential missed responses from safetystatus");
                        EnsureStopped();
                    }
                    else if (nUnansweredSafetystatusRequests > 0)
                        log.Warn("Missed {0} responses from safetystatus", nUnansweredSafetystatusRequests);

                    if (nUnansweredProgramstateRequests > 2)
                    {
                        log.Error("Too many sequential missed responses from programstate");
                        EnsureStopped();
                    }
                    else if (nUnansweredProgramstateRequests > 0)
                        log.Warn("Missed {0} responses from programstate", nUnansweredProgramstateRequests);


                    switch (dashboardCycle++)
                    {
                        case 0:
                            LeUrDashboard.uiFocusInstance.Send("robotmode");
                            LeUrDashboard.uiFocusInstance.Send("safetystatus");
                            nUnansweredRobotmodeRequests++;
                            nUnansweredSafetystatusRequests++;
                            break;
                        case 1:
                            LeUrDashboard.uiFocusInstance.Send("programstate");
                            nUnansweredProgramstateRequests++;
                            dashboardCycle = 0;
                            break;
                        default:
                            dashboardCycle = 0;
                            break;

                    }
                }

            // When the robot connects, get us ready to go!  Or, if it disconnects, put us in WAIT
            bool newRobotReady = false;
            if (LeUrCommand.uiFocusInstance == null)
                robotReady = false;
            else
            {
                if (LeUrCommand.uiFocusInstance.IsClientConnected)
                    newRobotReady = true;

                if (newRobotReady != robotReady)
                {
                    robotReady = newRobotReady;
                    if (robotReady)
                    {
                        log.Info("Changing robot connection to READY");
                        LeUrCommand.uiFocusInstance.status = LeUrCommand.Status.OK;
                        UrCommandAnnounce();

                        //log.Error("Hacky time delay.....");
                        //Thread.Sleep(1000);

                        // Send persistent values (or defaults) for speeds, accelerations, I/O, etc.
                        ExecuteLEScriptLine(-1, "grind_contact_enable(0)");  // Set contact enabled = No Touch No Grind
                        ExecuteLEScriptLine(-1, "grind_retract()");  // Ensure we're not on the part
                        ExecuteLEScriptLine(-1, string.Format("set_linear_speed({0})", ReadVariable("robot_linear_speed_mmps", DEFAULT_linear_speed)));
                        ExecuteLEScriptLine(-1, string.Format("set_linear_accel({0})", ReadVariable("robot_linear_accel_mmpss", DEFAULT_linear_accel)));
                        ExecuteLEScriptLine(-1, string.Format("set_blend_radius({0})", ReadVariable("robot_blend_radius_mm", DEFAULT_blend_radius)));
                        ExecuteLEScriptLine(-1, string.Format("set_joint_speed({0})", ReadVariable("robot_joint_speed_dps", DEFAULT_joint_speed)));
                        ExecuteLEScriptLine(-1, string.Format("set_joint_accel({0})", ReadVariable("robot_joint_accel_dpss", DEFAULT_joint_accel)));
                        ExecuteLEScriptLine(-1, string.Format("set_door_closed_input({0})", ReadVariable("robot_door_closed_input", DEFAULT_door_closed_input).Trim(new char[] { '[', ']' })));
                        ExecuteLEScriptLine(-1, string.Format("set_footswitch_pressed_input({0})", ReadVariable("robot_footswitch_pressed_input", DEFAULT_footswitch_pressed_input).Trim(new char[] { '[', ']' })));


                        ExecuteLEScriptLine(-1, string.Format("grind_trial_speed({0})", ReadVariable("grind_trial_speed_mmps", DEFAULT_grind_trial_speed)));
                        ExecuteLEScriptLine(-1, string.Format("grind_linear_accel({0})", ReadVariable("grind_linear_accel_mmpss", DEFAULT_grind_linear_accel)));
                        ExecuteLEScriptLine(-1, string.Format("grind_jog_speed({0})", ReadVariable("grind_jog_speed_mmps", DEFAULT_grind_jog_speed)));
                        ExecuteLEScriptLine(-1, string.Format("grind_jog_accel({0})", ReadVariable("grind_jog_accel_mmpss", DEFAULT_grind_jog_accel)));
                        ExecuteLEScriptLine(-1, string.Format("grind_max_blend_radius({0})", ReadVariable("grind_max_blend_radius_mm", DEFAULT_grind_max_blend_radius)));
                        ExecuteLEScriptLine(-1, string.Format("grind_touch_speed({0})", ReadVariable("grind_touch_speed_mmps", DEFAULT_grind_touch_speed)));
                        ExecuteLEScriptLine(-1, string.Format("grind_touch_retract({0})", ReadVariable("grind_touch_retract_mm", DEFAULT_grind_touch_retract)));
                        ExecuteLEScriptLine(-1, string.Format("grind_force_dwell({0})", ReadVariable("grind_force_dwell_ms", DEFAULT_grind_force_dwell)));
                        ExecuteLEScriptLine(-1, string.Format("grind_max_wait({0})", ReadVariable("grind_max_wait_ms", DEFAULT_grind_max_wait)));
                        ExecuteLEScriptLine(-1, string.Format("grind_point_frequency({0})", ReadVariable("grind_point_frequency_hz", DEFAULT_grind_point_frequency)));
                        ExecuteLEScriptLine(-1, string.Format("grind_force_mode_damping({0})", ReadVariable("grind_force_mode_damping", DEFAULT_grind_force_mode_damping)));
                        ExecuteLEScriptLine(-1, string.Format("grind_force_mode_gain_scaling({0})", ReadVariable("grind_force_mode_gain_scaling", DEFAULT_grind_force_mode_gain_scaling)));
                        ExecuteLEScriptLine(-1, "enable_cyline_cal(0)");

                        // Download selected tool and part geometry by acting like a reselect of both
                        MountedToolBox_SelectedIndexChanged(null, null);
                        PartGeometryBox_SelectedIndexChanged(null, null);

                        RobotCommandStatusLbl.BackColor = Color.Green;
                        RobotCommandStatusLbl.Text = "Command Ready";
                        // Restore all button settings with same current state
                        SetState(runState, true);
                    }
                    else
                    {
                        log.Info("Change robot connection to WAIT");
                        LeUrCommand.uiFocusInstance.status = LeUrCommand.Status.WAITING;
                        UrCommandAnnounce();

                        // Restore all button settings with same current state
                        SetState(runState, true);
                        EnsureNotRunning();
                    }
                }

            }
        }

        #endregion

        #region ===== LOG TAB CONTROLS                  ==============================================================================================================================
        private void UrLogRTB_DoubleClick(object sender, EventArgs e)
        {
            RobotLogRTB.Clear();
        }

        private void ConsoleRTB_DoubleClick(object sender, EventArgs e)
        {
            AuxLogRTB.Clear();
        }

        private void ErrorLogRTB_DoubleClick(object sender, EventArgs e)
        {
            ErrorLogRTB.Clear();
        }
        private void ExecLogRTB_DoubleClick(object sender, EventArgs e)
        {
            ExecLogRTB.Clear();
        }

        private void AllLogRTB_DoubleClick(object sender, EventArgs e)
        {
            AllLogRTB.Clear();
        }

        private void ClearAllLogRtbBtn_Click(object sender, EventArgs e)
        {
            AllLogRTB.Clear();
            ExecLogRTB.Clear();
            RobotLogRTB.Clear();
            AuxLogRTB.Clear();
            ErrorLogRTB.Clear();
        }
        private void ChangeLogLevel(string s)
        {
            LogManager.Configuration.Variables["myLevel"] = s;
            LogManager.ReconfigExistingLoggers();
        }
        private void DebugLevelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLogLevel(LogLevelCombo.Text);
        }
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            SplashForm splashForm = new SplashForm(this)
            {
                AutoClose = false
            };
            splashForm.ShowDialog();
        }
        #endregion ===== LOG TAB CONTROLS                   ==============================================================================================================================

        #region ===== MAIN UI CONTROLS                  ==============================================================================================================================
        private DialogResult ConfirmMessageBox(string question)
        {
            log.Info($"ConfirmMessageBox({question})");
            MessageDialog messageForm = new MessageDialog(this)
            {
                Title = "System Confirmation",
                Label = question,
                OkText = "&Yes",
                CancelText = "&No"
            };
            DialogResult result = messageForm.ShowDialog();
            return result;
        }
        public DialogResult ErrorMessageBox(string message)
        {
            log.Error($"ErrorMessageBox({message.Replace('\n', ' ')})");
            MessageDialog messageForm = new MessageDialog(this)
            {
                Title = "System ERROR",
                Label = "ERROR\n" + message,
                TextColor = Color.Red,
                OkText = "&OK",
                CancelText = "&Cancel"
            };
            DialogResult result = messageForm.ShowDialog();
            return result;
        }
        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = MainTab.TabPages[MainTab.SelectedIndex].Text;

            if (tabName == "Logs")
            {
                // This forces the log RTBs to all update... otherwise there are artifacts left over from NLog the first time in on program start
                for (int i = 0; i < 2; i++)
                {
                    AllLogRTB.Refresh();
                    ExecLogRTB.Refresh();
                    RobotLogRTB.Refresh();
                    AuxLogRTB.Refresh();
                    ErrorLogRTB.Refresh();
                }
            }
        }
        // Prevents selecting (seeing) a tab page that is not enabled
        private void MainTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex < 0) return;

            if (!e.TabPage.Enabled)
            {
                ErrorMessageBox($"{e.TabPage.Name} not allowed for User {operatorMode}");
                e.Cancel = true;
            }
        }


        private void SetState(RunState s, bool fForce = false)
        {
            if (fForce || runState != s)
            {
                runState = s;
                log.Debug("EXEC SetState({0},{1})", s.ToString(), fForce.ToString());

                EnterRunState();
            }
        }
        private void SetManualMoveButtons(bool f)
        {
            bool enable = f && robotReady;

            JogRunBtn.Enabled = enable;
            JogBtn.Enabled = enable;
            PositionMovePoseBtn.Enabled = enable;
            PositionMoveArmBtn.Enabled = enable;
            PositionSetBtn.Enabled = enable;
            MoveToolMountBtn.Enabled = enable;
            MoveToolHomeBtn.Enabled = enable;
        }

        private void SetVariableEditing(bool f)
        {
            BigEditBtn.Enabled = f;
            ClearAllPositionsBtn.Enabled = f;
            ClearPositionsBtn.Enabled = f;
            ClearVariablesBtn.Enabled = f;
            ClearAllVariablesBtn.Enabled = f;
        }

        private void EnterRunState()
        {
            switch (runState)
            {
                case RunState.IDLE:
                    RunStateLbl.Text = "IDLE";
                    RunStateLbl.BackColor = Color.Gray;

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = true;
                    RobotModeBtn.Enabled = true;
                    RobotSafetyStatusBtn.Enabled = true;
                    RobotProgramStateBtn.Enabled = true;


                    UserModeBox.Enabled = true;

                    ExitBtn.Enabled = true;

                    SetManualMoveButtons(true);
                    SetVariableEditing(true);

                    LoadSequenceBtn.Enabled = true;
                    NewSequenceBtn.Enabled = true;
                    SaveSequenceBtn.Enabled = SequenceWasModified();
                    SaveSequenceAsBtn.Enabled = true;

                    SetupTab.Enabled = true;

                    StartBtn.Enabled = false;
                    StepBtn.Enabled = false;
                    PauseBtn.Enabled = false;
                    StopBtn.Enabled = false;
                    GrindContactEnabledBtn.Enabled = true;

                    MountedToolBox.Enabled = true;
                    PartGeometryBox.Enabled = true;
                    DiameterLbl.Enabled = true;

                    ExecTmr.Enabled = false;
                    CurrentLineLbl.Text = "";
                    SequenceRTB.Enabled = true;
                    break;
                case RunState.READY:
                    RunStateLbl.Text = "STOPPED";
                    RunStateLbl.BackColor = Color.Red;
                    sleepTimer = null; // Cancels any pending sleep(...)

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = true;
                    RobotModeBtn.Enabled = true;
                    RobotSafetyStatusBtn.Enabled = true;
                    RobotProgramStateBtn.Enabled = true;

                    UserModeBox.Enabled = true;

                    ExitBtn.Enabled = true;

                    SetManualMoveButtons(true);
                    SetVariableEditing(true);

                    LoadSequenceBtn.Enabled = true;
                    NewSequenceBtn.Enabled = true;
                    SaveSequenceBtn.Enabled = SequenceWasModified();
                    SaveSequenceAsBtn.Enabled = true;

                    SetupTab.Enabled = true;

                    StartBtn.Enabled = protection.RunLEonard(); // Only enable if licensed!!
                    StepBtn.Enabled = protection.RunLEonard(); // Only enable if licensed!!;
                    PauseBtn.Enabled = false;
                    StopBtn.Enabled = false;
                    GrindContactEnabledBtn.Enabled = true;

                    MountedToolBox.Enabled = true;
                    PartGeometryBox.Enabled = true;
                    DiameterLbl.Enabled = true;

                    ExecTmr.Enabled = false;
                    //CurrentLineLbl.Text = "";
                    SequenceRTB.Enabled = true;

                    // If this was left open, it is now closed!
                    fileManager?.AllClose();
                    fileManager = null;
                    break;
                case RunState.RUNNING:
                    log.Debug($"Clearing callStack (had {callStack.Count} items)");
                    callStack.Clear();

                    RunStateLbl.Text = "RUNNING";
                    RunStateLbl.BackColor = Color.Green;
                    sleepTimer = null; // Cancels any pending sleep(...)

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = false;
                    RobotModeBtn.Enabled = false;
                    RobotSafetyStatusBtn.Enabled = false;
                    RobotProgramStateBtn.Enabled = false;

                    UserModeBox.Enabled = false;

                    ExitBtn.Enabled = false;

                    SetManualMoveButtons(false);
                    SetVariableEditing(false);

                    LoadSequenceBtn.Enabled = false;
                    NewSequenceBtn.Enabled = false;
                    SaveSequenceBtn.Enabled = false;
                    SaveSequenceAsBtn.Enabled = false;

                    SetupTab.Enabled = false;

                    StartBtn.Enabled = false;
                    StepBtn.Enabled = false;
                    PauseBtn.Enabled = true;
                    PauseBtn.Text = "Pause";
                    StopBtn.Enabled = true;
                    GrindContactEnabledBtn.Enabled = false;

                    MountedToolBox.Enabled = false;
                    PartGeometryBox.Enabled = false;
                    DiameterLbl.Enabled = false;

                    CurrentLineLbl.Text = "";
                    SequenceRTB.Enabled = false;

                    ExecTmr.Interval = 100;
                    ExecTmr.Enabled = true;
                    waitingForOperatorMessageForm = null;

                    break;
                case RunState.PAUSED:
                    RunStateLbl.Text = "PAUSED";
                    RunStateLbl.BackColor = Color.DarkOrange;

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = true;
                    RobotModeBtn.Enabled = true;
                    RobotSafetyStatusBtn.Enabled = true;
                    RobotProgramStateBtn.Enabled = true;

                    UserModeBox.Enabled = false;

                    ExitBtn.Enabled = false;

                    SetManualMoveButtons(false);
                    SetVariableEditing(false);

                    LoadSequenceBtn.Enabled = false;
                    NewSequenceBtn.Enabled = false;
                    SaveSequenceBtn.Enabled = false;
                    SaveSequenceAsBtn.Enabled = false;

                    SetupTab.Enabled = true;

                    StartBtn.Enabled = false;
                    StepBtn.Enabled = protection.RunLEonard(); // Only enable if licensed!!;
                    PauseBtn.Enabled = true;
                    PauseBtn.Text = "Continue";
                    StopBtn.Enabled = true;
                    GrindContactEnabledBtn.Enabled = true;

                    MountedToolBox.Enabled = false;
                    PartGeometryBox.Enabled = false;
                    DiameterLbl.Enabled = false;

                    SequenceRTB.Enabled = false;

                    ExecTmr.Enabled = false;
                    break;
            }

            ColorEnableButtonGreen(ExitBtn);
            ColorEnableButtonGreen(JogRunBtn);
            ColorEnableButtonGreen(JogBtn);
            ColorEnableButtonGreen(PositionMovePoseBtn);
            ColorEnableButtonGreen(PositionMoveArmBtn);
            ColorEnableButtonGreen(PositionSetBtn);
            ColorEnableButtonGreen(MoveToolMountBtn);
            ColorEnableButtonGreen(MoveToolHomeBtn);

            ColorEnableButtonGreen(LoadSequenceBtn);
            ColorEnableButtonGreen(NewSequenceBtn);
            ColorEnableButtonGreen(SaveSequenceBtn);
            ColorEnableButtonGreen(SaveSequenceAsBtn);

            ColorEnableButtonGreen(StartBtn);
            ColorEnableButton(PauseBtn, Color.DarkOrange);
            ColorEnableButtonGreen(StepBtn);
            ColorEnableButton(StopBtn, Color.Red);

            ColorEnableButtonGreen(BigEditBtn);
            ColorEnableButtonGreen(ClearAllPositionsBtn);
            ColorEnableButtonGreen(ClearPositionsBtn);
            ColorEnableButtonGreen(ClearVariablesBtn);
            ColorEnableButtonGreen(ClearAllVariablesBtn);
        }
        private void ColorEnableButtonGreen(Control c)
        {
            ColorEnableButton(c, Color.Green);
        }
        private void ColorEnableButton(Control c, Color enableColor)
        {
            c.BackColor = c.Enabled ? enableColor : Color.Gray;
        }

        bool mountedToolBoxActionDisabled = false;
        private void MountedToolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mountedToolBoxActionDisabled) return;

            ToolsGrd.ClearSelection();
            if (LeUrCommand.uiFocusInstance != null && MountedToolBox.Text.Length > 0)
                select_tool(MountedToolBox.Text);
        }

        private void UpdateGeometryToRobot()
        {
            if (LeUrCommand.uiFocusInstance != null)
            {
                PerformRobotCommand($"set_part_geometry_N({PartGeometryBox.SelectedIndex + 1},{DiameterLbl.Text})");
                WriteVariable("robot_geometry", $"{PartGeometryBox.SelectedItem},{DiameterLbl.Text}");
            }
        }

        bool partGeometryBoxDisabled = false;
        private void PartGeometryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.Info("PartGeometryBox changed to " + PartGeometryBox.Text + (partGeometryBoxDisabled ? " UPDATE DISABLED" : ""));
            if (partGeometryBoxDisabled) return;
            bool isFlat = PartGeometryBox.Text == "FLAT";
            if (isFlat)
            {
                DiameterLbl.Text = "0.0";
                DiameterLbl.Visible = false;
                DiameterDimLbl.Visible = false;
            }
            else
            {
                int index = PartGeometryBox.SelectedIndex;
                DiameterLbl.Text = diameterDefaults[index];
                DiameterLbl.Visible = true;
                DiameterDimLbl.Visible = true;
            }

            UpdateGeometryToRobot();
        }

        public enum ControlSetting
        {
            HIDDEN,
            DISABLED,
            NORMAL
        };
        public class ControlSpec
        {
            public Control control;
            public ControlSetting[] settings = new ControlSetting[3];
            public ControlSpec(Control c, ControlSetting operatorSetting, ControlSetting editorSetting, ControlSetting engineeringSetting)
            {
                control = c;
                settings[0] = operatorSetting;
                settings[1] = editorSetting;
                settings[2] = engineeringSetting;
            }
        }
        static private ControlSpec[] controlSpecs = null;
        private void BuildEnableTable()
        {
            controlSpecs = new ControlSpec[]
            {
                // Position UI Buttons
                new ControlSpec(ClearPositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearAllPositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),

                // Variable UI  Buttons
                new ControlSpec(ClearVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearAllVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),

                // Position Setting Buttons
                new ControlSpec(PositionMovePoseBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(PositionMoveArmBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(PositionSetBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(JogBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
            };

        }

        private void OperatorModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlSpecs == null) BuildEnableTable();

            OperatorMode origOperatorMode = operatorMode;
            OperatorMode newOperatorMode = (OperatorMode)UserModeBox.SelectedIndex;

#if !DEBUG
            // Enforce any password requirements (unless we're in DEBUG for convenience or if we force OperatorMode)
            if (!useOperatorModeOverride)
            {
                switch (newOperatorMode)
                {
                    case OperatorMode.OPERATOR:
                        break;
                    case OperatorMode.EDITOR:
                        SetValueForm form = new SetValueForm(this)
                        {
                            Value = 0,
                            Label = "Passcode for EDITOR",
                            NumberOfDecimals = 0,
                            MaxAllowed = 999999,
                            MinAllowed = 0,
                            IsPassword = true,
                        };
                        if (form.ShowDialog(this) != DialogResult.OK || form.Value != 9)
                        {
                            UserModeBox.SelectedIndex = 0;
                            return;
                        }
                        break;
                    case OperatorMode.ENGINEERING:
                        form = new SetValueForm(this)
                        {
                            Value = 0,
                            Label = "Passcode for ENGINEERING",
                            NumberOfDecimals = 0,
                            MaxAllowed = 999999,
                            MinAllowed = 0,
                            IsPassword = true,
                        };
                        if (form.ShowDialog(this) != DialogResult.OK || form.Value != 99)
                        {
                            UserModeBox.SelectedIndex = 0;
                            return;
                        }
                        break;
                }
            }
#endif
            operatorMode = newOperatorMode;

            const int RunPage = 0;
            const int CodePage = 1;
            const int SetupPage = 2;
            const int LogPage = 3;
            if (MainTab.TabPages[1] != null)  // Helps during program load before instantiation!
            {
                log.Info("Setting Operator Mode {0}", operatorMode);
                switch (operatorMode)
                {
                    case OperatorMode.OPERATOR:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[CodePage].Enabled = false;
                        MainTab.TabPages[SetupPage].Enabled = false;
                        MainTab.TabPages[LogPage].Enabled = true;
                        MainTab.SelectedIndex = 0;
                        break;
                    case OperatorMode.EDITOR:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[CodePage].Enabled = true;
                        MainTab.TabPages[SetupPage].Enabled = false;
                        MainTab.TabPages[LogPage].Enabled = true;
                        MainTab.SelectedIndex = 1;
                        break;
                    case OperatorMode.ENGINEERING:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[CodePage].Enabled = true;
                        MainTab.TabPages[SetupPage].Enabled = true;
                        MainTab.TabPages[LogPage].Enabled = true;
                        break;
                }
            }

            foreach (ControlSpec spec in controlSpecs)
            {
                Control c = spec.control;
                switch (spec.settings[(int)operatorMode])
                {
                    case ControlSetting.HIDDEN:
                        c.Enabled = false;
                        c.Visible = false;
                        break;
                    case ControlSetting.DISABLED:
                        c.Enabled = false;
                        c.Visible = true;
                        if (c.GetType().Name == "Button") c.BackColor = Color.Gray;
                        break;
                    case ControlSetting.NORMAL:
                        c.Enabled = true;
                        c.Visible = true;
                        if (c.GetType().Name == "Button") c.BackColor = Color.Green;
                        break;

                }
            }

            // Reenable other buttons and tabs as dictated by currect runState
            SetState(runState, true);
        }

        private void RobotModeBtn_Click(object sender, EventArgs e)
        {
            CloseSafetyPopup();
            switch (RobotModeBtn.Text)
            {
                case "Robotmode: RUNNING":
                    LeUrDashboard.uiFocusInstance?.Send("power off");
                    break;
                case "Robotmode: IDLE":
                    LeUrDashboard.uiFocusInstance?.Send("brake release");
                    break;
                case "Robotmode: POWER_OFF":
                    LeUrDashboard.uiFocusInstance?.Send("power on");
                    break;
                default:
                    log.Error($"Unknown robot mode button state! {RobotModeBtn.Text}");
                    ErrorMessageBox($"Unsure how to recover from {RobotModeBtn.Text}");
                    break;
            }
        }

        private void SafetyStatusBtn_Click(object sender, EventArgs e)
        {
            CloseSafetyPopup();
            // Note the _ in the return values have been removed!
            switch (RobotSafetyStatusBtn.Text)
            {
                case "Safetystatus: NORMAL":
                    LeUrDashboard.uiFocusInstance?.Send("power off");
                    break;
                case "Safetystatus: PROTECTIVE STOP":
                    ur_dashboard("unlock protective stop", 200);
                    ur_dashboard("close safety popup", 200);

                    break;
                case "Safetystatus: ROBOT EMERGENCY STOP":
                    ErrorMessageBox("Release Robot E-Stop");
                    ur_dashboard("close safety popup", 200);
                    break;
                default:
                    log.Error("Unknown safety status button state! {0}", RobotSafetyStatusBtn.Text);
                    ErrorMessageBox(String.Format("Unsure how to recover from {0}", RobotSafetyStatusBtn.Text));
                    break;
            }
        }
        private void SetupTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = SetupTab.TabPages[SetupTab.SelectedIndex].Text;

            // Actions to take on entering particular tabs
            if (tabName == "Tools")
                // Highlight the current tool selected in the grid
                SelectDataGridViewRow(ToolsGrd, MountedToolBox.Text);

            if (tabName == "Displays")
                // Highlight the curent display selected in the grid
                SelectDataGridViewRow(DisplaysGrd, SelectedDisplayLbl.Text);

            if (tabName == "License")
            {
                // Hide adjustment controls!
                LicenseAdjustGrp.Visible = false;
                // Update current license status
                GetLicenseStatus();
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion =================================================== MAIN UI BUTTONS ===================================================================

        #region ===== RUN FUNCTIONS                     ==============================================================================================================================

        private void GrindContactEnabledBtn_Click(object sender, EventArgs e)
        {
            log.Info("GrindContactEnabledBtn_Click(...)");
            string var = ReadVariable("grind_contact_enable", "0");
            // Increment current setting to cycle through 0, 1, 2
            int val = Convert.ToInt32(var);
            val++;
            val %= 3;
            RobotSend(String.Format("35,1,{0}", val));
        }

        private bool PrepareToRun()
        {
            // Mark and display the start time, set counters to 0
            runStartedTime = DateTime.Now;
            RunStartedTimeLbl.Text = runStartedTime.ToString();
            GrindCycleLbl.Text = "";
            GrindNCyclesLbl.Text = "";
            StepTimeEstimateLbl.Text = "";
            WriteVariable("sysStartTime", runStartedTime.ToString("yyyy-MM-ddTHH-mm-ss"), true, true);


            // Set initial language
            string sequenceFilename = SequenceFilenameLbl.Text;
            LEonardLanguages lang = LEonardLanguages.LEScript;
            if (sequenceFilename.EndsWith(".js")) lang = LEonardLanguages.Java;
            if (sequenceFilename.EndsWith(".py")) lang = LEonardLanguages.Python;
            SetLanguage(lang);

            // Wipe the engines
            InitializeJavaEngine();
            InitializePythonEngine();

            // Gocator
            // TODO this needs to be generalized
            LeGocator.uiFocusInstance?.PrepareToRun();

            SetCurrentLine(0);
            bool goodLabels = BuildLabelTable();
            return goodLabels;
        }

        private bool OkToRun()
        {
            if (!protection.RunLEonard())
            {
                ErrorMessageBox("Cannot run. LEonard license missing!");
                return false;
            }

            /*
            if (!ProgramStateBtn.Text.StartsWith("PLAYING"))
            {
                ErrorMessageBox("Cannot run. Program not running!");
                return false;
            }

            if (ReadVariable("robot_door_closed", "False") != "True")
            {
                ErrorMessageBox("Cannot run. Door Open!");
                return false;
            }
            if (ReadVariable("robot_footswitch_pressed", "True") == "True")
            {
                ErrorMessageBox("Cannot run. Footswitch Pressed!");
                return false;
            }

            // Is the board green?
            bool boardIsGreen =
                RobotCommandStatusLbl.BackColor == Color.Green &&
                RobotCompletedLbl.BackColor == Color.Green &&
                RobotReadyLbl.BackColor == Color.Green &&
                GrindReadyLbl.BackColor == Color.Green &&
                GrindProcessStateLbl.BackColor == Color.Green;
            if (!boardIsGreen)
            {
                ErrorMessageBox("The board is not green! Cannot run.");
                return false;
            }
            */


            return true;
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            log.Info("StartBtn_Click(...)");

            if (!OkToRun()) return;

            if (PrepareToRun())
            {
                isSingleStep = false;
                SetSequenceState(SequenceState.RUNNING);
                SetState(RunState.RUNNING);
            }
        }
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            log.Info("PauseBtn{0}_Click(...)", PauseBtn.Text);
            switch (runState)
            {
                case RunState.RUNNING:
                    // Perform PAUSE function
                    PerformPause();
                    break;
                case RunState.PAUSED:
                    // Perform CONTINUE function
                    if (!OkToRun()) return;

                    MessageDialog messageForm = new MessageDialog(this)
                    {
                        Title = "System Question",
                        Label = "Repeat highlighted line or move on ?",
                        OkText = "&Repeat",
                        CancelText = "&Move On"
                    };
                    DialogResult result = messageForm.ShowDialog();
                    if (result == DialogResult.OK) lineCurrentlyExecuting--;
                    RobotSendHalt();
                    SetState(RunState.RUNNING);
                    break;
            }
        }

        private void StepBtn_Click(object sender, EventArgs e)
        {
            log.Info("StepBtn_Click(...) STATE IS {0}", runState);
            if (!OkToRun()) return;

            switch (runState)
            {
                case RunState.READY:
                    // This is like hitting "Start" except we also set isSingleStep so we'll halt after line 1
                    if (PrepareToRun())
                    {
                        isSingleStep = true;
                        SetSequenceState(SequenceState.RUNNING);
                        SetState(RunState.RUNNING);
                    }
                    break;
                case RunState.PAUSED:
                    // Perform STEP function
                    MessageDialog messageForm = new MessageDialog(this)
                    {
                        Title = "System Question",
                        Label = "Repeat highlighted line or move on to next?",
                        OkText = "&Repeat",
                        CancelText = "&Move On"
                    };
                    DialogResult result = messageForm.ShowDialog();
                    if (result == DialogResult.OK) lineCurrentlyExecuting--;
                    RobotSendHalt();
                    isSingleStep = true;
                    SetState(RunState.RUNNING);
                    break;
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            log.Info("StopBtn_Click(...)");
            RobotSendHalt();

            UnboldSequence();
            SetState(RunState.READY);
            SetSequenceState(sequenceStateAtRun);
        }
        #endregion ===== RUN FUNCTIONS                     ==============================================================================================================================

        #region ===== LESCRIPT / CODE EDIT SUPPORT      ==============================================================================================================================
        private enum SequenceState
        {
            INIT,
            NEW,
            LOADED,
            MODIFIED,
            RUNNING
        }
        SequenceState sequenceState = SequenceState.INIT;
        SequenceState sequenceStateAtRun = SequenceState.INIT;
        private void SetSequenceState(SequenceState s)
        {
            if (sequenceState != s)
            {
                log.Debug("SetSequenceState({0})", s.ToString());

                SequenceState oldSequenceState = sequenceState;
                sequenceState = s;

                switch (sequenceState)
                {
                    case SequenceState.NEW:
                        NewSequenceBtn.Enabled = false;
                        LoadSequenceBtn.Enabled = true;
                        SaveSequenceBtn.Enabled = false;
                        SaveSequenceAsBtn.Enabled = true;
                        break;
                    case SequenceState.LOADED:
                        NewSequenceBtn.Enabled = true;
                        LoadSequenceBtn.Enabled = true;
                        SaveSequenceBtn.Enabled = false;
                        SaveSequenceAsBtn.Enabled = true;
                        break;
                    case SequenceState.MODIFIED:
                        NewSequenceBtn.Enabled = true;
                        LoadSequenceBtn.Enabled = true;
                        SaveSequenceBtn.Enabled = true;
                        SaveSequenceAsBtn.Enabled = true;
                        break;
                    case SequenceState.RUNNING:
                        sequenceStateAtRun = oldSequenceState;
                        NewSequenceBtn.Enabled = false;
                        LoadSequenceBtn.Enabled = false;
                        SaveSequenceBtn.Enabled = false;
                        SaveSequenceAsBtn.Enabled = false;
                        break;
                }
                NewSequenceBtn.BackColor = NewSequenceBtn.Enabled ? Color.Green : Color.Gray;
                LoadSequenceBtn.BackColor = LoadSequenceBtn.Enabled ? Color.Green : Color.Gray;
                SaveSequenceBtn.BackColor = SaveSequenceBtn.Enabled ? Color.Green : Color.Gray;
                SaveSequenceAsBtn.BackColor = SaveSequenceAsBtn.Enabled ? Color.Green : Color.Gray;
            }
        }

        public void SetupSequenceDefaults()
        {
            // Write System variables and set presumed language
            WriteVariable("sysSequenceFilename", Path.GetFileName(SequenceFilenameLbl.Text), true, true);
            WriteVariable("sysSequencePath", Path.GetDirectoryName(SequenceFilenameLbl.Text).Replace('\\','/'), true, true);
            if (SequenceFilenameLbl.Text.EndsWith(".js")) SetLanguage(LEonardLanguages.Java);
            else if (SequenceFilenameLbl.Text.EndsWith(".py")) SetLanguage(LEonardLanguages.Python);
            else SetLanguage(LEonardLanguages.LEScript);
        }

        private string sequenceAsLoaded = "";  // As it was when loaded so we can test for actual mods
        private bool SequenceWasModified()
        {
            return sequenceAsLoaded != SequenceRTB.Text;
        }
        bool LoadSequenceFile(string file)
        {
            log.Info("LoadSequenceFile({0})", file);
            SequenceFilenameLbl.Text = "";
            SequenceRTB.Text = "";
            try
            {
                SequenceRTB.LoadFile(file, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                SequenceFilenameLbl.Text = file;
                sequenceAsLoaded = SequenceRTB.Text;

                SetupSequenceDefaults();

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Can't open {0}", file);
                return false;
            }
        }

        private void NewSequenceBtn_Click(object sender, EventArgs e)
        {
            log.Info("NewSequenceBtn_Click(...)");
            if (SequenceWasModified())
            {
                var result = ConfirmMessageBox(String.Format("Sequence [{0}] has changed.\nSave changes?", LoadSequenceBtn.Text));
                if (result == DialogResult.OK)
                    SaveSequenceBtn_Click(null, null);
            }

            SetSequenceState(SequenceState.NEW);
            SetState(RunState.IDLE);
            SequenceFilenameLbl.Text = "Untitled";
            SequenceRTB.Clear();
            sequenceAsLoaded = "";
            MainTab.SelectedIndex = 1; // = "Program";
        }

        private void LoadSequenceBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadSequenceBtn_Click(...)");
            if (SequenceWasModified())
            {
                var result = ConfirmMessageBox(String.Format("Sequence [{0}] has changed.\nSave changes?", LoadSequenceBtn.Text));
                if (result == DialogResult.OK)
                    SaveSequenceBtn_Click(null, null);
            }

            string initialDirectory;
            if (SequenceFilenameLbl.Text != "Untitled" && SequenceFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(SequenceFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Sequence",
                Filter = "SEQUENCE",
                InitialDirectory = initialDirectory
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadSequenceFile(dialog.FileName))
                {
                    SetSequenceState(SequenceState.LOADED);
                    SetState(RunState.READY);
                }
            }
        }

        private void SaveSequenceBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveSequenceBtn_Click(...)");
            if (SequenceFilenameLbl.Text == "Untitled" || SequenceFilenameLbl.Text == "")
                SaveSequenceAsBtn_Click(null, null);
            else
            {
                log.Info("Save Sequence to {0}", SequenceFilenameLbl.Text);
                SequenceRTB.SaveFile(SequenceFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                sequenceAsLoaded = SequenceRTB.Text;
                SetSequenceState(SequenceState.LOADED);
                SetState(RunState.READY);
            }
        }

        private void SaveSequenceAsBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveSequenceAsBtn_Click(...)");

            string initialDirectory;
            if (SequenceFilenameLbl.Text != "Untitled" && SequenceFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(SequenceFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Sequence As...",
                Filter = "SEQUENCE",
                Extension = "SEQUENCE",
                InitialDirectory = initialDirectory,
                FileName = SequenceFilenameLbl.Text,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    log.Error($"{filename}");
                    bool fExtensionOK = false;
                    if (filename.EndsWith(".lescript")) fExtensionOK = true;
                    if (filename.EndsWith(".js")) fExtensionOK = true;
                    if (filename.EndsWith(".py")) fExtensionOK = true;

                    if (!fExtensionOK) filename += ".lescript";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox($"File {filename} already exists. Overwrite?"))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        SequenceFilenameLbl.Text = filename;
                        SetupSequenceDefaults();
                        SaveSequenceBtn_Click(null, null);
                    }
                }
            }
        }
        private void LEonardScriptRTB_ModifiedChanged(object sender, EventArgs e)
        {
            SetSequenceState(SequenceState.MODIFIED);
        }

        // Below 2 functions could be used to try to keep the scrolls of the two Sequence windows in sync someday
        // Some complexity here.......
        private void LEonardScriptRTBCopy_VScroll(object sender, EventArgs e)
        {
            //log.Info("LEonardScriptRTBCopy_VScroll");

            //RichTextBox r = (RichTextBox)sender;
            //log.Info("ss",r.)

        }

        private void LEonardScriptRTB_VScroll(object sender, EventArgs e)
        {
            //log.Info("LEonardScriptRTB_VScroll");

        }
        private void CurrentLineLbl_TextChanged(object sender, EventArgs e)
        {
            CurrentLineLblCopy.Text = CurrentLineLbl.Text;
        }

        private void SequenceFilenameLbl_TextChanged(object sender, EventArgs e)
        {
            LoadSequenceBtn.Text = Path.GetFileName(SequenceFilenameLbl.Text);
        }

        private void SequenceRTB_TextChanged(object sender, EventArgs e)
        {
            if (runState != RunState.RUNNING)
            {
                SetSequenceState(SequenceState.MODIFIED);
            }
            SequenceRTBCopy.Text = SequenceRTB.Text;
        }

        public void ShowPDF(string filename)
        {
            string full_filename = $@"{LEonardRoot}\Documentation\{filename}";
            System.Diagnostics.Process.Start(full_filename);

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "chrome.exe";
            //startInfo.Arguments = $"/incognito file:\\{LEonardRoot}\\Documentation\\{filename}";
            //process.StartInfo = startInfo;
            //process.Start();
        }
        private void FullManualBtn_Click(object sender, EventArgs e)
        {
            ShowPDF("LEonard User Manual.pdf");
        }
        private void URManualBtn_Click(object sender, EventArgs e)
        {
            ShowPDF("Using Universal Robots with LEonard.pdf");
        }

        private void GocatorManualBtn_Click(object sender, EventArgs e)
        {
            ShowPDF("Using LMI Gocators with LEonard.pdf");
        }

        public int RunVSCode(string filename)
        {
            /*
            string full_filename = $@"{LEonardRoot}\Code\{filename}";
            try
            {
                System.Diagnostics.Process.Start(full_filename);
                return 0;
            }
            catch
            {
                log.Error($"Could not execute {full_filename}");
                return 1;
            }*/



            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = $@"\{LEonardRoot}\Code\";
            startInfo.FileName = "code";
            startInfo.Arguments = filename;
            process.StartInfo = startInfo;
            process.Start();
            return 0;
        }


        private void BigEditBtn_Click(object sender, EventArgs e)
        {

            log.Info("BigEditBtn_Click(...)");

            //if (0 == RunVSCode(SequenceFilenameLbl.Text)) return;
            if (0 == RunVSCode(Path.Combine(LEonardRoot, "Code", "LEonard-code.code-workspace"))) return;

            // The old BigEdit for users who don't have VS Code
            BigEditDialog bigeditForm = new BigEditDialog(this)
            {
                Title = SequenceFilenameLbl.Text,
                ScreenWidth = Width,
                ScreenHeight = Height,
                Program = SequenceRTB.Text
            };
            bigeditForm.ShowDialog();

            log.Info("BigEditDialog returns {0}", bigeditForm.DialogResult);

            if (bigeditForm.DialogResult == DialogResult.OK)
            {
                SequenceRTB.Text = bigeditForm.Program;
                log.Info("Installing from BigEdit");
            }
        }


        #endregion ===== LESCRIPT / CODE EDIT SUPPORT      ==============================================================================================================================

        #region ===== SETUP FUNCTIONS                   ==============================================================================================================================
        private void DefaultConfigBtn_Click(object sender, EventArgs e)
        {
            log.Info("DefaultConfigBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the General Configuration settings. Proceed?"))
                return;

            SetLEonardRoot(DEFAULT_LEonardRoot);
        }
        private void LoadConfigBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadConfigBtn_Click(...)");
            LoadPersistent();
        }
        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveConfigBtn_Click(...)");
            SavePersistent();
        }
        public void MakeStandardSubdirectories()
        {
            // If ConfigDir doesn't exist, wipe out any default devices file!
            if (System.IO.Directory.Exists(System.IO.Path.Combine(LEonardRoot, ConfigFolder)))
                log.Info("Config Folder Exists!");
            else
            {
                // The first time we load in a new folder, we'll default the devices
                log.Info("Config Folder doesn't exists!");
                StartupDevicesLbl.Text = "";
                AutoConnectOnLoadChk.Checked = false;
                SavePersistentStartupDevices();
            }

            // Make standard subdirectories (if they don't exist)
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(LEonardRoot, ConfigFolder));
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(LEonardRoot, CodeFolder));
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(LEonardRoot, DataFolder));
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(LEonardRoot, LogsFolder));
        }

        // The root Rgistry key location for all of LEonard
        public RegistryKey GetAppNameKey()
        {
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey LeckyEngineeringKey = SoftwareKey.CreateSubKey("Lecky Engineering");
            return LeckyEngineeringKey.CreateSubKey("LEonard");
        }

        void LoadRootDirectory()
        {
            RegistryKey AppNameKey = GetAppNameKey();

            LEonardRoot = (string)AppNameKey.GetValue("LEonardRoot", @"C:\Users\Public\LEonard");

            if (!Directory.Exists(LEonardRoot))
            {
                DialogResult result = ConfirmMessageBox(String.Format("Root Directory [{0}] does not exist. Create it?", LEonardRoot));
                if (result == DialogResult.OK)
                {
                    System.IO.Directory.CreateDirectory(LEonardRoot);
                    sequenceFileToAutoload = "";
                }
                else
                {
                    forceClose = true;
                    Close();
                    return;
                }
            }
        }

        private string sequenceFileToAutoload = "";
        void LoadPersistent()
        {
            // Pull setup info from registry.... these are overwritten on exit or with various config save operations
            // Note default values are specified here as well
            log.Info("LoadPersistent()");

            if (LEonardRoot == null || LEonardRoot == "") LoadRootDirectory();
            MakeStandardSubdirectories();

            RegistryKey AppNameKey = GetAppNameKey();

            // Window State
            RegistryKey UIKey = AppNameKey.CreateSubKey("UI");
            SuspendLayout();
            Left = (Int32)UIKey.GetValue("Left", 0);
            Top = (Int32)UIKey.GetValue("Top", 0);
            Width = (Int32)UIKey.GetValue("Width", screenDesignWidth);
            Height = (Int32)UIKey.GetValue("Height", screenDesignHeight);
            ResumeLayout();
            FormBorderStyle = (FormBorderStyle)UIKey.GetValue("BorderStyle", FormBorderStyle.None);
            ControlBox = Convert.ToBoolean(UIKey.GetValue("ControlBox", "False"));
            MaximizeBox = Convert.ToBoolean(UIKey.GetValue("MaximizeBox", "False"));
            MinimizeBox = Convert.ToBoolean(UIKey.GetValue("MinimizeBox", "False"));
            WindowState = (FormWindowState)UIKey.GetValue("WindowState", FormWindowState.Normal);

            LEonardRootLbl.Text = LEonardRoot;

            StartupDevicesLbl.Text = (string)AppNameKey.GetValue("StartupDevicesLbl.Text", "");
            AutoConnectOnLoadChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoConnectOnLoadChk.Checked", "False"));

            // Operator Mode
            // Ignore persistence here: if we're running in debug it will kindly start us in Engineering mode else Operator
#if DEBUG
            operatorMode = OperatorMode.ENGINEERING;
#else
            if (useOperatorModeOverride)
                operatorMode = operatorModeOverride;
            else
                operatorMode = OperatorMode.OPERATOR; // (OperatorMode)(Int32)AppNameKey.GetValue("operatorMode", 0);
#endif
            UserModeBox.SelectedIndex = (int)operatorMode;

            // Debug Level selection (Persistent in Engineering mode, else forced to "Info"
            if (operatorMode == OperatorMode.ENGINEERING)
                LogLevelCombo.Text = (string)AppNameKey.GetValue("LogLevelCombo.Text", "Info");
            else
                LogLevelCombo.Text = "Info";

            // Restore displays table and set display mode
            LoadDisplaysBtn_Click(null, null);
            SelectedDisplayLbl.Text = (string)AppNameKey.GetValue("SelectedDisplayLbl.Text", "Default");
            uiUpdatesAreLive = true;
            SelectDisplayMode(SelectedDisplayLbl.Text);
            uiUpdatesAreLive = false;

            // Load the tools table
            LoadToolsBtn_Click(null, null);

            // Load the positions table
            LoadPositions();

            // Load the variables table
            LoadVariables();

            // Autoload file is the last loaded Sequence
            sequenceFileToAutoload = (string)AppNameKey.GetValue("SequenceFilenameLbl.Text", "");

            // Retrieve currently mounted tool
            MountedToolBox.Text = (string)AppNameKey.GetValue("MountedToolBox.Text", "");

            // Retrieve current part geometry
            for (int i = 0; i < 3; i++)
                diameterDefaults[i] = (string)AppNameKey.GetValue(String.Format("Diameter[{0}].Text", i), i == 0 ? "0.0" : "100.0");
            PartGeometryBox.Text = (string)AppNameKey.GetValue("PartGeometryBox.Text", "FLAT");

            // Load last loaded Java and Python programs
            LoadJavaProgram((string)AppNameKey.GetValue("JavaFilenameLbl.Text", "Untitled"));
            LoadPythonProgram((string)AppNameKey.GetValue("PythonFilenameLbl.Text", "Untitled"));
        }

        private void SavePersistentStartupDevices()
        {
            RegistryKey AppNameKey = GetAppNameKey();
            AppNameKey.SetValue("StartupDevicesLbl.Text", StartupDevicesLbl.Text);
            AppNameKey.SetValue("AutoConnectOnLoadChk.Checked", AutoConnectOnLoadChk.Checked);
        }

        void SavePersistent()
        {
            log.Info("SavePersistent()");

            RegistryKey AppNameKey = GetAppNameKey();

            // Window State
            RegistryKey UIKey = AppNameKey.CreateSubKey("UI");
            UIKey.SetValue("Left", Left);
            UIKey.SetValue("Top", Top);
            UIKey.SetValue("Width", Width);
            UIKey.SetValue("Height", Height);
            UIKey.SetValue("BorderStyle", (int)FormBorderStyle);
            UIKey.SetValue("ControlBox", ControlBox);
            UIKey.SetValue("MaximizeBox", MaximizeBox);
            UIKey.SetValue("MinimizeBox", MinimizeBox);
            UIKey.SetValue("WindowState", (int)WindowState);

            // From Setup Tab
            AppNameKey.SetValue("LEonardRoot", LEonardRoot);
            SavePersistentStartupDevices();

            // Operator Mode
            AppNameKey.SetValue("operatorMode", (Int32)operatorMode);

            // Log Level selection
            AppNameKey.SetValue("LogLevelCombo.Text", LogLevelCombo.Text);

            // Save currently selected display and displays table
            AppNameKey.SetValue("SelectedDisplayLbl.Text", SelectedDisplayLbl.Text);
            SaveDisplaysBtn_Click(null, null);

            // Save currently mounted tool and tools table
            AppNameKey.SetValue("MountedToolBox.Text", MountedToolBox.Text);
            SaveTools();

            // Save the positions table
            SavePositions();

            // Save the variables table
            SaveVariables();

            // Save currently loaded Sequence
            AppNameKey.SetValue("SequenceFilenameLbl.Text", SequenceFilenameLbl.Text);

            // Save current part geometry tool
            AppNameKey.SetValue("PartGeometryBox.Text", PartGeometryBox.Text);
            for (int i = 0; i < 3; i++)
                AppNameKey.SetValue(String.Format("Diameter[{0}].Text", i), diameterDefaults[i]);

            // Save currently loaded Java and Python programs
            AppNameKey.SetValue("JavaFilenameLbl.Text", JavaFilenameLbl.Text);
            AppNameKey.SetValue("PythonFilenameLbl.Text", PythonFilenameLbl.Text);
        }

        void SetLEonardRoot(string path)
        {
            LEonardRoot = path;
            LEonardRootLbl.Text = path;
            WriteVariable("sysLEonardRoot", path.Replace('\\', '/'), true);
        }
        private void ChangeRootDirectoryBtn_Click(object sender, EventArgs e)
        {
            log.Info("ChangeRootDirectoryBtn_Click(...)");
            DirectorySelectDialog dialog = new DirectorySelectDialog(this)
            {
                Title = "Select LEonard Root Directory",
                SelectedPath = LEonardRoot
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                log.Info("New LEonardRoot={0}", dialog.SelectedPath);
                SetLEonardRoot(dialog.SelectedPath);

                MakeStandardSubdirectories();
            }
        }

        private void JogBtn_Click(object sender, EventArgs e)
        {
            string partName = PartGeometryBox.Text;
            if (partName != "FLAT")
                partName += " " + DiameterLbl.Text + " mm DIA";

            JoggingDialog form = new JoggingDialog(this)
            {
                Prompt = "Jog to Desired Position",
                Tool = ReadVariable("robot_tool"),
                Part = partName
            };

            form.ShowDialog(this);
        }
        private void JogRunBtn_Click(object sender, EventArgs e)
        {
            JogBtn_Click(sender, e);
        }


        private void DiameterLbl_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = Convert.ToDouble(DiameterLbl.Text),
                Label = PartGeometryBox.Text + " DIAM, MM",
                NumberOfDecimals = 1,
                MaxAllowed = 3000,
                MinAllowed = 75,
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                DiameterLbl.Text = form.ValueOutString;
            }

            // Save value in slot associated with this geometry
            int index = PartGeometryBox.SelectedIndex;
            diameterDefaults[index] = DiameterLbl.Text;

            UpdateGeometryToRobot();
        }
        #endregion

        #region ===== DEVICES DATABASE SUPPORT CODE     ==============================================================================================================================
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
            devices.Columns.Add("TxPrefix", typeof(System.String));
            devices.Columns.Add("TxSuffix", typeof(System.String));
            devices.Columns.Add("RxTerminator", typeof(System.String));
            devices.Columns.Add("RxSeparator", typeof(System.String));
            devices.Columns.Add("OnConnectExec", typeof(System.String));
            devices.Columns.Add("OnDisconnectExec", typeof(System.String));
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
                0, "Command", false, false, "TcpServer", "127.0.0.1:1000",
                "A.CTL", "command",
                "", "<CR>", "<LF>", "#",
                "JE:le_send('me','Hello!')", "JE:le_send('me','exit')",
                true,
                @"C:\Users\Public\LEonard\LEonardClient\bin\Debug",
                "LEonardClient.exe",
                "",
                "",
                "",
                "",
                "test|exit",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                1, "UR-5eDash", false, false, "UrDashboard", "192.168.0.2:29999",
                "R.Dash", "",
                "", "<CR>", "<LF>", "",
                "", "",
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
                2, "UR-5eCommand", false, false, "UrCommand", "192.168.0.252:30000",
                "R.Cmd", "general",
                "", "<CR>", "<LF>", "#",
                "", "JE:le_send('me','999')",
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
                3, "Gocator", false, false, "Gocator", "192.168.0.3:8190",
                "A.GO", "gocator",
                "", "<CR>", "<LF>", "#",
                "", "",
                false,
                "",
                "",
                "",
                "",
                "",
                "",
                "trigger|stop|start",
                "LEonardHolefinder",
                "","","",
            });
            devices.Rows.Add(new object[] {
                4, "GocatorAcc", false, false, "Gocator", "192.168.0.252:8190",
                "A.GO", "gocator",
                "", "<CR>", "<LF>", "#",
                "", "",
                false,
                "",
                "",
                "",
                "",
                "",
                "",
                "trigger|stop|start",
                "LEonardHolefinder",
                "","","",
            });
            devices.Rows.Add(new object[] {
                5, "Sherlock", false, false, "TcpServer", "127.0.0.1:20000",
                "A.SH", "general",
                "", "<CR>", "<LF>", "#",
                "init()", "",
                true,
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
                "A.HA", "general",
                "", "<CR>", "<LF>", "#",
                "init()", "",
                true,
                "",
                "hdevelop.exe",
                @"""C:\Users\Public\LEonard\Code\Examples\MVTec\HALCON\LE01 Socket Test (Auto).hdev"" -run",
                "",
                "",
                "",
                "GO",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                7, "Keyence", false, false, "TcpClient", "192.168.0.10:8500",
                "AUX2K", "general",
                "", "<CR>", "<LF>", "#",
                "TE", "",
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
                8, "Dataman1", false, false, "Serial", "COM3",
                "A.DM1", "general",
                "", "", "<CR>", "#",
                "LE:le_send(me,+)", "",
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
                9, "Dataman2", false, false, "Serial", "COM4",
                "A.DM2", "general",
                "", "", "<CR>", "#",
                "LE:le_send(me,+)", "",
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
                "CTL", "general",
                "", "", "", "",
                "", "",
                true,
                "",
                "Chrome.exe",
                "/incognito 192.168.0.3",
                "",
                "",
                "",
                "",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                11, "Zebra FS40 Control", false, false, "TcpClient", "192.168.0.41:107",
                "A.FS40.C", "general",
                "", "<CR><LF>", "<LF>", "",
                "", "",
                false,
                "",
                "",
                "",
                "",
                "",
                "",
                "TRIGGER",
                "",
                "","","",
            });
            devices.Rows.Add(new object[] {
                12, "Zebra FS40 Results", false, false, "TcpClient", "192.168.0.41:25250",
                "A.FS40.R", "general",
                "", "<CR><LF>", "<LF>", "#",
                "", "",
                false,
                "",
                "",
                "",
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
                currentDeviceRowIndex = 0;

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
                return 1;
            }

            return 0;
        }

        private void LoadDevicesBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadDevicesBtn_Click(...)");

            string initialDirectory;
            if (DevicesFilenameLbl.Text != "Untitled" && DevicesFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(DevicesFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, ConfigFolder);

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
                initialDirectory = System.IO.Path.GetDirectoryName(DevicesFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, ConfigFolder);

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

            // Make sure everything is emptied and Disposed!
            LeDeviceBase.currentDevice = null;
            LeGocator.currentDevice = null;
            LeUrDashboard.currentDevice = null;
            LeUrCommand.currentDevice = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private string CharacterParser(string str)
        {
            String retString = str;
            retString = Regex.Replace(retString, "<LF>", "\u000A");
            retString = Regex.Replace(retString, "<CR>", "\u000D");
            retString = Regex.Replace(retString, "<CRLF>", "\u000D\u000A");
            return retString;
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
            string onConnectExec = (string)row["OnConnectExec"];
            bool connected = (bool)row["Connected"];
            string jobFile = (string)row["Jobfile"];
            string txPrefix = (string)row["TxPrefix"];
            string txSuffix = (string)row["TxSuffix"];
            string rxTerminator = (string)row["RxTerminator"];
            string rxSeparator = (string)row["RxSeparator"];

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

            // STEP 1: Instantiate device interface object
            switch (deviceType)
            {
                case "TcpServer":
                    interfaces[ID] = new LeTcpServer(this, messageTag, onConnectExec);
                    break;
                case "TcpClient":
                    interfaces[ID] = new LeTcpClient(this, messageTag, onConnectExec);
                    break;
                case "TcpClientAsync":
                    interfaces[ID] = new LeTcpClientAsync(this, messageTag, onConnectExec);
                    break;
                case "Serial":
                    interfaces[ID] = new LeSerial(this, messageTag, onConnectExec);
                    break;
                case "UrDashboard":
                    interfaces[ID] = new LeUrDashboard(this, messageTag, onConnectExec);
                    ((LeUrDashboard)interfaces[ID]).ProgramFilename = jobFile;
                    break;
                case "UrCommand":
                    interfaces[ID] = new LeUrCommand(this, messageTag, onConnectExec);
                    break;
                case "Gocator":
                    interfaces[ID] = new LeGocator(this, messageTag, onConnectExec);
                    ((LeGocator)interfaces[ID]).ProgramFilename = jobFile;
                    break;
                case "Null":
                    interfaces[ID] = new LeDevNull(this, messageTag, onConnectExec);
                    break;
                default:
                    ErrorMessageBox($"Instantiating: deviceType {deviceType} does not exist");
                    return 3;
            }

            // Setup the "me" device
            LeDeviceBase.currentDevice = interfaces[ID];

            // STEP 2: Start any requested runtime
            if ((bool)row["RuntimeAutostart"])
                DeviceRuntimeStartBtn_Click(null, null);

            // STEP 3: Install desired callback
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

            // STEP 4: Put in all the terminators and separators
            interfaces[ID].TxPrefix = CharacterParser(txPrefix);
            interfaces[ID].TxSuffix = CharacterParser(txSuffix);
            interfaces[ID].RxTerminator = CharacterParser(rxTerminator);
            interfaces[ID].RxSeparator = CharacterParser(rxSeparator);

            // STEP 5: Connect
            int connectSuccess = interfaces[ID].Connect(address);
            if (!interfaces[ID].IsConnected())
            {
                ErrorMessageBox($"Device {ID}:{name} of type {deviceType} will not connect.");
                interfaces[ID].Disconnect();
                interfaces[ID] = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return 4;
            }
            row["Connected"] = true;

            // STEP 6: Do anything special as required
            switch (deviceType)
            {
                case "UrDashboard":
                    row["Model"] = ur_dashboard("get robot model", 200);
                    row["Serial"] = ur_dashboard("get serial number", 200);
                    row["Version"] = ur_dashboard("PolyscopeVersion", 200);
                    break;
            }

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

        void SetMeDevice(LeDeviceInterface dev)
        {
            LeDeviceBase.currentDevice = dev;
        }
        private void DeviceDisconnect(DataRow row)
        {
            if (!(bool)row["Connected"])
            {
                //ErrorMessageBox($"Device {row["Name"]} already disconnected.");
                return;
            }
            int ID = (int)row["ID"];

            // Setup the "me" device
            LeDeviceBase.currentDevice = interfaces[ID];

            log.Info("Disconnecting {0}", (string)row["Name"]); ;
            row["Connected"] = false;
            if (interfaces[ID] != null)
            {
                SetMeDevice(interfaces[ID]);

                string execLEonardMessageOnDisconnect = (string)row["OnDisconnectExec"];
                if (execLEonardMessageOnDisconnect.Length > 0)
                    if (!ExecuteLEonardStatement((string)row["MessageTag"], execLEonardMessageOnDisconnect, (interfaces[ID])))
                        log.Error($"DeviceDisconnect cannot execute OnDisconnectExec {execLEonardMessageOnDisconnect}");

                interfaces[ID].Disconnect();
                interfaces[ID] = null;
                if (LeDeviceBase.currentDevice == this)
                    LeDeviceBase.currentDevice = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                UpdateAnnunciators();
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

            DeviceDisconnect(row);
            DeviceConnect(row);
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
                log.Error($"Device in row {currentDeviceRowIndex} not connected");
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
                        log.Error($"DeviceRuntimeStart for {row["Name"]}: Cannot find hWnd of Runtime window for {row["RuntimeFileName"]}");
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
                PerformPrompt("Waiting for app to start...", false, false);
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
                    else
                        log.Error($"DeviceSetupStart for {row["Name"]}: Cannot find hWnd of Runtime window for {row["SetupFileName"]}");

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
            string speedButtons = "";
            try
            {
                speedButtons = (string)(devices.Rows[currentDeviceRowIndex])["SpeedSendButtons"];
            }
            catch
            {
                return;

            }
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
        //      LE:command      Sent to LEscript ExecuteLEScriptLine
        //      JE:command      Sent to ExecuteJavaScript
        //      PE:command      Sent to ExecutePythonScript
        //      name = value    Sent to WriteVariable
        //      SET name value  Sent to WriteVariable
        public void GeneralCallback(string prefix, string message, LeDeviceInterface dev)
        {
            log.Debug($"GeneralCallback({prefix}, {message}, {dev})");
            ExecuteLEonardMessage(prefix, message, dev);
        }

        void DashboardCallback(string prefix, string message)
        {
            log.Debug($"{prefix}<== {message}");
        }

        // Callback used for LEonardClient and remote control
        void CommandCallback(string prefix, string message, LeDeviceInterface dev)
        {
            log.Debug($"CCB<==({prefix}, {message})");
            // Nothing special for now
            GeneralCallback(prefix, message, dev);
        }

        void AlternateCallback1(string message, string prefix, LeDeviceInterface dev)
        {
            log.Debug($"ACB<==({prefix},{message})");
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


        #endregion ===== DEVICES DATABASE SUPPORT CODE     ==============================================================================================================================

        #region ===== DISPLAY MANAGEMENT CODE           ==============================================================================================================================
        public double GlobalFontScaleOverridePct { get; set; } = 100.0;
        double suggestedSystemScalePct = 100.0;
        bool uiUpdatesAreLive = false;
        public class ControlInfo
        {
            public Font originalFont;
        }

        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public static void RememberInitialFont(Control ctl)
        {
            ControlInfo controlInfo = new ControlInfo();
            controlInfo.originalFont = ctl.Font;
            ctl.Tag = controlInfo;
        }


        // Minimum suggested by either height or width scaling, and limit max to maxFontScaleUpPct
        public double ScaleRecommender(int presentWidth, int originalWidth, int presentHeight, int originalHeight)
        {
            double scaleWidthPct = Math.Min(100.0 * presentWidth / originalWidth, maxFontScaleUpPct);
            double scaleHeightPct = Math.Min(100.0 * presentHeight / originalHeight, maxFontScaleUpPct);
            double minScalePct = Math.Min(scaleWidthPct, scaleHeightPct);
            double limitedScalePct = Math.Min(minScalePct, maxFontScaleUpPct);

            return limitedScalePct * GlobalFontScaleOverridePct / 100.0;
        }

        public static void RescaleFont(Control ctl, double scalePct)
        {
            Font oldFont = ((ControlInfo)ctl.Tag).originalFont;
            Font newFont = new Font(oldFont.FontFamily, (float)(oldFont.Size * scalePct / 100), oldFont.Style, oldFont.Unit);
            ctl.Font = newFont;
        }

        public static IEnumerable<Control> TakeControlInventory(Control ctl)
        {
            IEnumerable<Control> buttonList = GetAll(ctl, typeof(Button));
            //log.Info("Button Count: " + buttonList.Count());
            foreach (Button b in buttonList)
            {
                //log.Info($"BTN {b.Text} {b.Font.Size}");
                RememberInitialFont(b);
            }
            IEnumerable<Control> comboboxList = GetAll(ctl, typeof(ComboBox));
            //log.Info("ComboBox Count: " + comboboxList.Count());
            foreach (ComboBox cb in comboboxList)
            {
                //log.Info($"COMBO {cb.Text} {cb.Font.Size}");
                RememberInitialFont(cb);
            }

            IEnumerable<Control> datagridviewList = GetAll(ctl, typeof(DataGridView));
            //log.Info("DataGridView Count: " + datagridviewList.Count());
            foreach (DataGridView d in datagridviewList)
            {
                //log.Info($"DGV {d.Text} {d.Font.Size}");
                RememberInitialFont(d);
            }

            IEnumerable<Control> labelList = GetAll(ctl, typeof(Label));
            //log.Info("Label Count: " + labelList.Count());
            foreach (Label l in labelList)
            {
                //log.Info($"LBL {l.Text} {l.Font.Size}");
                RememberInitialFont(l);
            }

            IEnumerable<Control> richtextboxList = GetAll(ctl, typeof(RichTextBox));
            //log.Info("RichTextBox Count: " + richtextboxList.Count());
            foreach (RichTextBox r in richtextboxList)
            {
                //log.Info($"RTB {r.Text} {r.Font.Size}");
                RememberInitialFont(r);
            }

            IEnumerable<Control> tabcontrolList = GetAll(ctl, typeof(TabControl));
            //log.Info("TabControl Count: " + tabcontrolList.Count());
            foreach (TabControl t in tabcontrolList)
            {
                //log.Info($"TAB {t.Text} {t.Font.Size}");
                RememberInitialFont(t);
            }

            IEnumerable<Control> textboxList = GetAll(ctl, typeof(TextBox));
            //log.Info("TextBox Count: " + textboxList.Count());
            foreach (TextBox t in textboxList)
            {
                //log.Info($"TXT {t.Text} {t.Font.Size}");
                RememberInitialFont(t);
            }

            IEnumerable<Control> listboxList = GetAll(ctl, typeof(ListBox));
            //log.Info("ListBox Count: " + listboxList.Count());
            foreach (ListBox t in listboxList)
            {
                //log.Info($"LISTBOX {t.Text} {t.Font.Size}");
                RememberInitialFont(t);
            }

            IEnumerable<Control> checkboxList = GetAll(ctl, typeof(CheckBox));
            //log.Info("CheckBox Count: " + checkboxList.Count());
            foreach (CheckBox c in checkboxList)
            {
                //log.Info($"CHECKBOX {c.Text} {c.Font.Size}");
                RememberInitialFont(c);
            }

            IEnumerable<Control> returnList = buttonList;
            returnList = returnList.Concat(comboboxList);
            returnList = returnList.Concat(datagridviewList);
            returnList = returnList.Concat(labelList);
            returnList = returnList.Concat(richtextboxList);
            // TODO Tabs don't resize so we shouldn't resize their text for now!
            // returnList = returnList.Concat(tabcontrolList);
            returnList = returnList.Concat(textboxList);
            returnList = returnList.Concat(listboxList);
            returnList = returnList.Concat(checkboxList);

            return returnList;
        }

        void ScaleUiText(double scalePct)
        {
            foreach (Control c in allFontResizableList) RescaleFont(c, scalePct);
        }

        readonly string displaysFilename = "Displays.xml";
        private void ClearAndInitializeDisplays()
        {
            displays = new DataTable("Displays");
            DataColumn name = displays.Columns.Add("Name", typeof(System.String));
            displays.Columns.Add("Width", typeof(System.Int32));
            displays.Columns.Add("Height", typeof(System.Int32));
            displays.Columns.Add("Resizable", typeof(System.Boolean));
            displays.Columns.Add("Fullscreen", typeof(System.Boolean));
            displays.Columns.Add("FontScale", typeof(System.Double));
            displays.CaseSensitive = true;
            displays.PrimaryKey = new DataColumn[] { name };

            DisplaysGrd.DataSource = displays;
        }
        // App screen design sizes (Zebra ET80A Tablet as installed at Tosoh Quartz, what the unit shows as recommended resolution)
        //public const int tabletScreenDesignWidth = 2160;  // 2160 / 1920 = 112.5%
        //public const int tabletScreenDesignHeight = 1440; // 1440 / 1080 = 133.3%
        // Aspect Ratio: 2160 / 1440 = 1.5 (15:10)

        // App screen design sizes (Zebra L10 Tablet according to spec)
        //public const int tablet2ScreenDesignWidth = 1920;  // 1920 / 1920 = 100%
        //public const int tablet2ScreenDesignHeight = 1200; // 1200 / 1080 = 111.1%
        // Aspect Ratio: 1920 / 1200 = 1.6 (16:10)

        // App screen design sizes (LeckyOne Laptop)
        //public const int laptopScreenDesignWidth = 1920;   // 100%
        //public const int laptopScreenDesignHeight = 1080;  // 100%
        // Aspect Ratio: 1920 / 1080 = 1.78 (16:9)

        // App screen design sizes (Big Viewsonic Monitors)
        //public const int largeScreenDesignWidth = 2560;   // 2560 / 1920 = 133.3%
        //public const int largeScreenDesignHeight = 1440;  // 1440 / 1080 = 133.3%
        // Aspect Ratio: 2560 / 1440 = 1.78 (16:9)
        private void CreateDefaultDisplays()
        {
            displays.Rows.Add(new object[] { "Default", 1920, 1080, false, true, 100 });
            displays.Rows.Add(new object[] { "Standard Laptop", 1920, 1080, false, false, 100 });
            displays.Rows.Add(new object[] { "Wide Laptop", 1920, 1200, false, false, 100 });
            displays.Rows.Add(new object[] { "Zebra ET80A", 2160, 1440, false, false, 100 });
            displays.Rows.Add(new object[] { "Zebra L10", 1920, 1200, false, false, 100 });
            displays.Rows.Add(new object[] { "Large Monitor", 2560, 1440, false, true, 100 });
            displays.Rows.Add(new object[] { "Resize Medium", 1800, 1000, true, false, 100 });
            displays.Rows.Add(new object[] { "Resize Fullscreen", 1800, 1000, true, true, 100 });
        }

        private void SelectDataGridViewRow(DataGridView dgv, string name)
        {
            log.Info($"SelectDataGridViewRow({dgv.Name},{name})");
            // Highlight the corresponding row in the DataGridView
            foreach (DataGridViewRow row in dgv.Rows)
            {
                try
                {
                    string rowName = row.Cells[0].Value?.ToString();
                    bool select = (rowName == name);
                    //log.Info($"looking at DataGridRow {rowName} select={select}");
                    row.Selected = (rowName == name);
                }
                catch
                {

                }
            }
        }

        private void SelectDisplayMode(string name)
        {

            log.Info($"SelectDisplayMode({name})");

            // Find the row in the DataTable with the name
            DataRow referencedRow = null;
            foreach (DataRow row in displays.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace("FindDisplay({0}) = {1}", row["Name"], row.ToString());
                    referencedRow = row;
                }
            }
            if (referencedRow == null)
            {
                return;
            }

            // Highlight the corresponding row in the DataGridView
            SelectDataGridViewRow(DisplaysGrd, name);

            // Now enforce all of the desired screen parameters
            SelectedDisplayLbl.Text = name;
            int width = (int)referencedRow["Width"];
            int height = (int)referencedRow["Height"];
            bool isResizable = (bool)referencedRow["Resizable"];
            bool isFullscreen = (bool)referencedRow["Fullscreen"];
            GlobalFontScaleOverridePct = (double)referencedRow["FontScale"];

            System.Drawing.Rectangle screenRect = Screen.FromControl(this).Bounds;
            log.Info("Screen Dimensions: {0}x{1}", screenRect.Width, screenRect.Height);

            if (isResizable)
            {
                // Resizable
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.ControlBox = true;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                // Fixed Size
                this.FormBorderStyle = FormBorderStyle.None;
                this.ControlBox = false;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.WindowState = FormWindowState.Normal;
            }

            if (isFullscreen)
            {
                // Fullscreen

                // TODO- not 0,0 if on other monitor!
                Left = 0;
                Top = 0;
                Width = screenRect.Width;
                Height = screenRect.Height;
            }
            else
            {
                // Not Fullscreen

                // Todo- not 0,0 if on other monitor!
                Left = 0;
                Top = 0;
                Width = width;
                Height = height;
            }

            // Make sure we execute resize in case someone just changed the FontScale
            MainForm_Resize(null, null);
        }


        private void SelectDisplayBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(DisplaysGrd);
            if (name == null)
                ErrorMessageBox("Please select a display in the displays table.");
            else
            {
                SelectDisplayMode(name);
            }
        }

        private void LoadDisplaysBtn_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, displaysFilename);
            log.Info("LoadDisplays from {0}", filename);
            ClearAndInitializeDisplays();
            try
            {
                displays.ReadXml(filename);
            }
            catch
            {
                DialogResult result = ConfirmMessageBox("Could not load displays. Create some defaults?");
                if (result == DialogResult.OK)
                {
                    CreateDefaultDisplays();
                }
            }

            DisplaysGrd.DataSource = displays;
        }

        private void SaveDisplaysBtn_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, displaysFilename);
            log.Info("SaveDisplaysBtn_Click to {0}", filename);
            displays.AcceptChanges();
            displays.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private void ClearDisplaysButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all existing displays. Proceed?"))
            {
                ClearAndInitializeDisplays();
                if (DialogResult.OK == ConfirmMessageBox("Would you like to create the default displays?"))
                    CreateDefaultDisplays();
            }
        }

        public static void CrawlRTB(RichTextBox rtb, string message, int maxLength = 10000, int chopLength = 5000)
        {
            rtb.Text += message + Environment.NewLine;
            if (rtb.Text.Length > maxLength)
            {
                rtb.Text = rtb.Text.Substring(rtb.Text.Length - 1 - chopLength, chopLength);
            }
            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }

        #endregion ===== DISPLAY MANAGEMENT CODE           ==============================================================================================================================

        #region ===== TOOL DATABASE CODE                ==============================================================================================================================
        private DataRow SelectedRow(DataGridView dg)
        {
            if (dg.SelectedCells.Count < 1) return null;
            var cell = dg.SelectedCells[0];
            if (cell.ColumnIndex != 0) return null;
            if (cell.Value == null) return null;
            return (DataRow)((DataRowView)dg.Rows[cell.RowIndex].DataBoundItem).Row;
        }
        private string SelectedName(DataGridView dg)
        {
            if (dg.SelectedCells.Count < 1) return null;
            var cell = dg.SelectedCells[0];
            if (cell.ColumnIndex != 0) return null;
            if (cell.Value == null) return null;
            return cell.Value.ToString();
        }
        private int SelectedRowIndex(DataGridView dg)
        {
            if (dg.SelectedCells.Count < 1) return -1;
            var cell = dg.SelectedCells[0];
            if (cell.ColumnIndex != 0) return -1;
            if (cell.Value == null) return -1;
            return cell.RowIndex;
        }

        private void SelectToolBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(ToolsGrd);
            if (name == null)
                ErrorMessageBox("Please select a tool in the tool table.");
            else
            {
                log.Info("Selecting tool {0}", name);
                select_tool(name);
            }
        }

        private void JointMoveMountBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(ToolsGrd);
            if (name == null)
                ErrorMessageBox("Please select a tool in the tool table.");
            else
            {
                string position = SelectedRow(ToolsGrd)["MountPosition"].ToString();
                log.Info("Joint Move Tool Mount to {0}", position.ToString());
                GotoPositionJoint(position);
                PerformPrompt("Wait for move to tool mount position complete", true, true);
            }
        }

        private void JointMoveHomeBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(ToolsGrd);
            if (name == null)
                ErrorMessageBox("Please select a tool in the tool table.");
            else
            {
                string position = SelectedRow(ToolsGrd)["HomePosition"].ToString();
                log.Info("Joint Move Tool Home to {0}", position);
                GotoPositionJoint(position);
                PerformPrompt("Wait for move to tool home complete", true, true);
            }
        }


        private void ToolTestBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, "tool_on()");
        }

        private void ToolOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, "tool_off()");
        }

        private void CoolantTestBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, "coolant_on()");
        }

        private void CoolantOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, "coolant_off()");
        }

        readonly string toolsFilename = "Tools.xml";
        private void ClearAndInitializeTools()
        {
            tools = new DataTable("Tools");
            DataColumn name = tools.Columns.Add("Name", typeof(System.String));
            tools.Columns.Add("x_m", typeof(System.Double));
            tools.Columns.Add("y_m", typeof(System.Double));
            tools.Columns.Add("z_m", typeof(System.Double));
            tools.Columns.Add("rx_rad", typeof(System.Double));
            tools.Columns.Add("ry_rad", typeof(System.Double));
            tools.Columns.Add("rz_rad", typeof(System.Double));
            tools.Columns.Add("mass_kg", typeof(System.Double));
            tools.Columns.Add("cogx_m", typeof(System.Double));
            tools.Columns.Add("cogy_m", typeof(System.Double));
            tools.Columns.Add("cogz_m", typeof(System.Double));
            tools.Columns.Add("ToolOnOuts", typeof(System.String));
            tools.Columns.Add("ToolOffOuts", typeof(System.String));
            tools.Columns.Add("CoolantOnOuts", typeof(System.String));
            tools.Columns.Add("CoolantOffOuts", typeof(System.String));
            tools.Columns.Add("MountPosition", typeof(System.String));
            tools.Columns.Add("HomePosition", typeof(System.String));
            tools.CaseSensitive = true;
            tools.PrimaryKey = new DataColumn[] { name };

            ToolsGrd.DataSource = tools;
        }
        private void RefreshMountedToolBox(int currentToolIndex = -1)
        {
            log.Debug("RefreshMountedToolBox({0})", currentToolIndex);
            MountedToolBox.Items.Clear();
            foreach (DataRow row in tools.Rows)
            {
                MountedToolBox.Items.Add(row["Name"]);
            }

            if (currentToolIndex >= 0)
            {
                MountedToolBox.SelectedIndex = currentToolIndex;
            }
        }

        private void LoadToolsBtn_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, toolsFilename);
            log.Info("LoadTools from {0}", filename);
            ClearAndInitializeTools();
            try
            {
                tools.ReadXml(filename);
            }
            catch
            {
                DialogResult result = ConfirmMessageBox("Could not load tools. Create some defaults?");
                if (result == DialogResult.OK)
                {
                    CreateDefaultTools();
                }
            }

            ToolsGrd.DataSource = tools;
            RefreshMountedToolBox();
        }


        private void SaveTools()
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, toolsFilename);
            log.Info($"SaveTools to {filename}");
            tools.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private void SaveToolsBtn_Click(object sender, EventArgs e)
        {
            tools.AcceptChanges();
            SaveTools();
            RefreshMountedToolBox(MountedToolBox.SelectedIndex);
        }

        private void CreateDefaultTools()
        {
            tools.Rows.Add(new object[] { "gocator3210", 0, 0, 0.381, 0, 0, -1.57079, 1.8, 0, 0, 0.072, "2,0", "2,0", "2,0", "2,0", "gocator_mount", "gocator_home" });
            tools.Rows.Add(new object[] { "2F85", 0, 0, 0.175, 0, 0, 0, 1.0, 0, 0, 0.050, "2,1,5,1", "2,0,5,0", "3,1", "3,0", "sander_mount", "sander_home" });
            tools.Rows.Add(new object[] { "sander", 0, 0, 0.186, 0, 0, 0, 2.99, -0.011, 0.019, 0.067, "2,1", "2,0", "3,1", "3,0", "sander_mount", "sander_home" });
            tools.Rows.Add(new object[] { "spindle", 0, -0.165, 0.09, 0, 2.2214, -2.2214, 2.61, -0.004, -0.015, 0.049, "5,1", "5,0", "3,1", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "pen", 0, -0.08, 0.075, 0, 2.2214, -2.2214, 1.0, -0.004, -0.015, 0.049, "2,0,5,0", "2,0,5,0", "3,0", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "pen_SA", 0, -0.072, 0.103, 0, 2.2214, -2.2214, 0.98, 0, 0.002, 0.048, "2,0,5,0", "2,0,5,0", "3,0", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "none", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "sander_mount", "sander_home" });
        }

        /*
          From TQ 5/18/2022
          <Tools>
            <Name>sander</Name>
            <x_m>0</x_m>
            <y_m>0</y_m>
            <z_m>0.186</z_m>
            <rx_rad>0</rx_rad>
            <ry_rad>0</ry_rad>
            <rz_rad>0</rz_rad>
            <mass_kg>2.99</mass_kg>
            <cogx_m>-0.011</cogx_m>
            <cogy_m>0.019</cogy_m>
            <cogz_m>0.067</cogz_m>
            <ToolOnOuts>2,1</ToolOnOuts>
            <ToolOffOuts>2,0</ToolOffOuts>
            <CoolantOnOuts>3,1</CoolantOnOuts>
            <CoolantOffOuts>3,0</CoolantOffOuts>
            <MountPosition>sander_mount</MountPosition>
            <HomePosition>sander_home</HomePosition>
          </Tools>
          <Tools>
            <Name>spindle</Name>
            <x_m>0</x_m>
            <y_m>-0.165</y_m>
            <z_m>0.09</z_m>
            <rx_rad>0</rx_rad>
            <ry_rad>2.2214</ry_rad>
            <rz_rad>-2.2214</rz_rad>
            <mass_kg>2.61</mass_kg>
            <cogx_m>-0.004</cogx_m>
            <cogy_m>-0.015</cogy_m>
            <cogz_m>0.049</cogz_m>
            <ToolOnOuts>5,1</ToolOnOuts>
            <ToolOffOuts>5,0</ToolOffOuts>
            <CoolantOnOuts>3,1</CoolantOnOuts>
            <CoolantOffOuts>3,0</CoolantOffOuts>
            <MountPosition>spindle_mount</MountPosition>
            <HomePosition>spindle_home</HomePosition>
          </Tools>
        */
        private void ClearToolsBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all existing tools. Proceed?"))
            {
                ClearAndInitializeTools();
                if (DialogResult.OK == ConfirmMessageBox("Would you like to create the default tools?"))
                    CreateDefaultTools();
            }
        }

        private void MoveToolMountBtn_Click(object sender, EventArgs e)
        {
            GotoPositionJoint(MoveToolMountBtn.Text);
            PerformPrompt("Wait for move to tool mount position complete", true, true);
        }

        private void MoveToolHomeBtn_Click(object sender, EventArgs e)
        {
            GotoPositionJoint(MoveToolHomeBtn.Text);
            PerformPrompt("Wait for move to tool home complete", true, true);
        }

        private void SetDoorClosedInputBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, string.Format("set_door_closed_input({0})", DoorClosedInputTxt.Text));
        }

        private void SetFootswitchInputBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEScriptLine(-1, string.Format("set_footswitch_pressed_input({0})", FootswitchPressedInputTxt.Text));
        }

        private DataRow FindName(string name, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace($"FindName({row["Name"]},{table.TableName}) = {row.ToString()}");
                    return row;
                }
            }
            return null;
        }

        #endregion ===== TOOL DATABASE CODE                ==============================================================================================================================

        #region ===== POSITIONS DATABASE CODE           ==============================================================================================================================
        readonly string positionsFilename = "Positions.xml";

        private string ReadPositionJoint(string name)
        {
            foreach (DataRow row in positions.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace("ReadPositionJoint({0}) = {1}", row["Name"], row["Joints"]);
                    return row["Joints"].ToString();
                }
            }
            log.Error("ReadPositionJoint({0}) Not Found", name);
            return null;
        }
        private string ReadPositionPose(string name)
        {
            foreach (DataRow row in positions.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace("ReadPositionPose({0}) = {1}", row["Name"], row["Pose"]);
                    return row["Pose"].ToString();
                }
            }
            log.Error("ReadPositionPose({0}) Not Found", name);
            return null;
        }


        public bool SetSystemPosition(string name, bool isSystem)
        {
            foreach (DataRow row in positions.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    row["IsSystem"] = isSystem;
                    return true;
                }
            }
            log.Error($"SetSystemPosition({name}) Not Found");
            return false;
        }
        public bool WritePosition(string name, string joints = "", string pose = "", bool isSystem = false)
        {
            System.Threading.Monitor.Enter(lockObject);

            log.Trace("WritePosition({0}, {1}, {2}, {3})", name, joints, pose, isSystem);
            if (positions == null)
            {
                log.Error("positions == null!!??");
                return false;
            }

            bool foundVariable = false;
            foreach (DataRow row in positions.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    if (joints != "") row["Joints"] = joints;
                    if (pose != "") row["Pose"] = pose;
                    row["IsSystem"] = isSystem;
                    foundVariable = true;
                    break;
                }
            }

            if (!foundVariable)
                positions.Rows.Add(new object[] { name, joints, pose, isSystem });

            positions.AcceptChanges();
            Monitor.Exit(lockObject);
            return true;
        }


        private void LoadPositions()
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, positionsFilename);
            log.Info("LoadPositions from {0}", filename);
            ClearAndInitializePositions();
            try
            {
                positions.ReadXml(filename);
            }
            catch
            { }

            PositionsGrd.DataSource = positions;
        }

        private void SavePositions()
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, positionsFilename);
            log.Info("SavePositions to {0}", filename);
            positions.AcceptChanges();
            positions.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        int ClearNonSystemPositions()
        {
            while (DeleteFirstNonSystemEntry(positions)) ;
            return 0;
        }
        private void ClearPositionsBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all non-system positions. Proceed?"))
                ClearNonSystemPositions();
        }

        private void CreateDefaultPositions()
        {
            positions.Rows.Add(new object[] { "spindle_mount", "[-2.68179,-1.90227,-1.42486,-2.95848,-1.70261,0.000928376]", "p[-0.928515, -0.296863, 0.369036, 1.47493, 2.77222, 0.00280416]", true });
            positions.Rows.Add(new object[] { "spindle_home", "[-2.71839,-0.892528,-2.14111,-3.27621,-1.68817,-0.019554]", "p[-0.410055, -0.0168446, 0.429258, -1.54452, -2.73116, -0.0509774]", true });
            positions.Rows.Add(new object[] { "sander_mount", "[-2.53006,-2.15599,-1.18223,-1.37402,1.57131,0.124]", "p[-0.933321, -0.442727, 0.284064, 1.61808, 2.6928, 0.000150004]", true });
            positions.Rows.Add(new object[] { "sander_home", "[-2.57091,-0.82644,-2.14277,-1.743,1.57367,-0.999559]", "p[-0.319246, 0.00105911, 0.464005, -5.0997e-05, 3.14151, 3.32468e-05]", true });
            positions.Rows.Add(new object[] { "gocator_mount", "[-1.994536,-1.693767,-2.011792,-1.301532,1.941065,2.864294]", "p[-0.105517,-0.335526,-0.082677,2.218557,1.817424,0.612817]", true });
            positions.Rows.Add(new object[] { "gocator_home", "[-0.44141,-1.262893,-2.062313,-1.387395,1.571761,2.704165]", "p[0.266735,-0.271784,0.01577,0.000065,-3.141466,-0.00004]", true });
            positions.Rows.Add(new object[] { "cp_origin", "[-0.746832,-1.629936,-1.676383,-1.406107,1.571093,2.426708]", "p[0.286752,-0.444909,0.042253,0.043984,3.141235,-0.000046]", true });
            positions.Rows.Add(new object[] { "grind1", "[-0.964841,-1.56224,-2.25801,-2.46721,-0.975704,0.0351043]", "p[0.115668, -0.664968, 0.149296, -0.0209003, 3.11011, 0.00405717]", false });
            positions.Rows.Add(new object[] { "grind2", "[-1.19025,-1.54723,-2.28053,-2.45891,-1.20106,0.0341677]", "p[0.00572967, -0.666445, 0.145823, -0.0208504, 3.11009, 0.004073]", false });
            positions.Rows.Add(new object[] { "grind3", "[-1.41341,-1.57357,-2.26161,-2.45085,-1.42422,0.0333479]", "p[-0.0942147, -0.667831, 0.142729, -0.0208677, 3.1101, 0.00394188]", false });
        }
        private void ClearAndInitializePositions()
        {
            positions = new DataTable("Positions");
            DataColumn name = positions.Columns.Add("Name", typeof(System.String));
            positions.Columns.Add("Joints", typeof(System.String));
            positions.Columns.Add("Pose", typeof(System.String));
            positions.Columns.Add("IsSystem", typeof(System.Boolean));
            positions.CaseSensitive = true;
            positions.PrimaryKey = new DataColumn[] { name };
            PositionsGrd.DataSource = positions;
        }

        /*
          TQ Positions 5/18/2022
          <Positions>
            <Name>spindle_mount</Name>
            <Joints>[-2.68179,-1.90227,-1.42486,-2.95848,-1.70261,0.000928376]</Joints>
            <Pose>p[-0.928515, -0.296863, 0.369036, 1.47493, 2.77222, 0.00280416]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>spindle_home</Name>
            <Joints>[-2.71839,-0.892528,-2.14111,-3.27621,-1.68817,-0.019554]</Joints>
            <Pose>p[-0.410055, -0.0168446, 0.429258, -1.54452, -2.73116, -0.0509774]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>sander_mount</Name>
            <Joints>[-2.53006,-2.15599,-1.18223,-1.37402,1.57131,0.124]</Joints>
            <Pose>p[-0.933321, -0.442727, 0.284064, 1.61808, 2.6928, 0.000150004]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>sander_home</Name>
            <Joints>[-2.57091,-0.82644,-2.14277,-1.743,1.57367,-0.999559]</Joints>
            <Pose>p[-0.319246, 0.00105911, 0.464005, -5.0997e-05, 3.14151, 3.32468e-05]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>grind1</Name>
            <Joints>[-0.964841,-1.56224,-2.25801,-2.46721,-0.975704,0.0351043]</Joints>
            <Pose>p[0.115668, -0.664968, 0.149296, -0.0209003, 3.11011, 0.00405717]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>grind2</Name>
            <Joints>[-1.19025,-1.54723,-2.28053,-2.45891,-1.20106,0.0341677]</Joints>
            <Pose>p[0.00572967, -0.666445, 0.145823, -0.0208504, 3.11009, 0.004073]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
          <Positions>
            <Name>grind3</Name>
            <Joints>[-1.41341,-1.57357,-2.26161,-2.45085,-1.42422,0.0333479]</Joints>
            <Pose>p[-0.0942147, -0.667831, 0.142729, -0.0208677, 3.1101, 0.00394188]</Pose>
            <IsSystem>false</IsSystem>
          </Positions>
        */

        private void ClearAllPositionsBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all positions INCLUDING system positions. Proceed?"))
                ClearAndInitializePositions();
            if (DialogResult.OK == ConfirmMessageBox("Would you like to create the default positions?"))
                CreateDefaultPositions();
        }

        private void RecordPosition(string prompt, string varName)
        {
            JoggingDialog form = new JoggingDialog(this)
            {
                Prompt = prompt,
                Tool = ReadVariable("robot_tool"),
                Part = "Teaching Position Only",
                ShouldSave = true
            };

            form.ShowDialog(this);

            if (form.ShouldSave)
            {
                log.Trace(prompt);

                if (robotReady)
                {
                    copyPositionAtWrite = varName;
                    string robotPrefix = GetRobotPrefix("get_actual_both");
                    if (robotPrefix != null)
                        RobotSend(robotPrefix);
                }
            }
        }

        private bool GotoPositionJoint(string varName)
        {
            log.Trace("GotoPositionJoint({0})", varName);
            if (robotReady)
            {
                string q = ReadPositionJoint(varName);
                if (q != null)
                {
                    string robotPrefix = GetRobotPrefix("movej");
                    if (robotPrefix != null)
                    {
                        string msg = robotPrefix + "," + ExtractScalars(q);
                        log.Trace("Sending {0}", msg);
                        RobotSend(msg);
                        return true;
                    }
                }
            }
            return false;
        }
        private bool GotoPositionPose(string varName)
        {
            log.Trace("GotoPositionPose({0})", varName);
            if (robotReady)
            {
                string q = ReadPositionPose(varName);
                if (q != null)
                {
                    string robotPrefix = GetRobotPrefix("movel");
                    if (robotPrefix != null)
                    {
                        string msg = robotPrefix + "," + ExtractScalars(q);
                        log.Trace("Sending {0}", msg);
                        RobotSend(msg);
                        return true;
                    }
                }
            }
            return false;
        }

        private void PositionSetBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(PositionsGrd);
            if (name == null)
                ErrorMessageBox("Please select a position in the table to teach.");
            else
            {
                log.Info("Setting Position {0}", name);
                RecordPosition("Please teach position: " + name, name);
            }
        }

        private void PositionMovePoseBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(PositionsGrd);
            if (name == null)
                ErrorMessageBox("Please select a target position in the table.");
            else
            {
                GotoPositionPose(name);
                PerformPrompt(String.Format("Wait for robot linear move to {0} complete", name), true, true);
            }
        }

        private void PositionMoveArmBtn_Click(object sender, EventArgs e)
        {
            string name = SelectedName(PositionsGrd);
            if (name == null)
                ErrorMessageBox("Please select a target position in the table.");
            else
            {
                GotoPositionJoint(name);
                PerformPrompt(String.Format("Wait for robot joint move to {0} complete", name), true, true);
            }
        }
        #endregion ===== POSITIONS DATABASE CODE           ==============================================================================================================================

        #region ===== VARIABLE MANAGEMENT CODE          ==============================================================================================================================
        readonly string variablesFilename = "Variables.xml";

        public double ReadVariableDouble(string name, double defaultValue = 0)
        {
            double x = 0;
            try
            {
                x = Convert.ToDouble(ReadVariable(name, defaultValue.ToString()));
            }
            catch
            {
                log.Error($"ReadVariableDouble({name}) failed");

            }

            return x;
        }
        public double ReadVariableInt(string name, int defaultValue = 0)
        {
            int x = 0;
            try
            {
                x = Convert.ToInt32(ReadVariable(name, defaultValue.ToString()));
            }
            catch
            {
                log.Error($"ReadVariableDouble({name}) failed");

            }

            return x;
        }
        public string ReadVariable(string name, double defaultValue)
        {
            return ReadVariable(name, defaultValue.ToString());
        }
        public string ReadVariable(string name, string defaultValue = null)
        {
            /*
            if (name == "DateTime")
                return DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            if (name == "LEScriptFilename")
                return System.IO.Path.GetFileNameWithoutExtension(SequenceFilenameLbl.Text).Replace(' ', '_').ToLower();
            if (name == "LEonardLanguage")
                return LEonardLanguage.ToString();
            if (name == "LEonardRoot")
                return LEonardRoot;
            */

            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace("ReadVariable({0}) = {1}", row["Name"], row["Value"]);
                    row["IsNew"] = false;
                    return row["Value"].ToString();
                }
            }
            //log.Error("ReadVariable({0}) Not Found", name);
            return defaultValue;
        }
        public bool SetSystemVariable(string name, bool isSystem)
        {
            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    row["IsSystem"] = isSystem;
                    return true;
                }
            }
            log.Error($"SetSystemVariable({name},{isSystem}) Not Found");
            return false;
        }

        private Color ColorFromBooleanName(string name, bool invert = false)
        {
            switch (name)
            {
                case "True":
                    return invert ? Color.Red : Color.Green;
                case "False":
                    return invert ? Color.Green : Color.Red;
                default:
                    return Color.Yellow;
            }
        }


        public bool WriteVariable(string name, double value, bool isSystem = false)
        {
            return WriteVariable(name, value.ToString(), isSystem);
        }
        public bool WriteVariable(string name, int value, bool isSystem = false)
        {
            return WriteVariable(name, value.ToString(), isSystem);
        }
        public bool WriteVariable(string name, bool value, bool isSystem = false)
        {
            return WriteVariable(name, value ? "True" : "False", isSystem);
        }

        static readonly object lockObject = new object();
        static string alsoWriteVariableAs = null;
        static string copyVariableAtWrite = null;
        static string copyPositionAtWrite = null;
        static bool isSystemAlsoWrite = false;
        static bool isSystemCopyWrite = false;
        public bool WriteVariable(string name, string value, bool isSystem = false, bool pushToEngines = true)
        {
            System.Threading.Monitor.Enter(lockObject);
            if (value == null) value = "Null";
            string nameTrimmed = name.Trim();
            string valueTrimmed = value.Trim();

            // Automatically consider and variables with name starting in robot_ or grind_to be system variables
            if (nameTrimmed.StartsWith("robot_") || nameTrimmed.StartsWith("grind_")) isSystem = true;

            // Automatically add to javaEngine and pythonEngine
            if (pushToEngines)
            {
                //javaEngine.SetValue(name, value);
                ExecuteJavaScript($"{name} = '{value}'", null);
                ExecutePythonScript($"{name} = '{value}'", null);
                //pythonScope.SetVariable(name, value);
                //pythonEngine.Runtime.Globals.SetVariable(name, value);
            }

            log.Trace("WriteVariable({0}, {1})", nameTrimmed, valueTrimmed);
            if (variables == null)
            {
                log.Error("variables == null!!??");
                return false;
            }
            string datetime;
            //datetime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");  // If you prefer UTC time
            datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            bool foundVariable = false;
            foreach (DataRow row in variables.Rows)
            {
                if ((string)row["Name"] == nameTrimmed)
                {
                    row["Value"] = valueTrimmed;
                    row["IsNew"] = true;
                    row["TimeStamp"] = datetime;
                    row["IsSystem"] = isSystem;
                    foundVariable = true;
                    break;
                }
            }

            if (!foundVariable)
                variables.Rows.Add(new object[] { nameTrimmed, valueTrimmed, true, datetime, isSystem });

            // Update real-time annunciators
            switch (nameTrimmed)
            {
                case "robot_ready":
                    RobotReadyLbl.BackColor = ColorFromBooleanName(valueTrimmed);
                    RobotReadyLbl.Refresh();
                    break;
                case "gocator_ready":
                    GocatorReadyLbl.BackColor = ColorFromBooleanName(valueTrimmed);
                    GocatorReadyLbl.Refresh();
                    break;
                case "robot_response":
                    if (valueTrimmed.Contains("ERROR"))
                        PerformPrompt($"Received error message from robot: {valueTrimmed}");
                    break;
                case "robot_starting":
                    // This gets sent to us by command_validate on the UR. It means command valueTrimmed is going to start executing
                    log.Info("R.<== EXEC {0} STARTING", valueTrimmed);
                    break;
                case "robot_completed":
                    // This gets sent to us by PolyScope on the UR after command valueTrimmed has finished executing
                    RobotCompletedLbl.Text = valueTrimmed;
                    log.Info("R.<== EXEC {0} COMPLETED", valueTrimmed);

                    // Color us green if we're caught up!
                    if (RobotSentLbl.Text == RobotCompletedLbl.Text)
                        RobotCompletedLbl.BackColor = Color.Green;
                    RobotCompletedLbl.Refresh();

                    // Close operator "wait for robot" form if we're caught up
                    if (waitingForOperatorMessageForm != null && closeOperatorFormOnIndex && RobotSentLbl.Text == RobotCompletedLbl.Text)
                    {
                        waitingForOperatorMessageForm.Close();
                        waitingForOperatorMessageForm = null;
                        closeOperatorFormOnIndex = false;
                    }
                    break;
                case "grind_ready":
                    GrindReadyLbl.BackColor = ColorFromBooleanName(valueTrimmed);
                    RobotReadyLbl.Refresh();
                    break;
                case "grind_process_state":
                    GrindProcessStateLbl.BackColor = ColorFromBooleanName(valueTrimmed, true);
                    RobotReadyLbl.Refresh();
                    break;
                case "grind_n_cycles":
                    GrindNCyclesLbl.Text = valueTrimmed;
                    break;
                case "grind_cycle":
                    if (valueTrimmed == "0") valueTrimmed = "-";  // Gets set to 0 initially, will go to 1 when 1st actual cycle starts
                    GrindCycleLbl.Text = valueTrimmed;
                    break;
                case "grind_force_report_z_n":
                    try
                    {
                        double f = Convert.ToDouble(valueTrimmed);
                        GrindForceReportZLbl.Text = f.ToString("0.0");
                    }
                    catch
                    {
                        GrindForceReportZLbl.Text = "?.?";
                    }
                    break;
                case "robot_linear_speed_mmps":
                    SetLinearSpeedBtn.Text = "Linear Speed\n" + valueTrimmed + " mm/s";
                    break;
                case "robot_linear_accel_mmpss":
                    SetLinearAccelBtn.Text = "Linear Acceleration\n" + valueTrimmed + " mm/s^2";
                    break;
                case "robot_blend_radius_mm":
                    SetBlendRadiusBtn.Text = "Blend Radius\n" + valueTrimmed + " mm";
                    break;
                case "robot_joint_speed_dps":
                    SetJointSpeedBtn.Text = "Joint Speed\n" + valueTrimmed + " deg/s";
                    break;
                case "robot_joint_accel_dpss":
                    SetJointAccelBtn.Text = "Joint Acceleration\n" + valueTrimmed + " deg/s^2";
                    break;
                case "robot_door_closed_input":
                    DoorClosedInputLbl.Text = DoorClosedInputTxt.Text = valueTrimmed.Trim(new char[] { '[', ']' });
                    break;
                case "robot_footswitch_pressed_input":
                    FootswitchPressedInputLbl.Text = FootswitchPressedInputTxt.Text = valueTrimmed.Trim(new char[] { '[', ']' });
                    break;
                case "robot_step_time_estimate_ms":
                    double ms = Convert.ToDouble(valueTrimmed);
                    stepEndTimeEstimate = stepStartedTime.AddMilliseconds(ms);
                    TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)ms);
                    StepTimeEstimateLbl.Text = TimeSpanFormat(ts);
                    break;
                case "robot_door_closed":
                    switch (valueTrimmed)
                    {
                        case "False":
                            DoorClosedLbl.Text = "Door Open";
                            DoorClosedLbl.BackColor = Color.Red;
                            if (runState == RunState.RUNNING)
                            {
                                // Trying to avoid bothering UR with a stop command... it is already stopping because it saw the door open!
                                PauseBtn_Click(null, null);
                            }
                            break;
                        case "True":
                            DoorClosedLbl.Text = "Door Closed";
                            DoorClosedLbl.BackColor = Color.Green;
                            break;
                        default:
                            DoorClosedLbl.Text = "Door ????";
                            DoorClosedLbl.BackColor = Color.Yellow;
                            break;
                    }
                    break;
                case "robot_footswitch_pressed":
                    switch (valueTrimmed)
                    {
                        case "False":
                            FootswitchPressedLbl.Text = "Pedal Up";
                            FootswitchPressedLbl.BackColor = Color.Green;
                            if (runState != RunState.RUNNING)
                                // Disable freedrive mode
                                RobotSend("30,19,0");
                            break;
                        case "True":
                            FootswitchPressedLbl.Text = "Pedal Pressed";
                            FootswitchPressedLbl.BackColor = Color.Red;
                            if (runState != RunState.RUNNING)
                                // Enable freedrive in base coords with all axes on
                                RobotSend("30,19,1,0,1,1,1,1,1,1");
                            break;
                        default:
                            FootswitchPressedLbl.Text = "Pedal ????";
                            FootswitchPressedLbl.BackColor = Color.Yellow;
                            break;
                    }
                    break;
                case "grind_touch_speed_mmps":
                    SetTouchSpeedBtn.Text = "Grind Touch Speed\n" + valueTrimmed + " mm/s";
                    break;
                case "grind_touch_retract_mm":
                    SetTouchRetractBtn.Text = "Grind Touch Retract\n" + valueTrimmed + " mm";
                    break;
                case "grind_force_dwell_ms":
                    SetForceDwellBtn.Text = "Grind Force Dwell Time\n" + valueTrimmed + " ms";
                    break;
                case "grind_max_wait_ms":
                    SetMaxWaitBtn.Text = "Grind Max Wait Time\n" + valueTrimmed + " ms";
                    break;
                case "grind_max_blend_radius_mm":
                    SetMaxGrindBlendRadiusBtn.Text = "Grind Max Blend Radius\n" + valueTrimmed + " mm";
                    break;
                case "grind_trial_speed_mmps":
                    SetTrialSpeedBtn.Text = "Grind Trial Speed\n" + valueTrimmed + " mm/s";
                    break;
                case "grind_point_frequency_hz":
                    SetPointFrequencyBtn.Text = "Grind Point Frequency\n" + valueTrimmed + " Hz";
                    break;
                case "grind_jog_speed_mmps":
                    SetGrindJogSpeedBtn.Text = "Grind Jog Speed\n" + valueTrimmed + " mm/s";
                    break;
                case "grind_jog_accel_mmpss":
                    SetGrindJogAccelBtn.Text = "Grind Jog Accel\n" + valueTrimmed + " mm/s^2";
                    break;
                case "grind_linear_accel_mmpss":
                    SetGrindAccelBtn.Text = "Grind Acceleration\n" + valueTrimmed + " mm/s^2";
                    break;
                case "grind_force_mode_damping":
                    SetForceModeDampingBtn.Text = "Force Damping\n" + valueTrimmed;
                    break;
                case "grind_force_mode_gain_scaling":
                    SetForceModeGainScalingBtn.Text = "Force Gain Scaling\n" + valueTrimmed;
                    break;
                case "grind_contact_enable":
                    switch (valueTrimmed)
                    {
                        case "0":
                            GrindContactEnabledBtn.Text = "Touch OFF\nGrind OFF";
                            GrindContactEnabledBtn.BackColor = Color.Red;
                            break;
                        case "1":
                            GrindContactEnabledBtn.Text = "Touch ON\nGrind OFF";
                            GrindContactEnabledBtn.BackColor = Color.Blue;
                            break;
                        case "2":
                            GrindContactEnabledBtn.Text = "Touch ON\n Grind ON";
                            GrindContactEnabledBtn.BackColor = Color.Green;
                            break;
                        default:
                            GrindContactEnabledBtn.Text = "????";
                            GrindContactEnabledBtn.BackColor = Color.Red;
                            break;
                    }
                    break;
            }

            //variables.AcceptChanges();
            Monitor.Exit(lockObject);

            // This is a special capability that is not necessarily the best way to handle this!
            // If you set alsoWriteVariableAs=name, the next WriteVariable will write the same value to name
            if (alsoWriteVariableAs != null)
            {
                string dupName = alsoWriteVariableAs;
                alsoWriteVariableAs = null; // Let's avoid infinite recursion :)
                WriteVariable(dupName, valueTrimmed, isSystemAlsoWrite);
                isSystemAlsoWrite = false;
            }

            // Another experiment
            // Set copyVariableAtWrite to "name1=name2" and when name2 gets written it will also be written to name1
            if (copyVariableAtWrite != null)
            {
                string[] strings = copyVariableAtWrite.Split('=');
                if (strings.Length > 1)
                {
                    if (strings[1] == nameTrimmed)
                    {
                        copyVariableAtWrite = null; // Let's avoid infinite recursion :)
                        WriteVariable(strings[0], valueTrimmed, isSystemCopyWrite);
                        isSystemCopyWrite = false;
                    }
                }
            }

            // Set copyPositionAtWrite to "name" and when actual_tcp_pose or actual_joint_positions gets written it will also be written to Position:name
            if (copyPositionAtWrite != null)
            {
                if (name == "actual_joint_positions")
                {
                    WritePosition(copyPositionAtWrite, valueTrimmed, "", isSystemCopyWrite);
                }
                if (name == "actual_tcp_pose")
                {
                    WritePosition(copyPositionAtWrite, "", valueTrimmed, isSystemCopyWrite);
                    copyPositionAtWrite = null;
                    isSystemCopyWrite = false;
                }
            }
            return true;
        }


        // Regex to look for varname = value expressions (value can be any string, numeric or not)
        // @"^\s*                           Start of line, ignore leading whitespace
        // (?<name>[A-Za-z][A-Za-z0-9_]*)   Group "name" is one alpha followed by 0 or more alphanum and underscore
        // \s*                              Ignore whitespace
        // =                                Equals
        // \s*                              Ignore whitespace
        // (?<value>[A-Za-z0-9 _]+)         Group "value" is one or morealphanum space or underscore
        // \s*$"                            Ignore whitespace to EOL
        static readonly Regex directAssignmentRegex = new Regex(@"^\s*(?<name>[A-Za-z][A-Za-z0-9_]*)\s*=\s*(?<value>[\S ]+)$", RegexOptions.ExplicitCapture & RegexOptions.Compiled);

        // Regex to look for varname += or -= number expressions
        // @"^\s*                           Start of line, ignore leading whitespace
        // (?<name>[A-Za-z][A-Za-z0-9_]*)   Group "name" is one alpha followed by 0 or more alphanum and underscore
        // \s*                              Ignore whitespace
        // (?<operator>(\+=|\-=))           Group "operator" can be += or -=
        // \s*                              Ignore whitespace
        // (?<value>[\-+]?[0-9.]+)          Group "value" can be optional (+ or -) followed by one or more digits and decimal
        // \s*$"                            Ignore whitespace to EOL
        static readonly Regex plusMinusEqualsRegex = new Regex(@"^\s*(?<name>[A-Za-z][A-Za-z0-9_]*)\s*(?<operator>(\+=|\-=))\s*(?<value>[\-+]?[0-9.]+)$", RegexOptions.ExplicitCapture & RegexOptions.Compiled);

        // Regex to look for varname += or -= number expressions
        // @"^\s*                           Start of line, ignore leading whitespace
        // (?<name>[A-Za-z][A-Za-z0-9_]*)   Group "name" is one alpha followed by 0 or more alphanum and underscore
        // (?<operator>(\+\+|\-\-))         Group "operator" can be ++ or --
        // \s*$"                            Ignore whitespace to EOL
        static readonly Regex plusPlusMinusMinusRegex = new Regex(@"^\s*(?<name>[A-Za-z][A-Za-z0-9_]*)(?<operator>(\+\+|\-\-))\s*$", RegexOptions.ExplicitCapture & RegexOptions.Compiled);

        /// <summary>
        /// Takes a "name=value" string and set variable "name" equal to "value"
        /// ALSO: will handle name++ and name--
        /// ALSO: will handle name+=value and name-=value
        /// </summary>
        /// <param name="assignment">Variable to be modified</param>
        public bool UpdateVariable(string assignment, bool isSystem = false)
        {
            bool wasSuccessful = false;

            Match m = directAssignmentRegex.Match(assignment);
            if (m.Success)
            {
                log.Trace("DirectAssignment {0}={1}", m.Groups["name"].Value, m.Groups["value"].Value);
                wasSuccessful = WriteVariable(m.Groups["name"].Value, m.Groups["value"].Value, isSystem);
            }
            else
            {
                m = plusMinusEqualsRegex.Match(assignment);
                if (m.Success)
                {
                    log.Trace("PlusMinusEqualsAssignment {0}{1}{2}", m.Groups["name"].Value, m.Groups["operator"].Value, m.Groups["value"].Value);
                    string v = ReadVariable(m.Groups["name"].Value, "0");  // For += and -=, if the variable does nbot exist, it will be assumed to be 0!
                    if (v != null)
                    {
                        try
                        {
                            double x = Convert.ToDouble(v);
                            double y = Convert.ToDouble(m.Groups["value"].Value);
                            x = x + ((m.Groups["operator"].Value == "+=") ? y : -y);

                            wasSuccessful = WriteVariable(m.Groups["name"].Value, x.ToString());
                        }
                        catch { }
                    }
                }
                else
                {
                    m = plusPlusMinusMinusRegex.Match(assignment);
                    if (m.Success)
                    {
                        log.Trace("IncrAssignment {0}{1}", m.Groups["name"].Value, m.Groups["operator"].Value);
                        string v = ReadVariable(m.Groups["name"].Value, "0");  // For ++ and --, if the variable does nbot exist, it will be assumed to be 0!
                        if (v != null)
                        {
                            try
                            {
                                double x = Convert.ToDouble(v);
                                x = x + ((m.Groups["operator"].Value == "++") ? 1.0 : -1.0);
                                wasSuccessful = WriteVariable(m.Groups["name"].Value, x.ToString());
                            }
                            catch { }
                        }
                    }
                }
            }
            return wasSuccessful;
        }

        private void LoadVariables()
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, variablesFilename);
            log.Info("LoadVariables from {0}", filename);
            ClearAndInitializeVariables();
            try
            {
                variables.ReadXml(filename);
            }
            catch
            { }

            VariablesGrd.DataSource = variables;

            // Clear the IsNew flags
            foreach (DataRow row in variables.Rows)
                row["IsNew"] = false;
        }

        private void SaveVariables()
        {
            string filename = System.IO.Path.Combine(LEonardRoot, ConfigFolder, variablesFilename);
            log.Info("SaveVariables to {0}", filename);
            variables.AcceptChanges();
            variables.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private bool DeleteFirstNonSystemEntry(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["IsSystem"].ToString() != "True")
                {
                    log.Debug("Delete {0}", row["Name"]);
                    row.Delete();
                    table.AcceptChanges();
                    return true;
                }
            }
            return false;
        }
        private void ClearNonSystemVariables()
        {
            while (DeleteFirstNonSystemEntry(variables)) ;
        }
        private void ClearVariablesBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all non-system variables. Proceed?"))
                ClearNonSystemVariables();
        }

        private void ClearAndInitializeVariables()
        {
            variables = new DataTable("Variables");
            DataColumn name = variables.Columns.Add("Name", typeof(System.String));
            variables.Columns.Add("Value", typeof(System.String));
            variables.Columns.Add("IsNew", typeof(System.Boolean));
            variables.Columns.Add("TimeStamp", typeof(System.String));
            variables.Columns.Add("IsSystem", typeof(System.Boolean));
            variables.CaseSensitive = true;
            variables.PrimaryKey = new DataColumn[] { name };
            VariablesGrd.DataSource = variables;
        }

        private void ClearAllVariablesBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all variables INCLUDING system variables. Proceed?"))
                ClearAndInitializeVariables();
        }
        #endregion ===== VARIABLE MANAGEMENT CODE          ==============================================================================================================================

        #region ===== EXECUTIVE FUNCTIONS               ==============================================================================================================================
        // Something isn't right. If we're running, select PAUSE
        private void EnsureNotRunning()
        {
            if (runState == RunState.RUNNING)
                PauseBtn_Click(null, null);
        }
        // Something isn't right. If we're not stopped, select STOP
        private void EnsureStopped()
        {
            if (runState == RunState.RUNNING || runState == RunState.PAUSED)
                StopBtn_Click(null, null);
        }
        /// <summary>
        /// Is the line a label? This means starting with alpha, followed by 0 or more alphanum, followed by :
        /// </summary>
        /// <param name="line">Input Line</param>
        /// <returns>(bool Success, string Value if matched else null)</returns>
        private (bool Success, string Value) IsLineALabel(string line)
        {
            //Regex regex = new Regex("^[A-Za-z_][A-Za-z0-9_]*:$"); // Original until 11/6/2022
            Regex regex = new Regex("^[A-Za-z_][A-Za-z0-9_]*:");  // Making universal for all 3 languages
            Match match = regex.Match(line);
            if (match.Success)
                return (true, match.Value.Trim(':'));
            else
                return (false, null);
        }

        Dictionary<string, int> labels;
        private bool BuildLabelTable()
        {
            log.Debug("EXEC BuildLabelTable()");

            labels = new Dictionary<string, int>();

            int lineNo = 1;
            foreach (string line in SequenceRTB.Lines)
            {
                string cleanLine = line;

                // 1) Ignore comments: drop anything from # onward in the line
                int index = cleanLine.IndexOf("#");
                if (index >= 0)
                    cleanLine = cleanLine.Substring(0, index);

                // 2) Cleanup the line: drop all trailing whitespace
                cleanLine = cleanLine.TrimEnd(' ');

                var label = IsLineALabel(cleanLine);
                if (label.Success)
                {
                    try
                    {
                        labels.Add(label.Value, lineNo);
                    }
                    catch
                    {
                        ErrorMessageBox(String.Format("Label Problem\nRepeated label \"{0}\" on line {1}", label.Value, lineNo));
                        return false;
                    }
                    log.Debug("EXEC Found label {0:000}: {1}", lineNo, label.Value);
                }
                lineNo++;
            }

            return true;
        }

        // 1-based line number currently executing in Sequence (1 is first line)
        static int lineCurrentlyExecuting = 0;
        private string SetCurrentLine(int n)
        {
            lineCurrentlyExecuting = n;

            if (n >= 1 && n <= SequenceRTB.Lines.Count())
            {
                (int start, int length) = SequenceRTB.GetLineExtents(lineCurrentlyExecuting - 1);

                SequenceRTB.SelectAll();
                SequenceRTB.SelectionFont = new Font(SequenceRTB.Font, FontStyle.Regular);

                SequenceRTB.Select(start, length);
                SequenceRTB.SelectionFont = new Font(SequenceRTB.Font, FontStyle.Bold);
                SequenceRTB.ScrollToCaret();
                SequenceRTB.ScrollToCaret();

                SequenceRTBCopy.Select(start, length);
                SequenceRTBCopy.SelectionFont = new Font(SequenceRTBCopy.Font, FontStyle.Bold);
                SequenceRTBCopy.ScrollToCaret();
                SequenceRTBCopy.ScrollToCaret();
                return SequenceRTB.Lines[lineCurrentlyExecuting - 1];
            }
            return null;
        }

        Stack<int> callStack = new Stack<int>();
        // Call Stack!!
        void PushCurrentLine()
        {
            log.Debug($"About to push {lineCurrentlyExecuting} onto callStack");
            callStack.Push(lineCurrentlyExecuting);
        }
        bool PopCurrentLine()
        {
            if (callStack.Count > 0)
            {
                log.Debug($"About to pop {callStack.Peek()} from callStack");
                SetCurrentLine(callStack.Pop());
                return true;
            }
            ExecError("Return without Call");
            return false;
        }

        private bool ExecuteLEScriptFile(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(LEonardRoot, CodeFolder, filename));

                int lineNo = 1;
                foreach (string line in lines)
                {
                    log.Info("Execute Line: {0}", line);
                    ExecuteLEScriptLine(lineNo++, line);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, $"ExecuteLEScriptFile({filename}) failed");
                return false;
            }
        }

        /// Read file looking for lines of the form "name=value" and pass then to the variable write function
        private bool le_import_variables(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(LEonardRoot, CodeFolder, filename));

                foreach (string line in lines)
                {
                    log.Info("Import Line: {0}", line);
                    if (line.Contains("="))
                        UpdateVariable(line);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "ImportFile({0}) failed", filename);
                return false;
            }
        }

        private void UnboldSequence()
        {
            SequenceRTB.SelectAll();
            SequenceRTB.SelectionFont = new Font(SequenceRTB.Font, FontStyle.Regular);
            SequenceRTB.DeselectAll();

            SequenceRTBCopy.SelectAll();
            SequenceRTBCopy.SelectionFont = new Font(SequenceRTB.Font, FontStyle.Regular);
            SequenceRTBCopy.DeselectAll();
        }

        bool isSingleStep = false;
        Stopwatch sleepTimer = null;
        double sleepMs = 0;
        private void ReportStepTimeStats()
        {
            if (stepEndTimeEstimate != stepStartedTime)
            {
                // Redo this at the very end- normally is only called at 1Hz by HeartbeatTmr
                RecomputeTimes();
                log.Info("EXEC Estimated={0} Actual={1}", StepTimeEstimateLbl.Text, StepElapsedTimeLbl.Text);
            }
        }
        public bool RobotCompletedCaughtUp()
        {
            return ReadVariable("robot_completed") == robotSendIndex.ToString();
        }

        private void ExecTmr_Tick(object sender, EventArgs e)
        {
            // Wait for any operator prompt to be cleared
            if (waitingForOperatorMessageForm != null)
            {
                switch (waitingForOperatorMessageForm.result)
                {
                    case DialogResult.None:
                        return;
                    case DialogResult.Cancel:
                        log.Error("Operator selected \"Abort\" in MessageForm");
                        SetState(RunState.READY);
                        waitingForOperatorMessageForm = null;
                        return;
                    case DialogResult.OK:
                        log.Info("Operator selected \"Continue\" in MessageForm");
                        waitingForOperatorMessageForm = null;
                        break;
                }
            }

            // Stopwatch
            if (sleepTimer != null)
            {
                if (sleepTimer.ElapsedMilliseconds > sleepMs)
                    sleepTimer = null;
                else
                    return;
            }

            // If a UR is in focus and running, wait for stopped
            if (LeUrDashboard.uiFocusInstance != null)
                if (!RobotCompletedCaughtUp()) return;

            // If a Gocator is in focus, wait for stopped
            if (LeGocator.uiFocusInstance != null)
                if (ReadVariable("gocator_ready") != "True") return;

            if (lineCurrentlyExecuting >= SequenceRTB.Lines.Count())
            {
                log.Info($"EXEC  {lineCurrentlyExecuting:00000}: End of Sequence");
                ReportStepTimeStats();

                UnboldSequence();
                SetSequenceState(sequenceStateAtRun);
                SetState(RunState.READY);
            }
            else
            {
                ReportStepTimeStats();

                string line = SetCurrentLine(lineCurrentlyExecuting + 1);

                if (labels.ContainsValue(lineCurrentlyExecuting))
                    log.Info($"EXEC  {lineCurrentlyExecuting:00000}: Label {line}");
                else
                {
                    bool fContinue = false;
                    switch (LEonardLanguage)
                    {
                        case LEonardLanguages.LEScript:
                            fContinue = ExecuteLEScriptLine(lineCurrentlyExecuting, line);
                            break;
                        case LEonardLanguages.Java:
                            fContinue = ExecuteJavaLine(lineCurrentlyExecuting, line);
                            break;
                        case LEonardLanguages.Python:
                            fContinue = ExecutePythonLine(lineCurrentlyExecuting, line);
                            break;
                    }

                    if (isSingleStep)
                    {
                        isSingleStep = false;
                        SetState(RunState.PAUSED);
                    }
                    /* This isn't how this works anymore!
                    if (!fContinue)
                    {
                        log.Info("EXEC Execution ending");
                        UnboldSequence();
                        SetSequenceState(sequenceStateAtRun);
                        SetState(RunState.READY);
                    }
                    */
                }
            }
        }
        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            if (interfaces.Length == 0) return;

            // TODO: This is WIP since shouldn't need to call receive once callbacks work
            // TODO: do we really need to keep polling for message receipt?
            foreach (LeDeviceInterface device in interfaces)
            {
                if (device != null)
                {
                    SetMeDevice(device);
                    device.Receive(true); // true ==> fProcessCallBackOnly
                }
            }
        }

        #endregion ===== EXECUTIVE FUNCTIONS               ==============================================================================================================================

        #region ===== LESCRIPT DECODE AND EXECUTE       ==============================================================================================================================
        /// <summary>
        /// Return the characters enclosed in the first set of matching ( ) in a string
        /// Example: "speed (13.0)" returns 13.0 
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns>Characters enclosed in (...) or ""</returns>
        string ExtractParameters(string s, int nParams = -1, bool cutSpaces = true)
        {
            try
            {
                // Get what is enclosed between the first set of parentheses
                string parameters = "";
                parameters = Regex.Match(s, @"\(([^)]*)\)").Groups[1].Value;
                /* \(           # Starts with a '(' character"
                       (        # Parentheses in a regex mean "put (capture) the stuff in between into the Groups array
                          [^)]  # Any character that is not a ')' character
                          *     # Zero or more occurrences of the aforementioned "non ')' char
                       )        # Close the capturing group
                   \)           # Ends with a ')' character  */
                log.Trace("EXEC params=\"{0}\"", parameters);

                // Drop spaces if requested!
                if (cutSpaces)
                    parameters = Regex.Replace(parameters, @"\s+", "");


                // If nParams is specified (> -1), verify we have the right number!
                if (nParams > -1)
                {
                    if (nParams == 0)
                    {
                        if (parameters.Length != 0)
                        {
                            log.Trace("EXEC sees params={0} where none are expected", parameters);
                            return s;  // Nothing expected, we'll return what was there hoping to trigger a failure!
                        }
                    }
                    else
                    {
                        int commaCount = parameters.Count(f => (f == ','));
                        if (commaCount != nParams - 1)
                            return "";
                    }
                }
                return parameters;
            }
            catch (Exception ex)
            {
                log.Error(ex, "LEScript line parameter error: {0} {1}", s, ex);
                return "";
            }
        }

        public bool ExtractDoubleParameters(string command, int nParams, out double[] dparams)
        {
            dparams = null;

            // Get the command name
            int openParenIndex = command.IndexOf("(");
            int closeParenIndex = command.IndexOf(")");
            if (openParenIndex < 0 || closeParenIndex < openParenIndex)
                return false;

            string functionName = command.Substring(0, openParenIndex);

            string parameters = ExtractParameters(command, nParams);
            if (parameters.Length == 0)
            {
                ExecError($"{functionName} did not have {nParams} parameter{(nParams > 1 ? "s" : "")}");
                return false;
            }

            string[] paramList = parameters.Split(',');
            if (paramList.Length != nParams)
            {
                ExecError($"{functionName} could not extract {nParams} parameter{(nParams > 1 ? "s" : "")}");
                return false;
            }

            dparams = new double[nParams];
            for (int i = 0; i < nParams; i++)
            {
                try
                {
                    dparams[i] = Convert.ToDouble(paramList[i]);
                }
                catch
                {
                    ExecError($"{functionName} parameter {i + 1} is not a number: {paramList[i]}");
                    return false;
                }
            }
            return true;
        }
        public bool ExtractDoubleParameter(string command, out double dparam)
        {
            double[] dparams;
            dparam = 0;
            if (ExtractDoubleParameters(command, 1, out dparams))
            {
                dparam = dparams[0];
                return true;
            }
            return false;
        }
        public bool ExtractIntParameter(string command, out int iparam)
        {
            double dparam = 0;
            iparam = 0;
            if (ExtractDoubleParameter(command, out dparam))
            {
                iparam = Convert.ToInt32(dparam);
                return true;
            }
            return false;
        }

        string ExtractScalars(string input)
        {
            try
            {
                return input.Split('[', ']')[1];
            }
            catch
            {
                return "";
            }
        }

        // Specifies number of expected parameters and prefix in RobotSend for each function
        public struct CommandSpec
        {
            public int nParams;
            public string prefix;
        };

        public static string GetRobotPrefix(string command)
        {
            if (robotFunctionConversionDictionary.TryGetValue(command, out CommandSpec commandSpec))
                return commandSpec.prefix;
            else
                log.Error($"GetRobotPrefix({command}) Does not exist.");
            return null;
        }


        /// <summary>
        /// Return true iff string 'str' represents a number between lowLim and hiLim
        /// </summary>
        /// <param name="str">String to be checked</param>
        /// <param name="lowLim">Lowest allowable int</param>
        /// <param name="hiLim">Highest allowable int</param>
        /// <returns></returns>
        private bool ValidNumericString(string s, double lowLim, double hiLim)
        {
            try
            {
                double x = Convert.ToDouble(s);
                if (x < lowLim || x > hiLim)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }

        }

        int errorLineNumber = -1;
        string errorOrigLine = "";
        private void ExecError(string message)
        {
            string report = message + $"\nLine {errorLineNumber:000}: {errorOrigLine}";
            log.Error("EXEC " + report.Replace('\n', ' '));
            PerformPrompt("ERROR:\n" + report);
        }

        Random random = new Random();

        private void CommonLineExecStart(int lineNumber, string origLine)
        {
            // Step is starting now
            stepStartedTime = DateTime.Now;

            // Default time estimate to complete step is 0
            stepEndTimeEstimate = stepStartedTime;

            // Setup for ExecError
            errorLineNumber = lineNumber;
            errorOrigLine = origLine;

            // Line gets shown on screen with variables substituted and time estimate (unless we're making system calls)
            if (lineNumber > 0)
            {
                CurrentLineLbl.Text = String.Format("{0:000}: {1}", lineNumber, origLine);
                StepTimeEstimateLbl.Text = TimeSpanFormat(new TimeSpan());
            }
        }

        private bool ExecuteJavaLine(int lineNumber, string line, LeDeviceInterface dev = null)
        {
            if (lineNumber < 1)
                log.Info($"EXECJ {line}");
            else
                log.Info($"EXECJ {lineNumber:00000}: {line}");

            CommonLineExecStart(lineNumber, line);

            try
            {
                bool ret = false;
                if (line != null)
                {
                    javaEngine.Execute(line);
                    JavaUpdateVariablesRTB();
                    ret = true;
                }
                if (!ret)
                {
                    ExecError($"Cannot execute Java line {lineNumber:0000}: {line}");
                }
                return true;
            }
            catch (Exception ex)
            {
                // User decides whether to continue!
                ExecError($"Java Line Error: {line}\n{ex}");
                return true;  //false
            }
        }
        private bool ExecutePythonLine(int lineNumber, string line, LeDeviceInterface dev = null)
        {
            if (lineNumber < 1)
                log.Info($"EXECP {line}");
            else
                log.Info($"EXECP {lineNumber:00000}: {line}");

            CommonLineExecStart(lineNumber, line);

            try
            {
                bool ret = false;
                if (line != null) ret = PythonExec(line);
                PythonUpdateVariablesRTB();
                if (!ret)
                {
                    ExecError($"Cannot execute Python line {lineNumber:0000}: {line}");
                }
                return true; // ret;
            }
            catch (Exception ex)
            {
                // User decides if continue!
                ExecError($"Python Line Error: {line}\n{ex}");
                return true; // false;
            }
        }


        private bool ExecuteLEScriptLine(int lineNumber, string line, LeDeviceInterface dev = null)
        {
            if (lineNumber < 1)
                log.Info($"EXECL {line}");
            else
                log.Info($"EXECL {lineNumber:00000}: {line}");

            CommonLineExecStart(lineNumber, line);

            // Any variables to substitute {varName}
            string origLine = line;
            line = Regex.Replace(line, @"\{([^}]*)\}", m => ReadVariable(m.Groups[1].Value, "var_not_found"));
            /* {            # Bracket, means "starts with a '{' character"
                   (        # Parentheses in a regex mean "put (capture) the stuff in between into the Groups array
                      [^}]  # Any character that is not a '}' character
                      *     # Zero or more occurrences of the aforementioned "non '}' char
                   )        # Close the capturing group
               }            # Ends with a '}' character  */
            if (line != origLine)
                log.Info($"EXECL {lineNumber:00000}: {line}");

            // 1) Ignore comments: drop anything from # onward in the line AND anything from // onward!
            int index = line.IndexOf("#");
            if (index >= 0)
                line = line.Substring(0, index);
            index = line.IndexOf("//");
            if (index >= 0)
                line = line.Substring(0, index);

            // 2) Cleanup the line: replace all 2 or more whitespace with a single space and drop all leading/trailing whitespace
            string command = Regex.Replace(line, @"\s+", " ").Trim();

            // Skip blank lines or lines that previously had only comments
            if (command.Length < 1)
                return true;

            // Ensure all commands end with ) and nbothing comes after the first )
            int parenIndex = command.IndexOf(')');
            if (parenIndex >= 0 && parenIndex != command.Length - 1)
            {
                ExecError("Illegal line contains characters after ')'");
                return true;
            }

            // Language Selection Functions
            // using_lescript
            if (command == "using_lescript()")
            {
                using_lescript();
                return true;
            }

            // using_java
            if (command == "using_java()")
            {
                using_java();
                return true;
            }

            // using_python
            if (command == "using_python()")
            {
                using_python();
                return true;
            }

            // exec_lescript
            if (command.StartsWith("exec_lescript("))
            {
                string filename = ExtractParameters(command);

                if (!ExecuteLEScriptFile(filename))
                    ExecError($"Cannot execute LEScript file {filename}");

                return true;
            }

            // exec_java
            if (command.StartsWith("exec_java("))
            {
                string filename = ExtractParameters(command);

                if (!ExecuteJavaFile(filename))
                    ExecError($"Cannot execute Java file {filename}");

                return true;
            }

            // exec_python
            if (command.StartsWith("exec_python("))
            {
                string filename = ExtractParameters(command);
                if (!ExecutePythonFile(filename))
                    ExecError($"Cannot execute Python file {filename}");

                return true;
            }

            // execline_lescript
            if (command.StartsWith("execline_lescript("))
            {
                string param = ExtractParameters(command);

                if (!ExecuteLEScriptLine(-1, param))
                    ExecError($"Cannot execute LEScript line {param}");

                return true;
            }

            // execline_java
            if (command.StartsWith("execline_java("))
            {
                string param = ExtractParameters(command);

                if (!ExecuteJavaLine(-1, param))
                    ExecError($"Cannot execute Java line {param}");

                return true;
            }

            // execline_python
            if (command.StartsWith("execline_python("))
            {
                string param = ExtractParameters(command);

                if (!ExecutePythonLine(-1, param))
                    ExecError($"Cannot execute Python line {param}");

                return true;
            }

            // Variable Management Functions
            // clear_variables
            if (command == "clear_variables()")
            {
                ClearNonSystemVariables();
                return true;
            }

            // import_variables
            if (command.StartsWith("import_variables("))
            {
                string file = ExtractParameters(command);
                if (file.Length > 1)
                {
                    if (!le_import_variables(file))
                        ExecError($"File import error");
                }
                else
                    ExecError("Invalid import_variables command");

                return true;
            }

            // system_variable
            if (command.StartsWith("system_variable("))
            {
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unrecognized system_variable command");
                    return true;
                }
                string variableName = parameters[0];
                string value = ReadVariable(variableName, null);
                if (value == null)
                {
                    ExecError("Unrecognized variable in system_variable command");
                    return true;
                }
                SetSystemVariable(variableName, parameters[1] == "True");
                return true;
            }

            // le_random
            if (command.StartsWith("le_random("))
            {
                double[] randomParams;
                if (ExtractDoubleParameters(command, 3, out randomParams))
                {
                    int n = (int)randomParams[0];
                    double low = randomParams[1];
                    double high = randomParams[2];
                    for (int i = 0; i < n; i++)
                    {
                        double r = low + random.NextDouble() * (high - low);
                        WriteVariable($"rnd{i + 1}", $"{r:0.000000}");
                    }
                }
                return true;
            }

            // Console Control
            // le_print
            if (command.StartsWith("le_print("))
            {
                string s = ExtractParameters(command, -1, false);
                log.Info("LPR:" + s);
                Console.WriteLine(s);
                return true;
            }

            // le_show_console
            if (command.StartsWith("le_show_console("))
            {
                string param = ExtractParameters(command, -1, false);
                if (param == "False" || param == "false")
                    consoleForm.Hide();
                else
                    consoleForm.Show();
                return true;
            }

            // le_clear_console
            if (command == ("le_clear_console()"))
            {
                consoleForm.Clear();
                return true;
            }

            // Logging
            // le_log_info
            if (command.StartsWith("le_log_info("))
            {
                log.Info(ExtractParameters(command, -1, false));
                return true;
            }

            // le_log_error
            if (command.StartsWith("le_log_error("))
            {
                log.Error(ExtractParameters(command, -1, false));
                return true;
            }

            // Flow Control
            // pause
            if (command == "pause()")
            {
                PerformPause();
                return true;
            }

            // pauseif
            if (command.StartsWith("pauseif("))
            {
                string arg = ExtractParameters(command);
                if (arg.Length < 1)
                    ExecError("Expected pauseif(True|False)");
                else
                    PerformPauseIf(String.Equals(arg, "true", StringComparison.OrdinalIgnoreCase));
                return true;
            }

            // stop
            if (command == "stop()")
            {
                PerformStop();
                return true;
            }

            // stopif
            if (command.StartsWith("stopif("))
            {
                string arg = ExtractParameters(command);
                if (arg.Length < 1)
                    ExecError("Expected stopif(True|False)");
                else
                    PerformStopIf(String.Equals(arg, "true", StringComparison.OrdinalIgnoreCase));
                return true;
            }

            // prompt
            if (command.StartsWith("prompt("))
            {
                // This just displays the dialog. ExecTmr will wait for it to close
                PerformPrompt(ExtractParameters(command, -1, false));
                return true;
            }

            // promptif
            if (command.StartsWith("promptif("))
            {
                string[] args = ExtractParameters(command, 2, false).Split(',');
                if (args.Length < 2)
                    ExecError("Expected promptif(True|False, message)");
                else
                    PerformPromptIf(String.Equals(args[0], "true", StringComparison.OrdinalIgnoreCase), args[1]);
                return true;
            }

            // jump
            if (command.StartsWith("jump("))
            {
                string labelName = ExtractParameters(command);

                PerformJump(labelName);
                return true;
            }

            // jumpif
            if (command.StartsWith("jumpif("))
            {
                string[] parameters = ExtractParameters(command).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Expected jumpif(True|False,label)");
                    return true;
                }
                else
                {
                    if (parameters[0] == "True")
                        PerformJump(parameters[1]);
                }
                return true;
            }

            // jump_gt_zero
            if (command.StartsWith("jump_gt_zero("))
            {
                string[] parameters = ExtractParameters(command).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Expected jump_gt_zero(variable,label)");
                    return true;
                }
                else
                {
                    string variableName = parameters[0];
                    string labelName = parameters[1];

                    if (!labels.TryGetValue(labelName, out int jumpLine))
                    {
                        ExecError($"Expected jump_gt_zero(variable,label) Label not found: {labelName}");
                        return true;
                    }
                    else
                    {
                        string value = ReadVariable(variableName);
                        if (value == null)
                        {
                            ExecError($"Expected jump_gt_zero(variable,label)\nVariable not found: {variableName}");
                            return true;
                        }
                        else
                        {
                            try
                            {
                                double val = Convert.ToDouble(value);
                                if (val > 0.0)
                                {
                                    log.Info("EXECL {0:0000}: [JUMP_GT_ZERO] Line {1} --> {2:0000}", lineNumber, origLine, jumpLine);
                                    SetCurrentLine(jumpLine);
                                }
                                return true;
                            }
                            catch
                            {
                                ExecError($"Could not convert jump_gt_zero variable\n{variableName} = {value}");
                                return true;
                            }
                        }

                    }
                }
            }

            // call
            if (command.StartsWith("call("))
            {
                string labelName = ExtractParameters(command);
                PerformCall(labelName);
                return true;
            }

            // callif
            if (command.StartsWith("callif("))
            {
                string[] parameters = ExtractParameters(command).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Expected callif(True|False,label)");
                    return true;
                }
                else
                {
                    if (parameters[0] == "True")
                        PerformCall(parameters[1]);
                }
                return true;
            }

            // ret
            if (command == "ret" || command == "ret()")
            {
                PerformReturn();
                return true;
            }

            // sleep
            if (command.StartsWith("sleep("))
            {
                double sleepSeconds;
                if (ExtractDoubleParameter(command, out sleepSeconds))
                    le_sleep(sleepSeconds);
                return true;
            }

            // assertEquals
            if (command.StartsWith("assertEqual("))
            {
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unknown assert syntax");
                    return true;
                }
                string value = ReadVariable(parameters[0], null);
                if (value == null)
                {
                    ExecError("Unknown variable in assert function");
                    return true;
                }
                if (value != parameters[1])
                {
                    ExecError($"assertEquals FAILED\n{value} != {parameters[1]}");
                    return true;
                }
                return true;
            }

            // assertNotEquals
            if (command.StartsWith("assertNotEqual("))
            {
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unknown assert syntax");
                    return true;
                }

                // Variable undefined is OK here... that should pass!
                string value = ReadVariable(parameters[0], null);
                if (value == parameters[1])
                {
                    ExecError($"assertNotEquals FAILED\n{value} == {parameters[1]}");
                    return true;
                }
                return true;
            }

            // assertTrue
            if (command.StartsWith("assertTrue("))
            {
                string boolean = ExtractParameters(command);
                if (!String.Equals(boolean, "true", StringComparison.OrdinalIgnoreCase))
                {
                    ExecError($"assertTrue was NOT TRUE\n{boolean}");
                    return true;
                }
                return true;
            }

            // assertFalse
            if (command.StartsWith("assertFalse("))
            {
                string boolean = ExtractParameters(command);
                if (String.Equals(boolean, "true", StringComparison.OrdinalIgnoreCase))
                {
                    ExecError($"assertFalse was TRUE\n{boolean}");
                    return true;
                }
                return true;
            }

            // Device Management
            // le_connect
            if (command.StartsWith("le_connect("))
            {
                string deviceName = ExtractParameters(command);
                if (deviceName.Length < 1)
                {
                    ExecError("No device name specified");
                    return true;
                }

                le_connect(deviceName);
                return true;
            }

            // le_disconnect
            if (command.StartsWith("le_disconnect("))
            {
                string deviceName = ExtractParameters(command);
                if (deviceName.Length < 1)
                {
                    ExecError("No device name specified");
                    return true;
                }

                le_disconnect(deviceName);
                return true;
            }

            // le_connect_all
            if (command == "le_connect_all()")
            {
                le_connect_all();
                return true;
            }

            // le_disconnect_all
            if (command == "le_disconnect_all()")
            {
                le_disconnect_all();
                return true;
            }

            // le_send
            if (command.StartsWith("le_send("))
            {
                string str = ExtractParameters(command, 2, false);

                if (str == "")
                    ExecError($"le_send({command}) Bad syntax");
                else
                {
                    string[] values = str.Split(',');
                    string devName = values[0];
                    string message = values[1];
                    if (0 != le_send(devName, message))
                        ExecError($"le_send({devName}, {message}) Failed");
                }

                return true;
            }

            // le_ask
            if (command.StartsWith("le_ask("))
            {
                string response = "Null";
                string str = ExtractParameters(command, 3, false);
                if (str == "")
                    ExecError($"le_ask({command}) Bad syntax");
                else
                {
                    string[] values = str.Split(',');

                    string devName = values[0];
                    string message = values[1];
                    int timeoutMs = Convert.ToInt32(values[2]);
                    response = le_ask(devName, message, timeoutMs);
                }

                WriteVariable("le_ask_response", response);

                return true;
            }

            // Input File Support
            // infile_open
            if (command.StartsWith("infile_open("))
            {
                string filename = ExtractParameters(command);
                if (filename.Length < 1)
                {
                    ExecError("No file name specified");
                    return true;
                }

                string full_filename = System.IO.Path.Combine(LEonardRoot, DataFolder, filename);
                if (fileManager == null)
                    fileManager = new FileManager(this);

                if (fileManager.InputOpen(full_filename))
                    log.Info($"Input file {full_filename} open");
                else
                    ExecError($"Could not open {full_filename}");
                return true;
            }

            // infile_close
            if (command.StartsWith("infile_close("))
            {
                // Currently ignored
                string parameters = ExtractParameters(command);
                fileManager?.InputClose();
                return true;
            }

            // infile_scale
            if (command.StartsWith("infile_scale("))
            {
                string parameters = ExtractParameters(command);
                if (parameters.Length == 0)
                {
                    ExecError($"No parameters provided for infile_scale command");
                    return true;
                }
                string[] paramList = parameters.Split(',');
                if (paramList.Length % 2 != 0)
                {
                    ExecError($"infile_scale(...) requires parameters in pairs");
                    return true;
                }
                for (int i = 0; i < paramList.Length; i += 2)
                {
                    try
                    {
                        int scaleIndex = Convert.ToInt32(paramList[i]);
                        double scale = Convert.ToDouble(paramList[i + 1]);
                        fileManager?.AddScale(scaleIndex, scale);
                    }
                    catch
                    {
                        ExecError($"infile_scale(...) bad parameter pair: {paramList[i]},{paramList[i + 1]}");
                        return true;
                    }
                }
                return true;
            }

            // infile_readline
            if (command.StartsWith("infile_readline("))
            {
                // Currently ignored
                string parameters = ExtractParameters(command);

                if (fileManager == null || !fileManager.IsInputOpen())
                {
                    ExecError($"Input file not open");
                    return true;
                }

                fileManager.InputReadLine();
                return true;
            }

            // write_cyline_data
            if (command.StartsWith("write_cyline_data("))
            {
                string filename = ExtractParameters(command);
                if (filename.Length < 1)
                {
                    ExecError("No file name specified");
                    return true;
                }

                string full_filename = System.IO.Path.Combine(LEonardRoot, DataFolder, filename);
                full_filename = System.IO.Path.ChangeExtension(full_filename, ".csv");

                try
                {
                    StreamWriter writer = new StreamWriter(full_filename);
                    {
                        writer.WriteLine("filename,{0}", full_filename);
                        writer.WriteLine("date,{0}", DateTime.Now.ToString());
                        writer.WriteLine("robot_geometry,{0}", ReadVariable("robot_geometry", "???"));
                        writer.WriteLine("cyline_calibration_counts,{0}", ReadVariable("cyline_calibration_counts", "???").Trim(new char[] { '[', ']' }));
                        writer.WriteLine("cyline_correction,{0}", ReadVariable("cyline_correction", "???").Trim(new char[] { '[', ']' }));
                        writer.WriteLine("cyline_correction_size,{0}", ReadVariable("cyline_correction_size", "???"));
                        writer.WriteLine("cyline_coeff_table_size,{0}", ReadVariable("cyline_coeff_table_size", "???"));
                        writer.WriteLine("cyline_coeff_table_index,{0}", ReadVariable("cyline_coeff_table_index", "???"));
                        writer.WriteLine("cyline_deadband_time,{0}", ReadVariable("cyline_deadband_time", "???"));
                        writer.WriteLine("cyline_degree_slice,{0}", ReadVariable("cyline_degree_slice", "???"));
                        writer.WriteLine("cyline_expected_time,{0}", ReadVariable("cyline_expected_time", "???"));
                        writer.WriteLine("cyline_latest_e,{0}", ReadVariable("cyline_latest_e", "???").Trim(new char[] { '[', ']' }));
                        writer.WriteLine("cyline_max_e,{0}", ReadVariable("cyline_max_e", "???"));
                        writer.WriteLine("cyline_max_e_angle,{0}", ReadVariable("cyline_max_e_angle", "???"));
                        writer.WriteLine("cyline_min_e,{0}", ReadVariable("cyline_min_e", "???"));
                        writer.WriteLine("cyline_min_e_angle,{0}", ReadVariable("cyline_min_e_angle", "???"));
                        writer.WriteLine("cyline_training_weight,{0}", ReadVariable("cyline_training_weight", "???"));
                        writer.WriteLine("grind_linear_vel_mmps,{0}", ReadVariable("grind_linear_vel_mmps", "???"));
                        writer.WriteLine("grind_linear_accel_mmpss,{0}", ReadVariable("grind_linear_accel_mmpss", "???"));
                        writer.WriteLine("grind_linear_blend_radius_mm,{0}", ReadVariable("grind_linear_blend_radius_mm", "???"));
                        writer.WriteLine("grind_angular_vel_rps,{0}", ReadVariable("grind_angular_vel_rps", "???"));
                        writer.WriteLine("grind_angular_accel_rpss,{0}", ReadVariable("grind_angular_accel_rpss", "???"));
                        writer.WriteLine("grind_angular_blend_radius_rad,{0}", ReadVariable("grind_angular_blend_radius_rad", "???"));

                        writer.Close();
                    }
                }
                catch
                {
                    ExecError($"write_cyline_data(...) cannot write to\n{full_filename}");
                }

                return true;
            }

            // UR Functions
            // ur_dashboard
            if (command.StartsWith("ur_dashboard("))
            {
                string message = ExtractParameters(command, 2, false);
                if (message.Length < 1)
                {
                    ExecError("Expected ur_dashboard(message, timeout_ms)");
                    return true;
                }
                string[] p = message.Split(',');
                int timeout_ms = 200;
                try
                {
                    timeout_ms = Convert.ToInt32(p[1]);
                }
                catch { }
                string response = ur_dashboard(p[0], timeout_ms);
                WriteVariable("ur_dashboard_response", response); ;
                return true;
            }

            // select_tool  (Assumes operator has already installed it somehow!!)
            if (command.StartsWith("select_tool("))
            {
                string toolName = ExtractParameters(command, 1);
                select_tool(toolName);

                return true;
            }

            // set_part_geometry
            if (command.StartsWith("set_part_geometry("))
            {
                string parameters = ExtractParameters(command, 2);
                if (parameters.Length == 0)
                {
                    ExecError($"set_part_geometry: illegal parameters {parameters}");
                    return true;
                }
                string[] paramList = parameters.Split(',');
                if (paramList.Length != 2)
                {
                    ExecError($"set_part_geometry: illegal parameters {parameters}");
                    return true;
                }

                string geometryName = paramList[0];
                try
                {
                    double diam_mm = Convert.ToDouble(paramList[1]);
                    set_part_geometry(geometryName, diam_mm);
                }
                catch
                {
                    ExecError($"set_part_geometry: illegal parameters {parameters}");
                }
                return true;
            }

            // save_position
            if (command.StartsWith("save_position("))
            {
                string positionName = ExtractParameters(command);
                if (positionName.Length < 1)
                {
                    ExecError("No position name specified");
                    return true;
                }

                save_position(positionName);
                return true;
            }

            // system_position
            if (command.StartsWith("system_position("))
            {
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unrecognized system_position command");
                    return true;
                }
                string positionName = parameters[0];

                system_position(positionName, parameters[1] == "True");
                return true;
            }

            // clear_positions
            if (command == "clear_positions()")
            {
                ClearNonSystemPositions();
                return true;
            }

            // move_joint
            if (command.StartsWith("move_joint("))
            {
                string positionName = ExtractParameters(command);

                move_joint(positionName);
                return true;
            }

            // move_linear
            if (command.StartsWith("move_linear("))
            {
                string positionName = ExtractParameters(command);

                move_linear(positionName);
                return true;
            }

            // move_tool_home
            if (command.StartsWith("move_tool_home()"))
            {
                move_tool_home();
                return true;
            }

            // move_tool_mount
            if (command.StartsWith("move_tool_mount()"))
            {
                move_tool_mount();
                return true;
            }

            // Gocator Functions
            // gocator_send
            if (command.StartsWith("gocator_send("))
            {
                string message = ExtractParameters(command, -1, false);

                gocator_send(message);
                return true;
            }

            // gocator_trigger
            if (command.StartsWith("gocator_trigger("))
            {
                int preDelay_ms;
                if (ExtractIntParameter(command, out preDelay_ms))
                    gocator_trigger(preDelay_ms);
                else
                    ExecError($"gocator_trigger: {command}: Expected (preDelay_ms)");

                return true;
            }

            // gocator_adjust
            if (command.StartsWith("gocator_adjust_("))
            {
                int version;
                if (ExtractIntParameter(command, out version))
                    gocator_adjust(version);
                else
                    ExecError($"gocator_adjust: {command}: Expected (int version 1-4)");

                return true;
            }

            // gocator_write_data
            if (command.StartsWith("gocator_write_data("))
            {
                string filename;
                string tagName;

                // Can put in (filename,tagName) or just (filename), in which case tagName = ReadVariable("gocator_ID", "Null")
                string[] parameters = ExtractParameters(command).Split(',');
                if (parameters.Length == 2)
                {
                    filename = parameters[0];
                    tagName = parameters[1];
                }
                else if (parameters.Length == 1)
                {
                    filename = parameters[0];
                    tagName = ReadVariable("gocator_ID", "Null");
                }
                else
                {
                    ExecError($"gocator_write_data: {command} No file name specified");
                    return true;
                }

                gocator_write_data(filename, tagName);

                return true;
            }

            if (PerformRobotCommand(command))
                return true;

            // Matched nothing above... could be an assignment operator =, -=, +=, ++, --
            if (UpdateVariable(command))
            {
                return true;
            }

            ExecError("Cannot interpret line");
            return true;
        }
        public bool ExecuteLEonardMessage(string prefix, string message, LeDeviceInterface dev)
        {
            log.Trace($"{prefix}: {message} {dev}");

            // TODO This gets broken if the user tries to do anything else with '#' TODO isn't this supposed to follow <SEP>??
            string[] statements = message.Split('#');
            foreach (string statement in statements)
                if (!ExecuteLEonardStatement(prefix, statement, dev))
                {
                    log.Error($"{prefix} Illegal LEonardStatement({prefix}, {statement})");
                    return false;
                }
            return true;
        }
        public bool ExecuteLEonardStatement(string prefix, string statement, LeDeviceInterface dev = null)
        {
            // {script.....}
            if (statement.EndsWith(".js") && statement.Length > 3)
            {
                ExecuteJavaFile(statement);
                return true;
            }
            if (statement.EndsWith(".py") && statement.Length > 3)
            {
                ExecutePythonFile(statement);
                return true;
            }
            if (statement.StartsWith("LE:") && statement.Length > 5)
            {
                ExecuteLEScriptLine(-1, statement.Substring(3), dev);
                return true;
            }
            if (statement.StartsWith("JE:") && statement.Length > 5)
            {
                ExecuteJavaScript(statement.Substring(3), dev);
                return true;
            }
            if (statement.StartsWith("PE:") && statement.Length > 5)
            {
                ExecutePythonScript(statement.Substring(3), dev);
                return true;
            }

            // SET varName value
            if (statement.StartsWith("SET "))
            {
                string[] s = statement.Split(' ');
                if (s.Length == 3)
                    WriteVariable(s[1], s[2]);
                else
                    log.Error($"{prefix} Illegal SET statement: {statement}");
                return true;
            }

            // GET varName
            if (statement.StartsWith("GET "))
            {
                if (statement.Length > 4)
                {
                    string varName = statement.Substring(4).Trim();
                    string value = ReadVariable(varName);
                    string response = $"{varName}={value}";
                    if (dev != null)
                        if (dev.IsConnected())
                            dev.Send(response);
                }
                else
                    log.Error($"{prefix} Illegal GET statement: {statement}");
                return true;
            }

            // TODO this is quite naive and restrictive
            // varName=value
            if (statement.Contains("="))
            {
                UpdateVariable(statement);
                return true;
            }

            //log.Error($"{prefix} Illegal LEonardStatement statement: {statement}");
            return false;
        }
        #endregion ===== LESCRIPT DECODE AND EXECUTE       ==============================================================================================================================

        #region ===== SHARED SUPPORT FOR JAVA, PYTHON, LESCRIPT   ====================================================================================================================
        void SetLanguage(LEonardLanguages language)
        {
            LEonardLanguage = language;
            WriteVariable("sysLanguage", LEonardLanguage.ToString(), true, true); // This is a system variable and gets pushed to Java and Python
        }
        public void using_lescript()
        {
            SetLanguage(LEonardLanguages.LEScript);
        }
        public void using_java()
        {
            SetLanguage(LEonardLanguages.Java);
        }
        public void using_python()
        {
            SetLanguage(LEonardLanguages.Python);
        }
        public void le_show_console(bool f)
        {
            if (f)
                consoleForm.Show();
            else
                consoleForm.Hide();
        }
        public void le_clear_console()
        {
            consoleForm.Clear();
        }

        private void PerformPause()
        {
            RobotSendHalt();
            SetState(RunState.PAUSED);
        }
        private void PerformPauseIf(bool f)
        {
            if (f) PerformPause();
        }

        public void PerformStop()
        {
            UnboldSequence();
            SetSequenceState(sequenceStateAtRun);
            SetState(RunState.READY);
        }
        public void PerformStopIf(bool f)
        {
            if (f) PerformStop();
        }

        /// Put up MessageForm dialog. Execution will pause until the operator provides a response.
        private void PerformPrompt(string message, bool closeOnReady = false, bool isMotionWait = false)
        {
            log.Info($"le_prompt(message={message.Replace('\n', ' ')}, closeOnReady={closeOnReady}, isMotionWait={isMotionWait}");

            waitingForOperatorMessageForm = new MessageDialog(this)
            {
                Title = "LEonard Prompt",
                Label = message,
                OkText = isMotionWait ? "STOP MOTION" : "&Continue Execution",
                CancelText = isMotionWait ? "STOP MOTION" : "&Abort",
                IsMotionWait = isMotionWait,
            };
            closeOperatorFormOnIndex = closeOnReady;
            waitingForOperatorMessageForm.ShowDialog();
        }
        private void PerformPromptIf(bool f, string message, bool closeOnReady = false, bool isMotionWait = false)
        {
            if (f) PerformPrompt(message, closeOnReady, isMotionWait);
        }
        private bool assertTrue(bool f)
        {
            if (!f)
                ExecError("assertTrue was FALSE");
            return f;
        }
        private bool assertFalse(bool f)
        {
            if (f)
                ExecError("assertFalse was TRUE");
            return f;
        }

        private int le_connect(string deviceName)
        {
            DataRow row = devices.AsEnumerable().FirstOrDefault(r => (string)r["Name"] == deviceName);
            if (row == null)
            {
                ExecError($"le_connect: No device named {deviceName} found");
                return 10;
            }

            return DeviceConnect(row);
        }

        private int le_disconnect(string deviceName)
        {
            DataRow row = devices.AsEnumerable().FirstOrDefault(r => (string)r["Name"] == deviceName);
            if (row == null)
            {
                ExecError($"No device named {deviceName} was found.");
                return 10;
            }

            DeviceDisconnect(row);
            return 0;
        }
        private int le_connect_all()
        {
            DeviceConnectAllBtn_Click(null, null);
            return 0;
        }
        private int le_disconnect_all()
        {
            DeviceDisconnectAllBtn_Click(null, null);
            return 0;
        }

        public int le_send(string devName, string msg)
        {
            if (devName == "me")
            {
                if (LeDeviceBase.currentDevice == null)
                {
                    ExecError($"le_send(me,...): Could not determine who 'me' is");
                    return 10;
                }
                else
                    return LeDeviceBase.currentDevice.Send(msg);
            }
            else
            {
                DataRow row = FindName(devName, devices);
                if (row == null)
                {
                    ExecError($"le_send: Could not find device {devName}");
                    return 11;
                }

                if (interfaces[(int)row["ID"]] == null)
                {
                    ExecError($"le_send: {devName} exists but is not instantiated for connection");
                    return 12;
                }
                if (!interfaces[(int)row["ID"]].IsConnected())
                {
                    ExecError($"le_send: {devName} exists but is not connected");
                    return 13;
                }

                return interfaces[(int)row["ID"]].Send(msg);
            }
        }
        public string le_ask(string devName, string msg, int timeoutMs = 100)
        {
            DataRow row = FindName(devName, devices);
            if (row == null)
            {
                ExecError($"le_ask: Could not find device {devName}");
                return null;
            }

            if (interfaces[(int)row["ID"]] == null)
            {
                ExecError($"le_ask: {devName} exists but is not instantiated for connection");
                return null;
            }

            if (!interfaces[(int)row["ID"]].IsConnected())
            {
                ExecError($"le_ask: {devName} exists but is not connected");
                return null;
            }

            return interfaces[(int)row["ID"]].Ask(msg, timeoutMs);
        }

        bool PerformJump(string labelName)
        {
            if (labels.TryGetValue(labelName, out int jumpLine))
            {
                log.Info($"EXEC {lineCurrentlyExecuting:0000}: [JUMP] --> {jumpLine:0000}");
                SetCurrentLine(jumpLine);
            }
            else
                ExecError($"Unknown label \"{labelName}\"specified in jump");

            return true;
        }
        bool PerformJumpIf(bool condition, string labelName)
        {
            if (condition)
                return PerformJump(labelName);
            else
                return true;
        }
        bool PerformCall(string labelName)
        {
            if (labels.TryGetValue(labelName, out int callLine))
            {
                log.Info($"EXEC {lineCurrentlyExecuting:0000}: [CALL] --> {callLine:0000}");
                PushCurrentLine();

                SetCurrentLine(callLine);
            }
            else
                ExecError($"Unknown label \"{labelName}\"specified in jump");

            return true;
        }
        bool PerformCallIf(bool condition, string labelName)
        {
            if (condition)
                return PerformCall(labelName);
            else
                return true;
        }
        bool PerformReturn()
        {
            return PopCurrentLine();
        }

        bool le_sleep(double sleepSeconds)
        {
            log.Info($"EXEC {lineCurrentlyExecuting:0000}: le_sleep({sleepSeconds:0.000})");
            sleepMs = sleepSeconds * 1000.0;
            sleepTimer = new Stopwatch();
            sleepTimer.Start();

            double sec = Math.Truncate(sleepSeconds);
            double msec = (sleepSeconds - sec) * 1000.0;

            TimeSpan ts = new TimeSpan(0, 0, 0, (int)sec, (int)msec);
            StepTimeEstimateLbl.Text = TimeSpanFormat(ts);
            stepEndTimeEstimate = DateTime.Now.AddMilliseconds(sleepMs);
            return true;
        }

        // UR
        private int save_position(string positionName)
        {
            copyPositionAtWrite = positionName;

            PerformRobotCommand("get_actual_both()");
            return 0;
        }
        private int system_position(string positionName, bool f)
        {
            string value = ReadPositionJoint(positionName);
            if (value == null)
            {
                ExecError("Unrecognized position in system_position command");
                return 1;
            }
            SetSystemPosition(positionName, f);
            return 0;
        }
        private int move_joint(string positionName)
        {
            if (GotoPositionJoint(positionName))
            {
                PerformPrompt($"Wait for move_joint({positionName}) complete", true, true);
                return 0;
            }
            else
            {
                ExecError($"move_joint to {positionName} failed");
                return 1;
            }
        }
        private int move_linear(string positionName)
        {
            if (GotoPositionPose(positionName))
            {
                PerformPrompt($"Wait for move_linear({positionName}) complete", true, true);
                return 0;
            }
            else
            {
                ExecError($"move_linear to {positionName} failed");
                return 1;
            }
        }

        private int move_tool_home()
        {
            MoveToolHomeBtn_Click(null, null);
            return 0;
        }
        private int move_tool_mount()
        {
            MoveToolMountBtn_Click(null, null);
            return 0;
        }

        private int select_tool(string toolName)
        {
            DataRow row = FindName(toolName, tools);
            if (row == null)
            {
                ExecError($"select_tool: cannot find tool {toolName}");
                return 1;
            }
            // Kind of like a subroutine that calls all the pieces needed to effect a tool change
            // Just in case... make sure we disable current tool
            PerformRobotCommand($"set_tcp({row["x_m"]},{row["y_m"]},{row["z_m"]},{row["rx_rad"]},{row["ry_rad"]},{row["rz_rad"]})");
            PerformRobotCommand($"set_payload({row["mass_kg"]},{row["cogx_m"]},{row["cogy_m"]},{row["cogz_m"]})");
            PerformRobotCommand("tool_off()");
            PerformRobotCommand("coolant_off()");
            PerformRobotCommand($"set_tool_on_outputs({row["ToolOnOuts"]})");
            PerformRobotCommand($"set_tool_off_outputs({row["ToolOffOuts"]})");
            PerformRobotCommand($"set_coolant_on_outputs({row["CoolantOnOuts"]})");
            PerformRobotCommand($"set_coolant_off_outputs({row["CoolantOffOuts"]})");
            PerformRobotCommand("tool_off()");
            PerformRobotCommand("coolant_off()");
            /*
            // The original technique... more circuitous since it was recursive!
            ExecuteLEScriptLine(-1, String.Format("set_tcp({0},{1},{2},{3},{4},{5})", row["x_m"], row["y_m"], row["z_m"], row["rx_rad"], row["ry_rad"], row["rz_rad"]));
            ExecuteLEScriptLine(-1, String.Format("set_payload({0},{1},{2},{3})", row["mass_kg"], row["cogx_m"], row["cogy_m"], row["cogz_m"]));

            ExecuteLEScriptLine(-1, String.Format("tool_off()"));
            ExecuteLEScriptLine(-1, String.Format("coolant_off()"));
            ExecuteLEScriptLine(-1, String.Format("set_tool_on_outputs({0})", row["ToolOnOuts"]));
            ExecuteLEScriptLine(-1, String.Format("set_tool_off_outputs({0})", row["ToolOffOuts"]));
            ExecuteLEScriptLine(-1, String.Format("set_coolant_on_outputs({0})", row["CoolantOnOuts"]));
            ExecuteLEScriptLine(-1, String.Format("set_coolant_off_outputs({0})", row["CoolantOffOuts"]));
            ExecuteLEScriptLine(-1, String.Format("tool_off()"));
            ExecuteLEScriptLine(-1, String.Format("coolant_off()"));
            */
            WriteVariable("robot_tool", row["Name"].ToString());

            // Set Move buttons to go to tool change and home locations
            MoveToolMountBtn.Text = row["MountPosition"].ToString();
            MoveToolHomeBtn.Text = row["HomePosition"].ToString();

            // Update the UI selector but don't trigger another set of commands to the robot!
            mountedToolBoxActionDisabled = true;
            MountedToolBox.Text = (string)row["Name"];
            mountedToolBoxActionDisabled = false;

            // Highlight the corresponding row in the DataGridView
            SelectDataGridViewRow(ToolsGrd, toolName);

            // Give the UI some time to process all of those command returns!!!
            Thread.Sleep(1000);
            return 0;
        }

        int set_part_geometry(string geometryName, double diam_mm)
        {
            string diamStr = $"{diam_mm:0.0}";
            switch (geometryName)
            {
                case "FLAT":
                    DiameterLbl.Text = "0.0";
                    DiameterLbl.Visible = false;
                    DiameterDimLbl.Visible = false;
                    break;
                case "CYLINDER":
                    if (diam_mm < 75 || diam_mm > 3000)
                    {
                        ExecError($"Cylinder diameter must be between 75 and 3000: {diam_mm}");
                        return 1;
                    }
                    DiameterLbl.Text = diamStr;
                    DiameterLbl.Visible = true;
                    DiameterDimLbl.Visible = true;
                    diameterDefaults[1] = diamStr;
                    break;
                case "SPHERE":
                    if (diam_mm < 75 || diam_mm > 3000)
                    {
                        ExecError($"Sphere diameter must be between 75 and 3000: {diam_mm}");
                        return 2;
                    }
                    DiameterLbl.Text = diamStr;
                    DiameterLbl.Visible = true;
                    DiameterDimLbl.Visible = true;
                    diameterDefaults[2] = diamStr;
                    break;
                default:
                    ExecError($"set_part_geometry: First argument must be FLAT, CYLINDER, or SPHERE: {geometryName}");
                    return 3;
            }

            // Update the UI control but don't have it trigger commands to robot, which is done explicitly below
            partGeometryBoxDisabled = true;
            PartGeometryBox.Text = geometryName;
            partGeometryBoxDisabled = false;

            UpdateGeometryToRobot();
            return 0;
        }
        #endregion ===== SHARED SUPPORT FOR JAVA, PYTHON, LESCRIPT   ====================================================================================================================

        #region ===== JAVA SUPPORT CODE                 ==============================================================================================================================
        private void InitializeJavaEngine()
        {
            javaEngine = new Engine()
            .SetValue("using_lescript", new Action(() => using_lescript()))
            .SetValue("using_java", new Action(() => using_java()))
            .SetValue("using_python", new Action(() => using_python()))
            .SetValue("exec_lescript", new Func<string, bool>((string filename) => ExecuteLEScriptFile(filename)))
            .SetValue("exec_java", new Func<string, bool>((string filename) => ExecuteJavaFile(filename)))
            .SetValue("exec_python", new Func<string, bool>((string filename) => ExecutePythonFile(filename)))
            .SetValue("execline_lescript", new Action<string>((string line) => ExecuteLEScriptLine(-1, line)))
            .SetValue("execline_java", new Action<string>((string line) => ExecuteJavaLine(-1, line)))
            .SetValue("execline_python", new Action<string>((string line) => ExecutePythonLine(-1, line)))

            .SetValue("le_read_var", new Func<string, string>((string name) => ReadVariable(name)))
            .SetValue("le_write_var", new Func<string, string, bool>((string name, string value) => WriteVariable(name, value, false, false))) // Last param false so we don't write it back here as a string!
            .SetValue("le_write_sysvar", new Func<string, string, bool>((string name, string value) => WriteVariable(name, value, true, false))) // Last param false so we don't write it back here as a string!

            .SetValue("le_print", new Action<string>((string msg) => le_print_java(msg)))
            .SetValue("le_show_console", new Action<bool>((bool f) => le_show_console(f)))
            .SetValue("le_clear_console", new Action(() => le_clear_console()))

            .SetValue("le_log_info", new Action<string>((string msg) => log.Info(msg)))
            .SetValue("le_log_error", new Action<string>(s => log.Error(s)))

            .SetValue("pause", new Action(() => PerformPause()))
            .SetValue("pauseif", new Action<bool>((bool f) => PerformPauseIf(f)))
            .SetValue("stop", new Action(() => PerformStop()))
            .SetValue("stopif", new Action<bool>((bool f) => PerformStopIf(f)))
            .SetValue("prompt", new Action<string>((string prompt) => PerformPrompt(prompt)))
            .SetValue("promptif", new Action<bool, string>((bool f, string prompt) => PerformPromptIf(f, prompt)))
            .SetValue("jump", new Action<string>((string labelName) => PerformJump(labelName)))
            .SetValue("jumpif", new Action<bool, string>((bool condition, string labelName) => PerformJumpIf(condition, labelName)))
            .SetValue("call", new Action<string>((string labelName) => PerformCall(labelName)))
            .SetValue("callif", new Action<bool, string>((bool condition, string labelName) => PerformCallIf(condition, labelName)))
            .SetValue("ret", new Action(() => PerformReturn()))
            .SetValue("sleep", new Func<double, bool>((double timeout_s) => le_sleep(timeout_s)))
            .SetValue("assertTrue", new Func<bool, bool>((bool f) => assertTrue(f)))
            .SetValue("assertFalse", new Func<bool, bool>((bool f) => assertFalse(f)))

            .SetValue("le_connect", new Func<string, int>((string devName) => le_connect(devName)))
            .SetValue("le_disconnect", new Func<string, int>((string devName) => le_disconnect(devName)))
            .SetValue("le_connect_all", new Func<int>(() => le_connect_all()))
            .SetValue("le_disconnect_all", new Func<int>(() => le_disconnect_all()))
            .SetValue("le_send", new Func<string, string, int>((string devName, string msg) => le_send(devName, msg)))
            .SetValue("le_ask", new Func<string, string, int, string>((string devName, string msg, int timeoutMs) => le_ask(devName, msg, timeoutMs)))

            // Universal Robots
            // TODO Should these look at license?
            // Dashboard Communication
            .SetValue("ur_dashboard", new Func<string, int, string>((string msg, int timeout) => ur_dashboard(msg, timeout)))

            // Core Motion
            .SetValue("movej",
                new Func<double, double, double, double, double, double, bool>(
                    (double j1, double j2, double j3, double j4, double j5, double j6) => PerformRobotCommand($"movej({j1:0.000000},{j2:0.000000},{j3:0.000000},{j4:0.000000},{j5:0.000000},{j6:0.000000})")))
            .SetValue("get_actual_joint_positions", new Func<bool>(() => PerformRobotCommand("get_actual_joint_positions()")))
            .SetValue("get_target_joint_positions", new Func<bool>(() => PerformRobotCommand("get_target_joint_positions()")))
            .SetValue("movel",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")))
            .SetValue("get_actual_tcp_pose", new Func<bool>(() => PerformRobotCommand("get_actual_tcp_pose()")))
            .SetValue("get_target_tcp_pose", new Func<bool>(() => PerformRobotCommand("get_target_tcp_pose()")))
            .SetValue("get_actual_both", new Func<bool>(() => PerformRobotCommand("get_actual_both()")))
            .SetValue("get_target_both", new Func<bool>(() => PerformRobotCommand("get_target_both()")))
            .SetValue("set_tcp",
                new Func<double, double, double, double, double, double, bool>(
                    (double x_m, double y_m, double z_m, double rx_rad, double ry_rad, double rz_rad) => PerformRobotCommand($"set_tcp({x_m:0.000000},{y_m:0.000000},{z_m:0.000000},{rx_rad:0.000000},{ry_rad:0.000000},{rz_rad:0.000000})")))
            .SetValue("get_tcp_offset", new Func<bool>(() => PerformRobotCommand("get_tcp_offset()")))
            .SetValue("set_payload",
                new Func<double, double, double, double, bool>(
                    (double mass_kg, double cog_x_m, double cog_y_m, double cog_z_m) => PerformRobotCommand($"set_payload({mass_kg:0.000000},{cog_x_m:0.000000},{cog_y_m:0.000000},{cog_z_m:0.000000})")))
            .SetValue("free_drive",
                new Func<bool, int, bool, bool, bool, bool, bool, bool, bool>(
                    (bool enable, int axis, bool a1, bool a2, bool a3, bool a4, bool a5, bool a6) => PerformRobotCommand($"free_drive({enable},{axis},{a1},{a2},{a3},{a4},{a5},{a6})")))

            // Movel Incremental
            .SetValue("movel_incr_base",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_base({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")))
            .SetValue("movel_incr_tool",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_tool({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")))
            .SetValue("movel_incr_part",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")))
            .SetValue("movel_single_axis", new Func<int, double, bool>((int axis, double daxis) => PerformRobotCommand($"movel_single_axis({axis},{daxis:0.000000})")))
            .SetValue("movel_rot_only", new Func<double, double, double, bool>((double drx, double dry, double drz) => PerformRobotCommand($"movel_rot_only({drx:0.000000},{dry:0.000000},{drz:0.000000})")))

            // Movel Relative
            .SetValue("movel_rel_set_tool_origin",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_set_tool_origin({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")))
            .SetValue("movel_rel_set_tool_origin_here", new Func<bool>(() => PerformRobotCommand("movel_rel_set_part_origin_here()")))
            .SetValue("movel_rel_set_part_origin",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_set_part_origin({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")))
            .SetValue("movel_rel_set_part_origin_here", new Func<bool>(() => PerformRobotCommand("movel_rel_set_part_origin_here()")))
            .SetValue("movel_rel_tool",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_tool({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")))
            .SetValue("movel_rel_part",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_part({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")))

            // Tool Interface
            .SetValue("select_tool", new Func<string, int>((string toolName) => select_tool(toolName)))
            .SetValue("tool_on", new Func<bool>(() => PerformRobotCommand("tool_on()")))
            .SetValue("tool_off", new Func<bool>(() => PerformRobotCommand("tool_off()")))
            .SetValue("coolant_on", new Func<bool>(() => PerformRobotCommand("coolant_on()")))
            .SetValue("coolant_off", new Func<bool>(() => PerformRobotCommand("coolant_off()")))

            // Position Interface
            .SetValue("save_position", new Func<string, int>((string posName) => save_position(posName)))
            .SetValue("system_position", new Func<string, bool, int>((string posName, bool f) => system_position(posName, f)))
            .SetValue("clear_positions", new Func<int>(() => ClearNonSystemPositions()))
            .SetValue("move_joint", new Func<string, int>((string posName) => move_joint(posName)))
            .SetValue("move_linear", new Func<string, int>((string posName) => move_linear(posName)))
            .SetValue("move_tool_home", new Func<int>(() => move_tool_home()))
            .SetValue("move_tool_mount", new Func<int>(() => move_tool_mount()))

            // Set Motion Variables
            .SetValue("set_part_geometry", new Func<string, double, int>((string geometryName, double diam_mm) => set_part_geometry(geometryName, diam_mm)))
            .SetValue("set_part_geometry_N", new Func<int, double, bool>((int N, double diam_mm) => PerformRobotCommand($"set_part_geometry_N({N},{diam_mm:0.0})")))
            .SetValue("set_linear_speed", new Func<int, bool>((int speed_mmps) => PerformRobotCommand($"set_linear_speed({speed_mmps})")))
            .SetValue("set_linear_accel", new Func<int, bool>((int accel_mmpss) => PerformRobotCommand($"set_linear_accel({accel_mmpss})")))
            .SetValue("set_blend_radius", new Func<double, bool>((double blend_radius_mm) => PerformRobotCommand($"set_blend_radius({blend_radius_mm:0.0})")))
            .SetValue("set_joint_speed", new Func<int, bool>((int speed_dps) => PerformRobotCommand($"set_joint_speed({speed_dps})")))
            .SetValue("set_joint_accel", new Func<int, bool>((int accel_dpss) => PerformRobotCommand($"set_joint_accel({accel_dpss})")))

            // Robot I/O
            .SetValue("set_output", new Func<int, int, bool>((int dig_out, int state) => PerformRobotCommand($"set_output({dig_out},{state})")))

            // PolyScope Communication
            .SetValue("send_robot", new Func<string, bool>((string msg) => PerformRobotCommand($"send_robot({msg})")))
            .SetValue("robot_socket_reset", new Func<bool>(() => PerformRobotCommand("robot_socket_reset()")))
            .SetValue("send_program_exit", new Func<bool>(() => PerformRobotCommand("send_program_exit()")))

            // Grinding Patterns
            // TODO Should these look at license?
            // grind_line(dx_mm, dy_mm, n_cycles, speed_mm/s, force_N, stay_in_contact)
            .SetValue("grind_line",
                new Func<double, double, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_line({dx_mm:0.0},{dy_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))

            // grind_line_deg(length_mm, angle_deg, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            .SetValue("grind_line_deg",
                new Func<double, double, int, double, double, int, bool>(
                    (double length_mm, double angle_deg, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_line_deg({length_mm:0.0},{angle_deg:0.00},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            // grind_rect(dx_mm, dy_mm, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            .SetValue("grind_rect",
                new Func<double, double, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_rect({dx_mm:0.0},{dy_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            // grind_serp(dx_mm, dy_mm, n_xsteps, n_ysteps, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            .SetValue("grind_serp",
                new Func<double, double, int, int, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_xsteps, int n_ysteps, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_serp({dx_mm:0.0},{dy_mm:0.0},{n_xsteps},{n_ysteps},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            // grind_poly(circle_diam_mm, n_sides, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            .SetValue("grind_poly",
                new Func<double, int, int, double, double, int, bool>(
                    (double circle_diam_mm, int n_sides, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_poly({circle_diam_mm:0.0},{n_sides},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            // grind_circle(circle_diam_mm, n_cycles, speed_mm/s, force_N, stay_in_contact)
            .SetValue("grind_circle",
                new Func<double, int, double, double, int, bool>(
                    (double circle_diam_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_circle({circle_diam_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            // grind_spiral(circle1_diam_mm, grind_circle2_diam_mm, n_spirals, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            .SetValue("grind_spiral",
                new Func<double, double, int, int, double, double, int, bool>(
                    (double circle1_diam_mm, double circle2_diam_mm, int n_spirals, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_spiral({circle1_diam_mm:0.0},{circle2_diam_mm:0.0},{n_spirals},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")))
            .SetValue("grind_retract", new Func<bool>(() => PerformRobotCommand("grind_retract()")))

            // UR Grinding Variables
            .SetValue("grind_contact_enable", new Func<int, bool>((int x) => PerformRobotCommand($"grind_contact_enable({x})")))
            .SetValue("grind_touch_retract", new Func<double, bool>((double x) => PerformRobotCommand($"grind_touch_retract({x})")))
            .SetValue("grind_touch_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_touch_speed({x})")))
            .SetValue("grind_force_dwell", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_dwell({x})")))
            .SetValue("grind_max_wait", new Func<double, bool>((double x) => PerformRobotCommand($"grind_max_wait({x})")))
            .SetValue("grind_max_blend_radius", new Func<double, bool>((double x) => PerformRobotCommand($"grind_max_blend_radius({x})")))
            .SetValue("grind_trial_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_trial_speed({x})")))
            .SetValue("grind_linear_accel", new Func<double, bool>((double x) => PerformRobotCommand($"grind_linear_accel({x})")))
            .SetValue("grind_point_frequency", new Func<double, bool>((double x) => PerformRobotCommand($"grind_point_frequency({x})")))
            .SetValue("grind_jog_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_jog_speed({x})")))
            .SetValue("grind_jog_accel", new Func<double, bool>((double x) => PerformRobotCommand($"grind_jog_accel({x})")))
            .SetValue("grind_force_mode_damping", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_mode_damping({x})")))
            .SetValue("grind_force_mode_gain_scaling", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_mode_gain_scaling({x})")))

            // LMI Gocator
            // TODO Should these look at license
            .SetValue("gocator_send", new Func<string, int>((string message) => gocator_send(message)))
            .SetValue("gocator_trigger", new Func<int, int>((int preDelay_ms) => gocator_trigger(preDelay_ms)))
            .SetValue("gocator_adjust", new Func<int, int>((int version) => gocator_adjust(version)))
            .SetValue("gocator_write_data", new Func<string, string, int>((string filename, string tagName) => gocator_write_data(filename, tagName)))
            ;

            // Push all the LEonard variables down
            foreach (DataRow row in variables.Rows)
                ExecuteJavaScript($"{row["name"]} = '{row["value"]}'", null);
        }
        private void le_print_java(string msg)
        {
            CrawlRTB(JavaConsoleRTB, msg);
            log.Info("JPR:" + msg);
            Console.WriteLine(msg);
        }
        private void JavaUpdateVariablesRTB()
        {
            string finalUpdate = "";

            foreach (KeyValuePair<string, Jint.Runtime.Descriptors.PropertyDescriptor> kp in javaEngine.Global.GetOwnProperties().Reverse())
            {
                string typeName = kp.Value.Value.GetType().Name;

                if (kp.Value.Value.IsString())
                    finalUpdate += $"{kp.Key} = \"{kp.Value.Value}\"\n";
                else if (kp.Value.Value.IsNumber() || kp.Value.Value.IsBoolean())
                    finalUpdate += $"{kp.Key} = {kp.Value.Value}\n";
                else if (!kp.Value.Value.ToString().StartsWith("function()"))
                    finalUpdate += $"{kp.Key}:{typeName} = {kp.Value.Value}\n";
            }
            JavaVariablesRTB.Text = finalUpdate;
        }

        private void JavaNewBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaNewBtn_Click(...)");

            if (JavaCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Java code [{JavaFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    JavaSaveBtn_Click(null, null);
            }

            JavaCodeRTB.Text = "";
            JavaRunBtn.Enabled = false;
            JavaNewBtn.Enabled = false;
            JavaSaveBtn.Enabled = false;
            JavaSaveAsBtn.Enabled = false;
            JavaFilenameLbl.Text = "Untitled";
        }

        private bool LoadJavaProgram(string filename)
        {
            if (filename == null || filename == "Untitled" || filename.Length < 2)
            {
                JavaFilenameLbl.Text = "Untitled";
                return false;
            }

            try
            {
                JavaCodeRTB.LoadFile(filename, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            }
            catch
            {
                ErrorMessageBox($"Cannot load Java program {filename}");
                return false;
            }

            JavaFilenameLbl.Text = filename;
            JavaCodeRTB.Modified = false;
            JavaSaveAsBtn.Enabled = true;
            JavaSaveBtn.Enabled = false;
            JavaNewBtn.Enabled = true;

            return true;
        }
        private void JavaLoadBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaLoadBtn_Click(...)");
            if (JavaCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Java code [{JavaFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    JavaSaveAsBtn_Click(null, null);
            }

            string initialDirectory;
            if (JavaFilenameLbl.Text != "Untitled" && JavaFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(JavaFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Java Program",
                Filter = "*.js",
                InitialDirectory = initialDirectory,
                Extension = ".js"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadJavaProgram(dialog.FileName);
        }

        private void JavaSaveBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaSaveBtn_Click(...)");
            if (JavaFilenameLbl.Text == "Untitled" || JavaFilenameLbl.Text == "")
                JavaSaveAsBtn_Click(null, null);
            else
            {
                log.Info("Save Java program to {0}", JavaFilenameLbl.Text);
                JavaCodeRTB.SaveFile(JavaFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                JavaCodeRTB.Modified = false;
                JavaSaveBtn.Enabled = false;
            }
        }

        private void JavaSaveAsBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaSaveAsBtn_Click(...)");

            string initialDirectory;
            if (JavaFilenameLbl.Text != "Untitled" && JavaFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(JavaFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Java Program As...",
                Filter = "*.js",
                InitialDirectory = initialDirectory,
                FileName = JavaFilenameLbl.Text,
                Extension = ".js"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".js")) filename += ".js";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        JavaFilenameLbl.Text = filename;
                        JavaCodeRTB.SaveFile(JavaFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);

                        JavaCodeRTB.Modified = false;
                        JavaSaveAsBtn.Enabled = false;
                        JavaSaveBtn.Enabled = false;
                    }
                }
            }
        }
        private string javaCopy = null;
        private void JavaCodeRTB_TextChanged(object sender, EventArgs e)
        {
            // Font resizing triggers this, too, so we doublecheck to see if the text has actually changed!
            if (javaCopy == null)
                javaCopy = JavaCodeRTB.Text;

            if (javaCopy == JavaCodeRTB.Text)
                JavaCodeRTB.Modified = false;
            else
            {
                JavaSaveBtn.Enabled = true;
                JavaSaveAsBtn.Enabled = true;
                JavaRunBtn.Enabled = true;
                javaCopy = JavaCodeRTB.Text;
                JavaCodeRTB.Modified = true;
            }
        }

        bool JavaExec(string javaScript)
        {
            try
            {
                javaEngine.Execute(javaScript);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorMessageBox($"JavaExec Error: {ex}");
                return false;
            }
        }
        private void JavaRunBtn_Click(object sender, EventArgs e)
        {
            JavaExec(JavaCodeRTB.Text);
            JavaUpdateVariablesRTB();
        }
        private void JavaRestartBtn_Click(object sender, EventArgs e)
        {
            InitializeJavaEngine();
            JavaUpdateVariablesRTB();
        }

        bool ExecuteJavaScript(string code, LeDeviceInterface dev)
        {
            //log.Info($"Java Execute: {code}");
            //LeDeviceBase.currentDevice = dev;
            return JavaExec(code);
        }

        bool ExecuteJavaFile(string filename)
        {
            bool exec(string file)
            {
                string contents = File.ReadAllText(file);
                return JavaExec(contents);
            }

            if (File.Exists(filename))
            {
                return exec(filename);
            }

            filename = System.IO.Path.Combine(LEonardRoot, CodeFolder, filename);
            if (File.Exists(filename))
            {
                return exec(filename);
            }

            ExecError($"File {filename} does not exist");
            return false;
        }
        #endregion ===== JAVA SUPPORT CODE                 ==============================================================================================================================

        #region ===== PYTHON SUPPORT CODE               ==============================================================================================================================
        private void InitializePythonEngine()
        {
            pythonEngine = Python.CreateEngine();
            pythonScope = pythonEngine.CreateScope();

            // Make sure we're looking in the right spots for imports!
            ICollection<string> paths = pythonEngine.GetSearchPaths();
            paths.Add(System.IO.Path.Combine(executionRoot, @"..\..\Lib"));
            paths.Add(System.IO.Path.Combine(LEonardRoot, "Code", "Lib"));
            paths.Add(System.IO.Path.Combine(LEonardRoot, "Code"));
            foreach (string path in paths)
            {
                log.Debug($"Python Search Path: {path}");
            }
            pythonEngine.SetSearchPaths(paths);

            // The Standard Library
            pythonScope.SetVariable("using_lescript", new Action(() => using_lescript()));
            pythonScope.SetVariable("using_java", new Action(() => using_java()));
            pythonScope.SetVariable("using_python", new Action(() => using_python()));
            pythonScope.SetVariable("exec_lescript", new Func<string, bool>((string filename) => ExecuteLEScriptFile(filename)));
            pythonScope.SetVariable("exec_java", new Func<string, bool>((string filename) => ExecuteJavaFile(filename)));
            pythonScope.SetVariable("exec_python", new Func<string, bool>((string filename) => ExecutePythonFile(filename)));
            pythonScope.SetVariable("execline_lescript", new Action<string>((string line) => ExecuteLEScriptLine(-1, line)));
            pythonScope.SetVariable("execline_java", new Action<string>((string line) => ExecuteJavaLine(-1, line)));
            pythonScope.SetVariable("execline_python", new Action<string>((string line) => ExecutePythonLine(-1, line)));

            pythonScope.SetVariable("le_read_var", new Func<string, string>((string name) => ReadVariable(name)));
            pythonScope.SetVariable("le_write_var", new Func<string, string, bool>((string name, string value) => WriteVariable(name, value, false, false))); // Last param false so we don't write it back here as a string!
            pythonScope.SetVariable("le_write_sysvar", new Func<string, string, bool>((string name, string value) => WriteVariable(name, value, true, false))); // Last param false so we don't write it back here as a string!

            pythonScope.SetVariable("le_print", new Action<string>((string msg) => le_print_python(msg)));
            pythonScope.SetVariable("le_show_console", new Action<bool>((bool f) => le_show_console(f)));
            pythonScope.SetVariable("le_clear_console", new Action(() => le_clear_console()));

            pythonScope.SetVariable("le_log_info", new Action<string>((string msg) => log.Info(msg)));
            pythonScope.SetVariable("le_log_error", new Action<string>(s => log.Error(s)));

            pythonScope.SetVariable("pause", new Action(() => PerformPause()));
            pythonScope.SetVariable("pauseif", new Action<bool>((bool f) => PerformPauseIf(f)));
            pythonScope.SetVariable("stop", new Action(() => PerformStop()));
            pythonScope.SetVariable("stopif", new Action<bool>((bool f) => PerformStopIf(f)));
            pythonScope.SetVariable("prompt", new Action<string>((string prompt) => PerformPrompt(prompt)));
            pythonScope.SetVariable("promptif", new Action<bool, string>((bool f, string prompt) => PerformPromptIf(f, prompt)));
            pythonScope.SetVariable("jump", new Action<string>((string labelName) => PerformJump(labelName)));
            pythonScope.SetVariable("jumpif", new Action<bool, string>((bool condition, string labelName) => PerformJumpIf(condition, labelName)));
            pythonScope.SetVariable("call", new Action<string>((string labelName) => PerformCall(labelName)));
            pythonScope.SetVariable("callif", new Action<bool, string>((bool condition, string labelName) => PerformCallIf(condition, labelName)));
            pythonScope.SetVariable("ret", new Action(() => PerformReturn()));
            pythonScope.SetVariable("sleep", new Func<double, bool>((double timeout_s) => le_sleep(timeout_s)));
            pythonScope.SetVariable("assertTrue", new Func<bool, bool>((bool f) => assertTrue(f)));
            pythonScope.SetVariable("assertFalse", new Func<bool, bool>((bool f) => assertFalse(f)));

            pythonScope.SetVariable("le_connect", new Func<string, int>((string devName) => le_connect(devName)));
            pythonScope.SetVariable("le_disconnect", new Func<string, int>((string devName) => le_disconnect(devName)));
            pythonScope.SetVariable("le_connect_all", new Func<int>(() => le_connect_all()));
            pythonScope.SetVariable("le_disconnect_all", new Func<int>(() => le_disconnect_all()));
            pythonScope.SetVariable("le_send", new Func<string, string, int>((string devName, string msg) => le_send(devName, msg)));
            pythonScope.SetVariable("le_ask", new Func<string, string, int, string>((string devName, string msg, int timeoutMs) => le_ask(devName, msg, timeoutMs)));

            // Universal Robots
            // TODO Should these look at license?
            // Dashboard Communication
            pythonScope.SetVariable("ur_dashboard", new Func<string, int, string>((string msg, int timeout) => ur_dashboard(msg, timeout)));

            // Core Motion
            pythonScope.SetVariable("movej",
                new Func<double, double, double, double, double, double, bool>(
                    (double j1, double j2, double j3, double j4, double j5, double j6) => PerformRobotCommand($"movej({j1:0.000000},{j2:0.000000},{j3:0.000000},{j4:0.000000},{j5:0.000000},{j6:0.000000})")));
            pythonScope.SetVariable("get_actual_joint_positions", new Func<bool>(() => PerformRobotCommand("get_actual_joint_positions()")));
            pythonScope.SetVariable("get_target_joint_positions", new Func<bool>(() => PerformRobotCommand("get_target_joint_positions()")));
            pythonScope.SetVariable("movel",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")));
            pythonScope.SetVariable("get_actual_tcp_pose", new Func<bool>(() => PerformRobotCommand("get_actual_tcp_pose()")));
            pythonScope.SetVariable("get_target_tcp_pose", new Func<bool>(() => PerformRobotCommand("get_target_tcp_pose()")));
            pythonScope.SetVariable("get_actual_both", new Func<bool>(() => PerformRobotCommand("get_actual_both()")));
            pythonScope.SetVariable("get_target_both", new Func<bool>(() => PerformRobotCommand("get_target_both()")));
            pythonScope.SetVariable("set_tcp",
                new Func<double, double, double, double, double, double, bool>(
                    (double x_m, double y_m, double z_m, double rx_rad, double ry_rad, double rz_rad) => PerformRobotCommand($"set_tcp({x_m:0.000000},{y_m:0.000000},{z_m:0.000000},{rx_rad:0.000000},{ry_rad:0.000000},{rz_rad:0.000000})")));
            pythonScope.SetVariable("get_tcp_offset", new Func<bool>(() => PerformRobotCommand("get_tcp_offset()")));
            pythonScope.SetVariable("set_payload",
                new Func<double, double, double, double, bool>(
                    (double mass_kg, double cog_x_m, double cog_y_m, double cog_z_m) => PerformRobotCommand($"set_payload({mass_kg:0.000000},{cog_x_m:0.000000},{cog_y_m:0.000000},{cog_z_m:0.000000})")));

            // Movel Incremental
            pythonScope.SetVariable("movel_incr_base",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_base({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")));
            pythonScope.SetVariable("movel_incr_tool",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_tool({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")));
            pythonScope.SetVariable("movel_incr_part",
                new Func<double, double, double, double, double, double, bool>(
                    (double dx, double dy, double dz, double drx, double dry, double drz) => PerformRobotCommand($"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},{drx:0.000000},{dry:0.000000},{drz:0.000000})")));
            pythonScope.SetVariable("movel_single_axis", new Func<int, double, bool>((int axis, double daxis) => PerformRobotCommand($"movel_single_axis({axis},{daxis:0.000000})")));
            pythonScope.SetVariable("movel_rot_only", new Func<double, double, double, bool>((double drx, double dry, double drz) => PerformRobotCommand($"movel_rot_only({drx:0.000000},{dry:0.000000},{drz:0.000000})")));

            // Movel Relative
            pythonScope.SetVariable("movel_rel_set_tool_origin",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_set_tool_origin({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")));
            pythonScope.SetVariable("movel_rel_set_tool_origin_here", new Func<bool>(() => PerformRobotCommand("movel_rel_set_part_origin_here()")));
            pythonScope.SetVariable("movel_rel_set_part_origin",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_set_part_origin({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")));
            pythonScope.SetVariable("movel_rel_set_part_origin_here", new Func<bool>(() => PerformRobotCommand("movel_rel_set_part_origin_here()")));
            pythonScope.SetVariable("movel_rel_tool",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_tool({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")));
            pythonScope.SetVariable("movel_rel_part",
                new Func<double, double, double, double, double, double, bool>(
                    (double x, double y, double z, double rx, double ry, double rz) => PerformRobotCommand($"movel_rel_part({x:0.000000},{y:0.000000},{z:0.000000},{rx:0.000000},{ry:0.000000},{rz:0.000000})")));

            // Tool Interface
            pythonScope.SetVariable("select_tool", new Func<string, int>((string toolName) => select_tool(toolName)));
            pythonScope.SetVariable("tool_on", new Func<bool>(() => PerformRobotCommand("tool_on()")));
            pythonScope.SetVariable("tool_off", new Func<bool>(() => PerformRobotCommand("tool_off()")));
            pythonScope.SetVariable("coolant_on", new Func<bool>(() => PerformRobotCommand("coolant_on()")));
            pythonScope.SetVariable("coolant_off", new Func<bool>(() => PerformRobotCommand("coolant_off()")));

            // Position Interface
            pythonScope.SetVariable("save_position", new Func<string, int>((string posName) => save_position(posName)));
            pythonScope.SetVariable("system_position", new Func<string, bool, int>((string posName, bool f) => system_position(posName, f)));
            pythonScope.SetVariable("clear_position", new Func<int>(() => ClearNonSystemPositions()));
            pythonScope.SetVariable("move_joint", new Func<string, int>((string posName) => move_joint(posName)));
            pythonScope.SetVariable("move_linear", new Func<string, int>((string posName) => move_linear(posName)));
            pythonScope.SetVariable("move_tool_home", new Func<int>(() => move_tool_home()));
            pythonScope.SetVariable("move_tool_mount", new Func<int>(() => move_tool_mount()));
            pythonScope.SetVariable("free_drive",
                new Func<bool, int, bool, bool, bool, bool, bool, bool, bool>(
                    (bool enable, int axis, bool a1, bool a2, bool a3, bool a4, bool a5, bool a6) => PerformRobotCommand($"free_drive({enable},{axis},{a1},{a2},{a3},{a4},{a5},{a6})")));

            // Set Motion Variables
            pythonScope.SetVariable("set_part_geometry", new Func<string, double, int>((string geometryName, double diam_mm) => set_part_geometry(geometryName, diam_mm)));
            pythonScope.SetVariable("set_part_geometry_N", new Func<int, double, bool>((int N, double diam_mm) => PerformRobotCommand($"set_part_geometry_N({N},{diam_mm:0.0})")));
            pythonScope.SetVariable("set_linear_speed", new Func<int, bool>((int speed_mmps) => PerformRobotCommand($"set_linear_speed({speed_mmps})")));
            pythonScope.SetVariable("set_linear_accel", new Func<int, bool>((int accel_mmpss) => PerformRobotCommand($"set_linear_accel({accel_mmpss})")));
            pythonScope.SetVariable("set_blend_radius", new Func<double, bool>((double blend_radius_mm) => PerformRobotCommand($"set_blend_radius({blend_radius_mm:0.0})")));
            pythonScope.SetVariable("set_joint_speed", new Func<int, bool>((int speed_dps) => PerformRobotCommand($"set_joint_speed({speed_dps})")));
            pythonScope.SetVariable("set_joint_accel", new Func<int, bool>((int accel_dpss) => PerformRobotCommand($"set_joint_accel({accel_dpss})")));

            // Robot I/O
            pythonScope.SetVariable("set_output", new Func<int, int, bool>((int dig_out, int state) => PerformRobotCommand($"set_output({dig_out},{state})")));

            // PolyScope Communication
            pythonScope.SetVariable("send_robot", new Func<string, bool>((string msg) => PerformRobotCommand($"send_robot({msg})")));
            pythonScope.SetVariable("robot_socket_reset", new Func<bool>(() => PerformRobotCommand("robot_socket_reset()")));
            pythonScope.SetVariable("send_program_exit", new Func<bool>(() => PerformRobotCommand("send_program_exit()")));

            // Grinding Patterns
            // TODO Should these look at license?
            // grind_line(dx_mm, dy_mm, n_cycles, speed_mm/s, force_N, stay_in_contact)
            pythonScope.SetVariable("grind_line",
                new Func<double, double, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_line({dx_mm:0.0},{dy_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));

            // grind_line_deg(length_mm, angle_deg, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            pythonScope.SetVariable("grind_line_deg",
                new Func<double, double, int, double, double, int, bool>(
                    (double length_mm, double angle_deg, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_line_deg({length_mm:0.0},{angle_deg:0.00},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            // grind_rect(dx_mm, dy_mm, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            pythonScope.SetVariable("grind_rect",
                new Func<double, double, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_rect({dx_mm:0.0},{dy_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            // grind_serp(dx_mm, dy_mm, n_xsteps, n_ysteps, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            pythonScope.SetVariable("grind_serp",
                new Func<double, double, int, int, int, double, double, int, bool>(
                    (double dx_mm, double dy_mm, int n_xsteps, int n_ysteps, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_serp({dx_mm:0.0},{dy_mm:0.0},{n_xsteps},{n_ysteps},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            // grind_poly(circle_diam_mm, n_sides, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            pythonScope.SetVariable("grind_poly",
                new Func<double, int, int, double, double, int, bool>(
                    (double circle_diam_mm, int n_sides, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_poly({circle_diam_mm:0.0},{n_sides},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            // grind_circle(circle_diam_mm, n_cycles, speed_mm/s, force_N, stay_in_contact)
            pythonScope.SetVariable("grind_circle",
                new Func<double, int, double, double, int, bool>(
                    (double circle_diam_mm, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_circle({circle_diam_mm:0.0},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            // grind_spiral(circle1_diam_mm, grind_circle2_diam_mm, n_spirals, n_cycles, speed_mm/s, force_N, stay_in_contact) 
            pythonScope.SetVariable("grind_spiral",
                new Func<double, double, int, int, double, double, int, bool>(
                    (double circle1_diam_mm, double circle2_diam_mm, int n_spirals, int n_cycles, double speed_mmps, double force_N, int stay_in_contact) =>
                    PerformRobotCommand($"grind_spiral({circle1_diam_mm:0.0},{circle2_diam_mm:0.0},{n_spirals},{n_cycles},{speed_mmps:0.0},{force_N:0.00},{stay_in_contact})")));
            pythonScope.SetVariable("grind_retract", new Func<bool>(() => PerformRobotCommand("grind_retract()")));

            // UR Grinding Variables
            pythonScope.SetVariable("grind_contact_enable", new Func<int, bool>((int x) => PerformRobotCommand($"grind_contact_enable({x})")));
            pythonScope.SetVariable("grind_touch_retract", new Func<double, bool>((double x) => PerformRobotCommand($"grind_touch_retract({x})")));
            pythonScope.SetVariable("grind_touch_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_touch_speed({x})")));
            pythonScope.SetVariable("grind_force_dwell", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_dwell({x})")));
            pythonScope.SetVariable("grind_max_wait", new Func<double, bool>((double x) => PerformRobotCommand($"grind_max_wait({x})")));
            pythonScope.SetVariable("grind_max_blend_radius", new Func<double, bool>((double x) => PerformRobotCommand($"grind_max_blend_radius({x})")));
            pythonScope.SetVariable("grind_trial_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_trial_speed({x})")));
            pythonScope.SetVariable("grind_linear_accel", new Func<double, bool>((double x) => PerformRobotCommand($"grind_linear_accel({x})")));
            pythonScope.SetVariable("grind_point_frequency", new Func<double, bool>((double x) => PerformRobotCommand($"grind_point_frequency({x})")));
            pythonScope.SetVariable("grind_jog_speed", new Func<double, bool>((double x) => PerformRobotCommand($"grind_jog_speed({x})")));
            pythonScope.SetVariable("grind_jog_accel", new Func<double, bool>((double x) => PerformRobotCommand($"grind_jog_accel({x})")));
            pythonScope.SetVariable("grind_force_mode_damping", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_mode_damping({x})")));
            pythonScope.SetVariable("grind_force_mode_gain_scaling", new Func<double, bool>((double x) => PerformRobotCommand($"grind_force_mode_gain_scaling({x})")));

            // LMI Gocator
            // TODO Should these look at license
            pythonScope.SetVariable("gocator_send", new Func<string, int>((string message) => gocator_send(message)));
            pythonScope.SetVariable("gocator_trigger", new Func<int, int>((int preDelay_ms) => gocator_trigger(preDelay_ms)));
            pythonScope.SetVariable("gocator_adjust", new Func<int, int>((int version) => gocator_adjust(version)));
            pythonScope.SetVariable("gocator_write_data", new Func<string, string, int>((string filename, string tagName) => gocator_write_data(filename, tagName)));

            // Push all the LEonard variables down
            foreach (DataRow row in variables.Rows)
                ExecutePythonScript($"{row["name"]} = '{row["value"]}'", null);

        }
        private void le_print_python(string msg)
        {
            CrawlRTB(PythonConsoleRTB, msg);
            log.Info("PPR:" + msg);
            Console.WriteLine(msg);
        }
        private void PythonUpdateVariablesRTB()
        {
            string finalUpdate = "";

            foreach (string varName in pythonScope.GetVariableNames().Reverse())
            {
                var val = pythonScope.GetVariable(varName);
                string typeName = "??";
                try
                {
                    typeName = val.GetType().Name;
                    if (typeName == "String")
                        finalUpdate += $"{varName} = \"{val}\"\n";
                    else if (typeName == "Int32")
                        finalUpdate += $"{varName} = {val}\n";
                    else if (!(typeName.StartsWith("Action") || typeName.StartsWith("Func") || typeName.StartsWith("__")))
                        finalUpdate += $"{varName}::{typeName} = {val}\n";
                }
                catch
                {
                    finalUpdate += $"ERROR {varName}::{typeName} = {val}\n";
                }
            }

            PythonVariablesRTB.Text = finalUpdate;
        }

        private void PythonNewBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonNewBtn_Click(...)");

            if (PythonCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Python code [{PythonFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    PythonSaveBtn_Click(null, null);
            }

            PythonCodeRTB.Text = "";
            PythonRunBtn.Enabled = false;
            PythonNewBtn.Enabled = false;
            PythonSaveBtn.Enabled = false;
            PythonSaveAsBtn.Enabled = false;
            PythonFilenameLbl.Text = "Untitled";
        }

        private bool LoadPythonProgram(string filename)
        {
            if (filename == null || filename == "Untitled" || filename.Length < 2)
            {
                PythonFilenameLbl.Text = "Untitled";
                return false;
            }

            try
            {
                PythonCodeRTB.LoadFile(filename, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            }
            catch
            {
                ErrorMessageBox($"Cannot load Python program {filename}");
                return false;
            }

            PythonFilenameLbl.Text = filename;
            PythonCodeRTB.Modified = false;
            PythonSaveAsBtn.Enabled = true;
            PythonSaveBtn.Enabled = false;
            PythonNewBtn.Enabled = true;

            return true;
        }
        private void PythonLoadBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonLoadBtn_Click(...)");
            if (PythonCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Python code [{PythonFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    PythonSaveAsBtn_Click(null, null);
            }

            string initialDirectory;
            if (PythonFilenameLbl.Text != "Untitled" && PythonFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(PythonFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Python Program",
                Filter = "*.py",
                InitialDirectory = initialDirectory,
                Extension = ".py"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadPythonProgram(dialog.FileName);
        }

        private void PythonSaveBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonSaveBtn_Click(...)");
            if (PythonFilenameLbl.Text == "Untitled" || PythonFilenameLbl.Text == "")
                PythonSaveAsBtn_Click(null, null);
            else
            {
                log.Info("Save Python program to {0}", PythonFilenameLbl.Text);
                PythonCodeRTB.SaveFile(PythonFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                PythonCodeRTB.Modified = false;
                PythonSaveBtn.Enabled = false;
            }
        }

        private void PythonSaveAsBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonSaveAsBtn_Click(...)");

            string initialDirectory;
            if (PythonFilenameLbl.Text != "Untitled" && PythonFilenameLbl.Text.Length > 0)
                initialDirectory = System.IO.Path.GetDirectoryName(PythonFilenameLbl.Text);
            else
                initialDirectory = System.IO.Path.Combine(LEonardRoot, CodeFolder);

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Python Program As...",
                Filter = "*.py",
                InitialDirectory = initialDirectory,
                FileName = PythonFilenameLbl.Text,
                Extension = ".py"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".py")) filename += ".py";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        PythonFilenameLbl.Text = filename;
                        PythonCodeRTB.SaveFile(PythonFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);

                        PythonCodeRTB.Modified = false;
                        PythonSaveAsBtn.Enabled = false;
                        PythonSaveBtn.Enabled = false;
                    }
                }
            }
        }

        private string pythonCopy = null;
        private void PythonCodeRTB_TextChanged(object sender, EventArgs e)
        {
            // Font resizing triggers this, too, so we doublecheck to see if the text has actually changed!
            if (pythonCopy == null)
                pythonCopy = PythonCodeRTB.Text;

            if (pythonCopy == PythonCodeRTB.Text)
                PythonCodeRTB.Modified = false;
            else
            {
                PythonSaveBtn.Enabled = true;
                PythonSaveAsBtn.Enabled = true;
                PythonRunBtn.Enabled = true;
                pythonCopy = PythonCodeRTB.Text;
                PythonCodeRTB.Modified = true;
            }
        }
        bool PythonExec(string pythonScript)
        {
            Microsoft.Scripting.Hosting.ScriptSource script = pythonScope.Engine.CreateScriptSourceFromString(pythonScript);

            try
            {
                script.Execute(pythonScope);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorMessageBox($"PythonExec Error: {ex}");
                return false;
            }
        }
        private void PythonRunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PythonExec(PythonCodeRTB.Text);
            }
            catch (Exception ex)
            {
                ErrorMessageBox($"PythonRunBtn Error: {ex}");
            }
            PythonUpdateVariablesRTB();
        }
        private void PythonRestartBtn_Click(object sender, EventArgs e)
        {
            InitializePythonEngine();
            PythonUpdateVariablesRTB();
        }

        bool ExecutePythonScript(string code, LeDeviceInterface dev)
        {
            //log.Info($"Python Execute: {code}");
            try
            {
                //LeDeviceBase.currentDevice = dev;
                return PythonExec(code);
            }
            catch (Exception ex)
            {
                ErrorMessageBox($"ExecutePythonScript Error: {ex}");
                return false;
            }
        }

        bool ExecutePythonFile(string filename)
        {

            bool exec(string fname)
            {
                log.Info($"try exec {fname}");
                string contents = File.ReadAllText(fname);
                log.Info(contents);
                try
                {
                    return PythonExec(contents);
                }
                catch //(Exception ex)
                {
                    //ErrorMessageBox($"ExecutePythonScript Error: {ex}");
                    return false;
                }
            }

            if (File.Exists(filename))
            {
                return exec(filename);
            }

            filename = System.IO.Path.Combine(LEonardRoot, CodeFolder, filename);
            if (File.Exists(filename))
            {
                return exec(filename);
            }

            //ErrorMessageBox($"ExecutePythonFile({filename}) file does not exist");
            return false;
        }
        #endregion ===== PYTHON SUPPORT CODE               ==============================================================================================================================

        #region ===== LICENSING CODE                    ==============================================================================================================================
        private void GetLicenseStatus()
        {
            LicenseStatusLbl.Text = protection.GetStatus();
        }
        private void LicenseStatusLbl_DoubleClick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int challenge = rnd.Next(10000, 99999);

            SetValueForm form = new SetValueForm(this)
            {
                Value = 0,
                Label = $"Passcode {challenge} for ADJUST LICENSE",
                NumberOfDecimals = 0,
                MaxAllowed = 999999,
                MinAllowed = 0,
                IsPassword = true,
            };
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.Value == challenge + 1)
                {
                    LicenseAdjustGrp.Visible = true;
                    SaveLicenseBtn.Enabled = false;
                }
                else
                {
                    LicenseAdjustGrp.Visible = false;
                    ErrorMessageBox("Incorrect licensing passcode");
                    return;
                }
            }
        }

        private void TrialLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.CreateTrialLicense(30);
            protection.SaveLicense(licenseFilename);
            protection.LoadLicense(licenseFilename);
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }
        private void JavaLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleJava();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void PythonLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.TogglePython();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void UrLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleUR();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void GrindingLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleGrinding();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void GocatorLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleGocator();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void NewLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.CreateNewLicense();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void UpdateAnnunciators()
        {
            GocatorAnnounce();
            UrDashboardAnnounce();
            UrCommandAnnounce();
        }

        private void ReloadLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.LoadLicense(licenseFilename);
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = false;
            UpdateAnnunciators();
        }
        private void SaveLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.SaveLicense(licenseFilename);
            SaveLicenseBtn.Enabled = false;
            UpdateAnnunciators();
        }

        #endregion ===== LICENSING CODE                    ==============================================================================================================================

        #region ===== UR INTERFACE CODE                 ==============================================================================================================================
        enum ProgramState
        {
            UNKNOWN,
            STOPPED,
            PAUSED,
            PLAYING
        };

        int dashboardCycle = 0;
        int nUnansweredRobotmodeRequests = 0;
        int nUnansweredSafetystatusRequests = 0;
        int nUnansweredProgramstateRequests = 0;

        public void UrDashboardAnnounce()
        {
            log.Debug($"UrDashboardAnnounce nInstances={LeUrDashboard.nInstances}");

            // Buttons only visible if there is a UrDashboard
            void SetButtonVisibility(bool isVisible)
            {
                RobotConnectBtn.Visible = isVisible;
                RobotModeBtn.Visible = isVisible;
                RobotSafetyStatusBtn.Visible = isVisible;
                RobotProgramStateBtn.Visible = isVisible;
            }
            // If no UrDashboard is attached, hide the controls and return. Else show them!
            if (LeUrDashboard.nInstances > 0)
                SetButtonVisibility(true);
            else
            {
                SetButtonVisibility(false);
                return;
            }

            LeUrDashboard.Status status = LeUrDashboard.Status.ERROR;
            if (LeUrDashboard.uiFocusInstance != null)
                status = LeUrDashboard.uiFocusInstance.status;
            switch (status)
            {
                case LeUrDashboard.Status.OK:
                    RobotConnectBtn.BackColor = Color.Green;
                    RobotConnectBtn.Text = "Dashboard OK";

                    CloseSafetyPopup();

                    break;
                case LeUrDashboard.Status.ERROR:
                    RobotConnectBtn.BackColor = Color.Red;
                    RobotConnectBtn.Text = "Dashboard ERROR";
                    break;
                case LeUrDashboard.Status.OFF:
                    RobotConnectBtn.BackColor = Color.Red;
                    RobotConnectBtn.Text = "OFF";
                    RobotModeBtn.BackColor = Color.Red;
                    RobotSafetyStatusBtn.BackColor = Color.Red;
                    RobotProgramStateBtn.BackColor = Color.Red;
                    RobotModeBtn.Text = "";
                    RobotSafetyStatusBtn.Text = "";
                    RobotProgramStateBtn.Text = "";
                    break;
                default:
                    RobotConnectBtn.BackColor = Color.Yellow;
                    RobotConnectBtn.Text = "Dashboard ???";
                    break;
            }
        }
        public void UrCommandAnnounce()
        {
            log.Debug($"UrCommandAnnounce nInstances={LeUrCommand.nInstances}");

            // Buttons only visible if there is a UrCommand
            void SetButtonVisibility(bool isVisible)
            {
                RobotCommandStatusLbl.Visible = isVisible;
                RobotReadyLbl.Visible = isVisible;
                RobotSentLbl.Visible = isVisible;
                RobotCompletedLbl.Visible = isVisible;

                MoveToolHomeBtn.Visible = isVisible;
                MoveToolMountBtn.Visible = isVisible;
                MoveToolHomeLbl.Visible = isVisible;
                MoveToolMountLbl.Visible = isVisible;

                DoorClosedLbl.Visible = isVisible;
                FootswitchPressedLbl.Visible = isVisible;

                MountedToolBox.Visible = isVisible;
                MountedToolBoxLbl.Visible = isVisible;
                PartGeometryBox.Visible = isVisible;
                PartGeometryBoxLbl.Visible = isVisible;
                DiameterLbl.Visible = isVisible;
                DiameterDimLbl.Visible = isVisible;

                // Only available with grinding system
                bool showGrind = isVisible && Protection.license.hasGrinding;
                GrindContactEnabledBtn.Visible = showGrind;
                GrindReadyLbl.Visible = showGrind;
                GrindProcessStateLbl.Visible = showGrind;
                GrindLbl1.Visible = showGrind;
                GrindLbl2.Visible = showGrind;
                GrindLbl3.Visible = showGrind;
                GrindLbl4.Visible = showGrind;
                GrindCycleLbl.Visible = showGrind;
                GrindNCyclesLbl.Visible = showGrind;
                GrindForceReportZLbl.Visible = showGrind;
            }

            // If no UrCommand attached, hide the controls and return. Else show them!
            if (LeUrCommand.nInstances > 0)
                SetButtonVisibility(true);
            else
            {
                SetButtonVisibility(false);
                return;
            }

            LeUrCommand.Status status = LeUrCommand.Status.ERROR;
            if (LeUrCommand.uiFocusInstance != null)
                status = LeUrCommand.uiFocusInstance.status;
            switch (status)
            {
                case LeUrCommand.Status.OK:
                    RobotCommandStatusLbl.Text = "READY";
                    RobotCommandStatusLbl.BackColor = Color.Green;
                    RobotReadyLbl.BackColor = Color.Green;
                    GrindReadyLbl.BackColor = Color.Green;
                    GrindProcessStateLbl.BackColor = Color.Green;
                    RobotSentLbl.BackColor = Color.Green;
                    RobotCompletedLbl.BackColor = Color.Yellow;
                    break;
                case LeUrCommand.Status.WAITING:
                    RobotCommandStatusLbl.Text = "WAIT";
                    RobotCommandStatusLbl.BackColor = Color.Red;
                    RobotReadyLbl.BackColor = Color.Red;
                    GrindReadyLbl.BackColor = Color.Red;
                    GrindProcessStateLbl.BackColor = Color.Red;
                    RobotSentLbl.BackColor = Color.Red;
                    RobotCompletedLbl.BackColor = Color.Red;
                    break;
                case LeUrCommand.Status.ERROR:
                    RobotCommandStatusLbl.Text = "ERROR";
                    RobotCommandStatusLbl.BackColor = Color.Red;
                    RobotReadyLbl.BackColor = Color.Red;
                    GrindReadyLbl.BackColor = Color.Red;
                    RobotSentLbl.BackColor = Color.Red;
                    RobotCompletedLbl.BackColor = Color.Red;
                    GrindProcessStateLbl.BackColor = Color.Red;
                    break;
                case LeUrCommand.Status.OFF:
                    RobotCommandStatusLbl.Text = "OFF";
                    RobotCommandStatusLbl.BackColor = Color.Red;
                    RobotReadyLbl.BackColor = Color.Red;
                    GrindReadyLbl.BackColor = Color.Red;
                    GrindProcessStateLbl.BackColor = Color.Red;
                    RobotSentLbl.BackColor = Color.Red;
                    RobotCompletedLbl.BackColor = Color.Red;
                    break;
                default:
                    RobotCommandStatusLbl.Text = "???";
                    RobotCommandStatusLbl.BackColor = Color.Yellow;
                    RobotReadyLbl.BackColor = Color.Yellow;
                    GrindReadyLbl.BackColor = Color.Yellow;
                    GrindProcessStateLbl.BackColor = Color.Yellow;
                    RobotSentLbl.BackColor = Color.Yellow;
                    RobotCompletedLbl.BackColor = Color.Yellow;
                    break;
            }
        }
        private string ur_dashboard(string inquiry, int timeoutMs = 200)
        {
            string response = "Null";
            response = LeUrDashboard.uiFocusInstance?.Ask(inquiry, timeoutMs);
            log.Info($"ur_dashboard({inquiry}) received {response}");
            return response;
        }
        private void HandleRobotmodeResponse(string robotmodeResponse)
        {
            Color color = Color.Red;
            string buttonText = robotmodeResponse;
            switch (robotmodeResponse)
            {
                case "Robotmode: RUNNING":
                    color = Color.Green;
                    break;
                case "Robotmode: CONFIRM_SAFETY":
                    EnsureStopped();
                    color = Color.Blue;
                    break;
                case "Robotmode: IDLE":
                    EnsureNotRunning();
                    color = Color.Blue;
                    break;
                case "Robotmode: NO_CONTROLLER":
                case "Robotmode: DISCONNECTED":
                case "Robotmode: BACKDRIVE":
                case "Robotmode: POWER_OFF":
                    EnsureStopped();
                    color = Color.Red;
                    break;
                case "Robotmode: POWER_ON":
                    EnsureStopped();
                    color = Color.Blue;
                    break;
                case "Robotmode: BOOTING":
                    EnsureStopped();
                    color = Color.Coral;
                    break;
                default:
                    log.Error("Unknown response to robotmode: {0}", robotmodeResponse);
                    EnsureStopped();
                    buttonText = "Robotmode: ?? " + robotmodeResponse;
                    color = Color.Red;
                    break;
            }
            RobotModeBtn.Text = buttonText;
            RobotModeBtn.BackColor = color;
        }

        private void HandleSafetystatusResponse(string safetystatusResponse)
        {
            Color color = Color.Red;
            string buttonText = safetystatusResponse;
            switch (safetystatusResponse)
            {
                case "Safetystatus: NORMAL":
                    color = Color.Green;
                    break;
                case "Safetystatus: REDUCED":
                    color = Color.Yellow;
                    break;
                case "Safetystatus: PROTECTIVE_STOP":
                case "Safetystatus: RECOVERY":
                case "Safetystatus: SAFEGUARD_STOP":
                case "Safetystatus: SYSTEM_EMERGENCY_STOP":
                case "Safetystatus: ROBOT_EMERGENCY_STOP":
                case "Safetystatus: VIOLATION":
                case "Safetystatus: FAULT":
                case "Safetystatus: AUTOMATIC_MODE_SAFEGUARD_STOP":
                case "Safetystatus: SYSTEM_THREE_POSITION_ENABLING_STOP":
                    EnsureNotRunning();
                    color = Color.Red;
                    break;
                default:
                    log.Error("Unknown response to safetystatus: {0}", safetystatusResponse);
                    EnsureStopped();
                    buttonText = "Safetystatus: ?? " + safetystatusResponse;
                    color = Color.Red;
                    break;
            }
            RobotSafetyStatusBtn.Text = buttonText.Replace('_', ' ');
            RobotSafetyStatusBtn.BackColor = color;
        }

        // Is the supplied string a valid response to Dashboard programstate command?
        ProgramState IsProgramstateResponse(string message)
        {
            ProgramState programState = ProgramState.UNKNOWN;

            if (message != null)
            {
                if (message.StartsWith("STOPPED"))
                    programState = ProgramState.STOPPED;
                else if (message.StartsWith("PAUSED"))
                    programState = ProgramState.PAUSED;
                else if (message.StartsWith("PLAYING"))
                    programState = ProgramState.PLAYING;
            }

            return programState;
        }

        private void HandleProgramstateResponse(ProgramState programState, string programstateResponse)
        {
            Color color = Color.Red;
            string buttonText = programstateResponse;
            switch (programState)
            {
                case ProgramState.STOPPED:
                    //EnsureStopped();
                    break;
                case ProgramState.PAUSED:
                    EnsureNotRunning();
                    break;
                case ProgramState.PLAYING:
                    color = Color.Green;
                    /*
                    // Old code to reset the server... this is setup in Device Connect
                    if (robotCommandServer == null)
                    {
                        // Setup a server for the UR to connect to
                        robotCommandServer = new LeTcpServer(this, "UR")
                        {
                            receiveCallback = GeneralCallback
                        };
                        if (robotCommandServer.Connect(ServerIpTxt.Text, "30000") > 0)
                        {
                            log.Error("Robot command server initialization failure");
                            RobotCommandStatusLbl.BackColor = Color.Red;
                            RobotCommandStatusLbl.Text = "Command Error";
                        }
                        else
                        {
                            log.Info("Robot command connection ready");

                            RobotCommandStatusLbl.BackColor = Color.Red;
                            RobotCommandStatusLbl.Text = "Command Waiting";
                        }
                    }
                    */
                    break;
                default:
                    log.Error("Unknown response to programstate: {0}", programstateResponse);
                    EnsureStopped();
                    buttonText = "Programstate: ?? " + programstateResponse;
                    color = Color.Red;
                    break;
            }
            RobotProgramStateBtn.Text = buttonText;
            RobotProgramStateBtn.BackColor = color;
        }

        private void CloseSafetyPopup()
        {
            ur_dashboard("close popup", 200);
            ur_dashboard("close safety popup", 200);
        }

        public void RobotSendHalt()
        {
            LeUrCommand.uiFocusInstance?.Send("(999)");
        }
        int robotSendIndex = 100;
        // Command is a 0-n element comma-separated list "x,y,z" of doubles
        // We send (index,x,y,z)
        public bool RobotSend(string command)
        {
            if (LeUrCommand.uiFocusInstance == null)
            {
                ErrorMessageBox($"RobotSend({command}) failed. focusLeUrCommand is null.");
                return false;
            }
            if (!LeUrCommand.uiFocusInstance.IsClientConnected)
            {
                ErrorMessageBox($"RobotSend({command}) failed. focusLeUrCommand is not connected.");
                return false;
            }
            if (!RobotProgramStateBtn.Text.StartsWith("PLAYING"))
            {
                ErrorMessageBox($"RobotSend({command}) failed. Program not running.");
                return false;
            }

            ++robotSendIndex;
            if (robotSendIndex > 999) robotSendIndex = 100;
            try  // This fails if the jog thread is calling it!
            {
                RobotSentLbl.Text = robotSendIndex.ToString();
                RobotSentLbl.Refresh();
                RobotCompletedLbl.BackColor = Color.Red;
                RobotCompletedLbl.Refresh();
            }
            catch { }

            int checkValue = 1000 - robotSendIndex;
            string sendMessage = string.Format("({0},{1},{2})", robotSendIndex, checkValue, command);
            log.Info($"UR==> EXEC RobotSend{sendMessage}");
            LeUrCommand.uiFocusInstance.Send(sendMessage);
            return true;
        }

        public bool PerformRobotCommand(string command)
        {
            // Handle all of the other robot commands (which just use send_robot, some prefix params, and any other specified params)
            // Example:
            // set_linear_speed(1.1) ==> RobotSend("30,1.1")
            // grind_rect(30,30,5,20,10) ==> RobotSend("40,20,30,30,5,20,10")
            // etc.

            // Find the commandName from commandName(parameters)
            int openParenIndex = command.IndexOf("(");
            int closeParenIndex = command.IndexOf(")");
            if (openParenIndex > -1 && closeParenIndex > openParenIndex)
            {
                string commandInSequence = command.Substring(0, openParenIndex);
                if (robotFunctionConversionDictionary.TryGetValue(commandInSequence, out CommandSpec commandSpec))
                {
                    string parameters = ExtractParameters(command, commandSpec.nParams);
                    // Must be all numeric: Really, all (nnn,nnn,nnn)
                    if (!Regex.IsMatch(parameters, @"^[()+-.,0-9]*$"))
                        ExecError("PerformRobotCommand: Incorrect parameters");
                    else
                    {
                        if (commandSpec.nParams == 0 && parameters.Length == 0)          // Expected 0 parameters and got nothing
                            RobotSend(commandSpec.prefix);
                        else if ((commandSpec.nParams > 0 && parameters.Length > 0) ||   // Got some parameters and must have been the right number
                                 (commandSpec.nParams == -1 && parameters.Length > 0)    // Willing to accept whatever you have (as long as there's something!)
                                )
                            RobotSend(commandSpec.prefix + "," + parameters);
                        else
                            ExecError($"PerformRobotCommand: Wrong number of operands. Expected {commandSpec.nParams}");
                    }
                    return true;
                }
            }
            return false;
        }

        // These Sequence function will be converted to send_robot(prefix,[nParams additional parameters])
        public readonly static Dictionary<string, CommandSpec> robotFunctionConversionDictionary = new Dictionary<string, CommandSpec>
        {
            // The main "send anything" command
            {"send_robot",                      new CommandSpec(){nParams=-1, prefix="" } },
            {"robot_socket_reset",              new CommandSpec(){nParams=0,  prefix="98" } },
            {"robot_program_exit",              new CommandSpec(){nParams=0,  prefix="99" } },

            {"get_actual_tcp_pose",             new CommandSpec(){nParams=0,  prefix="1,10" } },
            {"get_target_tcp_pose",             new CommandSpec(){nParams=0,  prefix="1,11" } },
            {"get_actual_joint_positions",      new CommandSpec(){nParams=0,  prefix="1,12" } },
            {"get_target_joint_positions",      new CommandSpec(){nParams=0,  prefix="1,13" } },
            {"get_actual_both",                 new CommandSpec(){nParams=0,  prefix="1,14" } },
            {"get_target_both",                 new CommandSpec(){nParams=0,  prefix="1,15" } },
            {"movej",                           new CommandSpec(){nParams=6,  prefix="1,16" } },
            {"movel",                           new CommandSpec(){nParams=6,  prefix="1,17" } },
            {"get_tcp_offset",                  new CommandSpec(){nParams=0,  prefix="1,18" } },

            {"movel_incr_base",                 new CommandSpec(){nParams=6,  prefix="1,20" } },
            {"movel_incr_tool",                 new CommandSpec(){nParams=6,  prefix="1,21" } },
            {"movel_incr_part",                 new CommandSpec(){nParams=6,  prefix="1,22" } },
            {"movel_single_axis",               new CommandSpec(){nParams=2,  prefix="1,30" } },
            {"movel_rot_only",                  new CommandSpec(){nParams=3,  prefix="1,31" } },
            {"movel_rel_set_tool_origin",       new CommandSpec(){nParams=6,  prefix="1,40" } },
            {"movel_rel_set_tool_origin_here",  new CommandSpec(){nParams=0,  prefix="1,40" } },
            {"movel_rel_set_part_origin",       new CommandSpec(){nParams=6,  prefix="1,41" } },
            {"movel_rel_set_part_origin_here",  new CommandSpec(){nParams=0,  prefix="1,41" } },
            {"movel_rel_tool",                  new CommandSpec(){nParams=6,  prefix="1,42" } },
            {"movel_rel_part",                  new CommandSpec(){nParams=6,  prefix="1,43" } },

            {"set_linear_speed",                new CommandSpec(){nParams=1,  prefix="30,1" } },
            {"set_linear_accel",                new CommandSpec(){nParams=1,  prefix="30,2" } },
            {"set_blend_radius",                new CommandSpec(){nParams=1,  prefix="30,3" } },
            {"set_joint_speed",                 new CommandSpec(){nParams=1,  prefix="30,4" } },
            {"set_joint_accel",                 new CommandSpec(){nParams=1,  prefix="30,5" } },
            {"set_part_geometry_N",             new CommandSpec(){nParams=2,  prefix="30,6" } },
            {"set_door_closed_input",           new CommandSpec(){nParams=2,  prefix="30,10" } },
            {"set_tool_on_outputs",             new CommandSpec(){nParams=-1, prefix="30,11" } },
            {"set_tool_off_outputs",            new CommandSpec(){nParams=-1, prefix="30,12" } },
            {"set_coolant_on_outputs",          new CommandSpec(){nParams=-1, prefix="30,13" } },
            {"set_coolant_off_outputs",         new CommandSpec(){nParams=-1, prefix="30,14" } },
            {"tool_on",                         new CommandSpec(){nParams=0,  prefix="30,15" } },
            {"tool_off",                        new CommandSpec(){nParams=0,  prefix="30,16" } },
            {"coolant_on",                      new CommandSpec(){nParams=0,  prefix="30,17" } },
            {"coolant_off",                     new CommandSpec(){nParams=0,  prefix="30,18" } },
            {"free_drive",                      new CommandSpec(){nParams=8,  prefix="30,19" } },
            {"set_tcp",                         new CommandSpec(){nParams=6,  prefix="30,20" } },
            {"set_payload",                     new CommandSpec(){nParams=4,  prefix="30,21" } },
            {"set_footswitch_pressed_input",    new CommandSpec(){nParams=2,  prefix="30,22" } },
            {"set_output",                      new CommandSpec(){nParams=2,  prefix="30,30" } },

            {"zero_cal_timers",                 new CommandSpec(){nParams=0,  prefix="30,40" } },
            {"default_cyline_cal",              new CommandSpec(){nParams=1,  prefix="30,41" } },
            {"unity_cyline_cal",                new CommandSpec(){nParams=0,  prefix="30,42" } },
            {"return_cyline_cal",               new CommandSpec(){nParams=0,  prefix="30,43" } },
            {"enable_cyline_cal",               new CommandSpec(){nParams=1,  prefix="30,44" } },
            {"set_cyline_training_weight",      new CommandSpec(){nParams=1,  prefix="30,45" } },
            {"set_cyline_expected_time",        new CommandSpec(){nParams=1,  prefix="30,46" } },
            {"set_cyline_deadband_time",        new CommandSpec(){nParams=1,  prefix="30,47" } },
            {"new_cyline_cycle",                new CommandSpec(){nParams=0,  prefix="30,48" } },

            {"enable_user_timers",              new CommandSpec(){nParams=1,  prefix="30,50" } },
            {"zero_user_timers",                new CommandSpec(){nParams=0,  prefix="30,51" } },
            {"return_user_timers",              new CommandSpec(){nParams=0,  prefix="30,52" } },

            {"grind_contact_enable",            new CommandSpec(){nParams=1,  prefix="35,1" } },
            {"grind_touch_retract",             new CommandSpec(){nParams=1,  prefix="35,2" } },
            {"grind_touch_speed",               new CommandSpec(){nParams=1,  prefix="35,3" } },
            {"grind_force_dwell",               new CommandSpec(){nParams=1,  prefix="35,4" } },
            {"grind_max_wait",                  new CommandSpec(){nParams=1,  prefix="35,5" } },
            {"grind_max_blend_radius",          new CommandSpec(){nParams=1,  prefix="35,6" } },
            {"grind_trial_speed",               new CommandSpec(){nParams=1,  prefix="35,7" } },
            {"grind_linear_accel",              new CommandSpec(){nParams=1,  prefix="35,8" } },
            {"grind_point_frequency",           new CommandSpec(){nParams=1,  prefix="35,9" } },
            {"grind_jog_speed",                 new CommandSpec(){nParams=1,  prefix="35,10" } },
            {"grind_jog_accel",                 new CommandSpec(){nParams=1,  prefix="35,11" } },
            {"grind_force_mode_damping",        new CommandSpec(){nParams=1,  prefix="35,12" } },
            {"grind_force_mode_gain_scaling",   new CommandSpec(){nParams=1,  prefix="35,13" } },

            {"grind_line",                      new CommandSpec(){nParams=6,  prefix="40,10" }  },
            {"grind_line_deg",                  new CommandSpec(){nParams=6,  prefix="40,11" }  },
            {"grind_rect",                      new CommandSpec(){nParams=6,  prefix="40,20" }  },
            {"grind_serp",                      new CommandSpec(){nParams=8,  prefix="40,30" }  },
            {"grind_poly",                      new CommandSpec(){nParams=6,  prefix="40,40" }  },
            {"grind_circle",                    new CommandSpec(){nParams=5,  prefix="40,45" }  },
            {"grind_spiral",                    new CommandSpec(){nParams=7,  prefix="40,50" }  },
            {"grind_retract",                   new CommandSpec(){nParams=0,  prefix="40,99" } },
        };


        private void SetLinearSpeedBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("robot_linear_speed_mmps"),
                Label = "Robot LINEAR SPEED, mm/s",
                NumberOfDecimals = 0,
                MinAllowed = 10,
                MaxAllowed = 500,
                Default = DEFAULT_linear_speed
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("set_linear_speed({0})", form.Value));
            }
        }

        private void SetLinearAccelBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("robot_linear_accel_mmpss"),
                Label = "Robot LINEAR ACCELERATION, mm/s^2",
                NumberOfDecimals = 0,
                MinAllowed = 10,
                MaxAllowed = 2000,
                Default = DEFAULT_linear_accel
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("set_linear_accel({0})", form.Value));
            }
        }

        private void SetBlendRadiusBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("robot_blend_radius_mm"),
                Label = "Robot BLEND RADIUS, mm",
                NumberOfDecimals = 1,
                MinAllowed = 0,
                MaxAllowed = 10,
                Default = DEFAULT_blend_radius
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("set_blend_radius({0})", form.Value));
            }
        }
        private void SetJointSpeedBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("robot_joint_speed_dps"),
                Label = "Robot JOINT SPEED, deg/s",
                NumberOfDecimals = 0,
                MinAllowed = 2,
                MaxAllowed = 45,
                Default = DEFAULT_joint_speed
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("set_joint_speed({0})", form.Value));
            }
        }

        private void SetJointAccelBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("robot_joint_accel_dpss"),
                Label = "Robot JOINT ACCELERATION, deg/s^2",
                NumberOfDecimals = 0,
                MinAllowed = 2,
                MaxAllowed = 180,
                Default = DEFAULT_joint_accel
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("set_joint_accel({0})", form.Value));
            }
        }
        private void SetMoveDefaultsBtn_Click(object sender, EventArgs e)
        {
            log.Info("SetMoveDefaultsBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the Default Motion Parameters. Proceed?"))
                return;

            ExecuteLEScriptLine(-1, String.Format("set_linear_speed({0})", DEFAULT_linear_speed));
            ExecuteLEScriptLine(-1, String.Format("set_linear_accel({0})", DEFAULT_linear_accel));
            ExecuteLEScriptLine(-1, String.Format("set_blend_radius({0})", DEFAULT_blend_radius));
            ExecuteLEScriptLine(-1, String.Format("set_joint_speed({0})", DEFAULT_joint_speed));
            ExecuteLEScriptLine(-1, String.Format("set_joint_accel({0})", DEFAULT_joint_accel));
        }

        private void SetTouchSpeedBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_touch_speed_mmps"),
                Label = "Grind TOUCH SPEED, mm/s",
                NumberOfDecimals = 1,
                MinAllowed = 1,
                MaxAllowed = 15,
                Default = DEFAULT_grind_touch_speed
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_touch_speed({0})", form.Value));
            }
        }

        private void SetTouchRetractBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_touch_retract_mm"),
                Label = "Grind TOUCH RETRACT DISTANCE, mm",
                NumberOfDecimals = 0,
                MinAllowed = 0,
                MaxAllowed = 10,
                Default = DEFAULT_grind_touch_retract
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_touch_retract({0})", form.Value));
            }
        }
        private void SetForceDwellBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_force_dwell_ms"),
                Label = "Grind FORCE DWELL TIME, mS",
                NumberOfDecimals = 0,
                MinAllowed = 0,
                MaxAllowed = 2000,
                Default = DEFAULT_grind_force_dwell
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_force_dwell({0})", form.Value));
            }
        }

        private void SetMaxWaitBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_max_wait_ms"),
                Label = "Grind MAX WAIT TIME, mS",
                NumberOfDecimals = 0,
                MinAllowed = 0,
                MaxAllowed = 3000,
                Default = DEFAULT_grind_max_wait
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_max_wait({0})", form.Value));
            }
        }
        private void SetMaxGrindBlendRadiusBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_max_blend_radius_mm"),
                Label = "Grind MAX BLEND RADIUS, mm",
                NumberOfDecimals = 1,
                MinAllowed = 0,
                MaxAllowed = 10,
                Default = DEFAULT_grind_max_blend_radius
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_max_blend_radius({0})", form.Value));
            }
        }
        private void SetTrialSpeedBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_trial_speed_mmps"),
                Label = "Grind TRIAL SPEED, mm/s",
                NumberOfDecimals = 0,
                MinAllowed = 1,
                MaxAllowed = 200,
                Default = DEFAULT_grind_trial_speed
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_trial_speed({0})", form.Value));
            }
        }
        private void SetGrindAccelBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_linear_accel_mmpss"),
                Label = "Grind ACCELERATION, mm/s^2",
                NumberOfDecimals = 0,
                MinAllowed = 10,
                MaxAllowed = 2000,
                Default = DEFAULT_grind_linear_accel
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_linear_accel({0})", form.Value));
            }
        }
        private void SetPointFrequencyBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_point_frequency_hz"),
                Label = "Grind POINT FREQUENCY, Hz",
                NumberOfDecimals = 0,
                MinAllowed = 0,
                MaxAllowed = 10,
                Default = DEFAULT_grind_point_frequency
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_point_frequency({0})", form.Value));
            }
        }
        private void SetGrindJogSpeedBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_jog_speed_mmps"),
                Label = "Grind JOG SPEED, mm/s",
                NumberOfDecimals = 0,
                MinAllowed = 10,
                MaxAllowed = 200,
                Default = DEFAULT_grind_jog_speed
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_jog_speed({0})", form.Value));
            }
        }
        private void SetGrindJogAccel_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_jog_accel_mmpss"),
                Label = "Grind JOG ACCEL, mm/s^2",
                NumberOfDecimals = 0,
                MinAllowed = 10,
                MaxAllowed = 2000,
                Default = DEFAULT_grind_jog_accel
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_jog_accel({0})", form.Value));
            }
        }

        private void SetForceModeDampingBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_force_mode_damping"),
                Label = "Grind FORCE MODE DAMPING",
                NumberOfDecimals = 3,
                MinAllowed = 0,
                MaxAllowed = 1,
                Default = DEFAULT_grind_force_mode_damping
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_force_mode_damping({0})", form.Value));
            }
        }

        private void SetForceModeGainScalingBtn_Click(object sender, EventArgs e)
        {
            SetValueForm form = new SetValueForm(this)
            {
                Value = ReadVariableDouble("grind_force_mode_gain_scaling"),
                Label = "Grind FORCE MODE GAIN SCALING",
                NumberOfDecimals = 3,
                MinAllowed = 0,
                MaxAllowed = 2,
                Default = DEFAULT_grind_force_mode_gain_scaling
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ExecuteLEScriptLine(-1, String.Format("grind_force_mode_gain_scaling({0})", form.Value));
            }
        }
        private void SetGrindDefaultsBtn_Click(object sender, EventArgs e)
        {
            log.Info("SetGrindDefaultsBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the Grinding Motion Parameters. Proceed?"))
                return;

            ExecuteLEScriptLine(-1, String.Format("grind_trial_speed({0})", DEFAULT_grind_trial_speed));
            ExecuteLEScriptLine(-1, String.Format("grind_linear_accel({0})", DEFAULT_grind_linear_accel));
            ExecuteLEScriptLine(-1, String.Format("grind_jog_speed({0})", DEFAULT_grind_jog_speed));
            ExecuteLEScriptLine(-1, String.Format("grind_jog_accel({0})", DEFAULT_grind_jog_accel));
            ExecuteLEScriptLine(-1, String.Format("grind_max_blend_radius({0})", DEFAULT_grind_max_blend_radius));
            ExecuteLEScriptLine(-1, String.Format("grind_touch_speed({0})", DEFAULT_grind_touch_speed));
            ExecuteLEScriptLine(-1, String.Format("grind_touch_retract({0})", DEFAULT_grind_touch_retract));
            ExecuteLEScriptLine(-1, String.Format("grind_force_dwell({0})", DEFAULT_grind_force_dwell));
            ExecuteLEScriptLine(-1, String.Format("grind_max_wait({0})", DEFAULT_grind_max_wait));
            ExecuteLEScriptLine(-1, String.Format("grind_point_frequency({0})", DEFAULT_grind_point_frequency));
            ExecuteLEScriptLine(-1, String.Format("grind_force_mode_damping({0})", DEFAULT_grind_force_mode_damping));
            ExecuteLEScriptLine(-1, String.Format("grind_force_mode_gain_scaling({0})", DEFAULT_grind_force_mode_gain_scaling));
        }


        private void RobotConnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void CloseCommandServer()
        {
            // Stop us if we're running!
            if (runState == RunState.RUNNING || runState == RunState.PAUSED)
            {
                SetState(RunState.READY);
            }

            if (LeUrCommand.uiFocusInstance?.IsConnected() == true)
            {
                if (RobotProgramStateBtn.Text.StartsWith("PLAYING")) RobotSend("98");
                LeUrCommand.uiFocusInstance.Disconnect();
                LeUrCommand.uiFocusInstance = null;
            }
            RobotCommandStatusLbl.BackColor = Color.Red;
            RobotCommandStatusLbl.Text = "OFF";
        }

        private void ProgramStateBtn_Click(object sender, EventArgs e)
        {
            CloseSafetyPopup();
            if (RobotProgramStateBtn.Text.StartsWith("PLAYING"))
            {
                RobotSend("99");
                LeUrDashboard.uiFocusInstance?.Send("stop");
                RobotCommandStatusLbl.BackColor = Color.Red;
                RobotCommandStatusLbl.Text = "OFF";
                RobotReadyLbl.BackColor = Color.Red;
                GrindReadyLbl.BackColor = Color.Red;
                GrindProcessStateLbl.BackColor = Color.Red;
                CloseCommandServer();
            }
            else
            {
                LeUrDashboard.uiFocusInstance?.Send("play");
            }
        }
        #endregion ===== UR INTERFACE CODE                 ==============================================================================================================================

        #region ===== GOCATOR INTERFACE CODE            ==============================================================================================================================
        public void GocatorAnnounce()
        {
            log.Debug($"GocatorAnnounce nInstances={LeGocator.nInstances}");
            if (LeGocator.nInstances < 1)
            {
                GocatorConnectedLbl.Visible = false;
                GocatorReadyLbl.Visible = false;
                return;
            }
            else
            {
                GocatorConnectedLbl.Visible = true;
                GocatorReadyLbl.Visible = true;
            }

            LeGocator.Status status = LeGocator.Status.ERROR;
            if (LeGocator.uiFocusInstance != null)
                status = LeGocator.uiFocusInstance.status;
            switch (status)
            {
                case LeGocator.Status.OK:
                    GocatorConnectedLbl.Text = "Gocator OK";
                    GocatorConnectedLbl.BackColor = Color.Green;
                    GocatorReadyLbl.BackColor = Color.Green;
                    log.Info("Gocator connection READY");
                    break;
                case LeGocator.Status.ERROR:
                    GocatorConnectedLbl.Text = "Gocator ERROR";
                    GocatorConnectedLbl.BackColor = Color.Red;
                    GocatorReadyLbl.BackColor = Color.Red;
                    log.Error("Gocator connection ERROR");
                    break;
                case LeGocator.Status.OFF:
                    GocatorConnectedLbl.Text = "Gocator OFF";
                    GocatorConnectedLbl.BackColor = Color.Red;
                    GocatorReadyLbl.BackColor = Color.Red;
                    log.Info("Gocator connection OFF");
                    break;
                default:
                    GocatorConnectedLbl.Text = "Gocator ???";
                    GocatorConnectedLbl.BackColor = Color.Yellow;
                    GocatorReadyLbl.BackColor = Color.Yellow;
                    break;
            }
        }
        int gocator_send(string message)
        {
            if (LeGocator.uiFocusInstance == null)
            {
                ExecError("gocator_send: No Gocator selected");
                return 1;
            }

            LeGocator.uiFocusInstance.Send(message);
            return 0;
        }
        int gocator_trigger(int preDelay_ms)
        {
            if (LeGocator.uiFocusInstance == null)
            {
                ExecError("gocator_trigger: No Gocator selected");
                return 1;
            }

            LeGocator.uiFocusInstance.Trigger(preDelay_ms);
            GocatorReadyLbl.BackColor = ColorFromBooleanName("False");
            GocatorReadyLbl.Refresh();
            return 0;
        }
        int gocator_adjust(int version)
        {
            if (LeGocator.uiFocusInstance == null)
            {
                ExecError("gocator_adjust: No Gocator selected");
                return 1;
            }

            double dx = 0;
            double dy = 0;
            double dz = 0;
            double drx = 0;
            double dry = 0;
            if (ReadVariableInt("gc_decision", 2) == 0)
            {
                log.Info("gocator_adjust() using counterbore");
                dx = Convert.ToDouble(ReadVariable("gc_offset_x", "0")) / 1000000.0;
                dy = Convert.ToDouble(ReadVariable("gc_offset_y", "0")) / 1000000.0;
                dz = -Convert.ToDouble(ReadVariable("gc_offset_z", "0")) / 1000000.0;
                drx = -Convert.ToDouble(ReadVariable("gc_xangle", "0")) / 1000.0;
                dry = Convert.ToDouble(ReadVariable("gc_yangle", "0")) / 1000.0;
            }
            else if (ReadVariableInt("gh_decision", 2) == 0)
            {
                log.Info("gocator_adjust() using thru hole");
                dx = Convert.ToDouble(ReadVariable("gh_offset_x", "0")) / 1000000.0;
                dy = Convert.ToDouble(ReadVariable("gh_offset_y", "0")) / 1000000.0;
                dz = -Convert.ToDouble(ReadVariable("gh_offset_z", "0")) / 1000000.0;
                drx = -Convert.ToDouble(ReadVariable("gp_xangle", "0")) / 1000.0;
                dry = Convert.ToDouble(ReadVariable("gp_yangle", "0")) / 1000.0;
            }

            double abs_dx = Math.Abs(dx);
            double abs_dy = Math.Abs(dy);
            double abs_dz = Math.Abs(dz);
            double abs_drx = Math.Abs(drx);
            double abs_dry = Math.Abs(dry);

            double deg2rad(double x)
            {
                return x * Math.PI / 180.0;
            }

            log.Info($"gocator_adjust All Values: [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
            switch (version)
            {
                case 1:
                    if (abs_dx > 0.020 || abs_dy > 0.020 || abs_dz > 0.020)
                    {
                        ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, 0, 0, 0]");
                        return 2;
                    }
                    else
                    {
                        PerformRobotCommand($"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},0,0,0)");
                        return 0;
                    }
                case 2:
                    if (abs_drx > 15 || abs_dry > 15)
                    {
                        ExecError($"Excessive gocator_adjust [0, 0, 0, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        return 3;
                    }
                    else
                    {
                        PerformRobotCommand($"movel_incr_tool(0,0,0,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        return 0;
                    }
                case 3:
                    if (abs_dx > 0.020 || abs_dy > 0.020 || abs_dz > 0.020 ||
                        abs_drx > 15 || abs_dry > 15)
                    {
                        ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        return 4;
                    }
                    else
                    {
                        PerformRobotCommand($"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},0,0,0)");
                        // TODO this should be a wait complete
                        Thread.Sleep(1000);
                        PerformRobotCommand($"movel_incr_tool(0,0,0,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        return 0;
                    }
                case 4:
                    if (abs_dx > 0.020 || abs_dy > 0.020 || abs_dz > 0.020 ||
                        abs_drx > 15 || abs_dry > 15)
                    {
                        ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        return 5;
                    }
                    else
                    {
                        ExecuteLEScriptLine(-1, $"movel_incr_tool({dx}:0.000000,{dy}:0.000000,{dz}:0.000000,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        return 0;
                    }
                default:
                    return 6;
            }
        }
        int gocator_write_data(string filename, string tagName)
        {
            string full_filename = System.IO.Path.Combine(LEonardRoot, DataFolder, filename);
            full_filename = System.IO.Path.ChangeExtension(full_filename, ".csv");

            try
            {
                StreamWriter writer;
                if (!File.Exists(full_filename))
                {
                    writer = new StreamWriter(full_filename);
                    string gc_headers = "timestamp,gocator_ID,gc_decision,gc_offset_x,gc_offset_y,gc_offset_z,gc_outer_radius,gc_depth,dc_bevel_radius,gc_bevel_angle,gc_xangle,gc_yangle,gc_cb_depth,gc_axis_tilt,gc_axis_orient";
                    string gc_units = ",,,in,in,in,in,in,in,deg,deg,deg,in,deg,deg";
                    string gh_headers = "gh_decision,gh_offset_x,gh_offset_y,gh_offset_z,gh_radius";
                    string gh_units = ",in,in,in,in";
                    string gp_headers = "gp_xangle,gp_yangle,gp_z_offset,gp_std_dev";
                    string gp_units = "deg,deg,in,in";
                    string headers = gc_headers + "," + gh_headers + "," + gp_headers;
                    string units = gc_units + "," + gh_units + "," + gp_units;

                    writer.WriteLine(headers);
                    writer.WriteLine(units);
                }
                else
                    writer = new StreamWriter(full_filename, true);

                string GetRaw(string name)
                {
                    return ReadVariable(name, "??");
                }
                string GetDist(string name, double scale = 39.3701)
                {
                    try
                    {
                        double x = Convert.ToDouble(ReadVariable(name, "999")) * scale / 1000000.0;
                        return x.ToString("0.0000");
                    }
                    catch
                    {
                        return "INVALID";
                    }
                }
                string GetAngle(string name, double scale = 1.0)
                {
                    try
                    {
                        double x = Convert.ToDouble(ReadVariable(name, "999")) * scale / 1000.0;
                        return x.ToString("0.0");
                    }
                    catch
                    {
                        return "INVALID";
                    }
                }

                string output = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                output += $",{tagName},{GetRaw("gc_decision")},{GetDist("gc_offset_x")},{GetDist("gc_offset_y")},{GetDist("gc_offset_z")}";
                output += $",{GetDist("gc_outer_radius")},{GetAngle("gc_depth")},{GetAngle("gc_bevel_radius")},{GetAngle("gc_bevel_angle")},{GetAngle("gc_xangle")},{GetAngle("gc_yangle")}";
                output += $",{GetDist("gc_cb_depth")},{GetAngle("gc_axis_tilt")},{GetAngle("gc_axis_orient")}";
                output += $",{GetRaw("gh_decision")},{GetDist("gh_offset_x")},{GetDist("gh_offset_y")},{GetDist("gh_offset_z")},{GetDist("gh_radius")}";
                output += $",{GetAngle("gp_xangle")},{GetAngle("gp_yangle")},{GetDist("gp_z_offset")},{GetDist("gp_std_dev")}";
                writer.WriteLine(output);

                writer.Close();
                return 0;
            }
            catch
            {
                ExecError($"write_gocator_data(...) cannot write to\n{full_filename}");
                return 1;
            }
        }

        #endregion ===== GOCATOR INTERFACE CODE            ==============================================================================================================================
    }
}

