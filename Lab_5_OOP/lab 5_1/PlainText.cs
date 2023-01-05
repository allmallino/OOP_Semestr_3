using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_1
{
    internal class PlainText:IAction
    {
        public string execute(string text)=>text;
    }
}
