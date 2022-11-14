// File: FileSaveAsDialog.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: Custom Save As dialog with large buttons for use with touch screen

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
    public partial class FileSaveAsDialog : Form
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        MainForm mainForm;
        IEnumerable<Control> allResizeControlList;
        int originalWidth;

        public string Title { get; set; }
        public string Filter { get; set; }
        public string InitialDirectory { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; } = ".txt";

        private string[] fileList;
        private List<string> directoryList;


        public FileSaveAsDialog(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }
        private void FileSaveAsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePersistent();
        }

        private void FileSaveAsDialog_Load(object sender, EventArgs e)
        {
            originalWidth = Width;
            allResizeControlList = TakeControlInventory(this);

            LoadPersistent();
            
            TitleLbl.Text = Title;
            LoadDirectory(InitialDirectory);


            FileNameTxt.Text = Path.GetFileName(FileName);
            FileNameTxt.Select();
            FileNameTxt.SelectAll();
        }

        // **********************************************************************************************
        // FileNameTxt Methods
        // **********************************************************************************************

        private void FileNameTxt_Enter(object sender, EventArgs e)
        {
            log.Debug("FileNameTxt_Enter(null,null)");
            FileListBox.SelectedItem = null;
        }

        // **********************************************************************************************
        // DirectoryListBox Methods
        // **********************************************************************************************
        private void DirectoryListBox_Click(object sender, EventArgs e)
        {
            FileListBox.SelectedIndex = -1;
        }
        private void DirectoryListBox_DoubleClick(object sender, EventArgs e)
        {
            if (DirectoryListBox.SelectedIndex >= 0)
                LoadDirectory(directoryList[DirectoryListBox.SelectedIndex]);
        }


        // **********************************************************************************************
        // FileListBox Methods
        // **********************************************************************************************

        private void FileListBox_Click(object sender, EventArgs e)
        {
            DirectoryListBox.SelectedIndex = -1;
            FileNameTxt.Text = FileListBox.SelectedItem.ToString();
        }
        private void FileListBox_DoubleClick(object sender, EventArgs e)
        {
            FileNameTxt.Text = FileListBox.SelectedItem.ToString();
            SaveBtn_Click(sender, e);
        }

        // **********************************************************************************************
        // Button Methods
        // **********************************************************************************************

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // If nothing selected, try to interpret as a type-in?
            if (FileListBox.SelectedIndex < 0)
            {
                string filename = Path.Combine(DirectoryNameLbl.Text, FileNameTxt.Text);
                FileName = Path.ChangeExtension(filename, Extension);
            }
            else
            {

                //FileName = fileList[FileListBox.SelectedIndex];
                FileName = Path.Combine(DirectoryNameLbl.Text, FileListBox.SelectedItem.ToString());
            }
            log.Debug("SaveBtn_Click(...) Filename={0}", FileName);
            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            FileName = "";
            log.Debug("CancelBtn_Click(...)");
            DialogResult = DialogResult.Cancel;
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
                log.Info($"Folder Created: {createDirectory}");
                LoadDirectory(DirectoryNameLbl.Text);
            }

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            log.Debug("DeleteBtn_Click(...)");

            // Delete a file?
            if (FileListBox.SelectedIndex >= 0)
            {

                string deleteFilename = Path.Combine(DirectoryNameLbl.Text, FileListBox.SelectedItem.ToString());
                MessageDialog messageForm = new MessageDialog(mainForm)
                {
                    Title = "System Confirmation",
                    Label = $"Delete FILE {deleteFilename}\n ARE YOU SURE?",
                    OkText = "&Yes",
                    CancelText = "&No"
                };
                DialogResult result = messageForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.Delete(deleteFilename);
                    log.Info("Deleted {0}", deleteFilename);
                    LoadFiles(DirectoryNameLbl.Text);
                }
            }
            // Delete a directory?
            else if (DirectoryListBox.SelectedIndex >= 0)
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

        // **********************************************************************************************
        // Support Functions
        // **********************************************************************************************

        private void LoadFiles(string path, string nameStartsWith = null)
        {
            fileList = Directory.GetFiles(path, Filter);
            FileListBox.Items.Clear();
            foreach (string file in fileList)
            {
                string filename = Path.GetFileName(file);

                if (nameStartsWith == null || filename.StartsWith(nameStartsWith))
                    FileListBox.Items.Add(Path.GetFileName(file));
            }
        }

        private void LoadDirectory(string path)
        {
            DirectoryNameLbl.Text = path;

            string[] subDirectoryList = Directory.GetDirectories(path);

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

            FileNameTxt.Select();
            FileNameTxt.Text = "";
            LoadFiles(path);
        }

        private RegistryKey MyRegistryKey()
        {
            RegistryKey AppNameKey = mainForm.GetAppNameKey();
            RegistryKey FormNameKey = AppNameKey.CreateSubKey("FileSaveAsDialog");

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

        private void FileSaveAsDialog_Resize(object sender, EventArgs e)
        {
            double scalePct = Math.Min(100.0 * Width / originalWidth, 100);
            foreach (Control c in allResizeControlList) RescaleFont(c, scalePct * mainForm.GlobalFontScaleOverridePct / 100.0);
        }

    }
}
