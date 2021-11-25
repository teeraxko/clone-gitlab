//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using Entity.VehicleEntities;
//using Entity.CommonEntity;

//using Facade.VehicleFacade;

//using SystemFramework.AppException;
//using SystemFramework.AppMessage;
//using SystemFramework.AppConfig;

//using ictus.Common.Entity.General;

//namespace Presentation.VehicleGUI
//{
//    public class TMPfrmVehicleMaintenance : Presentation.VehicleGUI.frmVehicleRepairingBase
//    {
//        #region Designer generated code
//        //private FarPoint.Win.Spread.FpSpread fpsVehicleMaintenance;
//        //private FarPoint.Win.Spread.SheetView fpsVehicleMaintenance_Sheet1;
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if (components != null) 
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        private void InitializeComponent()
//        {
//            // 
//            // cmdDelete
//            // 
//            this.cmdDelete.Name = "cmdDelete";
//            // 
//            // cmdEdit
//            // 
//            this.cmdEdit.Name = "cmdEdit";
//            // 
//            // cmdAdd
//            // 
//            this.cmdAdd.Name = "cmdAdd";
//            // 
//            // frmVehicleMaintenance
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(1024, 486);
//            this.Name = "frmVehicleMaintenance";
//            this.Controls.SetChildIndex(this.cmdAdd, 0);
//            this.Controls.SetChildIndex(this.cmdEdit, 0);
//            this.Controls.SetChildIndex(this.cmdDelete, 0);
//            this.ResumeLayout(false);
//        }
//        #endregion

//        #region - Private -
////		private bool isReadonly = true;
//        #endregion

//        //==============================  Constructor  ==============================
//        public TMPfrmVehicleMaintenance()
//        {
//            InitializeComponent();
//            facadeRepairing = new VehicleMaintenanceFacade();
//            //this.Text = "ข้อมูลซ่อมบำรุง";
//            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceHistory");
//            setPermission(UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceHistory"));
//        }

//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceHistory");
//        }

//        #region - Private Method -
//        protected override void newfrmEntry()
//        {
//            frmEntry = new frmVehicleMaintenanceEntry();
//        }

//        protected override void visibleDetail(bool value)
//        {
//            fpsVehicleMaintenance.Visible = value;
//        }

//        protected override void clearDetail()
//        {
//            fpsVehicleMaintenance_Sheet1.RowCount = 0;
//            enableButton(false);
//        }

//        protected void bindDetail(int row, RepairingInfoBase value)
//        {
//            fpsVehicleMaintenance_Sheet1.Cells[row, 0].Text = value.EntityKey;
//            fpsVehicleMaintenance_Sheet1.Cells[row, 1].Text = value.RepairingNo;

//            if(value.TaxInvoiceDate==NullConstant.DATETIME)
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 2].Text = "";
//            }
//            else
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 2].Text = value.TaxInvoiceDate.ToShortDateString();
//            }
//            fpsVehicleMaintenance_Sheet1.Cells[row, 3].Text = value.TaxInvoiceNo;

//            fpsVehicleMaintenance_Sheet1.Cells[row, 4].Text = value.DriverName;
//            fpsVehicleMaintenance_Sheet1.Cells[row, 5].Text = value.Garage.ShortName;
//            if(value.RepairPeriod.From==NullConstant.DATETIME)
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 6].Text = "";
//            }
//            else
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 6].Text = value.RepairPeriod.From.ToShortDateString();
//            }
//            if(value.RepairPeriod.To==NullConstant.DATETIME)
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 7].Text = "";
//            }
//            else
//            {
//                fpsVehicleMaintenance_Sheet1.Cells[row, 7].Text = value.RepairPeriod.To.ToShortDateString();
//            }
//            fpsVehicleMaintenance_Sheet1.Cells[row, 8].Text = value.Mileage.ToString();
//            fpsVehicleMaintenance_Sheet1.Cells[row, 9].Text = value.TotalAmount.ToString();
//        }

//        protected override void displayDetail()
//        {
//            fpsVehicleMaintenance_Sheet1.RowCount = ObjVehicleRepairing.Count;
//            if(ObjVehicleRepairing.Count>0)
//            {
//                mdiParent.RefreshMasterCount();
//                for(int i=0; i<ObjVehicleRepairing.Count; i++)
//                {
//                    bindDetail(i, ObjVehicleRepairing[i]);
//                }
//                enableButton(true);
//                fpsVehicleMaintenance_Sheet1.SetActiveCell(fpsVehicleMaintenance_Sheet1.RowCount, 0);
//            }
//            else
//            {
//                clearDetail();
//            }
//        }
//        #endregion

//        //==============================  Base Event   ==============================
//        protected override void EditEvent()
//        {
//            try
//            {
//                newfrmEntry();
//                frmEntry.FormParent = this;
//                int row = fpsVehicleMaintenance_Sheet1.ActiveRow.Index;
//                string key = fpsVehicleMaintenance_Sheet1.Cells[row,0].Text;
//                frmEntry.InitEditAction(facadeRepairing.VehicleRepairing[key]);
//                frmEntry.ShowDialog();	
//            }
//            catch(TransactionException ex)
//            {
//                Message(ex);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }

//        protected override void DeleteEvent()
//        {
//            try
//            {
//                int row = fpsVehicleMaintenance_Sheet1.ActiveRow.Index;
//                string key = fpsVehicleMaintenance_Sheet1.Cells[row,0].Text;				
//                Maintenance maintenance = (Maintenance)facadeRepairing.VehicleRepairing[key];

//                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
//                {
//                    if(facadeRepairing.DeleteRepairing(maintenance))
//                    {
//                        if(fpsVehicleMaintenance_Sheet1.RowCount>1)
//                        {
//                            fpsVehicleMaintenance_Sheet1.Rows.Remove(fpsVehicleMaintenance_Sheet1.ActiveRow.Index, 1);
//                        }
//                        else
//                        {
//                            clearDetail();
//                        }
//                        mdiParent.RefreshMasterCount();
//                    }	
//                }
//            }
//            catch(TransactionException ex)
//            {
//                Message(ex);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }
//        //============================== Public Method ==============================
//        public override bool AddRow(RepairingInfoBase value)
//        {
//            if(base.AddRow(value))
//            {
//                fpsVehicleMaintenance_Sheet1.RowCount++;
//                bindDetail(fpsVehicleMaintenance_Sheet1.RowCount-1, value);
//                fpsVehicleMaintenance_Sheet1.SetActiveCell(fpsVehicleMaintenance_Sheet1.RowCount, 0);
//                mdiParent.RefreshMasterCount();
//                return true;
//            }
//            return false;
//        }

//        public override bool EditRow(RepairingInfoBase value)
//        {
//            if(base.EditRow(value))
//            {
//                bindDetail(fpsVehicleMaintenance_Sheet1.ActiveRow.Index, value);	
//                return true;
//            }
//            return false;
//        }		
//        //		==============================Public method ==============================
//        public override int MasterCount()
//        {
//            return ObjVehicleRepairing.Count;
//        }


//        //==============================     event     ==============================
//        //private void fpsVehicleMaintenance_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
//        //{
//        //    if(!e.ColumnHeader)
//        //    {
//        //        EditEvent();
//        //    }
//        //}

//    }
//}