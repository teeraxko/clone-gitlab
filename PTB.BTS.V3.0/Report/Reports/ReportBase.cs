using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SystemFramework.AppConfig;

namespace Report.Reports {
    public abstract class ReportBase {

        protected ReportDocument report;
        public ReportDocument Report {
            get {
                return this.report;
            }
        }
        //private string initFormular;
        protected string reportFileName;

        public string ReportFileName {
            get { return reportFileName; }
            set { reportFileName = value; }
        }

        public ReportBase() {
            //InitialReport();
        }

        protected virtual void InitialReport() {
            LoadReport();
            SetReportDataSource();
        }

        private void LoadReport() {
            try {
                this.report = new ReportDocument();
                this.report.Load(@ApplicationProfile.REPORT_PATH + reportFileName);
                //this.initFormular = this.report.DataDefinition.RecordSelectionFormula;
            } catch (Exception excp) {
                throw excp;
            }
        }

        private void SetReportDataSource() {
            try {
                DataSourceConnections dsc = this.report.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dsc[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected void SetReportFormularField(string formularName, string strValue) {
            try {
                this.report.DataDefinition.FormulaFields[formularName].Text = strValue;
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected void SetReportParameterField(string formularName, object value) {
            try {
                this.report.DataDefinition.ParameterFields[formularName].ApplyCurrentValues(CrytalParameterValue(value));
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected void SetRecordSelectionFormula(string selectionFormula) {
            try {
                this.report.DataDefinition.RecordSelectionFormula = selectionFormula;
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected void AppendRecordSelectionFormula(string selectionFormula) {
            try {
                if (selectionFormula.Trim().Length > 0) {
                    string mainFormula = this.report.DataDefinition.RecordSelectionFormula;
                    string newFormula = string.Empty;
                    if (mainFormula.Trim().Length > 0) {
                        newFormula = mainFormula + " and " + selectionFormula;
                    } else {
                        newFormula = selectionFormula;
                    }
                    this.report.DataDefinition.RecordSelectionFormula = newFormula;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private ParameterValues CrytalParameterValue(object paraValue) {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }







    }

}
