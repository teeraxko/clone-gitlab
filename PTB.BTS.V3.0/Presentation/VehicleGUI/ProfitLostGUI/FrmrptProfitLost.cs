using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.ProfitLostGUI
{
    public partial class FrmrptProfitLost : ChildFormBase, IMDIChildForm
    {
        #region - private -
        internal DateTime BVDate;
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        #endregion

        //============================== Constructor ==============================
        public FrmrptProfitLost() : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "Profit And Lost";
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

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptProfitAndLost.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint1.DataDefinition.ParameterFields["BVDate"].ApplyCurrentValues(CrytalParameterValue(BVDate));

                crvPrint.ReportSource = rdprint1;
                //////////////////
                SaveFileDialog savef = new SaveFileDialog();
                savef.InitialDirectory = @"c:\..";

                string exportPath = "ProfitAndLost.xls";
                savef.FileName = exportPath;

                if (savef.ShowDialog().Equals(DialogResult.OK))
                {
                    ///////////////////////////////////////////////
                    ExportOptions crExportOptions;
                    DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();

                    crDestOptions.DiskFileName = exportPath;

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
                    savef = null;
                }

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
            this.Cursor = Cursors.WaitCursor;
            ReportDatabaseLogon();
            this.crvPrint.DisplayToolbar = true;
            this.Cursor = Cursors.Default;
        }

        public void RefreshForm()
        {
            this.crvPrint.DisplayToolbar = true;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================
        private void FrmrptProfitLost_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }
}