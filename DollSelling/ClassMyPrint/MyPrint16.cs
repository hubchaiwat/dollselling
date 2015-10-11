using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrint
{
    namespace MyPrint16
    {
        class MyPrint16 : MyPrint
        {
            //Function สำหรับคืนค่าตำแหน่งของ X ในการพิมพ์เลขจำนวนเต็ม
            public static int getXNumber(int iXBegin, int iNumber)
            {
                if ((iNumber >= 10) && (iNumber < 100))
                    iXBegin = iXBegin - 12;
                else if ((iNumber >= 100) && (iNumber < 1000))
                    iXBegin = iXBegin - 23;
                else if ((iNumber >= 1000) && (iNumber < 10000))
                    iXBegin = iXBegin - 43;
                else if ((iNumber >= 10000) && (iNumber < 100000))
                    iXBegin = iXBegin - 54;
                else if ((iNumber >= 100000) && (iNumber < 1000000))
                    iXBegin = iXBegin - 66;
                else if ((iNumber >= 1000000) && (iNumber < 10000000))
                    iXBegin = iXBegin - 85;
                else if ((iNumber >= 10000000) && (iNumber < 100000000))
                    iXBegin = iXBegin - 97;
                else if ((iNumber >= 100000000) && (iNumber < 1000000000))
                    iXBegin = iXBegin - 107;
                else if (iNumber >= 1000000000)
                    iXBegin = iXBegin - 125;
                return iXBegin;
            }

            //Function สำหรับคืนค่าตำแหน่งของ X ในการพิมพ์สำหรับเลขที่เป็นจำนวนเงิน
            public static int getXCurrency(int iXBegin, double dbCurrency)
            {
                if ((dbCurrency >= 1.0) && (dbCurrency < 10.0))
                {
                    iXBegin = iXBegin + 13;
                }
                else if ((dbCurrency >= 100.0) && (dbCurrency < 1000.0))
                {
                    iXBegin = iXBegin - 10;
                }
                else if ((dbCurrency >= 1000.0) && (dbCurrency < 10000.0))
                {
                    iXBegin = iXBegin - 30;
                }
                else if ((dbCurrency >= 10000.0) && (dbCurrency < 100000.0))
                {
                    iXBegin = iXBegin - 42;
                }
                else if ((dbCurrency >= 100000.0) && (dbCurrency < 1000000.0))
                {
                    iXBegin = iXBegin - 55;
                }
                else if ((dbCurrency >= 1000000.0) && (dbCurrency < 10000000.0))
                {
                    iXBegin = iXBegin - 75;
                }
                else if ((dbCurrency >= 10000000.0) && (dbCurrency < 100000000.0))
                {
                    iXBegin = iXBegin - 87;
                }
                else if ((dbCurrency >= 100000000.0) && (dbCurrency < 1000000000.0))
                {
                    iXBegin = iXBegin - 99;
                }
                else if ((dbCurrency >= 1000000000.0) && (dbCurrency < 10000000000.0))
                {
                    iXBegin = iXBegin - 118;
                }
                return iXBegin;
            }
        }
    }
}
