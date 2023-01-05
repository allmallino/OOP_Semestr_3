using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex_2
{
    internal class Kettle
    {
        public void BoilUp(string component, bool isItCoffee)
        {
            Console.WriteLine("Water is heating up...");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            Console.WriteLine("Water is boiling");
            Console.WriteLine("You add the "+component);
            for (int i = 0; i < 30; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            if (isItCoffee)
                Console.WriteLine($"You've waited for a few minutes and a {component.Split(" ")[4]} coffee is ready.");
            else
                Console.WriteLine($"You've waited for a few minutes and a {component.Split(" ")[component.Split(" ").Length-2]} tea is ready.");
        }
    }
}
