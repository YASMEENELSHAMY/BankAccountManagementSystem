using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAccountManagementSystem
{
    internal class BankAccount
    {
        public int accountNumber {  get; set; }
        public string ownerName { get; set; }
        public double balance {  get; set; }

        protected List<string> transactionHistory;

        private static int acoountNumberGenrator = 100;
        public BankAccount(string ownerName,double intialBalance) {
            this.accountNumber = acoountNumberGenrator++;
            this.ownerName = ownerName;
            this.balance = intialBalance;
            this.transactionHistory = new List<string>();

        
        }

        public virtual void deposite(double amount) {
            if (amount <= 0)
            {
               Console.WriteLine("Deposite must be positive");
                return;
            }
            balance += amount;
            addTransaction("Deposite", amount, balance);
            Console.WriteLine($"Successfully deposited {amount}, Current balance: {balance}");

        }
        public virtual void withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposite must be positive");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Sorry, insufficient funds");
                return ;
            }
                balance -= amount;
            addTransaction("Withdraw", amount, balance);
            Console.WriteLine($"Successfully withdraw {amount}, Current balance: {balance}");
        }
        protected void addTransaction(string type, double amount, double balance) {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string transactionDetails = $"{timestamp} | type of transaction is: {type} | Amount:{amount} | Current balance: {balance}";
            transactionHistory.Add(transactionDetails);
        }
        public virtual void Display()
        {
            Console.WriteLine($"Account number: {accountNumber}");
            Console.WriteLine($"Owner:{ownerName}");
            Console.WriteLine($"Balance: {balance}");
        }
        public void displayTransactionHistory()
        {
            if(transactionHistory.Count ==0)
            {
                Console.WriteLine("There Is No Transaction Yet");
                return;
            }
            Console.WriteLine($"Transaction History for Account {accountNumber}-{ownerName}:");
            foreach( var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }

    }
}
