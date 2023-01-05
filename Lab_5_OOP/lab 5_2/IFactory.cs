using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_2
{
    internal interface IFactory
    {
        public void setNext(IFactory factory);
        public void produce();
        public void stats();
    }
}
