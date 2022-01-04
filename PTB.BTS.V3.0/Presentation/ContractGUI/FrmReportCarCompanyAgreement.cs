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
using ictus.Common.Entity;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
    public partial class FrmReportCarCompanyAgreement : ChildFormBase, IMDIChildForm
    {
        #region Private Variable

        ReportCarCompanyAgreement reportCarCompanyAgreement = new ReportCarCompanyAgreement();
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private frmMain mdiParent;

        #endregion

        #region Constructor
        public FrmReportCarCompanyAgreement()
            : base()
        {
            InitializeComponent();
            this.title = UserProfile.GetFormName("micontract","miContractDocumentCompanyAgreement");
        } 
        #endregion

        #region Private Method

        /// <summary>
        /// Show form ID
        /// </summary>
        /// <returns></returns>
        public override string FormID()
        {
            return UserProfile.GetFormID("micontract", "miContractDocumentCompanyAgreement");
        }

        /// <summary>
        /// Set Customer Name to Combo box
        /// </summary>
        private void InitComboCustomer()
        {            
            cboCustomerName.DataSource = facadeContract.DataSourceCustomerName;
        }

        private void CreateReport(string customerCode, DateTime contractDate)
        {
            this.Cursor = Cursors.WaitCursor;            
            Company company = facadeContract.GetCompany();
            reportCarCompanyAgreement.SetCriteria(company.CompanyCode, customerCode, contractDate);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportCarCompanyAgreement.Report;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Clear screen when retreive screen
        /// </summary>
        private void Clearscreen()
        {
            InitComboCustomer();

            btnContractPrint.Enabled = false;
            crvReport.Visible = false;
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

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {            
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region - Event-      
        
        /// <summary>
        /// กดปุ่มพิมพ์
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContractPrint_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)cboCustomerName.SelectedItem;

            CreateReport(customer.Code, dtpContractDate.Value);
        }

        private void FrmReportCarCompanyAgreement_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        /// <summary>
        /// เมื่อมีการเปลี่ยนชื่อลูกค้า
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cboCustomerName.Text))
            {
                btnContractPrint.Enabled = true;
            }
            else
            {
                //ไม่เลือกลูกค้า หรือชื่อเป็นค่าว่าง
                btnContractPrint.Enabled = false;
            }
            crvReport.Visible = false;
            crvReport.ReportSource = null;

        }        

        #endregion

        /// <summary>
        /// พิมพ์ชื่อลูกค้าเอง
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCustomerName_TextChanged(object sender, EventArgs e)
        {
            cboCustomerName_SelectedIndexChanged(sender, e);
        }
        
    }
}
