using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Vehicle;
using Presentation.CommonGUI;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmSellingPlanReport : ChildFormBase, IMDIChildForm
    {
        ReportVehicleSellingDepreciation reportVehicleSellingDepreciation = new ReportVehicleSellingDepreciation();
        ReportSellingQuotation reportQuotation = new ReportSellingQuotation();

        DateTime tempBVDate;
        private string tempVehicle;

        public FrmSellingPlanReport(DateTime bvdate , string vehicleNo)
            : base() 
        {

            InitializeComponent();

            tempBVDate = bvdate;
            tempVehicle = vehicleNo;

            PrintReportDepreciation();
            PrintReportQuotation();
        }
        private void PrintReportDepreciation()
        {
            this.Cursor = Cursors.WaitCursor;
            reportVehicleSellingDepreciation.SetCriteria(tempBVDate, tempVehicle);

            this.crvDepreciation.Visible = true;
            this.crvDepreciation.DisplayToolbar = true;
            this.crvDepreciation.ReportSource = reportVehicleSellingDepreciation.Report;
            this.Cursor = Cursors.Default;
        }

        private void PrintReportQuotation()
        {
            this.Cursor = Cursors.WaitCursor;
            reportQuotation.SetCriteria(tempBVDate, tempVehicle);

            this.crvQuotation.Visible = true;
            this.crvQuotation.DisplayToolbar = true;
            this.crvQuotation.ReportSource = reportQuotation.Report;
            this.Cursor = Cursors.Default;
        }

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            throw new NotImplementedException();
        }

        public void RefreshForm()
        {
            throw new NotImplementedException();
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        public void ExitForm()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
