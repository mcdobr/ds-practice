using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcPolish
{
    public partial class CalcPolish : Form
    {
        /**
         * Nu am implementat numere negative si paranteze (nu stiu din cerinta daca se cer?) 
         */
        private static Dictionary<char, int> operatorPriority;

        public CalcPolish()
        {
            InitializeComponent();

            operatorPriority = new Dictionary<char, int>();
            operatorPriority.Add('*', 2);
            operatorPriority.Add('/', 2);
            operatorPriority.Add('+', 1);
            operatorPriority.Add('-', 1);
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            string expr = expresssionBox.Text;
            resultBox.Clear();

            string postfixExpr = InfixToPostfix(expr);
            int result = EvalPostfixExpr(postfixExpr);
            resultBox.Text = result.ToString();
        }

        private static string InfixToPostfix(string expr)
        {
            Stack<char> opStack = new Stack<char>();

            StringBuilder sb = new StringBuilder();

            int idx = 0;
            while (idx < expr.Length)
            {
                if (Char.IsDigit(expr.ElementAt(idx)))
                {
                    while (idx < expr.Length && Char.IsDigit(expr.ElementAt(idx)))
                    {
                        sb.Append(expr.ElementAt(idx));
                        ++idx;
                    }
                    sb.Append(' ');
                }
                else if (IsOperator(expr.ElementAt(idx)))
                {
                    char op = expr.ElementAt(idx);
                    if (opStack.Count == 0)
                        opStack.Push(op);
                    else
                    {
                        if (operatorPriority[op] <= operatorPriority[opStack.Peek()])
                        {
                            sb.Append(opStack.Pop());
                            opStack.Push(op);
                        }
                        else
                        {
                            opStack.Push(op);
                        }
                    }
                    ++idx;
                }
            }

            while (opStack.Count > 0)
                sb.Append(opStack.Pop());

            return sb.ToString();
        }

        private static int EvalPostfixExpr(string postfixExpr)
        {
            Stack<int> operandStack = new Stack<int>();
            int idx = 0;
            while (idx < postfixExpr.Length)
            {
                if (Char.IsDigit(postfixExpr.ElementAt(idx)))
                {
                    int operand = 0;
                    while (idx < postfixExpr.Length && Char.IsDigit(postfixExpr.ElementAt(idx)))
                    {
                        char digit = postfixExpr.ElementAt(idx);
                        operand = operand * 10 + (digit - '0');
                        ++idx;
                    }
                    operandStack.Push(operand);
                }
                else if (IsOperator(postfixExpr.ElementAt(idx)))
                {
                    char op = postfixExpr.ElementAt(idx);
                    int snd = operandStack.Pop();
                    int fst = operandStack.Pop();

                    switch (op)
                    {
                        case '+':
                            operandStack.Push(fst + snd);
                            break;
                        case '-':
                            operandStack.Push(fst - snd);
                            break;
                        case '*':
                            operandStack.Push(fst * snd);
                            break;
                        case '/':
                            operandStack.Push(fst / snd);
                            break;
                    }
                    ++idx;
                }
                else if (Char.IsWhiteSpace(postfixExpr.ElementAt(idx)))
                    ++idx;
            }

            return operandStack.Pop();
        }

        private static bool IsOperator(char c)
        {
            string arr = "*/+-";
            return arr.Contains(c);
        }
    }
}
