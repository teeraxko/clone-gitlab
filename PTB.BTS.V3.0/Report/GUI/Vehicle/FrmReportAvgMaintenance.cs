using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;
using Entity.VehicleEntities;
using Report.BLL;
using Report.Reports.Vehicle;

namespace Report.GUI.Vehicle {
    public partial class FrmReportAvgMaintenance : FrmReportBase {
        ReportAvgMaintenance3years report3years = new ReportAvgMaintenance3years();
        ReportAvgMaintenance4years report4years = new ReportAvgMaintenance4years();
        ReportAvgMaintenance5years report5years = new ReportAvgMaintenance5years();

        public FrmReportAvgMaintenance()
            : base() {
            InitializeComponent();
            InitComboxItems();
        }

        private void InitComboxItems() {
            InitComboBrand();
            InitComboModel("ZZ");
            InitComboContractType();
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
            report3years.SetCriteria((string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text);
            report4years.SetCriteria((string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text);
            report5years.SetCriteria((string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, cmbContractType.Text);

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