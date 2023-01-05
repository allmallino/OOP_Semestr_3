using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab_OOP_3_5
{
    internal class Unit : IPayment
    {
        private List<IPayment> workers = new List<IPayment>();
        public string num;
        public void pay()
        {
            Console.WriteLine("    The money goes to Unit "+num+":");
            foreach (IPayment worker in workers)
                worker.pay();
        }
        public void getList()
        {
            Console.WriteLine("The Unit " + num + " has "+workers.Count + " workers:");
            foreach (IPayment worker in workers)
                worker.getList();
        }
        public void Add(Worker worker)
        {
            if (!workers.Contains((IPayment)worker))
            {
                workers.Add((IPayment)worker);
                Console.WriteLine("This worker has successfully added to the unit");
            }
            else
            {
                Console.WriteLine("This worker is already in this unit");
            }
            
        }
        public void Delete(Worker worker)
        {
            if (workers.Contains((IPayment) worker))
            {
                workers.Remove((IPayment)worker);
                Console.WriteLine("This worker has successfully removed from the unit");
            }
            else
            {
                Console.WriteLine("This unit doesn't have this worker");
            }
        }
        public List<IPayment> getChildren() => workers;
        public Unit(string num)
        {
            this.num = num;
        }
    }
}
