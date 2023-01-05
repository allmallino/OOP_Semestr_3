using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Lab_2_OOP.Program;

namespace Lab_2_OOP
{
    public class Bandit:Entity, IEnemy
    {
        private string[] names = new string[] { "Орк", "Ельф", "Людина", "Дворф" };
        public override int Level
        {
            get { return xp / 100; }
            set { xp += (int)(player.difcIndex * value); this.name = this.name.Split(" ")[0] + $" {Level} лвл"; }
        }
        public override int Health
        {
            get { return health; }
            set { health += value; }
        }
        public static Bandit CreateBandit()
        {
            return new Bandit();
        }
        public override void Move(Fruit fruit)
        {
            if (IEntity.attackState == 0)
            {
                if (Math.Sqrt(Math.Pow(entity.y - fruit.y, 2) + Math.Pow(entity.x - fruit.x, 2)) < Math.Sqrt(Math.Pow(entity.y - player.y, 2) + Math.Pow(entity.x - player.x, 2)))
                {
                    int newCord;
                    if (Math.Abs(this.x - fruit.x) >= Math.Abs(this.y - fruit.y))
                    {
                        newCord = this.x + Math.Abs(fruit.x - this.x) / (fruit.x - this.x);
                        if (Map.field[this.y, newCord] == 0)
                        {
                            Map.field[this.y, newCord] = index;
                            Map.field[this.y, this.x] = 0;
                            this.x = newCord;
                        }
                        else
                            Eating();
                    }
                    else
                    {
                        newCord = this.y + Math.Abs(fruit.y - this.y) / (fruit.y - this.y);
                        if (Map.field[newCord, this.x] == 0)
                        {
                            Map.field[newCord, this.x] = index;
                            Map.field[this.y, this.x] = 0;
                            this.y = newCord;
                        }
                        else
                            Eating();
                    }
                }
                else
                {
                    if (IEntity.attackState == 0)
                    {
                        int newCord;
                        if (Math.Abs(this.x - player.x) >= Math.Abs(this.y - player.y))
                        {
                            newCord = this.x + Math.Abs(player.x - this.x) / (player.x - this.x);
                            if (Map.field[this.y, newCord] == 0)
                            {
                                Map.field[this.y, newCord] = index;
                                Map.field[this.y, this.x] = 0;
                                this.x = newCord;
                            }
                            else if (Map.field[this.y, newCord] == 3)
                                Eating();
                            else
                            {
                                ((IEntity)this).GetHit(fruit);
                                IEntity.attackState = 2;
                            }
                        }
                        else
                        {
                            newCord = this.y + Math.Abs(player.y - this.y) / (player.y - this.y);
                            if (Map.field[newCord, this.x] == 0)
                            {
                                Map.field[newCord, this.x] = index;
                                Map.field[this.y, this.x] = 0;
                                this.y = newCord;
                            }
                            else if (Map.field[newCord, this.x] == 3)
                                Eating();
                            else
                            {
                                ((IEntity)this).GetHit(fruit);
                                IEntity.attackState = 2;
                            }
                        }
                    }
                    else
                        IEntity.attackState--;
                }
            }
            else
                IEntity.attackState--;
        }
        void IEnemy.Move(Fruit fruit)
        {
            if (IEnemy.attackState == 0)
            {
                int newCord;
                if (Math.Abs(this.x - player.x) > Math.Abs(this.y - player.y))
                {
                    if (player.y != this.y)
                        newCord = Math.Min(Math.Max(this.y - Math.Abs(player.y - this.y) / (player.y - this.y), 0), Map.yLength - 1);
                    else
                        newCord = Math.Min(Math.Max(this.y - rnd.Next(-1, 2), 0), Map.yLength - 1);
                    if (Map.field[newCord, this.x] == 0)
                    {
                        Map.field[newCord, this.x] = index;
                        Map.field[this.y, this.x] = 0;
                        this.y = newCord;
                    }
                    else if (Map.field[newCord, this.x] == 3)
                        Eating();
                    else if (Map.field[newCord, this.x] == 5)
                    {
                        player.GetHit(fruit);
                        IEnemy.attackState = 2;
                    }
                    else
                    {
                        if (player.x != this.x)
                            newCord = Math.Min(Math.Max(this.x - Math.Abs(player.x - this.x) / (player.x - this.x), 0), Map.xLength - 1);
                        else
                            newCord = Math.Min(Math.Max(this.x - rnd.Next(-1, 2), 0), Map.xLength - 1);
                        if (Map.field[this.y, newCord] == 0)
                        {
                            Map.field[this.y, newCord] = index;
                            Map.field[this.y, this.x] = 0;
                            this.x = newCord;
                        }
                        else if (Map.field[this.y, newCord] == 3)
                            Eating();
                    }
                }
                else
                {
                    if (player.x != this.x)
                        newCord = Math.Min(Math.Max(this.x - Math.Abs(player.x - this.x) / (player.x - this.x), 0), Map.xLength - 1);
                    else
                        newCord = Math.Min(Math.Max(this.x - rnd.Next(-1, 2), 0), Map.xLength - 1);
                    if (Map.field[this.y, newCord] == 0)
                    {
                        Map.field[this.y, newCord] = index;
                        Map.field[this.y, this.x] = 0;
                        this.x = newCord;
                    }
                    else if (Map.field[this.y, newCord] == 3)
                        Eating();
                    else if (Map.field[this.y, newCord] == 5)
                    {
                        player.GetHit(fruit);
                        IEnemy.attackState = 2;
                    }
                    else
                    {
                        if (player.y != this.y)
                            newCord = Math.Min(Math.Max(this.y - Math.Abs(player.y - this.y) / (player.y - this.y), 0), Map.yLength - 1);
                        else
                            newCord = Math.Min(Math.Max(this.y - rnd.Next(-1, 2), 0), Map.yLength - 1);
                        if (Map.field[newCord, this.x] == 0)
                        {
                            Map.field[newCord, this.x] = index;
                            Map.field[this.y, this.x] = 0;
                            this.y = newCord;
                        }
                        else if (Map.field[newCord, this.x] == 3)
                            Eating();
                    }
                }
            }
            else
                IEnemy.attackState--;
        }
        private Bandit()
        {
            this.xp=(Math.Max(player.Level + rnd.Next(2), 1)) * 100 + rnd.Next(25, 75);
            Map.field[this.y, this.x] = 2;
            this.name = $"Бандит {names[rnd.Next(names.Length)]} {Level} лвл";
            this.Health = 100 + 15 * Level;
            this.Damage = Math.Min(10 + 5 * Level, 40);
            this.index = 2;
        }
    }
}
