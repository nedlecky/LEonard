namespace LEonardSetup
{
    partial class MainSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSetupForm));
            this.InstallBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.ProductNameVersionLbl = new System.Windows.Forms.Label();
            this.DeveloperLogoPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UninstallBtn = new System.Windows.Forms.Button();
            this.InstructionsLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.FeedbackLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstallBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InstallBtn, 2);
            this.InstallBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallBtn.Location = new System.Drawing.Point(7, 463);
            this.InstallBtn.Margin = new System.Windows.Forms.Padding(7);
            this.InstallBtn.Name = "InstallBtn";
            this.InstallBtn.Size = new System.Drawing.Size(312, 80);
            this.InstallBtn.TabIndex = 0;
            this.InstallBtn.Text = "Install to C:\\LEonard";
            this.InstallBtn.UseVisualStyleBackColor = true;
            this.InstallBtn.Click += new System.EventHandler(this.InstallBtn_Click);
            // 
            // QuitBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.QuitBtn, 2);
            this.QuitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuitBtn.Location = new System.Drawing.Point(659, 463);
            this.QuitBtn.Margin = new System.Windows.Forms.Padding(7);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(316, 80);
            this.QuitBtn.TabIndex = 1;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // ProductNameVersionLbl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ProductNameVersionLbl, 6);
            this.ProductNameVersionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductNameVersionLbl.Font = new System.Drawing.Font("Agency FB", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameVersionLbl.ForeColor = System.Drawing.Color.Black;
            this.ProductNameVersionLbl.Location = new System.Drawing.Point(2, 0);
            this.ProductNameVersionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductNameVersionLbl.Name = "ProductNameVersionLbl";
            this.ProductNameVersionLbl.Size = new System.Drawing.Size(978, 152);
            this.ProductNameVersionLbl.TabIndex = 3;
            this.ProductNameVersionLbl.Text = "LEonard Setup. Welcome!";
            this.ProductNameVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeveloperLogoPic
            // 
            this.DeveloperLogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeveloperLogoPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeveloperLogoPic.Image = ((System.Drawing.Image)(resources.GetObject("DeveloperLogoPic.Image")));
            this.DeveloperLogoPic.Location = new System.Drawing.Point(75, 46);
            this.DeveloperLogoPic.Name = "DeveloperLogoPic";
            this.DeveloperLogoPic.Size = new System.Drawing.Size(157, 93);
            this.DeveloperLogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeveloperLogoPic.TabIndex = 86;
            this.DeveloperLogoPic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(320, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // VersionLbl
            // 
            this.VersionLbl.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.ForeColor = System.Drawing.Color.Black;
            this.VersionLbl.Location = new System.Drawing.Point(2, 0);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(314, 33);
            this.VersionLbl.TabIndex = 90;
            this.VersionLbl.Text = "VersionLbl";
            this.VersionLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.UninstallBtn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ProductNameVersionLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.QuitBtn, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.InstructionsLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.InstallBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FeedbackLbl, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 550);
            this.tableLayoutPanel1.TabIndex = 91;
            // 
            // UninstallBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.UninstallBtn, 2);
            this.UninstallBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UninstallBtn.Location = new System.Drawing.Point(329, 459);
            this.UninstallBtn.Name = "UninstallBtn";
            this.UninstallBtn.Size = new System.Drawing.Size(320, 88);
            this.UninstallBtn.TabIndex = 94;
            this.UninstallBtn.Text = "Uninstall and Delete C:\\LEonard";
            this.UninstallBtn.UseVisualStyleBackColor = true;
            this.UninstallBtn.Click += new System.EventHandler(this.UninstallBtn_Click);
            // 
            // InstructionsLbl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.InstructionsLbl, 2);
            this.InstructionsLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InstructionsLbl.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLbl.ForeColor = System.Drawing.Color.Black;
            this.InstructionsLbl.Location = new System.Drawing.Point(2, 304);
            this.InstructionsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InstructionsLbl.Name = "InstructionsLbl";
            this.InstructionsLbl.Size = new System.Drawing.Size(322, 152);
            this.InstructionsLbl.TabIndex = 92;
            this.InstructionsLbl.Text = "Let\'s keep this simple:";
            this.InstructionsLbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.DeveloperLogoPic);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.VersionLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 146);
            this.panel2.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 31);
            this.label1.TabIndex = 92;
            this.label1.Text = "by";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FeedbackLbl
            // 
            this.FeedbackLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeedbackLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedbackLbl.Location = new System.Drawing.Point(818, 304);
            this.FeedbackLbl.Name = "FeedbackLbl";
            this.FeedbackLbl.Size = new System.Drawing.Size(161, 152);
            this.FeedbackLbl.TabIndex = 0;
            // 
            // MainSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 550);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "MainSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEonard by Lecky Engineering";
            this.Load += new System.EventHandler(this.MainSetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstallBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Label ProductNameVersionLbl;
        private System.Windows.Forms.PictureBox DeveloperLogoPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InstructionsLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UninstallBtn;
        private System.Windows.Forms.Label FeedbackLbl;
    }
}

