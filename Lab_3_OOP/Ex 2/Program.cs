using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Ex_2;

namespace Lab3.B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool state;
            kitchenMachine machine = new kitchenMachine();
            while (true)
            {
                state = true;
                Console.Clear();
                Console.WriteLine("You want to:\n" +
                              "1)Make tea\n" +
                              "2)Make coffee\n" +
                              "3)Make juice\n" +
                              "4)Make stuffing\n" +
                              "5)Cut vegetables for the salad\n" +
                              "6)Stir dough");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        while (state)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose the tea:\n" +
                                              "1)White tea;\n" +
                                              "2)Black tea;\n" +
                                              "3)Green tea;\n" +
                                              "4)Gray tea;\n" +
                                              "5)Fruit tea;");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    machine.MakeTea("leaves of a white tea");
                                    state = false;
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    machine.MakeTea("leaves of a black tea");
                                    state = false;
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    machine.MakeTea("leaves of a green tea");
                                    state = false;
                                    break;
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    machine.MakeTea("leaves of a gray tea");
                                    state = false;
                                    break;
                                case ConsoleKey.D5:
                                    Console.Clear();
                                    machine.MakeTea("pieces of fruit and leaves for a fruit tea");
                                    state = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        while (state)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose the coffee beans:\n" +
                                              "1)Arabica coffee beans;\n" +
                                              "2)Robusta coffee beans;\n" +
                                              "3)Catimor coffee beans;\n" +
                                              "4)Caturra coffee beans;\n" +
                                              "5)Icatu coffee beans;");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    machine.MakeCoffee("arabica coffee beans");
                                    state = false;
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    machine.MakeCoffee("robusta coffee beans");
                                    state = false;
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    machine.MakeCoffee("catimor coffee beans");
                                    state = false;
                                    break;
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    machine.MakeCoffee("caturra coffee beans");
                                    state = false;
                                    break;
                                case ConsoleKey.D5:
                                    Console.Clear();
                                    machine.MakeCoffee("icatu coffee beans");
                                    state = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        while (state)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose the fruit:\n" +
                                              "1)Apple;\n" +
                                              "2)Grape;\n" +
                                              "3)Orange;\n" +
                                              "4)Strawberry;\n" +
                                              "5)Mixed all fruits;");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    machine.MakeJuice("apples");
                                    state = false;
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    machine.MakeJuice("grapes");
                                    state = false;
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    machine.MakeJuice("oranges");
                                    state = false;
                                    break;
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    machine.MakeJuice("strawberries");
                                    state = false;
                                    break;
                                case ConsoleKey.D5:
                                    Console.Clear();
                                    machine.MakeJuice("apples,grapes,oranges,strawberries");
                                    state = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        machine.MakeStuffing();
                        break;
                    case ConsoleKey.D5:
                        while (state)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose the vegetable:\n" +
                                              "1)Cucumber;\n" +
                                              "2)Tomato;\n" +
                                              "3)Lettuce;\n" +
                                              "4)Onion;\n" +
                                              "5)Cabbage;");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    machine.Cut("cucumbers");
                                    state = false;
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    machine.Cut("tomatoes");
                                    state = false;
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    machine.Cut("lettuces");
                                    state = false;
                                    break;
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    machine.Cut("onions");
                                    state = false;
                                    break;
                                case ConsoleKey.D5:
                                    Console.Clear();
                                    machine.Cut("cabbages");
                                    state = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        machine.StirDough();
                        break;
                }
                Console.Write("Press any button to go back...");
                Console.ReadKey();
            }
        }
    }
}