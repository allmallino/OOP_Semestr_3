using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Lab_2_OOP.Program;

namespace Lab_2_OOP
{
    public delegate void EatingHandle(Entity entity, FruitEventArgs args);
    public class FruitEventArgs: EventArgs
    {
        public bool state;
        public FruitEventArgs()
        {
            this.state = true;
            for(int i =0; i<ConsoleLog.logList.Length; i++)
            {
                if (ConsoleLog.logList[i] == $"{entity.name} закричав і починає тікати.")
                {
                    this.state = false;
                    break;
                }
            }
        }
    }
    public class Fruit:IThing
    {
        public int x, y;
        private int[] GenerateCoordinates()
        {
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(Map.xLength);
                y = rnd.Next(Map.yLength);
            }
            while (Map.field[y, x] != 0);
            return new int[] { y, x };
        }
        public int[] Coordinates { get => new int[] { y, x }; set { y = value[0]; x = value[1]; } }
        public static int healthGive, xpGive;
        public void ToGive(Entity entity, FruitEventArgs fargs)
        {
            if (fargs.state)
            {
                entity.Level = xpGive;
                entity.Health = healthGive;
                ConsoleLog.ToAdd($"{entity.name} з'їв фрукт");
            }
            else
                entity.Health = healthGive/10;
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
        }
        public Fruit()
        {
            Coordinates = GenerateCoordinates();
            healthGive = 20;
            xpGive = 100;
            Map.field[y, x] = 3;
        }
        ~Fruit()
        {
            ConsoleLog.ToAdd("Фрукт був видалений з пам'яті.");
        }
    }
}
