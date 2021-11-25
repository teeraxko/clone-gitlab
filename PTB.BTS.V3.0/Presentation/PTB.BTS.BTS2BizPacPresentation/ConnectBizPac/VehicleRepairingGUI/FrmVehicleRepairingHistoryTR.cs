using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.BTS2BizPacFacade.RepairingBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmVehicleRepairingHistoryTR : FrmVehicleRepairingHistoryBP
    {
        //============================== Constructor ==============================
        public FrmVehicleRepairingHistoryTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new VehicleRepairingTRFacade();
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleRepairing");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptVehicleRepairingExpense objfrm = new FrmrptVehicleRepairingExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_TEST_REPORT;
            objfrm.Show();
        }
    }
}