using System;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public int Checking { get; set; }
        public int Savings { get; set; }

        // public int Deposit(int num)
        // {

        // }

        // public int Withdraw(int num)
        // {

        // }
    }
    class Program
    {
        static void BannerMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine(message);
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);

            var userInput = Console.ReadLine().ToUpper().Trim();
            return userInput;
        }


        static void Main(string[] args)
        {
            var userHasChosenToQuit = false;

            while (userHasChosenToQuit == false)
            {
                BannerMessage("First Bank of Suncoast");

                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("Checking");
                Console.WriteLine("Savings");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Quit");
                Console.WriteLine();

                var userResponse = PromptForString("Checking or Savings?");

                if (userResponse == "CHECKING")
                {
                    Console.WriteLine();
                    Console.WriteLine("Deposit");
                    Console.WriteLine("Withdraw");
                    Console.WriteLine();
                    var userResponseChecking = PromptForString("Deposit or Withdraw?");

                    if (userResponseChecking == "DEPOSIT")
                    {
                        var checkingDepositAmount = int.Parse(PromptForString("How much would you like to deposit?"));
                    }
                    if (userResponseChecking == "WITHDRAW")
                    {
                        var checkingDepositAmount = int.Parse(PromptForString("How much would you like to deposit?"));
                    }
                    if (userResponseChecking == "QUIT")
                    {
                        userHasChosenToQuit = true;
                    }
                }

                if (userResponse == "SAVINGS")
                {
                    Console.WriteLine();
                    Console.WriteLine("Deposit");
                    Console.WriteLine("Withdraw");
                    Console.WriteLine();
                    var userResponseSavings = PromptForString("Deposit or Withdraw?");

                    if (userResponseSavings == "DEPOSIT")
                    {

                    }
                    if (userResponseSavings == "WITHDRAW")
                    {

                    }
                    if (userResponseSavings == "QUIT")
                    {
                        userHasChosenToQuit = true;
                    }


                }

                if (userResponse == "QUIT")
                {
                    userHasChosenToQuit = true;
                }
            }

            BannerMessage("Goodbye, Have a nice day!");
        }
    }
}
