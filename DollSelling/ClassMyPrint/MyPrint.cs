using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyPrint
{
    class MyPrint
    {
        //Function สำหรับเปลี่ยนวันที่จากปีค.ศ.เป็นพ.ศ.
        public static string getDateBD(string strDateAD)
        {
            string strDateBD = "";

            int iDay = getDayFromTextDate(strDateAD);
            int iMonth = getMonthFromTextDate(strDateAD);
            int iYear = getYearFromTextDate(strDateAD) + 543;

            strDateBD = makeDatePrint(iDay, iMonth, iYear);

            return strDateBD;
        }

        //Function สำหรับเปลี่ยนวันที่จากปีค.ศ.เป็นพ.ศ.
        public static string getDateAD(string strDateBD)
        {
            string strDateAD = "";

            int iDay = getDayFromTextDate(strDateBD);
            int iMonth = getMonthFromTextDate(strDateBD);
            int iYear = getYearFromTextDate(strDateBD) - 543;

            strDateAD = makeDatePrint(iDay, iMonth, iYear);

            return strDateAD;
        }

        //Function สำหรับสร้างข้อความวันที่เพื่อ Transaction
        public static string makeDateTransaction(int intDay, int intMonth, int intYear)
        {
            string strDate = "";

            //if (CultureInfo.CurrentCulture.ToString() == "th-TH")
            //    intYear = intYear - 543;

            strDate = strDate + "#" + intYear.ToString() + "/" + intMonth.ToString() + "/" + intDay.ToString() + "#";

            return strDate;
        }

        //Function สำหรับสร้างวันที่ในการพิมพ์
        public static string makeDatePrint(int intDay, int intMonth, int intYear)
        {
            string strDate = "";

            //สร้างวันที่
            if (intDay < 10)
            {
                strDate = strDate + "0";
            }

            strDate = strDate + intDay.ToString() + "/";

            //สร้างเดือน
            if (intMonth < 10)
            {
                strDate = strDate + "0";
            }

            strDate = strDate + intMonth.ToString() + "/";

            //สร้างปี
            intYear = intYear + 543;
            if (intYear < 10)
            {
                strDate = strDate + "000";
            }
            else if (intYear < 100)
            {
                strDate = strDate + "00";
            }
            else if (intYear < 1000)
            {
                strDate = strDate + "0";
            }

            strDate = strDate + intYear.ToString();

            return strDate;
        }

        //Function สำหรับสร้างวันที่ในการพิมพ์แบบปีเลข 2 หลัก
        public static string makeDatePrintShortYear(int intDay, int intMonth, int intYear)
        {
            string strDate = "";

            //สร้างวันที่
            if (intDay < 10)
            {
                strDate = strDate + "0";
            }

            strDate = strDate + intDay.ToString() + "/";

            //สร้างเดือน
            if (intMonth < 10)
            {
                strDate = strDate + "0";
            }

            strDate = strDate + intMonth.ToString() + "/";

            //สร้างปี
            intYear = intYear + 543;
            string strYear = "";
            if (intYear < 10)
            {
                strYear = strYear + "000";
            }
            else if (intYear < 100)
            {
                strYear = strYear + "00";
            }
            else if (intYear < 1000)
            {
                strYear = strYear + "0";
            }

            strYear = strYear + intYear.ToString();
            strYear = strYear.Substring(2, 2);

            strDate = strDate + strYear;

            return strDate;
        }

        //Function สำหรับสกัดวันที่ชนิด Integer ออกจากข้อความวันที่ชนิด String
        public static int getDayFromTextDate(string strDate)
        {
            int intDay = 0;
            string strDay = "";

            //สกัดวันที่ออกจากข้อความ
            strDay = strDate.Substring(0, 2);

            //แปลงค่าจากตัวอักษรเป็นตัวเลขให้กับ intDay
            intDay = int.Parse(strDay);

            return intDay;
        }

        //Function สำหรับสกัดเดือนชนิด Integer ออกจากข้อความวันที่ชนิด String
        public static int getMonthFromTextDate(string strDate)
        {
            int intMonth = 0;
            string strMonth = "";

            //สกัดวันที่ออกจากข้อความ
            strMonth = strDate.Substring(3, 2);

            //แปลงค่าจากตัวอักษรเป็นตัวเลขให้กับ intDay
            intMonth = int.Parse(strMonth);

            return intMonth;
        }

        //Function สำหรับสกัดปีชนิด Integer ออกจากข้อความวันที่ชนิด String
        public static int getYearFromTextDate(string strDate)
        {
            int intYear = 0;
            string strYear = "";

            //สกัดวันที่ออกจากข้อความ
            strYear = strDate.Substring(6, 4);

            //แปลงค่าจากตัวอักษรเป็นตัวเลขให้กับ intDay
            intYear = int.Parse(strYear);

            return intYear;
        }
    }
}
