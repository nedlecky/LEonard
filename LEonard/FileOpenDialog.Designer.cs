namespace LEonard
{
    partial class FileOpenDialog
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
            this.OpenBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.DirectoryListBox = new System.Windows.Forms.ListBox();
            this.DirectoryNameLbl = new System.Windows.Forms.Label();
            this.FileNameTxt = new System.Windows.Forms.TextBox();
            this.PreviewRTB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.NewFolderBtn = new System.Windows.Forms.Button();
            this.FileOpenLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileOpenLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenBtn
            // 
            this.OpenBtn.BackColor = System.Drawing.Color.Green;
            this.OpenBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenBtn.ForeColor = System.Drawing.Color.White;
            this.OpenBtn.Location = new System.Drawing.Point(684, 671);
            this.OpenBtn.Margin = new System.Windows.Forms.Padding(2);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(337, 105);
            this.OpenBtn.TabIndex = 79;
            this.OpenBtn.Text = "&Open";
            this.OpenBtn.UseVisualStyleBackColor = false;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Green;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(1025, 671);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(338, 105);
            this.CancelBtn.TabIndex = 78;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // FileListBox
            // 
            this.FileOpenLayoutPanel.SetColumnSpan(this.FileListBox, 2);
            this.FileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 42;
            this.FileListBox.Location = new System.Drawing.Point(344, 89);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(676, 534);
            this.FileListBox.TabIndex = 80;
            this.FileListBox.Click += new System.EventHandler(this.FileListBox_Click);
            this.FileListBox.SelectedIndexChanged += new System.EventHandler(this.FileListBox_SelectedIndexChanged);
            this.FileListBox.DoubleClick += new System.EventHandler(this.FileListBox_DoubleClick);
            // 
            // TitleLbl
            // 
            this.FileOpenLayoutPanel.SetColumnSpan(this.TitleLbl, 3);
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(3, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(1017, 43);
            this.TitleLbl.TabIndex = 81;
            this.TitleLbl.Text = "TitleLbl";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DirectoryListBox
            // 
            this.DirectoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryListBox.FormattingEnabled = true;
            this.DirectoryListBox.ItemHeight = 42;
            this.DirectoryListBox.Location = new System.Drawing.Point(3, 89);
            this.DirectoryListBox.Name = "DirectoryListBox";
            this.DirectoryListBox.Size = new System.Drawing.Size(335, 534);
            this.DirectoryListBox.TabIndex = 82;
            this.DirectoryListBox.Click += new System.EventHandler(this.DirectoryListBox_Click);
            this.DirectoryListBox.DoubleClick += new System.EventHandler(this.DirectoryListBox_DoubleClick);
            // 
            // DirectoryNameLbl
            // 
            this.DirectoryNameLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileOpenLayoutPanel.SetColumnSpan(this.DirectoryNameLbl, 3);
            this.DirectoryNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryNameLbl.Location = new System.Drawing.Point(3, 43);
            this.DirectoryNameLbl.Name = "DirectoryNameLbl";
            this.DirectoryNameLbl.Size = new System.Drawing.Size(1017, 43);
            this.DirectoryNameLbl.TabIndex = 84;
            this.DirectoryNameLbl.Text = "DirectoryName";
            this.DirectoryNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileNameTxt
            // 
            this.FileNameTxt.AcceptsReturn = true;
            this.FileOpenLayoutPanel.SetColumnSpan(this.FileNameTxt, 2);
            this.FileNameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameTxt.Location = new System.Drawing.Point(343, 628);
            this.FileNameTxt.Margin = new System.Windows.Forms.Padding(2);
            this.FileNameTxt.Name = "FileNameTxt";
            this.FileNameTxt.Size = new System.Drawing.Size(678, 44);
            this.FileNameTxt.TabIndex = 85;
            this.FileNameTxt.TextChanged += new System.EventHandler(this.FileNameTxt_TextChanged);
            // 
            // PreviewRTB
            // 
            this.PreviewRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewRTB.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewRTB.Location = new System.Drawing.Point(1025, 45);
            this.PreviewRTB.Margin = new System.Windows.Forms.Padding(2);
            this.PreviewRTB.Name = "PreviewRTB";
            this.PreviewRTB.ReadOnly = true;
            this.FileOpenLayoutPanel.SetRowSpan(this.PreviewRTB, 3);
            this.PreviewRTB.Size = new System.Drawing.Size(338, 622);
            this.PreviewRTB.TabIndex = 86;
            this.PreviewRTB.Text = "";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 626);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 43);
            this.label1.TabIndex = 87;
            this.label1.Text = "File Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1026, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 37);
            this.label2.TabIndex = 88;
            this.label2.Text = "Preview";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.Green;
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(343, 671);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(337, 105);
            this.DeleteBtn.TabIndex = 89;
            this.DeleteBtn.Text = "&Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // NewFolderBtn
            // 
            this.NewFolderBtn.BackColor = System.Drawing.Color.Green;
            this.NewFolderBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFolderBtn.ForeColor = System.Drawing.Color.White;
            this.NewFolderBtn.Location = new System.Drawing.Point(2, 671);
            this.NewFolderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewFolderBtn.Name = "NewFolderBtn";
            this.NewFolderBtn.Size = new System.Drawing.Size(337, 105);
            this.NewFolderBtn.TabIndex = 90;
            this.NewFolderBtn.Text = "&New Folder";
            this.NewFolderBtn.UseVisualStyleBackColor = false;
            this.NewFolderBtn.Click += new System.EventHandler(this.NewFolderBtn_Click);
            // 
            // FileOpenLayoutPanel
            // 
            this.FileOpenLayoutPanel.ColumnCount = 4;
            this.FileOpenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FileOpenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FileOpenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FileOpenLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FileOpenLayoutPanel.Controls.Add(this.PreviewRTB, 3, 1);
            this.FileOpenLayoutPanel.Controls.Add(this.label2, 3, 0);
            this.FileOpenLayoutPanel.Controls.Add(this.FileListBox, 1, 2);
            this.FileOpenLayoutPanel.Controls.Add(this.DirectoryListBox, 0, 2);
            this.FileOpenLayoutPanel.Controls.Add(this.DirectoryNameLbl, 0, 1);
            this.FileOpenLayoutPanel.Controls.Add(this.TitleLbl, 0, 0);
            this.FileOpenLayoutPanel.Controls.Add(this.label1, 0, 3);
            this.FileOpenLayoutPanel.Controls.Add(this.FileNameTxt, 1, 3);
            this.FileOpenLayoutPanel.Controls.Add(this.NewFolderBtn, 0, 4);
            this.FileOpenLayoutPanel.Controls.Add(this.DeleteBtn, 1, 4);
            this.FileOpenLayoutPanel.Controls.Add(this.OpenBtn, 2, 4);
            this.FileOpenLayoutPanel.Controls.Add(this.CancelBtn, 3, 4);
            this.FileOpenLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileOpenLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FileOpenLayoutPanel.Name = "FileOpenLayoutPanel";
            this.FileOpenLayoutPanel.RowCount = 5;
            this.FileOpenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.FileOpenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.FileOpenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.44444F));
            this.FileOpenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.FileOpenLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.FileOpenLayoutPanel.Size = new System.Drawing.Size(1365, 778);
            this.FileOpenLayoutPanel.TabIndex = 91;
            // 
            // FileOpenDialog
            // 
            this.AcceptButton = this.OpenBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(1365, 778);
            this.ControlBox = false;
            this.Controls.Add(this.FileOpenLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileOpenDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LEonard File Open";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileOpenDialog_FormClosing);
            this.Load += new System.EventHandler(this.FileOpenForm_Load);
            this.Resize += new System.EventHandler(this.FileOpenDialog_Resize);
            this.FileOpenLayoutPanel.ResumeLayout(false);
            this.FileOpenLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.ListBox DirectoryListBox;
        private System.Windows.Forms.Label DirectoryNameLbl;
        private System.Windows.Forms.TextBox FileNameTxt;
        private System.Windows.Forms.RichTextBox PreviewRTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button NewFolderBtn;
        private System.Windows.Forms.TableLayoutPanel FileOpenLayoutPanel;
    }
}