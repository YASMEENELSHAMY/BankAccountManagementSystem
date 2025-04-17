using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    internal class CheckingAccount : BankAccount
    {
        private double overdraftLimit;
        public CheckingAccount(string ownerName, double intialBalance, double overDraftLimit) : base(ownerName, intialBalance)
        {
            this.overdraftLimit = overDraftLimit;
        }
        public override void withdraw(double amount)
        {
            if(amount<=0)
            {
                Console.WriteLine("Withdraw amount must be positive");
                return;
            }
            if(amount> (balance + overdraftLimit))
            {
                Console.WriteLine("Exceeds overdraft limit");
                return;
            }
            balance-=amount;
            addTransaction("Withdraw", amount, balance);
            Console.WriteLine($"Successfully withdraw {amount}, Current balance: {balance}");
        }
    }
}
