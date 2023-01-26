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

            // Later to choose which provider factory based on some user input
            var cart = new ShoppingCart(order, new StandardShippingProviderFactory());

            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
            Console.ReadLine();
        }
    }
}
