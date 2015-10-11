using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DollSelling
{
    public partial class FormSearchCus : Form
    {
        public FormSearchCus()
        {
            InitializeComponent();

            dgvCustomer.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CustomerID,Prefix,CustomerName,Tel,Mobile");
            sb.Append(" FROM Customers");

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

                    strCustomerID = dt.Rows[0]["CustomerID"].ToString();
                    strCustomerName = dt.Rows[0]["CustomerName"].ToString();
                    btnSelect.Enabled = true;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[0].Value = dt.Rows[i]["CustomerID"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[1].Value = dt.Rows[i]["Prefix"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[2].Value = dt.Rows[i]["CustomerName"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[3].Value = dt.Rows[i]["Tel"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[4].Value = dt.Rows[i]["Mobile"];
                    }
                }
                else
                {
                    strCustomerID = "";
                    strCustomerName = "";
                    btnSelect.Enabled = false;
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
        private string strCustomerID = "";
        private string strCustomerName = "";

#endregion

#region Property

        public bool Selected
        {
            get { return bSelected; }
        }

        public string SelectCustomerID
        {
            get { return strCustomerID; }
        }

        public string SelectCustomerName
        {
            get { return strCustomerName; }
        }

#endregion

        private void radByCustomerID_Click(object sender, EventArgs e)
        {
            tbSearchCustomer.Enabled = true;
            tbSearchCustomer.Text = "";
            tbSearchCustomer.MaxLength = 5;
            tbSearchCustomer.Focus();
        }

        private void radByCustomerName_Click(object sender, EventArgs e)
        {
            tbSearchCustomer.Enabled = true;
            tbSearchCustomer.Text = "";
            tbSearchCustomer.MaxLength = 40;
            tbSearchCustomer.Focus();
        }

        private void radTotal_Click(object sender, EventArgs e)
        {
            tbSearchCustomer.Enabled = false;
            tbSearchCustomer.Text = "";
            btnSearchCustomer.Focus();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT CustomerID,Prefix,CustomerName,Tel,Mobile");
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

                    strCustomerID = dt.Rows[0]["CustomerID"].ToString();
                    strCustomerName = dt.Rows[0]["CustomerName"].ToString();
                    btnSelect.Enabled = true;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dataRow = dt.Rows[0];
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[0].Value = dt.Rows[i]["CustomerID"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[1].Value = dt.Rows[i]["Prefix"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[2].Value = dt.Rows[i]["CustomerName"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[3].Value = dt.Rows[i]["Tel"];
                        dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells[4].Value = dt.Rows[i]["Mobile"];
                    }
                }
                else
                {
                    strCustomerID = "";
                    strCustomerName = "";
                    btnSelect.Enabled = false;
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

        private void dgvCustomer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strCustomerID = dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                strCustomerName = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
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
