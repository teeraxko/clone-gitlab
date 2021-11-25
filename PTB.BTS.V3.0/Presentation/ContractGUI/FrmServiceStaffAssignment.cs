using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.ContractFacade;
using Entity.ContractEntities;
using SystemFramework.AppException;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using System.Data.SqlClient;
using Facade.CommonFacade;
using ictus.Common.Entity.Time;
using Entity.AttendanceEntities;
using Entity.CommonEntity;

namespace Presentation.ContractGUI
{
    public partial class FrmServiceStaffAssignment : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private bool isReadonly = true;
        private frmMain formMDIParent;
        private frmServiceStaffAssignmentEntry formEntry;
        private frmServiceStaffList formSSList;

        public ServiceStaffAssignmentFacade facadeServiceStaffAssignment;
        #endregion

        #region - Property -
        public ServiceStaff ServiceStaff
        {
            get
            {
                return facadeServiceStaffAssignment.AServiceStaffAssignmentList.AServiceStaff;
            }
            set
            {
                facadeServiceStaffAssignment.AServiceStaffAssignmentList.AServiceStaff = value;
            }
        }

        private int SelectedRow
        {
            get
            {
                return dtgSSAssignment.CurrentRow.Index;
            }
        }

        private string SelectedKey
        {
            get
            {
                return dtgSSAssignment[0, SelectedRow].Value.ToString();
            }
        }

        private ServiceStaffAssignment SelectedServiceStaffAssignment
        {
            get
            {
                return facadeServiceStaffAssignment.AServiceStaffAssignmentList[SelectedKey];
            }
        }
        #endregion

        #region Constructor
        public FrmServiceStaffAssignment()
            : base()
        {
            ExceptionInfo.ClassName = "frmServiceStaffAssignment";
            ExceptionInfo.FunctionName = "Constructor()";

            InitializeComponent();

            formEntry = new frmServiceStaffAssignmentEntry();
            formSSList = new frmServiceStaffList();

            facadeServiceStaffAssignment = new ServiceStaffAssignmentFacade();
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryServiceStaffAssignment");
            this.title = UserProfile.GetFormName("miContract", "miContractAssignmentHistoryServiceStaffAssignment");
        } 
        #endregion

        #region Private Method
        private void clearForm()
        {
            clearHeader();
            clearDetail();
            dtgMainAssign.RowCount = 0;
        }

        #region - Header -
        private void clearHeader()
        {
            txtEmpNo.Enabled = true;
            txtEmpName.Text = "";
            txtEmpSection.Text = "";
            txtEmpPosition.Text = "";
            txtPositionType.Text = "";
            txtServiceStaffType.Text = "";
            txtEmpAgeYY.Text = "0";
            txtEmpAgeMM.Text = "0";
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txbCustomer.Text = "";
            txbDepartment.Text = "";
            pctEmployee.Image = null;
        }

