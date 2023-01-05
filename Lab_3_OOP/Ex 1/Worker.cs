using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_OOP_3_5
{
    internal class Worker: IPayment
    {
        public string name;
        public string surname;
        public int salary;
        public void pay()
        {
            Console.WriteLine("         "+name + " " + surname + " received " + salary+";");
        }
        public void getList()
        {
            Console.WriteLine("  " + name + " " + surname + " with salary " + salary + ";");
        }
        public Worker(string name, string surname, int salary)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
        }   
    }
}
