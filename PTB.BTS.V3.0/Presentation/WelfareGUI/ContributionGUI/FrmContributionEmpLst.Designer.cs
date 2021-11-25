namespace PTB.PIS.Welfare.WindowsApp.ContributionGUI {
    partial class FrmContributionEmpLst {
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
            this.coluDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluContribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.grdData);
            this.pnlDetail.Controls.SetChildIndex(this.grdData, 0);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluDate,
            this.coluContribution,
            this.coluAmount});
            this.grdData.Location = new System.Drawing.Point(241, 6);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 50;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(510, 398);
            this.grdData.TabIndex = 22;
            this.grdData.Sorted += new System.EventHandler(this.grdData_Sorted);
            this.grdData.DoubleClick += new System.EventHandler(this.grdData_DoubleClick);
            // 
            // coluDate
            // 
            this.coluDate.HeaderText = "วันที่";
            this.coluDate.Name = "coluDate";
            this.coluDate.ReadOnly = true;
            this.coluDate.Width = 80;
            // 
            // coluContribution
            // 
            this.coluContribution.HeaderText = "เงินช่วยเหลือเพื่อ";
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
            this.coluAmount.HeaderText = "จำนวนเงิน (บาท)";
            this.coluAmount.Name = "coluAmount";
            this.coluAmount.ReadOnly = true;
            this.coluAmount.Width = 150;
            // 
            // FrmContributionEmpLst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Name = "FrmContributionEmpLst";
            this.Load += new System.EventHandler(this.From_Load);
            this.Controls.SetChildIndex(this.pnlDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluContribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluAmount;

    }
}
