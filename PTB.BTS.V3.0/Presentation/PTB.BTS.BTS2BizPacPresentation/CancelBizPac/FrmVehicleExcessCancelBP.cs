using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ExcessBPFacade;
using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmVehicleExcessCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmVehicleExcessCancelBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleExcessBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelVehicleExcess"); 
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptExcessExpense objfrm = new FrmrptExcessExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_CANCEL_FILE_NAME;
            objfrm.Show();
        }


        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelVehicleExcess");
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelVehicleExcess");
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

