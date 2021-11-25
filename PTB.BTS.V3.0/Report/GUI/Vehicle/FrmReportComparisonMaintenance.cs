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
using Entity.ContractEntities;

namespace Report.GUI.Vehicle
{
    public partial class FrmReportComparisonMaintenance : FrmReportBase
    {
        ReportComparisonMaintenance reportComparisonMaintenance = new ReportComparisonMaintenance();
        ReportComparisonMaintenance4Year reportComparisonMaintenance4Year = new ReportComparisonMaintenance4Year();
        private int registYear;

        public FrmReportComparisonMaintenance(): base()
        {
            InitializeComponent();

            InitComboxItems();

            dtpRegisterYear.Value = DateTime.Now.Date;

            dtpRegisterYear.Checked = false;
        }

        #region - InitCombo -
        /// <summary>
        /// Initailize customer and brand combobox  
        /// </summary>
        private void InitComboxItems()
        {
            InitComboCustomer();
            InitComboBrand();
        }

        /// <summary>
        /// set property for customer combobox
        /// </summary>
        private void InitComboCustomer()
        {
            DataTable customers = EntitiesProvider.CustomerDataTable();
            DataRow customerRow = customers.NewRow();
            customerRow["Customer_Code"] = CommonCombo.CUSTOMER_CODE;
            customerRow["English_Name"] = CommonCombo.CUST_ENGLISH_NAME;
            customerRow["Thai_Name"] = CommonCombo.CUST_THAI_NAME;
            customers.Rows.InsertAt(customerRow, 0);
            cmbCustomer.DataSource = customers;
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

        private void setYear()
        {
            if (dtpRegisterYear.Checked)
            {
                registYear = dtpRegisterYear.Value.Year;
            }
            else
            {
                registYear = 0;
            }
        }
        #endregion

        #region - Event -
        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //add by Aof 02/12/08
            if (GetMaxLeaseTerm((string)cmbCustomer.SelectedValue, (string)cmdBrand.SelectedValue, registYear) <= 36)
            {
                reportComparisonMaintenance.SetCriteria((string)cmbCustomer.SelectedValue, (string)cmdBrand.SelectedValue, registYear);
                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;
                this.crvReport.ReportSource = reportComparisonMaintenance.Report;
                this.Cursor = Cursors.Default;
            }
            else
            {
                reportComparisonMaintenance4Year.SetCriteria((string)cmbCustomer.SelectedValue, (string)cmdBrand.SelectedValue, registYear); this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;
                this.crvReport.ReportSource = reportComparisonMaintenance4Year.Report;
                this.Cursor = Cursors.Default;
            }
                //end add by Aof

            
        }

        private int GetMaxLeaseTerm(string customerCode, string brandCode, int registerDate)
        {
            using (PTB.BTS.Vehicle.Flow.VehicleFlow flow = new VehicleFlow())
            {
                return flow.GetVehicleContractLeaseTerm( customerCode, brandCode, registerDate);
            }
        }

        private void FrmReportComparisonMaintenance_Load(object sender, EventArgs e)
        {
            this.crvReport.Visible = false;
        }
        #endregion

        private void dtpRegisterYear_ValueChanged(object sender, EventArgs e)
        {
            setYear();
        }

    }
}
