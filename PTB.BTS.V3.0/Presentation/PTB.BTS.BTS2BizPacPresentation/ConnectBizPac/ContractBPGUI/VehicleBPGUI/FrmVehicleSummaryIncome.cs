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
    public partial class FrmVehicleSummaryIncome : FrmSummaryIncomeBase
    {
        public FrmVehicleSummaryIncome() : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleSummaryIncomeFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
            this.title = "Rerun " + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
        }

        //============================== Protected method ==============================
        protected override void PrintReport(DateTime connectDate)
        {
            FrmrptVehicleCharge objfrm = new FrmrptVehicleCharge();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_RERUN_REPORT;
            objfrm.ConnectDate = connectDate;
            objfrm.Show();
        }
    }
}