using Lab_OOP_3_5;
using System;
using System.Data;
using System.Collections.Generic;

namespace Lab3.A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<School> schools = new List<School>();
            School nvk = new School("NVK 39");
            Unit unitOne = new Unit("One");
            Unit unitTwo = new Unit("Two");
            nvk.Add(unitOne);
            nvk.Add(unitTwo);
            unitOne.Add(new Worker("Tayler", "Medichi", 6400));
            unitOne.Add(new Worker("Alex", "Jons", 1200));
            unitOne.Add(new Worker("Maria", "Green", 8392));
            unitTwo.Add(new Worker("Malc", "Colm", 6337));
            unitTwo.Add(new Worker("Sophia", "Lane", 5645));
            schools.Add(nvk);
            string input,output = "";
            int index;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your option:\n" +
                              " 1)To pay salaries\n" +
                              " 2)To see the list of workers in the specific unit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        foreach(IPayment payment in schools)
                            payment.pay();
                        Console.WriteLine("Press any button to go back...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        for(int i =0; i < schools.Count; i++)
                        {
                            output += " "+(i+1) + ") " + schools[i].name + ";\n";
                        }
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Choose the school:\n" + output);
                            input = Console.ReadLine();
                            if (Convert.ToInt32(input) - 1 < schools.Count)
                            {
                                break;
                            }
                        }
                        index=Convert.ToInt32(input)-1;
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Choose unit in the " + schools[index].name + ":\n");
                            schools[index].getList();
                            input = Console.ReadLine();
                            if (Convert.ToInt32(input) - 1 < schools[index].length)
                                break;
                        }
                        Console.Clear();
                        schools[index].find(Convert.ToInt32(input) - 1).getList();
                        Console.WriteLine("Press any button to go back...");
                        Console.ReadKey();
                        output = "";
                        break;
                }
            }
            
        }
    }
}