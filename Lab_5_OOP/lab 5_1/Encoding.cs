using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_1
{
    internal class Encoding:IAction
    {
        public string execute(string text)
        {
            string output = "";
            foreach (char c in text)
            {
                output += ((int)c - 20) + "~";
            }
            return output;
        }
    }
}
