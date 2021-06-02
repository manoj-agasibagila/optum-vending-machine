using Optum.VendingMachine.Domain;
using System;
using Optum.VendingMachine.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Optum.VendingMachine.ConsoleApp
{
    class Program
    {
        private static readonly IReadOnlyList<Product> _products;

        static Program()
        {
            var dao = new ProductDao();
            _products = dao.GetProducts();
        }

        private static double totalAmount;
        private static bool reset = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Optum Self Service!!");
            Console.WriteLine("Start by loading money to your wallet");
            
            while (true)
            {
                if(reset)
                {
                    Reset();
                    break;
                }

                HandleWallet();

                HandleProducts();
                
            }
            Console.ReadKey();
        }

        private static void HandleWallet()
        {
            while (true)
            {
                WalletHandler.DisplayCoins();
                if (WalletHandler.AcceptCoin(ref totalAmount))
                    continue;
                if (!WalletHandler.Continue())
                    break;
            }
        }

        private static void HandleProducts()
        {
            while (true)
            {
                ProductHandler.DisplayProducts();
                var productId = int.Parse(Console.ReadLine());
                var product = _products.FirstOrDefault(x => x.Id == productId);
                if (!ProductHandler.ValidateProductInput(product))
                {
                    Console.WriteLine("Invalid product selection");
                    continue;
                }

                if (!ProductHandler.ValidateProductPrice(product, totalAmount))
                {
                    Console.WriteLine($"You are short of ${product.Price - totalAmount} to buy this product.");
                    Console.WriteLine("Do you prefer to load more money to your wallet? Y/N");
                    var input = Console.ReadLine().ToUpper();
                    if (input == "Y" || input == "YES")
                        break;
                    else
                    {
                        reset = true;
                        break;
                    }
                }

                OrderHandler.BuyProduct(product, ref totalAmount);

                if (!OrderHandler.BuyMore())
                {
                    reset = true;
                    break;
                }
            }
        }

        private static void Reset()
        {
            if (totalAmount != 0)
            {
                Console.WriteLine($"Please collect remaining coins in your wallet worth ${totalAmount}");
            }
            Console.WriteLine("Thanks for visiting!!!");
            totalAmount = 0;
        }
    }
}
