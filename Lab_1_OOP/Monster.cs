using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Lab_1_OOP.Program;

namespace Lab_1_OOP
{
    public class Monster:Entity
    {
        private string[] names = new string[] { "Скелет", "Вовк", "Ведмідь", "Гоблін", "Павук" };
        public static Monster CreateMonster()
        {
            return new Monster();
        }
        private Monster()
        {
            this.Level = (Math.Max(player.Level + rnd.Next(2), 1)) * 100 + rnd.Next(25);
            Map.field[this.y, this.x] = 1;
            this.name = $"{names[rnd.Next(names.Length)]} {Level} лвл";
            this.Health = 100 + 10 * Level;
            this.Damage = Math.Min(10 + 3 * Level, 40);
            this.index = 1;
        }
    }
}
