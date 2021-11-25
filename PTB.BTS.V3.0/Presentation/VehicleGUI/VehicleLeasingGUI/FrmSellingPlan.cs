using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;
using Facade.VehicleFacade.VehicleLeasingFacade;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmSellingPlan : Presentation.CommonGUI.ChildFormBase, Presentation.CommonGUI.IMDIChildForm
    {
        #region Private

        private string vehicleNo;
        private FrmSellingPlanEntry frmEntry;
        private frmMain mdiParent;

        private VehicleSellingPlanFacade facade;
        public VehicleSellingPlanFacade Facade
        {
            get { return facade; }
        }

        private VehicleInfo SelectEntity
        {
            get
            {
                if (dtgSellingPlan.SelectedRows[0] != null)
                    return (VehicleInfo)dtgSellingPlan.SelectedRows[0].Tag;
                else
                    return null;
            }
        }

        private VehicleInfo SelectEntityByRow(int row)
        {
            return (VehicleInfo)dtgSellingPlan.Rows[row].Tag;
        }

        private int SelectIndex
        {
            get { return dtgSellingPlan.CurrentRow.Index; }
        }

        #endregion

        #region Constructor

        public FrmSellingPlan()
            : base()
        {
            InitializeComponent();
            this.title = UserProfile.GetFormName("miVehicle", "miSellingPlan");
        }
        
        #endregion

        #region Private Method

        /// <summary>
        /// Get Vehicle Selling object in order to insert to database
        /// by Aof 20/11/08
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private VehicleSelling getInsertVehicleSelling(int row)
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = SelectEntity.VehicleNo;

            vehicleSelling.Vehicle = vehicle;
            vehicleSelling.SellingPrice = decimal.Zero;
            vehicleSelling.BVDate = dtpSellingDate.Value.Date;
            vehicleSelling.BV = facade.CalculateBV(SelectEntity, dtpSellingDate.Value.Date);

            return vehicleSelling;
        }

        private VehicleSelling getInsertAllVehicleSelling(int row)
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = SelectEntityByRow(row).VehicleNo;

            vehicleSelling.Vehicle = vehicle;
            vehicleSelling.SellingPrice = decimal.Zero;
            vehicleSelling.BVDate = dtpSellingDate.Value.Date;
            vehicleSelling.BV = facade.CalculateBV(SelectEntityByRow(row), dtpSellingDate.Value.Date);

            return vehicleSelling;
        }

        private VehicleSelling getDeleteVehicleSelling(int row)
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = SelectEntity.VehicleNo;

            vehicleSelling.Vehicle = vehicle;

            return vehicleSelling;
        }

        private VehicleSelling getDeleteAllVehicleSelling(int row)
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = SelectEntityByRow(row).VehicleNo;

            vehicleSelling.Vehicle = vehicle;

            return vehicleSelling;
        }

        /// <summary>
        /// Get Vehicle Selling object in order to comfirm selling
        /// by Aof 20/11/08
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private VehicleSelling getConfirmVehicleSelling(int row)
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNo = SelectEntity.VehicleNo;
            vehicle.PlatePrefix = SelectEntity.PlatePrefix;
            vehicle.PlateRunningNo = SelectEntity.PlateRunningNo;
            vehicle.AModel = SelectEntity.AModel;
            vehicle.AColor = SelectEntity.AColor;
            vehicle.RegisterDate = SelectEntity.RegisterDate;

            vehicleSelling.Vehicle = vehicle;
            vehicleSelling.BVDate = Convert.ToDateTime(dtgSellingPlan[colBVDate.Index, row].Value);
            vehicleSelling.BV = Convert.ToDecimal(dtgSellingPlan[colBV.Index, row].Value);

            if (dtgSellingPlan[colSellingDate.Index, row].Value != null && dtgSellingPlan[colSellingDate.Index, row].Value.ToString() != "")
            {
                vehicleSelling.SellingDate = Convert.ToDateTime(dtgSellingPlan[colSellingDate.Index, row].Value);
            }
            else
            {
                vehicleSelling.SellingDate = null;
            }

            if (dtgSellingPlan[colSellingPrice.Index, row].Value != null && dtgSellingPlan[colSellingPrice.Index, row].Value.ToString() != "")
            {
                vehicleSelling.SellingPrice = Convert.ToDecimal(dtgSellingPlan[colSellingPrice.Index, row].Value);
            }
            else
            {
                vehicleSelling.SellingPrice = decimal.Zero;
            }

            if (dtgSellingPlan[colBidder.Index, row].Value != null && dtgSellingPlan[colBidder.Index, row].Value.ToString() != "")
            {
                vehicleSelling.Bidder = new Bidder(dtgSellingPlan[colBidder.Index, row].Value.ToString());
            }
            else
            {
                vehicleSelling.Bidder = null;
            }

            return vehicleSelling;
        }

        private void addData(int row)
        {
            if (SelectEntity != null)
            {
                try
                {
                    if (facade.InsertVehicleSelling(getInsertVehicleSelling(row)))
                    {
                        decimal bv, depre;
                        bv = facade.CalculateBV(SelectEntity, dtpSellingDate.Value.Date);
                        depre = SelectEntity.VehicleAmount - bv;
                        bindDataInsert(dtpSellingDate.Value.Date, bv, depre, row);
                    }

                    dtgSellingPlan[colNo.Index, row].Value = true;
                    btnConfirmSelling.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageForm(ex);
                }
            }
        }

        private void addDataAll(int row)
        {
            try
            {
                if (facade.InsertVehicleSelling(getInsertAllVehicleSelling(row)))
                {
                    decimal bv, depre;
                    bv = facade.CalculateBV(SelectEntityByRow(row), dtpSellingDate.Value.Date);
                    depre = SelectEntityByRow(row).VehicleAmount - bv;
                    bindDataInsert(dtpSellingDate.Value.Date, bv, depre, row);
                }

                dtgSellingPlan[colNo.Index, row].Value = true;
                btnConfirmSelling.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private void confirmEvent()
        {
            try
            {
                if (dtgSellingPlan[colSellingDate.Index, SelectIndex].Value == null)
                {
                    action = ActionType.ADD;
                }
                else 
                { 
                    action = ActionType.EDIT; 
                }

                frmEntry = new FrmSellingPlanEntry(this);
                frmEntry.InitEdit(getConfirmVehicleSelling(SelectIndex));
                frmEntry.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private void deleteData(int row)
        {
            if (SelectEntity != null)
            {
                try
                {
                    if (facade.DeleteVehicleSelling(getDeleteVehicleSelling(row)))
                    {
                        bindDataDelete(row);
                    }

                    dtgSellingPlan[colNo.Index, row].Value = false;
                    btnConfirmSelling.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageForm(ex);
                }
            }
        }

        private void deleteDataAll(int row)
        {
            try
            {
                if (facade.DeleteVehicleSelling(getDeleteAllVehicleSelling(row)))
                {
                    bindDataDelete(row);
                }

                dtgSellingPlan[colNo.Index, row].Value = false;
                btnConfirmSelling.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private void enableAmend(bool value)
        {
            btnConfirmSelling.Enabled = value;
            btnExit.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            dtpSellingDate.Value = DateTime.Today.Date;
            dtgSellingPlan.Rows.Clear();
            enableAmend(false);
        }

        private void visibleForm(bool value)
        {
            dtgSellingPlan.Visible = value;
            chkSelectAll.Visible = value;
            btnConfirmSelling.Visible = value;
            btnExit.Visible = value;
        }

        private void bindForm(List<VehicleInfo> list, List<VehicleSelling> list2, List<bool> list3)
        {
            dtgSellingPlan.Rows.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                dtgSellingPlan.RowCount++;
                bindData(list[i], list2[i], list3[i], dtgSellingPlan.RowCount - 1);
            }
        }

        private void bindData(VehicleInfo entity, VehicleSelling entity2, bool entity3, int row)
        {
            dtgSellingPlan.Rows[row].Tag = entity;
            dtgSellingPlan[colNo.Index, row].Value = entity3;
            dtgSellingPlan[colPlateNo.Index, row].Value = entity.PlateNumber;
            dtgSellingPlan[colBrand.Index, row].Value = entity.AModel.ABrand.AName.English;
            dtgSellingPlan[colModel.Index, row].Value = entity.AModel.AName.English;
            dtgSellingPlan[colRegisterDate.Index, row].Value = entity.RegisterDate;

            if (entity.VehicleAmount != decimal.Zero)
            {
                dtgSellingPlan[colPrice.Index, row].Value = entity.VehicleAmount;
            }
            else
            {
                dtgSellingPlan[colPrice.Index, row].Value = null;
            }

            if (entity2.BVDate.HasValue)
            {
                dtgSellingPlan[colBVDate.Index, row].Value = entity2.BVDate.Value.Date;
            }
            else
            {
                dtgSellingPlan[colBVDate.Index, row].Value = null;
            }

            if (entity2.BV != decimal.Zero)
            {
                dtgSellingPlan[colBV.Index, row].Value = entity2.BV;
            }
            else
            {
                dtgSellingPlan[colBV.Index, row].Value = null;
            }

            if (entity2.SellingDate.HasValue)
            {
                dtgSellingPlan[colSellingDate.Index, row].Value = entity2.SellingDate.Value.Date;
            }
            else
            {
                dtgSellingPlan[colSellingDate.Index, row].Value = null;
            }

            if (entity2.SellingPrice != 0)
            {
                dtgSellingPlan[colSellingPrice.Index, row].Value = entity2.SellingPrice;
            }
            else
            {
                dtgSellingPlan[colSellingPrice.Index, row].Value = null;
            }

            if (entity2.Bidder != null)
            {
                dtgSellingPlan[colBidder.Index, row].Value = entity2.Bidder.BidderCode;
            }
            else
            {
                dtgSellingPlan[colBidder.Index, row].Value = "";
            }

            if (entity.LatestMileage != 0)
            {
                dtgSellingPlan[colMileage.Index, row].Value = entity.LatestMileage;
            }
            else
            {
                dtgSellingPlan[colMileage.Index, row].Value = null;
            }
        }

        private void bindDataInsert(DateTime bvDate, decimal bv, decimal depre, int row)
        {
            dtgSellingPlan[colBVDate.Index, row].Value = bvDate.Date;
            dtgSellingPlan[colBV.Index, row].Value = bv;
            dtgSellingPlan[colDepreciation.Index, row].Value = depre;
        }

        private void bindDataDelete(int row)
        {
            dtgSellingPlan[colBVDate.Index, row].Value = null;
            dtgSellingPlan[colBV.Index, row].Value = null;
            dtgSellingPlan[colSellingDate.Index, row].Value = null;
            dtgSellingPlan[colSellingPrice.Index, row].Value = null;
            dtgSellingPlan[colBidder.Index, row].Value = "";
            dtgSellingPlan[colDepreciation.Index, row].Value = null;
        }

        private void bindDataConfirm(VehicleSelling entity, int row)
        {
            dtgSellingPlan[colBVDate.Index, row].Value = entity.BVDate.Value.Date;
            dtgSellingPlan[colBV.Index, row].Value = entity.BV;
            dtgSellingPlan[colSellingDate.Index, row].Value = entity.SellingDate.Value;
            dtgSellingPlan[colSellingPrice.Index, row].Value = entity.SellingPrice;
            dtgSellingPlan[colBidder.Index, row].Value = entity.Bidder.BidderCode;
        }
        #endregion

        #region Public Method

        public bool EditRow(VehicleSelling entity)
        {
            try
            {
                entity.Vehicle = new Vehicle();
                entity.Vehicle.VehicleNo = SelectEntity.VehicleNo;

                if (facade.UpdateVehicleSelling(entity))
                {
                    bindDataConfirm(entity, SelectIndex);
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex);
                return false;
            }
            return true;
        }

        #endregion

        #region IMDIChildForm Members

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleSellingPlan");
        }

        public override int MasterCount()
        {
            return 0;
        }

        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnablePrintCommand(false);
            MainMenuPrintStatus = false;
            gpbShowData.Enabled = true;

            facade = new VehicleSellingPlanFacade();
            dtpSellingDate.Value = DateTime.Today;
            visibleForm(false);
            clearForm();
        }

        public void RefreshForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<VehicleInfo> list = new List<VehicleInfo>();
                List<VehicleSelling> list2 = new List<VehicleSelling>();
                List<bool> list3 = new List<bool>();

                list = facade.GetVehicleInfoByVehicleSelling(dtpSellingDate.Value.Date);

                if (list.Count != 0)
                {
                    foreach (VehicleInfo entity in list)
                    {
                        VehicleSelling vehicleSelling = new VehicleSelling();
                        vehicleSelling = facade.FillVehicleSelling(entity.VehicleNo);
                        list2.Add(vehicleSelling);
                        if (vehicleSelling.Vehicle != null)
                        {
                            list3.Add(true);
                        }
                        else
                        {
                            list3.Add(false);
                        }
                    }

                    bindForm(list, list2, list3);
                    enableAmend(true);

                    if (list3[0].ToString() == "true" || list3[0].ToString() == "True")
                    {
                        btnConfirmSelling.Enabled = true;
                    }
                    else 
                    { 
                        btnConfirmSelling.Enabled = false; 
                    }

                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    mdiParent.EnablePrintCommand(true);
                    MainMenuPrintStatus = true;
                    gpbShowData.Enabled = true;
                    visibleForm(true);
                }
                else
                {
                    Message(MessageList.Error.E0004, " ข้อมูลที่ค้นหา");
                    clearForm();
                    visibleForm(false);
                }

                if (UserProfile.IsReadOnly("miVehicle", "miVehicleSellingPlan"))
                {
                    btnExit.Enabled = false;
                    btnConfirmSelling.Enabled = false;
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

            try
            {
                List<VehicleInfo> vehicleList = new List<VehicleInfo>();
                vehicleNo = "";

                for (int i = 0; i < dtgSellingPlan.Rows.Count; i++)
                {
                    vehicleList.Add((VehicleInfo)dtgSellingPlan.Rows[i].Tag);

                    if (dtgSellingPlan[colNo.Index, i].Value.ToString() == "True" || 
                        dtgSellingPlan[colNo.Index, i].Value.ToString() == "true")
                    {
                        if (dtgSellingPlan[colSellingDate.Index, i].Value == null)
                        {
                            if (vehicleNo == "")
                            {
                                vehicleNo += "'" + vehicleList[i].VehicleNo.ToString() + "'";
                            }
                            else
                            {
                                vehicleNo += ",'" + vehicleList[i].VehicleNo.ToString() + "'";
                            }
                        }
                    }
                }

                if (vehicleNo != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();
                    FrmSellingPlanReport frmReport = new FrmSellingPlanReport(dtpSellingDate.Value.Date, vehicleNo);

                    frmReport.Show();

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageForm(ex);
            }
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region Form Event

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        private void dtgSellingPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dtgSellingPlan[0, e.RowIndex].Value.ToString() == "True" || dtgSellingPlan[0, e.RowIndex].Value.ToString() == "true")
                {
                    confirmEvent();
                }
            }
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            if (btnConfirmSelling.Enabled == true)
            {
                confirmEvent();
            }
        }

        private void mniPrint_Click(object sender, EventArgs e)
        {
            if (btnExit.Enabled == true)
            {
                if (dtgSellingPlan.Rows.Count > 0)
                {
                    PrintForm();
                }
                else
                {
                    Message(MessageList.Error.E0005, "ข้อมูล");
                    btnShow.Focus();
                }
            }
        }

        private void dtgSellingPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == colNo.Index)
            {
                if (dtgSellingPlan[colNo.Index, e.RowIndex].Value.ToString() == "True" || dtgSellingPlan[colNo.Index, e.RowIndex].Value.ToString() == "true")
                {
                    deleteData(e.RowIndex);
                }
                else
                {
                    addData(e.RowIndex);
                }
            }
        }

        private void dtgSellingPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dtgSellingPlan[colNo.Index, e.RowIndex].Value.ToString() == "True" || dtgSellingPlan[colNo.Index, e.RowIndex].Value.ToString() == "true")
                {
                    btnConfirmSelling.Enabled = true;
                }
                else
                {
                    btnConfirmSelling.Enabled = false;
                }
            }
        }

        private void btnConfirmSelling_Click(object sender, EventArgs e)
        {
            confirmEvent();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                for (int i = 0; i < dtgSellingPlan.Rows.Count; i++)
                {
                    if (dtgSellingPlan[colNo.Index, i].Value.ToString() == "False" || dtgSellingPlan[colNo.Index, i].Value.ToString() == "false")
                    {
                        addDataAll(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dtgSellingPlan.Rows.Count; i++)
                {
                    if (dtgSellingPlan[colNo.Index, i].Value.ToString() == "True" || dtgSellingPlan[colNo.Index, i].Value.ToString() == "true")
                    {
                        deleteDataAll(i);
                    }
                }
            }
        } 
        
        #endregion
    }
}