using lab4_2;
using System;
using System.Collections.Generic;
using static System.Console;

namespace MyApp
{
    internal class Program
    {
        public static List<Enemy> enemyList = new List<Enemy>();
        public static string consoleList;
        public static int ind;
        static void toColor(string text)
        {
            foreach(char c in text)
            {
                switch (c)
                {
                    case '▒':
                        BackgroundColor = ConsoleColor.Red;
                        break;
                    case '▓':
                        BackgroundColor = ConsoleColor.DarkRed;
                        break;
                    default:
                        BackgroundColor = ConsoleColor.Black;
                        break;
                }
                Write(c);
            }
        }
        static void Main(string[] args)
        {
            ind =0;
            Random rand = new Random();
            enemyList.Add(new Slime("red", rand.Next(1, 11), 100, 100));
            while (true)
            {
                Clear();
                CursorTop = 0;
                WriteLine("Choose an enemy to damage:\n\n\n\n");
                CursorLeft = 6 + 15 * ind;
                WriteLine(@"\/");
                for (int i = 0; i < enemyList.Count; i++)
                {
                    CursorLeft = i * 15;
                    CursorTop = 6;
                    toColor("░░░░██████░░░░");
                    CursorLeft = i * 15;
                    CursorTop = 7;
                    toColor("░░██▒▒▒▒▒▒██░░");
                    CursorLeft = i * 15;
                    CursorTop = 8;
                    toColor("██▒▒▒▒▒▒▓▒▓▒██");
                    CursorLeft = i * 15;
                    CursorTop = 9;
                    toColor("██▒▒▒▒▒▒▒▒▒▒██");
                    CursorLeft = i * 15;
                    CursorTop = 10;
                    toColor("░░██████████░░");
                }
                CursorLeft = 0;
                CursorTop = 14;
                WriteLine("Console log:" + consoleList);
                CursorTop = 11;
                CursorLeft = 0;
                Write("You choose: "+ enemyList[ind].toString());
                switch (ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        ind =(ind + 1)% enemyList.Count;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (ind == 0)
                        {
                            ind = enemyList.Count-1;
                        }
                        else
                        {
                            ind--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        enemyList[ind].TakeDamage(10);
                        break;
                }
                if (enemyList.Count == 0) break;
            }
            Clear();
            WriteLine("You've killed all monsters. Press any button to close the aplication...");
            ReadKey();
        }
    }
}