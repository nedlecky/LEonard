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
            this.HeartbeatTmr = new System.Windows.Forms.Timer(this.components);
            this.AllLogRTB = new System.Windows.Forms.RichTextBox();
            this.Aux1LogRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.CrawlerClearBtn = new System.Windows.Forms.Button();
            this.RobotClearBtn = new System.Windows.Forms.Button();
            this.VisionClearBtn = new System.Windows.Forms.Button();
            this.Aux2LogRTB = new System.Windows.Forms.RichTextBox();
            this.ErrorClearBtn = new System.Windows.Forms.Button();
            this.ErrorLogRTB = new System.Windows.Forms.RichTextBox();
            this.CloseTmr = new System.Windows.Forms.Timer(this.components);
            this.BarcodeGrp = new System.Windows.Forms.GroupBox();
            this.BcrEndBtn = new System.Windows.Forms.Button();
            this.BcrtStartBtn = new System.Windows.Forms.Button();
            this.BcrtDestroyBtn = new System.Windows.Forms.Button();
            this.BcrtCreateBtn = new System.Windows.Forms.Button();
            this.BarcodeReaderThreadChk = new System.Windows.Forms.CheckBox();
            this.CurrentSendMessageBtn = new System.Windows.Forms.Button();
            this.MessageToSendTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SerialClearBtn = new System.Windows.Forms.Button();
            this.Aux3LogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CommandClearBtn = new System.Windows.Forms.Button();
            this.ControlLogRTB = new System.Windows.Forms.RichTextBox();
            this.PersonalityTabs = new System.Windows.Forms.TabControl();
            this.RuntimeTab = new System.Windows.Forms.TabPage();
            this.ProgramTab = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ReadVariableBtn = new System.Windows.Forms.Button();
            this.WriteStringValueTxt = new System.Windows.Forms.TextBox();
            this.WriteStringValueBtn = new System.Windows.Forms.Button();
            this.VariableNameTxt = new System.Windows.Forms.TextBox();
            this.LoadVariablesBtn = new System.Windows.Forms.Button();
            this.SaveVariablesBtn = new System.Windows.Forms.Button();
            this.ClearVariablesBtn = new System.Windows.Forms.Button();
            this.VariablesGrd = new System.Windows.Forms.DataGridView();
            this.JavaVariablesRefreshBtn = new System.Windows.Forms.Button();
            this.JavaScriptVariablesRTB = new System.Windows.Forms.RichTextBox();
            this.JavaCommandTxt = new System.Windows.Forms.TextBox();
            this.ExecJavaBtn = new System.Windows.Forms.Button();
            this.SetAutoloadFileBtn = new System.Windows.Forms.Button();
            this.JavaScriptFilenameLbl = new System.Windows.Forms.Label();
            this.JavaScriptCodeRTB = new System.Windows.Forms.RichTextBox();
            this.JavaScriptClearRTB = new System.Windows.Forms.Button();
            this.JavaScriptConsoleRTB = new System.Windows.Forms.RichTextBox();
            this.RunJavaProgramBtn = new System.Windows.Forms.Button();
            this.SaveAsJavaProgramBtn = new System.Windows.Forms.Button();
            this.NewJavaProgramBtn = new System.Windows.Forms.Button();
            this.LoadJavaProgramBtn = new System.Windows.Forms.Button();
            this.SaveJavaProgramBtn = new System.Windows.Forms.Button();
            this.ReportingTab = new System.Windows.Forms.TabPage();
            this.BrowserTab = new System.Windows.Forms.TabPage();
            this.webControl1 = new EO.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.ConfigTab = new System.Windows.Forms.TabPage();
            this.DevicesGrp = new System.Windows.Forms.GroupBox();
            this.speedBtnsGrp = new System.Windows.Forms.GroupBox();
            this.SpeedSendBtn1 = new System.Windows.Forms.Button();
            this.SetStartupDevicesBtn = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CurrentReconnectBtn = new System.Windows.Forms.Button();
            this.LaunchSetupBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ExitSetupBtn = new System.Windows.Forms.Button();
            this.DelayMsTxt = new System.Windows.Forms.TextBox();
            this.RestoreSetupBtn = new System.Windows.Forms.Button();
            this.SendMultipleTxt = new System.Windows.Forms.TextBox();
            this.MinimizeSetupBtn = new System.Windows.Forms.Button();
            this.CurrentSendMessageMultipleBtn = new System.Windows.Forms.Button();
            this.LaunchRuntimeBtn = new System.Windows.Forms.Button();
            this.CurrentDisconnectBtn = new System.Windows.Forms.Button();
            this.ExitRuntimeBtn = new System.Windows.Forms.Button();
            this.CurrentConnectBtn = new System.Windows.Forms.Button();
            this.RestoreRuntimeBtn = new System.Windows.Forms.Button();
            this.MinimizeRuntimeBtn = new System.Windows.Forms.Button();
            this.DevicesFilenameLbl = new System.Windows.Forms.Label();
            this.DefaultDevicesBtn = new System.Windows.Forms.Button();
            this.SaveDevicesBtn = new System.Windows.Forms.Button();
            this.DisconnectAllDevicesBtn = new System.Windows.Forms.Button();
            this.LoadDevicesBtn = new System.Windows.Forms.Button();
            this.ConnectAllDevicesBtn = new System.Windows.Forms.Button();
            this.SaveAsDevicesBtn = new System.Windows.Forms.Button();
            this.DevicesGrid = new System.Windows.Forms.DataGridView();
            this.ConfigGrp = new System.Windows.Forms.GroupBox();
            this.ChangeStartupJavaScriptBtn = new System.Windows.Forms.Button();
            this.StartupJavaScriptLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UtcTimeChk = new System.Windows.Forms.CheckBox();
            this.AutoConnectOnLoadChk = new System.Windows.Forms.CheckBox();
            this.ChangeStartupDevicesBtn = new System.Windows.Forms.Button();
            this.StartupDevicesLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeLEonardRootBtn = new System.Windows.Forms.Button();
            this.LEonardRootLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DefaultConfigBtn = new System.Windows.Forms.Button();
            this.LoadConfigBtn = new System.Windows.Forms.Button();
            this.SaveConfigBtn = new System.Windows.Forms.Button();
            this.OlisConnectBtn = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartupTmr = new System.Windows.Forms.Timer(this.components);
            this.ChromeBtn = new System.Windows.Forms.Button();
            this.ChromeUrlTxt = new System.Windows.Forms.TextBox();
            this.BarcodeGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.PersonalityTabs.SuspendLayout();
            this.ProgramTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).BeginInit();
            this.BrowserTab.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            this.DevicesGrp.SuspendLayout();
            this.speedBtnsGrp.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrid)).BeginInit();
            this.ConfigGrp.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeartbeatTmr
            // 
            this.HeartbeatTmr.Tick += new System.EventHandler(this.HeartbeatTmr_Tick);
            // 
            // AllLogRTB
            // 
            this.AllLogRTB.Location = new System.Drawing.Point(6, 19);
            this.AllLogRTB.Name = "AllLogRTB";
            this.AllLogRTB.ReadOnly = true;
            this.AllLogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AllLogRTB.Size = new System.Drawing.Size(426, 233);
            this.AllLogRTB.TabIndex = 6;
            this.AllLogRTB.Text = "";
            this.AllLogRTB.WordWrap = false;
            // 
            // Aux1LogRTB
            // 
            this.Aux1LogRTB.Location = new System.Drawing.Point(6, 15);
            this.Aux1LogRTB.Name = "Aux1LogRTB";
            this.Aux1LogRTB.ReadOnly = true;
            this.Aux1LogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Aux1LogRTB.Size = new System.Drawing.Size(376, 198);
            this.Aux1LogRTB.TabIndex = 7;
            this.Aux1LogRTB.Text = "";
            this.Aux1LogRTB.WordWrap = false;
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // CrawlerClearBtn
            // 
            this.CrawlerClearBtn.Location = new System.Drawing.Point(362, 22);
            this.CrawlerClearBtn.Name = "CrawlerClearBtn";
            this.CrawlerClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CrawlerClearBtn.TabIndex = 9;
            this.CrawlerClearBtn.Text = "Clear";
            this.CrawlerClearBtn.UseVisualStyleBackColor = true;
            this.CrawlerClearBtn.Click += new System.EventHandler(this.AllLogClearBtn_Click);
            // 
            // RobotClearBtn
            // 
            this.RobotClearBtn.Location = new System.Drawing.Point(312, 16);
            this.RobotClearBtn.Name = "RobotClearBtn";
            this.RobotClearBtn.Size = new System.Drawing.Size(50, 23);
            this.RobotClearBtn.TabIndex = 11;
            this.RobotClearBtn.Text = "Clear";
            this.RobotClearBtn.UseVisualStyleBackColor = true;
            this.RobotClearBtn.Click += new System.EventHandler(this.Aux1ClearBtn_Click);
            // 
            // VisionClearBtn
            // 
            this.VisionClearBtn.Location = new System.Drawing.Point(312, 19);
            this.VisionClearBtn.Name = "VisionClearBtn";
            this.VisionClearBtn.Size = new System.Drawing.Size(50, 23);
            this.VisionClearBtn.TabIndex = 14;
            this.VisionClearBtn.Text = "Clear";
            this.VisionClearBtn.UseVisualStyleBackColor = true;
            this.VisionClearBtn.Click += new System.EventHandler(this.Aux2ClearBtn_Click);
            // 
            // Aux2LogRTB
            // 
            this.Aux2LogRTB.Location = new System.Drawing.Point(6, 15);
            this.Aux2LogRTB.Name = "Aux2LogRTB";
            this.Aux2LogRTB.ReadOnly = true;
            this.Aux2LogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Aux2LogRTB.Size = new System.Drawing.Size(376, 231);
            this.Aux2LogRTB.TabIndex = 12;
            this.Aux2LogRTB.Text = "";
            this.Aux2LogRTB.WordWrap = false;
            // 
            // ErrorClearBtn
            // 
            this.ErrorClearBtn.Location = new System.Drawing.Point(362, 19);
            this.ErrorClearBtn.Name = "ErrorClearBtn";
            this.ErrorClearBtn.Size = new System.Drawing.Size(50, 23);
            this.ErrorClearBtn.TabIndex = 17;
            this.ErrorClearBtn.Text = "Clear";
            this.ErrorClearBtn.UseVisualStyleBackColor = true;
            this.ErrorClearBtn.Click += new System.EventHandler(this.ErrorLogClearBtn_Click);
            // 
            // ErrorLogRTB
            // 
            this.ErrorLogRTB.Location = new System.Drawing.Point(6, 16);
            this.ErrorLogRTB.Name = "ErrorLogRTB";
            this.ErrorLogRTB.ReadOnly = true;
            this.ErrorLogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ErrorLogRTB.Size = new System.Drawing.Size(426, 218);
            this.ErrorLogRTB.TabIndex = 15;
            this.ErrorLogRTB.Text = "";
            this.ErrorLogRTB.WordWrap = false;
            // 
            // CloseTmr
            // 
            this.CloseTmr.Tick += new System.EventHandler(this.CloseTmr_Tick);
            // 
            // BarcodeGrp
            // 
            this.BarcodeGrp.Controls.Add(this.BcrEndBtn);
            this.BarcodeGrp.Controls.Add(this.BcrtStartBtn);
            this.BarcodeGrp.Controls.Add(this.BcrtDestroyBtn);
            this.BarcodeGrp.Controls.Add(this.BcrtCreateBtn);
            this.BarcodeGrp.Controls.Add(this.BarcodeReaderThreadChk);
            this.BarcodeGrp.Location = new System.Drawing.Point(7, 579);
            this.BarcodeGrp.Name = "BarcodeGrp";
            this.BarcodeGrp.Size = new System.Drawing.Size(224, 110);
            this.BarcodeGrp.TabIndex = 22;
            this.BarcodeGrp.TabStop = false;
            this.BarcodeGrp.Text = "Barcode Thread Control";
            // 
            // BcrEndBtn
            // 
            this.BcrEndBtn.Location = new System.Drawing.Point(87, 55);
            this.BcrEndBtn.Name = "BcrEndBtn";
            this.BcrEndBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrEndBtn.TabIndex = 30;
            this.BcrEndBtn.Text = "End";
            this.BcrEndBtn.UseVisualStyleBackColor = true;
            this.BcrEndBtn.Click += new System.EventHandler(this.BcrtEndBtn_Click);
            // 
            // BcrtStartBtn
            // 
            this.BcrtStartBtn.Location = new System.Drawing.Point(6, 55);
            this.BcrtStartBtn.Name = "BcrtStartBtn";
            this.BcrtStartBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrtStartBtn.TabIndex = 29;
            this.BcrtStartBtn.Text = "Start";
            this.BcrtStartBtn.UseVisualStyleBackColor = true;
            this.BcrtStartBtn.Click += new System.EventHandler(this.BcrtStartBtn_Click);
            // 
            // BcrtDestroyBtn
            // 
            this.BcrtDestroyBtn.Location = new System.Drawing.Point(87, 26);
            this.BcrtDestroyBtn.Name = "BcrtDestroyBtn";
            this.BcrtDestroyBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrtDestroyBtn.TabIndex = 28;
            this.BcrtDestroyBtn.Text = "Destroy";
            this.BcrtDestroyBtn.UseVisualStyleBackColor = true;
            this.BcrtDestroyBtn.Click += new System.EventHandler(this.BcrtDestroyBtn_Click);
            // 
            // BcrtCreateBtn
            // 
            this.BcrtCreateBtn.Location = new System.Drawing.Point(6, 26);
            this.BcrtCreateBtn.Name = "BcrtCreateBtn";
            this.BcrtCreateBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrtCreateBtn.TabIndex = 27;
            this.BcrtCreateBtn.Text = "Create";
            this.BcrtCreateBtn.UseVisualStyleBackColor = true;
            this.BcrtCreateBtn.Click += new System.EventHandler(this.BcrtCreateBtn_Click);
            // 
            // BarcodeReaderThreadChk
            // 
            this.BarcodeReaderThreadChk.AutoSize = true;
            this.BarcodeReaderThreadChk.Location = new System.Drawing.Point(6, 84);
            this.BarcodeReaderThreadChk.Name = "BarcodeReaderThreadChk";
            this.BarcodeReaderThreadChk.Size = new System.Drawing.Size(177, 17);
            this.BarcodeReaderThreadChk.TabIndex = 26;
            this.BarcodeReaderThreadChk.Text = "BarcodeReaderThread Enabled";
            this.BarcodeReaderThreadChk.UseVisualStyleBackColor = true;
            this.BarcodeReaderThreadChk.CheckedChanged += new System.EventHandler(this.BarcodeReaderThreadChk_CheckedChanged);
            // 
            // CurrentSendMessageBtn
            // 
            this.CurrentSendMessageBtn.Location = new System.Drawing.Point(14, 90);
            this.CurrentSendMessageBtn.Name = "CurrentSendMessageBtn";
            this.CurrentSendMessageBtn.Size = new System.Drawing.Size(75, 23);
            this.CurrentSendMessageBtn.TabIndex = 27;
            this.CurrentSendMessageBtn.Text = "Send";
            this.CurrentSendMessageBtn.UseVisualStyleBackColor = true;
            this.CurrentSendMessageBtn.Click += new System.EventHandler(this.CurrentSendMessageBtn_Click);
            // 
            // MessageToSendTxt
            // 
            this.MessageToSendTxt.Location = new System.Drawing.Point(95, 95);
            this.MessageToSendTxt.Name = "MessageToSendTxt";
            this.MessageToSendTxt.Size = new System.Drawing.Size(100, 20);
            this.MessageToSendTxt.TabIndex = 28;
            this.MessageToSendTxt.Text = "(1,0,0,0,0)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RobotClearBtn);
            this.groupBox1.Controls.Add(this.Aux1LogRTB);
            this.groupBox1.Location = new System.Drawing.Point(1913, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 224);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aux1 Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SerialClearBtn);
            this.groupBox2.Controls.Add(this.Aux3LogRTB);
            this.groupBox2.Location = new System.Drawing.Point(1913, 516);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 262);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aux3 Log";
            // 
            // SerialClearBtn
            // 
            this.SerialClearBtn.Location = new System.Drawing.Point(306, 22);
            this.SerialClearBtn.Name = "SerialClearBtn";
            this.SerialClearBtn.Size = new System.Drawing.Size(50, 23);
            this.SerialClearBtn.TabIndex = 11;
            this.SerialClearBtn.Text = "Clear";
            this.SerialClearBtn.UseVisualStyleBackColor = true;
            this.SerialClearBtn.Click += new System.EventHandler(this.Aux3ClearBtn_Click);
            // 
            // Aux3LogRTB
            // 
            this.Aux3LogRTB.Location = new System.Drawing.Point(6, 19);
            this.Aux3LogRTB.Name = "Aux3LogRTB";
            this.Aux3LogRTB.ReadOnly = true;
            this.Aux3LogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Aux3LogRTB.Size = new System.Drawing.Size(370, 222);
            this.Aux3LogRTB.TabIndex = 7;
            this.Aux3LogRTB.Text = "";
            this.Aux3LogRTB.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VisionClearBtn);
            this.groupBox3.Controls.Add(this.Aux2LogRTB);
            this.groupBox3.Location = new System.Drawing.Point(1913, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 252);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aux2 Log";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CrawlerClearBtn);
            this.groupBox4.Controls.Add(this.AllLogRTB);
            this.groupBox4.Location = new System.Drawing.Point(1469, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 267);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ErrorClearBtn);
            this.groupBox5.Controls.Add(this.ErrorLogRTB);
            this.groupBox5.Location = new System.Drawing.Point(1471, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(438, 241);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Error Log";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CommandClearBtn);
            this.groupBox6.Controls.Add(this.ControlLogRTB);
            this.groupBox6.Location = new System.Drawing.Point(1471, 548);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(438, 230);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Control Log";
            // 
            // CommandClearBtn
            // 
            this.CommandClearBtn.Location = new System.Drawing.Point(362, 21);
            this.CommandClearBtn.Name = "CommandClearBtn";
            this.CommandClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CommandClearBtn.TabIndex = 9;
            this.CommandClearBtn.Text = "Clear";
            this.CommandClearBtn.UseVisualStyleBackColor = true;
            this.CommandClearBtn.Click += new System.EventHandler(this.ControlLogClearBtn_Click);
            // 
            // ControlLogRTB
            // 
            this.ControlLogRTB.Location = new System.Drawing.Point(6, 19);
            this.ControlLogRTB.Name = "ControlLogRTB";
            this.ControlLogRTB.ReadOnly = true;
            this.ControlLogRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ControlLogRTB.Size = new System.Drawing.Size(426, 205);
            this.ControlLogRTB.TabIndex = 6;
            this.ControlLogRTB.Text = "";
            this.ControlLogRTB.WordWrap = false;
            // 
            // PersonalityTabs
            // 
            this.PersonalityTabs.Controls.Add(this.RuntimeTab);
            this.PersonalityTabs.Controls.Add(this.ProgramTab);
            this.PersonalityTabs.Controls.Add(this.ReportingTab);
            this.PersonalityTabs.Controls.Add(this.BrowserTab);
            this.PersonalityTabs.Controls.Add(this.ConfigTab);
            this.PersonalityTabs.Location = new System.Drawing.Point(12, 27);
            this.PersonalityTabs.Name = "PersonalityTabs";
            this.PersonalityTabs.SelectedIndex = 0;
            this.PersonalityTabs.Size = new System.Drawing.Size(1451, 918);
            this.PersonalityTabs.TabIndex = 62;
            // 
            // RuntimeTab
            // 
            this.RuntimeTab.Location = new System.Drawing.Point(4, 22);
            this.RuntimeTab.Name = "RuntimeTab";
            this.RuntimeTab.Padding = new System.Windows.Forms.Padding(3);
            this.RuntimeTab.Size = new System.Drawing.Size(1443, 892);
            this.RuntimeTab.TabIndex = 0;
            this.RuntimeTab.Text = "Runtime";
            this.RuntimeTab.UseVisualStyleBackColor = true;
            // 
            // ProgramTab
            // 
            this.ProgramTab.Controls.Add(this.groupBox7);
            this.ProgramTab.Controls.Add(this.LoadVariablesBtn);
            this.ProgramTab.Controls.Add(this.SaveVariablesBtn);
            this.ProgramTab.Controls.Add(this.ClearVariablesBtn);
            this.ProgramTab.Controls.Add(this.VariablesGrd);
            this.ProgramTab.Controls.Add(this.JavaVariablesRefreshBtn);
            this.ProgramTab.Controls.Add(this.JavaScriptVariablesRTB);
            this.ProgramTab.Controls.Add(this.JavaCommandTxt);
            this.ProgramTab.Controls.Add(this.ExecJavaBtn);
            this.ProgramTab.Controls.Add(this.SetAutoloadFileBtn);
            this.ProgramTab.Controls.Add(this.JavaScriptFilenameLbl);
            this.ProgramTab.Controls.Add(this.JavaScriptCodeRTB);
            this.ProgramTab.Controls.Add(this.JavaScriptClearRTB);
            this.ProgramTab.Controls.Add(this.JavaScriptConsoleRTB);
            this.ProgramTab.Controls.Add(this.RunJavaProgramBtn);
            this.ProgramTab.Controls.Add(this.SaveAsJavaProgramBtn);
            this.ProgramTab.Controls.Add(this.NewJavaProgramBtn);
            this.ProgramTab.Controls.Add(this.LoadJavaProgramBtn);
            this.ProgramTab.Controls.Add(this.SaveJavaProgramBtn);
            this.ProgramTab.Location = new System.Drawing.Point(4, 22);
            this.ProgramTab.Name = "ProgramTab";
            this.ProgramTab.Size = new System.Drawing.Size(1443, 892);
            this.ProgramTab.TabIndex = 4;
            this.ProgramTab.Text = "Program";
            this.ProgramTab.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ReadVariableBtn);
            this.groupBox7.Controls.Add(this.WriteStringValueTxt);
            this.groupBox7.Controls.Add(this.WriteStringValueBtn);
            this.groupBox7.Controls.Add(this.VariableNameTxt);
            this.groupBox7.Location = new System.Drawing.Point(625, 340);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(650, 49);
            this.groupBox7.TabIndex = 81;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Manual";
            // 
            // ReadVariableBtn
            // 
            this.ReadVariableBtn.Location = new System.Drawing.Point(140, 17);
            this.ReadVariableBtn.Name = "ReadVariableBtn";
            this.ReadVariableBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadVariableBtn.TabIndex = 2;
            this.ReadVariableBtn.Text = "Read";
            this.ReadVariableBtn.UseVisualStyleBackColor = true;
            this.ReadVariableBtn.Click += new System.EventHandler(this.ReadVariableBtn_Click);
            // 
            // WriteStringValueTxt
            // 
            this.WriteStringValueTxt.Location = new System.Drawing.Point(338, 22);
            this.WriteStringValueTxt.Name = "WriteStringValueTxt";
            this.WriteStringValueTxt.Size = new System.Drawing.Size(209, 20);
            this.WriteStringValueTxt.TabIndex = 7;
            this.WriteStringValueTxt.Text = "Test String";
            // 
            // WriteStringValueBtn
            // 
            this.WriteStringValueBtn.Location = new System.Drawing.Point(257, 19);
            this.WriteStringValueBtn.Name = "WriteStringValueBtn";
            this.WriteStringValueBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteStringValueBtn.TabIndex = 4;
            this.WriteStringValueBtn.Text = "Write String";
            this.WriteStringValueBtn.UseVisualStyleBackColor = true;
            this.WriteStringValueBtn.Click += new System.EventHandler(this.WriteStringValueBtn_Click);
            // 
            // VariableNameTxt
            // 
            this.VariableNameTxt.Location = new System.Drawing.Point(6, 19);
            this.VariableNameTxt.Name = "VariableNameTxt";
            this.VariableNameTxt.Size = new System.Drawing.Size(128, 20);
            this.VariableNameTxt.TabIndex = 5;
            this.VariableNameTxt.Text = "X";
            // 
            // LoadVariablesBtn
            // 
            this.LoadVariablesBtn.Location = new System.Drawing.Point(625, 851);
            this.LoadVariablesBtn.Name = "LoadVariablesBtn";
            this.LoadVariablesBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadVariablesBtn.TabIndex = 80;
            this.LoadVariablesBtn.Text = "Load";
            this.LoadVariablesBtn.UseVisualStyleBackColor = true;
            this.LoadVariablesBtn.Click += new System.EventHandler(this.LoadVariablesBtn_Click);
            // 
            // SaveVariablesBtn
            // 
            this.SaveVariablesBtn.Location = new System.Drawing.Point(706, 851);
            this.SaveVariablesBtn.Name = "SaveVariablesBtn";
            this.SaveVariablesBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveVariablesBtn.TabIndex = 79;
            this.SaveVariablesBtn.Text = "Save";
            this.SaveVariablesBtn.UseVisualStyleBackColor = true;
            this.SaveVariablesBtn.Click += new System.EventHandler(this.SaveVariablesBtn_Click);
            // 
            // ClearVariablesBtn
            // 
            this.ClearVariablesBtn.Location = new System.Drawing.Point(787, 851);
            this.ClearVariablesBtn.Name = "ClearVariablesBtn";
            this.ClearVariablesBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearVariablesBtn.TabIndex = 78;
            this.ClearVariablesBtn.Text = "Clear";
            this.ClearVariablesBtn.UseVisualStyleBackColor = true;
            this.ClearVariablesBtn.Click += new System.EventHandler(this.ClearVariablesBtn_Click);
            // 
            // VariablesGrd
            // 
            this.VariablesGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariablesGrd.Location = new System.Drawing.Point(625, 392);
            this.VariablesGrd.Name = "VariablesGrd";
            this.VariablesGrd.Size = new System.Drawing.Size(650, 453);
            this.VariablesGrd.TabIndex = 77;
            // 
            // JavaVariablesRefreshBtn
            // 
            this.JavaVariablesRefreshBtn.Location = new System.Drawing.Point(625, 9);
            this.JavaVariablesRefreshBtn.Name = "JavaVariablesRefreshBtn";
            this.JavaVariablesRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.JavaVariablesRefreshBtn.TabIndex = 76;
            this.JavaVariablesRefreshBtn.Text = "Refresh";
            this.JavaVariablesRefreshBtn.UseVisualStyleBackColor = true;
            this.JavaVariablesRefreshBtn.Click += new System.EventHandler(this.JavaVariablesRefreshBtn_Click);
            // 
            // JavaScriptVariablesRTB
            // 
            this.JavaScriptVariablesRTB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaScriptVariablesRTB.Location = new System.Drawing.Point(625, 35);
            this.JavaScriptVariablesRTB.Name = "JavaScriptVariablesRTB";
            this.JavaScriptVariablesRTB.ReadOnly = true;
            this.JavaScriptVariablesRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.JavaScriptVariablesRTB.Size = new System.Drawing.Size(650, 299);
            this.JavaScriptVariablesRTB.TabIndex = 75;
            this.JavaScriptVariablesRTB.Text = "";
            this.JavaScriptVariablesRTB.WordWrap = false;
            // 
            // JavaCommandTxt
            // 
            this.JavaCommandTxt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaCommandTxt.Location = new System.Drawing.Point(339, 427);
            this.JavaCommandTxt.Multiline = true;
            this.JavaCommandTxt.Name = "JavaCommandTxt";
            this.JavaCommandTxt.Size = new System.Drawing.Size(280, 155);
            this.JavaCommandTxt.TabIndex = 74;
            this.JavaCommandTxt.Text = "print(\"hello\");";
            // 
            // ExecJavaBtn
            // 
            this.ExecJavaBtn.Location = new System.Drawing.Point(339, 395);
            this.ExecJavaBtn.Name = "ExecJavaBtn";
            this.ExecJavaBtn.Size = new System.Drawing.Size(280, 26);
            this.ExecJavaBtn.TabIndex = 73;
            this.ExecJavaBtn.Text = "Exec Java Scratchpad";
            this.ExecJavaBtn.UseVisualStyleBackColor = true;
            this.ExecJavaBtn.Click += new System.EventHandler(this.ExecJavaBtn_Click);
            // 
            // SetAutoloadFileBtn
            // 
            this.SetAutoloadFileBtn.Location = new System.Drawing.Point(510, 9);
            this.SetAutoloadFileBtn.Name = "SetAutoloadFileBtn";
            this.SetAutoloadFileBtn.Size = new System.Drawing.Size(109, 23);
            this.SetAutoloadFileBtn.TabIndex = 72;
            this.SetAutoloadFileBtn.Text = "Set To Autoload";
            this.SetAutoloadFileBtn.UseVisualStyleBackColor = true;
            this.SetAutoloadFileBtn.Click += new System.EventHandler(this.SetAutoloadFileBtn_Click);
            // 
            // JavaScriptFilenameLbl
            // 
            this.JavaScriptFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JavaScriptFilenameLbl.Location = new System.Drawing.Point(13, 9);
            this.JavaScriptFilenameLbl.Name = "JavaScriptFilenameLbl";
            this.JavaScriptFilenameLbl.Size = new System.Drawing.Size(491, 23);
            this.JavaScriptFilenameLbl.TabIndex = 71;
            this.JavaScriptFilenameLbl.Text = "Untitled";
            this.JavaScriptFilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // JavaScriptCodeRTB
            // 
            this.JavaScriptCodeRTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaScriptCodeRTB.Location = new System.Drawing.Point(12, 35);
            this.JavaScriptCodeRTB.Name = "JavaScriptCodeRTB";
            this.JavaScriptCodeRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.JavaScriptCodeRTB.Size = new System.Drawing.Size(607, 354);
            this.JavaScriptCodeRTB.TabIndex = 70;
            this.JavaScriptCodeRTB.Text = "";
            // 
            // JavaScriptClearRTB
            // 
            this.JavaScriptClearRTB.Location = new System.Drawing.Point(13, 559);
            this.JavaScriptClearRTB.Name = "JavaScriptClearRTB";
            this.JavaScriptClearRTB.Size = new System.Drawing.Size(50, 23);
            this.JavaScriptClearRTB.TabIndex = 18;
            this.JavaScriptClearRTB.Text = "Clear";
            this.JavaScriptClearRTB.UseVisualStyleBackColor = true;
            this.JavaScriptClearRTB.Click += new System.EventHandler(this.JavaScriptConsoleClearRTB_Click);
            // 
            // JavaScriptConsoleRTB
            // 
            this.JavaScriptConsoleRTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaScriptConsoleRTB.Location = new System.Drawing.Point(12, 588);
            this.JavaScriptConsoleRTB.MaxLength = 200;
            this.JavaScriptConsoleRTB.Name = "JavaScriptConsoleRTB";
            this.JavaScriptConsoleRTB.ReadOnly = true;
            this.JavaScriptConsoleRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.JavaScriptConsoleRTB.Size = new System.Drawing.Size(607, 290);
            this.JavaScriptConsoleRTB.TabIndex = 18;
            this.JavaScriptConsoleRTB.Text = "";
            this.JavaScriptConsoleRTB.WordWrap = false;
            // 
            // RunJavaProgramBtn
            // 
            this.RunJavaProgramBtn.Location = new System.Drawing.Point(13, 432);
            this.RunJavaProgramBtn.Name = "RunJavaProgramBtn";
            this.RunJavaProgramBtn.Size = new System.Drawing.Size(317, 23);
            this.RunJavaProgramBtn.TabIndex = 69;
            this.RunJavaProgramBtn.Text = "Run";
            this.RunJavaProgramBtn.UseVisualStyleBackColor = true;
            this.RunJavaProgramBtn.Click += new System.EventHandler(this.RunJavaProgramBtn_Click);
            // 
            // SaveAsJavaProgramBtn
            // 
            this.SaveAsJavaProgramBtn.Location = new System.Drawing.Point(255, 395);
            this.SaveAsJavaProgramBtn.Name = "SaveAsJavaProgramBtn";
            this.SaveAsJavaProgramBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveAsJavaProgramBtn.TabIndex = 68;
            this.SaveAsJavaProgramBtn.Text = "Save As...";
            this.SaveAsJavaProgramBtn.UseVisualStyleBackColor = true;
            this.SaveAsJavaProgramBtn.Click += new System.EventHandler(this.SaveAsJavaProgramBtn_Click);
            // 
            // NewJavaProgramBtn
            // 
            this.NewJavaProgramBtn.Location = new System.Drawing.Point(12, 395);
            this.NewJavaProgramBtn.Name = "NewJavaProgramBtn";
            this.NewJavaProgramBtn.Size = new System.Drawing.Size(75, 23);
            this.NewJavaProgramBtn.TabIndex = 67;
            this.NewJavaProgramBtn.Text = "New";
            this.NewJavaProgramBtn.UseVisualStyleBackColor = true;
            this.NewJavaProgramBtn.Click += new System.EventHandler(this.NewJavaProgramBtn_Click);
            // 
            // LoadJavaProgramBtn
            // 
            this.LoadJavaProgramBtn.Location = new System.Drawing.Point(93, 395);
            this.LoadJavaProgramBtn.Name = "LoadJavaProgramBtn";
            this.LoadJavaProgramBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadJavaProgramBtn.TabIndex = 66;
            this.LoadJavaProgramBtn.Text = "Load";
            this.LoadJavaProgramBtn.UseVisualStyleBackColor = true;
            this.LoadJavaProgramBtn.Click += new System.EventHandler(this.LoadJavaProgramBtn_Click);
            // 
            // SaveJavaProgramBtn
            // 
            this.SaveJavaProgramBtn.Location = new System.Drawing.Point(174, 395);
            this.SaveJavaProgramBtn.Name = "SaveJavaProgramBtn";
            this.SaveJavaProgramBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveJavaProgramBtn.TabIndex = 65;
            this.SaveJavaProgramBtn.Text = "Save";
            this.SaveJavaProgramBtn.UseVisualStyleBackColor = true;
            this.SaveJavaProgramBtn.Click += new System.EventHandler(this.SaveJavaProgramBtn_Click);
            // 
            // ReportingTab
            // 
            this.ReportingTab.Location = new System.Drawing.Point(4, 22);
            this.ReportingTab.Name = "ReportingTab";
            this.ReportingTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportingTab.Size = new System.Drawing.Size(1443, 892);
            this.ReportingTab.TabIndex = 1;
            this.ReportingTab.Text = "Reporting";
            this.ReportingTab.UseVisualStyleBackColor = true;
            // 
            // BrowserTab
            // 
            this.BrowserTab.Controls.Add(this.webControl1);
            this.BrowserTab.Location = new System.Drawing.Point(4, 22);
            this.BrowserTab.Name = "BrowserTab";
            this.BrowserTab.Size = new System.Drawing.Size(1443, 892);
            this.BrowserTab.TabIndex = 5;
            this.BrowserTab.Text = "Browser";
            this.BrowserTab.UseVisualStyleBackColor = true;
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Location = new System.Drawing.Point(3, 3);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(1437, 886);
            this.webControl1.TabIndex = 3;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.InputMsgFilter = null;
            this.webView1.ObjectForScripting = null;
            this.webView1.Title = null;
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.DevicesGrp);
            this.ConfigTab.Controls.Add(this.BarcodeGrp);
            this.ConfigTab.Controls.Add(this.ConfigGrp);
            this.ConfigTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(1443, 892);
            this.ConfigTab.TabIndex = 3;
            this.ConfigTab.Text = "Config";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // DevicesGrp
            // 
            this.DevicesGrp.Controls.Add(this.speedBtnsGrp);
            this.DevicesGrp.Controls.Add(this.SetStartupDevicesBtn);
            this.DevicesGrp.Controls.Add(this.groupBox10);
            this.DevicesGrp.Controls.Add(this.DevicesFilenameLbl);
            this.DevicesGrp.Controls.Add(this.DefaultDevicesBtn);
            this.DevicesGrp.Controls.Add(this.SaveDevicesBtn);
            this.DevicesGrp.Controls.Add(this.DisconnectAllDevicesBtn);
            this.DevicesGrp.Controls.Add(this.LoadDevicesBtn);
            this.DevicesGrp.Controls.Add(this.ConnectAllDevicesBtn);
            this.DevicesGrp.Controls.Add(this.SaveAsDevicesBtn);
            this.DevicesGrp.Controls.Add(this.DevicesGrid);
            this.DevicesGrp.Location = new System.Drawing.Point(7, 187);
            this.DevicesGrp.Name = "DevicesGrp";
            this.DevicesGrp.Size = new System.Drawing.Size(1430, 386);
            this.DevicesGrp.TabIndex = 70;
            this.DevicesGrp.TabStop = false;
            this.DevicesGrp.Text = "Devices";
            // 
            // speedBtnsGrp
            // 
            this.speedBtnsGrp.Controls.Add(this.SpeedSendBtn1);
            this.speedBtnsGrp.Location = new System.Drawing.Point(212, 321);
            this.speedBtnsGrp.Name = "speedBtnsGrp";
            this.speedBtnsGrp.Size = new System.Drawing.Size(1212, 50);
            this.speedBtnsGrp.TabIndex = 72;
            this.speedBtnsGrp.TabStop = false;
            this.speedBtnsGrp.Text = "Speed Send Buttons";
            // 
            // SpeedSendBtn1
            // 
            this.SpeedSendBtn1.Location = new System.Drawing.Point(6, 19);
            this.SpeedSendBtn1.Name = "SpeedSendBtn1";
            this.SpeedSendBtn1.Size = new System.Drawing.Size(75, 23);
            this.SpeedSendBtn1.TabIndex = 71;
            this.SpeedSendBtn1.Text = "Speed 1";
            this.SpeedSendBtn1.UseVisualStyleBackColor = true;
            this.SpeedSendBtn1.Click += new System.EventHandler(this.SpeedSendBtn1_Click);
            // 
            // SetStartupDevicesBtn
            // 
            this.SetStartupDevicesBtn.Location = new System.Drawing.Point(990, 50);
            this.SetStartupDevicesBtn.Name = "SetStartupDevicesBtn";
            this.SetStartupDevicesBtn.Size = new System.Drawing.Size(93, 23);
            this.SetStartupDevicesBtn.TabIndex = 70;
            this.SetStartupDevicesBtn.Text = "Set As Startup";
            this.SetStartupDevicesBtn.UseVisualStyleBackColor = true;
            this.SetStartupDevicesBtn.Click += new System.EventHandler(this.SetStartupDevicesBtn_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.CurrentReconnectBtn);
            this.groupBox10.Controls.Add(this.LaunchSetupBtn);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.ExitSetupBtn);
            this.groupBox10.Controls.Add(this.DelayMsTxt);
            this.groupBox10.Controls.Add(this.RestoreSetupBtn);
            this.groupBox10.Controls.Add(this.SendMultipleTxt);
            this.groupBox10.Controls.Add(this.MinimizeSetupBtn);
            this.groupBox10.Controls.Add(this.CurrentSendMessageMultipleBtn);
            this.groupBox10.Controls.Add(this.LaunchRuntimeBtn);
            this.groupBox10.Controls.Add(this.CurrentDisconnectBtn);
            this.groupBox10.Controls.Add(this.ExitRuntimeBtn);
            this.groupBox10.Controls.Add(this.MessageToSendTxt);
            this.groupBox10.Controls.Add(this.CurrentConnectBtn);
            this.groupBox10.Controls.Add(this.CurrentSendMessageBtn);
            this.groupBox10.Controls.Add(this.RestoreRuntimeBtn);
            this.groupBox10.Controls.Add(this.MinimizeRuntimeBtn);
            this.groupBox10.Location = new System.Drawing.Point(5, 15);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(201, 300);
            this.groupBox10.TabIndex = 69;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Act On Selected Row";
            // 
            // CurrentReconnectBtn
            // 
            this.CurrentReconnectBtn.Location = new System.Drawing.Point(16, 48);
            this.CurrentReconnectBtn.Name = "CurrentReconnectBtn";
            this.CurrentReconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.CurrentReconnectBtn.TabIndex = 73;
            this.CurrentReconnectBtn.Text = "Reconnect";
            this.CurrentReconnectBtn.UseVisualStyleBackColor = true;
            this.CurrentReconnectBtn.Click += new System.EventHandler(this.CurrentReconnectBtn_Click);
            // 
            // LaunchSetupBtn
            // 
            this.LaunchSetupBtn.Location = new System.Drawing.Point(79, 160);
            this.LaunchSetupBtn.Name = "LaunchSetupBtn";
            this.LaunchSetupBtn.Size = new System.Drawing.Size(59, 39);
            this.LaunchSetupBtn.TabIndex = 72;
            this.LaunchSetupBtn.Text = "Launch Setup";
            this.LaunchSetupBtn.UseVisualStyleBackColor = true;
            this.LaunchSetupBtn.Click += new System.EventHandler(this.LaunchSetupBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(153, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 38);
            this.label2.TabIndex = 34;
            this.label2.Text = "mS Spacing";
            // 
            // ExitSetupBtn
            // 
            this.ExitSetupBtn.Location = new System.Drawing.Point(79, 263);
            this.ExitSetupBtn.Name = "ExitSetupBtn";
            this.ExitSetupBtn.Size = new System.Drawing.Size(59, 23);
            this.ExitSetupBtn.TabIndex = 71;
            this.ExitSetupBtn.Text = "Exit";
            this.ExitSetupBtn.UseVisualStyleBackColor = true;
            this.ExitSetupBtn.Click += new System.EventHandler(this.ExitSetupBtn_Click);
            // 
            // DelayMsTxt
            // 
            this.DelayMsTxt.Location = new System.Drawing.Point(123, 124);
            this.DelayMsTxt.Name = "DelayMsTxt";
            this.DelayMsTxt.Size = new System.Drawing.Size(26, 20);
            this.DelayMsTxt.TabIndex = 33;
            this.DelayMsTxt.Text = "5";
            // 
            // RestoreSetupBtn
            // 
            this.RestoreSetupBtn.Location = new System.Drawing.Point(79, 234);
            this.RestoreSetupBtn.Name = "RestoreSetupBtn";
            this.RestoreSetupBtn.Size = new System.Drawing.Size(59, 23);
            this.RestoreSetupBtn.TabIndex = 69;
            this.RestoreSetupBtn.Text = "Restore";
            this.RestoreSetupBtn.UseVisualStyleBackColor = true;
            this.RestoreSetupBtn.Click += new System.EventHandler(this.RestoreSetupBtn_Click);
            // 
            // SendMultipleTxt
            // 
            this.SendMultipleTxt.Location = new System.Drawing.Point(91, 124);
            this.SendMultipleTxt.Name = "SendMultipleTxt";
            this.SendMultipleTxt.Size = new System.Drawing.Size(26, 20);
            this.SendMultipleTxt.TabIndex = 32;
            this.SendMultipleTxt.Text = "3";
            // 
            // MinimizeSetupBtn
            // 
            this.MinimizeSetupBtn.Location = new System.Drawing.Point(79, 205);
            this.MinimizeSetupBtn.Name = "MinimizeSetupBtn";
            this.MinimizeSetupBtn.Size = new System.Drawing.Size(59, 23);
            this.MinimizeSetupBtn.TabIndex = 70;
            this.MinimizeSetupBtn.Text = "Minimize";
            this.MinimizeSetupBtn.UseVisualStyleBackColor = true;
            this.MinimizeSetupBtn.Click += new System.EventHandler(this.MinimizeSetupBtn_Click);
            // 
            // CurrentSendMessageMultipleBtn
            // 
            this.CurrentSendMessageMultipleBtn.Location = new System.Drawing.Point(13, 121);
            this.CurrentSendMessageMultipleBtn.Name = "CurrentSendMessageMultipleBtn";
            this.CurrentSendMessageMultipleBtn.Size = new System.Drawing.Size(75, 23);
            this.CurrentSendMessageMultipleBtn.TabIndex = 31;
            this.CurrentSendMessageMultipleBtn.Text = "Send N";
            this.CurrentSendMessageMultipleBtn.UseVisualStyleBackColor = true;
            this.CurrentSendMessageMultipleBtn.Click += new System.EventHandler(this.CurrentSendMessageMultipleBtn_Click);
            // 
            // LaunchRuntimeBtn
            // 
            this.LaunchRuntimeBtn.Location = new System.Drawing.Point(14, 160);
            this.LaunchRuntimeBtn.Name = "LaunchRuntimeBtn";
            this.LaunchRuntimeBtn.Size = new System.Drawing.Size(59, 39);
            this.LaunchRuntimeBtn.TabIndex = 68;
            this.LaunchRuntimeBtn.Text = "Launch Runtime";
            this.LaunchRuntimeBtn.UseVisualStyleBackColor = true;
            this.LaunchRuntimeBtn.Click += new System.EventHandler(this.LaunchRuntimeBtn_Click);
            // 
            // CurrentDisconnectBtn
            // 
            this.CurrentDisconnectBtn.Location = new System.Drawing.Point(97, 19);
            this.CurrentDisconnectBtn.Name = "CurrentDisconnectBtn";
            this.CurrentDisconnectBtn.Size = new System.Drawing.Size(75, 23);
            this.CurrentDisconnectBtn.TabIndex = 30;
            this.CurrentDisconnectBtn.Text = "Disconnect";
            this.CurrentDisconnectBtn.UseVisualStyleBackColor = true;
            this.CurrentDisconnectBtn.Click += new System.EventHandler(this.CurrentDisconnectBtn_Click);
            // 
            // ExitRuntimeBtn
            // 
            this.ExitRuntimeBtn.Location = new System.Drawing.Point(14, 263);
            this.ExitRuntimeBtn.Name = "ExitRuntimeBtn";
            this.ExitRuntimeBtn.Size = new System.Drawing.Size(59, 23);
            this.ExitRuntimeBtn.TabIndex = 38;
            this.ExitRuntimeBtn.Text = "Exit";
            this.ExitRuntimeBtn.UseVisualStyleBackColor = true;
            this.ExitRuntimeBtn.Click += new System.EventHandler(this.ExitRuntimeBtn_Click);
            // 
            // CurrentConnectBtn
            // 
            this.CurrentConnectBtn.Location = new System.Drawing.Point(16, 19);
            this.CurrentConnectBtn.Name = "CurrentConnectBtn";
            this.CurrentConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.CurrentConnectBtn.TabIndex = 29;
            this.CurrentConnectBtn.Text = "Connect";
            this.CurrentConnectBtn.UseVisualStyleBackColor = true;
            this.CurrentConnectBtn.Click += new System.EventHandler(this.CurrentConnectBtn_Click);
            // 
            // RestoreRuntimeBtn
            // 
            this.RestoreRuntimeBtn.Location = new System.Drawing.Point(14, 234);
            this.RestoreRuntimeBtn.Name = "RestoreRuntimeBtn";
            this.RestoreRuntimeBtn.Size = new System.Drawing.Size(59, 23);
            this.RestoreRuntimeBtn.TabIndex = 36;
            this.RestoreRuntimeBtn.Text = "Restore";
            this.RestoreRuntimeBtn.UseVisualStyleBackColor = true;
            this.RestoreRuntimeBtn.Click += new System.EventHandler(this.RestoreRuntimeBtn_Click);
            // 
            // MinimizeRuntimeBtn
            // 
            this.MinimizeRuntimeBtn.Location = new System.Drawing.Point(14, 205);
            this.MinimizeRuntimeBtn.Name = "MinimizeRuntimeBtn";
            this.MinimizeRuntimeBtn.Size = new System.Drawing.Size(59, 23);
            this.MinimizeRuntimeBtn.TabIndex = 37;
            this.MinimizeRuntimeBtn.Text = "Minimize";
            this.MinimizeRuntimeBtn.UseVisualStyleBackColor = true;
            this.MinimizeRuntimeBtn.Click += new System.EventHandler(this.MinimizeRuntimeBtn_Click);
            // 
            // DevicesFilenameLbl
            // 
            this.DevicesFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DevicesFilenameLbl.Location = new System.Drawing.Point(212, 51);
            this.DevicesFilenameLbl.Name = "DevicesFilenameLbl";
            this.DevicesFilenameLbl.Size = new System.Drawing.Size(772, 23);
            this.DevicesFilenameLbl.TabIndex = 63;
            this.DevicesFilenameLbl.Text = "Untitled";
            // 
            // DefaultDevicesBtn
            // 
            this.DefaultDevicesBtn.Location = new System.Drawing.Point(212, 19);
            this.DefaultDevicesBtn.Name = "DefaultDevicesBtn";
            this.DefaultDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.DefaultDevicesBtn.TabIndex = 61;
            this.DefaultDevicesBtn.Text = "Default";
            this.DefaultDevicesBtn.UseVisualStyleBackColor = true;
            this.DefaultDevicesBtn.Click += new System.EventHandler(this.DefaultDevicesBtn_Click);
            // 
            // SaveDevicesBtn
            // 
            this.SaveDevicesBtn.Location = new System.Drawing.Point(374, 19);
            this.SaveDevicesBtn.Name = "SaveDevicesBtn";
            this.SaveDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveDevicesBtn.TabIndex = 59;
            this.SaveDevicesBtn.Text = "Save";
            this.SaveDevicesBtn.UseVisualStyleBackColor = true;
            this.SaveDevicesBtn.Click += new System.EventHandler(this.SaveDevicesBtn_Click);
            // 
            // DisconnectAllDevicesBtn
            // 
            this.DisconnectAllDevicesBtn.Location = new System.Drawing.Point(706, 19);
            this.DisconnectAllDevicesBtn.Name = "DisconnectAllDevicesBtn";
            this.DisconnectAllDevicesBtn.Size = new System.Drawing.Size(114, 23);
            this.DisconnectAllDevicesBtn.TabIndex = 67;
            this.DisconnectAllDevicesBtn.Text = "Disconnect All";
            this.DisconnectAllDevicesBtn.UseVisualStyleBackColor = true;
            this.DisconnectAllDevicesBtn.Click += new System.EventHandler(this.DisconnectAllDevicesBtn_Click);
            // 
            // LoadDevicesBtn
            // 
            this.LoadDevicesBtn.Location = new System.Drawing.Point(293, 19);
            this.LoadDevicesBtn.Name = "LoadDevicesBtn";
            this.LoadDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadDevicesBtn.TabIndex = 60;
            this.LoadDevicesBtn.Text = "Load";
            this.LoadDevicesBtn.UseVisualStyleBackColor = true;
            this.LoadDevicesBtn.Click += new System.EventHandler(this.LoadDevicesBtn_Click);
            // 
            // ConnectAllDevicesBtn
            // 
            this.ConnectAllDevicesBtn.Location = new System.Drawing.Point(607, 19);
            this.ConnectAllDevicesBtn.Name = "ConnectAllDevicesBtn";
            this.ConnectAllDevicesBtn.Size = new System.Drawing.Size(93, 23);
            this.ConnectAllDevicesBtn.TabIndex = 66;
            this.ConnectAllDevicesBtn.Text = "Connect All";
            this.ConnectAllDevicesBtn.UseVisualStyleBackColor = true;
            this.ConnectAllDevicesBtn.Click += new System.EventHandler(this.ConnectAllDevicesBtn_Click);
            // 
            // SaveAsDevicesBtn
            // 
            this.SaveAsDevicesBtn.Location = new System.Drawing.Point(455, 19);
            this.SaveAsDevicesBtn.Name = "SaveAsDevicesBtn";
            this.SaveAsDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveAsDevicesBtn.TabIndex = 64;
            this.SaveAsDevicesBtn.Text = "Save As...";
            this.SaveAsDevicesBtn.UseVisualStyleBackColor = true;
            this.SaveAsDevicesBtn.Click += new System.EventHandler(this.SaveAsDevicesBtn_Click);
            // 
            // DevicesGrid
            // 
            this.DevicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesGrid.Location = new System.Drawing.Point(212, 73);
            this.DevicesGrid.Name = "DevicesGrid";
            this.DevicesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DevicesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DevicesGrid.Size = new System.Drawing.Size(1212, 242);
            this.DevicesGrid.TabIndex = 58;
            this.DevicesGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DeviceGrid_CellBeginEdit);
            this.DevicesGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceGrid_RowEnter);
            this.DevicesGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DeviceGrid_UserDeletingRow);
            // 
            // ConfigGrp
            // 
            this.ConfigGrp.Controls.Add(this.ChangeStartupJavaScriptBtn);
            this.ConfigGrp.Controls.Add(this.StartupJavaScriptLbl);
            this.ConfigGrp.Controls.Add(this.label4);
            this.ConfigGrp.Controls.Add(this.UtcTimeChk);
            this.ConfigGrp.Controls.Add(this.AutoConnectOnLoadChk);
            this.ConfigGrp.Controls.Add(this.ChangeStartupDevicesBtn);
            this.ConfigGrp.Controls.Add(this.StartupDevicesLbl);
            this.ConfigGrp.Controls.Add(this.label3);
            this.ConfigGrp.Controls.Add(this.ChangeLEonardRootBtn);
            this.ConfigGrp.Controls.Add(this.LEonardRootLbl);
            this.ConfigGrp.Controls.Add(this.label1);
            this.ConfigGrp.Controls.Add(this.DefaultConfigBtn);
            this.ConfigGrp.Controls.Add(this.LoadConfigBtn);
            this.ConfigGrp.Controls.Add(this.SaveConfigBtn);
            this.ConfigGrp.Location = new System.Drawing.Point(6, 6);
            this.ConfigGrp.Name = "ConfigGrp";
            this.ConfigGrp.Size = new System.Drawing.Size(1431, 175);
            this.ConfigGrp.TabIndex = 62;
            this.ConfigGrp.TabStop = false;
            this.ConfigGrp.Text = "Config";
            // 
            // ChangeStartupJavaScriptBtn
            // 
            this.ChangeStartupJavaScriptBtn.Location = new System.Drawing.Point(507, 62);
            this.ChangeStartupJavaScriptBtn.Name = "ChangeStartupJavaScriptBtn";
            this.ChangeStartupJavaScriptBtn.Size = new System.Drawing.Size(24, 23);
            this.ChangeStartupJavaScriptBtn.TabIndex = 76;
            this.ChangeStartupJavaScriptBtn.Text = "...";
            this.ChangeStartupJavaScriptBtn.UseVisualStyleBackColor = true;
            this.ChangeStartupJavaScriptBtn.Click += new System.EventHandler(this.ChangeStartupJavaScriptBtn_Click);
            // 
            // StartupJavaScriptLbl
            // 
            this.StartupJavaScriptLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartupJavaScriptLbl.Location = new System.Drawing.Point(122, 62);
            this.StartupJavaScriptLbl.Name = "StartupJavaScriptLbl";
            this.StartupJavaScriptLbl.Size = new System.Drawing.Size(385, 23);
            this.StartupJavaScriptLbl.TabIndex = 75;
            this.StartupJavaScriptLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Startup Program File";
            // 
            // UtcTimeChk
            // 
            this.UtcTimeChk.AutoSize = true;
            this.UtcTimeChk.Location = new System.Drawing.Point(907, 17);
            this.UtcTimeChk.Name = "UtcTimeChk";
            this.UtcTimeChk.Size = new System.Drawing.Size(177, 17);
            this.UtcTimeChk.TabIndex = 73;
            this.UtcTimeChk.Text = "Use UTC Time in Time Stamps?";
            this.UtcTimeChk.UseVisualStyleBackColor = true;
            // 
            // AutoConnectOnLoadChk
            // 
            this.AutoConnectOnLoadChk.AutoSize = true;
            this.AutoConnectOnLoadChk.Location = new System.Drawing.Point(537, 45);
            this.AutoConnectOnLoadChk.Name = "AutoConnectOnLoadChk";
            this.AutoConnectOnLoadChk.Size = new System.Drawing.Size(170, 17);
            this.AutoConnectOnLoadChk.TabIndex = 72;
            this.AutoConnectOnLoadChk.Text = "Connect All Devices on Load?";
            this.AutoConnectOnLoadChk.UseVisualStyleBackColor = true;
            // 
            // ChangeStartupDevicesBtn
            // 
            this.ChangeStartupDevicesBtn.Location = new System.Drawing.Point(507, 40);
            this.ChangeStartupDevicesBtn.Name = "ChangeStartupDevicesBtn";
            this.ChangeStartupDevicesBtn.Size = new System.Drawing.Size(24, 23);
            this.ChangeStartupDevicesBtn.TabIndex = 70;
            this.ChangeStartupDevicesBtn.Text = "...";
            this.ChangeStartupDevicesBtn.UseVisualStyleBackColor = true;
            this.ChangeStartupDevicesBtn.Click += new System.EventHandler(this.ChangeStartupDevicesBtn_Click);
            // 
            // StartupDevicesLbl
            // 
            this.StartupDevicesLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartupDevicesLbl.Location = new System.Drawing.Point(122, 40);
            this.StartupDevicesLbl.Name = "StartupDevicesLbl";
            this.StartupDevicesLbl.Size = new System.Drawing.Size(385, 23);
            this.StartupDevicesLbl.TabIndex = 69;
            this.StartupDevicesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Startup Devices File";
            // 
            // ChangeLEonardRootBtn
            // 
            this.ChangeLEonardRootBtn.Location = new System.Drawing.Point(507, 19);
            this.ChangeLEonardRootBtn.Name = "ChangeLEonardRootBtn";
            this.ChangeLEonardRootBtn.Size = new System.Drawing.Size(24, 23);
            this.ChangeLEonardRootBtn.TabIndex = 67;
            this.ChangeLEonardRootBtn.Text = "...";
            this.ChangeLEonardRootBtn.UseVisualStyleBackColor = true;
            this.ChangeLEonardRootBtn.Click += new System.EventHandler(this.ChangeLEonardRootBtn_Click);
            // 
            // LEonardRootLbl
            // 
            this.LEonardRootLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LEonardRootLbl.Location = new System.Drawing.Point(122, 19);
            this.LEonardRootLbl.Name = "LEonardRootLbl";
            this.LEonardRootLbl.Size = new System.Drawing.Size(385, 23);
            this.LEonardRootLbl.TabIndex = 66;
            this.LEonardRootLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "LEonard Root";
            // 
            // DefaultConfigBtn
            // 
            this.DefaultConfigBtn.Location = new System.Drawing.Point(6, 146);
            this.DefaultConfigBtn.Name = "DefaultConfigBtn";
            this.DefaultConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.DefaultConfigBtn.TabIndex = 63;
            this.DefaultConfigBtn.Text = "Default";
            this.DefaultConfigBtn.UseVisualStyleBackColor = true;
            this.DefaultConfigBtn.Click += new System.EventHandler(this.DefaultConfigBtn_Click);
            // 
            // LoadConfigBtn
            // 
            this.LoadConfigBtn.Location = new System.Drawing.Point(87, 146);
            this.LoadConfigBtn.Name = "LoadConfigBtn";
            this.LoadConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadConfigBtn.TabIndex = 62;
            this.LoadConfigBtn.Text = "Load";
            this.LoadConfigBtn.UseVisualStyleBackColor = true;
            this.LoadConfigBtn.Click += new System.EventHandler(this.LoadConfigBtn_Click);
            // 
            // SaveConfigBtn
            // 
            this.SaveConfigBtn.Location = new System.Drawing.Point(168, 146);
            this.SaveConfigBtn.Name = "SaveConfigBtn";
            this.SaveConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveConfigBtn.TabIndex = 58;
            this.SaveConfigBtn.Text = "Save";
            this.SaveConfigBtn.UseVisualStyleBackColor = true;
            this.SaveConfigBtn.Click += new System.EventHandler(this.SaveConfigBtn_Click);
            // 
            // OlisConnectBtn
            // 
            this.OlisConnectBtn.Location = new System.Drawing.Point(19, 949);
            this.OlisConnectBtn.Name = "OlisConnectBtn";
            this.OlisConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.OlisConnectBtn.TabIndex = 4;
            this.OlisConnectBtn.Text = "Olis Connect";
            this.OlisConnectBtn.UseVisualStyleBackColor = true;
            this.OlisConnectBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(2313, 24);
            this.menuStrip.TabIndex = 63;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 975);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(2313, 22);
            this.statusStrip.TabIndex = 64;
            this.statusStrip.Text = "statusStrip";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // StartupTmr
            // 
            this.StartupTmr.Tick += new System.EventHandler(this.StartupTmr_Tick);
            // 
            // ChromeBtn
            // 
            this.ChromeBtn.Location = new System.Drawing.Point(100, 949);
            this.ChromeBtn.Name = "ChromeBtn";
            this.ChromeBtn.Size = new System.Drawing.Size(75, 23);
            this.ChromeBtn.TabIndex = 5;
            this.ChromeBtn.Text = "Chrome";
            this.ChromeBtn.UseVisualStyleBackColor = true;
            // 
            // ChromeUrlTxt
            // 
            this.ChromeUrlTxt.Location = new System.Drawing.Point(181, 949);
            this.ChromeUrlTxt.Name = "ChromeUrlTxt";
            this.ChromeUrlTxt.Size = new System.Drawing.Size(195, 20);
            this.ChromeUrlTxt.TabIndex = 65;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2313, 997);
            this.Controls.Add(this.ChromeUrlTxt);
            this.Controls.Add(this.ChromeBtn);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.OlisConnectBtn);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.PersonalityTabs);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Set During Load";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.BarcodeGrp.ResumeLayout(false);
            this.BarcodeGrp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.PersonalityTabs.ResumeLayout(false);
            this.ProgramTab.ResumeLayout(false);
            this.ProgramTab.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).EndInit();
            this.BrowserTab.ResumeLayout(false);
            this.ConfigTab.ResumeLayout(false);
            this.DevicesGrp.ResumeLayout(false);
            this.speedBtnsGrp.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrid)).EndInit();
            this.ConfigGrp.ResumeLayout(false);
            this.ConfigGrp.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer HeartbeatTmr;
        private System.Windows.Forms.RichTextBox AllLogRTB;
        private System.Windows.Forms.RichTextBox Aux1LogRTB;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Button CrawlerClearBtn;
        private System.Windows.Forms.Button RobotClearBtn;
        private System.Windows.Forms.Button VisionClearBtn;
        private System.Windows.Forms.RichTextBox Aux2LogRTB;
        private System.Windows.Forms.Button ErrorClearBtn;
        private System.Windows.Forms.RichTextBox ErrorLogRTB;
        private System.Windows.Forms.Timer CloseTmr;
        private System.Windows.Forms.GroupBox BarcodeGrp;
        private System.Windows.Forms.Button CurrentSendMessageBtn;
        private System.Windows.Forms.TextBox MessageToSendTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SerialClearBtn;
        private System.Windows.Forms.RichTextBox Aux3LogRTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button CommandClearBtn;
        private System.Windows.Forms.RichTextBox ControlLogRTB;
        private System.Windows.Forms.CheckBox BarcodeReaderThreadChk;
        private System.Windows.Forms.Button BcrEndBtn;
        private System.Windows.Forms.Button BcrtStartBtn;
        private System.Windows.Forms.Button BcrtDestroyBtn;
        private System.Windows.Forms.Button BcrtCreateBtn;
        private System.Windows.Forms.TabControl PersonalityTabs;
        private System.Windows.Forms.TabPage RuntimeTab;
        private System.Windows.Forms.TabPage ReportingTab;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView DevicesGrid;
        private System.Windows.Forms.Button SaveDevicesBtn;
        private System.Windows.Forms.Button LoadDevicesBtn;
        private System.Windows.Forms.Button DefaultDevicesBtn;
        private System.Windows.Forms.GroupBox ConfigGrp;
        private System.Windows.Forms.Button DefaultConfigBtn;
        private System.Windows.Forms.Button LoadConfigBtn;
        private System.Windows.Forms.Button SaveConfigBtn;
        private System.Windows.Forms.Label DevicesFilenameLbl;
        private System.Windows.Forms.Button ChangeLEonardRootBtn;
        private System.Windows.Forms.Label LEonardRootLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveAsDevicesBtn;
        private System.Windows.Forms.Button ChangeStartupDevicesBtn;
        private System.Windows.Forms.Label StartupDevicesLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox AutoConnectOnLoadChk;
        private System.Windows.Forms.Button DisconnectAllDevicesBtn;
        private System.Windows.Forms.Button ConnectAllDevicesBtn;
        private System.Windows.Forms.Timer StartupTmr;
        private System.Windows.Forms.CheckBox UtcTimeChk;
        private System.Windows.Forms.TabPage ProgramTab;
        private System.Windows.Forms.Button RunJavaProgramBtn;
        private System.Windows.Forms.Button SaveAsJavaProgramBtn;
        private System.Windows.Forms.Button NewJavaProgramBtn;
        private System.Windows.Forms.Button LoadJavaProgramBtn;
        private System.Windows.Forms.Button SaveJavaProgramBtn;
        private System.Windows.Forms.Button JavaScriptClearRTB;
        private System.Windows.Forms.RichTextBox JavaScriptConsoleRTB;
        private System.Windows.Forms.RichTextBox JavaScriptCodeRTB;
        private System.Windows.Forms.Label JavaScriptFilenameLbl;
        private System.Windows.Forms.Button ChangeStartupJavaScriptBtn;
        private System.Windows.Forms.Label StartupJavaScriptLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SetAutoloadFileBtn;
        private System.Windows.Forms.TextBox JavaCommandTxt;
        private System.Windows.Forms.Button ExecJavaBtn;
        private System.Windows.Forms.Button JavaVariablesRefreshBtn;
        private System.Windows.Forms.RichTextBox JavaScriptVariablesRTB;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button CurrentDisconnectBtn;
        private System.Windows.Forms.Button CurrentConnectBtn;
        private System.Windows.Forms.Button CurrentSendMessageMultipleBtn;
        private System.Windows.Forms.TextBox SendMultipleTxt;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.TextBox DelayMsTxt;
        private System.Windows.Forms.Button ExitRuntimeBtn;
        private System.Windows.Forms.Button MinimizeRuntimeBtn;
        private System.Windows.Forms.Button RestoreRuntimeBtn;
        private System.Windows.Forms.GroupBox DevicesGrp;
        private System.Windows.Forms.Button LaunchRuntimeBtn;
        private System.Windows.Forms.Button LaunchSetupBtn;
        private System.Windows.Forms.Button ExitSetupBtn;
        private System.Windows.Forms.Button RestoreSetupBtn;
        private System.Windows.Forms.Button MinimizeSetupBtn;
        private System.Windows.Forms.TabPage BrowserTab;
        private System.Windows.Forms.Button OlisConnectBtn;
        private EO.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
        private System.Windows.Forms.Button CurrentReconnectBtn;
        private System.Windows.Forms.Button LoadVariablesBtn;
        private System.Windows.Forms.Button SaveVariablesBtn;
        private System.Windows.Forms.Button ClearVariablesBtn;
        private System.Windows.Forms.DataGridView VariablesGrd;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button ReadVariableBtn;
        private System.Windows.Forms.TextBox WriteStringValueTxt;
        private System.Windows.Forms.Button WriteStringValueBtn;
        private System.Windows.Forms.TextBox VariableNameTxt;
        private System.Windows.Forms.Button SetStartupDevicesBtn;
        private System.Windows.Forms.Button SpeedSendBtn1;
        private System.Windows.Forms.GroupBox speedBtnsGrp;
        private System.Windows.Forms.Button ChromeBtn;
        private System.Windows.Forms.TextBox ChromeUrlTxt;
    }
}

