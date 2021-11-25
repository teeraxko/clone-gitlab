using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsMedicalAid;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace PTB.PIS.Welfare.ReportApp.GUI.MedicalAidGUI
{
    //  public partial class FrmReportMedicalAid : PTB.PIS.Welfare.ReportApp.GUI.FrmReportBase {
    public partial class FrmReportMedicalAid : FrmReportBase
    {
        public FrmReportMedicalAid()
            : base()
        {
            InitializeComponent();
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            DateTime fromEmployedDate, toEmployedDate;

            if (chkEmployedDate.Checked)
            {
                fromEmployedDate = dtpFromEmploy.Value.Date;
                toEmployedDate = dtpToEmploy.Value.Date;
            }
            else
            {
                fromEmployedDate = DateTime.MinValue.Date;
                toEmployedDate = DateTime.MaxValue.Date;
            }

            ReportMedicalAid report = new ReportMedicalAid();
            report.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date, fromEmployedDate, toEmployedDate, this.txtEmployeeNo.Text.Trim());
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
        }

        private void chkEmployedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployedDate.Checked)
            {
                dtpFromEmploy.Enabled = true;
                dtpToEmploy.Enabled = true;
            }
            else
            {
                dtpFromEmploy.Enabled = false;
                dtpToEmploy.Enabled = false;
            }
        }

        private void chkEmpNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmpNo.Checked)
            {
                txtEmployeeNo.Enabled = true;
            }
            else
            {
                txtEmployeeNo.Enabled = false;
                txtEmployeeNo.Clear();
            }
        }

        private void FrmReportMedicalAid_Load(object sender, EventArgs e)
        {
            this.dtpDateFrom.Value = DateTime.Now.Date;
            this.dtpDateTo.Value = DateTime.Now.Date;
            chkEmployedDate.Checked = false;
            chkEmpNo.Checked = false;
        }
    }
}

