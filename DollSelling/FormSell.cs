using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Product.ProductSell;
using MyFormat;
using Bill.BillOrder;
using MyPrint.MyPrint16;
using System.Globalization;

namespace DollSelling
{
    public partial class FormSell : Form
    {
        private ProductSell productSell;
        
        public FormSell()
        {
            InitializeComponent();
            printPreviewDialog1.Document = printDocument1;
            productSell = new ProductSell();
            dtpSellDate.Format = DateTimePickerFormat.Custom;
            dtpSellDate.CustomFormat = "dd/MM/yyyy";
        }

#region constant
        //ประกาศตัวแปร Title ของ MessageBox
        private const string cstTitle = "ผลการทำงาน";
        private const string cstWarning = "คำเตือน";

#endregion

#region Connection

        //ประกาศตัวแปรออบเจ็กต์ OleDbConnection ชื่อว่า Conn
        OleDbConnection Conn = new OleDbConnection();
        //ประกาศค่าคงที่ string ชื่อว่า strConn เก็บข้อความเชื่อมต่อฐานข้อมูล
        private const string strConn = "Provider=Microsoft.JET.OLEDB.4.0;;Data Source=C:\\Database\\mydollstore.mdb";

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
                MessageBox.Show(strError, cstTitle);
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
                MessageBox.Show(ex.Message, cstTitle);
            }
        }

#endregion
      
