using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ContractStuff
{
    class Account
    {
        public List<Movement> Credits;
        public List<Movement> Debits;

        private double InitialBalance;

        public double Balance
        {
            get
            {
                double sudoBalance = 0;
                sudoBalance += InitialBalance;
                foreach (Movement credit in Credits)
                {
                    sudoBalance += credit.Amount;
                }
                foreach (Movement debit in Debits)
                {
                    sudoBalance -= debit.Amount;
                }
                return sudoBalance;
            }
        }

        public Account(double initialBalance)
        {
            this.InitialBalance = initialBalance;
            Credits = new List<Movement>();
            Debits = new List<Movement>();
        }

        public Movement Withdraw(double amount)
        {
            Contract.Requires(amount > 0);
            Contract.Requires<moneyException>(amount <= Balance);
            Movement movement = new Movement(amount);
            Debits.Add(movement);
            return movement;
        }

        public void Deposit(Movement movement)
        {
            Credits.Add(movement);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Balance >= 0, "The Desired amount exceded the Balance. The withdrawal is canceled");
        }

        public class moneyException : ArgumentOutOfRangeException
        {
            public moneyException() : base("The Desired amount exceded the Balance. The withdrawal is canceled")
            {
            }
        }
    }
}
