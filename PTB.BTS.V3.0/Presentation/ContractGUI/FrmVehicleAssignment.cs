using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Entity.ContractEntities;
using Facade.ContractFacade;
using Entity.VehicleEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using Presentation.VehicleGUI;
using Facade.CommonFacade;
using ictus.Common.Entity.Time;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.ContractGUI
{
    public partial class FrmVehicleAssignment : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private bool isSetText = true;
        private frmMain mdiParent;
        private FrmVehicleAssignmentEntry frmEntry;
        private VehicleAssignment objVehicleAssignment;

        private int SelectedRow
        {
            get { return dtgVehicleAssign.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgVehicleAssign[0, SelectedRow].Value.ToString(); }
        }

        private VehicleAssignment selectedVehicleAssignment
        {
            get { return facadeVehicleAssignment.ObjVehicleAssignmentList[SelectedKey]; }
        }

        private Vehicle getVehicle()
        {
            return facadeVehicleAssignment.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
        }
        #endregion

        //============================== Property ==============================
        private VehicleAssignmentFacade facadeVehicleAssignment;
        public VehicleAssignmentFacade FacadeVehicleAssignment
        {
            get { return facadeVehicleAssignment; }
        }

        private Vehicle aVehicle;
        private Vehicle AVehicle
        {
            set
            {
                isSetText = false;
                txtPlatePrefix.Text = value.PlatePrefix;
                fpiPlateRunningNo.Value = value.PlateRunningNo;
                txtBrandName.Text = value.AModel.ABrand.AName.English;
                txtColorName.Text = value.AColor.AName.English;
                txtModelName.Text = value.AModel.AName.English;
                txtModelTypeName.Text = value.AModel.AModelType.AName.Thai;
                fpiNoOfSeat.Value = value.AModel.NoOfSeat;
                fpiCC.Value = value.AModel.EngineCC;

                YearMonth yearMonth1 = facadeVehicleAssignment.CalculateAge(value.BuyDate);
                fpiAgeYear.Value = yearMonth1.Year;
                fpiAgeMonth.Value = yearMonth1.Month;

                YearMonth yearMonth2 = facadeVehicleAssignment.CalculateAge(value.RegisterDate);
                fpiAgeCarYear.Value = yearMonth2.Year;
                fpiAgeCarMonth.Value = yearMonth2.Month;

                ContractBase contractBase = facadeVehicleAssignment.GetCurrentVehicleContract(value);

                if (value.AKindOfVehicle.Code != "Z" && contractBase != null && contractBase.ContractNo != null)
                {
                    txtContractNoYY.Text = contractBase.ContractNo.Year;
                    txtContractNoMM.Text = contractBase.ContractNo.Month;
                    txtContractNoXXX.Text = contractBase.ContractNo.No;
                    txtCurrentCustomer.Text = contractBase.ACustomerDepartment.ACustomer.ShortName;
                    txtCurrentDep.Text = contractBase.ACustomerDepartment.ShortName;
                }

                aVehicle = value;
                isSetText = true;
            }
            get
            {
                return aVehicle;
            }
        }

        //============================== Constructor ==============================
        public FrmVehicleAssignment() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractAssignmentHistoryVehicelAssignment");
            this.title = UserProfile.GetFormName("miContract", "miContractAssignmentHistoryVehicelAssignment");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractAssignmentHistoryVehicelAssignment");
        }

        //==============================Private method ==============================
        #region - Enable & Disable Control -
        private void enableVehicle(bool enabled)
        {
            txtPlatePrefix.Enabled = enabled;
            fpiPlateRunningNo.Enabled = enabled;
        }

        private void clearVehicle()
        {
            txtBrandName.Text = "";
            txtColorName.Text = "";
            txtModelName.Text = "";
            txtModelTypeName.Text = "";
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txtCurrentCustomer.Text = "";
            txtCurrentDep.Text = "";

            fpiNoOfSeat.Value = 0;
            fpiCC.Value = 0;
            fpiAgeYear.Value = 0;
            fpiAgeMonth.Value = 0;
            fpiAgeCarYear.Value = 0;
            fpiAgeCarMonth.Value = 0;
        }

        private void visibleButton(bool visible)
        {
            cmdAdd.Visible = visible;
            cmdEdit.Visible = visible;
            cmdDelete.Visible = visible;
        }

        private void enableButton(bool enable)
        {
            mniUpdate.Enabled = enable;
            cmdEdit.Enabled = enable;
            mniDelete.Enabled = enable;
            cmdDelete.Enabled = enable;
        }

        private void clearForm()
        {
            dtgVehicleAssign.Rows.Clear();
            dtgVehicleAssign.Enabled = true;
            cmdAdd.Enabled = true;
            mniAdd.Enabled = true;
            enableButton(false);
        }

        private void clearAll()
        {
            clearVehicle();
            clearForm();
            dtgVehicleAssign.Visible = false;
            visibleButton(false);
            enableVehicle(true);
            txtPlatePrefix.Focus();
            dtgVehicleMain.Rows.Clear();
        }

        private void setForm()
        {
            dtgVehicleAssign.Rows.Clear();
            dtgVehicleAssign.Visible = true;
            enableVehicle(false);
        }

        #endregion - Enable & Disable Control -

        #region - Validate Checking -
        private bool validateVehiclePlate()
        {
            if (txtPlatePrefix.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                txtPlatePrefix.Focus();
                return false;
            }
            else if (fpiPlateRunningNo.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                fpiPlateRunningNo.Focus();
                return false;
            }
            else
            { return true; }
        }

        private bool validateAddEvent()
        {
            if (aVehicle.AVehicleStatus.Code != "1")
            {
                Message(MessageList.Error.E0013, "จ่ายงานให้รถคันนี้ได้", "รถไม่อยู่ในสถานะที่พร้อมจะจ่ายงาน");
                txtPlatePrefix.Focus();
                return false;
            }
            return true;
        }

        #endregion - Validate Checking -

        private VehicleAssignment getVehicleAssignment(Vehicle value)
        {
            objVehicleAssignment = new VehicleAssignment();
            objVehicleAssignment.AAssignedVehicle = value;
            return objVehicleAssignment;
        }

        private void newObject()
        {
            facadeVehicleAssignment = new VehicleAssignmentFacade();
            frmEntry = new FrmVehicleAssignmentEntry(this);
        }

        private void formVehicleList()
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
            dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
            dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
            dialogVehicleList.ShowDialog();

            if (dialogVehicleList.Selected)
            {
                AVehicle = dialogVehicleList.SelectedVehicle;
                RefreshForm();
            }
        }

        private void bindForm()
        {
            tabVehicleContract.Visible = true;

            if (facadeVehicleAssignment.ObjVehicleAssignmentList.Count > 0)
            {
                dtgVehicleAssign.Rows.Clear();
                enableButton(true);

                for (int i = 0; i < facadeVehicleAssignment.ObjVehicleAssignmentList.Count; i++)
                {
                    dtgVehicleAssign.RowCount++;
                    bindVehicleAssignment(i, facadeVehicleAssignment.ObjVehicleAssignmentList[i]);
                }
                SetLastRow();
            }
            else
            {
                dtgVehicleAssign.Rows.Clear();
                enableButton(false);
            }

            mdiParent.RefreshMasterCount();
        }

        private void bindVehicleAssignment(int row, VehicleAssignment value)
        {
            dtgVehicleAssign[0, row].Value = value.EntityKey;
            dtgVehicleAssign[1, row].Value = value.APeriod.From.Date;
            dtgVehicleAssign[2, row].Value = value.APeriod.To.Date;
            dtgVehicleAssign[3, row].Value = GUIFunction.GetString(value.AMainVehicle.PlateNumber);
            dtgVehicleAssign[4, row].Value = GUIFunction.GetString(value.AContract.ContractNo.ToString());
            dtgVehicleAssign[5, row].Value = GUIFunction.GetString(value.AContract.ACustomerDepartment.ACustomer.ShortName);
            dtgVehicleAssign[6, row].Value = GUIFunction.GetString(value.AContract.ACustomerDepartment.ShortName);
            dtgVehicleAssign[7, row].Value = GUIFunction.GetString(value.AHirer.Name);
            dtgVehicleAssign[8, row].Value = GUIFunction.GetString(value.AAssignmentReason.Name);
        }

        private void bindVehicleMain()
        {
            VehicleAssignmentList listVehicleMain = facadeVehicleAssignment.ObjVehicleMainList;
            VehicleAssignment vehicleAssign;

            dtgVehicleMain.Rows.Clear();
            int iRow = 0;

            for (int i = 0; i < listVehicleMain.Count; i++)
            {
                vehicleAssign = listVehicleMain[i];

                if (vehicleAssign.AAssignedVehicle.VehicleNo != vehicleAssign.AMainVehicle.VehicleNo)
                {
                    dtgVehicleMain.RowCount++;
                    dtgVehicleMain[0, iRow].Value = vehicleAssign.EntityKey;
                    dtgVehicleMain[1, iRow].Value = vehicleAssign.APeriod.From.Date;
                    dtgVehicleMain[2, iRow].Value = vehicleAssign.APeriod.To.Date;
                    dtgVehicleMain[3, iRow].Value = vehicleAssign.AAssignedVehicle.PlateNumber;
                    dtgVehicleMain[4, iRow].Value = vehicleAssign.AContract.ContractNo.ToString();
                    dtgVehicleMain[5, iRow].Value = vehicleAssign.AContract.ACustomerDepartment.ACustomer.ShortName;
                    dtgVehicleMain[6, iRow].Value = vehicleAssign.AContract.ACustomerDepartment.ShortName;
                    dtgVehicleMain[7, iRow].Value = vehicleAssign.AHirer.Name;
                    dtgVehicleMain[8, iRow].Value = vehicleAssign.AAssignmentReason.Name;
                    iRow++;
                }
            }
        }

        //============================== Public Method  ============================
        public bool AddRow(VehicleAssignment value)
        {
            if (facadeVehicleAssignment.InsertVehicleAssignment(value))
            {
                if (dtgVehicleAssign.RowCount == 0)
                {
                    dtgVehicleAssign.Visible = true;
                }

                dtgVehicleAssign.RowCount++;
                bindVehicleAssignment(dtgVehicleAssign.RowCount - 1, value);
                enableButton(true);
                mdiParent.RefreshMasterCount();
                SetLastRow();
                return true;
            }
            return false;
        }

        public bool UpdateRow(VehicleAssignment oldVehicleAssignment, VehicleAssignment newVehicleAssignment)
        {
            if (facadeVehicleAssignment.UpdateVehicleAssignment(oldVehicleAssignment, newVehicleAssignment))
            {
                bindVehicleAssignment(SelectedRow, newVehicleAssignment);
                return true;
            }
            return false;
        }

        private void deleteRow()
        {
            if (facadeVehicleAssignment.DeleteVehicleAssignment(selectedVehicleAssignment))
            {
                if (dtgVehicleAssign.RowCount > 1)
                {
                    dtgVehicleAssign.Rows.RemoveAt(SelectedRow);
                }
                else
                { clearForm(); }
                mdiParent.RefreshMasterCount();
            }
        }

        private void SetLastRow()
        {
            dtgVehicleAssign.CurrentCell = dtgVehicleAssign.Rows[dtgVehicleAssign.RowCount - 1].Cells[1];
        }

        public override int MasterCount()
        {
            return facadeVehicleAssignment.ObjVehicleAssignmentList.Count;
        }

        //============================== Base Event ==============================
        public void InitForm()
        {
            mdiParent.DisableCommand();
            clearMainMenuStatus();

            txtPlatePrefix.Text = "";
            fpiPlateRunningNo.Text = "";
            tabVehicleContract.Visible = false;
            newObject();
            clearAll();
            mdiParent.RefreshMasterCount();
        }

        public void RefreshForm()
        {
            try
            {
                if (aVehicle != null && validateVehiclePlate())
                {
                    visibleButton(true);
                    facadeVehicleAssignment.DisplayVehicleAssignment(getVehicleAssignment(aVehicle));
                    setForm();
                    bindForm();

                    if (facadeVehicleAssignment.DisplayVehicleMain(aVehicle.VehicleNo))
                    {
                        bindVehicleMain();
                        dtgVehicleMain.CurrentCell = dtgVehicleMain.Rows[dtgVehicleMain.RowCount - 1].Cells[1];
                    }
                    else
                    {
                        dtgVehicleMain.Rows.Clear();
                    }

                    MainMenuNewStatus = true;
                    MainMenuDeleteStatus = false;
                    MainMenuRefreshStatus = true;
                    MainMenuPrintStatus = false;

                    mdiParent.EnableNewCommand(true);
                    mdiParent.EnableDeleteCommand(false);
                    mdiParent.EnableRefreshCommand(true);
                    mdiParent.EnablePrintCommand(false);
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }

            if (isReadonly)
            {
                cmdAdd.Enabled = false;
                mniAdd.Enabled = false;
                cmdDelete.Enabled = false;
                mniDelete.Enabled = false;
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            Dispose(true);
        }

        private void addEvent()
        {
            try
            {
                if (validateAddEvent())
                {
                    frmEntry = new FrmVehicleAssignmentEntry(this);
                    frmEntry.InitAddAction(aVehicle);
                    frmEntry.ShowDialog();
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
                frmEntry = new FrmVehicleAssignmentEntry(this);
                frmEntry.InitEditAction(selectedVehicleAssignment, aVehicle);
                frmEntry.ShowDialog();
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    deleteRow();
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        //============================== Event ==============================
        private void FrmVehicleAssignment_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void mniAdd_Click(object sender, System.EventArgs e)
        {
            addEvent();
        }


        private void mniUpdate_Click(object sender, EventArgs e)
        {
            editEvent();
        }

        private void mniDelete_Click(object sender, System.EventArgs e)
        {
            deleteEvent();
        }

        private void cmdAdd_Click(object sender, System.EventArgs e)
        {
            addEvent();
        }

        private void cmdEdit_Click(object sender, System.EventArgs e)
        {
            editEvent();
        }

        private void cmdDelete_Click(object sender, System.EventArgs e)
        {
            deleteEvent();
        }


        private void dtgVehicleAssign_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                editEvent();
            }
        }

        private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
        {
            formVehicleList();
        }

        private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (validateVehiclePlate())
                {
                    Vehicle vehicle = getVehicle();
                    if (vehicle != null)
                    {
                        AVehicle = vehicle;
                        RefreshForm();
                    }
                    else
                    {
                        Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
                        txtPlatePrefix.Focus();
                        clearAll();
                    }
                    vehicle = null;
                }
            }
        }

        private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
        {
            lblPlateNo.Text = fpiPlateRunningNo.Text;
            if (isSetText)
            {
                lblPlateNo.Text = fpiPlateRunningNo.Text;
                if (fpiPlateRunningNo.Text.Length == 4)
                {
                    if (validateVehiclePlate())
                    {
                        Vehicle vehicle = getVehicle();
                        if (vehicle != null)
                        {
                            AVehicle = vehicle;
                            RefreshForm();
                        }
                        else
                        {
                            Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
                            txtPlatePrefix.Focus();
                            clearAll();
                        }
                        vehicle = null;
                    }
                }
            }
        }

        private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
        {
            lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
            {
                fpiPlateRunningNo.Focus();
            }
        }
    }
}