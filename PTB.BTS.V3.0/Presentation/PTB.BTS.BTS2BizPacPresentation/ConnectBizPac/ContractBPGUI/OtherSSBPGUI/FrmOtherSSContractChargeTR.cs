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
    public partial class FrmOtherSSContractChargeTR : FrmOtherSSContractChargeBP
    {
        //============================== Constructor ==============================
        public FrmOtherSSContractChargeTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new OtherSSContractChargeTRFacade();

        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectServiceStaffContractCharge");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptOtherServiceStaff objfrm = new FrmrptOtherServiceStaff();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.FileName = BP_TEST_REPORT;
            objfrm.ConnectDate = DateTime.Today.AddMonths(-1);
            objfrm.Show();
        }
    }
}