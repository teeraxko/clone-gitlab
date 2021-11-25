using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmCompulsoryInsuranceBP : FrmBizPacConnectBase
    {
        //============================== Constructor ==============================
        public FrmCompulsoryInsuranceBP() : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new CompulsoryInsuranceBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectCompulsoryInsurance");
            gpbDateDetail.Visible = true;
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptCompulsoryExpense objfrm = new FrmrptCompulsoryExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = base.fileName;
            objfrm.isSaveFile = true;
            objfrm.ConnectDate = dtpDateDetail.Value.Date;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectCompulsoryInsurance");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get 
            { 
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectCompulsoryInsurance");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "หมายเลขพ.ร.บ."; }
        }

        public override string PaidToColumnName
        {
            get { return "ชื่อบริษัทประกัน"; }
        }

        public override string RemarkColumnName
        {
            get { return "หมายเหตุ"; }
        }

        public override string AmountColumnName
        {
            get { return "ค่า พ.ร.บ."; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "เลขที่ใบกำกับภาษี"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "วันที่ใบกำกับภาษี"; }
        }
        #endregion

    }
}