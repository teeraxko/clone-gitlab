using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ExcessBPFacade;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmVehicleExcessBP : FrmBizPacConnectBase
    {
        //============================== Constructor ==============================
        public FrmVehicleExcessBP() : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleExcessBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectVehicleExcess");
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptExcessExpense objfrm = new FrmrptExcessExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = base.fileName;
            objfrm.Show();
        }


        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectVehicleExcess");
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleExcess");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "เลขที่อุบัติเหตุ"; }
        }

        public override string PaidToColumnName
        {
            get { return "ชื่อบริษัทประกัน/ศูนย์บริการ"; }
        }

        public override string RemarkColumnName
        {
            get { return "หมายเหตุ"; }
        }

        public override string AmountColumnName
        {
            get { return "ค่า Excess"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "เลขที่ใบเสร็จรับเงิน"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "วันที่ใบเสร็จรับเงิน"; }
        }
        #endregion
    }
}

