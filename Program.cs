using System;

namespace ConsoleBankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //BankAccount acct = new BankAccount("Alex", 12330);
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter init Bal: ");
            decimal amt = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Choose '0' for Savings, '1' for Current:");
            string type = Console.ReadLine();

            try
            {

                if (amt <= 0)
                {
                    throw new ArgumentOutOfRangeException("negative amount input!");
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }

            try
            {
                if (name.Length < 2)
                {
                    throw new InvalidOperationException("name cant be empty input!");

                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Name Length too short");
                Console.WriteLine(e.ToString());
                return;
            }

            var acct = new BankAccount(name, amt, DateTime.Now, type);


            Console.WriteLine("Press\n 1. for deposit  \n 2. for Withdrawal \n 3. for Account statement\n");




            //while ( Console.ReadKey().Key != ConsoleKey.E)
            //{
            Console.WriteLine("\nPress 'E' to exit the process...");
            do
            {
                string cmd = Console.ReadLine();
                BankAppHelpers.BankOps(cmd, acct);

                Console.ReadKey();

            } while (Console.ReadKey().Key != ConsoleKey.E);

            //}
            //implement savins current

        }
    }
}