#region EvenAndFunction
        private void clearForNewBill()
        {
            dgvSell.Rows.Clear();
            dgvSell.Columns[0].Visible = true;

            tbSellCustomerID.Text = "";
            tbSellCustomerName.Text = "";
            tbSellSeller.Text = "";
            tbSellNoBill.Text = "";
            tbSellProductID.Text = "";
            clearForNewOrder();
            tbTotalPrice.Text = "";
            tbSearchBill.Text = "";

            tbSellCustomerName.Text = "";
            tbSellSeller.Enabled = false;
            tbSellNoBill.Enabled = false;
            tbSellProductID.Enabled = false;
            tbTotalPrice.Enabled = false;
            dtpSellDate.Enabled = false;
            btnCancelEachOrder.Enabled = false;
            dgvSell.Enabled = false;
            btnDeleteOrder.Enabled = false;
            btnSellPrint.Enabled = false;
            btnSellCancel.Enabled = false;
            btnSaveBill.Enabled = false;

            dtpSellDate.Visible = true;
            tbDatePastBill.Visible = false;

            tbSellCustomerID.ReadOnly = false;
            tbSellCustomerID.Focus();
        }

        private void clearForNewOrder()
        {
            tbSellProductID.Text = "";
            tbSellProductName.Text = "";
            tbPerUnit.Text = "";
            tbAmount.Text = "";
            tbDiscount.Text = "";
            tbPriceBeforeDiscount.Text = "";

            tbSellProductName.Enabled = false;
            tbPerUnit.Enabled = false;
            tbAmount.Enabled = false;
            tbDiscount.Enabled = false;
            tbPriceBeforeDiscount.Enabled = false;

            tbSellProductID.Focus();
            btnCancelEachOrder.Visible = false;
        }

        public void focusCustomerID()
        {
            tbSellCustomerID.Focus();
        }

        private double calTotalPriceAfterDiscount(string strDiscount, double dbPrice)
        {
            int iAmountPlus = 0, iLength = 0;
            int[] iTargetPlus = new int[5];
            string[] strArray = new string[5];

            iLength = strDiscount.Length;

            //สกัดตำแหน่งของเครื่องหมายบวกและนับจำนวนเครื่องหมายบวก
            for (int i = 0; i < iLength; i++)
            {
                if (strDiscount[i] == '+')
                {
                    iTargetPlus[iAmountPlus] = i;
                    iAmountPlus = iAmountPlus + 1;

                }
            }

            ////แสดงจำนวนของเครื่องหมายบวก
            //Console.WriteLine("iAmountPlus = " + iAmountPlus);

            //คำนวณในกรณีที่มีนิพจน์ตัวเดียว
            if (iAmountPlus == 0)
            {
                if (strDiscount[iLength - 1] != '%')
                {
                    double dbTemp = double.Parse(strDiscount);
                    return dbPrice - dbTemp;
                }

                else
                {
                    double dbTemp = 0.0d, dbDiscount = 0.0d;
                    strDiscount = strDiscount.Substring(0, iLength - 1);

                    dbTemp = double.Parse(strDiscount);
                    dbDiscount = dbPrice * dbTemp / 100.0;
                    return dbPrice - dbDiscount;
                }
            }

            ////แสดงตำแหน่งของเครื่องหมายบวก
            //for (int i = 0; i < iAmountPlus; i++)
            //{
            //    Console.WriteLine("iTargetPlus[" + i + "] = " + iTargetPlus[i]);
            //}

            //สกัดนิพจน์แต่ละนิพจน์ออกมาจาก strDiscount
            for (int i = 0; i <= iAmountPlus; i++)
            {
                if (i == 0)
                {
                    strArray[0] = strDiscount.Substring(0, iTargetPlus[0]);
                }
                else if ((i > 0) && (i < iAmountPlus))
                {
                    strArray[i] = strDiscount.Substring(iTargetPlus[i - 1] + 1, iTargetPlus[i] - iTargetPlus[i - 1] - 1);
                }
                else if (i == iAmountPlus)
                {
                    strArray[iAmountPlus] = strDiscount.Substring(iTargetPlus[iAmountPlus - 1] + 1, iLength - iTargetPlus[iAmountPlus - 1] - 1);
                }
            }


            ////พิมพ์ค่าใน strArray ออกมาเช็คดู
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("strArray[" + i + "] = " + strArray[i]);
            //}

            for (int i = 0; i <= iAmountPlus; i++)
            {
                string strTemp = strArray[i];
                if (strTemp[strTemp.Length - 1] != '%')
                {
                    double dbTemp = double.Parse(strTemp);
                    dbPrice = dbPrice - dbTemp;
                }
                else if (strTemp[strTemp.Length - 1] == '%')
                {
                    strTemp = strTemp.Substring(0, strTemp.Length - 1);
                    double dbDiscount = 0.0d, dbTemp = double.Parse(strTemp);
                    dbDiscount = dbPrice * dbTemp / 100.0;
                    dbPrice = dbPrice - dbDiscount;

                }

                //Console.WriteLine(i + " Price = " + dbPrice);
            }
            return dbPrice;
        }

        private void tbSellCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT CustomerName");
                sb.Append(" FROM Customers");
                sb.Append(" WHERE CustomerID=@CustomerID");

                string sqlSelect = sb.ToString();
                OpenConnection();
                OleDbCommand com = new OleDbCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = sqlSelect;
                com.Connection = Conn;

                com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = tbSellCustomerID.Text.Trim();

                try
                {
                    OleDbDataReader dr = com.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        tbSellCustomerName.Enabled = true;
                        tbSellCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                        btnSellCancel.Enabled = true;
                        tbSellSeller.ReadOnly = false;
                        tbSellSeller.Enabled = true;
                        tbSellSeller.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบสมาชิกที่ตรงกับรหัสสมาชิกนี้ค่ะ", cstWarning);
                        tbSellCustomerID.Text = "";
                        tbSellCustomerID.Focus();
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    MessageBox.Show(ex.Message, cstWarning);
                }

                CloseConnection();
            }
        }

        private void tbSellSeller_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                if (tbSellSeller.Text.Trim() != "")
                {
                    dtpSellDate.Enabled = true;
                    dtpSellDate.Focus();
                }
                else
                {
                    tbSellSeller.Text = "";
                    MessageBox.Show("กรุณาใส่ชื่อพนักงานขายด้วยค่ะ", cstWarning);
                    tbSellSeller.Focus();
                }
            }
        }

        private void dtpSellDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                tbSellNoBill.ReadOnly = false;
                tbSellNoBill.Enabled = true;
                tbSellNoBill.Focus();

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT MAX(BillNumber) AS MAXBillNumber");
                sb.Append(" FROM Bills");

                string sqlSelect = sb.ToString();

                OpenConnection();
                OleDbCommand com = new OleDbCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = sqlSelect;
                com.Connection = Conn;

                try
                {
                    OleDbDataReader dr = com.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);

                        string strMaxBillNumber = dt.Rows[0]["MaxBillNumber"].ToString();

                        if (strMaxBillNumber == "")
                        {
                            tbSellNoBill.Text = "1";
                        }
                        else
                        {
                            int iMaxBillNumber = int.Parse(strMaxBillNumber);
                            tbSellNoBill.Text = (iMaxBillNumber + 1).ToString();
                        }
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    MessageBox.Show(ex.Message, cstWarning);
                }

                CloseConnection();
            }
        }

        private void tbSellNoBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                int iBillNumber = 0;

                try
                {
                    iBillNumber = int.Parse(tbSellNoBill.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("ห้ามใส่ตัวอักษรในช่องเลขที่ใบเสร็จนะคะ เลขที่ใบเสร็จต้องเป็นตัวเลขเท่านั้นค่ะ", cstWarning);
                    tbSellNoBill.Text = "";
                    tbSellNoBill.Focus();
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT COUNT(BillNumber) AS CountBillNumber");
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
                        int iAmountRow = int.Parse(dt.Rows[0]["CountBillNumber"].ToString());

                        if (iAmountRow == 0)
                        {
                            tbSellProductID.Enabled = true;
                            tbSellProductID.Focus();
                        }

                        else
                        {
                            MessageBox.Show("เลขที่ใบเสร็จนี้เคยถูกใช้ไปแล้วค่ะ ต้องเปลี่ยนเป็นเลขที่ใบเสร็จเลขที่อื่นนะคะ", cstWarning);
                            tbSellNoBill.Text = "";
                            tbSellNoBill.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, cstWarning);
                }

                CloseConnection();
            }
        }

        private void tbSellProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ProductName, Price");
                sb.Append(" FROM Products");
                sb.Append(" WHERE ProductID=@ProductID");

                string sqlSelect = sb.ToString();

                OpenConnection();
                OleDbCommand com = new OleDbCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = sqlSelect;
                com.Connection = Conn;

                com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = tbSellProductID.Text.Trim();

                try
                {
                    OleDbDataReader dr = com.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        tbSellProductName.Enabled = true;
                        tbSellProductName.Text = dt.Rows[0]["ProductName"].ToString();
                        tbPerUnit.Enabled = true;
                        tbPerUnit.Text = dt.Rows[0]["Price"].ToString();
                        tbAmount.Enabled = true;
                        tbAmount.Focus();

                        productSell.ID = tbSellProductID.Text;
                        productSell.Name = dt.Rows[0]["ProductName"].ToString();
                        productSell.Price = double.Parse(dt.Rows[0]["Price"].ToString());

                        btnCancelEachOrder.Enabled = true;
                        btnCancelEachOrder.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีสินค้าที่ตรงกับรหัสสินค้านี้ค่ะ", cstWarning);
                        tbSellProductID.Text = "";
                        tbSellProductID.Focus();
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    MessageBox.Show(ex.Message, cstWarning);
                }
                CloseConnection();
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                int iAmount = 0;

                if (tbAmount.Text.Trim() == "")
                {
                    productSell.Amount = 1;
                    productSell.TotalPrice = productSell.Price;
                    tbPriceBeforeDiscount.Enabled = true;
                    tbPriceBeforeDiscount.Text = NumberFormat.getStringCurrency(productSell.Price);
                    tbDiscount.Enabled = true;
                    tbDiscount.Focus();
                    return;
                }

                try
                {
                    iAmount = int.Parse(tbAmount.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("จำนวนต้องเป็นตัวเลขเท่านั้นนะคะ", cstWarning);
                    tbAmount.Text = "";
                    tbAmount.Focus();
                }

                if (iAmount < 1)
                {
                    MessageBox.Show("จำนวนของสินค้าต้องมีจำนวนตั้งแต่ 1 ชิ้นขึ้นไปค่ะ");
                    tbAmount.Text = "";
                    tbAmount.Focus();
                }
                else if (iAmount > 10000)
                {
                    MessageBox.Show("จำนวนของสินค้าต้องมีจำนวนไม่เกิน 10,000 ชิ้นค่ะ" + Environment.NewLine + "ถ้ามากกว่า 10,000 ชิ้น กรุณาทำเป็น 2 รายการค่ะ",cstWarning);
                    tbAmount.Text = "";
                    tbAmount.Focus();
                }
                else
                {
                    productSell.Amount = iAmount;
                    double dbTmpPrice = productSell.Price * iAmount;
                    string strTmpPrice = NumberFormat.getStringCurrency(dbTmpPrice);
                    productSell.TotalPrice = double.Parse(strTmpPrice);
                    tbPriceBeforeDiscount.Enabled = true;
                    tbPriceBeforeDiscount.Text = NumberFormat.getStringCurrency(productSell.TotalPrice);
                    tbDiscount.Enabled = true;
                    tbDiscount.Focus();
                }
            }
        }

        private void increaseTotalPrice(double dbIncreasePrice)
        {
            if (tbTotalPrice.Text.Trim() == "")
            {
                tbTotalPrice.Text = NumberFormat.getStringCurrency(dbIncreasePrice);
            }
            else
            {
                double dbOldPrice = double.Parse(tbTotalPrice.Text.Trim());
                double dbNewPrice = dbOldPrice + dbIncreasePrice;
                tbTotalPrice.Text = NumberFormat.getStringCurrency(dbNewPrice);
            }
        }

        private void decreaseTotalPrice(double dbDecreasePrice)
        {
            if (tbTotalPrice.Text.Trim() == "")
            {
                return;
            }
            else
            {
                double dbOldPrice = double.Parse(tbTotalPrice.Text.Trim());
                double dbNewPrice = dbOldPrice - dbDecreasePrice;
                tbTotalPrice.Text = NumberFormat.getStringCurrency(dbNewPrice);
            }
        }

        private void addProductSaleToDgvSell()
        {
            dgvSell.Rows.Add();

            int iTarget = dgvSell.Rows.Count - 1;
            dgvSell.Rows[iTarget].Cells[0].Value = false;
            dgvSell.Rows[iTarget].Cells[1].Value = productSell.ID;
            dgvSell.Rows[iTarget].Cells[2].Value = productSell.Name;
            dgvSell.Rows[iTarget].Cells[3].Value = NumberFormat.getStringCurrency(productSell.Price);
            dgvSell.Rows[iTarget].Cells[4].Value = productSell.Amount;
            dgvSell.Rows[iTarget].Cells[5].Value = NumberFormat.getStringCurrency(productSell.Discount);
            dgvSell.Rows[iTarget].Cells[6].Value = NumberFormat.getStringCurrency(productSell.TotalPrice);
            increaseTotalPrice(productSell.TotalPrice);
            clearForNewOrder();
        }

        private void tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Tab))
            {
                string strDiscount = tbDiscount.Text.Trim();

                if (strDiscount == "")
                {
                    productSell.Discount = 0.0d;
                    dgvSell.Enabled = true;
                    btnDeleteOrder.Enabled = true;
                    btnSellPrint.Enabled = true;
                    btnSellCancel.Enabled = true;
                    tbTotalPrice.Enabled = true;
                    btnSaveBill.Enabled = true;
                    addProductSaleToDgvSell();
                    return;
                }

                for (int i = 0; i < strDiscount.Length; i++)
                {
                    if (strDiscount[i] == '-')
                    {
                        string strOut = "ในช่องส่วนลดห้ามใส่เครื่องหมายลบนะคะ ใส่ได้เฉพาะตัวเลข เครื่องหมายบวกและเครื่องหมาย % ค่ะ ดังตัวอย่าง" + Environment.NewLine;
                        strOut = strOut + "20 หรือ 20+30% หรือ 20+30%+400+20+100 เป็นต้น";
                        MessageBox.Show(strOut, cstWarning);
                        tbDiscount.Focus();
                        return;
                    }
                }

                if (strDiscount[0] == '+')
                    strDiscount = strDiscount.Substring(1, strDiscount.Length - 1);

                bool bCheck = true;

                for (int i = 0; i < strDiscount.Length; i++)
                {
                    switch (strDiscount[i])
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                        case '%':
                        case '.':
                        case '+': break;
                        default: bCheck = false; break;
                    }
                }

                if (bCheck == true)
                {
                    double dbOldTotalPrice = productSell.TotalPrice;
                    double dbNewPrice = calTotalPriceAfterDiscount(strDiscount, productSell.TotalPrice);
                    if (dbNewPrice < 1.0d)
                    {
                        string strOut = "คุณใส่ส่วนลดเกินกว่าราคาสินค้าที่ลดได้ ราคาของสินค้าขั้นต่ำต้องมีค่าอย่างน้อย 1 บาทค่ะ";
                        MessageBox.Show(strOut, cstWarning);
                        tbDiscount.Focus();
                        return;
                    }
                    else
                    {
                        double dbTmpDiscount = dbOldTotalPrice - dbNewPrice;
                        string strTempPrice = NumberFormat.getStringCurrency(dbTmpDiscount);
                        productSell.Discount = double.Parse(strTempPrice);
                        productSell.TotalPrice = dbNewPrice;
                        dgvSell.Enabled = true;
                        btnDeleteOrder.Enabled = true;
                        btnSellPrint.Enabled = true;
                        btnSellCancel.Enabled = true;
                        tbTotalPrice.Enabled = true;
                        btnSaveBill.Enabled = true;
                        addProductSaleToDgvSell();
                    }
                }
                else
                {
                    string strOut = "ในช่องส่วนลดห้ามใส่ตัวอักษรนะคะ ใส่ได้เฉพาะตัวเลข เครื่องหมายบวกและเครื่องหมาย % ค่ะ ดังตัวอย่าง" + Environment.NewLine;
                    strOut = strOut + "20 หรือ 20+30% หรือ 20+30%+400+20+100 เป็นต้น";
                    MessageBox.Show(strOut, cstWarning);
                    tbDiscount.Focus();
                    return;
                }
            }
        }

        private void btnCancelEachOrder_Click(object sender, EventArgs e)
        {
            clearForNewOrder();
            btnCancelEachOrder.Visible = false;
        }

        private void insertToBills(BillOrder billOrder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Bills(BillNumber,SellDate,EmployeeName,CustomerID,");
            sb.Append("CustomerName,ProductID,ProductName,Amount,Discount,TotalPrice)");
            sb.Append(" VALUES(@BillNumber,@SellDate,@EmployeeName,CustomerID,");
            sb.Append("@CustomerName,@ProductID,@ProductName,@Amount,@Discount,@TotalPrice)");

            string sqlInsert = sb.ToString();

            OpenConnection();
            OleDbTransaction tr = Conn.BeginTransaction();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlInsert;
            com.Connection = Conn;
            com.Transaction = tr;

            com.Parameters.Add("@BillNumber", OleDbType.BigInt).Value = billOrder.BillNumber;
            com.Parameters.Add("@SellDate", OleDbType.Date).Value = billOrder.SellDate;
            com.Parameters.Add("@EmployeeName", OleDbType.VarChar).Value = billOrder.EmployeeName;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = billOrder.CustomerID;
            com.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = billOrder.CustomerName;
            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = billOrder.ProductID;
            com.Parameters.Add("@ProductName", OleDbType.VarChar).Value = billOrder.ProductName;
            com.Parameters.Add("@Amount", OleDbType.Integer).Value = billOrder.Amount;
            com.Parameters.Add("@Discount", OleDbType.Double).Value = billOrder.Discount;
            com.Parameters.Add("@TotalPrice", OleDbType.Double).Value = billOrder.TotalPrice;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
        }

        private void insertToCirculations(double dbTotalPrice,string strSellDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Circulations(DetailDate,Circulation)");
            sb.Append(" VALUES(@DetailDate,@Circulation)");

            string sqlInsert = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlInsert;
            com.Connection = Conn;
            com.Transaction = tr;

            com.Parameters.Add("@DetailDate", OleDbType.Date).Value = strSellDate;
            com.Parameters.Add("@Circulation", OleDbType.Double).Value = dbTotalPrice;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show("Error in insert " + ex.Message, cstWarning);
            }
        }

        private void updateToCirculations(double dbTotalPrice, string strSellDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Circulation");
            sb.Append(" FROM Circulations");
            sb.Append(" WHERE DetailDate=@DetailDate");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            com.Parameters.Add("@DetailDate", OleDbType.Date).Value = strSellDate;

            double dbPastCirculation = 0.0d;

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dbPastCirculation = double.Parse(dt.Rows[0]["Circulation"].ToString());
                }

                dr.Close();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
                return;
            }

            double dbNewCirculation = dbPastCirculation + dbTotalPrice;

            sb = new StringBuilder();
            sb.Append("UPDATE Circulations");
            sb.Append(" SET Circulation=@Circulation");
            sb.Append(" WHERE DetailDate=@DetailDate");

            string sqlUpdate = sb.ToString();

            OpenConnection();
            com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlUpdate;
            com.Connection = Conn;
            com.Transaction = tr;

            com.Parameters.Add("@Circulation", OleDbType.Double).Value = dbNewCirculation;
            com.Parameters.Add("@DetailDate", OleDbType.Date).Value = strSellDate;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show("Step 2 " + ex.Message, cstWarning);
            }
        }

        private void increaseCirculation(double dbTotalPrice, string strSellDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(DetailDate) AS CountDetailDate");
            sb.Append(" FROM Circulations");
            sb.Append(" WHERE DetailDate=@DetailDate");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            int iDay = dtpSellDate.Value.Day;
            int iMonth = dtpSellDate.Value.Month;
            int iYear = dtpSellDate.Value.Year;
            com.Parameters.Add("@DetailDate", OleDbType.Date).Value = strSellDate;

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    int iAmount = int.Parse(dt.Rows[0]["CountDetailDate"].ToString());

                    if (iAmount == 1)
                        updateToCirculations(dbTotalPrice, strSellDate);
                    else
                        insertToCirculations(dbTotalPrice, strSellDate);
                }

                dr.Close();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show("Step 1 " + ex.Message, cstWarning);
            }
        }

        private void btnSellPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            int iIndex = 0;
            int iLength = dgvSell.Rows.Count;

            while (iIndex < iLength)
            {
                if (dgvSell.Rows[iIndex].Cells[0].Value.ToString() == "True")
                {
                    decreaseTotalPrice(double.Parse(dgvSell.Rows[iIndex].Cells[6].Value.ToString()));
                    dgvSell.Rows.RemoveAt(iIndex);
                    iLength = iLength - 1;
                }

                else
                    iIndex = iIndex + 1;
            }
        }

        private void btnSellCancel_Click(object sender, EventArgs e)
        {
            clearForNewBill();
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            btnNewBill.Visible = false;
            btnSellCancel.Visible = true;
            clearForNewBill();
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            dgvSell.Columns[0].Visible = false;
            tbSellProductID.Enabled = false;

            BillOrder billOrder = new BillOrder();

            billOrder.CustomerID = tbSellCustomerID.Text.Trim();
            billOrder.CustomerName = tbSellCustomerName.Text.Trim();
            billOrder.EmployeeName = tbSellSeller.Text.Trim();

            int iDay = dtpSellDate.Value.Day;
            int iMonth = dtpSellDate.Value.Month;
            int iYear = dtpSellDate.Value.Year;

            if (CultureInfo.CurrentCulture.ToString() == "th-TH")
                iYear = iYear + 543;

            billOrder.SellDate = MyPrint16.makeDateTransaction(iDay, iMonth, iYear);
            billOrder.BillNumber = int.Parse(tbSellNoBill.Text.ToString());

            for (int i = 0; i < dgvSell.Rows.Count; i++)
            {
                billOrder.ProductID = dgvSell.Rows[i].Cells[1].Value.ToString();
                billOrder.ProductName = dgvSell.Rows[i].Cells[2].Value.ToString();
                billOrder.Amount = int.Parse(dgvSell.Rows[i].Cells[4].Value.ToString());
                billOrder.Discount = double.Parse(dgvSell.Rows[i].Cells[5].Value.ToString());
                billOrder.TotalPrice = double.Parse(dgvSell.Rows[i].Cells[6].Value.ToString());
                insertToBills(billOrder);
            }

            btnNewBill.Visible = true;
            btnSellCancel.Visible = false;

            increaseCirculation(double.Parse(tbTotalPrice.Text), billOrder.SellDate);
            btnDeleteOrder.Enabled = false;
            btnSaveBill.Enabled = false;
        }

        private void tbSearchBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else if (char.IsNumber(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("กรุณาใส่เฉพาะตัวเลขเท่านั้นค่ะ");
            }
        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            if (tbSearchBill.Text.Trim() == "")
            {
                MessageBox.Show("คุณยังไม่ได้กรอกเลขที่ใบเสร็จที่ต้องการค้นหาค่ะ", cstWarning);
                return;
            }

            int iPastBillNumber = int.Parse(tbSearchBill.Text);
            showDetailPastBill(iPastBillNumber);
        }

        private void tbSellCustomerID_Enter(object sender, EventArgs e)
        {
            popCustomer.Visible = true;
        }

        private void tbSellCustomerID_Leave(object sender, EventArgs e)
        {
            popCustomer.Visible = false;
        }

        private void tbSellCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                FormSearchCus frmSearch = new FormSearchCus();
                frmSearch.ShowDialog();

                if (frmSearch.Selected == true)
                {
                    tbSellCustomerID.Text = frmSearch.SelectCustomerID;
                    tbSellCustomerName.Enabled = true;
                    tbSellCustomerName.Text = frmSearch.SelectCustomerName;
                    tbSellSeller.Enabled = true;
                    tbSellSeller.Focus();
                }
                else
                    tbSellCustomerID.Focus();
            }
        }

        private void tbSellProductID_Enter(object sender, EventArgs e)
        {
            popProduct.Visible = true;
        }

        private void tbSellProductID_Leave(object sender, EventArgs e)
        {
            popProduct.Visible = false;
        }

        private void tbSellProductID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                FormSearchPro frmSearch = new FormSearchPro();
                frmSearch.ShowDialog();

                if (frmSearch.Selected == true)
                {
                    tbSellProductID.Text = frmSearch.ProductID;
                    tbSellProductName.Enabled = true;
                    tbSellProductName.Text = frmSearch.ProductName;
                    tbPerUnit.Enabled = true;
                    tbPerUnit.Text = Convert.ToString(frmSearch.Price);
                    tbAmount.Enabled = true;
                    tbAmount.Focus();

                    productSell.ID = frmSearch.ProductID;
                    productSell.Name = frmSearch.ProductName;
                    productSell.Price = frmSearch.Price;

                    btnCancelEachOrder.Enabled = true;
                    btnCancelEachOrder.Visible = true;
                }
                else
                    tbSellProductID.Focus();
            }
        }
