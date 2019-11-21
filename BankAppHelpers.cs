using System;

namespace ConsoleBankApplication
{
    public static class BankAppHelpers
    {


        public static int RandomizeAcctId()
        {
            Random r = new Random();
            int generateId = r.Next(0000, 2000);
            return generateId;
        }



        public static int RandomizeAcctNumber()
        {
            Random r = new Random();
            int generateNum = r.Next(1000000001, 2000000002);
            return generateNum;
        }

        public static void BankOps(string cmd, BankAccount act)
        {
            switch (cmd)
            {
                case "1":
                    Console.WriteLine("Enter amount: ");
                    string amt = Console.ReadLine();
                    Console.WriteLine("Enter note: ");
                    string nt = Console.ReadLine();
                    act.Deposit(Convert.ToDecimal(amt), DateTime.Now, nt, "deposit");
                    Console.WriteLine(act.msg());
                    break;
                case "2":
                    act.Withdrawal(3000, DateTime.Now, "Airtime - Glo", "withdrwal");
                    Console.WriteLine(act.msg());

                    break;
                case "3":
                    Console.WriteLine(act.GetActReport());
                    break;
                default:
                    Console.WriteLine("thanks for banking with us");
                    break;
            }
        }

        /*
         if(cmd == "1"){

        }
         */

    }
}
