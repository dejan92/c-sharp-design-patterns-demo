using FactoryDesignPatternDemo.Business.Commerce;
using FactoryDesignPatternDemo.Business.Models.Commerce.Invoice;
using FactoryDesignPatternDemo.Business.Models.Commerce.Summary;
using FactoryDesignPatternDemo.Business.Shipping;
using FactoryDesignPatternDemo.Business.Shipping.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }

    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }

    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new EmailSummary();
        }
    }
}
