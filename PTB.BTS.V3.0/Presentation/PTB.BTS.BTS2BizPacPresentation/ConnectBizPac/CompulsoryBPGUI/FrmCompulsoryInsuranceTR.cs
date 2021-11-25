using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.BTS2BizPacPresentation;
using PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmCompulsoryInsuranceTR : FrmCompulsoryInsuranceBP
    {
        //============================== Constructor ==============================
        public FrmCompulsoryInsuranceTR()
            : base()
        {
            InitializeComponent();
            lblFormName.ForeColor = System.Drawing.Color.Black;
            facadeBTS2BizPacConnect = new CompulsoryInsuranceTRFacade();
        }

        //============================== Public method ==============================
        public override string Title
        {
            get
            {
                lblFormName.Text = "∑¥ Õ∫" + UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectCompulsoryInsurance");
                return lblFormName.Text;
            }
        }

        protected override void PrintReport()
        {
            FrmrptCompulsoryExpense objfrm = new FrmrptCompulsoryExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_TEST_REPORT;
            objfrm.ConnectDate = dtpDateDetail.Value;
            objfrm.Show();
        }
    }
}

