// File: Program.cs
// Project: LEonardTablet
// Author: Ned Lecky, Lecky Engineering LLC
// Purpose: The main rouutine (unmodified from default) for LEonardTablet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEonardTablet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
