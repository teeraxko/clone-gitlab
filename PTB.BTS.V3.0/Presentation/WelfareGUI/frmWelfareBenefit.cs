using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using ictus.Common.Entity;
using Facade.PiFacade;
using Facade.WelfareFacade;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.WelfareGUI
{
    public partial class frmWelfareBenefit : ChildFormBase,IMDIChildForm
    {
        #region - private -
        private const int VALID_DAY = 20;
        private const string exportPath = "COMDAT.DAT";
        //private const string exportPath = @"D:\COMDAT.DAT";
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        private WelfareBenefitFacade facadeWelfare;
        #endregion

        //		==============================Contructor==============================
        public frmWelfareBenefit()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            facadeWelfare = new WelfareBenefitFacade();
            this.Text = "Welfare Benefit";
        }

        //		============================== Private Method ==============================
        private CompanyInfo getCompany()
        {
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        private void ReportDatabaseLogon()
        {
            try
            {
                //Find valid date.
                DateTime validDate, forMonth;
                    
                validDate = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, VALID_DAY);
                validDate = facadeWelfare.RetriveDate(validDate); // Find that VALID_DAY is holiday or not

                forMonth = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, 1);

                objCompany = getCompany();

                if (facadeWelfare.GenWelfarePayrollBenefit(forMonth, validDate, dtpDate.Value)) // 2019-10-01, 2019-10-18, 2019-10-30
                {
                    SaveFileDialog savef = new SaveFileDialog();
                    savef.InitialDirectory = @"d:\..";
                    savef.FileName = exportPath;
                    savef.ShowDialog();
                    //======================================
                    //	string exportPath =  exportFileName;			
                    string StartDate1 = Convert.ToString(dtpDate.Value.Day);
                    string StartDate2 = Convert.ToString(dtpDate.Value.Month);
                    string StartDate3 = Convert.ToString(dtpDate.Value.Year);

                    ReportDocument crReportDocument = new ReportDocument();
                    crReportDocument.Load(@ApplicationProfile.REPORT_PATH + "rptWelfareBenefit.rpt");
                    DataSourceConnections dataSourceConnections = crReportDocument.DataSourceConnections;
                    IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                    iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    crReportDocument.DataDefinition.FormulaFields["DAY"].Text = StartDate1;
                    crReportDocument.DataDefinition.FormulaFields["MONTH"].Text = StartDate2;
                    crReportDocument.DataDefinition.FormulaFields["YEAR"].Text = StartDate3;

                    crvMedInterfaceFile.ReportSource = crReportDocument;

                    ExportOptions crExportOptions;
                    DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();

                    crDestOptions.DiskFileName = savef.FileName;

                    crExportOptions = crReportDocument.ExportOptions;
                    crExportOptions.DestinationOptions = crDestOptions;
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.Text;

                    TextFormatOptions csValuesFormatOptions;
                    csValuesFormatOptions = ExportOptions.CreateTextFormatOptions();
                    csValuesFormatOptions.CharactersPerInch = 12;
                    csValuesFormatOptions.LinesPerPage = 0;

                    crExportOptions = crReportDocument.ExportOptions;
                    crExportOptions.DestinationOptions = crDestOptions;
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.Text;
                    crExportOptions.ExportFormatOptions = csValuesFormatOptions;

                    crReportDocument.Export(crExportOptions);
                    //						crReportDocument.ExportToDisk (ExportFormatType.Text, exportPath); 
                    //rptPayrollConnectionCheckList
                    string Date1 = Convert.ToString(dtpDate.Value.Month);
                    string Date2 = Convert.ToString(dtpDate.Value.Year);

                    ReportDocument crReportDocument1 = new ReportDocument();
                    crReportDocument1.Load(@ApplicationProfile.REPORT_PATH + "rptWelfareConnectionCheckList.rpt");
                    DataSourceConnections dataSourceConnections1 = crReportDocument1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    crReportDocument1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                    crReportDocument1.DataDefinition.FormulaFields["MONTH"].Text = Date1;
                    crReportDocument1.DataDefinition.FormulaFields["YEAR"].Text = Date2;

                    crvWelfareBankReport.ReportSource = crReportDocument1;

                    ReportDocument crReportDocument2 = new ReportDocument();
                    crReportDocument2.Load(@ApplicationProfile.REPORT_PATH + "rptWelfareBenefitBankDeposit.rpt");
                    DataSourceConnections dataSourceConnections2 = crReportDocument2.DataSourceConnections;
                    IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                    iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    crvBankReport.ReportSource = crReportDocument2;
                }
                else
                {
                    errorMessage("Payment date is invalid !");
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        //		==============================Base Event ==============================
        public void InitForm()
        {
            try
            {
                //Find last day - 1 of current date 
                DateTime paymentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1);

                //If payment date is holiday then payment date will change to previous.
                dtpDate.Value = facadeWelfare.RetriveDate(paymentDate);
                tabMed.Hide();
                mdiParent.EnableExitCommand(true);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            {
            }
        }

        public void RefreshForm()
        {
            tabMed.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvBankReport.RefreshReport();
            crvWelfareBankReport.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmWelfareBenefit_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void frmWelfareBenefit_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvBankReport);
            CloseReport(crvMedInterfaceFile);
            CloseReport(crvWelfareBankReport);
        }
    }
}
