using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bill
{
    interface IBillBase
    {
        int BillNumber
        {
            get;
            set;
        }

        string SellDate
        {
            get;
            set;
        }

        string CustomerID
        {
            get;
            set;
        }

        string CustomerName
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
