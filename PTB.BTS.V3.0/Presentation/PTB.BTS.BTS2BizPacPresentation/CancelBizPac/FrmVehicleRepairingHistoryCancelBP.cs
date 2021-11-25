using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.RepairingBPFacade;
using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;
using System.Data.SqlClient;
using SystemFramework.AppException;
using Entity.VehicleEntities;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmVehicleRepairingHistoryCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmVehicleRepairingHistoryCancelBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleRepairingBPFacade();

            try
            {
                isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelVehicleRepairing");
                cboSelectCheck.DataSource = facadeBTS2BizPacConnect.DataSourceGarage;
                lblSelectName.Text = "ชื่อศูนย์ซ่อม";
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

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptVehicleRepairingExpense objfrm = new FrmrptVehicleRepairingExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_CANCEL_FILE_NAME;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelVehicleRepairing");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelVehicleRepairing");
                return lblFormName.Text;
            }
        }

        protected override void visibleForm(bool visible)
        {
            base.visibleForm(visible);
            gpbSelectCheck.Visible = visible;
        }

        protected override void SelectAll(int select)
        {
            Garage garage = new Garage();
            if (cboSelectCheck.Text.Trim() != "")
            {
                garage = (Garage)cboSelectCheck.SelectedItem;
            }
            else
            {
                garage = null;
            }

            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                if (garage == null)
                {
                    dtgBizPacConnect[1, i].Value = select.ToString();
                }
                else
                {
                    if (dtgBizPacConnect[8, i].Value.ToString() == garage.Code)
                    {
                        dtgBizPacConnect[1, i].Value = select.ToString();
                    }
                }
            }

            garage = null;
        }

        protected override string GetSelectCheck(PTB.BTS.BTS2BizPacEntity.IBTS2BizPacHeader value)
        {
            Garage garage = ((RepairingBase)value).Garage;
            return (garage != null) ? garage.Code : string.Empty;
        }

        public override string DocNoColumnName
        {
            get { return "เลขที่การซ่อม"; }
        }

        public override string PaidToColumnName
        {
            get { return "ชื่อศูนย์บริการ"; }
        }

        public override string RemarkColumnName
        {
            get { return "หมายเหตุ"; }
        }

        public override string AmountColumnName
        {
            get { return "ค่าซ่อม"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "เลขที่ใบกำกับภาษี"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "วันที่ออกใบกำกับภาษี"; }
        }
        #endregion

    }
}

