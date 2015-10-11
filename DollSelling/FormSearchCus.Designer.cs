namespace DollSelling
{
    partial class FormSearchCus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchCus));
            this.radByCustomerName = new System.Windows.Forms.RadioButton();
            this.radByCustomerID = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearchCustomer = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.radTotal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // radByCustomerName
            // 
            this.radByCustomerName.AutoSize = true;
            this.radByCustomerName.Location = new System.Drawing.Point(162, 28);
            this.radByCustomerName.Name = "radByCustomerName";
            this.radByCustomerName.Size = new System.Drawing.Size(63, 17);
            this.radByCustomerName.TabIndex = 16;
            this.radByCustomerName.Text = "ชื่อลูกค้า";
            this.radByCustomerName.UseVisualStyleBackColor = true;
            this.radByCustomerName.Click += new System.EventHandler(this.radByCustomerName_Click);
            // 
            // radByCustomerID
            // 
            this.radByCustomerID.AutoSize = true;
            this.radByCustomerID.Checked = true;
            this.radByCustomerID.Location = new System.Drawing.Point(87, 28);
            this.radByCustomerID.Name = "radByCustomerID";
            this.radByCustomerID.Size = new System.Drawing.Size(69, 17);
            this.radByCustomerID.TabIndex = 15;
            this.radByCustomerID.TabStop = true;
            this.radByCustomerID.Text = "รหัสลูกค้า";
            this.radByCustomerID.UseVisualStyleBackColor = true;
            this.radByCustomerID.Click += new System.EventHandler(this.radByCustomerID_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "ค้นหาโดย";
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchCustomer.Location = new System.Drawing.Point(338, 51);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCustomer.TabIndex = 13;
            this.btnSearchCustomer.Text = "ค้นหา";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.Column1,
            this.CustomerName,
            this.Tel,
            this.Mobile});
            this.dgvCustomer.Location = new System.Drawing.Point(12, 80);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(684, 358);
            this.dgvCustomer.TabIndex = 12;
            this.dgvCustomer.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellEnter);
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "รหัสลูกค้า";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "คำนำหน้า";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "ชื่อ";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 200;
            // 
            // Tel
            // 
            this.Tel.HeaderText = "โทรศัพท์";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            this.Tel.Width = 140;
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "มือถือ";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            this.Mobile.Width = 140;
            // 
            // tbSearchCustomer
            // 
            this.tbSearchCustomer.Location = new System.Drawing.Point(82, 53);
            this.tbSearchCustomer.MaxLength = 5;
            this.tbSearchCustomer.Name = "tbSearchCustomer";
            this.tbSearchCustomer.Size = new System.Drawing.Size(248, 20);
            this.tbSearchCustomer.TabIndex = 11;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(28, 56);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(46, 13);
            this.label72.TabIndex = 10;
            this.label72.Text = "คำค้นหา";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(285, 447);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 17;
            this.btnSelect.Text = "เลือก";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(366, 447);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "ออก";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radTotal
            // 
            this.radTotal.AutoSize = true;
            this.radTotal.Location = new System.Drawing.Point(231, 28);
            this.radTotal.Name = "radTotal";
            this.radTotal.Size = new System.Drawing.Size(58, 17);
            this.radTotal.TabIndex = 25;
            this.radTotal.Text = "ทั้งหมด";
            this.radTotal.UseVisualStyleBackColor = true;
            this.radTotal.Click += new System.EventHandler(this.radTotal_Click);
            // 
            // FormSearchCus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(708, 482);
            this.Controls.Add(this.radTotal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.radByCustomerName);
            this.Controls.Add(this.radByCustomerID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSearchCustomer);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.tbSearchCustomer);
            this.Controls.Add(this.label72);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchCus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาลูกค้า";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radByCustomerName;
        private System.Windows.Forms.RadioButton radByCustomerID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.TextBox tbSearchCustomer;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.RadioButton radTotal;
    }
}