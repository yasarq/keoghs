using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interfaces
{
    public interface IItem
    {
        char PRODUCT { get; } /*ideally this should be of different type in real life */

        decimal UnitPrice { get; } /* choice of decimal is better than double to avoid future rounding errors */

        IPricing Promotion { get; }
    }
}
