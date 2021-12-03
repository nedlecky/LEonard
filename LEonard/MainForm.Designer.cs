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
            this.BcrEndBtn = new System.Windows.Forms.Button();
            this.BcrtStartBtn = new System.Windows.Forms.Button();
            this.BcrtDestroyBtn = new System.Windows.Forms.Button();
            this.BcrtCreateBtn = new System.Windows.Forms.Button();
            this.BarcodeReaderThreadChk = new System.Windows.Forms.CheckBox();
            this.DM2DataLbl = new System.Windows.Forms.Label();
            this.DM1DataLbl = new System.Windows.Forms.Label();
            this.TriggerDM2Btn = new System.Windows.Forms.Button();
            this.TriggerDM1Btn = new System.Windows.Forms.Button();
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CommandClearBtn = new System.Windows.Forms.Button();
            this.CommandCrawlRTB = new System.Windows.Forms.RichTextBox();
            this.LogfileTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.Robot99Btn = new System.Windows.Forms.Button();
            this.Robot98Btn = new System.Windows.Forms.Button();
            this.Robot50Btn = new System.Windows.Forms.Button();
            this.Robot4Btn = new System.Windows.Forms.Button();
            this.Robot3Btn = new System.Windows.Forms.Button();
            this.Robot2Btn = new System.Windows.Forms.Button();
            this.Robot1Btn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.VisionClientCommandTxt = new System.Windows.Forms.TextBox();
            this.VisionClientSendBtn = new System.Windows.Forms.Button();
            this.VisionClientChk = new System.Windows.Forms.CheckBox();
            this.PersonalityTabs = new System.Windows.Forms.TabControl();
            this.RuntimeTab = new System.Windows.Forms.TabPage();
            this.ReportingTab = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IoTab = new System.Windows.Forms.TabPage();
            this.StaticDevicesTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConfigTab = new System.Windows.Forms.TabPage();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BarcodeGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.PersonalityTabs.SuspendLayout();
            this.ReportingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.IoTab.SuspendLayout();
            this.StaticDevicesTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeartbeatTmr
            // 
            this.HeartbeatTmr.Tick += new System.EventHandler(this.HeartbeatTmr_Tick);
            // 
            // AllCrawlRTB
            // 
            this.AllCrawlRTB.Location = new System.Drawing.Point(6, 48);
            this.AllCrawlRTB.Name = "AllCrawlRTB";
            this.AllCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AllCrawlRTB.Size = new System.Drawing.Size(426, 345);
            this.AllCrawlRTB.TabIndex = 6;
            this.AllCrawlRTB.Text = "";
            // 
            // RobotCrawlRTB
            // 
            this.RobotCrawlRTB.Location = new System.Drawing.Point(6, 15);
            this.RobotCrawlRTB.Name = "RobotCrawlRTB";
            this.RobotCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RobotCrawlRTB.Size = new System.Drawing.Size(376, 198);
            this.RobotCrawlRTB.TabIndex = 7;
            this.RobotCrawlRTB.Text = "";
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // CrawlerClearBtn
            // 
            this.CrawlerClearBtn.Location = new System.Drawing.Point(6, 399);
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
            this.VisionCrawlRTB.Size = new System.Drawing.Size(376, 198);
            this.VisionCrawlRTB.TabIndex = 12;
            this.VisionCrawlRTB.Text = "";
            // 
            // ErrorClearBtn
            // 
            this.ErrorClearBtn.Location = new System.Drawing.Point(6, 211);
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
            this.ErrorCrawlRTB.Size = new System.Drawing.Size(420, 189);
            this.ErrorCrawlRTB.TabIndex = 15;
            this.ErrorCrawlRTB.Text = "";
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
            this.BarcodeGrp.Controls.Add(this.DM2DataLbl);
            this.BarcodeGrp.Controls.Add(this.DM1DataLbl);
            this.BarcodeGrp.Controls.Add(this.TriggerDM2Btn);
            this.BarcodeGrp.Controls.Add(this.TriggerDM1Btn);
            this.BarcodeGrp.Location = new System.Drawing.Point(6, 6);
            this.BarcodeGrp.Name = "BarcodeGrp";
            this.BarcodeGrp.Size = new System.Drawing.Size(306, 217);
            this.BarcodeGrp.TabIndex = 22;
            this.BarcodeGrp.TabStop = false;
            this.BarcodeGrp.Text = "Barcode Reader Commands";
            // 
            // BcrEndBtn
            // 
            this.BcrEndBtn.Location = new System.Drawing.Point(103, 123);
            this.BcrEndBtn.Name = "BcrEndBtn";
            this.BcrEndBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrEndBtn.TabIndex = 30;
            this.BcrEndBtn.Text = "End";
            this.BcrEndBtn.UseVisualStyleBackColor = true;
            this.BcrEndBtn.Click += new System.EventHandler(this.BcrtEndBtn_Click);
            // 
            // BcrtStartBtn
            // 
            this.BcrtStartBtn.Location = new System.Drawing.Point(22, 123);
            this.BcrtStartBtn.Name = "BcrtStartBtn";
            this.BcrtStartBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrtStartBtn.TabIndex = 29;
            this.BcrtStartBtn.Text = "Start";
            this.BcrtStartBtn.UseVisualStyleBackColor = true;
            this.BcrtStartBtn.Click += new System.EventHandler(this.BcrtStartBtn_Click);
            // 
            // BcrtDestroyBtn
            // 
            this.BcrtDestroyBtn.Location = new System.Drawing.Point(103, 94);
            this.BcrtDestroyBtn.Name = "BcrtDestroyBtn";
            this.BcrtDestroyBtn.Size = new System.Drawing.Size(75, 23);
            this.BcrtDestroyBtn.TabIndex = 28;
            this.BcrtDestroyBtn.Text = "Destroy";
            this.BcrtDestroyBtn.UseVisualStyleBackColor = true;
            this.BcrtDestroyBtn.Click += new System.EventHandler(this.BcrtDestroyBtn_Click);
            // 
            // BcrtCreateBtn
            // 
            this.BcrtCreateBtn.Location = new System.Drawing.Point(22, 94);
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
            this.BarcodeReaderThreadChk.Location = new System.Drawing.Point(22, 152);
            this.BarcodeReaderThreadChk.Name = "BarcodeReaderThreadChk";
            this.BarcodeReaderThreadChk.Size = new System.Drawing.Size(177, 17);
            this.BarcodeReaderThreadChk.TabIndex = 26;
            this.BarcodeReaderThreadChk.Text = "BarcodeReaderThread Enabled";
            this.BarcodeReaderThreadChk.UseVisualStyleBackColor = true;
            this.BarcodeReaderThreadChk.CheckedChanged += new System.EventHandler(this.BarcodeReaderThreadChk_CheckedChanged);
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
            // CommandServerChk
            // 
            this.CommandServerChk.AutoSize = true;
            this.CommandServerChk.Location = new System.Drawing.Point(6, 21);
            this.CommandServerChk.Name = "CommandServerChk";
            this.CommandServerChk.Size = new System.Drawing.Size(107, 17);
            this.CommandServerChk.TabIndex = 24;
            this.CommandServerChk.Text = "Command Server";
            this.CommandServerChk.UseVisualStyleBackColor = true;
            this.CommandServerChk.CheckedChanged += new System.EventHandler(this.CommandServerChk_CheckedChanged);
            // 
            // StartTestClientBtn
            // 
            this.StartTestClientBtn.Location = new System.Drawing.Point(119, 19);
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
            this.RobotServerChk.Location = new System.Drawing.Point(6, 19);
            this.RobotServerChk.Name = "RobotServerChk";
            this.RobotServerChk.Size = new System.Drawing.Size(89, 17);
            this.RobotServerChk.TabIndex = 26;
            this.RobotServerChk.Text = "Robot Server";
            this.RobotServerChk.UseVisualStyleBackColor = true;
            this.RobotServerChk.CheckedChanged += new System.EventHandler(this.RobotServerChk_CheckedChanged);
            // 
            // RobotSendBtn
            // 
            this.RobotSendBtn.Location = new System.Drawing.Point(138, 39);
            this.RobotSendBtn.Name = "RobotSendBtn";
            this.RobotSendBtn.Size = new System.Drawing.Size(75, 23);
            this.RobotSendBtn.TabIndex = 27;
            this.RobotSendBtn.Text = "Send";
            this.RobotSendBtn.UseVisualStyleBackColor = true;
            this.RobotSendBtn.Click += new System.EventHandler(this.RobotSendBtn_Click);
            // 
            // RobotCommandTxt
            // 
            this.RobotCommandTxt.Location = new System.Drawing.Point(13, 42);
            this.RobotCommandTxt.Name = "RobotCommandTxt";
            this.RobotCommandTxt.Size = new System.Drawing.Size(119, 20);
            this.RobotCommandTxt.TabIndex = 28;
            this.RobotCommandTxt.Text = "(1,0,0,0,0)";
            // 
            // VisionCommandTxt
            // 
            this.VisionCommandTxt.Location = new System.Drawing.Point(13, 42);
            this.VisionCommandTxt.Name = "VisionCommandTxt";
            this.VisionCommandTxt.Size = new System.Drawing.Size(119, 20);
            this.VisionCommandTxt.TabIndex = 31;
            this.VisionCommandTxt.Text = "test1";
            // 
            // VisionSendBtn
            // 
            this.VisionSendBtn.Location = new System.Drawing.Point(141, 40);
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
            this.VisionServerChk.Location = new System.Drawing.Point(6, 19);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 252);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot Messages";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BarcodeClearBtn);
            this.groupBox2.Controls.Add(this.BarcodeCrawlRTB);
            this.groupBox2.Location = new System.Drawing.Point(6, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 252);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Reader Messages";
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
            this.BarcodeCrawlRTB.Size = new System.Drawing.Size(386, 198);
            this.BarcodeCrawlRTB.TabIndex = 7;
            this.BarcodeCrawlRTB.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VisionCrawlRTB);
            this.groupBox3.Controls.Add(this.VisionClearBtn);
            this.groupBox3.Location = new System.Drawing.Point(6, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 252);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vision Messages";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkedListBox1);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.CrawlerClearBtn);
            this.groupBox4.Controls.Add(this.AllCrawlRTB);
            this.groupBox4.Location = new System.Drawing.Point(12, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 433);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "All Messages";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "ROBOT:",
            "VISION:",
            "BARCODE:",
            "ERROR:"});
            this.checkedListBox1.Location = new System.Drawing.Point(117, 8);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 34);
            this.checkedListBox1.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ErrorCrawlRTB);
            this.groupBox5.Controls.Add(this.ErrorClearBtn);
            this.groupBox5.Location = new System.Drawing.Point(12, 548);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(432, 241);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "All ERROR Messages";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CommandClearBtn);
            this.groupBox6.Controls.Add(this.CommandCrawlRTB);
            this.groupBox6.Location = new System.Drawing.Point(6, 113);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(602, 202);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Command Messages";
            // 
            // CommandClearBtn
            // 
            this.CommandClearBtn.Location = new System.Drawing.Point(6, 170);
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
            this.CommandCrawlRTB.Size = new System.Drawing.Size(420, 145);
            this.CommandCrawlRTB.TabIndex = 6;
            this.CommandCrawlRTB.Text = "";
            // 
            // LogfileTxt
            // 
            this.LogfileTxt.Location = new System.Drawing.Point(68, 44);
            this.LogfileTxt.Name = "LogfileTxt";
            this.LogfileTxt.Size = new System.Drawing.Size(237, 20);
            this.LogfileTxt.TabIndex = 57;
            this.LogfileTxt.Text = "C:/Users/nedlecky/Desktop/LEonard.log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Logfile";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.StartTestClientBtn);
            this.groupBox7.Controls.Add(this.CommandServerChk);
            this.groupBox7.Location = new System.Drawing.Point(6, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(204, 100);
            this.groupBox7.TabIndex = 58;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Command";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.Robot99Btn);
            this.groupBox8.Controls.Add(this.Robot98Btn);
            this.groupBox8.Controls.Add(this.Robot50Btn);
            this.groupBox8.Controls.Add(this.Robot4Btn);
            this.groupBox8.Controls.Add(this.Robot3Btn);
            this.groupBox8.Controls.Add(this.Robot2Btn);
            this.groupBox8.Controls.Add(this.Robot1Btn);
            this.groupBox8.Controls.Add(this.RobotSendBtn);
            this.groupBox8.Controls.Add(this.RobotServerChk);
            this.groupBox8.Controls.Add(this.RobotCommandTxt);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(281, 207);
            this.groupBox8.TabIndex = 59;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Robot Commands";
            // 
            // Robot99Btn
            // 
            this.Robot99Btn.Location = new System.Drawing.Point(117, 99);
            this.Robot99Btn.Name = "Robot99Btn";
            this.Robot99Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot99Btn.TabIndex = 35;
            this.Robot99Btn.Text = "CMD 99";
            this.Robot99Btn.UseVisualStyleBackColor = true;
            this.Robot99Btn.Click += new System.EventHandler(this.Robot99Btn_Click);
            // 
            // Robot98Btn
            // 
            this.Robot98Btn.Location = new System.Drawing.Point(117, 79);
            this.Robot98Btn.Name = "Robot98Btn";
            this.Robot98Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot98Btn.TabIndex = 34;
            this.Robot98Btn.Text = "CMD 98";
            this.Robot98Btn.UseVisualStyleBackColor = true;
            this.Robot98Btn.Click += new System.EventHandler(this.Robot98Btn_Click);
            // 
            // Robot50Btn
            // 
            this.Robot50Btn.Location = new System.Drawing.Point(13, 158);
            this.Robot50Btn.Name = "Robot50Btn";
            this.Robot50Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot50Btn.TabIndex = 33;
            this.Robot50Btn.Text = "CMD 50";
            this.Robot50Btn.UseVisualStyleBackColor = true;
            this.Robot50Btn.Click += new System.EventHandler(this.Robot50Btn_Click);
            // 
            // Robot4Btn
            // 
            this.Robot4Btn.Location = new System.Drawing.Point(13, 138);
            this.Robot4Btn.Name = "Robot4Btn";
            this.Robot4Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot4Btn.TabIndex = 32;
            this.Robot4Btn.Text = "CMD 4";
            this.Robot4Btn.UseVisualStyleBackColor = true;
            this.Robot4Btn.Click += new System.EventHandler(this.Robot4Btn_Click);
            // 
            // Robot3Btn
            // 
            this.Robot3Btn.Location = new System.Drawing.Point(13, 119);
            this.Robot3Btn.Name = "Robot3Btn";
            this.Robot3Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot3Btn.TabIndex = 31;
            this.Robot3Btn.Text = "CMD 3";
            this.Robot3Btn.UseVisualStyleBackColor = true;
            this.Robot3Btn.Click += new System.EventHandler(this.Robot3Btn_Click);
            // 
            // Robot2Btn
            // 
            this.Robot2Btn.Location = new System.Drawing.Point(13, 99);
            this.Robot2Btn.Name = "Robot2Btn";
            this.Robot2Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot2Btn.TabIndex = 30;
            this.Robot2Btn.Text = "CMD 2";
            this.Robot2Btn.UseVisualStyleBackColor = true;
            this.Robot2Btn.Click += new System.EventHandler(this.Robot2Btn_Click);
            // 
            // Robot1Btn
            // 
            this.Robot1Btn.Location = new System.Drawing.Point(13, 79);
            this.Robot1Btn.Name = "Robot1Btn";
            this.Robot1Btn.Size = new System.Drawing.Size(75, 23);
            this.Robot1Btn.TabIndex = 29;
            this.Robot1Btn.Text = "CMD 1";
            this.Robot1Btn.UseVisualStyleBackColor = true;
            this.Robot1Btn.Click += new System.EventHandler(this.Robot1Btn_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.VisionServerChk);
            this.groupBox9.Controls.Add(this.VisionCommandTxt);
            this.groupBox9.Controls.Add(this.VisionSendBtn);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(281, 213);
            this.groupBox9.TabIndex = 60;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Vision Commands";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.VisionClientCommandTxt);
            this.groupBox10.Controls.Add(this.VisionClientSendBtn);
            this.groupBox10.Controls.Add(this.VisionClientChk);
            this.groupBox10.Location = new System.Drawing.Point(6, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(246, 213);
            this.groupBox10.TabIndex = 61;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Vision Client";
            // 
            // VisionClientCommandTxt
            // 
            this.VisionClientCommandTxt.Location = new System.Drawing.Point(15, 43);
            this.VisionClientCommandTxt.Name = "VisionClientCommandTxt";
            this.VisionClientCommandTxt.Size = new System.Drawing.Size(119, 20);
            this.VisionClientCommandTxt.TabIndex = 33;
            this.VisionClientCommandTxt.Text = "test1";
            // 
            // VisionClientSendBtn
            // 
            this.VisionClientSendBtn.Location = new System.Drawing.Point(149, 43);
            this.VisionClientSendBtn.Name = "VisionClientSendBtn";
            this.VisionClientSendBtn.Size = new System.Drawing.Size(75, 23);
            this.VisionClientSendBtn.TabIndex = 32;
            this.VisionClientSendBtn.Text = "Send";
            this.VisionClientSendBtn.UseVisualStyleBackColor = true;
            this.VisionClientSendBtn.Click += new System.EventHandler(this.VisionClientSendBtn_Click);
            // 
            // VisionClientChk
            // 
            this.VisionClientChk.AutoSize = true;
            this.VisionClientChk.Location = new System.Drawing.Point(6, 20);
            this.VisionClientChk.Name = "VisionClientChk";
            this.VisionClientChk.Size = new System.Drawing.Size(83, 17);
            this.VisionClientChk.TabIndex = 30;
            this.VisionClientChk.Text = "Vision Client";
            this.VisionClientChk.UseVisualStyleBackColor = true;
            this.VisionClientChk.CheckedChanged += new System.EventHandler(this.VisionClientChk_CheckedChanged);
            // 
            // PersonalityTabs
            // 
            this.PersonalityTabs.Controls.Add(this.RuntimeTab);
            this.PersonalityTabs.Controls.Add(this.ReportingTab);
            this.PersonalityTabs.Controls.Add(this.IoTab);
            this.PersonalityTabs.Controls.Add(this.ConfigTab);
            this.PersonalityTabs.Location = new System.Drawing.Point(462, 27);
            this.PersonalityTabs.Name = "PersonalityTabs";
            this.PersonalityTabs.SelectedIndex = 0;
            this.PersonalityTabs.Size = new System.Drawing.Size(642, 762);
            this.PersonalityTabs.TabIndex = 62;
            // 
            // RuntimeTab
            // 
            this.RuntimeTab.Location = new System.Drawing.Point(4, 22);
            this.RuntimeTab.Name = "RuntimeTab";
            this.RuntimeTab.Padding = new System.Windows.Forms.Padding(3);
            this.RuntimeTab.Size = new System.Drawing.Size(634, 736);
            this.RuntimeTab.TabIndex = 0;
            this.RuntimeTab.Text = "Runtime";
            this.RuntimeTab.UseVisualStyleBackColor = true;
            // 
            // ReportingTab
            // 
            this.ReportingTab.Controls.Add(this.dataGridView3);
            this.ReportingTab.Controls.Add(this.dataGridView2);
            this.ReportingTab.Controls.Add(this.dataGridView1);
            this.ReportingTab.Location = new System.Drawing.Point(4, 22);
            this.ReportingTab.Name = "ReportingTab";
            this.ReportingTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportingTab.Size = new System.Drawing.Size(634, 736);
            this.ReportingTab.TabIndex = 1;
            this.ReportingTab.Text = "Reporting";
            this.ReportingTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(50, 484);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(558, 198);
            this.dataGridView3.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(50, 261);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(558, 198);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(558, 186);
            this.dataGridView1.TabIndex = 0;
            // 
            // IoTab
            // 
            this.IoTab.Controls.Add(this.StaticDevicesTab);
            this.IoTab.Controls.Add(this.menuStrip1);
            this.IoTab.Location = new System.Drawing.Point(4, 22);
            this.IoTab.Name = "IoTab";
            this.IoTab.Padding = new System.Windows.Forms.Padding(3);
            this.IoTab.Size = new System.Drawing.Size(634, 736);
            this.IoTab.TabIndex = 2;
            this.IoTab.Text = "I/O";
            this.IoTab.UseVisualStyleBackColor = true;
            // 
            // StaticDevicesTab
            // 
            this.StaticDevicesTab.Controls.Add(this.tabPage1);
            this.StaticDevicesTab.Controls.Add(this.tabPage2);
            this.StaticDevicesTab.Controls.Add(this.tabPage3);
            this.StaticDevicesTab.Controls.Add(this.tabPage4);
            this.StaticDevicesTab.Controls.Add(this.tabPage5);
            this.StaticDevicesTab.Location = new System.Drawing.Point(6, 6);
            this.StaticDevicesTab.Name = "StaticDevicesTab";
            this.StaticDevicesTab.SelectedIndex = 0;
            this.StaticDevicesTab.Size = new System.Drawing.Size(622, 511);
            this.StaticDevicesTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Command";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UR-5e Robot";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(614, 485);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sherlock Vision";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(614, 485);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HALCON Vision";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.BarcodeGrp);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(614, 485);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cognex Dataman";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.label3);
            this.ConfigTab.Controls.Add(this.LogfileTxt);
            this.ConfigTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(634, 736);
            this.ConfigTab.TabIndex = 3;
            this.ConfigTab.Text = "Config";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1104, 24);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 797);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1104, 22);
            this.statusStrip.TabIndex = 64;
            this.statusStrip.Text = "statusStrip";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 65;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 519);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 66;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 819);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.PersonalityTabs);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip1;
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
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.PersonalityTabs.ResumeLayout(false);
            this.ReportingTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.IoTab.ResumeLayout(false);
            this.IoTab.PerformLayout();
            this.StaticDevicesTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ConfigTab.ResumeLayout(false);
            this.ConfigTab.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TextBox LogfileTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button Robot4Btn;
        private System.Windows.Forms.Button Robot3Btn;
        private System.Windows.Forms.Button Robot2Btn;
        private System.Windows.Forms.Button Robot1Btn;
        private System.Windows.Forms.Button Robot99Btn;
        private System.Windows.Forms.Button Robot98Btn;
        private System.Windows.Forms.Button Robot50Btn;
        private System.Windows.Forms.CheckBox BarcodeReaderThreadChk;
        private System.Windows.Forms.Button BcrEndBtn;
        private System.Windows.Forms.Button BcrtStartBtn;
        private System.Windows.Forms.Button BcrtDestroyBtn;
        private System.Windows.Forms.Button BcrtCreateBtn;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox VisionClientChk;
        private System.Windows.Forms.TextBox VisionClientCommandTxt;
        private System.Windows.Forms.Button VisionClientSendBtn;
        private System.Windows.Forms.TabControl PersonalityTabs;
        private System.Windows.Forms.TabPage RuntimeTab;
        private System.Windows.Forms.TabPage ReportingTab;
        private System.Windows.Forms.TabPage IoTab;
        private System.Windows.Forms.TabControl StaticDevicesTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button2;
    }
}

