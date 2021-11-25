using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.BizPac;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmCancelBizLoan : PTB.PIS.Welfare.WindowsApp.BizPacGUI.FrmCancelBizBase
    {
        public FrmCancelBizLoan()
            : base()
        {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelLoan");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelLoan");
        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelLoan");
        }

        public override int MasterCount()
        {
            return this.details.Count;
        }

        protected override void RetiveData()
        {
            if (rbtnDate.Checked)
                this.details = LoanBizPacFacade.GetConnectHistoryByDate(this.fromDateTime, this.toDateTime);
            else
                this.details = LoanBizPacFacade.GetConnectHistoryByRefNo(txtRefNo.Text.Trim());
        }

        protected override void Submit()
        {
            List<ConnectBizPacDetail> details = this.GetSelectData();
            bool connectComplete = LoanBizPacFacade.CancelBiz(details);
            if (connectComplete)
            {
                base.Submit();
            }
        }

    }
}

