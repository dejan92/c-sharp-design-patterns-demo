using FactoryDesignPatternDemo.Business.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Test
{
    public abstract class OrderFactory
    {
        protected abstract Order CreateOrder();

        public Order GetOrder()
        {
            var order = CreateOrder();

            order.LineItems.Add(
                new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1
            );

            order.LineItems.Add(
                new Item("CONSULTING", "Build a website", decimal.One), 1
            );

            return order;
        }
    }

    public class StandardOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Dejan Jovanov",
                    Country = "Australia"
                },
                Sender = new Address
                {
                    To = "Elena Jovanov",
                    Country = "Australia"
                },
                TotalWeight = 1
            };

            return order;
        }
    }
    
    public class InternationalOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Dejan Jovanov",
                    Country = "Australia"
                },
                Sender = new Address
                {
                    To = "Elena Jovanov",
                    Country = "Sweden"
                },
                TotalWeight = 11
            };

            return order;
        }
    }
}
