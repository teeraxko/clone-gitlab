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


        /// <summary>
        /// Set Form ID to display on the parent form at the bottom left.
        /// </summary>
        /// <returns></returns>
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractListExpectedIncomeReport");
        }

        /// <summary>
        /// Clear screen when retreive screen
        /// </summary>
        private void Clearscreen()
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(1).AddDays(-1);
            InitComboContractType();

            VisibleForm(false);

            crvReport.Visible = false;
        }

        /// <summary>
        /// Set datasource to Contract Type Combo box
        /// </summary>
        private void InitComboContractType()
        {

            cboContractType.DataSource = ContractTypeComboDataSource();
        }
       
        private void SetForm(ContractBase contract)
        {

            VisibleForm(true);

            MainMenuPrintStatus = true;
            mdiParent.EnablePrintCommand(true);
            MainMenuNewStatus = true;
            mdiParent.EnableNewCommand(true);
        }

        private void VisibleForm(bool visible)
        {
           
        }

        /// <summary>
        /// Show report
        /// </summary>
        private void CreateReport()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Company company = (new ContractFacadeBase()).GetCompany();
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

            Clearscreen();

        }

        /// <summary>
        /// Refresh form.
        /// </summary>
        public void RefreshForm()
        {
        }

        //Show the report.
        public void PrintForm()
        {
            CreateReport();
        }

        /// <summary>
        /// Close form.
        /// </summary>
        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region - Event-

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateReport();
        }

        private void FrmContractListExpectedIncomeReport_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }
        
        #endregion

        /// <summary>
        /// Datasource of contract type combo.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Set enable/disable search condition.
        /// </summary>
        /// <param name="enable"></param>
        private void EnableSearchCondition(bool enable)
        {
            dtpFromDate.Enabled = enable;
            dtpToDate.Enabled = enable;
            cboContractType.Enabled = enable;
        }
    }
}