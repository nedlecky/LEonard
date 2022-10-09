// File: MessageDialog.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
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

        public DialogResult result = DialogResult.OK;

        // Can override these before showing dialog
        public string Title { get; set; } = "??";
        public string Label { get; set; } = "???";
        public string OkText { get; set; } = "OK";
        public string CancelText { get; set; } = "Cancel";

        public bool IsTypeIn { get; set; } = false;
        public string TypeInLabel { get; set; } = "";
        public string TypeInText { get; set; }

        public bool IsMotionWait { get; set; } = false;



        MainForm mainForm;
        int originalWidth;
        bool uiUpdatesAreLive = false;

        public MessageDialog(MainForm _mainForm = null)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            TakeControlInventory();
            originalWidth = Width;

            LoadPersistent();
            ScaleUiText();
            uiUpdatesAreLive = true;

            Text = Title;
            label1.Text = Label;
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

            Width = (Int32)FormNameKey.GetValue("Width", 1300);
            Height = (Int32)FormNameKey.GetValue("Height", 800);
            Left = (Int32)FormNameKey.GetValue("Left", (mainForm.Width - Width) / 2);
            Top = (Int32)FormNameKey.GetValue("Top", (mainForm.Height - Height) / 2);
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        // Lists of all controls that get tweaked in UI management
        IEnumerable<Control> buttonList;
        IEnumerable<Control> labelList;
        IEnumerable<Control> textboxList;

        private void RememberInitialFont(Control ctl)
        {
            ControlInfo controlInfo = new ControlInfo();
            controlInfo.originalFont = ctl.Font;
            ctl.Tag = controlInfo;
        }
        private void TakeControlInventory()
        {
            buttonList = GetAll(this, typeof(Button));
            labelList = GetAll(this, typeof(Label));
            textboxList = GetAll(this, typeof(TextBox));

            log.Info("Button Count: " + buttonList.Count());
            log.Info("Label Count: " + labelList.Count());
            log.Info("TextBox Count: " + textboxList.Count());

            foreach (Control c in buttonList) RememberInitialFont(c);
            foreach (Control c in labelList) RememberInitialFont(c);
            foreach (Control c in textboxList) RememberInitialFont(c);
        }
        void RescaleFont(Control ctl, double scale)
        {
            Font oldFont = ((ControlInfo)ctl.Tag).originalFont;
            Font newFont = new Font(oldFont.FontFamily, (float)(oldFont.Size * scale / 100.0), oldFont.Style, oldFont.Unit);
            ctl.Font = newFont;
        }

        void ScaleUiText()
        {
            double scale = 100.0 * Width / originalWidth;

            foreach (Control c in buttonList) RescaleFont(c, scale);
            foreach (Control c in labelList) RescaleFont(c, scale);
            foreach (Control c in textboxList) RescaleFont(c, scale);
        }

        private void MessageDialog_Resize(object sender, EventArgs e)
        {
            if (uiUpdatesAreLive) ScaleUiText();
        }
    }
}
