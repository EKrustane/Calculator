﻿using System;
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
            Display.Text += button.Text;
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

        }
    }

}