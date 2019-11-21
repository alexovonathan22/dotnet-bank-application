using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankApplication
{
    public class BankAccount
    {
        public int AcctNumber { get; }
        public string AcctName { get; set; }
        public DateTime dateCrn { get; }
        public string AcctType { get; set; }

        public bool txn;

        public decimal Balance
        {
            get
            {
                decimal bal = 0;
                foreach (var eachTransaction in cstTransactions)
                {
                    bal += eachTransaction.Amount;
                }
                return bal;
            }
        }

        private static int acctRandom = BankAppHelpers.RandomizeAcctNumber();
        public BankAccount(string name, decimal initBal, DateTime datenow, string type)
        {
            Deposit(initBal, DateTime.Now, "Starting Balance", "deposit");
            AcctName = name;
            AcctNumber = acctRandom;
            dateCrn = datenow;
            AcctType = type == "0" ? "Savings" : "Current";
        }
        private List<Transactions> cstTransactions = new List<Transactions>();
        public void Deposit(decimal amount, DateTime date, string note, string action)
        {
            try
            {
                if (amount <= 0)
                {
                    txn = true;
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\nAmount of deposit must be positive\n");
                Console.WriteLine(e.ToString());
                return;
            }
            var deposit = new Transactions(amount, date, note, action);
            cstTransactions.Add(deposit);

        }

        public void Withdrawal(decimal withdrawalAmount, DateTime date, string note, string action)
        {

            try
            {
                if (withdrawalAmount <= 0)
                {
                    txn = true;
                    throw new ArgumentOutOfRangeException(nameof(withdrawalAmount), "Amount of deposit must be positive");
                }
                else if (Balance - withdrawalAmount < 0)
                {
                    txn = true;

                    throw new InvalidOperationException("Insufficietnt funds, load up");
                }
                else if (withdrawalAmount > Balance)
                {
                    txn = true;

                    throw new InvalidOperationException("Insufficietnt funds, load up");

                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Insufficietnt funds, load up\n");
                Console.WriteLine(e.ToString());
                return;
            }
            var withdrawal = new Transactions(-withdrawalAmount, date, note, action);
            cstTransactions.Add(withdrawal);
        }

        public string GetActReport()
        {
            var report = new StringBuilder();

            report.AppendLine($"\t\tACCOUNT STATEMENT FOR {AcctName} with acct {AcctType} number: {AcctNumber}");
            report.AppendLine($"\t\tAcct CREAETED {dateCrn}");

            report.AppendLine($"Date \t\t Amount \t\t Notes \t\t \tTransaction Type");
            report.AppendLine($"---------------------------------------------------------------------------------\n");
            foreach (var item in cstTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t{item.Notes} \t\t{item.Action}");
            }
            report.AppendLine($"\n\n---------------------------------------------------------------------------------\n");

            report.AppendLine($"ledger bal: {Balance}");

            return report.ToString();
        }

        public string msg()
        {
            return txn ? "\nTransaction Failed" : "\nTransaction Successful";
        }

    }
}
