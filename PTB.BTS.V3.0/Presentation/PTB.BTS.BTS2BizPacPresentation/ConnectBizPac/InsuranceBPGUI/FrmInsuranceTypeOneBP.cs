using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade;

using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmInsuranceTypeOneBP : FrmBizPacConnectBase
    {
        //============================== Constructor ==============================
        public FrmInsuranceTypeOneBP(): base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new InsuranceTypeOneBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectInsuranceTypeOne");
            gpbDateDetail.Visible = true;
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptInsuranceExpense objfrm = new FrmrptInsuranceExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = base.fileName;
            objfrm.isSaveFile = true;
            objfrm.ConnectDate = dtpDateDetail.Value.Date;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectInsuranceTypeOne");
        }

        public override string Title
        {
            get 
            { 
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectInsuranceTypeOne");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�����Ţ��������"; }
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
            get { return "���»�Сѹ"; }
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