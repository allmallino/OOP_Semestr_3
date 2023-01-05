using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_OOP
{
    static class Map
    {
        public static int[,] field;
        public static int xLength;
        public static int yLength;

        static Map()
        {
            yLength = xLength = 10;
            field = new int[yLength, xLength];
        }
        public static void Show()
        {
            for (int i = 0; i < yLength; i++)
            {
                BackgroundColor = ConsoleColor.DarkGreen;
                for (int j = 0; j < xLength; j++)
                {
                    if (field[i, j] == 0)//порожнє поле
                    {
                        Write(" ");
                    }
                    else if (field[i, j] == 1)//монстр
                    {
                        BackgroundColor = ConsoleColor.Black;
                        Write("M");
                        BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (field[i, j] == 2)//бандит
                    {
                        BackgroundColor = ConsoleColor.DarkGray;
                        ForegroundColor = ConsoleColor.Black;
                        Write("B");
                        BackgroundColor = ConsoleColor.DarkGreen;
                        ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[i, j] == 3)//фрукт
                    {
                        BackgroundColor = ConsoleColor.Yellow;
                        ForegroundColor = ConsoleColor.Black;
                        Write("F");
                        BackgroundColor = ConsoleColor.DarkGreen;
                        ForegroundColor = ConsoleColor.White;
                    }
                    else//гравець
                    {
                        BackgroundColor = ConsoleColor.DarkRed;
                        Write("P");
                        BackgroundColor = ConsoleColor.DarkGreen;
                    }
                }
                BackgroundColor = ConsoleColor.Black;
                WriteLine(" ");
            }
        }
    }
}
