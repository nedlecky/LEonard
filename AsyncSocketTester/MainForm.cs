using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketTester
{
    public partial class MainForm : Form
    {
        private static NLog.Logger log;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "Socket Tester";
            
            log = NLog.LogManager.GetCurrentClassLogger();

            log.Info("Started");
    }

        AsynchronousSocketListener listener1,listener2;

        private void StartListener1Btn_Click(object sender, EventArgs e)
        {
            listener1 = new AsynchronousSocketListener("LI1");
            listener1.StartListening(Listener1IpTxt.Text,Listener1PortTxt.Text);
        }
        private void StartListener2Btn_Click(object sender, EventArgs e)
        {
            listener2 = new AsynchronousSocketListener("LI2");
            listener2.StartListening(Listener2IpTxt.Text, Listener2PortTxt.Text);
        }

        AsynchronousClient client1, client2;

        private void ConnectClient1Btn_Click(object sender, EventArgs e)
        {
            client1 = new AsynchronousClient("CL1");
            client1.StartClient(Listener1IpTxt.Text, Listener1PortTxt.Text);
        }
        private void ConnectClient2Btn_Click(object sender, EventArgs e)
        {
            client2 = new AsynchronousClient("CL2");
            client2.StartClient(Listener2IpTxt.Text, Listener2PortTxt.Text);
        }
        private void SendClient1Btn_Click(object sender, EventArgs e)
        {
            client1.Send(SendClient1Txt.Text + "\n");
        }

        private void SendClient2Btn_Click(object sender, EventArgs e)
        {
            client2.Send(SendClient2Txt.Text + "\n");
        }


    }
}
