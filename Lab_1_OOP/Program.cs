using System;
using static System.Math;
using static System.Console;

namespace Lab_1_OOP 
{ 
    internal class Program
    {
        public static Entity entity;
        public static Player player;
        public static int fruitIndex = 0;
        public static string[] consoleLog = new string[6];
        public static void CreatingCreatures()
        {
            Random rnd = new Random();
            if (rnd.NextDouble() >= 0.7)
                entity= Bandit.CreateBandit();
            else
                entity = Monster.CreateMonster();
        }
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.Unicode;
            player = Player.CreateNewPlayer();
            
            Fruit fruit = new Fruit();
            CreatingCreatures();
            while (true)
            {
                Clear();
                
                Write("M - монстр (атакує гравця), ");
                BackgroundColor = ConsoleColor.DarkGray;
                ForegroundColor = ConsoleColor.Black;
                Write("B");
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                Write(" - бандит (атакує гравця і краде фрукти), ");
                BackgroundColor = ConsoleColor.Yellow;
                ForegroundColor = ConsoleColor.Black;
                Write("F");
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                Write(" - фрукт (лікує), ");
                BackgroundColor = ConsoleColor.DarkRed;
                Write("P");
                BackgroundColor = ConsoleColor.Black;
                Write(" - гравець.\n\nКерування на WASD:");
                CursorLeft = 35;
                Write("HP");
                CursorLeft = 70;
                WriteLine($"Бали: {player.xp}");
                for(int i=10;i>0;i--)
                {
                    CursorLeft = 35;
                    if (player.Health / 10 - i >= 0)
                        BackgroundColor = ConsoleColor.Red;
                    if (i == 5 && player.Health != 100)
                        Write(player.Health);
                    else
                        Write("  ");
                    BackgroundColor = ConsoleColor.Black;
                    WriteLine();
                }
                CursorTop = 3;
                Map.Show();
                CursorTop = 4;
                CursorLeft = 70;
                WriteLine("Console log:");
                for (int j = 0; j < consoleLog.Length; j++)
                {
                    CursorLeft = 70;
                    if (consoleLog[j] == null)
                        break;
                    WriteLine(consoleLog[j]);
                }
                CursorLeft = 70;
                WriteLine($"Зараз зайнято пам'яті: {GC.GetTotalMemory(false) / 1024} кб");
                CursorLeft = 70;
                WriteLine($"fruitIndex {fruitIndex}/5");
                CursorTop = 13;
                player.Move(fruit);
                entity.Move(fruit);
            }
        }
    }
}