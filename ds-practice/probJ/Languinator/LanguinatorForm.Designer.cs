namespace Languinator
{
    partial class LanguinatorForm
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
            this.helloLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Location = new System.Drawing.Point(102, 122);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(0, 13);
            this.helloLabel.TabIndex = 0;
            // 
            // LanguinatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.helloLabel);
            this.Name = "LanguinatorForm";
            this.Text = "Languinator";
            this.Load += new System.EventHandler(this.LanguinatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloLabel;
    }
}

