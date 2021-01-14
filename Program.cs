using System;

namespace FirstBankOfSuncoast
{
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

                if (userResponse == "QUIT")
                {
                    userHasChosenToQuit = true;
                }
            }

            BannerMessage("Have a nice day!");
        }
    }
}
