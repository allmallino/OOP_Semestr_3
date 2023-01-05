using lab4;
using System;

namespace MyApp
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            IFactory fabric1 = new Factory1();
            IFactory fabric2 = new Factory2();
            IFactory fabric3 = new Factory3();
            IFactory fabric4 = new Factory4();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your season of the year:\n" +
                                  " 1)Spring;\n" +
                                  " 2)Summer;\n" +
                                  " 3)Autumn;\n" +
                                  " 4)Winter;");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("For that time of the year there are a lot of vegetables. So you choose the juice from the Second fabric");
                        fabric2.MakeJuice().Drink();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("For that time of the year there are a lot of fruit and berries. So you choose the juice from the Third fabric");
                        fabric3.MakeJuice().Drink();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("For that time of the year there are a lot of apples. So you choose the juice from the First fabric");
                        fabric1.MakeJuice().Drink();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("For that time of the year you need a lot of vitamins. So you choose the juice from the Fourth fabric");
                        fabric4.MakeJuice().Drink();
                        break;
                }
                Console.ReadKey();
            }

        }
    }
}