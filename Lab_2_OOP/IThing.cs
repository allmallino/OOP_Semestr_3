using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_2_OOP.Program;

namespace Lab_2_OOP
{
    internal interface IThing
    {
        public int[] Coordinates { get; set; }
        public int[] GenerateCoordinates() => new int[2];
    }
}
