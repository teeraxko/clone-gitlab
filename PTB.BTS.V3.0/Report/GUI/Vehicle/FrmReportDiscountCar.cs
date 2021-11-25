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
    public partial class FrmReportDiscountCar : FrmReportBase
    {
        ReportDiscountCar reportDiscountCar = new ReportDiscountCar();
        private int POYear;
        private int POMonth;

        public FrmReportDiscountCar(): base() 
        {
            InitializeComponent();

            //InitComboxItems();

            //dtpMonthly.Value = DateTime.Now.Date;
            //dtpQuatationYear.Value = DateTime.Now.Date;

            //dtpMonthly.Checked = false;
            //dtpQuatationYear.Checked = false;


            this.dtpMonthly.CustomFormat = "MM/yyyy";
            this.dtpMonthly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthly.Name = "dtpCriteria";
            this.dtpMonthly.TabIndex = 2;





        }

        #region - InitCombo -
        /// <summary>
        /// Initailize customer combobox  
        /// </summary>
        /// 



       
        //private void InitComboxItems()
        //{
            //InitComboCustomer();
       // }
       



        /// <summary>
        /// set property for customer combobox
        /// </summary>
       /* private void InitComboCustomer()
       {           
          DataTable quotationstatus = EntitiesProvider.QuotationStatusDataTable();
            DataRow quotationstatusRow = quotationstatus.NewRow();


            quotationstatusRow["Quotation_Status"] = CommonCombo.QUOTATION_STATUS;
    


            quotationstatus.Rows.InsertAt(quotationstatusRow, 0);

            cmbQuotationStatus.DataSource = quotationstatus;




       
        }*/
         

        /*private void setYear()
        {
            if (dtpMonthly.Checked)
            {
                contractYear = dtpMonthly.Value.Year;
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
        */

        #endregion

        #region -Event-
        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //setYear(string)dtpMonthly.Value.Year

            if (dtpMonthly.Checked ) {

                POMonth = dtpMonthly.Value.Month;
                POYear = dtpMonthly.Value.Year;

            }

                else {

                    POMonth = 0;
                    POYear = 0;
            
            }






            reportDiscountCar.SetCriteria((string)txtPO.Text, (string)txtQuotation.Text, (int)POYear, (int)POMonth);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportDiscountCar.Report;
            this.Cursor = Cursors.Default; 
        }

        private void FrmReportDiscountCar_Load(object sender, EventArgs e)
        {
            this.crvReport.Visible = false;
        }
        #endregion
    }
}
