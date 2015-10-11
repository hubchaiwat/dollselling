using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People
{
    interface IPeopleBase
    {
        string ID
        {
            get;
            set;
        }

        string Prefix
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }

        string Tel
        {
            get;
            set;
        }

        string Mobile
        {
            get;
            set;
        }

        string Email
        {
            get;
            set;
        }

        string Note
        {
            get;
            set;
        }
    }
}
