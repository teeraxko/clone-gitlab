using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Contract;
using Report.BLL;

namespace Report.GUI.Contract {
    public partial class FrmReportPenaltyCharge : FrmReportBase  {
        private ReportPenaltyCharge rpt = new ReportPenaltyCharge();
        public FrmReportPenaltyCharge():base() {
            InitializeComponent();
            InitComboxItems();
        }

        private void InitComboxItems() {
            InitComboBrand();
            InitComboModel("ZZ");
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

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e) {
            InitComboModel((string)cmbBrand.SelectedValue);
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            rpt.SetCriteria((string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue);
            crvMain.ReportSource = rpt.Report;
            this.Cursor = Cursors.Default;

        }


    }
}