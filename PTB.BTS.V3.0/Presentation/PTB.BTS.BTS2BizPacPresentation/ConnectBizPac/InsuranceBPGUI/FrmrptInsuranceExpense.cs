using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmrptInsuranceExpense : ChildFormBase, IMDIChildForm
    {
        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private Presentation.frmMain mdiParent;
        internal string fileName = string.Empty;
        internal bool isSaveFile = false;
        internal DateTime ConnectDate = DateTime.Today;
        #endregion

        //============================== Constructor ==============================
        public FrmrptInsuranceExpense()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานค่าเบี้ยประกันภัย";
        }

        //============================== Property ==============================
        public CompanyInfo getCompany()
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

        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptInsuranceTypeOnebyGarage.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["CompName"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint1.DataDefinition.FormulaFields["BPFileName"].Text = "'" + fileName + "'";
                rdprint1.DataDefinition.ParameterFields["ConnectDate"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvInsurance.ReportSource = rdprint1;

                ReportDocument rdprint2 = new ReportDocument();

                rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptInsuranceExpense.rpt");
                DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint2.DataDefinition.FormulaFields["BPFileName"].Text = "'" + fileName + "'";
                rdprint2.DataDefinition.ParameterFields["ConnectDate"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvExpense.ReportSource = rdprint2;

                if (isSaveFile)
                {
                    /////////////////////////////////////////////////////////////////////

                    SaveFileDialog savef = new SaveFileDialog();
                    savef.InitialDirectory = @"c:\..";

                    string exportPath = "รายงานค่าเบี้ยประกันภัย_" + ConnectDate.ToString("MMMM") + "_" + ConnectDate.Year.ToString() + ".xls";
                    savef.FileName = exportPath;

                    SaveFileDialog saveExpense = new SaveFileDialog();
                    saveExpense.InitialDirectory = @"c:\..";

                    string exportPathExpense = "รายงานค่าเบี้ยประกันภัย_" + ConnectDate.ToString("MMMM") + "_" + ConnectDate.Year.ToString() + "_Expense.xls";
                    saveExpense.FileName = exportPathExpense;

                    if (savef.ShowDialog().Equals(DialogResult.OK))
                    {
                        ///////////////////////////////////////////////
                        ExportOptions crExportOptions;
                        DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();
                        crDestOptions.DiskFileName = savef.FileName;

                        ExcelDataOnlyFormatOptions csValuesFormatOptions = new ExcelDataOnlyFormatOptions();
                        csValuesFormatOptions.ExportPageHeaderAndPageFooter = true;
                        csValuesFormatOptions.SimplifyPageHeaders = true;
                        csValuesFormatOptions.ExcelAreaType = AreaSectionKind.PageHeader;

                        crExportOptions = rdprint1.ExportOptions;
                        crExportOptions.DestinationOptions = crDestOptions;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptions.ExportFormatOptions = csValuesFormatOptions;

                        rdprint1.Export(crExportOptions);
                        //savef = null;
                        //////////////////////
                        ExportOptions crExportOptionsExpense;
                        DiskFileDestinationOptions crDestOptionsExpense = new DiskFileDestinationOptions();

                        // Dec 21, 2017 [Kriangkrai A.] system did not show save dialog to select saving path for 2nd report
                        //crDestOptionsExpense.DiskFileName = saveExpense.FileName;
                        crDestOptionsExpense.DiskFileName = savef.FileName.Replace(".xls", "_Expense.xls");

                        ExcelDataOnlyFormatOptions csValuesFormatOptionsExpense = new ExcelDataOnlyFormatOptions();
                        csValuesFormatOptionsExpense.ExportPageHeaderAndPageFooter = true;
                        csValuesFormatOptionsExpense.SimplifyPageHeaders = true;
                        csValuesFormatOptionsExpense.ExcelAreaType = AreaSectionKind.PageHeader;

                        crExportOptionsExpense = rdprint2.ExportOptions;
                        crExportOptionsExpense.DestinationOptions = crDestOptionsExpense;
                        crExportOptionsExpense.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsExpense.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsExpense.ExportFormatOptions = csValuesFormatOptionsExpense;

                        rdprint2.Export(crExportOptionsExpense);
                        saveExpense = null;
                    }
                    
                }

                Message(MessageList.Information.I0005);
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
        private ParameterValues CrytalParameterValue(object paraValue)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }
        //==============================Base Event ==============================
        public void InitForm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            tbControl.Show();
      //      crvInsurance.RefreshReport();
      //      crvExpense.RefreshReport();
            crvExpense.DisplayToolbar = true;
            crvInsurance.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            tbControl.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }


        //==============================Base Event ==============================
        private void FrmrptInsuranceExpense_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void FrmrptInsuranceExpense_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvExpense);
            CloseReport(crvInsurance);
        }
    }
}