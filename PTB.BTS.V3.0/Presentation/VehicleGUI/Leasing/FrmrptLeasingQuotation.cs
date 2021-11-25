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

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.Leasing
{
    public partial class FrmrptLeasingQuotation : ChildFormBase, IMDIChildForm
    {
        internal string Remark = string.Empty;
        internal string QuotationNo = string.Empty;

        //============================== Constructor ==============================
        public FrmrptLeasingQuotation()
            : base()
        {
            InitializeComponent();
            this.Text = "Car Leasing Quotation";
        }

        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleLeasingQuatation.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Quotation_No"].Text = "'" + QuotationNo +"'";
                rdprint1.DataDefinition.ParameterFields["pRemark"].ApplyCurrentValues(CrytalParameterValue(Remark));

                crvQuotation.ReportSource = rdprint1;

                ReportDocument rdprint2 = new ReportDocument();
                rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleLeasingCalculateDetail.rpt");
                DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint2.DataDefinition.FormulaFields["Quotation_No"].Text = "'" + QuotationNo + "'";

                crvLeasing.ReportSource = rdprint2;
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
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            this.crvLeasing.DisplayToolbar = true;
            this.crvQuotation.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public void RefreshForm()
        {
            this.crvLeasing.DisplayToolbar = true;
            this.crvQuotation.DisplayToolbar = true;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================

        private void FrmrptLeasingQuotation_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }
}