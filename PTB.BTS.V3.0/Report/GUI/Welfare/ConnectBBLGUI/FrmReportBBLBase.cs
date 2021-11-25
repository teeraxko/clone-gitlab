using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportConnectBBL;

namespace PTB.PIS.Welfare.ReportApp.GUI.ConnectBBLGUI {
    public partial class FrmReportBBLBase : FrmReportBase {
        protected ReportConnectBBLBase reportConnectBBLBase;
        public FrmReportBBLBase():base() {
            InitializeComponent();
        }

        private void LoadReport() {
            Application.DoEvents();
            this.crvMain.ReportSource = reportConnectBBLBase.Report;
        }

        private void FrmReportBBLBase_Load(object sender, EventArgs e) {
            LoadReport();
            this.WindowState = FormWindowState.Maximized;
        }
    }
}