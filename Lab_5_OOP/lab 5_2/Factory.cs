using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_2
{
    internal class Factory:IFactory
    {
        private int id;
        private IFactory nextElement;
        private int components=30;
        public void setNext(IFactory factory)
        {
            nextElement = factory;
        }
        public void produce()
        {
            if (components >= 15)
            {
             a:     Console.Clear();
                    Console.WriteLine("Would you like to give your order to " + id + " factory?\n" +
                                      "1)Yes;\n" +
                                      "2)No;");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            components -= 15;
                            Console.Clear();
                            Console.WriteLine($"The {id} factory made your order (-15 components)\n\n\n\nPress any button to go back....");
                            Console.ReadKey();
                            return;
                        case ConsoleKey.D2:
                            Console.Clear();
                            break;
                        default:
                            goto a;
                    }
            }

            if(nextElement != null)
            {
                nextElement.produce();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no availible factories.\n\n\nPress any button to go back....");
                Console.ReadKey();
            }
        }
        public void stats()
        {
            Console.WriteLine("---------------------------------\n" + id + " Factory\nNums of components:" + components);
            if (nextElement != null)
            {
                nextElement.stats();
            }
            else
            {
                Console.WriteLine("\n\n\nPress any button to go back....");
                Console.ReadKey();
            }
        }
        public Factory(int id)
        {
            this.id = id;
        }
    }
}
