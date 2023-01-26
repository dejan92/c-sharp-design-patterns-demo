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
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);

            var invoice = purchaseProviderFactory.CreateInvoice(order);

            // Send the invoice to the customer :)\

            var summary = purchaseProviderFactory.CreateSummary(order);

            summary.Send();

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }

}
