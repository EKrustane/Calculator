using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void InitializeCalculator()
        {
            this.BackColor = Color.PeachPuff;
            string buttonName = null;
            Button button = null;
            Display.Text = "0";
            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
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

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {

        }
    }

}