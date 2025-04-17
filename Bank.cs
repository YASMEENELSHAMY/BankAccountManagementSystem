using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    internal class Bank
    {
        private List<BankAccount> bankAccounts;
        public Bank() { 
            bankAccounts = new List<BankAccount>();
        }
        public void createAccount(string type,string ownerName, double initialBalance, double newParam)
        {
            if (type.ToLower() == "saving")
            {
                BankAccount savingAccount = new SavingAccount(ownerName, initialBalance, newParam);
                bankAccounts.Add(savingAccount);
                Console.WriteLine($"Saving account created successfully for {ownerName} with account number:{savingAccount.accountNumber} Balance:{initialBalance}");

            }
            else if(type.ToLower() == "checking")
            {
                BankAccount checkingAccount = new CheckingAccount(ownerName, initialBalance, newParam);
                bankAccounts.Add(checkingAccount);
                Console.WriteLine($"Checking account created successfully for {ownerName} with account number:{checkingAccount.accountNumber} Balance:{initialBalance}");
            }
            else
            { 
                Console.WriteLine("Invaild account type.");
                return;
            }


        }


        public BankAccount findAccount(int accountNumber)
        {
            if (bankAccounts.Find(acc => acc.accountNumber == accountNumber) == null)
            {
                Console.WriteLine("Account not found.");
                return null;
            }
            else
                return bankAccounts.Find(acc => acc.accountNumber == accountNumber);
        }
        public void transferMoney(int fromAccount, int toAccount,double amount)
        {
            BankAccount FromAccount = findAccount(fromAccount);
            BankAccount ToAccount = findAccount(toAccount);
            if (FromAccount == null || ToAccount == null)
            {
                Console.WriteLine("One or both account numbers are invalid.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be Positive.");
                return ;
            }

            if (FromAccount.balance < amount)
            {
                Console.WriteLine("Insufficient funds to complete the transfer.");
                return ;
            }

            FromAccount.withdraw(amount);
            ToAccount.deposite(amount);
            Console.WriteLine($"Successfully transferred {amount} from Account{fromAccount} to Account {toAccount}");
        }
        public void viewAllAccounts()
        {
            if (bankAccounts.Count() == 0)
            {
                Console.WriteLine("There Is No Accounts");
                return;
            }
            foreach (BankAccount bankAccount in bankAccounts)
            {
                bankAccount.Display();
                Console.WriteLine("================================");
            }
        }
        public void closeAccount( int accountNumber )
        {
            BankAccount bankAccount = findAccount(accountNumber);
            if (bankAccount == null)
            {
               Console.WriteLine("Account not found.");
                return;
            }
            bankAccounts.Remove(bankAccount);
            Console.WriteLine($"Account {accountNumber} has been closed.");
        }

    }
}
