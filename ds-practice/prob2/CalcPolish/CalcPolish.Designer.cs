namespace CalcPolish
{
    partial class CalcPolish
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
            this.expresssionBox = new System.Windows.Forms.TextBox();
            this.equalsButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // expresssionBox
            // 
            this.expresssionBox.Location = new System.Drawing.Point(12, 12);
            this.expresssionBox.Name = "expresssionBox";
            this.expresssionBox.Size = new System.Drawing.Size(100, 20);
            this.expresssionBox.TabIndex = 0;
            // 
            // equalsButton
            // 
            this.equalsButton.Location = new System.Drawing.Point(61, 53);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(75, 23);
            this.equalsButton.TabIndex = 1;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = true;
            this.equalsButton.Click += new System.EventHandler(this.equalsButton_Click);
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(172, 12);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(100, 20);
            this.resultBox.TabIndex = 2;
            // 
            // CalcPolish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.equalsButton);
            this.Controls.Add(this.expresssionBox);
            this.Name = "CalcPolish";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expresssionBox;
        private System.Windows.Forms.Button equalsButton;
        private System.Windows.Forms.TextBox resultBox;
    }
}

