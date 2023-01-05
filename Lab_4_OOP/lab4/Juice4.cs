using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Juice4:Juice 
    {
        public override void Drink()
        {
            Console.WriteLine($"You've just drank juice with {ingridients} for {price} dollars in {typeOfPakage} pakage from the fourth factory");
        }
        public Juice4(int price, string ingridients, string typeOfPakage)
        {
            this.price = price;
            this.ingridients = ingridients;
            this.typeOfPakage = typeOfPakage;
        }
    }
}
