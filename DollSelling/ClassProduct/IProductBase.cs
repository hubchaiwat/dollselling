using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    public interface IProductBase
    {
        string ID
        {
            get;
            set;
        }
        
        string Name
        {
            get;
            set;
        }

        string Barcode
        {
            get;
            set;
        }

        double Price
        {
            get;
            set;
        }
    }
}
