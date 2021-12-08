using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;

namespace JintTester1
{
    public partial class Form1 : Form
    {
        Engine jintEngine;
        public Form1()
        {
            InitializeComponent();

            jintEngine = new Engine()
                // Expose the alert function in JavaScript that triggers the native function (previously created) Alert
                .SetValue("alert", new Action<string>(Alert))
                .SetValue("print", new Action<string>(Print))
            ;
        }

        private void Alert(string Message)
        {
            MessageBox.Show(Message, "Window Alert", MessageBoxButtons.OK);
        }
        private void Print(string message)
        {
            Console.WriteLine(message);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            string script = ScriptTxt.Text;

            try
            {
                Stopwatch sw1 = new Stopwatch();
                Stopwatch sw2 = new Stopwatch();
                sw1.Restart();
                for(int i=0; i<100; i++)
                    jintEngine.Execute(script);
                sw1.Stop();
                sw2.Restart();
                double a=0;
                double b=0;
                double c=0;
                string aStr="";
                for (int i = 0; i < 100; i++)
                {
                    a = jintEngine.GetValue("a").AsNumber();
                    b = jintEngine.GetValue("b").AsNumber();
                    c = jintEngine.GetValue("c").AsNumber();
                    aStr = jintEngine.GetValue("aStr").AsString();
                }
                sw2.Stop();
                Console.WriteLine(string.Format("a={0} b={1} c={2} aStr={3} mS.1={4} mS.2={5}", a, b, c, aStr, sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds));
            }
            catch (Jint.Runtime.JavaScriptException Ex)
            {
                Console.WriteLine(Ex.Message);
            }

        }

        private void ScriptTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
