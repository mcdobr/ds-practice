namespace CalcSimple
{
    partial class CalcSimpleForm
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
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multiplicationButton = new System.Windows.Forms.Button();
            this.divisionButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.powerButton = new System.Windows.Forms.Button();
            this.firstOperandBox = new System.Windows.Forms.TextBox();
            this.secondOperandBox = new System.Windows.Forms.TextBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(394, 359);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 23);
            this.plusButton.TabIndex = 0;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(394, 330);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 23);
            this.minusButton.TabIndex = 2;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // multiplicationButton
            // 
            this.multiplicationButton.Location = new System.Drawing.Point(394, 301);
            this.multiplicationButton.Name = "multiplicationButton";
            this.multiplicationButton.Size = new System.Drawing.Size(75, 23);
            this.multiplicationButton.TabIndex = 3;
            this.multiplicationButton.Text = "*";
            this.multiplicationButton.UseVisualStyleBackColor = true;
            this.multiplicationButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // divisionButton
            // 
            this.divisionButton.Location = new System.Drawing.Point(394, 272);
            this.divisionButton.Name = "divisionButton";
            this.divisionButton.Size = new System.Drawing.Size(75, 23);
            this.divisionButton.TabIndex = 4;
            this.divisionButton.Text = "/";
            this.divisionButton.UseVisualStyleBackColor = true;
            this.divisionButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(301, 301);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(87, 23);
            this.logButton.TabIndex = 5;
            this.logButton.Text = "log(no, base)";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // powerButton
            // 
            this.powerButton.Location = new System.Drawing.Point(301, 272);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(87, 23);
            this.powerButton.TabIndex = 6;
            this.powerButton.Text = "x^y";
            this.powerButton.UseVisualStyleBackColor = true;
            this.powerButton.Click += new System.EventHandler(this.OperationButton_Clicked);
            // 
            // firstOperandBox
            // 
            this.firstOperandBox.Location = new System.Drawing.Point(58, 154);
            this.firstOperandBox.Name = "firstOperandBox";
            this.firstOperandBox.Size = new System.Drawing.Size(100, 20);
            this.firstOperandBox.TabIndex = 7;
            // 
            // secondOperandBox
            // 
            this.secondOperandBox.Location = new System.Drawing.Point(195, 154);
            this.secondOperandBox.Name = "secondOperandBox";
            this.secondOperandBox.Size = new System.Drawing.Size(100, 20);
            this.secondOperandBox.TabIndex = 8;
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(343, 154);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(100, 20);
            this.resultBox.TabIndex = 9;
            // 
            // CalcSimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 424);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.secondOperandBox);
            this.Controls.Add(this.firstOperandBox);
            this.Controls.Add(this.powerButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.divisionButton);
            this.Controls.Add(this.multiplicationButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Name = "CalcSimpleForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multiplicationButton;
        private System.Windows.Forms.Button divisionButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.TextBox firstOperandBox;
        private System.Windows.Forms.TextBox secondOperandBox;
        private System.Windows.Forms.TextBox resultBox;
    }
}

