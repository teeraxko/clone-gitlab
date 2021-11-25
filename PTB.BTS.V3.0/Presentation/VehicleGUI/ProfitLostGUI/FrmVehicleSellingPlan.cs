using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Facade.VehicleFacade.LeasingFacade;
using SystemFramework.AppConfig;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.ProfitLostGUI
{
    public partial class FrmVehicleSellingPlan : Presentation.CommonGUI.ChildFormBase, Presentation.CommonGUI.IMDIChildForm
    {
        private FrmVehicleSellingPlanEntry frmEntry;
        private frmMain mdiParent;

        private VehicleSellingPlanFacade facade;
        public VehicleSellingPlanFacade Facade
        {
            get { return facade; }
        }

        private VehicleSellingPlan SelectEntity
        {
            get
            {
                if (dtgSellingPlan.SelectedRows[0] != null)
                    return (VehicleSellingPlan)dtgSellingPlan.SelectedRows[0].Tag;
                else
                    return null;
            }
        }

        private int SelectIndex
        {
            get { return dtgSellingPlan.CurrentRow.Index; }
        }

        //============================== Constructor ==============================
        public FrmVehicleSellingPlan() : base()
        {
            InitializeComponent();
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleSellingPlan");
        }


        //============================== Private Method ==============================
        private void EditData()
        {
            try
            {
                frmEntry = new FrmVehicleSellingPlanEntry(this);
                frmEntry.InitEdit(SelectEntity);
                frmEntry.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private void DeleteData()
        {
            if (SelectEntity != null && Message(MessageList.Question.Q0001) == DialogResult.Yes)
            {
                facade.Delete(SelectEntity, new ictus.Common.Entity.Time.YearMonth(dtpEffectMonth.Value));

                ((VehicleSellingPlan)dtgSellingPlan.Rows[SelectIndex].Tag).BVDate = null;
                ((VehicleSellingPlan)dtgSellingPlan.Rows[SelectIndex].Tag).SellingDate = null;
                ((VehicleSellingPlan)dtgSellingPlan.Rows[SelectIndex].Tag).EstimateSelling = decimal.Zero;
                dtgSellingPlan[6, SelectIndex].Value = null;
                dtgSellingPlan[7, SelectIndex].Value = null;
                dtgSellingPlan[8, SelectIndex].Value = decimal.Zero;
            }
        }

        private void enableAmend(bool value)
        {
            btnEdit.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void ClearForm()
        {
            dtgSellingPlan.Rows.Clear();
            enableAmend(false);
        }

        private void BindForm()
        {
            VehicleSellingPlanList list = facade.List;
            dtgSellingPlan.Rows.Clear();

            foreach (VehicleSellingPlan entity in list)
            {
                dtgSellingPlan.RowCount++;
                BindData(entity, dtgSellingPlan.RowCount - 1);
            }
        }

        private void BindData(VehicleSellingPlan entity, int row)
        {
            dtgSellingPlan.Rows[row].Tag = entity;
            dtgSellingPlan[0, row].Value = entity.VehicleInfo.PlateNumber;
            dtgSellingPlan[1, row].Value = entity.VehicleInfo.AModel.ABrand.AName.English;
            dtgSellingPlan[2, row].Value = entity.VehicleInfo.AModel.AName.English;
            dtgSellingPlan[3, row].Value = entity.VehicleInfo.RegisterDate;
            dtgSellingPlan[4, row].Value = entity.VehicleYear;
            dtgSellingPlan[5, row].Value = entity.VehicleInfo.VehicleAmount;

            if (entity.BVDate.HasValue)
                dtgSellingPlan[6, row].Value = entity.BVDate.Value;

            if (entity.SellingDate.HasValue)
                dtgSellingPlan[7, row].Value = entity.SellingDate.Value;
            dtgSellingPlan[8, row].Value = entity.EstimateSelling;
        }

        //============================== Public method ==============================
        public bool EditRow(VehicleSellingPlan entity)
        {
            if (facade.CalculateBV(entity, new ictus.Common.Entity.Time.YearMonth(dtpEffectMonth.Value)))
            {
                BindData(entity, SelectIndex);
                return true;
            }
            return false;
        }

        //============================== Base Event ==============================
        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleSellingPlan");
        }

        public override int MasterCount()
        {
            return facade.List.Count;
        }

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnablePrintCommand(true);
            MainMenuPrintStatus = true;

            facade = new VehicleSellingPlanFacade();
            dtpEffectMonth.Value = DateTime.Today;
            dtpPrintFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpPrintTo.Value = new DateTime(DateTime.Today.Year, 12, 31);
            gpbShowData.Enabled = true;
            ClearForm();
        }

        public void RefreshForm()
        {
            mdiParent.EnableNewCommand(true);
            MainMenuNewStatus = true;
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
            gpbShowData.Enabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (facade.FillList(new ictus.Common.Entity.Time.YearMonth(dtpEffectMonth.Value)))
                {
                    BindForm();
                    enableAmend(true);
                }
                else
                {
                    ClearForm();
                }

                if (UserProfile.IsReadOnly("miVehicle", "miVehicleSellingPlan"))
                {
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageForm(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;            
            }
        }

        public void PrintForm()
        {
            if (dtpPrintFrom.Value > dtpPrintTo.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpPrintFrom.Focus();
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();
                    Report.GUI.Vehicle.FrmReportVehicleSellingPlan frmReport = new Report.GUI.Vehicle.FrmReportVehicleSellingPlan(dtpPrintFrom.Value, dtpPrintTo.Value);
                    frmReport.Show();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageForm(ex);
                }
            }
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        //============================== Event ==============================
        private void FrmVehicleSellingPlan_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dtgSellingPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditData();
            }
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintForm();
        }
    }
}