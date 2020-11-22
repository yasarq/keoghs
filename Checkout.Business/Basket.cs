using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Business
{

    public class Basket : IBasket
    {

        private List<IPricing> _promoItems;

        public Basket(List<IPricing> promoItems)
        {
            _promoItems = promoItems;
        }
        ///// <summary>
        ///// add an item to basket 
        ///// </summary>
        ///// <param name="item">Item to add to the basket</param>
        //public void AddToCart(IItem item)
        //{
        //    if (item == null)
        //        throw new ArgumentNullException(nameof(item));

        //    _items.Add(item);
        //}

        ///// <summary>
        ///// Calculates the total cost of all items in the basket
        ///// </summary>
        ///// <returns>Total price of all items including any discount</returns>
        //public decimal GetTotalCart()
        //{
        // TODO// calculate total with offers
        //    return basketTotal;
        //}


        public decimal Checkout(IList<PRODUCT> products)
        {
            decimal result = 0;
            foreach (var item in _promoItems)
            {
                var prods = products.Where(p => p == item.Sku);
                result = result + item.GetPrice(prods.Count());
            }

            return result;
        }
    }
}
