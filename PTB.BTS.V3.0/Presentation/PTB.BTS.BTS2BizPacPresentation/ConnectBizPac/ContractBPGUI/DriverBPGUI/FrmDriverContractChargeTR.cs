using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmDriverContractChargeTR : FrmDriverContractChargeBP
    {
        //============================== Constructor ==============================
        public FrmDriverContractChargeTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new DriverContractChargeTRFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBPPreConnectDriverCharge");
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBPPreConnectDriverCharge");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptDrivingService objfrm = new FrmrptDrivingService();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.FileName = BP_TEST_REPORT;
            objfrm.ConnectDate = DateTime.Today.AddMonths(-1);
            objfrm.Show();
        }
    }
}