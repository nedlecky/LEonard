// File: MainForm.LEscriptEdit.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Copyright 2021, 2022, 2023
// Purpose: MainForm functions supporting editing of LEscript programs

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm
    {
        // Drop any highlighted lines!
        private enum RecipeState
        {
            INIT,
            NEW,
            LOADED,
            MODIFIED,
            RUNNING
        }
        RecipeState recipeState = RecipeState.INIT;
        RecipeState recipeStateAtRun = RecipeState.INIT;
        private void SetRecipeState(RecipeState s)
        {
            if (recipeState != s)
            {
                log.Debug("SetRecipeState({0})", s.ToString());

                RecipeState oldRecipeState = recipeState;
                recipeState = s;

                switch (recipeState)
                {
                    case RecipeState.NEW:
                        NewLEonardScriptBtn.Enabled = false;
                        LoadLEonardScriptBtn.Enabled = true;
                        SaveLEonardScriptBtn.Enabled = false;
                        SaveAsLEonardScriptBtn.Enabled = true;
                        break;
                    case RecipeState.LOADED:
                        NewLEonardScriptBtn.Enabled = true;
                        LoadLEonardScriptBtn.Enabled = true;
                        SaveLEonardScriptBtn.Enabled = false;
                        SaveAsLEonardScriptBtn.Enabled = true;
                        break;
                    case RecipeState.MODIFIED:
                        NewLEonardScriptBtn.Enabled = true;
                        LoadLEonardScriptBtn.Enabled = true;
                        SaveLEonardScriptBtn.Enabled = true;
                        SaveAsLEonardScriptBtn.Enabled = true;
                        break;
                    case RecipeState.RUNNING:
                        recipeStateAtRun = oldRecipeState;
                        NewLEonardScriptBtn.Enabled = false;
                        LoadLEonardScriptBtn.Enabled = false;
                        SaveLEonardScriptBtn.Enabled = false;
                        SaveAsLEonardScriptBtn.Enabled = false;
                        break;
                }
                NewLEonardScriptBtn.BackColor = NewLEonardScriptBtn.Enabled ? Color.Green : Color.Gray;
                LoadLEonardScriptBtn.BackColor = LoadLEonardScriptBtn.Enabled ? Color.Green : Color.Gray;
                SaveLEonardScriptBtn.BackColor = SaveLEonardScriptBtn.Enabled ? Color.Green : Color.Gray;
                SaveAsLEonardScriptBtn.BackColor = SaveAsLEonardScriptBtn.Enabled ? Color.Green : Color.Gray;
            }
        }


        private string recipeAsLoaded = "";  // As it was when loaded so we can test for actual mods
        private bool RecipeWasModified()
        {
            return recipeAsLoaded != LEonardScriptRTB.Text;
        }
        bool LoadLEonardScriptFile(string file)
        {
            log.Info("LoadRecipeFile({0})", file);
            LEonardScriptFilenameLbl.Text = "";
            LEonardScriptRTB.Text = "";
            try
            {
                LEonardScriptRTB.LoadFile(file, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                LEonardScriptFilenameLbl.Text = file;
                recipeAsLoaded = LEonardScriptRTB.Text;
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Can't open {0}", file);
                return false;
            }
        }

        private void NewLEonardScriptBtn_Click(object sender, EventArgs e)
        {
            log.Info("NewRecipeBtn_Click(...)");
            if (RecipeWasModified())
            {
                var result = ConfirmMessageBox(String.Format("LEonardScript [{0}] has changed.\nSave changes?", LoadLEonardScriptBtn.Text));
                if (result == DialogResult.OK)
                    SaveLEonardScriptBtn_Click(null, null);
            }

            SetRecipeState(RecipeState.NEW);
            SetState(RunState.IDLE);
            LEonardScriptFilenameLbl.Text = "Untitled";
            LEonardScriptRTB.Clear();
            recipeAsLoaded = "";
            MainTab.SelectedIndex = 1; // = "Program";
        }

        private void LoadLEonardScriptBtn_Click(object sender, EventArgs e)
        {
            log.Info("LoadRecipeBtn_Click(...)");
            if (RecipeWasModified())
            {
                var result = ConfirmMessageBox(String.Format("LEonardScript [{0}] has changed.\nSave changes?", LoadLEonardScriptBtn.Text));
                if (result == DialogResult.OK)
                    SaveLEonardScriptBtn_Click(null, null);
            }

            string initialDirectory;
            if (LEonardScriptFilenameLbl.Text != "Untitled" && LEonardScriptFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(LEonardScriptFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Code");

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Recipe",
                Filter = "*.txt",
                InitialDirectory = initialDirectory
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadLEonardScriptFile(dialog.FileName))
                {
                    SetRecipeState(RecipeState.LOADED);
                    SetState(RunState.READY);
                }
            }
        }

        private void SaveLEonardScriptBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveRecipeBtn_Click(...)");
            if (LEonardScriptFilenameLbl.Text == "Untitled" || LEonardScriptFilenameLbl.Text == "")
                SaveAsLEonardScriptBtn_Click(null, null);
            else
            {
                log.Info("Save Recipe program to {0}", LEonardScriptFilenameLbl.Text);
                LEonardScriptRTB.SaveFile(LEonardScriptFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                recipeAsLoaded = LEonardScriptRTB.Text;
                SetRecipeState(RecipeState.LOADED);
                SetState(RunState.READY);
            }
        }

        private void SaveAsLEonardScriptBtn_Click(object sender, EventArgs e)
        {
            log.Info("SaveAsRecipeBtn_Click(...)");

            string initialDirectory;
            if (LEonardScriptFilenameLbl.Text != "Untitled" && LEonardScriptFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(LEonardScriptFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Code");

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonardScript program As...",
                Filter = "*.txt",
                InitialDirectory = initialDirectory,
                FileName = LEonardScriptFilenameLbl.Text,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".txt")) filename += ".txt";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        LEonardScriptFilenameLbl.Text = filename;
                        SaveLEonardScriptBtn_Click(null, null);
                    }
                }
            }
        }
        private void LEonardScriptRTB_ModifiedChanged(object sender, EventArgs e)
        {
            SetRecipeState(RecipeState.MODIFIED);
        }
    }
}
