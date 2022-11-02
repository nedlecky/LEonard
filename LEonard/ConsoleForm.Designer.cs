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
            this.ConsoleLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleRTB
            // 
            this.ConsoleLayoutPanel.SetColumnSpan(this.ConsoleRTB, 5);
            this.ConsoleRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleRTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleRTB.Location = new System.Drawing.Point(3, 77);
            this.ConsoleRTB.Name = "ConsoleRTB";
            this.ConsoleRTB.Size = new System.Drawing.Size(850, 668);
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
            this.ConsoleLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ConsoleLayoutPanel.Name = "ConsoleLayoutPanel";
            this.ConsoleLayoutPanel.RowCount = 2;
            this.ConsoleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ConsoleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.ConsoleLayoutPanel.Size = new System.Drawing.Size(856, 748);
            this.ConsoleLayoutPanel.TabIndex = 1;
            // 
            // ConsoleClearBtn
            // 
            this.ConsoleClearBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleClearBtn.Location = new System.Drawing.Point(687, 3);
            this.ConsoleClearBtn.Name = "ConsoleClearBtn";
            this.ConsoleClearBtn.Size = new System.Drawing.Size(166, 68);
            this.ConsoleClearBtn.TabIndex = 1;
            this.ConsoleClearBtn.Text = "Clear";
            this.ConsoleClearBtn.UseVisualStyleBackColor = true;
            this.ConsoleClearBtn.Click += new System.EventHandler(this.ConsoleClearBtn_Click);
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 748);
            this.Controls.Add(this.ConsoleLayoutPanel);
            this.Name = "ConsoleForm";
            this.Text = "ConsoleForm";
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.ConsoleLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleRTB;
        private System.Windows.Forms.TableLayoutPanel ConsoleLayoutPanel;
        private System.Windows.Forms.Button ConsoleClearBtn;
    }
}