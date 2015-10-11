namespace DollSelling
{
    partial class FormSell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSell));
            this.popCustomer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSearchBill = new System.Windows.Forms.TextBox();
            this.btnSearchBill = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.tbSellNoBill = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSellSeller = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSellPrint = new System.Windows.Forms.Button();
            this.dgvSell = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSellCustomerName = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.tbSellCustomerID = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.popProduct = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPriceBeforeDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelEachOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPerUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbSellProductID = new System.Windows.Forms.TextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.tbSellProductName = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.btnSellCancel = new System.Windows.Forms.Button();
            this.dtpSellDate = new System.Windows.Forms.DateTimePicker();
            this.tbDatePastBill = new System.Windows.Forms.TextBox();
            this.btnNewBill = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // popCustomer
            // 
            this.popCustomer.AutoSize = true;
            this.popCustomer.BackColor = System.Drawing.Color.Yellow;
            this.popCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.popCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.popCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.popCustomer.Location = new System.Drawing.Point(212, 86);
            this.popCustomer.Name = "popCustomer";
            this.popCustomer.Size = new System.Drawing.Size(181, 17);
            this.popCustomer.TabIndex = 78;
            this.popCustomer.Text = "ระบุรหัสสินค้า (ถ้าไม่ทราบ กดปุ่ม F3)";
            this.popCustomer.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gold;
            this.groupBox1.Controls.Add(this.tbSearchBill);
            this.groupBox1.Controls.Add(this.btnSearchBill);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(104, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 46);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหาใบเสร็จ";
            // 
            // tbSearchBill
            // 
            this.tbSearchBill.Location = new System.Drawing.Point(87, 20);
            this.tbSearchBill.Name = "tbSearchBill";
            this.tbSearchBill.Size = new System.Drawing.Size(100, 20);
            this.tbSearchBill.TabIndex = 53;
            this.tbSearchBill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchBill_KeyPress);
            // 
            // btnSearchBill
            // 
            this.btnSearchBill.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchBill.Location = new System.Drawing.Point(192, 18);
            this.btnSearchBill.Name = "btnSearchBill";
            this.btnSearchBill.Size = new System.Drawing.Size(66, 23);
            this.btnSearchBill.TabIndex = 51;
            this.btnSearchBill.Text = "ค้นหา";
            this.btnSearchBill.UseVisualStyleBackColor = false;
            this.btnSearchBill.Click += new System.EventHandler(this.btnSearchBill_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "เลขที่ใบเสร็จ";
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSaveBill.Enabled = false;
            this.btnSaveBill.Location = new System.Drawing.Point(287, 479);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBill.TabIndex = 75;
            this.btnSaveBill.Text = "บันทึก";
            this.btnSaveBill.UseVisualStyleBackColor = false;
            this.btnSaveBill.Click += new System.EventHandler(this.btnSaveBill_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(730, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "บาท";
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.BackColor = System.Drawing.Color.White;
            this.tbTotalPrice.Enabled = false;
            this.tbTotalPrice.Location = new System.Drawing.Point(625, 481);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            this.tbTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.tbTotalPrice.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(570, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "ราคาสุทธิ";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDeleteOrder.Enabled = false;
            this.btnDeleteOrder.Location = new System.Drawing.Point(102, 479);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 70;
            this.btnDeleteOrder.Text = "ลบสินค้า";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // tbSellNoBill
            // 
            this.tbSellNoBill.BackColor = System.Drawing.Color.White;
            this.tbSellNoBill.Enabled = false;
            this.tbSellNoBill.Location = new System.Drawing.Point(621, 88);
            this.tbSellNoBill.Name = "tbSellNoBill";
            this.tbSellNoBill.Size = new System.Drawing.Size(104, 20);
            this.tbSellNoBill.TabIndex = 58;
            this.tbSellNoBill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSellNoBill_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(548, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "เลขที่ใบเสร็จ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(291, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "วันที่";
            // 
            // tbSellSeller
            // 
            this.tbSellSeller.BackColor = System.Drawing.Color.White;
            this.tbSellSeller.Enabled = false;
            this.tbSellSeller.Location = new System.Drawing.Point(183, 88);
            this.tbSellSeller.MaxLength = 40;
            this.tbSellSeller.Name = "tbSellSeller";
            this.tbSellSeller.Size = new System.Drawing.Size(100, 20);
            this.tbSellSeller.TabIndex = 57;
            this.tbSellSeller.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSellSeller_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(117, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "ชื่อพนักงาน";
            // 
            // btnSellPrint
            // 
            this.btnSellPrint.BackColor = System.Drawing.Color.Lime;
            this.btnSellPrint.Enabled = false;
            this.btnSellPrint.Location = new System.Drawing.Point(368, 479);
            this.btnSellPrint.Name = "btnSellPrint";
            this.btnSellPrint.Size = new System.Drawing.Size(75, 23);
            this.btnSellPrint.TabIndex = 65;
            this.btnSellPrint.Text = "พิมพ์";
            this.btnSellPrint.UseVisualStyleBackColor = false;
            this.btnSellPrint.Click += new System.EventHandler(this.btnSellPrint_Click);
            // 
            // dgvSell
            // 
            this.dgvSell.AllowUserToAddRows = false;
            this.dgvSell.AllowUserToDeleteRows = false;
            this.dgvSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSell.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvSell.Enabled = false;
            this.dgvSell.Location = new System.Drawing.Point(103, 244);
            this.dgvSell.Name = "dgvSell";
            this.dgvSell.Size = new System.Drawing.Size(667, 231);
            this.dgvSell.TabIndex = 64;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "รหัสสินค้า";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ชื่อสินค้า";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 130;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ราคา/หน่วย";
            this.Column7.Name = "Column7";
            this.Column7.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "จำนวน";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ส่วนลด";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ราคาหลังหักส่วนลด";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 150;
            // 
            // tbSellCustomerName
            // 
            this.tbSellCustomerName.BackColor = System.Drawing.Color.White;
            this.tbSellCustomerName.Enabled = false;
            this.tbSellCustomerName.Location = new System.Drawing.Point(342, 60);
            this.tbSellCustomerName.Name = "tbSellCustomerName";
            this.tbSellCustomerName.ReadOnly = true;
            this.tbSellCustomerName.Size = new System.Drawing.Size(301, 20);
            this.tbSellCustomerName.TabIndex = 63;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(291, 63);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(45, 13);
            this.label90.TabIndex = 62;
            this.label90.Text = "ชื่อลูกค้า";
            // 
            // tbSellCustomerID
            // 
            this.tbSellCustomerID.BackColor = System.Drawing.Color.White;
            this.tbSellCustomerID.Location = new System.Drawing.Point(183, 60);
            this.tbSellCustomerID.MaxLength = 5;
            this.tbSellCustomerID.Name = "tbSellCustomerID";
            this.tbSellCustomerID.Size = new System.Drawing.Size(64, 20);
            this.tbSellCustomerID.TabIndex = 56;
            this.tbSellCustomerID.Enter += new System.EventHandler(this.tbSellCustomerID_Enter);
            this.tbSellCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSellCustomerID_KeyPress);
            this.tbSellCustomerID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSellCustomerID_KeyUp);
            this.tbSellCustomerID.Leave += new System.EventHandler(this.tbSellCustomerID_Leave);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(117, 63);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(51, 13);
            this.label89.TabIndex = 61;
            this.label89.Text = "รหัสลูกค้า";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.GreenYellow;
            this.groupBox8.Controls.Add(this.popProduct);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.tbPriceBeforeDiscount);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.btnCancelEachOrder);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.tbPerUnit);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.tbAmount);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.tbDiscount);
            this.groupBox8.Controls.Add(this.tbSellProductID);
            this.groupBox8.Controls.Add(this.label113);
            this.groupBox8.Controls.Add(this.tbSellProductName);
            this.groupBox8.Controls.Add(this.label115);
            this.groupBox8.Controls.Add(this.label114);
            this.groupBox8.Location = new System.Drawing.Point(103, 114);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(667, 109);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "เพิ่มสินค้า";
            // 
            // popProduct
            // 
            this.popProduct.AutoSize = true;
            this.popProduct.BackColor = System.Drawing.Color.Yellow;
            this.popProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.popProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.popProduct.Location = new System.Drawing.Point(109, 50);
            this.popProduct.Name = "popProduct";
            this.popProduct.Size = new System.Drawing.Size(181, 17);
            this.popProduct.TabIndex = 54;
            this.popProduct.Text = "ระบุรหัสสินค้า (ถ้าไม่ทราบ กดปุ่ม F3)";
            this.popProduct.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(553, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "บาท";
            // 
            // tbPriceBeforeDiscount
            // 
            this.tbPriceBeforeDiscount.BackColor = System.Drawing.Color.White;
            this.tbPriceBeforeDiscount.Enabled = false;
            this.tbPriceBeforeDiscount.Location = new System.Drawing.Point(447, 52);
            this.tbPriceBeforeDiscount.Name = "tbPriceBeforeDiscount";
            this.tbPriceBeforeDiscount.ReadOnly = true;
            this.tbPriceBeforeDiscount.Size = new System.Drawing.Size(100, 20);
            this.tbPriceBeforeDiscount.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "ราคาก่อนหักส่วนลด";
            // 
            // btnCancelEachOrder
            // 
            this.btnCancelEachOrder.BackColor = System.Drawing.Color.Tomato;
            this.btnCancelEachOrder.Location = new System.Drawing.Point(496, 24);
            this.btnCancelEachOrder.Name = "btnCancelEachOrder";
            this.btnCancelEachOrder.Size = new System.Drawing.Size(126, 23);
            this.btnCancelEachOrder.TabIndex = 103;
            this.btnCancelEachOrder.Text = "ยกเลิกการเพิ่มสินค้านี้";
            this.btnCancelEachOrder.UseVisualStyleBackColor = false;
            this.btnCancelEachOrder.Visible = false;
            this.btnCancelEachOrder.Click += new System.EventHandler(this.btnCancelEachOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "(ระบบจะเริ่มทำการหักส่วนลดแบบขั้นบันไดจากซ้ายไปขวาค่ะ)";
            // 
            // tbPerUnit
            // 
            this.tbPerUnit.BackColor = System.Drawing.Color.White;
            this.tbPerUnit.Enabled = false;
            this.tbPerUnit.Location = new System.Drawing.Point(88, 52);
            this.tbPerUnit.Name = "tbPerUnit";
            this.tbPerUnit.ReadOnly = true;
            this.tbPerUnit.Size = new System.Drawing.Size(100, 20);
            this.tbPerUnit.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "ราคาต่อหน่วย";
            // 
            // tbAmount
            // 
            this.tbAmount.BackColor = System.Drawing.Color.White;
            this.tbAmount.Enabled = false;
            this.tbAmount.Location = new System.Drawing.Point(240, 52);
            this.tbAmount.MaxLength = 5;
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 20);
            this.tbAmount.TabIndex = 15;
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "จำนวน";
            // 
            // tbDiscount
            // 
            this.tbDiscount.BackColor = System.Drawing.Color.White;
            this.tbDiscount.Enabled = false;
            this.tbDiscount.Location = new System.Drawing.Point(71, 79);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(189, 20);
            this.tbDiscount.TabIndex = 13;
            this.tbDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiscount_KeyPress);
            // 
            // tbSellProductID
            // 
            this.tbSellProductID.BackColor = System.Drawing.Color.White;
            this.tbSellProductID.Enabled = false;
            this.tbSellProductID.Location = new System.Drawing.Point(72, 24);
            this.tbSellProductID.MaxLength = 5;
            this.tbSellProductID.Name = "tbSellProductID";
            this.tbSellProductID.Size = new System.Drawing.Size(64, 20);
            this.tbSellProductID.TabIndex = 99;
            this.tbSellProductID.Enter += new System.EventHandler(this.tbSellProductID_Enter);
            this.tbSellProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSellProductID_KeyPress);
            this.tbSellProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSellProductID_KeyUp);
            this.tbSellProductID.Leave += new System.EventHandler(this.tbSellProductID_Leave);
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(15, 82);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(40, 13);
            this.label113.TabIndex = 12;
            this.label113.Text = "ส่วนลด";
            // 
            // tbSellProductName
            // 
            this.tbSellProductName.BackColor = System.Drawing.Color.White;
            this.tbSellProductName.Enabled = false;
            this.tbSellProductName.Location = new System.Drawing.Point(191, 24);
            this.tbSellProductName.Name = "tbSellProductName";
            this.tbSellProductName.ReadOnly = true;
            this.tbSellProductName.Size = new System.Drawing.Size(300, 20);
            this.tbSellProductName.TabIndex = 11;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(142, 27);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(46, 13);
            this.label115.TabIndex = 10;
            this.label115.Text = "ชื่อสินค้า";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(14, 27);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(52, 13);
            this.label114.TabIndex = 0;
            this.label114.Text = "รหัสสินค้า";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(101, 228);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(80, 13);
            this.label116.TabIndex = 59;
            this.label116.Text = "สรุปรายการขาย";
            // 
            // btnSellCancel
            // 
            this.btnSellCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSellCancel.Enabled = false;
            this.btnSellCancel.Location = new System.Drawing.Point(449, 479);
            this.btnSellCancel.Name = "btnSellCancel";
            this.btnSellCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSellCancel.TabIndex = 66;
            this.btnSellCancel.Text = "ยกเลิก";
            this.btnSellCancel.UseVisualStyleBackColor = false;
            this.btnSellCancel.Click += new System.EventHandler(this.btnSellCancel_Click);
            // 
            // dtpSellDate
            // 
            this.dtpSellDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpSellDate.Enabled = false;
            this.dtpSellDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSellDate.Location = new System.Drawing.Point(342, 87);
            this.dtpSellDate.Name = "dtpSellDate";
            this.dtpSellDate.Size = new System.Drawing.Size(200, 20);
            this.dtpSellDate.TabIndex = 71;
            this.dtpSellDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpSellDate_KeyPress);
            // 
            // tbDatePastBill
            // 
            this.tbDatePastBill.BackColor = System.Drawing.Color.White;
            this.tbDatePastBill.Location = new System.Drawing.Point(342, 87);
            this.tbDatePastBill.Name = "tbDatePastBill";
            this.tbDatePastBill.ReadOnly = true;
            this.tbDatePastBill.Size = new System.Drawing.Size(200, 20);
            this.tbDatePastBill.TabIndex = 77;
            this.tbDatePastBill.Visible = false;
            // 
            // btnNewBill
            // 
            this.btnNewBill.BackColor = System.Drawing.Color.Yellow;
            this.btnNewBill.Location = new System.Drawing.Point(449, 479);
            this.btnNewBill.Name = "btnNewBill";
            this.btnNewBill.Size = new System.Drawing.Size(75, 23);
            this.btnNewBill.TabIndex = 79;
            this.btnNewBill.Text = "ใหม่";
            this.btnNewBill.UseVisualStyleBackColor = false;
            this.btnNewBill.Visible = false;
            this.btnNewBill.Click += new System.EventHandler(this.btnNewBill_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FormSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(780, 508);
            this.Controls.Add(this.popCustomer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveBill);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTotalPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.tbSellNoBill);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbSellSeller);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSellPrint);
            this.Controls.Add(this.dgvSell);
            this.Controls.Add(this.tbSellCustomerName);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.tbSellCustomerID);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.btnSellCancel);
            this.Controls.Add(this.btnNewBill);
            this.Controls.Add(this.dtpSellDate);
            this.Controls.Add(this.tbDatePastBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSell";
            this.Text = "FormSell";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label popCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSearchBill;
        private System.Windows.Forms.Button btnSearchBill;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSaveBill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.TextBox tbSellNoBill;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSellSeller;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSellPrint;
        private System.Windows.Forms.DataGridView dgvSell;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox tbSellCustomerName;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox tbSellCustomerID;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label popProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPriceBeforeDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelEachOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPerUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbSellProductID;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.TextBox tbSellProductName;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Button btnSellCancel;
        private System.Windows.Forms.DateTimePicker dtpSellDate;
        private System.Windows.Forms.TextBox tbDatePastBill;
        private System.Windows.Forms.Button btnNewBill;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}