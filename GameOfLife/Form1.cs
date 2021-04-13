using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameOfLife
{
    public  partial class Form1 : Form
    {
        bool[,] map;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            textBox1.Text = "80";
            textBox2.Text = "80";
            textBox3.Text = "10";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void InitMap()
        {
            this.map = new bool[toInt(textBox1), toInt(textBox2)];
            for (int i = 0; i < toInt(textBox1); i++)
            {
                for (int j = 0; j < toInt(textBox2); j++)
                {
                    this.map[i, j] = false;
                }
            }
            Random rand = new Random();
            for (int i = 0; i < toInt(textBox1); i++)
            {
                for (int j = 0; j < toInt(textBox2); j++)
                {
                    switch (this.comboBox1.SelectedIndex)
                    {
                        case 0: // Пустой шаблон
                            this.map[i, j] = false;
                            break;
                        case 1: // Рандомный
                            int val = rand.Next(0, 2);
                            switch (val)
                            {
                                case 0:
                                    this.map[i, j] = false;
                                    break;
                                case 1:
                                    this.map[i, j] = true;
                                    break;
                            }
                            break;
                    }
                }
            }
            if(this.comboBox1.SelectedIndex == 2)
            {
                string filename = "";
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    string s = File.ReadAllText(ofd.FileName);
                    int si = 0;
                    int width = 0;
                    int height = 0;
                    for (; char.IsNumber(s[si]); si++)
                    {
                        width = width * 10 + s[si] - '0';
                    }
                    si++;
                    for (; char.IsNumber(s[si]); si++)
                    {
                        height = height * 10 + s[si] - '0';
                    }
                    map = tomap(width, height, s.Substring(++si));
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            string gameBounds = "";
            if (radioButton1.Checked == true) gameBounds = "Завертывание";
            if (radioButton2.Checked == true) gameBounds = "Виртуальные 0";
            this.Hide();
            this.InitMap();
            new Form2(comboBox1.SelectedIndex, comboBox2.SelectedIndex, this.map, toInt(textBox3), gameBounds, toInt(textBox1), toInt(textBox2)).ShowDialog();
            this.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool[,] tomap(int width,int height,string s)
        {
            bool[,] map=new bool[width,height];
            int k = -1;
            int si = 0;
            char c = (char)(s[si]-32);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (++k == 6)
                    {
                        k = 0;
                        c = s[++si];
                        c -= (char)32;
                    }
                    map[i, j] = (c & 1) == 1;
                    c >>= 1;
                }
            }
            return map;
        }

        public int toInt(TextBox textBox)
        {
            return int.Parse(textBox.Text);
        }



        private void radioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked == true) radioButton2.Checked = false;
            else radioButton2.Checked = true;
        }

        private void radioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true) radioButton1.Checked = false;
            else radioButton1.Checked = true;
        }


    }
}
