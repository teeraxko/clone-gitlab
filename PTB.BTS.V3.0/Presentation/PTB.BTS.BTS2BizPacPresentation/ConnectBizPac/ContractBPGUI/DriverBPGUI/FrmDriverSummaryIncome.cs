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
    public partial class FrmDriverSummaryIncome : FrmSummaryIncomeBase
    {
        public FrmDriverSummaryIncome() : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new DriverSummaryIncomeFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectDriverContractCharge");
            this.title = "Rerun " + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectDriverContractCharge");
        }

        //============================== Protected method ==============================
        protected override void PrintReport(DateTime connectDate)
        {
            FrmrptDrivingService objfrm = new FrmrptDrivingService();
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