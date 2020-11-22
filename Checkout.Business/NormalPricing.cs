using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Business
{

    public abstract class NormalPricing : IPricing
    {
        public abstract PRODUCT Sku { get; }
        protected abstract decimal Price { get; }
        public decimal GetPrice(int count)
        {
            return Price * count;
        }
    }

    public class PricingProductTypeA : NormalPricing
    {
        public override PRODUCT Sku { get; } = 'A';
        protected override decimal Price { get; } = 10;
    }

    public class PricingProductTypeC : NormalPricing
    {
        public override PRODUCT Sku { get; } = 'C';
        protected override decimal Price { get; } = 40;
    }
}
