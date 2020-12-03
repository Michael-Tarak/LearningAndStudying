using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bomber.Controllers
{
    static class MapController
    {
        public const int BombsCount = 30;
        public const int MapWidth = 20;
        public const int MapHeight = 10;
        public const int CellSize = 32;
        public static int[,] Map = new int[MapHeight, MapWidth];
        public static Button[,] Buttons = new Button[MapHeight, MapWidth];
        public static bool IsFirstStep;
        private static int currentPictureToSet;
        private static Point firstCoord;
        public static void Init(Form form)
        {
            currentPictureToSet = 0;
            IsFirstStep = true;
            InitMap(form);
            InitButtons(form);
        }
        private static void InitMap(Form form)
        {
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }
        private static void InitButtons(Form form)
        {
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    var button = new Button();
                    button.Location = new Point(j * CellSize, i * CellSize);
                    button.Size = new Size(CellSize, CellSize);
                    button.Image = ButtonStatusImage.Empty;
                    button.MouseUp += new MouseEventHandler(OnMouseButtonPressed);
                    form.Controls.Add(button);
                    Buttons[i, j] = button;
                }
            }
        }

        private static void OnMouseButtonPressed(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    OnLeftButtonPressed(pressedButton);
                    break;
                case MouseButtons.Right:
                    OnRightButtonPressed(pressedButton);
                    break;
                default:
                    break;
            }
        }

        private static void OnRightButtonPressed(Button pressedButton)
        {
            currentPictureToSet++;
            currentPictureToSet %= 3; 
            switch (currentPictureToSet)
            {
                case 0:
                    pressedButton.Image = ButtonStatusImage.Empty;
                    break;
                case 1:
                    pressedButton.Image = ButtonStatusImage.Flag;
                    break;
                case 2:
                    pressedButton.Image = ButtonStatusImage.QuestionMark;
                    break;
                default:
                    break;
            }
        }

        private static void OnLeftButtonPressed(Button pressedButton)
        {
            pressedButton.Enabled = false;
            int jButton = pressedButton.Location.X / CellSize;
            int iButton = pressedButton.Location.Y / CellSize;
            if (IsFirstStep)
            {
                firstCoord = new Point(jButton, iButton);
                SeedMap();
                BombFinder();
                IsFirstStep = false;
            }
            OpenCells(iButton,jButton);
            if (Map[iButton,jButton] == -1)
            {
                for (int i = 0; i < MapHeight; i++)
                {
                    for (int j = 0; j < MapWidth; j++)
                    {
                        if (Map[i,j] == -1)
                        {
                            OpenCell(i, j);
                        }
                    }
                }
                MessageBox.Show("Поражение");
            }
        }

        private static void ConfigureMapSize(Form form)
        {
            form.Width = MapWidth * CellSize + 20;
            form.Height = MapHeight * CellSize;
        }
        private static void SeedMap()
        {
            var random = new Random();
            for (int i = 0; i < BombsCount; i++)
            {
                int posI = random.Next(0, MapHeight - 1);
                int posJ = random.Next(0, MapWidth - 1);
                while (Map[posI, posJ] == -1 || !Buttons[posI,posJ].Enabled)
                {
                    posI = random.Next(0, MapHeight - 1);
                    posJ = random.Next(0, MapWidth - 1);

                }
                Map[posI, posJ] = -1;
            }
            
        }
        private static void BombFinder()
        {
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    if (Map[i,j] == -1)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || Map[k, l] == -1)
                                {
                                    continue;
                                }
                                Map[k, l]++;
                            }
                        }
                    }
                }
            }
        }
        private static bool IsInBorder(int i,int j)
        {
            if (i < 0 || j < 0 || j > MapWidth - 1 || i > MapHeight - 1)
            {
                return false;
            }
            return true;
        }
        private static void OpenCell(int i, int j)
        {
            Buttons[i, j].Enabled = false;
            switch (Map[i,j])
            {
                case -1:
                    Buttons[i, j].Image = ButtonStatusImage.Bomb;
                    break;
                case 0:
                    Buttons[i, j].Image = ButtonStatusImage.Empty;
                    break;
                case 1:
                    Buttons[i, j].Image = ButtonStatusImage.One;
                    break;
                case 2:
                    Buttons[i, j].Image = ButtonStatusImage.Two;
                    break;
                case 3:
                    Buttons[i, j].Image = ButtonStatusImage.Three;
                    break;
                case 4:
                    Buttons[i, j].Image = ButtonStatusImage.Four;
                    break;
                case 5:
                    Buttons[i, j].Image = ButtonStatusImage.Five;
                    break;
                case 6:
                    Buttons[i, j].Image = ButtonStatusImage.Six;
                    break;
                case 7:
                    Buttons[i, j].Image = ButtonStatusImage.Seven;
                    break;
                case 8:
                    Buttons[i, j].Image = ButtonStatusImage.Eight;
                    break;

                default:
                    break;
            }
        }
        private static void OpenCells(int i, int j)
        {
            OpenCell(i, j);
            if (Map[i,j] > 0)
            {
                return;
            }
            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k,l) || !Buttons[k, l].Enabled)
                    {
                        continue;
                    }
                    if (Map[k,l] == 0)
                    {
                        OpenCells(k, l);
                    }
                    else
                    {
                        if (Map[k,l] > 0)
                        {
                            OpenCell(k, l);
                        }
                    }
                }
            }
        }
    }
}