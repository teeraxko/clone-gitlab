using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using CrystalDecisions.CrystalReports.Engine;
using Facade.PiFacade;
using SystemFramework.AppException;
using System.Data.SqlClient;
using SystemFramework.AppMessage;
using CrystalDecisions.Shared;
using PTB.BTS.Contract.Facade;

namespace Presentation.ContractGUI
{
    public partial class FrmrptVehicleChargeDiff : ChildFormBase, IMDIChildForm 
    {
        private frmMain mdiParent;
        private VehicleChargeDiffFacade facadeVehicleChargeDiff;

        //============================== Constructor ==============================
        public FrmrptVehicleChargeDiff()
            : base()
        {
            InitializeComponent();
            facadeVehicleChargeDiff = new VehicleChargeDiffFacade();
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentChargeDiff");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentChargeDiff");
        }

        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                if (facadeVehicleChargeDiff.GenerateChargeDiff(dtpDate.Value))
                {
                    ReportDocument rdprint1 = new ReportDocument();

                    rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeDifference.rpt");
                    DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + facadeVehicleChargeDiff.GetCompanyInfo().AFullName.Thai + "'";
                    rdprint1.DataDefinition.FormulaFields["Year"].Text = "'" + dtpDate.Value.Year.ToString() + "'";
                    rdprint1.DataDefinition.FormulaFields["Month"].Text = "'" + dtpDate.Value.Month.ToString() + "'";

                    crvReport1.ReportSource = rdprint1;
                }
                else
                {
                    Message(MessageList.Error.E0014, "คำนวณผลต่างค่าเช่าได้");                    
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

        //==============================Base Event ==============================
        public void InitForm()
        {
            dtpDate.Value = DateTime.Today;
            crvReport1.Hide();
        }

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Base Event ==============================
        private void FrmListofVehicleChargeDiff_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvReport1.Show();
            crvReport1.RefreshReport();
            this.Cursor = Cursors.Default;
        }
    }
}