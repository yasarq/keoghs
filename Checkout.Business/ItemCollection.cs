using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Business
{

    public class ItemCollection : List<Item>
    {
        public ItemCollection() { }

        public void AddItem(Item newItem)
        {
            if (newItem == null)
                return;

            this.Add(newItem);
        }
    }
}
