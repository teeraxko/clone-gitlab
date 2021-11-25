using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportConnectBBL {
    public abstract class ReportConnectBBLBase : ReportBase{

        protected DateTime paymentDateTime;
        public ReportConnectBBLBase(DateTime paymentDateTime) {
            this.paymentDateTime = paymentDateTime;
        }

        protected override void InitialReport() {
            base.InitialReport();
            this.SetFormulars();
            this.SetParameters();
        }

        protected virtual void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        protected virtual void SetParameters() {
            this.SetReportParameterField("PaymentDate",this.paymentDateTime);
        }

    }

}
