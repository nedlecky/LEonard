// File: MainForm.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: The main code window for the LEonard program

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using NLog;

namespace LEonard
{
    public partial class MainForm : Form
    {
        private static NLog.Logger log;
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static string LEonardRoot = null;
        Jint.Engine javaEngine;
        Microsoft.Scripting.Hosting.ScriptEngine pythonEngine;
        Microsoft.Scripting.Hosting.ScriptScope pythonScope;
        Protection protection;

        // TODO should be replaced with generic devices interface (in progress below)
        LeTcpServer focusLeUrCommand = null;
        LeTcpClient focusLeUrDashboard = null;
        LeGocator focusLeGocator = null;
        FileManager fileManager = null;

        // TODO: This needs to dynamically resize and the code that does it doesn't!!
        // These map 1:1 with the rows in devices.... I hope (Using ID field in row but this is a bit fragile)
        LeDeviceInterface[] interfaces = { null, null, null, null, null, null, null, null, null, null, null };
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
        const string DEFAULT_LEonardRoot = "C:\\LEonard";
        const string DEFAULT_RobotProgramTxt = "LEonard/LEonard01.urp";
        const string DEFAULT_RobotIpTxt = "192.168.0.2";
        const string DEFAULT_ServerIpTxt = "192.168.0.252";
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

        public MainForm()
        {
            InitializeComponent();

            InitializeJavaEngine();
            InitializePythonEngine();
        }

        // Lists of all controls that get tweaked in UI management
        IEnumerable<Control> allFontResizableList;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Startup logging system (which also displays messages)
            log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("MainForm_Load(...)");

            string companyName = Application.CompanyName;
            string appName = Application.ProductName;
            string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string executable = Application.ExecutablePath;
            string filename = Path.GetFileName(executable);
            executionRoot = Path.GetDirectoryName(executable);
            string caption = appName + " Rev " + productVersion;
#if DEBUG
            caption += " DEBUG";
#endif
            this.Text = caption;
            VersionLbl.Text = caption;

            // Check screen dimensions.....
            // TODO Good SPOT FOR DONGLE CHECK
            Rectangle r = Screen.FromControl(this).Bounds;
            log.Info("Screen Dimensions: {0}x{1}", r.Width, r.Height);
            if (r.Width < screenDesignWidth || r.Height < screenDesignHeight)
            {
                DialogResult result = ConfirmMessageBox(String.Format("Screen dimensions for this application must be at least {0} x {1}. Continue anyway?", screenDesignWidth, screenDesignHeight));
                if (result != DialogResult.OK)
                {
                    forceClose = true;
                    Close();
                    return;
                }
            }

            LoadRootDirectory();

            // Set logfile variable in NLog
            LogManager.Configuration.Variables["LogfileName"] = LEonardRoot + "/Logs/LEonard.log";
            LogManager.ReconfigExistingLoggers();

            allFontResizableList = TakeControlInventory(this);

            LoadPersistent();

            splashForm = new SplashForm(this)
            {
                AutoClose = true,
            };

            // Flag that we're starting
            log.Info("================================================================");
            log.Info(string.Format("Starting {0} in [{1}]", filename, executionRoot));
            log.Info(caption);
            log.Info("================================================================");

            UserModeBox.SelectedIndex = (int)operatorMode;

            // 1-second tick
            HeartbeatTmr.Interval = 1000;
            HeartbeatTmr.Enabled = true;

            // Real start of everyone will happen shortly
            StartupTmr.Interval = 2000;
            StartupTmr.Enabled = true;

            SetRecipeState(RecipeState.NEW);
            SetState(RunState.IDLE);
            // TODO Is this OK... how do we get to READY!
            SetState(RunState.READY);

            ResumeLayout();

            licenseFilename = Path.Combine(LEonardRoot, "license.txt");
            protection = new Protection(this, licenseFilename);
        }

