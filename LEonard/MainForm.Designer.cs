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
            this.Fixed1Pic = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Fixed2Pic = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.AllCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.RobotCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CrawlerClearBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisionCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.Fixed1Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fixed2Pic)).BeginInit();
            this.BarcodeGrp.SuspendLayout();
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
            // Fixed1Pic
            // 
            this.Fixed1Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fixed1Pic.Location = new System.Drawing.Point(12, 86);
            this.Fixed1Pic.Name = "Fixed1Pic";
            this.Fixed1Pic.Size = new System.Drawing.Size(305, 305);
            this.Fixed1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Fixed1Pic.TabIndex = 2;
            this.Fixed1Pic.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fixed2Pic
            // 
            this.Fixed2Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fixed2Pic.Location = new System.Drawing.Point(455, 86);
            this.Fixed2Pic.Name = "Fixed2Pic";
            this.Fixed2Pic.Size = new System.Drawing.Size(133, 195);
            this.Fixed2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Fixed2Pic.TabIndex = 4;
            this.Fixed2Pic.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(594, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AllCrawlRTB
            // 
            this.AllCrawlRTB.Location = new System.Drawing.Point(12, 509);
            this.AllCrawlRTB.Name = "AllCrawlRTB";
            this.AllCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AllCrawlRTB.Size = new System.Drawing.Size(413, 252);
            this.AllCrawlRTB.TabIndex = 6;
            this.AllCrawlRTB.Text = "";
            // 
            // RobotCrawlRTB
            // 
            this.RobotCrawlRTB.Location = new System.Drawing.Point(431, 509);
            this.RobotCrawlRTB.Name = "RobotCrawlRTB";
            this.RobotCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RobotCrawlRTB.Size = new System.Drawing.Size(413, 252);
            this.RobotCrawlRTB.TabIndex = 7;
            this.RobotCrawlRTB.Text = "";
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "All";
            // 
            // CrawlerClearBtn
            // 
            this.CrawlerClearBtn.Location = new System.Drawing.Point(40, 486);
            this.CrawlerClearBtn.Name = "CrawlerClearBtn";
            this.CrawlerClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CrawlerClearBtn.TabIndex = 9;
            this.CrawlerClearBtn.Text = "Clear";
            this.CrawlerClearBtn.UseVisualStyleBackColor = true;
            this.CrawlerClearBtn.Click += new System.EventHandler(this.CrawlerClearBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 486);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Robot";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(900, 486);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(850, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Vision";
            // 
            // VisionCrawlRTB
            // 
            this.VisionCrawlRTB.Location = new System.Drawing.Point(850, 509);
            this.VisionCrawlRTB.Name = "VisionCrawlRTB";
            this.VisionCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.VisionCrawlRTB.Size = new System.Drawing.Size(413, 252);
            this.VisionCrawlRTB.TabIndex = 12;
            this.VisionCrawlRTB.Text = "";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(900, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(847, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Error";
            // 
            // ErrorCrawlRTB
            // 
            this.ErrorCrawlRTB.Location = new System.Drawing.Point(853, 72);
            this.ErrorCrawlRTB.Name = "ErrorCrawlRTB";
            this.ErrorCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ErrorCrawlRTB.Size = new System.Drawing.Size(413, 381);
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
            this.BarcodeGrp.Location = new System.Drawing.Point(528, 349);
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
            this.TestThreadEnabledChk.Checked = true;
            this.TestThreadEnabledChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TestThreadEnabledChk.Location = new System.Drawing.Point(528, 326);
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
            this.CommandServerChk.Location = new System.Drawing.Point(528, 303);
            this.CommandServerChk.Name = "CommandServerChk";
            this.CommandServerChk.Size = new System.Drawing.Size(107, 17);
            this.CommandServerChk.TabIndex = 24;
            this.CommandServerChk.Text = "Command Server";
            this.CommandServerChk.UseVisualStyleBackColor = true;
            this.CommandServerChk.CheckedChanged += new System.EventHandler(this.CommandServerChk_CheckedChanged);
            // 
            // StartTestClientBtn
            // 
            this.StartTestClientBtn.Location = new System.Drawing.Point(365, 370);
            this.StartTestClientBtn.Name = "StartTestClientBtn";
            this.StartTestClientBtn.Size = new System.Drawing.Size(75, 56);
            this.StartTestClientBtn.TabIndex = 25;
            this.StartTestClientBtn.Text = "Start Test Client";
            this.StartTestClientBtn.UseVisualStyleBackColor = true;
            this.StartTestClientBtn.Click += new System.EventHandler(this.StartTestClientBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 773);
            this.Controls.Add(this.StartTestClientBtn);
            this.Controls.Add(this.CommandServerChk);
            this.Controls.Add(this.TestThreadEnabledChk);
            this.Controls.Add(this.BarcodeGrp);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ErrorCrawlRTB);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VisionCrawlRTB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CrawlerClearBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RobotCrawlRTB);
            this.Controls.Add(this.AllCrawlRTB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Fixed2Pic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Fixed1Pic);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.ExitBtn);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Set During Load";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Fixed1Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fixed2Pic)).EndInit();
            this.BarcodeGrp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Timer HeartbeatTmr;
        private System.Windows.Forms.PictureBox Fixed1Pic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Fixed2Pic;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox AllCrawlRTB;
        private System.Windows.Forms.RichTextBox RobotCrawlRTB;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CrawlerClearBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox VisionCrawlRTB;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
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
    }
}

