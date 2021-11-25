namespace Report.Contract {
    partial class FrmListNoAccidentReward {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReward = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.mtxtForYear = new System.Windows.Forms.MaskedTextBox();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblReward);
            this.groupBox1.Controls.Add(this.lblPaymentDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.btnShowReport);
            this.groupBox1.Controls.Add(this.mtxtForYear);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(551, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Reward : ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(363, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Payment Date :";
            // 
            // lblReward
            // 
            this.lblReward.Location = new System.Drawing.Point(611, 28);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(70, 13);
            this.lblReward.TabIndex = 13;
            this.lblReward.Text = "lblReward";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.Location = new System.Drawing.Point(451, 28);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(94, 13);
            this.lblPaymentDate.TabIndex = 12;
            this.lblPaymentDate.Text = "lblPaymentDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ถึง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "จาก";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "สำหรับปี";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // lblToDate
            // 
            this.lblToDate.BackColor = System.Drawing.Color.White;
            this.lblToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToDate.Location = new System.Drawing.Point(272, 27);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(81, 15);
            this.lblToDate.TabIndex = 4;
            this.lblToDate.Text = "lblToDate";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromDate
            // 
            this.lblFromDate.BackColor = System.Drawing.Color.White;
            this.lblFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFromDate.Location = new System.Drawing.Point(172, 28);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(81, 15);
            this.lblFromDate.TabIndex = 3;
            this.lblFromDate.Text = "lblFromDate";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(89, 24);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(63, 22);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "ดูข้อมูล";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // mtxtForYear
            // 
            this.mtxtForYear.HidePromptOnLeave = true;
            this.mtxtForYear.Location = new System.Drawing.Point(52, 25);
            this.mtxtForYear.Mask = "0000";
            this.mtxtForYear.Name = "mtxtForYear";
            this.mtxtForYear.PromptChar = ' ';
            this.mtxtForYear.Size = new System.Drawing.Size(32, 20);
            this.mtxtForYear.TabIndex = 1;
            this.mtxtForYear.ValidatingType = typeof(int);
            this.mtxtForYear.Validated += new System.EventHandler(this.mtxtForYear_Validated);
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.DisplayGroupTree = false;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 64);
            this.crv.Name = "crv";
            this.crv.ShowGroupTreeButton = false;
            this.crv.ShowRefreshButton = false;
            this.crv.Size = new System.Drawing.Size(792, 509);
            this.crv.TabIndex = 2;
            // 
            // FrmListNoAccidentReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListNoAccidentReward";
            this.Text = "FrmListNoAccidentReward";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.MaskedTextBox mtxtForYear;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}