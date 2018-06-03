namespace Dir2Xml
{
    partial class AppForm
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
            this.saveToXmlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveToXmlButton
            // 
            this.saveToXmlButton.Location = new System.Drawing.Point(123, 133);
            this.saveToXmlButton.Name = "saveToXmlButton";
            this.saveToXmlButton.Size = new System.Drawing.Size(106, 23);
            this.saveToXmlButton.TabIndex = 0;
            this.saveToXmlButton.Text = "Save to XML";
            this.saveToXmlButton.UseVisualStyleBackColor = true;
            this.saveToXmlButton.Click += new System.EventHandler(this.saveToXmlButton_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 241);
            this.Controls.Add(this.saveToXmlButton);
            this.Name = "AppForm";
            this.Text = "Dir2Xml";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveToXmlButton;
    }
}

