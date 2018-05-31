namespace echoClient
{
    partial class ClientForm
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
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 275);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(409, 195);
            this.messageBox.TabIndex = 0;
            this.messageBox.Text = "";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 12);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(521, 257);
            this.chatBox.TabIndex = 1;
            this.chatBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(427, 275);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(106, 195);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 482);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.messageBox);
            this.Name = "ClientForm";
            this.Text = "Echo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.Button sendButton;
    }
}

