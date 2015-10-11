namespace DollSelling
{
    partial class FormSearchPro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchPro));
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.รหัสสินค้า = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearchProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radByProductName = new System.Windows.Forms.RadioButton();
            this.radByProductID = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.radTotal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "ค้นหาโดย";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchProduct.Location = new System.Drawing.Point(328, 45);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(75, 23);
            this.btnSearchProduct.TabIndex = 20;
            this.btnSearchProduct.Text = "ค้นหา";
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.รหัสสินค้า,
            this.ColumnBarcode,
            this.ColumnProName,
            this.ColumnPrice,
            this.ColumnColor,
            this.ColumnSize});
            this.dgvProduct.Location = new System.Drawing.Point(30, 76);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(652, 371);
            this.dgvProduct.TabIndex = 19;
            this.dgvProduct.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellEnter);
            // 
            // รหัสสินค้า
            // 
            this.รหัสสินค้า.HeaderText = "รหัสสินค้า";
            this.รหัสสินค้า.Name = "รหัสสินค้า";
            this.รหัสสินค้า.ReadOnly = true;
            // 
            // ColumnBarcode
            // 
            this.ColumnBarcode.HeaderText = "Barcode";
            this.ColumnBarcode.Name = "ColumnBarcode";
            this.ColumnBarcode.ReadOnly = true;
            // 
            // ColumnProName
            // 
            this.ColumnProName.HeaderText = "ชื่อสินค้า";
            this.ColumnProName.Name = "ColumnProName";
            this.ColumnProName.ReadOnly = true;
            this.ColumnProName.Width = 200;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "ราคา/หน่วย";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            // 
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "สี";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.ReadOnly = true;
            this.ColumnColor.Width = 50;
            // 
            // ColumnSize
            // 
            this.ColumnSize.HeaderText = "ขนาด";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ReadOnly = true;
            this.ColumnSize.Width = 50;
            // 
            // tbSearchProduct
            // 
            this.tbSearchProduct.Location = new System.Drawing.Point(72, 47);
            this.tbSearchProduct.MaxLength = 5;
            this.tbSearchProduct.Name = "tbSearchProduct";
            this.tbSearchProduct.Size = new System.Drawing.Size(248, 20);
            this.tbSearchProduct.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "คำค้น";
            // 
            // radByProductName
            // 
            this.radByProductName.AutoSize = true;
            this.radByProductName.Location = new System.Drawing.Point(167, 22);
            this.radByProductName.Name = "radByProductName";
            this.radByProductName.Size = new System.Drawing.Size(64, 17);
            this.radByProductName.TabIndex = 16;
            this.radByProductName.Text = "ชื่อสินค้า";
            this.radByProductName.UseVisualStyleBackColor = true;
            this.radByProductName.Click += new System.EventHandler(this.radByProductName_Click);
            // 
            // radByProductID
            // 
            this.radByProductID.AutoSize = true;
            this.radByProductID.Checked = true;
            this.radByProductID.Location = new System.Drawing.Point(91, 22);
            this.radByProductID.Name = "radByProductID";
            this.radByProductID.Size = new System.Drawing.Size(70, 17);
            this.radByProductID.TabIndex = 15;
            this.radByProductID.TabStop = true;
            this.radByProductID.Text = "รหัสสินค้า";
            this.radByProductID.UseVisualStyleBackColor = true;
            this.radByProductID.Click += new System.EventHandler(this.radByProductID_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(348, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "ออก";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelect.Location = new System.Drawing.Point(267, 453);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 22;
            this.btnSelect.Text = "เลือก";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // radTotal
            // 
            this.radTotal.AutoSize = true;
            this.radTotal.Location = new System.Drawing.Point(237, 22);
            this.radTotal.Name = "radTotal";
            this.radTotal.Size = new System.Drawing.Size(58, 17);
            this.radTotal.TabIndex = 24;
            this.radTotal.Text = "ทั้งหมด";
            this.radTotal.UseVisualStyleBackColor = true;
            this.radTotal.Click += new System.EventHandler(this.radTotal_Click);
            // 
            // FormSearchPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(708, 482);
            this.Controls.Add(this.radTotal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.tbSearchProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radByProductName);
            this.Controls.Add(this.radByProductID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาสินค้า";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.TextBox tbSearchProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radByProductName;
        private System.Windows.Forms.RadioButton radByProductID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.RadioButton radTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn รหัสสินค้า;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
    }
}