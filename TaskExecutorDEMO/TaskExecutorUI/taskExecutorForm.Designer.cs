namespace TaskExecutorUI
{
    partial class taskExecutorForm
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
            this.taskProgressBar = new System.Windows.Forms.ProgressBar();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taskProgressBar
            // 
            this.taskProgressBar.Location = new System.Drawing.Point(12, 12);
            this.taskProgressBar.Name = "taskProgressBar";
            this.taskProgressBar.Size = new System.Drawing.Size(544, 23);
            this.taskProgressBar.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(562, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            // 
            // taskExecutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 47);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.taskProgressBar);
            this.Name = "taskExecutorForm";
            this.Text = "Task Executor UI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar taskProgressBar;
        private System.Windows.Forms.Button startBtn;
    }
}

