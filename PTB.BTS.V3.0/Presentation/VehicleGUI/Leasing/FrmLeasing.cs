using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.VehicleFacade.LeasingFacade;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.Leasing
{
    public partial class FrmLeasing : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmLeasingEntry frmEntry;
        #endregion -Private -

        #region - Property -
        private QuotationFacade facadeQuotation;
        public QuotationFacade FacadeQuotation
        {
            get { return facadeQuotation; }
        }

        private int SelectedRow
        {
            get { return dtgQuotation.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgQuotation[0, SelectedRow].Value.ToString(); }
        }

        private Quotation selectedQuotation
        {
            get { return (Quotation)facadeQuotation.ListQuotation[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================
        public FrmLeasing() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleLeasing");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleLeasing");
        }

        public override int MasterCount()
        {
            return facadeQuotation.ListQuotation.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeQuotation = new QuotationFacade();
            frmEntry = new FrmLeasingEntry(this);
        }

        private void visibleForm(bool visible)
        {
            dtgQuotation.Visible = visible;
            btnAdd.Visible = visible;
            btnUpdate.Visible = visible;
            btnDelete.Visible = visible;
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
            dtpFromDate.Value = DateTime.Today.AddYears(-1);
            dtgQuotation.RowCount = 0;
            enableAmend(false);
        }

        private void bindQuotation(int row, Quotation value)
        {
            dtgQuotation[0, row].Value = value.EntityKey.ToString();
            dtgQuotation[1, row].Value = value.QuotationNo.ToString();
            dtgQuotation[2, row].Value = value.LastIssueDate;

            if (value.Customer != null)
            {
                dtgQuotation[3, row].Value = value.Customer.ShortName;
            }

            if (value.AnewVehicle.VehicleInfo.AModel != null)
            {
                if (value.AnewVehicle.VehicleInfo.AModel.ABrand != null)
                {
                    dtgQuotation[4, row].Value = value.AnewVehicle.VehicleInfo.AModel.ABrand.AName.English;
                }
                dtgQuotation[5, row].Value = value.AnewVehicle.VehicleInfo.AModel.AName.English;
            }
            dtgQuotation[6, row].Value = value.IsCustomerAccept;
            dtgQuotation[7, row].Value = value.PONo;
        }

        private void bindForm()
        {
            dtgQuotation.RowCount = 0;

            if (facadeQuotation.ListQuotation.Count > 0)
            {
                for (int i = 0; i < facadeQuotation.ListQuotation.Count; i++)
                {
                    dtgQuotation.RowCount++;
                    bindQuotation(i, facadeQuotation.ListQuotation[i]);
                }
            }
        }

        //==========================Public Method========================
        #region - Quotation -
        public bool AddQuotation(Quotation value)
        {
            if (facadeQuotation.InsertQuotation(value))
            {
                dtgQuotation.RowCount++;
                bindQuotation(dtgQuotation.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateQuotation(Quotation value)
        {
            if (facadeQuotation.UpdateQuotation(value))
            {
                bindQuotation(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmLeasingEntry(this);
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

        private void updateEvent(bool isUpdate)
        {
            try
            {
                if (facadeQuotation.FillQuotationDetail(selectedQuotation))
                {
                    frmEntry = new FrmLeasingEntry(this);
                    frmEntry.InitEditAction(selectedQuotation, isUpdate);
                    frmEntry.ShowDialog();
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

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    if (facadeQuotation.DeleteQuotation(selectedQuotation))
                    {
                        if (dtgQuotation.RowCount > 1)
                        {
                            dtgQuotation.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgQuotation.RowCount = 0;
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
        #endregion

        #region - PO -
        public bool DeletePO(Quotation quotation, Entity.CommonEntity.PURCHAS_STATUS_TYPE poStatus)
        {
            if (facadeQuotation.DeleteQuotationPO(quotation, poStatus))
            {
                for (int i = 0; i < dtgQuotation.RowCount; i++)
                {
                    if (dtgQuotation[0, i].Value.ToString() == quotation.QuotationNo.ToString())
                    {
                        dtgQuotation[7, i].Value = "";
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        //============================== Base Event ==============================
        public void InitForm()
        {
            newObject();
            clearForm();
            visibleForm(false);

            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
        }

        public void RefreshForm()
        {
            try
            {
                visibleForm(true);

                if (facadeQuotation.DisplayQuotationMainList(dtpFromDate.Value.Date))
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgQuotation.RowCount = 0;
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
        private void FrmLeasing_Load(object sender, EventArgs e)
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
            updateEvent(true);
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
            updateEvent(true);
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void dtgQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent(false);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}