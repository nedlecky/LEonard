namespace LEonard
{
    partial class BigEditDialog
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
            this.KeepBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ProgramRTB = new System.Windows.Forms.RichTextBox();
            this.ProgramStatementsRTB = new System.Windows.Forms.RichTextBox();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.FilenameLbl = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainTableLayoutPanel.SuspendLayout();
            this.ButtonTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeepBtn
            // 
            this.KeepBtn.BackColor = System.Drawing.Color.Green;
            this.KeepBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.KeepBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeepBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepBtn.ForeColor = System.Drawing.Color.White;
            this.KeepBtn.Location = new System.Drawing.Point(165, 2);
            this.KeepBtn.Margin = new System.Windows.Forms.Padding(2);
            this.KeepBtn.Name = "KeepBtn";
            this.KeepBtn.Size = new System.Drawing.Size(159, 123);
            this.KeepBtn.TabIndex = 8;
            this.KeepBtn.Text = "&Keep\r\nEdits";
            this.KeepBtn.UseVisualStyleBackColor = false;
            this.KeepBtn.Click += new System.EventHandler(this.KeepBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Green;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(328, 2);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(159, 123);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ProgramRTB
            // 
            this.ProgramRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramRTB.Location = new System.Drawing.Point(3, 3);
            this.ProgramRTB.Name = "ProgramRTB";
            this.MainTableLayoutPanel.SetRowSpan(this.ProgramRTB, 2);
            this.ProgramRTB.Size = new System.Drawing.Size(983, 955);
            this.ProgramRTB.TabIndex = 9;
            this.ProgramRTB.Text = "";
            // 
            // ProgramStatementsRTB
            // 
            this.ProgramStatementsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramStatementsRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramStatementsRTB.Location = new System.Drawing.Point(992, 3);
            this.ProgramStatementsRTB.Name = "ProgramStatementsRTB";
            this.ProgramStatementsRTB.ReadOnly = true;
            this.ProgramStatementsRTB.Size = new System.Drawing.Size(489, 822);
            this.ProgramStatementsRTB.TabIndex = 10;
            this.ProgramStatementsRTB.Text = "";
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.BackColor = System.Drawing.Color.Green;
            this.ReloadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReloadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadBtn.ForeColor = System.Drawing.Color.White;
            this.ReloadBtn.Location = new System.Drawing.Point(2, 2);
            this.ReloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(159, 123);
            this.ReloadBtn.TabIndex = 11;
            this.ReloadBtn.Text = "&Abandon\r\nEdits";
            this.ReloadBtn.UseVisualStyleBackColor = false;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // FilenameLbl
            // 
            this.FilenameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilenameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilenameLbl.Location = new System.Drawing.Point(12, 9);
            this.FilenameLbl.Name = "FilenameLbl";
            this.FilenameLbl.Size = new System.Drawing.Size(1319, 36);
            this.FilenameLbl.TabIndex = 12;
            this.FilenameLbl.Text = "FilenameLbl";
            this.FilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainTableLayoutPanel.Controls.Add(this.ProgramRTB, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ProgramStatementsRTB, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ButtonTableLayoutPanel, 1, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.20689F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.7931F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1484, 961);
            this.MainTableLayoutPanel.TabIndex = 13;
            // 
            // ButtonTableLayoutPanel
            // 
            this.ButtonTableLayoutPanel.ColumnCount = 3;
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonTableLayoutPanel.Controls.Add(this.ReloadBtn, 0, 0);
            this.ButtonTableLayoutPanel.Controls.Add(this.KeepBtn, 1, 0);
            this.ButtonTableLayoutPanel.Controls.Add(this.CancelBtn, 2, 0);
            this.ButtonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonTableLayoutPanel.Location = new System.Drawing.Point(992, 831);
            this.ButtonTableLayoutPanel.Name = "ButtonTableLayoutPanel";
            this.ButtonTableLayoutPanel.RowCount = 1;
            this.ButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonTableLayoutPanel.Size = new System.Drawing.Size(489, 127);
            this.ButtonTableLayoutPanel.TabIndex = 11;
            // 
            // BigEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Controls.Add(this.FilenameLbl);
            this.Name = "BigEditDialog";
            this.Text = "BigEditDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BigEditDialog_FormClosing);
            this.Load += new System.EventHandler(this.BigEditDialog_Load);
            this.Resize += new System.EventHandler(this.BigEditDialog_Resize);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.ButtonTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KeepBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.RichTextBox ProgramRTB;
        private System.Windows.Forms.RichTextBox ProgramStatementsRTB;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Label FilenameLbl;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ButtonTableLayoutPanel;
    }
}