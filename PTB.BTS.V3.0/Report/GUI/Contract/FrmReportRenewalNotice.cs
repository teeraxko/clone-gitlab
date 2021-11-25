using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;
using Entity.VehicleEntities;
using Report.BLL;
using Report.Reports.Contract;

namespace Report.GUI.Contract
{
    public partial class FrmReportRenewalNotice : FrmReportBase
    {
        #region Private Variable
        ReportRenewalNotice reportRenewal = new ReportRenewalNotice();
        DateTime tempEndDate;
        private string tempContract;
        private string tempTISAuthorize;
        #endregion

        #region Constructor
        public FrmReportRenewalNotice(DateTime endDate, string contractNo, string tisAuthorize)
            : base()
        {
            InitializeComponent();

            tempEndDate = endDate;
            tempContract = contractNo;
            tempTISAuthorize = tisAuthorize;

            PrintReport();
        } 
        #endregion

        #region Private Method
        private void PrintReport()
        {
            this.Cursor = Cursors.WaitCursor;
            reportRenewal.SetCriteria(tempEndDate, tempContract, tempTISAuthorize);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportRenewal.Report;
            this.Cursor = Cursors.Default;
        } 
        #endregion
    }
}
