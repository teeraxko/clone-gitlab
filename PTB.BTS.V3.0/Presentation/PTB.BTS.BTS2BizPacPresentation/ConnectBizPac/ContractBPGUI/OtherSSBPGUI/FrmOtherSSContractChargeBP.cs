using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmOtherSSContractChargeBP : FrmBizPacChargeConnectBase
    {
        //============================== Constructor ==============================
        public FrmOtherSSContractChargeBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new OtherSSContractChargeBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge"); ;
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptOtherServiceStaff objfrm = new FrmrptOtherServiceStaff();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.FileName = base.fileName;
            objfrm.IsSaveFile = true;
            objfrm.IsTestConnect = false;
            objfrm.ConnectDate = DateTime.Today.AddMonths(-1);
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get 
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�����Ţ�ѭ��"; }
        }

        public override string PaidToColumnName
        {
            get { return "���ͺ���ѷ�١���"; }
        }

        public override string RemarkColumnName
        {
            get { return "�����˵�"; }
        }

        public override string AmountColumnName
        {
            get { return "������"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "�ѹ�����������ѭ��"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "�ѹ�������ش�ѭ��"; }
        }
        #endregion
    }
}