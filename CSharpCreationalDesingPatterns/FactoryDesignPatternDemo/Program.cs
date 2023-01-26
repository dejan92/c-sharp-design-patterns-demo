using FactoryDesignPatternDemo.Business.Commerce;
using FactoryDesignPatternDemo.Business;
using System;
using System.Net;
using FactoryDesignPatternDemo.Business.Shipping.Factories;

namespace FactoryDesignPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Dejan Jovanov",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion

            IPurchaseProviderFactory purchaseProviderFactory;

            if (order.Sender.Country.ToLower() == "sweden")
            {
                purchaseProviderFactory = new SwedenPurchaseProviderFactory();
            }
            else if (order.Sender.Country.ToLower() == "australia")
            {
                purchaseProviderFactory = new AustraliaPurchaseProviderFactory();
            }
            else
            {
                throw new Exception("Sender country is not available!");
            }
            // Later to choose which provider factory based on some user input
            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
            Console.ReadLine();
        }
    }
}
