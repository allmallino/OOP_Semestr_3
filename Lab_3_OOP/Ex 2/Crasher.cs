using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Ex_2
{
    internal class Crasher
    {
        public void Crash(string component)
        {
            Console.WriteLine("You add some " + component + " to the crashing machine");
            for(int i =0; i < 15; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            Console.WriteLine("Crashing machine is speeding up...");
            for (int i = 0; i < 30; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.CursorLeft = 0;
            Console.WriteLine($"Your pile of the crashed {component} is ready\n\n\n");
        }
    }
}
