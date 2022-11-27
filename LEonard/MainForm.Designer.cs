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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CurrentLineLbl = new System.Windows.Forms.Label();
            this.SequenceRTB = new System.Windows.Forms.RichTextBox();
            this.StepBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SequenceFilenameLbl = new System.Windows.Forms.Label();
            this.SaveSequenceAsBtn = new System.Windows.Forms.Button();
            this.NewSequenceBtn = new System.Windows.Forms.Button();
            this.LoadSequenceBtn = new System.Windows.Forms.Button();
            this.SaveSequenceBtn = new System.Windows.Forms.Button();
            this.HeartbeatTmr = new System.Windows.Forms.Timer(this.components);
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
            this.PositionMoveArmBtn = new System.Windows.Forms.Button();
            this.JogBtn = new System.Windows.Forms.Button();
            this.PositionSetBtn = new System.Windows.Forms.Button();
            this.variablesPage = new System.Windows.Forms.TabPage();
            this.VariablesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VariablesGrd = new System.Windows.Forms.DataGridView();
            this.ClearAllVariablesBtn = new System.Windows.Forms.Button();
            this.ClearVariablesBtn = new System.Windows.Forms.Button();
            this.javaEnginePage = new System.Windows.Forms.TabPage();
            this.JavaScreenLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.JavaFilenameLbl = new System.Windows.Forms.Label();
            this.JavaRunBtn = new System.Windows.Forms.Button();
            this.JavaNewBtn = new System.Windows.Forms.Button();
            this.JavaLoadBtn = new System.Windows.Forms.Button();
            this.JavaSaveBtn = new System.Windows.Forms.Button();
            this.JavaSaveAsBtn = new System.Windows.Forms.Button();
            this.JavaConsoleRTB = new System.Windows.Forms.RichTextBox();
            this.JavaVariablesRTB = new System.Windows.Forms.RichTextBox();
            this.JavaCodeRTB = new System.Windows.Forms.RichTextBox();
            this.JavaRestartBtn = new System.Windows.Forms.Button();
            this.pythonEnginePage = new System.Windows.Forms.TabPage();
            this.PythonScreenLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PythonFilenameLbl = new System.Windows.Forms.Label();
            this.PythonNewBtn = new System.Windows.Forms.Button();
            this.PythonLoadBtn = new System.Windows.Forms.Button();
            this.PythonSaveBtn = new System.Windows.Forms.Button();
            this.PythonSaveAsBtn = new System.Windows.Forms.Button();
            this.PythonConsoleRTB = new System.Windows.Forms.RichTextBox();
            this.PythonVariablesRTB = new System.Windows.Forms.RichTextBox();
            this.PythonCodeRTB = new System.Windows.Forms.RichTextBox();
            this.PythonRunBtn = new System.Windows.Forms.Button();
            this.PythonRestartBtn = new System.Windows.Forms.Button();
            this.manualPage = new System.Windows.Forms.TabPage();
            this.GocatorManualBtn = new System.Windows.Forms.Button();
            this.URManualBtn = new System.Windows.Forms.Button();
            this.FullManualBtn = new System.Windows.Forms.Button();
            this.MountedToolBoxLbl = new System.Windows.Forms.Label();
            this.MountedToolBox = new System.Windows.Forms.ComboBox();
            this.UserModeBox = new System.Windows.Forms.ComboBox();
            this.RobotModeBtn = new System.Windows.Forms.Button();
            this.RobotSafetyStatusBtn = new System.Windows.Forms.Button();
            this.RobotProgramStateBtn = new System.Windows.Forms.Button();
            this.PartGeometryBoxLbl = new System.Windows.Forms.Label();
            this.DiameterDimLbl = new System.Windows.Forms.Label();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.RunPage = new System.Windows.Forms.TabPage();
            this.RunTabLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.StatusLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.RobotConnectBtn = new System.Windows.Forms.Button();
            this.CommandCounterLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RobotSentLbl = new System.Windows.Forms.Label();
            this.RobotCompletedLbl = new System.Windows.Forms.Label();
            this.GrindProcessStateLbl = new System.Windows.Forms.Label();
            this.GocatorReadyLbl = new System.Windows.Forms.Label();
            this.GocatorConnectedLbl = new System.Windows.Forms.Label();
            this.SequenceRTBCopy = new System.Windows.Forms.RichTextBox();
            this.RunCenterColumnLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.MoveToolHomeBtn = new System.Windows.Forms.Button();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.MoveToolMountBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.RunStartedTimeLbl = new System.Windows.Forms.Label();
            this.RunElapsedTimeLbl = new System.Windows.Forms.Label();
            this.RunStateLbl = new System.Windows.Forms.Label();
            this.GrindLbl3 = new System.Windows.Forms.Label();
            this.CurrentLineLblCopy = new System.Windows.Forms.Label();
            this.GrindLbl1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.StepTimeRemainingLbl = new System.Windows.Forms.Label();
            this.StepElapsedTimeLbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.StepTimeEstimateLbl = new System.Windows.Forms.Label();
            this.GrindNofNLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GrindCycleLbl = new System.Windows.Forms.Label();
            this.GrindLbl2 = new System.Windows.Forms.Label();
            this.GrindNCyclesLbl = new System.Windows.Forms.Label();
            this.LastReportedZLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GrindForceReportZLbl = new System.Windows.Forms.Label();
            this.GrindLbl4 = new System.Windows.Forms.Label();
            this.MoveToolMountLbl = new System.Windows.Forms.Label();
            this.MoveToolHomeLbl = new System.Windows.Forms.Label();
            this.CodePage = new System.Windows.Forms.TabPage();
            this.ProgramTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileBigEditPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BigEditBtn = new System.Windows.Forms.Button();
            this.SetupPage = new System.Windows.Forms.TabPage();
            this.SetupTab = new System.Windows.Forms.TabControl();
            this.devicesPage = new System.Windows.Forms.TabPage();
            this.SetupDevicesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceReconnectBtn = new System.Windows.Forms.Button();
            this.DeviceConnectBtn = new System.Windows.Forms.Button();
            this.DeviceDisconnectBtn = new System.Windows.Forms.Button();
            this.DevicesGrd = new System.Windows.Forms.DataGridView();
            this.DeviceConnectAllBtn = new System.Windows.Forms.Button();
            this.DeviceDisconnectAllBtn = new System.Windows.Forms.Button();
            this.RuntimeAppHelperLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceRuntimeMinimizeBtn = new System.Windows.Forms.Button();
            this.DeviceRuntimeRestoreBtn = new System.Windows.Forms.Button();
            this.SetupAppHelperLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceSetupRestoreBtn = new System.Windows.Forms.Button();
            this.DeviceSetupMinimizeBtn = new System.Windows.Forms.Button();
            this.SetStartupDevicesFileBtn = new System.Windows.Forms.Button();
            this.ClearDevicesBtn = new System.Windows.Forms.Button();
            this.SaveAsDevicesBtn = new System.Windows.Forms.Button();
            this.SaveDevicesBtn = new System.Windows.Forms.Button();
            this.LoadDevicesBtn = new System.Windows.Forms.Button();
            this.ReloadDevicesBtn = new System.Windows.Forms.Button();
            this.AutoConnectOnLoadChk = new LEonard.MyCheckBox();
            this.speedBtnsGrp = new System.Windows.Forms.GroupBox();
            this.SpeedSendBtn1 = new System.Windows.Forms.Button();
            this.lbl4 = new System.Windows.Forms.Label();
            this.StartupDevicesLbl = new System.Windows.Forms.Label();
            this.DevicesFilenameLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RuntimeAppHelperLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceRuntimeExitBtn = new System.Windows.Forms.Button();
            this.DeviceRuntimeStartBtn = new System.Windows.Forms.Button();
            this.SetupAppHelperLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceSetupExitBtn = new System.Windows.Forms.Button();
            this.DeviceSetupStartBtn = new System.Windows.Forms.Button();
            this.displaysPage = new System.Windows.Forms.TabPage();
            this.SetupDisplayLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DisplaysGrd = new System.Windows.Forms.DataGridView();
            this.SelectDisplayBtn = new System.Windows.Forms.Button();
            this.LoadDisplaysBtn = new System.Windows.Forms.Button();
            this.SaveDisplaysBtn = new System.Windows.Forms.Button();
            this.ClearDisplaysButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedDisplayLbl = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.toolsPage = new System.Windows.Forms.TabPage();
            this.SetupToolsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SetDoorClosedInputBtn = new System.Windows.Forms.Button();
            this.SetFootswitchPressedInputBtn = new System.Windows.Forms.Button();
            this.FootswitchIoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FootswitchPressedInputTxt = new System.Windows.Forms.TextBox();
            this.FootswitchPressedInputLbl = new System.Windows.Forms.Label();
            this.DoorIoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DoorClosedInputLbl = new System.Windows.Forms.Label();
            this.DoorClosedInputTxt = new System.Windows.Forms.TextBox();
            this.ToolsGrd = new System.Windows.Forms.DataGridView();
            this.SelectToolBtn = new System.Windows.Forms.Button();
            this.JointMoveMountBtn = new System.Windows.Forms.Button();
            this.JointMoveHomeBtn = new System.Windows.Forms.Button();
            this.ToolTestBtn = new System.Windows.Forms.Button();
            this.ToolOffBtn = new System.Windows.Forms.Button();
            this.CoolantTestBtn = new System.Windows.Forms.Button();
            this.CoolantOffBtn = new System.Windows.Forms.Button();
            this.LoadToolsBtn = new System.Windows.Forms.Button();
            this.SaveToolsBtn = new System.Windows.Forms.Button();
            this.ClearToolsBtn = new System.Windows.Forms.Button();
            this.robotPage = new System.Windows.Forms.TabPage();
            this.SetupGrindLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SetMoveDefaultsBtn = new System.Windows.Forms.Button();
            this.SetPointFrequencyBtn = new System.Windows.Forms.Button();
            this.SetBlendRadiusBtn = new System.Windows.Forms.Button();
            this.SetForceModeGainScalingBtn = new System.Windows.Forms.Button();
            this.SetForceModeDampingBtn = new System.Windows.Forms.Button();
            this.SetJointAccelBtn = new System.Windows.Forms.Button();
            this.SetTrialSpeedBtn = new System.Windows.Forms.Button();
            this.SetJointSpeedBtn = new System.Windows.Forms.Button();
            this.SetGrindAccelBtn = new System.Windows.Forms.Button();
            this.SetGrindJogAccelBtn = new System.Windows.Forms.Button();
            this.SetMaxGrindBlendRadiusBtn = new System.Windows.Forms.Button();
            this.SetLinearSpeedBtn = new System.Windows.Forms.Button();
            this.SetGrindJogSpeedBtn = new System.Windows.Forms.Button();
            this.SetTouchSpeedBtn = new System.Windows.Forms.Button();
            this.SetTouchRetractBtn = new System.Windows.Forms.Button();
            this.SetForceDwellBtn = new System.Windows.Forms.Button();
            this.SetMaxWaitBtn = new System.Windows.Forms.Button();
            this.SetGrindDefaultsBtn = new System.Windows.Forms.Button();
            this.SetLinearAccelBtn = new System.Windows.Forms.Button();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.SetupGeneralLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LoadConfigBtn = new System.Windows.Forms.Button();
            this.SaveConfigBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LEonardRootLbl = new System.Windows.Forms.Label();
            this.DefaultConfigBtn = new System.Windows.Forms.Button();
            this.ChangeRootDirectoryBtn = new System.Windows.Forms.Button();
            this.licensePage = new System.Windows.Forms.TabPage();
            this.SetupLicenseLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LicenseStatusLbl = new System.Windows.Forms.Label();
            this.LicenseAdjustGrp = new System.Windows.Forms.GroupBox();
            this.AdjustmentButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SaveLicenseBtn = new System.Windows.Forms.Button();
            this.ReloadLicenseBtn = new System.Windows.Forms.Button();
            this.JavaLicenseBtn = new System.Windows.Forms.Button();
            this.PythonLicenseBtn = new System.Windows.Forms.Button();
            this.UrLicenseBtn = new System.Windows.Forms.Button();
            this.GrindingLicenseBtn = new System.Windows.Forms.Button();
            this.GocatorLicenseBtn = new System.Windows.Forms.Button();
            this.NewLicenseBtn = new System.Windows.Forms.Button();
            this.TrialLicenseBtn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LogsPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RobotLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ExecLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ErrorLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.AuxLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AllLogRTB = new System.Windows.Forms.RichTextBox();
            this.LogPageControlsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LogLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.LogLevelCombo = new System.Windows.Forms.ComboBox();
            this.AboutBtn = new System.Windows.Forms.Button();
            this.ClearAllLogRtbBtn = new System.Windows.Forms.Button();
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
            this.JavaScreenLayoutPanel.SuspendLayout();
            this.pythonEnginePage.SuspendLayout();
            this.PythonScreenLayoutPanel.SuspendLayout();
            this.manualPage.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.RunPage.SuspendLayout();
            this.RunTabLayoutPanel.SuspendLayout();
            this.StatusLayoutPanel.SuspendLayout();
            this.CommandCounterLayoutPanel.SuspendLayout();
            this.RunCenterColumnLayoutPanel.SuspendLayout();
            this.GrindNofNLayoutPanel.SuspendLayout();
            this.LastReportedZLayoutPanel.SuspendLayout();
            this.CodePage.SuspendLayout();
            this.ProgramTableLayoutPanel.SuspendLayout();
            this.FileBigEditPanel.SuspendLayout();
            this.SetupPage.SuspendLayout();
            this.SetupTab.SuspendLayout();
            this.devicesPage.SuspendLayout();
            this.SetupDevicesLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrd)).BeginInit();
            this.RuntimeAppHelperLayoutPanel2.SuspendLayout();
            this.SetupAppHelperLayoutPanel2.SuspendLayout();
            this.speedBtnsGrp.SuspendLayout();
            this.RuntimeAppHelperLayoutPanel1.SuspendLayout();
            this.SetupAppHelperLayoutPanel1.SuspendLayout();
            this.displaysPage.SuspendLayout();
            this.SetupDisplayLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaysGrd)).BeginInit();
            this.toolsPage.SuspendLayout();
            this.SetupToolsLayoutPanel.SuspendLayout();
            this.FootswitchIoLayoutPanel.SuspendLayout();
            this.DoorIoLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGrd)).BeginInit();
            this.robotPage.SuspendLayout();
            this.SetupGrindLayoutPanel.SuspendLayout();
            this.generalPage.SuspendLayout();
            this.SetupGeneralLayoutPanel.SuspendLayout();
            this.licensePage.SuspendLayout();
            this.SetupLicenseLayoutPanel.SuspendLayout();
            this.LicenseAdjustGrp.SuspendLayout();
            this.AdjustmentButtonLayoutPanel.SuspendLayout();
            this.LogsPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.LogPageControlsLayoutPanel.SuspendLayout();
            this.LogLevelGroupBox.SuspendLayout();
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
            this.CurrentLineLbl.Location = new System.Drawing.Point(3, 668);
            this.CurrentLineLbl.Name = "CurrentLineLbl";
            this.CurrentLineLbl.Size = new System.Drawing.Size(840, 40);
            this.CurrentLineLbl.TabIndex = 79;
            this.CurrentLineLbl.TextChanged += new System.EventHandler(this.CurrentLineLbl_TextChanged);
            // 
            // SequenceRTB
            // 
            this.SequenceRTB.DetectUrls = false;
            this.SequenceRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SequenceRTB.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SequenceRTB.Location = new System.Drawing.Point(2, 2);
            this.SequenceRTB.Margin = new System.Windows.Forms.Padding(2);
            this.SequenceRTB.Name = "SequenceRTB";
            this.SequenceRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.SequenceRTB.Size = new System.Drawing.Size(842, 664);
            this.SequenceRTB.TabIndex = 72;
            this.SequenceRTB.Text = "";
            this.SequenceRTB.VScroll += new System.EventHandler(this.LEonardScriptRTB_VScroll);
            this.SequenceRTB.TextChanged += new System.EventHandler(this.SequenceRTB_TextChanged);
            // 
            // StepBtn
            // 
            this.StepBtn.BackColor = System.Drawing.Color.Gray;
            this.StepBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepBtn.Enabled = false;
            this.StepBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepBtn.ForeColor = System.Drawing.Color.White;
            this.StepBtn.Location = new System.Drawing.Point(191, 2);
            this.StepBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StepBtn.Name = "StepBtn";
            this.StepBtn.Size = new System.Drawing.Size(185, 135);
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
            this.StopBtn.Location = new System.Drawing.Point(569, 2);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(185, 135);
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
            this.PauseBtn.Location = new System.Drawing.Point(380, 2);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(185, 135);
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
            this.StartBtn.Size = new System.Drawing.Size(185, 135);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // SequenceFilenameLbl
            // 
            this.SequenceFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SequenceFilenameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SequenceFilenameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SequenceFilenameLbl.Location = new System.Drawing.Point(2, 0);
            this.SequenceFilenameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SequenceFilenameLbl.Name = "SequenceFilenameLbl";
            this.SequenceFilenameLbl.Size = new System.Drawing.Size(636, 84);
            this.SequenceFilenameLbl.TabIndex = 77;
            this.SequenceFilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SequenceFilenameLbl.TextChanged += new System.EventHandler(this.SequenceFilenameLbl_TextChanged);
            // 
            // SaveSequenceAsBtn
            // 
            this.SaveSequenceAsBtn.BackColor = System.Drawing.Color.Gray;
            this.SaveSequenceAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveSequenceAsBtn.Enabled = false;
            this.SaveSequenceAsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveSequenceAsBtn.ForeColor = System.Drawing.Color.White;
            this.SaveSequenceAsBtn.Location = new System.Drawing.Point(745, 2);
            this.SaveSequenceAsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveSequenceAsBtn.Name = "SaveSequenceAsBtn";
            this.SaveSequenceAsBtn.Size = new System.Drawing.Size(150, 94);
            this.SaveSequenceAsBtn.TabIndex = 4;
            this.SaveSequenceAsBtn.Text = "Save As...";
            this.SaveSequenceAsBtn.UseVisualStyleBackColor = false;
            this.SaveSequenceAsBtn.Click += new System.EventHandler(this.SaveSequenceAsBtn_Click);
            // 
            // NewSequenceBtn
            // 
            this.NewSequenceBtn.BackColor = System.Drawing.Color.Gray;
            this.NewSequenceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewSequenceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSequenceBtn.ForeColor = System.Drawing.Color.White;
            this.NewSequenceBtn.Location = new System.Drawing.Point(437, 2);
            this.NewSequenceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewSequenceBtn.Name = "NewSequenceBtn";
            this.NewSequenceBtn.Size = new System.Drawing.Size(150, 94);
            this.NewSequenceBtn.TabIndex = 2;
            this.NewSequenceBtn.Text = "New";
            this.NewSequenceBtn.UseVisualStyleBackColor = false;
            this.NewSequenceBtn.Click += new System.EventHandler(this.NewSequenceBtn_Click);
            // 
            // LoadSequenceBtn
            // 
            this.LoadSequenceBtn.BackColor = System.Drawing.Color.Gray;
            this.LoadSequenceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadSequenceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadSequenceBtn.ForeColor = System.Drawing.Color.White;
            this.LoadSequenceBtn.Location = new System.Drawing.Point(22, 2);
            this.LoadSequenceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoadSequenceBtn.Name = "LoadSequenceBtn";
            this.LoadSequenceBtn.Size = new System.Drawing.Size(411, 94);
            this.LoadSequenceBtn.TabIndex = 1;
            this.LoadSequenceBtn.Text = "Untitled";
            this.LoadSequenceBtn.UseVisualStyleBackColor = false;
            this.LoadSequenceBtn.Click += new System.EventHandler(this.LoadSequenceBtn_Click);
            // 
            // SaveSequenceBtn
            // 
            this.SaveSequenceBtn.BackColor = System.Drawing.Color.Gray;
            this.SaveSequenceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveSequenceBtn.Enabled = false;
            this.SaveSequenceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveSequenceBtn.ForeColor = System.Drawing.Color.White;
            this.SaveSequenceBtn.Location = new System.Drawing.Point(591, 2);
            this.SaveSequenceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveSequenceBtn.Name = "SaveSequenceBtn";
            this.SaveSequenceBtn.Size = new System.Drawing.Size(150, 94);
            this.SaveSequenceBtn.TabIndex = 3;
            this.SaveSequenceBtn.Text = "Save";
            this.SaveSequenceBtn.UseVisualStyleBackColor = false;
            this.SaveSequenceBtn.Click += new System.EventHandler(this.SaveSequenceBtn_Click);
            // 
            // HeartbeatTmr
            // 
            this.HeartbeatTmr.Tick += new System.EventHandler(this.HeartbeatTmr_Tick);
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
            this.RobotCommandStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotCommandStatusLbl.ForeColor = System.Drawing.Color.White;
            this.RobotCommandStatusLbl.Location = new System.Drawing.Point(230, 70);
            this.RobotCommandStatusLbl.Name = "RobotCommandStatusLbl";
            this.RobotCommandStatusLbl.Size = new System.Drawing.Size(139, 90);
            this.RobotCommandStatusLbl.TabIndex = 78;
            this.RobotCommandStatusLbl.Text = "Command Status";
            this.RobotCommandStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindReadyLbl
            // 
            this.GrindReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.GrindReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindReadyLbl.ForeColor = System.Drawing.Color.White;
            this.GrindReadyLbl.Location = new System.Drawing.Point(230, 340);
            this.GrindReadyLbl.Name = "GrindReadyLbl";
            this.GrindReadyLbl.Size = new System.Drawing.Size(139, 90);
            this.GrindReadyLbl.TabIndex = 88;
            this.GrindReadyLbl.Text = "Grind Ready";
            this.GrindReadyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotReadyLbl
            // 
            this.RobotReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.RobotReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotReadyLbl.ForeColor = System.Drawing.Color.White;
            this.RobotReadyLbl.Location = new System.Drawing.Point(230, 160);
            this.RobotReadyLbl.Name = "RobotReadyLbl";
            this.RobotReadyLbl.Size = new System.Drawing.Size(139, 90);
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
            this.GrindContactEnabledBtn.Location = new System.Drawing.Point(759, 3);
            this.GrindContactEnabledBtn.Name = "GrindContactEnabledBtn";
            this.GrindContactEnabledBtn.Size = new System.Drawing.Size(183, 133);
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
            this.MonitorTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorTab.ItemSize = new System.Drawing.Size(150, 96);
            this.MonitorTab.Location = new System.Drawing.Point(849, 3);
            this.MonitorTab.Name = "MonitorTab";
            this.ProgramTableLayoutPanel.SetRowSpan(this.MonitorTab, 3);
            this.MonitorTab.SelectedIndex = 0;
            this.MonitorTab.Size = new System.Drawing.Size(1030, 792);
            this.MonitorTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MonitorTab.TabIndex = 94;
            // 
            // positionsPage
            // 
            this.positionsPage.Controls.Add(this.PositionLayoutPanel);
            this.positionsPage.Location = new System.Drawing.Point(4, 100);
            this.positionsPage.Name = "positionsPage";
            this.positionsPage.Size = new System.Drawing.Size(1022, 688);
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
            this.PositionLayoutPanel.Size = new System.Drawing.Size(1022, 688);
            this.PositionLayoutPanel.TabIndex = 101;
            // 
            // PositionMovePoseBtn
            // 
            this.PositionMovePoseBtn.BackColor = System.Drawing.Color.Green;
            this.PositionMovePoseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionMovePoseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionMovePoseBtn.ForeColor = System.Drawing.Color.White;
            this.PositionMovePoseBtn.Location = new System.Drawing.Point(2, 2);
            this.PositionMovePoseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionMovePoseBtn.Name = "PositionMovePoseBtn";
            this.PositionMovePoseBtn.Size = new System.Drawing.Size(251, 146);
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
            this.PositionsGrd.Size = new System.Drawing.Size(1016, 452);
            this.PositionsGrd.TabIndex = 85;
            // 
            // ClearAllPositionsBtn
            // 
            this.ClearAllPositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearAllPositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllPositionsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllPositionsBtn.Location = new System.Drawing.Point(768, 611);
            this.ClearAllPositionsBtn.Name = "ClearAllPositionsBtn";
            this.ClearAllPositionsBtn.Size = new System.Drawing.Size(251, 74);
            this.ClearAllPositionsBtn.TabIndex = 95;
            this.ClearAllPositionsBtn.Text = "Clear All";
            this.ClearAllPositionsBtn.UseVisualStyleBackColor = false;
            this.ClearAllPositionsBtn.Click += new System.EventHandler(this.ClearAllPositionsBtn_Click);
            // 
            // ClearPositionsBtn
            // 
            this.ClearPositionsBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearPositionsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearPositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearPositionsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearPositionsBtn.Location = new System.Drawing.Point(513, 611);
            this.ClearPositionsBtn.Name = "ClearPositionsBtn";
            this.ClearPositionsBtn.Size = new System.Drawing.Size(249, 74);
            this.ClearPositionsBtn.TabIndex = 92;
            this.ClearPositionsBtn.Text = "Clear";
            this.ClearPositionsBtn.UseVisualStyleBackColor = false;
            this.ClearPositionsBtn.Click += new System.EventHandler(this.ClearPositionsBtn_Click);
            // 
            // PositionMoveArmBtn
            // 
            this.PositionMoveArmBtn.BackColor = System.Drawing.Color.Green;
            this.PositionMoveArmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionMoveArmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionMoveArmBtn.ForeColor = System.Drawing.Color.White;
            this.PositionMoveArmBtn.Location = new System.Drawing.Point(257, 2);
            this.PositionMoveArmBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionMoveArmBtn.Name = "PositionMoveArmBtn";
            this.PositionMoveArmBtn.Size = new System.Drawing.Size(251, 146);
            this.PositionMoveArmBtn.TabIndex = 98;
            this.PositionMoveArmBtn.Text = "Joint Move to Position";
            this.PositionMoveArmBtn.UseVisualStyleBackColor = false;
            this.PositionMoveArmBtn.Click += new System.EventHandler(this.PositionMoveArmBtn_Click);
            // 
            // JogBtn
            // 
            this.JogBtn.BackColor = System.Drawing.Color.Green;
            this.JogBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JogBtn.ForeColor = System.Drawing.Color.White;
            this.JogBtn.Location = new System.Drawing.Point(767, 2);
            this.JogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JogBtn.Name = "JogBtn";
            this.JogBtn.Size = new System.Drawing.Size(253, 146);
            this.JogBtn.TabIndex = 100;
            this.JogBtn.Text = "Jog Only";
            this.JogBtn.UseVisualStyleBackColor = false;
            this.JogBtn.Click += new System.EventHandler(this.JogBtn_Click);
            // 
            // PositionSetBtn
            // 
            this.PositionSetBtn.BackColor = System.Drawing.Color.Green;
            this.PositionSetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionSetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionSetBtn.ForeColor = System.Drawing.Color.White;
            this.PositionSetBtn.Location = new System.Drawing.Point(512, 2);
            this.PositionSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PositionSetBtn.Name = "PositionSetBtn";
            this.PositionSetBtn.Size = new System.Drawing.Size(251, 146);
            this.PositionSetBtn.TabIndex = 96;
            this.PositionSetBtn.Text = "Set Position";
            this.PositionSetBtn.UseVisualStyleBackColor = false;
            this.PositionSetBtn.Click += new System.EventHandler(this.PositionSetBtn_Click);
            // 
            // variablesPage
            // 
            this.variablesPage.Controls.Add(this.VariablesLayoutPanel);
            this.variablesPage.Location = new System.Drawing.Point(4, 100);
            this.variablesPage.Name = "variablesPage";
            this.variablesPage.Padding = new System.Windows.Forms.Padding(3);
            this.variablesPage.Size = new System.Drawing.Size(1022, 688);
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
            this.VariablesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.VariablesLayoutPanel.Name = "VariablesLayoutPanel";
            this.VariablesLayoutPanel.RowCount = 2;
            this.VariablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VariablesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.VariablesLayoutPanel.Size = new System.Drawing.Size(1016, 682);
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
            this.VariablesGrd.Size = new System.Drawing.Size(1010, 596);
            this.VariablesGrd.TabIndex = 84;
            // 
            // ClearAllVariablesBtn
            // 
            this.ClearAllVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearAllVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllVariablesBtn.Location = new System.Drawing.Point(765, 605);
            this.ClearAllVariablesBtn.Name = "ClearAllVariablesBtn";
            this.ClearAllVariablesBtn.Size = new System.Drawing.Size(248, 74);
            this.ClearAllVariablesBtn.TabIndex = 91;
            this.ClearAllVariablesBtn.Text = "Clear All";
            this.ClearAllVariablesBtn.UseVisualStyleBackColor = false;
            this.ClearAllVariablesBtn.Click += new System.EventHandler(this.ClearAllVariablesBtn_Click);
            // 
            // ClearVariablesBtn
            // 
            this.ClearVariablesBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearVariablesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearVariablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearVariablesBtn.ForeColor = System.Drawing.Color.White;
            this.ClearVariablesBtn.Location = new System.Drawing.Point(511, 605);
            this.ClearVariablesBtn.Name = "ClearVariablesBtn";
            this.ClearVariablesBtn.Size = new System.Drawing.Size(248, 74);
            this.ClearVariablesBtn.TabIndex = 88;
            this.ClearVariablesBtn.Text = "Clear";
            this.ClearVariablesBtn.UseVisualStyleBackColor = false;
            this.ClearVariablesBtn.Click += new System.EventHandler(this.ClearVariablesBtn_Click);
            // 
            // javaEnginePage
            // 
            this.javaEnginePage.Controls.Add(this.JavaScreenLayoutPanel);
            this.javaEnginePage.Location = new System.Drawing.Point(4, 100);
            this.javaEnginePage.Name = "javaEnginePage";
            this.javaEnginePage.Size = new System.Drawing.Size(1022, 688);
            this.javaEnginePage.TabIndex = 5;
            this.javaEnginePage.Text = "Java";
            this.javaEnginePage.UseVisualStyleBackColor = true;
            // 
            // JavaScreenLayoutPanel
            // 
            this.JavaScreenLayoutPanel.ColumnCount = 6;
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaFilenameLbl, 0, 0);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaRunBtn, 0, 2);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaNewBtn, 2, 2);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaLoadBtn, 3, 2);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaSaveBtn, 4, 2);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaSaveAsBtn, 5, 2);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaConsoleRTB, 0, 3);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaVariablesRTB, 3, 3);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaCodeRTB, 0, 1);
            this.JavaScreenLayoutPanel.Controls.Add(this.JavaRestartBtn, 1, 2);
            this.JavaScreenLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaScreenLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.JavaScreenLayoutPanel.Name = "JavaScreenLayoutPanel";
            this.JavaScreenLayoutPanel.RowCount = 4;
            this.JavaScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.950495F));
            this.JavaScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.35644F));
            this.JavaScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.920792F));
            this.JavaScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.77228F));
            this.JavaScreenLayoutPanel.Size = new System.Drawing.Size(1022, 688);
            this.JavaScreenLayoutPanel.TabIndex = 3;
            // 
            // JavaFilenameLbl
            // 
            this.JavaFilenameLbl.AutoSize = true;
            this.JavaFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JavaScreenLayoutPanel.SetColumnSpan(this.JavaFilenameLbl, 6);
            this.JavaFilenameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaFilenameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaFilenameLbl.Location = new System.Drawing.Point(3, 0);
            this.JavaFilenameLbl.Name = "JavaFilenameLbl";
            this.JavaFilenameLbl.Size = new System.Drawing.Size(1016, 34);
            this.JavaFilenameLbl.TabIndex = 0;
            this.JavaFilenameLbl.Text = "Untitled";
            // 
            // JavaRunBtn
            // 
            this.JavaRunBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaRunBtn.Enabled = false;
            this.JavaRunBtn.Location = new System.Drawing.Point(3, 479);
            this.JavaRunBtn.Name = "JavaRunBtn";
            this.JavaRunBtn.Size = new System.Drawing.Size(164, 48);
            this.JavaRunBtn.TabIndex = 1;
            this.JavaRunBtn.Text = "Run";
            this.JavaRunBtn.UseVisualStyleBackColor = true;
            this.JavaRunBtn.Click += new System.EventHandler(this.JavaRunBtn_Click);
            // 
            // JavaNewBtn
            // 
            this.JavaNewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaNewBtn.Enabled = false;
            this.JavaNewBtn.Location = new System.Drawing.Point(343, 479);
            this.JavaNewBtn.Name = "JavaNewBtn";
            this.JavaNewBtn.Size = new System.Drawing.Size(164, 48);
            this.JavaNewBtn.TabIndex = 3;
            this.JavaNewBtn.Text = "New";
            this.JavaNewBtn.UseVisualStyleBackColor = true;
            this.JavaNewBtn.Click += new System.EventHandler(this.JavaNewBtn_Click);
            // 
            // JavaLoadBtn
            // 
            this.JavaLoadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaLoadBtn.Location = new System.Drawing.Point(513, 479);
            this.JavaLoadBtn.Name = "JavaLoadBtn";
            this.JavaLoadBtn.Size = new System.Drawing.Size(164, 48);
            this.JavaLoadBtn.TabIndex = 4;
            this.JavaLoadBtn.Text = "Load...";
            this.JavaLoadBtn.UseVisualStyleBackColor = true;
            this.JavaLoadBtn.Click += new System.EventHandler(this.JavaLoadBtn_Click);
            // 
            // JavaSaveBtn
            // 
            this.JavaSaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaSaveBtn.Enabled = false;
            this.JavaSaveBtn.Location = new System.Drawing.Point(683, 479);
            this.JavaSaveBtn.Name = "JavaSaveBtn";
            this.JavaSaveBtn.Size = new System.Drawing.Size(164, 48);
            this.JavaSaveBtn.TabIndex = 5;
            this.JavaSaveBtn.Text = "Save";
            this.JavaSaveBtn.UseVisualStyleBackColor = true;
            this.JavaSaveBtn.Click += new System.EventHandler(this.JavaSaveBtn_Click);
            // 
            // JavaSaveAsBtn
            // 
            this.JavaSaveAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaSaveAsBtn.Enabled = false;
            this.JavaSaveAsBtn.Location = new System.Drawing.Point(853, 479);
            this.JavaSaveAsBtn.Name = "JavaSaveAsBtn";
            this.JavaSaveAsBtn.Size = new System.Drawing.Size(166, 48);
            this.JavaSaveAsBtn.TabIndex = 6;
            this.JavaSaveAsBtn.Text = "Save As...";
            this.JavaSaveAsBtn.UseVisualStyleBackColor = true;
            this.JavaSaveAsBtn.Click += new System.EventHandler(this.JavaSaveAsBtn_Click);
            // 
            // JavaConsoleRTB
            // 
            this.JavaScreenLayoutPanel.SetColumnSpan(this.JavaConsoleRTB, 3);
            this.JavaConsoleRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaConsoleRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaConsoleRTB.Location = new System.Drawing.Point(3, 533);
            this.JavaConsoleRTB.Name = "JavaConsoleRTB";
            this.JavaConsoleRTB.Size = new System.Drawing.Size(504, 152);
            this.JavaConsoleRTB.TabIndex = 7;
            this.JavaConsoleRTB.Text = "";
            // 
            // JavaVariablesRTB
            // 
            this.JavaScreenLayoutPanel.SetColumnSpan(this.JavaVariablesRTB, 3);
            this.JavaVariablesRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaVariablesRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaVariablesRTB.Location = new System.Drawing.Point(513, 533);
            this.JavaVariablesRTB.Name = "JavaVariablesRTB";
            this.JavaVariablesRTB.Size = new System.Drawing.Size(506, 152);
            this.JavaVariablesRTB.TabIndex = 8;
            this.JavaVariablesRTB.Text = "";
            // 
            // JavaCodeRTB
            // 
            this.JavaScreenLayoutPanel.SetColumnSpan(this.JavaCodeRTB, 6);
            this.JavaCodeRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaCodeRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaCodeRTB.Location = new System.Drawing.Point(3, 37);
            this.JavaCodeRTB.Name = "JavaCodeRTB";
            this.JavaCodeRTB.Size = new System.Drawing.Size(1016, 436);
            this.JavaCodeRTB.TabIndex = 9;
            this.JavaCodeRTB.Text = "";
            this.JavaCodeRTB.TextChanged += new System.EventHandler(this.JavaCodeRTB_TextChanged);
            // 
            // JavaRestartBtn
            // 
            this.JavaRestartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaRestartBtn.Location = new System.Drawing.Point(173, 479);
            this.JavaRestartBtn.Name = "JavaRestartBtn";
            this.JavaRestartBtn.Size = new System.Drawing.Size(164, 48);
            this.JavaRestartBtn.TabIndex = 10;
            this.JavaRestartBtn.Text = "Restart";
            this.JavaRestartBtn.UseVisualStyleBackColor = true;
            this.JavaRestartBtn.Click += new System.EventHandler(this.JavaRestartBtn_Click);
            // 
            // pythonEnginePage
            // 
            this.pythonEnginePage.Controls.Add(this.PythonScreenLayoutPanel);
            this.pythonEnginePage.Location = new System.Drawing.Point(4, 100);
            this.pythonEnginePage.Name = "pythonEnginePage";
            this.pythonEnginePage.Size = new System.Drawing.Size(1022, 688);
            this.pythonEnginePage.TabIndex = 6;
            this.pythonEnginePage.Text = "Python";
            this.pythonEnginePage.UseVisualStyleBackColor = true;
            // 
            // PythonScreenLayoutPanel
            // 
            this.PythonScreenLayoutPanel.ColumnCount = 6;
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonFilenameLbl, 0, 0);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonNewBtn, 2, 2);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonLoadBtn, 3, 2);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonSaveBtn, 4, 2);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonSaveAsBtn, 5, 2);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonConsoleRTB, 0, 3);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonVariablesRTB, 3, 3);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonCodeRTB, 0, 1);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonRunBtn, 0, 2);
            this.PythonScreenLayoutPanel.Controls.Add(this.PythonRestartBtn, 1, 2);
            this.PythonScreenLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonScreenLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PythonScreenLayoutPanel.Name = "PythonScreenLayoutPanel";
            this.PythonScreenLayoutPanel.RowCount = 4;
            this.PythonScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.950495F));
            this.PythonScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.35644F));
            this.PythonScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.920792F));
            this.PythonScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.77228F));
            this.PythonScreenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PythonScreenLayoutPanel.Size = new System.Drawing.Size(1022, 688);
            this.PythonScreenLayoutPanel.TabIndex = 5;
            // 
            // PythonFilenameLbl
            // 
            this.PythonFilenameLbl.AutoSize = true;
            this.PythonFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PythonScreenLayoutPanel.SetColumnSpan(this.PythonFilenameLbl, 6);
            this.PythonFilenameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonFilenameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PythonFilenameLbl.Location = new System.Drawing.Point(3, 0);
            this.PythonFilenameLbl.Name = "PythonFilenameLbl";
            this.PythonFilenameLbl.Size = new System.Drawing.Size(1016, 34);
            this.PythonFilenameLbl.TabIndex = 0;
            this.PythonFilenameLbl.Text = "Untitled";
            // 
            // PythonNewBtn
            // 
            this.PythonNewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonNewBtn.Enabled = false;
            this.PythonNewBtn.Location = new System.Drawing.Point(343, 479);
            this.PythonNewBtn.Name = "PythonNewBtn";
            this.PythonNewBtn.Size = new System.Drawing.Size(164, 48);
            this.PythonNewBtn.TabIndex = 3;
            this.PythonNewBtn.Text = "New";
            this.PythonNewBtn.UseVisualStyleBackColor = true;
            this.PythonNewBtn.Click += new System.EventHandler(this.PythonNewBtn_Click);
            // 
            // PythonLoadBtn
            // 
            this.PythonLoadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonLoadBtn.Location = new System.Drawing.Point(513, 479);
            this.PythonLoadBtn.Name = "PythonLoadBtn";
            this.PythonLoadBtn.Size = new System.Drawing.Size(164, 48);
            this.PythonLoadBtn.TabIndex = 4;
            this.PythonLoadBtn.Text = "Load...";
            this.PythonLoadBtn.UseVisualStyleBackColor = true;
            this.PythonLoadBtn.Click += new System.EventHandler(this.PythonLoadBtn_Click);
            // 
            // PythonSaveBtn
            // 
            this.PythonSaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonSaveBtn.Enabled = false;
            this.PythonSaveBtn.Location = new System.Drawing.Point(683, 479);
            this.PythonSaveBtn.Name = "PythonSaveBtn";
            this.PythonSaveBtn.Size = new System.Drawing.Size(164, 48);
            this.PythonSaveBtn.TabIndex = 5;
            this.PythonSaveBtn.Text = "Save";
            this.PythonSaveBtn.UseVisualStyleBackColor = true;
            this.PythonSaveBtn.Click += new System.EventHandler(this.PythonSaveBtn_Click);
            // 
            // PythonSaveAsBtn
            // 
            this.PythonSaveAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonSaveAsBtn.Enabled = false;
            this.PythonSaveAsBtn.Location = new System.Drawing.Point(853, 479);
            this.PythonSaveAsBtn.Name = "PythonSaveAsBtn";
            this.PythonSaveAsBtn.Size = new System.Drawing.Size(166, 48);
            this.PythonSaveAsBtn.TabIndex = 6;
            this.PythonSaveAsBtn.Text = "Save As...";
            this.PythonSaveAsBtn.UseVisualStyleBackColor = true;
            this.PythonSaveAsBtn.Click += new System.EventHandler(this.PythonSaveAsBtn_Click);
            // 
            // PythonConsoleRTB
            // 
            this.PythonScreenLayoutPanel.SetColumnSpan(this.PythonConsoleRTB, 3);
            this.PythonConsoleRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonConsoleRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PythonConsoleRTB.Location = new System.Drawing.Point(3, 533);
            this.PythonConsoleRTB.Name = "PythonConsoleRTB";
            this.PythonConsoleRTB.Size = new System.Drawing.Size(504, 152);
            this.PythonConsoleRTB.TabIndex = 8;
            this.PythonConsoleRTB.Text = "";
            // 
            // PythonVariablesRTB
            // 
            this.PythonScreenLayoutPanel.SetColumnSpan(this.PythonVariablesRTB, 3);
            this.PythonVariablesRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonVariablesRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PythonVariablesRTB.Location = new System.Drawing.Point(513, 533);
            this.PythonVariablesRTB.Name = "PythonVariablesRTB";
            this.PythonVariablesRTB.Size = new System.Drawing.Size(506, 152);
            this.PythonVariablesRTB.TabIndex = 9;
            this.PythonVariablesRTB.Text = "";
            // 
            // PythonCodeRTB
            // 
            this.PythonScreenLayoutPanel.SetColumnSpan(this.PythonCodeRTB, 6);
            this.PythonCodeRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonCodeRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PythonCodeRTB.Location = new System.Drawing.Point(3, 37);
            this.PythonCodeRTB.Name = "PythonCodeRTB";
            this.PythonCodeRTB.Size = new System.Drawing.Size(1016, 436);
            this.PythonCodeRTB.TabIndex = 10;
            this.PythonCodeRTB.Text = "";
            this.PythonCodeRTB.TextChanged += new System.EventHandler(this.PythonCodeRTB_TextChanged);
            // 
            // PythonRunBtn
            // 
            this.PythonRunBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonRunBtn.Enabled = false;
            this.PythonRunBtn.Location = new System.Drawing.Point(3, 479);
            this.PythonRunBtn.Name = "PythonRunBtn";
            this.PythonRunBtn.Size = new System.Drawing.Size(164, 48);
            this.PythonRunBtn.TabIndex = 3;
            this.PythonRunBtn.Text = "Run";
            this.PythonRunBtn.UseVisualStyleBackColor = true;
            this.PythonRunBtn.Click += new System.EventHandler(this.PythonRunBtn_Click);
            // 
            // PythonRestartBtn
            // 
            this.PythonRestartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonRestartBtn.Location = new System.Drawing.Point(173, 479);
            this.PythonRestartBtn.Name = "PythonRestartBtn";
            this.PythonRestartBtn.Size = new System.Drawing.Size(164, 48);
            this.PythonRestartBtn.TabIndex = 11;
            this.PythonRestartBtn.Text = "Restart";
            this.PythonRestartBtn.UseVisualStyleBackColor = true;
            this.PythonRestartBtn.Click += new System.EventHandler(this.PythonRestartBtn_Click);
            // 
            // manualPage
            // 
            this.manualPage.Controls.Add(this.GocatorManualBtn);
            this.manualPage.Controls.Add(this.URManualBtn);
            this.manualPage.Controls.Add(this.FullManualBtn);
            this.manualPage.Location = new System.Drawing.Point(4, 100);
            this.manualPage.Name = "manualPage";
            this.manualPage.Size = new System.Drawing.Size(1022, 688);
            this.manualPage.TabIndex = 3;
            this.manualPage.Text = "Manual";
            this.manualPage.UseVisualStyleBackColor = true;
            // 
            // GocatorManualBtn
            // 
            this.GocatorManualBtn.AutoSize = true;
            this.GocatorManualBtn.Location = new System.Drawing.Point(16, 358);
            this.GocatorManualBtn.Name = "GocatorManualBtn";
            this.GocatorManualBtn.Size = new System.Drawing.Size(525, 167);
            this.GocatorManualBtn.TabIndex = 109;
            this.GocatorManualBtn.Text = "Gocator Manual";
            this.GocatorManualBtn.UseVisualStyleBackColor = true;
            this.GocatorManualBtn.Click += new System.EventHandler(this.GocatorManualBtn_Click);
            // 
            // URManualBtn
            // 
            this.URManualBtn.AutoSize = true;
            this.URManualBtn.Location = new System.Drawing.Point(16, 185);
            this.URManualBtn.Name = "URManualBtn";
            this.URManualBtn.Size = new System.Drawing.Size(525, 167);
            this.URManualBtn.TabIndex = 108;
            this.URManualBtn.Text = "UR Manual";
            this.URManualBtn.UseVisualStyleBackColor = true;
            this.URManualBtn.Click += new System.EventHandler(this.URManualBtn_Click);
            // 
            // FullManualBtn
            // 
            this.FullManualBtn.AutoSize = true;
            this.FullManualBtn.Location = new System.Drawing.Point(16, 12);
            this.FullManualBtn.Name = "FullManualBtn";
            this.FullManualBtn.Size = new System.Drawing.Size(525, 167);
            this.FullManualBtn.TabIndex = 107;
            this.FullManualBtn.Text = "Show Full Manual\r\nUsing System PDF Viewer";
            this.FullManualBtn.UseVisualStyleBackColor = true;
            this.FullManualBtn.Click += new System.EventHandler(this.FullManualBtn_Click);
            // 
            // MountedToolBoxLbl
            // 
            this.MountedToolBoxLbl.BackColor = System.Drawing.Color.Gray;
            this.MountedToolBoxLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MountedToolBoxLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MountedToolBoxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MountedToolBoxLbl.ForeColor = System.Drawing.Color.White;
            this.MountedToolBoxLbl.Location = new System.Drawing.Point(3, 66);
            this.MountedToolBoxLbl.Name = "MountedToolBoxLbl";
            this.MountedToolBoxLbl.Size = new System.Drawing.Size(272, 67);
            this.MountedToolBoxLbl.TabIndex = 97;
            this.MountedToolBoxLbl.Text = "Tool";
            this.MountedToolBoxLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MountedToolBox
            // 
            this.MountedToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MountedToolBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MountedToolBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MountedToolBox.FormattingEnabled = true;
            this.MountedToolBox.Location = new System.Drawing.Point(3, 3);
            this.MountedToolBox.Name = "MountedToolBox";
            this.MountedToolBox.Size = new System.Drawing.Size(272, 50);
            this.MountedToolBox.TabIndex = 5;
            this.MountedToolBox.SelectedIndexChanged += new System.EventHandler(this.MountedToolBox_SelectedIndexChanged);
            // 
            // UserModeBox
            // 
            this.UserModeBox.BackColor = System.Drawing.SystemColors.Control;
            this.UserModeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserModeBox.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserModeBox.FormattingEnabled = true;
            this.UserModeBox.Items.AddRange(new object[] {
            "OPERATOR",
            "EDITOR",
            "ENGINEERING"});
            this.UserModeBox.Location = new System.Drawing.Point(3, 3);
            this.UserModeBox.Name = "UserModeBox";
            this.UserModeBox.Size = new System.Drawing.Size(221, 38);
            this.UserModeBox.TabIndex = 103;
            this.UserModeBox.SelectedIndexChanged += new System.EventHandler(this.OperatorModeBox_SelectedIndexChanged);
            // 
            // RobotModeBtn
            // 
            this.RobotModeBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotModeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotModeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotModeBtn.ForeColor = System.Drawing.Color.White;
            this.RobotModeBtn.Location = new System.Drawing.Point(3, 163);
            this.RobotModeBtn.Name = "RobotModeBtn";
            this.RobotModeBtn.Size = new System.Drawing.Size(221, 84);
            this.RobotModeBtn.TabIndex = 106;
            this.RobotModeBtn.Text = "Robot Mode";
            this.RobotModeBtn.UseVisualStyleBackColor = false;
            this.RobotModeBtn.Click += new System.EventHandler(this.RobotModeBtn_Click);
            // 
            // RobotSafetyStatusBtn
            // 
            this.RobotSafetyStatusBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotSafetyStatusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotSafetyStatusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotSafetyStatusBtn.ForeColor = System.Drawing.Color.White;
            this.RobotSafetyStatusBtn.Location = new System.Drawing.Point(3, 253);
            this.RobotSafetyStatusBtn.Name = "RobotSafetyStatusBtn";
            this.RobotSafetyStatusBtn.Size = new System.Drawing.Size(221, 84);
            this.RobotSafetyStatusBtn.TabIndex = 107;
            this.RobotSafetyStatusBtn.Text = "Safety Status";
            this.RobotSafetyStatusBtn.UseVisualStyleBackColor = false;
            this.RobotSafetyStatusBtn.Click += new System.EventHandler(this.SafetyStatusBtn_Click);
            // 
            // RobotProgramStateBtn
            // 
            this.RobotProgramStateBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotProgramStateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotProgramStateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotProgramStateBtn.ForeColor = System.Drawing.Color.White;
            this.RobotProgramStateBtn.Location = new System.Drawing.Point(3, 343);
            this.RobotProgramStateBtn.Name = "RobotProgramStateBtn";
            this.RobotProgramStateBtn.Size = new System.Drawing.Size(221, 84);
            this.RobotProgramStateBtn.TabIndex = 108;
            this.RobotProgramStateBtn.Text = "Program State";
            this.RobotProgramStateBtn.UseVisualStyleBackColor = false;
            this.RobotProgramStateBtn.Click += new System.EventHandler(this.ProgramStateBtn_Click);
            // 
            // PartGeometryBoxLbl
            // 
            this.PartGeometryBoxLbl.BackColor = System.Drawing.Color.Gray;
            this.PartGeometryBoxLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PartGeometryBoxLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartGeometryBoxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartGeometryBoxLbl.ForeColor = System.Drawing.Color.White;
            this.PartGeometryBoxLbl.Location = new System.Drawing.Point(3, 66);
            this.PartGeometryBoxLbl.Name = "PartGeometryBoxLbl";
            this.PartGeometryBoxLbl.Size = new System.Drawing.Size(272, 67);
            this.PartGeometryBoxLbl.TabIndex = 115;
            this.PartGeometryBoxLbl.Text = "Part Geom";
            this.PartGeometryBoxLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiameterDimLbl
            // 
            this.DiameterDimLbl.AutoSize = true;
            this.DiameterDimLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiameterDimLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiameterDimLbl.Location = new System.Drawing.Point(191, 0);
            this.DiameterDimLbl.Name = "DiameterDimLbl";
            this.DiameterDimLbl.Size = new System.Drawing.Size(183, 61);
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
            this.MainTab.Controls.Add(this.CodePage);
            this.MainTab.Controls.Add(this.SetupPage);
            this.MainTab.Controls.Add(this.LogsPage);
            this.MainTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.ItemSize = new System.Drawing.Size(96, 96);
            this.MainTab.Location = new System.Drawing.Point(8, 11);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1900, 912);
            this.MainTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
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
            this.RunPage.Size = new System.Drawing.Size(1892, 808);
            this.RunPage.TabIndex = 0;
            this.RunPage.Text = "Run";
            this.RunPage.ToolTipText = "Run";
            this.RunPage.UseVisualStyleBackColor = true;
            // 
            // RunTabLayoutPanel
            // 
            this.RunTabLayoutPanel.ColumnCount = 3;
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.RunTabLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RunTabLayoutPanel.Controls.Add(this.StatusLayoutPanel, 2, 0);
            this.RunTabLayoutPanel.Controls.Add(this.SequenceRTBCopy, 0, 0);
            this.RunTabLayoutPanel.Controls.Add(this.RunCenterColumnLayoutPanel, 1, 0);
            this.RunTabLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunTabLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.RunTabLayoutPanel.Name = "RunTabLayoutPanel";
            this.RunTabLayoutPanel.RowCount = 1;
            this.RunTabLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RunTabLayoutPanel.Size = new System.Drawing.Size(1882, 798);
            this.RunTabLayoutPanel.TabIndex = 161;
            // 
            // StatusLayoutPanel
            // 
            this.StatusLayoutPanel.ColumnCount = 2;
            this.StatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.21673F));
            this.StatusLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.78327F));
            this.StatusLayoutPanel.Controls.Add(this.label9, 1, 0);
            this.StatusLayoutPanel.Controls.Add(this.UserModeBox, 0, 0);
            this.StatusLayoutPanel.Controls.Add(this.RobotProgramStateBtn, 0, 5);
            this.StatusLayoutPanel.Controls.Add(this.RobotSafetyStatusBtn, 0, 4);
            this.StatusLayoutPanel.Controls.Add(this.RobotModeBtn, 0, 3);
            this.StatusLayoutPanel.Controls.Add(this.RobotConnectBtn, 0, 2);
            this.StatusLayoutPanel.Controls.Add(this.RobotCommandStatusLbl, 1, 2);
            this.StatusLayoutPanel.Controls.Add(this.RobotReadyLbl, 1, 3);
            this.StatusLayoutPanel.Controls.Add(this.CommandCounterLayoutPanel, 1, 4);
            this.StatusLayoutPanel.Controls.Add(this.GrindReadyLbl, 1, 5);
            this.StatusLayoutPanel.Controls.Add(this.GrindProcessStateLbl, 1, 6);
            this.StatusLayoutPanel.Controls.Add(this.GocatorReadyLbl, 1, 9);
            this.StatusLayoutPanel.Controls.Add(this.GocatorConnectedLbl, 0, 9);
            this.StatusLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLayoutPanel.Location = new System.Drawing.Point(1507, 3);
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
            this.StatusLayoutPanel.Size = new System.Drawing.Size(372, 792);
            this.StatusLayoutPanel.TabIndex = 161;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(229, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 41);
            this.label9.TabIndex = 154;
            this.label9.Text = "User";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RobotConnectBtn
            // 
            this.RobotConnectBtn.BackColor = System.Drawing.Color.Gray;
            this.RobotConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotConnectBtn.ForeColor = System.Drawing.Color.White;
            this.RobotConnectBtn.Location = new System.Drawing.Point(3, 73);
            this.RobotConnectBtn.Name = "RobotConnectBtn";
            this.RobotConnectBtn.Size = new System.Drawing.Size(221, 84);
            this.RobotConnectBtn.TabIndex = 73;
            this.RobotConnectBtn.Text = "Robot Connect";
            this.RobotConnectBtn.UseVisualStyleBackColor = false;
            this.RobotConnectBtn.Click += new System.EventHandler(this.RobotConnectBtn_Click);
            // 
            // CommandCounterLayoutPanel
            // 
            this.CommandCounterLayoutPanel.ColumnCount = 1;
            this.CommandCounterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.Controls.Add(this.RobotSentLbl, 0, 0);
            this.CommandCounterLayoutPanel.Controls.Add(this.RobotCompletedLbl, 0, 1);
            this.CommandCounterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandCounterLayoutPanel.Location = new System.Drawing.Point(230, 253);
            this.CommandCounterLayoutPanel.Name = "CommandCounterLayoutPanel";
            this.CommandCounterLayoutPanel.RowCount = 2;
            this.CommandCounterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CommandCounterLayoutPanel.Size = new System.Drawing.Size(139, 84);
            this.CommandCounterLayoutPanel.TabIndex = 160;
            // 
            // RobotSentLbl
            // 
            this.RobotSentLbl.BackColor = System.Drawing.Color.Green;
            this.RobotSentLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotSentLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotSentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotSentLbl.ForeColor = System.Drawing.Color.White;
            this.RobotSentLbl.Location = new System.Drawing.Point(3, 0);
            this.RobotSentLbl.Name = "RobotSentLbl";
            this.RobotSentLbl.Size = new System.Drawing.Size(133, 42);
            this.RobotSentLbl.TabIndex = 149;
            this.RobotSentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotCompletedLbl
            // 
            this.RobotCompletedLbl.BackColor = System.Drawing.Color.Gray;
            this.RobotCompletedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotCompletedLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotCompletedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotCompletedLbl.ForeColor = System.Drawing.Color.White;
            this.RobotCompletedLbl.Location = new System.Drawing.Point(3, 42);
            this.RobotCompletedLbl.Name = "RobotCompletedLbl";
            this.RobotCompletedLbl.Size = new System.Drawing.Size(133, 42);
            this.RobotCompletedLbl.TabIndex = 135;
            this.RobotCompletedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindProcessStateLbl
            // 
            this.GrindProcessStateLbl.BackColor = System.Drawing.Color.Gray;
            this.GrindProcessStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindProcessStateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindProcessStateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindProcessStateLbl.ForeColor = System.Drawing.Color.White;
            this.GrindProcessStateLbl.Location = new System.Drawing.Point(230, 430);
            this.GrindProcessStateLbl.Name = "GrindProcessStateLbl";
            this.GrindProcessStateLbl.Size = new System.Drawing.Size(139, 90);
            this.GrindProcessStateLbl.TabIndex = 136;
            this.GrindProcessStateLbl.Text = "Grind Process State";
            this.GrindProcessStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GocatorReadyLbl
            // 
            this.GocatorReadyLbl.BackColor = System.Drawing.Color.Gray;
            this.GocatorReadyLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GocatorReadyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GocatorReadyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GocatorReadyLbl.ForeColor = System.Drawing.Color.White;
            this.GocatorReadyLbl.Location = new System.Drawing.Point(230, 700);
            this.GocatorReadyLbl.Name = "GocatorReadyLbl";
            this.GocatorReadyLbl.Size = new System.Drawing.Size(139, 92);
            this.GocatorReadyLbl.TabIndex = 160;
            this.GocatorReadyLbl.Text = "Gocator Ready";
            this.GocatorReadyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GocatorConnectedLbl
            // 
            this.GocatorConnectedLbl.BackColor = System.Drawing.Color.Gray;
            this.GocatorConnectedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GocatorConnectedLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GocatorConnectedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GocatorConnectedLbl.ForeColor = System.Drawing.Color.White;
            this.GocatorConnectedLbl.Location = new System.Drawing.Point(3, 700);
            this.GocatorConnectedLbl.Name = "GocatorConnectedLbl";
            this.GocatorConnectedLbl.Size = new System.Drawing.Size(221, 92);
            this.GocatorConnectedLbl.TabIndex = 161;
            this.GocatorConnectedLbl.Text = "Gocator Connected";
            this.GocatorConnectedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SequenceRTBCopy
            // 
            this.SequenceRTBCopy.DetectUrls = false;
            this.SequenceRTBCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SequenceRTBCopy.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SequenceRTBCopy.Location = new System.Drawing.Point(2, 2);
            this.SequenceRTBCopy.Margin = new System.Windows.Forms.Padding(2);
            this.SequenceRTBCopy.Name = "SequenceRTBCopy";
            this.SequenceRTBCopy.ReadOnly = true;
            this.SequenceRTBCopy.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.SequenceRTBCopy.Size = new System.Drawing.Size(842, 794);
            this.SequenceRTBCopy.TabIndex = 129;
            this.SequenceRTBCopy.Text = "";
            this.SequenceRTBCopy.VScroll += new System.EventHandler(this.LEonardScriptRTBCopy_VScroll);
            // 
            // RunCenterColumnLayoutPanel
            // 
            this.RunCenterColumnLayoutPanel.ColumnCount = 2;
            this.RunCenterColumnLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RunCenterColumnLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label18, 0, 0);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.MoveToolHomeBtn, 1, 12);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.TimeLbl, 1, 0);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.MoveToolMountBtn, 0, 12);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label14, 0, 1);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label12, 0, 2);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.RunStartedTimeLbl, 1, 1);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.RunElapsedTimeLbl, 1, 2);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.RunStateLbl, 0, 3);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.GrindLbl3, 0, 9);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.CurrentLineLblCopy, 0, 4);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.GrindLbl1, 0, 8);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label16, 0, 5);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.StepTimeRemainingLbl, 1, 7);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.StepElapsedTimeLbl, 1, 5);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label13, 0, 6);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.label17, 0, 7);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.StepTimeEstimateLbl, 1, 6);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.GrindNofNLayoutPanel, 1, 8);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.LastReportedZLayoutPanel, 1, 9);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.MoveToolMountLbl, 0, 10);
            this.RunCenterColumnLayoutPanel.Controls.Add(this.MoveToolHomeLbl, 1, 10);
            this.RunCenterColumnLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunCenterColumnLayoutPanel.Location = new System.Drawing.Point(849, 3);
            this.RunCenterColumnLayoutPanel.Name = "RunCenterColumnLayoutPanel";
            this.RunCenterColumnLayoutPanel.RowCount = 13;
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761325F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.8641F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.761326F));
            this.RunCenterColumnLayoutPanel.Size = new System.Drawing.Size(652, 792);
            this.RunCenterColumnLayoutPanel.TabIndex = 162;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(320, 53);
            this.label18.TabIndex = 155;
            this.label18.Text = "Current Time";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoveToolHomeBtn
            // 
            this.MoveToolHomeBtn.BackColor = System.Drawing.Color.Green;
            this.MoveToolHomeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveToolHomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolHomeBtn.ForeColor = System.Drawing.Color.White;
            this.MoveToolHomeBtn.Location = new System.Drawing.Point(328, 734);
            this.MoveToolHomeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MoveToolHomeBtn.Name = "MoveToolHomeBtn";
            this.MoveToolHomeBtn.Size = new System.Drawing.Size(322, 56);
            this.MoveToolHomeBtn.TabIndex = 137;
            this.MoveToolHomeBtn.Text = "tool_home";
            this.MoveToolHomeBtn.UseVisualStyleBackColor = false;
            this.MoveToolHomeBtn.Click += new System.EventHandler(this.JointMoveHomeBtn_Click);
            // 
            // TimeLbl
            // 
            this.TimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLbl.Location = new System.Drawing.Point(328, 0);
            this.TimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(322, 53);
            this.TimeLbl.TabIndex = 5;
            this.TimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoveToolMountBtn
            // 
            this.MoveToolMountBtn.BackColor = System.Drawing.Color.Green;
            this.MoveToolMountBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveToolMountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolMountBtn.ForeColor = System.Drawing.Color.White;
            this.MoveToolMountBtn.Location = new System.Drawing.Point(2, 734);
            this.MoveToolMountBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MoveToolMountBtn.Name = "MoveToolMountBtn";
            this.MoveToolMountBtn.Size = new System.Drawing.Size(322, 56);
            this.MoveToolMountBtn.TabIndex = 138;
            this.MoveToolMountBtn.Text = "tool_mount";
            this.MoveToolMountBtn.UseVisualStyleBackColor = false;
            this.MoveToolMountBtn.Click += new System.EventHandler(this.JointMoveMountBtn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(320, 53);
            this.label14.TabIndex = 133;
            this.label14.Text = "Start Time";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(320, 53);
            this.label12.TabIndex = 131;
            this.label12.Text = "Total Run Time";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunStartedTimeLbl
            // 
            this.RunStartedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunStartedTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunStartedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunStartedTimeLbl.Location = new System.Drawing.Point(329, 53);
            this.RunStartedTimeLbl.Name = "RunStartedTimeLbl";
            this.RunStartedTimeLbl.Size = new System.Drawing.Size(320, 53);
            this.RunStartedTimeLbl.TabIndex = 134;
            this.RunStartedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RunElapsedTimeLbl
            // 
            this.RunElapsedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunElapsedTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunElapsedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunElapsedTimeLbl.Location = new System.Drawing.Point(329, 106);
            this.RunElapsedTimeLbl.Name = "RunElapsedTimeLbl";
            this.RunElapsedTimeLbl.Size = new System.Drawing.Size(320, 53);
            this.RunElapsedTimeLbl.TabIndex = 132;
            this.RunElapsedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RunStateLbl
            // 
            this.RunStateLbl.BackColor = System.Drawing.Color.Gray;
            this.RunStateLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunCenterColumnLayoutPanel.SetColumnSpan(this.RunStateLbl, 2);
            this.RunStateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunStateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunStateLbl.ForeColor = System.Drawing.Color.White;
            this.RunStateLbl.Location = new System.Drawing.Point(3, 159);
            this.RunStateLbl.Name = "RunStateLbl";
            this.RunStateLbl.Size = new System.Drawing.Size(646, 53);
            this.RunStateLbl.TabIndex = 122;
            this.RunStateLbl.Text = "Current Step";
            this.RunStateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindLbl3
            // 
            this.GrindLbl3.AutoSize = true;
            this.GrindLbl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindLbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindLbl3.Location = new System.Drawing.Point(3, 573);
            this.GrindLbl3.Name = "GrindLbl3";
            this.GrindLbl3.Size = new System.Drawing.Size(320, 53);
            this.GrindLbl3.TabIndex = 156;
            this.GrindLbl3.Text = "Last Z Force";
            this.GrindLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentLineLblCopy
            // 
            this.CurrentLineLblCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunCenterColumnLayoutPanel.SetColumnSpan(this.CurrentLineLblCopy, 2);
            this.CurrentLineLblCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentLineLblCopy.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLineLblCopy.Location = new System.Drawing.Point(3, 212);
            this.CurrentLineLblCopy.Name = "CurrentLineLblCopy";
            this.CurrentLineLblCopy.Size = new System.Drawing.Size(646, 149);
            this.CurrentLineLblCopy.TabIndex = 125;
            // 
            // GrindLbl1
            // 
            this.GrindLbl1.AutoSize = true;
            this.GrindLbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindLbl1.Location = new System.Drawing.Point(3, 520);
            this.GrindLbl1.Name = "GrindLbl1";
            this.GrindLbl1.Size = new System.Drawing.Size(320, 53);
            this.GrindLbl1.TabIndex = 124;
            this.GrindLbl1.Text = "Grind Cycle";
            this.GrindLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 361);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(320, 53);
            this.label16.TabIndex = 143;
            this.label16.Text = "Time in Step";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StepTimeRemainingLbl
            // 
            this.StepTimeRemainingLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepTimeRemainingLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepTimeRemainingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepTimeRemainingLbl.Location = new System.Drawing.Point(329, 467);
            this.StepTimeRemainingLbl.Name = "StepTimeRemainingLbl";
            this.StepTimeRemainingLbl.Size = new System.Drawing.Size(320, 53);
            this.StepTimeRemainingLbl.TabIndex = 148;
            this.StepTimeRemainingLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StepElapsedTimeLbl
            // 
            this.StepElapsedTimeLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepElapsedTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepElapsedTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepElapsedTimeLbl.Location = new System.Drawing.Point(329, 361);
            this.StepElapsedTimeLbl.Name = "StepElapsedTimeLbl";
            this.StepElapsedTimeLbl.Size = new System.Drawing.Size(320, 53);
            this.StepElapsedTimeLbl.TabIndex = 144;
            this.StepElapsedTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 414);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(320, 53);
            this.label13.TabIndex = 145;
            this.label13.Text = "Time Estimate";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 467);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(320, 53);
            this.label17.TabIndex = 147;
            this.label17.Text = "Time Remaining";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StepTimeEstimateLbl
            // 
            this.StepTimeEstimateLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepTimeEstimateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StepTimeEstimateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepTimeEstimateLbl.Location = new System.Drawing.Point(329, 414);
            this.StepTimeEstimateLbl.Name = "StepTimeEstimateLbl";
            this.StepTimeEstimateLbl.Size = new System.Drawing.Size(320, 53);
            this.StepTimeEstimateLbl.TabIndex = 146;
            this.StepTimeEstimateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GrindNofNLayoutPanel
            // 
            this.GrindNofNLayoutPanel.ColumnCount = 3;
            this.GrindNofNLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GrindNofNLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GrindNofNLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GrindNofNLayoutPanel.Controls.Add(this.GrindCycleLbl, 0, 0);
            this.GrindNofNLayoutPanel.Controls.Add(this.GrindLbl2, 1, 0);
            this.GrindNofNLayoutPanel.Controls.Add(this.GrindNCyclesLbl, 2, 0);
            this.GrindNofNLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindNofNLayoutPanel.Location = new System.Drawing.Point(329, 523);
            this.GrindNofNLayoutPanel.Name = "GrindNofNLayoutPanel";
            this.GrindNofNLayoutPanel.RowCount = 1;
            this.GrindNofNLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GrindNofNLayoutPanel.Size = new System.Drawing.Size(320, 47);
            this.GrindNofNLayoutPanel.TabIndex = 156;
            // 
            // GrindCycleLbl
            // 
            this.GrindCycleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindCycleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindCycleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindCycleLbl.Location = new System.Drawing.Point(3, 0);
            this.GrindCycleLbl.Name = "GrindCycleLbl";
            this.GrindCycleLbl.Size = new System.Drawing.Size(100, 47);
            this.GrindCycleLbl.TabIndex = 126;
            this.GrindCycleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindLbl2
            // 
            this.GrindLbl2.AutoSize = true;
            this.GrindLbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindLbl2.Location = new System.Drawing.Point(109, 0);
            this.GrindLbl2.Name = "GrindLbl2";
            this.GrindLbl2.Size = new System.Drawing.Size(100, 47);
            this.GrindLbl2.TabIndex = 128;
            this.GrindLbl2.Text = "of";
            this.GrindLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindNCyclesLbl
            // 
            this.GrindNCyclesLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindNCyclesLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindNCyclesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindNCyclesLbl.Location = new System.Drawing.Point(215, 0);
            this.GrindNCyclesLbl.Name = "GrindNCyclesLbl";
            this.GrindNCyclesLbl.Size = new System.Drawing.Size(102, 47);
            this.GrindNCyclesLbl.TabIndex = 127;
            this.GrindNCyclesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LastReportedZLayoutPanel
            // 
            this.LastReportedZLayoutPanel.ColumnCount = 3;
            this.LastReportedZLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LastReportedZLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LastReportedZLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LastReportedZLayoutPanel.Controls.Add(this.GrindForceReportZLbl, 0, 0);
            this.LastReportedZLayoutPanel.Controls.Add(this.GrindLbl4, 1, 0);
            this.LastReportedZLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastReportedZLayoutPanel.Location = new System.Drawing.Point(329, 576);
            this.LastReportedZLayoutPanel.Name = "LastReportedZLayoutPanel";
            this.LastReportedZLayoutPanel.RowCount = 1;
            this.LastReportedZLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LastReportedZLayoutPanel.Size = new System.Drawing.Size(320, 47);
            this.LastReportedZLayoutPanel.TabIndex = 157;
            // 
            // GrindForceReportZLbl
            // 
            this.GrindForceReportZLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrindForceReportZLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindForceReportZLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindForceReportZLbl.Location = new System.Drawing.Point(3, 0);
            this.GrindForceReportZLbl.Name = "GrindForceReportZLbl";
            this.GrindForceReportZLbl.Size = new System.Drawing.Size(100, 47);
            this.GrindForceReportZLbl.TabIndex = 157;
            this.GrindForceReportZLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrindLbl4
            // 
            this.GrindLbl4.AutoSize = true;
            this.GrindLbl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindLbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindLbl4.Location = new System.Drawing.Point(109, 0);
            this.GrindLbl4.Name = "GrindLbl4";
            this.GrindLbl4.Size = new System.Drawing.Size(100, 47);
            this.GrindLbl4.TabIndex = 158;
            this.GrindLbl4.Text = "N";
            this.GrindLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoveToolMountLbl
            // 
            this.MoveToolMountLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveToolMountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolMountLbl.Location = new System.Drawing.Point(3, 626);
            this.MoveToolMountLbl.Name = "MoveToolMountLbl";
            this.RunCenterColumnLayoutPanel.SetRowSpan(this.MoveToolMountLbl, 2);
            this.MoveToolMountLbl.Size = new System.Drawing.Size(320, 106);
            this.MoveToolMountLbl.TabIndex = 139;
            this.MoveToolMountLbl.Text = "Joint Move to\r\nTool Mount Pose";
            this.MoveToolMountLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MoveToolHomeLbl
            // 
            this.MoveToolHomeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveToolHomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToolHomeLbl.Location = new System.Drawing.Point(329, 626);
            this.MoveToolHomeLbl.Name = "MoveToolHomeLbl";
            this.RunCenterColumnLayoutPanel.SetRowSpan(this.MoveToolHomeLbl, 2);
            this.MoveToolHomeLbl.Size = new System.Drawing.Size(320, 106);
            this.MoveToolHomeLbl.TabIndex = 141;
            this.MoveToolHomeLbl.Text = "Joint Move to\r\nTool Home Pose";
            this.MoveToolHomeLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CodePage
            // 
            this.CodePage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CodePage.Controls.Add(this.ProgramTableLayoutPanel);
            this.CodePage.Location = new System.Drawing.Point(4, 100);
            this.CodePage.Name = "CodePage";
            this.CodePage.Padding = new System.Windows.Forms.Padding(3);
            this.CodePage.Size = new System.Drawing.Size(1892, 808);
            this.CodePage.TabIndex = 1;
            this.CodePage.Text = "Code";
            this.CodePage.UseVisualStyleBackColor = true;
            // 
            // ProgramTableLayoutPanel
            // 
            this.ProgramTableLayoutPanel.ColumnCount = 2;
            this.ProgramTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.ProgramTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.ProgramTableLayoutPanel.Controls.Add(this.SequenceRTB, 0, 0);
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
            this.ProgramTableLayoutPanel.Size = new System.Drawing.Size(1882, 798);
            this.ProgramTableLayoutPanel.TabIndex = 96;
            // 
            // FileBigEditPanel
            // 
            this.FileBigEditPanel.ColumnCount = 2;
            this.FileBigEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileBigEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.FileBigEditPanel.Controls.Add(this.BigEditBtn, 1, 0);
            this.FileBigEditPanel.Controls.Add(this.SequenceFilenameLbl, 0, 0);
            this.FileBigEditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBigEditPanel.Location = new System.Drawing.Point(3, 711);
            this.FileBigEditPanel.Name = "FileBigEditPanel";
            this.FileBigEditPanel.RowCount = 1;
            this.FileBigEditPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileBigEditPanel.Size = new System.Drawing.Size(840, 84);
            this.FileBigEditPanel.TabIndex = 95;
            // 
            // BigEditBtn
            // 
            this.BigEditBtn.BackColor = System.Drawing.Color.Gray;
            this.BigEditBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BigEditBtn.Enabled = false;
            this.BigEditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BigEditBtn.ForeColor = System.Drawing.Color.White;
            this.BigEditBtn.Location = new System.Drawing.Point(642, 2);
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
            this.SetupPage.Controls.Add(this.SetupTab);
            this.SetupPage.Controls.Add(this.label19);
            this.SetupPage.Controls.Add(this.label8);
            this.SetupPage.Controls.Add(this.label7);
            this.SetupPage.Location = new System.Drawing.Point(4, 100);
            this.SetupPage.Name = "SetupPage";
            this.SetupPage.Size = new System.Drawing.Size(1892, 808);
            this.SetupPage.TabIndex = 2;
            this.SetupPage.Text = "Setup";
            this.SetupPage.UseVisualStyleBackColor = true;
            // 
            // SetupTab
            // 
            this.SetupTab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.SetupTab.Controls.Add(this.devicesPage);
            this.SetupTab.Controls.Add(this.displaysPage);
            this.SetupTab.Controls.Add(this.toolsPage);
            this.SetupTab.Controls.Add(this.robotPage);
            this.SetupTab.Controls.Add(this.generalPage);
            this.SetupTab.Controls.Add(this.licensePage);
            this.SetupTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupTab.ItemSize = new System.Drawing.Size(150, 96);
            this.SetupTab.Location = new System.Drawing.Point(0, 0);
            this.SetupTab.Name = "SetupTab";
            this.SetupTab.SelectedIndex = 0;
            this.SetupTab.Size = new System.Drawing.Size(1888, 804);
            this.SetupTab.TabIndex = 161;
            this.SetupTab.SelectedIndexChanged += new System.EventHandler(this.SetupTab_SelectedIndexChanged);
            // 
            // devicesPage
            // 
            this.devicesPage.Controls.Add(this.SetupDevicesLayoutPanel);
            this.devicesPage.Location = new System.Drawing.Point(4, 100);
            this.devicesPage.Name = "devicesPage";
            this.devicesPage.Padding = new System.Windows.Forms.Padding(3);
            this.devicesPage.Size = new System.Drawing.Size(1880, 700);
            this.devicesPage.TabIndex = 1;
            this.devicesPage.Text = "Devices";
            this.devicesPage.UseVisualStyleBackColor = true;
            // 
            // SetupDevicesLayoutPanel
            // 
            this.SetupDevicesLayoutPanel.ColumnCount = 12;
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.SetupDevicesLayoutPanel.Controls.Add(this.DeviceReconnectBtn, 2, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DeviceConnectBtn, 0, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DeviceDisconnectBtn, 1, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DevicesGrd, 0, 1);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DeviceConnectAllBtn, 10, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DeviceDisconnectAllBtn, 11, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.RuntimeAppHelperLayoutPanel2, 5, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.SetupAppHelperLayoutPanel2, 8, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.SetStartupDevicesFileBtn, 7, 2);
            this.SetupDevicesLayoutPanel.Controls.Add(this.ClearDevicesBtn, 11, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.SaveAsDevicesBtn, 10, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.SaveDevicesBtn, 9, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.LoadDevicesBtn, 8, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.ReloadDevicesBtn, 7, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.AutoConnectOnLoadChk, 9, 2);
            this.SetupDevicesLayoutPanel.Controls.Add(this.speedBtnsGrp, 0, 4);
            this.SetupDevicesLayoutPanel.Controls.Add(this.lbl4, 0, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.StartupDevicesLbl, 1, 3);
            this.SetupDevicesLayoutPanel.Controls.Add(this.DevicesFilenameLbl, 1, 2);
            this.SetupDevicesLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.SetupDevicesLayoutPanel.Controls.Add(this.RuntimeAppHelperLayoutPanel1, 4, 0);
            this.SetupDevicesLayoutPanel.Controls.Add(this.SetupAppHelperLayoutPanel1, 7, 0);
            this.SetupDevicesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupDevicesLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.SetupDevicesLayoutPanel.Name = "SetupDevicesLayoutPanel";
            this.SetupDevicesLayoutPanel.RowCount = 5;
            this.SetupDevicesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.54449F));
            this.SetupDevicesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.8513F));
            this.SetupDevicesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.897388F));
            this.SetupDevicesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.853413F));
            this.SetupDevicesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.853413F));
            this.SetupDevicesLayoutPanel.Size = new System.Drawing.Size(1874, 694);
            this.SetupDevicesLayoutPanel.TabIndex = 0;
            // 
            // DeviceReconnectBtn
            // 
            this.DeviceReconnectBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceReconnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceReconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceReconnectBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceReconnectBtn.Location = new System.Drawing.Point(314, 2);
            this.DeviceReconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceReconnectBtn.Name = "DeviceReconnectBtn";
            this.DeviceReconnectBtn.Size = new System.Drawing.Size(152, 103);
            this.DeviceReconnectBtn.TabIndex = 106;
            this.DeviceReconnectBtn.Text = "Reconnect";
            this.DeviceReconnectBtn.UseVisualStyleBackColor = false;
            this.DeviceReconnectBtn.Click += new System.EventHandler(this.DeviceReconnectBtn_Click);
            // 
            // DeviceConnectBtn
            // 
            this.DeviceConnectBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceConnectBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceConnectBtn.Location = new System.Drawing.Point(2, 2);
            this.DeviceConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceConnectBtn.Name = "DeviceConnectBtn";
            this.DeviceConnectBtn.Size = new System.Drawing.Size(152, 103);
            this.DeviceConnectBtn.TabIndex = 99;
            this.DeviceConnectBtn.Text = "Connect";
            this.DeviceConnectBtn.UseVisualStyleBackColor = false;
            this.DeviceConnectBtn.Click += new System.EventHandler(this.DeviceConnectBtn_Click);
            // 
            // DeviceDisconnectBtn
            // 
            this.DeviceDisconnectBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceDisconnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceDisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceDisconnectBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceDisconnectBtn.Location = new System.Drawing.Point(158, 2);
            this.DeviceDisconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceDisconnectBtn.Name = "DeviceDisconnectBtn";
            this.DeviceDisconnectBtn.Size = new System.Drawing.Size(152, 103);
            this.DeviceDisconnectBtn.TabIndex = 98;
            this.DeviceDisconnectBtn.Text = "Disconnect";
            this.DeviceDisconnectBtn.UseVisualStyleBackColor = false;
            this.DeviceDisconnectBtn.Click += new System.EventHandler(this.DeviceDisconnectBtn_Click);
            // 
            // DevicesGrd
            // 
            this.DevicesGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DevicesGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DevicesGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.DevicesGrd, 12);
            this.DevicesGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesGrd.Location = new System.Drawing.Point(3, 110);
            this.DevicesGrd.Name = "DevicesGrd";
            this.DevicesGrd.Size = new System.Drawing.Size(1868, 395);
            this.DevicesGrd.TabIndex = 89;
            this.DevicesGrd.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesGrd_RowEnter);
            // 
            // DeviceConnectAllBtn
            // 
            this.DeviceConnectAllBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceConnectAllBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceConnectAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceConnectAllBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceConnectAllBtn.Location = new System.Drawing.Point(1562, 2);
            this.DeviceConnectAllBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceConnectAllBtn.Name = "DeviceConnectAllBtn";
            this.DeviceConnectAllBtn.Size = new System.Drawing.Size(152, 103);
            this.DeviceConnectAllBtn.TabIndex = 107;
            this.DeviceConnectAllBtn.Text = "Connect All";
            this.DeviceConnectAllBtn.UseVisualStyleBackColor = false;
            this.DeviceConnectAllBtn.Click += new System.EventHandler(this.DeviceConnectAllBtn_Click);
            // 
            // DeviceDisconnectAllBtn
            // 
            this.DeviceDisconnectAllBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceDisconnectAllBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceDisconnectAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceDisconnectAllBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceDisconnectAllBtn.Location = new System.Drawing.Point(1718, 2);
            this.DeviceDisconnectAllBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceDisconnectAllBtn.Name = "DeviceDisconnectAllBtn";
            this.DeviceDisconnectAllBtn.Size = new System.Drawing.Size(154, 103);
            this.DeviceDisconnectAllBtn.TabIndex = 108;
            this.DeviceDisconnectAllBtn.Text = "Disconnect All";
            this.DeviceDisconnectAllBtn.UseVisualStyleBackColor = false;
            this.DeviceDisconnectAllBtn.Click += new System.EventHandler(this.DeviceDisconnectAllBtn_Click);
            // 
            // RuntimeAppHelperLayoutPanel2
            // 
            this.RuntimeAppHelperLayoutPanel2.ColumnCount = 1;
            this.RuntimeAppHelperLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RuntimeAppHelperLayoutPanel2.Controls.Add(this.DeviceRuntimeMinimizeBtn, 0, 1);
            this.RuntimeAppHelperLayoutPanel2.Controls.Add(this.DeviceRuntimeRestoreBtn, 0, 0);
            this.RuntimeAppHelperLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RuntimeAppHelperLayoutPanel2.Location = new System.Drawing.Point(783, 3);
            this.RuntimeAppHelperLayoutPanel2.Name = "RuntimeAppHelperLayoutPanel2";
            this.RuntimeAppHelperLayoutPanel2.RowCount = 2;
            this.RuntimeAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RuntimeAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RuntimeAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RuntimeAppHelperLayoutPanel2.Size = new System.Drawing.Size(150, 101);
            this.RuntimeAppHelperLayoutPanel2.TabIndex = 111;
            // 
            // DeviceRuntimeMinimizeBtn
            // 
            this.DeviceRuntimeMinimizeBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceRuntimeMinimizeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceRuntimeMinimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceRuntimeMinimizeBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceRuntimeMinimizeBtn.Location = new System.Drawing.Point(2, 52);
            this.DeviceRuntimeMinimizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRuntimeMinimizeBtn.Name = "DeviceRuntimeMinimizeBtn";
            this.DeviceRuntimeMinimizeBtn.Size = new System.Drawing.Size(146, 47);
            this.DeviceRuntimeMinimizeBtn.TabIndex = 114;
            this.DeviceRuntimeMinimizeBtn.Text = "Minimize";
            this.DeviceRuntimeMinimizeBtn.UseVisualStyleBackColor = false;
            this.DeviceRuntimeMinimizeBtn.Click += new System.EventHandler(this.DeviceRuntimeMinimizeBtn_Click);
            // 
            // DeviceRuntimeRestoreBtn
            // 
            this.DeviceRuntimeRestoreBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceRuntimeRestoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceRuntimeRestoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceRuntimeRestoreBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceRuntimeRestoreBtn.Location = new System.Drawing.Point(2, 2);
            this.DeviceRuntimeRestoreBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRuntimeRestoreBtn.Name = "DeviceRuntimeRestoreBtn";
            this.DeviceRuntimeRestoreBtn.Size = new System.Drawing.Size(146, 46);
            this.DeviceRuntimeRestoreBtn.TabIndex = 113;
            this.DeviceRuntimeRestoreBtn.Text = "Restore";
            this.DeviceRuntimeRestoreBtn.UseVisualStyleBackColor = false;
            this.DeviceRuntimeRestoreBtn.Click += new System.EventHandler(this.DeviceRuntimeRestoreBtn_Click);
            // 
            // SetupAppHelperLayoutPanel2
            // 
            this.SetupAppHelperLayoutPanel2.ColumnCount = 1;
            this.SetupAppHelperLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SetupAppHelperLayoutPanel2.Controls.Add(this.DeviceSetupRestoreBtn, 0, 0);
            this.SetupAppHelperLayoutPanel2.Controls.Add(this.DeviceSetupMinimizeBtn, 0, 1);
            this.SetupAppHelperLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupAppHelperLayoutPanel2.Location = new System.Drawing.Point(1251, 3);
            this.SetupAppHelperLayoutPanel2.Name = "SetupAppHelperLayoutPanel2";
            this.SetupAppHelperLayoutPanel2.RowCount = 2;
            this.SetupAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SetupAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SetupAppHelperLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SetupAppHelperLayoutPanel2.Size = new System.Drawing.Size(150, 101);
            this.SetupAppHelperLayoutPanel2.TabIndex = 112;
            // 
            // DeviceSetupRestoreBtn
            // 
            this.DeviceSetupRestoreBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceSetupRestoreBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSetupRestoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSetupRestoreBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceSetupRestoreBtn.Location = new System.Drawing.Point(2, 2);
            this.DeviceSetupRestoreBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceSetupRestoreBtn.Name = "DeviceSetupRestoreBtn";
            this.DeviceSetupRestoreBtn.Size = new System.Drawing.Size(146, 46);
            this.DeviceSetupRestoreBtn.TabIndex = 114;
            this.DeviceSetupRestoreBtn.Text = "Restore";
            this.DeviceSetupRestoreBtn.UseVisualStyleBackColor = false;
            this.DeviceSetupRestoreBtn.Click += new System.EventHandler(this.DeviceSetupRestoreBtn_Click);
            // 
            // DeviceSetupMinimizeBtn
            // 
            this.DeviceSetupMinimizeBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceSetupMinimizeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSetupMinimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSetupMinimizeBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceSetupMinimizeBtn.Location = new System.Drawing.Point(2, 52);
            this.DeviceSetupMinimizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceSetupMinimizeBtn.Name = "DeviceSetupMinimizeBtn";
            this.DeviceSetupMinimizeBtn.Size = new System.Drawing.Size(146, 47);
            this.DeviceSetupMinimizeBtn.TabIndex = 115;
            this.DeviceSetupMinimizeBtn.Text = "Minimize";
            this.DeviceSetupMinimizeBtn.UseVisualStyleBackColor = false;
            this.DeviceSetupMinimizeBtn.Click += new System.EventHandler(this.DeviceSetupMinimizeBtn_Click);
            // 
            // SetStartupDevicesFileBtn
            // 
            this.SetStartupDevicesFileBtn.BackColor = System.Drawing.Color.Green;
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.SetStartupDevicesFileBtn, 2);
            this.SetStartupDevicesFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetStartupDevicesFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetStartupDevicesFileBtn.ForeColor = System.Drawing.Color.White;
            this.SetStartupDevicesFileBtn.Location = new System.Drawing.Point(1095, 511);
            this.SetStartupDevicesFileBtn.Name = "SetStartupDevicesFileBtn";
            this.SetStartupDevicesFileBtn.Size = new System.Drawing.Size(306, 41);
            this.SetStartupDevicesFileBtn.TabIndex = 103;
            this.SetStartupDevicesFileBtn.Text = "Use This File At Startup";
            this.SetStartupDevicesFileBtn.UseVisualStyleBackColor = false;
            this.SetStartupDevicesFileBtn.Click += new System.EventHandler(this.SetStartupDevicesFileBtn_Click);
            // 
            // ClearDevicesBtn
            // 
            this.ClearDevicesBtn.BackColor = System.Drawing.Color.Green;
            this.ClearDevicesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearDevicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearDevicesBtn.ForeColor = System.Drawing.Color.White;
            this.ClearDevicesBtn.Location = new System.Drawing.Point(1719, 558);
            this.ClearDevicesBtn.Name = "ClearDevicesBtn";
            this.ClearDevicesBtn.Size = new System.Drawing.Size(152, 62);
            this.ClearDevicesBtn.TabIndex = 105;
            this.ClearDevicesBtn.Text = "Clear";
            this.ClearDevicesBtn.UseVisualStyleBackColor = false;
            this.ClearDevicesBtn.Click += new System.EventHandler(this.ClearDevicesBtn_Click);
            // 
            // SaveAsDevicesBtn
            // 
            this.SaveAsDevicesBtn.BackColor = System.Drawing.Color.Green;
            this.SaveAsDevicesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsDevicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsDevicesBtn.ForeColor = System.Drawing.Color.White;
            this.SaveAsDevicesBtn.Location = new System.Drawing.Point(1563, 558);
            this.SaveAsDevicesBtn.Name = "SaveAsDevicesBtn";
            this.SaveAsDevicesBtn.Size = new System.Drawing.Size(150, 62);
            this.SaveAsDevicesBtn.TabIndex = 104;
            this.SaveAsDevicesBtn.Text = "Save As...";
            this.SaveAsDevicesBtn.UseVisualStyleBackColor = false;
            this.SaveAsDevicesBtn.Click += new System.EventHandler(this.SaveAsDevicesBtn_Click);
            // 
            // SaveDevicesBtn
            // 
            this.SaveDevicesBtn.BackColor = System.Drawing.Color.Green;
            this.SaveDevicesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveDevicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDevicesBtn.ForeColor = System.Drawing.Color.White;
            this.SaveDevicesBtn.Location = new System.Drawing.Point(1407, 558);
            this.SaveDevicesBtn.Name = "SaveDevicesBtn";
            this.SaveDevicesBtn.Size = new System.Drawing.Size(150, 62);
            this.SaveDevicesBtn.TabIndex = 101;
            this.SaveDevicesBtn.Text = "Save";
            this.SaveDevicesBtn.UseVisualStyleBackColor = false;
            this.SaveDevicesBtn.Click += new System.EventHandler(this.SaveDevicesBtn_Click);
            // 
            // LoadDevicesBtn
            // 
            this.LoadDevicesBtn.BackColor = System.Drawing.Color.Green;
            this.LoadDevicesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadDevicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDevicesBtn.ForeColor = System.Drawing.Color.White;
            this.LoadDevicesBtn.Location = new System.Drawing.Point(1251, 558);
            this.LoadDevicesBtn.Name = "LoadDevicesBtn";
            this.LoadDevicesBtn.Size = new System.Drawing.Size(150, 62);
            this.LoadDevicesBtn.TabIndex = 113;
            this.LoadDevicesBtn.Text = "Load";
            this.LoadDevicesBtn.UseVisualStyleBackColor = false;
            this.LoadDevicesBtn.Click += new System.EventHandler(this.LoadDevicesBtn_Click);
            // 
            // ReloadDevicesBtn
            // 
            this.ReloadDevicesBtn.BackColor = System.Drawing.Color.Green;
            this.ReloadDevicesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReloadDevicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadDevicesBtn.ForeColor = System.Drawing.Color.White;
            this.ReloadDevicesBtn.Location = new System.Drawing.Point(1095, 558);
            this.ReloadDevicesBtn.Name = "ReloadDevicesBtn";
            this.ReloadDevicesBtn.Size = new System.Drawing.Size(150, 62);
            this.ReloadDevicesBtn.TabIndex = 100;
            this.ReloadDevicesBtn.Text = "Reload";
            this.ReloadDevicesBtn.UseVisualStyleBackColor = false;
            this.ReloadDevicesBtn.Click += new System.EventHandler(this.ReloadDevicesBtn_Click);
            // 
            // AutoConnectOnLoadChk
            // 
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.AutoConnectOnLoadChk, 3);
            this.AutoConnectOnLoadChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoConnectOnLoadChk.Location = new System.Drawing.Point(1407, 511);
            this.AutoConnectOnLoadChk.Name = "AutoConnectOnLoadChk";
            this.AutoConnectOnLoadChk.Size = new System.Drawing.Size(464, 30);
            this.AutoConnectOnLoadChk.TabIndex = 118;
            this.AutoConnectOnLoadChk.Text = "     Auto Connect On Load";
            this.AutoConnectOnLoadChk.UseVisualStyleBackColor = true;
            // 
            // speedBtnsGrp
            // 
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.speedBtnsGrp, 12);
            this.speedBtnsGrp.Controls.Add(this.SpeedSendBtn1);
            this.speedBtnsGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedBtnsGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedBtnsGrp.Location = new System.Drawing.Point(3, 626);
            this.speedBtnsGrp.Name = "speedBtnsGrp";
            this.speedBtnsGrp.Size = new System.Drawing.Size(1868, 65);
            this.speedBtnsGrp.TabIndex = 114;
            this.speedBtnsGrp.TabStop = false;
            this.speedBtnsGrp.Text = "Speed Send Buttons";
            // 
            // SpeedSendBtn1
            // 
            this.SpeedSendBtn1.Location = new System.Drawing.Point(6, 28);
            this.SpeedSendBtn1.Name = "SpeedSendBtn1";
            this.SpeedSendBtn1.Size = new System.Drawing.Size(145, 31);
            this.SpeedSendBtn1.TabIndex = 71;
            this.SpeedSendBtn1.Text = "Speed 1";
            this.SpeedSendBtn1.UseVisualStyleBackColor = true;
            this.SpeedSendBtn1.Click += new System.EventHandler(this.SpeedSendBtn1_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(3, 555);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(150, 68);
            this.lbl4.TabIndex = 120;
            this.lbl4.Text = "Startup File";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StartupDevicesLbl
            // 
            this.StartupDevicesLbl.AutoSize = true;
            this.StartupDevicesLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.StartupDevicesLbl, 6);
            this.StartupDevicesLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartupDevicesLbl.Location = new System.Drawing.Point(159, 555);
            this.StartupDevicesLbl.Name = "StartupDevicesLbl";
            this.StartupDevicesLbl.Size = new System.Drawing.Size(930, 68);
            this.StartupDevicesLbl.TabIndex = 121;
            this.StartupDevicesLbl.Text = "StartupDevicesLbl";
            this.StartupDevicesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DevicesFilenameLbl
            // 
            this.DevicesFilenameLbl.AutoSize = true;
            this.DevicesFilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupDevicesLayoutPanel.SetColumnSpan(this.DevicesFilenameLbl, 6);
            this.DevicesFilenameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesFilenameLbl.Location = new System.Drawing.Point(159, 508);
            this.DevicesFilenameLbl.Name = "DevicesFilenameLbl";
            this.DevicesFilenameLbl.Size = new System.Drawing.Size(930, 47);
            this.DevicesFilenameLbl.TabIndex = 102;
            this.DevicesFilenameLbl.Text = "Untitled";
            this.DevicesFilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 47);
            this.label2.TabIndex = 122;
            this.label2.Text = "Current";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RuntimeAppHelperLayoutPanel1
            // 
            this.RuntimeAppHelperLayoutPanel1.ColumnCount = 1;
            this.RuntimeAppHelperLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RuntimeAppHelperLayoutPanel1.Controls.Add(this.DeviceRuntimeExitBtn, 0, 1);
            this.RuntimeAppHelperLayoutPanel1.Controls.Add(this.DeviceRuntimeStartBtn, 0, 0);
            this.RuntimeAppHelperLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RuntimeAppHelperLayoutPanel1.Location = new System.Drawing.Point(627, 3);
            this.RuntimeAppHelperLayoutPanel1.Name = "RuntimeAppHelperLayoutPanel1";
            this.RuntimeAppHelperLayoutPanel1.RowCount = 2;
            this.RuntimeAppHelperLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RuntimeAppHelperLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RuntimeAppHelperLayoutPanel1.Size = new System.Drawing.Size(150, 101);
            this.RuntimeAppHelperLayoutPanel1.TabIndex = 123;
            // 
            // DeviceRuntimeExitBtn
            // 
            this.DeviceRuntimeExitBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceRuntimeExitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceRuntimeExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceRuntimeExitBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceRuntimeExitBtn.Location = new System.Drawing.Point(2, 52);
            this.DeviceRuntimeExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRuntimeExitBtn.Name = "DeviceRuntimeExitBtn";
            this.DeviceRuntimeExitBtn.Size = new System.Drawing.Size(146, 47);
            this.DeviceRuntimeExitBtn.TabIndex = 115;
            this.DeviceRuntimeExitBtn.Text = "Stop";
            this.DeviceRuntimeExitBtn.UseVisualStyleBackColor = false;
            this.DeviceRuntimeExitBtn.Click += new System.EventHandler(this.DeviceRuntimeExitBtn_Click);
            // 
            // DeviceRuntimeStartBtn
            // 
            this.DeviceRuntimeStartBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceRuntimeStartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceRuntimeStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceRuntimeStartBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceRuntimeStartBtn.Location = new System.Drawing.Point(2, 2);
            this.DeviceRuntimeStartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRuntimeStartBtn.Name = "DeviceRuntimeStartBtn";
            this.DeviceRuntimeStartBtn.Size = new System.Drawing.Size(146, 46);
            this.DeviceRuntimeStartBtn.TabIndex = 109;
            this.DeviceRuntimeStartBtn.Text = "Runtime";
            this.DeviceRuntimeStartBtn.UseVisualStyleBackColor = false;
            this.DeviceRuntimeStartBtn.Click += new System.EventHandler(this.DeviceRuntimeStartBtn_Click);
            // 
            // SetupAppHelperLayoutPanel1
            // 
            this.SetupAppHelperLayoutPanel1.ColumnCount = 1;
            this.SetupAppHelperLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SetupAppHelperLayoutPanel1.Controls.Add(this.DeviceSetupExitBtn, 0, 1);
            this.SetupAppHelperLayoutPanel1.Controls.Add(this.DeviceSetupStartBtn, 0, 0);
            this.SetupAppHelperLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupAppHelperLayoutPanel1.Location = new System.Drawing.Point(1095, 3);
            this.SetupAppHelperLayoutPanel1.Name = "SetupAppHelperLayoutPanel1";
            this.SetupAppHelperLayoutPanel1.RowCount = 2;
            this.SetupAppHelperLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SetupAppHelperLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SetupAppHelperLayoutPanel1.Size = new System.Drawing.Size(150, 101);
            this.SetupAppHelperLayoutPanel1.TabIndex = 124;
            // 
            // DeviceSetupExitBtn
            // 
            this.DeviceSetupExitBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceSetupExitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSetupExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSetupExitBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceSetupExitBtn.Location = new System.Drawing.Point(2, 52);
            this.DeviceSetupExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceSetupExitBtn.Name = "DeviceSetupExitBtn";
            this.DeviceSetupExitBtn.Size = new System.Drawing.Size(146, 47);
            this.DeviceSetupExitBtn.TabIndex = 116;
            this.DeviceSetupExitBtn.Text = "Stop";
            this.DeviceSetupExitBtn.UseVisualStyleBackColor = false;
            this.DeviceSetupExitBtn.Click += new System.EventHandler(this.DeviceSetupExitBtn_Click);
            // 
            // DeviceSetupStartBtn
            // 
            this.DeviceSetupStartBtn.BackColor = System.Drawing.Color.Green;
            this.DeviceSetupStartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceSetupStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSetupStartBtn.ForeColor = System.Drawing.Color.White;
            this.DeviceSetupStartBtn.Location = new System.Drawing.Point(2, 2);
            this.DeviceSetupStartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceSetupStartBtn.Name = "DeviceSetupStartBtn";
            this.DeviceSetupStartBtn.Size = new System.Drawing.Size(146, 46);
            this.DeviceSetupStartBtn.TabIndex = 110;
            this.DeviceSetupStartBtn.Text = "Setup";
            this.DeviceSetupStartBtn.UseVisualStyleBackColor = false;
            this.DeviceSetupStartBtn.Click += new System.EventHandler(this.DeviceSetupStartBtn_Click);
            // 
            // displaysPage
            // 
            this.displaysPage.Controls.Add(this.SetupDisplayLayoutPanel);
            this.displaysPage.Controls.Add(this.label24);
            this.displaysPage.Location = new System.Drawing.Point(4, 100);
            this.displaysPage.Name = "displaysPage";
            this.displaysPage.Size = new System.Drawing.Size(1880, 700);
            this.displaysPage.TabIndex = 6;
            this.displaysPage.Text = "Displays";
            this.displaysPage.UseVisualStyleBackColor = true;
            // 
            // SetupDisplayLayoutPanel
            // 
            this.SetupDisplayLayoutPanel.ColumnCount = 11;
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupDisplayLayoutPanel.Controls.Add(this.DisplaysGrd, 0, 1);
            this.SetupDisplayLayoutPanel.Controls.Add(this.SelectDisplayBtn, 0, 0);
            this.SetupDisplayLayoutPanel.Controls.Add(this.LoadDisplaysBtn, 8, 2);
            this.SetupDisplayLayoutPanel.Controls.Add(this.SaveDisplaysBtn, 9, 2);
            this.SetupDisplayLayoutPanel.Controls.Add(this.ClearDisplaysButton, 10, 2);
            this.SetupDisplayLayoutPanel.Controls.Add(this.label3, 6, 0);
            this.SetupDisplayLayoutPanel.Controls.Add(this.SelectedDisplayLbl, 8, 0);
            this.SetupDisplayLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupDisplayLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SetupDisplayLayoutPanel.Name = "SetupDisplayLayoutPanel";
            this.SetupDisplayLayoutPanel.RowCount = 3;
            this.SetupDisplayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76245F));
            this.SetupDisplayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.7283F));
            this.SetupDisplayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50925F));
            this.SetupDisplayLayoutPanel.Size = new System.Drawing.Size(1880, 700);
            this.SetupDisplayLayoutPanel.TabIndex = 22;
            // 
            // DisplaysGrd
            // 
            this.DisplaysGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DisplaysGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DisplaysGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DisplaysGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SetupDisplayLayoutPanel.SetColumnSpan(this.DisplaysGrd, 11);
            this.DisplaysGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplaysGrd.Location = new System.Drawing.Point(3, 85);
            this.DisplaysGrd.Name = "DisplaysGrd";
            this.DisplaysGrd.RowTemplate.Height = 34;
            this.DisplaysGrd.Size = new System.Drawing.Size(1874, 531);
            this.DisplaysGrd.TabIndex = 85;
            // 
            // SelectDisplayBtn
            // 
            this.SelectDisplayBtn.BackColor = System.Drawing.Color.Green;
            this.SelectDisplayBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectDisplayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDisplayBtn.ForeColor = System.Drawing.Color.White;
            this.SelectDisplayBtn.Location = new System.Drawing.Point(3, 3);
            this.SelectDisplayBtn.Name = "SelectDisplayBtn";
            this.SelectDisplayBtn.Size = new System.Drawing.Size(164, 76);
            this.SelectDisplayBtn.TabIndex = 95;
            this.SelectDisplayBtn.Text = "Select";
            this.SelectDisplayBtn.UseVisualStyleBackColor = false;
            this.SelectDisplayBtn.Click += new System.EventHandler(this.SelectDisplayBtn_Click);
            // 
            // LoadDisplaysBtn
            // 
            this.LoadDisplaysBtn.BackColor = System.Drawing.Color.Green;
            this.LoadDisplaysBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadDisplaysBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDisplaysBtn.ForeColor = System.Drawing.Color.White;
            this.LoadDisplaysBtn.Location = new System.Drawing.Point(1363, 622);
            this.LoadDisplaysBtn.Name = "LoadDisplaysBtn";
            this.LoadDisplaysBtn.Size = new System.Drawing.Size(164, 75);
            this.LoadDisplaysBtn.TabIndex = 94;
            this.LoadDisplaysBtn.Text = "Reload";
            this.LoadDisplaysBtn.UseVisualStyleBackColor = false;
            this.LoadDisplaysBtn.Click += new System.EventHandler(this.LoadDisplaysBtn_Click);
            // 
            // SaveDisplaysBtn
            // 
            this.SaveDisplaysBtn.BackColor = System.Drawing.Color.Green;
            this.SaveDisplaysBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveDisplaysBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDisplaysBtn.ForeColor = System.Drawing.Color.White;
            this.SaveDisplaysBtn.Location = new System.Drawing.Point(1533, 622);
            this.SaveDisplaysBtn.Name = "SaveDisplaysBtn";
            this.SaveDisplaysBtn.Size = new System.Drawing.Size(164, 75);
            this.SaveDisplaysBtn.TabIndex = 93;
            this.SaveDisplaysBtn.Text = "Save";
            this.SaveDisplaysBtn.UseVisualStyleBackColor = false;
            this.SaveDisplaysBtn.Click += new System.EventHandler(this.SaveDisplaysBtn_Click);
            // 
            // ClearDisplaysButton
            // 
            this.ClearDisplaysButton.BackColor = System.Drawing.Color.Green;
            this.ClearDisplaysButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearDisplaysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearDisplaysButton.ForeColor = System.Drawing.Color.White;
            this.ClearDisplaysButton.Location = new System.Drawing.Point(1703, 622);
            this.ClearDisplaysButton.Name = "ClearDisplaysButton";
            this.ClearDisplaysButton.Size = new System.Drawing.Size(174, 75);
            this.ClearDisplaysButton.TabIndex = 92;
            this.ClearDisplaysButton.Text = "Clear";
            this.ClearDisplaysButton.UseVisualStyleBackColor = false;
            this.ClearDisplaysButton.Click += new System.EventHandler(this.ClearDisplaysButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.SetupDisplayLayoutPanel.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1023, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 31);
            this.label3.TabIndex = 96;
            this.label3.Text = "Selected:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectedDisplayLbl
            // 
            this.SelectedDisplayLbl.AutoSize = true;
            this.SelectedDisplayLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupDisplayLayoutPanel.SetColumnSpan(this.SelectedDisplayLbl, 3);
            this.SelectedDisplayLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectedDisplayLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedDisplayLbl.Location = new System.Drawing.Point(1363, 49);
            this.SelectedDisplayLbl.Name = "SelectedDisplayLbl";
            this.SelectedDisplayLbl.Size = new System.Drawing.Size(514, 33);
            this.SelectedDisplayLbl.TabIndex = 97;
            this.SelectedDisplayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(406, 463);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 37);
            this.label24.TabIndex = 20;
            this.label24.Text = "%";
            // 
            // toolsPage
            // 
            this.toolsPage.Controls.Add(this.SetupToolsLayoutPanel);
            this.toolsPage.Location = new System.Drawing.Point(4, 100);
            this.toolsPage.Name = "toolsPage";
            this.toolsPage.Padding = new System.Windows.Forms.Padding(3);
            this.toolsPage.Size = new System.Drawing.Size(1880, 700);
            this.toolsPage.TabIndex = 0;
            this.toolsPage.Text = "Tools";
            this.toolsPage.UseVisualStyleBackColor = true;
            // 
            // SetupToolsLayoutPanel
            // 
            this.SetupToolsLayoutPanel.ColumnCount = 11;
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.SetupToolsLayoutPanel.Controls.Add(this.SetDoorClosedInputBtn, 3, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.SetFootswitchPressedInputBtn, 0, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.FootswitchIoLayoutPanel, 1, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.DoorIoLayoutPanel, 4, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.ToolsGrd, 0, 1);
            this.SetupToolsLayoutPanel.Controls.Add(this.SelectToolBtn, 0, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.JointMoveMountBtn, 1, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.JointMoveHomeBtn, 2, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.ToolTestBtn, 3, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.ToolOffBtn, 4, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.CoolantTestBtn, 5, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.CoolantOffBtn, 6, 0);
            this.SetupToolsLayoutPanel.Controls.Add(this.LoadToolsBtn, 8, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.SaveToolsBtn, 9, 2);
            this.SetupToolsLayoutPanel.Controls.Add(this.ClearToolsBtn, 10, 2);
            this.SetupToolsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupToolsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.SetupToolsLayoutPanel.Name = "SetupToolsLayoutPanel";
            this.SetupToolsLayoutPanel.RowCount = 3;
            this.SetupToolsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76245F));
            this.SetupToolsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.7283F));
            this.SetupToolsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50925F));
            this.SetupToolsLayoutPanel.Size = new System.Drawing.Size(1874, 694);
            this.SetupToolsLayoutPanel.TabIndex = 0;
            // 
            // SetDoorClosedInputBtn
            // 
            this.SetDoorClosedInputBtn.BackColor = System.Drawing.Color.Green;
            this.SetDoorClosedInputBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetDoorClosedInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetDoorClosedInputBtn.ForeColor = System.Drawing.Color.White;
            this.SetDoorClosedInputBtn.Location = new System.Drawing.Point(513, 616);
            this.SetDoorClosedInputBtn.Name = "SetDoorClosedInputBtn";
            this.SetDoorClosedInputBtn.Size = new System.Drawing.Size(164, 75);
            this.SetDoorClosedInputBtn.TabIndex = 96;
            this.SetDoorClosedInputBtn.Text = "Set Door Closed Input";
            this.SetDoorClosedInputBtn.UseVisualStyleBackColor = false;
            this.SetDoorClosedInputBtn.Click += new System.EventHandler(this.SetDoorClosedInputBtn_Click);
            // 
            // SetFootswitchPressedInputBtn
            // 
            this.SetFootswitchPressedInputBtn.BackColor = System.Drawing.Color.Green;
            this.SetFootswitchPressedInputBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetFootswitchPressedInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetFootswitchPressedInputBtn.ForeColor = System.Drawing.Color.White;
            this.SetFootswitchPressedInputBtn.Location = new System.Drawing.Point(3, 616);
            this.SetFootswitchPressedInputBtn.Name = "SetFootswitchPressedInputBtn";
            this.SetFootswitchPressedInputBtn.Size = new System.Drawing.Size(164, 75);
            this.SetFootswitchPressedInputBtn.TabIndex = 121;
            this.SetFootswitchPressedInputBtn.Text = "Set Footswitch Pressed Input";
            this.SetFootswitchPressedInputBtn.UseVisualStyleBackColor = false;
            this.SetFootswitchPressedInputBtn.Click += new System.EventHandler(this.SetFootswitchInputBtn_Click);
            // 
            // FootswitchIoLayoutPanel
            // 
            this.FootswitchIoLayoutPanel.ColumnCount = 1;
            this.FootswitchIoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FootswitchIoLayoutPanel.Controls.Add(this.FootswitchPressedInputTxt, 0, 0);
            this.FootswitchIoLayoutPanel.Controls.Add(this.FootswitchPressedInputLbl, 0, 1);
            this.FootswitchIoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FootswitchIoLayoutPanel.Location = new System.Drawing.Point(173, 616);
            this.FootswitchIoLayoutPanel.Name = "FootswitchIoLayoutPanel";
            this.FootswitchIoLayoutPanel.RowCount = 2;
            this.FootswitchIoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FootswitchIoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FootswitchIoLayoutPanel.Size = new System.Drawing.Size(164, 75);
            this.FootswitchIoLayoutPanel.TabIndex = 129;
            // 
            // FootswitchPressedInputTxt
            // 
            this.FootswitchPressedInputTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FootswitchPressedInputTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FootswitchPressedInputTxt.Location = new System.Drawing.Point(3, 3);
            this.FootswitchPressedInputTxt.Name = "FootswitchPressedInputTxt";
            this.FootswitchPressedInputTxt.Size = new System.Drawing.Size(158, 35);
            this.FootswitchPressedInputTxt.TabIndex = 122;
            this.FootswitchPressedInputTxt.Text = "7,1";
            // 
            // FootswitchPressedInputLbl
            // 
            this.FootswitchPressedInputLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FootswitchPressedInputLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FootswitchPressedInputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FootswitchPressedInputLbl.Location = new System.Drawing.Point(3, 37);
            this.FootswitchPressedInputLbl.Name = "FootswitchPressedInputLbl";
            this.FootswitchPressedInputLbl.Size = new System.Drawing.Size(158, 38);
            this.FootswitchPressedInputLbl.TabIndex = 123;
            this.FootswitchPressedInputLbl.Text = "7,1";
            this.FootswitchPressedInputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoorIoLayoutPanel
            // 
            this.DoorIoLayoutPanel.ColumnCount = 1;
            this.DoorIoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DoorIoLayoutPanel.Controls.Add(this.DoorClosedInputLbl, 0, 1);
            this.DoorIoLayoutPanel.Controls.Add(this.DoorClosedInputTxt, 0, 0);
            this.DoorIoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoorIoLayoutPanel.Location = new System.Drawing.Point(683, 616);
            this.DoorIoLayoutPanel.Name = "DoorIoLayoutPanel";
            this.DoorIoLayoutPanel.RowCount = 2;
            this.DoorIoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DoorIoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DoorIoLayoutPanel.Size = new System.Drawing.Size(164, 75);
            this.DoorIoLayoutPanel.TabIndex = 130;
            // 
            // DoorClosedInputLbl
            // 
            this.DoorClosedInputLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoorClosedInputLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoorClosedInputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorClosedInputLbl.Location = new System.Drawing.Point(3, 37);
            this.DoorClosedInputLbl.Name = "DoorClosedInputLbl";
            this.DoorClosedInputLbl.Size = new System.Drawing.Size(158, 38);
            this.DoorClosedInputLbl.TabIndex = 124;
            this.DoorClosedInputLbl.Text = "1,1";
            this.DoorClosedInputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoorClosedInputTxt
            // 
            this.DoorClosedInputTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoorClosedInputTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorClosedInputTxt.Location = new System.Drawing.Point(3, 3);
            this.DoorClosedInputTxt.Name = "DoorClosedInputTxt";
            this.DoorClosedInputTxt.Size = new System.Drawing.Size(158, 35);
            this.DoorClosedInputTxt.TabIndex = 118;
            this.DoorClosedInputTxt.Text = "1,1";
            // 
            // ToolsGrd
            // 
            this.ToolsGrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ToolsGrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolsGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ToolsGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SetupToolsLayoutPanel.SetColumnSpan(this.ToolsGrd, 11);
            this.ToolsGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsGrd.Location = new System.Drawing.Point(3, 84);
            this.ToolsGrd.Name = "ToolsGrd";
            this.ToolsGrd.RowTemplate.Height = 34;
            this.ToolsGrd.Size = new System.Drawing.Size(1868, 526);
            this.ToolsGrd.TabIndex = 85;
            // 
            // SelectToolBtn
            // 
            this.SelectToolBtn.BackColor = System.Drawing.Color.Green;
            this.SelectToolBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectToolBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectToolBtn.ForeColor = System.Drawing.Color.White;
            this.SelectToolBtn.Location = new System.Drawing.Point(3, 3);
            this.SelectToolBtn.Name = "SelectToolBtn";
            this.SelectToolBtn.Size = new System.Drawing.Size(164, 75);
            this.SelectToolBtn.TabIndex = 95;
            this.SelectToolBtn.Text = "Select";
            this.SelectToolBtn.UseVisualStyleBackColor = false;
            this.SelectToolBtn.Click += new System.EventHandler(this.SelectToolBtn_Click);
            // 
            // JointMoveMountBtn
            // 
            this.JointMoveMountBtn.BackColor = System.Drawing.Color.Green;
            this.JointMoveMountBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JointMoveMountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JointMoveMountBtn.ForeColor = System.Drawing.Color.White;
            this.JointMoveMountBtn.Location = new System.Drawing.Point(173, 3);
            this.JointMoveMountBtn.Name = "JointMoveMountBtn";
            this.JointMoveMountBtn.Size = new System.Drawing.Size(164, 75);
            this.JointMoveMountBtn.TabIndex = 120;
            this.JointMoveMountBtn.Text = "Joint Move to Mount";
            this.JointMoveMountBtn.UseVisualStyleBackColor = false;
            this.JointMoveMountBtn.Click += new System.EventHandler(this.JointMoveMountBtn_Click);
            // 
            // JointMoveHomeBtn
            // 
            this.JointMoveHomeBtn.BackColor = System.Drawing.Color.Green;
            this.JointMoveHomeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JointMoveHomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JointMoveHomeBtn.ForeColor = System.Drawing.Color.White;
            this.JointMoveHomeBtn.Location = new System.Drawing.Point(343, 3);
            this.JointMoveHomeBtn.Name = "JointMoveHomeBtn";
            this.JointMoveHomeBtn.Size = new System.Drawing.Size(164, 75);
            this.JointMoveHomeBtn.TabIndex = 119;
            this.JointMoveHomeBtn.Text = "Joint Move to Home";
            this.JointMoveHomeBtn.UseVisualStyleBackColor = false;
            this.JointMoveHomeBtn.Click += new System.EventHandler(this.JointMoveHomeBtn_Click);
            // 
            // ToolTestBtn
            // 
            this.ToolTestBtn.BackColor = System.Drawing.Color.Green;
            this.ToolTestBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolTestBtn.ForeColor = System.Drawing.Color.White;
            this.ToolTestBtn.Location = new System.Drawing.Point(513, 3);
            this.ToolTestBtn.Name = "ToolTestBtn";
            this.ToolTestBtn.Size = new System.Drawing.Size(164, 75);
            this.ToolTestBtn.TabIndex = 125;
            this.ToolTestBtn.Text = "Tool Test";
            this.ToolTestBtn.UseVisualStyleBackColor = false;
            this.ToolTestBtn.Click += new System.EventHandler(this.ToolTestBtn_Click);
            // 
            // ToolOffBtn
            // 
            this.ToolOffBtn.BackColor = System.Drawing.Color.Green;
            this.ToolOffBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolOffBtn.ForeColor = System.Drawing.Color.White;
            this.ToolOffBtn.Location = new System.Drawing.Point(683, 3);
            this.ToolOffBtn.Name = "ToolOffBtn";
            this.ToolOffBtn.Size = new System.Drawing.Size(164, 75);
            this.ToolOffBtn.TabIndex = 126;
            this.ToolOffBtn.Text = "Tool Off";
            this.ToolOffBtn.UseVisualStyleBackColor = false;
            this.ToolOffBtn.Click += new System.EventHandler(this.ToolOffBtn_Click);
            // 
            // CoolantTestBtn
            // 
            this.CoolantTestBtn.BackColor = System.Drawing.Color.Green;
            this.CoolantTestBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoolantTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoolantTestBtn.ForeColor = System.Drawing.Color.White;
            this.CoolantTestBtn.Location = new System.Drawing.Point(853, 3);
            this.CoolantTestBtn.Name = "CoolantTestBtn";
            this.CoolantTestBtn.Size = new System.Drawing.Size(164, 75);
            this.CoolantTestBtn.TabIndex = 127;
            this.CoolantTestBtn.Text = "Cool Test";
            this.CoolantTestBtn.UseVisualStyleBackColor = false;
            this.CoolantTestBtn.Click += new System.EventHandler(this.CoolantTestBtn_Click);
            // 
            // CoolantOffBtn
            // 
            this.CoolantOffBtn.BackColor = System.Drawing.Color.Green;
            this.CoolantOffBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoolantOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoolantOffBtn.ForeColor = System.Drawing.Color.White;
            this.CoolantOffBtn.Location = new System.Drawing.Point(1023, 3);
            this.CoolantOffBtn.Name = "CoolantOffBtn";
            this.CoolantOffBtn.Size = new System.Drawing.Size(164, 75);
            this.CoolantOffBtn.TabIndex = 128;
            this.CoolantOffBtn.Text = "Cool Off";
            this.CoolantOffBtn.UseVisualStyleBackColor = false;
            this.CoolantOffBtn.Click += new System.EventHandler(this.CoolantOffBtn_Click);
            // 
            // LoadToolsBtn
            // 
            this.LoadToolsBtn.BackColor = System.Drawing.Color.Green;
            this.LoadToolsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadToolsBtn.ForeColor = System.Drawing.Color.White;
            this.LoadToolsBtn.Location = new System.Drawing.Point(1363, 616);
            this.LoadToolsBtn.Name = "LoadToolsBtn";
            this.LoadToolsBtn.Size = new System.Drawing.Size(164, 75);
            this.LoadToolsBtn.TabIndex = 94;
            this.LoadToolsBtn.Text = "Reload";
            this.LoadToolsBtn.UseVisualStyleBackColor = false;
            this.LoadToolsBtn.Click += new System.EventHandler(this.LoadToolsBtn_Click);
            // 
            // SaveToolsBtn
            // 
            this.SaveToolsBtn.BackColor = System.Drawing.Color.Green;
            this.SaveToolsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveToolsBtn.ForeColor = System.Drawing.Color.White;
            this.SaveToolsBtn.Location = new System.Drawing.Point(1533, 616);
            this.SaveToolsBtn.Name = "SaveToolsBtn";
            this.SaveToolsBtn.Size = new System.Drawing.Size(164, 75);
            this.SaveToolsBtn.TabIndex = 93;
            this.SaveToolsBtn.Text = "Save";
            this.SaveToolsBtn.UseVisualStyleBackColor = false;
            this.SaveToolsBtn.Click += new System.EventHandler(this.SaveToolsBtn_Click);
            // 
            // ClearToolsBtn
            // 
            this.ClearToolsBtn.BackColor = System.Drawing.Color.Green;
            this.ClearToolsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearToolsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearToolsBtn.ForeColor = System.Drawing.Color.White;
            this.ClearToolsBtn.Location = new System.Drawing.Point(1703, 616);
            this.ClearToolsBtn.Name = "ClearToolsBtn";
            this.ClearToolsBtn.Size = new System.Drawing.Size(168, 75);
            this.ClearToolsBtn.TabIndex = 92;
            this.ClearToolsBtn.Text = "Clear";
            this.ClearToolsBtn.UseVisualStyleBackColor = false;
            this.ClearToolsBtn.Click += new System.EventHandler(this.ClearToolsBtn_Click);
            // 
            // robotPage
            // 
            this.robotPage.Controls.Add(this.SetupGrindLayoutPanel);
            this.robotPage.Location = new System.Drawing.Point(4, 100);
            this.robotPage.Name = "robotPage";
            this.robotPage.Size = new System.Drawing.Size(1880, 700);
            this.robotPage.TabIndex = 2;
            this.robotPage.Text = "Robots";
            this.robotPage.UseVisualStyleBackColor = true;
            // 
            // SetupGrindLayoutPanel
            // 
            this.SetupGrindLayoutPanel.ColumnCount = 8;
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupGrindLayoutPanel.Controls.Add(this.SetMoveDefaultsBtn, 3, 3);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetPointFrequencyBtn, 5, 1);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetBlendRadiusBtn, 2, 3);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetForceModeGainScalingBtn, 3, 1);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetForceModeDampingBtn, 2, 1);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetJointAccelBtn, 1, 4);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetTrialSpeedBtn, 0, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetJointSpeedBtn, 1, 3);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetGrindAccelBtn, 1, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetGrindJogAccelBtn, 1, 1);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetMaxGrindBlendRadiusBtn, 2, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetLinearSpeedBtn, 0, 3);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetGrindJogSpeedBtn, 0, 1);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetTouchSpeedBtn, 3, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetTouchRetractBtn, 4, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetForceDwellBtn, 5, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetMaxWaitBtn, 6, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetGrindDefaultsBtn, 7, 0);
            this.SetupGrindLayoutPanel.Controls.Add(this.SetLinearAccelBtn, 0, 4);
            this.SetupGrindLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupGrindLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SetupGrindLayoutPanel.Name = "SetupGrindLayoutPanel";
            this.SetupGrindLayoutPanel.RowCount = 6;
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGrindLayoutPanel.Size = new System.Drawing.Size(1880, 700);
            this.SetupGrindLayoutPanel.TabIndex = 0;
            // 
            // SetMoveDefaultsBtn
            // 
            this.SetMoveDefaultsBtn.BackColor = System.Drawing.Color.Green;
            this.SetMoveDefaultsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetMoveDefaultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMoveDefaultsBtn.ForeColor = System.Drawing.Color.White;
            this.SetMoveDefaultsBtn.Location = new System.Drawing.Point(708, 351);
            this.SetMoveDefaultsBtn.Name = "SetMoveDefaultsBtn";
            this.SetMoveDefaultsBtn.Size = new System.Drawing.Size(229, 110);
            this.SetMoveDefaultsBtn.TabIndex = 122;
            this.SetMoveDefaultsBtn.Text = "Restore Defaults";
            this.SetMoveDefaultsBtn.UseVisualStyleBackColor = false;
            this.SetMoveDefaultsBtn.Click += new System.EventHandler(this.SetMoveDefaultsBtn_Click);
            // 
            // SetPointFrequencyBtn
            // 
            this.SetPointFrequencyBtn.BackColor = System.Drawing.Color.Green;
            this.SetPointFrequencyBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetPointFrequencyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetPointFrequencyBtn.ForeColor = System.Drawing.Color.White;
            this.SetPointFrequencyBtn.Location = new System.Drawing.Point(1178, 119);
            this.SetPointFrequencyBtn.Name = "SetPointFrequencyBtn";
            this.SetPointFrequencyBtn.Size = new System.Drawing.Size(229, 110);
            this.SetPointFrequencyBtn.TabIndex = 122;
            this.SetPointFrequencyBtn.Text = "Set Point Frequency";
            this.SetPointFrequencyBtn.UseVisualStyleBackColor = false;
            this.SetPointFrequencyBtn.Click += new System.EventHandler(this.SetPointFrequencyBtn_Click);
            // 
            // SetBlendRadiusBtn
            // 
            this.SetBlendRadiusBtn.BackColor = System.Drawing.Color.Green;
            this.SetBlendRadiusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetBlendRadiusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetBlendRadiusBtn.ForeColor = System.Drawing.Color.White;
            this.SetBlendRadiusBtn.Location = new System.Drawing.Point(473, 351);
            this.SetBlendRadiusBtn.Name = "SetBlendRadiusBtn";
            this.SetBlendRadiusBtn.Size = new System.Drawing.Size(229, 110);
            this.SetBlendRadiusBtn.TabIndex = 111;
            this.SetBlendRadiusBtn.Text = "Set Blend Radius";
            this.SetBlendRadiusBtn.UseVisualStyleBackColor = false;
            this.SetBlendRadiusBtn.Click += new System.EventHandler(this.SetBlendRadiusBtn_Click);
            // 
            // SetForceModeGainScalingBtn
            // 
            this.SetForceModeGainScalingBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceModeGainScalingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetForceModeGainScalingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceModeGainScalingBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceModeGainScalingBtn.Location = new System.Drawing.Point(708, 119);
            this.SetForceModeGainScalingBtn.Name = "SetForceModeGainScalingBtn";
            this.SetForceModeGainScalingBtn.Size = new System.Drawing.Size(229, 110);
            this.SetForceModeGainScalingBtn.TabIndex = 125;
            this.SetForceModeGainScalingBtn.Text = "Set Force Mode Gain Scaling";
            this.SetForceModeGainScalingBtn.UseVisualStyleBackColor = false;
            this.SetForceModeGainScalingBtn.Click += new System.EventHandler(this.SetForceModeGainScalingBtn_Click);
            // 
            // SetForceModeDampingBtn
            // 
            this.SetForceModeDampingBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceModeDampingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetForceModeDampingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceModeDampingBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceModeDampingBtn.Location = new System.Drawing.Point(473, 119);
            this.SetForceModeDampingBtn.Name = "SetForceModeDampingBtn";
            this.SetForceModeDampingBtn.Size = new System.Drawing.Size(229, 110);
            this.SetForceModeDampingBtn.TabIndex = 126;
            this.SetForceModeDampingBtn.Text = "Set Force Mode Damping";
            this.SetForceModeDampingBtn.UseVisualStyleBackColor = false;
            this.SetForceModeDampingBtn.Click += new System.EventHandler(this.SetForceModeDampingBtn_Click);
            // 
            // SetJointAccelBtn
            // 
            this.SetJointAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetJointAccelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetJointAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetJointAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetJointAccelBtn.Location = new System.Drawing.Point(238, 467);
            this.SetJointAccelBtn.Name = "SetJointAccelBtn";
            this.SetJointAccelBtn.Size = new System.Drawing.Size(229, 110);
            this.SetJointAccelBtn.TabIndex = 113;
            this.SetJointAccelBtn.Text = "Set Joint Accel";
            this.SetJointAccelBtn.UseVisualStyleBackColor = false;
            this.SetJointAccelBtn.Click += new System.EventHandler(this.SetJointAccelBtn_Click);
            // 
            // SetTrialSpeedBtn
            // 
            this.SetTrialSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetTrialSpeedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetTrialSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTrialSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetTrialSpeedBtn.Location = new System.Drawing.Point(3, 3);
            this.SetTrialSpeedBtn.Name = "SetTrialSpeedBtn";
            this.SetTrialSpeedBtn.Size = new System.Drawing.Size(229, 110);
            this.SetTrialSpeedBtn.TabIndex = 119;
            this.SetTrialSpeedBtn.Text = "Set Trial Speed";
            this.SetTrialSpeedBtn.UseVisualStyleBackColor = false;
            this.SetTrialSpeedBtn.Click += new System.EventHandler(this.SetTrialSpeedBtn_Click);
            // 
            // SetJointSpeedBtn
            // 
            this.SetJointSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetJointSpeedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetJointSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetJointSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetJointSpeedBtn.Location = new System.Drawing.Point(238, 351);
            this.SetJointSpeedBtn.Name = "SetJointSpeedBtn";
            this.SetJointSpeedBtn.Size = new System.Drawing.Size(229, 110);
            this.SetJointSpeedBtn.TabIndex = 112;
            this.SetJointSpeedBtn.Text = "Set Joint Speed";
            this.SetJointSpeedBtn.UseVisualStyleBackColor = false;
            this.SetJointSpeedBtn.Click += new System.EventHandler(this.SetJointSpeedBtn_Click);
            // 
            // SetGrindAccelBtn
            // 
            this.SetGrindAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindAccelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetGrindAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindAccelBtn.Location = new System.Drawing.Point(238, 3);
            this.SetGrindAccelBtn.Name = "SetGrindAccelBtn";
            this.SetGrindAccelBtn.Size = new System.Drawing.Size(229, 110);
            this.SetGrindAccelBtn.TabIndex = 120;
            this.SetGrindAccelBtn.Text = "Set Acceleration";
            this.SetGrindAccelBtn.UseVisualStyleBackColor = false;
            this.SetGrindAccelBtn.Click += new System.EventHandler(this.SetGrindAccelBtn_Click);
            // 
            // SetGrindJogAccelBtn
            // 
            this.SetGrindJogAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindJogAccelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetGrindJogAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindJogAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindJogAccelBtn.Location = new System.Drawing.Point(238, 119);
            this.SetGrindJogAccelBtn.Name = "SetGrindJogAccelBtn";
            this.SetGrindJogAccelBtn.Size = new System.Drawing.Size(229, 110);
            this.SetGrindJogAccelBtn.TabIndex = 124;
            this.SetGrindJogAccelBtn.Text = "Set Jog Accel";
            this.SetGrindJogAccelBtn.UseVisualStyleBackColor = false;
            this.SetGrindJogAccelBtn.Click += new System.EventHandler(this.SetGrindJogAccel_Click);
            // 
            // SetMaxGrindBlendRadiusBtn
            // 
            this.SetMaxGrindBlendRadiusBtn.BackColor = System.Drawing.Color.Green;
            this.SetMaxGrindBlendRadiusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetMaxGrindBlendRadiusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMaxGrindBlendRadiusBtn.ForeColor = System.Drawing.Color.White;
            this.SetMaxGrindBlendRadiusBtn.Location = new System.Drawing.Point(473, 3);
            this.SetMaxGrindBlendRadiusBtn.Name = "SetMaxGrindBlendRadiusBtn";
            this.SetMaxGrindBlendRadiusBtn.Size = new System.Drawing.Size(229, 110);
            this.SetMaxGrindBlendRadiusBtn.TabIndex = 118;
            this.SetMaxGrindBlendRadiusBtn.Text = "Set Max Blend Radius";
            this.SetMaxGrindBlendRadiusBtn.UseVisualStyleBackColor = false;
            this.SetMaxGrindBlendRadiusBtn.Click += new System.EventHandler(this.SetMaxGrindBlendRadiusBtn_Click);
            // 
            // SetLinearSpeedBtn
            // 
            this.SetLinearSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetLinearSpeedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetLinearSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetLinearSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetLinearSpeedBtn.Location = new System.Drawing.Point(3, 351);
            this.SetLinearSpeedBtn.Name = "SetLinearSpeedBtn";
            this.SetLinearSpeedBtn.Size = new System.Drawing.Size(229, 110);
            this.SetLinearSpeedBtn.TabIndex = 109;
            this.SetLinearSpeedBtn.Text = "Set Linear Speed";
            this.SetLinearSpeedBtn.UseVisualStyleBackColor = false;
            this.SetLinearSpeedBtn.Click += new System.EventHandler(this.SetLinearSpeedBtn_Click);
            // 
            // SetGrindJogSpeedBtn
            // 
            this.SetGrindJogSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindJogSpeedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetGrindJogSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindJogSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindJogSpeedBtn.Location = new System.Drawing.Point(3, 119);
            this.SetGrindJogSpeedBtn.Name = "SetGrindJogSpeedBtn";
            this.SetGrindJogSpeedBtn.Size = new System.Drawing.Size(229, 110);
            this.SetGrindJogSpeedBtn.TabIndex = 123;
            this.SetGrindJogSpeedBtn.Text = "Set Jog Speed";
            this.SetGrindJogSpeedBtn.UseVisualStyleBackColor = false;
            this.SetGrindJogSpeedBtn.Click += new System.EventHandler(this.SetGrindJogSpeedBtn_Click);
            // 
            // SetTouchSpeedBtn
            // 
            this.SetTouchSpeedBtn.BackColor = System.Drawing.Color.Green;
            this.SetTouchSpeedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetTouchSpeedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTouchSpeedBtn.ForeColor = System.Drawing.Color.White;
            this.SetTouchSpeedBtn.Location = new System.Drawing.Point(708, 3);
            this.SetTouchSpeedBtn.Name = "SetTouchSpeedBtn";
            this.SetTouchSpeedBtn.Size = new System.Drawing.Size(229, 110);
            this.SetTouchSpeedBtn.TabIndex = 115;
            this.SetTouchSpeedBtn.Text = "Set Touch Speed";
            this.SetTouchSpeedBtn.UseVisualStyleBackColor = false;
            this.SetTouchSpeedBtn.Click += new System.EventHandler(this.SetTouchSpeedBtn_Click);
            // 
            // SetTouchRetractBtn
            // 
            this.SetTouchRetractBtn.BackColor = System.Drawing.Color.Green;
            this.SetTouchRetractBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetTouchRetractBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetTouchRetractBtn.ForeColor = System.Drawing.Color.White;
            this.SetTouchRetractBtn.Location = new System.Drawing.Point(943, 3);
            this.SetTouchRetractBtn.Name = "SetTouchRetractBtn";
            this.SetTouchRetractBtn.Size = new System.Drawing.Size(229, 110);
            this.SetTouchRetractBtn.TabIndex = 114;
            this.SetTouchRetractBtn.Text = "Set Touch Retract";
            this.SetTouchRetractBtn.UseVisualStyleBackColor = false;
            this.SetTouchRetractBtn.Click += new System.EventHandler(this.SetTouchRetractBtn_Click);
            // 
            // SetForceDwellBtn
            // 
            this.SetForceDwellBtn.BackColor = System.Drawing.Color.Green;
            this.SetForceDwellBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetForceDwellBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetForceDwellBtn.ForeColor = System.Drawing.Color.White;
            this.SetForceDwellBtn.Location = new System.Drawing.Point(1178, 3);
            this.SetForceDwellBtn.Name = "SetForceDwellBtn";
            this.SetForceDwellBtn.Size = new System.Drawing.Size(229, 110);
            this.SetForceDwellBtn.TabIndex = 116;
            this.SetForceDwellBtn.Text = "Set Force Dwell";
            this.SetForceDwellBtn.UseVisualStyleBackColor = false;
            this.SetForceDwellBtn.Click += new System.EventHandler(this.SetForceDwellBtn_Click);
            // 
            // SetMaxWaitBtn
            // 
            this.SetMaxWaitBtn.BackColor = System.Drawing.Color.Green;
            this.SetMaxWaitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetMaxWaitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMaxWaitBtn.ForeColor = System.Drawing.Color.White;
            this.SetMaxWaitBtn.Location = new System.Drawing.Point(1413, 3);
            this.SetMaxWaitBtn.Name = "SetMaxWaitBtn";
            this.SetMaxWaitBtn.Size = new System.Drawing.Size(229, 110);
            this.SetMaxWaitBtn.TabIndex = 117;
            this.SetMaxWaitBtn.Text = "Set Max Wait";
            this.SetMaxWaitBtn.UseVisualStyleBackColor = false;
            this.SetMaxWaitBtn.Click += new System.EventHandler(this.SetMaxWaitBtn_Click);
            // 
            // SetGrindDefaultsBtn
            // 
            this.SetGrindDefaultsBtn.BackColor = System.Drawing.Color.Green;
            this.SetGrindDefaultsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetGrindDefaultsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetGrindDefaultsBtn.ForeColor = System.Drawing.Color.White;
            this.SetGrindDefaultsBtn.Location = new System.Drawing.Point(1648, 3);
            this.SetGrindDefaultsBtn.Name = "SetGrindDefaultsBtn";
            this.SetGrindDefaultsBtn.Size = new System.Drawing.Size(229, 110);
            this.SetGrindDefaultsBtn.TabIndex = 121;
            this.SetGrindDefaultsBtn.Text = "Restore Defaults";
            this.SetGrindDefaultsBtn.UseVisualStyleBackColor = false;
            this.SetGrindDefaultsBtn.Click += new System.EventHandler(this.SetGrindDefaultsBtn_Click);
            // 
            // SetLinearAccelBtn
            // 
            this.SetLinearAccelBtn.BackColor = System.Drawing.Color.Green;
            this.SetLinearAccelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetLinearAccelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetLinearAccelBtn.ForeColor = System.Drawing.Color.White;
            this.SetLinearAccelBtn.Location = new System.Drawing.Point(3, 467);
            this.SetLinearAccelBtn.Name = "SetLinearAccelBtn";
            this.SetLinearAccelBtn.Size = new System.Drawing.Size(229, 110);
            this.SetLinearAccelBtn.TabIndex = 110;
            this.SetLinearAccelBtn.Text = "Set Linear Accel";
            this.SetLinearAccelBtn.UseVisualStyleBackColor = false;
            this.SetLinearAccelBtn.Click += new System.EventHandler(this.SetLinearAccelBtn_Click);
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.SetupGeneralLayoutPanel);
            this.generalPage.Location = new System.Drawing.Point(4, 100);
            this.generalPage.Name = "generalPage";
            this.generalPage.Size = new System.Drawing.Size(1880, 700);
            this.generalPage.TabIndex = 5;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // SetupGeneralLayoutPanel
            // 
            this.SetupGeneralLayoutPanel.ColumnCount = 6;
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.SetupGeneralLayoutPanel.Controls.Add(this.LoadConfigBtn, 3, 4);
            this.SetupGeneralLayoutPanel.Controls.Add(this.SaveConfigBtn, 4, 4);
            this.SetupGeneralLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.SetupGeneralLayoutPanel.Controls.Add(this.LEonardRootLbl, 1, 0);
            this.SetupGeneralLayoutPanel.Controls.Add(this.DefaultConfigBtn, 5, 4);
            this.SetupGeneralLayoutPanel.Controls.Add(this.ChangeRootDirectoryBtn, 4, 0);
            this.SetupGeneralLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupGeneralLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SetupGeneralLayoutPanel.Name = "SetupGeneralLayoutPanel";
            this.SetupGeneralLayoutPanel.RowCount = 5;
            this.SetupGeneralLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.315789F));
            this.SetupGeneralLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.315789F));
            this.SetupGeneralLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.52631F));
            this.SetupGeneralLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05264F));
            this.SetupGeneralLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.SetupGeneralLayoutPanel.Size = new System.Drawing.Size(1880, 700);
            this.SetupGeneralLayoutPanel.TabIndex = 0;
            // 
            // LoadConfigBtn
            // 
            this.LoadConfigBtn.BackColor = System.Drawing.Color.Green;
            this.LoadConfigBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadConfigBtn.ForeColor = System.Drawing.Color.White;
            this.LoadConfigBtn.Location = new System.Drawing.Point(942, 591);
            this.LoadConfigBtn.Name = "LoadConfigBtn";
            this.LoadConfigBtn.Size = new System.Drawing.Size(307, 106);
            this.LoadConfigBtn.TabIndex = 98;
            this.LoadConfigBtn.Text = "Reload";
            this.LoadConfigBtn.UseVisualStyleBackColor = false;
            this.LoadConfigBtn.Click += new System.EventHandler(this.LoadConfigBtn_Click);
            // 
            // SaveConfigBtn
            // 
            this.SaveConfigBtn.BackColor = System.Drawing.Color.Green;
            this.SaveConfigBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveConfigBtn.ForeColor = System.Drawing.Color.White;
            this.SaveConfigBtn.Location = new System.Drawing.Point(1255, 591);
            this.SaveConfigBtn.Name = "SaveConfigBtn";
            this.SaveConfigBtn.Size = new System.Drawing.Size(307, 106);
            this.SaveConfigBtn.TabIndex = 100;
            this.SaveConfigBtn.Text = "Save";
            this.SaveConfigBtn.UseVisualStyleBackColor = false;
            this.SaveConfigBtn.Click += new System.EventHandler(this.SaveConfigBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(45, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 44);
            this.label1.TabIndex = 68;
            this.label1.Text = "LEonard Root Dir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LEonardRootLbl
            // 
            this.LEonardRootLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupGeneralLayoutPanel.SetColumnSpan(this.LEonardRootLbl, 3);
            this.LEonardRootLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LEonardRootLbl.Location = new System.Drawing.Point(316, 0);
            this.LEonardRootLbl.Name = "LEonardRootLbl";
            this.LEonardRootLbl.Size = new System.Drawing.Size(933, 44);
            this.LEonardRootLbl.TabIndex = 69;
            this.LEonardRootLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DefaultConfigBtn
            // 
            this.DefaultConfigBtn.BackColor = System.Drawing.Color.Green;
            this.DefaultConfigBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultConfigBtn.ForeColor = System.Drawing.Color.White;
            this.DefaultConfigBtn.Location = new System.Drawing.Point(1568, 591);
            this.DefaultConfigBtn.Name = "DefaultConfigBtn";
            this.DefaultConfigBtn.Size = new System.Drawing.Size(309, 106);
            this.DefaultConfigBtn.TabIndex = 99;
            this.DefaultConfigBtn.Text = "Restore Defaults";
            this.DefaultConfigBtn.UseVisualStyleBackColor = false;
            this.DefaultConfigBtn.Click += new System.EventHandler(this.DefaultConfigBtn_Click);
            // 
            // ChangeRootDirectoryBtn
            // 
            this.ChangeRootDirectoryBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChangeRootDirectoryBtn.Location = new System.Drawing.Point(1255, 3);
            this.ChangeRootDirectoryBtn.Name = "ChangeRootDirectoryBtn";
            this.ChangeRootDirectoryBtn.Size = new System.Drawing.Size(60, 38);
            this.ChangeRootDirectoryBtn.TabIndex = 70;
            this.ChangeRootDirectoryBtn.Text = "...";
            this.ChangeRootDirectoryBtn.UseVisualStyleBackColor = true;
            this.ChangeRootDirectoryBtn.Click += new System.EventHandler(this.ChangeRootDirectoryBtn_Click);
            // 
            // licensePage
            // 
            this.licensePage.Controls.Add(this.SetupLicenseLayoutPanel);
            this.licensePage.Location = new System.Drawing.Point(4, 100);
            this.licensePage.Name = "licensePage";
            this.licensePage.Size = new System.Drawing.Size(1880, 700);
            this.licensePage.TabIndex = 7;
            this.licensePage.Text = "License";
            this.licensePage.UseVisualStyleBackColor = true;
            // 
            // SetupLicenseLayoutPanel
            // 
            this.SetupLicenseLayoutPanel.ColumnCount = 8;
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.Controls.Add(this.LicenseStatusLbl, 0, 0);
            this.SetupLicenseLayoutPanel.Controls.Add(this.LicenseAdjustGrp, 4, 1);
            this.SetupLicenseLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupLicenseLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SetupLicenseLayoutPanel.Name = "SetupLicenseLayoutPanel";
            this.SetupLicenseLayoutPanel.RowCount = 8;
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.SetupLicenseLayoutPanel.Size = new System.Drawing.Size(1880, 700);
            this.SetupLicenseLayoutPanel.TabIndex = 102;
            // 
            // LicenseStatusLbl
            // 
            this.LicenseStatusLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetupLicenseLayoutPanel.SetColumnSpan(this.LicenseStatusLbl, 3);
            this.LicenseStatusLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LicenseStatusLbl.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseStatusLbl.Location = new System.Drawing.Point(3, 0);
            this.LicenseStatusLbl.Name = "LicenseStatusLbl";
            this.SetupLicenseLayoutPanel.SetRowSpan(this.LicenseStatusLbl, 8);
            this.LicenseStatusLbl.Size = new System.Drawing.Size(699, 700);
            this.LicenseStatusLbl.TabIndex = 100;
            this.LicenseStatusLbl.Text = "License Status";
            this.LicenseStatusLbl.DoubleClick += new System.EventHandler(this.LicenseStatusLbl_DoubleClick);
            // 
            // LicenseAdjustGrp
            // 
            this.SetupLicenseLayoutPanel.SetColumnSpan(this.LicenseAdjustGrp, 4);
            this.LicenseAdjustGrp.Controls.Add(this.AdjustmentButtonLayoutPanel);
            this.LicenseAdjustGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LicenseAdjustGrp.Location = new System.Drawing.Point(943, 90);
            this.LicenseAdjustGrp.Name = "LicenseAdjustGrp";
            this.SetupLicenseLayoutPanel.SetRowSpan(this.LicenseAdjustGrp, 7);
            this.LicenseAdjustGrp.Size = new System.Drawing.Size(934, 607);
            this.LicenseAdjustGrp.TabIndex = 104;
            this.LicenseAdjustGrp.TabStop = false;
            this.LicenseAdjustGrp.Text = "Adjustments";
            // 
            // AdjustmentButtonLayoutPanel
            // 
            this.AdjustmentButtonLayoutPanel.ColumnCount = 4;
            this.AdjustmentButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AdjustmentButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AdjustmentButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AdjustmentButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.SaveLicenseBtn, 3, 5);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.ReloadLicenseBtn, 2, 5);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.JavaLicenseBtn, 1, 0);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.PythonLicenseBtn, 1, 1);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.UrLicenseBtn, 1, 2);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.GrindingLicenseBtn, 1, 3);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.GocatorLicenseBtn, 1, 4);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.NewLicenseBtn, 0, 0);
            this.AdjustmentButtonLayoutPanel.Controls.Add(this.TrialLicenseBtn, 0, 1);
            this.AdjustmentButtonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdjustmentButtonLayoutPanel.Location = new System.Drawing.Point(3, 40);
            this.AdjustmentButtonLayoutPanel.Name = "AdjustmentButtonLayoutPanel";
            this.AdjustmentButtonLayoutPanel.RowCount = 6;
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.AdjustmentButtonLayoutPanel.Size = new System.Drawing.Size(928, 564);
            this.AdjustmentButtonLayoutPanel.TabIndex = 0;
            // 
            // SaveLicenseBtn
            // 
            this.SaveLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.SaveLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveLicenseBtn.Enabled = false;
            this.SaveLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.SaveLicenseBtn.Location = new System.Drawing.Point(699, 473);
            this.SaveLicenseBtn.Name = "SaveLicenseBtn";
            this.SaveLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.SaveLicenseBtn.TabIndex = 108;
            this.SaveLicenseBtn.Text = "Save";
            this.SaveLicenseBtn.UseVisualStyleBackColor = false;
            this.SaveLicenseBtn.Click += new System.EventHandler(this.SaveLicenseBtn_Click);
            // 
            // ReloadLicenseBtn
            // 
            this.ReloadLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.ReloadLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReloadLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.ReloadLicenseBtn.Location = new System.Drawing.Point(467, 473);
            this.ReloadLicenseBtn.Name = "ReloadLicenseBtn";
            this.ReloadLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.ReloadLicenseBtn.TabIndex = 110;
            this.ReloadLicenseBtn.Text = "Reload";
            this.ReloadLicenseBtn.UseVisualStyleBackColor = false;
            this.ReloadLicenseBtn.Click += new System.EventHandler(this.ReloadLicenseBtn_Click);
            // 
            // JavaLicenseBtn
            // 
            this.JavaLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.JavaLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JavaLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JavaLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.JavaLicenseBtn.Location = new System.Drawing.Point(235, 3);
            this.JavaLicenseBtn.Name = "JavaLicenseBtn";
            this.JavaLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.JavaLicenseBtn.TabIndex = 103;
            this.JavaLicenseBtn.Text = "Java?";
            this.JavaLicenseBtn.UseVisualStyleBackColor = false;
            this.JavaLicenseBtn.Click += new System.EventHandler(this.JavaLicenseBtn_Click);
            // 
            // PythonLicenseBtn
            // 
            this.PythonLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.PythonLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PythonLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PythonLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.PythonLicenseBtn.Location = new System.Drawing.Point(235, 97);
            this.PythonLicenseBtn.Name = "PythonLicenseBtn";
            this.PythonLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.PythonLicenseBtn.TabIndex = 104;
            this.PythonLicenseBtn.Text = "Python?";
            this.PythonLicenseBtn.UseVisualStyleBackColor = false;
            this.PythonLicenseBtn.Click += new System.EventHandler(this.PythonLicenseBtn_Click);
            // 
            // UrLicenseBtn
            // 
            this.UrLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.UrLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.UrLicenseBtn.Location = new System.Drawing.Point(235, 191);
            this.UrLicenseBtn.Name = "UrLicenseBtn";
            this.UrLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.UrLicenseBtn.TabIndex = 105;
            this.UrLicenseBtn.Text = "UR?";
            this.UrLicenseBtn.UseVisualStyleBackColor = false;
            this.UrLicenseBtn.Click += new System.EventHandler(this.UrLicenseBtn_Click);
            // 
            // GrindingLicenseBtn
            // 
            this.GrindingLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.GrindingLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrindingLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrindingLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.GrindingLicenseBtn.Location = new System.Drawing.Point(235, 285);
            this.GrindingLicenseBtn.Name = "GrindingLicenseBtn";
            this.GrindingLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.GrindingLicenseBtn.TabIndex = 106;
            this.GrindingLicenseBtn.Text = "Grinding?";
            this.GrindingLicenseBtn.UseVisualStyleBackColor = false;
            this.GrindingLicenseBtn.Click += new System.EventHandler(this.GrindingLicenseBtn_Click);
            // 
            // GocatorLicenseBtn
            // 
            this.GocatorLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.GocatorLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GocatorLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GocatorLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.GocatorLicenseBtn.Location = new System.Drawing.Point(235, 379);
            this.GocatorLicenseBtn.Name = "GocatorLicenseBtn";
            this.GocatorLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.GocatorLicenseBtn.TabIndex = 107;
            this.GocatorLicenseBtn.Text = "Gocator?";
            this.GocatorLicenseBtn.UseVisualStyleBackColor = false;
            this.GocatorLicenseBtn.Click += new System.EventHandler(this.GocatorLicenseBtn_Click);
            // 
            // NewLicenseBtn
            // 
            this.NewLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.NewLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.NewLicenseBtn.Location = new System.Drawing.Point(3, 3);
            this.NewLicenseBtn.Name = "NewLicenseBtn";
            this.NewLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.NewLicenseBtn.TabIndex = 109;
            this.NewLicenseBtn.Text = "New Full License";
            this.NewLicenseBtn.UseVisualStyleBackColor = false;
            this.NewLicenseBtn.Click += new System.EventHandler(this.NewLicenseBtn_Click);
            // 
            // TrialLicenseBtn
            // 
            this.TrialLicenseBtn.BackColor = System.Drawing.Color.Green;
            this.TrialLicenseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrialLicenseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrialLicenseBtn.ForeColor = System.Drawing.Color.White;
            this.TrialLicenseBtn.Location = new System.Drawing.Point(3, 97);
            this.TrialLicenseBtn.Name = "TrialLicenseBtn";
            this.TrialLicenseBtn.Size = new System.Drawing.Size(226, 88);
            this.TrialLicenseBtn.TabIndex = 99;
            this.TrialLicenseBtn.Text = "Create 30-day Trial";
            this.TrialLicenseBtn.UseVisualStyleBackColor = false;
            this.TrialLicenseBtn.Click += new System.EventHandler(this.TrialLicenseBtn_Click);
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
            // LogsPage
            // 
            this.LogsPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogsPage.Controls.Add(this.tableLayoutPanel1);
            this.LogsPage.Location = new System.Drawing.Point(4, 100);
            this.LogsPage.Name = "LogsPage";
            this.LogsPage.Size = new System.Drawing.Size(1892, 808);
            this.LogsPage.TabIndex = 5;
            this.LogsPage.Text = "Logs";
            this.LogsPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogPageControlsLayoutPanel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1888, 804);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RobotLogRTB);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1230, 324);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(655, 315);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Robot: Messages Starting With \"R.\"";
            // 
            // RobotLogRTB
            // 
            this.RobotLogRTB.DetectUrls = false;
            this.RobotLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotLogRTB.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobotLogRTB.Location = new System.Drawing.Point(3, 25);
            this.RobotLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.RobotLogRTB.MaxLength = 1000000;
            this.RobotLogRTB.Name = "RobotLogRTB";
            this.RobotLogRTB.ReadOnly = true;
            this.RobotLogRTB.Size = new System.Drawing.Size(649, 287);
            this.RobotLogRTB.TabIndex = 0;
            this.RobotLogRTB.Text = "";
            this.RobotLogRTB.WordWrap = false;
            this.RobotLogRTB.DoubleClick += new System.EventHandler(this.UrLogRTB_DoubleClick);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ExecLogRTB);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(3, 324);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1221, 315);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Exec: Messages Starting With \"EXEC\"";
            // 
            // ExecLogRTB
            // 
            this.ExecLogRTB.DetectUrls = false;
            this.ExecLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecLogRTB.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecLogRTB.Location = new System.Drawing.Point(3, 25);
            this.ExecLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.ExecLogRTB.MaxLength = 1000000;
            this.ExecLogRTB.Name = "ExecLogRTB";
            this.ExecLogRTB.ReadOnly = true;
            this.ExecLogRTB.Size = new System.Drawing.Size(1215, 287);
            this.ExecLogRTB.TabIndex = 0;
            this.ExecLogRTB.Text = "";
            this.ExecLogRTB.WordWrap = false;
            this.ExecLogRTB.DoubleClick += new System.EventHandler(this.ExecLogRTB_DoubleClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ErrorLogRTB);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 645);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1221, 156);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Errors and Warnings";
            // 
            // ErrorLogRTB
            // 
            this.ErrorLogRTB.DetectUrls = false;
            this.ErrorLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorLogRTB.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLogRTB.Location = new System.Drawing.Point(3, 25);
            this.ErrorLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorLogRTB.MaxLength = 1000000;
            this.ErrorLogRTB.Name = "ErrorLogRTB";
            this.ErrorLogRTB.ReadOnly = true;
            this.ErrorLogRTB.Size = new System.Drawing.Size(1215, 128);
            this.ErrorLogRTB.TabIndex = 0;
            this.ErrorLogRTB.Text = "";
            this.ErrorLogRTB.WordWrap = false;
            this.ErrorLogRTB.DoubleClick += new System.EventHandler(this.ErrorLogRTB_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.AuxLogRTB);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(1230, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(655, 315);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Aux: Messages Starting With \"A.\"";
            // 
            // AuxLogRTB
            // 
            this.AuxLogRTB.DetectUrls = false;
            this.AuxLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuxLogRTB.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuxLogRTB.Location = new System.Drawing.Point(3, 25);
            this.AuxLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.AuxLogRTB.MaxLength = 1000000;
            this.AuxLogRTB.Name = "AuxLogRTB";
            this.AuxLogRTB.ReadOnly = true;
            this.AuxLogRTB.Size = new System.Drawing.Size(649, 287);
            this.AuxLogRTB.TabIndex = 0;
            this.AuxLogRTB.Text = "";
            this.AuxLogRTB.WordWrap = false;
            this.AuxLogRTB.DoubleClick += new System.EventHandler(this.ConsoleRTB_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AllLogRTB);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1221, 315);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "All Log Messages (Double-click to clear any of these or use Clear All button)";
            // 
            // AllLogRTB
            // 
            this.AllLogRTB.DetectUrls = false;
            this.AllLogRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllLogRTB.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllLogRTB.Location = new System.Drawing.Point(3, 25);
            this.AllLogRTB.Margin = new System.Windows.Forms.Padding(2);
            this.AllLogRTB.MaxLength = 1000000;
            this.AllLogRTB.Name = "AllLogRTB";
            this.AllLogRTB.ReadOnly = true;
            this.AllLogRTB.Size = new System.Drawing.Size(1215, 287);
            this.AllLogRTB.TabIndex = 0;
            this.AllLogRTB.Text = "";
            this.AllLogRTB.WordWrap = false;
            this.AllLogRTB.DoubleClick += new System.EventHandler(this.AllLogRTB_DoubleClick);
            // 
            // LogPageControlsLayoutPanel
            // 
            this.LogPageControlsLayoutPanel.ColumnCount = 3;
            this.LogPageControlsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.95055F));
            this.LogPageControlsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.02472F));
            this.LogPageControlsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.02472F));
            this.LogPageControlsLayoutPanel.Controls.Add(this.LogLevelGroupBox, 0, 0);
            this.LogPageControlsLayoutPanel.Controls.Add(this.AboutBtn, 2, 0);
            this.LogPageControlsLayoutPanel.Controls.Add(this.ClearAllLogRtbBtn, 1, 0);
            this.LogPageControlsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPageControlsLayoutPanel.Location = new System.Drawing.Point(1230, 645);
            this.LogPageControlsLayoutPanel.Name = "LogPageControlsLayoutPanel";
            this.LogPageControlsLayoutPanel.RowCount = 1;
            this.LogPageControlsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LogPageControlsLayoutPanel.Size = new System.Drawing.Size(655, 156);
            this.LogPageControlsLayoutPanel.TabIndex = 5;
            // 
            // LogLevelGroupBox
            // 
            this.LogLevelGroupBox.Controls.Add(this.LogLevelCombo);
            this.LogLevelGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogLevelGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLevelGroupBox.Location = new System.Drawing.Point(3, 3);
            this.LogLevelGroupBox.Name = "LogLevelGroupBox";
            this.LogLevelGroupBox.Size = new System.Drawing.Size(308, 118);
            this.LogLevelGroupBox.TabIndex = 7;
            this.LogLevelGroupBox.TabStop = false;
            this.LogLevelGroupBox.Text = "Log Level";
            // 
            // LogLevelCombo
            // 
            this.LogLevelCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.LogLevelCombo.Size = new System.Drawing.Size(211, 50);
            this.LogLevelCombo.TabIndex = 0;
            this.LogLevelCombo.SelectedIndexChanged += new System.EventHandler(this.DebugLevelCombo_SelectedIndexChanged);
            // 
            // AboutBtn
            // 
            this.AboutBtn.BackColor = System.Drawing.Color.Green;
            this.AboutBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutBtn.ForeColor = System.Drawing.Color.White;
            this.AboutBtn.Location = new System.Drawing.Point(487, 3);
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(165, 150);
            this.AboutBtn.TabIndex = 6;
            this.AboutBtn.Text = "About";
            this.AboutBtn.UseVisualStyleBackColor = false;
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // ClearAllLogRtbBtn
            // 
            this.ClearAllLogRtbBtn.BackColor = System.Drawing.Color.Green;
            this.ClearAllLogRtbBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearAllLogRtbBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllLogRtbBtn.ForeColor = System.Drawing.Color.White;
            this.ClearAllLogRtbBtn.Location = new System.Drawing.Point(317, 3);
            this.ClearAllLogRtbBtn.Name = "ClearAllLogRtbBtn";
            this.ClearAllLogRtbBtn.Size = new System.Drawing.Size(164, 150);
            this.ClearAllLogRtbBtn.TabIndex = 5;
            this.ClearAllLogRtbBtn.Text = "Clear All";
            this.ClearAllLogRtbBtn.UseVisualStyleBackColor = false;
            this.ClearAllLogRtbBtn.Click += new System.EventHandler(this.ClearAllLogRtbBtn_Click);
            // 
            // JogRunBtn
            // 
            this.JogRunBtn.BackColor = System.Drawing.Color.Green;
            this.JogRunBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JogRunBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JogRunBtn.ForeColor = System.Drawing.Color.White;
            this.JogRunBtn.Location = new System.Drawing.Point(899, 2);
            this.JogRunBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JogRunBtn.Name = "JogRunBtn";
            this.JogRunBtn.Size = new System.Drawing.Size(150, 94);
            this.JogRunBtn.TabIndex = 5;
            this.JogRunBtn.Text = "Jog Robot";
            this.JogRunBtn.UseVisualStyleBackColor = false;
            this.JogRunBtn.Click += new System.EventHandler(this.JogRunBtn_Click);
            // 
            // DiameterLbl
            // 
            this.DiameterLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiameterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiameterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiameterLbl.Location = new System.Drawing.Point(3, 0);
            this.DiameterLbl.Name = "DiameterLbl";
            this.DiameterLbl.Size = new System.Drawing.Size(182, 61);
            this.DiameterLbl.TabIndex = 9;
            this.DiameterLbl.Text = "25.0";
            this.DiameterLbl.Click += new System.EventHandler(this.DiameterLbl_Click);
            // 
            // PartGeometryBox
            // 
            this.PartGeometryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartGeometryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartGeometryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartGeometryBox.FormattingEnabled = true;
            this.PartGeometryBox.Items.AddRange(new object[] {
            "FLAT",
            "CYLINDER",
            "SPHERE"});
            this.PartGeometryBox.Location = new System.Drawing.Point(3, 3);
            this.PartGeometryBox.Name = "PartGeometryBox";
            this.PartGeometryBox.Size = new System.Drawing.Size(272, 50);
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
            this.DoorClosedLbl.Location = new System.Drawing.Point(1053, 0);
            this.DoorClosedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DoorClosedLbl.Name = "DoorClosedLbl";
            this.DoorClosedLbl.Size = new System.Drawing.Size(144, 98);
            this.DoorClosedLbl.TabIndex = 6;
            this.DoorClosedLbl.Text = "Door State";
            this.DoorClosedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionLbl
            // 
            this.DiamVersionLayoutPanel.SetColumnSpan(this.VersionLbl, 2);
            this.VersionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.Location = new System.Drawing.Point(3, 68);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(371, 30);
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
            this.FootswitchPressedLbl.Location = new System.Drawing.Point(1201, 0);
            this.FootswitchPressedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FootswitchPressedLbl.Name = "FootswitchPressedLbl";
            this.FootswitchPressedLbl.Size = new System.Drawing.Size(144, 98);
            this.FootswitchPressedLbl.TabIndex = 8;
            this.FootswitchPressedLbl.Text = "Pedal State";
            this.FootswitchPressedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Time2Lbl
            // 
            this.Time2Lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiamVersionLayoutPanel.SetColumnSpan(this.Time2Lbl, 2);
            this.Time2Lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Time2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time2Lbl.Location = new System.Drawing.Point(2, 98);
            this.Time2Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Time2Lbl.Name = "Time2Lbl";
            this.Time2Lbl.Size = new System.Drawing.Size(373, 35);
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
            this.BottomButtonLayoutPanel.Location = new System.Drawing.Point(8, 929);
            this.BottomButtonLayoutPanel.Name = "BottomButtonLayoutPanel";
            this.BottomButtonLayoutPanel.RowCount = 1;
            this.BottomButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomButtonLayoutPanel.Size = new System.Drawing.Size(1896, 139);
            this.BottomButtonLayoutPanel.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.MountedToolBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.MountedToolBoxLbl, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(948, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(278, 133);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.PartGeometryBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.PartGeometryBoxLbl, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1232, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(278, 133);
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
            this.DiamVersionLayoutPanel.Location = new System.Drawing.Point(1516, 3);
            this.DiamVersionLayoutPanel.Name = "DiamVersionLayoutPanel";
            this.DiamVersionLayoutPanel.RowCount = 4;
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.91105F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.308465F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.95552F));
            this.DiamVersionLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.82497F));
            this.DiamVersionLayoutPanel.Size = new System.Drawing.Size(377, 133);
            this.DiamVersionLayoutPanel.TabIndex = 7;
            // 
            // TopButtonLayoutPanel
            // 
            this.TopButtonLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopButtonLayoutPanel.ColumnCount = 9;
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.29314F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52964F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52964F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52964F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52964F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10845F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10845F));
            this.TopButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.371379F));
            this.TopButtonLayoutPanel.Controls.Add(this.ExitBtn, 8, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.FootswitchPressedLbl, 7, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.DoorClosedLbl, 6, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.JogRunBtn, 5, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.SaveSequenceAsBtn, 4, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.SaveSequenceBtn, 3, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.NewSequenceBtn, 2, 0);
            this.TopButtonLayoutPanel.Controls.Add(this.LoadSequenceBtn, 1, 0);
            this.TopButtonLayoutPanel.Location = new System.Drawing.Point(421, 7);
            this.TopButtonLayoutPanel.Name = "TopButtonLayoutPanel";
            this.TopButtonLayoutPanel.RowCount = 1;
            this.TopButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopButtonLayoutPanel.Size = new System.Drawing.Size(1487, 98);
            this.TopButtonLayoutPanel.TabIndex = 14;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Gray;
            this.ExitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.Location = new System.Drawing.Point(1349, 2);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(136, 94);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.TopButtonLayoutPanel);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.BottomButtonLayoutPanel);
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
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MonitorTab.ResumeLayout(false);
            this.positionsPage.ResumeLayout(false);
            this.PositionLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PositionsGrd)).EndInit();
            this.variablesPage.ResumeLayout(false);
            this.VariablesLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VariablesGrd)).EndInit();
            this.javaEnginePage.ResumeLayout(false);
            this.JavaScreenLayoutPanel.ResumeLayout(false);
            this.JavaScreenLayoutPanel.PerformLayout();
            this.pythonEnginePage.ResumeLayout(false);
            this.PythonScreenLayoutPanel.ResumeLayout(false);
            this.PythonScreenLayoutPanel.PerformLayout();
            this.manualPage.ResumeLayout(false);
            this.manualPage.PerformLayout();
            this.MainTab.ResumeLayout(false);
            this.RunPage.ResumeLayout(false);
            this.RunTabLayoutPanel.ResumeLayout(false);
            this.StatusLayoutPanel.ResumeLayout(false);
            this.CommandCounterLayoutPanel.ResumeLayout(false);
            this.RunCenterColumnLayoutPanel.ResumeLayout(false);
            this.RunCenterColumnLayoutPanel.PerformLayout();
            this.GrindNofNLayoutPanel.ResumeLayout(false);
            this.GrindNofNLayoutPanel.PerformLayout();
            this.LastReportedZLayoutPanel.ResumeLayout(false);
            this.LastReportedZLayoutPanel.PerformLayout();
            this.CodePage.ResumeLayout(false);
            this.ProgramTableLayoutPanel.ResumeLayout(false);
            this.FileBigEditPanel.ResumeLayout(false);
            this.SetupPage.ResumeLayout(false);
            this.SetupTab.ResumeLayout(false);
            this.devicesPage.ResumeLayout(false);
            this.SetupDevicesLayoutPanel.ResumeLayout(false);
            this.SetupDevicesLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesGrd)).EndInit();
            this.RuntimeAppHelperLayoutPanel2.ResumeLayout(false);
            this.SetupAppHelperLayoutPanel2.ResumeLayout(false);
            this.speedBtnsGrp.ResumeLayout(false);
            this.RuntimeAppHelperLayoutPanel1.ResumeLayout(false);
            this.SetupAppHelperLayoutPanel1.ResumeLayout(false);
            this.displaysPage.ResumeLayout(false);
            this.displaysPage.PerformLayout();
            this.SetupDisplayLayoutPanel.ResumeLayout(false);
            this.SetupDisplayLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplaysGrd)).EndInit();
            this.toolsPage.ResumeLayout(false);
            this.SetupToolsLayoutPanel.ResumeLayout(false);
            this.FootswitchIoLayoutPanel.ResumeLayout(false);
            this.FootswitchIoLayoutPanel.PerformLayout();
            this.DoorIoLayoutPanel.ResumeLayout(false);
            this.DoorIoLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGrd)).EndInit();
            this.robotPage.ResumeLayout(false);
            this.SetupGrindLayoutPanel.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.SetupGeneralLayoutPanel.ResumeLayout(false);
            this.SetupGeneralLayoutPanel.PerformLayout();
            this.licensePage.ResumeLayout(false);
            this.SetupLicenseLayoutPanel.ResumeLayout(false);
            this.LicenseAdjustGrp.ResumeLayout(false);
            this.AdjustmentButtonLayoutPanel.ResumeLayout(false);
            this.LogsPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.LogPageControlsLayoutPanel.ResumeLayout(false);
            this.LogLevelGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.Timer StartupTmr;
        private System.Windows.Forms.Timer CloseTmr;
        private System.Windows.Forms.Button SaveSequenceAsBtn;
        private System.Windows.Forms.Button NewSequenceBtn;
        private System.Windows.Forms.Button LoadSequenceBtn;
        private System.Windows.Forms.Button SaveSequenceBtn;
        private System.Windows.Forms.Button StepBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.RichTextBox SequenceRTB;
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
        private System.Windows.Forms.Button ClearVariablesBtn;
        private System.Windows.Forms.DataGridView VariablesGrd;
        private System.Windows.Forms.Label MountedToolBoxLbl;
        private System.Windows.Forms.ComboBox MountedToolBox;
        private System.Windows.Forms.TabPage positionsPage;
        private System.Windows.Forms.Button PositionMoveArmBtn;
        private System.Windows.Forms.Button PositionMovePoseBtn;
        private System.Windows.Forms.Button PositionSetBtn;
        private System.Windows.Forms.Button ClearAllPositionsBtn;
        private System.Windows.Forms.Button ClearPositionsBtn;
        private System.Windows.Forms.DataGridView PositionsGrd;
        private System.Windows.Forms.ComboBox UserModeBox;
        private System.Windows.Forms.Label SequenceFilenameLbl;
        private System.Windows.Forms.TabPage manualPage;
        private System.Windows.Forms.Button RobotModeBtn;
        private System.Windows.Forms.Button RobotSafetyStatusBtn;
        private System.Windows.Forms.Button RobotProgramStateBtn;
        private System.Windows.Forms.Label PartGeometryBoxLbl;
        private System.Windows.Forms.Label DiameterDimLbl;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage RunPage;
        private System.Windows.Forms.TabPage CodePage;
        private System.Windows.Forms.TabPage SetupPage;
        private System.Windows.Forms.Button SelectToolBtn;
        private System.Windows.Forms.DataGridView ToolsGrd;
        private System.Windows.Forms.Button LoadToolsBtn;
        private System.Windows.Forms.Button SaveToolsBtn;
        private System.Windows.Forms.Button ClearToolsBtn;
        private System.Windows.Forms.Button DefaultConfigBtn;
        private System.Windows.Forms.Button LoadConfigBtn;
        private System.Windows.Forms.Label LEonardRootLbl;
        private System.Windows.Forms.Button ChangeRootDirectoryBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RobotConnectBtn;
        private System.Windows.Forms.ComboBox PartGeometryBox;
        private System.Windows.Forms.Label DiameterLbl;
        private System.Windows.Forms.RichTextBox SequenceRTBCopy;
        private System.Windows.Forms.Button JogRunBtn;
        private System.Windows.Forms.TextBox DoorClosedInputTxt;
        private System.Windows.Forms.Button SetDoorClosedInputBtn;
        private System.Windows.Forms.Label DoorClosedLbl;
        private System.Windows.Forms.Label RobotCompletedLbl;
        private System.Windows.Forms.Button SetForceDwellBtn;
        private System.Windows.Forms.Button SetTouchSpeedBtn;
        private System.Windows.Forms.Button SetTouchRetractBtn;
        private System.Windows.Forms.Label GrindProcessStateLbl;
        private System.Windows.Forms.Button JointMoveMountBtn;
        private System.Windows.Forms.Button JointMoveHomeBtn;
        private System.Windows.Forms.Button SetMaxWaitBtn;
        private System.Windows.Forms.Button SetMaxGrindBlendRadiusBtn;
        private System.Windows.Forms.Button SetTrialSpeedBtn;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label RobotSentLbl;
        private System.Windows.Forms.Button SetGrindAccelBtn;
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
        private System.Windows.Forms.TextBox FootswitchPressedInputTxt;
        private System.Windows.Forms.Button SetFootswitchPressedInputBtn;
        private System.Windows.Forms.Label FootswitchPressedLbl;
        private System.Windows.Forms.Label DoorClosedInputLbl;
        private System.Windows.Forms.Label FootswitchPressedInputLbl;
        private System.Windows.Forms.Button ToolTestBtn;
        private System.Windows.Forms.Button CoolantOffBtn;
        private System.Windows.Forms.Button CoolantTestBtn;
        private System.Windows.Forms.Button ToolOffBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label Time2Lbl;
        private System.Windows.Forms.Button SetPointFrequencyBtn;
        private System.Windows.Forms.Button BigEditBtn;
        private System.Windows.Forms.Button SetGrindJogSpeedBtn;
        private System.Windows.Forms.Button SetGrindJogAccelBtn;
        private System.Windows.Forms.Button SetForceModeDampingBtn;
        private System.Windows.Forms.Button SetForceModeGainScalingBtn;
        private System.Windows.Forms.Label GocatorReadyLbl;
        private System.Windows.Forms.TabPage LogsPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox AllLogRTB;
        private System.Windows.Forms.Button ClearAllLogRtbBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox ErrorLogRTB;
        private System.Windows.Forms.Button AboutBtn;
        private System.Windows.Forms.GroupBox LogLevelGroupBox;
        private System.Windows.Forms.ComboBox LogLevelCombo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox RobotLogRTB;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RichTextBox ExecLogRTB;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox AuxLogRTB;
        private System.Windows.Forms.TableLayoutPanel BottomButtonLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel TopButtonLayoutPanel;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TableLayoutPanel RunTabLayoutPanel;
        private System.Windows.Forms.TabPage javaEnginePage;
        private System.Windows.Forms.TableLayoutPanel ProgramTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FileBigEditPanel;
        private System.Windows.Forms.TableLayoutPanel PositionLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel VariablesLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel StatusLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel CommandCounterLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel DiamVersionLayoutPanel;
        private System.Windows.Forms.TabPage pythonEnginePage;
        private System.Windows.Forms.Button JavaRunBtn;
        private System.Windows.Forms.Button PythonRunBtn;
        private System.Windows.Forms.TabControl SetupTab;
        private System.Windows.Forms.TabPage toolsPage;
        private System.Windows.Forms.TableLayoutPanel SetupToolsLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel FootswitchIoLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel DoorIoLayoutPanel;
        private System.Windows.Forms.TabPage devicesPage;
        private System.Windows.Forms.TabPage robotPage;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TableLayoutPanel SetupGeneralLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel SetupDevicesLayoutPanel;
        private System.Windows.Forms.DataGridView DevicesGrd;
        private System.Windows.Forms.TableLayoutPanel SetupGrindLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel LogPageControlsLayoutPanel;
        private System.Windows.Forms.Button SaveDevicesBtn;
        private System.Windows.Forms.Button ReloadDevicesBtn;
        private System.Windows.Forms.Button DeviceConnectBtn;
        private System.Windows.Forms.Button DeviceDisconnectBtn;
        private System.Windows.Forms.Label DevicesFilenameLbl;
        private System.Windows.Forms.Button SetStartupDevicesFileBtn;
        private System.Windows.Forms.Button SaveAsDevicesBtn;
        private System.Windows.Forms.Button ClearDevicesBtn;
        private System.Windows.Forms.Button DeviceReconnectBtn;
        private System.Windows.Forms.Button DeviceConnectAllBtn;
        private System.Windows.Forms.Button DeviceDisconnectAllBtn;
        private System.Windows.Forms.Button DeviceRuntimeStartBtn;
        private System.Windows.Forms.Button DeviceSetupStartBtn;
        private System.Windows.Forms.TableLayoutPanel RuntimeAppHelperLayoutPanel2;
        private System.Windows.Forms.Button DeviceRuntimeExitBtn;
        private System.Windows.Forms.Button DeviceRuntimeMinimizeBtn;
        private System.Windows.Forms.Button DeviceRuntimeRestoreBtn;
        private System.Windows.Forms.TableLayoutPanel SetupAppHelperLayoutPanel2;
        private System.Windows.Forms.Button DeviceSetupExitBtn;
        private System.Windows.Forms.Button DeviceSetupRestoreBtn;
        private System.Windows.Forms.Button DeviceSetupMinimizeBtn;
        private System.Windows.Forms.Button LoadDevicesBtn;
        private System.Windows.Forms.TabPage displaysPage;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TableLayoutPanel JavaScreenLayoutPanel;
        private System.Windows.Forms.Label JavaFilenameLbl;
        private System.Windows.Forms.Button JavaNewBtn;
        private System.Windows.Forms.Button JavaLoadBtn;
        private System.Windows.Forms.Button JavaSaveBtn;
        private System.Windows.Forms.Button JavaSaveAsBtn;
        private System.Windows.Forms.TableLayoutPanel PythonScreenLayoutPanel;
        private System.Windows.Forms.Label PythonFilenameLbl;
        private System.Windows.Forms.Button PythonNewBtn;
        private System.Windows.Forms.Button PythonLoadBtn;
        private System.Windows.Forms.Button PythonSaveBtn;
        private System.Windows.Forms.Button PythonSaveAsBtn;
        private System.Windows.Forms.RichTextBox JavaConsoleRTB;
        private System.Windows.Forms.RichTextBox JavaVariablesRTB;
        private System.Windows.Forms.RichTextBox PythonConsoleRTB;
        private System.Windows.Forms.RichTextBox PythonVariablesRTB;
        private System.Windows.Forms.RichTextBox JavaCodeRTB;
        private System.Windows.Forms.RichTextBox PythonCodeRTB;
        private System.Windows.Forms.TableLayoutPanel SetupDisplayLayoutPanel;
        private System.Windows.Forms.DataGridView DisplaysGrd;
        private System.Windows.Forms.Button SelectDisplayBtn;
        private System.Windows.Forms.Button LoadDisplaysBtn;
        private System.Windows.Forms.Button SaveDisplaysBtn;
        private System.Windows.Forms.Button ClearDisplaysButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SelectedDisplayLbl;
        private System.Windows.Forms.TableLayoutPanel RunCenterColumnLayoutPanel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button MoveToolHomeBtn;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Button MoveToolMountBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label RunStartedTimeLbl;
        private System.Windows.Forms.Label RunElapsedTimeLbl;
        private System.Windows.Forms.Label RunStateLbl;
        private System.Windows.Forms.Label GrindLbl3;
        private System.Windows.Forms.Label CurrentLineLblCopy;
        private System.Windows.Forms.Label GrindLbl1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label StepTimeRemainingLbl;
        private System.Windows.Forms.Label StepElapsedTimeLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label StepTimeEstimateLbl;
        private System.Windows.Forms.TableLayoutPanel GrindNofNLayoutPanel;
        private System.Windows.Forms.Label GrindCycleLbl;
        private System.Windows.Forms.Label GrindLbl2;
        private System.Windows.Forms.Label GrindNCyclesLbl;
        private System.Windows.Forms.TableLayoutPanel LastReportedZLayoutPanel;
        private System.Windows.Forms.Label GrindForceReportZLbl;
        private System.Windows.Forms.Label GrindLbl4;
        private System.Windows.Forms.Label MoveToolMountLbl;
        private System.Windows.Forms.Label MoveToolHomeLbl;
        private System.Windows.Forms.TabPage licensePage;
        private System.Windows.Forms.Button TrialLicenseBtn;
        private System.Windows.Forms.Label LicenseStatusLbl;
        private System.Windows.Forms.TableLayoutPanel SetupLicenseLayoutPanel;
        private System.Windows.Forms.Button JavaLicenseBtn;
        private System.Windows.Forms.GroupBox LicenseAdjustGrp;
        private System.Windows.Forms.TableLayoutPanel AdjustmentButtonLayoutPanel;
        private System.Windows.Forms.Button GocatorLicenseBtn;
        private System.Windows.Forms.Button GrindingLicenseBtn;
        private System.Windows.Forms.Button UrLicenseBtn;
        private System.Windows.Forms.Button PythonLicenseBtn;
        private System.Windows.Forms.Button SaveLicenseBtn;
        private System.Windows.Forms.Button NewLicenseBtn;
        private System.Windows.Forms.Button ReloadLicenseBtn;
        private System.Windows.Forms.GroupBox speedBtnsGrp;
        private System.Windows.Forms.Button SpeedSendBtn1;
        private System.Windows.Forms.Label GocatorConnectedLbl;
        private System.Windows.Forms.Button PythonRestartBtn;
        private MyCheckBox AutoConnectOnLoadChk;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label StartupDevicesLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FullManualBtn;
        private System.Windows.Forms.Button GocatorManualBtn;
        private System.Windows.Forms.Button URManualBtn;
        private System.Windows.Forms.TableLayoutPanel RuntimeAppHelperLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel SetupAppHelperLayoutPanel1;
        private System.Windows.Forms.Button JavaRestartBtn;
    }
}

