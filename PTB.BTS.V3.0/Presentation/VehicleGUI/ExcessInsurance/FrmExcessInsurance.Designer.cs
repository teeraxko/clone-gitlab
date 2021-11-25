namespace Presentation.VehicleGUI.ExcessInsurance
{
    partial class FrmExcessInsurance
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
            this.cboToYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgExcess = new System.Windows.Forms.DataGridView();
            this.EntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccidentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccidentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcessTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            this.btnShowData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcess)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.gpbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboToYear
            // 
            this.cboToYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboToYear.FormattingEnabled = true;
            this.cboToYear.Location = new System.Drawing.Point(126, 24);
            this.cboToYear.Name = "cboToYear";
            this.cboToYear.Size = new System.Drawing.Size(80, 23);
            this.cboToYear.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "ปีใบเสร็จรับเงิน";
            // 
            // dtgExcess
            // 
            this.dtgExcess.AllowUserToAddRows = false;
            this.dtgExcess.AllowUserToDeleteRows = false;
            this.dtgExcess.AllowUserToResizeColumns = false;
            this.dtgExcess.AllowUserToResizeRows = false;
            this.dtgExcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgExcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgExcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgExcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityKey,
            this.PlateNo,
            this.AccidentNo,
            this.AccidentDate,
            this.ClaimNo,
            this.ReceiptNo,
            this.ReceiptDate,
            this.ExcessTotalAmount});
            this.dtgExcess.ContextMenuStrip = this.ctmMenu;
            this.dtgExcess.Location = new System.Drawing.Point(12, 64);
            this.dtgExcess.MultiSelect = false;
            this.dtgExcess.Name = "dtgExcess";
            this.dtgExcess.ReadOnly = true;
            this.dtgExcess.RowHeadersWidth = 23;
            this.dtgExcess.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgExcess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgExcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcess.Size = new System.Drawing.Size(795, 236);
            this.dtgExcess.TabIndex = 9;
            this.dtgExcess.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExcess_CellDoubleClick);
            // 
            // EntityKey
            // 
            this.EntityKey.HeaderText = "EntityKey";
            this.EntityKey.Name = "EntityKey";
            this.EntityKey.ReadOnly = true;
            this.EntityKey.Visible = false;
            // 
            // PlateNo
            // 
            this.PlateNo.HeaderText = "ทะเบียนรถ";
            this.PlateNo.Name = "PlateNo";
            this.PlateNo.ReadOnly = true;
            this.PlateNo.Width = 80;
            // 
            // AccidentNo
            // 
            this.AccidentNo.HeaderText = "หมายเลขอุบัติเหตุ";
            this.AccidentNo.Name = "AccidentNo";
            this.AccidentNo.ReadOnly = true;
            this.AccidentNo.Width = 110;
            // 
            // AccidentDate
            // 
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.AccidentDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.AccidentDate.HeaderText = "วันเวลาเกิดอุบัติเหตุ";
            this.AccidentDate.Name = "AccidentDate";
            this.AccidentDate.ReadOnly = true;
            this.AccidentDate.Width = 140;
            // 
            // ClaimNo
            // 
            this.ClaimNo.HeaderText = "ClaimNo";
            this.ClaimNo.Name = "ClaimNo";
            this.ClaimNo.ReadOnly = true;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.HeaderText = "หมายเลขใบเสร็จ";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            this.ReceiptNo.Width = 120;
            // 
            // ReceiptDate
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ReceiptDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReceiptDate.HeaderText = "วันที่ใบเสร็จ";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            // 
            // ExcessTotalAmount
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ExcessTotalAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExcessTotalAmount.HeaderText = "ค่า Excess";
            this.ExcessTotalAmount.Name = "ExcessTotalAmount";
            this.ExcessTotalAmount.ReadOnly = true;
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(102, 48);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(101, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(101, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(331, 320);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 55;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(412, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gpbDetail
            // 
            this.gpbDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbDetail.Controls.Add(this.btnShowData);
            this.gpbDetail.Controls.Add(this.label5);
            this.gpbDetail.Controls.Add(this.cboToYear);
            this.gpbDetail.Location = new System.Drawing.Point(12, 0);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(795, 56);
            this.gpbDetail.TabIndex = 57;
            this.gpbDetail.TabStop = false;
            this.gpbDetail.Text = "ค่า Excess";
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(232, 24);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 6;
            this.btnShowData.Text = "ดูข้อมูล";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // FrmExcessInsurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(818, 362);
            this.Controls.Add(this.gpbDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtgExcess);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmExcessInsurance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmExcessInsurance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcess)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.gpbDetail.ResumeLayout(false);
            this.gpbDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboToYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgExcess;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gpbDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccidentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccidentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExcessTotalAmount;
        private System.Windows.Forms.Button btnShowData;
    }
}
