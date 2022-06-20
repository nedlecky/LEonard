namespace LEonardTablet
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
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseTmr
            // 
            this.CloseTmr.Tick += new System.EventHandler(this.CloseTmr_Tick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Agency FB", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(680, 76);
            this.label2.TabIndex = 1;
            this.label2.Text = "LEonardTablet";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Green;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(564, 288);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(127, 108);
            this.CloseBtn.TabIndex = 81;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DeveloperLogoPic
            // 
            this.DeveloperLogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeveloperLogoPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeveloperLogoPic.Image = ((System.Drawing.Image)(resources.GetObject("DeveloperLogoPic.Image")));
            this.DeveloperLogoPic.Location = new System.Drawing.Point(179, 193);
            this.DeveloperLogoPic.Name = "DeveloperLogoPic";
            this.DeveloperLogoPic.Size = new System.Drawing.Size(319, 203);
            this.DeveloperLogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DeveloperLogoPic.TabIndex = 85;
            this.DeveloperLogoPic.TabStop = false;
            // 
            // VersionLbl
            // 
            this.VersionLbl.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.ForeColor = System.Drawing.Color.Black;
            this.VersionLbl.Location = new System.Drawing.Point(2, 86);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(700, 81);
            this.VersionLbl.TabIndex = 87;
            this.VersionLbl.Text = "VersionLbl\r\nLine 2";
            this.VersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(702, 430);
            this.ControlBox = false;
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.DeveloperLogoPic);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LEonardTablet Information";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.Click += new System.EventHandler(this.SplashForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DeveloperLogoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CloseTmr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PictureBox DeveloperLogoPic;
        private System.Windows.Forms.Label VersionLbl;
    }
}