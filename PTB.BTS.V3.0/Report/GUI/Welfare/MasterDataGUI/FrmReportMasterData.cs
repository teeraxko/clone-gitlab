using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsMasterData;

namespace PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI {
    public partial class FrmReportMasterData : FrmReportBase {

        protected  ReportMasterDataBase reportMasterDataBase;
        public FrmReportMasterData():base() {
            InitializeComponent();
        }

        private void FrmReportMasterData_Load(object sender, EventArgs e) {
            LoadReport();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadReport() {
            Application.DoEvents();
            this.crvMain.ReportSource = reportMasterDataBase.Report;
        }

    }
}