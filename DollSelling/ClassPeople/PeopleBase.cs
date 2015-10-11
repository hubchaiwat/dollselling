using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People
{
    class PeopleBase : IPeopleBase
    {
        public const string cstNotChoosePrefix = "User does not choose prefix.";

        protected string m_strID;
        protected string m_strPrefix;
        protected string m_strName;
        protected string m_strAddress;
        protected string m_strTel;
        protected string m_strMobile;
        protected string m_strEmail;
        protected string m_strNote;

        public string ID
        {
            get { return m_strID; }
            set { m_strID = value; }
        }

        public string Prefix
        {
            get { return m_strPrefix; }
            set { m_strPrefix = value; }
        }

        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        public string Address
        {
            get { return m_strAddress; }
            set { m_strAddress = value; }
        }

        public string Tel
        {
            get { return m_strTel; }
            set { m_strTel = value; }
        }

        public string Mobile
        {
            get { return m_strMobile; }
            set { m_strMobile = value; }
        }

        public string Email
        {
            get { return m_strEmail; }
            set { m_strEmail = value; }
        }

        public string Note
        {
            get { return m_strNote; }
            set { m_strNote = value; }
        }

        public PeopleBase()
        {
            m_strID = "";
            m_strPrefix = "";
            m_strName = "";
            m_strAddress = "";
            m_strTel = "";
            m_strMobile = "";
            m_strEmail = "";
            m_strNote = "";
        }

        public static string getPrefix(int iIndex,string strChoosePrefix)
        {
            string strPrefix = "";

            if (iIndex == -1)
            {
                strPrefix = cstNotChoosePrefix;
            }
            else
            {
                strPrefix = strChoosePrefix;
            }

            return strPrefix;
        }
    }
}
