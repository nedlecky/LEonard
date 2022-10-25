// File: MainForm.Variables.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Variable system for LEonard (independent of Java and Python variables)

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
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

        private void LoadVariables()
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

        private void SaveVariables()
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
    }
}
