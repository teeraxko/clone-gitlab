using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsConnectBizPac;

namespace PTB.PIS.Welfare.ReportApp.GUI.ConnectBizPacGUI
{
    //    public partial class FrmConnectBizPac : PTB.PIS.Welfare.ReportApp.GUI.FrmReportBase {
    public partial class FrmConnectBizPac : FrmReportBase
    {

        protected ReportConnectBizPac report;

        public FrmConnectBizPac()
            : base()
        {
            InitializeComponent();
        }

        public FrmConnectBizPac(string reportFileName, string mainTableName, List<string> listOfRefNo, string fileName)
            : this()
        {
            try
            {
                this.report = new ReportConnectBizPac(reportFileName, mainTableName, listOfRefNo, fileName);
            }
            catch (Exception ex)
            {
                // Kriangkrai A.
                throw ex;
            }
            //DisplayReport();
        }


        protected void DisplayReport()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Application.DoEvents();
            this.crvMain.ReportSource = this.report.Report;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void FrmConnectBizPac_Load(object sender, EventArgs e)
        {
            DisplayReport();
        }


    }
}

