using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmrptQuotationReport : ChildFormBase, IMDIChildForm
    {
        internal string printDate = DateTime.Today.Date.Day.ToString() + "/" + DateTime.Today.Date.Month.ToString() + "/" + DateTime.Today.Date.Year.ToString();

        //============================== Constructor ==============================
        public FrmrptQuotationReport()
            : base()
        {
            InitializeComponent();
            this.Text = "Quotation Report";
        }

        public FrmrptQuotationReport(DocumentNo quotationNo)
            : base()
        {
            InitializeComponent();
            this.Text = "Quotation Report";
            hidQuotationNo.Text = quotationNo.ToString();
        }
        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleQuotation.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.ParameterFields["@pQuotationNo"].ApplyCurrentValues(CrytalParameterValue(hidQuotationNo.Text));
                
                crvPrint.ReportSource = rdprint1;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        private ParameterValues CrytalParameterValue(object paraValue)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }

        //==============================Base Event ==============================
        public void InitForm()
        {
            this.Cursor = Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            this.crvPrint.DisplayToolbar = true;
            this.Cursor = Cursors.Default;
        }

        public void RefreshForm()
        {
            this.crvPrint.DisplayToolbar = true;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================
        private void FrmrptLeasingPurchasing_Load(object sender, EventArgs e)
        {
            InitForm();
        }

    }
}