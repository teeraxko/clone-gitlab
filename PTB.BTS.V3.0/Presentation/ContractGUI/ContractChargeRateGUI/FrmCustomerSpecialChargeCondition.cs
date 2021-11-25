using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.ContractFacade.ContractChargeRateFacade;
using SystemFramework.AppConfig;
using PTB.BTS.ContractEntities.ContractChargeRate;
using System.Data.SqlClient;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmCustomerSpecialChargeCondition : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private FrmCustomerSpecialChargeConditionEntry frmEntry;
        private frmMain mdiParent;
        #endregion

        #region - Property -
        private CustomerSpecialChargeConditionFacade facadeSpecialCharge;
        public CustomerSpecialChargeConditionFacade FacadeSpecialCharge
        {
            get { return facadeSpecialCharge; }
        }

        private int SelectedRow
        {
            get { return dtgSpecialAdjust.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgSpecialAdjust[colEntityKey.Index, SelectedRow].Value.ToString(); }
        }

        public CustomerSpecialChargeCondition selectedSpecialCharge
        {
            get { return (CustomerSpecialChargeCondition)facadeSpecialCharge.ObjSpecialChargeList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmCustomerSpecialChargeCondition()
            : base()
        {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentSpecialCharge");
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentSpecialCharge");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentSpecialCharge");
        }

        public override int MasterCount()
        {
            return facadeSpecialCharge.ObjSpecialChargeList.Count;
        }

        //=============================== Private Method ================================	
        private void visibleForm(bool value)
        {
            dtgSpecialAdjust.Visible = value;
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
            dtgSpecialAdjust.RowCount = 0;
            enableAmend(false);
            visibleForm(false);
        }

        private void bindCustomerSpecialChargeCondition(int row, CustomerSpecialChargeCondition value)
        {
            dtgSpecialAdjust[colEntityKey.Index, row].Value = value.EntityKey.ToString();

            if (value.DriverStaff != null)
            {
                dtgSpecialAdjust[colEmployee.Index, row].Value = value.DriverStaff.EmployeeIDName;
                dtgSpecialAdjust[colPosition.Index, row].Value = value.DriverStaff.APosition.AName.English;
            }
            else
            {
                dtgSpecialAdjust[colEmployee.Index, row].Value = string.Empty;
                dtgSpecialAdjust[colPosition.Index, row].Value = string.Empty;
            }

            dtgSpecialAdjust[colContractNo.Index, row].Value = value.Contract.ContractNo.ToString();
            //add by Aof 04/12/08
            //For multiple department assignment
            if (value.AssignDepartment != null && value.AssignDepartment.ShortName != string.Empty)
            {
                dtgSpecialAdjust[colCustomer.Index, row].Value = string.Concat(value.Contract.ACustomer.ShortName, " (", value.AssignDepartment.ShortName, ")");
            }
            else
            {
                dtgSpecialAdjust[colCustomer.Index, row].Value = value.Contract.ACustomer.ShortName;
            }
            //end add by Aof
            dtgSpecialAdjust[colTelAmount.Index, row].Value = value.TelephoneAmount;
            dtgSpecialAdjust[colSpecialAmount.Index, row].Value = value.SpecialAmount;

            dtgSpecialAdjust[colStartDate.Index, row].Value = value.Contract.APeriod.From;
            dtgSpecialAdjust[colEndDate.Index, row].Value = value.Contract.APeriod.To;
        }

        private void bindForm()
        {
            dtgSpecialAdjust.RowCount = 0;

            if (facadeSpecialCharge.ObjSpecialChargeList.Count > 0)
            {
                for (int i = 0; i < facadeSpecialCharge.ObjSpecialChargeList.Count; i++)
                {
                    dtgSpecialAdjust.RowCount++;
                    bindCustomerSpecialChargeCondition(i, facadeSpecialCharge.ObjSpecialChargeList[i]);
                }
            }
        }

        //==========================Public Method========================
        public bool AddRow(CustomerSpecialChargeCondition value)
        {
            if (facadeSpecialCharge.InsertCustomerSpecialChargeCondition(value))
            {
                dtgSpecialAdjust.RowCount++;
                bindCustomerSpecialChargeCondition(dtgSpecialAdjust.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(CustomerSpecialChargeCondition value)
        {
            if (facadeSpecialCharge.UpdateCustomerSpecialChargeCondition(value))
            {
                bindCustomerSpecialChargeCondition(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmCustomerSpecialChargeConditionEntry(this);
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
                frmEntry = new FrmCustomerSpecialChargeConditionEntry(this);
                frmEntry.InitEditAction(selectedSpecialCharge);
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
                    if (facadeSpecialCharge.DeleteCustomerSpecialChargeCondition(selectedSpecialCharge))
                    {
                        if (dtgSpecialAdjust.RowCount > 1)
                        {
                            dtgSpecialAdjust.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgSpecialAdjust.RowCount = 0;
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
            facadeSpecialCharge = new CustomerSpecialChargeConditionFacade();
            RefreshForm();
        }

        public void RefreshForm()
        {
            try
            {
                mdiParent.EnableRefreshCommand(true);
                MainMenuRefreshStatus = true;
                mdiParent.EnablePrintCommand(true);
                MainMenuPrintStatus = true;

                if (facadeSpecialCharge.DisplayCustomerSpecialChargeCondition())
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgSpecialAdjust.RowCount = 0;
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
        }

        public void ExitForm()
        {
            this.Close();
        }

        //============================== Event ==============================
        private void FrmCustomerSpecialChargeCondition_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
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

        private void dtgSpecialAdjust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
    }
}