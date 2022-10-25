// File: MainForm.Tools.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: MainForm functions supporting Tools

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
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
                ExecuteLEonardScriptLine(-1, string.Format("select_tool({0})", name));
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
            ExecuteLEonardScriptLine(-1, "tool_on()");
        }

        private void ToolOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEonardScriptLine(-1, "tool_off()");
        }

        private void CoolantTestBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEonardScriptLine(-1, "coolant_on()");
        }

        private void CoolantOffBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEonardScriptLine(-1, "coolant_off()");
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
            ExecuteLEonardScriptLine(-1, string.Format("set_door_closed_input({0})", DoorClosedInputTxt.Text));
        }

        private void SetFootswitchInputBtn_Click(object sender, EventArgs e)
        {
            ExecuteLEonardScriptLine(-1, string.Format("set_footswitch_pressed_input({0})", FootswitchPressedInputTxt.Text));
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
    }
}