        private void bindServiceStaff(ServiceStaff value)
        {
            txtEmpNo.Tag = value;
            txtEmpNo.Enabled = false;
            txtEmpNo.Text = value.EmployeeNo;
            txtEmpName.Text = value.EmployeeName;
            txtEmpSection.Text = value.ASection.ToString();
            txtEmpPosition.Text = value.APosition.ToString();
            txtPositionType.Text = value.APosition.APositionType.ADescription.Thai;
            if (value.AServiceStaffType != null)
            {
                txtServiceStaffType.Text = value.AServiceStaffType.ADescription.English;
            }
            YearMonth age = facadeServiceStaffAssignment.CalculateAge(value.BirthDate);
            txtEmpAgeYY.Text = age.Year.ToString();
            txtEmpAgeMM.Text = age.Month.ToString();
            if (value.ACurrentContract != null)
            {
                txtContractNoYY.Text = value.ACurrentContract.ContractNo.Year;
                txtContractNoMM.Text = value.ACurrentContract.ContractNo.Month;
                txtContractNoXXX.Text = value.ACurrentContract.ContractNo.No;
                txbCustomer.Text = value.ACurrentContract.ACustomer.ShortName;
                txbDepartment.Text = value.ACurrentContract.ACustomerDepartment.ShortName;
            }

            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
                System.IO.FileInfo[] files = dirInfo.GetFiles(txtEmpNo.Text + ".*");
                if (files != null && files.Length == 1)
                {
                    //Old function use file always : woranai 2009/04/27
                    //pctEmployee.Image = System.Drawing.Image.FromFile(files[0].FullName);
                    pctEmployee.Load(files[0].FullName);
                }
                else
                {
                    pctEmployee.Image = null;
                }
                dirInfo = null;
                files = null;
            }
            catch
            {
                pctEmployee.Image = null;
            }
        }
        #endregion

        #region - Detail -
        private void clearDetail()
        {
            dtgSSAssignment.RowCount = 0;
            enableButton(false);
        }

        private void bindServiceStaffAssignment(int row, ServiceStaffAssignment value)
        {
            dtgSSAssignment[0, row].Value = value.EntityKey;
            dtgSSAssignment[1, row].Value = value.APeriod.From;
            dtgSSAssignment[2, row].Value = value.APeriod.To;
            dtgSSAssignment[3, row].Value = CTFunction.GetString(value.AssignmentRole);
            dtgSSAssignment[4, row].Value = value.AMainServiceStaff.EmployeeNo;
            dtgSSAssignment[5, row].Value = value.AMainServiceStaff.EmployeeName;
            dtgSSAssignment[6, row].Value = value.AContract.ContractNo.ToString();
            dtgSSAssignment[7, row].Value = value.AContract.ACustomer.ShortName;
            dtgSSAssignment[8, row].Value = value.AContract.ACustomerDepartment.ShortName;
            dtgSSAssignment[9, row].Value = value.AHirer.Name;
        }

        private void showDetail()
        {
            tabSSContract.Visible = true;
            dtgSSAssignment.RowCount = 0;

            for (int i = 0; i < facadeServiceStaffAssignment.AServiceStaffAssignmentList.Count; i++)
            {
                dtgSSAssignment.RowCount++;
                bindServiceStaffAssignment(i, facadeServiceStaffAssignment.AServiceStaffAssignmentList[i]);
            }
            enableButton(true);
            formMDIParent.RefreshMasterCount();
        }

        private void bindSSAssignmentMain()
        {
            ServiceStaffAssignmentList listSSAssign = facadeServiceStaffAssignment.ListSSAssignmentMain;
            ServiceStaffAssignment ssAssign;
            dtgMainAssign.RowCount = 0;
            int iRow = 0;

            for (int i = 0; i < listSSAssign.Count; i++)
            {
                ssAssign = listSSAssign[i];

                if (ssAssign.AAssignedServiceStaff.EmployeeNo != ssAssign.AMainServiceStaff.EmployeeNo)
                {
                    dtgMainAssign.RowCount++;
                    dtgMainAssign[0, iRow].Value = ssAssign.EntityKey;
                    dtgMainAssign[1, iRow].Value = ssAssign.APeriod.From;
                    dtgMainAssign[2, iRow].Value = ssAssign.APeriod.To;
                    dtgMainAssign[3, iRow].Value = CTFunction.GetString(ssAssign.AssignmentRole);
                    dtgMainAssign[4, iRow].Value = ssAssign.AAssignedServiceStaff.EmployeeNo;
                    dtgMainAssign[5, iRow].Value = ssAssign.AAssignedServiceStaff.EmployeeName;
                    dtgMainAssign[6, iRow].Value = ssAssign.AContract.ContractNo.ToString();
                    dtgMainAssign[7, iRow].Value = ssAssign.AContract.ACustomer.ShortName;
                    dtgMainAssign[8, iRow].Value = ssAssign.AContract.ACustomerDepartment.ShortName;
                    dtgMainAssign[9, iRow].Value = ssAssign.AHirer.Name;
                    iRow++;
                }
            }
        }
        #endregion

        #region - Command -
        private void visibleButton(bool visible)
        {
            btnAdd.Visible = visible;
            btnUpdate.Visible = visible;
            btnDelete.Visible = visible;
        }

        private void enableButton(bool enable)
        {
            mniUpdate.Enabled = enable;
            btnUpdate.Enabled = enable;
            mniDelete.Enabled = enable;
            btnDelete.Enabled = enable;
        }
        #endregion

        #region - Validate -
        private bool validateDelete()
        {
            ServiceStaffAssignment serviceStaffAssignment = SelectedServiceStaffAssignment;
            //					7.1
            if (serviceStaffAssignment.AAssignedServiceStaff.EmployeeNo == serviceStaffAssignment.AMainServiceStaff.EmployeeNo)
            {
                Message(MessageList.Error.E0013, "ลบรายการนี้ได้", "มีสัญญากำกับอยู่");
                serviceStaffAssignment = null;
                return false;
            }
            //					7.2
            else
            {
                ServiceStaffAssignmentList tempServiceStaffAssignmentList = new ServiceStaffAssignmentList(facadeServiceStaffAssignment.GetCompany());
                ServiceStaffAssignment condition = new ServiceStaffAssignment();
                condition.AMainServiceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                condition.AssignmentRole = ASSIGNMENT_ROLE_TYPE.SPARE;
                condition.AContract = serviceStaffAssignment.AContract;
                if (facadeServiceStaffAssignment.FillServiceStaffAssignmentList(ref tempServiceStaffAssignmentList, condition))
                {
                    Message(MessageList.Error.E0044);
                    tempServiceStaffAssignmentList = null;
                    condition = null;
                    return false;
                }
            }

            return true;
        }
        #endregion

        private void bindForm()
        {
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;
            MainMenuDeleteStatus = false;
            MainMenuPrintStatus = false;

            formMDIParent.EnableNewCommand(true);
            formMDIParent.EnableRefreshCommand(true);
            formMDIParent.EnableDeleteCommand(false);
            formMDIParent.EnablePrintCommand(false);

            tabSSContract.Visible = true;
            visibleButton(true);

            try
            {
                //Change for select staff by period : woranai 2008/11/06
                //ServiceStaff.ACurrentContract = (ServiceStaffContract)facadeServiceStaffAssignment.GetServiceStaffCurrentContract(ServiceStaff.EmployeeNo);
                if (ServiceStaff.ACurrentContract != null)
                {
                    ServiceStaff.ACurrentContract = (ServiceStaffContract)facadeServiceStaffAssignment.GetContract(ServiceStaff.ACurrentContract.ContractNo);
                }

                bindServiceStaff(ServiceStaff);
                if (facadeServiceStaffAssignment.DisplayServiceStaffAssignment())
                {
                    showDetail();
                    dtgSSAssignment.CurrentCell = dtgSSAssignment.Rows[dtgSSAssignment.RowCount - 1].Cells[1];
                }
                else
                {
                    clearDetail();
                }

                if (facadeServiceStaffAssignment.DisplaySSAssignmentMain(ServiceStaff.EmployeeNo))
                {
                    bindSSAssignmentMain();
                    dtgMainAssign.CurrentCell = dtgMainAssign.Rows[dtgMainAssign.RowCount - 1].Cells[1];
                }
                else
                {
                    dtgMainAssign.RowCount = 0;
                }
            }
            catch (SqlException ex)
            {
                Message(ex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
        }

        private void callList()
        {
            try
            {
                formSSList.ShowDialog();

                if (formSSList.Selected)
                {
                    //TODO : Ya

                    TimePeriod timePeriod = new TimePeriod();
                    timePeriod.From = DateTime.Today;
                    timePeriod.To = DateTime.Today;
                    ServiceStaff = facadeServiceStaffAssignment.GetServiceStaffMainByPeriod(formSSList.SelectedServiceStaff.EmployeeNo, timePeriod);

                    txtEmpNo.Text = ServiceStaff.EmployeeNo;
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
                Message(ex);
            }
            finally
            { }
        }

        private void getServiceStaff()
        {
            try
            {
                if (ServiceStaff == null || ServiceStaff.EmployeeNo != txtEmpNo.Text)
                {
                    //TODO : Ya

                    TimePeriod timePeriod = new TimePeriod();
                    timePeriod.From = DateTime.Today;
                    timePeriod.To = DateTime.Today;
                    ServiceStaff = facadeServiceStaffAssignment.GetServiceStaffMainByPeriod(this.txtEmpNo.Text, timePeriod);
                    if (ServiceStaff == null)
                    {
                        Message(MessageList.Error.E0004, "รหัสพนักงาน");
                        setSelected(txtEmpNo);
                        clearForm();
                    }
                    else
                    {
                        bindForm();
                    }
                }
                else
                {
                    bindForm();
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
                Message(ex);
            }
            finally
            { }

            if (isReadonly)
            {
                btnAdd.Enabled = false;
                mniAdd.Enabled = false;
                btnDelete.Enabled = false;
                mniDelete.Enabled = false;
            }
        }

        private void AddEvent()
        {
            try
            {
                formEntry.InitAddAction(this, ServiceStaff);
                formEntry.ShowDialog();
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
        }

        private void EditEvent()
        {
            try
            {
                formEntry.InitEditAction(this, SelectedServiceStaffAssignment);
                formEntry.ShowDialog();
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
        }

        private void DeleteEvent()
        {
            try
            {
                if (validateDelete())
                {
                    if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                    {
                        DeleteRow();
                    }
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
                Message(ex);
            }
        }
        #endregion

        #region Public Method
        public bool AddRow(ServiceStaffAssignment value)
        {
            if (facadeServiceStaffAssignment.InsertServiceStaffAssignment(value))
            {
                dtgSSAssignment.RowCount++;
                bindServiceStaffAssignment(dtgSSAssignment.RowCount - 1, value);
                enableButton(true);
                bindServiceStaff(value.AAssignedServiceStaff);
                formMDIParent.RefreshMasterCount();
                dtgSSAssignment.CurrentCell = dtgSSAssignment.Rows[dtgSSAssignment.RowCount - 1].Cells[1];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRow(ServiceStaffAssignment value, ServiceStaffAssignment condition)
        {
            if (facadeServiceStaffAssignment.UpdateServiceStaffAssignment(value, condition))
            {
                bindServiceStaffAssignment(SelectedRow, value);
                bindServiceStaff(value.AAssignedServiceStaff);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteRow()
        {
            ServiceStaffAssignment serviceStaffAssignment = SelectedServiceStaffAssignment;
            if (facadeServiceStaffAssignment.DeleteServiceStaffAssignment(serviceStaffAssignment))
            {
                facadeServiceStaffAssignment.AServiceStaffAssignmentList.AServiceStaff = serviceStaffAssignment.AAssignedServiceStaff;
                bindServiceStaff(serviceStaffAssignment.AAssignedServiceStaff);
                if (dtgSSAssignment.RowCount > 1)
                {
                    dtgSSAssignment.Rows.RemoveAt(SelectedRow);
                }
                else
                {
                    dtgSSAssignment.RowCount = 0;
                    enableButton(false);
                }
                formMDIParent.RefreshMasterCount();
            }
            serviceStaffAssignment = null;
        }

        public override int MasterCount()
        {
            return facadeServiceStaffAssignment.AServiceStaffAssignmentList.Count;
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractAssignmentHistoryServiceStaffAssignment");
        }

        public void InitForm()
        {
            formMDIParent.EnableNewCommand(false);
            formMDIParent.EnableRefreshCommand(false);

            clearForm();
            txtEmpNo.Text = "";

            tabSSContract.Visible = false;
            visibleButton(false);
            formMDIParent.ClearMasterCount();
        }

        public void RefreshForm()
        {
            getServiceStaff();
            formMDIParent.RefreshMasterCount();
        }

        public void PrintForm()
        { }

        public void ExitForm()
        {
            formEntry = null;
            facadeServiceStaffAssignment = null;

            this.Close();
        }
        #endregion

        #region Form Event
		private void FrmServiceStaffAssignment_Load(object sender, EventArgs e)
        {
            formMDIParent = (frmMain)this.MdiParent;
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Trim().Length == txtEmpNo.MaxLength)
            {
                getServiceStaff();
            }
        }

        private void txtEmpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEmpNo.Text.Trim() == "")
                {
                    Message(MessageList.Error.E0002, "รหัสพนักงาน");
                    setSelected(txtEmpNo);
                }
                else
                {
                    getServiceStaff();
                }
            }
        }

        private void txtEmpNo_DoubleClick(object sender, EventArgs e)
        {
            callList();
        }

        private void dtgSSAssignment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                EditEvent();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        } 
	#endregion
    }
}