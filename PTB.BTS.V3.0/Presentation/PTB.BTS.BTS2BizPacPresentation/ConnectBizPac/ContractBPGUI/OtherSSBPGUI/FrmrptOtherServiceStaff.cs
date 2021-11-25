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

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using Presentation.PTB.BTS.BTS2BizPacPresentation.ConnectBizPac.ContractBPGUI;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmrptOtherServiceStaff : ChildFormBase, IMDIChildForm
    {

        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private Presentation.frmMain mdiParent;
        internal string FileName = string.Empty;
        internal bool IsSaveFile = false;
        internal bool IsTestConnect = true;
        public DateTime ConnectDate = DateTime.Today;
        private string name = string.Empty;

        #endregion

        //		============================== Constructor ==============================
        public FrmrptOtherServiceStaff():base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "Other Service Staff Service";

        }
        		//		============================== Property ==============================
		public CompanyInfo getCompany()
		{
			objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}

			else
			{
				return null;
			}
		}
		//		============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();

                //crvSummary
                ReportDocument rdprintSummary = new ReportDocument();
                rdprintSummary.Load(@ApplicationProfile.REPORT_PATH + "rptOtherServiceSummary.rpt");
                DataSourceConnections dataSourceConnections1 = rdprintSummary.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintSummary.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintSummary.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                rdprintSummary.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintSummary.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvSummary.ReportSource = rdprintSummary;

                //crvTIS
                ReportDocument rdprintTIS = new ReportDocument();
                rdprintTIS.Load(@ApplicationProfile.REPORT_PATH + "rptOtherServiceStaffServiceAttachTIS.rpt");
                DataSourceConnections dataSourceConnections3 = rdprintTIS.DataSourceConnections;
                IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
                iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTIS.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintTIS.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintTIS.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvTIS.ReportSource = rdprintTIS;

                //crvDetail
                ReportDocument rdprintOther = new ReportDocument();
                rdprintOther.Load(@ApplicationProfile.REPORT_PATH + "rptOtherServiceStaffServiceAttach.rpt");
                DataSourceConnections dataSourceConnections2 = rdprintOther.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintOther.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintOther.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintOther.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvDetail.ReportSource = rdprintOther;

                if ((FileName != FrmBizPacChargeConnectBase.BP_TEST_REPORT) && (FileName != FrmSummaryIncomeBase.BP_RERUN_REPORT))
                {
                    name = "Other Service Staff Service_" + FileName.Substring(15, 2) + DateTime.Today.ToString("MMM") + FileName.Substring(11, 2) + "_" + FileName.Substring(17, 2) + FileName.Substring(19, 2);
                }
                else
                {
                    name = "Other Service Staff Service_" + DateTime.Today.ToString("MMMM") + "_" + DateTime.Today.Year.ToString();
                }


                //Todsporn Modified 1/6/2020 SQL upgrade 2019

                if ((ApplicationProfile.SERVER_NAME == @"PTBSVR01") && (!IsTestConnect))
                {
                    const string path = @"\\PTBSVR01\BTS\Report\PDF\";
                    string exportPathSummaryPDF = path + name + ".PDF";
                    string exportPathTISPDF = path + name + "_TIS" + ".PDF";
                    string exportPathOtherPDF = path + name + "_Other" + ".PDF";

                    ExportOptions crExportOptionsSummaryPDF;
                    DiskFileDestinationOptions crDestOptionsSummaryPDF = new DiskFileDestinationOptions();

                    crDestOptionsSummaryPDF.DiskFileName = exportPathSummaryPDF;

                    crExportOptionsSummaryPDF = rdprintSummary.ExportOptions;
                    crExportOptionsSummaryPDF.DestinationOptions = crDestOptionsSummaryPDF;
                    crExportOptionsSummaryPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsSummaryPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintSummary.Export(crExportOptionsSummaryPDF);

                    ExportOptions crExportOptionsTISPDF;
                    DiskFileDestinationOptions crDestOptionsTISPDF = new DiskFileDestinationOptions();

                    crDestOptionsTISPDF.DiskFileName = exportPathTISPDF;

                    crExportOptionsTISPDF = rdprintTIS.ExportOptions;
                    crExportOptionsTISPDF.DestinationOptions = crDestOptionsTISPDF;
                    crExportOptionsTISPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsTISPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTIS.Export(crExportOptionsTISPDF);

                    ExportOptions crExportOptionsOtherPDF;
                    DiskFileDestinationOptions crDestOptionsOtherPDF = new DiskFileDestinationOptions();

                    crDestOptionsOtherPDF.DiskFileName = exportPathOtherPDF;

                    crExportOptionsOtherPDF = rdprintOther.ExportOptions;
                    crExportOptionsOtherPDF.DestinationOptions = crDestOptionsOtherPDF;
                    crExportOptionsOtherPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsOtherPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintOther.Export(crExportOptionsOtherPDF);
                }

                if (IsSaveFile)
                {
                    /////////////////////////////////////////////////////////////////////
                    SaveFileDialog savef = new SaveFileDialog();
                    savef.InitialDirectory = @"c:\..";
                    savef.FileName = name + ".xls";

                    if (savef.ShowDialog().Equals(DialogResult.OK))
                    {
                        string savefTIS = name + "_TIS" + ".xls";
                        string savefOther = name + "_Other" + ".xls";
                        string directory = Path.GetDirectoryName(savef.FileName);

                        ///////////////////////////////////////////////
                        ExportOptions crExportOptionsSummary;
                        DiskFileDestinationOptions crDestOptionsSummary = new DiskFileDestinationOptions();

                        crDestOptionsSummary.DiskFileName = savef.FileName;

                        ExcelDataOnlyFormatOptions csValuesFormatOption = new ExcelDataOnlyFormatOptions();
                        csValuesFormatOption.ExportPageHeaderAndPageFooter = true;
                        csValuesFormatOption.SimplifyPageHeaders = true;
                        csValuesFormatOption.ExcelAreaType = AreaSectionKind.PageHeader;

                        crExportOptionsSummary = rdprintSummary.ExportOptions;
                        crExportOptionsSummary.DestinationOptions = crDestOptionsSummary;
                        crExportOptionsSummary.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsSummary.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsSummary.ExportFormatOptions = csValuesFormatOption;

                        rdprintSummary.Export(crExportOptionsSummary);
                        savef = null;

                        ExportOptions crExportOptionsTIS;
                        DiskFileDestinationOptions crDestOptionsTIS = new DiskFileDestinationOptions();

                        crDestOptionsTIS.DiskFileName = Path.Combine(directory, savefTIS);
                        crExportOptionsTIS = rdprintTIS.ExportOptions;
                        crExportOptionsTIS.DestinationOptions = crDestOptionsTIS;
                        crExportOptionsTIS.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTIS.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTIS.ExportFormatOptions = csValuesFormatOption;

                        rdprintTIS.Export(crExportOptionsTIS);

                        ExportOptions crExportOptionsOther;
                        DiskFileDestinationOptions crDestOptionsOther = new DiskFileDestinationOptions();

                        crDestOptionsOther.DiskFileName = Path.Combine(directory, savefOther);

                        crExportOptionsOther = rdprintOther.ExportOptions;
                        crExportOptionsOther.DestinationOptions = crDestOptionsOther;
                        crExportOptionsOther.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsOther.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsOther.ExportFormatOptions = csValuesFormatOption;

                        rdprintOther.Export(crExportOptionsOther);
                   }
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

        #region Base Event
        public void InitForm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            mdiParent.EnableExitCommand(true);

            crvSummary.DisplayToolbar = true;
            crvDetail.DisplayToolbar = true;
            crvTIS.DisplayToolbar = true;

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public void RefreshForm()
        {
            tabControl1.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        } 
        #endregion

        #region Form Event
        private void FrmrptOtherServiceStaff_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void FrmrptOtherServiceStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvDetail);
            CloseReport(crvSummary);
            CloseReport(crvTIS);
        } 
        #endregion
    }
}