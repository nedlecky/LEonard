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

namespace LEonard
{

    public partial class ConsoleForm : Form
    {
        private StringRedir RedirConsole;
        private TextWriter ConsoleWriter;
        public ConsoleForm()
        {
            InitializeComponent();

            Console.WriteLine("ConsoleForm() line to ORIGINAL console.");

            // Here we redirect Console.WriteLine to a RichTextBox control. 
            ConsoleWriter = Console.Out;    // Save the current console TextWriter. 
            RedirConsole = new StringRedir(ref ConsoleRTB);
            Console.SetOut(RedirConsole);   // Set console output to the StringRedir class. 

            Console.WriteLine("ConsoleForm() line to NEW console.");
        }

        ~ConsoleForm()
        {
            Console.WriteLine(" ~ConsoleForm() line to NEW console.");
            Console.SetOut(ConsoleWriter);  // Redirect Console back to original TextWriter. 
            RedirConsole.Close();           // Close our StringRedir TextWriter. 
            Console.WriteLine(" ~ConsoleForm() line to ORIGINAL console.");
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {

        }

        private void ConsoleClearBtn_Click(object sender, EventArgs e)
        {
            ConsoleRTB.Clear();
        }
    }
    public class StringRedir : StringWriter
    { // Redirecting Console output to RichtextBox
        private RichTextBox outBox;

        public StringRedir(ref RichTextBox textBox)
        {
            outBox = textBox;
        }

        public override void WriteLine(string message)
        {
            MainForm.CrawlRTB(outBox, message);
            //outBox.Refresh();
        }
    }
}
