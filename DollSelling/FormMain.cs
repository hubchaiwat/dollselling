using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using People.Customer;
using Product.ProductDetail;

namespace DollSelling
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            frmSell.MdiParent = this;
        }

        FormSell frmSell = new FormSell();
#region Enum
        public enum EnumPanel : int
        {
            Customer,
            Product,
            Sell
        }

#endregion

#region constant
        //ประกาศตัวแปร Title ของ MessageBox
        private const string cstTitle = "ผลการทำงาน";
        private const string cstWarning = "คำเตือน";

        //ประกาศค่าคงที่ของจำนวน button menubar
        private const int cstMaxMenubar = 4;

#endregion

#region General Variable
        //ประกาศตัวแปรเพื่อบ่งบอกว่าทำงานในหน้าจอใดอยู่
        private EnumPanel eCurrentPanel = EnumPanel.Product;

        private bool[] bCusMenuBar = new bool[cstMaxMenubar];
        private bool[] bProMenuBar = new bool[cstMaxMenubar];
        private bool[] bSellMenuBar = new bool[cstMaxMenubar];

#endregion

//จัดการเกี่ยวกับการเชื่อมต่อฐานข้อมูล
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
                strError = strError + "กรุณาตรวจสอบไฟล์ Database ของท่านอีกครั้งว่าไฟล์อยู่ในตำแหน่งที่ถูกต้องหรือไม่"+Environment.NewLine;
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

#region LoadAndCloseForm
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            showPanelSell();
            OpenConnection();
            for (int i = 0; i < cstMaxMenubar; i++)
            {
                if (i == 0)
                {
                    bCusMenuBar[i] = true;
                    bProMenuBar[i] = true;
                    bSellMenuBar[i] = true;
                }
                else
                {
                    bCusMenuBar[i] = false;
                    bProMenuBar[i] = false;
                    bSellMenuBar[i] = false;
                }    
            }

            //tbSearchBill.Text = "1";
            //int iPastBillNumber = int.Parse(tbSearchBill.Text);
            //showDetailPastBill(iPastBillNumber);
            //printPreviewDialog1.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

#endregion

