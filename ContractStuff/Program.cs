using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acount1 = new Account(100);
            Customer patrick = new Customer("Patrick", 1);
            Account acount2 = new Account(60);
            Customer søren = new Customer("Søren", 2);
            Bank nordea = new Bank("Nordea");
            nordea.MakeStatement(acount1, patrick);
            nordea.MakeStatement(acount2, søren);
            //nordea.MakeStatement(acount2, patrick);
            //nordea.Move(120, acount1, acount2);
            nordea.Move(80, acount1, acount2);
            Console.ReadLine();
        }
    }
}
