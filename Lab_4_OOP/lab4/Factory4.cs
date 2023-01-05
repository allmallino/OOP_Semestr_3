using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Factory4:IFactory
    {
        public string name;
        public string ingridients;
        public string typeOfPakage;
        public int price;
        public Juice MakeJuice() => new Juice4(price, ingridients, typeOfPakage);
        public Factory4()
        {
            name = "the fourth fabric";
            ingridients = "apples, bananas, strawberries, tomatoes, garlic, onions";
            typeOfPakage = "metal";
            price = 76;
        }
    }
}
