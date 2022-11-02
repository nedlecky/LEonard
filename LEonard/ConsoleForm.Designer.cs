namespace LEonard
{
    partial class ConsoleForm
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
            this.ConsoleRTB = new System.Windows.Forms.RichTextBox();
            this.ConsoleLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConsoleClearBtn = new System.Windows.Forms.Button();
            this.AlwaysOnTopChk = new LEonard.MyCheckBox();
            this.HideBtn = new System.Windows.Forms.Button();
            this.ConsoleLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleRTB
            // 
            this.ConsoleLayoutPanel.SetColumnSpan(this.ConsoleRTB, 5);
            this.ConsoleRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleRTB.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleRTB.Location = new System.Drawing.Point(3, 79);
            this.ConsoleRTB.Name = "ConsoleRTB";
            this.ConsoleRTB.Size = new System.Drawing.Size(778, 679);
            this.ConsoleRTB.TabIndex = 0;
            this.ConsoleRTB.Text = "";
            // 
            // ConsoleLayoutPanel
            // 
            this.ConsoleLayoutPanel.ColumnCount = 5;
            this.ConsoleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConsoleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConsoleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConsoleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConsoleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ConsoleLayoutPanel.Controls.Add(this.ConsoleRTB, 0, 1);
            this.ConsoleLayoutPanel.Controls.Add(this.ConsoleClearBtn, 4, 0);
            this.ConsoleLayoutPanel.Controls.Add(this.AlwaysOnTopChk, 0, 0);
            this.ConsoleLayoutPanel.Controls.Add(this.HideBtn, 3, 0);
            this.ConsoleLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ConsoleLayoutPanel.Name = "ConsoleLayoutPanel";
            this.ConsoleLayoutPanel.RowCount = 2;
            this.ConsoleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ConsoleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.ConsoleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConsoleLayoutPanel.Size = new System.Drawing.Size(784, 761);
            this.ConsoleLayoutPanel.TabIndex = 1;
            // 
            // ConsoleClearBtn
            // 
            this.ConsoleClearBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleClearBtn.Location = new System.Drawing.Point(627, 3);
            this.ConsoleClearBtn.Name = "ConsoleClearBtn";
            this.ConsoleClearBtn.Size = new System.Drawing.Size(154, 70);
            this.ConsoleClearBtn.TabIndex = 1;
            this.ConsoleClearBtn.Text = "Clear";
            this.ConsoleClearBtn.UseVisualStyleBackColor = true;
            this.ConsoleClearBtn.Click += new System.EventHandler(this.ConsoleClearBtn_Click);
            // 
            // AlwaysOnTopChk
            // 
            this.ConsoleLayoutPanel.SetColumnSpan(this.AlwaysOnTopChk, 2);
            this.AlwaysOnTopChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlwaysOnTopChk.Location = new System.Drawing.Point(3, 3);
            this.AlwaysOnTopChk.Name = "AlwaysOnTopChk";
            this.AlwaysOnTopChk.Size = new System.Drawing.Size(155, 38);
            this.AlwaysOnTopChk.TabIndex = 3;
            this.AlwaysOnTopChk.Text = "Always On Top";
            this.AlwaysOnTopChk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AlwaysOnTopChk.UseVisualStyleBackColor = true;
            this.AlwaysOnTopChk.CheckedChanged += new System.EventHandler(this.AlwaysOnTopChk_CheckedChanged);
            // 
            // HideBtn
            // 
            this.HideBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideBtn.Location = new System.Drawing.Point(471, 3);
            this.HideBtn.Name = "HideBtn";
            this.HideBtn.Size = new System.Drawing.Size(150, 70);
            this.HideBtn.TabIndex = 4;
            this.HideBtn.Text = "Hide - F12";
            this.HideBtn.UseVisualStyleBackColor = true;
            this.HideBtn.Click += new System.EventHandler(this.HideBtn_Click);
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.ControlBox = false;
            this.Controls.Add(this.ConsoleLayoutPanel);
            this.KeyPreview = true;
            this.Name = "ConsoleForm";
            this.Text = "ConsoleForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleForm_FormClosing);
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsoleForm_KeyDown);
            this.Resize += new System.EventHandler(this.ConsoleForm_Resize);
            this.ConsoleLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleRTB;
        private System.Windows.Forms.TableLayoutPanel ConsoleLayoutPanel;
        private System.Windows.Forms.Button ConsoleClearBtn;
        private MyCheckBox AlwaysOnTopChk;
        private System.Windows.Forms.Button HideBtn;
    }
}