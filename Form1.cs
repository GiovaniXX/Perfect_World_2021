using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_World_2021
{
    public partial class Form1_pwe_2021 : Form
    {
        public Form1_pwe_2021()
        {
            InitializeComponent();
        }

        private void button4_armor_add_Click(object sender, EventArgs e)
        {
            string item = comboBox2_armor_bonus_list.Text;
            string v = textBox2_armor_bonus_list_bonus.Text;
            string original = textBox1_armor_bonus_list.Text;
            textBox1_armor_bonus_list.Text = original + item + v + Environment.NewLine;
        }

        private void button3_armor_dell_Click(object sender, EventArgs e)
        {
            textBox1_armor_bonus_list.Clear();
        }

        private void button2_armor_down_Click(object sender, EventArgs e)
        {

        }

        private void button1_armor_up_Click(object sender, EventArgs e)
        {

        }
    }
}
