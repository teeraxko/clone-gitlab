using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.GUI.Contract
{
    public partial class FrmRenewalNotice : Form
    {
        public FrmRenewalNotice()
        {
            InitializeComponent();
        }

        private void FrmRenewalNotice_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmReportRenewalNotice objForm = new FrmReportRenewalNotice(dtpEndDate.Value, ContractNo);
            objFrm.MdiParent = this;
            objFrm.Show();
        }



    }
}
