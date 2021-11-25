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
using Entity.ContractEntities;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmChargeRateByServiceStaffType : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmChargeRateByServiceStaffTypeEntry frmEntry;
        #endregion -Private -

        #region - Property -
        private ChargeRateByServiceStaffTypeFacade facadeChargeRateByServiceStaffType;
        public ChargeRateByServiceStaffTypeFacade FacadeChargeRateByServiceStaffType
        {
            get { return facadeChargeRateByServiceStaffType; }
        }

        private int SelectedRow
        {
            get { return dtgChargeRateServiceStaff.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgChargeRateServiceStaff[0, SelectedRow].Value.ToString(); }
        }

        public ChargeRateByServiceStaffType selectedChargeRateByServiceStaffType
        {
            get { return (ChargeRateByServiceStaffType)facadeChargeRateByServiceStaffType.ObjChargeRateByServiceStaffTypeList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmChargeRateByServiceStaffType() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = false;
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffCharge");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingServiceStaffCharge");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingServiceStaffCharge");
        }

        public override int MasterCount()
        {
            return facadeChargeRateByServiceStaffType.ObjChargeRateByServiceStaffTypeList.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeFacade();
            frmEntry = new FrmChargeRateByServiceStaffTypeEntry(this);
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
            dtgChargeRateServiceStaff.RowCount = 0;
            enableAmend(false);
        }

        private void bindChargeRateByServiceStaffType(int row, ChargeRateByServiceStaffType value)
        {
            dtgChargeRateServiceStaff[0, row].Value = value.EntityKey.ToString();
            if (value.ServiceStaffType.Type == ServiceStaffType.DUMMYCODE)
            {
                dtgChargeRateServiceStaff[1, row].Value = "";
            }
            else
            { 
                dtgChargeRateServiceStaff[1, row].Value = value.ServiceStaffType.ADescription.English;
            }

            if(value.Customer.Code == Customer.DUMMYCODE)
            {
                dtgChargeRateServiceStaff[2, row].Value = "";
            }
            else
            {   
                dtgChargeRateServiceStaff[2, row].Value = value.Customer.ShortName;
            }
            
            dtgChargeRateServiceStaff[3, row].Value = value.DriverOnlyStatus;
            dtgChargeRateServiceStaff[4, row].Value = value.ChargeRate.OTARate;
            dtgChargeRateServiceStaff[5, row].Value = value.ChargeRate.OTBRate;
            dtgChargeRateServiceStaff[6, row].Value = value.ChargeRate.OTCRate;
            dtgChargeRateServiceStaff[7, row].Value = value.ChargeRate.AbsenceDeduction;
            dtgChargeRateServiceStaff[8, row].Value = value.ChargeRate.OneDayTripRateFar;
            //dtgChargeRateServiceStaff[9, row].Value = value.ChargeRate.OneDayTripRateNear;
            dtgChargeRateServiceStaff[9, row].Value = value.ChargeRate.OvernightTripRate;
            dtgChargeRateServiceStaff[10, row].Value = value.ChargeRate.TaxiRate;
            dtgChargeRateServiceStaff[11, row].Value = value.ChargeRate.MinLeaveDays;
            dtgChargeRateServiceStaff[12, row].Value = value.ChargeRate.MinHolidayAmount;
        }

        private void bindForm()
        {
            dtgChargeRateServiceStaff.RowCount = 0;

            if (facadeChargeRateByServiceStaffType.ObjChargeRateByServiceStaffTypeList.Count > 0)
            {
                for (int i = 0; i < facadeChargeRateByServiceStaffType.ObjChargeRateByServiceStaffTypeList.Count; i++)
                {
                    dtgChargeRateServiceStaff.RowCount++;
                    bindChargeRateByServiceStaffType(i, facadeChargeRateByServiceStaffType.ObjChargeRateByServiceStaffTypeList[i]);
                }
            }
        }

        //		==========================Public Method========================
        public bool AddRow(ChargeRateByServiceStaffType value)
        {
            if (facadeChargeRateByServiceStaffType.InsertChargeRateByServiceStaffType(value))
            {
                dtgChargeRateServiceStaff.RowCount++;
                bindChargeRateByServiceStaffType(dtgChargeRateServiceStaff.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(ChargeRateByServiceStaffType value)
        {
            if (facadeChargeRateByServiceStaffType.UpdateChargeRateByServiceStaffType(value))
            {
                bindChargeRateByServiceStaffType(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmChargeRateByServiceStaffTypeEntry(this);
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
                frmEntry = new FrmChargeRateByServiceStaffTypeEntry(this);
                frmEntry.InitEditAction(selectedChargeRateByServiceStaffType);
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
                    if (selectedChargeRateByServiceStaffType.ServiceStaffType.Type == "ZZZ" || selectedChargeRateByServiceStaffType.Customer.Code == Customer.DUMMYCODE)
                    {
                        Message(MessageList.Error.E0014, "ลบข้อมูลนี้ได้");
                    }
                    else
                    {
                        if (facadeChargeRateByServiceStaffType.DeleteChargeRateByServiceStaffType(selectedChargeRateByServiceStaffType))
                        {
                            if (dtgChargeRateServiceStaff.RowCount > 1)
                            {
                                dtgChargeRateServiceStaff.Rows.RemoveAt(SelectedRow);
                            }
                            else
                            {
                                dtgChargeRateServiceStaff.RowCount = 0;
                                enableAmend(false);
                            }

                            mdiParent.RefreshMasterCount();
                        }
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
                if (facadeChargeRateByServiceStaffType.DisplayChargeRateByServiceStaffType())
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgChargeRateServiceStaff.RowCount = 0;
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
        private void FrmChargeRateByServiceStaffType_Load(object sender, EventArgs e)
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

        private void dtgChargeRateServiceStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
    }
}

