using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double numOne = 0;
        double numTwo = 0;
        int lenghtOfNumOne = 0;
        string expression;
        string operation;
        string secondOperation;
        bool operationInserted = false;
        bool scifiMode = false;
        const int widthSmall = 285;
        const int widthLarge = 360;
        int sliderValue = 0;
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.LightGray;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            string buttonName = null;
            Button button = null;
            Display.Text = "0";
            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.Font = new Font("Consolas", 22f);
                buttonDecimal.Text = ".";
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }


            

            private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0.";
                }
                else
                {
                    Display.Text += ".";
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            {
                string s = Display.Text;
                if (s.Length > 0)
                {
                    s = s.Substring(0, s.Length - 1);
                }
                else
                {
                    s = "0";
                }
                Display.Text = s;

            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1; //number = number * (-1)
                Display.Text = Convert.ToString(number);
            }
            catch
            {

            }
        }

         private void buttonResult_Click(object sender, EventArgs e)
        {
            expression = Display.Text.Substring(lenghtOfNumOne + 1, Display.Text.Length - lenghtOfNumOne - 1);
            numTwo = Convert.ToDouble(expression);
            if (operation=="+")
            {
                numOne = numOne + numTwo;
            }
            else if (operation=="-")
            {
                numOne = numOne - numTwo;
            }
            else if (operation=="x")
            {
                numOne = numOne * numTwo;
            }
            else if (operation=="/")
            {
                numOne = numOne / numTwo;
            }
            else if (operation=="^")
            {
                numOne = Math.Pow(numOne, numTwo);
            }

            Display.Text = numOne.ToString();
            operationInserted = false;
        }
        private void Operation_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            if (!operationInserted)
            {
                lenghtOfNumOne = Display.Text.Length;
                numOne = Convert.ToDouble(Display.Text);
                operation = ((Button)sender).Text;
                Display.Text += operation;
                operationInserted = true;
            }
           else
            {
                secondOperation = ((Button)sender).Text;
                expression = Display.Text.Substring(lenghtOfNumOne + 1, Display.Text.Length - lenghtOfNumOne - 1);
                numTwo = Convert.ToDouble(expression);

                if (operation == "+")
                {
                    numOne = numOne + numTwo;
                }
                else if (operation == "-")
                {
                    numOne = numOne - numTwo;
                }
                else if (operation == "x")
                {
                    numOne = numOne * numTwo;
                }
                else if (operation == "/")
                {
                    numOne = numOne / numTwo;
                }
                else if (operation =="^")
                {
                    numOne = Math.Pow(numOne, numTwo);
                }


                Display.Text = numOne.ToString();
                lenghtOfNumOne = Display.Text.Length;
                Display.Text += secondOperation;
                operation = secondOperation;
            }
           if (button.Text == "√")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }
           if (button.Text == "%")
            {
                numTwo = 0.01;
                Display.Text = (numOne * numTwo).ToString();
                return;
            }
            if (button.Text == "sin")
            {
                Display.Text = Math.Sin(numOne).ToString();
                return;
            }
            if (button.Text == "cos")
            {
                Display.Text = Math.Cos(numOne).ToString();
                return;
            }
            if (button.Text == "tg")
            {
                Display.Text = Math.Tan(numOne).ToString();
                return;
            }



        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            operationInserted = false;
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if(scifiMode)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sliderValue = trackBar1.Value;
            string labelName = null;
            string buttonName = null;
            for (int i = 0; i < 10; i++)
            {
                for (int j=1;j<=2;j++)
                {
                    labelName = "label" + j;
                    buttonName = "button" + i;
                    if (trackBar1.Value == trackBar1.Maximum)
                    {
                        this.Controls[labelName].ForeColor = Color.White;
                        this.BackColor = Color.Black;
                        this.Controls[buttonName].BackColor = Color.Black;
                        this.Controls[buttonName].ForeColor = Color.White;
                    }
                    else if (trackBar1.Value == trackBar1.Minimum)
                    {
                        this.Controls[labelName].ForeColor = Color.Black;
                        this.BackColor = Color.LightGray;
                        this.Controls[buttonName].BackColor = Color.White;
                        this.Controls[buttonName].ForeColor = Color.Black;
                    }
                }
                


            }

        
      

        }
        
    }


}