using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Factory3:IFactory
    {
        public string name;
        public string ingridients;
        public string typeOfPakage;
        public int price;
        public Juice MakeJuice() => new Juice3(price, ingridients, typeOfPakage);
        public Factory3()
        {
            name = "the third fabric";
            ingridients = "bananas, strawberries";
            typeOfPakage = "plastic";
            price = 50;
        }
    }
}
