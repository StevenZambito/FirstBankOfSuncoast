using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

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
            Console.WriteLine();
            Console.WriteLine(prompt);

            var userInput = Console.ReadLine().ToUpper().Trim();
            return userInput;
        }
        static int CalculateBalance(List<Transaction> transactions)
        {
            var depositList = transactions.Where(transaction => transaction.TransactionType == "Deposit").ToList();
            var withdrawList = transactions.Where(transaction => transaction.TransactionType == "Withdraw").ToList();
            var depositTotal = 0;
            var withdrawTotal = 0;
            foreach (var element in depositList)
            {
                depositTotal += element.Amount;

            }
            foreach (var element in withdrawList)
            {
                withdrawTotal += element.Amount;

            }
            return depositTotal - withdrawTotal;
        }

        static void Main(string[] args)
        {
            // var transactions = new List<Transaction>();
            var fileReader = new StreamReader("transactions.csv");
            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

            var transactions = csvReader.GetRecords<Transaction>().ToList();

            var userHasChosenToQuit = false;

            BannerMessage("First Bank of Suncoast");

            while (userHasChosenToQuit == false)
            {
                Console.WriteLine("------------");
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("Checking");
                Console.WriteLine("Savings");
                Console.WriteLine("Transactions");
                Console.WriteLine("Quit");
                Console.WriteLine("------------");

                var userResponse = PromptForString("Please choose a menu option");

                if (userResponse == "CHECKING")
                {
                    var checkingList = transactions.Where(x => x.DestinationAccount == "Checking").ToList();
                    var checkingBalance = CalculateBalance(checkingList);
                    Console.WriteLine();
                    Console.WriteLine($"Account balance: {checkingBalance}");

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

                        transactions.Add(newTransaction);

                        Console.WriteLine();
                        Console.WriteLine($"${checkingDepositAmount} was deposited into your checking account.");
                        Console.WriteLine();
                    }

                    if (userResponseChecking == "WITHDRAW")
                    {
                        var checkingWithdrawAmount = int.Parse(PromptForString("How much would you like to withdraw?"));

                        if (checkingBalance >= checkingWithdrawAmount)
                        {
                            var newTransaction = new Transaction
                            {
                                Amount = checkingWithdrawAmount,
                                TransactionType = "Withdraw",
                                DestinationAccount = "Checking"
                            };

                            transactions.Add(newTransaction);

                            Console.WriteLine();
                            Console.WriteLine($"${checkingWithdrawAmount} was withdrawn from your checking account.");
                            Console.WriteLine();
                        }

                        else if (checkingBalance < checkingWithdrawAmount)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"You do not have ${checkingWithdrawAmount} in your checking account to withdraw.");
                            Console.WriteLine();
                        }
                    }

                    if (userResponseChecking == "QUIT")
                    {
                        userHasChosenToQuit = true;
                    }
                }

                if (userResponse == "SAVINGS")
                {
                    var savingsList = transactions.Where(x => x.DestinationAccount == "Savings").ToList();
                    var savingsBalance = CalculateBalance(savingsList);
                    Console.WriteLine();
                    Console.WriteLine($"Account balance: {savingsBalance}");

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

                        transactions.Add(newTransaction);

                        Console.WriteLine();
                        Console.WriteLine($"${savingsDepositAmount} was deposited into your savings account.");
                        Console.WriteLine();

                    }
                    if (userResponseSavings == "WITHDRAW")
                    {
                        var savingsWithdrawAmount = int.Parse(PromptForString("How much would you like to withdraw?"));
                        if (savingsBalance >= savingsWithdrawAmount)
                        {
                            var newTransaction = new Transaction
                            {
                                Amount = savingsWithdrawAmount,
                                TransactionType = "Withdraw",
                                DestinationAccount = "Savings"

                            };

                            transactions.Add(newTransaction);

                            Console.WriteLine();
                            Console.WriteLine($"${savingsWithdrawAmount} was withdrawn from your savings account.");
                            Console.WriteLine();
                        }

                        else if (savingsBalance < savingsWithdrawAmount)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"You do not have ${savingsWithdrawAmount} in your checking account to withdraw.");
                            Console.WriteLine();
                        }
                    }

                    if (userResponseSavings == "QUIT")
                    {
                        userHasChosenToQuit = true;
                    }
                }

                if (userResponse == "TRANSACTIONS")
                {
                    var userResponseTransactions = PromptForString("Which account would you like to see transactions for? Checking or Savings?");

                    if (userResponseTransactions == "CHECKING")
                    {
                        var checkingTransactions = transactions.Where(x => x.DestinationAccount == "Checking");
                        foreach (var transaction in checkingTransactions)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Transaction Type: {transaction.TransactionType}");
                            Console.WriteLine($"Amount: {transaction.Amount}");

                        }
                    }

                    if (userResponseTransactions == "SAVINGS")
                    {
                        var savingsTransactions = transactions.Where(x => x.DestinationAccount == "Savings");
                        foreach (var transaction in savingsTransactions)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Transaction Type: {transaction.TransactionType}");
                            Console.WriteLine($"Amount: {transaction.Amount}");

                        }
                    }

                    if (userResponseTransactions == "QUIT")
                    {
                        userHasChosenToQuit = true;
                    }
                }

                if (userResponse == "QUIT")
                {
                    userHasChosenToQuit = true;
                }
            }

            var fileWriter = new StreamWriter("transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(transactions);
            fileWriter.Close();

            BannerMessage("Goodbye, Have a nice day!");
        }
    }
}
