using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bill
{
    class BillBase : IBillBase
    {
        protected int m_iBillNumber;
        protected string m_strSellDate;
        protected string m_strCustomerID;
        protected string m_strCustomerName;
        protected double m_dbDiscount;
        protected double m_dbTotalPrice;

        public int BillNumber
        {
            get { return m_iBillNumber; }
            set { m_iBillNumber = value; }
        }

        public string SellDate
        {
            get { return m_strSellDate; }
            set { m_strSellDate = value; }
        }

        public string CustomerID
        {
            get { return m_strCustomerID; }
            set { m_strCustomerID = value; }
        }

        public string CustomerName
        {
            get { return m_strCustomerName; }
            set { m_strCustomerName = value; }
        }

        public double Discount
        {
            get { return m_dbDiscount; }
            set { m_dbDiscount = value; }
        }

        public double TotalPrice
        {
            get { return m_dbTotalPrice; }
            set { m_dbTotalPrice = value; }
        }

        public BillBase()
        {
            m_iBillNumber = 0;
            m_strSellDate = "";
            m_strCustomerID = "";
            m_strCustomerName = "";
            m_dbDiscount = 0.0d;
            m_dbTotalPrice = 0.0d;
        }
    }
}
