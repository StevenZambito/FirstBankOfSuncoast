using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public int Amount { get; set; }
        public string TransactionType { get; set; }
        public string DestinationAccount { get; set; }

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

            var transactions = new List<Transaction>();

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

                        var newTransaction = new Transaction
                        {
                            Amount = checkingDepositAmount,
                            TransactionType = "Deposit",
                            DestinationAccount = "Checking"

                        };

                    }
                    if (userResponseChecking == "WITHDRAW")
                    {
                        var checkingWithdrawAmount = int.Parse(PromptForString("How much would you like to withdraw?"));
                        var newTransaction = new Transaction
                        {
                            Amount = checkingWithdrawAmount,
                            TransactionType = "Withdraw",
                            DestinationAccount = "Checking"

                        };
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
                        var savingsDepositAmount = int.Parse(PromptForString("How much would you like to deposit?"));
                        var newTransaction = new Transaction
                        {
                            Amount = savingsDepositAmount,
                            TransactionType = "Deposit",
                            DestinationAccount = "Savings"

                        };

                    }
                    if (userResponseSavings == "WITHDRAW")
                    {
                        var savingsWithdrawAmount = int.Parse(PromptForString("How much would you like to withdraw?"));
                        var newTransaction = new Transaction
                        {
                            Amount = savingsWithdrawAmount,
                            TransactionType = "Withdraw",
                            DestinationAccount = "Savings"

                        };

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