        // Function key shortcut handling (primarily for development testing assistance)
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
            }
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (!uiUpdatesAreLive) return;

            // Scale to the lesser of the implied Width and Height scales
            double widthScale = 100.0 * (double)Width / (double)screenDesignWidth;
            double heightScale = 100.0 * (double)Height / (double)screenDesignHeight;
            suggestedSystemScale = Math.Min(widthScale, heightScale);

            // Scale up by maximum maxFontScaleUpPct
            suggestedSystemScale = Math.Min(suggestedSystemScale, maxFontScaleUpPct);

            log?.Info($"MainForm Resize to {Width} x {Height}");
            log?.Info($"Resizing font to {suggestedSystemScale}%");

            ScaleUiText(suggestedSystemScale);
        }


        private void StartupTmr_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(250);
            splashForm.Show();

            log.Info("StartupTmr()...");
            StartupTmr.Enabled = false;

            MessageTmr.Interval = 100;
            MessageTmr.Enabled = true;

            //StartThreads();

            // TODO this should happen in devices
            // Connect to the robot and Gocator
            if (StartupDevicesLbl.Text.Length > 0)
            {
                LoadDevicesFile(StartupDevicesLbl.Text);
            }
            //RobotConnectBtn_Click(null, null);
            //GocatorConnectBtn_Click(null, null);

            // Load the last recipe if there was one loaded in LoadPersistent()
            if (recipeFileToAutoload != "")
                if (LoadRecipeFile(recipeFileToAutoload))
                {
                    SetRecipeState(RecipeState.LOADED);
                    SetState(RunState.READY);
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
            this.Close();
        }

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
            log.Error($"ErrorMessageBox({message})");
            MessageDialog messageForm = new MessageDialog(this)
            {
                Title = "System ERROR",
                Label = message,
                OkText = "&OK",
                CancelText = "&Cancel"
            };
            DialogResult result = messageForm.ShowDialog();
            return result;
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
                if (RecipeWasModified())
                {
                    var result = ConfirmMessageBox($"Closing Application!\nRecipe [{LoadRecipeBtn.Text}] has changed.\nSave changes before exit?");
                    if (result == DialogResult.OK)
                        SaveRecipeBtn_Click(null, null);
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

        static bool robotReady = false;
        static DateTime runStartedTime;   // When did the user hit run?
        static DateTime stepStartedTime;  // When did the current recipe line start executing?
        static DateTime stepEndTimeEstimate;  // When do we think it will end?
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

        private void HeartbeatTmr_Tick(object sender, EventArgs e)
        {
            // Update current time
            Time2Lbl.Text = TimeLbl.Text = DateTime.Now.ToString();

            // Update elapsed time panel
            if (runState == RunState.RUNNING || runState == RunState.PAUSED)
                RecomputeTimes();

            // DASHBOARD Handler: Round-robin sending the Dashboard monitoring commands
            if (focusLeUrDashboard != null)
                if (!focusLeUrDashboard.IsConnected())
                {
                    RobotConnectBtn.Text = "Dashboard ERROR";
                    RobotConnectBtn.BackColor = Color.Red;
                }
                else
                {
                    // Any responses received?
                    string dashResponse = focusLeUrDashboard.Receive();
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
                            focusLeUrDashboard.Send("robotmode");
                            focusLeUrDashboard.Send("safetystatus");
                            nUnansweredRobotmodeRequests++;
                            nUnansweredSafetystatusRequests++;
                            break;
                        case 1:
                            focusLeUrDashboard.Send("programstate");
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
            if (focusLeUrCommand == null)
                robotReady = false;
            else
            {
                if (focusLeUrCommand.IsClientConnected)
                    newRobotReady = true;

                if (newRobotReady != robotReady)
                {
                    robotReady = newRobotReady;
                    if (robotReady)
                    {
                        log.Info("Changing robot connection to READY");

                        // Send persistent values (or defaults) for speeds, accelerations, I/O, etc.
                        ExecuteLine(-1, "grind_contact_enable(0)");  // Set contact enabled = No Touch No Grind
                        ExecuteLine(-1, "grind_retract()");  // Ensure we're not on the part
                        ExecuteLine(-1, string.Format("set_linear_speed({0})", ReadVariable("robot_linear_speed_mmps", DEFAULT_linear_speed)));
                        ExecuteLine(-1, string.Format("set_linear_accel({0})", ReadVariable("robot_linear_accel_mmpss", DEFAULT_linear_accel)));
                        ExecuteLine(-1, string.Format("set_blend_radius({0})", ReadVariable("robot_blend_radius_mm", DEFAULT_blend_radius)));
                        ExecuteLine(-1, string.Format("set_joint_speed({0})", ReadVariable("robot_joint_speed_dps", DEFAULT_joint_speed)));
                        ExecuteLine(-1, string.Format("set_joint_accel({0})", ReadVariable("robot_joint_accel_dpss", DEFAULT_joint_accel)));
                        ExecuteLine(-1, string.Format("set_door_closed_input({0})", ReadVariable("robot_door_closed_input", DEFAULT_door_closed_input).Trim(new char[] { '[', ']' })));
                        ExecuteLine(-1, string.Format("set_footswitch_pressed_input({0})", ReadVariable("robot_footswitch_pressed_input", DEFAULT_footswitch_pressed_input).Trim(new char[] { '[', ']' })));


                        ExecuteLine(-1, string.Format("grind_trial_speed({0})", ReadVariable("grind_trial_speed_mmps", DEFAULT_grind_trial_speed)));
                        ExecuteLine(-1, string.Format("grind_linear_accel({0})", ReadVariable("grind_linear_accel_mmpss", DEFAULT_grind_linear_accel)));
                        ExecuteLine(-1, string.Format("grind_jog_speed({0})", ReadVariable("grind_jog_speed_mmps", DEFAULT_grind_jog_speed)));
                        ExecuteLine(-1, string.Format("grind_jog_accel({0})", ReadVariable("grind_jog_accel_mmpss", DEFAULT_grind_jog_accel)));
                        ExecuteLine(-1, string.Format("grind_max_blend_radius({0})", ReadVariable("grind_max_blend_radius_mm", DEFAULT_grind_max_blend_radius)));
                        ExecuteLine(-1, string.Format("grind_touch_speed({0})", ReadVariable("grind_touch_speed_mmps", DEFAULT_grind_touch_speed)));
                        ExecuteLine(-1, string.Format("grind_touch_retract({0})", ReadVariable("grind_touch_retract_mm", DEFAULT_grind_touch_retract)));
                        ExecuteLine(-1, string.Format("grind_force_dwell({0})", ReadVariable("grind_force_dwell_ms", DEFAULT_grind_force_dwell)));
                        ExecuteLine(-1, string.Format("grind_max_wait({0})", ReadVariable("grind_max_wait_ms", DEFAULT_grind_max_wait)));
                        ExecuteLine(-1, string.Format("grind_point_frequency({0})", ReadVariable("grind_point_frequency_hz", DEFAULT_grind_point_frequency)));
                        ExecuteLine(-1, string.Format("grind_force_mode_damping({0})", ReadVariable("grind_force_mode_damping", DEFAULT_grind_force_mode_damping)));
                        ExecuteLine(-1, string.Format("grind_force_mode_gain_scaling({0})", ReadVariable("grind_force_mode_gain_scaling", DEFAULT_grind_force_mode_gain_scaling)));
                        ExecuteLine(-1, "enable_cyline_cal(0)");

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
                        RobotCommandStatusLbl.BackColor = Color.Red;
                        RobotCommandStatusLbl.Text = "WAIT";
                        // Restore all button settings with same current state
                        SetState(runState, true);
                        EnsureNotRunning();
                    }
                }

            }
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
            SafetyStatusBtn.Text = buttonText.Replace('_', ' ');
            SafetyStatusBtn.BackColor = color;
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
                    EnsureStopped();
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
            ProgramStateBtn.Text = buttonText;
            ProgramStateBtn.BackColor = color;
        }


        // ===================================================================
        // START MAIN UI BUTTONS
        // ===================================================================

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
                    UrLogRTB.Refresh();
                    UrDashboardLogRTB.Refresh();
                    ErrorLogRTB.Refresh();
                }
            }
        }
        // Prevents selecting (seeing) a tab page that is not enabled
        private void MainTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex < 0) return;
            e.Cancel = !e.TabPage.Enabled;
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
            LoadPositionsBtn.Enabled = f;
            SavePositionsBtn.Enabled = f;
            ClearAllPositionsBtn.Enabled = f;
            ClearPositionsBtn.Enabled = f;
            LoadVariablesBtn.Enabled = f;
            SaveVariablesBtn.Enabled = f;
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
                    SafetyStatusBtn.Enabled = true;
                    ProgramStateBtn.Enabled = true;


                    UserModeBox.Enabled = true;

                    ExitBtn.Enabled = true;

                    SetManualMoveButtons(true);
                    SetVariableEditing(true);

                    LoadRecipeBtn.Enabled = true;
                    NewRecipeBtn.Enabled = true;
                    SaveRecipeBtn.Enabled = RecipeWasModified();
                    SaveAsRecipeBtn.Enabled = true;

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
                    RecipeRTB.Enabled = true;
                    break;
                case RunState.READY:
                    RunStateLbl.Text = "STOPPED";
                    RunStateLbl.BackColor = Color.Red;
                    sleepTimer = null; // Cancels any pending sleep(...)

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = true;
                    RobotModeBtn.Enabled = true;
                    SafetyStatusBtn.Enabled = true;
                    ProgramStateBtn.Enabled = true;

                    UserModeBox.Enabled = true;

                    ExitBtn.Enabled = true;

                    SetManualMoveButtons(true);
                    SetVariableEditing(true);

                    LoadRecipeBtn.Enabled = true;
                    NewRecipeBtn.Enabled = true;
                    SaveRecipeBtn.Enabled = RecipeWasModified();
                    SaveAsRecipeBtn.Enabled = true;

                    SetupTab.Enabled = true;

                    StartBtn.Enabled = true;
                    StepBtn.Enabled = true;
                    PauseBtn.Enabled = false;
                    StopBtn.Enabled = false;
                    GrindContactEnabledBtn.Enabled = true;

                    MountedToolBox.Enabled = true;
                    PartGeometryBox.Enabled = true;
                    DiameterLbl.Enabled = true;

                    ExecTmr.Enabled = false;
                    //CurrentLineLbl.Text = "";
                    RecipeRTB.Enabled = true;

                    fileManager?.AllClose();
                    break;
                case RunState.RUNNING:
                    log.Info($"Clearing callStack (had {callStack.Count} items");
                    callStack.Clear();

                    RunStateLbl.Text = "RUNNING";
                    RunStateLbl.BackColor = Color.Green;
                    sleepTimer = null; // Cancels any pending sleep(...)

                    // Robot Communication Control
                    RobotConnectBtn.Enabled = false;
                    RobotModeBtn.Enabled = false;
                    SafetyStatusBtn.Enabled = false;
                    ProgramStateBtn.Enabled = false;

                    UserModeBox.Enabled = false;

                    ExitBtn.Enabled = false;

                    SetManualMoveButtons(false);
                    SetVariableEditing(false);

                    LoadRecipeBtn.Enabled = false;
                    NewRecipeBtn.Enabled = false;
                    SaveRecipeBtn.Enabled = false;
                    SaveAsRecipeBtn.Enabled = false;

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
                    RecipeRTB.Enabled = false;

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
                    SafetyStatusBtn.Enabled = true;
                    ProgramStateBtn.Enabled = true;

                    UserModeBox.Enabled = false;

                    ExitBtn.Enabled = false;

                    SetManualMoveButtons(false);
                    SetVariableEditing(false);

                    LoadRecipeBtn.Enabled = false;
                    NewRecipeBtn.Enabled = false;
                    SaveRecipeBtn.Enabled = false;
                    SaveAsRecipeBtn.Enabled = false;

                    SetupTab.Enabled = true;

                    StartBtn.Enabled = false;
                    StepBtn.Enabled = true;
                    PauseBtn.Enabled = true;
                    PauseBtn.Text = "Continue";
                    StopBtn.Enabled = true;
                    GrindContactEnabledBtn.Enabled = true;

                    MountedToolBox.Enabled = false;
                    PartGeometryBox.Enabled = false;
                    DiameterLbl.Enabled = false;

                    RecipeRTB.Enabled = false;

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

            ColorEnableButtonGreen(LoadRecipeBtn);
            ColorEnableButtonGreen(NewRecipeBtn);
            ColorEnableButtonGreen(SaveRecipeBtn);
            ColorEnableButtonGreen(SaveAsRecipeBtn);

            ColorEnableButtonGreen(StartBtn);
            ColorEnableButton(PauseBtn, Color.DarkOrange);
            ColorEnableButtonGreen(StepBtn);
            ColorEnableButton(StopBtn, Color.Red);

            ColorEnableButtonGreen(BigEditBtn);
            ColorEnableButtonGreen(LoadPositionsBtn);
            ColorEnableButtonGreen(SavePositionsBtn);
            ColorEnableButtonGreen(ClearAllPositionsBtn);
            ColorEnableButtonGreen(ClearPositionsBtn);
            ColorEnableButtonGreen(LoadVariablesBtn);
            ColorEnableButtonGreen(SaveVariablesBtn);
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
            if (focusLeUrCommand != null)
                ExecuteLine(-1, String.Format("select_tool({0})", MountedToolBox.Text));
        }

        private void UpdateGeometryToRobot()
        {
            if (focusLeUrCommand != null)
            {
                ExecuteLine(-1, String.Format("set_part_geometry_N({0},{1})", PartGeometryBox.SelectedIndex + 1, DiameterLbl.Text));
                WriteVariable("robot_geometry", String.Format("{0},{1}", PartGeometryBox.SelectedItem, DiameterLbl.Text));
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
                // Position Test Buttons
                //new ControlSpec(PositionTestButtonGrp, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(LoadPositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(SavePositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearPositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearAllPositionsBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),

                // Variable Test Buttons
                //new ControlSpec(VariableTestButtonGrp, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(LoadVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(SaveVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
                new ControlSpec(ClearAllVariablesBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),

                // Set Position Button
                new ControlSpec(PositionSetBtn, ControlSetting.HIDDEN, ControlSetting.DISABLED, ControlSetting.NORMAL),
            };

        }

        private void OperatorModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlSpecs == null) BuildEnableTable();

            OperatorMode origOperatorMode = operatorMode;
            OperatorMode newOperatorMode = (OperatorMode)UserModeBox.SelectedIndex;

