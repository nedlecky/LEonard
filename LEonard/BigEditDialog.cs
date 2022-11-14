// File: BigEditDialog.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Fullscreen (touch tablet) editor

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LEonard.MainForm;

namespace LEonard
{
    public partial class BigEditDialog : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm mainForm;
        IEnumerable<Control> allResizeControlList;
        int originalWidth;

        // Can override these before showing dialog
        public string Title { get; set; } = "??";
        public int ScreenWidth { get; set; } = 1000;
        public int ScreenHeight { get; set; } = 1000;
        public string Program { get; set; } = "";

        public BigEditDialog(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void BigEditDialog_Load(object sender, EventArgs e)
        {
            originalWidth = Width;
            allResizeControlList = TakeControlInventory(this);

            LoadPersistent();

            FilenameLbl.Text = Title;
            Top = 0;
            Left = 0;
            Width = ScreenWidth;
            Height = ScreenHeight;

            DialogResult = DialogResult.None;
            CancelBtn.Select();

            ProgramRTB.Text = Program;
        }
        private void BigEditDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePersistent();
        }

        private void KeepBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Program = ProgramRTB.Text;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            ProgramRTB.Text = Program;
        }

        private RegistryKey MyRegistryKey()
        {
            RegistryKey AppNameKey = mainForm.GetAppNameKey();
            RegistryKey FormNameKey = AppNameKey.CreateSubKey("BigEditDialog");

            return FormNameKey;
        }

        private void SavePersistent()
        {
            RegistryKey FormNameKey = MyRegistryKey();

            FormNameKey.SetValue("Left", Left);
            FormNameKey.SetValue("Top", Top);
            FormNameKey.SetValue("Width", Width);
            FormNameKey.SetValue("Height", Height);
        }
        private void LoadPersistent()
        {
            RegistryKey FormNameKey = MyRegistryKey();

            Width = (Int32)FormNameKey.GetValue("Width", Width);
            Height = (Int32)FormNameKey.GetValue("Height", Height);
            Left = (Int32)FormNameKey.GetValue("Left", (mainForm.Width - Width) / 2);
            Top = (Int32)FormNameKey.GetValue("Top", (mainForm.Height - Height) / 2);
        }

        private void BigEditDialog_Resize(object sender, EventArgs e)
        {
            double scalePct = Math.Min(100.0 * Width / originalWidth, 100);
            foreach (Control c in allResizeControlList) RescaleFont(c, scalePct * mainForm.GlobalFontScaleOverridePct / 100.0);
        }

        
        private void FullManualBtn_Click(object sender, EventArgs e)
        {
            mainForm.ShowPDF("LEonard%20User%20Manual.pdf");
        }

        private void URManualBtn_Click(object sender, EventArgs e)
        {
            mainForm.ShowPDF("Using%20Universal%20Robots%20with%20LEonard.pdf");
        }

        private void GocatorManualBtn_Click(object sender, EventArgs e)
        {
            mainForm.ShowPDF("Using%20LMI%20Gocators%20with%20LEonard.pdf");
        }
    }
}
