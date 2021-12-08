namespace JintTester1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RunBtn = new System.Windows.Forms.Button();
            this.ScriptTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(12, 268);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(279, 40);
            this.RunBtn.TabIndex = 0;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // ScriptTxt
            // 
            this.ScriptTxt.Location = new System.Drawing.Point(12, 12);
            this.ScriptTxt.Multiline = true;
            this.ScriptTxt.Name = "ScriptTxt";
            this.ScriptTxt.Size = new System.Drawing.Size(279, 250);
            this.ScriptTxt.TabIndex = 1;
            this.ScriptTxt.Text = resources.GetString("ScriptTxt.Text");
            this.ScriptTxt.TextChanged += new System.EventHandler(this.ScriptTxt_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 376);
            this.Controls.Add(this.ScriptTxt);
            this.Controls.Add(this.RunBtn);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.TextBox ScriptTxt;
    }
}

