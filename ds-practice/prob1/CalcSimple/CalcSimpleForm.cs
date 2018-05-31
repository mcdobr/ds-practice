using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcSimple
{
    public partial class CalcSimpleForm : Form
    {
        public CalcSimpleForm()
        {
            InitializeComponent();
        }

        /*
         * Toate butoanele diferite de = apeleaza asta
         * Se pun numerele inainte de a selecta operatia
         */
        private void OperationButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            double fstOperand, sndOperand;

            bool fstSuccess = Double.TryParse(firstOperandBox.Text, out fstOperand);
            bool sndSuccess = Double.TryParse(secondOperandBox.Text, out sndOperand);

            bool operationFailed = !fstSuccess || !sndSuccess;
            if (operationFailed)
            {
                MessageBox.Show("Inputs were not valid numbers");
                return;
            }

            switch (btn.Text)
            {
                case "+":
                    resultBox.Text = (fstOperand + sndOperand).ToString();
                    break;
                case "-":
                    resultBox.Text = (fstOperand - sndOperand).ToString();
                    break;
                case "*":
                    resultBox.Text = (fstOperand * sndOperand).ToString();
                    break;
                case "/":
                    resultBox.Text = (fstOperand / sndOperand).ToString();
                    break;
                case "log(no, base)":
                    resultBox.Text = Math.Log(fstOperand, sndOperand).ToString();
                    break;
                case "x^y":
                    resultBox.Text = Math.Pow(fstOperand, sndOperand).ToString();
                    break;
            }
        }
    }
}
