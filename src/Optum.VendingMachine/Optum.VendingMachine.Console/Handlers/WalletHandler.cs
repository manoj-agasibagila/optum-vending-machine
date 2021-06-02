using Optum.VendingMachine.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optum.VendingMachine.ConsoleApp
{
    public class WalletHandler
    {
        public static void DisplayCoins()
        {
            Console.WriteLine("Insert coins of below denominations");
            Console.WriteLine("1. Nickel");
            Console.WriteLine("2. Dime");
            Console.WriteLine("3. Quarter");
            Console.WriteLine("INSERT COIN.....");
        }

        public static bool AcceptCoin(ref double TotalAmount)
        {
            var coin = int.Parse(Console.ReadLine());
            bool invalidInsert = false;
            switch (coin)
            {
                case (int)Coins.Nickel:
                    TotalAmount += 0.05;
                    break;
                case (int)Coins.Dime:
                    TotalAmount += 0.1;
                    break;
                case (int)Coins.Quarter:
                    TotalAmount += 0.25;
                    break;
                default:
                    invalidInsert = true;
                    break;
            }

            if (invalidInsert)
                Console.WriteLine("INVALID COIN...please insert valid coins");
            else
                Console.WriteLine($"Amount in your wallet: ${TotalAmount}");

            return invalidInsert;
        }

        public static bool Continue()
        {
            bool proceed = false;
            Console.WriteLine("Do you want insert more coins? Y/N");
            var response = Console.ReadLine().ToUpper();

            switch (response)
            {
                case "Y":
                case "YES":
                    proceed = true;
                    break;
                case "N":
                case "NO":
                    break;
                default:
                    break;
            }

            return proceed;
        }
    }
}
