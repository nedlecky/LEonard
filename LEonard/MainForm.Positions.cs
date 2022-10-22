// File: MainForm.Positions.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: MainForm functions supporting Positions

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm: Form
    {
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
    }
}