#region UIControl

        private void saveMenuBar()
        {
            if (eCurrentPanel == EnumPanel.Customer)
            {
                bCusMenuBar[0] = buttonNew.Enabled;
                bCusMenuBar[1] = buttonEdit.Enabled;
                bCusMenuBar[2] = buttonSave.Enabled;
                bCusMenuBar[3] = buttonDelete.Enabled;
            }
            else if (eCurrentPanel == EnumPanel.Product)
            {
                bProMenuBar[0] = buttonNew.Enabled;
                bProMenuBar[1] = buttonEdit.Enabled;
                bProMenuBar[2] = buttonSave.Enabled;
                bProMenuBar[3] = buttonDelete.Enabled;
            }
            else if (eCurrentPanel == EnumPanel.Sell)
            {
                bSellMenuBar[0] = false;
                bSellMenuBar[1] = false;
                bSellMenuBar[2] = false;
                bSellMenuBar[3] = false;
            }
        }

        private void loadCusMenuBar()
        {
            buttonNew.Enabled = bCusMenuBar[0];
            buttonEdit.Enabled = bCusMenuBar[1];
            buttonSave.Enabled = bCusMenuBar[2];
            buttonDelete.Enabled = bCusMenuBar[3];
        }

        private void loadProMenuBar()
        {
            buttonNew.Enabled = bProMenuBar[0];
            buttonEdit.Enabled = bProMenuBar[1];
            buttonSave.Enabled = bProMenuBar[2];
            buttonDelete.Enabled = bProMenuBar[3];
        }

        private void loadSellMenuBar()
        {
            buttonNew.Enabled = bSellMenuBar[0];
            buttonEdit.Enabled = bSellMenuBar[1];
            buttonSave.Enabled = bSellMenuBar[2];
            buttonDelete.Enabled = bSellMenuBar[3];
        }

        //show panels
        private void showPanelSell()
        {
            saveMenuBar();
            loadSellMenuBar();
            eCurrentPanel = EnumPanel.Sell;

            frmSell.Visible = true;
            panelCustomer.Visible = false;
            panelProduct.Visible = false;
        }

        private void showPanelCustomer()
        {
            saveMenuBar();
            loadCusMenuBar();
            eCurrentPanel = EnumPanel.Customer;

            //frmSell.Visible = false;
            panelCustomer.Visible = true;
            panelProduct.Visible = false;
        }

        private void showPanelProduct()
        {
            saveMenuBar();
            loadProMenuBar();
            eCurrentPanel = EnumPanel.Product;

            //frmSell.Visible = false;
            panelCustomer.Visible = false;
            panelProduct.Visible = true;
        }

        //controls about sell
        private void imgSell_MouseHover(object sender, EventArgs e)
        {
            linkSell.ForeColor = Color.Blue;
        }

        private void imgSell_MouseLeave(object sender, EventArgs e)
        {
            linkSell.ForeColor = Color.Black;
        }

        private void imgSell_Click(object sender, EventArgs e)
        {
            showPanelSell();
        }

        private void linkSell_MouseHover(object sender, EventArgs e)
        {
            linkSell.ForeColor = Color.Blue;
        }

        private void linkSell_MouseLeave(object sender, EventArgs e)
        {
            linkSell.ForeColor = Color.Black;
        }

        private void linkSell_Click(object sender, EventArgs e)
        {
            showPanelSell();
        }

        private void menuSell_Click(object sender, EventArgs e)
        {
            showPanelSell();
        }

        //Controls about customer

        private void imgCustomer_MouseHover(object sender, EventArgs e)
        {
            linkCustomer.ForeColor = Color.Blue;
        }

        private void imgCustomer_MouseLeave(object sender, EventArgs e)
        {
            linkCustomer.ForeColor = Color.Black;
        }

        private void imgCustomer_Click(object sender, EventArgs e)
        {
            showPanelCustomer();
        }

        private void linkCustomer_MouseHover(object sender, EventArgs e)
        {
            linkCustomer.ForeColor = Color.Blue;
        }

        private void linkCustomer_MouseLeave(object sender, EventArgs e)
        {
            linkCustomer.ForeColor = Color.Black;
        }

        private void linkCustomer_Click(object sender, EventArgs e)
        {
            showPanelCustomer();
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            showPanelCustomer();
        }

        //Controls about product
        private void imgProduct_MouseHover(object sender, EventArgs e)
        {
            linkProduct.ForeColor = Color.Blue;
        }

        private void imgProduct_MouseLeave(object sender, EventArgs e)
        {
            linkProduct.ForeColor = Color.Black;
        }

        private void imgProduct_Click(object sender, EventArgs e)
        {
            showPanelProduct();
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            showPanelProduct();
        }

        //Control about exit program
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //General
        private void radByCustomerID_Click(object sender, EventArgs e)
        {
            tbSearchCustomer.MaxLength = 5;
        }

        private void radByCustomerName_Click(object sender, EventArgs e)
        {
            tbSearchCustomer.MaxLength = 40;
        }

        private void radByProductID_Click(object sender, EventArgs e)
        {
            tbSearchProduct.MaxLength = 5;
        }

        private void radByProductName_Click(object sender, EventArgs e)
        {
            tbSearchProduct.MaxLength = 40;
        }

        private void cbPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbUnitType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        

#endregion

#region MenuBar
        private void menuReport_Click(object sender, EventArgs e)
        {
            FormReport frmReport = new FormReport();
            frmReport.ShowDialog();
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\DollHelp\\help.chm");
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.ShowDialog();
        }
#endregion

