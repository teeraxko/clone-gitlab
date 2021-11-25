using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.BLL;
using Report.Reports.Vehicle;

namespace Report.GUI.Vehicle {
    public partial class FrmReportAvgMaintenanceCust : FrmReportBase {
        ReportAvgMaintenanceCust3years report3years = new ReportAvgMaintenanceCust3years();
        ReportAvgMaintenanceCust4years report4years = new ReportAvgMaintenanceCust4years();
        ReportAvgMaintenanceCust5years report5years = new ReportAvgMaintenanceCust5years();

        public FrmReportAvgMaintenanceCust():base() {
            InitializeComponent();
            InitComboxItems();
            dtpStartDate.Value = DateTime.Now.Date;
        }

        private void InitComboxItems() {
            InitComboCustomer();
            InitComboBrand();
            InitComboModel("ZZ");
            InitComboContractType();
        }

        private void InitComboCustomer() {
            DataTable customers = EntitiesProvider.CustomerDataTable();
            DataRow customerRow = customers.NewRow();
            customerRow["Customer_Code"] = "XXXXXX";
            customerRow["English_Name"] = "==All==";
            customerRow["Thai_Name"] = "==ทั้งหมด==";
            customers.Rows.InsertAt(customerRow, 0);
            cmbCustomer.DataSource = customers;
        }

        private void InitComboBrand() {
            DataTable brands = EntitiesProvider.BrandDataTable();
            DataRow brandRow = brands.NewRow();
            brandRow["Brand_Code"] = "ZZ";
            brandRow["Brand_English_Name"] = "==All==";
            brandRow["Brand_Thai_Name"] = "==ทั้งหมด==";
            brands.Rows.InsertAt(brandRow, 0);
            cmbBrand.DataSource = brands;
        }

        private void InitComboModel(string brandCode) {
            DataTable models = EntitiesProvider.ModelDataTable(brandCode);
            DataRow modelRow = models.NewRow();
            modelRow["Brand_Code"] = brandCode;
            modelRow["Model_Code"] = "ZZZZZ";
            modelRow["Model_English_Name"] = "==All==";
            modelRow["Model_Thai_Name"] = "==ทั้งหมด==";
            models.Rows.InsertAt(modelRow, 0);
            cmbModel.DataSource = models;
        }

        private void InitComboContractType() {
            cmbContractType.SelectedIndex = 0;
        }


        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e) {
            InitComboModel((string)cmbBrand.SelectedValue);
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            report3years.SetCriteria((string)cmbCustomer.SelectedValue, (string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text, dtpStartDate.Value.Month, dtpStartDate.Value.Year);
            report4years.SetCriteria((string)cmbCustomer.SelectedValue, (string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text, dtpStartDate.Value.Month, dtpStartDate.Value.Year);
            report5years.SetCriteria((string)cmbCustomer.SelectedValue, (string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text, dtpStartDate.Value.Month, dtpStartDate.Value.Year);

            this.crv3Years.Visible = true;
            this.crv4Years.Visible = true;
            this.crv5Years.Visible = true;
            this.crv3Years.DisplayToolbar = true;
            this.crv4Years.DisplayToolbar = true;
            this.crv5Years.DisplayToolbar = true;


            this.crv3Years.ReportSource = report3years.Report;
            this.crv4Years.ReportSource = report4years.Report;
            this.crv5Years.ReportSource = report5years.Report;
            this.Cursor = Cursors.Default; 

        }

    }
}