#if !DEBUG
            // Enforce any password requirements (unless we're in DEBUG for convenience)
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
#endif
            operatorMode = newOperatorMode;

            const int RunPage = 0;
            const int ProgramPage = 1;
            const int SetupPage = 2;
            const int LogPage = 3;
            if (MainTab.TabPages[1] != null)  // Helps during program load before instantiation!
            {
                log.Info("Setting Operator Mode {0}", operatorMode);
                switch (operatorMode)
                {
                    case OperatorMode.OPERATOR:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[ProgramPage].Enabled = false;
                        MainTab.TabPages[SetupPage].Enabled = false;
                        MainTab.TabPages[LogPage].Enabled = true;
                        MainTab.SelectedIndex = 0;
                        break;
                    case OperatorMode.EDITOR:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[ProgramPage].Enabled = true;
                        MainTab.TabPages[SetupPage].Enabled = false;
                        MainTab.TabPages[LogPage].Enabled = true;
                        MainTab.SelectedIndex = 1;
                        break;
                    case OperatorMode.ENGINEERING:
                        MainTab.TabPages[RunPage].Enabled = true;
                        MainTab.TabPages[ProgramPage].Enabled = true;
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
                    focusLeUrDashboard?.Send("power off");
                    break;
                case "Robotmode: IDLE":
                    focusLeUrDashboard?.Send("brake release");
                    break;
                case "Robotmode: POWER_OFF":
                    focusLeUrDashboard?.Send("power on");
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
            switch (SafetyStatusBtn.Text)
            {
                case "Safetystatus: NORMAL":
                    focusLeUrDashboard?.Send("power off");
                    break;
                case "Safetystatus: PROTECTIVE STOP":
                    UrDashboardInquiryResponse("unlock protective stop", 200);
                    UrDashboardInquiryResponse("close safety popup", 200);

                    break;
                case "Safetystatus: ROBOT EMERGENCY STOP":
                    ErrorMessageBox("Release Robot E-Stop");
                    UrDashboardInquiryResponse("close safety popup", 200);
                    break;
                default:
                    log.Error("Unknown safety status button state! {0}", SafetyStatusBtn.Text);
                    ErrorMessageBox(String.Format("Unsure how to recover from {0}", SafetyStatusBtn.Text));
                    break;
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UrLogRTB_DoubleClick(object sender, EventArgs e)
        {
            UrLogRTB.Clear();
        }

        private void UrDashboardLogRTB_DoubleClick(object sender, EventArgs e)
        {
            UrDashboardLogRTB.Clear();
        }

        private void ErrorLogRTB_DoubleClick(object sender, EventArgs e)
        {
            ErrorLogRTB.Clear();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            SplashForm splashForm = new SplashForm(this)
            {
                AutoClose = false
            };
            splashForm.ShowDialog();
        }


        // ===================================================================
        // END MAIN UI BUTTONS
        // ===================================================================



        // ===================================================================
        // START RUN
        // ===================================================================

        private void GrindContactEnabledBtn_Click(object sender, EventArgs e)
        {
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

            // This allows offline dry runs but makes sure you know!
            /*
            if (!robotReady)
            {
                if (AllowRunningOfflineChk.Checked)
                {
                    var result = ConfirmMessageBox("Robot not connected.\nRun anyway?");
                    if (result != DialogResult.OK) return false;
                }
                else
                {
                    ErrorMessageBox("Robot not connected.\nRunning not allowed per Setup checkbox.");
                    return false;
                }
            }
            */

            // Gocator
            // TODO this needs to be generalized
            focusLeGocator?.PrepareToRun();

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
                SetRecipeState(RecipeState.RUNNING);
                SetState(RunState.RUNNING);
            }
        }

        private void RobotAndSystemPause()
        {
            RobotSendHalt();
            SetState(RunState.PAUSED);
        }
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            log.Info("PauseBtn{0}_Click(...)", PauseBtn.Text);
            switch (runState)
            {
                case RunState.RUNNING:
                    // Perform PAUSE function
                    RobotAndSystemPause();
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
                        SetRecipeState(RecipeState.RUNNING);
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

            UnboldRecipe();
            SetState(RunState.READY);
            SetRecipeState(recipeStateAtRun);
        }


        // ===================================================================
        // END RUN
        // ===================================================================

        // ===================================================================
        // START SETUP
        // ===================================================================
        private void DefaultConfigBtn_Click(object sender, EventArgs e)
        {
            log.Info("DefaultConfigBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the General Configuration settings. Proceed?"))
                return;

            LEonardRoot = DEFAULT_LEonardRoot;
            LEonardRootLbl.Text = LEonardRoot;
            AllowRunningOfflineChk.Checked = false;
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

        private void AllowRunningOfflineChk_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowRunningOfflineChk.Checked)
                AllowRunningOfflineChk.BackColor = Color.Green;
            else
                AllowRunningOfflineChk.BackColor = Color.Gray;
        }

        public void MakeStandardSubdirectories()
        {
            // Make standard subdirectories (if they don't exist)
            System.IO.Directory.CreateDirectory(Path.Combine(LEonardRoot, "Devices"));
            System.IO.Directory.CreateDirectory(Path.Combine(LEonardRoot, "Recipes"));
            System.IO.Directory.CreateDirectory(Path.Combine(LEonardRoot, "Data"));
            System.IO.Directory.CreateDirectory(Path.Combine(LEonardRoot, "Logs"));
        }

        public RegistryKey GetAppNameKey()
        {
            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey LeckyEngineeringKey = SoftwareKey.CreateSubKey("Lecky Engineering");
            return LeckyEngineeringKey.CreateSubKey("LEonard");
        }

        void LoadRootDirectory()
        {
            RegistryKey AppNameKey = GetAppNameKey();

            LEonardRoot = (string)AppNameKey.GetValue("LEonardRoot", "C:\\LEonard");

            // Suggested root?
            string suggestedRoot = Path.GetFullPath(Path.Combine(executionRoot, "../../.."));
            log.Info("Current root is {0}", LEonardRoot);
            log.Info("Suggested root is {0}", suggestedRoot);

            if (LEonardRoot != suggestedRoot)
            {
                DialogResult result = ConfirmMessageBox($"Root is set to\n{LEonardRoot}\nYou are executing out of\n{suggestedRoot}\nChange?");
                if (result == DialogResult.OK)
                {
                    LEonardRoot = suggestedRoot;
                }
            }

            if (!Directory.Exists(LEonardRoot))
            {
                DialogResult result = ConfirmMessageBox(String.Format("Root Directory [{0}] does not exist. Create it?", LEonardRoot));
                if (result == DialogResult.OK)
                {
                    System.IO.Directory.CreateDirectory(LEonardRoot);
                }
                else
                {
                    forceClose = true;
                    Close();
                    return;
                }
            }
        }

        private string recipeFileToAutoload = "";
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
            AllowRunningOfflineChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AllowRunningOfflineChk.Checked", "False"));

            StartupDevicesLbl.Text = (string)AppNameKey.GetValue("StartupDevicesLbl.Text", "");
            AutoConnectOnLoadChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoConnectOnLoadChk.Checked", "False"));

            // Operator Mode
            // Ignore persistence here: if we're running in debug it will kindly start us in Engineering mode else Operator
