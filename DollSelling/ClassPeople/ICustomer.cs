using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People
{
    namespace Customer
    {
        interface ICustomer
        {

            string Fax
            {
                get;
                set;
            }

            string Reciever
            {
                get;
                set;
            }

            string Job
            {
                get;
                set;
            }
        }
    }
}
