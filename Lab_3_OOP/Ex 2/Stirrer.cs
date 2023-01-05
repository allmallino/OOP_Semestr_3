using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    internal class Stirrer
    {
        public void Stir()
        {
            Console.WriteLine("You throw some dough and ingridients in the machine");
            Thread.Sleep(500);
            Console.WriteLine("A stirring machine is on and its whisk starts moving...");
            for (int i = 0; i < 40; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            Console.WriteLine("The machine succsessfully stirred the dough");
        }
    }
}
