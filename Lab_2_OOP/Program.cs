using System;
using static System.Math;
using static System.Console;
using System.Transactions;

namespace Lab_2_OOP
{
    internal class Program
    {
        public static Entity entity;
        public static Player player;
        public delegate void Move(Fruit fruit);
        public static event Move movement;
        public static void CreatingCreatures(EatingHandle handle, Fruit fruit)
        {
            Random rnd = new Random();
            if (rnd.NextDouble() >= 0.7)
                entity = Bandit.CreateBandit();
            else
                entity = Monster.CreateMonster();
            movement = null;
            movement += player.Move;
            movement += entity.Move;
            entity.EntityEatingHandle += handle;
            //entity.EntityEatingHandle += delegate (Entity entity, FruitEventArgs args)
            //{
            //    if (args.state)
            //    {
            //        entity.Level = Fruit.xpGive;
            //        entity.Health = Fruit.healthGive;
            //        ConsoleLog.ToAdd($"{entity.name} з'їв фрукт");
            //    }
            //    else
            //        entity.Health = Fruit.healthGive / 10;
            //    int x, y;
            //    Random rnd = new Random();
            //    do
            //    {
            //        x = rnd.Next(Map.xLength);
            //        y = rnd.Next(Map.yLength);
            //    }
            //    while (Map.field[y, x] != 0);
            //    Map.field[fruit.y, fruit.x] = 0;
            //    fruit.y = y;
            //    fruit.x = x;
            //    Map.field[y, x] = 3;
            //};
            //entity.EntityEatingHandle += (Entity entity, FruitEventArgs args) =>
            //{
            //    if (args.state)
            //    {
            //        entity.Level = Fruit.xpGive;
            //        entity.Health = Fruit.healthGive;
            //        ConsoleLog.ToAdd($"{entity.name} з'їв фрукт");
            //    }
            //    else
            //        entity.Health = Fruit.healthGive / 10;
            //    int x, y;
            //    Random rnd = new Random();
            //    do
            //    {
            //        x = rnd.Next(Map.xLength);
            //        y = rnd.Next(Map.yLength);
            //    }
            //    while (Map.field[y, x] != 0);
            //    Map.field[fruit.y, fruit.x] = 0;
            //    fruit.y = y;
            //    fruit.x = x;
            //    Map.field[y, x] = 3;
            //};
            entity.AddFruit(fruit);
        }
        public static void InvokeEvent(Fruit fruit)
        {
            if (movement != null)
                movement(fruit);
        }
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.Unicode;
            player = Player.CreateNewPlayer();
            Fruit fruit = new Fruit();
            player.AddFruit(fruit);
            player.EntityEatingHandle += fruit.ToGive;
            CreatingCreatures(new EatingHandle(fruit.ToGive), fruit);
            while (true)
            {
                #region Interface
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
                for (int i = 10; i > 0; i--)
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
                
                ConsoleLog.Show();
                CursorLeft = 70;
                WriteLine($"Зараз зайнято пам'яті: {GC.GetTotalMemory(false) / 1024} кб");
                CursorTop = 13;
                #endregion
                try
                {
                    InvokeEvent(fruit);
                }
                catch (PlayerWrongKeyException exception)
                {
                    CursorTop = 13;
                    CursorLeft = 0;
                    WriteLine(exception.args);
                    WriteLine("Натисність будь-яку клавішу, щоб продовжити гру...");
                    ReadKey();
                }
                catch(Exception exc)
                {
                    CursorLeft = 0;
                    Write($"Сталася помилка. Натисніть будь-яку клавішу, щоб вийти");
                    ReadKey();
                    Clear();
                    WriteLine($"Усього набрано: {player.xp} балів\n\n");
                    WriteLine($"Console log:\n" +
                              $"Помилка:{exc.ToString()};\n" +
                              $"Зараз зайнято пам'яті: {GC.GetTotalMemory(false) / 1024} кб;\n" +
                              $"Генерація ігрока: {GC.GetGeneration(player)};\n" +
                              $"Генерація сутності: {GC.GetGeneration(entity)};\n" +
                              $"Генерація фрукту: {GC.GetGeneration(fruit)};\n" +
                              $"Всього проведено {GC.CollectionCount(0)} очисток на 0 генераці;\n" +
                              $"Всього проведено {GC.CollectionCount(1)} очисток на 1 генераці;\n" +
                              $"Всього проведено {GC.CollectionCount(2)} очисток на 2 генераці.");
                    ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}