#region ToolBar
        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (eCurrentPanel == EnumPanel.Customer)
            {
                clearFieldCustomer();
                btnSearchEachMember.Enabled = false;
                setReadOnlyFieldCustomer(false);
                btnCancelCusCommand.Visible = true;
                btnCancelCusCommand.Text = "ยกเลิกการเพิ่มลูกค้า";
                tbCustomerID.ReadOnly = false;
            }
            else if (eCurrentPanel == EnumPanel.Product)
            {
                clearFieldProduct();
                btnSearchEachProduct.Enabled = false;
                setReadOnlyFieldProduct(false);
                btnCancelProCommand.Visible = true;
                btnCancelProCommand.Text = "ยกเลิกเพิ่มสินค้า";
                tbProductID.ReadOnly = false;
            }

            buttonNew.Enabled = false;
            buttonEdit.Enabled = false;
            buttonSave.Enabled = true;
            buttonDelete.Enabled = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (eCurrentPanel == EnumPanel.Customer)
            {
                setReadOnlyFieldCustomer(false);
                btnCancelCusCommand.Visible = true;
                tbCustomerID.ReadOnly = true;
                btnCancelCusCommand.Text = "ยกเลิกการแก้ไขข้อมูล";
            }
            else if (eCurrentPanel == EnumPanel.Product)
            {
                setReadOnlyFieldProduct(false);
                btnCancelProCommand.Visible = true;
                tbProductID.ReadOnly = true;
                btnCancelProCommand.Text = "ยกเลิกการแก้ไขข้อมูล";
            }

            buttonSave.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (eCurrentPanel == EnumPanel.Customer)
            {
                bool bCheck = false;
                if (btnSearchEachMember.Enabled == false)
                    bCheck = checkDuplicateCustomerID(tbCustomerID.Text.Trim());

                if (bCheck == true)
                {
                    MessageBox.Show("รหัสสมาชิกนี้มีอยู่แล้วในระบบค่ะ กรุณากรอกรหัสสมาชิกอีกครั้งนะคะ", cstWarning);
                    tbCustomerID.Text = "";
                    tbCustomerID.Focus();
                    return;
                }

                Customer customer = new Customer();

                addDataToCustomer(customer);

                bCheck = true;
                bCheck = checkNewCustomer(customer);
                if (bCheck == false)
                {
                    return;
                }

                insertToCustomers(customer);
                btnSearchEachMember.Enabled = true;
                btnCancelCusCommand.Visible = false;
                setReadOnlyFieldCustomer(true);
                tbCustomerID.ReadOnly = false;
            }
            else if (eCurrentPanel == EnumPanel.Product)
            {
                bool bCheck = false;
                if (btnSearchEachProduct.Enabled == false)
                    bCheck = checkDuplicateProductID(tbProductID.Text.Trim());

                if (bCheck == true)
                {
                    MessageBox.Show("รหัสสินค้านี้มีอยู่แล้วในระบบค่ะ กรุณากรอกรหัสสินค้าอีกครั้งนะคะ", cstWarning);
                    tbProductID.Text = "";
                    tbProductID.Focus();
                    return;
                }

                bCheck = true;

                ProductDetail product = new ProductDetail();
                bCheck = addDataToProduct(product);
                if (bCheck == false)
                    return;

                bCheck = checkNewProduct(product);
                if (bCheck == false)
                    return;

                insertToProducts(product);
                btnSearchEachProduct.Enabled = true;
                btnCancelProCommand.Visible = false;
                setReadOnlyFieldProduct(true);
                tbProductID.ReadOnly = false;
            }

            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (eCurrentPanel == EnumPanel.Customer)
                deleteCustomer(tbCustomerID.Text.Trim());
            else if (eCurrentPanel == EnumPanel.Product)
                deleteProduct(tbProductID.Text.Trim());

            buttonEdit.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
        }
#endregion

