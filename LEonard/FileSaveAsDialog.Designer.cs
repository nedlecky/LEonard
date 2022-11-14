namespace LEonard
{
    partial class FileSaveAsDialog
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.FileNameTxt = new System.Windows.Forms.TextBox();
            this.DirectoryNameLbl = new System.Windows.Forms.Label();
            this.DirectoryListBox = new System.Windows.Forms.ListBox();
            this.NewFolderBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveAsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SaveAsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.SaveAsLayoutPanel.SetColumnSpan(this.TitleLbl, 4);
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(3, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(984, 51);
            this.TitleLbl.TabIndex = 85;
            this.TitleLbl.Text = "TitleLbl";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileListBox
            // 
            this.SaveAsLayoutPanel.SetColumnSpan(this.FileListBox, 3);
            this.FileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 42;
            this.FileListBox.Items.AddRange(new object[] {
            "FileListBox"});
            this.FileListBox.Location = new System.Drawing.Point(250, 105);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(737, 508);
            this.FileListBox.TabIndex = 84;
            this.FileListBox.Click += new System.EventHandler(this.FileListBox_Click);
            this.FileListBox.DoubleClick += new System.EventHandler(this.FileListBox_DoubleClick);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.Green;
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(496, 663);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(243, 98);
            this.SaveBtn.TabIndex = 83;
            this.SaveBtn.Text = "&Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Green;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(743, 663);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(245, 98);
            this.CancelBtn.TabIndex = 82;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // FileNameTxt
            // 
            this.SaveAsLayoutPanel.SetColumnSpan(this.FileNameTxt, 3);
            this.FileNameTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameTxt.Location = new System.Drawing.Point(250, 619);
            this.FileNameTxt.Name = "FileNameTxt";
            this.FileNameTxt.Size = new System.Drawing.Size(732, 44);
            this.FileNameTxt.TabIndex = 86;
            this.FileNameTxt.Enter += new System.EventHandler(this.FileNameTxt_Enter);
            // 
            // DirectoryNameLbl
            // 
            this.DirectoryNameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveAsLayoutPanel.SetColumnSpan(this.DirectoryNameLbl, 4);
            this.DirectoryNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryNameLbl.Location = new System.Drawing.Point(3, 51);
            this.DirectoryNameLbl.Name = "DirectoryNameLbl";
            this.DirectoryNameLbl.Size = new System.Drawing.Size(984, 51);
            this.DirectoryNameLbl.TabIndex = 88;
            this.DirectoryNameLbl.Text = "DirectoryName";
            this.DirectoryNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DirectoryListBox
            // 
            this.DirectoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryListBox.FormattingEnabled = true;
            this.DirectoryListBox.ItemHeight = 42;
            this.DirectoryListBox.Items.AddRange(new object[] {
            "DirectoryListBox"});
            this.DirectoryListBox.Location = new System.Drawing.Point(3, 105);
            this.DirectoryListBox.Name = "DirectoryListBox";
            this.DirectoryListBox.Size = new System.Drawing.Size(241, 508);
            this.DirectoryListBox.TabIndex = 87;
            this.DirectoryListBox.Click += new System.EventHandler(this.DirectoryListBox_Click);
            this.DirectoryListBox.DoubleClick += new System.EventHandler(this.DirectoryListBox_DoubleClick);
            // 
            // NewFolderBtn
            // 
            this.NewFolderBtn.BackColor = System.Drawing.Color.Green;
            this.NewFolderBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFolderBtn.ForeColor = System.Drawing.Color.White;
            this.NewFolderBtn.Location = new System.Drawing.Point(2, 663);
            this.NewFolderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewFolderBtn.Name = "NewFolderBtn";
            this.NewFolderBtn.Size = new System.Drawing.Size(243, 98);
            this.NewFolderBtn.TabIndex = 91;
            this.NewFolderBtn.Text = "&New Folder";
            this.NewFolderBtn.UseVisualStyleBackColor = false;
            this.NewFolderBtn.Click += new System.EventHandler(this.NewFolderBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Green;
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(249, 663);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(243, 98);
            this.DeleteBtn.TabIndex = 92;
            this.DeleteBtn.Text = "&Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 616);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 45);
            this.label1.TabIndex = 93;
            this.label1.Text = "File Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveAsLayoutPanel
            // 
            this.SaveAsLayoutPanel.ColumnCount = 4;
            this.SaveAsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.SaveAsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.SaveAsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.SaveAsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.SaveAsLayoutPanel.Controls.Add(this.CancelBtn, 3, 4);
            this.SaveAsLayoutPanel.Controls.Add(this.TitleLbl, 0, 0);
            this.SaveAsLayoutPanel.Controls.Add(this.DirectoryNameLbl, 0, 1);
            this.SaveAsLayoutPanel.Controls.Add(this.label1, 0, 3);
            this.SaveAsLayoutPanel.Controls.Add(this.SaveBtn, 2, 4);
            this.SaveAsLayoutPanel.Controls.Add(this.FileNameTxt, 1, 3);
            this.SaveAsLayoutPanel.Controls.Add(this.NewFolderBtn, 0, 4);
            this.SaveAsLayoutPanel.Controls.Add(this.DeleteBtn, 1, 4);
            this.SaveAsLayoutPanel.Controls.Add(this.DirectoryListBox, 0, 2);
            this.SaveAsLayoutPanel.Controls.Add(this.FileListBox, 1, 2);
            this.SaveAsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SaveAsLayoutPanel.Name = "SaveAsLayoutPanel";
            this.SaveAsLayoutPanel.RowCount = 5;
            this.SaveAsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.738725F));
            this.SaveAsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.738725F));
            this.SaveAsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.38727F));
            this.SaveAsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.927383F));
            this.SaveAsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.2079F));
            this.SaveAsLayoutPanel.Size = new System.Drawing.Size(990, 763);
            this.SaveAsLayoutPanel.TabIndex = 94;
            // 
            // FileSaveAsDialog
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(990, 763);
            this.ControlBox = false;
            this.Controls.Add(this.SaveAsLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSaveAsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LEonard File Save As";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileSaveAsDialog_FormClosing);
            this.Load += new System.EventHandler(this.FileSaveAsDialog_Load);
            this.Resize += new System.EventHandler(this.FileSaveAsDialog_Resize);
            this.SaveAsLayoutPanel.ResumeLayout(false);
            this.SaveAsLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox FileNameTxt;
        private System.Windows.Forms.Label DirectoryNameLbl;
        private System.Windows.Forms.ListBox DirectoryListBox;
        private System.Windows.Forms.Button NewFolderBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel SaveAsLayoutPanel;
    }
}