using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Bank
    {
        private string name;
        private List<Customer> customers { get; set; }
        private List<Account> accounts { get; set; }

        public Bank(string name)
        {
            this.name = name;
            accounts = new List<Account>();
            customers = new List<Customer>();
        }

        public void Move(Double amount, Account source, Account target)
        {
            Contract.Requires(amount > 0);
            Movement movement = source.Withdraw(amount);
            target.Deposit(movement);
        }

        public void MakeStatement(Account account, Customer customer)
        {
            Contract.Requires(accounts.Contains(account) == false);
            accounts.Add(account);
            if(customers.Contains(customer) == false)
            {
                customers.Add(customer);
            }
            customer.AddAcount(account);
        }

        public class AccountExeption : ArgumentException
        {
            public AccountExeption() : base("The account Belongs to another customer")
            {
            }
        }
    }
}
