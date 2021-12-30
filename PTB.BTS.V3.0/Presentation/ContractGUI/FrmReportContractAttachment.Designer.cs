namespace Presentation.ContractGUI
{
    partial class FrmReportContractAttachment
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
            this.gpbContractInfo = new System.Windows.Forms.GroupBox();
            this.cboModelType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.lblAttachmentNoXXX = new System.Windows.Forms.Label();
            this.lblAttachmentNoMM = new System.Windows.Forms.Label();
            this.lblAttachmentNoYY = new System.Windows.Forms.Label();
            this.txtAttachmentNoXXX = new System.Windows.Forms.TextBox();
            this.txtAttachmentNoMM = new System.Windows.Forms.TextBox();
            this.txtAttachmentNoYY = new System.Windows.Forms.TextBox();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.lblAttachmentNo = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.gpbContractInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbContractInfo
            // 
            this.gpbContractInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbContractInfo.Controls.Add(this.cboModelType);
            this.gpbContractInfo.Controls.Add(this.lblVehicleType);
            this.gpbContractInfo.Controls.Add(this.lblAttachmentNoXXX);
            this.gpbContractInfo.Controls.Add(this.lblAttachmentNoMM);
            this.gpbContractInfo.Controls.Add(this.lblAttachmentNoYY);
            this.gpbContractInfo.Controls.Add(this.txtAttachmentNoXXX);
            this.gpbContractInfo.Controls.Add(this.txtAttachmentNoMM);
            this.gpbContractInfo.Controls.Add(this.txtAttachmentNoYY);
            this.gpbContractInfo.Controls.Add(this.cboCustomerName);
            this.gpbContractInfo.Controls.Add(this.lblCustomerName);
            this.gpbContractInfo.Controls.Add(this.btnPrint);
            this.gpbContractInfo.Controls.Add(this.btnCreateNew);
            this.gpbContractInfo.Controls.Add(this.lblAttachmentNo);
            this.gpbContractInfo.Location = new System.Drawing.Point(12, 12);
            this.gpbContractInfo.Name = "gpbContractInfo";
            this.gpbContractInfo.Size = new System.Drawing.Size(777, 85);
            this.gpbContractInfo.TabIndex = 142;
            this.gpbContractInfo.TabStop = false;
            this.gpbContractInfo.Text = "ข้อมูลเอกสารแนบท้ายสัญญา";
            // 
            // cboModelType
            // 
            this.cboModelType.DisplayMember = "ThaiDescription";
            this.cboModelType.FormattingEnabled = true;
            this.cboModelType.Location = new System.Drawing.Point(88, 50);
            this.cboModelType.Name = "cboModelType";
            this.cboModelType.Size = new System.Drawing.Size(111, 21);
            this.cboModelType.TabIndex = 160;
            this.cboModelType.SelectedIndexChanged += new System.EventHandler(this.cboModelType_SelectedIndexChanged);
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(27, 53);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(42, 13);
            this.lblVehicleType.TabIndex = 159;
            this.lblVehicleType.Text = "ชนิดรถ";
            // 
            // lblAttachmentNoXXX
            // 
            this.lblAttachmentNoXXX.AutoSize = true;
            this.lblAttachmentNoXXX.Location = new System.Drawing.Point(536, 43);
            this.lblAttachmentNoXXX.Name = "lblAttachmentNoXXX";
            this.lblAttachmentNoXXX.Size = new System.Drawing.Size(28, 13);
            this.lblAttachmentNoXXX.TabIndex = 158;
            this.lblAttachmentNoXXX.Text = "XXX";
            // 
            // lblAttachmentNoMM
            // 
            this.lblAttachmentNoMM.AutoSize = true;
            this.lblAttachmentNoMM.Location = new System.Drawing.Point(501, 43);
            this.lblAttachmentNoMM.Name = "lblAttachmentNoMM";
            this.lblAttachmentNoMM.Size = new System.Drawing.Size(25, 13);
            this.lblAttachmentNoMM.TabIndex = 157;
            this.lblAttachmentNoMM.Text = "MM";
            // 
            // lblAttachmentNoYY
            // 
            this.lblAttachmentNoYY.AutoSize = true;
            this.lblAttachmentNoYY.Location = new System.Drawing.Point(473, 43);
            this.lblAttachmentNoYY.Name = "lblAttachmentNoYY";
            this.lblAttachmentNoYY.Size = new System.Drawing.Size(21, 13);
            this.lblAttachmentNoYY.TabIndex = 156;
            this.lblAttachmentNoYY.Text = "YY";
            // 
            // txtAttachmentNoXXX
            // 
            this.txtAttachmentNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAttachmentNoXXX.Location = new System.Drawing.Point(530, 20);
            this.txtAttachmentNoXXX.MaxLength = 3;
            this.txtAttachmentNoXXX.Name = "txtAttachmentNoXXX";
            this.txtAttachmentNoXXX.Size = new System.Drawing.Size(38, 20);
            this.txtAttachmentNoXXX.TabIndex = 155;
            this.txtAttachmentNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAttachmentNoXXX.TextChanged += new System.EventHandler(this.txtAttachmentNoXXX_TextChanged);
            // 
            // txtAttachmentNoMM
            // 
            this.txtAttachmentNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAttachmentNoMM.Location = new System.Drawing.Point(498, 20);
            this.txtAttachmentNoMM.MaxLength = 2;
            this.txtAttachmentNoMM.Name = "txtAttachmentNoMM";
            this.txtAttachmentNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtAttachmentNoMM.TabIndex = 154;
            this.txtAttachmentNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAttachmentNoMM.TextChanged += new System.EventHandler(this.txtAttachmentNoMM_TextChanged);
            // 
            // txtAttachmentNoYY
            // 
            this.txtAttachmentNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAttachmentNoYY.Location = new System.Drawing.Point(466, 20);
            this.txtAttachmentNoYY.MaxLength = 2;
            this.txtAttachmentNoYY.Name = "txtAttachmentNoYY";
            this.txtAttachmentNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtAttachmentNoYY.TabIndex = 153;
            this.txtAttachmentNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAttachmentNoYY.TextChanged += new System.EventHandler(this.txtAttachmentNoYY_TextChanged);
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.DisplayMember = "English_Name";
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(88, 19);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(234, 21);
            this.cboCustomerName.TabIndex = 149;
            this.cboCustomerName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerName_SelectedIndexChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(27, 25);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(45, 13);
            this.lblCustomerName.TabIndex = 148;
            this.lblCustomerName.Text = "ชื่อลูกค้า";
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(578, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 23);
            this.btnPrint.TabIndex = 142;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.ForeColor = System.Drawing.Color.Black;
            this.btnCreateNew.Location = new System.Drawing.Point(656, 19);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(103, 23);
            this.btnCreateNew.TabIndex = 140;
            this.btnCreateNew.Text = "สร้างรายการใหม่";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // lblAttachmentNo
            // 
            this.lblAttachmentNo.AutoSize = true;
            this.lblAttachmentNo.Location = new System.Drawing.Point(341, 23);
            this.lblAttachmentNo.Name = "lblAttachmentNo";
            this.lblAttachmentNo.Size = new System.Drawing.Size(115, 13);
            this.lblAttachmentNo.TabIndex = 136;
            this.lblAttachmentNo.Text = "Attachment# PTB - N -";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(250, 509);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 161;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(328, 509);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 162;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(406, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 163;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(482, 509);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 164;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Location = new System.Drawing.Point(12, 114);
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.Size = new System.Drawing.Size(777, 380);
            this.dgvAttachmentList.TabIndex = 165;
            // 
            // FrmReportContractAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 544);
            this.Controls.Add(this.dgvAttachmentList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gpbContractInfo);
            this.Name = "FrmReportContractAttachment";
            this.Text = "เอกสารแนบสัญญา";
            this.Load += new System.EventHandler(this.FrmReportContractAttachment_Load);
            this.gpbContractInfo.ResumeLayout(false);
            this.gpbContractInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbContractInfo;
        protected internal System.Windows.Forms.TextBox txtAttachmentNoXXX;
        protected internal System.Windows.Forms.TextBox txtAttachmentNoMM;
        protected internal System.Windows.Forms.TextBox txtAttachmentNoYY;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label lblAttachmentNo;
        private System.Windows.Forms.Label lblAttachmentNoXXX;
        private System.Windows.Forms.Label lblAttachmentNoMM;
        private System.Windows.Forms.Label lblAttachmentNoYY;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cboModelType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAttachmentList;
    }
}