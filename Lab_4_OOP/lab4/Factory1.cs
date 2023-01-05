using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Factory1:IFactory
    {
        public string name;
        public string ingridients;
        public string typeOfPakage;
        public int price;
        public Juice MakeJuice() => new Juice1(price, ingridients, typeOfPakage);
        public Factory1()
        {
            name = "the first fabric";
            ingridients = "apple";
            typeOfPakage = "paper";
            price = 29;
        }
    }
}
