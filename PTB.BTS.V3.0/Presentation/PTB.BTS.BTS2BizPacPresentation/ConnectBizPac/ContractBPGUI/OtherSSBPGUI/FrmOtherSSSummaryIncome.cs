using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.PTB.BTS.BTS2BizPacPresentation.ConnectBizPac.ContractBPGUI;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmOtherSSSummaryIncome : FrmSummaryIncomeBase
    {
        public FrmOtherSSSummaryIncome()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new OtherSSSummaryIncomeFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge");
            this.title = "Rerun " + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge");
        }

        //============================== Protected method ==============================
        protected override void PrintReport(DateTime connectDate)
        {
            FrmrptOtherServiceStaff objfrm = new FrmrptOtherServiceStaff();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.FileName = BP_RERUN_REPORT;
            objfrm.ConnectDate = connectDate;
            objfrm.Show();
        }

        protected override DateTime GetDate
        {
            get
            {
                return dtpDateFrom.Value.AddMonths(1);
            }
        }
    }
}