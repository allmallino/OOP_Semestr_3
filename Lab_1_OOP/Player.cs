using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_1_OOP.Program;

namespace Lab_1_OOP
{
    public class Player : Entity
    {
        private double difcIndex;
        public override int Health
        {
            get => base.Health;
            set { health = Math.Min(value + health, 100); }
        }
        public override int Level
        {
            get => base.Level;
            set
            {
                if ((int)(this.xp + difcIndex * value) / 100 > this.Level)
                {
                    this.Damage += 10;
                }
                base.Level = (int)(difcIndex * value);
            }
        }
        public override void GetHit(Fruit fruit)
        {
            this.Health = -entity.Damage;
            if (this.Health <= 0)
                Die(fruit);
            CursorLeft = 0;
            WriteLine($"У {entity.name} залишилося {entity.Health} hp");
            ReadKey();
        }
        new public void Move(Fruit fruit)
        {
            switch (ReadKey().Key)
            {
                case ConsoleKey.A:
                    if (this.x != 0)
                    {
                        if (Map.field[this.y, this.x - 1] == 1 || Map.field[this.y, this.x - 1] == 2)//зустріне ворога
                        { entity.GetHit(fruit); return; }
                        else if (Map.field[this.y, this.x - 1] == 3)//знайде фрукт
                            fruit.ToGive(player);
                        Map.field[this.y, this.x - 1] = 5;
                        Map.field[this.y, this.x] = 0;
                        this.x--;
                        return;
                    }
                    break;
                case ConsoleKey.W:
                    if (this.y != 0)
                    {
                        if (Map.field[this.y - 1, this.x] == 1 || Map.field[this.y - 1, this.x] == 2)//зустріне ворога
                        { entity.GetHit(fruit); return; }
                        else if (Map.field[this.y - 1, this.x] == 3)//знайде фрукт
                            fruit.ToGive(player);
                        Map.field[this.y - 1, this.x] = 5;
                        Map.field[this.y, this.x] = 0;
                        this.y--;
                        return;
                    }
                    break;
                case ConsoleKey.S:
                    if (this.y != Map.yLength - 1)
                    {
                        if (Map.field[this.y + 1, this.x] == 1 || Map.field[this.y + 1, this.x] == 2)//зустріне ворога
                        { entity.GetHit(fruit); return; }
                        else if (Map.field[this.y + 1, this.x] == 3)//знайде фрукт
                            fruit.ToGive(player);
                        Map.field[this.y + 1, this.x] = 5;
                        Map.field[this.y, this.x] = 0;
                        this.y += 1;
                        return;
                    }
                    break;
                case ConsoleKey.D:
                    if (this.x != Map.xLength - 1)
                    {
                        if (Map.field[this.y, this.x + 1] == 1 || Map.field[this.y, this.x + 1] == 2)//зустріне ворога
                        { entity.GetHit(fruit); return; }
                        else if (Map.field[this.y, this.x + 1] == 3)//знайде фрукт
                            fruit.ToGive(player);
                        Map.field[this.y, this.x + 1] = 5;
                        Map.field[this.y, this.x] = 0;
                        this.x += 1;
                        return;
                    }
                    break;
            }
            CursorLeft--;
            Write(" ");
            CursorLeft--;
            this.Move(fruit);
        }
        private void Die(Fruit fruit)
        {
            CursorLeft = 0;
            Write($"Ви програли. Натисність будь-яку кнопку щоб вийти");
            ReadKey();
            Clear();
            WriteLine($"Усього набрано: {player.xp} балів\n\n" +
                      $"Console log:\n" +
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
        public static Player CreateNewPlayer()
        {
            while (true)
            {
                Clear();
                WriteLine("Оберіть складність:\n" +
                          "1.Легка складність (Модифікаток балів - 0.5);\n" +
                          "2.Середня складність (Модифікаток балів - 1);\n" +
                          "3.Складна складність (Модифікаток балів - 1.5).\n");
                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        return new Player(0.5);
                    case ConsoleKey.D2:
                        return new Player(1);
                    case ConsoleKey.D3:
                        return new Player(1.5);
                }
            }
        }
        private Player(double ind)
        {
            Map.field[this.y, this.x] = 5;
            this.Level = 0;
            this.Damage = (int)(40 * (2 - ind));
            this.Health = 100;
            this.difcIndex = ind;
        }
    }
}
