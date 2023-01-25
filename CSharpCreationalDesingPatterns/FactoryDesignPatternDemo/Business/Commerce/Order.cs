﻿using FactoryDesignPatternDemo.Business.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Business.Commerce
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal Total => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        public Address Recipient { get; set; }

        public Address Sender { get; set; }

        public decimal TotalWeight { get; set; }
    }

    public class Address
    {
        public string To { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}
