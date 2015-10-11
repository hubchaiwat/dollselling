using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrint
{
    namespace MyPrint12
    {
        class MyPrint12 : MyPrint
        {
            //Function สำหรับคืนค่าตำแหน่งของ X ในการพิมพ์เลขจำนวนเต็ม
            public static int getXNumber(int iXBegin, int iNumber)
            {
                if ((iNumber >= 10) && (iNumber < 100))
                    iXBegin = iXBegin - 8;
                else if ((iNumber >= 100) && (iNumber < 1000))
                    iXBegin = iXBegin - 17;
                else if ((iNumber >= 1000) && (iNumber < 10000))
                    iXBegin = iXBegin - 31;
                else if ((iNumber >= 10000) && (iNumber < 100000))
                    iXBegin = iXBegin - 40;
                else if ((iNumber >= 100000) && (iNumber < 1000000))
                    iXBegin = iXBegin - 49;
                else if ((iNumber >= 1000000) && (iNumber < 10000000))
                    iXBegin = iXBegin - 62;
                else if ((iNumber >= 10000000) && (iNumber < 100000000))
                    iXBegin = iXBegin - 72;
                else if ((iNumber >= 100000000) && (iNumber < 1000000000))
                    iXBegin = iXBegin - 80;
                else if (iNumber >= 1000000000)
                    iXBegin = iXBegin - 94;
                return iXBegin;
            }

            //Function สำหรับคืนค่าตำแหน่งของ X ในการพิมพ์สำหรับเลขที่เป็นจำนวนเงิน
            public static int getXCurrency(int iXBegin, double dbCurrency)
            {
                if ((dbCurrency >= 10.0) && (dbCurrency < 100.0))
                {
                    iXBegin = iXBegin - 8;
                }
                else if ((dbCurrency >= 100.0) && (dbCurrency < 1000.0))
                {
                    iXBegin = iXBegin - 17;
                }
                else if ((dbCurrency >= 1000.0) && (dbCurrency < 10000.0))
                {
                    iXBegin = iXBegin - 31;
                }
                else if ((dbCurrency >= 10000.0) && (dbCurrency < 100000.0))
                {
                    iXBegin = iXBegin - 40;
                }
                else if ((dbCurrency >= 100000.0) && (dbCurrency < 1000000.0))
                {
                    iXBegin = iXBegin - 49;
                }
                else if ((dbCurrency >= 1000000.0) && (dbCurrency < 10000000.0))
                {
                    iXBegin = iXBegin - 63;
                }
                else if ((dbCurrency >= 10000000.0) && (dbCurrency < 100000000.0))
                {
                    iXBegin = iXBegin - 73;
                }
                else if ((dbCurrency >= 100000000.0) && (dbCurrency < 1000000000.0))
                {
                    iXBegin = iXBegin - 82;
                }
                else if ((dbCurrency >= 1000000000.0) && (dbCurrency < 10000000000.0))
                {
                    iXBegin = iXBegin - 95;
                }
                return iXBegin;
            }
        }
    }
}
