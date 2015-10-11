using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    class ProductBase : IProductBase
    {
        protected string m_strID;
        protected string m_strBarcode;
        protected string m_strName;
        protected double m_dbPrice;
        protected string m_strNote;

        public string ID
        {
            get { return m_strID; }
            set {m_strID = value;}
        }

        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        public string Barcode
        {
            get { return m_strBarcode; }
            set { m_strBarcode = value; }
        }

        public double Price
        {
            get { return m_dbPrice; }
            set { m_dbPrice = value; }
        }

        public string Note
        {
            get { return m_strNote; }
            set { m_strNote = value; }
        }

        public ProductBase()
        {
            m_strID = "";
            m_strBarcode = "";
            m_strName = "";
            m_dbPrice = 0.0d;
            m_strNote = "";
        }
    }
}
