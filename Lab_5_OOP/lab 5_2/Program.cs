using lab_5_2;
using System;
using System.Data;
using System.Text;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool state = true;
            IFactory factory1 = new Factory(1);
            IFactory factory2 = new Factory(2);
            factory1.setNext(factory2);
            IFactory factory3 = new Factory(3);
            factory2.setNext(factory3);
            IFactory factory4 = new Factory(4);
            factory3.setNext(factory4);
            IFactory factory5 = new Factory(5);
            factory4.setNext(factory5);
            IFactory factory6 = new Factory(6);
            factory5.setNext(factory6);
            IFactory factory7 = new Factory(7);
            factory6.setNext(factory7);
            IFactory factory8 = new Factory(8);
            factory7.setNext(factory8);
            IFactory factory9 = new Factory(9);
            factory8.setNext(factory9);
            while (true)
            {
                state = true;
                Console.Clear();
                Console.WriteLine("Choose your option:\n" +
                                  "1) To give orders;\n" +
                                  "2) Statistics;");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        while (state)
                        {
                            Console.Clear();
                            Console.WriteLine("To which factory you want to give your order:\n" +
                                              "1) The first factory;\n" +
                                              "2) The second factory;\n" +
                                              "3) The third factory;\n" +
                                              "4) The fourth factory;\n" +
                                              "5) The fifth factory;\n" +
                                              "6) The sixth factory;\n" +
                                              "7) The seventh factory;\n" +
                                              "8) The eighth factory;\n" +
                                              "9) The ninth factory;");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    factory1.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D2:
                                    factory2.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D3:
                                    factory3.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D4:
                                    factory4.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D5:
                                    factory5.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D6:
                                    factory6.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D7:
                                    factory7.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D8:
                                    factory8.produce();
                                    state = false;
                                    break;
                                case ConsoleKey.D9:
                                    factory9.produce();
                                    state = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        factory1.stats();
                        break;
                }
            }
        }
    }
}