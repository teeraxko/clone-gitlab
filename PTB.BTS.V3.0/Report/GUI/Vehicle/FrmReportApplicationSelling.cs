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

namespace Report.GUI.Vehicle
{
    public partial class FrmReportApplicationSelling : FrmReportBase
    {
        ReportApplicationSelling reportApplicationSelling = new ReportApplicationSelling();

        public FrmReportApplicationSelling() : base()
        {
            InitializeComponent();

            InitComboxItems();

            dtpSellingFrom.Value = DateTime.Now;
            dtpSellingTo.Value = DateTime.Now;
        }
        #region -InitCombo-

        /// <summary>
        /// Initailize customer and brand combobox  
        /// </summary>
        private void InitComboxItems()
        {
            InitComboBrand();
        }
        /// <summary>
        /// set property for brand combobox
        /// </summary>
        private void InitComboBrand()
        {
            DataTable brand = EntitiesProvider.BrandDataTable();
            DataRow brandRow = brand.NewRow();
            brandRow["Brand_Code"] = CommonCombo.BRAND_CODE;
            brandRow["Brand_English_Name"] = CommonCombo.BRAND_ENGLISH_NAME;
            brandRow["Brand_Thai_Name"] = CommonCombo.BRAND_THAI_NAME;
            brand.Rows.InsertAt(brandRow, 0);
            cmdBrand.DataSource = brand;
        }
        #endregion

        #region -Event-
        private void FrmReportApplicationSelling_Load(object sender, EventArgs e)
        {
            this.crvReport.Visible = false;
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            reportApplicationSelling.SetCriteria((string)cmdBrand.SelectedValue, dtpSellingFrom.Value, dtpSellingTo.Value);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportApplicationSelling.Report;
            this.Cursor = Cursors.Default;
        }
        #endregion

    }
}
