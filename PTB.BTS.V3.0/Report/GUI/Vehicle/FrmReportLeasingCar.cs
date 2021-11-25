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
    public partial class FrmReportLeasingCar : FrmReportBase
    {
        
        
        ReportLeasingCar reportLeasingCar = new ReportLeasingCar();
        private int contractYear;
        private int quotationYear;

        public FrmReportLeasingCar(): base() 
        {
            InitializeComponent();

            InitComboxItems();

            dtpContractYear.Value = DateTime.Now.Date;
            dtpQuatationYear.Value = DateTime.Now.Date;

            dtpContractYear.Checked = false;
            dtpQuatationYear.Checked = false;
        }

        #region - InitCombo -
        /// <summary>
        /// Initailize customer combobox  
        /// </summary>
        private void InitComboxItems()
        {
            InitComboCustomer();
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

        private void setYear()
        {
            if (dtpContractYear.Checked)
            {
                contractYear = dtpContractYear.Value.Year;
            }
            else
            {
                contractYear = 0;
            }

            if (dtpQuatationYear.Checked)
            {
                quotationYear = dtpQuatationYear.Value.Year;
            }
            else
            {
                quotationYear = 0;
            }
        }

        #endregion

        #region -Event-
        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            setYear();

            reportLeasingCar.SetCriteria((string)cmbCustomer.SelectedValue, contractYear, quotationYear);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportLeasingCar.Report;
            this.Cursor = Cursors.Default; 
        }

        private void FrmReportLeasingCar_Load(object sender, EventArgs e)
        {
            this.crvReport.Visible = false;
        }
        #endregion
    }
}