#endregion

#region SearchPastBill

        private void showDetailPastBill(int iPastBillNumbet)
        {
            dgvSell.Rows.Clear();
            dgvSell.Columns[0].Visible = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT FORMAT(SellDate,'dd/MM/yyyy') AS SellDate,EmployeeName,CustomerID,CustomerName,ProductID,ProductName,Amount,Discount,TotalPrice");
            sb.Append(" FROM Bills");
            sb.Append(" WHERE BillNumber=@BillNumber");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            com.Parameters.Add("@BillNumber", OleDbType.BigInt).Value = tbSearchBill.Text.Trim();

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    tbSellCustomerID.ReadOnly = true;
                    tbSellCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
                    tbSellCustomerName.Enabled = true;
                    tbSellCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    tbSellSeller.Enabled = true;
                    tbSellSeller.ReadOnly = true;
                    tbSellSeller.Text = dt.Rows[0]["EmployeeName"].ToString();

                    dtpSellDate.Visible = false;
                    tbDatePastBill.Visible = true;

                    string strPastDate = dt.Rows[0]["SellDate"].ToString();
                    int iPastDay = MyPrint16.getDayFromTextDate(strPastDate);
                    int iPastMonth = MyPrint16.getMonthFromTextDate(strPastDate);
                    int iPastYear = MyPrint16.getYearFromTextDate(strPastDate);

                    if (CultureInfo.CurrentCulture.ToString() == "th-TH")
                    {
                        iPastYear = iPastYear - 543;
                    }

                    tbDatePastBill.Text = MyPrint16.makeDatePrint(iPastDay, iPastMonth, iPastYear);
                    tbSellNoBill.Enabled = true;
                    tbSellNoBill.ReadOnly = true;
                    tbSellNoBill.Text = tbSearchBill.Text;

                    dgvSell.Enabled = true;


                    double dbSumPrice = 0.0d;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvSell.Rows.Add();
                        int iIndex = dgvSell.Rows.Count - 1;
                        dgvSell.Rows[iIndex].Cells[0].Value = false;
                        dgvSell.Rows[iIndex].Cells[1].Value = dt.Rows[i]["ProductID"].ToString();
                        dgvSell.Rows[iIndex].Cells[2].Value = dt.Rows[i]["ProductName"].ToString();

                        int iAmount = int.Parse(dt.Rows[i]["Amount"].ToString());
                        double dbDiscount = double.Parse(dt.Rows[i]["Discount"].ToString());
                        double dbTotalPrice = double.Parse(dt.Rows[i]["TotalPrice"].ToString());
                        dbSumPrice = dbSumPrice + dbTotalPrice;
                        double dbPricePerUnit = (dbTotalPrice + dbDiscount) / (double)iAmount;

                        dgvSell.Rows[iIndex].Cells[3].Value = NumberFormat.getStringCurrency(dbPricePerUnit);
                        dgvSell.Rows[iIndex].Cells[4].Value = iAmount.ToString();
                        dgvSell.Rows[iIndex].Cells[5].Value = NumberFormat.getStringCurrency(dbDiscount);
                        dgvSell.Rows[iIndex].Cells[6].Value = NumberFormat.getStringCurrency(dbTotalPrice);
                    }

                    tbTotalPrice.Enabled = true;
                    tbTotalPrice.Text = NumberFormat.getStringCurrency(dbSumPrice);
                    btnSellPrint.Enabled = true;
                    btnNewBill.Visible = true;
                    btnSellCancel.Visible = false;
                }
                else
                {
                    clearForNewBill();
                    btnNewBill.Visible = false;
                    btnSellCancel.Visible = true;
                    MessageBox.Show("ไม่พบใบเสร็จที่ตรงกับเลขที่ใบเสร็จนี้ค่ะ", cstWarning);
                }

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
        }

