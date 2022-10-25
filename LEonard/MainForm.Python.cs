// File: MainForm.Python.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Python system for LEonard

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonard
{
    public partial class MainForm : Form
    {
        private void lePrintP(string msg)
        {
            CrawlRTB(PythonConsoleRTB, msg);
            log.Info("P** " + msg);
        }
        private void InitializePythonEngine()
        {
            pythonEngine = IronPython.Hosting.Python.CreateEngine();
            pythonScope = pythonEngine.CreateScope();

            pythonScope.RemoveVariable("print");

            pythonScope.SetVariable("lePrompt", new Action<string>((string prompt) => PromptOperator("Python Prompt:\n" + prompt)));
            pythonScope.SetVariable("lePrint", new Action<string>((string msg) => lePrintP(msg)));
            pythonScope.SetVariable("leLogInfo", new Action<string>((string msg) => log.Info(msg)));
            pythonScope.SetVariable("leLogError", new Action<string>(s => log.Error(s)));
            pythonScope.SetVariable("leExec", new Action<string>((string line) => ExecuteLEonardScriptLine(-1, line)));
            pythonScope.SetVariable("leWriteVariable", new Action<string, string>((string name, string value) => WriteVariable(name, value)));
            pythonScope.SetVariable("leReadVariable", new Func<string, string>((string name) => ReadVariable(name)));
            pythonScope.SetVariable("foo", "fighter");
        }

        private void PythonRunBtn_Click(object sender, EventArgs e)
        {
            if (!protection.RunLEonard())
            {
                ErrorMessageBox("Cannot run. LEonard license missing!");
                return;
            }

            try
            {
                Microsoft.Scripting.Hosting.ScriptSource pythonScript = pythonScope.Engine.CreateScriptSourceFromString(PythonCodeRTB.Text);
                pythonScript.Execute(pythonScope);
            }
            catch
            {

            }
        }

        private void PythonNewBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonNewBtn_Click(...)");

            if (PythonCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Python code [{PythonFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    PythonSaveBtn_Click(null, null);
            }

            PythonCodeRTB.Text = "";
            PythonRunBtn.Enabled = false;
            PythonNewBtn.Enabled = false;
            PythonSaveBtn.Enabled = false;
            PythonSaveAsBtn.Enabled = false;
            PythonFilenameLbl.Text = "Untitled";
        }

        private bool LoadPythonProgram(string filename)
        {
            if (filename == null || filename == "Untitled" || filename.Length < 2)
            {
                PythonFilenameLbl.Text = "Untitled";
                return false;
            }

            try
            {
                PythonCodeRTB.LoadFile(filename, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            }
            catch
            {
                ErrorMessageBox($"Cannot load Python program {filename}");
                return false;
            }

            PythonFilenameLbl.Text = filename;
            PythonCodeRTB.Modified = false;
            PythonSaveAsBtn.Enabled = true;
            PythonSaveBtn.Enabled = false;
            PythonNewBtn.Enabled = true;

            return true;
        }
        private void PythonLoadBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonLoadBtn_Click(...)");
            if (PythonCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Python code [{PythonFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    PythonSaveAsBtn_Click(null, null);
            }

            string initialDirectory;
            if (PythonFilenameLbl.Text != "Untitled" && PythonFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(PythonFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Python Program",
                Filter = "*.py",
                InitialDirectory = initialDirectory,
                Extension = ".py"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadPythonProgram(dialog.FileName);
        }

        private void PythonSaveBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonSaveBtn_Click(...)");
            if (PythonFilenameLbl.Text == "Untitled" || PythonFilenameLbl.Text == "")
                PythonSaveAsBtn_Click(null, null);
            else
            {
                log.Info("Save Python program to {0}", PythonFilenameLbl.Text);
                PythonCodeRTB.SaveFile(PythonFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                PythonCodeRTB.Modified = false;
                PythonSaveBtn.Enabled = false;
            }
        }

        private void PythonSaveAsBtn_Click(object sender, EventArgs e)
        {
            log.Info("PythonSaveAsBtn_Click(...)");

            string initialDirectory;
            if (PythonFilenameLbl.Text != "Untitled" && PythonFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(PythonFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Python Program As...",
                Filter = "*.py",
                InitialDirectory = initialDirectory,
                FileName = PythonFilenameLbl.Text,
                Extension = ".py"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".py")) filename += ".py";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        PythonFilenameLbl.Text = filename;
                        PythonCodeRTB.SaveFile(PythonFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);

                        PythonCodeRTB.Modified = false;
                        PythonSaveAsBtn.Enabled = false;
                        PythonSaveBtn.Enabled = false;
                    }
                }
            }
        }

        private string pythonCopy = null;
        private void PythonCodeRTB_TextChanged(object sender, EventArgs e)
        {
            // Font resizing triggers this, too, so we doublecheck to see if the text has actually changed!
            if (pythonCopy == null)
                pythonCopy = PythonCodeRTB.Text;

            if (pythonCopy == PythonCodeRTB.Text)
                PythonCodeRTB.Modified = false;
            else
            {
                PythonSaveBtn.Enabled = true;
                PythonSaveAsBtn.Enabled = true;
                PythonRunBtn.Enabled = true;
                pythonCopy = PythonCodeRTB.Text;
                PythonCodeRTB.Modified = true;
            }
        }

        private void SetupTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabName = SetupTab.TabPages[SetupTab.SelectedIndex].Text;

            // Actions to take on entering particular tabs
            if (tabName == "Tools")
                // Highlight the curent tool selected in the grid
                SelectDataGridViewRow(ToolsGrd, MountedToolBox.Text);

            if (tabName == "Displays")
                // Highlight the curent display selected in the grid
                SelectDataGridViewRow(DisplaysGrd, SelectedDisplayLbl.Text);

            if (tabName == "License")
            {
                // Hide adjustment controls!
                LicenseAdjustGrp.Visible = false;
                // Update current license status
                GetLicenseStatus();
            }
        }
        // TODO needs to direct output to dev...
        void ExecutePythonScript(string code, LeDeviceInterface dev)
        {
            log.Info($"Python Execute: {code}");
            try
            {
                Microsoft.Scripting.Hosting.ScriptSource pythonScript = pythonScope.Engine.CreateScriptSourceFromString(code);
                pythonScript.Execute(pythonScope);
            }
            catch (Exception ex)
            {
                log.Error(ex, $"ExecutePythonScript Error {code}");
            }
        }

        bool ExecutePythonFile(string filename)
        {

            void exec(string f)
            {
                string contents = File.ReadAllText(f);
                Microsoft.Scripting.Hosting.ScriptSource pythonScript = pythonScope.Engine.CreateScriptSourceFromString(contents);
                pythonScript.Execute(pythonScope);
            }

            if (File.Exists(filename))
            {
                exec(filename);
                return true;
            }

            filename = Path.Combine(LEonardRoot, filename);
            if (File.Exists(filename))
            {
                exec(filename);
                return true;
            }

            ExecError($"File {filename} does not exist");
            return false;
        }
    }
}
