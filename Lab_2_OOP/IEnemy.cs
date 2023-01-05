using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_OOP
{
    internal interface IEnemy
    {
        public static int attackState;
        public void Move(Fruit fruit){ }
    }
}
