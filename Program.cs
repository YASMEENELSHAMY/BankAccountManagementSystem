using BankAccountManagementSystem;

class program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        while (true)
        {
            Console.WriteLine("Bank Account Management System");
            Console.WriteLine("1-Create Account");
            Console.WriteLine("2-Deposite Money");
            Console.WriteLine("3-Withdraw Money");
            Console.WriteLine("4-Transfer Money");
            Console.WriteLine("5-View Account Details");
            Console.WriteLine("6-View Transaction History");
            Console.WriteLine("7-Close Account");
            Console.WriteLine("8-View All Accounts");
            Console.WriteLine("9-Exit");
            Console.WriteLine("Enter your choice");
            int choice=int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Account type (Saving/Checking): ");
                    string type=Console.ReadLine();
                    Console.Write("Enter Owner Name: ");
                    string ownerName=Console.ReadLine();
                    Console.Write("Enter Initial deposite: ");
                    double initialDeposite =double.Parse(Console.ReadLine());
                    Console.Write("Enter Interest Rate or overdrife limit: ");
                    double param=double.Parse(Console.ReadLine());
                    bank.createAccount(type, ownerName, initialDeposite, param);
                    break;

                case 2:
                    Console.Write("Enter your account number: ");
                    int accountNumber=int.Parse(Console.ReadLine());
                    Console.Write("Enter the amount: ");
                    double amount=double.Parse(Console.ReadLine());
                    bank.findAccount(accountNumber)?.deposite(amount);
                    break;
                case 3:
                    Console.Write("Enter your account number: ");
                    int accNum = int.Parse(Console.ReadLine());
                    Console.Write("Enter the amount: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    bank.findAccount(accNum)?.withdraw(withdrawAmount);
                    break;

                case 4:
                    Console.Write("Enter Source Account Number: ");
                    int fromAcc=int.Parse(Console.ReadLine());
                    Console.Write("Enter Destination Account Number: ");
                    int toAcc = int.Parse(Console.ReadLine());
                    Console.Write("Enter Transfer Amount: ");
                    double transAmount = double.Parse(Console.ReadLine());
                    bank.transferMoney(fromAcc, toAcc, transAmount);
                    break;
                case 5:
                    Console.Write("Enter Account Number: ");
                    int acc_num=int.Parse(Console.ReadLine());
                    bank.findAccount(acc_num)?.Display();
                    break;
                case 6:
                    Console.Write("Enter Account Number: ");
                    acc_num = int.Parse(Console.ReadLine());
                    bank.findAccount(acc_num)?.displayTransactionHistory();
                    break;
                case 7:
                    Console.Write("Enter Account Number To Close: ");
                    acc_num = int.Parse(Console.ReadLine());
                    bank.closeAccount(acc_num);
                    break;
                case 8:
                    bank.viewAllAccounts();
                    break;
                case 9:
                    Console.WriteLine("Exiting System...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, Please try again.");
                    break;



            }
        }
    }

}