using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.BTS2BizPacPresentation;
using PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmInsuranceTypeOneTR : FrmInsuranceTypeOneBP
    {
        //============================== Constructor ==============================
        public FrmInsuranceTypeOneTR() : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new InsuranceTypeOneTRFacade();
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectInsuranceTypeOne");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptInsuranceExpense objfrm = new FrmrptInsuranceExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_TEST_REPORT;
            objfrm.ConnectDate = dtpDateDetail.Value;
            objfrm.Show();
        }
    }
}