using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.BTS2BizPacFacade.ExcessBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmVehicleExcessTR : FrmVehicleExcessBP
    {
        //============================== Constructor ==============================
        public FrmVehicleExcessTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new VehicleExcessTRFacade();
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleExcess");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptExcessExpense objfrm = new FrmrptExcessExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_TEST_REPORT;
            objfrm.Show();
        }
    }
}