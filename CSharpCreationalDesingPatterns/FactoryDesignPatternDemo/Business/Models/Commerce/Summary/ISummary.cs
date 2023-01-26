using FactoryDesignPatternDemo.Business.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);

        void Send();
    }

    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is an email summary!";
        }

        public void Send()
        {
            Console.WriteLine("Sending the email summary...");
        }
    }

    public class CsvSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This,is,a,CSV,summary";
        }

        public void Send()
        {
            Console.WriteLine("Sending the CSV summary...");
        }
    }
}
