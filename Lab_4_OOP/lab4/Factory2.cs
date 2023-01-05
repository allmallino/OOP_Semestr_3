using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Factory2:IFactory
    {
        public string name;
        public string ingridients;
        public string typeOfPakage;
        public int price;
        public Juice MakeJuice() => new Juice2(price, ingridients, typeOfPakage);
        public Factory2()
        {
            name = "the second fabric";
            ingridients = "tomatoes, garlic, onions";
            typeOfPakage = "glass";
            price = 64;
        }
    }
}
