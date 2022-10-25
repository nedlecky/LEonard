// File: SplashForm.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Implements the splash screen (also used as the About dialog)

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LEonard
{
    public partial class SplashForm : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public bool AutoClose { get; set; } = true;
        MainForm mainForm;

        public SplashForm(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            string companyName = Application.CompanyName;
            string appName = Application.ProductName;
            string productVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string executable = Application.ExecutablePath;
            string filename = Path.GetFileName(executable);
            string directory = Path.GetDirectoryName(executable);
            string caption = "Product: " + appName + " Rev " + productVersion;
#if DEBUG
            caption += "\n RUNNING IN DEBUG MODE";
#endif
            Text = caption;
            VersionLbl.Text = caption;

            if (AutoClose)
            {
                Left = mainForm.Left + (mainForm.Width - Width) / 2;
                Top = mainForm.Top + (mainForm.Height - Height) / 2;
                CloseBtn.Visible = false;
                CloseTmr.Interval = 10000;
                CloseTmr.Enabled = true;
            }
            else
                CloseBtn.Visible = true;
        }

        // Form closes with the Close button, a close timer, or any click anywhere in the form!
        private void CloseTmr_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SplashForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
