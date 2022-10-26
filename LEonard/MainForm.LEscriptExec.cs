// File: MainForm.LEscriptExec.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: MainForm functions supporting execution of LEscript

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm
    {
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
                log.Error(ex, "LEonardScript line parameter error: {0} {1}", s, ex);
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

        // These recipe commands will be converted to send_robot(prefix,[nParams additional parameters])
        public readonly static Dictionary<string, CommandSpec> robotAlias = new Dictionary<string, CommandSpec>
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
            {"free_drive",                      new CommandSpec(){nParams=1,  prefix="30,19" } },
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

        public static string GetRobotPrefix(string command)
        {
            if (robotAlias.TryGetValue(command, out CommandSpec commandSpec))
                return commandSpec.prefix;
            else
                log.Error($"GetRobotPrefix({command}) Does not exist.");
            return null;
        }

        private void LogInterpret(string command, int lineNumber, string line)
        {
            if (lineNumber < 1)
                log.Info("EXEC [{0}] {1}", command.ToUpper(), line);
            else
                log.Info("EXEC {0:0000}: [{1}] {2}", lineNumber, command.ToUpper(), line);
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
            PromptOperator("ERROR:\n" + report);
        }

        Random random = new Random();

        private bool ExecuteLEonardScriptLine(int lineNumber, string line, LeDeviceInterface dev = null)
        {
            // Step is starting now
            stepStartedTime = DateTime.Now;

            // Default time estimate to complete step is 0
            stepEndTimeEstimate = stepStartedTime;

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
                log.Info("EXEC {0:0000}: \"{1}\" from \"{2}\"", lineNumber, line, origLine);

            // Line gets shown on screen with variables substituted and time estimate (unless we're making system calls)
            if (lineNumber > 0)
            {
                CurrentLineLbl.Text = String.Format("{0:000}: {1}", lineNumber, line);
                StepTimeEstimateLbl.Text = TimeSpanFormat(new TimeSpan());
            }

            // Setup for ExecError
            errorLineNumber = lineNumber;
            errorOrigLine = origLine;

            // 1) Ignore comments: drop anything from # onward in the line
            int index = line.IndexOf("#");
            if (index >= 0)
                line = line.Substring(0, index);

            // 2) Cleanup the line: replace all 2 or more whitespace with a single space and drop all leading/trailing whitespace
            string command = Regex.Replace(line, @"\s+", " ").Trim();

            // Skip blank lines or lines that previously had only comments
            if (command.Length < 1)
            {
                log.Info("EXEC {0:0000}: [REM] {1}", lineNumber, origLine);
                return true;
            }

            // Is line a label? If so, we ignore it!
            if (IsLineALabel(command).Success)
            {
                LogInterpret("label", lineNumber, command);
                return true;
            }

            // end
            if (command == "end()" || command == "end")
            {
                LogInterpret("end", lineNumber, origLine);
                return false;
            }

            // pause
            if (command == "pause()" || command == "pause")
            {
                LogInterpret("pause", lineNumber, origLine);
                RobotAndSystemPause();
                return true;
            }

            // clear
            if (command == "clear()" || command == "clear")
            {
                LogInterpret("clear", lineNumber, command);
                ClearNonSystemVariables();
                return true;
            }

            // All other commands are assignment or end with )
            int parenIndex = command.IndexOf(')');
            if (parenIndex >= 0 && parenIndex != command.Length - 1)
            {
                ExecError("Illegal line contains characters after ')'");
                return true;
            }

            // import filename
            if (command.StartsWith("import("))
            {
                LogInterpret("import", lineNumber, command);
                string file = ExtractParameters(command);
                if (file.Length > 1)
                {
                    if (!ImportFile(file))
                        ExecError($"File import error");
                }
                else
                    ExecError("Invalid import command");

                return true;
            }

            // sleep
            if (command.StartsWith("sleep("))
            {
                LogInterpret("sleep", lineNumber, command);
                double sleepSeconds;
                if (ExtractDoubleParameter(command, out sleepSeconds))
                {
                    sleepMs = sleepSeconds * 1000.0;
                    sleepTimer = new Stopwatch();
                    sleepTimer.Start();

                    double sec = Math.Truncate(sleepSeconds);
                    double msec = (sleepSeconds - sec) * 1000.0;
                    log.Info("Looks like {0} sec  {1} msec", sec, msec);

                    TimeSpan ts = new TimeSpan(0, 0, 0, (int)sec, (int)msec);
                    StepTimeEstimateLbl.Text = TimeSpanFormat(ts);
                    stepEndTimeEstimate = DateTime.Now.AddMilliseconds(sleepMs);
                }
                return true;
            }

            // random
            if (command.StartsWith("random("))
            {
                LogInterpret("random", lineNumber, command);
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

            // assert
            if (command.StartsWith("assert("))
            {
                LogInterpret("assert", lineNumber, command);
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unknown assert command");
                    return true;
                }
                string value = ReadVariable(parameters[0], null);
                if (value == null)
                {
                    ExecError("Unknown variable in assert command");
                    return true;
                }
                if (value != parameters[1])
                {
                    ExecError($"Assertion FAILS\n{value} != {parameters[1]}");
                    return true;
                }
                return true;
            }

            // system_variable
            if (command.StartsWith("system_variable("))
            {
                LogInterpret("system_variable", lineNumber, command);
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

            // system_position
            if (command.StartsWith("system_position("))
            {
                LogInterpret("system_position", lineNumber, command);
                string[] parameters = ExtractParameters(command, 2).Split(',');
                if (parameters.Length != 2)
                {
                    ExecError("Unrecognized system_position command");
                    return true;
                }
                string positionName = parameters[0];
                string value = ReadPositionJoint(positionName);
                if (value == null)
                {
                    ExecError("Unrecognized position in system_position command");
                    return true;
                }
                SetSystemPosition(positionName, parameters[1] == "True");
                return true;
            }

            // jump
            if (command.StartsWith("jump("))
            {
                string labelName = ExtractParameters(command);

                if (labels.TryGetValue(labelName, out int jumpLine))
                {
                    log.Info("EXEC {0:0000}: [JUMP] {1} --> {2:0000}", lineNumber, origLine, jumpLine);
                    SetCurrentLine(jumpLine);
                    return true;
                }
                else
                {
                    ExecError("Unknown label specified in jump");
                    return true;
                }
            }

            // call
            if (command.StartsWith("call("))
            {
                string labelName = ExtractParameters(command);

                if (labels.TryGetValue(labelName, out int jumpLine))
                {
                    log.Info("EXEC {0:0000}: [CALL] {1} --> {2:0000}", lineNumber, origLine, jumpLine);
                    PushCurrentLine();
                    SetCurrentLine(jumpLine);
                    return true;
                }
                else
                {
                    ExecError("Unknown label specified in call");
                    return true;
                }
            }

            // exec_java
            if (command.StartsWith("exec_java("))
            {
                LogInterpret("exec_java", lineNumber, command);
                string filename = ExtractParameters(command);

                if (!ExecuteJavaFile(filename))
                    ExecError($"Cannot execute java file {filename}");

                return true;
            }

            // exec_python
            if (command.StartsWith("exec_python("))
            {
                LogInterpret("exec_python", lineNumber, command);
                string filename = ExtractParameters(command);
                if (!ExecutePythonFile(filename))
                    ExecError($"Cannot execute python file {filename}");

                return true;
            }

            // return
            if (command == "return")
            {
                PopCurrentLine();
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
                                    log.Info("EXEC {0:0000}: [JUMP_GT_ZERO] Line {1} --> {2:0000}", lineNumber, origLine, jumpLine);
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

            // move_joint
            if (command.StartsWith("move_joint("))
            {
                LogInterpret("move_joint", lineNumber, command);
                string positionName = ExtractParameters(command);
                if (GotoPositionJoint(positionName))
                    PromptOperator($"Wait for move_joint({positionName}) complete", true, true);
                else
                    ExecError($"Joint move to {positionName} failed");
                return true;
            }

            // move_linear
            if (command.StartsWith("move_linear("))
            {
                LogInterpret("move_linear", lineNumber, origLine);
                string positionName = ExtractParameters(command);

                if (GotoPositionPose(positionName))
                    PromptOperator($"Wait for move_linear({positionName}) complete", true, true);
                else
                    ExecError($"Linear move to {positionName} failed");
                return true;
            }

            // move_relative
            // This is really deprecated for movel_incr_part(...)
            if (command.StartsWith("move_relative("))
            {
                LogInterpret("move_relative", lineNumber, origLine);
                string xy = ExtractParameters(command, 2);

                if (xy == "")
                    ExecError("Relative move no parameters x,y");
                else
                {
                    try
                    {
                        string[] p = xy.Split(',');
                        double x_mm = Convert.ToDouble(p[0]);
                        double y_mm = Convert.ToDouble(p[1]);
                        if (Math.Abs(x_mm) > DEFAULT_max_allowable_relative_move_mm || Math.Abs(y_mm) > DEFAULT_max_allowable_relative_move_mm)
                            ExecError($"X and Y must be no more than +/{DEFAULT_max_allowable_relative_move_mm} mm");
                        RobotSend($"{MainForm.GetRobotPrefix("movel_incr_part")},{x_mm / 1000.0},{y_mm / 1000.0},0,0,0,0");
                    }
                    catch
                    {
                        ExecError("Relative move bad parameters x,y");
                    }
                }

                return true;
            }

            // ur_dashboard
            if (command.StartsWith("ur_dashboard("))
            {
                LogInterpret("ur_dashboard", lineNumber, origLine);
                string message = ExtractParameters(command, 1, false);
                if (message.Length < 1)
                {
                    ExecError("No message specified");
                    return true;
                }
                string response = UrDashboardInquiryResponse(message, 200);
                WriteVariable("lastUrDashboardResponse", response); ;
                return true;
            }

            // ur_wait_stopped
            if (command == "ur_wait_stopped()")
            {
                waitUrStopped = true;
                return true;
            }

            // save_position
            if (command.StartsWith("save_position("))
            {
                LogInterpret("save_position", lineNumber, origLine);
                string positionName = ExtractParameters(command);
                if (positionName.Length < 1)
                {
                    ExecError("No position name specified");
                    return true;
                }
                copyPositionAtWrite = positionName;

                RobotSend(MainForm.GetRobotPrefix("get_actual_both"));
                return true;
            }

            // move_tool_home
            if (command.StartsWith("move_tool_home()"))
            {
                LogInterpret("move_tool_home", lineNumber, origLine);
                MoveToolHomeBtn_Click(null, null);
                return true;
            }

            // move_tool_mount
            if (command.StartsWith("move_tool_mount()"))
            {
                LogInterpret("move_tool_mount", lineNumber, origLine);
                MoveToolMountBtn_Click(null, null);
                return true;
            }

            // select_tool  (Assumes operator has already installed it somehow!!)
            if (command.StartsWith("select_tool("))
            {
                LogInterpret("select_tool", lineNumber, origLine);
                string name = ExtractParameters(command, 1);
                DataRow row = FindTool(name);
                if (row == null)
                {
                    log.Error("Unknown tool specified in EXEC: {0.000} {1}", lineNumber, command);
                    PromptOperator("Unrecognized command: " + command);
                    return true;
                }
                else
                {
                    // Kind of like a subroutine that calls all the pieces needed to effect a tool change
                    // Just in case... make sure we disable current tool

                    ExecuteLEonardScriptLine(-1, String.Format("set_tcp({0},{1},{2},{3},{4},{5})", row["x_m"], row["y_m"], row["z_m"], row["rx_rad"], row["ry_rad"], row["rz_rad"]));
                    ExecuteLEonardScriptLine(-1, String.Format("set_payload({0},{1},{2},{3})", row["mass_kg"], row["cogx_m"], row["cogy_m"], row["cogz_m"]));

                    ExecuteLEonardScriptLine(-1, String.Format("tool_off()"));
                    ExecuteLEonardScriptLine(-1, String.Format("coolant_off()"));
                    ExecuteLEonardScriptLine(-1, String.Format("set_tool_on_outputs({0})", row["ToolOnOuts"]));
                    ExecuteLEonardScriptLine(-1, String.Format("set_tool_off_outputs({0})", row["ToolOffOuts"]));
                    ExecuteLEonardScriptLine(-1, String.Format("set_coolant_on_outputs({0})", row["CoolantOnOuts"]));
                    ExecuteLEonardScriptLine(-1, String.Format("set_coolant_off_outputs({0})", row["CoolantOffOuts"]));
                    ExecuteLEonardScriptLine(-1, String.Format("tool_off()"));
                    ExecuteLEonardScriptLine(-1, String.Format("coolant_off()"));
                    WriteVariable("robot_tool", row["Name"].ToString());

                    // Set Move buttons to go to tool change and home locations
                    MoveToolMountBtn.Text = row["MountPosition"].ToString();
                    MoveToolHomeBtn.Text = row["HomePosition"].ToString();

                    // Update the UI selector but don't trigger another set of commands to the robot!
                    mountedToolBoxActionDisabled = true;
                    MountedToolBox.Text = (string)row["Name"];
                    mountedToolBoxActionDisabled = false;

                    // Highlight the corresponding row in the DataGridView
                    SelectDataGridViewRow(ToolsGrd, name);

                    // Give the UI some time to process all of those command returns!!!
                    Thread.Sleep(1000);
                }
                return true;
            }

            // set_part_geometry
            if (command.StartsWith("set_part_geometry("))
            {
                LogInterpret("set_part_geometry", lineNumber, origLine);

                string parameters = ExtractParameters(command, 2);
                if (parameters.Length == 0)
                {
                    log.Error("Illegal parameters for set_part_geometry EXEC: {0.000} {1}", lineNumber, command);
                    PromptOperator("Illegal set_part_geometry command:\n" + command);
                    return true;
                }
                string[] paramList = parameters.Split(',');
                if (paramList.Length != 2)
                {
                    log.Error("Illegal parameters for set_part_geometry EXEC: {0.000} {1}", lineNumber, command);
                    PromptOperator("Illegal set_part_geometry command:\n" + command);
                    return true;
                }

                switch (paramList[0])
                {
                    case "FLAT":
                        DiameterLbl.Text = "0.0";
                        DiameterLbl.Visible = false;
                        DiameterDimLbl.Visible = false;
                        break;
                    case "CYLINDER":
                        if (!ValidNumericString(paramList[1], 75, 3000))
                        {
                            log.Error("Diameter must be between 75 and 3000 EXEC: {0.000} {1}", lineNumber, command);
                            PromptOperator("Diameter be between 75 and 3000:\n" + command);
                            return true;
                        }
                        DiameterLbl.Text = paramList[1];
                        DiameterLbl.Visible = true;
                        DiameterDimLbl.Visible = true;
                        diameterDefaults[1] = paramList[1];
                        break;
                    case "SPHERE":
                        if (!ValidNumericString(paramList[1], 75, 3000))
                        {
                            log.Error("Diameter must be between 75 and 3000 EXEC: {0.000} {1}", lineNumber, command);
                            PromptOperator("Diameter be between 75 and 3000:\n" + command);
                            return true;
                        }
                        DiameterLbl.Text = paramList[1];
                        DiameterLbl.Visible = true;
                        DiameterDimLbl.Visible = true;
                        diameterDefaults[2] = paramList[1];
                        break;
                    default:
                        log.Error("First argument to must be FLAT, CYLINDER, or SPHERE EXEC: {0.000} {1}", lineNumber, command);
                        PromptOperator("First argument to must be FLAT, CYLINDER, or SPHERE:\n" + command);
                        return true;
                }

                // Update the UI control but don't have it trigger commands to robot, which is done explicitly below
                partGeometryBoxDisabled = true;
                PartGeometryBox.Text = paramList[0];
                partGeometryBoxDisabled = false;

                UpdateGeometryToRobot();
                return true;
            }

            // prompt
            if (command.StartsWith("prompt("))
            {
                LogInterpret("prompt", lineNumber, origLine);
                // This just displays the dialog. ExecTmr will wait for it to close
                PromptOperator(ExtractParameters(command, -1, false));
                return true;
            }

            // lePrint
            void print(string s)
            {
                log.Info("L** " + s);
            }
            if (command.StartsWith("lePrint("))
            {
                LogInterpret("lePrint", lineNumber, origLine);
                print(ExtractParameters(command, -1, false));
                return true;
            }

            // send
            if (command.StartsWith("send("))
            {
                LogInterpret("send", lineNumber, origLine);
                string str = ExtractParameters(command, -1, false);
                if (dev == null)
                    print("dev=null " + str);
                else
                    dev.Send(str);

                return true;
            }

            // gocator_send
            if (command.StartsWith("gocator_send("))
            {
                if (focusLeGocator == null)
                {
                    ExecError("No Gocator selected");
                    return true;
                }

                LogInterpret("gocator_send", lineNumber, origLine);
                focusLeGocator?.Send(ExtractParameters(command, -1, false));
                return true;
            }

            // gocator_trigger
            if (command.StartsWith("gocator_trigger("))
            {
                LogInterpret("gocator_trigger", lineNumber, origLine);
                if (focusLeGocator == null)
                {
                    ExecError("No Gocator selected");
                    return true;
                }

                int preDelay_ms;
                if (ExtractIntParameter(command, out preDelay_ms))
                {
                    focusLeGocator?.Trigger(preDelay_ms);
                    GocatorReadyLbl.BackColor = ColorFromBooleanName("False");
                    GocatorReadyLbl.Refresh();
                }

                return true;
            }

            // gocator_adjust
            if (command.StartsWith("gocator_adjust("))
            {
                LogInterpret("gocator_adjust", lineNumber, origLine);
                if (focusLeGocator == null)
                {
                    ExecError("No Gocator selected");
                    return true;
                }

                int version;
                if (!ExtractIntParameter(command, out version))
                    return true;

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
                            ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, 0, 0, 0]");
                        else
                            ExecuteLEonardScriptLine(-1, $"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},0,0,0)");
                        break;
                    case 2:
                        if (abs_drx > 15 || abs_dry > 15)
                            ExecError($"Excessive gocator_adjust [0, 0, 0, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        else
                            ExecuteLEonardScriptLine(-1, $"movel_incr_tool(0,0,0,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        break;
                    case 3:
                        if (abs_dx > 0.020 || abs_dy > 0.020 || abs_dz > 0.020 ||
                            abs_drx > 15 || abs_dry > 15)
                            ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        else
                        {
                            ExecuteLEonardScriptLine(-1, $"movel_incr_part({dx:0.000000},{dy:0.000000},{dz:0.000000},0,0,0)");
                            // TODO this should be a wait complete
                            Thread.Sleep(1000);
                            ExecuteLEonardScriptLine(-1, $"movel_incr_tool(0,0,0,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        }
                        break;
                    case 4:
                        if (abs_dx > 0.020 || abs_dy > 0.020 || abs_dz > 0.020 ||
                            abs_drx > 15 || abs_dry > 15)
                            ExecError($"Excessive gocator_adjust [{dx:0.000000} m, {dy:0.000000} m, {dz:0.000000} m, {drx:0.000000} deg, {dry:0.000000} deg, 0]");
                        else
                            ExecuteLEonardScriptLine(-1, $"movel_incr_tool({dx}:0.000000,{dy}:0.000000,{dz}:0.000000,{deg2rad(drx):0.000000},{deg2rad(dry):0.000000},0)");
                        break;
                    default:
                        break;
                }
                return true;
            }

            // write_gocator_data
            if (command.StartsWith("gocator_write_data("))
            {
                LogInterpret("gocator_write_data", lineNumber, origLine);

                string filename = ExtractParameters(command);
                if (filename.Length < 1)
                {
                    ExecError("No file name specified");
                    return true;
                }

                string full_filename = Path.Combine(LEonardRoot, DataFolder, filename);
                full_filename = Path.ChangeExtension(full_filename, ".csv");

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
                    output += $",{GetRaw("gocator_ID")},{GetRaw("gc_decision")},{GetDist("gc_offset_x")},{GetDist("gc_offset_y")},{GetDist("gc_offset_z")}";
                    output += $",{GetDist("gc_outer_radius")},{GetAngle("gc_depth")},{GetAngle("gc_bevel_radius")},{GetAngle("gc_bevel_angle")},{GetAngle("gc_xangle")},{GetAngle("gc_yangle")}";
                    output += $",{GetDist("gc_cb_depth")},{GetAngle("gc_axis_tilt")},{GetAngle("gc_axis_orient")}";
                    output += $",{GetRaw("gh_decision")},{GetDist("gh_offset_x")},{GetDist("gh_offset_y")},{GetDist("gh_offset_z")},{GetDist("gh_radius")}";
                    output += $",{GetAngle("gp_xangle")},{GetAngle("gp_yangle")},{GetDist("gp_z_offset")},{GetDist("gp_std_dev")}";
                    writer.WriteLine(output);

                    writer.Close();
                }
                catch
                {
                    ExecError($"write_gocator_data(...) cannot write to\n{full_filename}");
                }

                return true;
            }

            // infile_open
            if (command.StartsWith("infile_open("))
            {
                LogInterpret("infile_open", lineNumber, origLine);

                string filename = ExtractParameters(command);
                if (filename.Length < 1)
                {
                    ExecError("No file name specified");
                    return true;
                }

                string full_filename = Path.Combine(LEonardRoot, DataFolder, filename);
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
                LogInterpret("infile_close", lineNumber, origLine);

                // Currently ignored
                string parameters = ExtractParameters(command);
                fileManager?.InputClose();
                return true;
            }

            // infile_scale
            if (command.StartsWith("infile_scale("))
            {
                LogInterpret("infile_scale", lineNumber, origLine);

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
                        fileManager.AddScale(scaleIndex, scale);
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
                LogInterpret("infile_readline", lineNumber, origLine);

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
                LogInterpret("write_cyline_data", lineNumber, origLine);

                string filename = ExtractParameters(command);
                if (filename.Length < 1)
                {
                    ExecError("No file name specified");
                    return true;
                }

                string full_filename = Path.Combine(LEonardRoot, DataFolder, filename);
                full_filename = Path.ChangeExtension(full_filename, ".csv");

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
                        writer.WriteLine("grind_ang_vel_rps,{0}", ReadVariable("grind_ang_vel_rps", "???"));
                        writer.WriteLine("grind_ang_accel_rpss,{0}", ReadVariable("grind_ang_accel_rpss", "???"));
                        writer.WriteLine("grind_ang_blend_radius_rad,{0}", ReadVariable("grind_ang_blend_radius_rad", "???"));

                        writer.Close();
                    }
                }
                catch
                {
                    ExecError($"write_cyline_data(...) cannot write to\n{full_filename}");
                }

                return true;
            }

            // device_connect
            if (command.StartsWith("device_connect("))
            {
                LogInterpret("device_connect", lineNumber, origLine);

                string deviceName = ExtractParameters(command);
                if (deviceName.Length < 1)
                {
                    ExecError("No device name specified");
                    return true;
                }

                DataRow row = devices.AsEnumerable().FirstOrDefault(r => (string)r["Name"] == deviceName);
                if (row == null)
                {
                    ExecError($"No device named {deviceName} was found.");
                    return true;
                }

                DeviceConnect(row);
                return true;
            }

            // device_disconnect
            if (command.StartsWith("device_disconnect("))
            {
                LogInterpret("device_disconnect", lineNumber, origLine);

                string deviceName = ExtractParameters(command);
                if (deviceName.Length < 1)
                {
                    ExecError("No device name specified");
                    return true;
                }

                DataRow row = devices.AsEnumerable().FirstOrDefault(r => (string)r["Name"] == deviceName);
                if (row == null)
                {
                    ExecError($"No device named {deviceName} was found.");
                    return true;
                }

                DeviceDisconnect(row);
                return true;
            }

            // device_connect_all
            if (command == "device_connect_all()")
            {
                LogInterpret("device_connect_all", lineNumber, origLine);

                DeviceConnectAllBtn_Click(null, null);
                return true;
            }

            // device_disconnect_all
            if (command == "device_disconnect_all()")
            {
                LogInterpret("device_disconnect_all", lineNumber, origLine);

                DeviceDisconnectAllBtn_Click(null, null);
                return true;
            }


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
                string commandInRecipe = command.Substring(0, openParenIndex);
                if (robotAlias.TryGetValue(commandInRecipe, out CommandSpec commandSpec))
                {
                    LogInterpret(commandInRecipe, lineNumber, origLine);
                    string parameters = ExtractParameters(command, commandSpec.nParams);
                    // Must be all numeric: Really, all (nnn,nnn,nnn)
                    if (!Regex.IsMatch(parameters, @"^[()+-.,0-9]*$"))
                        ExecError("Incorrect parameters");
                    else
                    {
                        if (commandSpec.nParams == 0 && parameters.Length == 0)   // Expected 0 parameters and got nothing
                            RobotSend(commandSpec.prefix);
                        else if ((commandSpec.nParams > 0 && parameters.Length > 0) ||   // Got some parameters and must have been the right number
                                 (commandSpec.nParams == -1 && parameters.Length > 0)    // Willing to accept whatever you have (as long as there's something!)
                                )
                            RobotSend(commandSpec.prefix + "," + parameters);
                        else
                            ExecError($"Wrong number of operands. Expected {commandSpec.nParams}");
                    }
                    return true;
                }
            }

            // Matched nothing above... could be an assignment operator =, -=, +=, ++, --
            if (UpdateVariable(command))
            {
                LogInterpret("assign", lineNumber, origLine);
                return true;
            }

            ExecError("Cannot interpret line");
            return true;
        }
        public bool ExecuteLEonardMessage(string prefix, string message, LeDeviceInterface dev)
        {
            log.Trace($"{prefix}: {message} {dev}");

            // TODO This gets broken if the user tries to do anything else with '#'
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
                ExecuteLEonardScriptLine(-1, statement.Substring(3), dev);
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

            log.Error($"{prefix} Illegal LEonardStatement statement: {statement}");
            return false;
        }
    }
}
