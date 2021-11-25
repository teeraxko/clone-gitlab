using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.BLL;

namespace Report.GUI.PI {
    public partial class FrmReportEmployeeSearch : FrmReportBase {
        public FrmReportEmployeeSearch() :base(){
            InitializeComponent();
        }

        private void btnRetriveData_Click(object sender, EventArgs e) {
            RetiveData();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RetiveData() {
            DataTable employees = EntitiesProvider.EmployeeSerach(txtCitizenID.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim());


            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (DataRow  employee in employees.Rows) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = employee;
                grdData.Rows[rowIndex].Cells["Employee_no"].Value = employee["Employee_no"];
                grdData.Rows[rowIndex].Cells["CitizenID"].Value = employee["ID_Card_No"];
                grdData.Rows[rowIndex].Cells["FullName"].Value = employee["Thai_Prefix"] + " " + employee["Thai_Name"] + " " + employee["Thai_Surname"];
                grdData.Rows[rowIndex].Cells["HireDate"].Value = employee["Hire_Date"];
                grdData.Rows[rowIndex].Cells["Status"].Value = employee["Thai_Description"];
                grdData.Rows[rowIndex].Cells["TerminationDate"].Value = employee["Termination_Date"];
                grdData.Rows[rowIndex].Cells["TerminationReson"].Value = employee["Termination_Reason"];
                rowIndex++;
            }
            if (employees.Rows.Count <= 0) {
                MessageBox.Show("ไม่พบข้อมูลพนักงานตามเงื่อนไขที่ระบุ", "", MessageBoxButtons.OK);
            }

        }

        private void controlTextBox_KeyPress(object sender, KeyPressEventArgs e) {

        }

    }
}