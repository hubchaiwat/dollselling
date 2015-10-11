using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    namespace ProductDetail
    {
        interface IProductDetail
        {
            string UnitCode
            {
                get;
                set;
            }

            double Cost
            {
                get;
                set;
            }

            double Price2
            {
                get;
                set;
            }

            string ColorCode
            {
                get;
                set;
            }

            string SizeCode
            {
                get;
                set;
            }
        }
    }
}
