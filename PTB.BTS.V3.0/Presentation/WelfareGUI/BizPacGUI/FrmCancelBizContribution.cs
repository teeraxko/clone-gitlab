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
    public partial class FrmCancelBizContribution : PTB.PIS.Welfare.WindowsApp.BizPacGUI.FrmCancelBizBase
    {
        public FrmCancelBizContribution()
            : base()
        {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelContribution");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelContribution");
        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelContribution");
        }

        public override int MasterCount()
        {
            return this.details.Count;
        }


        protected override void RetiveData()
        {
            if (rbtnDate.Checked)
                this.details = ContributionBizPacFacade.GetConnectHistoryByDate(this.fromDateTime, this.toDateTime);
            else
                this.details = ContributionBizPacFacade.GetConnectHistoryByRefNo(txtRefNo.Text.Trim());
        }

        protected override void Submit()
        {
            List<ConnectBizPacDetail> details = this.GetSelectData();
            bool connectComplete = ContributionBizPacFacade.CancelBiz(details);
            if (connectComplete)
            {
                base.Submit();
            }
        }



    }
}

