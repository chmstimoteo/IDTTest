namespace IDTTest
{
    partial class MainForm
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
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.Location = new System.Drawing.Point(127, 12);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(713, 355);
            this.lstMessage.TabIndex = 1;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(12, 331);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(109, 23);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Clear message";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 366);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.lstMessage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.Button Clear;
    }
}

