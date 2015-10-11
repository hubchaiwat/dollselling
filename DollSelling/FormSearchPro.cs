using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Product.ProductDetail;

namespace DollSelling
{
    public partial class FormSearchPro : Form
    {
        public FormSearchPro()
        {
            InitializeComponent();

            dgvProduct.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ProductID,Barcode,ProductName,Price,ColorCode,SizeCode");
            sb.Append(" FROM Products");

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

                    btnSelect.Enabled = true;
                    strProductID = dt.Rows[0]["ProductID"].ToString();
                    strProductName = dt.Rows[0]["ProductName"].ToString();
                    dbPrice = double.Parse(dt.Rows[0]["Price"].ToString());

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvProduct.Rows.Add();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[0].Value = dt.Rows[i]["ProductID"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[1].Value = dt.Rows[i]["Barcode"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[2].Value = dt.Rows[i]["ProductName"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[3].Value = dt.Rows[i]["Price"];

                        string strColorCode = dt.Rows[i]["ColorCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[4].Value = ProductDetail.getColorName(strColorCode);

                        string strSizeCode = dt.Rows[i]["SizeCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[5].Value = ProductDetail.getSizeName(strSizeCode);
                    }
                }
                else
                {
                    btnSelect.Enabled = false;
                    strProductID = "";
                    strProductName = "";
                    dbPrice = 0.0d;
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

#region Member
        private bool bSelected = false;
        private string strProductID = "";
        private string strProductName = "";
        private double dbPrice = 0.0d;
#endregion

#region Property

        public bool Selected
        {
            get { return bSelected; }
        }

        public string ProductID
        {
            get { return strProductID; }
        }

        public string ProductName
        {
            get { return strProductName; }
        }

        public double Price
        {
            get { return dbPrice; }
        }

#endregion

        private void radByProductID_Click(object sender, EventArgs e)
        {
            tbSearchProduct.Enabled = true;
            tbSearchProduct.Text = "";
            tbSearchProduct.MaxLength = 5;
            tbSearchProduct.Focus();
        }

        private void radByProductName_Click(object sender, EventArgs e)
        {
            tbSearchProduct.Enabled = true;
            tbSearchProduct.Text = "";
            tbSearchProduct.MaxLength = 40;
            tbSearchProduct.Focus();
        }

        private void radTotal_Click(object sender, EventArgs e)
        {
            tbSearchProduct.Enabled = false;
            tbSearchProduct.Text = "";
            btnSearchProduct.Focus();
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

                    btnSelect.Enabled = true;
                    strProductID = dt.Rows[0]["ProductID"].ToString();
                    strProductName = dt.Rows[0]["ProductName"].ToString();
                    dbPrice = double.Parse(dt.Rows[0]["Price"].ToString());

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvProduct.Rows.Add();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[0].Value = dt.Rows[i]["ProductID"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[1].Value = dt.Rows[i]["Barcode"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[2].Value = dt.Rows[i]["ProductName"];
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[3].Value = dt.Rows[i]["Price"];

                        string strColorCode = dt.Rows[i]["ColorCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[4].Value = ProductDetail.getColorName(strColorCode);

                        string strSizeCode = dt.Rows[i]["SizeCode"].ToString();
                        dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[5].Value = ProductDetail.getSizeName(strSizeCode);
                    }
                }
                else
                {
                    btnSelect.Enabled = false;
                    strProductID = "";
                    strProductName = "";
                    dbPrice = 0.0d;
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

        private void dgvProduct_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strProductID = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                strProductName = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                dbPrice = double.Parse(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            bSelected = true;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bSelected = false;
            this.Close();
        }
    }
}
