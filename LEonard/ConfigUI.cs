using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
        void LoadPersistent()
        {
            // Pull setup info from registry.... these are overwritten on exit or with various config save operations
            // Note default values are specified here as well
            Crawl("LoadPersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");
            LEonardRoot = (string)AppNameKey.GetValue("LEonardRoot", "\\");
            LEonardRootLbl.Text = LEonardRoot;
            StartupDevicesLbl.Text = (string)AppNameKey.GetValue("StartupDevicesLbl.Text", "");
            AutoLoadChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoLoadChk.Checked", "False"));
            AutoStartChk.Checked = Convert.ToBoolean(AppNameKey.GetValue("AutoStartChk.Checked", "False"));

            PersonalityTabs.SelectedIndex = (Int32)AppNameKey.GetValue("PersonalityTabs.SelectedIndex", 0);
        }

        void SavePersistent()
        {
            Crawl("SavePersistent()");

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey AppNameKey = SoftwareKey.CreateSubKey("LEonard");
            AppNameKey.SetValue("LEonardRoot", LEonardRoot);
            AppNameKey.SetValue("StartupDevicesLbl.Text", StartupDevicesLbl.Text);
            AppNameKey.SetValue("AutoLoadChk.Checked", AutoLoadChk.Checked);
            AppNameKey.SetValue("AutoStartChk.Checked", AutoStartChk.Checked);

            AppNameKey.SetValue("PersonalityTabs.SelectedIndex", PersonalityTabs.SelectedIndex);
        }
        private void ChangeLEonardRootBtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Crawl(String.Format("You selected ERROR LEonardRoot={0}", dialog.SelectedPath));
                LEonardRoot = dialog.SelectedPath;
                LEonardRootLbl.Text = LEonardRoot;

                DefaultConfigBtn.Enabled = true;
                LoadConfigBtn.Enabled = true;
                SaveConfigBtn.Enabled = true;
            }

        }

        private void ChangeStartupDevicesBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Startup LEonard Devices File";
            dialog.Filter = "Device files|*.dev";
            dialog.InitialDirectory = LEonardRoot;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StartupDevicesLbl.Text = dialog.FileName;
                Crawl("Startup Devices file set to " + StartupDevicesLbl.Text);

                DefaultConfigBtn.Enabled = true;
                LoadConfigBtn.Enabled = true;
                SaveConfigBtn.Enabled = true;

                if (MessageBox.Show("Load this file now?", "LEonard Confiormation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LoadDevicesFile(StartupDevicesLbl.Text);
            }
        }

        private void AutoLoadChk_CheckedChanged(object sender, EventArgs e)
        {
            DefaultConfigBtn.Enabled = true;
            LoadConfigBtn.Enabled = true;
            SaveConfigBtn.Enabled = true;
        }

        private void AutoStartChk_CheckedChanged(object sender, EventArgs e)
        {
            DefaultConfigBtn.Enabled = true;
            LoadConfigBtn.Enabled = true;
            SaveConfigBtn.Enabled = true;
        }

        private void DefaultConfigBtn_Click(object sender, EventArgs e)
        {
            LEonardRoot = "";
            LEonardRootLbl.Text = LEonardRoot;
            StartupDevicesLbl.Text = "";
            AutoLoadChk.Checked = false;
            AutoStartChk.Checked = false;

            DefaultConfigBtn.Enabled = false;
            LoadConfigBtn.Enabled = true;
            SaveConfigBtn.Enabled = true;
        }

        private void LoadConfigBtn_Click(object sender, EventArgs e)
        {
            LoadPersistent();
            DefaultConfigBtn.Enabled = true;
            LoadConfigBtn.Enabled = false;
            SaveConfigBtn.Enabled = false;
        }

        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            SavePersistent();
            DefaultConfigBtn.Enabled = true;
            LoadConfigBtn.Enabled = false;
            SaveConfigBtn.Enabled = false;
        }
    }
}
