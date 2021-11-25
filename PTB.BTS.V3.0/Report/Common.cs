using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;

using CrystalDecisions.Shared;
using ictus.Common.Entity;
using PTB.BTS.PI.Flow;
using SystemFramework.AppConfig;

namespace Report
{
    internal class Common
    {
        public static CompanyInfo GetCompanyInfo()
        {
            CompanyInfo comp = new CompanyInfo("12");
            CompanyFlow companyFlow = new CompanyFlow();
            companyFlow.FillCompany(ref comp);
            return comp;
        }

        public static DateTime EndMonthDate(int year, int month)
        {
            int endMonthDay = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, endMonthDay);
        }

        public static DateTime EndMonthDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            return Common.EndMonthDate(year, month);
        }

        #region CrystalReport Utility

        public static ReportDocument GetReportDocument(string reportName)
        {

            ReportDocument rpt = new ReportDocument();
            rpt.Load(@ApplicationProfile.REPORT_PATH + reportName);
            try
            {
                Common.SetReportDataSource(rpt);
                return rpt;
            }
            catch (Exception excp)
            {
                throw excp;
            }


        }

        private static void SetReportDataSource(ReportDocument rpt)
        {
            DataSourceConnections dsc = rpt.DataSourceConnections;
            IConnectionInfo iConnectionInfo1 = dsc[0];
            iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
        }

        public static void SetFormularField(ReportDocument rpt, string formularName, string strValue)
        {
            rpt.DataDefinition.FormulaFields[formularName].Text = strValue;
        }

        public static void SetParameterField(ReportDocument rpt, string formularName, object value)
        {
            rpt.DataDefinition.ParameterFields[formularName].ApplyCurrentValues(CrytalParameterValue(value));
        }

        private static ParameterValues CrytalParameterValue(object paraValue)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }

        #endregion
    }
}
