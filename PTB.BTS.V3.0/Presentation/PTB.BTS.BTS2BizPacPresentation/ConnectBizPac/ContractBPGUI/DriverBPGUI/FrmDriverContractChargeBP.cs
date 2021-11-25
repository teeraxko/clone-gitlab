using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;
using SystemFramework.AppMessage;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmDriverContractChargeBP : FrmBizPacChargeConnectBaseNew
    {
        #region Private Variable
        private const int MAX_REPORT_PAGES = 6;
        #endregion

        #region Constructor
        public FrmDriverContractChargeBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new DriverContractChargeBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectDriverContractCharge");
        } 
        #endregion

        #region Protected Override
        protected override void PrintReport()
        {
            FrmrptDrivingService objfrm = new FrmrptDrivingService();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.FileName = base.fileName;
            objfrm.IsSaveFile = true;
            objfrm.IsTestConnect = false;
            objfrm.ConnectDate = DateTime.Today.AddMonths(-1);
            objfrm.Show();
        }

        protected override bool ValidateConnect()
        {
            bool result = base.ValidateConnect();

            result &= ValidateReport();           

            return result;
        }
        #endregion

        #region - Override base -
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectDriverContractCharge");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get 
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectDriverContractCharge");
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

        #region Private Method
        private bool ValidateReport()
        {
            int count = 0;

            foreach (Form item in ((Presentation.frmMain)this.MdiParent).MdiChildren)
            {
                if (item is FrmrptDrivingService)
                {
                    count++;
                }
            }

            if (count > MAX_REPORT_PAGES)
            {
                errorMessage(string.Format(MessageResource.E0012, "�������§ҹ��", "��˹�Ҩ��ʴ���§ҹ�Թ�ӹǹ����˹� \n", "�Դ˹�Ҩ���§ҹ��� Connect ������������"));
                return false;
            }

            return true;
        }
        #endregion
    }
}