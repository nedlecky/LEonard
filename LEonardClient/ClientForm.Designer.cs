namespace LEonardClient
{
    partial class ClientForm
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
            this.CrawlerRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ClientIpTxt = new System.Windows.Forms.TextBox();
            this.ClientPortTxt = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.AbortBtn = new System.Windows.Forms.Button();
            this.GetStatusBtn = new System.Windows.Forms.Button();
            this.CommRTB = new System.Windows.Forms.RichTextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.InitTmr = new System.Windows.Forms.Timer(this.components);
            this.ExitBtn = new System.Windows.Forms.Button();
            this.Stress1Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LogfileTxt = new System.Windows.Forms.TextBox();
            this.AutoGetStatusChk = new System.Windows.Forms.CheckBox();
            this.MessageTxt = new System.Windows.Forms.TextBox();
            this.Java1Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CrawlerRTB
            // 
            this.CrawlerRTB.Location = new System.Drawing.Point(12, 599);
            this.CrawlerRTB.Name = "CrawlerRTB";
            this.CrawlerRTB.Size = new System.Drawing.Size(507, 311);
            this.CrawlerRTB.TabIndex = 0;
            this.CrawlerRTB.Text = "";
            this.CrawlerRTB.WordWrap = false;
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(12, 9);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(128, 23);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ClientIpTxt
            // 
            this.ClientIpTxt.Location = new System.Drawing.Point(12, 38);
            this.ClientIpTxt.Name = "ClientIpTxt";
            this.ClientIpTxt.Size = new System.Drawing.Size(83, 20);
            this.ClientIpTxt.TabIndex = 3;
            this.ClientIpTxt.Text = "192.168.1.103";
            // 
            // ClientPortTxt
            // 
            this.ClientPortTxt.Location = new System.Drawing.Point(101, 38);
            this.ClientPortTxt.Name = "ClientPortTxt";
            this.ClientPortTxt.Size = new System.Drawing.Size(39, 20);
            this.ClientPortTxt.TabIndex = 4;
            this.ClientPortTxt.Text = "1000";
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(218, 145);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(107, 22);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // AbortBtn
            // 
            this.AbortBtn.Location = new System.Drawing.Point(218, 173);
            this.AbortBtn.Name = "AbortBtn";
            this.AbortBtn.Size = new System.Drawing.Size(107, 23);
            this.AbortBtn.TabIndex = 10;
            this.AbortBtn.Text = "Abort";
            this.AbortBtn.UseVisualStyleBackColor = true;
            this.AbortBtn.Click += new System.EventHandler(this.AbortBtn_Click);
            // 
            // GetStatusBtn
            // 
            this.GetStatusBtn.Location = new System.Drawing.Point(218, 88);
            this.GetStatusBtn.Name = "GetStatusBtn";
            this.GetStatusBtn.Size = new System.Drawing.Size(107, 22);
            this.GetStatusBtn.TabIndex = 12;
            this.GetStatusBtn.Text = "Get Status";
            this.GetStatusBtn.UseVisualStyleBackColor = true;
            this.GetStatusBtn.Click += new System.EventHandler(this.GetStatusBtn_Click);
            // 
            // CommRTB
            // 
            this.CommRTB.Location = new System.Drawing.Point(12, 238);
            this.CommRTB.Name = "CommRTB";
            this.CommRTB.Size = new System.Drawing.Size(507, 355);
            this.CommRTB.TabIndex = 13;
            this.CommRTB.Text = "";
            this.CommRTB.WordWrap = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(12, 64);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(128, 23);
            this.SaveBtn.TabIndex = 14;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // InitTmr
            // 
            this.InitTmr.Tick += new System.EventHandler(this.InitTmr_Tick);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(459, 12);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(60, 42);
            this.ExitBtn.TabIndex = 45;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Stress1Btn
            // 
            this.Stress1Btn.Location = new System.Drawing.Point(218, 116);
            this.Stress1Btn.Name = "Stress1Btn";
            this.Stress1Btn.Size = new System.Drawing.Size(107, 23);
            this.Stress1Btn.TabIndex = 50;
            this.Stress1Btn.Text = "100X GetStatus";
            this.Stress1Btn.UseVisualStyleBackColor = true;
            this.Stress1Btn.Click += new System.EventHandler(this.Stress1Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Logfile";
            // 
            // LogfileTxt
            // 
            this.LogfileTxt.Location = new System.Drawing.Point(58, 212);
            this.LogfileTxt.Name = "LogfileTxt";
            this.LogfileTxt.Size = new System.Drawing.Size(368, 20);
            this.LogfileTxt.TabIndex = 55;
            this.LogfileTxt.Text = "C:/Users/nedlecky/Desktop/LEonard Files/LEonardClient.log";
            // 
            // AutoGetStatusChk
            // 
            this.AutoGetStatusChk.AutoSize = true;
            this.AutoGetStatusChk.Checked = true;
            this.AutoGetStatusChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoGetStatusChk.Location = new System.Drawing.Point(331, 88);
            this.AutoGetStatusChk.Name = "AutoGetStatusChk";
            this.AutoGetStatusChk.Size = new System.Drawing.Size(101, 17);
            this.AutoGetStatusChk.TabIndex = 56;
            this.AutoGetStatusChk.Text = "Auto Get Status";
            this.AutoGetStatusChk.UseVisualStyleBackColor = true;
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(332, 147);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.Size = new System.Drawing.Size(130, 20);
            this.MessageTxt.TabIndex = 57;
            this.MessageTxt.Text = "set xy TestXY";
            // 
            // Java1Btn
            // 
            this.Java1Btn.Location = new System.Drawing.Point(218, 10);
            this.Java1Btn.Name = "Java1Btn";
            this.Java1Btn.Size = new System.Drawing.Size(107, 22);
            this.Java1Btn.TabIndex = 58;
            this.Java1Btn.Text = "Java1";
            this.Java1Btn.UseVisualStyleBackColor = true;
            this.Java1Btn.Click += new System.EventHandler(this.Java1Btn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 915);
            this.ControlBox = false;
            this.Controls.Add(this.Java1Btn);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.AutoGetStatusChk);
            this.Controls.Add(this.LogfileTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Stress1Btn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CommRTB);
            this.Controls.Add(this.GetStatusBtn);
            this.Controls.Add(this.AbortBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ClientPortTxt);
            this.Controls.Add(this.ClientIpTxt);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.CrawlerRTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox CrawlerRTB;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox ClientIpTxt;
        private System.Windows.Forms.TextBox ClientPortTxt;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button AbortBtn;
        private System.Windows.Forms.Button GetStatusBtn;
        private System.Windows.Forms.RichTextBox CommRTB;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Timer InitTmr;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button Stress1Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogfileTxt;
        private System.Windows.Forms.CheckBox AutoGetStatusChk;
        private System.Windows.Forms.TextBox MessageTxt;
        private System.Windows.Forms.Button Java1Btn;
    }
}

