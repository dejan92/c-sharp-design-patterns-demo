using FactoryDesignPatternDemo.Business.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatternDemo.Business.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