#if DEBUG
            operatorMode = OperatorMode.ENGINEERING;
#else
            operatorMode = OperatorMode.OPERATOR; // (OperatorMode)(Int32)AppNameKey.GetValue("operatorMode", 0);
#endif
            UserModeBox.SelectedIndex = (int)operatorMode;

            // Debug Level selection (forced to INFO now)
            // DebugLevelCombo.Text = (string)AppNameKey.GetValue("DebugLevelCombo.Text", "Info");
            LogLevelCombo.Text = "Info";

            // Restore displays table and set display mode
            LoadDisplaysBtn_Click(null, null);
            SelectedDisplayLbl.Text = (string)AppNameKey.GetValue("SelectedDisplayLbl.Text", "Default");
            SelectDisplayMode(SelectedDisplayLbl.Text);

            // Load the tools table
            LoadToolsBtn_Click(null, null);

            // Load the positions table
            LoadPositionsBtn_Click(null, null);

            // Load the variables table
            LoadVariablesBtn_Click(null, null);

            // Load the Recipe Commands for User Inspection
            try
            {
                RecipeCommandsRTB.LoadFile("ProgramStatements.rtf");
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not load ProgramStatements.rtf!");
            }

            // Load Revision History for User Inspection
            try
            {
                RevHistRTB.LoadFile("RevisionHistory.rtf");
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not load RevisionHistory.rtf!");
            }

            // Autoload file is the last loaded recipe
            recipeFileToAutoload = (string)AppNameKey.GetValue("RecipeFilenameLbl.Text", "");

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
            AppNameKey.SetValue("AllowRunningOfflineChk.Checked", AllowRunningOfflineChk.Checked);
            AppNameKey.SetValue("StartupDevicesLbl.Text", StartupDevicesLbl.Text);
            AppNameKey.SetValue("AutoConnectOnLoadChk.Checked", AutoConnectOnLoadChk.Checked);

            // Operator Mode
            AppNameKey.SetValue("operatorMode", (Int32)operatorMode);

            // Debug Level selection
            AppNameKey.SetValue("DebugLevelCombo.Text", LogLevelCombo.Text);

            // Save currently selected display and displays table
            AppNameKey.SetValue("SelectedDisplayLbl.Text", SelectedDisplayLbl.Text);
            SaveDisplaysBtn_Click(null, null);

            // Save currently mounted tool and tools table
            AppNameKey.SetValue("MountedToolBox.Text", MountedToolBox.Text);
            SaveToolsBtn_Click(null, null);

            // Save the positions table
            SavePositionsBtn_Click(null, null);

            // Save the variables table
            SaveVariablesBtn_Click(null, null);

            // Save currently loaded recipe
            AppNameKey.SetValue("RecipeFilenameLbl.Text", RecipeFilenameLbl.Text);

            // Save current part geometry tool
            AppNameKey.SetValue("PartGeometryBox.Text", PartGeometryBox.Text);
            for (int i = 0; i < 3; i++)
                AppNameKey.SetValue(String.Format("Diameter[{0}].Text", i), diameterDefaults[i]);

            // Save currently loaded Java and Python programs
            AppNameKey.SetValue("JavaFilenameLbl.Text", JavaFilenameLbl.Text);
            AppNameKey.SetValue("PythonFilenameLbl.Text", PythonFilenameLbl.Text);
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
                LEonardRoot = dialog.SelectedPath;
                LEonardRootLbl.Text = LEonardRoot;

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
                Prompt = "Jog to Defect",
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

        private void ChangeLogLevel(string s)
        {
            LogManager.Configuration.Variables["myLevel"] = s;
            LogManager.ReconfigExistingLoggers();
        }
        private void DebugLevelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLogLevel(LogLevelCombo.Text);
        }

        // ===================================================================
        // END SETUP
        // ===================================================================

        // ===================================================================
        // START EXECUTIVE
        // ===================================================================

        /// <summary>
        /// Is the line a recipe label? This means starting with alpha, followed by 0 or more alphanum, followed by :
        /// </summary>
        /// <param name="line">Input Line</param>
        /// <returns>(bool Success, string Value if matched else null)</returns>
        private (bool Success, string Value) IsLineALabel(string line)
        {
            Regex regex = new Regex("^[A-Za-z_][A-Za-z0-9_]*:$");
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
            foreach (string line in RecipeRTB.Lines)
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

        // 1-index line curently executing in recipe (1 is first line)
        static int lineCurrentlyExecuting = 0;
        /// <summary>
        /// Set the lineCurrentlyExecuting to n and highlight it in the RecipeRTB
        /// </summary>
        /// <param name="n">Line number to start executing</param>
        private string SetCurrentLine(int n)
        {
            lineCurrentlyExecuting = n;

            if (n >= 1 && n <= RecipeRTB.Lines.Count())
            {
                (int start, int length) = RecipeRTB.GetLineExtents(lineCurrentlyExecuting - 1);

                RecipeRTB.SelectAll();
                RecipeRTB.SelectionFont = new Font(RecipeRTB.Font, FontStyle.Regular);

                RecipeRTB.Select(start, length);
                RecipeRTB.SelectionFont = new Font(RecipeRTB.Font, FontStyle.Bold);
                RecipeRTB.ScrollToCaret();
                RecipeRTB.ScrollToCaret();

                RecipeRTBCopy.Select(start, length);
                RecipeRTBCopy.SelectionFont = new Font(RecipeRTBCopy.Font, FontStyle.Bold);
                RecipeRTBCopy.ScrollToCaret();
                RecipeRTBCopy.ScrollToCaret();
                return RecipeRTB.Lines[lineCurrentlyExecuting - 1];
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
        void PopCurrentLine()
        {
            if (callStack.Count > 0)
            {
                log.Debug($"About to pop {callStack.Peek()} from callStack");
                SetCurrentLine(callStack.Pop());
            }
        }

        /// <summary>
        /// Read file looking for lines of the form "name=value" and pass then to the variable write function
        /// </summary>
        /// <param name="filename">File to import- assumed to reside in LEonardRoot/Recipes</param>
        /// <returns>true if file import completed successfully</returns>
        private bool ImportFile(string filename)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(Path.Combine(LEonardRoot, "Recipes", filename));

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

        /// <summary>
        /// Put up MessageForm dialog. Execution will pause until the operator handles the response.
        /// </summary>
        /// <param name="message">This is the message to be displayed</param>
        private void PromptOperator(string message, bool closeOnReady = false, bool isMotionWait = false)
        {
            log.Info("PromptOperator(message={0}, closeOnReady={1}, isMotioWait={2}", message, closeOnReady, isMotionWait);
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




        private void UnboldRecipe()
        {
            RecipeRTB.SelectAll();
            RecipeRTB.SelectionFont = new Font(RecipeRTB.Font, FontStyle.Regular);
            RecipeRTB.DeselectAll();

            RecipeRTBCopy.SelectAll();
            RecipeRTBCopy.SelectionFont = new Font(RecipeRTB.Font, FontStyle.Regular);
            RecipeRTBCopy.DeselectAll();
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

            if (lineCurrentlyExecuting >= RecipeRTB.Lines.Count())
            {
                log.Info("EXEC Reached end of file");
                ReportStepTimeStats();

                UnboldRecipe();
                SetRecipeState(recipeStateAtRun);
                SetState(RunState.READY);
            }
            else
            {
                ReportStepTimeStats();
                string line = SetCurrentLine(lineCurrentlyExecuting + 1);
                bool fContinue = ExecuteLine(lineCurrentlyExecuting, line);
                if (isSingleStep)
                {
                    isSingleStep = false;
                    SetState(RunState.PAUSED);
                }
                if (!fContinue)
                {
                    log.Info("EXEC Execution ending");
                    UnboldRecipe();
                    SetRecipeState(recipeStateAtRun);
                    SetState(RunState.READY);
                }
            }
        }
        private void MessageTmr_Tick(object sender, EventArgs e)
        {
            if (interfaces.Length == 0) return;

            // TODO: This is WIP since shouldn't need to call receive once callbacks work
            // TODO: do we really need to keep polling for message receipt?
            foreach (LeDeviceInterface device in interfaces)
                device?.Receive(true);  // Only calls receive for interfaces with a callback!

            // The original method
            /*
            bool fRobotError = true;
            if (robotCommandServer != null)
                if (robotCommandServer.IsConnected())
                {
                    robotCommandServer.Receive();
                    fRobotError = false;
                }
            if (fRobotError)
            {
                RobotReadyLbl.BackColor = Color.Red;
                GrindReadyLbl.BackColor = Color.Red;
                GrindProcessStateLbl.BackColor = Color.Red;
            }

            if (gocator != null)
                if (gocator.IsConnected())
                    gocator.Receive();
                else
                {
                    GocatorConnectBtn.BackColor = Color.Red;
                    GocatorConnectBtn.Text = "Gocator OFF";
                }
            */
        }

        // ===================================================================
        // END EXECUTIVE
        // ===================================================================


        // ===================================================================
        // START GOCATOR INTERFACE
        // ===================================================================

        public void GocatorAnnounce(LeGocator.Status status)
        {
            switch (status)
            {
                case LeGocator.Status.OK:
                    GocatorConnectedLbl.Text = "Gocator OK";
                    GocatorConnectedLbl.BackColor = Color.Green;
                    GocatorReadyLbl.BackColor = Color.Green;
                    log.Info("Gocator connection READY");
                    break;
                case LeGocator.Status.ERROR:
                    log.Error("Gocator client initialization failure");
                    GocatorConnectedLbl.Text = "Gocator ERROR";
                    GocatorConnectedLbl.BackColor = Color.Red;
                    GocatorReadyLbl.BackColor = Color.Red;
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

        // ===================================================================
        // END GOCATOR INTERFACE
        // ===================================================================


        
        private void CurrentLineLbl_TextChanged(object sender, EventArgs e)
        {
            CurrentLineLblCopy.Text = CurrentLineLbl.Text;
        }

        private void RecipeFilenameLbl_TextChanged(object sender, EventArgs e)
        {
            LoadRecipeBtn.Text = Path.GetFileNameWithoutExtension(RecipeFilenameLbl.Text);
        }

        private void RecipeRTB_TextChanged(object sender, EventArgs e)
        {
            if (runState != RunState.RUNNING)
            {
                SetRecipeState(RecipeState.MODIFIED);
                //UnboldRecipe();
            }
            RecipeRTBCopy.Text = RecipeRTB.Text;
        }

        private void ClearAllLogRtbBtn_Click(object sender, EventArgs e)
        {
            AllLogRTB.Clear();
            ExecLogRTB.Clear();
            UrLogRTB.Clear();
            UrDashboardLogRTB.Clear();
            ErrorLogRTB.Clear();
        }

        private void FullManualBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            startInfo.Arguments = String.Format("file:\\{0}\\LEonard%20User%20Manual.pdf", executionRoot);
            process.StartInfo = startInfo;
            process.Start();
        }

        private void BigEditBtn_Click(object sender, EventArgs e)
        {

            log.Info("BigEditBtn_Click(...)");
            BigEditDialog bigeditForm = new BigEditDialog()
            {
                Title = RecipeFilenameLbl.Text,
                ScreenWidth = screenDesignWidth,
                ScreenHeight = screenDesignHeight,
                Recipe = RecipeRTB.Text
            };
            bigeditForm.ShowDialog();

            log.Info("BigEditDialog returns {0}", bigeditForm.DialogResult);

            if (bigeditForm.DialogResult == DialogResult.OK)
            {
                RecipeRTB.Text = bigeditForm.Recipe;
                log.Info("Installing from BigEdit");
            }
        }

        // Below 2 functions could be used to try to keep the scrolls of the two recipe windows in sync someday
        // Some complexity here.......
        private void RecipeRTBCopy_VScroll(object sender, EventArgs e)
        {
            //log.Info("RecipeRTBCopy VScroll");

            //RichTextBox r = (RichTextBox)sender;
            //log.Info("ss",r.)

        }

        private void RecipeRTB_VScroll(object sender, EventArgs e)
        {
            //log.Info("RecipeRTB VScroll");

        }
    }

    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// Dependable replacement for RTB.GetFirstCharIndexFromLine. Actually adds up the previous lines plus terminator.
        /// When you don't do this, you get odd behavior with line wrapping and if you toggle it off, you get flashing of the control.
        /// </summary>
        /// <param name="n">0-indexed line number to examine</param>
        /// <returns></returns>
        public static (int start, int length) GetLineExtents(this System.Windows.Forms.RichTextBox richTextBox, int n)
        {
            int start = 0;
            for (int i = 0; i < n; i++)
                start += richTextBox.Lines[i].Length + 1;

            return (start, richTextBox.Lines[n].Length);
        }
    }
}

