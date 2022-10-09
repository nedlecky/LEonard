namespace LEonard
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.CloseTmr = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DeveloperLogoPic = new System.Windows.Forms.PictureBox();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowTmr = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseTmr
            // 
            this.CloseTmr.Tick += new System.EventHandler(this.CloseTmr_Tick);
            // 
            // label2
            // 
            this.tableLayoutPanel.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Agency FB", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(528, 99);
            this.label2.TabIndex = 1;
            this.label2.Text = "LEonard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(535, 598);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(164, 72);
            this.CloseBtn.TabIndex = 81;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DeveloperLogoPic
            // 
            this.DeveloperLogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeveloperLogoPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeveloperLogoPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeveloperLogoPic.Image = ((System.Drawing.Image)(resources.GetObject("DeveloperLogoPic.Image")));
            this.DeveloperLogoPic.Location = new System.Drawing.Point(535, 3);
            this.DeveloperLogoPic.Name = "DeveloperLogoPic";
            this.DeveloperLogoPic.Size = new System.Drawing.Size(164, 93);
            this.DeveloperLogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeveloperLogoPic.TabIndex = 85;
            this.DeveloperLogoPic.TabStop = false;
            // 
            // VersionLbl
            // 
            this.tableLayoutPanel.SetColumnSpan(this.VersionLbl, 3);
            this.VersionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionLbl.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.ForeColor = System.Drawing.Color.Black;
            this.VersionLbl.Location = new System.Drawing.Point(2, 99);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(698, 99);
            this.VersionLbl.TabIndex = 87;
            this.VersionLbl.Text = "VersionLbl\r\nLine 2";
            this.VersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(172, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.13793F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.72414F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.13793F));
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBox1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.VersionLbl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.DeveloperLogoPic, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.CloseBtn, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44445F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(702, 673);
            this.tableLayoutPanel.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 91);
            this.label1.TabIndex = 89;
            this.label1.Text = "\r\nCopyright Lecky Engineering LLC 2021, 2022, 2023\r\n\r\nLibraries:\r\n  NLog\r\n  Jint\r" +
    "\n  IronPython";
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(702, 673);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LEonard Information";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.Click += new System.EventHandler(this.SplashForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CloseTmr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PictureBox DeveloperLogoPic;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer ShowTmr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
    }
}