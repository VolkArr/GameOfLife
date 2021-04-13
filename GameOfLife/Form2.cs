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
    public partial class Form2 : Form
    {
        private Graphics tempDrawMap;
        private static int pixelsize;
        private Size MapSize;
        private Cell[,] map;
        private int template;
        private int rules;
        private string gameBounds;





        public Form2(int template, int rules, Cell[,] map, int PixSize, string gameBounds, int X, int Y)
        {
            this.map = map;
            InitializeComponent();
            radioButton1.Checked = true;
            this.gameBounds = gameBounds;
            Cell.timersleep = 2000 / trackBar1.Value;
            this.template = template;
            this.rules = rules;
            pixelsize = PixSize;
            this.MapSize = new Size(X, Y);
            GameMap.Size = MapSize * pixelsize;
            this.tempDrawMap = this.GameMap.CreateGraphics();
            Cell.pixelsize = pixelsize;
            ControlPanel.Location = new Point(GameMap.Location.X + GameMap.Width + 16, GameMap.Location.Y);
            this.Size = new Size(GameMap.Width + ControlPanel.Width + 50, Math.Max(GameMap.Height + 60, ControlPanel.Location.Y + ControlPanel.Height + 48));
            this.map = map;
            for (int i = 0; i < MapSize.Width; i++)
            {
                for (int j = 0; j < MapSize.Height; j++)
                {
                    Graphics tempBMP = GameMap.CreateGraphics();
                    tempBMP.TranslateTransform(i * pixelsize, j * pixelsize);
                    this.map[i, j].cellBMP = tempBMP;
                }
            }
        }


        private void escapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

        //private bool CalcNextMapPos(bool[,] curBox)
        //{
        //    int count = 0;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (i == 1 && j == 1) continue;
        //            if (curBox[i, j] == true)
        //                count++;
        //        }
        //    }
        //    switch (curBox[1, 1])
        //    {
        //        case false:
        //            if (count == 3)
        //                return true;
        //            else
        //                return false;
        //        case true:
        //            if (count < 2 || count > 3)
        //                return false;
        //            else
        //                return true;
        //    }
        //}

        //private void DrawMap()
        //{
        //    Bitmap BMP = new(GameMap.Size.Width, GameMap.Size.Height);
        //    Graphics GBMP = Graphics.FromImage(BMP);
        //    for (int i = 0; i < MapSize.Width; i++)
        //    {
        //        for (int j = 0; j < MapSize.Height; j++)
        //        {
        //            switch (this.map[i, j])
        //            {
        //                case false:
        //                    GBMP.FillRectangle(Brushes.LightGray, i * pixelsize, j * pixelsize, pixelsize, pixelsize);
        //                    GBMP.DrawRectangle(Pens.Gray, i * pixelsize, j * pixelsize, pixelsize, pixelsize);
        //                    break;
        //                case true:
        //                    GBMP.FillRectangle(Brushes.Green, i * pixelsize, j * pixelsize, pixelsize, pixelsize);
        //                    GBMP.DrawRectangle(Pens.DarkGreen, i * pixelsize, j * pixelsize, pixelsize, pixelsize);
        //                    break;
        //            }
        //        }
        //    }
        //    GameMap.Image = BMP;
        //}

        //private void GameUpdate_Tick(object sender, EventArgs e)
        //{
        //    bool[,] tempArr = new bool[3, 3];
        //    switch (gameBounds)
        //    {
        //        case "Завертывание":
        //            for (int i = 0; i < MapSize.Width; i++)
        //            {
        //                for (int j = 0; j < MapSize.Height; j++)
        //                {
        //                    for (int k = 0; k < 3; k++)
        //                    {
        //                        for (int l = 0; l < 3; l++)
        //                        {
        //                            tempArr[k, l] = this.map[(k - 1 + i + MapSize.Width )% MapSize.Width, (j - 1 + l + MapSize.Height)% MapSize.Height];
        //                        }
        //                    }
        //                    this.nextMap[i, j] = CalcNextMapPos(tempArr);
        //                }
        //            }
        //            break;
        //        case "Виртуальные 0":
        //            for (int i = 0; i < MapSize.Width; i++)
        //            {
        //                for (int j = 0; j < MapSize.Height; j++)
        //                {
        //                    if (i == 0 && j == 0)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 0 || l == 0)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (i == MapSize.Width - 1 && j == 0)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 2 || l == 0)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (i == 0 && j == MapSize.Height - 1)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 0 || l == 2)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (i == MapSize.Width - 1 && j == MapSize.Height - 1)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 2 || l == 2)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (i == 0)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 0)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (i == MapSize.Width - 1)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (k == 2)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (j == 0)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (l == 0)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else if (j == MapSize.Height - 1)
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                if (l == 2)
        //                                {
        //                                    tempArr[k, l] = false;
        //                                }
        //                                else
        //                                {
        //                                    tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        for (int k = 0; k < 3; k++)
        //                        {
        //                            for (int l = 0; l < 3; l++)
        //                            {
        //                                tempArr[k, l] = this.map[k - 1 + i, j - 1 + l];
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            break;
        //    }
        //    DrawMap();
        //}
        private void pause_resume_button_Click(object sender, EventArgs e)
        {
            if (pause_resume_button.Text == "Возобновить") {
                for (int i = 0; i < MapSize.Width; i++)
                {
                    for (int j = 0; j < MapSize.Height; j++)
                    {
                        map[i, j].cellThread.Start();
                    }
                }
                pause_resume_button.Text = "Пауза";
            }
            else{
                for (int i = 0; i < MapSize.Width; i++)
                {
                    for (int j = 0; j < MapSize.Height; j++)
                    {
                        map[i, j].cellThread.Suspend();
                    }
                }
                pause_resume_button.Text = "Возобновить";
            }
      
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Cell.timersleep = 2000 / trackBar1.Value;
        }

        private void SavePoint_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new();
            if(file.ShowDialog() == DialogResult.OK)
            {
                saveFile(file.FileName);
            }
        }

        private void saveFile(string fileName)
        {
            //FileStream fs = new(fileName,FileMode.Create,FileAccess.Write);
            string s = MapSize.Width + " " + MapSize.Height + " "+toByte();
            File.WriteAllText(fileName, s);
            //byte[] buffer = new UTF8Encoding(true).GetBytes(s);
            //fs.Write(buffer, 0, s.Length);
            //fs.Close();
        }

        private string toByte()
        {
            int charsize = 6;
            string arrByte ="";
            for (int i = 0; i < map.Length / charsize; i++)
            {
                char tempByte = (char)0;
                for (int j = 0; j < charsize; j++)
                {
                    tempByte |= (char) ((map[(i * charsize + j) / MapSize.Height, (i * charsize + j) % MapSize.Height].cellStatus ? (char)1 : (char)0) << j);
                }
                tempByte += (char)32;
                arrByte += tempByte;
            }
            char newTempByte = (char)0;
            if (map.Length % charsize != 0)
            {
                for (int j = 0; j < map.Length % charsize; j++)
                {
                    newTempByte |= (char)((map[(map.Length / charsize * charsize + j) / MapSize.Height, (map.Length / charsize * charsize + j) % MapSize.Height].cellStatus ? (char)1 : (char)0) << j);
                }
                newTempByte += (char)32;
                arrByte += newTempByte;
            }
            return arrByte;
        }

        private void GameMap_MouseDown(object sender, MouseEventArgs e)
        {
            this.GameMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameMap_MouseMove);


        }

        private void GameMap_MouseUp(object sender, MouseEventArgs e)
        {
            this.GameMap.MouseMove -= this.GameMap_MouseMove;
        }

        private void GameMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X < 0 || e.Location.X >= GameMap.Width || e.Location.Y < 0 || e.Location.Y >= GameMap.Height) return;
            this.map[e.Location.X / pixelsize, e.Location.Y / pixelsize].cellStatus = true;
            if (radioButton1.Checked == true) DrawCells(tempDrawMap, e.Location.X / pixelsize, e.Location.Y / pixelsize);
            if (radioButton2.Checked == true) EraseCells(tempDrawMap, e.Location.X / pixelsize, e.Location.Y / pixelsize);
        }

        private void GameMap_MouseLeave(object sender, EventArgs e)
        {
            this.GameMap.MouseMove -= this.GameMap_MouseMove;
        }

        private void DrawCells(Graphics BMP,int x, int y)
        {
            BMP.FillRectangle(Brushes.Green, x * pixelsize, y * pixelsize, pixelsize, pixelsize);
            BMP.DrawRectangle(Pens.DarkGreen, x * pixelsize, y * pixelsize, pixelsize, pixelsize);
        }

        private void EraseCells(Graphics BMP, int x, int y)
        {
            BMP.FillRectangle(Brushes.LightGray, x * pixelsize, y * pixelsize, pixelsize, pixelsize);
            BMP.DrawRectangle(Pens.Gray,  x* pixelsize, y * pixelsize, pixelsize, pixelsize);
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
