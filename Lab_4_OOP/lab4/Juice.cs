using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal abstract class Juice
    {
        public int price;
        public string ingridients;
        public string typeOfPakage;
        public abstract void Drink();
    }
}
