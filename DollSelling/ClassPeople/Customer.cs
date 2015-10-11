using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace People
{
    namespace Customer
    {
        class Customer : PeopleBase, ICustomer
        {
            private string m_strFax;
            private string m_strReciever;
            private string m_strJob;

            public string Fax
            {
                get { return m_strFax; }
                set { m_strFax = value; }
            }

            public string Reciever
            {
                get { return m_strReciever; }
                set { m_strReciever = value; }
            }

            public string Job
            {
                get { return m_strJob; }
                set { m_strJob = value; }
            }

            public Customer()
            {
                m_strID = "";
                m_strPrefix = "";
                m_strName = "";
                m_strAddress = "";
                m_strTel = "";
                m_strMobile = "";
                m_strEmail = "";
                m_strNote = "";
                m_strFax = "";
                m_strReciever = "";
                m_strJob = "";
            }
        }
    }
}
