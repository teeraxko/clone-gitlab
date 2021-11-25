namespace Presentation.WelfareGUI
{
    partial class frmWelfareBenefit
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
            this.tabMed = new System.Windows.Forms.TabControl();
            this.tabWelfareList = new System.Windows.Forms.TabPage();
            this.crvWelfareBankReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabBankDeposit = new System.Windows.Forms.TabPage();
            this.crvBankReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbInformation = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmdShow = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.crvMedInterfaceFile = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabMed.SuspendLayout();
            this.tabWelfareList.SuspendLayout();
            this.tabBankDeposit.SuspendLayout();
            this.gpbInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMed
            // 
            this.tabMed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMed.Controls.Add(this.tabWelfareList);
            this.tabMed.Controls.Add(this.tabBankDeposit);
            this.tabMed.Location = new System.Drawing.Point(0, 80);
            this.tabMed.Name = "tabMed";
            this.tabMed.SelectedIndex = 0;
            this.tabMed.Size = new System.Drawing.Size(898, 213);
            this.tabMed.TabIndex = 28;
            // 
            // tabWelfareList
            // 
            this.tabWelfareList.Controls.Add(this.crvWelfareBankReport);
            this.tabWelfareList.Location = new System.Drawing.Point(4, 22);
            this.tabWelfareList.Name = "tabWelfareList";
            this.tabWelfareList.Size = new System.Drawing.Size(890, 187);
            this.tabWelfareList.TabIndex = 0;
            this.tabWelfareList.Text = "Welfare Bank Deposit List";
            // 
            // crvWelfareBankReport
            // 
            this.crvWelfareBankReport.ActiveViewIndex = -1;
            this.crvWelfareBankReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvWelfareBankReport.DisplayGroupTree = false;
            this.crvWelfareBankReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvWelfareBankReport.Location = new System.Drawing.Point(0, 0);
            this.crvWelfareBankReport.Name = "crvWelfareBankReport";
            this.crvWelfareBankReport.ShowCloseButton = false;
            this.crvWelfareBankReport.ShowGroupTreeButton = false;
            this.crvWelfareBankReport.Size = new System.Drawing.Size(890, 187);
            this.crvWelfareBankReport.TabIndex = 14;
            // 
            // tabBankDeposit
            // 
            this.tabBankDeposit.Controls.Add(this.crvBankReport);
            this.tabBankDeposit.Location = new System.Drawing.Point(4, 22);
            this.tabBankDeposit.Name = "tabBankDeposit";
            this.tabBankDeposit.Size = new System.Drawing.Size(890, 187);
            this.tabBankDeposit.TabIndex = 1;
            this.tabBankDeposit.Text = "Bank Deposit List";
            // 
            // crvBankReport
            // 
            this.crvBankReport.ActiveViewIndex = -1;
            this.crvBankReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBankReport.DisplayGroupTree = false;
            this.crvBankReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBankReport.Location = new System.Drawing.Point(0, 0);
            this.crvBankReport.Name = "crvBankReport";
            this.crvBankReport.ShowCloseButton = false;
            this.crvBankReport.ShowGroupTreeButton = false;
            this.crvBankReport.Size = new System.Drawing.Size(890, 187);
            this.crvBankReport.TabIndex = 15;
            // 
            // gpbInformation
            // 
            this.gpbInformation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbInformation.Controls.Add(this.dtpDate);
            this.gpbInformation.Controls.Add(this.cmdShow);
            this.gpbInformation.Controls.Add(this.label);
            this.gpbInformation.Location = new System.Drawing.Point(297, 8);
            this.gpbInformation.Name = "gpbInformation";
            this.gpbInformation.Size = new System.Drawing.Size(304, 72);
            this.gpbInformation.TabIndex = 26;
            this.gpbInformation.TabStop = false;
            this.gpbInformation.Text = "ระบุรายละเอียด";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(87, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(110, 20);
            this.dtpDate.TabIndex = 8;
            // 
            // cmdShow
            // 
            this.cmdShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdShow.Location = new System.Drawing.Point(207, 27);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 23);
            this.cmdShow.TabIndex = 9;
            this.cmdShow.Text = "ส่งข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(23, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(52, 13);
            this.label.TabIndex = 7;
            this.label.Text = "จ่ายวันที่ :";
            // 
            // crvMedInterfaceFile
            // 
            this.crvMedInterfaceFile.ActiveViewIndex = -1;
            this.crvMedInterfaceFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.crvMedInterfaceFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMedInterfaceFile.DisplayGroupTree = false;
            this.crvMedInterfaceFile.Location = new System.Drawing.Point(712, 32);
            this.crvMedInterfaceFile.Name = "crvMedInterfaceFile";
            this.crvMedInterfaceFile.ShowCloseButton = false;
            this.crvMedInterfaceFile.ShowGroupTreeButton = false;
            this.crvMedInterfaceFile.Size = new System.Drawing.Size(179, 56);
            this.crvMedInterfaceFile.TabIndex = 27;
            this.crvMedInterfaceFile.Visible = false;
            // 
            // frmWelfareBenefit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 291);
            this.Controls.Add(this.tabMed);
            this.Controls.Add(this.gpbInformation);
            this.Controls.Add(this.crvMedInterfaceFile);
            this.Name = "frmWelfareBenefit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWelfareBenefit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWelfareBenefit_FormClosed);
            this.tabMed.ResumeLayout(false);
            this.tabWelfareList.ResumeLayout(false);
            this.tabBankDeposit.ResumeLayout(false);
            this.gpbInformation.ResumeLayout(false);
            this.gpbInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMed;
        private System.Windows.Forms.TabPage tabWelfareList;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvWelfareBankReport;
        private System.Windows.Forms.TabPage tabBankDeposit;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBankReport;
        private System.Windows.Forms.GroupBox gpbInformation;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMedInterfaceFile;
    }
}