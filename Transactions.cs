using System;

namespace ConsoleBankApplication
{
    public class Transactions
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        public string Action { get; }


        public Transactions(decimal amount, DateTime date, string note, string action)
        {
            Amount = amount;
            Date = date;
            Notes = note;
            Action = action;
        }
    }
}
