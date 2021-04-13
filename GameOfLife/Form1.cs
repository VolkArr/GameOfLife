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
using System.Threading;


namespace GameOfLife
{

    public partial class Form1 : Form
    {
        Cell[,] map;
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

        public void BoolToCells(bool[,] map)
        {

        }

       

        private void InitMap()
        {

            this.map = new Cell[toInt(textBox1), toInt(textBox2)];
            for (int i = 0; i < toInt(textBox1); i++)
            {
                for (int j = 0; j < toInt(textBox2); j++)
                {
                    this.map[i,j] = new Cell();
                }
            }
            for (int i = 0; i < toInt(textBox1); i++)
            {
                for (int j = 0; j < toInt(textBox2); j++)
                {
                    Cell[] cells = new Cell[8];
                    for(int c = 0; c < 9; c++)
                    {
                        Int32 k = c;
                        if (c > 4) k--;
                        if (c == 4 ) continue;
                        cells[k] = this.map[(i + c / 3 - 1 + toInt(textBox1))% toInt(textBox1), (j + c % 3 - 1 + toInt(textBox2)) % toInt(textBox2)] ;
                    }
                    this.map[i, j].cells = cells;
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
                            this.map[i, j].cellStatus = false;
                            break;
                        case 1: // Рандомный
                            int val = rand.Next(0, 2);
                            switch (val)
                            {
                                case 0:
                                    this.map[i, j].cellStatus = false;
                                    break;
                                case 1:
                                    this.map[i, j].cellStatus = true;
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
                    
                    BoolToCells(tomap(width, height, s.Substring(++si)));
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
    public class Cell
    {
        static public int timersleep;
        public static int pixelsize;
        private static Size cellsize = new Size(pixelsize, pixelsize);
        public Graphics cellBMP;
        public bool cellStatus = false;
        public Cell[] cells { private get; set; }
        public Thread cellThread;


        public Cell()
        {
            cellThread = new Thread(Life);
        }

        private void Life()
        {
            while (true)
            {
                UpdaateCell();
                DrawCellsOnMap();
                Thread.Sleep(timersleep);
            }

        }

        public void UpdaateCell()
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (cells[i].cellStatus == true)
                {
                    count++;
                }
            }
            switch (this.cellStatus)
            {
                case false:
                    if (count == 3)
                        this.cellStatus = true;
                    else
                        this.cellStatus = false;
                    break;
                case true:
                    if (count < 2 || count > 3)
                        this.cellStatus = false;
                    else
                        this.cellStatus = true;
                    break;
            }

        }

        public void DrawCellsOnMap()
        {
            Rectangle ProizvolniyVzmahRukoy = new Rectangle(0, 0, pixelsize, pixelsize);
            switch (cellStatus)
            {
                case false:
                    this.cellBMP.FillRectangle(Brushes.LightGray, ProizvolniyVzmahRukoy);
                    this.cellBMP.DrawRectangle(Pens.Gray, ProizvolniyVzmahRukoy);
                    break;
                case true:
                    this.cellBMP.FillRectangle(Brushes.Green, ProizvolniyVzmahRukoy);
                    this.cellBMP.DrawRectangle(Pens.DarkGreen, ProizvolniyVzmahRukoy);
                    break;
            }
        }


    }
}
