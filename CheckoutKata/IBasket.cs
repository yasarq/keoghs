using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interfaces
{
    public interface IBasket
    {
        decimal Checkout(IList<PRODUCT> products);
        //  void RemoveItemFromBasket(IItem item);

        /*ideally separate checkout (adding items to basket and get total)*/
    }
}
