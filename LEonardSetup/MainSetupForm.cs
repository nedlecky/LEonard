using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LEonardSetup
{
    public partial class MainSetupForm : Form
    {
        string LEonardVersion = "2.11.1.0";

        private void MainSetupForm_Load(object sender, EventArgs e)
        {
            VersionLbl.Text = $"Ver {LEonardVersion}";

            // Where is "Packages"
            // Could be in this directory (normal) or two directories up (dev mode)
            bool fFoundPackage = false;
            if (Directory.Exists("Package"))
                fFoundPackage = true;
            else
            {
                if (Directory.Exists(@"..\..\Redist"))
                {
                    Directory.SetCurrentDirectory(@"..\..\Redist");
                    fFoundPackage = true;
                }
                else
                {
                    InstructionsLbl.Text = "Cannot Find Packages to Install";
                    InstallBtn.Enabled = false;
                }
            }

            if (fFoundPackage)
            {
                string cd = Directory.GetCurrentDirectory();
                FeedbackLbl.Text = $"Package in {cd}";
            }
        }

        public MainSetupForm()
        {
            InitializeComponent();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        int Perform(string command, string args)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo(command, args);
            ProcessInfo.WorkingDirectory = ".";
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();

            int ret = Process.ExitCode;
            Process.Close();
            return ret;
        }

        private void InstallBtn_Click(object sender, EventArgs e)
        {
            string message = "WARNING WARNING WARNING\nINSTALLING desktop shortcut\nINSTALLING Start Menu link\n * **** INSTALLING C:\\LEonard\\LEonard Executables and Data File Updates *****\nPROCEED ??? ";
            string title = "INSTALLING LEonard";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                MakeDesktopShortcut();
                MakeStartLink();

                string destinationFolder = @"C:\LEonard";
                Perform("robocopy.exe", $@"Package\LEonard {destinationFolder}\LEonard /MIR");
                Perform("robocopy.exe", $@"Package\LEonardClient {destinationFolder}\LEonardClient /MIR");
                Perform("robocopy.exe", $@"Package\Documentation {destinationFolder}\Documentation /MIR");
                Perform("robocopy.exe", $@"Package\3rdParty {destinationFolder}\3rdParty /XO /S");
                Perform("robocopy.exe", $@"Package\Code {destinationFolder}\Code /XO /S");
                Perform("robocopy.exe", $@"Package\Config {destinationFolder}\Config /XO /S");
            }
        }

        private void UninstallBtn_Click(object sender, EventArgs e)
        {
            string message = "WARNING WARNING WARNING\nREMOVING desktop shortcut\nREMOVING Start Menu link\n * **** DELETING c:\\LEonard\\LEonard Executables *****\nPROCEED ??? ";
            string title = "UNINSTALLING LEonard";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                MakeDesktopShortcut(true);
                MakeStartLink(true);

                void ScaryDelete(string path)
                {
                    try
                    {
                        if (Directory.Exists(path))
                            Directory.Delete(path, true);
                    }
                    catch
                    {

                    }
                }

                // Scary recursive delete of C:\LEonard
                ScaryDelete(@"C:\LEonard\LEonard");
                ScaryDelete(@"C:\LEonard\3rdParty");
            }
        }

        void MakeStartLink(bool fRemoving = false)
        {
            string programs_path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            string shortcutFolder = Path.Combine(programs_path, @"Lecky Engineering\LEonard");
            if (!Directory.Exists(shortcutFolder))
            {
                // Nothing to remove!
                if (fRemoving) return;

                Directory.CreateDirectory(shortcutFolder);
            }

            WshShell shellClass = new WshShell();
            string leonardLink = Path.Combine(shortcutFolder, "LEonard.lnk");

            if (fRemoving)
            {
                System.IO.File.Delete(leonardLink);
                return;
            }

            // Create the desktop shortcut
            IWshShortcut shortcut = (IWshShortcut)shellClass.CreateShortcut(leonardLink);
            shortcut.TargetPath = @"C:\LEonard\LEonard\LEonard.exe";
            shortcut.IconLocation = @"C:\LEonard\LEonard\LEonardIcon.ico";
            shortcut.WorkingDirectory = @"C:\LEonard\LEonard\";
            shortcut.Arguments = "";
            shortcut.Description = "Let's run LEonard!";
            shortcut.Save();
        }

        private void MakeDesktopShortcut(bool fRemoving = false)
        {
            IShellLink link = (IShellLink)new ShellLink();

            // Where should the file go?
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string shortcutFilename = Path.Combine(desktopPath, "LEonard.lnk");

            if (fRemoving)
            {
                System.IO.File.Delete(shortcutFilename);
                return;
            }

            // Setup shortcut information
            IPersistFile file = (IPersistFile)link;
            link.SetDescription("LEonard");
            link.SetPath(@"C:\LEonard\LEonard\LEonard.exe");
            link.SetDescription("Description is?");
            link.SetWorkingDirectory(@"C:\LEonard\LEonard");
            file.Save(shortcutFilename, false);
        }

    }

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
}
