namespace Example_Async_Call
{
    partial class frmLogger
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
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.txtLogInfo = new System.Windows.Forms.TextBox();
            this.btnLogInfo = new System.Windows.Forms.Button();
            this.btnSyncRead = new System.Windows.Forms.Button();
            this.btnAsyncRead = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(112, 63);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(225, 20);
            this.txtLogPath.TabIndex = 0;
            this.txtLogPath.Text = "C:\\Users\\bschroeder\\Desktop\\LogTest.txt";
            // 
            // txtLogInfo
            // 
            this.txtLogInfo.Location = new System.Drawing.Point(112, 133);
            this.txtLogInfo.Name = "txtLogInfo";
            this.txtLogInfo.Size = new System.Drawing.Size(225, 20);
            this.txtLogInfo.TabIndex = 1;
            this.txtLogInfo.Text = "Test Message";
            // 
            // btnLogInfo
            // 
            this.btnLogInfo.Location = new System.Drawing.Point(149, 194);
            this.btnLogInfo.Name = "btnLogInfo";
            this.btnLogInfo.Size = new System.Drawing.Size(150, 27);
            this.btnLogInfo.TabIndex = 2;
            this.btnLogInfo.Text = "Log Info";
            this.btnLogInfo.UseVisualStyleBackColor = true;
            this.btnLogInfo.Click += new System.EventHandler(this.btnLogInfo_Click);
            // 
            // btnSyncRead
            // 
            this.btnSyncRead.Location = new System.Drawing.Point(383, 62);
            this.btnSyncRead.Name = "btnSyncRead";
            this.btnSyncRead.Size = new System.Drawing.Size(127, 21);
            this.btnSyncRead.TabIndex = 3;
            this.btnSyncRead.Text = "Sync Read";
            this.btnSyncRead.UseVisualStyleBackColor = true;
            this.btnSyncRead.Click += new System.EventHandler(this.btnSyncRead_Click);
            // 
            // btnAsyncRead
            // 
            this.btnAsyncRead.Location = new System.Drawing.Point(383, 107);
            this.btnAsyncRead.Name = "btnAsyncRead";
            this.btnAsyncRead.Size = new System.Drawing.Size(127, 21);
            this.btnAsyncRead.TabIndex = 4;
            this.btnAsyncRead.Text = "Async Read";
            this.btnAsyncRead.UseVisualStyleBackColor = true;
            this.btnAsyncRead.Click += new System.EventHandler(this.btnAsyncRead_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(383, 151);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(127, 21);
            this.btnMessage.TabIndex = 5;
            this.btnMessage.Text = "Say Hello";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // frmLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 314);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnAsyncRead);
            this.Controls.Add(this.btnSyncRead);
            this.Controls.Add(this.btnLogInfo);
            this.Controls.Add(this.txtLogInfo);
            this.Controls.Add(this.txtLogPath);
            this.Name = "frmLogger";
            this.Text = "Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.TextBox txtLogInfo;
        private System.Windows.Forms.Button btnLogInfo;
        private System.Windows.Forms.Button btnSyncRead;
        private System.Windows.Forms.Button btnAsyncRead;
        private System.Windows.Forms.Button btnMessage;
    }
}

