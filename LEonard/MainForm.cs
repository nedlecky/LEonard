// File: MainForm.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: The main code window for the LEonard program

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NLog;
using LEonard;
using Jint;
using System.Net.NetworkInformation;
using static IronPython.Modules._ast;
using static IronPython.Modules.PythonIterTools;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Configuration;
using System.Net.Http.Headers;
using Microsoft.Scripting.Hosting;
using System.ServiceModel.Channels;
using Microsoft.Scripting.Runtime;
using Leonard;
using NLog.Fluent;
using System.Drawing.Text;
using System.ServiceModel.Configuration;
//using static Community.CsharpSqlite.Sqlite3;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        // These map 1:1 with the rows in devices.... I hope
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

                if (javaCopy != JavaCodeRTB.Text) //JavaCodeRTB.Modified)
                {
                    var result = ConfirmMessageBox($"Closing Application!\nJava code [{JavaFilenameLbl.Text}] has changed.\nSave changes before exit?");
                    if (result == DialogResult.OK)
                        JavaSaveBtn_Click(null, null);
                }

                if (pythonCopy != PythonCodeRTB.Text) //PythonCodeRTB.Modified)
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
                    focusLeUrDashboard?.InquiryResponse("unlock protective stop", 200);
                    focusLeUrDashboard?.InquiryResponse("close safety popup", 200);

                    break;
                case "Safetystatus: ROBOT EMERGENCY STOP":
                    ErrorMessageBox("Release Robot E-Stop");
                    focusLeUrDashboard?.InquiryResponse("close safety popup", 200);
                    break;
                default:
                    log.Error("Unknown safety status button state! {0}", SafetyStatusBtn.Text);
                    ErrorMessageBox(String.Format("Unsure how to recover from {0}", SafetyStatusBtn.Text));
                    break;
            }
        }

        private void KeyboardBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AllLogRTB_DoubleClick(object sender, EventArgs e)
        {
            AllLogRTB.Clear();
        }

        private void ExecLogRTB_DoubleClick(object sender, EventArgs e)
        {
            ExecLogRTB.Clear();
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
        // START GRIND
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
        // END GRIND
        // ===================================================================

        // ===================================================================
        // START EDIT
        // ===================================================================

        // Drop any highlighted lines!
        private enum RecipeState
        {
            INIT,
            NEW,
            LOADED,
            MODIFIED,
            RUNNING
        }
        RecipeState recipeState = RecipeState.INIT;
        RecipeState recipeStateAtRun = RecipeState.INIT;
        private void SetRecipeState(RecipeState s)
        {
            if (recipeState != s)
            {
                log.Debug("SetRecipeState({0})", s.ToString());

                RecipeState oldRecipeState = recipeState;
                recipeState = s;

                switch (recipeState)
                {
                    case RecipeState.NEW:
                        NewRecipeBtn.Enabled = false;
                        LoadRecipeBtn.Enabled = true;
                        SaveRecipeBtn.Enabled = false;
                        SaveAsRecipeBtn.Enabled = true;
                        break;
                    case RecipeState.LOADED:
                        NewRecipeBtn.Enabled = true;
                        LoadRecipeBtn.Enabled = true;
                        SaveRecipeBtn.Enabled = false;
                        SaveAsRecipeBtn.Enabled = true;
                        break;
                    case RecipeState.MODIFIED:
                        NewRecipeBtn.Enabled = true;
                        LoadRecipeBtn.Enabled = true;
                        SaveRecipeBtn.Enabled = true;
                        SaveAsRecipeBtn.Enabled = true;
                        break;
                    case RecipeState.RUNNING:
                        recipeStateAtRun = oldRecipeState;
                        NewRecipeBtn.Enabled = false;
                        LoadRecipeBtn.Enabled = false;
                        SaveRecipeBtn.Enabled = false;
                        SaveAsRecipeBtn.Enabled = false;
                        break;
                }
                NewRecipeBtn.BackColor = NewRecipeBtn.Enabled ? Color.Green : Color.Gray;
                LoadRecipeBtn.BackColor = LoadRecipeBtn.Enabled ? Color.Green : Color.Gray;
                SaveRecipeBtn.BackColor = SaveRecipeBtn.Enabled ? Color.Green : Color.Gray;
                SaveAsRecipeBtn.BackColor = SaveAsRecipeBtn.Enabled ? Color.Green : Color.Gray;
            }
        }


        private string recipeAsLoaded = "";  // As it was when loaded so we can test for actual mods
        private bool RecipeWasModified()
        {
            return recipeAsLoaded != RecipeRTB.Text;
        }
        bool LoadRecipeFile(string file)
        {
            log.Info("LoadRecipeFile({0})", file);
            RecipeFilenameLbl.Text = "";
            RecipeRTB.Text = "";
            try
            {
                RecipeRTB.LoadFile(file, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                RecipeFilenameLbl.Text = file;
                recipeAsLoaded = RecipeRTB.Text;
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Can't open {0}", file);
                return false;
            }
        }

        private void NewRecipeBtn_Click(object sender, EventArgs e)
        {
            log.Info("NewRecipeBtn_Click(...)");
            if (RecipeWasModified())
            {
                var result = ConfirmMessageBox(String.Format("Recipe [{0}] has changed.\nSave changes?", LoadRecipeBtn.Text));
                if (result == DialogResult.OK)
                    SaveRecipeBtn_Click(null, null);
            }

            SetRecipeState(RecipeState.NEW);
            SetState(RunState.IDLE);
            RecipeFilenameLbl.Text = "Untitled";
            RecipeRTB.Clear();
            recipeAsLoaded = "";
            MainTab.SelectedIndex = 1; // = "Program";
        }

        private void LoadRecipeBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadRecipeBtn_Click(...)");
            if (RecipeWasModified())
            {
                var result = ConfirmMessageBox(String.Format("Recipe [{0}] has changed.\nSave changes?", LoadRecipeBtn.Text));
                if (result == DialogResult.OK)
                    SaveRecipeBtn_Click(null, null);
            }

            string initialDirectory;
            if (RecipeFilenameLbl.Text != "Untitled" && RecipeFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(RecipeFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Recipe",
                Filter = "*.txt",
                InitialDirectory = initialDirectory
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadRecipeFile(dialog.FileName))
                {
                    SetRecipeState(RecipeState.LOADED);
                    SetState(RunState.READY);
                }
            }
        }

        private void SaveRecipeBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveRecipeBtn_Click(...)");
            if (RecipeFilenameLbl.Text == "Untitled" || RecipeFilenameLbl.Text == "")
                SaveAsRecipeBtn_Click(null, null);
            else
            {
                log.Info("Save Recipe program to {0}", RecipeFilenameLbl.Text);
                RecipeRTB.SaveFile(RecipeFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                recipeAsLoaded = RecipeRTB.Text;
                SetRecipeState(RecipeState.LOADED);
                SetState(RunState.READY);
            }
        }

        private void SaveAsRecipeBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveAsRecipeBtn_Click(...)");

            string initialDirectory;
            if (RecipeFilenameLbl.Text != "Untitled" && RecipeFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(RecipeFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Recipe As...",
                Filter = "*.txt",
                InitialDirectory = initialDirectory,
                FileName = RecipeFilenameLbl.Text,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".txt")) filename += ".txt";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        RecipeFilenameLbl.Text = filename;
                        SaveRecipeBtn_Click(null, null);
                    }
                }
            }
        }
        private void RecipeRTB_ModifiedChanged(object sender, EventArgs e)
        {
            SetRecipeState(RecipeState.MODIFIED);
        }
        // ===================================================================
        // END EDIT
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
                RecipeCommandsRTB.LoadFile("RecipeCommands.rtf");
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not load RecipeCommands.rtf!");
            }

            // Load Revision Hstory for User Inspection
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
        int logFilter = 0;
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

            // Resets such that the above log messages will happen
            logFilter = 3;
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
        // ===================================================================
        // END EXECUTIVE
        // ===================================================================

        // ===================================================================
        // START ROBOT INTERFACE
        // ===================================================================
        public void UrDashboardAnnounce(LeUrDashboard.DashboardStatus status)
        {
            switch (status)
            {
                case LeUrDashboard.DashboardStatus.OK:
                    RobotConnectBtn.BackColor = Color.Green;
                    RobotConnectBtn.Text = "Dashboard OK";

                    RobotModelLbl.Text = focusLeUrDashboard.InquiryResponse("get robot model", 200);
                    RobotSerialNumberLbl.Text = focusLeUrDashboard.InquiryResponse("get serial number", 200);
                    RobotPolyscopeVersionLbl.Text = focusLeUrDashboard.InquiryResponse("PolyscopeVersion", 200);
                    focusLeUrDashboard.InquiryResponse("stop", 200);
                    CloseSafetyPopup();

                    break;
                case LeUrDashboard.DashboardStatus.ERROR:
                    RobotConnectBtn.BackColor = Color.Red;
                    RobotConnectBtn.Text = "Dashboard ERROR";
                    break;
                case LeUrDashboard.DashboardStatus.OFF:
                    RobotConnectBtn.BackColor = Color.Red;
                    RobotConnectBtn.Text = "OFF";
                    RobotModeBtn.BackColor = Color.Red;
                    SafetyStatusBtn.BackColor = Color.Red;
                    ProgramStateBtn.BackColor = Color.Red;
                    RobotModeBtn.Text = "";
                    SafetyStatusBtn.Text = "";
                    ProgramStateBtn.Text = "";
                    break;
                default:
                    RobotConnectBtn.BackColor = Color.Yellow;
                    RobotConnectBtn.Text = "Dashboard ???";
                    break;
            }
        }
        public void UrCommandAnnounce(LeUrCommand.CommandStatus status)
        {
            switch (status)
            {
                case LeUrCommand.CommandStatus.OK:
                    GocatorConnectedLbl.Text = "Gocator OK";
                    GocatorConnectedLbl.BackColor = Color.Green;
                    GocatorReadyLbl.BackColor = Color.Green;
                    log.Info("Gocator connection READY");
                    break;
                case LeUrCommand.CommandStatus.ERROR:
                    log.Error("Gocator client initialization failure");
                    GocatorConnectedLbl.Text = "Gocator ERROR";
                    GocatorConnectedLbl.BackColor = Color.Red;
                    GocatorReadyLbl.BackColor = Color.Red;
                    break;
                case LeUrCommand.CommandStatus.OFF:
                    RobotConnectBtn.BackColor = Color.Red;
                    RobotConnectBtn.Text = "OFF";
                    RobotModeBtn.BackColor = Color.Red;
                    SafetyStatusBtn.BackColor = Color.Red;
                    ProgramStateBtn.BackColor = Color.Red;
                    RobotModeBtn.Text = "";
                    SafetyStatusBtn.Text = "";
                    ProgramStateBtn.Text = "";
                    break;
                default:
                    GocatorConnectedLbl.Text = "Gocator ???";
                    GocatorConnectedLbl.BackColor = Color.Yellow;
                    GocatorReadyLbl.BackColor = Color.Yellow;
                    break;
            }
        }

        private void CloseSafetyPopup()
        {
            log.Info("close popup = {0}", focusLeUrDashboard?.InquiryResponse("close popup"), 200);
            log.Info("close safety popup = {0}", focusLeUrDashboard?.InquiryResponse("close safety popup"), 200);
        }

        public void RobotSendHalt()
        {
            focusLeUrCommand?.Send("(999)");
        }
        int robotSendIndex = 100;
        // Command is a 0-n element comma-separated list "x,y,z" of doubles
        // We send (index,x,y,z)
        public bool RobotSend(string command)
        {
            if (focusLeUrCommand == null)
            {
                ErrorMessageBox($"RobotSend({command}) failed. focusLeUrCommand is null.");
                return false;
            }
            if (!focusLeUrCommand.IsClientConnected)
            {
                ErrorMessageBox($"RobotSend({command}) failed. focusLeUrCommand is not connected.");
                return false;
            }
            if (!ProgramStateBtn.Text.StartsWith("PLAYING"))
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
            focusLeUrCommand.Send(sendMessage);
            return true;
        }
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
                ExecuteLine(-1, String.Format("set_linear_speed({0})", form.Value));
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
                ExecuteLine(-1, String.Format("set_linear_accel({0})", form.Value));
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
                ExecuteLine(-1, String.Format("set_blend_radius({0})", form.Value));
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
                ExecuteLine(-1, String.Format("set_joint_speed({0})", form.Value));
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
                ExecuteLine(-1, String.Format("set_joint_accel({0})", form.Value));
            }
        }
        private void SetMoveDefaultsBtn_Click(object sender, EventArgs e)
        {
            log.Info("SetMoveDefaultsBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the Default Motion Parameters. Proceed?"))
                return;

            ExecuteLine(-1, String.Format("set_linear_speed({0})", DEFAULT_linear_speed));
            ExecuteLine(-1, String.Format("set_linear_accel({0})", DEFAULT_linear_accel));
            ExecuteLine(-1, String.Format("set_blend_radius({0})", DEFAULT_blend_radius));
            ExecuteLine(-1, String.Format("set_joint_speed({0})", DEFAULT_joint_speed));
            ExecuteLine(-1, String.Format("set_joint_accel({0})", DEFAULT_joint_accel));
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
                ExecuteLine(-1, String.Format("grind_touch_speed({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_touch_retract({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_force_dwell({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_max_wait({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_max_blend_radius({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_trial_speed({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_linear_accel({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_point_frequency({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_jog_speed({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_jog_accel({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_force_mode_damping({0})", form.Value));
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
                ExecuteLine(-1, String.Format("grind_force_mode_gain_scaling({0})", form.Value));
            }
        }

        private void SetGrindDefaultsBtn_Click(object sender, EventArgs e)
        {
            log.Info("SetGrindDefaultsBtn_Click(...)");
            if (DialogResult.OK != ConfirmMessageBox("This will reset the Grinding Motion Parameters. Proceed?"))
                return;

            ExecuteLine(-1, String.Format("grind_trial_speed({0})", DEFAULT_grind_trial_speed));
            ExecuteLine(-1, String.Format("grind_linear_accel({0})", DEFAULT_grind_linear_accel));
            ExecuteLine(-1, String.Format("grind_jog_speed({0})", DEFAULT_grind_jog_speed));
            ExecuteLine(-1, String.Format("grind_jog_accel({0})", DEFAULT_grind_jog_accel));
            ExecuteLine(-1, String.Format("grind_max_blend_radius({0})", DEFAULT_grind_max_blend_radius));
            ExecuteLine(-1, String.Format("grind_touch_speed({0})", DEFAULT_grind_touch_speed));
            ExecuteLine(-1, String.Format("grind_touch_retract({0})", DEFAULT_grind_touch_retract));
            ExecuteLine(-1, String.Format("grind_force_dwell({0})", DEFAULT_grind_force_dwell));
            ExecuteLine(-1, String.Format("grind_max_wait({0})", DEFAULT_grind_max_wait));
            ExecuteLine(-1, String.Format("grind_point_frequency({0})", DEFAULT_grind_point_frequency));
            ExecuteLine(-1, String.Format("grind_force_mode_damping({0})", DEFAULT_grind_force_mode_damping));
            ExecuteLine(-1, String.Format("grind_force_mode_gain_scaling({0})", DEFAULT_grind_force_mode_gain_scaling));
        }

        public void GeneralCallbackStatementExecute(string prefix, string statement)
        {
            log.Trace($"{prefix}: {statement}");
            // {script.....}
            if (statement.StartsWith("LE:") && statement.Length > 5)
                ExecuteLine(-1, statement.Substring(3));
            else if (statement.StartsWith("JE:") && statement.Length > 5)
                ExecuteJavaScript(statement.Substring(3));
            else if (statement.StartsWith("PE:") && statement.Length > 5)
                ExecutePythonScript(statement.Substring(3));
            else if (statement.Contains("="))           // name=value
                UpdateVariable(statement);
            else if (statement.StartsWith("SET ")) // SET name value
            {
                string[] s = statement.Split(' ');
                if (s.Length == 3)
                    WriteVariable(s[1], s[2]);
                else
                    log.Error($"{prefix} Illegal SET statement: {statement}");
            }
            else
                log.Error($"{prefix} Illegal GeneralCallbackStatementExecute({prefix}, {statement})");
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
        public void GeneralCallback(string prefix, string message)
        {
            log.Info($"GeneralCallback({prefix},{message})");

            // TODO This gets broken if the user tries to do anything else with '#'
            string[] statements = message.Split('#');
            foreach (string statement in statements)
                GeneralCallbackStatementExecute(prefix, statement);
        }

        void DashboardCallback(string prefix, string message)
        {
            log.Debug($"{prefix}<== {message}");
        }

        // Callback used for LEonardClient and remote control
        void CommandCallback(string prefix, string message)
        {
            log.Info($"CCB<==({prefix}, {message})");
            // Nothing special for now
            GeneralCallback(prefix, message);
        }

        void AlternateCallback1(string message, string prefix)
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

            if (focusLeUrCommand?.IsConnected() == true)
            {
                if (ProgramStateBtn.Text.StartsWith("PLAYING")) RobotSend("98");
                focusLeUrCommand.Disconnect();
                focusLeUrCommand = null;
            }
            RobotCommandStatusLbl.BackColor = Color.Red;
            RobotCommandStatusLbl.Text = "OFF";
        }

        private void ProgramStateBtn_Click(object sender, EventArgs e)
        {
            CloseSafetyPopup();
            if (ProgramStateBtn.Text.StartsWith("PLAYING"))
            {
                RobotSend("99");
                focusLeUrDashboard?.Send("stop");
                RobotCommandStatusLbl.BackColor = Color.Red;
                RobotCommandStatusLbl.Text = "OFF";
                RobotReadyLbl.BackColor = Color.Red;
                GrindReadyLbl.BackColor = Color.Red;
                GrindProcessStateLbl.BackColor = Color.Red;
                CloseCommandServer();
            }
            else
            {
                focusLeUrDashboard?.Send("play");
            }
        }

        // ===================================================================
        // END ROBOT INTERFACE
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

        // ===================================================================
        // START VARIABLE SYSTEM
        // ===================================================================

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
            if (name == "DateTime")
                return DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            if (name == "RecipeFilename")
                return Path.GetFileNameWithoutExtension(RecipeFilenameLbl.Text).Replace(' ', '_').ToLower();

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
        public bool WriteVariable(string name, string value, bool isSystem = false)
        {
            System.Threading.Monitor.Enter(lockObject);
            string nameTrimmed = name.Trim();
            string valueTrimmed = value.Trim();

            // Automatically consider and variables with name starting in robot_ or grind_to be system variables
            if (nameTrimmed.StartsWith("robot_") || nameTrimmed.StartsWith("grind_")) isSystem = true;

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
                        PromptOperator($"Received error message from robot: {valueTrimmed}");
                    break;
                case "robot_starting":
                    // This gets sent to us by command_validate on the UR. It means command valueTrimmed is going to start executing
                    log.Info("UR<== EXEC {0} STARTING", valueTrimmed);
                    break;
                case "robot_completed":
                    // This gets sent to us by PolyScope on the UR after command valueTrimmed has finished executing
                    RobotCompletedLbl.Text = valueTrimmed;
                    log.Info("UR<== EXEC {0} COMPLETED", valueTrimmed);

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
                    string v = ReadVariable(m.Groups["name"].Value);
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
                        string v = ReadVariable(m.Groups["name"].Value);
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

        private void LoadVariablesBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, "Recipes", variablesFilename);
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

        private void SaveVariablesBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, "Recipes", variablesFilename);
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

        // ===================================================================
        // END VARIABLE SYSTEM
        // ===================================================================

        // ===================================================================
        // START TOOL SYSTEM
        // ===================================================================
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
                ExecuteLine(-1, string.Format("select_tool({0})", name));
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
                PromptOperator("Wait for move to tool mount position complete", true, true);
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
                PromptOperator("Wait for move to tool home complete", true, true);
            }
        }


        private void ToolTestBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, "tool_on()");
        }

        private void ToolOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, "tool_off()");
        }

        private void CoolantTestBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, "coolant_on()");
        }

        private void CoolantOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, "coolant_off()");
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
            string filename = Path.Combine(LEonardRoot, "Recipes", toolsFilename);
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


        private void SaveToolsBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, "Recipes", toolsFilename);
            log.Info("SaveTools to {0}", filename);
            tools.AcceptChanges();
            tools.WriteXml(filename, XmlWriteMode.WriteSchema, true);
            RefreshMountedToolBox(MountedToolBox.SelectedIndex);
        }

        private void CreateDefaultTools()
        {
            tools.Rows.Add(new object[] { "sander", 0, 0, 0.186, 0, 0, 0, 2.99, -0.011, 0.019, 0.067, "2,1", "2,0", "3,1", "3,0", "sander_mount", "sander_home" });
            tools.Rows.Add(new object[] { "spindle", 0, -0.165, 0.09, 0, 2.2214, -2.2214, 2.61, -0.004, -0.015, 0.049, "5,1", "5,0", "3,1", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "pen", 0, -0.08, 0.075, 0, 2.2214, -2.2214, 1.0, -0.004, -0.015, 0.049, "2,0,5,0", "2,0,5,0", "3,0", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "pen_SA", 0, -0.072, 0.103, 0, 2.2214, -2.2214, 0.98, 0, 0.002, 0.048, "2,0,5,0", "2,0,5,0", "3,0", "3,0", "spindle_mount", "spindle_home" });
            tools.Rows.Add(new object[] { "2F85", 0, 0, 0.175, 0, 0, 0, 1.0, 0, 0, 0.050, "2,1,5,1", "2,0,5,0", "3,1", "3,0", "sander_mount", "sander_home" });
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
            PromptOperator("Wait for move to tool mount position complete", true, true);
        }

        private void MoveToolHomeBtn_Click(object sender, EventArgs e)
        {
            GotoPositionJoint(MoveToolHomeBtn.Text);
            PromptOperator("Wait for move to tool home complete", true, true);
        }

        private void SetDoorClosedInputBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, string.Format("set_door_closed_input({0})", DoorClosedInputTxt.Text));
        }

        private void SetFootswitchInputBtn_Click(object sender, EventArgs e)
        {
            ExecuteLine(-1, string.Format("set_footswitch_pressed_input({0})", FootswitchPressedInputTxt.Text));
        }

        private DataRow FindTool(string name)
        {
            foreach (DataRow row in tools.Rows)
            {
                if ((string)row["Name"] == name)
                {
                    log.Trace("FindTool({0}) = {1}", row["Name"], row.ToString());
                    return row;
                }
            }
            return null;
        }

        // ===================================================================
        // END TOOL SYSTEM
        // ===================================================================

        // ===================================================================
        // START POSITIONS SYSTEM
        // ===================================================================

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


        private void LoadPositionsBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, "Recipes", positionsFilename);
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

        private void SavePositionsBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(LEonardRoot, "Recipes", positionsFilename);
            log.Info("SavePositions to {0}", filename);
            positions.AcceptChanges();
            positions.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        private void ClearPositionsBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ConfirmMessageBox("This will clear all non-system positions. Proceed?"))
                while (DeleteFirstNonSystemEntry(positions)) ;
        }

        private void CreateDefaultPositions()
        {
            positions.Rows.Add(new object[] { "spindle_mount", "[-2.68179,-1.90227,-1.42486,-2.95848,-1.70261,0.000928376]", "p[-0.928515, -0.296863, 0.369036, 1.47493, 2.77222, 0.00280416]" });
            positions.Rows.Add(new object[] { "spindle_home", "[-2.71839,-0.892528,-2.14111,-3.27621,-1.68817,-0.019554]", "p[-0.410055, -0.0168446, 0.429258, -1.54452, -2.73116, -0.0509774]" });
            positions.Rows.Add(new object[] { "sander_mount", "[-2.53006,-2.15599,-1.18223,-1.37402,1.57131,0.124]", "p[-0.933321, -0.442727, 0.284064, 1.61808, 2.6928, 0.000150004]" });
            positions.Rows.Add(new object[] { "sander_home", "[-2.57091,-0.82644,-2.14277,-1.743,1.57367,-0.999559]", "p[-0.319246, 0.00105911, 0.464005, -5.0997e-05, 3.14151, 3.32468e-05]" });
            positions.Rows.Add(new object[] { "grind1", "[-0.964841,-1.56224,-2.25801,-2.46721,-0.975704,0.0351043]", "p[0.115668, -0.664968, 0.149296, -0.0209003, 3.11011, 0.00405717]" });
            positions.Rows.Add(new object[] { "grind2", "[-1.19025,-1.54723,-2.28053,-2.45891,-1.20106,0.0341677]", "p[0.00572967, -0.666445, 0.145823, -0.0208504, 3.11009, 0.004073]" });
            positions.Rows.Add(new object[] { "grind3", "[-1.41341,-1.57357,-2.26161,-2.45085,-1.42422,0.0333479]", "p[-0.0942147, -0.667831, 0.142729, -0.0208677, 3.1101, 0.00394188]" });
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
                PromptOperator(String.Format("Wait for robot linear move to {0} complete", name), true, true);
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
                PromptOperator(String.Format("Wait for robot joint move to {0} complete", name), true, true);
            }
        }

        private void AskSafetyStatusBtn_Click(object sender, EventArgs e)
        {
            focusLeUrDashboard?.InquiryResponse("safetystatus");
        }

        private void UnlockProtectiveStopBtn_Click(object sender, EventArgs e)
        {
            focusLeUrDashboard?.InquiryResponse("unlock protective stop");
        }

        // ===================================================================
        // END POSITIONS SYSTEM
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

        // ===================================================================
        // START UI CONTROL SYSTEM
        // ===================================================================

        double suggestedSystemScale = 100.0;
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
        public static void RescaleFont(Control ctl, double scale)
        {
            Font oldFont = ((ControlInfo)ctl.Tag).originalFont;
            Font newFont = new Font(oldFont.FontFamily, (float)(oldFont.Size * scale / 100), oldFont.Style, oldFont.Unit);
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

            IEnumerable<Control> returnList = buttonList;
            returnList = returnList.Concat(comboboxList);
            returnList = returnList.Concat(datagridviewList);
            returnList = returnList.Concat(labelList);
            returnList = returnList.Concat(richtextboxList);
            // TODO Tabs don't resize so we shouldn't resize their text for now!
            // returnList = returnList.Concat(tabcontrolList);
            returnList = returnList.Concat(textboxList);

            return returnList;
        }

        void ScaleUiText(double scale)
        {
            foreach (Control c in allFontResizableList) RescaleFont(c, scale);
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
            displays.Rows.Add(new object[] { "Zebra ET80A", 2160, 1440, false, false, 100 });
            displays.Rows.Add(new object[] { "Zebra L10", 1920, 1200, false, false, 100 });
            displays.Rows.Add(new object[] { "My Laptop", 1920, 1200, false, false, 100 });
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
            //double fontScale = (double)referencedRow["FontScale"];

            Rectangle screenRect = Screen.FromControl(this).Bounds;
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

                // Todo- not 0,0 if on other monitor!
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
            string filename = Path.Combine(LEonardRoot, "Recipes", displaysFilename);
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
            string filename = Path.Combine(LEonardRoot, "Recipes", displaysFilename);
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

        private void CrawlRTB(RichTextBox rtb, string message)
        {
            rtb.Text += message + Environment.NewLine;
            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }

        // ===================================================================
        // END UI CONTROL SYSTEM
        // ===================================================================



        // ===================================================================
        // START LICENSING
        // ===================================================================

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

        private void ReloadLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.LoadLicense(licenseFilename);
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = false;
        }
        private void SaveLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.SaveLicense(licenseFilename);
            SaveLicenseBtn.Enabled = false;
        }


        // ===================================================================
        // END LICENSING
        // ===================================================================
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

