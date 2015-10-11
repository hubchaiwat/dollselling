using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    namespace ProductSell
    {
        interface IProductSell
        {
            int Amount
            {
                get;
                set;
            }

            double Discount
            {
                get;
                set;
            }

            double TotalPrice
            {
                get;
                set;
            }
        }
    }
}
