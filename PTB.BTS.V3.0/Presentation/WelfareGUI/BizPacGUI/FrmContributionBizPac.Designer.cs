namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI {
    partial class FrmContributionBizPac {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coluDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluContribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.pnlGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdData);
            this.pnlGrid.Size = new System.Drawing.Size(833, 383);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(0, 439);
            this.pnlBtn.Size = new System.Drawing.Size(833, 50);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Size = new System.Drawing.Size(833, 56);
            this.groupBox1.Controls.SetChildIndex(this.dtpDateFrom, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpDateTo, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnRetiveData, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpPaymentDate, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeColumns = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.coluDate,
            this.colEmployee,
            this.coluContribution,
            this.coluAmount});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(833, 383);
            this.grdData.TabIndex = 24;
            // 
            // colChk
            // 
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colChk.Width = 40;
            // 
            // coluDate
            // 
            this.coluDate.HeaderText = "�ѹ���";
            this.coluDate.Name = "coluDate";
            this.coluDate.ReadOnly = true;
            this.coluDate.Width = 80;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "��ѡ�ҹ";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 200;
            // 
            // coluContribution
            // 
            this.coluContribution.HeaderText = "�Թ�������������";
            this.coluContribution.Name = "coluContribution";
            this.coluContribution.ReadOnly = true;
            this.coluContribution.Width = 200;
            // 
            // coluAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.coluAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.coluAmount.HeaderText = "�ӹǹ�Թ (�ҷ)";
            this.coluAmount.Name = "coluAmount";
            this.coluAmount.ReadOnly = true;
            this.coluAmount.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "�ѹ���ѹ�֡�ѭ��";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(500, 18);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(86, 20);
            this.dtpPaymentDate.TabIndex = 8;
            // 
            // FrmContributionBizPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 489);
            this.Name = "FrmContributionBizPac";
            this.Text = "FrmContributionBizPac";
            this.pnlGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluContribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;

    }
}