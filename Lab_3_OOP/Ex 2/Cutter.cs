using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex_2
{
    internal class Cutter
    {
        public void Cut(string components)
        {
            Console.WriteLine("Cutting machine is on and its blades are speeding up...");
            foreach(string component in components.Split(","))
            {
                Console.WriteLine("You throw some " + component + " in the cutting machine");
                for (int i = 0; i < 15; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }
                Console.CursorLeft = 0;
            }
            Console.WriteLine($"You've succsessfully cutted {components}\n\n");
        }
    }
}
