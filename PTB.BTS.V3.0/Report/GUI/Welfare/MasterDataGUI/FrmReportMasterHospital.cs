using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI {
    public class FrmReportMasterHospital : FrmReportMasterData {
        public FrmReportMasterHospital()
            : base() {
            this.Text = "ข้อมูลโรงพยาบาล";
            this.reportMasterDataBase = new Reports.ReportsMasterData.ReportHospital();
        }
    }
}