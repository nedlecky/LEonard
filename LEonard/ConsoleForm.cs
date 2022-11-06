// File: ConsoleForm.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Unified console form... this captures Console.WriteLine

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LEonard.MainForm;


namespace LEonard
{
    public partial class ConsoleForm : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm mainForm;
        IEnumerable<Control> allResizeControlList;
        int originalWidth;

        private StringRedir RedirConsole;
        private TextWriter ConsoleWriter;
        public ConsoleForm(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;

            //Console.WriteLine("ConsoleForm() line to ORIGINAL console.");

            // Here we redirect Console.WriteLine to a RichTextBox control. 
            ConsoleWriter = Console.Out;    // Save the current console TextWriter. 
            RedirConsole = new StringRedir(ref ConsoleRTB);
            Console.SetOut(RedirConsole);   // Set console output to the StringRedir class. 

            //Console.WriteLine("ConsoleForm() line to NEW console.");
        }

        ~ConsoleForm()
        {
            //Console.WriteLine(" ~ConsoleForm() line to NEW console.");
            Console.SetOut(ConsoleWriter);  // Redirect Console back to original TextWriter. 
            RedirConsole.Close();           // Close our StringRedir TextWriter. 
            //Console.WriteLine(" ~ConsoleForm() line to ORIGINAL console.");
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            Text = "LEonard Console";

            originalWidth = Width;
            allResizeControlList = TakeControlInventory(this);

            LoadPersistent();
        }
        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePersistent();
        }

        private void AlwaysOnTopChk_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopChk.Checked;
        }

        private void HideBtn_Click(object sender, EventArgs e)
        {
            mainForm.IsConsoleVisible = false;
            Hide();
        }
        public void Clear()
        {
            ConsoleRTB.Clear();
            ConsoleRTB.Text = "Console cleared\n";
        }
        private void ConsoleClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private RegistryKey MyRegistryKey()
        {
            RegistryKey AppNameKey = mainForm.GetAppNameKey();
            RegistryKey FormNameKey = AppNameKey.CreateSubKey("ConsoleForm");

            return FormNameKey;
        }

        private void SavePersistent()
        {
            RegistryKey FormNameKey = MyRegistryKey();

            FormNameKey.SetValue("Left", Left);
            FormNameKey.SetValue("Top", Top);
            FormNameKey.SetValue("Width", Width);
            FormNameKey.SetValue("Height", Height);
            FormNameKey.SetValue("AlwaysOnTopChk.Checked", AlwaysOnTopChk.Checked);
        }
        private void LoadPersistent()
        {
            RegistryKey FormNameKey = MyRegistryKey();

            Width = (Int32)FormNameKey.GetValue("Width", 800);
            Height = (Int32)FormNameKey.GetValue("Height", 800);
            Left = (Int32)FormNameKey.GetValue("Left", (mainForm.Width - Width) / 2);
            Top = (Int32)FormNameKey.GetValue("Top", (mainForm.Height - Height) / 2);
            AlwaysOnTopChk.Checked = Convert.ToBoolean(FormNameKey.GetValue("AlwaysOnTopChk.Checked", "True"));

            FormNameKey.SetValue("AlwaysOnTopChk.Checked", AlwaysOnTopChk.Checked);
        }

        private void ConsoleForm_Resize(object sender, EventArgs e)
        {
            double scale = Math.Min(100.0 * Width / originalWidth, 100);
            foreach (Control c in allResizeControlList) RescaleFont(c, scale);
        }

        private void ConsoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            //log.Trace("MainForm_KeyDown: {0}", e.KeyData);
            switch (e.KeyData)
            {
                case Keys.F12:
                    mainForm.IsConsoleVisible = false;
                    Hide();
                    break;
            }
        }
    }
    public class StringRedir : StringWriter
    { // Redirecting Console output to RichtextBox
        private RichTextBox outBox;

        public StringRedir(ref RichTextBox textBox)
        {
            outBox = textBox;
        }

        public override void WriteLine(string message)
        {
            MainForm.CrawlRTB(outBox, message);
        }
    }
}
