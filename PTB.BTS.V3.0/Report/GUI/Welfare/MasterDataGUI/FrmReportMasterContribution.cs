using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI {
    public class FrmReportMasterContribution : FrmReportMasterData {
        public FrmReportMasterContribution():base() {
            this.Text = "ข้อมูลเงินช่วยเหลือ";
            this.reportMasterDataBase = new Reports.ReportsMasterData.ReportContribution();
        }
    }
}
