namespace Report.GUI.Contract {
    partial class FrmReportContractCarLeasing {
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
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(0, 55);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(636, 401);
            this.crvMain.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContractNo);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtContractNo
            // 
            this.txtContractNo.Location = new System.Drawing.Point(59, 12);
            this.txtContractNo.MaxLength = 7;
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.Size = new System.Drawing.Size(100, 20);
            this.txtContractNo.TabIndex = 11;
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(165, 10);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(75, 23);
            this.btnRetiveData.TabIndex = 10;
            this.btnRetiveData.Text = "แสดงข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "PTB-C-";
            // 
            // FrmReportContractCarLeasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 456);
            this.Controls.Add(this.crvMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReportContractCarLeasing";
            this.Text = "Car Leasing Agreement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContractNo;
    }
}