using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    internal class Juicer
    {
        public void MakeJuice(string components)
        {
            Console.WriteLine("The juicer starts working...");
            foreach (string component in components.Split(","))
            {
                Console.WriteLine("You throw cutted " + component + " in the juicer and it starts to make juice of it");
                for (int i = 0; i < 25; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }
                Console.CursorLeft = 0;
            }
            if (components.Split(",").Length > 1)
                Console.WriteLine($"You have multyfruit juice now");
            else
                Console.WriteLine($"You have {components} juice now");
        }
    }
}