#endregion

#region PrintInvoice
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1 = new PrintDocument();
            Font fnt = new Font("Tahoma", 20);
            Point pDoll2U = new Point(350, 50);
            Point pBillNumber = new Point(650, 50);
            Point pBillText = new Point(320, 100);
            Point pDate = new Point(20, 130);
            Point pBranch = new Point(600, 130);
            Point pCustomerID = new Point(20, 160);
            Point pCustomerName = new Point(550, 160);
            Point pEmployee = new Point(20, 190);
            Point pProductHead = new Point(20, 250);

            string strStoreName = "Doll2U";
            string strBillNumber = "เลขที่: " + NumberFormat.getStringNumber(int.Parse(tbSellNoBill.Text));
            string strBillText = "ใบเสร็จรับเงิน";
            string strDate = "วันที่ ";

            if (dtpSellDate.Visible == true)
            {
                int iCurrentDay = dtpSellDate.Value.Day;
                int iCurrentMonth = dtpSellDate.Value.Month;
                int iCurrentYear = dtpSellDate.Value.Year;
                strDate = strDate + MyPrint16.makeDatePrint(iCurrentDay, iCurrentMonth, iCurrentYear);
            }
            else
            {
                strDate = strDate + tbDatePastBill.Text.Trim();
            }
            
            string strBranch = "สาขา สยามสแควร์";
            string strCustomerID = "รหัสลูกค้า " + tbSellCustomerID.Text.Trim();
            string strCustomerName = "ชื่อลูกค้า " + tbSellCustomerName.Text.Trim();
            string strEmployee = "พนักงาน: " + tbSellSeller.Text.Trim();
            string strProductHead = "รหัสสินค้า  ชื่อสินค้า                                           จำนวน                ราคา(บาท)";

            e.Graphics.DrawString(strStoreName, fnt, Brushes.Black, pDoll2U);
            e.Graphics.DrawString(strBillNumber, fnt, Brushes.Black, pBillNumber);
            e.Graphics.DrawString(strBillText, fnt, Brushes.Black, pBillText);

            fnt = new Font("Tahoma", 16);

            e.Graphics.DrawString(strDate, fnt, Brushes.Black, pDate);
            e.Graphics.DrawString(strBranch, fnt, Brushes.Black, pBranch);
            e.Graphics.DrawString(strCustomerID, fnt, Brushes.Black, pCustomerID);
            e.Graphics.DrawString(strCustomerName, fnt, Brushes.Black, pCustomerName);
            e.Graphics.DrawString(strEmployee, fnt, Brushes.Black, pEmployee);
            e.Graphics.DrawString(strProductHead, fnt, Brushes.Black, pProductHead);

            int yTarget = 250 + fnt.Height;
            double dbSumDiscount = 0.0d;
            double dbSumPrice = 0.0d;

            //พิมพ์รายการสินค้าใน Bill 
            for (int i = 0; i < dgvSell.Rows.Count; i++)
            {
                //พิมพ์รหัสสินค้า
                e.Graphics.DrawString(dgvSell.Rows[i].Cells[1].Value.ToString(), fnt, Brushes.Black, 20, yTarget);

                //พิมพ์ชื่อสินค้า
                e.Graphics.DrawString(dgvSell.Rows[i].Cells[2].Value.ToString(), fnt, Brushes.Black, 120, yTarget);

                //พิมพ์จำนวน
                int iAmountEach = int.Parse(dgvSell.Rows[i].Cells[4].Value.ToString());
                int iXAmountEach = MyPrint16.getXNumber(558, iAmountEach);
                string strAmountEach = NumberFormat.getStringNumber(iAmountEach);

                e.Graphics.DrawString(strAmountEach, fnt, Brushes.Black, iXAmountEach, yTarget);

                //พิมพ์ราคา
                double dbDiscount = double.Parse(dgvSell.Rows[i].Cells[5].Value.ToString());
                dbSumDiscount = dbSumDiscount + dbDiscount;
                double dbPriceAfterDiscount = double.Parse(dgvSell.Rows[i].Cells[6].Value.ToString());
                double dbPrice = dbPriceAfterDiscount + dbDiscount;
                dbSumPrice = dbSumPrice + dbPrice;
                int iXdbPrice = MyPrint16.getXCurrency(730, dbPrice);

                string strPrice = NumberFormat.getStringCurrency(dbPrice);
                e.Graphics.DrawString(strPrice, fnt, Brushes.Black, iXdbPrice, yTarget);
                yTarget = yTarget + fnt.Height;
            }

            yTarget = 880;

            //พิมพ์ ราคารวม
            e.Graphics.DrawString("ราคารวม", fnt, Brushes.Black, 20, yTarget);

            int iXdbSumPrice = MyPrint16.getXCurrency(730, dbSumPrice);
            string strSumPrice = NumberFormat.getStringCurrency(dbSumPrice);
            e.Graphics.DrawString(strSumPrice, fnt, Brushes.Black, iXdbSumPrice, yTarget);

            if (dbSumDiscount > 0.0)
            {
                //รวมส่วนลด
                yTarget = yTarget + fnt.Height;
                e.Graphics.DrawString("รวมส่วนลด", fnt, Brushes.Black, 20, yTarget);
                int iXBeginSumDiscount = MyPrint16.getXCurrency(723, dbSumDiscount);
                string strSumDiscount = NumberFormat.getStringCurrency(dbSumDiscount);
                e.Graphics.DrawString("-" + strSumDiscount, fnt, Brushes.Black, iXBeginSumDiscount, yTarget);
            }

            //พิมพ์ราคาหลังหักส่วนลด
            yTarget = yTarget + fnt.Height;
            e.Graphics.DrawString("ราคาหลังหักส่วนลด", fnt, Brushes.Black, 20, yTarget);
            double dbPriceComplete = double.Parse(tbTotalPrice.Text.Trim());
            string strPriceTotal = NumberFormat.getStringCurrency(dbPriceComplete);
            int iXBeginPriceComplete = MyPrint16.getXCurrency(730, dbPriceComplete);
            e.Graphics.DrawString(strPriceTotal, fnt, Brushes.Black, iXBeginPriceComplete, yTarget);

            //พิมพ์ภาษีมูลค่าเพิ่ม
            yTarget = yTarget + fnt.Height;
            e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม 7%", fnt, Brushes.Black, 20, yTarget);
            double dbPriceVAT = dbPriceComplete * 7 / 107;
            string strPriceVAT = NumberFormat.getStringCurrency(dbPriceVAT);
            int iXBeginPriceVAT = MyPrint16.getXCurrency(730, dbPriceVAT);
            e.Graphics.DrawString(strPriceVAT, fnt, Brushes.Black, iXBeginPriceVAT, yTarget);

            //พิมพ์ราคาสุทธิ
            yTarget = yTarget + fnt.Height;
            e.Graphics.DrawString("ราคาสุทธิ", fnt, Brushes.Black, 20, yTarget);
            e.Graphics.DrawString(strPriceTotal, fnt, Brushes.Black, iXBeginPriceComplete, yTarget);

            //พิมพ์ Include VAT
            e.Graphics.DrawString("Include VAT", fnt, Brushes.Black, 320, 1050);

            //พิมพ์ขอบคุณที่ใช้บริการ
            e.Graphics.DrawString("ขอบคุณที่ใช้บริการ", fnt, Brushes.Black, 300, 1050 + fnt.Height);
        }

#endregion

    }
}
