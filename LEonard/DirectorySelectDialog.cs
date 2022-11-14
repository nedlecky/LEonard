// File: DirectorySelectDialog.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Custom Directory Select dialog with large buttons for use with touch screen

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
    public partial class DirectorySelectDialog : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm mainForm;
        IEnumerable<Control> allResizeControlList;
        int originalWidth;
        int originalHeight;

        public string SelectedPath { get; set; }
        public string Title { get; set; }

        List<string> directoryList;
        public DirectorySelectDialog(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void DirectorySelectDialog_Load(object sender, EventArgs e)
        {
            originalWidth = Width;
            originalHeight = Height;
            allResizeControlList = TakeControlInventory(this);

            LoadPersistent();

            TitleLbl.Text = Title;
            LoadDirectory(SelectedPath);
        }
        private void DirectorySelectDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePersistent();
        }


        // **********************************************************************************************
        // DirectoryListBox Methods
        // **********************************************************************************************

        private void DirectoryListBox_Click(object sender, EventArgs e)
        {
            //DirectoryNameLbl.Text = directoryList[DirectoryListBox.SelectedIndex];
        }

        private void DirectoryListBox_DoubleClick(object sender, EventArgs e)
        {
            if (DirectoryListBox.SelectedIndex >= 0)
            {
                SelectedPath = directoryList[DirectoryListBox.SelectedIndex];
                LoadDirectory(SelectedPath);
            }
        }

        // **********************************************************************************************
        // Button Methods
        // **********************************************************************************************

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            SelectedPath = DirectoryNameLbl.Text;
            log.Debug("SelectBtn_Click(...) SelectedPath={0}", SelectedPath);
            DialogResult = DialogResult.OK;
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SelectedPath = "";
            log.Debug("CancelBtn_Click(...)");
            DialogResult = DialogResult.Cancel;
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            log.Debug("DeleteBtn_Click(...)");

            // Delete a directory?
            if (DirectoryListBox.SelectedIndex >= 0)
            {
                if (DirectoryListBox.SelectedItem.ToString() != "..") // Don't delete your parent directory!
                {
                    string deleteDirectory = Path.Combine(DirectoryNameLbl.Text, DirectoryListBox.SelectedItem.ToString());
                    MessageDialog messageForm = new MessageDialog(mainForm)
                    {
                        Title = "System Confirmation",
                        Label = $"Delete DIRECTORY AND CONTENTS\n{deleteDirectory}",
                        OkText = "&Yes",
                        CancelText = "&No"
                    };
                    DialogResult result = messageForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Directory.Delete(deleteDirectory, true);
                        log.Info("Deleted directory {0}", deleteDirectory);
                        LoadDirectory(DirectoryNameLbl.Text);
                    }
                }
            }
        }
        private void NewFolderBtn_Click(object sender, EventArgs e)
        {
            MessageDialog messageForm = new MessageDialog(mainForm)
            {
                Title = "System Confirmation",
                Label = $"Create new folder in\n{DirectoryNameLbl.Text}?",
                OkText = "&Yes",
                CancelText = "&No",
                IsTypeIn = true,
                TypeInLabel = "New Folder:",
                TypeInText = ""
            };
            DialogResult result = messageForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string createDirectory = Path.Combine(DirectoryNameLbl.Text, messageForm.TypeInText);
                Directory.CreateDirectory(createDirectory);
                log.Info("Folder Created: {0}", createDirectory);
                LoadDirectory(DirectoryNameLbl.Text);
            }
        }
        private RegistryKey MyRegistryKey()
        {
            RegistryKey AppNameKey = mainForm.GetAppNameKey();
            RegistryKey FormNameKey = AppNameKey.CreateSubKey("DirectorySelectDialog");

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

        // **********************************************************************************************
        // Support Functions
        // **********************************************************************************************

        private void LoadDirectory(string path)
        {
            string[] subDirectoryList;
            try
            {
                subDirectoryList = Directory.GetDirectories(path);
            }
            catch
            {
                return;
            }

            directoryList = new List<string>();
            DirectoryListBox.Items.Clear();

            DirectoryInfo parent = Directory.GetParent(path);
            if (parent != null)
            {

                DirectoryListBox.Items.Add("..");
                directoryList.Add(Directory.GetParent(path).FullName);
            }

            foreach (string directory in subDirectoryList)
            {
                DirectoryListBox.Items.Add(Path.GetFileName(directory));
                directoryList.Add(directory);
            }
            DirectoryNameLbl.Text = path;
        }

        private void DirectorySelectDialog_Resize(object sender, EventArgs e)
        {
            double scalePct = mainForm.ScaleRecommender(Width, originalWidth, Height, originalHeight);
            foreach (Control c in allResizeControlList) RescaleFont(c, scalePct);
        }
    }
}
