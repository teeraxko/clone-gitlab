using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.GUI.PI {
//    public partial class FrmReportSalaryEmployee : Form {
    public partial class FrmReportSalaryEmployee : FrmReportBase  {
        ReportSalaryEmployee report;
        public FrmReportSalaryEmployee()
            : base() {
            InitializeComponent();
            rbtnNoSpecFrom.Checked = true;
            rbtnNoSpecTo.Checked = true;
            this.report = new ReportSalaryEmployee();
        }

        private void rbtnNoSpecFrom_CheckedChanged(object sender, EventArgs e) {
            if (rbtnNoSpecFrom.Checked) {
                numSalaryFrom.Value = 0;
                numSalaryFrom.Enabled = false;
            } else {
                numSalaryFrom.Enabled = true;
            }
        }

        private void rbtnNoSpecTo_CheckedChanged(object sender, EventArgs e) {
            if (rbtnNoSpecTo.Checked) {
                numSalaryTo.Value = 0;
                numSalaryTo.Enabled = false;
            } else {
                numSalaryTo.Enabled = true;
            }
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            report.SetCriteria(this.BuildSelectionFormula());
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 

        }

        private string BuildSelectionFormula() {
            string formular;
            if (rbtnNoSpecFrom.Checked) {
                formular = "";
            } else {
                formular = " {Employee_Salary.Basic_Salary} >= " + numSalaryFrom.Value.ToString() + " ";
            }

            if (rbtnSpecTo.Checked) {
                if (rbtnSpecFrom.Checked) {
                    formular = formular + " and ";
                }
                formular = formular + " {Employee_Salary.Basic_Salary} <= " + numSalaryTo.Value.ToString() + " ";
            }
            return formular;
        }

    }
}