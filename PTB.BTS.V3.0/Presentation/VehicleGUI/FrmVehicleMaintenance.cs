using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using Facade.VehicleFacade;
using Entity.VehicleEntities;
using ictus.Common.Entity.General;
using SystemFramework.AppException;
using System.Data.SqlClient;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
    public partial class frmVehicleMaintenance : Presentation.VehicleGUI.frmVehicleRepairingBase
    {
        public frmVehicleMaintenance()
            : base()
        {
            InitializeComponent();
            facadeRepairing = new VehicleMaintenanceFacade();
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceHistory");
            setPermission(UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceHistory"));
        }

        #region Protected Method

        protected override void newfrmEntry()
        {
            frmEntry = new frmVehicleMaintenanceEntry();
        }

        protected override void visibleDetail(bool value)
        {
            dtgMaintenance.Visible = value;
        }

        protected override void clearDetail()
        {
            dtgMaintenance.Rows.Clear();
            enableButton(false);
        }

        protected void bindDetail(int row, RepairingInfoBase value)
        {
            dtgMaintenance[0, row].Value = value.EntityKey;
            dtgMaintenance[1, row].Value = value.RepairingNo;

            if (value.TaxInvoiceDate == NullConstant.DATETIME)
            {
                dtgMaintenance[2, row].Value = null;
            }
            else
            {
                dtgMaintenance[2, row].Value = value.TaxInvoiceDate;
            }
            dtgMaintenance[3, row].Value = value.TaxInvoiceNo;

            dtgMaintenance[4, row].Value = value.DriverName;
            dtgMaintenance[5, row].Value = value.Garage.ShortName;
            if (value.RepairPeriod.From == NullConstant.DATETIME)
            {
                dtgMaintenance[6, row].Value = "";
            }
            else
            {
                dtgMaintenance[6, row].Value = value.RepairPeriod.From;
            }
            if (value.RepairPeriod.To == NullConstant.DATETIME)
            {
                dtgMaintenance[7, row].Value = "";
            }
            else
            {
                dtgMaintenance[7, row].Value = value.RepairPeriod.To;
            }
            dtgMaintenance[8, row].Value = value.Mileage;
            dtgMaintenance[9, row].Value = value.TotalAmount;
        }

        protected override void displayDetail()
        {
            dtgMaintenance.Rows.Clear();

            if (ObjVehicleRepairing.Count > 0)
            {
                mdiParent.RefreshMasterCount();
                for (int i = 0; i < ObjVehicleRepairing.Count; i++)
                {
                    dtgMaintenance.RowCount++;
                    bindDetail(i, ObjVehicleRepairing[i]);
                }
                enableButton(true);
                dtgMaintenance.CurrentCell = dtgMaintenance.Rows[dtgMaintenance.RowCount - 1].Cells[1];
            }
            else
            {
                clearDetail();
            }
        }

        //==============================  Base Event   ==============================
        protected override void EditEvent()
        {
            try
            {
                newfrmEntry();
                frmEntry.FormParent = this;
                string key = dtgMaintenance[0, dtgMaintenance.CurrentRow.Index].Value.ToString();
                frmEntry.InitEditAction(facadeRepairing.VehicleRepairing[key]);
                frmEntry.ShowDialog();
            }
            catch (TransactionException ex)
            {
                Message(ex);
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

        protected override void DeleteEvent()
        {
            try
            {
                string key = dtgMaintenance[0, dtgMaintenance.CurrentRow.Index].Value.ToString();
                Maintenance maintenance = (Maintenance)facadeRepairing.VehicleRepairing[key];

                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    if (facadeRepairing.DeleteRepairing(maintenance))
                    {
                        if (dtgMaintenance.RowCount > 1)
                        {
                            dtgMaintenance.Rows.RemoveAt(dtgMaintenance.CurrentRow.Index);
                        }
                        else
                        {
                            clearDetail();
                        }
                        mdiParent.RefreshMasterCount();
                    }
                }
            }
            catch (TransactionException ex)
            {
                Message(ex);
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

        #region Public method
        public override bool AddRow(RepairingInfoBase value)
        {
            if (base.AddRow(value))
            {
                dtgMaintenance.RowCount++;
                bindDetail(dtgMaintenance.RowCount - 1, value);
                dtgMaintenance.CurrentCell = dtgMaintenance.Rows[dtgMaintenance.RowCount - 1].Cells[1];
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public override bool EditRow(RepairingInfoBase value)
        {
            if (base.EditRow(value))
            {
                bindDetail(dtgMaintenance.CurrentRow.Index, value);
                return true;
            }
            return false;
        }

        public override int MasterCount()
        {
            return ObjVehicleRepairing.Count;
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceHistory");
        }
        #endregion

        #region Form Event
        private void dtgMaintenance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditEvent();
            }
        } 
        #endregion
    }
}