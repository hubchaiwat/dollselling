using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using MyPrint.MyPrint12;
using MyFormat;
using System.Globalization;

namespace DollSelling
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

#region Connecting
        //ประกาศตัวแปรออบเจ็กต์ OleDbConnection ชื่อว่า Conn
        OleDbConnection Conn = new OleDbConnection();

        //ประกาศค่าคงที่ string ชื่อว่า strConn เก็บข้อความเชื่อมต่อฐานข้อมูล
        private const string strConn = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Database\\mydollstore.mdb";

        //ประกาศฟังก์ชันสำหรับเปิดการเชื่อมต่อฐานข้อมูล
        private void OpenConnection()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                Conn.ConnectionString = strConn;
                Conn.Open();
            }
            catch
            {
                string strError = "";
                strError = strError + "ไฟล์ Database ของโปรแกรมได้รับความเสียหายค่ะ" + Environment.NewLine;
                strError = strError + "กรุณาตรวจสอบไฟล์ Database ของท่านอีกครั้งว่าไฟล์อยู่ในตำแหน่งที่ถูกต้องหรือไม่" + Environment.NewLine;
                strError = strError + "ตำแหน่งที่ถูกต้องของ Database คือ C:\\Database\\mydollstore.mdb" + Environment.NewLine;
                MessageBox.Show(strError, "ข้อผิดพลาด");
                this.Close();
            }

        }//End of function OpenConnection

        //ประกาศฟังก์ชันสำหรับปิดการเชื่อมต่อฐานข้อมูล
        private void CloseConnection()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ข้อผิดพลาด");
            }
        }
