using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab_OOP_3_5
{
    internal class School : IPayment
    {
        public string name;
        private List<Unit> units = new List<Unit>();
        public void pay()
        {
            Console.WriteLine("The money goes to the school "+ name +":");
            foreach (IPayment unit in units)
                unit.pay();
        }
        public void getList()
        {
            int i = 1;
            foreach (Unit unit in units)
            {
                Console.WriteLine("  "+i+") unit " + unit.num + ";");
                i++;
            }
        }
        public Unit find(int i) => units[i];
        public int length => units.Count;
        public void Add(Unit unit)
        {
            if (!units.Contains(unit))
            {
                units.Add(unit);
                Console.WriteLine("This unit has successfully added to the school");
            }
            else
            {
                Console.WriteLine("This unit is already in this school");
            }

        }
        public void Delete(Unit unit)
        {
            if (units.Contains(unit))
            {
                units.Remove(unit);
                Console.WriteLine("This unit has successfully removed from the school");
            }
            else
            {
                Console.WriteLine("This school doesn't have this unit");
            }
        }
        public List<Unit> getChildren() => units;

        public School(string name)
        {
            this.name = name;
        }
    }
}
