namespace ChatUI
{
    partial class ChatUI
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
            this.sendBox = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(12, 446);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(516, 20);
            this.sendBox.TabIndex = 0;
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.Control;
            this.chatBox.Location = new System.Drawing.Point(12, 12);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(597, 428);
            this.chatBox.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(534, 446);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 20);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // ChatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 478);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.sendBox);
            this.Name = "ChatUI";
            this.Text = "Chat Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatUI_FormClosing);
            this.Load += new System.EventHandler(this.ChatUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.Button sendBtn;
    }
}

