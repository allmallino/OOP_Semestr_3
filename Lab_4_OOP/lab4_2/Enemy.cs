using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyApp.Program;

namespace lab4_2
{
    internal abstract class Enemy
    {
        public string name;
        public int level;
        public int health;
        public int baseHealth;
        public string toString() => $"{name}, lvl {level}, HP:{health}/{baseHealth}";
        public void TakeDamage(int amount)
        {
            if (health <= amount)
            {
                enemyList.RemoveAt(ind);
                consoleList = $"{name} died";
                ind = 0;
                return;
            }
            else
            {
                health -= amount;
                consoleList = $"You damaged {name} for {amount} hp";
            }
            if (health <= baseHealth / 2)
            {
                baseHealth /= 2;
                Clone();
            }
        }
        public abstract void Clone();
    }
}
