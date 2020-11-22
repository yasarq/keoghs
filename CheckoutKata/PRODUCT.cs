using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interfaces
{
    public struct PRODUCT
    {
        private char _value;

        public PRODUCT(char value)
        {
            _value = value;
        }

        public PRODUCT(PRODUCT sku)
        {
            _value = sku._value;
        }

        public static implicit operator PRODUCT(char v)
        {
            return new PRODUCT(v);
        }

        public static explicit operator char(PRODUCT v)
        {
            return v._value;
        }

        public static bool operator ==(PRODUCT sku1, PRODUCT sku2)
        {
            return sku1.Equals(sku2);
        }

        public static bool operator !=(PRODUCT sku1, PRODUCT sku2)
        {
            return !sku1.Equals(sku2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            PRODUCT sku;
            try
            {
                sku = (PRODUCT)obj;
            }
            catch
            {
                return false;
            }

            return _value == (char)sku;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
