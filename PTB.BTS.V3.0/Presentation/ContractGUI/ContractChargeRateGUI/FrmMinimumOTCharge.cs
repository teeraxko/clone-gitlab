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
    public partial class FrmMinimumOTCharge : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmMinimumOTChargeEntry frmEntry; 
        #endregion -Private -       

        #region - Property -
        private MinimumOTChargeFacade facadeMinimumOTCharge;
        public MinimumOTChargeFacade FacadeMinimumOTCharge
        {
            get { return facadeMinimumOTCharge; }
        }

        private int SelectedRow
        {
            get { return dtgDriverStatus.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgDriverStatus[0, SelectedRow].Value.ToString(); }
        }

        public MinimumOTCharge selectedMinimumOTCharge
        {
            get { return (MinimumOTCharge)facadeMinimumOTCharge.ObjMinimumOTChargeList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmMinimumOTCharge(): base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingMinimumOTCharge");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingMinimumOTCharge");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingMinimumOTCharge");
        }

        public override int MasterCount()
        {
            return facadeMinimumOTCharge.ObjMinimumOTChargeList.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeMinimumOTCharge = new MinimumOTChargeFacade();
            frmEntry = new FrmMinimumOTChargeEntry(this);
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
            dtgDriverStatus.RowCount = 0;
            enableAmend(false);            
        }

        private void bindMinimumOTCharge(int row, MinimumOTCharge value)
        {
            dtgDriverStatus[0, row].Value = value.EntityKey.ToString();
            dtgDriverStatus[1, row].Value = value.DriverOnlyStatus;
            dtgDriverStatus[2, row].Value = value.MinOTHour;
            dtgDriverStatus[3, row].Value = value.MinOTAmount;
        }

        private void bindForm()
        {
            dtgDriverStatus.RowCount = 0;

            if (facadeMinimumOTCharge.ObjMinimumOTChargeList.Count > 0)
            {
                for (int i = 0; i < facadeMinimumOTCharge.ObjMinimumOTChargeList.Count; i++)
                {
                    dtgDriverStatus.RowCount++;
                    bindMinimumOTCharge(i, facadeMinimumOTCharge.ObjMinimumOTChargeList[i]);
                }
            }            
        }

        //		==========================Public Method========================
        public bool AddRow(MinimumOTCharge value)
        {
            if (facadeMinimumOTCharge.InsertMinimumOTCharge(value))
            {
                dtgDriverStatus.RowCount++;
                bindMinimumOTCharge(dtgDriverStatus.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(MinimumOTCharge value)
        {
            if (facadeMinimumOTCharge.UpdateMinimumOTCharge(value))
            {
                bindMinimumOTCharge(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmMinimumOTChargeEntry(this);
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
                frmEntry = new FrmMinimumOTChargeEntry(this);
                frmEntry.InitEditAction(selectedMinimumOTCharge);
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
                    if (facadeMinimumOTCharge.DeleteMinimumOTCharge(selectedMinimumOTCharge))
                    {
                        if (dtgDriverStatus.RowCount > 1)
                        {
                            dtgDriverStatus.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgDriverStatus.RowCount = 0;
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
        }

        public void RefreshForm()
        {
            try
            {
                if (facadeMinimumOTCharge.DisplayMinimumOTChage())
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgDriverStatus.RowCount = 0;
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
        private void FrmMinimumOTCharge_Load(object sender, EventArgs e)
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

        private void dtgDriverStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
    }
}

