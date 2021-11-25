using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using PTB.BTS.ContractEntities.ContractChargeRate;
using ictus.Common.Entity;
using Entity.ContractEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using ictus.Common.Entity.Time;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmCustomerSpecialChargeConditionEntry : EntryFormBase
    {
        private bool isReadOnly = true;
        private bool isTextChange = true;
        private FrmCustomerSpecialChargeCondition parentForm;
        private ContractList listContract;
        private CustomerList listCustomer;
        private CustomerDepartmentList listCustDept;
        private Company company;

        //============================== Property ==============================
        private CustomerSpecialChargeCondition objSpecialCharge;
        public CustomerSpecialChargeCondition ObjSpecialCharge
        {
            set
            {
                isTextChange = false;
                objSpecialCharge = value;
                txtEmpNo.Tag = value.DriverStaff;
                lblEmpNo.Text = value.DriverStaff.EmployeeNo;
                lblEmpName.Text = value.DriverStaff.EmployeeName;
                lblPosition.Text = value.DriverStaff.APosition.AName.English;
                lblContract.Tag = value.Contract;
                lblContract.Text = value.Contract.ContractNo.ToString();
                lblCustomer.Text = value.Contract.ACustomer.ToString();
                fpdTelephone.Value = value.TelephoneAmount;
                fpdSpecial.Value = value.SpecialAmount;
                isTextChange = true;
                lblCustDept.Text = value.AssignDepartment.ShortName;
            }
            get
            {
                if (action == ActionType.ADD)
                {
                    objSpecialCharge = new CustomerSpecialChargeCondition();
                    objSpecialCharge.Contract = (ContractBase)cboContract.SelectedItem;
                    objSpecialCharge.DriverStaff = (ServiceStaff)txtEmpNo.Tag;
                    if ((CustomerDepartment)cboCustDept.SelectedItem == null)
                    {
                        objSpecialCharge.AssignDepartment = new CustomerDepartment();
                    }
                    else
                    {
                        objSpecialCharge.AssignDepartment = (CustomerDepartment)cboCustDept.SelectedItem;
                    }
                }

                objSpecialCharge.TelephoneAmount = Convert.ToDecimal(fpdTelephone.Value);
                objSpecialCharge.SpecialAmount = Convert.ToDecimal(fpdSpecial.Value);
                return objSpecialCharge;
            }
        }

        //============================== Constructor ==============================
        public FrmCustomerSpecialChargeConditionEntry(FrmCustomerSpecialChargeCondition frmParent)
            : base()
        {
            InitializeComponent();
            parentForm = frmParent;
            isReadOnly = UserProfile.IsReadOnly("miContract", "miContractDocumentSpecialCharge");
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentSpecialCharge");
        }

        //============================== Private Method ==============================
        private void clearForm()
        {
            isTextChange = false;
            txtEmpNo.Text = "";
            lblEmpName.Text = "";
            lblPosition.Text = "";
            cboContract.SelectedIndex = -1;
            cboCustomer.SelectedIndex = -1;
            fpdSpecial.MaxValue = 99999.99;
            fpdSpecial.MinValue = -99999.99;
            fpdTelephone.MaxValue = 9999.99;
            fpdTelephone.MinValue = -9999.99;
            fpdTelephone.Value = decimal.Zero;
            fpdSpecial.Value = decimal.Zero;            
            txtEmpNo.Enabled = true;
            enableCombo(false);
            enableDetail(false);
            visibleDetail(true);
            isTextChange = true;
        }

        private void enableCombo(bool enable)
        {
            cboContract.Enabled = enable;
            cboCustomer.Enabled = enable;
            cboCustDept.Enabled = enable;
            btnCharge.Enabled = enable;
        }

        private void enableDetail(bool enable)
        {
            gpbSpecialCharge.Enabled = enable;
            btnOK.Enabled = enable;
        }

        private void visibleDetail(bool visible)
        {
            txtEmpNo.Visible = visible;
            lblEmpNo.Visible = !visible;
            cboCustomer.Visible = visible;
            lblCustomer.Visible = !visible;
            cboContract.Visible = visible;
            lblContract.Visible = !visible;
            cboCustDept.Visible = visible;
            lblCustDept.Visible = !visible;
        }

        private bool validateForm()
        {
            if (Convert.ToDecimal(fpdTelephone.Value) == decimal.Zero & Convert.ToDecimal(fpdSpecial.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0002, "ข้อมูล");
                fpdTelephone.Focus();
                return false;
            }
            return true;
        }

        private bool validateCharge()
        {
            if (action == ActionType.ADD)
            {
                if (cboCustomer.Text == "")
                {
                    Message(MessageList.Error.E0005, "ลูกค้า");
                    cboCustomer.Focus();
                    return false;
                }
            }
            return true;
        }

        private void formSSList()
        {
            frmServiceStaffList dialogSSlist = new frmServiceStaffList();

            dialogSSlist.ShowDialog();
            if (dialogSSlist.Selected)
            {
                setServiceStaff(dialogSSlist.SelectedServiceStaff);
            }
        }

        private void setServiceStaff(ServiceStaff serviceStaff)
        {
            isTextChange = false;
            txtEmpNo.Tag = serviceStaff;
            txtEmpNo.Text = serviceStaff.EmployeeNo;
            lblEmpName.Text = serviceStaff.EmployeeName;
            lblPosition.Text = serviceStaff.APosition.AName.English;
            isTextChange = true;

            if (parentForm.FacadeSpecialCharge.FillServiceStaffAssignmentInPeriodList(serviceStaff, DateTime.Today))
            {
                enableCombo(true);
                listContract = new ContractList(company);
                listCustomer = new CustomerList(company);

                foreach (ServiceStaffAssignment assignment in parentForm.FacadeSpecialCharge.ObjSSAssignmentList)
                {
                    if (!listCustomer.Contain(assignment.AContract.ACustomer))
                    {
                        listCustomer.Add(assignment.AContract.ACustomer);
                    }
                    listContract.Add(assignment.AContract.ACustomer.ToString(), assignment.AContract);
                }

                cboCustomer.DataSource = listCustomer.GetArrayList();
                cboContract.DataSource = listContract.GetArrayList();
                cboContract.DisplayMember = "ContractNo";
            }
        }

        private void selectedContract(Customer customer)
        {
            cboContract.SelectedItem = listContract[customer.ToString()];
            if (customer.Code == Entity.Constants.CustomerCodeValue.TIS)
            {
                if (listCustDept == null)
                {
                    listCustDept = parentForm.FacadeSpecialCharge.GetCustomerDepartmentList(customer);
                }

                if (listCustDept != null && listCustDept.Count > 0)
                {
                    cboCustDept.Enabled = true;
                    cboCustDept.DataSource = listCustDept.GetArrayList();
                }
            }
            else
            {
                cboCustDept.DataSource = null;
                listCustDept = null;
                cboCustDept.Enabled = false;
            }
        }

        private void selectedCustomer(ContractBase contract)
        {
            cboCustomer.SelectedItem = contract.ACustomer;
        }

        private void inputCharge(ContractBase contract)
        {
            if (validateCharge())
            {
                txtEmpNo.Enabled = false;
                enableCombo(false);
                enableDetail(true);
                setFocus();

                /* Code     Customer
                 * 000023   MCT
                 * 000024   Thai-MC
                 * 000081   IVICT
                 */
                //fpdTelephone.Enabled = (contract.ACustomer.Code == "000024" || contract.ACustomer.Code == "000023" || contract.ACustomer.Code == "000081");
            }
        }

        private void setFocus()
        {
            fpdSpecial.Focus();
            fpdTelephone.Focus();
        }

        //============================== Public Method ==============================
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            visibleDetail(true);
            //Boom 05/01/2020
            //fpdTelephone.Enabled = false;
            //fpdSpecial.Enabled = false;
        }

        internal void InitEditAction(CustomerSpecialChargeCondition specialCharge)
        {
            baseEDIT();
            clearForm();
            txtEmpNo.Enabled = false;
            enableDetail(true);
            visibleDetail(false);
            inputCharge(specialCharge.Contract);
            ObjSpecialCharge = specialCharge;

            if (isReadOnly)
            {
                btnOK.Enabled = false;
            }
        }

        //============================== Base Event ==============================
        private void addEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.AddRow(ObjSpecialCharge))
                    {
                        this.Close();
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void editEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.UpdateRow(ObjSpecialCharge))
                    {
                        this.Close();
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }


        //============================== event ==============================
        private void FrmCustomerSpecialChargeConditionEntry_Load(object sender, EventArgs e)
        {
            if (company == null)
            {
                company = parentForm.FacadeSpecialCharge.GetCompany();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    addEvent();
                    break;
                case ActionType.EDIT:
                    editEvent();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            inputCharge((ContractBase)cboContract.SelectedItem); 
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                selectedContract((Customer)cboCustomer.SelectedItem);
        }

        private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                selectedCustomer((ContractBase)cboContract.SelectedItem);
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (isTextChange)
            {
                if (txtEmpNo.Text.Length == txtEmpNo.MaxLength)
                {
                    try
                    {
                        ServiceStaff serviceStaff = parentForm.FacadeSpecialCharge.GetServiceStaff(txtEmpNo.Text);
                        if (serviceStaff != null)
                        {
                            setServiceStaff(serviceStaff);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        Message(sqlex);
                    }
                    catch (AppExceptionBase ex)
                    {
                        Message(ex);
                        setSelected(txtEmpNo);
                        clearForm();
                    }
                    catch (Exception ex)
                    {
                        Message(ex);
                    }
                }
            }
        }

        private void txtEmpNo_DoubleClick(object sender, EventArgs e)
        {
            formSSList();
        }
    }
}