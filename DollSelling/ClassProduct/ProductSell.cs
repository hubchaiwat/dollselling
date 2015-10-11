using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    namespace ProductSell
    {
        class ProductSell : ProductBase, IProductSell
        {
            private int m_iAmount;
            private double m_dbDiscount;
            private double m_dbTotalPrice;

            public int Amount
            {
                get { return m_iAmount; }
                set { m_iAmount = value; }
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

            public ProductSell()
            {
                m_strID = "";
                m_strBarcode = "";
                m_strName = "";
                m_dbPrice = 0.0d;
                m_strNote = "";
                m_iAmount = 0;
                m_dbDiscount = 0.0d;
                m_dbTotalPrice = 0.0d;
            }
        }
    }
}
