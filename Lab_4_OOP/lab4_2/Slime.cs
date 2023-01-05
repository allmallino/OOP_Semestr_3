using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Program;

namespace lab4_2
{
    internal class Slime:Enemy
    {
        public override void Clone()
        {
            if (enemyList.Count < 8)
            {
                consoleList = $"Attention!! A {name} is going to clone";
                enemyList.Add(new Slime(this));
            }
            else
                consoleList = $"{name} can't clone because there is no free space";
        }
        public Slime(string color, int level, int health, int baseHealth)
        {
            this.name = color+" slime";
            this.level = level;
            this.health = health;
            this.baseHealth = baseHealth;
        }
        public Slime(Enemy enemy)
        {
            name = enemy.name + "'s clone";
            level = enemy.level;
            health = enemy.health;
            baseHealth = enemy.baseHealth;
        }
    }
}
