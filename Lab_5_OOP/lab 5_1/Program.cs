using lab_5_1;
using System;
using System.Data;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor textAction = new TextEditor(@"text.txt");
            string text;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write down your text:");
                text = Console.ReadLine();
                if (text != "")
                    break;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the way of saving your text:\n" +
                                  "1) Save without changes;\n" +
                                  "2) Save without unnecessary spaces;\n" +
                                  "3) Encode your text and save it;");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        textAction.Save(text);
                        Console.Clear();
                        Console.WriteLine("Your text is successfuly saved.\n\n\n\nPress any button to exit....");
                        Console.ReadKey();
                        return;
                    case ConsoleKey.D2:
                        textAction.setAction(new WorkWIthSpaces());
                        textAction.Save(text);
                        Console.Clear();
                        Console.WriteLine("Your text is successfuly saved.\n\n\n\nPress any button to exit....");
                        Console.ReadKey();
                        return;
                    case ConsoleKey.D3:
                        textAction.setAction(new Encoding());
                        textAction.Save(text);
                        Console.Clear();
                        Console.WriteLine("Your text is successfuly saved.\n\n\n\nPress any button to exit....");
                        Console.ReadKey();
                        return;
                }
            }
        }
    }
}