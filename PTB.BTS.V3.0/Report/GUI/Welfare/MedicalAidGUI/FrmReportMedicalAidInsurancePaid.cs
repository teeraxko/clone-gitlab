using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Welfare.ReportsMedicalAid;

namespace Report.GUI.Welfare.MedicalAidGUI
{
    public partial class FrmReportMedicalAidInsurancePaid : FrmReportBase
    {
        public FrmReportMedicalAidInsurancePaid()
        {
            InitializeComponent();

            this.dtpDateFrom.Value = DateTime.Today;
            this.dtpDateTo.Value = DateTime.Today;
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ReportMedicalAidInsurancePaid report = new ReportMedicalAidInsurancePaid();
                report.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date, cboMedicalLetter.SelectedIndex, cboMedicalFor.SelectedIndex);
                Application.DoEvents();
                this.crvMain.ReportSource = report.Report;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);            
            }
        }
    }
}