// File: MainForm.UR.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: MainForm functions providing UR and Grind interfaces

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
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
    }
}
