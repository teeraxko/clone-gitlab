using System;
using System.Windows.Forms;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Facade.ContractFacade;
using Presentation.CommonGUI;
using Report.Reports.Contract;
using SystemFramework.AppMessage;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.AttendanceEntities;

namespace Presentation.ContractGUI
{
    public partial class FrmReportDriverAgreement : ChildFormBase, IMDIChildForm	
    {
        #region -Initail constrain-
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private ContractBase driverContract;
        private DocumentNo contractNo;
        private frmMain mdiParent;
        #endregion

        #region Constructor
        public FrmReportDriverAgreement()
            : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Method
        /// <summary>
        /// Clear screen when retreive screen
        /// </summary>
        private void clearscreen()
        {
            initComboCustomer();

            txtContractNoYY.Text = string.Empty;
            txtContractNoMM.Text = string.Empty;
            txtContractNoXXX.Text = string.Empty;

            txtContractStartDate.Text = string.Empty;
            txtContractEndDate.Text = string.Empty;
            txtContractType.Text = string.Empty;
            txtContractsts.Text = string.Empty;
            txtCustomerName.Text = string.Empty;

            txtCommonDriver.Text = "0";
            numCommonRate.Value = 0;
            txtFamilyDriver.Text = "0";
            numFamilyRate.Value = 0;
            crvReport.Visible = false;

            visibleForm(false);
            enableSearchDetail(true);
        }

        private void visibleForm(bool visible)
        {
            gpbContractDetail.Visible = visible;
            gpbTISDetail.Visible = visible;
            gpbOtherDetail.Visible = visible;
        }

        /// <summary>
        /// Get ContractNo from DocumentNo 
        /// </summary>
        /// <returns>object contract</returns>
        private DocumentNo getContractNo()
        {
            contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;
        }

        /// <summary>
        /// set value to  customer combobox
        /// </summary>
        private void initComboCustomer()
        {
            cmbCustomerName.DataSource = facadeContract.DataSourceCustomerName;
        }

        /// <summary>
        /// Pop up Contract List by condition from first screen
        /// </summary>
        private void formContractList()
        {
            ContractType contractType = new ContractType();
            contractType.Code = ContractType.CONTRACT_TYPE_DRIVER;
            ContractStatus contractStatus = new ContractStatus();
            contractStatus.Code = ContractStatus.CONTRACT_STS_APPROVED;

            FrmContractDriverList dialogContractList = new FrmContractDriverList();

            if (cmbCustomerName.Text != "")
                dialogContractList.ConditionCustomer = (Customer)cmbCustomerName.SelectedItem;

            dialogContractList.ConditionCONTRACT_TYPE = contractType;
            dialogContractList.IsContractDriverList = true;
            dialogContractList.ConditionContractStatus = contractStatus;

            if (txtContractNoYY.Text != "")
                dialogContractList.ConditionYY = txtContractNoYY.Text;
            if (txtContractNoMM.Text != "")
                dialogContractList.ConditionMM = txtContractNoMM.Text;
            if (txtContractNoXXX.Text != "")
                dialogContractList.ConditionXXX = txtContractNoXXX.Text;
            dialogContractList.ShowDialog();
            if (dialogContractList.Selected)
                retriveContract(dialogContractList.SelectedContract);

            dialogContractList = null;
        }

        /// <summary>
        /// set value from object contract to screen
        /// </summary>
        /// <param name="contract"></param>
        private void retriveContract(ContractBase contract)
        {
            bindForm(contract);
            setForm(contract);
        }

        private void bindForm(ContractBase contract)
        {
            txtContractNoYY.Text = contract.ContractNo.Year;
            txtContractNoMM.Text = contract.ContractNo.Month;
            txtContractNoXXX.Text = contract.ContractNo.No;
            txtContractStartDate.Text = contract.APeriod.From.ToString("dd/MM/yyyy");
            txtContractEndDate.Text = contract.APeriod.To.Date.ToString("dd/MM/yyyy");
            txtContractType.Text = contract.AContractType.AName.English;
            txtContractsts.Text = contract.AContractStatus.AName.English;
            txtCustomerName.Text = contract.ACustomer.AName.English;
            driverContract = contract;
        }

