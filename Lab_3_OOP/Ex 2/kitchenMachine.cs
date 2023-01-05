using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    internal class kitchenMachine
    {
        Kettle kettle;
        Cutter cutter;
        Grinder grinder;
        Stirrer stirrer;
        Juicer juicer;
        Crasher crasher;
        public void MakeTea(string component)
        {
            kettle.BoilUp(component, false); 
        }
        public void MakeCoffee(string component)
        {
            crasher.Crash(component);
            kettle.BoilUp("pile of the crashed "+component, true);
        }
        public void MakeJuice(string component)
        {
            cutter.Cut(component);
            juicer.MakeJuice(component);
        }
        public void Cut(string component)
        {
            cutter.Cut(component);
        }
        public void MakeStuffing()
        {
            cutter.Cut("meat,onion,potato");
            grinder.Grind("meat, onion, potato pieces");
        }
        public void StirDough()
        {
            stirrer.Stir();
        }
        public kitchenMachine()
        {
            kettle = new Kettle();
            cutter = new Cutter();
            grinder = new Grinder();
            stirrer = new Stirrer();
            juicer = new Juicer();
            crasher = new Crasher();
        }
    }
}
