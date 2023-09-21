using System;

namespace Assignment_4
{
    class Accounts
    {
        private string accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private decimal amount;
        private decimal balance;

        public Accounts(string accountNo, string customerName, string accountType, decimal startingBalance)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.balance = startingBalance;
        }

        public void Credit(decimal amount)
        {
            this.balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (amount <= balance)
            {
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void ShowData()
        {
            Console.WriteLine("===========================Account Detail================================");
            Console.WriteLine("Account No: " + accountNo);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Balance: " + balance);
            Console.WriteLine("=========================================================================");
        }

        public void PerformTransaction()
        {
            Console.Write("Enter transaction type (D->Deposit, W->Withdrawal): ");
            char transactionType = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (transactionType == 'D')
            {
                Console.Write("Enter the amount to deposit: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                {
                    Credit(depositAmount);
                    Console.WriteLine("Deposit successful.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (transactionType == 'W')
            {
                Console.Write("Enter the amount to withdraw: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                {
                    Debit(withdrawalAmount);
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }
    }

    class Programs
    {
        static void Main()
        {
            Console.Write("Enter Account No: ");
            string accountNo = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Account Type: ");
            string accountType = Console.ReadLine();

            Console.Write("Enter Starting Balance: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal startingBalance))
            {
                Accounts account = new Accounts(accountNo, customerName, accountType, startingBalance);

                account.PerformTransaction();
                account.ShowData();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.ReadLine();
        }
    }
}
