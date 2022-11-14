// File: MessageDialog.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Two-button dialog with relabelable buttons optimized for use with touch screen

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LEonard.MainForm;

namespace LEonard
{
    public partial class MessageDialog : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm mainForm;
        IEnumerable<Control> allResizeControlList;
        int originalWidth;

        public DialogResult result = DialogResult.OK;

        // Can override these before showing dialog
        public string Title { get; set; } = "??";
        public string Label { get; set; } = "???";
        public Color TextColor { get; set; } = Color.Black;
        public string OkText { get; set; } = "OK";
        public string CancelText { get; set; } = "Cancel";

        public bool IsTypeIn { get; set; } = false;
        public string TypeInLabel { get; set; } = "";
        public string TypeInText { get; set; }

        public bool IsMotionWait { get; set; } = false;

        public MessageDialog(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            originalWidth = Width;
            allResizeControlList = TakeControlInventory(this);

            LoadPersistent();

            Text = Title;
            label1.Text = Label;
            label1.ForeColor = TextColor;
            OkBtn.Text = OkText;
            CancelBtn.Text = CancelText;
            result = DialogResult.None;
            OkBtn.Select();

            // Setup for type in
            if (IsTypeIn)
            {
                TypeInLbl.Text = TypeInLabel;
                TypeInTxt.Text = TypeInText;
                TypeInLbl.Visible = true;
                TypeInTxt.Visible = true;
                TypeInTxt.Select();
            }
            else
            {
                TypeInLbl.Text = "??";
                TypeInTxt.Text = "??";
                TypeInLbl.Visible = false;
                TypeInTxt.Visible = false;
            }

            // Setup for Motion Wait
            if (IsMotionWait)
            {
                OkBtn.BackColor = Color.Red;
                CancelBtn.BackColor = Color.Red;
            }
        }

        private void MessageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePersistent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            TypeInText = TypeInTxt.Text;

            if (IsMotionWait)
            {
                // Not only halt the bot but also stop any running program
                mainForm?.RobotSendHalt();
                result = DialogResult.Cancel;
            }
            else
                result = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (IsMotionWait)
            {
                // Not only halt the bot but also stop any running program
                mainForm?.RobotSendHalt();
                result = DialogResult.Cancel;
            }
            else
                result = DialogResult.Cancel;
        }

        private RegistryKey MyRegistryKey()
        {
            RegistryKey AppNameKey = mainForm.GetAppNameKey();
            RegistryKey FormNameKey = AppNameKey.CreateSubKey("MessageDialog");

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

        private void MessageDialog_Resize(object sender, EventArgs e)
        {
            double scalePct = Math.Min(100.0 * Width / originalWidth, 100);
            foreach (Control c in allResizeControlList) RescaleFont(c, scalePct * mainForm.GlobalFontScaleOverridePct / 100.0);
        }
    }
}
