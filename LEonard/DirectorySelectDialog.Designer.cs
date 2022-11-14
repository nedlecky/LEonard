namespace LEonard
{
    partial class DirectorySelectDialog
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
            this.DirectoryListBox = new System.Windows.Forms.ListBox();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DirectoryNameLbl = new System.Windows.Forms.Label();
            this.NewFolderBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TableLayoutPanel.SetColumnSpan(this.TitleLbl, 4);
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(3, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(1202, 80);
            this.TitleLbl.TabIndex = 90;
            this.TitleLbl.Text = "TitleLbl";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DirectoryListBox
            // 
            this.TableLayoutPanel.SetColumnSpan(this.DirectoryListBox, 4);
            this.DirectoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryListBox.FormattingEnabled = true;
            this.DirectoryListBox.ItemHeight = 37;
            this.DirectoryListBox.Location = new System.Drawing.Point(3, 83);
            this.DirectoryListBox.Name = "DirectoryListBox";
            this.DirectoryListBox.Size = new System.Drawing.Size(1202, 479);
            this.DirectoryListBox.TabIndex = 89;
            this.DirectoryListBox.Click += new System.EventHandler(this.DirectoryListBox_Click);
            this.DirectoryListBox.DoubleClick += new System.EventHandler(this.DirectoryListBox_DoubleClick);
            // 
            // SelectBtn
            // 
            this.SelectBtn.BackColor = System.Drawing.Color.Green;
            this.SelectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectBtn.ForeColor = System.Drawing.Color.White;
            this.SelectBtn.Location = new System.Drawing.Point(606, 647);
            this.SelectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(298, 120);
            this.SelectBtn.TabIndex = 88;
            this.SelectBtn.Text = "&Select";
            this.SelectBtn.UseVisualStyleBackColor = false;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Green;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(908, 647);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(298, 120);
            this.CancelBtn.TabIndex = 87;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // DirectoryNameLbl
            // 
            this.TableLayoutPanel.SetColumnSpan(this.DirectoryNameLbl, 4);
            this.DirectoryNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryNameLbl.Location = new System.Drawing.Point(3, 565);
            this.DirectoryNameLbl.Name = "DirectoryNameLbl";
            this.DirectoryNameLbl.Size = new System.Drawing.Size(1202, 80);
            this.DirectoryNameLbl.TabIndex = 91;
            this.DirectoryNameLbl.Text = "DirectoryNameLbl";
            this.DirectoryNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewFolderBtn
            // 
            this.NewFolderBtn.BackColor = System.Drawing.Color.Green;
            this.NewFolderBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFolderBtn.ForeColor = System.Drawing.Color.White;
            this.NewFolderBtn.Location = new System.Drawing.Point(2, 647);
            this.NewFolderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewFolderBtn.Name = "NewFolderBtn";
            this.NewFolderBtn.Size = new System.Drawing.Size(298, 120);
            this.NewFolderBtn.TabIndex = 93;
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
            this.DeleteBtn.Location = new System.Drawing.Point(304, 647);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(298, 120);
            this.DeleteBtn.TabIndex = 92;
            this.DeleteBtn.Text = "&Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Controls.Add(this.TitleLbl, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.CancelBtn, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.SelectBtn, 2, 3);
            this.TableLayoutPanel.Controls.Add(this.DeleteBtn, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.NewFolderBtn, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.DirectoryListBox, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.DirectoryNameLbl, 0, 2);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 4;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(1208, 769);
            this.TableLayoutPanel.TabIndex = 94;
            // 
            // DirectorySelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 769);
            this.ControlBox = false;
            this.Controls.Add(this.TableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectorySelectDialog";
            this.Text = "LEonard Directory Select";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectorySelectDialog_FormClosing);
            this.Load += new System.EventHandler(this.DirectorySelectDialog_Load);
            this.Resize += new System.EventHandler(this.DirectorySelectDialog_Resize);
            this.TableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.ListBox DirectoryListBox;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label DirectoryNameLbl;
        private System.Windows.Forms.Button NewFolderBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
    }
}