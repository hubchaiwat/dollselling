using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFormat
{
    class NumberFormat
    {
        //Function สำหรับคืนค่าเลขจำนวนเต็มชนิด String แบบ Comma
        public static string getStringNumber(int iNumber)
        {

            if (iNumber < 10)
            {
                return iNumber.ToString();
            }

            double dbTemp = 0.0d;
            dbTemp = dbTemp + iNumber;

            return string.Format("{0:0,0}", dbTemp);
        }

        //Function สำหรับคืนค่าเลขจำนวนจริงชนิด String แบบ Comma
        public static string getStringCurrency(double dbCurrency)
        {
            return string.Format("{0:N}", dbCurrency);
        }
    }
}
