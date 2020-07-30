using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anam_Pharma
{
    public partial class Calculator : Form
    {
        Double answerValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }
        
        private void equalsBtn_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    answer_txt.Text = (answerValue + Double.Parse(answer_txt.Text)).ToString();
                    break;
                case "-":
                    answer_txt.Text = (answerValue - Double.Parse(answer_txt.Text)).ToString();
                    break;
                case "*":
                    answer_txt.Text = (answerValue * Double.Parse(answer_txt.Text)).ToString();
                    break;
                case "/":
                    answer_txt.Text = (answerValue / Double.Parse(answer_txt.Text)).ToString();
                    break;
                default:
                    break;
            }
            answerValue = Double.Parse(answer_txt.Text);
            currentOP_lbl.Text = "";

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((answer_txt.Text == "0") || (isOperationPerformed))
            {
                answer_txt.Clear();
            }

            isOperationPerformed = false;

            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!answer_txt.Text.Contains("."))
                {
                    answer_txt.Text = answer_txt.Text + button.Text;
                }
            }
            else
            {
                answer_txt.Text = answer_txt.Text + button.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (answerValue != 0)
            {
                equalsBtn.PerformClick();

                operationPerformed = button.Text;
                currentOP_lbl.Text = answerValue + " " + operationPerformed;

                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                answerValue = Double.Parse(answer_txt.Text);

                currentOP_lbl.Text = answerValue + " " + operationPerformed;

                isOperationPerformed = true;
            }
        }

        private void eclearBtn_Click(object sender, EventArgs e)
        {
            answer_txt.Text = "0";
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            answer_txt.Text = "0";
            answerValue = 0;
        }

    }
}
