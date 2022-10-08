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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CurrentLineLbl = new System.Windows.Forms.Label();
            this.RecipeRTB = new System.Windows.Forms.RichTextBox();
            this.StepBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.RecipeFilenameLbl = new System.Windows.Forms.Label();
            this.SaveAsRecipeBtn = new System.Windows.Forms.Button();
            this.NewRecipeBtn = new System.Windows.Forms.Button();
            this.LoadRecipeBtn = new System.Windows.Forms.Button();
            this.SaveRecipeBtn = new System.Windows.Forms.Button();
            this.HeartbeatTmr = new System.Windows.Forms.Timer(this.components);
            this.TimeLbl = new System.Windows.Forms.Label();
            this.StartupTmr = new System.Windows.Forms.Timer(this.components);
            this.CloseTmr = new System.Windows.Forms.Timer(this.components);
            this.ExecTmr = new System.Windows.Forms.Timer(this.components);
            this.MessageTmr = new System.Windows.Forms.Timer(this.components);
            this.RobotCommandStatusLbl = new System.Windows.Forms.Label();
            this.GrindReadyLbl = new System.Windows.Forms.Label();
            this.RobotReadyLbl = new System.Windows.Forms.Label();
            this.GrindContactEnabledBtn = new System.Windows.Forms.Button();
            this.MonitorTab = new System.Windows.Forms.TabControl();
            this.positionsPage = new System.Windows.Forms.TabPage();
            this.PositionLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PositionMovePoseBtn = new System.Windows.Forms.Button();
            this.PositionsGrd = new System.Windows.Forms.DataGridView();
            this.ClearAllPositionsBtn = new System.Windows.Forms.Button();
            this.ClearPositionsBtn = new System.Windows.Forms.Button();
            this.SavePositionsBtn = new System.Windows.Forms.Button();
            this.LoadPositionsBtn = new System.Windows.Forms.Button();
            this.PositionMoveArmBtn = new System.Windows.Forms.Button();
            this.JogBtn = new System.Windows.Forms.Button();
            this.PositionSetBtn = new System.Windows.Forms.Button();
            this.variablesPage = new System.Windows.Forms.TabPage();
            this.VariablesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VariablesGrd = new System.Windows.Forms.DataGridView();
            this.ClearAllVariablesBtn = new System.Windows.Forms.Button();
            this.ClearVariablesBtn = new System.Windows.Forms.Button();
            this.SaveVariablesBtn = new System.Windows.Forms.Button();
            this.LoadVariablesBtn = new System.Windows.Forms.Button();
            this.javaEnginePage = new System.Windows.Forms.TabPage();
            this.JavaRunBtn = new System.Windows.Forms.Button();
            this.JavaScriptRTB = new System.Windows.Forms.RichTextBox();
            this.pythonEnginePage = new System.Windows.Forms.TabPage();
            this.manualPage = new System.Windows.Forms.TabPage();
            this.ManualLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RecipeCommandsRTB = new System.Windows.Forms.RichTextBox();
            this.FullManualBtn = new System.Windows.Forms.Button();
            this.revhistPage = new System.Windows.Forms.TabPage();
            this.RevHistRTB = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MountedToolBox = new System.Windows.Forms.ComboBox();
            this.UserModeBox = new System.Windows.Forms.ComboBox();
            this.RobotModeBtn = new System.Windows.Forms.Button();
            this.SafetyStatusBtn = new System.Windows.Forms.Button();
            this.ProgramStateBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DiameterDimLbl = new System.Windows.Forms.Label();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.RunPage = new System.Windows.Forms.TabPage();
            this.RunTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.StatusLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.RobotConnectBtn = new System.Windows.Forms.Button();
            this.GocatorConnectBtn = new System.Windows.Forms.Button();
            this.GocatorReadyLbl = new System.Windows.Forms.Label();
            this.CommandCounterLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RobotSentLbl = new System.Windows.Forms.Label();
            this.RobotCompletedLbl = new System.Windows.Forms.Label();
            this.GrindProcessStateLbl = new System.Windows.Forms.Label();
            this.RecipeRTBCopy = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.MoveToolMountBtn = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.MoveToolHomeBtn = new System.Windows.Forms.Button();
            this.GrindForceReportZLbl = new System.Windows.Forms.Label();
            this.RunStartedTimeLbl = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.RunElapsedTimeLbl = new System.Windows.Forms.Label();
            this.RunStateLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CurrentLineLblCopy = new System.Windows.Forms.Label();
            this.StepTimeRemainingLbl = new System.Windows.Forms.Label();
            this.GrindCycleLbl = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.GrindNCyclesLbl = new System.Windows.Forms.Label();
            this.StepTimeEstimateLbl = new System.Windows.Forms.Label();
            this.Grind = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.StepElapsedTimeLbl = new System.Windows.Forms.Label();
            this.ProgramPage = new System.Windows.Forms.TabPage();
            this.ProgramTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileBigEditPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BigEditBtn = new System.Windows.Forms.Button();
            this.SetupPage = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.RobotPolyscopeVersionLbl = new System.Windows.Forms.Label();
            this.RobotSerialNumberLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RobotModelLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DefaultMoveSetupGrp = new System.Windows.Forms.GroupBox();
            this.SetMoveDefaultsBtn = new System.Windows.Forms.Button();
            this.SetLinearAccelBtn = new System.Windows.Forms.Button();
            this.SetBlendRadiusBtn = new System.Windows.Forms.Button();
            this.SetJointSpeedBtn = new System.Windows.Forms.Button();
            this.SetJointAccelBtn = new System.Windows.Forms.Button();
            this.SetLinearSpeedBtn = new System.Windows.Forms.Button();
            this.GrindingMoveSetupGrp = new System.Windows.Forms.GroupBox();
            this.SetForceModeDampingBtn = new System.Windows.Forms.Button();
            this.SetForceModeGainScalingBtn = new System.Windows.Forms.Button();
            this.SetGrindJogAccelBtn = new System.Windows.Forms.Button();
            this.SetGrindJogSpeedBtn = new System.Windows.Forms.Button();
            this.SetPointFrequencyBtn = new System.Windows.Forms.Button();
            this.SetGrindDefaultsBtn = new System.Windows.Forms.Button();
            this.SetGrindAccelBtn = new System.Windows.Forms.Button();
            this.SetTrialSpeedBtn = new System.Windows.Forms.Button();
            this.SetMaxGrindBlendRadiusBtn = new System.Windows.Forms.Button();
            this.SetMaxWaitBtn = new System.Windows.Forms.Button();
            this.SetForceDwellBtn = new System.Windows.Forms.Button();
            this.SetTouchSpeedBtn = new System.Windows.Forms.Button();
            this.SetTouchRetractBtn = new System.Windows.Forms.Button();
            this.ToolSetupGrp = new System.Windows.Forms.GroupBox();
            this.CoolantOffBtn = new System.Windows.Forms.Button();
            this.CoolantTestBtn = new System.Windows.Forms.Button();
            this.ToolOffBtn = new System.Windows.Forms.Button();
            this.ToolTestBtn = new System.Windows.Forms.Button();
            this.DoorClosedInputLbl = new System.Windows.Forms.Label();
            this.FootswitchPressedInputLbl = new System.Windows.Forms.Label();
            this.FootswitchPressedInputTxt = new System.Windows.Forms.TextBox();
            this.SetFootswitchPressedInputBtn = new System.Windows.Forms.Button();
            this.JointMoveMountBtn = new System.Windows.Forms.Button();
            this.JointMoveHomeBtn = new System.Windows.Forms.Button();
            this.DoorClosedInputTxt = new System.Windows.Forms.TextBox();
            this.SetDoorClosedInputBtn = new System.Windows.Forms.Button();
            this.SelectToolBtn = new System.Windows.Forms.Button();
            this.ToolsGrd = new System.Windows.Forms.DataGridView();
            this.LoadToolsBtn = new System.Windows.Forms.Button();
            this.SaveToolsBtn = new System.Windows.Forms.Button();
            this.ClearToolsBtn = new System.Windows.Forms.Button();
            this.GeneralConfigGrp = new System.Windows.Forms.GroupBox();
            this.SaveConfigBtn = new System.Windows.Forms.Button();
            this.AllowRunningOfflineChk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RobotProgramTxt = new System.Windows.Forms.TextBox();
            this.LoadConfigBtn = new System.Windows.Forms.Button();
            this.DefaultConfigBtn = new System.Windows.Forms.Button();
            this.ServerIpTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RobotIpTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LEonardRootLbl = new System.Windows.Forms.Label();
            this.ChangeRootDirectoryBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LogLevelCombo = new System.Windows.Forms.ComboBox();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.ClearAllLogRtbBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.UrLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ExecLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ErrorLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.UrDashboardLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AllLogRTB = new System.Windows.Forms.RichTextBox();
            this.UiPage = new System.Windows.Forms.TabPage();
            this.UiDefaultBtn = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.UiFixedHeightTxt = new System.Windows.Forms.TextBox();
            this.UiFixedWidthTxt = new System.Windows.Forms.TextBox();
            this.UiFreeBtn = new System.Windows.Forms.Button();
            this.UiFixedBtn = new System.Windows.Forms.Button();
            this.JogRunBtn = new System.Windows.Forms.Button();
            this.DiameterLbl = new System.Windows.Forms.Label();
            this.PartGeometryBox = new System.Windows.Forms.ComboBox();
            this.DoorClosedLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.FootswitchPressedLbl = new System.Windows.Forms.Label();
            this.Time2Lbl = new System.Windows.Forms.Label();
            this.BottomButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DiamVersionLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TopButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MonitorTab.SuspendLayout();
            this.positionsPage.SuspendLayout();
            this.PositionLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionsGrd)).BeginInit();
            this.variablesPage.SuspendLayout();
            this.VariablesLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).BeginInit();
            this.javaEnginePage.SuspendLayout();
            this.manualPage.SuspendLayout();
            this.ManualLayoutPanel.SuspendLayout();
            this.revhistPage.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.RunPage.SuspendLayout();
            this.RunTabLayoutPanel.SuspendLayout();
            this.StatusLayoutPanel.SuspendLayout();
            this.CommandCounterLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ProgramPage.SuspendLayout();
            this.ProgramTableLayoutPanel.SuspendLayout();
            this.FileBigEditPanel.SuspendLayout();
            this.SetupPage.SuspendLayout();
            this.DefaultMoveSetupGrp.SuspendLayout();
            this.GrindingMoveSetupGrp.SuspendLayout();
            this.ToolSetupGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGrd)).BeginInit();
            this.GeneralConfigGrp.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.UiPage.SuspendLayout();
            this.BottomButtonLayoutPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.DiamVersionLayoutPanel.SuspendLayout();
            this.TopButtonLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentLineLbl
            // 
            this.CurrentLineLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentLineLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentLineLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLineLbl.Location = new System.Drawing.Point(3, 1028);
            this.CurrentLineLbl.Name = "CurrentLineLbl";
            this.CurrentLineLbl.Size = new System.Drawing.Size(814, 40);
            this.CurrentLineLbl.TabIndex = 79;
            this.CurrentLineLbl.TextChanged += new System.EventHandler(this.CurrentLineLbl_TextChanged);
            // 
            // RecipeRTB
            // 
            this.RecipeRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipeRTB.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipeRTB.Location = new System.Drawing.Point(2, 2);
            this.RecipeRTB.Margin = new System.Windows.Forms.Padding(2);
            this.RecipeRTB.Name = "RecipeRTB";
            this.RecipeRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RecipeRTB.Size = new System.Drawing.Size(816, 1024);
            this.RecipeRTB.TabIndex = 72;
            this.RecipeRTB.Text = "";
            this.RecipeRTB.VScroll += new System.EventHandler(this.RecipeRTB_VScroll);
            this.RecipeRTB.TextChanged += new System.EventHandler(this.RecipeRTB_TextChanged);
            // 
            // StepBtn
            // 
            this.StepBtn.BackColor = System.Drawing.Color.Gray;
            this.StepBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepBtn.Enabled = false;
            this.StepBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepBtn.ForeColor = System.Drawing.Color.White;
            this.StepBtn.Location = new System.Drawing.Point(215, 2);
            this.StepBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StepBtn.Name = "StepBtn";
            this.StepBtn.Size = new System.Drawing.Size(209, 135);
            this.StepBtn.TabIndex = 1;
            this.StepBtn.Text = "Step";
            this.StepBtn.UseVisualStyleBackColor = false;
            this.StepBtn.Click += new System.EventHandler(this.StepBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.Color.Gray;
            this.StopBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopBtn.Enabled = false;
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBtn.ForeColor = System.Drawing.Color.White;
            this.StopBtn.Location = new System.Drawing.Point(641, 2);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(209, 135);
            this.StopBtn.TabIndex = 3;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.Gray;
            this.PauseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseBtn.ForeColor = System.Drawing.Color.White;
            this.PauseBtn.Location = new System.Drawing.Point(428, 2);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(209, 135);
            this.PauseBtn.TabIndex = 2;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = false;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.Gray;
            this.StartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartBtn.Enabled = false;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.ForeColor = System.Drawing.Color.White;
            this.StartBtn.Location = new System.Drawing.Point(2, 2);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(209, 135);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // RecipeFilenameLbl
            // 
            this.RecipeFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecipeFilenameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipeFilenameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipeFilenameLbl.Location = new System.Drawing.Point(2, 0);
            this.RecipeFilenameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecipeFilenameLbl.Name = "RecipeFilenameLbl";
            this.RecipeFilenameLbl.Size = new System.Drawing.Size(610, 84);
            this.RecipeFilenameLbl.TabIndex = 77;
            this.RecipeFilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecipeFilenameLbl.TextChanged += new System.EventHandler(this.RecipeFilenameLbl_TextChanged);
            // 
            // SaveAsRecipeBtn
            // 
            this.SaveAsRecipeBtn.BackColor = System.Drawing.Color.Gray;
            this.SaveAsRecipeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsRecipeBtn.Enabled = false;
            this.SaveAsRecipeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsRecipeBtn.ForeColor = System.Drawing.Color.White;
            this.SaveAsRecipeBtn.Location = new System.Drawing.Point(715, 2);
            this.SaveAsRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveAsRecipeBtn.Name = "SaveAsRecipeBtn";
            this.SaveAsRecipeBtn.Size = new System.Drawing.Size(175, 94);
            this.SaveAsRecipeBtn.TabIndex = 4;
            this.SaveAsRecipeBtn.Text = "Save As...";
            this.SaveAsRecipeBtn.UseVisualStyleBackColor = false;
            this.SaveAsRecipeBtn.Click += new System.EventHandler(this.SaveAsRecipeBtn_Click);
            // 
            // NewRecipeBtn
            // 
            this.NewRecipeBtn.BackColor = System.Drawing.Color.Gray;
            this.NewRecipeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewRecipeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecipeBtn.ForeColor = System.Drawing.Color.White;
            this.NewRecipeBtn.Location = new System.Drawing.Point(357, 2);
            this.NewRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewRecipeBtn.Name = "NewRecipeBtn";
            this.NewRecipeBtn.Size = new System.Drawing.Size(175, 94);
            this.NewRecipeBtn.TabIndex = 2;
            this.NewRecipeBtn.Text = "New";
            this.NewRecipeBtn.UseVisualStyleBackColor = false;
            this.NewRecipeBtn.Click += new System.EventHandler(this.NewRecipeBtn_Click);
            // 
            // LoadRecipeBtn
            // 
            this.LoadRecipeBtn.BackColor = System.Drawing.Color.Gray;
            this.LoadRecipeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadRecipeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadRecipeBtn.ForeColor = System.Drawing.Color.White;
            this.LoadRecipeBtn.Location = new System.Drawing.Point(2, 2);
            this.LoadRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoadRecipeBtn.Name = "LoadRecipeBtn";
            this.LoadRecipeBtn.Size = new System.Drawing.Size(351, 94);
            this.LoadRecipeBtn.TabIndex = 1;
            this.LoadRecipeBtn.Text = "Untitled";
            this.LoadRecipeBtn.UseVisualStyleBackColor = false;
            this.LoadRecipeBtn.Click += new System.EventHandler(this.LoadRecipeBtn_Click);
            // 
            // SaveRecipeBtn
            // 
            this.SaveRecipeBtn.BackColor = System.Drawing.Color.Gray;
            this.SaveRecipeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveRecipeBtn.Enabled = false;
            this.SaveRecipeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveRecipeBtn.ForeColor = System.Drawing.Color.White;
            this.SaveRecipeBtn.Location = new System.Drawing.Point(536, 2);
            this.SaveRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveRecipeBtn.Name = "SaveRecipeBtn";
            this.SaveRecipeBtn.Size = new System.Drawing.Size(175, 94);
            this.SaveRecipeBtn.TabIndex = 3;
            this.SaveRecipeBtn.Text = "Save";
            this.SaveRecipeBtn.UseVisualStyleBackColor = false;
            this.SaveRecipeBtn.Click += new System.EventHandler(this.SaveRecipeBtn_Click);
            // 
            // HeartbeatTmr
            // 
            this.HeartbeatTmr.Tick += new System.EventHandler(this.HeartbeatTmr_Tick);
            // 
            // TimeLbl
            // 
            this.TimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLbl.Location = new System.Drawing.Point(452, 18);
            this.TimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(353, 52);
            this.TimeLbl.TabIndex = 5;
            this.TimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartupTmr
            // 
            this.StartupTmr.Tick += new System.EventHandler(this.StartupTmr_Tick);
            // 
            // CloseTmr
            // 
            this.CloseTmr.Tick += new System.EventHandler(this.CloseTmr_Tick);
            // 
            // ExecTmr
            // 
            this.ExecTmr.Tick += new System.EventHandler(this.ExecTmr_Tick);
            // 
            // MessageTmr
            // 
            this.MessageTmr.Tick += new System.EventHandler(this.MessageTmr_Tick);
            // 
            // RobotCommandStatusLbl
            // 
            this.RobotCommandStatusLbl.BackColor = System.Drawing.Color.Gray;
            this.RobotCommandStatusLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotCommandStatusLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotCommandStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotCommandStatusLbl.ForeColor = System.Drawing.Color.White;
            this.RobotCommandStatusLbl.Location = new System.Drawing.Point(325, 70);
            this.RobotCommandStatusLbl.Name = "RobotCommandStatusLbl";
            this.RobotCommandStatusLbl.Size = new System.Drawing.Size(198, 135);
            this.RobotCommandStatusLbl.TabIndex = 78;
            this.RobotCommandStatusLbl.Text = "Command Status";
            this.RobotCommandStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindReadyLbl
            // 
            this.GrindReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.GrindReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindReadyLbl.ForeColor = System.Drawing.Color.White;
            this.GrindReadyLbl.Location = new System.Drawing.Point(325, 340);
            this.GrindReadyLbl.Name = "GrindReadyLbl";
            this.GrindReadyLbl.Size = new System.Drawing.Size(198, 135);
            this.GrindReadyLbl.TabIndex = 88;
            this.GrindReadyLbl.Text = "Grind Ready";
            this.GrindReadyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotReadyLbl
            // 
            this.RobotReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.RobotReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotReadyLbl.ForeColor = System.Drawing.Color.White;
            this.RobotReadyLbl.Location = new System.Drawing.Point(325, 205);
            this.RobotReadyLbl.Name = "RobotReadyLbl";
            this.RobotReadyLbl.Size = new System.Drawing.Size(198, 135);
            this.RobotReadyLbl.TabIndex = 89;
            this.RobotReadyLbl.Text = "Robot Ready";
            this.RobotReadyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindContactEnabledBtn
            // 
            this.GrindContactEnabledBtn.BackColor = System.Drawing.Color.Gray;
            this.GrindContactEnabledBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindContactEnabledBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindContactEnabledBtn.ForeColor = System.Drawing.Color.White;
            this.GrindContactEnabledBtn.Location = new System.Drawing.Point(855, 3);
            this.GrindContactEnabledBtn.Name = "GrindContactEnabledBtn";
            this.GrindContactEnabledBtn.Size = new System.Drawing.Size(207, 133);
            this.GrindContactEnabledBtn.TabIndex = 4;
            this.GrindContactEnabledBtn.Text = "Grind Contact Enabled";
            this.GrindContactEnabledBtn.UseVisualStyleBackColor = false;
            this.GrindContactEnabledBtn.Click += new System.EventHandler(this.GrindContactEnabledBtn_Click);
            // 
            // MonitorTab
            // 
            this.MonitorTab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.MonitorTab.Controls.Add(this.positionsPage);
            this.MonitorTab.Controls.Add(this.variablesPage);
            this.MonitorTab.Controls.Add(this.javaEnginePage);
            this.MonitorTab.Controls.Add(this.pythonEnginePage);
            this.MonitorTab.Controls.Add(this.manualPage);
            this.MonitorTab.Controls.Add(this.revhistPage);
            this.MonitorTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorTab.ItemSize = new System.Drawing.Size(150, 60);
            this.MonitorTab.Location = new System.Drawing.Point(823, 3);
            this.MonitorTab.Name = "MonitorTab";
            this.ProgramTableLayoutPanel.SetRowSpan(this.MonitorTab, 3);
            this.MonitorTab.SelectedIndex = 0;
            this.MonitorTab.Size = new System.Drawing.Size(1296, 1152);
            this.MonitorTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MonitorTab.TabIndex = 94;
            // 
            // positionsPage
            // 
            this.positionsPage.Controls.Add(this.PositionLayoutPanel);
            this.positionsPage.Location = new System.Drawing.Point(4, 64);
            this.positionsPage.Name = "positionsPage";
            this.positionsPage.Size = new System.Drawing.Size(1288, 1084);
            this.positionsPage.TabIndex = 2;
            this.positionsPage.Text = "Positions";
            this.positionsPage.UseVisualStyleBackColor = true;
            // 
            // PositionLayoutPanel
            // 
            this.PositionLayoutPanel.ColumnCount = 4;
            this.PositionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PositionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PositionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PositionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PositionLayoutPanel.Controls.Add(this.PositionMovePoseBtn, 0, 0);
            this.PositionLayoutPanel.Controls.Add(this.PositionsGrd, 0, 1);
            this.PositionLayoutPanel.Controls.Add(this.ClearAllPositionsBtn, 3, 2);
            this.PositionLayoutPanel.Controls.Add(this.ClearPositionsBtn, 2, 2);
            this.PositionLayoutPanel.Controls.Add(this.SavePositionsBtn, 1, 2);
            this.PositionLayoutPanel.Controls.Add(this.LoadPositionsBtn, 0, 2);
            this.PositionLayoutPanel.Controls.Add(this.PositionMoveArmBtn, 1, 0);
            this.PositionLayoutPanel.Controls.Add(this.JogBtn, 3, 0);
            this.PositionLayoutPanel.Controls.Add(this.PositionSetBtn, 2, 0);
            this.PositionLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PositionLayoutPanel.Name = "PositionLayoutPanel";
            this.PositionLayoutPanel.RowCount = 3;
            this.PositionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PositionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PositionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.PositionLayoutPanel.Size = new System.Drawing.Size(1288, 1084);
            this.PositionLayoutPanel.TabIndex = 101;
            // 
            // PositionMovePoseBtn
            // 
            this.PositionMovePoseBtn.BackColor = System.Drawing.Color.Green;
            this.PositionMovePoseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionMovePoseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionMovePoseBtn.ForeColor = System.Drawing.Color.White;
            this.PositionMovePoseBtn.Location = new System.Drawing.Point(2, 2);
            this.PositionMovePoseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionMovePoseBtn.Name = "PositionMovePoseBtn";
            this.PositionMovePoseBtn.Size = new System.Drawing.Size(318, 146);
            this.PositionMovePoseBtn.TabIndex = 97;
            this.PositionMovePoseBtn.Text = "Linear Move to Pose";
            this.PositionMovePoseBtn.UseVisualStyleBackColor = false;
            this.PositionMovePoseBtn.Click += new System.EventHandler(this.PositionMovePoseBtn_Click);
            // 
            // PositionsGrd
            // 
            this.PositionsGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.PositionsGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PositionsGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PositionsGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PositionLayoutPanel.SetColumnSpan(this.PositionsGrd, 4);
            this.PositionsGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionsGrd.Location = new System.Drawing.Point(3, 153);
            this.PositionsGrd.Name = "PositionsGrd";
            this.PositionsGrd.RowTemplate.Height = 34;
            this.PositionsGrd.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PositionsGrd.Size = new System.Drawing.Size(1282, 848);
            this.PositionsGrd.TabIndex = 85;
            // 
            // ClearAllPositionsBtn
            // 
            this.ClearAllPositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearAllPositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllPositionsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllPositionsBtn.Location = new System.Drawing.Point(969, 1007);
            this.ClearAllPositionsBtn.Name = "ClearAllPositionsBtn";
            this.ClearAllPositionsBtn.Size = new System.Drawing.Size(316, 74);
            this.ClearAllPositionsBtn.TabIndex = 95;
            this.ClearAllPositionsBtn.Text = "Clear All";
            this.ClearAllPositionsBtn.UseVisualStyleBackColor = false;
            this.ClearAllPositionsBtn.Click += new System.EventHandler(this.ClearAllPositionsBtn_Click);
            // 
            // ClearPositionsBtn
            // 
            this.ClearPositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearPositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearPositionsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearPositionsBtn.Location = new System.Drawing.Point(647, 1007);
            this.ClearPositionsBtn.Name = "ClearPositionsBtn";
            this.ClearPositionsBtn.Size = new System.Drawing.Size(316, 74);
            this.ClearPositionsBtn.TabIndex = 92;
            this.ClearPositionsBtn.Text = "Clear";
            this.ClearPositionsBtn.UseVisualStyleBackColor = false;
            this.ClearPositionsBtn.Click += new System.EventHandler(this.ClearPositionsBtn_Click);
            // 
            // SavePositionsBtn
            // 
            this.SavePositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.SavePositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SavePositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePositionsBtn.ForeColor = System.Drawing.Color.White;
            this.SavePositionsBtn.Location = new System.Drawing.Point(325, 1007);
            this.SavePositionsBtn.Name = "SavePositionsBtn";
            this.SavePositionsBtn.Size = new System.Drawing.Size(316, 74);
            this.SavePositionsBtn.TabIndex = 93;
            this.SavePositionsBtn.Text = "Save";
            this.SavePositionsBtn.UseVisualStyleBackColor = false;
            this.SavePositionsBtn.Click += new System.EventHandler(this.SavePositionsBtn_Click);
            // 
            // LoadPositionsBtn
            // 
            this.LoadPositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.LoadPositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPositionsBtn.ForeColor = System.Drawing.Color.White;
            this.LoadPositionsBtn.Location = new System.Drawing.Point(3, 1007);
            this.LoadPositionsBtn.Name = "LoadPositionsBtn";
            this.LoadPositionsBtn.Size = new System.Drawing.Size(316, 74);
            this.LoadPositionsBtn.TabIndex = 94;
            this.LoadPositionsBtn.Text = "Reload";
            this.LoadPositionsBtn.UseVisualStyleBackColor = false;
            this.LoadPositionsBtn.Click += new System.EventHandler(this.LoadPositionsBtn_Click);
            // 
            // PositionMoveArmBtn
            // 
            this.PositionMoveArmBtn.BackColor = System.Drawing.Color.Green;
            this.PositionMoveArmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionMoveArmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionMoveArmBtn.ForeColor = System.Drawing.Color.White;
            this.PositionMoveArmBtn.Location = new System.Drawing.Point(324, 2);
            this.PositionMoveArmBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionMoveArmBtn.Name = "PositionMoveArmBtn";
            this.PositionMoveArmBtn.Size = new System.Drawing.Size(318, 146);
            this.PositionMoveArmBtn.TabIndex = 98;
            this.PositionMoveArmBtn.Text = "Joint Move to Position";
            this.PositionMoveArmBtn.UseVisualStyleBackColor = false;
            this.PositionMoveArmBtn.Click += new System.EventHandler(this.PositionMoveArmBtn_Click);
            // 
            // JogBtn
            // 
            this.JogBtn.BackColor = System.Drawing.Color.Green;
            this.JogBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JogBtn.ForeColor = System.Drawing.Color.White;
            this.JogBtn.Location = new System.Drawing.Point(968, 2);
            this.JogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JogBtn.Name = "JogBtn";
            this.JogBtn.Size = new System.Drawing.Size(318, 146);
            this.JogBtn.TabIndex = 100;
            this.JogBtn.Text = "Jog Only";
            this.JogBtn.UseVisualStyleBackColor = false;
            this.JogBtn.Click += new System.EventHandler(this.JogBtn_Click);
            // 
            // PositionSetBtn
            // 
            this.PositionSetBtn.BackColor = System.Drawing.Color.Green;
            this.PositionSetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionSetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionSetBtn.ForeColor = System.Drawing.Color.White;
            this.PositionSetBtn.Location = new System.Drawing.Point(646, 2);
            this.PositionSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionSetBtn.Name = "PositionSetBtn";
            this.PositionSetBtn.Size = new System.Drawing.Size(318, 146);
            this.PositionSetBtn.TabIndex = 96;
            this.PositionSetBtn.Text = "Set Position";
            this.PositionSetBtn.UseVisualStyleBackColor = false;
            this.PositionSetBtn.Click += new System.EventHandler(this.PositionSetBtn_Click);
            // 
            // variablesPage
            // 
            this.variablesPage.Controls.Add(this.VariablesLayoutPanel);
            this.variablesPage.Location = new System.Drawing.Point(4, 64);
            this.variablesPage.Name = "variablesPage";
            this.variablesPage.Padding = new System.Windows.Forms.Padding(3);
            this.variablesPage.Size = new System.Drawing.Size(1288, 1084);
            this.variablesPage.TabIndex = 0;
            this.variablesPage.Text = "Variables";
            this.variablesPage.UseVisualStyleBackColor = true;
            // 
            // VariablesLayoutPanel
            // 
            this.VariablesLayoutPanel.ColumnCount = 4;
            this.VariablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.VariablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.VariablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.VariablesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.VariablesLayoutPanel.Controls.Add(this.VariablesGrd, 0, 0);
            this.VariablesLayoutPanel.Controls.Add(this.ClearAllVariablesBtn, 3, 1);
            this.VariablesLayoutPanel.Controls.Add(this.ClearVariablesBtn, 2, 1);
            this.VariablesLayoutPanel.Controls.Add(this.SaveVariablesBtn, 1, 1);
            this.VariablesLayoutPanel.Controls.Add(this.LoadVariablesBtn, 0, 1);
            this.VariablesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.VariablesLayoutPanel.Name = "VariablesLayoutPanel";
            this.VariablesLayoutPanel.RowCount = 2;
            this.VariablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VariablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.VariablesLayoutPanel.Size = new System.Drawing.Size(1282, 1078);
            this.VariablesLayoutPanel.TabIndex = 92;
            // 
            // VariablesGrd
            // 
            this.VariablesGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.VariablesGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VariablesGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.VariablesGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VariablesLayoutPanel.SetColumnSpan(this.VariablesGrd, 4);
            this.VariablesGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesGrd.Location = new System.Drawing.Point(3, 3);
            this.VariablesGrd.Name = "VariablesGrd";
            this.VariablesGrd.RowTemplate.Height = 34;
            this.VariablesGrd.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VariablesGrd.Size = new System.Drawing.Size(1276, 992);
            this.VariablesGrd.TabIndex = 84;
            // 
            // ClearAllVariablesBtn
            // 
            this.ClearAllVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearAllVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllVariablesBtn.Location = new System.Drawing.Point(963, 1001);
            this.ClearAllVariablesBtn.Name = "ClearAllVariablesBtn";
            this.ClearAllVariablesBtn.Size = new System.Drawing.Size(316, 74);
            this.ClearAllVariablesBtn.TabIndex = 91;
            this.ClearAllVariablesBtn.Text = "Clear All";
            this.ClearAllVariablesBtn.UseVisualStyleBackColor = false;
            this.ClearAllVariablesBtn.Click += new System.EventHandler(this.ClearAllVariablesBtn_Click);
            // 
            // ClearVariablesBtn
            // 
            this.ClearVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.ClearVariablesBtn.Location = new System.Drawing.Point(643, 1001);
            this.ClearVariablesBtn.Name = "ClearVariablesBtn";
            this.ClearVariablesBtn.Size = new System.Drawing.Size(314, 74);
            this.ClearVariablesBtn.TabIndex = 88;
            this.ClearVariablesBtn.Text = "Clear";
            this.ClearVariablesBtn.UseVisualStyleBackColor = false;
            this.ClearVariablesBtn.Click += new System.EventHandler(this.ClearVariablesBtn_Click);
            // 
            // SaveVariablesBtn
            // 
            this.SaveVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.SaveVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.SaveVariablesBtn.Location = new System.Drawing.Point(323, 1001);
            this.SaveVariablesBtn.Name = "SaveVariablesBtn";
            this.SaveVariablesBtn.Size = new System.Drawing.Size(314, 74);
            this.SaveVariablesBtn.TabIndex = 89;
            this.SaveVariablesBtn.Text = "Save";
            this.SaveVariablesBtn.UseVisualStyleBackColor = false;
            this.SaveVariablesBtn.Click += new System.EventHandler(this.SaveVariablesBtn_Click);
            // 
            // LoadVariablesBtn
            // 
            this.LoadVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.LoadVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.LoadVariablesBtn.Location = new System.Drawing.Point(3, 1001);
            this.LoadVariablesBtn.Name = "LoadVariablesBtn";
            this.LoadVariablesBtn.Size = new System.Drawing.Size(314, 74);
            this.LoadVariablesBtn.TabIndex = 90;
            this.LoadVariablesBtn.Text = "Reload";
            this.LoadVariablesBtn.UseVisualStyleBackColor = false;
            this.LoadVariablesBtn.Click += new System.EventHandler(this.LoadVariablesBtn_Click);
            // 
            // javaEnginePage
            // 
            this.javaEnginePage.Controls.Add(this.JavaRunBtn);
            this.javaEnginePage.Controls.Add(this.JavaScriptRTB);
            this.javaEnginePage.Location = new System.Drawing.Point(4, 64);
            this.javaEnginePage.Name = "javaEnginePage";
            this.javaEnginePage.Size = new System.Drawing.Size(1288, 1084);
            this.javaEnginePage.TabIndex = 5;
            this.javaEnginePage.Text = "Java";
            this.javaEnginePage.UseVisualStyleBackColor = true;
            // 
            // JavaRunBtn
            // 
            this.JavaRunBtn.Location = new System.Drawing.Point(19, 716);
            this.JavaRunBtn.Name = "JavaRunBtn";
            this.JavaRunBtn.Size = new System.Drawing.Size(164, 63);
            this.JavaRunBtn.TabIndex = 1;
            this.JavaRunBtn.Text = "Run";
            this.JavaRunBtn.UseVisualStyleBackColor = true;
            this.JavaRunBtn.Click += new System.EventHandler(this.JavaRunBtn_Click);
            // 
            // JavaScriptRTB
            // 
            this.JavaScriptRTB.Location = new System.Drawing.Point(19, 14);
            this.JavaScriptRTB.Name = "JavaScriptRTB";
            this.JavaScriptRTB.Size = new System.Drawing.Size(976, 696);
            this.JavaScriptRTB.TabIndex = 0;
            this.JavaScriptRTB.Text = resources.GetString("JavaScriptRTB.Text");
            // 
            // pythonEnginePage
            // 
            this.pythonEnginePage.Location = new System.Drawing.Point(4, 64);
            this.pythonEnginePage.Name = "pythonEnginePage";
            this.pythonEnginePage.Size = new System.Drawing.Size(1288, 1084);
            this.pythonEnginePage.TabIndex = 6;
            this.pythonEnginePage.Text = "Python";
            this.pythonEnginePage.UseVisualStyleBackColor = true;
            // 
            // manualPage
            // 
            this.manualPage.Controls.Add(this.ManualLayoutPanel);
            this.manualPage.Location = new System.Drawing.Point(4, 64);
            this.manualPage.Name = "manualPage";
            this.manualPage.Size = new System.Drawing.Size(1288, 1084);
            this.manualPage.TabIndex = 3;
            this.manualPage.Text = "Manual";
            this.manualPage.UseVisualStyleBackColor = true;
            // 
            // ManualLayoutPanel
            // 
            this.ManualLayoutPanel.ColumnCount = 1;
            this.ManualLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ManualLayoutPanel.Controls.Add(this.RecipeCommandsRTB, 0, 0);
            this.ManualLayoutPanel.Controls.Add(this.FullManualBtn, 0, 1);
            this.ManualLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManualLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ManualLayoutPanel.Name = "ManualLayoutPanel";
            this.ManualLayoutPanel.RowCount = 2;
            this.ManualLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ManualLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.ManualLayoutPanel.Size = new System.Drawing.Size(1288, 1084);
            this.ManualLayoutPanel.TabIndex = 106;
            // 
            // RecipeCommandsRTB
            // 
            this.RecipeCommandsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipeCommandsRTB.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipeCommandsRTB.Location = new System.Drawing.Point(2, 2);
            this.RecipeCommandsRTB.Margin = new System.Windows.Forms.Padding(2);
            this.RecipeCommandsRTB.Name = "RecipeCommandsRTB";
            this.RecipeCommandsRTB.ReadOnly = true;
            this.RecipeCommandsRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RecipeCommandsRTB.Size = new System.Drawing.Size(1284, 1020);
            this.RecipeCommandsRTB.TabIndex = 104;
            this.RecipeCommandsRTB.Text = "";
            // 
            // FullManualBtn
            // 
            this.FullManualBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullManualBtn.Location = new System.Drawing.Point(3, 1027);
            this.FullManualBtn.Name = "FullManualBtn";
            this.FullManualBtn.Size = new System.Drawing.Size(1282, 54);
            this.FullManualBtn.TabIndex = 105;
            this.FullManualBtn.Text = "Show Full Manual PDF in Chrome";
            this.FullManualBtn.UseVisualStyleBackColor = true;
            this.FullManualBtn.Click += new System.EventHandler(this.FullManualBtn_Click);
            // 
            // revhistPage
            // 
            this.revhistPage.Controls.Add(this.RevHistRTB);
            this.revhistPage.Location = new System.Drawing.Point(4, 64);
            this.revhistPage.Name = "revhistPage";
            this.revhistPage.Size = new System.Drawing.Size(1288, 1084);
            this.revhistPage.TabIndex = 4;
            this.revhistPage.Text = "RevHist";
            this.revhistPage.UseVisualStyleBackColor = true;
            // 
            // RevHistRTB
            // 
            this.RevHistRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RevHistRTB.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevHistRTB.Location = new System.Drawing.Point(0, 0);
            this.RevHistRTB.Margin = new System.Windows.Forms.Padding(2);
            this.RevHistRTB.Name = "RevHistRTB";
            this.RevHistRTB.ReadOnly = true;
            this.RevHistRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RevHistRTB.Size = new System.Drawing.Size(1288, 1084);
            this.RevHistRTB.TabIndex = 105;
            this.RevHistRTB.Text = "";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 67);
            this.label6.TabIndex = 97;
            this.label6.Text = "Tool";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MountedToolBox
            // 
            this.MountedToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MountedToolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MountedToolBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MountedToolBox.FormattingEnabled = true;
            this.MountedToolBox.Location = new System.Drawing.Point(3, 3);
            this.MountedToolBox.Name = "MountedToolBox";
            this.MountedToolBox.Size = new System.Drawing.Size(308, 63);
            this.MountedToolBox.TabIndex = 5;
            this.MountedToolBox.SelectedIndexChanged += new System.EventHandler(this.MountedToolBox_SelectedIndexChanged);
            // 
            // UserModeBox
            // 
            this.UserModeBox.BackColor = System.Drawing.SystemColors.Control;
            this.UserModeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserModeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserModeBox.FormattingEnabled = true;
            this.UserModeBox.Items.AddRange(new object[] {
            "OPERATOR",
            "EDITOR",
            "ENGINEERING"});
            this.UserModeBox.Location = new System.Drawing.Point(3, 3);
            this.UserModeBox.Name = "UserModeBox";
            this.UserModeBox.Size = new System.Drawing.Size(316, 47);
            this.UserModeBox.TabIndex = 103;
            this.UserModeBox.SelectedIndexChanged += new System.EventHandler(this.OperatorModeBox_SelectedIndexChanged);
            // 
            // RobotModeBtn
            // 
            this.RobotModeBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotModeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotModeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotModeBtn.ForeColor = System.Drawing.Color.White;
            this.RobotModeBtn.Location = new System.Drawing.Point(3, 208);
            this.RobotModeBtn.Name = "RobotModeBtn";
            this.RobotModeBtn.Size = new System.Drawing.Size(316, 129);
            this.RobotModeBtn.TabIndex = 106;
            this.RobotModeBtn.Text = "Robot Mode";
            this.RobotModeBtn.UseVisualStyleBackColor = false;
            this.RobotModeBtn.Click += new System.EventHandler(this.RobotModeBtn_Click);
            // 
            // SafetyStatusBtn
            // 
            this.SafetyStatusBtn.BackColor = System.Drawing.Color.Gray;
            this.SafetyStatusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SafetyStatusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SafetyStatusBtn.ForeColor = System.Drawing.Color.White;
            this.SafetyStatusBtn.Location = new System.Drawing.Point(3, 343);
            this.SafetyStatusBtn.Name = "SafetyStatusBtn";
            this.SafetyStatusBtn.Size = new System.Drawing.Size(316, 129);
            this.SafetyStatusBtn.TabIndex = 107;
            this.SafetyStatusBtn.Text = "Safety Status";
            this.SafetyStatusBtn.UseVisualStyleBackColor = false;
            this.SafetyStatusBtn.Click += new System.EventHandler(this.SafetyStatusBtn_Click);
            // 
            // ProgramStateBtn
            // 
            this.ProgramStateBtn.BackColor = System.Drawing.Color.Gray;
            this.ProgramStateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramStateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramStateBtn.ForeColor = System.Drawing.Color.White;
            this.ProgramStateBtn.Location = new System.Drawing.Point(3, 478);
            this.ProgramStateBtn.Name = "ProgramStateBtn";
            this.ProgramStateBtn.Size = new System.Drawing.Size(316, 129);
            this.ProgramStateBtn.TabIndex = 108;
            this.ProgramStateBtn.Text = "Program State";
            this.ProgramStateBtn.UseVisualStyleBackColor = false;
            this.ProgramStateBtn.Click += new System.EventHandler(this.ProgramStateBtn_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 67);
            this.label5.TabIndex = 115;
            this.label5.Text = "Part Geom";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiameterDimLbl
            // 
            this.DiameterDimLbl.AutoSize = true;
            this.DiameterDimLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiameterDimLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiameterDimLbl.Location = new System.Drawing.Point(215, 0);
            this.DiameterDimLbl.Name = "DiameterDimLbl";
            this.DiameterDimLbl.Size = new System.Drawing.Size(207, 59);
            this.DiameterDimLbl.TabIndex = 12;
            this.DiameterDimLbl.Text = "dia (mm)";
            this.DiameterDimLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.MainTab.Controls.Add(this.RunPage);
            this.MainTab.Controls.Add(this.ProgramPage);
            this.MainTab.Controls.Add(this.SetupPage);
            this.MainTab.Controls.Add(this.LogPage);
            this.MainTab.Controls.Add(this.UiPage);
            this.MainTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.ItemSize = new System.Drawing.Size(96, 96);
            this.MainTab.Location = new System.Drawing.Point(8, 11);
            this.MainTab.Multiline = true;
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(2140, 1272);
            this.MainTab.TabIndex = 0;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            this.MainTab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainTab_Selecting);
            // 
            // RunPage
            // 
            this.RunPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunPage.Controls.Add(this.RunTabLayoutPanel);
            this.RunPage.Location = new System.Drawing.Point(4, 100);
            this.RunPage.Name = "RunPage";
            this.RunPage.Padding = new System.Windows.Forms.Padding(3);
            this.RunPage.Size = new System.Drawing.Size(2132, 1168);
            this.RunPage.TabIndex = 0;
            this.RunPage.Text = "Run";
            this.RunPage.ToolTipText = "Run";
            this.RunPage.UseVisualStyleBackColor = true;
            // 
            // RunTabLayoutPanel
            // 
            this.RunTabLayoutPanel.ColumnCount = 3;
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RunTabLayoutPanel.Controls.Add(this.StatusLayoutPanel, 2, 0);
            this.RunTabLayoutPanel.Controls.Add(this.RecipeRTBCopy, 0, 0);
            this.RunTabLayoutPanel.Controls.Add(this.panel2, 1, 0);
            this.RunTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.RunTabLayoutPanel.Name = "RunTabLayoutPanel";
            this.RunTabLayoutPanel.RowCount = 1;
            this.RunTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RunTabLayoutPanel.Size = new System.Drawing.Size(2122, 1158);
            this.RunTabLayoutPanel.TabIndex = 161;
            // 
            // StatusLayoutPanel
            // 
            this.StatusLayoutPanel.ColumnCount = 2;
            this.StatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.21673F));
            this.StatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.78327F));
            this.StatusLayoutPanel.Controls.Add(this.label9, 1, 0);
            this.StatusLayoutPanel.Controls.Add(this.UserModeBox, 0, 0);
            this.StatusLayoutPanel.Controls.Add(this.ProgramStateBtn, 0, 5);
            this.StatusLayoutPanel.Controls.Add(this.SafetyStatusBtn, 0, 4);
            this.StatusLayoutPanel.Controls.Add(this.RobotModeBtn, 0, 3);
            this.StatusLayoutPanel.Controls.Add(this.RobotConnectBtn, 0, 2);
            this.StatusLayoutPanel.Controls.Add(this.RobotCommandStatusLbl, 1, 2);
            this.StatusLayoutPanel.Controls.Add(this.GocatorConnectBtn, 0, 8);
            this.StatusLayoutPanel.Controls.Add(this.GocatorReadyLbl, 1, 8);
            this.StatusLayoutPanel.Controls.Add(this.CommandCounterLayoutPanel, 1, 9);
            this.StatusLayoutPanel.Controls.Add(this.RobotReadyLbl, 1, 3);
            this.StatusLayoutPanel.Controls.Add(this.GrindReadyLbl, 1, 4);
            this.StatusLayoutPanel.Controls.Add(this.GrindProcessStateLbl, 1, 5);
            this.StatusLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLayoutPanel.Location = new System.Drawing.Point(1593, 3);
            this.StatusLayoutPanel.Name = "StatusLayoutPanel";
            this.StatusLayoutPanel.RowCount = 10;
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StatusLayoutPanel.Size = new System.Drawing.Size(526, 1152);
            this.StatusLayoutPanel.TabIndex = 161;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(324, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 50);
            this.label9.TabIndex = 154;
            this.label9.Text = "User";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RobotConnectBtn
            // 
            this.RobotConnectBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotConnectBtn.ForeColor = System.Drawing.Color.White;
            this.RobotConnectBtn.Location = new System.Drawing.Point(3, 73);
            this.RobotConnectBtn.Name = "RobotConnectBtn";
            this.RobotConnectBtn.Size = new System.Drawing.Size(316, 129);
            this.RobotConnectBtn.TabIndex = 73;
            this.RobotConnectBtn.Text = "Robot Connect";
            this.RobotConnectBtn.UseVisualStyleBackColor = false;
            this.RobotConnectBtn.Click += new System.EventHandler(this.RobotConnectBtn_Click);
            // 
            // GocatorConnectBtn
            // 
            this.GocatorConnectBtn.BackColor = System.Drawing.Color.Gray;
            this.GocatorConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GocatorConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GocatorConnectBtn.ForeColor = System.Drawing.Color.White;
            this.GocatorConnectBtn.Location = new System.Drawing.Point(3, 883);
            this.GocatorConnectBtn.Name = "GocatorConnectBtn";
            this.GocatorConnectBtn.Size = new System.Drawing.Size(316, 129);
            this.GocatorConnectBtn.TabIndex = 159;
            this.GocatorConnectBtn.Text = "Gocator Connect";
            this.GocatorConnectBtn.UseVisualStyleBackColor = false;
            this.GocatorConnectBtn.Click += new System.EventHandler(this.GocatorConnectBtn_Click);
            // 
            // GocatorReadyLbl
            // 
            this.GocatorReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.GocatorReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GocatorReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GocatorReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GocatorReadyLbl.ForeColor = System.Drawing.Color.White;
            this.GocatorReadyLbl.Location = new System.Drawing.Point(325, 880);
            this.GocatorReadyLbl.Name = "GocatorReadyLbl";
            this.GocatorReadyLbl.Size = new System.Drawing.Size(198, 135);
            this.GocatorReadyLbl.TabIndex = 160;
            this.GocatorReadyLbl.Text = "Gocator Ready";
            this.GocatorReadyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommandCounterLayoutPanel
            // 
            this.CommandCounterLayoutPanel.ColumnCount = 1;
            this.CommandCounterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.Controls.Add(this.RobotSentLbl, 0, 0);
            this.CommandCounterLayoutPanel.Controls.Add(this.RobotCompletedLbl, 0, 1);
            this.CommandCounterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandCounterLayoutPanel.Location = new System.Drawing.Point(325, 1018);
            this.CommandCounterLayoutPanel.Name = "CommandCounterLayoutPanel";
            this.CommandCounterLayoutPanel.RowCount = 2;
            this.CommandCounterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.Size = new System.Drawing.Size(198, 131);
            this.CommandCounterLayoutPanel.TabIndex = 160;
            // 
            // RobotSentLbl
            // 
            this.RobotSentLbl.BackColor = System.Drawing.Color.Green;
            this.RobotSentLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotSentLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotSentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotSentLbl.ForeColor = System.Drawing.Color.White;
            this.RobotSentLbl.Location = new System.Drawing.Point(3, 0);
            this.RobotSentLbl.Name = "RobotSentLbl";
            this.RobotSentLbl.Size = new System.Drawing.Size(192, 65);
            this.RobotSentLbl.TabIndex = 149;
            this.RobotSentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotCompletedLbl
            // 
            this.RobotCompletedLbl.BackColor = System.Drawing.Color.Gray;
            this.RobotCompletedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotCompletedLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotCompletedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotCompletedLbl.ForeColor = System.Drawing.Color.White;
            this.RobotCompletedLbl.Location = new System.Drawing.Point(3, 65);
            this.RobotCompletedLbl.Name = "RobotCompletedLbl";
            this.RobotCompletedLbl.Size = new System.Drawing.Size(192, 66);
            this.RobotCompletedLbl.TabIndex = 135;
            this.RobotCompletedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindProcessStateLbl
            // 
            this.GrindProcessStateLbl.BackColor = System.Drawing.Color.Gray;
            this.GrindProcessStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindProcessStateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindProcessStateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindProcessStateLbl.ForeColor = System.Drawing.Color.White;
            this.GrindProcessStateLbl.Location = new System.Drawing.Point(325, 475);
            this.GrindProcessStateLbl.Name = "GrindProcessStateLbl";
            this.GrindProcessStateLbl.Size = new System.Drawing.Size(198, 135);
            this.GrindProcessStateLbl.TabIndex = 136;
            this.GrindProcessStateLbl.Text = "Grind Process State";
            this.GrindProcessStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecipeRTBCopy
            // 
            this.RecipeRTBCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecipeRTBCopy.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipeRTBCopy.Location = new System.Drawing.Point(2, 2);
            this.RecipeRTBCopy.Margin = new System.Windows.Forms.Padding(2);
            this.RecipeRTBCopy.Name = "RecipeRTBCopy";
            this.RecipeRTBCopy.ReadOnly = true;
            this.RecipeRTBCopy.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RecipeRTBCopy.Size = new System.Drawing.Size(738, 1154);
            this.RecipeRTBCopy.TabIndex = 129;
            this.RecipeRTBCopy.Text = "";
            this.RecipeRTBCopy.VScroll += new System.EventHandler(this.RecipeRTBCopy_VScroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.MoveToolMountBtn);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.MoveToolHomeBtn);
            this.panel2.Controls.Add(this.TimeLbl);
            this.panel2.Controls.Add(this.GrindForceReportZLbl);
            this.panel2.Controls.Add(this.RunStartedTimeLbl);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.RunElapsedTimeLbl);
            this.panel2.Controls.Add(this.RunStateLbl);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.CurrentLineLblCopy);
            this.panel2.Controls.Add(this.StepTimeRemainingLbl);
            this.panel2.Controls.Add(this.GrindCycleLbl);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.GrindNCyclesLbl);
            this.panel2.Controls.Add(this.StepTimeEstimateLbl);
            this.panel2.Controls.Add(this.Grind);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.StepElapsedTimeLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(745, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 1152);
            this.panel2.TabIndex = 130;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(198, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(251, 46);
            this.label18.TabIndex = 155;
            this.label18.Text = "Current Time";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(415, 916);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(416, 110);
            this.label15.TabIndex = 141;
            this.label15.Text = "Joint Move to\r\nTool Home Pose:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(246, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(203, 46);
            this.label14.TabIndex = 133;
            this.label14.Text = "Start Time";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 909);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(396, 115);
            this.label11.TabIndex = 139;
            this.label11.Text = "Joint Move to\r\nTool Mount Pose:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(157, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(292, 46);
            this.label12.TabIndex = 131;
            this.label12.Text = "Total Run Time";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoveToolMountBtn
            // 
            this.MoveToolMountBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveToolMountBtn.BackColor = System.Drawing.Color.Green;
            this.MoveToolMountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolMountBtn.ForeColor = System.Drawing.Color.White;
            this.MoveToolMountBtn.Location = new System.Drawing.Point(14, 1026);
            this.MoveToolMountBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MoveToolMountBtn.Name = "MoveToolMountBtn";
            this.MoveToolMountBtn.Size = new System.Drawing.Size(396, 115);
            this.MoveToolMountBtn.TabIndex = 138;
            this.MoveToolMountBtn.Text = "tool_mount";
            this.MoveToolMountBtn.UseVisualStyleBackColor = false;
            this.MoveToolMountBtn.Click += new System.EventHandler(this.MoveToolMountBtn_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(573, 763);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 46);
            this.label22.TabIndex = 158;
            this.label22.Text = "N";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoveToolHomeBtn
            // 
            this.MoveToolHomeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveToolHomeBtn.BackColor = System.Drawing.Color.Green;
            this.MoveToolHomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolHomeBtn.ForeColor = System.Drawing.Color.White;
            this.MoveToolHomeBtn.Location = new System.Drawing.Point(414, 1026);
            this.MoveToolHomeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MoveToolHomeBtn.Name = "MoveToolHomeBtn";
            this.MoveToolHomeBtn.Size = new System.Drawing.Size(417, 115);
            this.MoveToolHomeBtn.TabIndex = 137;
            this.MoveToolHomeBtn.Text = "tool_home";
            this.MoveToolHomeBtn.UseVisualStyleBackColor = false;
            this.MoveToolHomeBtn.Click += new System.EventHandler(this.MoveToolHomeBtn_Click);
            // 
            // GrindForceReportZLbl
            // 
            this.GrindForceReportZLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindForceReportZLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindForceReportZLbl.Location = new System.Drawing.Point(458, 760);
            this.GrindForceReportZLbl.Name = "GrindForceReportZLbl";
            this.GrindForceReportZLbl.Size = new System.Drawing.Size(112, 52);
            this.GrindForceReportZLbl.TabIndex = 157;
            this.GrindForceReportZLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunStartedTimeLbl
            // 
            this.RunStartedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunStartedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunStartedTimeLbl.Location = new System.Drawing.Point(452, 80);
            this.RunStartedTimeLbl.Name = "RunStartedTimeLbl";
            this.RunStartedTimeLbl.Size = new System.Drawing.Size(353, 52);
            this.RunStartedTimeLbl.TabIndex = 134;
            this.RunStartedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(36, 763);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(419, 46);
            this.label21.TabIndex = 156;
            this.label21.Text = "Last Reported Z Force";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunElapsedTimeLbl
            // 
            this.RunElapsedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunElapsedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunElapsedTimeLbl.Location = new System.Drawing.Point(452, 141);
            this.RunElapsedTimeLbl.Name = "RunElapsedTimeLbl";
            this.RunElapsedTimeLbl.Size = new System.Drawing.Size(353, 52);
            this.RunElapsedTimeLbl.TabIndex = 132;
            this.RunElapsedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RunStateLbl
            // 
            this.RunStateLbl.BackColor = System.Drawing.Color.Gray;
            this.RunStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunStateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunStateLbl.ForeColor = System.Drawing.Color.White;
            this.RunStateLbl.Location = new System.Drawing.Point(27, 247);
            this.RunStateLbl.Name = "RunStateLbl";
            this.RunStateLbl.Size = new System.Drawing.Size(786, 94);
            this.RunStateLbl.TabIndex = 122;
            this.RunStateLbl.Text = "Current Step";
            this.RunStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(226, 702);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 46);
            this.label10.TabIndex = 124;
            this.label10.Text = "Grind Cycle";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentLineLblCopy
            // 
            this.CurrentLineLblCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentLineLblCopy.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLineLblCopy.Location = new System.Drawing.Point(27, 347);
            this.CurrentLineLblCopy.Name = "CurrentLineLblCopy";
            this.CurrentLineLblCopy.Size = new System.Drawing.Size(786, 160);
            this.CurrentLineLblCopy.TabIndex = 125;
            // 
            // StepTimeRemainingLbl
            // 
            this.StepTimeRemainingLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepTimeRemainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepTimeRemainingLbl.Location = new System.Drawing.Point(458, 639);
            this.StepTimeRemainingLbl.Name = "StepTimeRemainingLbl";
            this.StepTimeRemainingLbl.Size = new System.Drawing.Size(353, 52);
            this.StepTimeRemainingLbl.TabIndex = 148;
            this.StepTimeRemainingLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GrindCycleLbl
            // 
            this.GrindCycleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindCycleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindCycleLbl.Location = new System.Drawing.Point(458, 700);
            this.GrindCycleLbl.Name = "GrindCycleLbl";
            this.GrindCycleLbl.Size = new System.Drawing.Size(112, 52);
            this.GrindCycleLbl.TabIndex = 126;
            this.GrindCycleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(52, 639);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(402, 46);
            this.label17.TabIndex = 147;
            this.label17.Text = "Step Time Remaining";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GrindNCyclesLbl
            // 
            this.GrindNCyclesLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindNCyclesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindNCyclesLbl.Location = new System.Drawing.Point(628, 702);
            this.GrindNCyclesLbl.Name = "GrindNCyclesLbl";
            this.GrindNCyclesLbl.Size = new System.Drawing.Size(100, 52);
            this.GrindNCyclesLbl.TabIndex = 127;
            this.GrindNCyclesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StepTimeEstimateLbl
            // 
            this.StepTimeEstimateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepTimeEstimateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepTimeEstimateLbl.Location = new System.Drawing.Point(458, 580);
            this.StepTimeEstimateLbl.Name = "StepTimeEstimateLbl";
            this.StepTimeEstimateLbl.Size = new System.Drawing.Size(353, 52);
            this.StepTimeEstimateLbl.TabIndex = 146;
            this.StepTimeEstimateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grind
            // 
            this.Grind.AutoSize = true;
            this.Grind.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grind.Location = new System.Drawing.Point(574, 706);
            this.Grind.Name = "Grind";
            this.Grind.Size = new System.Drawing.Size(54, 46);
            this.Grind.TabIndex = 128;
            this.Grind.Text = "of";
            this.Grind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(85, 586);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(367, 46);
            this.label13.TabIndex = 145;
            this.label13.Text = "Step Time Estimate";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(125, 528);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(329, 46);
            this.label16.TabIndex = 143;
            this.label16.Text = "Time in This Step";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StepElapsedTimeLbl
            // 
            this.StepElapsedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepElapsedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepElapsedTimeLbl.Location = new System.Drawing.Point(458, 522);
            this.StepElapsedTimeLbl.Name = "StepElapsedTimeLbl";
            this.StepElapsedTimeLbl.Size = new System.Drawing.Size(353, 52);
            this.StepElapsedTimeLbl.TabIndex = 144;
            this.StepElapsedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgramPage
            // 
            this.ProgramPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProgramPage.Controls.Add(this.ProgramTableLayoutPanel);
            this.ProgramPage.Location = new System.Drawing.Point(4, 100);
            this.ProgramPage.Name = "ProgramPage";
            this.ProgramPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProgramPage.Size = new System.Drawing.Size(2132, 1168);
            this.ProgramPage.TabIndex = 1;
            this.ProgramPage.Text = "Program";
            this.ProgramPage.UseVisualStyleBackColor = true;
            // 
            // ProgramTableLayoutPanel
            // 
            this.ProgramTableLayoutPanel.ColumnCount = 2;
            this.ProgramTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.65031F));
            this.ProgramTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.34969F));
            this.ProgramTableLayoutPanel.Controls.Add(this.RecipeRTB, 0, 0);
            this.ProgramTableLayoutPanel.Controls.Add(this.CurrentLineLbl, 0, 1);
            this.ProgramTableLayoutPanel.Controls.Add(this.MonitorTab, 1, 0);
            this.ProgramTableLayoutPanel.Controls.Add(this.FileBigEditPanel, 0, 2);
            this.ProgramTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ProgramTableLayoutPanel.Name = "ProgramTableLayoutPanel";
            this.ProgramTableLayoutPanel.RowCount = 3;
            this.ProgramTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProgramTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProgramTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ProgramTableLayoutPanel.Size = new System.Drawing.Size(2122, 1158);
            this.ProgramTableLayoutPanel.TabIndex = 96;
            // 
            // FileBigEditPanel
            // 
            this.FileBigEditPanel.ColumnCount = 2;
            this.FileBigEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileBigEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.FileBigEditPanel.Controls.Add(this.BigEditBtn, 1, 0);
            this.FileBigEditPanel.Controls.Add(this.RecipeFilenameLbl, 0, 0);
            this.FileBigEditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBigEditPanel.Location = new System.Drawing.Point(3, 1071);
            this.FileBigEditPanel.Name = "FileBigEditPanel";
            this.FileBigEditPanel.RowCount = 1;
            this.FileBigEditPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileBigEditPanel.Size = new System.Drawing.Size(814, 84);
            this.FileBigEditPanel.TabIndex = 95;
            // 
            // BigEditBtn
            // 
            this.BigEditBtn.BackColor = System.Drawing.Color.Gray;
            this.BigEditBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BigEditBtn.Enabled = false;
            this.BigEditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BigEditBtn.ForeColor = System.Drawing.Color.White;
            this.BigEditBtn.Location = new System.Drawing.Point(616, 2);
            this.BigEditBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BigEditBtn.Name = "BigEditBtn";
            this.BigEditBtn.Size = new System.Drawing.Size(196, 80);
            this.BigEditBtn.TabIndex = 95;
            this.BigEditBtn.Text = "Big Edit";
            this.BigEditBtn.UseVisualStyleBackColor = false;
            this.BigEditBtn.Click += new System.EventHandler(this.BigEditBtn_Click);
            // 
            // SetupPage
            // 
            this.SetupPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SetupPage.Controls.Add(this.label19);
            this.SetupPage.Controls.Add(this.RobotPolyscopeVersionLbl);
            this.SetupPage.Controls.Add(this.RobotSerialNumberLbl);
            this.SetupPage.Controls.Add(this.label8);
            this.SetupPage.Controls.Add(this.RobotModelLbl);
            this.SetupPage.Controls.Add(this.label7);
            this.SetupPage.Controls.Add(this.DefaultMoveSetupGrp);
            this.SetupPage.Controls.Add(this.GrindingMoveSetupGrp);
            this.SetupPage.Controls.Add(this.ToolSetupGrp);
            this.SetupPage.Controls.Add(this.GeneralConfigGrp);
            this.SetupPage.Location = new System.Drawing.Point(4, 100);
            this.SetupPage.Name = "SetupPage";
            this.SetupPage.Size = new System.Drawing.Size(2132, 1168);
            this.SetupPage.TabIndex = 2;
            this.SetupPage.Text = "Setup";
            this.SetupPage.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(820, 1125);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 36);
            this.label19.TabIndex = 160;
            this.label19.Text = "Software";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RobotPolyscopeVersionLbl
            // 
            this.RobotPolyscopeVersionLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotPolyscopeVersionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotPolyscopeVersionLbl.Location = new System.Drawing.Point(954, 1125);
            this.RobotPolyscopeVersionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RobotPolyscopeVersionLbl.Name = "RobotPolyscopeVersionLbl";
            this.RobotPolyscopeVersionLbl.Size = new System.Drawing.Size(718, 36);
            this.RobotPolyscopeVersionLbl.TabIndex = 159;
            this.RobotPolyscopeVersionLbl.Text = "PolyScope";
            this.RobotPolyscopeVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotSerialNumberLbl
            // 
            this.RobotSerialNumberLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotSerialNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotSerialNumberLbl.Location = new System.Drawing.Point(495, 1125);
            this.RobotSerialNumberLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RobotSerialNumberLbl.Name = "RobotSerialNumberLbl";
            this.RobotSerialNumberLbl.Size = new System.Drawing.Size(257, 36);
            this.RobotSerialNumberLbl.TabIndex = 157;
            this.RobotSerialNumberLbl.Text = "Serial Number";
            this.RobotSerialNumberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(427, 1125);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 36);
            this.label8.TabIndex = 158;
            this.label8.Text = "S/N";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RobotModelLbl
            // 
            this.RobotModelLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotModelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotModelLbl.Location = new System.Drawing.Point(223, 1125);
            this.RobotModelLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RobotModelLbl.Name = "RobotModelLbl";
            this.RobotModelLbl.Size = new System.Drawing.Size(157, 36);
            this.RobotModelLbl.TabIndex = 153;
            this.RobotModelLbl.Text = "Model";
            this.RobotModelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 1125);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 36);
            this.label7.TabIndex = 154;
            this.label7.Text = "Robot Model";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DefaultMoveSetupGrp
            // 
            this.DefaultMoveSetupGrp.Controls.Add(this.SetMoveDefaultsBtn);
            this.DefaultMoveSetupGrp.Controls.Add(this.SetLinearAccelBtn);
            this.DefaultMoveSetupGrp.Controls.Add(this.SetBlendRadiusBtn);
            this.DefaultMoveSetupGrp.Controls.Add(this.SetJointSpeedBtn);
            this.DefaultMoveSetupGrp.Controls.Add(this.SetJointAccelBtn);
            this.DefaultMoveSetupGrp.Controls.Add(this.SetLinearSpeedBtn);
            this.DefaultMoveSetupGrp.Location = new System.Drawing.Point(1188, 492);
            this.DefaultMoveSetupGrp.Name = "DefaultMoveSetupGrp";
            this.DefaultMoveSetupGrp.Size = new System.Drawing.Size(927, 320);
            this.DefaultMoveSetupGrp.TabIndex = 118;
            this.DefaultMoveSetupGrp.TabStop = false;
            this.DefaultMoveSetupGrp.Text = "Default (non-Grinding) Motion Parameters";
            // 
            // SetMoveDefaultsBtn
            // 
            this.SetMoveDefaultsBtn.BackColor = System.Drawing.Color.Green;
            this.SetMoveDefaultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMoveDefaultsBtn.ForeColor = System.Drawing.Color.White;
            this.SetMoveDefaultsBtn.Location = new System.Drawing.Point(750, 27);
            this.SetMoveDefaultsBtn.Name = "SetMoveDefaultsBtn";
            this.SetMoveDefaultsBtn.Size = new System.Drawing.Size(171, 130);
            this.SetMoveDefaultsBtn.TabIndex = 122;
            this.SetMoveDefaultsBtn.Text = "Restore Defaults";
            this.SetMoveDefaultsBtn.UseVisualStyleBackColor = false;
            this.SetMoveDefaultsBtn.Click += new System.EventHandler(this.SetMoveDefaultsBtn_Click);
            // 
            // SetLinearAccelBtn
            // 
            this.SetLinearAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetLinearAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetLinearAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetLinearAccelBtn.Location = new System.Drawing.Point(308, 40);
            this.SetLinearAccelBtn.Name = "SetLinearAccelBtn";
            this.SetLinearAccelBtn.Size = new System.Drawing.Size(286, 130);
            this.SetLinearAccelBtn.TabIndex = 110;
            this.SetLinearAccelBtn.Text = "Set Linear Accel";
            this.SetLinearAccelBtn.UseVisualStyleBackColor = false;
            this.SetLinearAccelBtn.Click += new System.EventHandler(this.SetLinearAccelBtn_Click);
            // 
            // SetBlendRadiusBtn
            // 
            this.SetBlendRadiusBtn.BackColor = System.Drawing.Color.Green;
            this.SetBlendRadiusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetBlendRadiusBtn.ForeColor = System.Drawing.Color.White;
            this.SetBlendRadiusBtn.Location = new System.Drawing.Point(600, 176);
            this.SetBlendRadiusBtn.Name = "SetBlendRadiusBtn";
            this.SetBlendRadiusBtn.Size = new System.Drawing.Size(286, 130);
            this.SetBlendRadiusBtn.TabIndex = 111;
            this.SetBlendRadiusBtn.Text = "Set Blend Radius";
            this.SetBlendRadiusBtn.UseVisualStyleBackColor = false;
            this.SetBlendRadiusBtn.Click += new System.EventHandler(this.SetBlendRadiusBtn_Click);
            // 
            // SetJointSpeedBtn
            // 
            this.SetJointSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetJointSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetJointSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetJointSpeedBtn.Location = new System.Drawing.Point(15, 177);
            this.SetJointSpeedBtn.Name = "SetJointSpeedBtn";
            this.SetJointSpeedBtn.Size = new System.Drawing.Size(286, 130);
            this.SetJointSpeedBtn.TabIndex = 112;
            this.SetJointSpeedBtn.Text = "Set Joint Speed";
            this.SetJointSpeedBtn.UseVisualStyleBackColor = false;
            this.SetJointSpeedBtn.Click += new System.EventHandler(this.SetJointSpeedBtn_Click);
            // 
            // SetJointAccelBtn
            // 
            this.SetJointAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetJointAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetJointAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetJointAccelBtn.Location = new System.Drawing.Point(308, 176);
            this.SetJointAccelBtn.Name = "SetJointAccelBtn";
            this.SetJointAccelBtn.Size = new System.Drawing.Size(286, 130);
            this.SetJointAccelBtn.TabIndex = 113;
            this.SetJointAccelBtn.Text = "Set Joint Accel";
            this.SetJointAccelBtn.UseVisualStyleBackColor = false;
            this.SetJointAccelBtn.Click += new System.EventHandler(this.SetJointAccelBtn_Click);
            // 
            // SetLinearSpeedBtn
            // 
            this.SetLinearSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetLinearSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetLinearSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetLinearSpeedBtn.Location = new System.Drawing.Point(15, 43);
            this.SetLinearSpeedBtn.Name = "SetLinearSpeedBtn";
            this.SetLinearSpeedBtn.Size = new System.Drawing.Size(286, 130);
            this.SetLinearSpeedBtn.TabIndex = 109;
            this.SetLinearSpeedBtn.Text = "Set Linear Speed";
            this.SetLinearSpeedBtn.UseVisualStyleBackColor = false;
            this.SetLinearSpeedBtn.Click += new System.EventHandler(this.SetLinearSpeedBtn_Click);
            // 
            // GrindingMoveSetupGrp
            // 
            this.GrindingMoveSetupGrp.Controls.Add(this.SetForceModeDampingBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetForceModeGainScalingBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetGrindJogAccelBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetGrindJogSpeedBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetPointFrequencyBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetGrindDefaultsBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetGrindAccelBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetTrialSpeedBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetMaxGrindBlendRadiusBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetMaxWaitBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetForceDwellBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetTouchSpeedBtn);
            this.GrindingMoveSetupGrp.Controls.Add(this.SetTouchRetractBtn);
            this.GrindingMoveSetupGrp.Location = new System.Drawing.Point(3, 820);
            this.GrindingMoveSetupGrp.Name = "GrindingMoveSetupGrp";
            this.GrindingMoveSetupGrp.Size = new System.Drawing.Size(2106, 299);
            this.GrindingMoveSetupGrp.TabIndex = 117;
            this.GrindingMoveSetupGrp.TabStop = false;
            this.GrindingMoveSetupGrp.Text = "Grinding Motion Parameters";
            // 
            // SetForceModeDampingBtn
            // 
            this.SetForceModeDampingBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceModeDampingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceModeDampingBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceModeDampingBtn.Location = new System.Drawing.Point(535, 169);
            this.SetForceModeDampingBtn.Name = "SetForceModeDampingBtn";
            this.SetForceModeDampingBtn.Size = new System.Drawing.Size(243, 124);
            this.SetForceModeDampingBtn.TabIndex = 126;
            this.SetForceModeDampingBtn.Text = "Set Force Mode Damping";
            this.SetForceModeDampingBtn.UseVisualStyleBackColor = false;
            this.SetForceModeDampingBtn.Click += new System.EventHandler(this.SetForceModeDampingBtn_Click);
            // 
            // SetForceModeGainScalingBtn
            // 
            this.SetForceModeGainScalingBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceModeGainScalingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceModeGainScalingBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceModeGainScalingBtn.Location = new System.Drawing.Point(795, 169);
            this.SetForceModeGainScalingBtn.Name = "SetForceModeGainScalingBtn";
            this.SetForceModeGainScalingBtn.Size = new System.Drawing.Size(243, 124);
            this.SetForceModeGainScalingBtn.TabIndex = 125;
            this.SetForceModeGainScalingBtn.Text = "Set Force Mode Gain Scaling";
            this.SetForceModeGainScalingBtn.UseVisualStyleBackColor = false;
            this.SetForceModeGainScalingBtn.Click += new System.EventHandler(this.SetForceModeGainScalingBtn_Click);
            // 
            // SetGrindJogAccelBtn
            // 
            this.SetGrindJogAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindJogAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindJogAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindJogAccelBtn.Location = new System.Drawing.Point(275, 169);
            this.SetGrindJogAccelBtn.Name = "SetGrindJogAccelBtn";
            this.SetGrindJogAccelBtn.Size = new System.Drawing.Size(243, 124);
            this.SetGrindJogAccelBtn.TabIndex = 124;
            this.SetGrindJogAccelBtn.Text = "Set Jog Accel";
            this.SetGrindJogAccelBtn.UseVisualStyleBackColor = false;
            this.SetGrindJogAccelBtn.Click += new System.EventHandler(this.SetGrindJogAccel_Click);
            // 
            // SetGrindJogSpeedBtn
            // 
            this.SetGrindJogSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindJogSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindJogSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindJogSpeedBtn.Location = new System.Drawing.Point(15, 169);
            this.SetGrindJogSpeedBtn.Name = "SetGrindJogSpeedBtn";
            this.SetGrindJogSpeedBtn.Size = new System.Drawing.Size(243, 124);
            this.SetGrindJogSpeedBtn.TabIndex = 123;
            this.SetGrindJogSpeedBtn.Text = "Set Jog Speed";
            this.SetGrindJogSpeedBtn.UseVisualStyleBackColor = false;
            this.SetGrindJogSpeedBtn.Click += new System.EventHandler(this.SetGrindJogSpeedBtn_Click);
            // 
            // SetPointFrequencyBtn
            // 
            this.SetPointFrequencyBtn.BackColor = System.Drawing.Color.Green;
            this.SetPointFrequencyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetPointFrequencyBtn.ForeColor = System.Drawing.Color.White;
            this.SetPointFrequencyBtn.Location = new System.Drawing.Point(1575, 169);
            this.SetPointFrequencyBtn.Name = "SetPointFrequencyBtn";
            this.SetPointFrequencyBtn.Size = new System.Drawing.Size(243, 124);
            this.SetPointFrequencyBtn.TabIndex = 122;
            this.SetPointFrequencyBtn.Text = "Set Point Frequency";
            this.SetPointFrequencyBtn.UseVisualStyleBackColor = false;
            this.SetPointFrequencyBtn.Click += new System.EventHandler(this.SetPointFrequencyBtn_Click);
            // 
            // SetGrindDefaultsBtn
            // 
            this.SetGrindDefaultsBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindDefaultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindDefaultsBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindDefaultsBtn.Location = new System.Drawing.Point(1935, 39);
            this.SetGrindDefaultsBtn.Name = "SetGrindDefaultsBtn";
            this.SetGrindDefaultsBtn.Size = new System.Drawing.Size(171, 130);
            this.SetGrindDefaultsBtn.TabIndex = 121;
            this.SetGrindDefaultsBtn.Text = "Restore Defaults";
            this.SetGrindDefaultsBtn.UseVisualStyleBackColor = false;
            this.SetGrindDefaultsBtn.Click += new System.EventHandler(this.SetGrindDefaultsBtn_Click);
            // 
            // SetGrindAccelBtn
            // 
            this.SetGrindAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindAccelBtn.Location = new System.Drawing.Point(275, 39);
            this.SetGrindAccelBtn.Name = "SetGrindAccelBtn";
            this.SetGrindAccelBtn.Size = new System.Drawing.Size(243, 130);
            this.SetGrindAccelBtn.TabIndex = 120;
            this.SetGrindAccelBtn.Text = "Set Acceleration";
            this.SetGrindAccelBtn.UseVisualStyleBackColor = false;
            this.SetGrindAccelBtn.Click += new System.EventHandler(this.SetGrindAccelBtn_Click);
            // 
            // SetTrialSpeedBtn
            // 
            this.SetTrialSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetTrialSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTrialSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetTrialSpeedBtn.Location = new System.Drawing.Point(15, 39);
            this.SetTrialSpeedBtn.Name = "SetTrialSpeedBtn";
            this.SetTrialSpeedBtn.Size = new System.Drawing.Size(243, 130);
            this.SetTrialSpeedBtn.TabIndex = 119;
            this.SetTrialSpeedBtn.Text = "Set Trial Speed";
            this.SetTrialSpeedBtn.UseVisualStyleBackColor = false;
            this.SetTrialSpeedBtn.Click += new System.EventHandler(this.SetTrialSpeedBtn_Click);
            // 
            // SetMaxGrindBlendRadiusBtn
            // 
            this.SetMaxGrindBlendRadiusBtn.BackColor = System.Drawing.Color.Green;
            this.SetMaxGrindBlendRadiusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMaxGrindBlendRadiusBtn.ForeColor = System.Drawing.Color.White;
            this.SetMaxGrindBlendRadiusBtn.Location = new System.Drawing.Point(535, 39);
            this.SetMaxGrindBlendRadiusBtn.Name = "SetMaxGrindBlendRadiusBtn";
            this.SetMaxGrindBlendRadiusBtn.Size = new System.Drawing.Size(243, 130);
            this.SetMaxGrindBlendRadiusBtn.TabIndex = 118;
            this.SetMaxGrindBlendRadiusBtn.Text = "Set Max Blend Radius";
            this.SetMaxGrindBlendRadiusBtn.UseVisualStyleBackColor = false;
            this.SetMaxGrindBlendRadiusBtn.Click += new System.EventHandler(this.SetMaxGrindBlendRadiusBtn_Click);
            // 
            // SetMaxWaitBtn
            // 
            this.SetMaxWaitBtn.BackColor = System.Drawing.Color.Green;
            this.SetMaxWaitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMaxWaitBtn.ForeColor = System.Drawing.Color.White;
            this.SetMaxWaitBtn.Location = new System.Drawing.Point(1575, 39);
            this.SetMaxWaitBtn.Name = "SetMaxWaitBtn";
            this.SetMaxWaitBtn.Size = new System.Drawing.Size(243, 130);
            this.SetMaxWaitBtn.TabIndex = 117;
            this.SetMaxWaitBtn.Text = "Set Max Wait";
            this.SetMaxWaitBtn.UseVisualStyleBackColor = false;
            this.SetMaxWaitBtn.Click += new System.EventHandler(this.SetMaxWaitBtn_Click);
            // 
            // SetForceDwellBtn
            // 
            this.SetForceDwellBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceDwellBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceDwellBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceDwellBtn.Location = new System.Drawing.Point(1315, 39);
            this.SetForceDwellBtn.Name = "SetForceDwellBtn";
            this.SetForceDwellBtn.Size = new System.Drawing.Size(243, 130);
            this.SetForceDwellBtn.TabIndex = 116;
            this.SetForceDwellBtn.Text = "Set Force Dwell";
            this.SetForceDwellBtn.UseVisualStyleBackColor = false;
            this.SetForceDwellBtn.Click += new System.EventHandler(this.SetForceDwellBtn_Click);
            // 
            // SetTouchSpeedBtn
            // 
            this.SetTouchSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetTouchSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTouchSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetTouchSpeedBtn.Location = new System.Drawing.Point(795, 39);
            this.SetTouchSpeedBtn.Name = "SetTouchSpeedBtn";
            this.SetTouchSpeedBtn.Size = new System.Drawing.Size(243, 130);
            this.SetTouchSpeedBtn.TabIndex = 115;
            this.SetTouchSpeedBtn.Text = "Set Touch Speed";
            this.SetTouchSpeedBtn.UseVisualStyleBackColor = false;
            this.SetTouchSpeedBtn.Click += new System.EventHandler(this.SetTouchSpeedBtn_Click);
            // 
            // SetTouchRetractBtn
            // 
            this.SetTouchRetractBtn.BackColor = System.Drawing.Color.Green;
            this.SetTouchRetractBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTouchRetractBtn.ForeColor = System.Drawing.Color.White;
            this.SetTouchRetractBtn.Location = new System.Drawing.Point(1055, 39);
            this.SetTouchRetractBtn.Name = "SetTouchRetractBtn";
            this.SetTouchRetractBtn.Size = new System.Drawing.Size(243, 130);
            this.SetTouchRetractBtn.TabIndex = 114;
            this.SetTouchRetractBtn.Text = "Set Touch Retract";
            this.SetTouchRetractBtn.UseVisualStyleBackColor = false;
            this.SetTouchRetractBtn.Click += new System.EventHandler(this.SetTouchRetractBtn_Click);
            // 
            // ToolSetupGrp
            // 
            this.ToolSetupGrp.Controls.Add(this.CoolantOffBtn);
            this.ToolSetupGrp.Controls.Add(this.CoolantTestBtn);
            this.ToolSetupGrp.Controls.Add(this.ToolOffBtn);
            this.ToolSetupGrp.Controls.Add(this.ToolTestBtn);
            this.ToolSetupGrp.Controls.Add(this.DoorClosedInputLbl);
            this.ToolSetupGrp.Controls.Add(this.FootswitchPressedInputLbl);
            this.ToolSetupGrp.Controls.Add(this.FootswitchPressedInputTxt);
            this.ToolSetupGrp.Controls.Add(this.SetFootswitchPressedInputBtn);
            this.ToolSetupGrp.Controls.Add(this.JointMoveMountBtn);
            this.ToolSetupGrp.Controls.Add(this.JointMoveHomeBtn);
            this.ToolSetupGrp.Controls.Add(this.DoorClosedInputTxt);
            this.ToolSetupGrp.Controls.Add(this.SetDoorClosedInputBtn);
            this.ToolSetupGrp.Controls.Add(this.SelectToolBtn);
            this.ToolSetupGrp.Controls.Add(this.ToolsGrd);
            this.ToolSetupGrp.Controls.Add(this.LoadToolsBtn);
            this.ToolSetupGrp.Controls.Add(this.SaveToolsBtn);
            this.ToolSetupGrp.Controls.Add(this.ClearToolsBtn);
            this.ToolSetupGrp.Location = new System.Drawing.Point(3, 3);
            this.ToolSetupGrp.Name = "ToolSetupGrp";
            this.ToolSetupGrp.Size = new System.Drawing.Size(2112, 475);
            this.ToolSetupGrp.TabIndex = 101;
            this.ToolSetupGrp.TabStop = false;
            this.ToolSetupGrp.Text = "Tools";
            // 
            // CoolantOffBtn
            // 
            this.CoolantOffBtn.BackColor = System.Drawing.Color.Green;
            this.CoolantOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoolantOffBtn.ForeColor = System.Drawing.Color.White;
            this.CoolantOffBtn.Location = new System.Drawing.Point(784, 367);
            this.CoolantOffBtn.Name = "CoolantOffBtn";
            this.CoolantOffBtn.Size = new System.Drawing.Size(82, 96);
            this.CoolantOffBtn.TabIndex = 128;
            this.CoolantOffBtn.Text = "Cool Off";
            this.CoolantOffBtn.UseVisualStyleBackColor = false;
            this.CoolantOffBtn.Click += new System.EventHandler(this.CoolantOffBtn_Click);
            // 
            // CoolantTestBtn
            // 
            this.CoolantTestBtn.BackColor = System.Drawing.Color.Green;
            this.CoolantTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoolantTestBtn.ForeColor = System.Drawing.Color.White;
            this.CoolantTestBtn.Location = new System.Drawing.Point(696, 367);
            this.CoolantTestBtn.Name = "CoolantTestBtn";
            this.CoolantTestBtn.Size = new System.Drawing.Size(82, 96);
            this.CoolantTestBtn.TabIndex = 127;
            this.CoolantTestBtn.Text = "Cool Test";
            this.CoolantTestBtn.UseVisualStyleBackColor = false;
            this.CoolantTestBtn.Click += new System.EventHandler(this.CoolantTestBtn_Click);
            // 
            // ToolOffBtn
            // 
            this.ToolOffBtn.BackColor = System.Drawing.Color.Green;
            this.ToolOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolOffBtn.ForeColor = System.Drawing.Color.White;
            this.ToolOffBtn.Location = new System.Drawing.Point(597, 367);
            this.ToolOffBtn.Name = "ToolOffBtn";
            this.ToolOffBtn.Size = new System.Drawing.Size(82, 96);
            this.ToolOffBtn.TabIndex = 126;
            this.ToolOffBtn.Text = "Tool Off";
            this.ToolOffBtn.UseVisualStyleBackColor = false;
            this.ToolOffBtn.Click += new System.EventHandler(this.ToolOffBtn_Click);
            // 
            // ToolTestBtn
            // 
            this.ToolTestBtn.BackColor = System.Drawing.Color.Green;
            this.ToolTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolTestBtn.ForeColor = System.Drawing.Color.White;
            this.ToolTestBtn.Location = new System.Drawing.Point(509, 367);
            this.ToolTestBtn.Name = "ToolTestBtn";
            this.ToolTestBtn.Size = new System.Drawing.Size(82, 96);
            this.ToolTestBtn.TabIndex = 125;
            this.ToolTestBtn.Text = "Tool Test";
            this.ToolTestBtn.UseVisualStyleBackColor = false;
            this.ToolTestBtn.Click += new System.EventHandler(this.ToolTestBtn_Click);
            // 
            // DoorClosedInputLbl
            // 
            this.DoorClosedInputLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoorClosedInputLbl.Location = new System.Drawing.Point(1987, 414);
            this.DoorClosedInputLbl.Name = "DoorClosedInputLbl";
            this.DoorClosedInputLbl.Size = new System.Drawing.Size(97, 49);
            this.DoorClosedInputLbl.TabIndex = 124;
            this.DoorClosedInputLbl.Text = "1,1";
            // 
            // FootswitchPressedInputLbl
            // 
            this.FootswitchPressedInputLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FootswitchPressedInputLbl.Location = new System.Drawing.Point(1650, 414);
            this.FootswitchPressedInputLbl.Name = "FootswitchPressedInputLbl";
            this.FootswitchPressedInputLbl.Size = new System.Drawing.Size(97, 49);
            this.FootswitchPressedInputLbl.TabIndex = 123;
            this.FootswitchPressedInputLbl.Text = "7,1";
            // 
            // FootswitchPressedInputTxt
            // 
            this.FootswitchPressedInputTxt.Location = new System.Drawing.Point(1650, 367);
            this.FootswitchPressedInputTxt.Name = "FootswitchPressedInputTxt";
            this.FootswitchPressedInputTxt.Size = new System.Drawing.Size(97, 44);
            this.FootswitchPressedInputTxt.TabIndex = 122;
            this.FootswitchPressedInputTxt.Text = "7,1";
            // 
            // SetFootswitchPressedInputBtn
            // 
            this.SetFootswitchPressedInputBtn.BackColor = System.Drawing.Color.Green;
            this.SetFootswitchPressedInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetFootswitchPressedInputBtn.ForeColor = System.Drawing.Color.White;
            this.SetFootswitchPressedInputBtn.Location = new System.Drawing.Point(1411, 367);
            this.SetFootswitchPressedInputBtn.Name = "SetFootswitchPressedInputBtn";
            this.SetFootswitchPressedInputBtn.Size = new System.Drawing.Size(233, 96);
            this.SetFootswitchPressedInputBtn.TabIndex = 121;
            this.SetFootswitchPressedInputBtn.Text = "Set Footswitch Pressed Input";
            this.SetFootswitchPressedInputBtn.UseVisualStyleBackColor = false;
            this.SetFootswitchPressedInputBtn.Click += new System.EventHandler(this.SetFootswitchInputBtn_Click);
            // 
            // JointMoveMountBtn
            // 
            this.JointMoveMountBtn.BackColor = System.Drawing.Color.Green;
            this.JointMoveMountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JointMoveMountBtn.ForeColor = System.Drawing.Color.White;
            this.JointMoveMountBtn.Location = new System.Drawing.Point(167, 367);
            this.JointMoveMountBtn.Name = "JointMoveMountBtn";
            this.JointMoveMountBtn.Size = new System.Drawing.Size(155, 96);
            this.JointMoveMountBtn.TabIndex = 120;
            this.JointMoveMountBtn.Text = "Joint Move to Mount";
            this.JointMoveMountBtn.UseVisualStyleBackColor = false;
            this.JointMoveMountBtn.Click += new System.EventHandler(this.JointMoveMountBtn_Click);
            // 
            // JointMoveHomeBtn
            // 
            this.JointMoveHomeBtn.BackColor = System.Drawing.Color.Green;
            this.JointMoveHomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JointMoveHomeBtn.ForeColor = System.Drawing.Color.White;
            this.JointMoveHomeBtn.Location = new System.Drawing.Point(328, 367);
            this.JointMoveHomeBtn.Name = "JointMoveHomeBtn";
            this.JointMoveHomeBtn.Size = new System.Drawing.Size(155, 96);
            this.JointMoveHomeBtn.TabIndex = 119;
            this.JointMoveHomeBtn.Text = "Joint Move to Home";
            this.JointMoveHomeBtn.UseVisualStyleBackColor = false;
            this.JointMoveHomeBtn.Click += new System.EventHandler(this.JointMoveHomeBtn_Click);
            // 
            // DoorClosedInputTxt
            // 
            this.DoorClosedInputTxt.Location = new System.Drawing.Point(1987, 367);
            this.DoorClosedInputTxt.Name = "DoorClosedInputTxt";
            this.DoorClosedInputTxt.Size = new System.Drawing.Size(97, 44);
            this.DoorClosedInputTxt.TabIndex = 118;
            this.DoorClosedInputTxt.Text = "1,1";
            // 
            // SetDoorClosedInputBtn
            // 
            this.SetDoorClosedInputBtn.BackColor = System.Drawing.Color.Green;
            this.SetDoorClosedInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetDoorClosedInputBtn.ForeColor = System.Drawing.Color.White;
            this.SetDoorClosedInputBtn.Location = new System.Drawing.Point(1776, 367);
            this.SetDoorClosedInputBtn.Name = "SetDoorClosedInputBtn";
            this.SetDoorClosedInputBtn.Size = new System.Drawing.Size(205, 96);
            this.SetDoorClosedInputBtn.TabIndex = 96;
            this.SetDoorClosedInputBtn.Text = "Set Door Closed Input";
            this.SetDoorClosedInputBtn.UseVisualStyleBackColor = false;
            this.SetDoorClosedInputBtn.Click += new System.EventHandler(this.SetDoorClosedInputBtn_Click);
            // 
            // SelectToolBtn
            // 
            this.SelectToolBtn.BackColor = System.Drawing.Color.Green;
            this.SelectToolBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectToolBtn.ForeColor = System.Drawing.Color.White;
            this.SelectToolBtn.Location = new System.Drawing.Point(6, 367);
            this.SelectToolBtn.Name = "SelectToolBtn";
            this.SelectToolBtn.Size = new System.Drawing.Size(155, 96);
            this.SelectToolBtn.TabIndex = 95;
            this.SelectToolBtn.Text = "Select";
            this.SelectToolBtn.UseVisualStyleBackColor = false;
            this.SelectToolBtn.Click += new System.EventHandler(this.SelectToolBtn_Click);
            // 
            // ToolsGrd
            // 
            this.ToolsGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ToolsGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolsGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ToolsGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ToolsGrd.DefaultCellStyle = dataGridViewCellStyle4;
            this.ToolsGrd.Location = new System.Drawing.Point(6, 43);
            this.ToolsGrd.Name = "ToolsGrd";
            this.ToolsGrd.RowTemplate.Height = 34;
            this.ToolsGrd.Size = new System.Drawing.Size(2100, 308);
            this.ToolsGrd.TabIndex = 85;
            // 
            // LoadToolsBtn
            // 
            this.LoadToolsBtn.BackColor = System.Drawing.Color.Green;
            this.LoadToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadToolsBtn.ForeColor = System.Drawing.Color.White;
            this.LoadToolsBtn.Location = new System.Drawing.Point(894, 367);
            this.LoadToolsBtn.Name = "LoadToolsBtn";
            this.LoadToolsBtn.Size = new System.Drawing.Size(155, 96);
            this.LoadToolsBtn.TabIndex = 94;
            this.LoadToolsBtn.Text = "Reload";
            this.LoadToolsBtn.UseVisualStyleBackColor = false;
            this.LoadToolsBtn.Click += new System.EventHandler(this.LoadToolsBtn_Click);
            // 
            // SaveToolsBtn
            // 
            this.SaveToolsBtn.BackColor = System.Drawing.Color.Green;
            this.SaveToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveToolsBtn.ForeColor = System.Drawing.Color.White;
            this.SaveToolsBtn.Location = new System.Drawing.Point(1055, 367);
            this.SaveToolsBtn.Name = "SaveToolsBtn";
            this.SaveToolsBtn.Size = new System.Drawing.Size(155, 96);
            this.SaveToolsBtn.TabIndex = 93;
            this.SaveToolsBtn.Text = "Save";
            this.SaveToolsBtn.UseVisualStyleBackColor = false;
            this.SaveToolsBtn.Click += new System.EventHandler(this.SaveToolsBtn_Click);
            // 
            // ClearToolsBtn
            // 
            this.ClearToolsBtn.BackColor = System.Drawing.Color.Green;
            this.ClearToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearToolsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearToolsBtn.Location = new System.Drawing.Point(1218, 367);
            this.ClearToolsBtn.Name = "ClearToolsBtn";
            this.ClearToolsBtn.Size = new System.Drawing.Size(155, 96);
            this.ClearToolsBtn.TabIndex = 92;
            this.ClearToolsBtn.Text = "Clear";
            this.ClearToolsBtn.UseVisualStyleBackColor = false;
            this.ClearToolsBtn.Click += new System.EventHandler(this.ClearToolsBtn_Click);
            // 
            // GeneralConfigGrp
            // 
            this.GeneralConfigGrp.Controls.Add(this.SaveConfigBtn);
            this.GeneralConfigGrp.Controls.Add(this.AllowRunningOfflineChk);
            this.GeneralConfigGrp.Controls.Add(this.label4);
            this.GeneralConfigGrp.Controls.Add(this.RobotProgramTxt);
            this.GeneralConfigGrp.Controls.Add(this.LoadConfigBtn);
            this.GeneralConfigGrp.Controls.Add(this.DefaultConfigBtn);
            this.GeneralConfigGrp.Controls.Add(this.ServerIpTxt);
            this.GeneralConfigGrp.Controls.Add(this.label2);
            this.GeneralConfigGrp.Controls.Add(this.RobotIpTxt);
            this.GeneralConfigGrp.Controls.Add(this.label3);
            this.GeneralConfigGrp.Controls.Add(this.LEonardRootLbl);
            this.GeneralConfigGrp.Controls.Add(this.ChangeRootDirectoryBtn);
            this.GeneralConfigGrp.Controls.Add(this.label1);
            this.GeneralConfigGrp.Location = new System.Drawing.Point(3, 492);
            this.GeneralConfigGrp.Margin = new System.Windows.Forms.Padding(2);
            this.GeneralConfigGrp.Name = "GeneralConfigGrp";
            this.GeneralConfigGrp.Padding = new System.Windows.Forms.Padding(2);
            this.GeneralConfigGrp.Size = new System.Drawing.Size(1180, 320);
            this.GeneralConfigGrp.TabIndex = 96;
            this.GeneralConfigGrp.TabStop = false;
            this.GeneralConfigGrp.Text = "General Configuration";
            // 
            // SaveConfigBtn
            // 
            this.SaveConfigBtn.BackColor = System.Drawing.Color.Green;
            this.SaveConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveConfigBtn.ForeColor = System.Drawing.Color.White;
            this.SaveConfigBtn.Location = new System.Drawing.Point(852, 223);
            this.SaveConfigBtn.Name = "SaveConfigBtn";
            this.SaveConfigBtn.Size = new System.Drawing.Size(157, 86);
            this.SaveConfigBtn.TabIndex = 100;
            this.SaveConfigBtn.Text = "Save";
            this.SaveConfigBtn.UseVisualStyleBackColor = false;
            this.SaveConfigBtn.Click += new System.EventHandler(this.SaveConfigBtn_Click);
            // 
            // AllowRunningOfflineChk
            // 
            this.AllowRunningOfflineChk.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllowRunningOfflineChk.AutoSize = true;
            this.AllowRunningOfflineChk.BackColor = System.Drawing.Color.Gray;
            this.AllowRunningOfflineChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllowRunningOfflineChk.ForeColor = System.Drawing.Color.White;
            this.AllowRunningOfflineChk.Location = new System.Drawing.Point(847, 173);
            this.AllowRunningOfflineChk.Name = "AllowRunningOfflineChk";
            this.AllowRunningOfflineChk.Size = new System.Drawing.Size(325, 43);
            this.AllowRunningOfflineChk.TabIndex = 89;
            this.AllowRunningOfflineChk.Text = "Allow Running Offline";
            this.AllowRunningOfflineChk.UseMnemonic = false;
            this.AllowRunningOfflineChk.UseVisualStyleBackColor = false;
            this.AllowRunningOfflineChk.CheckedChanged += new System.EventHandler(this.AllowRunningOfflineChk_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 37);
            this.label4.TabIndex = 88;
            this.label4.Text = "Robot Program to Load";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RobotProgramTxt
            // 
            this.RobotProgramTxt.Location = new System.Drawing.Point(397, 113);
            this.RobotProgramTxt.Name = "RobotProgramTxt";
            this.RobotProgramTxt.Size = new System.Drawing.Size(606, 44);
            this.RobotProgramTxt.TabIndex = 87;
            // 
            // LoadConfigBtn
            // 
            this.LoadConfigBtn.BackColor = System.Drawing.Color.Green;
            this.LoadConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadConfigBtn.ForeColor = System.Drawing.Color.White;
            this.LoadConfigBtn.Location = new System.Drawing.Point(679, 223);
            this.LoadConfigBtn.Name = "LoadConfigBtn";
            this.LoadConfigBtn.Size = new System.Drawing.Size(157, 86);
            this.LoadConfigBtn.TabIndex = 98;
            this.LoadConfigBtn.Text = "Reload";
            this.LoadConfigBtn.UseVisualStyleBackColor = false;
            this.LoadConfigBtn.Click += new System.EventHandler(this.LoadConfigBtn_Click);
            // 
            // DefaultConfigBtn
            // 
            this.DefaultConfigBtn.BackColor = System.Drawing.Color.Green;
            this.DefaultConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultConfigBtn.ForeColor = System.Drawing.Color.White;
            this.DefaultConfigBtn.Location = new System.Drawing.Point(1015, 223);
            this.DefaultConfigBtn.Name = "DefaultConfigBtn";
            this.DefaultConfigBtn.Size = new System.Drawing.Size(157, 86);
            this.DefaultConfigBtn.TabIndex = 99;
            this.DefaultConfigBtn.Text = "Restore Defaults";
            this.DefaultConfigBtn.UseVisualStyleBackColor = false;
            this.DefaultConfigBtn.Click += new System.EventHandler(this.DefaultConfigBtn_Click);
            // 
            // ServerIpTxt
            // 
            this.ServerIpTxt.Location = new System.Drawing.Point(397, 173);
            this.ServerIpTxt.Name = "ServerIpTxt";
            this.ServerIpTxt.Size = new System.Drawing.Size(267, 44);
            this.ServerIpTxt.TabIndex = 79;
            this.ServerIpTxt.Text = "192.168.0.253";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(173, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 42);
            this.label2.TabIndex = 78;
            this.label2.Text = "UR Robot IP Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RobotIpTxt
            // 
            this.RobotIpTxt.Location = new System.Drawing.Point(397, 223);
            this.RobotIpTxt.Name = "RobotIpTxt";
            this.RobotIpTxt.Size = new System.Drawing.Size(267, 44);
            this.RobotIpTxt.TabIndex = 72;
            this.RobotIpTxt.Text = "192.168.0.2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(73, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 40);
            this.label3.TabIndex = 71;
            this.label3.Text = "Local IP for Server";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LEonardRootLbl
            // 
            this.LEonardRootLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LEonardRootLbl.Location = new System.Drawing.Point(397, 57);
            this.LEonardRootLbl.Name = "LEonardRootLbl";
            this.LEonardRootLbl.Size = new System.Drawing.Size(606, 46);
            this.LEonardRootLbl.TabIndex = 69;
            this.LEonardRootLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChangeRootDirectoryBtn
            // 
            this.ChangeRootDirectoryBtn.Location = new System.Drawing.Point(1009, 57);
            this.ChangeRootDirectoryBtn.Name = "ChangeRootDirectoryBtn";
            this.ChangeRootDirectoryBtn.Size = new System.Drawing.Size(60, 46);
            this.ChangeRootDirectoryBtn.TabIndex = 70;
            this.ChangeRootDirectoryBtn.Text = "...";
            this.ChangeRootDirectoryBtn.UseVisualStyleBackColor = true;
            this.ChangeRootDirectoryBtn.Click += new System.EventHandler(this.ChangeRootDirectoryBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 37);
            this.label1.TabIndex = 68;
            this.label1.Text = "LEonard Root Directory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogPage
            // 
            this.LogPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogPage.Controls.Add(this.tableLayoutPanel1);
            this.LogPage.Location = new System.Drawing.Point(4, 100);
            this.LogPage.Name = "LogPage";
            this.LogPage.Size = new System.Drawing.Size(2132, 1168);
            this.LogPage.TabIndex = 5;
            this.LogPage.Text = "Log";
            this.LogPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2128, 1164);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.AboutBtn);
            this.groupBox1.Controls.Add(this.ClearAllLogRtbBtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1386, 933);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 228);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.LogLevelCombo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 118);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Level";
            // 
            // LogLevelCombo
            // 
            this.LogLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogLevelCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLevelCombo.FormattingEnabled = true;
            this.LogLevelCombo.Items.AddRange(new object[] {
            "Error",
            "Warn",
            "Info",
            "Debug",
            "Trace"});
            this.LogLevelCombo.Location = new System.Drawing.Point(23, 43);
            this.LogLevelCombo.Name = "LogLevelCombo";
            this.LogLevelCombo.Size = new System.Drawing.Size(291, 50);
            this.LogLevelCombo.TabIndex = 0;
            this.LogLevelCombo.SelectedIndexChanged += new System.EventHandler(this.DebugLevelCombo_SelectedIndexChanged);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutBtn.BackColor = System.Drawing.Color.Green;
            this.AboutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutBtn.ForeColor = System.Drawing.Color.White;
            this.AboutBtn.Location = new System.Drawing.Point(589, 104);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(142, 116);
            this.AboutBtn.TabIndex = 6;
            this.AboutBtn.Text = "About";
            this.AboutBtn.UseVisualStyleBackColor = false;
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // ClearAllLogRtbBtn
            // 
            this.ClearAllLogRtbBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearAllLogRtbBtn.BackColor = System.Drawing.Color.Green;
            this.ClearAllLogRtbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllLogRtbBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllLogRtbBtn.Location = new System.Drawing.Point(358, 104);
            this.ClearAllLogRtbBtn.Name = "ClearAllLogRtbBtn";
            this.ClearAllLogRtbBtn.Size = new System.Drawing.Size(161, 116);
            this.ClearAllLogRtbBtn.TabIndex = 5;
            this.ClearAllLogRtbBtn.Text = "Clear All";
            this.ClearAllLogRtbBtn.UseVisualStyleBackColor = false;
            this.ClearAllLogRtbBtn.Click += new System.EventHandler(this.ClearAllLogRtbBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.UrLogRTB);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1386, 468);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(739, 459);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Robot Commands and Responses";
            // 
            // UrLogRTB
            // 
            this.UrLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrLogRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrLogRTB.Location = new System.Drawing.Point(3, 25);
            this.UrLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.UrLogRTB.MaxLength = 1000000;
            this.UrLogRTB.Name = "UrLogRTB";
            this.UrLogRTB.ReadOnly = true;
            this.UrLogRTB.Size = new System.Drawing.Size(733, 431);
            this.UrLogRTB.TabIndex = 0;
            this.UrLogRTB.Text = "";
            this.UrLogRTB.WordWrap = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ExecLogRTB);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(3, 468);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1377, 459);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Recipe Execution Messages";
            // 
            // ExecLogRTB
            // 
            this.ExecLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecLogRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecLogRTB.Location = new System.Drawing.Point(3, 25);
            this.ExecLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.ExecLogRTB.MaxLength = 1000000;
            this.ExecLogRTB.Name = "ExecLogRTB";
            this.ExecLogRTB.ReadOnly = true;
            this.ExecLogRTB.Size = new System.Drawing.Size(1371, 431);
            this.ExecLogRTB.TabIndex = 0;
            this.ExecLogRTB.Text = "";
            this.ExecLogRTB.WordWrap = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ErrorLogRTB);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 933);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1377, 228);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Errors and Warnings";
            // 
            // ErrorLogRTB
            // 
            this.ErrorLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorLogRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLogRTB.Location = new System.Drawing.Point(3, 25);
            this.ErrorLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorLogRTB.MaxLength = 1000000;
            this.ErrorLogRTB.Name = "ErrorLogRTB";
            this.ErrorLogRTB.ReadOnly = true;
            this.ErrorLogRTB.Size = new System.Drawing.Size(1371, 200);
            this.ErrorLogRTB.TabIndex = 0;
            this.ErrorLogRTB.Text = "";
            this.ErrorLogRTB.WordWrap = false;
            this.ErrorLogRTB.DoubleClick += new System.EventHandler(this.ErrorLogRTB_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.UrDashboardLogRTB);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1386, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(739, 459);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Robot Dashboard Server";
            // 
            // UrDashboardLogRTB
            // 
            this.UrDashboardLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrDashboardLogRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrDashboardLogRTB.Location = new System.Drawing.Point(3, 25);
            this.UrDashboardLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.UrDashboardLogRTB.MaxLength = 1000000;
            this.UrDashboardLogRTB.Name = "UrDashboardLogRTB";
            this.UrDashboardLogRTB.ReadOnly = true;
            this.UrDashboardLogRTB.Size = new System.Drawing.Size(733, 431);
            this.UrDashboardLogRTB.TabIndex = 0;
            this.UrDashboardLogRTB.Text = "";
            this.UrDashboardLogRTB.WordWrap = false;
            this.UrDashboardLogRTB.DoubleClick += new System.EventHandler(this.UrDashboardLogRTB_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AllLogRTB);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1377, 459);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "All Log Messages (Double-click to clear any of these)";
            // 
            // AllLogRTB
            // 
            this.AllLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllLogRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllLogRTB.Location = new System.Drawing.Point(3, 25);
            this.AllLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.AllLogRTB.MaxLength = 1000000;
            this.AllLogRTB.Name = "AllLogRTB";
            this.AllLogRTB.ReadOnly = true;
            this.AllLogRTB.Size = new System.Drawing.Size(1371, 431);
            this.AllLogRTB.TabIndex = 0;
            this.AllLogRTB.Text = "";
            this.AllLogRTB.WordWrap = false;
            // 
            // UiPage
            // 
            this.UiPage.Controls.Add(this.UiDefaultBtn);
            this.UiPage.Controls.Add(this.label23);
            this.UiPage.Controls.Add(this.label20);
            this.UiPage.Controls.Add(this.UiFixedHeightTxt);
            this.UiPage.Controls.Add(this.UiFixedWidthTxt);
            this.UiPage.Controls.Add(this.UiFreeBtn);
            this.UiPage.Controls.Add(this.UiFixedBtn);
            this.UiPage.Location = new System.Drawing.Point(4, 100);
            this.UiPage.Name = "UiPage";
            this.UiPage.Size = new System.Drawing.Size(2132, 1168);
            this.UiPage.TabIndex = 6;
            this.UiPage.Text = "UIcon";
            this.UiPage.UseVisualStyleBackColor = true;
            // 
            // UiDefaultBtn
            // 
            this.UiDefaultBtn.Location = new System.Drawing.Point(34, 22);
            this.UiDefaultBtn.Name = "UiDefaultBtn";
            this.UiDefaultBtn.Size = new System.Drawing.Size(189, 84);
            this.UiDefaultBtn.TabIndex = 6;
            this.UiDefaultBtn.Text = "Default";
            this.UiDefaultBtn.UseVisualStyleBackColor = true;
            this.UiDefaultBtn.Click += new System.EventHandler(this.UiDefaultBtn_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(369, 112);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(109, 37);
            this.label23.TabIndex = 5;
            this.label23.Text = "Height";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(244, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 37);
            this.label20.TabIndex = 4;
            this.label20.Text = "Width";
            // 
            // UiFixedHeightTxt
            // 
            this.UiFixedHeightTxt.Location = new System.Drawing.Point(367, 152);
            this.UiFixedHeightTxt.Name = "UiFixedHeightTxt";
            this.UiFixedHeightTxt.Size = new System.Drawing.Size(100, 44);
            this.UiFixedHeightTxt.TabIndex = 3;
            this.UiFixedHeightTxt.Text = "1440";
            // 
            // UiFixedWidthTxt
            // 
            this.UiFixedWidthTxt.Location = new System.Drawing.Point(244, 152);
            this.UiFixedWidthTxt.Name = "UiFixedWidthTxt";
            this.UiFixedWidthTxt.Size = new System.Drawing.Size(100, 44);
            this.UiFixedWidthTxt.TabIndex = 2;
            this.UiFixedWidthTxt.Text = "2160";
            // 
            // UiFreeBtn
            // 
            this.UiFreeBtn.Location = new System.Drawing.Point(34, 202);
            this.UiFreeBtn.Name = "UiFreeBtn";
            this.UiFreeBtn.Size = new System.Drawing.Size(189, 84);
            this.UiFreeBtn.TabIndex = 1;
            this.UiFreeBtn.Text = "Free";
            this.UiFreeBtn.UseVisualStyleBackColor = true;
            this.UiFreeBtn.Click += new System.EventHandler(this.UiFreeBtn_Click);
            // 
            // UiFixedBtn
            // 
            this.UiFixedBtn.Location = new System.Drawing.Point(34, 112);
            this.UiFixedBtn.Name = "UiFixedBtn";
            this.UiFixedBtn.Size = new System.Drawing.Size(189, 84);
            this.UiFixedBtn.TabIndex = 0;
            this.UiFixedBtn.Text = "Fixed";
            this.UiFixedBtn.UseVisualStyleBackColor = true;
            this.UiFixedBtn.Click += new System.EventHandler(this.UiFixedBtn_Click);
            // 
            // JogRunBtn
            // 
            this.JogRunBtn.BackColor = System.Drawing.Color.Green;
            this.JogRunBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JogRunBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JogRunBtn.ForeColor = System.Drawing.Color.White;
            this.JogRunBtn.Location = new System.Drawing.Point(894, 2);
            this.JogRunBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JogRunBtn.Name = "JogRunBtn";
            this.JogRunBtn.Size = new System.Drawing.Size(175, 94);
            this.JogRunBtn.TabIndex = 5;
            this.JogRunBtn.Text = "Jog Robot";
            this.JogRunBtn.UseVisualStyleBackColor = false;
            this.JogRunBtn.Click += new System.EventHandler(this.JogRunBtn_Click);
            // 
            // DiameterLbl
            // 
            this.DiameterLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiameterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiameterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiameterLbl.Location = new System.Drawing.Point(3, 0);
            this.DiameterLbl.Name = "DiameterLbl";
            this.DiameterLbl.Size = new System.Drawing.Size(206, 59);
            this.DiameterLbl.TabIndex = 9;
            this.DiameterLbl.Text = "25.0";
            this.DiameterLbl.Click += new System.EventHandler(this.DiameterLbl_Click);
            // 
            // PartGeometryBox
            // 
            this.PartGeometryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartGeometryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartGeometryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartGeometryBox.FormattingEnabled = true;
            this.PartGeometryBox.Items.AddRange(new object[] {
            "FLAT",
            "CYLINDER",
            "SPHERE"});
            this.PartGeometryBox.Location = new System.Drawing.Point(3, 3);
            this.PartGeometryBox.Name = "PartGeometryBox";
            this.PartGeometryBox.Size = new System.Drawing.Size(308, 63);
            this.PartGeometryBox.TabIndex = 7;
            this.PartGeometryBox.SelectedIndexChanged += new System.EventHandler(this.PartGeometryBox_SelectedIndexChanged);
            // 
            // DoorClosedLbl
            // 
            this.DoorClosedLbl.BackColor = System.Drawing.Color.Gray;
            this.DoorClosedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoorClosedLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoorClosedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorClosedLbl.ForeColor = System.Drawing.Color.White;
            this.DoorClosedLbl.Location = new System.Drawing.Point(1073, 0);
            this.DoorClosedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DoorClosedLbl.Name = "DoorClosedLbl";
            this.DoorClosedLbl.Size = new System.Drawing.Size(175, 98);
            this.DoorClosedLbl.TabIndex = 6;
            this.DoorClosedLbl.Text = "Door Closed?";
            this.DoorClosedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionLbl
            // 
            this.DiamVersionLayoutPanel.SetColumnSpan(this.VersionLbl, 2);
            this.VersionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.Location = new System.Drawing.Point(3, 73);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(419, 29);
            this.VersionLbl.TabIndex = 10;
            this.VersionLbl.Text = "VersionLbl";
            this.VersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FootswitchPressedLbl
            // 
            this.FootswitchPressedLbl.BackColor = System.Drawing.Color.Gray;
            this.FootswitchPressedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FootswitchPressedLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FootswitchPressedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FootswitchPressedLbl.ForeColor = System.Drawing.Color.White;
            this.FootswitchPressedLbl.Location = new System.Drawing.Point(1252, 0);
            this.FootswitchPressedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FootswitchPressedLbl.Name = "FootswitchPressedLbl";
            this.FootswitchPressedLbl.Size = new System.Drawing.Size(168, 98);
            this.FootswitchPressedLbl.TabIndex = 8;
            this.FootswitchPressedLbl.Text = "Pedal Pressed?";
            this.FootswitchPressedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Time2Lbl
            // 
            this.Time2Lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiamVersionLayoutPanel.SetColumnSpan(this.Time2Lbl, 2);
            this.Time2Lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Time2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time2Lbl.Location = new System.Drawing.Point(2, 102);
            this.Time2Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Time2Lbl.Name = "Time2Lbl";
            this.Time2Lbl.Size = new System.Drawing.Size(421, 31);
            this.Time2Lbl.TabIndex = 11;
            this.Time2Lbl.Text = "Time";
            this.Time2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BottomButtonLayoutPanel
            // 
            this.BottomButtonLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomButtonLayoutPanel.ColumnCount = 8;
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.BottomButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.BottomButtonLayoutPanel.Controls.Add(this.StartBtn, 0, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.GrindContactEnabledBtn, 4, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.StopBtn, 3, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.StepBtn, 1, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.PauseBtn, 2, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.tableLayoutPanel3, 5, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.tableLayoutPanel4, 6, 0);
            this.BottomButtonLayoutPanel.Controls.Add(this.DiamVersionLayoutPanel, 7, 0);
            this.BottomButtonLayoutPanel.Location = new System.Drawing.Point(8, 1289);
            this.BottomButtonLayoutPanel.Name = "BottomButtonLayoutPanel";
            this.BottomButtonLayoutPanel.RowCount = 1;
            this.BottomButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomButtonLayoutPanel.Size = new System.Drawing.Size(2136, 139);
            this.BottomButtonLayoutPanel.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.MountedToolBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1068, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 133);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.PartGeometryBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1388, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(314, 133);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // DiamVersionLayoutPanel
            // 
            this.DiamVersionLayoutPanel.ColumnCount = 2;
            this.DiamVersionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DiamVersionLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DiamVersionLayoutPanel.Controls.Add(this.DiameterLbl, 0, 0);
            this.DiamVersionLayoutPanel.Controls.Add(this.DiameterDimLbl, 1, 0);
            this.DiamVersionLayoutPanel.Controls.Add(this.Time2Lbl, 0, 3);
            this.DiamVersionLayoutPanel.Controls.Add(this.VersionLbl, 0, 2);
            this.DiamVersionLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiamVersionLayoutPanel.Location = new System.Drawing.Point(1708, 3);
            this.DiamVersionLayoutPanel.Name = "DiamVersionLayoutPanel";
            this.DiamVersionLayoutPanel.RowCount = 4;
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.DiamVersionLayoutPanel.Size = new System.Drawing.Size(425, 133);
            this.DiamVersionLayoutPanel.TabIndex = 7;
            // 
            // TopButtonLayoutPanel
            // 
            this.TopButtonLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopButtonLayoutPanel.ColumnCount = 8;
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2472F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.78652F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.78652F));
            this.TopButtonLayoutPanel.Controls.Add(this.LoadRecipeBtn, 0, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.FootswitchPressedLbl, 6, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.NewRecipeBtn, 1, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.DoorClosedLbl, 5, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.JogRunBtn, 4, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.SaveRecipeBtn, 2, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.SaveAsRecipeBtn, 3, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.ExitBtn, 7, 0);
            this.TopButtonLayoutPanel.Location = new System.Drawing.Point(548, 7);
            this.TopButtonLayoutPanel.Name = "TopButtonLayoutPanel";
            this.TopButtonLayoutPanel.RowCount = 1;
            this.TopButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopButtonLayoutPanel.Size = new System.Drawing.Size(1600, 98);
            this.TopButtonLayoutPanel.TabIndex = 14;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Gray;
            this.ExitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.Location = new System.Drawing.Point(1424, 2);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(174, 94);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2160, 1440);
            this.ControlBox = false;
            this.Controls.Add(this.TopButtonLayoutPanel);
            this.Controls.Add(this.BottomButtonLayoutPanel);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Code Sets This Caption";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MonitorTab.ResumeLayout(false);
            this.positionsPage.ResumeLayout(false);
            this.PositionLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PositionsGrd)).EndInit();
            this.variablesPage.ResumeLayout(false);
            this.VariablesLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).EndInit();
            this.javaEnginePage.ResumeLayout(false);
            this.manualPage.ResumeLayout(false);
            this.ManualLayoutPanel.ResumeLayout(false);
            this.revhistPage.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.RunPage.ResumeLayout(false);
            this.RunTabLayoutPanel.ResumeLayout(false);
            this.StatusLayoutPanel.ResumeLayout(false);
            this.CommandCounterLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ProgramPage.ResumeLayout(false);
            this.ProgramTableLayoutPanel.ResumeLayout(false);
            this.FileBigEditPanel.ResumeLayout(false);
            this.SetupPage.ResumeLayout(false);
            this.DefaultMoveSetupGrp.ResumeLayout(false);
            this.GrindingMoveSetupGrp.ResumeLayout(false);
            this.ToolSetupGrp.ResumeLayout(false);
            this.ToolSetupGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGrd)).EndInit();
            this.GeneralConfigGrp.ResumeLayout(false);
            this.GeneralConfigGrp.PerformLayout();
            this.LogPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.UiPage.ResumeLayout(false);
            this.UiPage.PerformLayout();
            this.BottomButtonLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.DiamVersionLayoutPanel.ResumeLayout(false);
            this.DiamVersionLayoutPanel.PerformLayout();
            this.TopButtonLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer HeartbeatTmr;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Timer StartupTmr;
        private System.Windows.Forms.Timer CloseTmr;
        private System.Windows.Forms.Button SaveAsRecipeBtn;
        private System.Windows.Forms.Button NewRecipeBtn;
        private System.Windows.Forms.Button LoadRecipeBtn;
        private System.Windows.Forms.Button SaveRecipeBtn;
        private System.Windows.Forms.Button StepBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.RichTextBox RecipeRTB;
        private System.Windows.Forms.Timer ExecTmr;
        private System.Windows.Forms.Timer MessageTmr;
        private System.Windows.Forms.Label RobotCommandStatusLbl;
        private System.Windows.Forms.Label GrindReadyLbl;
        private System.Windows.Forms.Label RobotReadyLbl;
        private System.Windows.Forms.Button GrindContactEnabledBtn;
        private System.Windows.Forms.Label CurrentLineLbl;
        private System.Windows.Forms.TabControl MonitorTab;
        private System.Windows.Forms.TabPage variablesPage;
        private System.Windows.Forms.Button ClearAllVariablesBtn;
        private System.Windows.Forms.Button LoadVariablesBtn;
        private System.Windows.Forms.Button SaveVariablesBtn;
        private System.Windows.Forms.Button ClearVariablesBtn;
        private System.Windows.Forms.DataGridView VariablesGrd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox MountedToolBox;
        private System.Windows.Forms.TabPage positionsPage;
        private System.Windows.Forms.Button PositionMoveArmBtn;
        private System.Windows.Forms.Button PositionMovePoseBtn;
        private System.Windows.Forms.Button PositionSetBtn;
        private System.Windows.Forms.Button ClearAllPositionsBtn;
        private System.Windows.Forms.Button LoadPositionsBtn;
        private System.Windows.Forms.Button SavePositionsBtn;
        private System.Windows.Forms.Button ClearPositionsBtn;
        private System.Windows.Forms.DataGridView PositionsGrd;
        private System.Windows.Forms.ComboBox UserModeBox;
        private System.Windows.Forms.Label RecipeFilenameLbl;
        private System.Windows.Forms.RichTextBox RecipeCommandsRTB;
        private System.Windows.Forms.TabPage manualPage;
        private System.Windows.Forms.Button RobotModeBtn;
        private System.Windows.Forms.Button SafetyStatusBtn;
        private System.Windows.Forms.Button ProgramStateBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DiameterDimLbl;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage RunPage;
        private System.Windows.Forms.TabPage ProgramPage;
        private System.Windows.Forms.TabPage SetupPage;
        private System.Windows.Forms.GroupBox ToolSetupGrp;
        private System.Windows.Forms.Button SelectToolBtn;
        private System.Windows.Forms.DataGridView ToolsGrd;
        private System.Windows.Forms.Button LoadToolsBtn;
        private System.Windows.Forms.Button SaveToolsBtn;
        private System.Windows.Forms.Button ClearToolsBtn;
        private System.Windows.Forms.Button DefaultConfigBtn;
        private System.Windows.Forms.Button LoadConfigBtn;
        private System.Windows.Forms.GroupBox GeneralConfigGrp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RobotProgramTxt;
        private System.Windows.Forms.TextBox ServerIpTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RobotIpTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LEonardRootLbl;
        private System.Windows.Forms.Button ChangeRootDirectoryBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RobotConnectBtn;
        private System.Windows.Forms.ComboBox PartGeometryBox;
        private System.Windows.Forms.Label DiameterLbl;
        private System.Windows.Forms.Label RunStateLbl;
        private System.Windows.Forms.Label Grind;
        private System.Windows.Forms.Label GrindNCyclesLbl;
        private System.Windows.Forms.Label GrindCycleLbl;
        private System.Windows.Forms.Label CurrentLineLblCopy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox RecipeRTBCopy;
        private System.Windows.Forms.Button JogRunBtn;
        private System.Windows.Forms.Label RunStartedTimeLbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label RunElapsedTimeLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox DoorClosedInputTxt;
        private System.Windows.Forms.Button SetDoorClosedInputBtn;
        private System.Windows.Forms.Label DoorClosedLbl;
        private System.Windows.Forms.Label RobotCompletedLbl;
        private System.Windows.Forms.CheckBox AllowRunningOfflineChk;
        private System.Windows.Forms.GroupBox GrindingMoveSetupGrp;
        private System.Windows.Forms.Button SetForceDwellBtn;
        private System.Windows.Forms.Button SetTouchSpeedBtn;
        private System.Windows.Forms.Button SetTouchRetractBtn;
        private System.Windows.Forms.Label GrindProcessStateLbl;
        private System.Windows.Forms.Button JointMoveMountBtn;
        private System.Windows.Forms.Button JointMoveHomeBtn;
        private System.Windows.Forms.Button MoveToolMountBtn;
        private System.Windows.Forms.Button MoveToolHomeBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label StepElapsedTimeLbl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button SetMaxWaitBtn;
        private System.Windows.Forms.Button SetMaxGrindBlendRadiusBtn;
        private System.Windows.Forms.Button SetTrialSpeedBtn;
        private System.Windows.Forms.Label StepTimeEstimateLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label StepTimeRemainingLbl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label RobotSentLbl;
        private System.Windows.Forms.Button SetGrindAccelBtn;
        private System.Windows.Forms.GroupBox DefaultMoveSetupGrp;
        private System.Windows.Forms.Button SetLinearAccelBtn;
        private System.Windows.Forms.Button SetBlendRadiusBtn;
        private System.Windows.Forms.Button SetJointSpeedBtn;
        private System.Windows.Forms.Button SetJointAccelBtn;
        private System.Windows.Forms.Button SetLinearSpeedBtn;
        private System.Windows.Forms.Button JogBtn;
        private System.Windows.Forms.Button SetMoveDefaultsBtn;
        private System.Windows.Forms.Button SetGrindDefaultsBtn;
        private System.Windows.Forms.Button SaveConfigBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage revhistPage;
        private System.Windows.Forms.RichTextBox RevHistRTB;
        private System.Windows.Forms.Button FullManualBtn;
        private System.Windows.Forms.TextBox FootswitchPressedInputTxt;
        private System.Windows.Forms.Button SetFootswitchPressedInputBtn;
        private System.Windows.Forms.Label FootswitchPressedLbl;
        private System.Windows.Forms.Label DoorClosedInputLbl;
        private System.Windows.Forms.Label FootswitchPressedInputLbl;
        private System.Windows.Forms.Button ToolTestBtn;
        private System.Windows.Forms.Button CoolantOffBtn;
        private System.Windows.Forms.Button CoolantTestBtn;
        private System.Windows.Forms.Button ToolOffBtn;
        private System.Windows.Forms.Label RobotPolyscopeVersionLbl;
        private System.Windows.Forms.Label RobotSerialNumberLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label RobotModelLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label Time2Lbl;
        private System.Windows.Forms.Button SetPointFrequencyBtn;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label GrindForceReportZLbl;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BigEditBtn;
        private System.Windows.Forms.Button SetGrindJogSpeedBtn;
        private System.Windows.Forms.Button SetGrindJogAccelBtn;
        private System.Windows.Forms.Button SetForceModeDampingBtn;
        private System.Windows.Forms.Button SetForceModeGainScalingBtn;
        private System.Windows.Forms.Button GocatorConnectBtn;
        private System.Windows.Forms.Label GocatorReadyLbl;
        private System.Windows.Forms.TabPage UiPage;
        private System.Windows.Forms.Button UiFreeBtn;
        private System.Windows.Forms.Button UiFixedBtn;
        private System.Windows.Forms.TabPage LogPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox AllLogRTB;
        private System.Windows.Forms.Button ClearAllLogRtbBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox ErrorLogRTB;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox LogLevelCombo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox UrLogRTB;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RichTextBox ExecLogRTB;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox UrDashboardLogRTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel BottomButtonLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel TopButtonLayoutPanel;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TableLayoutPanel RunTabLayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage javaEnginePage;
        private System.Windows.Forms.TableLayoutPanel ProgramTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FileBigEditPanel;
        private System.Windows.Forms.TableLayoutPanel PositionLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel VariablesLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ManualLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel StatusLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel CommandCounterLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel DiamVersionLayoutPanel;
        private System.Windows.Forms.TextBox UiFixedHeightTxt;
        private System.Windows.Forms.TextBox UiFixedWidthTxt;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button UiDefaultBtn;
        private System.Windows.Forms.TabPage pythonEnginePage;
        private System.Windows.Forms.RichTextBox JavaScriptRTB;
        private System.Windows.Forms.Button JavaRunBtn;
    }
}

