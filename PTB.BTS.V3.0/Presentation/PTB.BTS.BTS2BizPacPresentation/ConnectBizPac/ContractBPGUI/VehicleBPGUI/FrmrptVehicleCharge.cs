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
    public partial class FrmrptVehicleCharge : ChildFormBase, IMDIChildForm
    {
   		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private Presentation.frmMain mdiParent;
        public string fileName = string.Empty;
        internal bool isSaveFile = false;
        public DateTime ConnectDate = DateTime.Today;
        private string name = string.Empty;

		#endregion

		//		============================== Constructor ==============================
        public FrmrptVehicleCharge() : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานแสดงค่าเช่า";

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

                rdprintSummary.Load(@ApplicationProfile.REPORT_PATH + "rptCarRentalServiceSummary.rpt");
                DataSourceConnections dataSourceConnections1 = rdprintSummary.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintSummary.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprintSummary.DataDefinition.FormulaFields["FileName"].Text = "'" + fileName + "'";
                rdprintSummary.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvSummary.ReportSource = rdprintSummary;
                //crvTIS

                ReportDocument rdprintTIS = new ReportDocument();

                rdprintTIS.Load(@ApplicationProfile.REPORT_PATH + "rptCarRentalAttachForTIS.rpt");
                DataSourceConnections dataSourceConnections2 = rdprintTIS.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTIS.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprintTIS.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvTIS.ReportSource = rdprintTIS;

                //crvDetail
                ReportDocument rdprintOther = new ReportDocument();

                rdprintOther.Load(@ApplicationProfile.REPORT_PATH + "rptCarRentalAttachForOther.rpt");
                DataSourceConnections dataSourceConnections3 = rdprintOther.DataSourceConnections;
                IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
                iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintOther.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprintOther.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvDetail.ReportSource = rdprintOther;

                if ((fileName != FrmBizPacChargeConnectBase.BP_TEST_REPORT) && (fileName != FrmSummaryIncomeBase.BP_RERUN_REPORT))
                {
                    name = "รายงานค่าเช่ารถ_" + fileName.Substring(15, 2) + DateTime.Today.ToString("MMM") + fileName.Substring(11, 2) + "_" + fileName.Substring(17, 2) + fileName.Substring(19, 2);
                }
                else
                {
                    name = "รายงานค่าเช่ารถ_" + DateTime.Today.ToString("MMMM") + "_" + DateTime.Today.Year.ToString();
                }
                ///////////////////create to PDF file


                //Todsporn Modified 1/6/2020 SQL upgrade 2019

                if (ApplicationProfile.SERVER_NAME == @"PTBSVR01")
                {
                    const string path = @"\\PTBSVR01\BTS\Report\PDF\";
                    string exportPathSummaryPDF = path + name + ".PDF";
                    string exportPathTISPDF = path + name + "_TIS" + ".PDF";
                    string exportPathOtherPDF = path + name + "_Other" + ".PDF";

                    ///////////////////////////////////////////////
                    ExportOptions crExportOptionsPDF;
                    DiskFileDestinationOptions crDestOptionsPDF = new DiskFileDestinationOptions();

                    crDestOptionsPDF.DiskFileName = exportPathSummaryPDF;

                    crExportOptionsPDF = rdprintSummary.ExportOptions;
                    crExportOptionsPDF.DestinationOptions = crDestOptionsPDF;
                    crExportOptionsPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintSummary.Export(crExportOptionsPDF);

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
                ///////////////create to excel file

                if (isSaveFile)
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
                        ExportOptions crExportOptions;
                        DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();

                        crDestOptions.DiskFileName = savef.FileName;

                        ExcelDataOnlyFormatOptions csValuesFormatOptions = new ExcelDataOnlyFormatOptions();
                        csValuesFormatOptions.ExportPageHeaderAndPageFooter = true;
                        csValuesFormatOptions.SimplifyPageHeaders = true;
                        csValuesFormatOptions.ExcelAreaType = AreaSectionKind.PageHeader;

                        crExportOptions = rdprintSummary.ExportOptions;
                        crExportOptions.DestinationOptions = crDestOptions;
                        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptions.ExportFormatOptions = csValuesFormatOptions;

                        rdprintSummary.Export(crExportOptions);

                        ExportOptions crExportOptionsTIS;
                        DiskFileDestinationOptions crDestOptionsTIS = new DiskFileDestinationOptions();

                        crDestOptionsTIS.DiskFileName = Path.Combine(directory, savefTIS);

                        crExportOptionsTIS = rdprintTIS.ExportOptions;
                        crExportOptionsTIS.DestinationOptions = crDestOptionsTIS;
                        crExportOptionsTIS.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTIS.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTIS.ExportFormatOptions = csValuesFormatOptions;

                        rdprintTIS.Export(crExportOptionsTIS);
                        savefTIS = null;

                        ExportOptions crExportOptionsOther;
                        DiskFileDestinationOptions crDestOptionsOther = new DiskFileDestinationOptions();

                        crDestOptionsOther.DiskFileName = Path.Combine(directory, savefOther);

                        crExportOptionsOther = rdprintOther.ExportOptions;
                        crExportOptionsOther.DestinationOptions = crDestOptionsOther;
                        crExportOptionsOther.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsOther.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsOther.ExportFormatOptions = csValuesFormatOptions;

                        rdprintOther.Export(crExportOptionsOther);
                        savefOther = null;
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

        //		==============================Base Event ==============================
        public void InitForm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            mdiParent.EnableExitCommand(true);

            crvSummary.DisplayToolbar = true;
            crvTIS.DisplayToolbar = true;
            crvDetail.DisplayToolbar = true;            

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
       
    //		============================== Event ==============================
        private void FrmrptVehicleCharge_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void FrmrptVehicleCharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvDetail);
            CloseReport(crvSummary);
            CloseReport(crvTIS);
        }
    }
}