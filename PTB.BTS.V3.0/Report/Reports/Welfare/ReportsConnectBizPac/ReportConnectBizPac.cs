using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsConnectBizPac {
    public class ReportConnectBizPac : ReportBase  {

        private List<string> listOfRefNo;

        protected string mainTableName;
        protected string fileName;
        
        public ReportConnectBizPac(string reportFileName, string mainTableName,List<string> listOfRefNo,string fileName) {
            this.reportFileName = reportFileName;
            this.mainTableName = mainTableName;
            this.listOfRefNo = listOfRefNo;
            this.fileName = fileName;
            this.InitialReport();
            this.SetFormulars();
            this.AppendRecordSelectionFormula(this.BuildSelectionFormular());
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
            this.SetReportFormularField("FileName", "'" + this.fileName + "'");
        }

        private string BuildSelectionFormular() {
            StringBuilder setOfRef = new StringBuilder();
            setOfRef.Append(@"{" + mainTableName + @".BizPac_Reference_No} IN ['X'");
            foreach (string refNo in this.listOfRefNo) {
                setOfRef.Append(@", '" + refNo + @"'");
            }
            setOfRef.Append(@"]");
            return setOfRef.ToString();
        }


    }
}
