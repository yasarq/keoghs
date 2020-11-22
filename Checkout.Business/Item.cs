using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Business
{
    public class Item : IItem
    {
        public PRODUCT PRODUCT { get; }
        public decimal UnitPrice { get; }
        public IPricing Promotion { get; }

        char IItem.PRODUCT => throw new NotImplementedException();

        decimal IItem.UnitPrice => throw new NotImplementedException();

        IPricing IItem.Promotion => throw new NotImplementedException();

        public Item(char sku, decimal unitPrice, IPricing promotion = null)
        {
            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero", nameof(unitPrice));

            PRODUCT = sku;
            UnitPrice = unitPrice;
            Promotion = promotion;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return PRODUCT == ((Item)obj).PRODUCT;
        }
    }
}
