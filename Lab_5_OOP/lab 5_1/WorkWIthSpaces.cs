using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_1
{
    internal class WorkWIthSpaces : IAction
    {
        public string execute(string text)
        {
            string output = "";
            char lastElement ='~';
            foreach(char c in text)
            {
                if(c+""+lastElement!= "  ")
                {
                    output += c + "";
                    lastElement = c;
                }
            }
            return output;
        }
    }
}
