using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    internal class Grinder
    {
        public void Grind(string components)
        {
            Console.WriteLine("A grinding machine is on and it starts moving...");
            Thread.Sleep(500);
            Console.WriteLine($"You throw the {components} in the machine");
            for (int i = 0; i < 40; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            Console.WriteLine("The machine succsessfully made the stuffing");
        }
    }
}
