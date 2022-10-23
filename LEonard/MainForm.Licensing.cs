// File: MainForm.Licensing.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: MainForm functions for interfacing with and creating licenses

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
        private void GetLicenseStatus()
        {
            LicenseStatusLbl.Text = protection.GetStatus();
        }
        private void LicenseStatusLbl_DoubleClick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int challenge = rnd.Next(10000, 99999);

            SetValueForm form = new SetValueForm(this)
            {
                Value = 0,
                Label = $"Passcode {challenge} for ADJUST LICENSE",
                NumberOfDecimals = 0,
                MaxAllowed = 999999,
                MinAllowed = 0,
                IsPassword = true,
            };
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.Value == challenge + 1)
                {
                    LicenseAdjustGrp.Visible = true;
                    SaveLicenseBtn.Enabled = false;
                }
                else
                {
                    LicenseAdjustGrp.Visible = false;
                    ErrorMessageBox("Incorrect licensing passcode");
                    return;
                }
            }
        }

        private void TrialLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.CreateTrialLicense(30);
            protection.SaveLicense(licenseFilename);
            protection.LoadLicense(licenseFilename);
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }
        private void JavaLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleJava();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void PythonLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.TogglePython();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void UrLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleUR();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void GrindingLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleGrinding();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void GocatorLicenseBtn_Click(object sender, EventArgs e)
        {
            Protection.license.ToggleGocator();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void NewLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.CreateNewLicense();
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = true;
        }

        private void ReloadLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.LoadLicense(licenseFilename);
            GetLicenseStatus();
            SaveLicenseBtn.Enabled = false;
        }
        private void SaveLicenseBtn_Click(object sender, EventArgs e)
        {
            protection.SaveLicense(licenseFilename);
            SaveLicenseBtn.Enabled = false;
        }
    }
}
