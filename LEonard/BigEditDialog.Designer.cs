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
            this.SuspendLayout();
            // 
            // KeepBtn
            // 
            this.KeepBtn.BackColor = System.Drawing.Color.Green;
            this.KeepBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.KeepBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepBtn.ForeColor = System.Drawing.Color.White;
            this.KeepBtn.Location = new System.Drawing.Point(1619, 1265);
            this.KeepBtn.Margin = new System.Windows.Forms.Padding(2);
            this.KeepBtn.Name = "KeepBtn";
            this.KeepBtn.Size = new System.Drawing.Size(247, 164);
            this.KeepBtn.TabIndex = 8;
            this.KeepBtn.Text = "&Keep\r\nEdits";
            this.KeepBtn.UseVisualStyleBackColor = false;
            this.KeepBtn.Click += new System.EventHandler(this.KeepBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Green;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(1902, 1265);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(247, 164);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // LEonardScriptRTB
            // 
            this.ProgramRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramRTB.Location = new System.Drawing.Point(12, 48);
            this.ProgramRTB.Name = "LEonardScriptRTB";
            this.ProgramRTB.Size = new System.Drawing.Size(1319, 1381);
            this.ProgramRTB.TabIndex = 9;
            this.ProgramRTB.Text = "";
            // 
            // ProgramStatementsRTB
            // 
            this.ProgramStatementsRTB.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramStatementsRTB.Location = new System.Drawing.Point(1337, 12);
            this.ProgramStatementsRTB.Name = "ProgramStatementsRTB";
            this.ProgramStatementsRTB.ReadOnly = true;
            this.ProgramStatementsRTB.Size = new System.Drawing.Size(796, 1248);
            this.ProgramStatementsRTB.TabIndex = 10;
            this.ProgramStatementsRTB.Text = "";
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.BackColor = System.Drawing.Color.Green;
            this.ReloadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadBtn.ForeColor = System.Drawing.Color.White;
            this.ReloadBtn.Location = new System.Drawing.Point(1336, 1265);
            this.ReloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(247, 164);
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
            // BigEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2160, 1440);
            this.ControlBox = false;
            this.Controls.Add(this.FilenameLbl);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.ProgramStatementsRTB);
            this.Controls.Add(this.ProgramRTB);
            this.Controls.Add(this.KeepBtn);
            this.Controls.Add(this.CancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BigEditDialog";
            this.Text = "BigEditDialog";
            this.Load += new System.EventHandler(this.BigEditDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KeepBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.RichTextBox ProgramRTB;
        private System.Windows.Forms.RichTextBox ProgramStatementsRTB;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Label FilenameLbl;
    }
}