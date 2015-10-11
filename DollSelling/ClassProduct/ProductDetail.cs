using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product
{
    namespace ProductDetail
    {
        class ProductDetail : ProductBase, IProductDetail
        {
            public const string cstNotChooseColor = "User does not choose color.";
            public const string cstNotChooseUnit = "User does not choose unit.";
            public const string cstNotChooseSize = "User does not choose size.";

            private string m_strUnitCode;
            private double m_dbCost;
            private double m_dbPrice2;
            private string m_strSizeCode;
            private string m_strColorCode;

            public string UnitCode
            {
                get { return m_strUnitCode; }
                set { m_strUnitCode = value; }
            }

            public double Cost
            {
                get { return m_dbCost; }
                set { m_dbCost = value; }
            }

            public double Price2
            {
                get { return m_dbPrice2; }
                set { m_dbPrice2 = value; }
            }

            public string ColorCode
            {
                get { return m_strColorCode; }
                set { m_strColorCode = value; }
            }

            public string SizeCode
            {
                get { return m_strSizeCode; }
                set { m_strSizeCode = value; }
            }

            public ProductDetail()
            {
                m_strID = "";
                m_strBarcode = "";
                m_strName = "";
                m_dbPrice = 0.0d;
                m_strNote = "";
                m_strUnitCode = "";
                m_dbCost = 0.0d;
                m_dbPrice2 = 0.0d;
                m_strSizeCode = "";
                m_strColorCode = "";
            }

            public static string getUnitCode(int iIndex, string strUnitType)
            {
                string strUnitCode = "";

                if (iIndex == -1)
                {
                    strUnitCode = cstNotChooseUnit;
                }
                else
                {
                    if (strUnitType == "ตัว")
                        strUnitCode = "01";
                    else if (strUnitType == "ชิ้น")
                        strUnitCode = "02";
                }
                return strUnitCode;
            }

            public static string getColorCode(int iIndex, string strColorName)
            {
                string strColorCode = "";

                if (iIndex == -1)
                {
                    strColorCode = cstNotChooseColor;
                }
                else
                {
                    if (strColorName == "แดง")
                        strColorCode = "R";
                    else if (strColorName == "เหลือง")
                        strColorCode = "Y";
                    else if (strColorName == "ส้ม")
                        strColorCode = "O";
                    else if (strColorName == "เขียว")
                        strColorCode = "G";
                    else if (strColorName == "น้ำเงิน")
                        strColorCode = "B";
                    else if (strColorName == "ชมพู")
                        strColorCode = "PI";
                    else if (strColorName == "ม่วง")
                        strColorCode = "PP";
                    else if (strColorName == "น้ำตาล")
                        strColorCode = "BR";
                    else if (strColorName == "ดำ")
                        strColorCode = "BL";
                    else if (strColorName == "ขาว")
                        strColorCode = "W";
                    else if (strColorName == "ฟ้า")
                        strColorCode = "BK";
                }

                return strColorCode;
            }

            public static string getColorName(string strColorCode)
            {
                string strColorName = "";

                if (strColorCode == "R")
                    strColorName = "แดง";
                else if (strColorCode == "Y")
                    strColorName = "เหลือง";
                else if (strColorCode == "O")
                    strColorName = "ส้ม";
                else if (strColorCode == "G")
                    strColorName = "เขียว";
                else if (strColorCode == "B")
                    strColorName = "น้ำเงิน";
                else if (strColorCode == "PI")
                    strColorName = "ชมพู";
                else if (strColorCode == "BR")
                    strColorName = "น้ำตาล";
                else if (strColorCode == "BL")
                    strColorName = "ดำ";
                else if (strColorCode == "W")
                    strColorName = "ขาว";
                else if (strColorCode == "BK")
                    strColorName = "ฟ้า";

                return strColorName;
            }

            public static string getSizeCode(int iIndex, string strSizeName)
            {
                string strSizeCode = "";

                if (iIndex == -1)
                {
                    strSizeCode = cstNotChooseSize;
                }
                else
                {
                    if (strSizeName == "เล็ก")
                        strSizeCode = "S";
                    else if (strSizeName == "กลาง")
                        strSizeCode = "M";
                    else if (strSizeName == "ใหญ่")
                        strSizeCode = "L";
                }
                return strSizeCode;
            }

            public static string getSizeName(string strSizeCode)
            {
                string strSizeName = "";

                if (strSizeCode == "S")
                    strSizeName = "เล็ก";
                else if (strSizeCode == "M")
                    strSizeName = "กลาง";
                else if (strSizeCode == "L")
                    strSizeName = "ใหญ่";

                return strSizeName;
            }
        }
    }
}
