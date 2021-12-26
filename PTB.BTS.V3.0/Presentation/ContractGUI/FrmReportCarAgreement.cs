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

namespace Presentation.ContractGUI
{
    public partial class FrmReportCarAgreement : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        ReportCarAgreement reportCarAgreement = new ReportCarAgreement();
        private VehicleContract objVehicleContract;
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private string customerCode;
        private string contractNo;
        private string companyCode;
        private DocumentNo contract;
        private frmMain mdiParent;
        #endregion

        #region Constructor
        public FrmReportCarAgreement()
            : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Method

        //D21018 ออกสัญญาพนักงานขับรถ + ออกสัญญารถเช่า
        private DOCUMENT_TYPE _documentType;
        private DOCUMENT_TYPE DocumentType
        {
            get
            {
                return this._documentType;
            }
            set
            {
                this._documentType = value;
            }
        }

        /// <summary>
        /// Get ContractNo from DocumentNo 
        /// </summary>
        /// <returns></returns>
        private DocumentNo getContractNo()
        {
            //D21018 ออกสัญญาพนักงานขับรถ + ออกสัญญารถเช่า
            contract = new DocumentNo(this._documentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contract;
        }

        /// <summary>
        /// Clear screen when retreive screen
        /// </summary>
        private void clearscreen()
        {
            initComboCustomer();

            //D21018-BTS Contract Modification
            initComboVehicleType();

            txtContractNoYY.Text = string.Empty;
            txtContractNoMM.Text = string.Empty;
            txtContractNoXXX.Text = string.Empty;
            txtContractStartDate.Text = string.Empty;
            txtContractEndDate.Text = string.Empty;
            txtContractType.Text = string.Empty;
            txtContractsts.Text = string.Empty;
            txtCustomerName.Text = string.Empty;

            visibleForm(false);
            enableSearchDetail(true);

            crvReport.Visible = false;
        }

        /// <summary>
        /// Set Customer Name to Combo box
        /// </summary>
        private void initComboCustomer()
        {
            objVehicleContract = new VehicleContract(facadeContract.GetCompany());
            cmbCustomerName.DataSource = facadeContract.DataSourceCustomerName;
        }

        //D21018-BTS Contract Modification
        private void initComboVehicleType()
        {
            List<string> kindContract = new List<string>() { "C", "R", "T" };
            cboVehicleKindContract.DataSource = kindContract;             
        }
        /// <summary>
        /// Pop up Contract List by condition from first screen
        /// </summary>
        private void formContractList()
        {
            ContractType contractType = new ContractType();
            contractType.Code = ContractType.CONTRACT_TYPE_VEHICLE;
            ContractStatus contractStatus = new ContractStatus();
            contractStatus.Code = ContractStatus.CONTRACT_STS_APPROVED;

            frmContractVDOList dialogContractList = new frmContractVDOList();

            if (cmbCustomerName.Text != "")
            {
                dialogContractList.ConditionCustomer = (Customer)cmbCustomerName.SelectedItem;
            }

            //D21018 ออกสัญญาพนักงานขับรถ + ออกสัญญารถเช่า
            dialogContractList.DocumentType = this.DocumentType;            

            dialogContractList.ConditionCONTRACT_TYPE = contractType;
            dialogContractList.IsVehclePurchaing = true;
            dialogContractList.ConditionContractStatus = contractStatus;

            if (txtContractNoYY.Text != "")
            {
                dialogContractList.ConditionYY = txtContractNoYY.Text;
            }

            if (txtContractNoMM.Text != "")
            {
                dialogContractList.ConditionMM = txtContractNoMM.Text;
            }

            if (txtContractNoXXX.Text != "")
            {
                dialogContractList.ConditionXXX = txtContractNoXXX.Text;
            }
            dialogContractList.ShowDialog();

            if (dialogContractList.Selected)
            {
                retriveContract(dialogContractList.SelectedContract);
            }

            dialogContractList = null;
        }

        /// <summary>
        /// set value from object contract to screen
        /// </summary>
        /// <param name="contract"></param>
        private void retriveContract(ContractBase contract)
        {
            txtContractNoYY.Text = contract.ContractNo.Year;
            txtContractNoMM.Text = contract.ContractNo.Month;
            txtContractNoXXX.Text = contract.ContractNo.No;
            txtContractStartDate.Text = contract.APeriod.From.ToString("dd/MM/yyyy");
            txtContractEndDate.Text = contract.APeriod.To.Date.ToString("dd/MM/yyyy");
            txtContractType.Text = contract.AContractType.AName.English;
            txtContractsts.Text = contract.AContractStatus.AName.English;
            txtCustomerName.Text = contract.ACustomer.AName.English;
            customerCode = contract.ACustomer.Code;
            contractNo = contract.ContractNo.ToString();
            companyCode = facadeContract.GetCompany().CompanyCode;

            setForm(contract);
        }

        private void setForm(ContractBase contract)
        {
            btnPrint.Enabled = contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_APPROVED;

            visibleForm(true);
            enableSearchDetail(false);

            MainMenuPrintStatus = true;
            mdiParent.EnablePrintCommand(true);
            MainMenuNewStatus = true;
            mdiParent.EnableNewCommand(true);
        }

        private void enableSearchDetail(bool enable)
        {
            cmbCustomerName.Enabled = enable;
            txtContractNoMM.Enabled = enable;
            txtContractNoXXX.Enabled = enable;
            txtContractNoYY.Enabled = enable;
            btnSearch.Enabled = enable;
            btnPrint.Enabled = !enable;
        }

        private void visibleForm(bool visible)
        {
            gpbOtherDetail.Visible = visible;
        }

        private void createReport()
        {
            this.Cursor = Cursors.WaitCursor;
            reportCarAgreement.SetCriteria(companyCode, customerCode, contractNo, txtAccessory.Text);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportCarAgreement.Report;
            this.Cursor = Cursors.Default;
        }

        #region Validate
        /// <summary>
        /// Check input ContractNo before Pop up Contract List screen
        /// </summary>
        /// <returns></returns>
        private bool validateInputContractNo()
        {
            return validatetxtContractNoYY() &&
                    validatetxtContractNoMM() &&
                    validatetxtContractNoXXX() &&
                    validateContractNo();
        }

        /// <summary>
        /// Check input ContractNo Year
        /// </summary>
        /// <returns></returns>
        private bool validatetxtContractNoYY()
        {
            if (txtContractNoYY.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoYY.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check input ContractNo Month
        /// </summary>
        /// <returns></returns>
        private bool validatetxtContractNoMM()
        {
            if (txtContractNoMM.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoMM.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check Input ContractNo XXX
        /// </summary>
        /// <returns></returns>
        private bool validatetxtContractNoXXX()
        {
            if (txtContractNoXXX.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoXXX.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check validate ContractNo 
        /// </summary>
        /// <returns></returns>
        private bool validateContractNo()
        {
            ContractBase tempContract = facadeContract.RetriveContract(getContractNo());

            if (tempContract == null)
            {
                Message(MessageList.Error.E0004, "เลขที่สัญญา");
                txtContractNoYY.Focus();
                return false;
            }
            else
            {
                if (tempContract.AContractType.Code != ContractType.CONTRACT_TYPE_VEHICLE)
                {
                    Message(MessageList.Error.E0004, "เลขที่สัญญา");
                    txtContractNoXXX.Focus();
                    return false;
                }
            }

            return true;
        }

        private void SetDocumentTypeFromAbbreviation(string value)
        {
            switch (value)
            {
                case "C":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
                case "R":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_RENEWAL;
                    break;
                case "T":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                    break;
                default:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
            }
        }

        private void SetDocumentType()
        {
            switch (cboVehicleKindContract.Text)
            {
                case "C":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
                case "R":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_RENEWAL;
                    break;
                case "T":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                    break;
                default:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
            }
        }

        #endregion

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

            //D21018 ออกสัญญาพนักงานขับรถ + ออกสัญญารถเช่า
            cboVehicleKindContract.SelectedIndex = 0;
            cboVehicleKindContract.Enabled = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formContractList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            createReport();
        }

        private void FrmReportCarAgreement_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void txtContractNoYY_TextChanged(object sender, EventArgs e)
        {
            if (txtContractNoYY.Text.Length == 2)
                txtContractNoMM.Focus();
        }

        private void txtContractNoMM_TextChanged(object sender, EventArgs e)
        {
            if (txtContractNoMM.Text.Length == 2)
                txtContractNoXXX.Focus();
        }

        private void txtContractNoXXX_TextChanged(object sender, EventArgs e)
        {
            if (txtContractNoXXX.Text.Length == 3)
            {
                if (validateInputContractNo())
                { retriveContract(facadeContract.RetriveContract(getContractNo())); }
            }
        }

        private void txtContractNoXXX_DoubleClick(object sender, EventArgs e)
        {
            formContractList();
        }
        #endregion

        private void cboVehicleKindContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDocumentType();
        }
    }
}
