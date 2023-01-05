using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Lab_1_OOP.Program;

namespace Lab_1_OOP
{
    public class Bandit:Entity
    {
        private string[] names = new string[] { "Орк", "Ельф", "Людина", "Дворф" };
        public static Bandit CreateBandit()
        {
            return new Bandit();
        }
        public override void Move(Fruit fruit)
        {
            if (attackState == 0)
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
                            fruit.ToGive(entity);
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
                            fruit.ToGive(entity);
                    }
                }
                else
                {
                    base.Move(fruit);
                }
            }
            else
                attackState--;
        }
        private Bandit()
        {
            this.Level = (Math.Max(player.Level + rnd.Next(2), 1)) * 100 + rnd.Next(25, 75);
            Map.field[this.y, this.x] = 2;
            this.name = $"Бандит {names[rnd.Next(names.Length)]} {Level} лвл";
            this.Health = 100 + 15 * Level;
            this.Damage = Math.Min(10 + 5 * Level, 40);
            this.index = 2;
        }
    }
}
