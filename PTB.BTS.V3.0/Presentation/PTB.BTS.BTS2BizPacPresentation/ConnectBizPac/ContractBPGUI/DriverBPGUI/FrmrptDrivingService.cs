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
    public partial class FrmrptDrivingService : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private Presentation.frmMain mdiParent;
        internal string FileName = string.Empty;
        internal bool IsTestConnect = true;
        internal bool IsSaveFile = false;
        internal DateTime ConnectDate = DateTime.Today;
        private string name = string.Empty;
        private string ProcessDesc = string.Empty;
        #endregion

        #region Contructor
        public FrmrptDrivingService()
            : base()
        {
            InitializeComponent();
            this.Text = "Detail of driving service charge";
        } 
        #endregion

        #region Private Method
        private CompanyInfo getCompany()
        {
            CompanyInfo objCompany = new CompanyInfo("12");

            using (CompanyFacade facade = new CompanyFacade())
            {
                if (facade.FillCompany(ref objCompany))
                {
                    return objCompany;
                }

                else
                {
                    return null;
                }
            }
        }

        private void ReportDatabaseLogon()
        {
            try
            {
                ProcessDesc = string.Empty;
                CompanyInfo objCompany = getCompany();

                #region Load report customer charge
                //crvSummary
                ProcessDesc = "Load report driving summary";
                ReportDocument rdprintSummary = new ReportDocument();
                rdprintSummary.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceSummary.rpt");
                DataSourceConnections dataSourceConnections1 = rdprintSummary.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintSummary.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintSummary.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                rdprintSummary.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintSummary.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));
                crvSummary.ReportSource = rdprintSummary;

                //crvTIS
                ProcessDesc = "Load report driving for TIS";
                ReportDocument rdprintTIS = new ReportDocument();
                rdprintTIS.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForTIS.rpt");
                DataSourceConnections dataSourceConnections2 = rdprintTIS.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTIS.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintTIS.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintTIS.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintTIS.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintTIS.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvTIS.ReportSource = rdprintTIS;

                //crvThaiMC
                ProcessDesc = "Load report driving for Thai-MC";
                ReportDocument rdprintTMC = new ReportDocument();
                rdprintTMC.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForThaiMC.rpt");
                DataSourceConnections dataSourceConnections3 = rdprintTMC.DataSourceConnections;
                IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
                iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTMC.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintTMC.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintTMC.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintTMC.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintTMC.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvThaiMC.ReportSource = rdprintTMC;

                //crvIVICT
                ProcessDesc = "Load report driving for IVICT";
                ReportDocument rdprintIVICT = new ReportDocument();
                rdprintIVICT.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForIVICT.rpt");
                DataSourceConnections dataSourceConnections9 = rdprintIVICT.DataSourceConnections;
                IConnectionInfo iConnectionInfo9 = dataSourceConnections9[0];
                iConnectionInfo9.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintIVICT.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintIVICT.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintIVICT.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintIVICT.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintIVICT.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvIVICT.ReportSource = rdprintIVICT;

                //crvMCT
                ProcessDesc = "Load report driving for MCT";
                ReportDocument rdprintMCT = new ReportDocument();
                rdprintMCT.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForMCT.rpt");
                DataSourceConnections dataSourceConnections8 = rdprintMCT.DataSourceConnections;
                IConnectionInfo iConnectionInfo8 = dataSourceConnections8[0];
                iConnectionInfo8.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintMCT.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintMCT.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintMCT.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintMCT.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintMCT.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvMCT.ReportSource = rdprintMCT;

                //crvTID
                ProcessDesc = "Load report driving for TID";
                ReportDocument rdprintTID = new ReportDocument();
                rdprintTID.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForTID.rpt");
                DataSourceConnections dataSourceConnections4 = rdprintTID.DataSourceConnections;
                IConnectionInfo iConnectionInfo4 = dataSourceConnections4[0];
                iConnectionInfo4.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTID.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintTID.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintTID.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintTID.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintTID.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvTID.ReportSource = rdprintTID;

                //crvMIT
                ProcessDesc = "Load report driving for MIT";
                ReportDocument rdprintMIT = new ReportDocument();
                rdprintMIT.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForMIT.rpt");
                DataSourceConnections dataSourceConnections5 = rdprintMIT.DataSourceConnections;
                IConnectionInfo iConnectionInfo5 = dataSourceConnections5[0];
                iConnectionInfo5.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintMIT.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintMIT.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintMIT.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintMIT.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintMIT.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvMIT.ReportSource = rdprintMIT;

                //crvTMNF
                ProcessDesc = "Load report driving for TMNF";
                ReportDocument rdprintTMNF = new ReportDocument();
                rdprintTMNF.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForTMNF.rpt");
                DataSourceConnections dataSourceConnections6 = rdprintTMNF.DataSourceConnections;
                IConnectionInfo iConnectionInfo6 = dataSourceConnections6[0];
                iConnectionInfo6.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintTMNF.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintTMNF.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintTMNF.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintTMNF.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintTMNF.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvTMNF.ReportSource = rdprintTMNF;

                //crvOther
                ProcessDesc = "Load report driving for other customer";
                ReportDocument rdprintOther = new ReportDocument();
                rdprintOther.Load(@ApplicationProfile.REPORT_PATH + "rptDrivingServiceAttachForOther.rpt");
                DataSourceConnections dataSourceConnections7 = rdprintOther.DataSourceConnections;
                IConnectionInfo iConnectionInfo7 = dataSourceConnections7[0];
                iConnectionInfo7.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprintOther.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprintOther.DataDefinition.FormulaFields["User"].Text = "'" + UserProfile.UserID + "'";
                rdprintOther.DataDefinition.ParameterFields["Date"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                if (IsTestConnect)
                {
                    rdprintOther.DataDefinition.FormulaFields["ShowFileName"].Text = "'True'";
                    rdprintOther.DataDefinition.FormulaFields["FileName"].Text = "'" + FileName + "'";
                }

                crvOther.ReportSource = rdprintOther; 
                #endregion

                if ((FileName != FrmBizPacChargeConnectBase.BP_TEST_REPORT) && (FileName != FrmSummaryIncomeBase.BP_RERUN_REPORT))
                {
                    name = "Driver service staff service_" + FileName.Substring(15, 2) + DateTime.Today.ToString("MMM") + FileName.Substring(11, 2) + "_" + FileName.Substring(17, 2) + FileName.Substring(19, 2);
                }
                else
                {
                    name = "Driver service staff service_" + DateTime.Today.ToString("MMMM") + "_" + DateTime.Today.Year.ToString();
                }

                #region Create PDF Files


                //Todsporn Modified 1/6/2020 SQL upgrade 2019
                if ((ApplicationProfile.SERVER_NAME == @"PTBSVR01") && (!IsTestConnect))
                {
                    const string path = @"\\PTBSVR01\BTS\Report\PDF\";
                    string exportPathSummaryPDF = path + name + ".PDF";
                    string exportPathTISPDF = path + name + "_TIS" + ".PDF";
                    string exportPathTMCPDF = path + name + "_ThaiMC" + ".PDF";
                    string exportPathIVICTPDF = path + name + "_IVICT" + ".PDF";
                    string exportPathMCTPDF = path + name + "_MCT" + ".PDF";
                    string exportPathTIDPDF = path + name + "_TID" + ".PDF";
                    string exportPathMITPDF = path + name + "_MIT" + ".PDF";
                    string exportPathTMNFPDF = path + name + "_TMNF" + ".PDF";
                    string exportPathOtherPDF = path + name + "_Other" + ".PDF";

                    ExportOptions crExportOptionsPDF;
                    DiskFileDestinationOptions crDestOptionsPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving Summary";
                    crDestOptionsPDF.DiskFileName = exportPathSummaryPDF;

                    crExportOptionsPDF = rdprintSummary.ExportOptions;
                    crExportOptionsPDF.DestinationOptions = crDestOptionsPDF;
                    crExportOptionsPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintSummary.Export(crExportOptionsPDF);

                    ExportOptions crExportOptionsTISPDF;
                    DiskFileDestinationOptions crDestOptionsTISPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For TIS";
                    crDestOptionsTISPDF.DiskFileName = exportPathTISPDF;

                    crExportOptionsTISPDF = rdprintTIS.ExportOptions;
                    crExportOptionsTISPDF.DestinationOptions = crDestOptionsTISPDF;
                    crExportOptionsTISPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsTISPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTIS.Export(crExportOptionsTISPDF);

                    ExportOptions crExportOptionsTMCPDF;
                    DiskFileDestinationOptions crDestOptionsTMCPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For Thai-MC";
                    crDestOptionsTMCPDF.DiskFileName = exportPathTMCPDF;

                    crExportOptionsTMCPDF = rdprintTMC.ExportOptions;
                    crExportOptionsTMCPDF.DestinationOptions = crDestOptionsTMCPDF;
                    crExportOptionsTMCPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsTMCPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTMC.Export(crExportOptionsTMCPDF);

                    ExportOptions crExportOptionsIVICTPDF;
                    DiskFileDestinationOptions crDestOptionsIVICTPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For IVICT";
                    crDestOptionsIVICTPDF.DiskFileName = exportPathIVICTPDF;  // Nov 3, 2018 [Kriangkrai A.] Fixing Bugs set export path to incorrect variable

                    crExportOptionsIVICTPDF = rdprintIVICT.ExportOptions;
                    crExportOptionsIVICTPDF.DestinationOptions = crDestOptionsIVICTPDF;
                    crExportOptionsIVICTPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsIVICTPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTMC.Export(crExportOptionsIVICTPDF);

                    ExportOptions crExportOptionsMCTPDF;
                    DiskFileDestinationOptions crDestOptionsMCTPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For MCT";
                    crDestOptionsMCTPDF.DiskFileName = exportPathMCTPDF;

                    crExportOptionsMCTPDF = rdprintMCT.ExportOptions;
                    crExportOptionsMCTPDF.DestinationOptions = crDestOptionsMCTPDF;
                    crExportOptionsMCTPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsMCTPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintMCT.Export(crExportOptionsMCTPDF);

                    ExportOptions crExportOptionsTIDPDF;
                    DiskFileDestinationOptions crDestOptionsTIDPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For TID";
                    crDestOptionsTIDPDF.DiskFileName = exportPathTIDPDF;

                    crExportOptionsTIDPDF = rdprintTID.ExportOptions;
                    crExportOptionsTIDPDF.DestinationOptions = crDestOptionsTIDPDF;
                    crExportOptionsTIDPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsTIDPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTID.Export(crExportOptionsTIDPDF);

                    ExportOptions crExportOptionsMITPDF;
                    DiskFileDestinationOptions crDestOptionsMITPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For MIT";
                    crDestOptionsMITPDF.DiskFileName = exportPathMITPDF;

                    crExportOptionsMITPDF = rdprintMIT.ExportOptions;
                    crExportOptionsMITPDF.DestinationOptions = crDestOptionsMITPDF;
                    crExportOptionsMITPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsMITPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintMIT.Export(crExportOptionsMITPDF);

                    ExportOptions crExportOptionsTMNFPDF;
                    DiskFileDestinationOptions crDestOptionsTMNFPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For TMNF";
                    crDestOptionsTMNFPDF.DiskFileName = exportPathTMNFPDF;

                    crExportOptionsTMNFPDF = rdprintTMNF.ExportOptions;
                    crExportOptionsTMNFPDF.DestinationOptions = crDestOptionsTMNFPDF;
                    crExportOptionsTMNFPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsTMNFPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintTMNF.Export(crExportOptionsTMNFPDF);

                    ExportOptions crExportOptionsOtherPDF;
                    DiskFileDestinationOptions crDestOptionsOtherPDF = new DiskFileDestinationOptions();

                    ProcessDesc = "Create PDF File Driving For Other Customer";
                    crDestOptionsOtherPDF.DiskFileName = exportPathOtherPDF;

                    crExportOptionsOtherPDF = rdprintOther.ExportOptions;
                    crExportOptionsOtherPDF.DestinationOptions = crDestOptionsOtherPDF;
                    crExportOptionsOtherPDF.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptionsOtherPDF.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rdprintOther.Export(crExportOptionsOtherPDF);
                } 
                #endregion

                #region Create Excel Files
                if (IsSaveFile)
                {
                    SaveFileDialog savef = new SaveFileDialog();
                    savef.InitialDirectory = @"c:\..";
                    savef.FileName = name + ".xls";                    

                    if (savef.ShowDialog().Equals(DialogResult.OK))
                    {
                        string saveTIS = name + "_TIS" + ".xls";
                        string saveTMC = name + "_ThaiMC" + ".xls";
                        string saveIVICT = name + "_IVICT" + ".xls";
                        string saveMCT = name + "_MCT" + ".xls";
                        string saveTID = name + "_TID" + ".xls";
                        string saveMIT = name + "_MIT" + ".xls";
                        string saveTMNF = name + "_TMNF" + ".xls";
                        string savefOther = name + "_Other" + ".xls";
                        string directory = Path.GetDirectoryName(savef.FileName);                        

                        ProcessDesc = "Create Excel File Driving Summary";
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
                        savef = null;

                        ProcessDesc = "Create Excel File Driving For TIS";
                        ExportOptions crExportOptionsTIS;
                        DiskFileDestinationOptions crDestOptionsTIS = new DiskFileDestinationOptions();
                        crDestOptionsTIS.DiskFileName = Path.Combine(directory, saveTIS);

                        crExportOptionsTIS = rdprintTIS.ExportOptions;
                        crExportOptionsTIS.DestinationOptions = crDestOptionsTIS;
                        crExportOptionsTIS.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTIS.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTIS.ExportFormatOptions = csValuesFormatOptions;

                        rdprintTIS.Export(crExportOptionsTIS);
                        saveTIS = null;

                        ProcessDesc = "Create Excel File Driving For Thai-MC";
                        ExportOptions crExportOptionsTMC;
                        DiskFileDestinationOptions crDestOptionsTMC = new DiskFileDestinationOptions();
                        crDestOptionsTMC.DiskFileName = Path.Combine(directory, saveTMC);

                        crExportOptionsTMC = rdprintTMC.ExportOptions;
                        crExportOptionsTMC.DestinationOptions = crDestOptionsTMC;
                        crExportOptionsTMC.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTMC.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTMC.ExportFormatOptions = csValuesFormatOptions;

                        rdprintTMC.Export(crExportOptionsTMC);
                        saveTMC = null;

                        ProcessDesc = "Create Excel File Driving For IVICT";
                        ExportOptions crExportOptionsIVICT;
                        DiskFileDestinationOptions crDestOptionsIVICT = new DiskFileDestinationOptions();
                        crDestOptionsIVICT.DiskFileName = Path.Combine(directory, saveIVICT);

                        crExportOptionsIVICT = rdprintIVICT.ExportOptions;
                        crExportOptionsIVICT.DestinationOptions = crDestOptionsIVICT;
                        crExportOptionsIVICT.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsIVICT.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsIVICT.ExportFormatOptions = csValuesFormatOptions;

                        rdprintIVICT.Export(crExportOptionsIVICT);
                        saveIVICT = null;

                        ProcessDesc = "Create Excel File Driving For MCT";
                        ExportOptions crExportOptionsMCT;
                        DiskFileDestinationOptions crDestOptionsMCT = new DiskFileDestinationOptions();
                        crDestOptionsMCT.DiskFileName = Path.Combine(directory, saveMCT);

                        crExportOptionsMCT = rdprintMCT.ExportOptions;
                        crExportOptionsMCT.DestinationOptions = crDestOptionsMCT;
                        crExportOptionsMCT.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsMCT.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsMCT.ExportFormatOptions = csValuesFormatOptions;

                        rdprintMCT.Export(crExportOptionsMCT);
                        saveMCT = null;

                        ProcessDesc = "Create Excel File Driving For TID";
                        ExportOptions crExportOptionsTID;
                        DiskFileDestinationOptions crDestOptionsTID = new DiskFileDestinationOptions();
                        crDestOptionsTID.DiskFileName = Path.Combine(directory, saveTID);

                        crExportOptionsTID = rdprintTID.ExportOptions;
                        crExportOptionsTID.DestinationOptions = crDestOptionsTID;
                        crExportOptionsTID.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTID.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTID.ExportFormatOptions = csValuesFormatOptions;

                        rdprintTID.Export(crExportOptionsTID);
                        saveTID = null;

                        ProcessDesc = "Create Excel File Driving For MIT";
                        ExportOptions crExportOptionsMIT;
                        DiskFileDestinationOptions crDestOptionsMIT = new DiskFileDestinationOptions();
                        crDestOptionsMIT.DiskFileName = Path.Combine(directory, saveMIT);

                        crExportOptionsMIT = rdprintMIT.ExportOptions;
                        crExportOptionsMIT.DestinationOptions = crDestOptionsMIT;
                        crExportOptionsMIT.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsMIT.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsMIT.ExportFormatOptions = csValuesFormatOptions;

                        rdprintMIT.Export(crExportOptionsMIT);
                        saveMIT = null;

                        ProcessDesc = "Create Excel File Driving For TMNF";
                        ExportOptions crExportOptionsTMNF;
                        DiskFileDestinationOptions crDestOptionsTMNF = new DiskFileDestinationOptions();
                        crDestOptionsTMNF.DiskFileName = Path.Combine(directory, saveTMNF);

                        crExportOptionsTMNF = rdprintTMNF.ExportOptions;
                        crExportOptionsTMNF.DestinationOptions = crDestOptionsTMNF;
                        crExportOptionsTMNF.ExportDestinationType = ExportDestinationType.DiskFile;
                        crExportOptionsTMNF.ExportFormatType = ExportFormatType.ExcelRecord;
                        crExportOptionsTMNF.ExportFormatOptions = csValuesFormatOptions;

                        rdprintTMNF.Export(crExportOptionsTMNF);
                        saveTMNF = null;

                        ProcessDesc = "Create Excel File Driving For Other Customer";
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
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error Message : {0} \nProcess Status : {1}", ex.Message, ProcessDesc), "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public class ReportFactory
        {
            protected static Queue reportQueue = new Queue();
            protected static ReportClass CreateReport(Type reportClass)
            {
                object report = Activator.CreateInstance(reportClass);
                reportQueue.Enqueue(report);
                return (ReportClass)report;
            }

            public static ReportClass GetReport(Type reportClass)
            {
                //75 is   my print job limit.           
                if (reportQueue.Count > 75)
                {
                    ((ReportClass)reportQueue.Dequeue()).Dispose();
                }
                return CreateReport(reportClass);
            }
        }
        #endregion

        #region Base Event
        public void InitForm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            mdiParent.EnableExitCommand(true);
            crvSummary.DisplayToolbar = true;
            crvMIT.DisplayToolbar = true;
            crvTMNF.DisplayToolbar = true;
            crvMCT.DisplayToolbar = true;
            crvTIS.DisplayToolbar = true;
            crvTID.DisplayToolbar = true;
            crvThaiMC.DisplayToolbar = true;
            crvIVICT.DisplayToolbar = true; 
            crvOther.DisplayToolbar = true;

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
            this.Close();
        }
        #endregion

        #region Form Event
        private void FrmrptDrivingService_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();          
        }

        private void FrmrptDrivingService_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvSummary);
            CloseReport(crvMCT);
            CloseReport(crvMIT);
            CloseReport(crvOther);
            CloseReport(crvThaiMC);
            CloseReport(crvTID);
            CloseReport(crvTIS);
            CloseReport(crvTMNF);
        }
        #endregion
    }
}