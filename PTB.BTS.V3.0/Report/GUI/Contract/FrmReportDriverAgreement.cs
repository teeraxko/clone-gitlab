using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Contract;
using Report.BLL;

namespace Report.GUI.Contract
{
    public partial class FrmReportDriverAgreement : FrmReportBase
    {
        ReportTISDriverAgreement reportTISDriverAgreement = new ReportTISDriverAgreement();
        ReportDriverAgreement reportDriverAgreement = new ReportDriverAgreement();

        public FrmReportDriverAgreement(): base()
        {
            InitializeComponent();
            Clearscreen();

        }

        private void Clearscreen()
        {
            InitComboxItems();
            //clear left box
            txtContractNo.Text = string.Empty;
            txtContractStartDate.Text = string.Empty;
            txtContractEndDate.Text = string.Empty;
            txtContractType.Text = string.Empty;
            txtContractsts.Text = string.Empty;
            txtCustomerName.Text = string.Empty;

            //clear right box
            txtCommonDriver.Text = string.Empty;
            txtCommonRate.Text = "0";
            txtFamilyDriver.Text = string.Empty;
            txtFamilyRate.Text = "0";
            dtpHireDateFrom.Value = DateTime.Now;
            dtpHireDateTo.Value = DateTime.Now;
        }
        /// <summary>
        /// Initailize customer and brand combobox  
        /// </summary>
        private void InitComboxItems()
        {
            InitComboCustomer();
        }
        /// <summary>
        /// set property for brand combobox
        /// </summary>
        private void InitComboCustomer()
        {
            DataTable customers = EntitiesProvider.CustomerDataTable();
            DataRow customerRow = customers.NewRow();
            customerRow["Customer_Code"] = " ";
            customerRow["English_Name"] = "==All==";
            customerRow["Thai_Name"] = "==ทั้งหมด==";
            customers.Rows.InsertAt(customerRow, 0);
            cmbCustomerName.DataSource = customers;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (cutomer = 000001)
            //{
                this.Cursor = Cursors.WaitCursor;
                //   reportTISDriverAgreement.SetCriteria(....);

                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;
                this.crvReport.ReportSource = reportTISDriverAgreement.Report;
                this.Cursor = Cursors.Default;
            //}
            //else
            //{
                this.Cursor = Cursors.WaitCursor;
                //   reportDriverAgreement.SetCriteria(....);

                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;
                this.crvReport.ReportSource = reportDriverAgreement.Report;
                this.Cursor = Cursors.Default;
            //}
        }

        private void FrmReportDriverAgreement_Load(object sender, EventArgs e)
        {
            this.crvReport.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }


    }
}
