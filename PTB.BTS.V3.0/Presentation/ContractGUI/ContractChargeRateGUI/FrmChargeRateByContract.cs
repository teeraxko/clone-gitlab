using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Facade.ContractFacade.ContractChargeRateFacade;

using Presentation.CommonGUI;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmChargeRateByContract : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmChargeRateByContractEntry frmEntry;
        #endregion -Private -

        #region - Property -
        private ChargeRateByContractFacade facadeChargeRateByContract;
        public ChargeRateByContractFacade FacadeChargeRateByContract
        {
            get { return facadeChargeRateByContract; }
        }

        private int SelectedRow
        {
            get { return dtgChargeRateContract.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgChargeRateContract[0, SelectedRow].Value.ToString(); }
        }

        public ChargeRateByContract selectedChargeRateByContract
        {
            get { return (ChargeRateByContract)facadeChargeRateByContract.ObjChargeRateByContractList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmChargeRateByContract() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = false;
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffChargeContract");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingServiceStaffChargeContract");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingServiceStaffChargeContract");
        }

        public override int MasterCount()
        {
            return dtgChargeRateContract.RowCount;
            //return facadeChargeRateByContract.ObjChargeRateByContractList.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeChargeRateByContract = new ChargeRateByContractFacade();
            frmEntry = new FrmChargeRateByContractEntry(this);
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
            dtgChargeRateContract.RowCount = 0;
            enableAmend(false);
        }

        private void bindChargeRateByContract(int row, ChargeRateByContract value)
        {
            dtgChargeRateContract[0, row].Value = value.EntityKey.ToString();
            dtgChargeRateContract[1, row].Value = value.ContractBase.ContractNo.ToString();

            Entity.ContractEntities.ServiceStaffAssignment assignment = facadeChargeRateByContract.GetMainAssignmentInDate(value.ContractBase, DateTime.Today);
            if (assignment != null)
            {
                dtgChargeRateContract[2, row].Value = assignment.AAssignedServiceStaff.EmployeeIDName;
                dtgChargeRateContract[3, row].Value = assignment.AAssignedServiceStaff.AServiceStaffType.ADescription.English;
            }
            
            dtgChargeRateContract[4, row].Value = value.ChargeRate.OTARate;
            dtgChargeRateContract[5, row].Value = value.ChargeRate.OTBRate;
            dtgChargeRateContract[6, row].Value = value.ChargeRate.OTCRate;
            dtgChargeRateContract[7, row].Value = value.ChargeRate.BasicChargeAmount;
            dtgChargeRateContract[8, row].Value = value.ChargeRate.AbsenceDeduction;
            dtgChargeRateContract[9, row].Value = value.ChargeRate.OneDayTripRateFar;
            //dtgChargeRateContract[10, row].Value = value.ChargeRate.OneDayTripRateNear;
            dtgChargeRateContract[10, row].Value = value.ChargeRate.OvernightTripRate;
            dtgChargeRateContract[11, row].Value = value.ChargeRate.TaxiRate;
            dtgChargeRateContract[12, row].Value = value.ChargeRate.MinLeaveDays;
            dtgChargeRateContract[13, row].Value = value.ChargeRate.MinHolidayAmount;
        }

        private void bindForm()
        {
            DateTime forDate = new DateTime(DateTime.Today.AddMonths(-2).Year, DateTime.Today.AddMonths(-2).Month, 1);
            dtgChargeRateContract.RowCount = 0;

            if (facadeChargeRateByContract.ObjChargeRateByContractList.Count > 0)
            {
                foreach (ChargeRateByContract entity in facadeChargeRateByContract.ObjChargeRateByContractList)
                {
                    if (entity.ContractBase.APeriod.To > forDate)
                    {
                        dtgChargeRateContract.RowCount++;
                        bindChargeRateByContract(dtgChargeRateContract.RowCount - 1, entity);
                    }
                }
            }
        }

        //		==========================Public Method========================
        public bool AddRow(ChargeRateByContract value)
        {
            if (facadeChargeRateByContract.InsertChargeRateByContract(value))
            {
                dtgChargeRateContract.RowCount++;
                bindChargeRateByContract(dtgChargeRateContract.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(ChargeRateByContract value)
        {
            if (facadeChargeRateByContract.UpdateChargeRateByContract(value))
            {
                bindChargeRateByContract(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmChargeRateByContractEntry(this);
                frmEntry.InitAddAction();
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
                frmEntry = new FrmChargeRateByContractEntry(this);
                frmEntry.InitEditAction(selectedChargeRateByContract);
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
                    if (facadeChargeRateByContract.DeleteChargeRateByContract(selectedChargeRateByContract))
                    {
                        if (dtgChargeRateContract.RowCount > 1)
                        {
                            dtgChargeRateContract.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgChargeRateContract.RowCount = 0;
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
            newObject();
            clearForm();
            RefreshForm();

            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
            mdiParent.EnablePrintCommand(true);
            MainMenuPrintStatus = true;
        }

        public void RefreshForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                if (facadeChargeRateByContract.DisplayChargeRateByContract())
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgChargeRateContract.RowCount = 0;
                }
                mdiParent.RefreshMasterCount();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageForm(ex);
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
            try
            {
                Report.GUI.Contract.FrmReportChargeRateByContract frmReport = new Report.GUI.Contract.FrmReportChargeRateByContract();
                frmReport.Show();
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        public void ExitForm()
        {
            this.Close();
        }


        //============================== Event ==============================
        private void FrmChargeRateByContract_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
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

        private void dtgChargeRateContract_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }

        private void dtgChargeRateContract_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

