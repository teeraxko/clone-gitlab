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

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI {
    public partial class FrmCancelBizMedicalAid : PTB.PIS.Welfare.WindowsApp.BizPacGUI.FrmCancelBizBase {
        public FrmCancelBizMedicalAid():base() {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelMedicalAid");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelMedicalAid");
        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelMedicalAid");
        }

        public override int MasterCount()
        {
            return this.details.Count;
        }

        protected override void RetiveData() {
            if (rbtnDate.Checked)
                this.details = MedicalAidBizPacFacade.GetConnectHistoryByDate(this.fromDateTime, this.toDateTime);
            else
                this.details = MedicalAidBizPacFacade.GetConnectHistoryByRefNo(txtRefNo.Text.Trim());
        }

        protected override void Submit() {
            List<ConnectBizPacDetail> details = this.GetSelectData();
            bool connectComplete = MedicalAidBizPacFacade.CancelBiz(details);
            if (connectComplete) {
                base.Submit();
            }
        }

    }
}