#endregion
        
        private void FormReport_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            
            dtpBegin.Format = DateTimePickerFormat.Custom;
            dtpBegin.CustomFormat = "dd/MM/yyyy";

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd/MM/yyyy";

            //dtpBegin.Text = "Jan 01, 1753";
            //printPreviewDialog1.ShowDialog();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private string getBeginDate()
        {
            string strBeginDay = "";

            int iDay = dtpBegin.Value.Day;
            int iMonth = dtpBegin.Value.Month;
            int iYear = dtpBegin.Value.Year;

            strBeginDay = MyPrint12.makeDatePrint(iDay, iMonth, iYear);

            return strBeginDay; 
        }

        private string getEndDate()
        {
            string strBeginDay = "";

            int iDay = dtpEnd.Value.Day;
            int iMonth = dtpEnd.Value.Month;
            int iYear = dtpEnd.Value.Year;

            strBeginDay = MyPrint12.makeDatePrint(iDay, iMonth, iYear);

            return strBeginDay;
        }

        private string getCustomerName(int iBillNumber)
        {
            string strCustomerName = "";
            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CustomerName");
            sb.Append(" FROM Bills");
            sb.Append(" WHERE BillNumber=@BillNumber");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            com.Parameters.Add("@BillNumber", OleDbType.BigInt).Value = iBillNumber;

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    strCustomerName = dt.Rows[0]["CustomerName"].ToString();
                }

                dr.Close();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message, "คำเตือน");
            }

            return strCustomerName;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //สำหรับทดสอบการพิมพ์ตัวเลขแบบมี comma
            //Font fnt = new Font("Tahoma", 12);
            //int iNumber = 1;
            //int yTarget = 100;
            //for (int i = 0; i < 10; i++)
            //{
            //    int iXNumber = MyPrint12.getXNumber(300, iNumber);
            //    string strNumber = NumberFormat.getStringNumber(iNumber);
            //    e.Graphics.DrawString(strNumber, fnt, Brushes.Black, iXNumber, yTarget);

            //    iNumber = iNumber * 10;
            //    yTarget = yTarget + fnt.Height;
            //}

            //Font fnt = new Font("Tahoma", 12);
            //double dbCurrency = 1.0d;
            //int yTarget = 100;
            //for (int i = 0; i < 10; i++)
            //{
            //    int iXCurrency = MyPrint12.getXCurrency(300, dbCurrency);
            //    string strNumber = NumberFormat.getStringCurrency(dbCurrency);
            //    e.Graphics.DrawString(strNumber, fnt, Brushes.Black, iXCurrency, yTarget);

            //    dbCurrency = dbCurrency * 10;
            //    yTarget = yTarget + fnt.Height;
            //}

            /***************************เริ่มกระบวนการออกรายงาน*****************************/
            ArrayList alDate = new ArrayList();

            Font fnt = new Font("Tahoma", 16);
            Point pPrintDate = new Point(550, 40);
            Point pDoll2U = new Point(350, 80);
            Point pHeader = new Point(190, 130);

            string strPrintDate = "วันที่พิมพ์ " + MyPrint12.makeDatePrint(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            string strPrintDoll2U = "Doll2U";
            string strHeader = "รายงานสรุปยอดขายตามช่วงเวลา";

            e.Graphics.DrawString(strPrintDate, fnt, Brushes.Black, pPrintDate);

            fnt = new Font("Tahoma", 30);
            e.Graphics.DrawString(strPrintDoll2U, fnt, Brushes.Black, pDoll2U);

            fnt = new Font("Tahoma", 22);
            e.Graphics.DrawString(strHeader, fnt, Brushes.Black, pHeader);

            fnt = new Font("Tahoma", 16);
            int YTarget = 150 + fnt.Height;
            e.Graphics.DrawString("ตั้งแต่วันที่ " + getBeginDate() + " ถึง " + getEndDate(), fnt, Brushes.Black, 220, YTarget);

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT FORMAT(SellDate,'dd/MM/yyyy') AS SellDate");
            sb.Append(" FROM Bills");
            sb.Append(" WHERE SellDate BETWEEN @Begin AND @End");
            sb.Append(" ORDER BY SellDate");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            int iDay = dtpBegin.Value.Day;
            int iMonth = dtpBegin.Value.Month;
            int iYear = dtpBegin.Value.Year;

            if (CultureInfo.CurrentCulture.ToString() == "th-TH")
                iYear = iYear + 543;
            com.Parameters.Add("@Begin", OleDbType.Date).Value = MyPrint12.makeDateTransaction(iDay, iMonth, iYear);
            
            //**************************
            
            iDay = dtpEnd.Value.Day;
            iMonth = dtpEnd.Value.Month;
            iYear = dtpEnd.Value.Year;

            if (CultureInfo.CurrentCulture.ToString() == "th-TH")
                iYear = iYear + 543;
            com.Parameters.Add("@End", OleDbType.Date).Value = MyPrint12.makeDateTransaction(iDay, iMonth, iYear);

            try
            {
                OleDbDataReader dr = com.ExecuteReader();
                //int iBegin = 550;
                //double dbSum = 0;

                if (dr.HasRows == true)
                {
                    YTarget = YTarget + fnt.Height;
                    YTarget = YTarget + fnt.Height;

                    fnt = new Font("Tahoma", 12, FontStyle.Bold);
                    e.Graphics.DrawString("วันที่", fnt, Brushes.Black, 60, YTarget);
                    e.Graphics.DrawString("เลขที่ใบเสร็จ", fnt, Brushes.Black, 125, YTarget);
                    e.Graphics.DrawString("ชื่อลูกค้า", fnt, Brushes.Black, 250, YTarget);
                    e.Graphics.DrawString("ส่วนลด", fnt, Brushes.Black, 425, YTarget);
                    e.Graphics.DrawString("ราคาหลังหักส่วนลด", fnt, Brushes.Black, 525, YTarget);
                    e.Graphics.DrawString("ภาษี 7%", fnt, Brushes.Black, 715, YTarget);

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    dr.Close();
                    CloseConnection();

                    string strPastDate = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strCurrentDate = dt.Rows[i]["SellDate"].ToString();

                        if (strPastDate != strCurrentDate)
                        {
                            alDate.Add(strCurrentDate);
                        }
                        strPastDate = strCurrentDate;
                    }

                    foreach (string strSellDate in alDate)
                    {
                        YTarget = YTarget + fnt.Height;
                        fnt = new Font("Tahoma", 12, FontStyle.Bold);

                        iDay = MyPrint12.getDayFromTextDate(strSellDate);
                        iMonth = MyPrint12.getMonthFromTextDate(strSellDate);
                        iYear = MyPrint12.getYearFromTextDate(strSellDate);

                        if (CultureInfo.CurrentCulture.ToString() == "th-TH")
                            iYear = iYear - 543;

                        string strBillDate = MyPrint12.makeDatePrintShortYear(iDay, iMonth, iYear);

                        e.Graphics.DrawString(strBillDate, fnt, Brushes.Black, 35, YTarget);

                        fnt = new Font("Tahoma", 12, FontStyle.Regular);

                        DateTime dtDate = new DateTime(iYear, iMonth, iDay);

                        ////**************************
                        //MessageBox.Show(iYear.ToString());

                        sb = new StringBuilder();
                        sb.Append("SELECT BillNumber,");
                        sb.Append("SUM(Discount) AS SumDiscount,");
                        sb.Append("SUM(TotalPrice) AS SumPrice");
                        sb.Append(" FROM Bills");
                        sb.Append(" WHERE SellDate=@SellDate");
                        sb.Append(" GROUP BY BillNumber");

                        sqlSelect = sb.ToString();
                        OpenConnection();
                        com = new OleDbCommand();
                        com.CommandType = CommandType.Text;
                        com.CommandText = sqlSelect;
                        com.Connection = Conn;

                        com.Parameters.Add("@SellDate", OleDbType.Date).Value = dtDate.ToShortDateString();

                        try
                        {
                            dr = com.ExecuteReader();

                            if (dr.HasRows == true)
                            {
                                dt = new DataTable();
                                dt.Load(dr);

                                double dbSumPrice = 0.0d;
                                double dbSumDiscount = 0.0d;
                                double dbSumTax = 0.0d;
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    if (j != 0)
                                        YTarget = YTarget + fnt.Height;

                                    //พิมพ์เลขที่ใบเสร็จ
                                    int iBillNumber = int.Parse(dt.Rows[j]["BillNumber"].ToString());
                                    int iXBillNumber = MyPrint12.getXNumber(180, iBillNumber);
                                    e.Graphics.DrawString(iBillNumber.ToString(), fnt, Brushes.Black, iXBillNumber, YTarget);

                                    //พิมพ์ชื่อลูกค้า
                                    string strCustomerName = getCustomerName(iBillNumber);
                                    e.Graphics.DrawString(strCustomerName, fnt, Brushes.Black, 230, YTarget);

                                    //พิมพ์ส่วนลด
                                    double dbDiscount = double.Parse(dt.Rows[j]["SumDiscount"].ToString());
                                    dbSumDiscount = dbSumDiscount + dbDiscount;
                                    int iXDiscount = MyPrint12.getXCurrency(450,dbDiscount);
                                    string strDiscount = NumberFormat.getStringCurrency(dbDiscount);
                                    e.Graphics.DrawString(strDiscount, fnt, Brushes.Black, iXDiscount, YTarget);

                                    //พิมพ์ราคาหลังหักส่วนลด
                                    double dbPrice = double.Parse(dt.Rows[j]["SumPrice"].ToString());
                                    dbSumPrice = dbSumPrice + dbPrice;
                                    int iXPrice = MyPrint12.getXCurrency(615, dbPrice);
                                    string strPrice = NumberFormat.getStringCurrency(dbPrice);
                                    e.Graphics.DrawString(strPrice, fnt, Brushes.Black, iXPrice, YTarget);

                                    //พิมพ์ภาษี 7%
                                    double dbTax = dbPrice * 7 / 107;
                                    dbSumTax = dbSumTax + dbTax;
                                    int iXTax = MyPrint12.getXCurrency(750, dbTax);
                                    string strTax = NumberFormat.getStringCurrency(dbTax);
                                    e.Graphics.DrawString(strTax, fnt, Brushes.Black, iXTax, YTarget);

                                }
                                //พิมพ์คำว่ารวม
                                fnt = new Font("Tahoma", 12, FontStyle.Bold);
                                YTarget = YTarget + fnt.Height;
                                e.Graphics.DrawString("รวม", fnt, Brushes.Black, 250, YTarget);

                                //พิมพ์รวมส่วนลด
                                int iXSumDiscount = MyPrint12.getXCurrency(441, dbSumDiscount);

                                if ((dbSumDiscount >= 0) && (dbSumDiscount < 100))
                                    iXSumDiscount = iXSumDiscount + 5;

                                string strSumDiscount= NumberFormat.getStringCurrency(dbSumDiscount);
                                e.Graphics.DrawString(strSumDiscount, fnt, Brushes.Black, iXSumDiscount, YTarget);

                                //พิมพ์รวมราคาหลังหักส่วนลด
                                int iXSumPrice = MyPrint12.getXCurrency(605, dbSumPrice);
                                string strSumPrice = NumberFormat.getStringCurrency(dbSumPrice);
                                e.Graphics.DrawString(strSumPrice, fnt, Brushes.Black, iXSumPrice, YTarget);

                                //พิมพ์รวมภาษี 7%
                                int iXSumTax = MyPrint12.getXCurrency(740, dbSumTax);
                                string strSumTax = NumberFormat.getStringCurrency(dbSumTax);
                                e.Graphics.DrawString(strSumTax, fnt, Brushes.Black, iXSumTax, YTarget);
                            }
                            dr.Close();
                            CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            CloseConnection();
                            MessageBox.Show(ex.Message, "คำเตือน");
                        }
                        YTarget = YTarget + fnt.Height;
                    }
                }
                else
                {
                    YTarget = YTarget + fnt.Height;
                    YTarget = YTarget + fnt.Height;
                    e.Graphics.DrawString("ไม่มีรายการขายในช่วงที่กำหนดค่ะ", fnt, Brushes.Black, 250, YTarget);
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message, "ข้อผิดพลาด");
            }
        }
    }
}
