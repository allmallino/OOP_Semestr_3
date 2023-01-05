using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_1_OOP.Program;

namespace Lab_1_OOP
{
    public class Fruit
    {
        public int x, y;
        private int healthGive, xpGive;
        public void ToGive(Entity entity)
        {
            entity.Level = xpGive;
            entity.Health = healthGive;
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(Map.xLength);
                y = rnd.Next(Map.yLength);
            }
            while (Map.field[y, x] != 0);
            Map.field[this.y, this.x] = 0;
            this.y = y;
            this.x = x;
            Map.field[y, x] = 3;
            if (fruitIndex == 5)
                forcedGC();
            else
                fruitIndex++;
        }
        private void forcedGC()
        {
            fruitIndex = 0;
            for (int i = 0; i < 100000; i++)
            {
                Fruit fr = new Fruit();
                Map.field[fr.y, fr.x] = 0;
            }
        }
        public Fruit()
        {
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(Map.xLength);
                y = rnd.Next(Map.yLength);
            }
            while (Map.field[y, x] != 0);
            this.y = y;
            this.x= x;
            healthGive = xpGive = 20;
            Map.field[y, x] = 3;
        }
        ~Fruit()
        {
            for (int i = 0; i < consoleLog.Length; i++)
            {
                if (consoleLog[i] == null)
                {
                    consoleLog[i] = "Фрукт був видалений з пам'яті.";
                    return;
                }
            }
            for (int i = 0; i < consoleLog.Length - 1; i++)
            {
                consoleLog[i] = consoleLog[i + 1];
            }
            consoleLog[consoleLog.Length - 1] = "Фрукт був видалений з пам'яті.";
        }
    }
}
