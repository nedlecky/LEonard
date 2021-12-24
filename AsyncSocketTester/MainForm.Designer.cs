namespace AsyncSocketTester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectClient1Btn = new System.Windows.Forms.Button();
            this.AllLogRTB = new System.Windows.Forms.RichTextBox();
            this.CommLogRTB = new System.Windows.Forms.RichTextBox();
            this.ErrorLogRTB = new System.Windows.Forms.RichTextBox();
            this.StartListener1Btn = new System.Windows.Forms.Button();
            this.StartListener2Btn = new System.Windows.Forms.Button();
            this.Listener1IpTxt = new System.Windows.Forms.TextBox();
            this.Listener2IpTxt = new System.Windows.Forms.TextBox();
            this.Listener1PortTxt = new System.Windows.Forms.TextBox();
            this.Listener2PortTxt = new System.Windows.Forms.TextBox();
            this.ConnectClient2Btn = new System.Windows.Forms.Button();
            this.SendClient1Btn = new System.Windows.Forms.Button();
            this.SendClient2Btn = new System.Windows.Forms.Button();
            this.SendClient1Txt = new System.Windows.Forms.TextBox();
            this.SendClient2Txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectClient1Btn
            // 
            this.ConnectClient1Btn.Location = new System.Drawing.Point(12, 17);
            this.ConnectClient1Btn.Name = "ConnectClient1Btn";
            this.ConnectClient1Btn.Size = new System.Drawing.Size(110, 23);
            this.ConnectClient1Btn.TabIndex = 0;
            this.ConnectClient1Btn.Text = "Connect Client 1";
            this.ConnectClient1Btn.UseVisualStyleBackColor = true;
            this.ConnectClient1Btn.Click += new System.EventHandler(this.ConnectClient1Btn_Click);
            // 
            // AllLogRTB
            // 
            this.AllLogRTB.Location = new System.Drawing.Point(12, 121);
            this.AllLogRTB.Name = "AllLogRTB";
            this.AllLogRTB.Size = new System.Drawing.Size(937, 211);
            this.AllLogRTB.TabIndex = 1;
            this.AllLogRTB.Text = "";
            // 
            // CommLogRTB
            // 
            this.CommLogRTB.Location = new System.Drawing.Point(12, 338);
            this.CommLogRTB.Name = "CommLogRTB";
            this.CommLogRTB.Size = new System.Drawing.Size(937, 208);
            this.CommLogRTB.TabIndex = 2;
            this.CommLogRTB.Text = "";
            // 
            // ErrorLogRTB
            // 
            this.ErrorLogRTB.Location = new System.Drawing.Point(12, 552);
            this.ErrorLogRTB.Name = "ErrorLogRTB";
            this.ErrorLogRTB.Size = new System.Drawing.Size(937, 233);
            this.ErrorLogRTB.TabIndex = 3;
            this.ErrorLogRTB.Text = "";
            // 
            // StartListener1Btn
            // 
            this.StartListener1Btn.Location = new System.Drawing.Point(549, 19);
            this.StartListener1Btn.Name = "StartListener1Btn";
            this.StartListener1Btn.Size = new System.Drawing.Size(128, 23);
            this.StartListener1Btn.TabIndex = 4;
            this.StartListener1Btn.Text = "Start Listener 1";
            this.StartListener1Btn.UseVisualStyleBackColor = true;
            this.StartListener1Btn.Click += new System.EventHandler(this.StartListener1Btn_Click);
            // 
            // StartListener2Btn
            // 
            this.StartListener2Btn.Location = new System.Drawing.Point(549, 48);
            this.StartListener2Btn.Name = "StartListener2Btn";
            this.StartListener2Btn.Size = new System.Drawing.Size(128, 23);
            this.StartListener2Btn.TabIndex = 5;
            this.StartListener2Btn.Text = "Start Listener 2";
            this.StartListener2Btn.UseVisualStyleBackColor = true;
            this.StartListener2Btn.Click += new System.EventHandler(this.StartListener2Btn_Click);
            // 
            // Listener1IpTxt
            // 
            this.Listener1IpTxt.Location = new System.Drawing.Point(683, 22);
            this.Listener1IpTxt.Name = "Listener1IpTxt";
            this.Listener1IpTxt.Size = new System.Drawing.Size(72, 20);
            this.Listener1IpTxt.TabIndex = 6;
            this.Listener1IpTxt.Text = "127.0.0.1";
            // 
            // Listener2IpTxt
            // 
            this.Listener2IpTxt.Location = new System.Drawing.Point(683, 51);
            this.Listener2IpTxt.Name = "Listener2IpTxt";
            this.Listener2IpTxt.Size = new System.Drawing.Size(72, 20);
            this.Listener2IpTxt.TabIndex = 7;
            this.Listener2IpTxt.Text = "127.0.0.1";
            // 
            // Listener1PortTxt
            // 
            this.Listener1PortTxt.Location = new System.Drawing.Point(761, 21);
            this.Listener1PortTxt.Name = "Listener1PortTxt";
            this.Listener1PortTxt.Size = new System.Drawing.Size(49, 20);
            this.Listener1PortTxt.TabIndex = 8;
            this.Listener1PortTxt.Text = "10001";
            // 
            // Listener2PortTxt
            // 
            this.Listener2PortTxt.Location = new System.Drawing.Point(761, 50);
            this.Listener2PortTxt.Name = "Listener2PortTxt";
            this.Listener2PortTxt.Size = new System.Drawing.Size(49, 20);
            this.Listener2PortTxt.TabIndex = 9;
            this.Listener2PortTxt.Text = "10002";
            // 
            // ConnectClient2Btn
            // 
            this.ConnectClient2Btn.Location = new System.Drawing.Point(12, 48);
            this.ConnectClient2Btn.Name = "ConnectClient2Btn";
            this.ConnectClient2Btn.Size = new System.Drawing.Size(110, 23);
            this.ConnectClient2Btn.TabIndex = 10;
            this.ConnectClient2Btn.Text = "Connect Client 2";
            this.ConnectClient2Btn.UseVisualStyleBackColor = true;
            this.ConnectClient2Btn.Click += new System.EventHandler(this.ConnectClient2Btn_Click);
            // 
            // SendClient1Btn
            // 
            this.SendClient1Btn.Location = new System.Drawing.Point(128, 17);
            this.SendClient1Btn.Name = "SendClient1Btn";
            this.SendClient1Btn.Size = new System.Drawing.Size(75, 23);
            this.SendClient1Btn.TabIndex = 11;
            this.SendClient1Btn.Text = "Send";
            this.SendClient1Btn.UseVisualStyleBackColor = true;
            this.SendClient1Btn.Click += new System.EventHandler(this.SendClient1Btn_Click);
            // 
            // SendClient2Btn
            // 
            this.SendClient2Btn.Location = new System.Drawing.Point(128, 47);
            this.SendClient2Btn.Name = "SendClient2Btn";
            this.SendClient2Btn.Size = new System.Drawing.Size(75, 23);
            this.SendClient2Btn.TabIndex = 12;
            this.SendClient2Btn.Text = "Send";
            this.SendClient2Btn.UseVisualStyleBackColor = true;
            this.SendClient2Btn.Click += new System.EventHandler(this.SendClient2Btn_Click);
            // 
            // SendClient1Txt
            // 
            this.SendClient1Txt.Location = new System.Drawing.Point(209, 19);
            this.SendClient1Txt.Name = "SendClient1Txt";
            this.SendClient1Txt.Size = new System.Drawing.Size(125, 20);
            this.SendClient1Txt.TabIndex = 13;
            this.SendClient1Txt.Text = "From Client1";
            // 
            // SendClient2Txt
            // 
            this.SendClient2Txt.Location = new System.Drawing.Point(209, 48);
            this.SendClient2Txt.Name = "SendClient2Txt";
            this.SendClient2Txt.Size = new System.Drawing.Size(125, 20);
            this.SendClient2Txt.TabIndex = 14;
            this.SendClient2Txt.Text = "From Client 2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 797);
            this.Controls.Add(this.SendClient2Txt);
            this.Controls.Add(this.SendClient1Txt);
            this.Controls.Add(this.SendClient2Btn);
            this.Controls.Add(this.SendClient1Btn);
            this.Controls.Add(this.ConnectClient2Btn);
            this.Controls.Add(this.Listener2PortTxt);
            this.Controls.Add(this.Listener1PortTxt);
            this.Controls.Add(this.Listener2IpTxt);
            this.Controls.Add(this.Listener1IpTxt);
            this.Controls.Add(this.StartListener2Btn);
            this.Controls.Add(this.StartListener1Btn);
            this.Controls.Add(this.ErrorLogRTB);
            this.Controls.Add(this.CommLogRTB);
            this.Controls.Add(this.AllLogRTB);
            this.Controls.Add(this.ConnectClient1Btn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectClient1Btn;
        private System.Windows.Forms.RichTextBox AllLogRTB;
        private System.Windows.Forms.RichTextBox CommLogRTB;
        private System.Windows.Forms.RichTextBox ErrorLogRTB;
        private System.Windows.Forms.Button StartListener1Btn;
        private System.Windows.Forms.Button StartListener2Btn;
        private System.Windows.Forms.TextBox Listener1IpTxt;
        private System.Windows.Forms.TextBox Listener2IpTxt;
        private System.Windows.Forms.TextBox Listener1PortTxt;
        private System.Windows.Forms.TextBox Listener2PortTxt;
        private System.Windows.Forms.Button ConnectClient2Btn;
        private System.Windows.Forms.Button SendClient1Btn;
        private System.Windows.Forms.Button SendClient2Btn;
        private System.Windows.Forms.TextBox SendClient1Txt;
        private System.Windows.Forms.TextBox SendClient2Txt;
    }
}

