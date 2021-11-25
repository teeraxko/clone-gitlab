namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmSellingPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgSellingPlan = new System.Windows.Forms.DataGridView();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirmSelling = new System.Windows.Forms.Button();
            this.gpbShowData = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpSellingDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.colNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPlateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBidder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepreciation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSellingPlan)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.gpbShowData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSellingPlan
            // 
            this.dtgSellingPlan.AllowUserToAddRows = false;
            this.dtgSellingPlan.AllowUserToDeleteRows = false;
            this.dtgSellingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSellingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSellingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSellingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colPlateNo,
            this.colBrand,
            this.colModel,
            this.colRegisterDate,
            this.colPrice,
            this.colBVDate,
            this.colBV,
            this.colSellingDate,
            this.colSellingPrice,
            this.colBidder,
            this.colDepreciation,
            this.colMileage});
            this.dtgSellingPlan.ContextMenuStrip = this.ctmMenu;
            this.dtgSellingPlan.Location = new System.Drawing.Point(12, 80);
            this.dtgSellingPlan.Name = "dtgSellingPlan";
            this.dtgSellingPlan.RowHeadersWidth = 23;
            this.dtgSellingPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSellingPlan.Size = new System.Drawing.Size(1005, 200);
            this.dtgSellingPlan.TabIndex = 3;
            this.dtgSellingPlan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSellingPlan_CellDoubleClick);
            this.dtgSellingPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSellingPlan_CellClick);
            this.dtgSellingPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSellingPlan_CellContentClick);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.ShowImageMargin = false;
            this.ctmMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(110, 22);
            this.mniUpdate.Text = "ยืนยันการขาย";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(110, 22);
            this.mniDelete.Text = "พิมพ์";
            this.mniDelete.Click += new System.EventHandler(this.mniPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(519, 297);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "ยกเลิก";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfirmSelling
            // 
            this.btnConfirmSelling.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirmSelling.Location = new System.Drawing.Point(412, 297);
            this.btnConfirmSelling.Name = "btnConfirmSelling";
            this.btnConfirmSelling.Size = new System.Drawing.Size(98, 23);
            this.btnConfirmSelling.TabIndex = 4;
            this.btnConfirmSelling.Text = "ยืนยันการขาย";
            this.btnConfirmSelling.UseVisualStyleBackColor = true;
            this.btnConfirmSelling.Click += new System.EventHandler(this.btnConfirmSelling_Click);
            // 
            // gpbShowData
            // 
            this.gpbShowData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbShowData.Controls.Add(this.btnShow);
            this.gpbShowData.Controls.Add(this.dtpSellingDate);
            this.gpbShowData.Controls.Add(this.label1);
            this.gpbShowData.Location = new System.Drawing.Point(22, 8);
            this.gpbShowData.Name = "gpbShowData";
            this.gpbShowData.Size = new System.Drawing.Size(339, 64);
            this.gpbShowData.TabIndex = 0;
            this.gpbShowData.TabStop = false;
            this.gpbShowData.Text = "Selling Vehicle";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.Location = new System.Drawing.Point(221, 23);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpSellingDate
            // 
            this.dtpSellingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpSellingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSellingDate.Location = new System.Drawing.Point(99, 24);
            this.dtpSellingDate.Name = "dtpSellingDate";
            this.dtpSellingDate.Size = new System.Drawing.Size(90, 20);
            this.dtpSellingDate.TabIndex = 1;
            this.dtpSellingDate.Value = new System.DateTime(2007, 3, 15, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selling Date";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(48, 286);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(137, 17);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "Select All / Deselect All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // colNo
            // 
            this.colNo.HeaderText = "เลือก";
            this.colNo.Name = "colNo";
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colNo.Width = 35;
            // 
            // colPlateNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colPlateNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPlateNo.HeaderText = "ทะเบียนรถ";
            this.colPlateNo.Name = "colPlateNo";
            this.colPlateNo.ReadOnly = true;
            this.colPlateNo.Width = 70;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "ยี่ห้อ";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 80;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "รุ่น";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 150;
            // 
            // colRegisterDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colRegisterDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRegisterDate.HeaderText = "วันที่ลงทะเบียน";
            this.colRegisterDate.Name = "colRegisterDate";
            this.colRegisterDate.ReadOnly = true;
            this.colRegisterDate.Width = 105;
            // 
            // colPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPrice.HeaderText = "ราคาซื้อ";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 90;
            // 
            // colBVDate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.colBVDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBVDate.HeaderText = "BV Date";
            this.colBVDate.Name = "colBVDate";
            this.colBVDate.ReadOnly = true;
            this.colBVDate.Width = 90;
            // 
            // colBV
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colBV.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBV.HeaderText = "BV";
            this.colBV.Name = "colBV";
            this.colBV.ReadOnly = true;
            this.colBV.Width = 80;
            // 
            // colSellingDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.colSellingDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSellingDate.HeaderText = "Selling Date";
            this.colSellingDate.Name = "colSellingDate";
            this.colSellingDate.ReadOnly = true;
            this.colSellingDate.Width = 90;
            // 
            // colSellingPrice
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.colSellingPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.colSellingPrice.HeaderText = "Selling Price";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.ReadOnly = true;
            this.colSellingPrice.Width = 90;
            // 
            // colBidder
            // 
            this.colBidder.HeaderText = "BidderCode";
            this.colBidder.Name = "colBidder";
            this.colBidder.Visible = false;
            // 
            // colDepreciation
            // 
            this.colDepreciation.HeaderText = "Depreciation";
            this.colDepreciation.Name = "colDepreciation";
            this.colDepreciation.Visible = false;
            // 
            // colMileage
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.colMileage.DefaultCellStyle = dataGridViewCellStyle9;
            this.colMileage.HeaderText = "Mileage";
            this.colMileage.Name = "colMileage";
            this.colMileage.ReadOnly = true;
            this.colMileage.Width = 80;
            // 
            // FrmSellingPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 332);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.gpbShowData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirmSelling);
            this.Controls.Add(this.dtgSellingPlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSellingPlan";
            this.Text = "Selling Vehicle List";
            this.Load += new System.EventHandler(this.FrmVehicleSellingPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSellingPlan)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.gpbShowData.ResumeLayout(false);
            this.gpbShowData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSellingPlan;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirmSelling;
        private System.Windows.Forms.GroupBox gpbShowData;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtpSellingDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBidder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepreciation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMileage;
    }
}