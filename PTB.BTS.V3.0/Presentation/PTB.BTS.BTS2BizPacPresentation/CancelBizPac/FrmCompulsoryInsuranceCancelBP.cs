using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade;
using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmCompulsoryInsuranceCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmCompulsoryInsuranceCancelBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new CompulsoryInsuranceBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelCompulsoryInsurance"); ;
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptCompulsoryExpense objfrm = new FrmrptCompulsoryExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_CANCEL_FILE_NAME;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelCompulsoryInsurance");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelCompulsoryInsurance");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�����Ţ�.�.�."; }
        }

        public override string PaidToColumnName
        {
            get { return "���ͺ���ѷ��Сѹ"; }
        }

        public override string RemarkColumnName
        {
            get { return "�����˵�"; }
        }

        public override string AmountColumnName
        {
            get { return "��� �.�.�."; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "�Ţ���㺡ӡѺ����"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "�ѹ���㺡ӡѺ����"; }
        }
        #endregion

    }
}