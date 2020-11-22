using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Interfaces;
namespace Checkout.Interfaces
{
    public interface IPricing
    {
        decimal GetPrice(int count);
        PRODUCT Sku { get; }

    }
}
