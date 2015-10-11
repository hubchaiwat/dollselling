using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bill
{
    namespace BillOrder
    {
        class BillOrder : BillBase, IBillOrder
        {
            private string m_strEmployeeName;
            private string m_strProductID;
            private string m_strProductName;
            private int m_iAmount;

            public string EmployeeName
            {
                get { return m_strEmployeeName; }
                set { m_strEmployeeName = value; }
            }

            public string ProductID
            {
                get { return m_strProductID; }
                set { m_strProductID = value; }
            }

            public string ProductName
            {
                get { return m_strProductName; }
                set { m_strProductName = value; }
            }

            public int Amount
            {
                get { return m_iAmount; }
                set { m_iAmount = value; }
            }

            public BillOrder()
            {
                m_iBillNumber = 0;
                m_strSellDate = "";
                m_strEmployeeName = "";
                m_strCustomerID = "";
                m_strCustomerName = "";
                m_strProductID = "";
                m_strProductName = "";
                m_iAmount = 0;
                m_dbDiscount = 0.0d;
                m_dbTotalPrice = 0.0d;
            }
        }
    }
}
