using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI {
    public class FrmReportMasterLoanReson : FrmReportMasterData {
        public FrmReportMasterLoanReson()
            : base() {
            this.Text = "�������˵ؼš�á������Թ";
            this.reportMasterDataBase = new Reports.ReportsMasterData.ReportLoanReason();
        }
    }
}