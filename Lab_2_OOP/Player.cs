using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_2_OOP.Program;
using System.Diagnostics;

namespace Lab_2_OOP
{
    public sealed class Player : Entity
    {
        public double difcIndex;
        public override int Health
        {
            get => health;
            set { health = Math.Min(value + health, 100); }
        }
        public override int Level
        {
            get => xp / 100;
            set
            {
                if ((int)(this.xp + difcIndex * value) / 100 > this.Level)
                {
                    this.Damage += 10;
                    if ((int)(this.xp + difcIndex * value) / 100 > entity.Level)
                        entity.Scream();
                }
                xp += (int)(difcIndex * value);
                
            }
        }
        private void Die(Fruit fruit)
        {
            CursorLeft = 0;
            Write($"Ви програли. Натисність будь-яку кнопку, щоб вийти");
            ReadKey();
            Clear();
            WriteLine($"{entity.name} вбив гравця з {this.Level} лвл. Усього набрано: {this.xp} балів\n\n");
            WriteLine($"Console log:\n" +
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
        public void GetHit(Fruit fruit)
        {
            this.Health = -entity.Damage;
            if (this.Health <= 0)
                Die(fruit);
            CursorLeft = 0;
            WriteLine($"У {entity.name} залишилося {entity.Health} hp");
            ReadKey();
        }
        private void toMoveLeft(int side, Fruit fruit)
        {
            if (Map.field[y, x - side] == 1 || Map.field[y, x - side] == 2)//зустріне ворога
            { ((IEntity)entity).GetHit(fruit); return; }
            else if (Map.field[y, x - side] == 3)//знайде фрукт
                Eating();
            Map.field[y, x - side] = 5;
            Map.field[y, x] = 0;
            x-=side;
        }
        private void toMoveUp(int side, Fruit fruit)
        {
            if (Map.field[y - side, x] == 1 || Map.field[y - side, x] == 2)//зустріне ворога
            { ((IEntity)entity).GetHit(fruit); return; }
            else if (Map.field[y - side, x] == 3)//знайде фрукт
                Eating();
            Map.field[y - side, x] = 5;
            Map.field[y, x] = 0;
            y -= side;
        }
        private int[] MovingLeft(int side, Fruit fruit)
        {
            if (Map.field[y, x - side] == 1 || Map.field[y, x - side] == 2)//зустріне ворога
            { ((IEntity)entity).GetHit(fruit); return new int[] {y,x}; }
            else if (Map.field[y, x - side] == 3)//знайде фрукт
                Eating();
            Map.field[y, x] = 0;
            return new int[] { y, x - side };
        }
        private int[] MovingUp(int side, Fruit fruit)
        {
            if (Map.field[y - side, x] == 1 || Map.field[y - side, x] == 2)//зустріне ворога
            { ((IEntity)entity).GetHit(fruit); return new int[] { y, x }; }
            else if (Map.field[y - side, x] == 3)//знайде фрукт
                Eating();
            Map.field[y, x] = 0;
            return new int[] { y - side, x };
        }
        public override void Move(Fruit fruit)
        {
            ConsoleKey key = ReadKey().Key;
            #region action
            //void ActMove(int side, Fruit fruit, Action<int, Fruit> act) => act(side, fruit);
            //switch (key)
            //{
            //    case ConsoleKey.A:
            //        if (this.x != 0)
            //        {
            //            ActMove(1, fruit, toMoveLeft);
            //            return;
            //        }
            //        throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("неосяжні стіни замку"));
            //    case ConsoleKey.W:
            //        if (this.y != 0)
            //        {
            //            ActMove(1, fruit, toMoveUp);
            //            return;
            //        }
            //        throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("небезпечні гірські хребти"));
            //    case ConsoleKey.S:
            //        if (this.y != Map.yLength - 1)
            //        {
            //            ActMove(-1, fruit, toMoveUp);
            //            return;
            //        }
            //        throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("глубокі ріки"));
            //    case ConsoleKey.D:
            //        if (this.x != Map.xLength - 1)
            //        {
            //            ActMove(-1, fruit, toMoveLeft);
            //            return;
            //        }
            //        throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("величезні ліса"));
            //    default:
            //        throw new PlayerWrongKeyException(new PlayerWrongKeyArgs(key));
            //}
            #endregion
            #region function
            int[] FuncMove(int side, Fruit fruit, Func<int, Fruit, int[]> func) => func(side, fruit);
            switch (key)
            {
                case ConsoleKey.A:
                    if (this.x != 0)
                    {
                        Coordinates = FuncMove(1, fruit, MovingLeft);
                        Map.field[y, x] = 5;
                        return;
                    }
                    throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("неосяжні стіни замку"));
                case ConsoleKey.W:
                    if (this.y != 0)
                    {
                        Coordinates = FuncMove(1, fruit, MovingUp);
                        Map.field[y, x] = 5;
                        return;
                    }
                    throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("небезпечні гірські хребти"));
                case ConsoleKey.S:
                    if (this.y != Map.yLength - 1)
                    {
                        Coordinates = FuncMove(-1, fruit, MovingUp);
                        Map.field[y, x] = 5;
                        return;
                    }
                    throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("глубокі ріки"));
                case ConsoleKey.D:
                    if (this.x != Map.xLength - 1)
                    {
                        Coordinates = FuncMove(-1, fruit, MovingLeft);
                        Map.field[y, x] = 5;
                        return;
                    }
                    throw new PlayerWrongKeyException(new PlayerWrongKeyArgs("величезні ліса"));
                default:
                    throw new PlayerWrongKeyException(new PlayerWrongKeyArgs(key));
            }
            #endregion
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
            this.name = "Гравець";
        }
    }
   
}