        private void setForm(ContractBase contract)
        {
            btnPrint.Enabled = contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_APPROVED;
            gpbTISDetail.Enabled = contract.ACustomer.Code == Entity.Constants.CustomerCodeValue.TIS;

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

        private string getCustomerCodeForChargeRate(ContractBase value)
        {
            ChargeRateByServiceStaffType condition = new ChargeRateByServiceStaffType();
            condition.ServiceStaffType = ((ServiceStaffContract)value).ALatestServiceStaffRoleList[0].AServiceStaffType;
            condition.Customer = value.ACustomer;

            using (ContractAgreementFacade facade = new ContractAgreementFacade())
            {
                condition.DriverOnlyStatus = (facade.CheckDriverOnly(value) == -1);

                if (facade.FillChargeRateByServiceStaffType(condition))
                {
                    return value.ACustomer.Code;
                }
                else
                {
                    return Customer.DUMMYCODE;
                }
            }
        }

        private string getCustomerCodeForWorkingTimeCondition(ContractBase value)
        {
            WorkingTimeCondition condition = new WorkingTimeCondition();
            condition.APositionType = new ictus.PIS.PI.Entity.PositionType();
            condition.APositionType.Type = Entity.Constants.PositionTypeCodeValue.SERVICESTAFF;

            condition.ACustomerDepartment = new CustomerDepartment();
            condition.ACustomerDepartment.Code = Entity.Constants.CustomerDepartmentCodeValue.DUMMY;
            condition.ACustomerDepartment.ACustomer = value.ACustomer;

            condition.AServiceStaffType = ((ServiceStaffContract)value).ALatestServiceStaffRoleList[0].AServiceStaffType;

            using (ContractAgreementFacade facade = new ContractAgreementFacade())
            {
                if (facade.FillWorkingTimeCondition(condition))
                {
                    return value.ACustomer.Code;
                }
                else
                {
                    return Customer.DUMMYCODE;
                }
            }
        }

        #region Validate
        /// <summary>
        /// Check valid on Fill in Agreement Group box
        /// </summary>
        /// <returns> boolean </returns>
        private bool validatevalue()
        {
            if (cboFromDay.Text == string.Empty || cboToDay.Text == string.Empty)
            {
                Message(MessageList.Error.E0005, " Working Day");
                cboFromDay.Focus();
                return false;
            }
            return true;
        }

        private bool validatevalueForTis()
        {
            if (txtCommonDriver.Text == "0")
            {
                Message(MessageList.Error.E0002, "Common Driver");
                txtCommonDriver.Focus();
                return false;
            }
            if (numCommonRate.Value == 0)
            {
                Message(MessageList.Error.E0002, "Common Rate");
                numCommonRate.Focus();
                return false;
            }
            if (txtFamilyDriver.Text == "0")
            {
                Message(MessageList.Error.E0002, "Family Driver");
                txtFamilyDriver.Focus();
                return false;
            }
            if (numFamilyRate.Value == 0)
            {
                Message(MessageList.Error.E0002, "Family Rate");
                numFamilyRate.Focus();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Check input ContractNo before Pop up Contract List screen
        /// </summary>
        /// <returns> boolean </returns>
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
        /// <returns> boolean </returns>
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
        /// <returns> boolean </returns>
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
        /// <returns> boolean </returns>
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
        /// <returns> boolean </returns>
        private bool validateContractNo()
        {
            ContractBase tempContract = facadeContract.RetriveContract(getContractNo());

            if (tempContract == null)
            {
                Message(MessageList.Error.E0004, "เลขที่สัญญา");
                txtContractNoXXX.Focus();
                return false;
            }
            else
            {
                if (tempContract.AContractType.Code != ContractType.CONTRACT_TYPE_DRIVER)
                {
                    Message(MessageList.Error.E0004, "เลขที่สัญญา");
                    txtContractNoXXX.Focus();
                    return false;
                }
            }

            return true;
        } 
        #endregion
        #endregion

        #region -Public Method-
        /// <summary>
        /// Check input  must be numeric or backspace
        /// </summary>
        /// <param name="value"></param>
        /// <returns> boolean </returns>
        public bool IsNumericInt(char value)
        {
            switch (value)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                case '\b': return true;
            }
            return false;

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
            if (driverContract != null)
            {
                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;

                if (driverContract.ACustomer.Code == Entity.Constants.CustomerCodeValue.TIS)
                {
                    if (validatevalueForTis() && validatevalue())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        ReportTISDriverAgreement reportTISDriverAgreement = new ReportTISDriverAgreement();
                        reportTISDriverAgreement.SetCriteria(
                            getCustomerCodeForChargeRate(driverContract),
                            driverContract.ContractNo.ToString(),
                            txtCommonDriver.Text,
                            txtFamilyDriver.Text,
                            numCommonRate.Value,
                            numFamilyRate.Value,
                            cboFromDay.SelectedItem.ToString(),
                            cboToDay.SelectedItem.ToString(),
                            getCustomerCodeForWorkingTimeCondition(driverContract));

                        this.crvReport.ReportSource = reportTISDriverAgreement.Report;
                        this.Cursor = Cursors.Default;
                    }
                }                
                else
                {
                    if (validatevalue())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        ReportDriverAgreement reportDriverAgreement = new ReportDriverAgreement(driverContract.ACustomer.Code);
                        reportDriverAgreement.SetCriteria(
                            getCustomerCodeForChargeRate(driverContract),
                            driverContract.ContractNo.ToString(),
                            numCommonRate.Value,
                            cboFromDay.SelectedItem.ToString(),
                            cboToDay.SelectedItem.ToString(),
                            rtbRemark.Text,
                            getCustomerCodeForWorkingTimeCondition(driverContract));

                        this.crvReport.ReportSource = reportDriverAgreement.Report;
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region -Event-
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintForm();
        }

        private void FrmReportDriverAgreement_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formContractList();
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

        private void txtCommonDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsNumericInt(e.KeyChar))
            {
                Message(MessageList.Error.E0006, "");
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }   
        private void txtFamilyDriver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsNumericInt(e.KeyChar))
            {
                Message(MessageList.Error.E0006, "");
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }
        #endregion          
    }
}
