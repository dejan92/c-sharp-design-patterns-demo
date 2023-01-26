using FactoryDesignPatternDemo.Business.Commerce;
using FactoryDesignPatternDemo.Business.Shipping;
using FactoryDesignPatternDemo.Business.Shipping.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = shippingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }

}
