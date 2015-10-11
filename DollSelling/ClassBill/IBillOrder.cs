using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bill
{
    interface IBillOrder
    {
        string EmployeeName
        {
            get;
            set;
        }

        string ProductID
        {
            get;
            set;
        }

        string ProductName
        {
            get;
            set;
        }

        int Amount
        {
            get;
            set;
        }
    }
}
