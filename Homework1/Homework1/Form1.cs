using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double num1, num2,result;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {           //操作数合法性判断
            if (!double.TryParse(textBox1.Text, out num1))
                MessageBox.Show("操作数不合法！", "提示");
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out num2))
                MessageBox.Show("操作数不合法！", "提示");
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

       
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
           
                switch (comboBox1.SelectedItem.ToString())
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                        result = double.NaN;
                    else
                        result = num1 / num2;
                    break;
            }
            textBox3.Text = Convert.ToString(result);
        }

        public void My_Conbobox() 
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            My_Conbobox();
        }

    }
}

