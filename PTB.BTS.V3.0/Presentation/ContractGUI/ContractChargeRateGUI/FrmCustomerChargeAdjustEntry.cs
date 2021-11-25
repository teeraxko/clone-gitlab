using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Presentation.CommonGUI;
using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Facade.CommonFacade;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;
using System.Data.SqlClient;
using ictus.Common.Entity.Time;
using ictus.Common.Entity;
using Facade.ContractFacade.ContractChargeRateFacade;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmCustomerChargeAdjustEntry : EntryFormBase
    {
        private bool isReadOnly = true;
        private bool isDriver = true;
        private bool isTextChange = true;
        private FrmCustomerChargeAdjust parentForm;
        private ChargeRate chargeRate;
        private ContractList listContract;
        private CustomerList listCustomer;
        private CustomerDepartmentList listCustDept;
        private Company company;

        private decimal minOTAmount = decimal.Zero;

        //============================== Property ==============================
        private CustomerChargeAdjustment objCustomerChargeAdjustment;
        public CustomerChargeAdjustment ObjCustomerChargeAdjustment
        {
            set
            {
                isTextChange = false;

                objCustomerChargeAdjustment = value;
                lblDate.Text = value.ForYearMonth.DateTime.ToString("MM/yyyy");
                lblDate.Tag = value.ForYearMonth.DateTime;
                txtEmpNo.Tag = value.Employee;
                lblEmpNo.Text = value.Employee.EmployeeNo;
                lblEmpName.Text = value.Employee.EmployeeName;
                lblPosition.Text = value.Employee.APosition.AName.English;
                lblContract.Tag = value.Contract;
                lblContract.Text = value.Contract.ContractNo.ToString();
                lblCustomer.Text = value.Contract.ACustomer.ToString();
                lblCustDept.Text = value.AssignDepartment.ShortName;

                if (value.OTAHour >= 0)
                {
                    fpiOTHour_A.Value = Decimal.Floor(value.OTAHour);
                }
                else
                {
                    fpiOTHour_A.Value = Decimal.Ceiling(value.OTAHour);
                }

                if (value.OTBHour >= 0)
                {
                    fpiOTHour_B.Value = Decimal.Floor(value.OTBHour);
                }
                else
                {
                    fpiOTHour_B.Value = Decimal.Ceiling(value.OTBHour);
                }

                if (value.OTBHour >= 0)
                {
                    fpiOTHour_C.Value = Decimal.Floor(value.OTCHour);
                }
                else
                {
                    fpiOTHour_C.Value = Decimal.Ceiling(value.OTCHour);
                }

                fpiOTMin_A.Value = GUIFunction.ConverToMinute(value.OTAHour);
                fpiOTMin_B.Value = GUIFunction.ConverToMinute(value.OTBHour);
                fpiOTMin_C.Value = GUIFunction.ConverToMinute(value.OTCHour);
                fpdOTAAmount.Value = value.OTAAmount;
                fpdOTBAmount.Value = value.OTBAmount;
                fpdOTCAmount.Value = value.OTCAmount;
                fpiHoliday.Value = value.Holiday;
                fpiHolidayAmount.Value = value.HolidayAmount;
                fpiTaxiBenefit.Value = value.TaxiAmount;
                fpiTaxiTimes.Value = value.TaxiTimes;
                fpiOneDayTripFarBenefit.Value = value.OneDayTripFarAmount;
                fpiOneDayTripFarTimed.Value = value.OneDayTripFarTimes;
                fpiOneDayTripNearBenefit.Value = value.OneDayTripNearAmount;
                fpiOneDayTripNearTimes.Value = value.OneDayTripNearTimes;
                fpiOvernightTripBenefit.Value = value.OvernightTripAmount;
                fpiOvernightTripTimes.Value = value.OvernightTripTimes;
                fpdDeduct.Value = value.Deduct;
                fpdDeductAmount.Value = value.DeductAmount;
                fpdOtherAmount.Value = value.OtherAmount;
                txtReason.Text = value.Reason;
                isTextChange = true;
            }
            get
            {
                if (action == ActionType.ADD)
                {
                    objCustomerChargeAdjustment = new CustomerChargeAdjustment();
                    objCustomerChargeAdjustment.ForYearMonth = new YearMonth((DateTime)lblDate.Tag);
                    objCustomerChargeAdjustment.Employee = (Employee)txtEmpNo.Tag;
                    objCustomerChargeAdjustment.Contract = (ContractBase)cboContract.SelectedItem;
                    if ((CustomerDepartment)cboCustDept.SelectedItem == null)
                    {
                        objCustomerChargeAdjustment.AssignDepartment = new CustomerDepartment();
                    }
                    else
                    {
                        objCustomerChargeAdjustment.AssignDepartment = (CustomerDepartment)cboCustDept.SelectedItem;
                    }
                }           

                objCustomerChargeAdjustment.OTAHour = convertToDecimal(Convert.ToInt32(fpiOTHour_A.Value), Convert.ToInt32(fpiOTMin_A.Value));
                objCustomerChargeAdjustment.OTBHour = convertToDecimal(Convert.ToInt32(fpiOTHour_B.Value), Convert.ToInt32(fpiOTMin_B.Value));
                objCustomerChargeAdjustment.OTCHour = convertToDecimal(Convert.ToInt32(fpiOTHour_C.Value), Convert.ToInt32(fpiOTMin_C.Value));
                objCustomerChargeAdjustment.OTAAmount = Convert.ToDecimal(fpdOTAAmount.Value);
                objCustomerChargeAdjustment.OTBAmount = Convert.ToDecimal(fpdOTBAmount.Value);
                objCustomerChargeAdjustment.OTCAmount = Convert.ToDecimal(fpdOTCAmount.Value);
                objCustomerChargeAdjustment.HolidayAmount = Convert.ToDecimal(fpiHolidayAmount.Value);
                objCustomerChargeAdjustment.Holiday = Convert.ToInt16(fpiHoliday.Value);
                objCustomerChargeAdjustment.TaxiAmount = Convert.ToDecimal(fpiTaxiBenefit.Value);
                objCustomerChargeAdjustment.TaxiTimes = Convert.ToInt16(fpiTaxiTimes.Value);
                objCustomerChargeAdjustment.OneDayTripFarAmount = Convert.ToDecimal(fpiOneDayTripFarBenefit.Value);
                objCustomerChargeAdjustment.OneDayTripFarTimes = Convert.ToInt16(fpiOneDayTripFarTimed.Value);
                objCustomerChargeAdjustment.OneDayTripNearAmount = Convert.ToDecimal(fpiOneDayTripNearBenefit.Value);
                objCustomerChargeAdjustment.OneDayTripNearTimes = Convert.ToInt16(fpiOneDayTripNearTimes.Value);
                objCustomerChargeAdjustment.OvernightTripAmount = Convert.ToDecimal(fpiOvernightTripBenefit.Value);
                objCustomerChargeAdjustment.OvernightTripTimes = Convert.ToInt16(fpiOvernightTripTimes.Value);
                objCustomerChargeAdjustment.DeductAmount = Convert.ToDecimal(fpdDeductAmount.Value);
                objCustomerChargeAdjustment.Deduct = Convert.ToDecimal(fpdDeduct.Value);
                objCustomerChargeAdjustment.OtherAmount = Convert.ToDecimal(fpdOtherAmount.Value);
                objCustomerChargeAdjustment.Reason = txtReason.Text;
                return objCustomerChargeAdjustment;
            }
        }

        //============================== Constructor ==============================
        public FrmCustomerChargeAdjustEntry(FrmCustomerChargeAdjust value, bool forDriver)
            : base()
        {
            InitializeComponent();
            chargeRate = new ChargeRate();

            parentForm = value;

            isDriver = forDriver;

            if (isDriver)
            {
                isReadOnly = UserProfile.IsReadOnly("miContract", "miContractSettingCustomerChargeAdjustDriver");
                this.title = UserProfile.GetFormName("miContract", "miContractSettingCustomerChargeAdjustDriver");
            }
            else
            {
                isReadOnly = UserProfile.IsReadOnly("miContract", "miContractSettingCustomerChargeAdjustOtherSS");
                this.title = UserProfile.GetFormName("miContract", "miContractSettingCustomerChargeAdjustOtherSS");
            }
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
            cboCustDept.SelectedIndex = -1;
            fpiOTHour_A.Value = 0;
            fpiOTHour_B.Value = 0;
            fpiOTHour_C.Value = 0;
            fpiOTMin_A.Value = 0;
            fpiOTMin_B.Value = 0;
            fpiOTMin_C.Value = 0;
            fpiHoliday.Value = 0;
            fpiHolidayAmount.Value = 0;
            fpiTaxiBenefit.Value = 0;
            fpiTaxiTimes.Value = 0;
            fpiOneDayTripFarBenefit.Value = 0;
            fpiOneDayTripFarTimed.Value = 0;
            fpiOneDayTripNearBenefit.Value = 0;
            fpiOneDayTripNearTimes.Value = 0;
            fpiOvernightTripBenefit.Value = 0;
            fpiOvernightTripTimes.Value = 0;
            fpdDeduct.Value = 0;
            fpdDeductAmount.Value = 0;
            fpdOtherAmount.Value = 0;
            fpdOtherAmount.MaxValue = 999999.99;
            fpdOtherAmount.MinValue = -999999.99;
            fpdOTAAmount.MaxValue = 99999.99;
            fpdOTAAmount.MinValue = -99999.99;
            fpdOTBAmount.MaxValue = 99999.99;
            fpdOTBAmount.MinValue = -99999.99;
            fpdOTCAmount.MaxValue = 99999.99;
            fpdOTCAmount.MinValue = -99999.99;
            fpdDeduct.MaxValue = 99.9;
            fpdDeduct.MinValue = -99.9;
            fpdDeductAmount.MaxValue = 99999.99;
            fpdDeductAmount.MinValue = -99999.99;
            txtReason.Text = "";
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
            gpbDetail.Enabled = enable;
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

        private void setFocus()
        {
            fpiOTHour_A.Focus();
            fpiOTHour_B.Focus();
            fpiOTHour_C.Focus();
            fpiOTMin_A.Focus();
            fpiOTMin_B.Focus();
            fpiOTMin_C.Focus();
            fpiHoliday.Focus();
            fpiHolidayAmount.Focus();
            fpiTaxiBenefit.Focus();
            fpiTaxiTimes.Focus();
            fpiOneDayTripFarBenefit.Focus();
            fpiOneDayTripFarTimed.Focus();
            fpiOneDayTripNearBenefit.Focus();
            fpiOneDayTripNearTimes.Focus();
            fpiOvernightTripBenefit.Focus();
            fpiOvernightTripTimes.Focus();
            fpdDeduct.Focus();
            fpdDeductAmount.Focus();
            fpdOtherAmount.Focus();
        }

        private bool validateForm()
        {
            if (
                Convert.ToInt32(fpiOTHour_A.Value) == 0 &
                Convert.ToInt32(fpiOTHour_B.Value) == 0 &
                Convert.ToInt32(fpiOTHour_C.Value) == 0 &
                Convert.ToInt32(fpiOTMin_A.Value) == 0 &
                Convert.ToInt32(fpiOTMin_B.Value) == 0 &
                Convert.ToInt32(fpiOTMin_C.Value) == 0 &
                Convert.ToInt32(fpiOneDayTripFarBenefit.Value) == 0 &
                Convert.ToInt32(fpiOneDayTripFarTimed.Value) == 0 &
                Convert.ToInt32(fpiOneDayTripNearBenefit.Value) == 0 &
                Convert.ToInt32(fpiOneDayTripNearTimes.Value) == 0 &
                Convert.ToInt32(fpiOvernightTripBenefit.Value) == 0 &
                Convert.ToInt32(fpiOvernightTripTimes.Value) == 0 &
                Convert.ToInt32(fpiTaxiBenefit.Value) == 0 &
                Convert.ToInt32(fpiTaxiTimes.Value) == 0 &
                Convert.ToInt32(fpdDeduct.Value) == 0 &
                Convert.ToInt32(fpdDeductAmount.Value) == 0 &
                Convert.ToInt32(fpiHoliday.Value) == 0 &
                Convert.ToInt32(fpiHolidayAmount.Value) == 0 &
                Convert.ToDecimal(fpdOtherAmount.Value) == decimal.Zero
                )
            {
                Message(MessageList.Error.E0002, "ข้อมูล");
                fpiOTHour_A.Focus();
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

                if (cboCustDept.Items.Count > 0 && cboCustDept.Text == string.Empty)
                {
                    Message(MessageList.Error.E0005, "ฝ่ายลูกค้า");
                    cboCustomer.Focus();
                    return false;
                }

                ContractBase contract = (ContractBase)cboContract.SelectedItem;
                foreach (CustomerChargeAdjustment charge in parentForm.FacadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList)
                {
                    if (charge.Employee.EmployeeNo == txtEmpNo.Text &&
                        charge.Contract.ACustomer.Code == contract.ACustomer.Code &&
                        charge.Contract.ContractNo.ToString() == contract.ContractNo.ToString())
                    {
                        if (charge.AssignDepartment != null && cboCustDept.SelectedItem != null &&
                            charge.AssignDepartment.Code != ((CustomerDepartment)cboCustDept.SelectedItem).Code)
                        {
                            continue;
                        }
                        else
                        {
                            Message(MessageList.Error.E0013, "บันทึกรายการนี้ได้", "มีการ charge ลูกค้าในช่วงเวลานี้แล้ว");
                            cboCustomer.Focus();
                        }
                        return false;                            
                    }                    
                }
            }
            return true;
        }

        private decimal convertToDecimal(int hour, int minute)
        {
            if (hour < 0 & minute < 0)
            {
                return decimal.Parse(hour.ToString() + "." + Decimal.Negate(minute).ToString());
            }
            else if (hour >= 0 & minute < 0)
            {
                return Decimal.Negate(decimal.Parse(hour.ToString() + "." + Decimal.Negate(minute).ToString()));
            }
            return GUIFunction.ConverToDecimal(hour, minute);
        }

        private void formSSList()
        {
            frmServiceStaffList dialogSSlist = new frmServiceStaffList();
            if (isDriver)
            {
                dialogSSlist.IsMachanicDriver = true;
            }
            else
            {
                dialogSSlist.IsNotDriver = true;
            }

            dialogSSlist.ShowDialog();
            if (dialogSSlist.Selected)
            {
                setServiceStaff(dialogSSlist.SelectedServiceStaff);
            }
        }

        private void setServiceStaff(ServiceStaff serviceStaff)
        {
            bool result = false;
            DateTime adjustDate = (DateTime)lblDate.Tag;

            if (isDriver)
            {
                adjustDate = adjustDate.AddMonths(-1);
                result = (serviceStaff.APosition.PositionCode == "28" || serviceStaff.APosition.APositionRole == POSITION_ROLE_TYPE.MACHANIC);
            }
            else
            {
                result = (serviceStaff.APosition.PositionCode != "28" & serviceStaff.APosition.APositionRole != POSITION_ROLE_TYPE.MACHANIC);
            }

            if (result)
            {
                isTextChange = false;
                txtEmpNo.Tag = serviceStaff;
                txtEmpNo.Text = serviceStaff.EmployeeNo;
                lblEmpName.Text = serviceStaff.EmployeeName;
                lblPosition.Text = serviceStaff.APosition.AName.English;
                isTextChange = true;

                if (parentForm.FacadeCustomerChargeAdjustment.FillServiceStaffAssignmentInPeriodList(serviceStaff, new YearMonth(adjustDate)))
                {
                    enableCombo(true);
                    listContract = new ContractList(company);
                    listCustomer = new CustomerList(company);

                    foreach (ServiceStaffAssignment assignment in parentForm.FacadeCustomerChargeAdjustment.ObjSSAssignmentList)
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
            else
            {
                Message(MessageList.Error.E0004, "พนักงาน กรุณากรอกรหัสพนักงานให้ถูกต้อง");
                txtEmpNo.Focus();
                clearForm();
            }
        }

        private void selectedContract(Customer customer)
        {
            cboContract.SelectedItem = listContract[customer.ToString()];

            if (isDriver && customer.Code == Entity.Constants.CustomerCodeValue.TIS)
            {
                if (listCustDept == null)
                {
                    listCustDept = parentForm.FacadeCustomerChargeAdjustment.GetCustomerDepartmentList(customer);
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
                ChargeRate rate = parentForm.FacadeCustomerChargeAdjustment.GetCustomerChargeRate(contract);
                minOTAmount = parentForm.FacadeCustomerChargeAdjustment.GetCustomerMinOTAmount(contract);

                if (rate != null && minOTAmount != decimal.Zero)
                {
                    chargeRate = rate;
                    txtEmpNo.Enabled = false;
                    enableCombo(false);
                    enableDetail(true);
                    setFocus();
                }

                rate = null;
            }
        }

        private decimal halfRound(decimal value)
        {
            return parentForm.FacadeCustomerChargeAdjustment.HalfRound(value);
        }

        //============================== Public Method ==============================
        internal void InitAddAction(DateTime date)
        {
            baseADD();
            clearForm();
            visibleDetail(true);
            lblDate.Tag = date;
            lblDate.Text = date.ToString("MM/yyyy");
        }

        internal void InitEditAction(CustomerChargeAdjustment selectedCustomerChargeAdjustment)
        {
            baseEDIT();
            clearForm();
            txtEmpNo.Enabled = false;
            enableDetail(true);
            visibleDetail(false);
            inputCharge(selectedCustomerChargeAdjustment.Contract);
            ObjCustomerChargeAdjustment = selectedCustomerChargeAdjustment;

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
                    if (parentForm.AddRow(ObjCustomerChargeAdjustment))
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
                    if (parentForm.UpdateRow(ObjCustomerChargeAdjustment))
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
        private void FrmCustomerChargeAdjustEntry_Load(object sender, EventArgs e)
        {
            if (company == null)
            {
                company = parentForm.FacadeCustomerChargeAdjustment.GetCompany();
            }

            fpiHoliday.Enabled = isDriver;
            fpiHolidayAmount.Enabled = isDriver;
            fpiOneDayTripNearTimes.Enabled = isDriver;
            fpiOneDayTripNearBenefit.Enabled = isDriver;
            fpdOtherAmount.Enabled = !isDriver;            
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (isTextChange)
            {
                if (txtEmpNo.Text.Length == txtEmpNo.MaxLength)
                {
                    try
                    {
                        ServiceStaff serviceStaff = parentForm.FacadeCustomerChargeAdjustment.GetServiceStaff(txtEmpNo.Text);
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

        private void fpiTaxiTimes_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpiTaxiBenefit.Value = Convert.ToInt16(fpiTaxiTimes.Value) * chargeRate.TaxiRate;
        }

        private void fpiOneDayTripNearTimes_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpiOneDayTripNearBenefit.Value = Convert.ToInt16(fpiOneDayTripNearTimes.Value) * chargeRate.OneDayTripRateNear;
        }

        private void fpiOneDayTripFarTimed_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpiOneDayTripFarBenefit.Value = Convert.ToInt16(fpiOneDayTripFarTimed.Value) * chargeRate.OneDayTripRateFar;
        }

        private void fpiOvernightTripTimes_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpiOvernightTripBenefit.Value = Convert.ToInt16(fpiOvernightTripTimes.Value) * chargeRate.OvernightTripRate;
        }

        private void fpiHoliday_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpiHolidayAmount.Value = Convert.ToInt16(fpiHoliday.Value) * minOTAmount;
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            inputCharge((ContractBase)cboContract.SelectedItem);            
        }

        private void fpiOTHour_A_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTAAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_A.Value), Convert.ToInt32(fpiOTMin_A.Value))) * chargeRate.OTARate;
        }

        private void fpiOTMin_A_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTAAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_A.Value), Convert.ToInt32(fpiOTMin_A.Value))) * chargeRate.OTARate;
        }

        private void fpiOTHour_B_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTBAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_B.Value), Convert.ToInt32(fpiOTMin_B.Value))) * chargeRate.OTBRate;
        }

        private void fpiOTMin_B_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTBAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_B.Value), Convert.ToInt32(fpiOTMin_B.Value))) * chargeRate.OTBRate;
        }

        private void fpiOTHour_C_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTCAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_C.Value), Convert.ToInt32(fpiOTMin_C.Value))) * chargeRate.OTCRate;
        }

        private void fpiOTMin_C_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdOTCAmount.Value = halfRound(convertToDecimal(Convert.ToInt32(fpiOTHour_C.Value), Convert.ToInt32(fpiOTMin_C.Value))) * chargeRate.OTCRate;
        }

        private void fpdDeduct_ValueChanged(object sender, EventArgs e)
        {
            if (isTextChange)
                fpdDeductAmount.Value = Convert.ToDecimal(fpdDeduct.Value) * chargeRate.AbsenceDeduction;
        }
    }
}