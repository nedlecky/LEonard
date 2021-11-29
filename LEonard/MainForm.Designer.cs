namespace LEonard
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
            this.components = new System.ComponentModel.Container();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.HeartbeatTmr = new System.Windows.Forms.Timer(this.components);
            this.AllCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.RobotCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.CrawlerClearBtn = new System.Windows.Forms.Button();
            this.RobotClearBtn = new System.Windows.Forms.Button();
            this.VisionClearBtn = new System.Windows.Forms.Button();
            this.VisionCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.ErrorClearBtn = new System.Windows.Forms.Button();
            this.ErrorCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.CloseTmr = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BarcodeGrp = new System.Windows.Forms.GroupBox();
            this.DM2DataLbl = new System.Windows.Forms.Label();
            this.DM1DataLbl = new System.Windows.Forms.Label();
            this.TriggerDM2Btn = new System.Windows.Forms.Button();
            this.TriggerDM1Btn = new System.Windows.Forms.Button();
            this.TestThreadEnabledChk = new System.Windows.Forms.CheckBox();
            this.CommandServerChk = new System.Windows.Forms.CheckBox();
            this.StartTestClientBtn = new System.Windows.Forms.Button();
            this.RobotServerChk = new System.Windows.Forms.CheckBox();
            this.RobotSendBtn = new System.Windows.Forms.Button();
            this.RobotCommandTxt = new System.Windows.Forms.TextBox();
            this.VisionCommandTxt = new System.Windows.Forms.TextBox();
            this.VisionSendBtn = new System.Windows.Forms.Button();
            this.VisionServerChk = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BarcodeClearBtn = new System.Windows.Forms.Button();
            this.BarcodeCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CommandClearBtn = new System.Windows.Forms.Button();
            this.CommandCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.BarcodeGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(1214, 12);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(55, 41);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // TimeLbl
            // 
            this.TimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TimeLbl.Location = new System.Drawing.Point(12, 12);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(174, 26);
            this.TimeLbl.TabIndex = 1;
            this.TimeLbl.Text = "???";
            this.TimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeartbeatTmr
            // 
            this.HeartbeatTmr.Tick += new System.EventHandler(this.HeartbeatTmr_Tick);
            // 
            // AllCrawlRTB
            // 
            this.AllCrawlRTB.Location = new System.Drawing.Point(6, 19);
            this.AllCrawlRTB.Name = "AllCrawlRTB";
            this.AllCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AllCrawlRTB.Size = new System.Drawing.Size(533, 283);
            this.AllCrawlRTB.TabIndex = 6;
            this.AllCrawlRTB.Text = "";
            // 
            // RobotCrawlRTB
            // 
            this.RobotCrawlRTB.Location = new System.Drawing.Point(6, 15);
            this.RobotCrawlRTB.Name = "RobotCrawlRTB";
            this.RobotCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RobotCrawlRTB.Size = new System.Drawing.Size(270, 198);
            this.RobotCrawlRTB.TabIndex = 7;
            this.RobotCrawlRTB.Text = "";
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // CrawlerClearBtn
            // 
            this.CrawlerClearBtn.Location = new System.Drawing.Point(6, 302);
            this.CrawlerClearBtn.Name = "CrawlerClearBtn";
            this.CrawlerClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CrawlerClearBtn.TabIndex = 9;
            this.CrawlerClearBtn.Text = "Clear";
            this.CrawlerClearBtn.UseVisualStyleBackColor = true;
            this.CrawlerClearBtn.Click += new System.EventHandler(this.CrawlerClearBtn_Click);
            // 
            // RobotClearBtn
            // 
            this.RobotClearBtn.Location = new System.Drawing.Point(6, 219);
            this.RobotClearBtn.Name = "RobotClearBtn";
            this.RobotClearBtn.Size = new System.Drawing.Size(50, 23);
            this.RobotClearBtn.TabIndex = 11;
            this.RobotClearBtn.Text = "Clear";
            this.RobotClearBtn.UseVisualStyleBackColor = true;
            this.RobotClearBtn.Click += new System.EventHandler(this.RobotClearBtn_Click);
            // 
            // VisionClearBtn
            // 
            this.VisionClearBtn.Location = new System.Drawing.Point(6, 219);
            this.VisionClearBtn.Name = "VisionClearBtn";
            this.VisionClearBtn.Size = new System.Drawing.Size(50, 23);
            this.VisionClearBtn.TabIndex = 14;
            this.VisionClearBtn.Text = "Clear";
            this.VisionClearBtn.UseVisualStyleBackColor = true;
            this.VisionClearBtn.Click += new System.EventHandler(this.VisionClearBtn_Click);
            // 
            // VisionCrawlRTB
            // 
            this.VisionCrawlRTB.Location = new System.Drawing.Point(6, 15);
            this.VisionCrawlRTB.Name = "VisionCrawlRTB";
            this.VisionCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.VisionCrawlRTB.Size = new System.Drawing.Size(270, 198);
            this.VisionCrawlRTB.TabIndex = 12;
            this.VisionCrawlRTB.Text = "";
            // 
            // ErrorClearBtn
            // 
            this.ErrorClearBtn.Location = new System.Drawing.Point(6, 302);
            this.ErrorClearBtn.Name = "ErrorClearBtn";
            this.ErrorClearBtn.Size = new System.Drawing.Size(50, 23);
            this.ErrorClearBtn.TabIndex = 17;
            this.ErrorClearBtn.Text = "Clear";
            this.ErrorClearBtn.UseVisualStyleBackColor = true;
            this.ErrorClearBtn.Click += new System.EventHandler(this.ErrorClearBtn_Click);
            // 
            // ErrorCrawlRTB
            // 
            this.ErrorCrawlRTB.Location = new System.Drawing.Point(6, 16);
            this.ErrorCrawlRTB.Name = "ErrorCrawlRTB";
            this.ErrorCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ErrorCrawlRTB.Size = new System.Drawing.Size(420, 286);
            this.ErrorCrawlRTB.TabIndex = 15;
            this.ErrorCrawlRTB.Text = "";
            // 
            // CloseTmr
            // 
            this.CloseTmr.Tick += new System.EventHandler(this.CloseTmr_Tick);
            // 
            // BarcodeGrp
            // 
            this.BarcodeGrp.Controls.Add(this.DM2DataLbl);
            this.BarcodeGrp.Controls.Add(this.DM1DataLbl);
            this.BarcodeGrp.Controls.Add(this.TriggerDM2Btn);
            this.BarcodeGrp.Controls.Add(this.TriggerDM1Btn);
            this.BarcodeGrp.Location = new System.Drawing.Point(588, 349);
            this.BarcodeGrp.Name = "BarcodeGrp";
            this.BarcodeGrp.Size = new System.Drawing.Size(306, 104);
            this.BarcodeGrp.TabIndex = 22;
            this.BarcodeGrp.TabStop = false;
            this.BarcodeGrp.Text = "Barcode Readers";
            // 
            // DM2DataLbl
            // 
            this.DM2DataLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DM2DataLbl.Location = new System.Drawing.Point(103, 54);
            this.DM2DataLbl.Name = "DM2DataLbl";
            this.DM2DataLbl.Size = new System.Drawing.Size(180, 23);
            this.DM2DataLbl.TabIndex = 25;
            // 
            // DM1DataLbl
            // 
            this.DM1DataLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DM1DataLbl.Location = new System.Drawing.Point(103, 25);
            this.DM1DataLbl.Name = "DM1DataLbl";
            this.DM1DataLbl.Size = new System.Drawing.Size(180, 23);
            this.DM1DataLbl.TabIndex = 24;
            // 
            // TriggerDM2Btn
            // 
            this.TriggerDM2Btn.Location = new System.Drawing.Point(22, 54);
            this.TriggerDM2Btn.Name = "TriggerDM2Btn";
            this.TriggerDM2Btn.Size = new System.Drawing.Size(75, 23);
            this.TriggerDM2Btn.TabIndex = 23;
            this.TriggerDM2Btn.Text = "Trigger DM2";
            this.TriggerDM2Btn.UseVisualStyleBackColor = true;
            this.TriggerDM2Btn.Click += new System.EventHandler(this.TriggerDM2Btn_Click);
            // 
            // TriggerDM1Btn
            // 
            this.TriggerDM1Btn.Location = new System.Drawing.Point(22, 25);
            this.TriggerDM1Btn.Name = "TriggerDM1Btn";
            this.TriggerDM1Btn.Size = new System.Drawing.Size(75, 23);
            this.TriggerDM1Btn.TabIndex = 22;
            this.TriggerDM1Btn.Text = "Trigger DM1";
            this.TriggerDM1Btn.UseVisualStyleBackColor = true;
            this.TriggerDM1Btn.Click += new System.EventHandler(this.TriggerDM1Btn_Click);
            // 
            // TestThreadEnabledChk
            // 
            this.TestThreadEnabledChk.AutoSize = true;
            this.TestThreadEnabledChk.Location = new System.Drawing.Point(588, 326);
            this.TestThreadEnabledChk.Name = "TestThreadEnabledChk";
            this.TestThreadEnabledChk.Size = new System.Drawing.Size(126, 17);
            this.TestThreadEnabledChk.TabIndex = 23;
            this.TestThreadEnabledChk.Text = "Test Thread Enabled";
            this.TestThreadEnabledChk.UseVisualStyleBackColor = true;
            this.TestThreadEnabledChk.CheckedChanged += new System.EventHandler(this.TestThreadEnabledChk_CheckedChanged);
            // 
            // CommandServerChk
            // 
            this.CommandServerChk.AutoSize = true;
            this.CommandServerChk.Location = new System.Drawing.Point(631, 133);
            this.CommandServerChk.Name = "CommandServerChk";
            this.CommandServerChk.Size = new System.Drawing.Size(107, 17);
            this.CommandServerChk.TabIndex = 24;
            this.CommandServerChk.Text = "Command Server";
            this.CommandServerChk.UseVisualStyleBackColor = true;
            this.CommandServerChk.CheckedChanged += new System.EventHandler(this.CommandServerChk_CheckedChanged);
            // 
            // StartTestClientBtn
            // 
            this.StartTestClientBtn.Location = new System.Drawing.Point(759, 112);
            this.StartTestClientBtn.Name = "StartTestClientBtn";
            this.StartTestClientBtn.Size = new System.Drawing.Size(75, 56);
            this.StartTestClientBtn.TabIndex = 25;
            this.StartTestClientBtn.Text = "Start Test Client";
            this.StartTestClientBtn.UseVisualStyleBackColor = true;
            this.StartTestClientBtn.Click += new System.EventHandler(this.StartTestClientBtn_Click);
            // 
            // RobotServerChk
            // 
            this.RobotServerChk.AutoSize = true;
            this.RobotServerChk.Location = new System.Drawing.Point(631, 174);
            this.RobotServerChk.Name = "RobotServerChk";
            this.RobotServerChk.Size = new System.Drawing.Size(89, 17);
            this.RobotServerChk.TabIndex = 26;
            this.RobotServerChk.Text = "Robot Server";
            this.RobotServerChk.UseVisualStyleBackColor = true;
            this.RobotServerChk.CheckedChanged += new System.EventHandler(this.RobotServerChk_CheckedChanged);
            // 
            // RobotSendBtn
            // 
            this.RobotSendBtn.Location = new System.Drawing.Point(759, 195);
            this.RobotSendBtn.Name = "RobotSendBtn";
            this.RobotSendBtn.Size = new System.Drawing.Size(75, 23);
            this.RobotSendBtn.TabIndex = 27;
            this.RobotSendBtn.Text = "Send";
            this.RobotSendBtn.UseVisualStyleBackColor = true;
            this.RobotSendBtn.Click += new System.EventHandler(this.RobotSendBtn_Click);
            // 
            // RobotCommandTxt
            // 
            this.RobotCommandTxt.Location = new System.Drawing.Point(631, 197);
            this.RobotCommandTxt.Name = "RobotCommandTxt";
            this.RobotCommandTxt.Size = new System.Drawing.Size(119, 20);
            this.RobotCommandTxt.TabIndex = 28;
            this.RobotCommandTxt.Text = "(1,0,0,0,0)";
            this.RobotCommandTxt.TextChanged += new System.EventHandler(this.RobotCommandTxt_TextChanged);
            // 
            // VisionCommandTxt
            // 
            this.VisionCommandTxt.Location = new System.Drawing.Point(631, 261);
            this.VisionCommandTxt.Name = "VisionCommandTxt";
            this.VisionCommandTxt.Size = new System.Drawing.Size(119, 20);
            this.VisionCommandTxt.TabIndex = 31;
            this.VisionCommandTxt.Text = "test1";
            // 
            // VisionSendBtn
            // 
            this.VisionSendBtn.Location = new System.Drawing.Point(759, 259);
            this.VisionSendBtn.Name = "VisionSendBtn";
            this.VisionSendBtn.Size = new System.Drawing.Size(75, 23);
            this.VisionSendBtn.TabIndex = 30;
            this.VisionSendBtn.Text = "Send";
            this.VisionSendBtn.UseVisualStyleBackColor = true;
            this.VisionSendBtn.Click += new System.EventHandler(this.VisionSendBtn_Click);
            // 
            // VisionServerChk
            // 
            this.VisionServerChk.AutoSize = true;
            this.VisionServerChk.Location = new System.Drawing.Point(631, 238);
            this.VisionServerChk.Name = "VisionServerChk";
            this.VisionServerChk.Size = new System.Drawing.Size(88, 17);
            this.VisionServerChk.TabIndex = 29;
            this.VisionServerChk.Text = "Vision Server";
            this.VisionServerChk.UseVisualStyleBackColor = true;
            this.VisionServerChk.CheckedChanged += new System.EventHandler(this.VisionServerChk_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RobotClearBtn);
            this.groupBox1.Controls.Add(this.RobotCrawlRTB);
            this.groupBox1.Location = new System.Drawing.Point(1001, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 252);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BarcodeClearBtn);
            this.groupBox2.Controls.Add(this.BarcodeCrawlRTB);
            this.groupBox2.Location = new System.Drawing.Point(1001, 575);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 252);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode";
            // 
            // BarcodeClearBtn
            // 
            this.BarcodeClearBtn.Location = new System.Drawing.Point(6, 223);
            this.BarcodeClearBtn.Name = "BarcodeClearBtn";
            this.BarcodeClearBtn.Size = new System.Drawing.Size(50, 23);
            this.BarcodeClearBtn.TabIndex = 11;
            this.BarcodeClearBtn.Text = "Clear";
            this.BarcodeClearBtn.UseVisualStyleBackColor = true;
            this.BarcodeClearBtn.Click += new System.EventHandler(this.BarcodeClearBtn_Click);
            // 
            // BarcodeCrawlRTB
            // 
            this.BarcodeCrawlRTB.Location = new System.Drawing.Point(-4, 19);
            this.BarcodeCrawlRTB.Name = "BarcodeCrawlRTB";
            this.BarcodeCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.BarcodeCrawlRTB.Size = new System.Drawing.Size(280, 198);
            this.BarcodeCrawlRTB.TabIndex = 7;
            this.BarcodeCrawlRTB.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VisionCrawlRTB);
            this.groupBox3.Controls.Add(this.VisionClearBtn);
            this.groupBox3.Location = new System.Drawing.Point(1001, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 252);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vision";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CrawlerClearBtn);
            this.groupBox4.Controls.Add(this.AllCrawlRTB);
            this.groupBox4.Location = new System.Drawing.Point(12, 496);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(545, 331);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "All Messages";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ErrorCrawlRTB);
            this.groupBox5.Controls.Add(this.ErrorClearBtn);
            this.groupBox5.Location = new System.Drawing.Point(563, 496);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(432, 331);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ERRORS";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CommandClearBtn);
            this.groupBox6.Controls.Add(this.CommandCrawlRTB);
            this.groupBox6.Location = new System.Drawing.Point(12, 50);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(455, 331);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Command";
            // 
            // CommandClearBtn
            // 
            this.CommandClearBtn.Location = new System.Drawing.Point(6, 302);
            this.CommandClearBtn.Name = "CommandClearBtn";
            this.CommandClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CommandClearBtn.TabIndex = 9;
            this.CommandClearBtn.Text = "Clear";
            this.CommandClearBtn.UseVisualStyleBackColor = true;
            this.CommandClearBtn.Click += new System.EventHandler(this.CommandClearBtn_Click);
            // 
            // CommandCrawlRTB
            // 
            this.CommandCrawlRTB.Location = new System.Drawing.Point(6, 19);
            this.CommandCrawlRTB.Name = "CommandCrawlRTB";
            this.CommandCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.CommandCrawlRTB.Size = new System.Drawing.Size(443, 283);
            this.CommandCrawlRTB.TabIndex = 6;
            this.CommandCrawlRTB.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 832);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.VisionCommandTxt);
            this.Controls.Add(this.VisionSendBtn);
            this.Controls.Add(this.VisionServerChk);
            this.Controls.Add(this.RobotCommandTxt);
            this.Controls.Add(this.RobotSendBtn);
            this.Controls.Add(this.RobotServerChk);
            this.Controls.Add(this.StartTestClientBtn);
            this.Controls.Add(this.CommandServerChk);
            this.Controls.Add(this.TestThreadEnabledChk);
            this.Controls.Add(this.BarcodeGrp);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.ExitBtn);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Set During Load";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.BarcodeGrp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Timer HeartbeatTmr;
        private System.Windows.Forms.RichTextBox AllCrawlRTB;
        private System.Windows.Forms.RichTextBox RobotCrawlRTB;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Button CrawlerClearBtn;
        private System.Windows.Forms.Button RobotClearBtn;
        private System.Windows.Forms.Button VisionClearBtn;
        private System.Windows.Forms.RichTextBox VisionCrawlRTB;
        private System.Windows.Forms.Button ErrorClearBtn;
        private System.Windows.Forms.RichTextBox ErrorCrawlRTB;
        private System.Windows.Forms.Timer CloseTmr;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox BarcodeGrp;
        private System.Windows.Forms.Label DM2DataLbl;
        private System.Windows.Forms.Label DM1DataLbl;
        private System.Windows.Forms.Button TriggerDM2Btn;
        private System.Windows.Forms.Button TriggerDM1Btn;
        private System.Windows.Forms.CheckBox TestThreadEnabledChk;
        private System.Windows.Forms.CheckBox CommandServerChk;
        private System.Windows.Forms.Button StartTestClientBtn;
        private System.Windows.Forms.CheckBox RobotServerChk;
        private System.Windows.Forms.Button RobotSendBtn;
        private System.Windows.Forms.TextBox RobotCommandTxt;
        private System.Windows.Forms.TextBox VisionCommandTxt;
        private System.Windows.Forms.Button VisionSendBtn;
        private System.Windows.Forms.CheckBox VisionServerChk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BarcodeClearBtn;
        private System.Windows.Forms.RichTextBox BarcodeCrawlRTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button CommandClearBtn;
        private System.Windows.Forms.RichTextBox CommandCrawlRTB;
    }
}

