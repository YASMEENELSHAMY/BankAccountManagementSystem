using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    internal class SavingAccount : BankAccount
    {
        private double interestRate;
        public SavingAccount(string ownerName, double intialBalance, double interestRate) : base(ownerName, intialBalance)
        {
            this.interestRate = interestRate;
        }
        public void calcInterest()
        {
            double interest= interestRate* balance;
            balance += interest;
            addTransaction("Interest added",interest,balance);
            Console.WriteLine($"Interest added, New balance is :{balance}");
        }
    }
}
