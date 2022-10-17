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
            this.AllLogRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ClientIpTxt = new System.Windows.Forms.TextBox();
            this.ClientPortTxt = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.AbortBtn = new System.Windows.Forms.Button();
            this.GetStatusBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.InitTmr = new System.Windows.Forms.Timer(this.components);
            this.ExitBtn = new System.Windows.Forms.Button();
            this.Stress1Btn = new System.Windows.Forms.Button();
            this.AutoGetStatusChk = new System.Windows.Forms.CheckBox();
            this.MessageTxt = new System.Windows.Forms.TextBox();
            this.Java1Btn = new System.Windows.Forms.Button();
            this.JavaScriptTxt = new System.Windows.Forms.TextBox();
            this.SendJsBtn = new System.Windows.Forms.Button();
            this.GetStatusTmr = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ErrorLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CommLogRTB = new System.Windows.Forms.RichTextBox();
            this.StressLogBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllLogRTB
            // 
            this.AllLogRTB.Location = new System.Drawing.Point(13, 19);
            this.AllLogRTB.Name = "AllLogRTB";
            this.AllLogRTB.ReadOnly = true;
            this.AllLogRTB.Size = new System.Drawing.Size(488, 205);
            this.AllLogRTB.TabIndex = 0;
            this.AllLogRTB.Text = "";
            this.AllLogRTB.WordWrap = false;
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
            this.SendBtn.Location = new System.Drawing.Point(168, 64);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(107, 22);
            this.SendBtn.TabIndex = 5;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // AbortBtn
            // 
            this.AbortBtn.Location = new System.Drawing.Point(433, 119);
            this.AbortBtn.Name = "AbortBtn";
            this.AbortBtn.Size = new System.Drawing.Size(78, 23);
            this.AbortBtn.TabIndex = 10;
            this.AbortBtn.Text = "Abort";
            this.AbortBtn.UseVisualStyleBackColor = true;
            this.AbortBtn.Click += new System.EventHandler(this.AbortBtn_Click);
            // 
            // GetStatusBtn
            // 
            this.GetStatusBtn.Location = new System.Drawing.Point(168, 9);
            this.GetStatusBtn.Name = "GetStatusBtn";
            this.GetStatusBtn.Size = new System.Drawing.Size(107, 22);
            this.GetStatusBtn.TabIndex = 12;
            this.GetStatusBtn.Text = "Get Status";
            this.GetStatusBtn.UseVisualStyleBackColor = true;
            this.GetStatusBtn.Click += new System.EventHandler(this.GetStatusBtn_Click);
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
            this.ExitBtn.Location = new System.Drawing.Point(433, 7);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(78, 22);
            this.ExitBtn.TabIndex = 45;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Stress1Btn
            // 
            this.Stress1Btn.Location = new System.Drawing.Point(168, 35);
            this.Stress1Btn.Name = "Stress1Btn";
            this.Stress1Btn.Size = new System.Drawing.Size(107, 23);
            this.Stress1Btn.TabIndex = 50;
            this.Stress1Btn.Text = "100X GetStatus";
            this.Stress1Btn.UseVisualStyleBackColor = true;
            this.Stress1Btn.Click += new System.EventHandler(this.Stress1Btn_Click);
            // 
            // AutoGetStatusChk
            // 
            this.AutoGetStatusChk.AutoSize = true;
            this.AutoGetStatusChk.Location = new System.Drawing.Point(281, 12);
            this.AutoGetStatusChk.Name = "AutoGetStatusChk";
            this.AutoGetStatusChk.Size = new System.Drawing.Size(101, 17);
            this.AutoGetStatusChk.TabIndex = 56;
            this.AutoGetStatusChk.Text = "Auto Get Status";
            this.AutoGetStatusChk.UseVisualStyleBackColor = true;
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(281, 66);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.Size = new System.Drawing.Size(121, 20);
            this.MessageTxt.TabIndex = 57;
            this.MessageTxt.Text = "SET xy TestXY";
            // 
            // Java1Btn
            // 
            this.Java1Btn.Location = new System.Drawing.Point(168, 120);
            this.Java1Btn.Name = "Java1Btn";
            this.Java1Btn.Size = new System.Drawing.Size(107, 22);
            this.Java1Btn.TabIndex = 58;
            this.Java1Btn.Text = "Java1";
            this.Java1Btn.UseVisualStyleBackColor = true;
            this.Java1Btn.Click += new System.EventHandler(this.Java1Btn_Click);
            // 
            // JavaScriptTxt
            // 
            this.JavaScriptTxt.Location = new System.Drawing.Point(281, 94);
            this.JavaScriptTxt.Name = "JavaScriptTxt";
            this.JavaScriptTxt.Size = new System.Drawing.Size(121, 20);
            this.JavaScriptTxt.TabIndex = 60;
            this.JavaScriptTxt.Text = "lePrint(\'Hello LEonard from LEonardClient\');";
            // 
            // SendJsBtn
            // 
            this.SendJsBtn.Location = new System.Drawing.Point(168, 92);
            this.SendJsBtn.Name = "SendJsBtn";
            this.SendJsBtn.Size = new System.Drawing.Size(107, 22);
            this.SendJsBtn.TabIndex = 59;
            this.SendJsBtn.Text = "Send {script}";
            this.SendJsBtn.UseVisualStyleBackColor = true;
            this.SendJsBtn.Click += new System.EventHandler(this.SendJsBtn_Click);
            // 
            // GetStatusTmr
            // 
            this.GetStatusTmr.Tick += new System.EventHandler(this.GetStatusTmr_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllLogRTB);
            this.groupBox1.Location = new System.Drawing.Point(4, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 230);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ErrorLogRTB);
            this.groupBox2.Location = new System.Drawing.Point(4, 649);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 230);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Error";
            // 
            // ErrorLogRTB
            // 
            this.ErrorLogRTB.Location = new System.Drawing.Point(13, 19);
            this.ErrorLogRTB.Name = "ErrorLogRTB";
            this.ErrorLogRTB.ReadOnly = true;
            this.ErrorLogRTB.Size = new System.Drawing.Size(488, 205);
            this.ErrorLogRTB.TabIndex = 0;
            this.ErrorLogRTB.Text = "";
            this.ErrorLogRTB.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CommLogRTB);
            this.groupBox3.Location = new System.Drawing.Point(4, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 230);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comm";
            // 
            // CommLogRTB
            // 
            this.CommLogRTB.Location = new System.Drawing.Point(13, 19);
            this.CommLogRTB.Name = "CommLogRTB";
            this.CommLogRTB.ReadOnly = true;
            this.CommLogRTB.Size = new System.Drawing.Size(488, 205);
            this.CommLogRTB.TabIndex = 0;
            this.CommLogRTB.Text = "";
            this.CommLogRTB.WordWrap = false;
            // 
            // StressLogBtn
            // 
            this.StressLogBtn.Location = new System.Drawing.Point(281, 35);
            this.StressLogBtn.Name = "StressLogBtn";
            this.StressLogBtn.Size = new System.Drawing.Size(75, 23);
            this.StressLogBtn.TabIndex = 63;
            this.StressLogBtn.Text = "Stress Log";
            this.StressLogBtn.UseVisualStyleBackColor = true;
            this.StressLogBtn.Click += new System.EventHandler(this.StressLogBtn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 882);
            this.ControlBox = false;
            this.Controls.Add(this.StressLogBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.JavaScriptTxt);
            this.Controls.Add(this.SendJsBtn);
            this.Controls.Add(this.Java1Btn);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.AutoGetStatusChk);
            this.Controls.Add(this.Stress1Btn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.GetStatusBtn);
            this.Controls.Add(this.AbortBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ClientPortTxt);
            this.Controls.Add(this.ClientIpTxt);
            this.Controls.Add(this.ConnectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox AllLogRTB;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox ClientIpTxt;
        private System.Windows.Forms.TextBox ClientPortTxt;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button AbortBtn;
        private System.Windows.Forms.Button GetStatusBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Timer InitTmr;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button Stress1Btn;
        private System.Windows.Forms.CheckBox AutoGetStatusChk;
        private System.Windows.Forms.TextBox MessageTxt;
        private System.Windows.Forms.Button Java1Btn;
        private System.Windows.Forms.TextBox JavaScriptTxt;
        private System.Windows.Forms.Button SendJsBtn;
        private System.Windows.Forms.Timer GetStatusTmr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox ErrorLogRTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox CommLogRTB;
        private System.Windows.Forms.Button StressLogBtn;
    }
}

