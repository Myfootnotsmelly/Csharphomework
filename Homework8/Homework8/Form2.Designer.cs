namespace Homework8
{
    partial class frmAddOrder
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOIofAddingOrder = new System.Windows.Forms.DataGridView();
            this.thisgoodsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itempriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderAddingbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOI = new System.Windows.Forms.Button();
            this.btnDelOI = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOIofAddingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddingbindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvOIofAddingOrder, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvOIofAddingOrder
            // 
            this.dgvOIofAddingOrder.AllowUserToAddRows = false;
            this.dgvOIofAddingOrder.AutoGenerateColumns = false;
            this.dgvOIofAddingOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOIofAddingOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thisgoodsDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.goodPriceDataGridViewTextBoxColumn,
            this.itempriceDataGridViewTextBoxColumn});
            this.dgvOIofAddingOrder.DataSource = this.OrderAddingbindingSource;
            this.dgvOIofAddingOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOIofAddingOrder.Location = new System.Drawing.Point(3, 3);
            this.dgvOIofAddingOrder.Name = "dgvOIofAddingOrder";
            this.dgvOIofAddingOrder.RowTemplate.Height = 27;
            this.dgvOIofAddingOrder.Size = new System.Drawing.Size(448, 431);
            this.dgvOIofAddingOrder.TabIndex = 0;
            // 
            // thisgoodsDataGridViewTextBoxColumn
            // 
            this.thisgoodsDataGridViewTextBoxColumn.DataPropertyName = "thisgoods";
            this.thisgoodsDataGridViewTextBoxColumn.HeaderText = "thisgoods";
            this.thisgoodsDataGridViewTextBoxColumn.Name = "thisgoodsDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // goodPriceDataGridViewTextBoxColumn
            // 
            this.goodPriceDataGridViewTextBoxColumn.DataPropertyName = "GoodPrice";
            this.goodPriceDataGridViewTextBoxColumn.HeaderText = "GoodPrice";
            this.goodPriceDataGridViewTextBoxColumn.Name = "goodPriceDataGridViewTextBoxColumn";
            this.goodPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itempriceDataGridViewTextBoxColumn
            // 
            this.itempriceDataGridViewTextBoxColumn.DataPropertyName = "Itemprice";
            this.itempriceDataGridViewTextBoxColumn.HeaderText = "Itemprice";
            this.itempriceDataGridViewTextBoxColumn.Name = "itempriceDataGridViewTextBoxColumn";
            // 
            // OrderAddingbindingSource
            // 
            this.OrderAddingbindingSource.DataSource = typeof(Homework8.OrderItem);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(461, 288);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(148, 145);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddOI, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDelOI, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtCname, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(461, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(148, 280);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnAddOI
            // 
            this.btnAddOI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOI.Location = new System.Drawing.Point(3, 59);
            this.btnAddOI.Name = "btnAddOI";
            this.btnAddOI.Size = new System.Drawing.Size(142, 50);
            this.btnAddOI.TabIndex = 0;
            this.btnAddOI.Text = "新建订单项";
            this.btnAddOI.UseVisualStyleBackColor = true;
            this.btnAddOI.Click += new System.EventHandler(this.btnAddOI_Click);
            // 
            // btnDelOI
            // 
            this.btnDelOI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelOI.Location = new System.Drawing.Point(3, 115);
            this.btnDelOI.Name = "btnDelOI";
            this.btnDelOI.Size = new System.Drawing.Size(142, 50);
            this.btnDelOI.TabIndex = 1;
            this.btnDelOI.Text = "删除订单项";
            this.btnDelOI.UseVisualStyleBackColor = true;
            this.btnDelOI.Click += new System.EventHandler(this.btnDelOI_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(3, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(142, 50);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(3, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCname
            // 
            this.txtCname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCname.Location = new System.Drawing.Point(3, 3);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(142, 25);
            this.txtCname.TabIndex = 4;
            this.txtCname.Text = "请输入客户名";
            // 
            // frmAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 432);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddOrder";
            this.Text = "frmAddOrder";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOIofAddingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddingbindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvOIofAddingOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn thisgoodsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itempriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource OrderAddingbindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddOI;
        private System.Windows.Forms.Button btnDelOI;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCname;
    }
}