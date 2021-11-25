using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using Facade.ContractFacade.ContractChargeRateFacade;

using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using Presentation.PiGUI;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.CommonEntity;

using SystemFramework.AppException;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using ictus.Common.Entity.Time;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmCustomerChargeAdjust : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isDriver = true;
        private bool isReadonly = true;

        private frmMain mdiParent;
        private FrmCustomerChargeAdjustEntry frmEntry;
        #endregion -Private -

        #region - Property -
        private CustomerChargeAdjustmentFacade facadeCustomerChargeAdjustment;
        public CustomerChargeAdjustmentFacade FacadeCustomerChargeAdjustment
        {
            get { return facadeCustomerChargeAdjustment; }
        }

        private int SelectedRow
        {
            get { return dtgCustomerAdjust.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgCustomerAdjust[0, SelectedRow].Value.ToString(); }
        }

        public CustomerChargeAdjustment selectedCustomerChargeAdjustment
        {
            get { return (CustomerChargeAdjustment)facadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmCustomerChargeAdjust(bool forDriver)
            : base()
        {
            InitializeComponent();
            isDriver = forDriver;

            if (isDriver)
            {
                isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingCustomerChargeAdjustDriver");
                this.title = UserProfile.GetFormName("miContract", "miContractSettingCustomerChargeAdjustDriver");
            }
            else
            {
                isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingCustomerChargeAdjustOtherSS");
                this.title = UserProfile.GetFormName("miContract", "miContractSettingCustomerChargeAdjustOtherSS");
            }
        }

        public override string FormID()
        {
            if (isDriver)
            {
                return UserProfile.GetFormID("miContract", "miContractSettingCustomerChargeAdjustDriver");
            }
            else
            {
                return UserProfile.GetFormID("miContract", "miContractSettingCustomerChargeAdjustOtherSS");
            }
        }

        public override int MasterCount()
        {
            return facadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList.Count;
        }

        //=============================== Private Method ================================	
        private void visibleForm(bool value)
        {
            dtgCustomerAdjust.Visible = value;
            btnUpdate.Visible = value;
            btnDelete.Visible = value;
            btnAdd.Visible = value;
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            dtgCustomerAdjust.RowCount = 0;
            gpbData.Enabled = true;
            enableAmend(false);
            visibleForm(false);
        }

        private void bindCustomerChargeAdjustment(int row, CustomerChargeAdjustment value)
        {
            dtgCustomerAdjust[0, row].Value = value.EntityKey.ToString();
            dtgCustomerAdjust[1, row].Value = value.Employee.EmployeeIDName;

            //For multiple department assignment
            if (value.AssignDepartment != null && value.AssignDepartment.ShortName != string.Empty)
            {
                dtgCustomerAdjust[2, row].Value = string.Concat(value.Contract.ACustomer.ShortName, " (", value.AssignDepartment.ShortName, ")");
            }
            else
            {
                dtgCustomerAdjust[2, row].Value = value.Contract.ACustomer.ShortName;            
            }

            dtgCustomerAdjust[3, row].Value = value.OTAHour;
            dtgCustomerAdjust[4, row].Value = value.OTAAmount;
            dtgCustomerAdjust[5, row].Value = value.OTBHour;
            dtgCustomerAdjust[6, row].Value = value.OTBAmount;
            dtgCustomerAdjust[7, row].Value = value.OTCHour;
            dtgCustomerAdjust[8, row].Value = value.OTCAmount;
            dtgCustomerAdjust[9, row].Value = value.Holiday;
            dtgCustomerAdjust[10, row].Value = value.HolidayAmount;
            dtgCustomerAdjust[11, row].Value = value.TaxiTimes;
            dtgCustomerAdjust[12, row].Value = value.TaxiAmount;
            dtgCustomerAdjust[13, row].Value = value.OneDayTripFarTimes;
            dtgCustomerAdjust[14, row].Value = value.OneDayTripFarAmount;
            dtgCustomerAdjust[15, row].Value = value.OneDayTripNearTimes;
            dtgCustomerAdjust[16, row].Value = value.OneDayTripNearAmount;
            dtgCustomerAdjust[17, row].Value = value.OvernightTripTimes;
            dtgCustomerAdjust[18, row].Value = value.OvernightTripAmount;
            dtgCustomerAdjust[19, row].Value = value.Deduct;
            dtgCustomerAdjust[20, row].Value = value.DeductAmount;
            dtgCustomerAdjust[21, row].Value = value.OtherAmount;
            dtgCustomerAdjust[22, row].Value = value.Reason;
        }

        private void bindForm()
        {
            dtgCustomerAdjust.RowCount = 0;

            if (facadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList.Count > 0)
            {
                for (int i = 0; i < facadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList.Count; i++)
                {
                    dtgCustomerAdjust.RowCount++;
                    bindCustomerChargeAdjustment(i, facadeCustomerChargeAdjustment.ObjCustomerChargeAdjustmentList[i]);
                }
            }
        }

        //==========================Public Method========================
        public bool AddRow(CustomerChargeAdjustment value)
        {
            if (facadeCustomerChargeAdjustment.InsertCustomerChargeAdjustment(value))
            {
                dtgCustomerAdjust.RowCount++;
                bindCustomerChargeAdjustment(dtgCustomerAdjust.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(CustomerChargeAdjustment value)
        {
            if (facadeCustomerChargeAdjustment.UpdateCustomerChargeAdjustment(value))
            {
                bindCustomerChargeAdjustment(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmCustomerChargeAdjustEntry(this, isDriver);
                frmEntry.InitAddAction(dtpDate.Value);
                frmEntry.ShowDialog();
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

        private void updateEvent()
        {
            try
            {
                frmEntry = new FrmCustomerChargeAdjustEntry(this, isDriver);
                frmEntry.InitEditAction(selectedCustomerChargeAdjustment);
                frmEntry.ShowDialog();
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

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    if (facadeCustomerChargeAdjustment.DeleteCustomerChargeAdjustment(selectedCustomerChargeAdjustment))
                    {
                        if (dtgCustomerAdjust.RowCount > 1)
                        {
                            dtgCustomerAdjust.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgCustomerAdjust.RowCount = 0;
                            enableAmend(false);
                        }

                        mdiParent.RefreshMasterCount();
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

        //============================== Base Event ==============================
        public void InitForm()
        {
            facadeCustomerChargeAdjustment = new CustomerChargeAdjustmentFacade();
            clearForm();
        }

        public void RefreshForm()
        {
            try
            {
                mdiParent.EnableNewCommand(true);
                MainMenuNewStatus = true;
                mdiParent.EnableRefreshCommand(true);
                MainMenuRefreshStatus = true;
                mdiParent.EnablePrintCommand(true);
                MainMenuPrintStatus = true;

                visibleForm(true);
                gpbData.Enabled = false;

                if (facadeCustomerChargeAdjustment.DisplayCustomerChargeAdjustment(new YearMonth(dtpDate.Value), isDriver))
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgCustomerAdjust.RowCount = 0;
                }
                mdiParent.RefreshMasterCount();
                
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

            if (isReadonly)
            {
                mniAdd.Enabled = false;
                btnAdd.Enabled = false;
                enableAmend(false);
            }
        }

        public void PrintForm()
        {
            if (isDriver)
            {
                frmrptCustomerChargeAdjustment formReport = new frmrptCustomerChargeAdjustment();
                formReport.MdiParent = (Presentation.frmMain)this.MdiParent;
                formReport.SelectedDate = dtpDate.Value;
                formReport.Show();
            }
            else 
            {
                FrmrptCustomerChargeAdjustmentOtherSS formReport = new FrmrptCustomerChargeAdjustmentOtherSS();
                formReport.MdiParent = (Presentation.frmMain)this.MdiParent;
                formReport.SelectedDate = dtpDate.Value;
                formReport.Show();
            }
             

        }

        public void ExitForm()
        {
            this.Close();
        }

        //============================== Event ==============================
        private void FrmCustomerChargeAdjust_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }
        
        private void btnShowData_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void dtgCustomerAdjust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
    }
}