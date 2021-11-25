using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
    public partial class FrmVehicleAssignmentEntry : Presentation.CommonGUI.EntryFormBase
    {
        #region - Private -

        private bool isReadonly = true;
        private bool isTextChange = true;
        private FrmVehicleAssignment parentForm;
        private VehicleAssignment objVehicleAssignment;

        #endregion

        //		============================== Property ====================
        private Vehicle aAssignVehicle;
        public Vehicle AAssignVehicle
        {
            set
            {
                isTextChange = false;
                aAssignVehicle = value;
                txtAssignPlatePrefix.Text = value.PlatePrefix;
                fpiAssignRunningNo.Text = value.PlateRunningNo;
                txtBrandName.Text = value.AModel.ABrand.AName.English;
                isTextChange = true;
            }
        }

        private Vehicle aMainVehicle;
        public Vehicle AMainVehicle
        {
            set
            {
                isTextChange = false;
                aMainVehicle = value;
                txtMainPlatePrefix.Text = value.PlatePrefix;
                fpiMainRunningNo.Text = value.PlateRunningNo;
                isTextChange = true;
            }
        }

        //		============================== Constructor ==============================
        public FrmVehicleAssignmentEntry(FrmVehicleAssignment parentForm) : base()
        {
            InitializeComponent();
            this.parentForm = parentForm;

            try
            {
                cboAssignmentReason.DataSource = parentForm.FacadeVehicleAssignment.DataSourceAssignmentReason;
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
                Message(ex);
            }

            isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryVehicelAssignment");
        }

        //		============================== Private Method ==============================
        #region - Validate -
        private bool validateForm()
        {
            return validateInputDate() && validateMainVehiclePlate() && validateVehicle() && validateReason() && validateAvailableVehicle() && validateDupVehicle();
        }

        private bool validateInputDate()
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpFromDate.Focus();
                return false;
            }
            return true;
        }

        private bool validateAvailableVehicle()
        {
            if (parentForm.FacadeVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(getVehicleAssignment()))
            {
                Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าวได้");
                dtpFromDate.Focus();
                return false;
            }
            return true;
        }

        private bool validateMainVehiclePlate()
        {
            return this.validateMainVehiclePlate(true);
        }

        private bool validateMainVehiclePlate(bool isShowMessage)
        {
            if (txtMainPlatePrefix.Text == "")
            {
                if (isShowMessage)
                {
                    Message(MessageList.Error.E0002, "ทะเบียนรถ");
                    txtMainPlatePrefix.Focus();
                }
                return false;
            }
            else if (fpiMainRunningNo.Text == "")
            {
                if (isShowMessage)
                {
                    Message(MessageList.Error.E0002, "ทะเบียนรถ");
                    fpiMainRunningNo.Focus();
                }
                return false;
            }
            else
            { return true; }
        }

        private bool validateDupVehicle()
        {
            if (txtMainPlatePrefix.Text == txtAssignPlatePrefix.Text && fpiMainRunningNo.Text == fpiAssignRunningNo.Text)
            {
                Message(MessageList.Error.E0014, "แทนรถเลขทะเบียนเดียวกันได้");
                txtMainPlatePrefix.Focus();
                return false;
            }
            return true;
        }

        private bool validateVehicle()
        {
            Vehicle vehicle = parentForm.FacadeVehicleAssignment.GetVehicle(txtMainPlatePrefix.Text, fpiMainRunningNo.Text);
            if (vehicle == null)
            {
                Message(MessageList.Error.E0004, "ทะเบียนรถ");
                txtAssignPlatePrefix.Focus();
                vehicle = null;
                return false;
            }
            else
            {
                //TODO : Ya
                if (!parentForm.FacadeVehicleAssignment.ValidateMainAssignInPeriod(vehicle.VehicleNo, this.dtpFromDate.Value, this.dtpToDate.Value))
                {
                    Message(MessageList.Error.E0002, "ทะเบียนรถที่ถูกผูกกับสัญญาในช่วงระยะเวลาการจ่ายงาน");
                    txtMainPlatePrefix.Focus();
                    vehicle = null;
                    return false;
                }

                // BEGIN: Old Version
                //if (!parentForm.FacadeVehicleAssignment.RetriveVehicleIsAssign(vehicle.VehicleNo))
                //{
                //    Message(MessageList.Error.E0002, "ทะเบียนรถที่ถูกผูกกับสัญญา");
                //    txtMainPlatePrefix.Focus();
                //    vehicle = null;
                //    return false;
                //}
                // END: Old Version

                AMainVehicle = vehicle;
                vehicle = null;
                return true;
            }
        }

        private bool validateReason()
        {
            if (cboAssignmentReason.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "เหตุผลในการจ่ายงาน");
                cboAssignmentReason.Focus();
                return false;
            }
            return true;
        }

        private bool validatePeriodAssign(VehicleAssignment value)
        {
            VehicleAssignmentList listVehicleAssignment = null;
            VehicleAssignment vehicleAssignment = null;

            if (!value.APeriod.From.Equals(dtpFromDate.Value) || !value.APeriod.To.Equals(dtpToDate.Value))
            {
                listVehicleAssignment = new VehicleAssignmentList(parentForm.FacadeVehicleAssignment.GetCompany());
                vehicleAssignment = new VehicleAssignment();
                vehicleAssignment.AAssignedVehicle = value.AAssignedVehicle;

                if (parentForm.FacadeVehicleAssignment.FillVehicleSpareAssignmentList(ref listVehicleAssignment, vehicleAssignment))
                {
                    listVehicleAssignment.Remove(value);

                    for (int i = 0; i < listVehicleAssignment.Count; i++)
                    {
                        if ((listVehicleAssignment[i].APeriod.From <= dtpToDate.Value) & (listVehicleAssignment[i].APeriod.To >= dtpFromDate.Value))
                        {
                            Message(MessageList.Error.E0014, "จ่ายงานในช่วงเวลาดังกล่าวได้");
                            dtpFromDate.Focus();
                            listVehicleAssignment = null;
                            return false;
                        }
                    }
                }
                listVehicleAssignment = null;
                vehicleAssignment = null;
            }

            listVehicleAssignment = new VehicleAssignmentList(parentForm.FacadeVehicleAssignment.GetCompany());
            vehicleAssignment = new VehicleAssignment();
            vehicleAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;
            vehicleAssignment.AMainVehicle = value.AAssignedVehicle;
            vehicleAssignment.AContract = value.AContract;

            if (parentForm.FacadeVehicleAssignment.FillVehicleSpareAssignmentByRoleList(listVehicleAssignment, vehicleAssignment))
            {
                foreach (VehicleAssignment assignment in listVehicleAssignment)
                {
                    if (assignment.APeriod.To > dtpToDate.Value.Date)
                    {
                        Message(MessageList.Error.E0018, "วันที่สิ้นสุดจ่ายงาน", "วันที่สิ้นสุดที่รถ spare มาทำงานแทน");
                        dtpToDate.Focus();
                        return false;
                    }
                }
            }

            listVehicleAssignment = null;
            vehicleAssignment = null;


            //Validate period of assignment must less than or equal to contract to date. : woranai 2007/01/15
            if (dtpToDate.Value.Date > value.AContract.APeriod.To.Date)
            {
                Message(MessageList.Error.E0011, "วันที่สิ้นสุดจ่ายงาน", "วันที่สิ้นสุดสัญญา");
                dtpToDate.Focus();
                return false;
            }

            return true;
        }
        #endregion

        private VehicleAssignment getVehicleAssignment()
        {
            objVehicleAssignment = new VehicleAssignment();
            objVehicleAssignment.AAssignedVehicle = aAssignVehicle;
            objVehicleAssignment.APeriod.From = dtpFromDate.Value.Date;
            objVehicleAssignment.APeriod.To = dtpToDate.Value.Date;
            objVehicleAssignment.AMainVehicle = aMainVehicle;
            objVehicleAssignment.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;
            objVehicleAssignment.AHirer.Name = txtHirerName.Text;
            objVehicleAssignment.AAssignmentReason.Name = cboAssignmentReason.Text;

            //TODO: P'Ya
            VehicleAssignment conditionVehicleAssignment = this.GetVehicleAssignmentCondition(aMainVehicle.VehicleNo);
            VehicleAssignment vehicleAssignment = parentForm.FacadeVehicleAssignment.GetCurrentVehicleAssignment(conditionVehicleAssignment);

            //objVehicleAssignment.AContract = parentForm.FacadeVehicleAssignment.GetCurrentVehicleContract(aMainVehicle);
            if (vehicleAssignment != null)
            {
                objVehicleAssignment.AContract = vehicleAssignment.AContract;
            }


            return objVehicleAssignment;
        }

        private void setVehicleAssignment(VehicleAssignment value)
        {
            isTextChange = false;
            objVehicleAssignment = value;
            txtHirerName.Text = value.AHirer.Name;
            cboAssignmentReason.Text = value.AAssignmentReason.Name;
            dtpFromDate.Value = value.APeriod.From;
            dtpToDate.Value = value.APeriod.To;
            txtMainPlatePrefix.Text = value.AMainVehicle.PlatePrefix;
            fpiMainRunningNo.Text = value.AMainVehicle.PlateRunningNo;

            if (value.AContract != null)
            {
                txtContractNoYY.Text = value.AContract.ContractNo.Year;
                txtContractNoMM.Text = value.AContract.ContractNo.Month;
                txtContractNoXXX.Text = value.AContract.ContractNo.No;
                txtCutsName.Text = value.AContract.ACustomerDepartment.ACustomer.ShortName;
                txtDeptName.Text = value.AContract.ACustomerDepartment.ShortName;

                setDriverName(value.AContract.ContractNo, value.AMainVehicle.VehicleNo);
            }
            isTextChange = true;
        }

        private void formVehicleList()
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();

            dialogVehicleList.ConditionPlatePrefix = txtMainPlatePrefix.Text;
            dialogVehicleList.ConditionPlateRunningNo = fpiMainRunningNo.Text;
            dialogVehicleList.IsVehicleAssign = true;

            //TODO : Ya
            dialogVehicleList.ConditionStartDate = this.dtpFromDate.Value;
            dialogVehicleList.ConditionEndDate = this.dtpToDate.Value;

            dialogVehicleList.ShowDialog();

            if (dialogVehicleList.Selected)
            {
                AMainVehicle = dialogVehicleList.SelectedVehicle;
                setHiereName(aMainVehicle.VehicleNo);
            }
        }

        private void clearCombo()
        {
            if (cboAssignmentReason.Items.Count > 0)
            {
                cboAssignmentReason.SelectedIndex = -1;
                cboAssignmentReason.SelectedIndex = -1;
            }
        }

        private void clearForm()
        {
            txtMainPlatePrefix.Text = "";
            fpiMainRunningNo.Text = "";
            txtDriverNo.Text = "";
            txtDriverName.Text = "";
            txtHirerName.Text = "";
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txtCutsName.Text = "";
            txtDeptName.Text = "";
            clearCombo();

            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Focus();
        }

        private void enableKeyField(bool enable)
        {
            txtMainPlatePrefix.Enabled = enable;
            fpiMainRunningNo.Enabled = enable;
        }

        private void setHiereName(int vehicleNo)
        {
            VehicleAssignment conditionVehicleAssignment = this.GetVehicleAssignmentCondition(vehicleNo);
            VehicleAssignment vehicleAssignment = parentForm.FacadeVehicleAssignment.GetCurrentVehicleAssignment(conditionVehicleAssignment);

            if (vehicleAssignment != null)
            {
                if (vehicleAssignment.AHirer != null)
                {
                    txtHirerName.Text = vehicleAssignment.AHirer.Name;
                }
                if (vehicleAssignment.AContract != null)
                {
                    txtContractNoYY.Text = vehicleAssignment.AContract.ContractNo.Year;
                    txtContractNoMM.Text = vehicleAssignment.AContract.ContractNo.Month;
                    txtContractNoXXX.Text = vehicleAssignment.AContract.ContractNo.No;
                    txtCutsName.Text = vehicleAssignment.AContract.ACustomerDepartment.ACustomer.ShortName;
                    txtDeptName.Text = vehicleAssignment.AContract.ACustomerDepartment.ShortName;

                    setDriverName(vehicleAssignment.AContract.ContractNo, vehicleNo);
                }
            }
            else
            {
                Message(MessageList.Error.E0013, "ดึงข้อมูลรถ", "ระบุช่วงการจ่ายงานไม่อยู่ในช่วงที่รถที่ถูกแทนทำงาน");

                // clear old contract detail
                this.txtContractNoYY.Text = string.Empty;
                this.txtContractNoMM.Text = string.Empty;
                this.txtContractNoXXX.Text = string.Empty;
                this.txtCutsName.Text = string.Empty;
                this.txtDeptName.Text = string.Empty;
            }
        }

        private VehicleAssignment GetVehicleAssignmentCondition(int vehicleNo)
        {
            TimePeriod conditionPeriod = new TimePeriod();
            conditionPeriod.From = this.dtpFromDate.Value;
            conditionPeriod.To = this.dtpToDate.Value;

            Vehicle mainVehicle = new Vehicle();
            mainVehicle.VehicleNo = vehicleNo;

            VehicleAssignment conditionVehicleAssignment = new VehicleAssignment();
            conditionVehicleAssignment.AMainVehicle = mainVehicle;
            conditionVehicleAssignment.APeriod = conditionPeriod;

            return conditionVehicleAssignment;
        }
        private void setDriverName(DocumentNo contractNo, int vehicleNo)
        {
            Employee employee = parentForm.FacadeVehicleAssignment.GetDriver(contractNo, vehicleNo);

            if (employee != null && !employee.EmployeeNo.Equals(string.Empty))
            {
                txtDriverNo.Text = employee.EmployeeNo.ToString();
                txtDriverName.Text = employee.EmployeeName;
            }
            else 
            {
                txtDriverNo.Text = string.Empty;
                txtDriverName.Text = string.Empty;
            }
        }

        //		============================== Public Method ==============================
        public void InitAddAction(Vehicle value)
        {
            this.title = "ใบจ่ายงานรถ";
            baseADD();
            clearForm();
            AAssignVehicle = value;
            enableKeyField(true);
        }

        public void InitEditAction(VehicleAssignment aVehicleAssignment, Vehicle aVehicle)
        {
            this.title = "ใบจ่ายงานรถ";
            baseEDIT();
            clearForm();
            AAssignVehicle = aVehicle;
            setVehicleAssignment(aVehicleAssignment);
            enableKeyField(false);

            if (aVehicleAssignment.AssignmentRole.Equals(ASSIGNMENT_ROLE_TYPE.MAIN))
            {
                dtpFromDate.Enabled = false;
            }

            if (isReadonly)
            {
                cmdOK.Enabled = false;
            }
        }

        //		============================== Base event ==============================
        private void addEvent()
        {
            try
            {
                if (validateForm() && parentForm.AddRow(getVehicleAssignment()))
                {
                    this.Hide();
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        private void editEvent()
        {
            try
            {
                objVehicleAssignment.AHirer.Name = txtHirerName.Text;
                objVehicleAssignment.AAssignmentReason.Name = cboAssignmentReason.Text;

                if (validateReason() && validateInputDate() && validatePeriodAssign(objVehicleAssignment))
                {
                    VehicleAssignment newVehicleAssignment = new VehicleAssignment();
                    newVehicleAssignment.AMainVehicle = objVehicleAssignment.AMainVehicle;
                    newVehicleAssignment.AAssignedVehicle = objVehicleAssignment.AAssignedVehicle;
                    newVehicleAssignment.AssignmentRole = objVehicleAssignment.AssignmentRole;
                    newVehicleAssignment.AContract = objVehicleAssignment.AContract;
                    newVehicleAssignment.AHirer.Name = txtHirerName.Text;
                    newVehicleAssignment.AAssignmentReason.Name = cboAssignmentReason.Text;
                    newVehicleAssignment.APeriod.From = dtpFromDate.Value.Date;
                    newVehicleAssignment.APeriod.To = dtpToDate.Value.Date;

                    if (parentForm.UpdateRow(objVehicleAssignment, newVehicleAssignment))
                    {
                        this.Hide();
                    }
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }
        //============================== event ==============================
        private void frmVehicleAssignmentEntry_Load(object sender, System.EventArgs e)
        {
            if (action == ActionType.ADD)
            {
                clearCombo();
            }
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
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

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void fpiMainRunningNo_DoubleClick(object sender, System.EventArgs e)
        {
            formVehicleList();
        }

        private void txtMainPlatePrefix_TextChanged(object sender, System.EventArgs e)
        {
            if (txtMainPlatePrefix.Text.Length == txtMainPlatePrefix.MaxLength)
            {
                fpiMainRunningNo.Focus();
            }
        }

        private void fpiMainRunningNo_TextChanged(object sender, System.EventArgs e)
        {
            if (isTextChange)
            {
                if (fpiMainRunningNo.Text.Length == 4)
                {
                    if (validateMainVehiclePlate())
                    {
                        if (validateVehicle())
                        {
                            setHiereName(aMainVehicle.VehicleNo);
                        }
                    }
                }
            }
        }

        private void txtAssignPlatePrefix_TextChanged(object sender, System.EventArgs e)
        {
            lblPlatePrefix.Text = txtAssignPlatePrefix.Text;
        }

        private void fpiAssignRunningNo_TextChanged(object sender, System.EventArgs e)
        {
            lblPlateNo.Text = fpiAssignRunningNo.Text;
        }

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {
            if (validateMainVehiclePlate(false))
            {
                if (validateVehicle())
                {
                    setHiereName(aMainVehicle.VehicleNo);
                }
            }
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            if (validateMainVehiclePlate(false))
            {
                if (validateVehicle())
                {
                    setHiereName(aMainVehicle.VehicleNo);
                }
            }
        }
    }
}

