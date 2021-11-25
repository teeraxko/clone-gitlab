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

using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;
using System.Threading;
using System.Globalization;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmrptCompulsoryExpense : ChildFormBase, IMDIChildForm
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
        public FrmrptCompulsoryExpense()
            : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานค่าประกัน พรบ.";
		}

		//============================== Property ==============================
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

		//============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptCompulsoryExpensebyGarage.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["CompName"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint1.DataDefinition.FormulaFields["BPFileName"].Text = "'"+ fileName +"'";
                rdprint1.DataDefinition.ParameterFields["ConnectDate"].ApplyCurrentValues(CrytalParameterValue(ConnectDate));

                crvCompulsory.ReportSource = rdprint1;

                ///////////////////////////////////////////////

                if (isSaveFile)
                {
                    SaveFileDialog savef = new SaveFileDialog();
                    savef.InitialDirectory = @"c:\..";

                    string exportPath = "รายงานค่าประกัน พรบ._" + ConnectDate.ToString("MMMM") + "_" + ConnectDate.ToString("yyyy") + ".xls";
                    savef.FileName = exportPath;

                    if (savef.ShowDialog().Equals(DialogResult.OK))
                    {
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
                    }
                    savef = null;
                }
                ///////////////////////////////////////////////
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
            crvCompulsory.Show();
      //      crvCompulsory.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvCompulsory.Show();
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
        private void FrmrptCompulsoryExpense_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void FrmrptCompulsoryExpense_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvCompulsory);
        }
    }
}