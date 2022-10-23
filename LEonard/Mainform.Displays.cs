// File: MainForm.Displays.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: MainForm functions forsupporting siplay resizing and font scaling

using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
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
    }
}
