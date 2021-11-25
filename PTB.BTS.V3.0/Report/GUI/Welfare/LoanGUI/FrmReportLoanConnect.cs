using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportConnectBBL;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsConnectBizPac;

namespace PTB.PIS.Welfare.ReportApp.GUI.LoanGUI {
    public partial class FrmReportLoanConnect : FrmReportBase {
        
        protected ReportConnectBBLBase reportConnectBBLBase;
        protected ReportConnectBizPac reportConnectBizPac;
        
        private DateTime paymentDate;

        public DateTime PaymentDate {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        private String connectFileName;

        public String ConnectFileName {
            get { return connectFileName; }
            set { connectFileName = value; }
        }

        private string reportFileName;

        public string ReportFileName {
            get { return reportFileName; }
            set { reportFileName = value; }
        }

        private string mainTableName;

        public string MainTableName {
            get { return mainTableName; }
            set { mainTableName = value; }
        }

        private List<string> listOfRefNo;

        public List<string> ListOfRefNo {
            get { return listOfRefNo; }
            set { listOfRefNo = value; }
        }
	




        public FrmReportLoanConnect():base() {
            InitializeComponent();
        }

        public void LoadDate() 
        {
            this.reportConnectBBLBase = new ReportConnectBBLLoan(this.paymentDate);
            this.reportConnectBizPac = new ReportConnectBizPac(this.reportFileName, this.mainTableName, this.listOfRefNo, this.connectFileName);
        }

        protected void DisplayReport() {
            this.crvMain.DisplayToolbar = true;
            this.crvMain.DisplayToolbar = true;
            this.crvMain.ReportSource = this.reportConnectBizPac.Report;
            this.crvMain2.ReportSource = this.reportConnectBBLBase.Report;
        }

        private void FrmReportLoanConnect_Load(object sender, EventArgs e) {
            DisplayReport();
        }


    }
}