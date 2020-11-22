using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Business
{
    public abstract class PromotionalPricing : IPricing
    {
        public abstract PRODUCT Sku { get; }

        protected abstract decimal UnitPrice { get; }
        protected abstract decimal DiscountPrice { get; }
        protected abstract int QtyForDiscount { get; }

        public decimal GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            decimal result = 0;

            while (count >= QtyForDiscount)
            {
                result = result + DiscountPrice;
                count = count - QtyForDiscount;
            }

            return result + (UnitPrice * count);
        }
    }

    public class PricingProductTypeB : PromotionalPricing
    {
        public override PRODUCT Sku { get; } = 'B';
        protected override decimal UnitPrice { get; } = 15;
        protected override decimal DiscountPrice { get; } = 40;
        protected override int QtyForDiscount { get; } = 3;
    }

    public class PricingProductTypeD : PromotionalPricing
    {
        public override PRODUCT Sku { get; } = 'D';
        protected override decimal UnitPrice { get; } = 55;
        protected override decimal DiscountPrice { get; } = (55 * 2) - ((55 * 2) * ((decimal)25 / 100));
        protected override int QtyForDiscount { get; } = 2;
    }
}