//จัดการทะเบียนลูกค้า
#region Customer

        public void clearFieldCustomer()
        {
            tbCustomerID.Text = "";
            cbPrefix.SelectedIndex = -1;
            cbPrefix.Text = "เลือกคำนำหน้า";
            tbCustomerName.Text = "";
            tbAddress.Text = "";
            tbTel.Text = "";
            tbMobile.Text = "";
            tbFax.Text = "";
            tbEmail.Text = "";
            tbReciever.Text = "";
            tbJob.Text = "";
            tbCustomerNote.Text = "";
        }

        public void setReadOnlyFieldCustomer(bool bValue)
        {
            tbCustomerName.ReadOnly = bValue;
            tbAddress.ReadOnly = bValue;
            tbTel.ReadOnly = bValue;
            tbMobile.ReadOnly = bValue;
            tbFax.ReadOnly = bValue;
            tbEmail.ReadOnly = bValue;
            tbReciever.ReadOnly = bValue;
            tbJob.ReadOnly = bValue;
            tbCustomerNote.ReadOnly = bValue;
        }

        private bool checkDuplicateCustomerID(string strCustomerID)
        {
            bool bDuplicate = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(CustomerID) AS CountCustomerID");
            sb.Append(" FROM Customers");
            sb.Append(" WHERE CustomerID=@CustomerID");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = strCustomerID;

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                DataTable tr = new DataTable();
                tr.Load(dr);

                int iCount = int.Parse(tr.Rows[0]["CountCustomerID"].ToString());
                if (iCount == 1)
                    return true;

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, cstWarning);
            }

            CloseConnection();

            return bDuplicate;
        }

        private void addDataToCustomer(Customer customer)
        {
            //รับข้อมูลรหัสลูกค้า
            customer.ID = tbCustomerID.Text.Trim();

            //รับข้อมูลคำนำหน้า
            customer.Prefix = Customer.getPrefix(cbPrefix.SelectedIndex, cbPrefix.SelectedItem.ToString());

            //รับข้อมูลชื่อของลูกค้า
            customer.Name = tbCustomerName.Text.Trim();

            //รับข้อมูลที่อยู่
            customer.Address = tbAddress.Text.Trim();

            //รับข้อมูลเบอร์โทรศัพท์
            customer.Tel = tbTel.Text.Trim();

            //รับข้อมูลมือถือ
            customer.Mobile = tbMobile.Text.Trim();

            //รับข้อมูล Fax
            customer.Fax = tbFax.Text.Trim();

            //รับข้อมูล Email
            customer.Email = tbEmail.Text.Trim();

            //รับข้อมูลผู้รับสินค้า
            customer.Reciever = tbReciever.Text.Trim();

            //รับข้อมูลอาชีพของผู้รับสินค้า
            customer.Job = tbJob.Text.Trim();

            //รับข้อมูลหมายเหตุ
            customer.Note = tbCustomerNote.Text.Trim();
        }

        private bool checkNewCustomer(Customer customer)
        {
            bool bCheck = true;
            string strError1 = "";
            string strError2 = "";
            string strError3 = "";

            //เช็คข้อมูลรหัสลูกค้า
            if (customer.ID.Length < 5)
                strError1 = strError1 + "คุณกรอกรหัสลูกค้าไม่ครบ 5 ตัวค่ะ";

            //เช็คข้อมูลคำนำหน้า
            if (customer.Prefix == Customer.cstNotChoosePrefix)
                strError3 = strError3 + "คุณยังไม่ได้เลือกคำนำหน้าค่ะ";

            //เช็คข้อมูลที่อยู่
            if (customer.Address.Length == 0)
                strError2 = strError2 + "ที่อยู่ ";

            //เช็คข้อมูลเบอร์โทรศัพท์
            if (customer.Tel.Length == 0)
                strError2 = strError2 + "เบอร์โทรศัพท์ ";

            //เช็คข้อมูลมือถือ
            if (customer.Mobile.Length == 0)
                strError2 = strError2 + "เบอร์โทรศัพท์มือถือ ";

            //เช็คข้อมูล Fax
            if (customer.Fax.Length == 0)
                strError2 = strError2 + "หมายเลข Fax ";

            //เช็คข้อมูล Email
            if (customer.Email.Length == 0)
                strError2 = strError2 + "Email ";

            //เช็คข้อมูลผู้รับสินค้า
            if (customer.Reciever.Length == 0)
                strError2 = strError2 + "ชื่อผู้รับสินค้า ";

            //เช็คข้อมูลอาชีพของผู้รับสินค้า
            if (customer.Job.Length == 0)
                strError2 = strError2 + "อาชีพของผู้รับสินค้า ";

            if (strError2 != "")
            {
                strError1 = strError1 + Environment.NewLine;
                strError1 = strError1 + "คุณยังไม่ได้กรอก" + strError2 + "ค่ะ";
            }

            if (strError3 != "")
            {
                strError1 = strError1 + Environment.NewLine;
                strError1 = strError1 + strError3;
            }

            if (strError1 != "")
            {
                bCheck = false;
                MessageBox.Show(strError1, cstTitle);
            }
            return bCheck;
        }

        private void insertToCustomers(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Customers(CustomerID,Prefix,CustomerName,Address,Tel,Mobile,Fax,Email,Reciever,Job,CustomerNote)");
            sb.Append(" VALUES(@CustomerID,@Prefix,@CustomerName,@Address,@Tel,@Mobile,@Fax,@Email,@Reciever,@Job,@CustomerNote)");

            string sqlInsert = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlInsert;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = customer.ID;
            com.Parameters.Add("@Prefix", OleDbType.VarChar).Value = customer.Prefix;
            com.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = customer.Name;
            com.Parameters.Add("@Address", OleDbType.VarChar).Value = customer.Address;
            com.Parameters.Add("@Tel", OleDbType.VarChar).Value = customer.Tel;
            com.Parameters.Add("@Mobile", OleDbType.VarChar).Value = customer.Mobile;
            com.Parameters.Add("@Fax", OleDbType.VarChar).Value = customer.Fax;
            com.Parameters.Add("@Email", OleDbType.VarChar).Value = customer.Email;
            com.Parameters.Add("@Reciever", OleDbType.VarChar).Value = customer.Reciever;
            com.Parameters.Add("@Job", OleDbType.VarChar).Value = customer.Job;
            com.Parameters.Add("@CustomerNote", OleDbType.VarChar).Value = customer.Note;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                MessageBox.Show("เพิ่มข้อมูลลูกค้าท่านนี้เรียบร้อยแล้วค่ะ", cstTitle);
            }
            catch
            {
                tr.Rollback();
                updateToCustomers(customer);
                CloseConnection();
            }
        }

        private void updateToCustomers(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Customers");
            sb.Append(" SET Prefix=@Prefix,");
            sb.Append("CustomerName=@CustomerName,");
            sb.Append("Address=@Address,");
            sb.Append("Tel=@Tel,");
            sb.Append("Mobile=@Mobile,");
            sb.Append("Fax=@Fax,");
            sb.Append("Email=@Email,");
            sb.Append("Reciever=@Reciever,");
            sb.Append("Job=@Job,");
            sb.Append("CustomerNote=@CustomerNote");
            sb.Append(" WHERE CustomerID=@CustomerID");

            string sqlUpdate = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlUpdate;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Add("@Prefix", OleDbType.VarChar).Value = customer.Prefix;
            com.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = customer.Name;
            com.Parameters.Add("@Address", OleDbType.VarChar).Value = customer.Address;
            com.Parameters.Add("@Tel", OleDbType.VarChar).Value = customer.Tel;
            com.Parameters.Add("@Mobile", OleDbType.VarChar).Value = customer.Mobile;
            com.Parameters.Add("@Fax", OleDbType.VarChar).Value = customer.Fax;
            com.Parameters.Add("@Email", OleDbType.VarChar).Value = customer.Email;
            com.Parameters.Add("@Reciever", OleDbType.VarChar).Value = customer.Reciever;
            com.Parameters.Add("@Job", OleDbType.VarChar).Value = customer.Job;
            com.Parameters.Add("@CustomerNote", OleDbType.VarChar).Value = customer.Note;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = customer.ID;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                MessageBox.Show("แก้ไขข้อมูลลูกค้าท่านนี้เรียบร้อยแล้วค่ะ", cstTitle);
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
        }

        private void deleteCustomer(string strCustomerID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM Customers WHERE CustomerID=@CustomerID");
            string sqlDelete = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlDelete;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = strCustomerID;

            int iRowAffect = 0;
            try
            {
                iRowAffect = com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                if (iRowAffect != 0)
                {
                    MessageBox.Show("ลบข้อมูลลูกค้าท่านนี้เรียบร้อยแล้วค่ะ", cstTitle);
                }
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
            btnSearchEachMember.Enabled = true;
            clearFieldCustomer();
            setReadOnlyFieldCustomer(true);
            tbCustomerID.ReadOnly = false;
        }

        private void btnSearchEachMember_Click(object sender, EventArgs e)
        {
            buttonNew.Enabled = true;
            
            string strSearchCustomer = tbCustomerID.Text.Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Customers");
            sb.Append(" WHERE CustomerID=@CustomerID");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader dr;
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;
            com.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = strSearchCustomer;

            try
            {
                dr = com.ExecuteReader();
                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    DataRow dataRow = dt.Rows[0];
                    cbPrefix.SelectedItem = dataRow["Prefix"].ToString();
                    tbCustomerName.Text = dataRow["CustomerName"].ToString();
                    tbAddress.Text = dataRow["Address"].ToString();
                    tbTel.Text = dataRow["Tel"].ToString();
                    tbMobile.Text = dataRow["Mobile"].ToString();
                    tbFax.Text = dataRow["Fax"].ToString();
                    tbEmail.Text = dataRow["Email"].ToString();
                    tbReciever.Text = dataRow["Reciever"].ToString();
                    tbJob.Text = dataRow["Job"].ToString();
                    tbCustomerNote.Text = dataRow["CustomerNote"].ToString();

                    buttonEdit.Enabled = true;
                    buttonDelete.Enabled = true;
                }
                else
                {
                    clearFieldCustomer();
                    MessageBox.Show("ไม่มีสมาชิกท่านใดตรงกับรหัสลูกค้านี้ค่ะ", cstWarning);
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

        private void btnCancelCusCommand_Click(object sender, EventArgs e)
        {
            buttonNew.Enabled = true;
            buttonEdit.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
            clearFieldCustomer();
            setReadOnlyFieldCustomer(true);
            tbCustomerID.ReadOnly = false;
            btnSearchEachMember.Enabled = true;
            btnCancelCusCommand.Visible = false;
            tbCustomerID.Focus();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CustomerID,CustomerName,Tel,Mobile");
            sb.Append(" FROM Customers");

            string sqlSelect = sb.ToString();

            if (radByCustomerID.Checked == true)
            {
                sqlSelect = sqlSelect + " WHERE CustomerID LIKE '" + tbSearchCustomer.Text.Trim() + "%'";
            }
            else if (radByCustomerName.Checked == true)
            {
                sqlSelect = sqlSelect + " WHERE CustomerName LIKE '" + tbSearchCustomer.Text.Trim() + "%'";
            }

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 2].Cells[0].Value = dt.Rows[i]["CustomerID"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 2].Cells[1].Value = dt.Rows[i]["CustomerName"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 2].Cells[2].Value = dt.Rows[i]["Tel"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 2].Cells[3].Value = dt.Rows[i]["Mobile"];
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

#endregion

//จัดการทะเบียนสินค้า
#region Product

        public void clearFieldProduct()
        {
            tbProductID.Text = "";
            tbBarcode.Text = "";
            tbProductName.Text = "";
            cbUnitType.SelectedIndex = -1;
            cbUnitType.Text = "เลือกหน่วยนับ";
            tbProductName.Text = "";
            cbUnitType.SelectedIndex = -1;
            cbUnitType.Text = "เลือกขนาด";
            tbCost.Text = "";
            tbPrice1.Text = "";
            tbPrice2.Text = "";
            cbColor.SelectedIndex = -1;
            cbColor.Text = "เลือกสี";
            cbSize.SelectedIndex = -1;
            cbSize.Text = "เลือกขนาด";
        }

        public void setReadOnlyFieldProduct(bool bValue)
        {
            tbBarcode.ReadOnly = bValue;
            tbProductName.ReadOnly = bValue;
            tbProductName.ReadOnly = bValue;
            tbCost.ReadOnly = bValue;
            tbPrice1.ReadOnly = bValue;
            tbPrice2.ReadOnly = bValue;
            tbProductNote.ReadOnly = bValue;
        }

        private bool checkDuplicateProductID(string strProductID)
        {
            bool bDuplicate = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(ProductID) AS CountProductID");
            sb.Append(" FROM Products");
            sb.Append(" WHERE ProductID=@ProductID");

            string sqlSelect = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;
            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = strProductID;

            try
            {
                OleDbDataReader dr = com.ExecuteReader();

                DataTable tr = new DataTable();
                tr.Load(dr);

                int iCount = int.Parse(tr.Rows[0]["CountProductID"].ToString());
                if (iCount == 1)
                    return true;

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, cstWarning);
            }

            CloseConnection();

            return bDuplicate;
        }

        private bool addDataToProduct(ProductDetail product)
        {
            bool bCheck = true;

            product.ID = tbProductID.Text.Trim();
            product.Name = tbProductName.Text.Trim();
            product.Barcode = tbBarcode.Text.Trim();
            product.Name = tbProductName.Text.Trim();
            product.UnitCode = ProductDetail.getUnitCode(cbUnitType.SelectedIndex, cbUnitType.SelectedItem.ToString());

            try
            {
                product.Cost = Double.Parse(tbCost.Text.Trim());
            }
            catch
            {
                MessageBox.Show("ราคาต้นทุนต้องเป็นตัวเลขเท่านั้นค่ะ เช่น 20.50 เป็นต้น", cstWarning);
                return false;
            }

            try
            {
                product.Price = Double.Parse(tbPrice1.Text.Trim());
            }
            catch
            {
                MessageBox.Show("ราคาขายที่ 1 ต้องเป็นตัวเลขเท่านั้นค่ะ เช่น 20.50 เป็นต้น", cstWarning);
                return false;
            }

            try
            {
                product.Price2 = Double.Parse(tbPrice2.Text.Trim());
            }
            catch
            {
                MessageBox.Show("ราคาขายที่ 2 ต้องเป็นตัวเลขเท่านั้นค่ะ เช่น 20.50 เป็นต้น", cstWarning);
                return false;
            }

            product.ColorCode = ProductDetail.getColorCode(cbColor.SelectedIndex, cbColor.SelectedItem.ToString());
            product.SizeCode = ProductDetail.getSizeCode(cbSize.SelectedIndex, cbSize.SelectedItem.ToString());
            product.Note = tbProductNote.Text.Trim();

            return bCheck;
        }

        private bool checkNewProduct(ProductDetail product)
        {
            bool bCheck = true;
            string strError1 = "";
            string strError2 = "";
            string strError3 = "";
            string strError4 = "";

            if (product.ID.Length < 5)
                strError1 = strError1 + "คุณกรอกรหัสสินค้าไม่ครบ 5 ตัวค่ะ";

            if (product.Barcode.Length == 0)
                strError2 = strError2 + "Barcode ";

            if (product.Name.Length == 0)
                strError2 = strError2 + "ชื่อสินค้า ";

            if (product.UnitCode == ProductDetail.cstNotChooseUnit)
                strError3 = strError3 + "หน่วยนับ ";

            if (product.Cost <= 1)
                strError4 = strError4 + "ราคาต้นทุน ";

            if (product.Price <= 1)
                strError4 = strError4 + "ราคาขาย1 ";

            if (product.Price2 <= 1)
                strError4 = strError4 + "ราคาขาย2 ";

            if (product.ColorCode == ProductDetail.cstNotChooseColor)
                strError3 = strError3 + "สี ";

            if (product.SizeCode == ProductDetail.cstNotChooseSize)
                strError3 = strError3 + "ขนาด ";

            if (strError1 != "")
                strError1 = strError1 + "ค่ะ";

            if (strError2 != "")
            {
                strError1 = strError1 + Environment.NewLine;
                strError1 = strError1 + "คุณยังไม่ได้กรอก" + strError2 + "ค่ะ";
            }

            if (strError3 != "")
            {
                strError1 = strError1 + Environment.NewLine;
                strError1 = strError1 + "คุณยังไม่ได้เลือก" + strError3 + "ค่ะ";
            }

            if (strError4 != "")
            {
                strError1 = strError1 + Environment.NewLine;
                strError1 = strError1 + "ราคา" + strError4 + "ต้องมีค่าอย่างน้อย 1 บาทค่ะ";
            }

            if (strError1 != "")
            {
                bCheck = false;
                MessageBox.Show(strError1, cstWarning);
            }

            return bCheck;
        }

        private void insertToProducts(ProductDetail product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Products(ProductID,Barcode,ProductName,UnitCode,");
            sb.Append("Cost,Price,Price2,ColorCode,SizeCode,ProductNote)");
            sb.Append(" VALUES(@ProductID,@BarCode,@ProductName,@UnitCode,");
            sb.Append("@Cost,@Price,@Price2,@ColorCode,@SizeCode,@ProductNote)");

            string sqlInsert = sb.ToString();
            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlInsert;
            com.Connection = Conn;
            com.Transaction = tr;

            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = product.ID;
            com.Parameters.Add("@BarCode", OleDbType.VarChar).Value = product.Barcode;
            com.Parameters.Add("@ProductName", OleDbType.VarChar).Value = product.Name;
            com.Parameters.Add("@UnitCode", OleDbType.VarChar).Value = product.UnitCode;
            com.Parameters.Add("@Cost", OleDbType.Single).Value = product.Cost;
            com.Parameters.Add("@Price", OleDbType.Single).Value = product.Price;
            com.Parameters.Add("@Price2", OleDbType.Single).Value = product.Price2;
            com.Parameters.Add("@ColorCode", OleDbType.VarChar).Value = product.ColorCode;
            com.Parameters.Add("@SizeCode", OleDbType.VarChar).Value = product.SizeCode;
            com.Parameters.Add("@ProductNote", OleDbType.VarChar).Value = product.Note;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                MessageBox.Show("เพิ่มข้อมูลสินค้าเรียบร้อยแล้วค่ะ", cstTitle);
            }
            catch
            {
                tr.Rollback();
                CloseConnection();
                updateToProduct(product);
            }
        }

        private void updateToProduct(ProductDetail product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update Products");
            sb.Append(" SET Barcode=@Barcode,");
            sb.Append("ProductName=@ProductName,");
            sb.Append("UnitCode=@UnitCode,");
            sb.Append("Cost=@Cost,");
            sb.Append("Price=@Price,");
            sb.Append("Price2=@Price2,");
            sb.Append("ColorCode=@ColorCode,");
            sb.Append("SizeCode=@SizeCode,");
            sb.Append("ProductNote=@ProductNote");
            sb.Append(" WHERE ProductID=@ProductID");

            string sqlUpdate = sb.ToString();
            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlUpdate;
            com.Connection = Conn;
            com.Transaction = tr;

            com.Parameters.Add("@Barcode", OleDbType.VarChar).Value = product.Barcode;
            com.Parameters.Add("@ProductName", OleDbType.VarChar).Value = product.Name;
            com.Parameters.Add("@UnitCode", OleDbType.VarChar).Value = product.UnitCode;
            com.Parameters.Add("@Cost", OleDbType.Single).Value = product.Cost;
            com.Parameters.Add("@Price", OleDbType.Single).Value = product.Price;
            com.Parameters.Add("@Price2", OleDbType.Single).Value = product.Price2;
            com.Parameters.Add("@ColorCode", OleDbType.VarChar).Value = product.ColorCode;
            com.Parameters.Add("@SizeCode", OleDbType.VarChar).Value = product.SizeCode;
            com.Parameters.Add("@ProductNote", OleDbType.VarChar).Value = product.Note;
            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = product.ID;

            try
            {
                com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                MessageBox.Show("แก้ไขข้อมูลสินค้านี้เรียบร้อยแล้วค่ะ", cstTitle);
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
        }

        private void deleteProduct(string strProductID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM Products WHERE ProductID=@ProductID");
            string sqlDelete = sb.ToString();

            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            OleDbTransaction tr = Conn.BeginTransaction();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlDelete;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = strProductID;

            int iRowAffect = 0;
            try
            {
                iRowAffect = com.ExecuteNonQuery();
                tr.Commit();
                CloseConnection();
                if (iRowAffect != 0)
                {
                    MessageBox.Show("ลบข้อมูลสินค้านี้เรียบร้อยแล้วค่ะ", cstTitle);
                }
            }
            catch (Exception ex)
            {
                tr.Rollback();
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }
            btnSearchEachProduct.Enabled = true;
            clearFieldProduct();
            setReadOnlyFieldProduct(true);
            tbProductID.ReadOnly = false;
        }

        private void btnSearchEachProduct_Click(object sender, EventArgs e)
        {
            buttonNew.Enabled = true;
            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Products");
            sb.Append(" WHERE ProductID=@ProductID");

            string sqlSelect = sb.ToString();
            OpenConnection();
            OleDbCommand com = new OleDbCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlSelect;
            com.Connection = Conn;

            com.Parameters.Add("@ProductID", OleDbType.VarChar).Value = tbProductID.Text.Trim();
            OleDbDataReader dr;

            try
            {
                dr = com.ExecuteReader();
                if (dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    DataRow dataRow = dt.Rows[0];
                    tbBarcode.Text = dataRow["BarCode"].ToString();
                    tbProductName.Text = dataRow["ProductName"].ToString();
                    cbUnitType.SelectedIndex = (int.Parse(dataRow["UnitCode"].ToString()) - 1);
                    tbCost.Text = dataRow["Cost"].ToString();
                    tbPrice1.Text = dataRow["Price"].ToString();
                    tbPrice2.Text = dataRow["Price2"].ToString();
                    string strColorCode = dataRow["ColorCode"].ToString();
                    cbColor.SelectedItem = ProductDetail.getColorName(strColorCode);
                    string strSizeCode = dataRow["SizeCode"].ToString();
                    cbSize.SelectedItem = ProductDetail.getSizeName(strSizeCode);
                    tbProductNote.Text = dataRow["ProductNote"].ToString();

                    buttonEdit.Enabled = true;
                    buttonDelete.Enabled = true;
                }
                else
                {
                    clearFieldProduct();
                    MessageBox.Show("ไม่มีสินค้าที่ตรงกับรหัสสินค้านี้ค่ะ", cstWarning);
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message, cstWarning);
            }

            CloseConnection();
        }

        private void btnCancelProCommand_Click(object sender, EventArgs e)
        {
            clearFieldProduct();
            setReadOnlyFieldProduct(true);

            buttonNew.Enabled = true;
            buttonEdit.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;

            tbProductID.ReadOnly = false;
            btnSearchEachProduct.Enabled = true;
            btnCancelProCommand.Visible = false;
            tbProductID.Focus();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            dgvProduct.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ProductID,Barcode,ProductName,Price,ColorCode,SizeCode");
            sb.Append(" FROM Products");

            string sqlSelect = sb.ToString();

            if (radByProductID.Checked == true)
            {
                sqlSelect = sqlSelect + " WHERE ProductID LIKE '" + tbSearchProduct.Text + "%'";
            }
            else if (radByProductName.Checked == true)
            {
                sqlSelect = sqlSelect + " WHERE ProductName LIKE '" + tbSearchProduct.Text + "%'";
            }

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

                    if (dgvProduct.Rows.Count == 2)
                    {
                        dgvProduct.Rows.RemoveAt(0);
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvProduct.Rows.Add();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[0].Value = dt.Rows[i]["ProductID"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[1].Value = dt.Rows[i]["Barcode"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[2].Value = dt.Rows[i]["ProductName"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[3].Value = dt.Rows[i]["Price"];

                        string strColorCode = dt.Rows[i]["ColorCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[4].Value = ProductDetail.getColorName(strColorCode);

                        string strSizeCode = dt.Rows[i]["SizeCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 2].Cells[5].Value = ProductDetail.getSizeName(strSizeCode);
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
#endregion

    }//End of partial class
}//End of namespace
