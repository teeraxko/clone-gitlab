using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmInsuranceTypeOneCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmInsuranceTypeOneCancelBP(): base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new InsuranceTypeOneBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelInsuranceTypeOne"); 
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptInsuranceExpense objfrm = new FrmrptInsuranceExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_CANCEL_FILE_NAME;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelInsuranceTypeOne");
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelInsuranceTypeOne");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "หมายเลขกรมธรรม์"; }
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
            get { return "เบี้ยประกัน"; }
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