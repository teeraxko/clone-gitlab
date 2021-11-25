using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Welfare.ReportsMedicalAid
{
    public class ReportMedicalAidInsurancePaid : ReportBase
    {
        #region Private Variable
        #endregion

        #region Constructor
        public ReportMedicalAidInsurancePaid()
            : base()
        {
            this.reportFileName = "rptMedicalAidInsurancePaid.rpt";
            this.InitialReport();
        } 
        #endregion

        #region Public Method
        public void SetCriteria(DateTime fromDate, DateTime toDate, int medicalLetter, int medicalFor)
        {
            this.SetFormulars();
            this.SetParameters(fromDate, toDate, medicalLetter, medicalFor);
        } 
        #endregion

        #region Private Method
        private void SetFormulars()
        {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters(DateTime fromDate, DateTime toDate, int medicalLetter, int medicalFor)
        {
            this.SetReportParameterField("FromDate", fromDate);
            this.SetReportParameterField("ToDate", toDate);

            string parameterLetter = string.Empty;
            string parameterFor = string.Empty;

            //Y = Yes, N = No, Z = All
            switch (medicalLetter)
            {
                case 1:
                    parameterLetter = "Y";
                    break;
                case 2:
                    parameterLetter = "N";
                    break;
                default:
                    parameterLetter = "Z";
                    break;
            }

            //O = Owner, F = Family, Z = All
            switch (medicalFor)
            {
                case 1:
                    parameterFor = "O";
                    break;
                case 2:
                    parameterFor = "F";
                    break;
                default:
                    parameterFor = "Z";
                    break;
            }

            this.SetReportParameterField("MedicalLetter", parameterLetter);
            this.SetReportParameterField("MedicalFor", parameterFor);
        }
        
        #endregion
    }
}
