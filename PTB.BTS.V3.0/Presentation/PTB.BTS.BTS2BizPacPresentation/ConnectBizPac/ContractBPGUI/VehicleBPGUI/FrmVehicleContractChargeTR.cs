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
    public partial class FrmVehicleContractChargeTR : FrmVehicleContractChargeBP
    {
        //============================== Constructor ==============================
        public FrmVehicleContractChargeTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new VehicleContractChargeTRFacade();
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptVehicleCharge objfrm = new FrmrptVehicleCharge();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_TEST_REPORT;
            objfrm.Show();
        }
    }
}