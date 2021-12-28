using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.GUI;
using Entity.ContractEntities;
using Report.Reports.Contract;
using Report.BLL;
using Facade.ContractFacade;
using SystemFramework.AppMessage;
using Entity.CommonEntity;
using Presentation.CommonGUI;
using Report.Reports;
using ictus.Common.Entity;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using SystemFramework.AppException;


namespace Presentation.ContractGUI
{
    public partial class FrmrptContractListExpectedIncomeReport : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        ReportContractList reportContractList = new ReportContractList();
        ReportExpectedIncome reportExptedIncome = new ReportExpectedIncome();
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private string companyCode;
        private DocumentNo contract;
        private frmMain mdiParent;
        #endregion

        #region Constructor
        public FrmrptContractListExpectedIncomeReport()
            : base()
        {            
            InitializeComponent();
            this.title = UserProfile.GetFormName("miContract", "miContractListExpectedIncomeReport");
        } 
        #endregion

        #region Private Method


        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractListExpectedIncomeReport");
        }

        /// <summary>
        /// Clear screen when retreive screen
        /// </summary>
        private void clearscreen()
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(1).AddDays(-1);
            initComboContractType();

            visibleForm(false);

            crvReport.Visible = false;
        }

        /// <summary>
        /// Set datasource to Contract Type Combo box
        /// </summary>
        private void initComboContractType()
        {

            cboContractType.DataSource = ContractTypeComboDataSource();
        }
       
        private void setForm(ContractBase contract)
        {

            visibleForm(true);

            MainMenuPrintStatus = true;
            mdiParent.EnablePrintCommand(true);
            MainMenuNewStatus = true;
            mdiParent.EnableNewCommand(true);
        }

        private void visibleForm(bool visible)
        {
           
        }

        private void createReport()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Company company = facadeContract.GetCompany();
                this.Cursor = Cursors.WaitCursor;
                if (!chkExpectedIncome.Checked){
                    ReportContractList rptContract = new ReportContractList();
                    rptContract.SetCriteria(company.CompanyCode, dtpFromDate.Value, dtpToDate.Value, cboContractType.SelectedValue.ToString());
                    this.crvReport.ReportSource = rptContract.Report;
                }else{
                    ReportExpectedIncome rptExptedIncome = new ReportExpectedIncome();
                    rptExptedIncome.SetCriteria(company.CompanyCode);
                    this.crvReport.ReportSource = rptExptedIncome.Report;
                }
                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;                
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
            
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            MainMenuNewStatus = false;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;

            mdiParent.EnableNewCommand(false);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);

            clearscreen();

        }

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {
            createReport();
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region - Event-

        private void btnPrint_Click(object sender, EventArgs e)
        {
            createReport();
        }

        private void FrmContractListExpectedIncomeReport_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }
        
        #endregion

        private List<KeyValuePair<string, string>> ContractTypeComboDataSource()
        {
            List<KeyValuePair<string, string>> dataSource = new List<KeyValuePair<string, string>>();
            dataSource.Add(new KeyValuePair<string,string>("","ทั้งหมด"));
            dataSource.Add(new KeyValuePair<string,string>("C","New Car"));
            dataSource.Add(new KeyValuePair<string,string>("R","Renewal"));
            dataSource.Add(new KeyValuePair<string, string>("T", "Temporary"));
            dataSource.Add(new KeyValuePair<string, string>("D", "Driver"));
            return dataSource;
        }

        private void chkExpectedIncome_CheckedChanged(object sender, EventArgs e)
        {
            EnableSearchCondition(!chkExpectedIncome.Checked);
        }

        private void EnableSearchCondition(bool enable)
        {
            dtpFromDate.Enabled = enable;
            dtpToDate.Enabled = enable;
            cboContractType.Enabled = enable;
        }
    }
}