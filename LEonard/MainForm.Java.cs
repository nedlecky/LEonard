// File: MainForm.Java.cs
// Project: LEonard
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: Java system for LEonard

using Jint;
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
        /*
        private void JavaAlert(string message)
        {
            PromptOperator("Java:\n" + message);
        }
        private void JavaPrint(string message)
        {
            log.Info("JVP " + message);
            CrawlRTB(JavaConsoleRTB, message);
        }
        private void JavaLogInfo(string message)
        {
            log.Info(message);
        }
        private void JavaLogError(string message)
        {
            log.Error(message);
        }
        private void JavaExecuteLine(string message)
        {
            ExecuteLine(-1, message);
        }
        private void JavaWriteVariable(string name, string value)
        {
            WriteVariable(name, value);
        }
        private string JavaReadVariable(string name)
        {
            return ReadVariable(name);
        }
        */
        private void JavaUpdateVariablesRTB()
        {
            string finalUpdate = "";

            foreach (KeyValuePair<string, Jint.Runtime.Descriptors.PropertyDescriptor> kp in javaEngine.Global.GetOwnProperties())
            {

                string varType = "";
                if (kp.Value.Value.IsString()) varType = "S";
                else if (kp.Value.Value.IsNumber()) varType = "N";
                else if (kp.Value.Value.IsBoolean()) varType = "B";
                if (varType.Length > 0)
                {
                    finalUpdate += varType + " " + kp.Key.ToString() + " = " + kp.Value.Value.ToString() + "\n";
                }
            }
            JavaVariablesRTB.Text = finalUpdate;
        }

        private void InitializeJavaEngine()
        {
            javaEngine = new Engine()
                    .SetValue("lePrompt", new Action<string>((string prompt) => PromptOperator("Java Prompt:\n" + prompt)))
                    .SetValue("lePrint", new Action<string>((string msg) => CrawlRTB(JavaConsoleRTB, msg)))
                    .SetValue("leLogInfo", new Action<string>((string msg) => log.Info(msg)))
                    .SetValue("leLogError", new Action<string>(s => log.Error(s)))
                    .SetValue("leExec", new Action<string>((string line) => ExecuteLine(-1, line)))
                    .SetValue("leWriteVariable", new Action<string, string>((string name, string value) => WriteVariable(name, value)))
                    .SetValue("leReadVariable", new Func<string, string>((string name) => ReadVariable(name)))
                ;
        }
        private void JavaRunBtn_Click(object sender, EventArgs e)
        {
            if (!protection.RunLEonard())
            {
                ErrorMessageBox("Cannot run. LEonard license missing!");
                return;
            }

            string script = JavaCodeRTB.Text;

            try
            {
                javaEngine.Execute(script);
            }
            catch
            {

            }
            JavaUpdateVariablesRTB();
        }
        private void JavaNewBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaNewBtn_Click(...)");

            if (JavaCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Java code [{JavaFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    JavaSaveBtn_Click(null, null);
            }

            JavaCodeRTB.Text = "";
            JavaRunBtn.Enabled = false;
            JavaNewBtn.Enabled = false;
            JavaSaveBtn.Enabled = false;
            JavaSaveAsBtn.Enabled = false;
            JavaFilenameLbl.Text = "Untitled";
        }

        private bool LoadJavaProgram(string filename)
        {
            if (filename == null || filename == "Untitled" || filename.Length < 2)
            {
                JavaFilenameLbl.Text = "Untitled";
                return false;
            }

            try
            {
                JavaCodeRTB.LoadFile(filename, System.Windows.Forms.RichTextBoxStreamType.PlainText);
            }
            catch
            {
                ErrorMessageBox($"Cannot load Java program {filename}");
                return false;
            }

            JavaFilenameLbl.Text = filename;
            JavaCodeRTB.Modified = false;
            JavaSaveAsBtn.Enabled = true;
            JavaSaveBtn.Enabled = false;
            JavaNewBtn.Enabled = true;

            return true;
        }
        private void JavaLoadBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaLoadBtn_Click(...)");
            if (JavaCodeRTB.Modified)
            {
                var result = ConfirmMessageBox($"Java code [{JavaFilenameLbl.Text}] has changed.\nSave changes?");
                if (result == DialogResult.OK)
                    JavaSaveAsBtn_Click(null, null);
            }

            string initialDirectory;
            if (JavaFilenameLbl.Text != "Untitled" && JavaFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(JavaFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileOpenDialog dialog = new FileOpenDialog(this)
            {
                Title = "Open a LEonard Java Program",
                Filter = "*.js",
                InitialDirectory = initialDirectory,
                Extension = ".js"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadJavaProgram(dialog.FileName);
        }

        private void JavaSaveBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaSaveBtn_Click(...)");
            if (JavaFilenameLbl.Text == "Untitled" || JavaFilenameLbl.Text == "")
                JavaSaveAsBtn_Click(null, null);
            else
            {
                log.Info("Save Java program to {0}", JavaFilenameLbl.Text);
                JavaCodeRTB.SaveFile(JavaFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);
                JavaCodeRTB.Modified = false;
                JavaSaveBtn.Enabled = false;
            }
        }

        private void JavaSaveAsBtn_Click(object sender, EventArgs e)
        {
            log.Info("JavaSaveAsBtn_Click(...)");

            string initialDirectory;
            if (JavaFilenameLbl.Text != "Untitled" && JavaFilenameLbl.Text.Length > 0)
                initialDirectory = Path.GetDirectoryName(JavaFilenameLbl.Text);
            else
                initialDirectory = Path.Combine(LEonardRoot, "Recipes");

            FileSaveAsDialog dialog = new FileSaveAsDialog(this)
            {
                Title = "Save a LEonard Java Program As...",
                Filter = "*.js",
                InitialDirectory = initialDirectory,
                FileName = JavaFilenameLbl.Text,
                Extension = ".js"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    string filename = dialog.FileName;
                    if (!filename.EndsWith(".js")) filename += ".js";
                    bool okToSave = true;
                    if (File.Exists(filename))
                    {
                        if (DialogResult.OK != ConfirmMessageBox(string.Format("File {0} already exists. Overwrite?", filename)))
                            okToSave = false;
                    }
                    if (okToSave)
                    {
                        JavaFilenameLbl.Text = filename;
                        JavaCodeRTB.SaveFile(JavaFilenameLbl.Text, System.Windows.Forms.RichTextBoxStreamType.PlainText);

                        JavaCodeRTB.Modified = false;
                        JavaSaveAsBtn.Enabled = false;
                        JavaSaveBtn.Enabled = false;
                    }
                }
            }
        }
        private string javaCopy = null;
        private void JavaCodeRTB_TextChanged(object sender, EventArgs e)
        {
            // Font resizing triggers this, too, so we doublecheck to see if the text has actually changed!
            if (javaCopy == null)
                javaCopy = JavaCodeRTB.Text;

            if (javaCopy == JavaCodeRTB.Text)
                JavaCodeRTB.Modified = false;
            else
            {
                JavaSaveBtn.Enabled = true;
                JavaSaveAsBtn.Enabled = true;
                JavaRunBtn.Enabled = true;
                javaCopy = JavaCodeRTB.Text;
                JavaCodeRTB.Modified = true;
            }
        }
        void ExecuteJavaScript(string code)
        {
            log.Info($"Java Execute: {code}");
            try
            {
                javaEngine.Execute(code);
            }
            catch (Exception ex)
            {
                log.Error(ex, $"ExecuteJavaScript Error {code}");
            }
        }

        bool ExecuteJavaFile(string filename)
        {
            void exec(string f)
            {
                string contents = File.ReadAllText(f);
                javaEngine.Execute(contents);
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
