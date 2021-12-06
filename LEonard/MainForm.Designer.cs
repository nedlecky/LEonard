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
            this.StartTestClientBtn = new System.Windows.Forms.Button();
            this.SendMessageBtn = new System.Windows.Forms.Button();
            this.MessageToSendTxt = new System.Windows.Forms.TextBox();
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.Robot99Btn = new System.Windows.Forms.Button();
            this.Robot98Btn = new System.Windows.Forms.Button();
            this.Robot50Btn = new System.Windows.Forms.Button();
            this.Robot4Btn = new System.Windows.Forms.Button();
            this.Robot3Btn = new System.Windows.Forms.Button();
            this.Robot2Btn = new System.Windows.Forms.Button();
            this.Robot1Btn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.PersonalityTabs = new System.Windows.Forms.TabControl();
            this.RuntimeTab = new System.Windows.Forms.TabPage();
            this.ReportingTab = new System.Windows.Forms.TabPage();
            this.VariablesTab = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.WriteInt32VariableBtn = new System.Windows.Forms.Button();
            this.ReadVariableBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.WriteStringValueTxt = new System.Windows.Forms.Button();
            this.WriteInt32ValueTxt = new System.Windows.Forms.TextBox();
            this.VariableNameTxt = new System.Windows.Forms.TextBox();
            this.ClearVariablesBtn = new System.Windows.Forms.Button();
            this.DefaultVariablesBtn = new System.Windows.Forms.Button();
            this.VariablesGrd = new System.Windows.Forms.DataGridView();
            this.ConfigTab = new System.Windows.Forms.TabPage();
            this.DeviceControlGrp = new System.Windows.Forms.GroupBox();
            this.SaveAsDevicesBtn = new System.Windows.Forms.Button();
            this.DevicesFilenameLbl = new System.Windows.Forms.Label();
            this.ConfigGrp = new System.Windows.Forms.GroupBox();
            this.AutoStartChk = new System.Windows.Forms.CheckBox();
            this.AutoLoadChk = new System.Windows.Forms.CheckBox();
            this.ChangeStartupDevicesBtn = new System.Windows.Forms.Button();
            this.StartupDevicesLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeLEonardRootBtn = new System.Windows.Forms.Button();
            this.LEonardRootLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DefaultConfigBtn = new System.Windows.Forms.Button();
            this.LoadConfigBtn = new System.Windows.Forms.Button();
            this.SaveConfigBtn = new System.Windows.Forms.Button();
            this.DefaultDevicesBtn = new System.Windows.Forms.Button();
            this.LoadDevicesBtn = new System.Windows.Forms.Button();
            this.SaveDevicesBtn = new System.Windows.Forms.Button();
            this.DevicesGrid = new System.Windows.Forms.DataGridView();
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
            this.BarcodeGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.PersonalityTabs.SuspendLayout();
            this.VariablesTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).BeginInit();
            this.ConfigTab.SuspendLayout();
            this.DeviceControlGrp.SuspendLayout();
            this.ConfigGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrid)).BeginInit();
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
            this.AllCrawlRTB.Size = new System.Drawing.Size(426, 294);
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
            this.CrawlerClearBtn.Location = new System.Drawing.Point(362, 50);
            this.CrawlerClearBtn.Name = "CrawlerClearBtn";
            this.CrawlerClearBtn.Size = new System.Drawing.Size(50, 23);
            this.CrawlerClearBtn.TabIndex = 9;
            this.CrawlerClearBtn.Text = "Clear";
            this.CrawlerClearBtn.UseVisualStyleBackColor = true;
            this.CrawlerClearBtn.Click += new System.EventHandler(this.CrawlerClearBtn_Click);
            // 
            // RobotClearBtn
            // 
            this.RobotClearBtn.Location = new System.Drawing.Point(312, 16);
            this.RobotClearBtn.Name = "RobotClearBtn";
            this.RobotClearBtn.Size = new System.Drawing.Size(50, 23);
            this.RobotClearBtn.TabIndex = 11;
            this.RobotClearBtn.Text = "Clear";
            this.RobotClearBtn.UseVisualStyleBackColor = true;
            this.RobotClearBtn.Click += new System.EventHandler(this.RobotClearBtn_Click);
            // 
            // VisionClearBtn
            // 
            this.VisionClearBtn.Location = new System.Drawing.Point(312, 19);
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
            this.VisionCrawlRTB.Size = new System.Drawing.Size(376, 231);
            this.VisionCrawlRTB.TabIndex = 12;
            this.VisionCrawlRTB.Text = "";
            // 
            // ErrorClearBtn
            // 
            this.ErrorClearBtn.Location = new System.Drawing.Point(362, 19);
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
            this.ErrorCrawlRTB.Size = new System.Drawing.Size(426, 218);
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
            this.BarcodeGrp.Location = new System.Drawing.Point(1110, 541);
            this.BarcodeGrp.Name = "BarcodeGrp";
            this.BarcodeGrp.Size = new System.Drawing.Size(306, 252);
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
            // StartTestClientBtn
            // 
            this.StartTestClientBtn.Location = new System.Drawing.Point(254, 21);
            this.StartTestClientBtn.Name = "StartTestClientBtn";
            this.StartTestClientBtn.Size = new System.Drawing.Size(102, 23);
            this.StartTestClientBtn.TabIndex = 25;
            this.StartTestClientBtn.Text = "Start Test Client";
            this.StartTestClientBtn.UseVisualStyleBackColor = true;
            this.StartTestClientBtn.Click += new System.EventHandler(this.StartTestClientBtn_Click);
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(136, 58);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(75, 23);
            this.SendMessageBtn.TabIndex = 27;
            this.SendMessageBtn.Text = "Send";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            this.SendMessageBtn.Click += new System.EventHandler(this.SendMessageBtn_Click);
            // 
            // MessageToSendTxt
            // 
            this.MessageToSendTxt.Location = new System.Drawing.Point(6, 58);
            this.MessageToSendTxt.Name = "MessageToSendTxt";
            this.MessageToSendTxt.Size = new System.Drawing.Size(119, 20);
            this.MessageToSendTxt.TabIndex = 28;
            this.MessageToSendTxt.Text = "(1,0,0,0,0)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RobotClearBtn);
            this.groupBox1.Controls.Add(this.RobotCrawlRTB);
            this.groupBox1.Location = new System.Drawing.Point(1422, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 224);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot Messages";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BarcodeClearBtn);
            this.groupBox2.Controls.Add(this.BarcodeCrawlRTB);
            this.groupBox2.Location = new System.Drawing.Point(1422, 541);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 252);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Reader Messages";
            // 
            // BarcodeClearBtn
            // 
            this.BarcodeClearBtn.Location = new System.Drawing.Point(306, 22);
            this.BarcodeClearBtn.Name = "BarcodeClearBtn";
            this.BarcodeClearBtn.Size = new System.Drawing.Size(50, 23);
            this.BarcodeClearBtn.TabIndex = 11;
            this.BarcodeClearBtn.Text = "Clear";
            this.BarcodeClearBtn.UseVisualStyleBackColor = true;
            this.BarcodeClearBtn.Click += new System.EventHandler(this.BarcodeClearBtn_Click);
            // 
            // BarcodeCrawlRTB
            // 
            this.BarcodeCrawlRTB.Location = new System.Drawing.Point(6, 19);
            this.BarcodeCrawlRTB.Name = "BarcodeCrawlRTB";
            this.BarcodeCrawlRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.BarcodeCrawlRTB.Size = new System.Drawing.Size(370, 222);
            this.BarcodeCrawlRTB.TabIndex = 7;
            this.BarcodeCrawlRTB.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.VisionClearBtn);
            this.groupBox3.Controls.Add(this.VisionCrawlRTB);
            this.groupBox3.Location = new System.Drawing.Point(1422, 283);
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
            this.groupBox4.Size = new System.Drawing.Size(438, 348);
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
            this.groupBox5.Controls.Add(this.ErrorClearBtn);
            this.groupBox5.Controls.Add(this.ErrorCrawlRTB);
            this.groupBox5.Location = new System.Drawing.Point(12, 548);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(438, 241);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "All ERROR Messages";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.StartTestClientBtn);
            this.groupBox6.Controls.Add(this.CommandClearBtn);
            this.groupBox6.Controls.Add(this.CommandCrawlRTB);
            this.groupBox6.Location = new System.Drawing.Point(12, 381);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(438, 161);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Command Messages";
            // 
            // CommandClearBtn
            // 
            this.CommandClearBtn.Location = new System.Drawing.Point(362, 21);
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
            this.CommandCrawlRTB.Size = new System.Drawing.Size(426, 120);
            this.CommandCrawlRTB.TabIndex = 6;
            this.CommandCrawlRTB.Text = "";
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
            this.groupBox8.Location = new System.Drawing.Point(1110, 49);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(306, 224);
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
            this.groupBox9.Location = new System.Drawing.Point(1110, 283);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(306, 252);
            this.groupBox9.TabIndex = 60;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Vision Commands";
            // 
            // PersonalityTabs
            // 
            this.PersonalityTabs.Controls.Add(this.RuntimeTab);
            this.PersonalityTabs.Controls.Add(this.ReportingTab);
            this.PersonalityTabs.Controls.Add(this.VariablesTab);
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
            this.ReportingTab.Location = new System.Drawing.Point(4, 22);
            this.ReportingTab.Name = "ReportingTab";
            this.ReportingTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportingTab.Size = new System.Drawing.Size(634, 736);
            this.ReportingTab.TabIndex = 1;
            this.ReportingTab.Text = "Reporting";
            this.ReportingTab.UseVisualStyleBackColor = true;
            // 
            // VariablesTab
            // 
            this.VariablesTab.Controls.Add(this.groupBox7);
            this.VariablesTab.Controls.Add(this.ClearVariablesBtn);
            this.VariablesTab.Controls.Add(this.DefaultVariablesBtn);
            this.VariablesTab.Controls.Add(this.VariablesGrd);
            this.VariablesTab.Location = new System.Drawing.Point(4, 22);
            this.VariablesTab.Name = "VariablesTab";
            this.VariablesTab.Padding = new System.Windows.Forms.Padding(3);
            this.VariablesTab.Size = new System.Drawing.Size(634, 736);
            this.VariablesTab.TabIndex = 2;
            this.VariablesTab.Text = "Variables";
            this.VariablesTab.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.WriteInt32VariableBtn);
            this.groupBox7.Controls.Add(this.ReadVariableBtn);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.WriteStringValueTxt);
            this.groupBox7.Controls.Add(this.WriteInt32ValueTxt);
            this.groupBox7.Controls.Add(this.VariableNameTxt);
            this.groupBox7.Location = new System.Drawing.Point(143, 586);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(339, 136);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Manual";
            // 
            // WriteInt32VariableBtn
            // 
            this.WriteInt32VariableBtn.Location = new System.Drawing.Point(130, 62);
            this.WriteInt32VariableBtn.Name = "WriteInt32VariableBtn";
            this.WriteInt32VariableBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteInt32VariableBtn.TabIndex = 3;
            this.WriteInt32VariableBtn.Text = "Write Int32";
            this.WriteInt32VariableBtn.UseVisualStyleBackColor = true;
            this.WriteInt32VariableBtn.Click += new System.EventHandler(this.WriteInt32VariableBtn_Click);
            // 
            // ReadVariableBtn
            // 
            this.ReadVariableBtn.Location = new System.Drawing.Point(130, 33);
            this.ReadVariableBtn.Name = "ReadVariableBtn";
            this.ReadVariableBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadVariableBtn.TabIndex = 2;
            this.ReadVariableBtn.Text = "Read";
            this.ReadVariableBtn.UseVisualStyleBackColor = true;
            this.ReadVariableBtn.Click += new System.EventHandler(this.ReadVariableBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(211, 93);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Test String";
            // 
            // WriteStringValueTxt
            // 
            this.WriteStringValueTxt.Location = new System.Drawing.Point(130, 91);
            this.WriteStringValueTxt.Name = "WriteStringValueTxt";
            this.WriteStringValueTxt.Size = new System.Drawing.Size(75, 23);
            this.WriteStringValueTxt.TabIndex = 4;
            this.WriteStringValueTxt.Text = "Write String";
            this.WriteStringValueTxt.UseVisualStyleBackColor = true;
            this.WriteStringValueTxt.Click += new System.EventHandler(this.WriteStringValueTxt_Click);
            // 
            // WriteInt32ValueTxt
            // 
            this.WriteInt32ValueTxt.Location = new System.Drawing.Point(211, 62);
            this.WriteInt32ValueTxt.Name = "WriteInt32ValueTxt";
            this.WriteInt32ValueTxt.Size = new System.Drawing.Size(100, 20);
            this.WriteInt32ValueTxt.TabIndex = 6;
            this.WriteInt32ValueTxt.Text = "123";
            // 
            // VariableNameTxt
            // 
            this.VariableNameTxt.Location = new System.Drawing.Point(24, 35);
            this.VariableNameTxt.Name = "VariableNameTxt";
            this.VariableNameTxt.Size = new System.Drawing.Size(100, 20);
            this.VariableNameTxt.TabIndex = 5;
            this.VariableNameTxt.Text = "X";
            // 
            // ClearVariablesBtn
            // 
            this.ClearVariablesBtn.Location = new System.Drawing.Point(14, 663);
            this.ClearVariablesBtn.Name = "ClearVariablesBtn";
            this.ClearVariablesBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearVariablesBtn.TabIndex = 8;
            this.ClearVariablesBtn.Text = "Clear";
            this.ClearVariablesBtn.UseVisualStyleBackColor = true;
            this.ClearVariablesBtn.Click += new System.EventHandler(this.ClearVariablesBtn_Click);
            // 
            // DefaultVariablesBtn
            // 
            this.DefaultVariablesBtn.Location = new System.Drawing.Point(14, 692);
            this.DefaultVariablesBtn.Name = "DefaultVariablesBtn";
            this.DefaultVariablesBtn.Size = new System.Drawing.Size(75, 23);
            this.DefaultVariablesBtn.TabIndex = 1;
            this.DefaultVariablesBtn.Text = "Default";
            this.DefaultVariablesBtn.UseVisualStyleBackColor = true;
            this.DefaultVariablesBtn.Click += new System.EventHandler(this.DefaultVariablesBtn_Click);
            // 
            // VariablesGrd
            // 
            this.VariablesGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariablesGrd.Location = new System.Drawing.Point(6, 6);
            this.VariablesGrd.Name = "VariablesGrd";
            this.VariablesGrd.Size = new System.Drawing.Size(622, 574);
            this.VariablesGrd.TabIndex = 0;
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.DeviceControlGrp);
            this.ConfigTab.Controls.Add(this.SaveAsDevicesBtn);
            this.ConfigTab.Controls.Add(this.DevicesFilenameLbl);
            this.ConfigTab.Controls.Add(this.ConfigGrp);
            this.ConfigTab.Controls.Add(this.DefaultDevicesBtn);
            this.ConfigTab.Controls.Add(this.LoadDevicesBtn);
            this.ConfigTab.Controls.Add(this.SaveDevicesBtn);
            this.ConfigTab.Controls.Add(this.DevicesGrid);
            this.ConfigTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(634, 736);
            this.ConfigTab.TabIndex = 3;
            this.ConfigTab.Text = "Config";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // DeviceControlGrp
            // 
            this.DeviceControlGrp.Controls.Add(this.MessageToSendTxt);
            this.DeviceControlGrp.Controls.Add(this.SendMessageBtn);
            this.DeviceControlGrp.Location = new System.Drawing.Point(8, 528);
            this.DeviceControlGrp.Name = "DeviceControlGrp";
            this.DeviceControlGrp.Size = new System.Drawing.Size(620, 181);
            this.DeviceControlGrp.TabIndex = 65;
            this.DeviceControlGrp.TabStop = false;
            // 
            // SaveAsDevicesBtn
            // 
            this.SaveAsDevicesBtn.Enabled = false;
            this.SaveAsDevicesBtn.Location = new System.Drawing.Point(251, 470);
            this.SaveAsDevicesBtn.Name = "SaveAsDevicesBtn";
            this.SaveAsDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveAsDevicesBtn.TabIndex = 64;
            this.SaveAsDevicesBtn.Text = "Save As...";
            this.SaveAsDevicesBtn.UseVisualStyleBackColor = true;
            this.SaveAsDevicesBtn.Click += new System.EventHandler(this.SaveAsDevicesBtn_Click);
            // 
            // DevicesFilenameLbl
            // 
            this.DevicesFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DevicesFilenameLbl.Location = new System.Drawing.Point(6, 196);
            this.DevicesFilenameLbl.Name = "DevicesFilenameLbl";
            this.DevicesFilenameLbl.Size = new System.Drawing.Size(622, 23);
            this.DevicesFilenameLbl.TabIndex = 63;
            this.DevicesFilenameLbl.Text = "Untitled";
            // 
            // ConfigGrp
            // 
            this.ConfigGrp.Controls.Add(this.AutoStartChk);
            this.ConfigGrp.Controls.Add(this.AutoLoadChk);
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
            this.ConfigGrp.Size = new System.Drawing.Size(622, 175);
            this.ConfigGrp.TabIndex = 62;
            this.ConfigGrp.TabStop = false;
            this.ConfigGrp.Text = "Config";
            // 
            // AutoStartChk
            // 
            this.AutoStartChk.AutoSize = true;
            this.AutoStartChk.Location = new System.Drawing.Point(265, 73);
            this.AutoStartChk.Name = "AutoStartChk";
            this.AutoStartChk.Size = new System.Drawing.Size(177, 17);
            this.AutoStartChk.TabIndex = 72;
            this.AutoStartChk.Text = "Auto Start All Devices on Load?";
            this.AutoStartChk.UseVisualStyleBackColor = true;
            this.AutoStartChk.CheckedChanged += new System.EventHandler(this.AutoStartChk_CheckedChanged);
            // 
            // AutoLoadChk
            // 
            this.AutoLoadChk.AutoSize = true;
            this.AutoLoadChk.Location = new System.Drawing.Point(138, 74);
            this.AutoLoadChk.Name = "AutoLoadChk";
            this.AutoLoadChk.Size = new System.Drawing.Size(121, 17);
            this.AutoLoadChk.TabIndex = 71;
            this.AutoLoadChk.Text = "Auto Load on Start?";
            this.AutoLoadChk.UseVisualStyleBackColor = true;
            this.AutoLoadChk.CheckedChanged += new System.EventHandler(this.AutoLoadChk_CheckedChanged);
            // 
            // ChangeStartupDevicesBtn
            // 
            this.ChangeStartupDevicesBtn.Location = new System.Drawing.Point(504, 42);
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
            this.StartupDevicesLbl.Location = new System.Drawing.Point(122, 42);
            this.StartupDevicesLbl.Name = "StartupDevicesLbl";
            this.StartupDevicesLbl.Size = new System.Drawing.Size(385, 23);
            this.StartupDevicesLbl.TabIndex = 69;
            this.StartupDevicesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Startup Devices File";
            // 
            // ChangeLEonardRootBtn
            // 
            this.ChangeLEonardRootBtn.Location = new System.Drawing.Point(504, 17);
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
            this.label1.Location = new System.Drawing.Point(43, 22);
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
            // DefaultDevicesBtn
            // 
            this.DefaultDevicesBtn.Location = new System.Drawing.Point(8, 470);
            this.DefaultDevicesBtn.Name = "DefaultDevicesBtn";
            this.DefaultDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.DefaultDevicesBtn.TabIndex = 61;
            this.DefaultDevicesBtn.Text = "Default";
            this.DefaultDevicesBtn.UseVisualStyleBackColor = true;
            this.DefaultDevicesBtn.Click += new System.EventHandler(this.DefaultDevicesBtn_Click);
            // 
            // LoadDevicesBtn
            // 
            this.LoadDevicesBtn.Location = new System.Drawing.Point(89, 470);
            this.LoadDevicesBtn.Name = "LoadDevicesBtn";
            this.LoadDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadDevicesBtn.TabIndex = 60;
            this.LoadDevicesBtn.Text = "Load";
            this.LoadDevicesBtn.UseVisualStyleBackColor = true;
            this.LoadDevicesBtn.Click += new System.EventHandler(this.LoadDevicesBtn_Click);
            // 
            // SaveDevicesBtn
            // 
            this.SaveDevicesBtn.Enabled = false;
            this.SaveDevicesBtn.Location = new System.Drawing.Point(170, 470);
            this.SaveDevicesBtn.Name = "SaveDevicesBtn";
            this.SaveDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveDevicesBtn.TabIndex = 59;
            this.SaveDevicesBtn.Text = "Save";
            this.SaveDevicesBtn.UseVisualStyleBackColor = true;
            this.SaveDevicesBtn.Click += new System.EventHandler(this.SaveDevicesBtn_Click);
            // 
            // DevicesGrid
            // 
            this.DevicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesGrid.Location = new System.Drawing.Point(8, 222);
            this.DevicesGrid.Name = "DevicesGrid";
            this.DevicesGrid.Size = new System.Drawing.Size(620, 242);
            this.DevicesGrid.TabIndex = 58;
            this.DevicesGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DeviceGrid_CellBeginEdit);
            this.DevicesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceGrid_CellContentClick);
            this.DevicesGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceGrid_CellValueChanged);
            this.DevicesGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceGrid_RowEnter);
            this.DevicesGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DeviceGrid_UserDeletingRow);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1818, 24);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 801);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1818, 22);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1818, 823);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BarcodeGrp);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.PersonalityTabs);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
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
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.PersonalityTabs.ResumeLayout(false);
            this.VariablesTab.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).EndInit();
            this.ConfigTab.ResumeLayout(false);
            this.DeviceControlGrp.ResumeLayout(false);
            this.DeviceControlGrp.PerformLayout();
            this.ConfigGrp.ResumeLayout(false);
            this.ConfigGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrid)).EndInit();
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
        private System.Windows.Forms.Button StartTestClientBtn;
        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.TextBox MessageToSendTxt;
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
        private System.Windows.Forms.TabControl PersonalityTabs;
        private System.Windows.Forms.TabPage RuntimeTab;
        private System.Windows.Forms.TabPage ReportingTab;
        private System.Windows.Forms.TabPage VariablesTab;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBox1;
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
        private System.Windows.Forms.CheckBox AutoStartChk;
        private System.Windows.Forms.CheckBox AutoLoadChk;
        private System.Windows.Forms.GroupBox DeviceControlGrp;
        private System.Windows.Forms.Button DefaultVariablesBtn;
        private System.Windows.Forms.DataGridView VariablesGrd;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox WriteInt32ValueTxt;
        private System.Windows.Forms.TextBox VariableNameTxt;
        private System.Windows.Forms.Button WriteStringValueTxt;
        private System.Windows.Forms.Button WriteInt32VariableBtn;
        private System.Windows.Forms.Button ReadVariableBtn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button ClearVariablesBtn;
    }
}

