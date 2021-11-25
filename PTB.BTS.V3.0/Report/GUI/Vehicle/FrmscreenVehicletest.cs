using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.GUI.Vehicle
{
    public partial class FrmscreenVehicletest : FrmReportBase
    {
        public FrmscreenVehicletest()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmReportVehicleSellingDepreciation objfrm = new FrmReportVehicleSellingDepreciation(dtpSellingDate.Value , textBox1.Text);
            objfrm.Show();
        }

        private void FrmscreenVehicletest_Load(object sender, EventArgs e)
        {
            dtpSellingDate.Value = DateTime.Now.Date;
            textBox1.Text = string.Empty;
        }

     
    }
}
