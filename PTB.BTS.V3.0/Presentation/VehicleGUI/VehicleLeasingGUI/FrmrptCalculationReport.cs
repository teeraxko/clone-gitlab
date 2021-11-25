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

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmrptCalculationReport : ChildFormBase, IMDIChildForm
    {

        #region - private -
        //internal DateTime BVDate;
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private int foryear;
        public int ForYear
        {
            set { foryear = value; }
        }

        private bool isActual;
        public bool IsActual
        {
            set { isActual = value; }
        }

        private string conditionQuotationNo;
        public string ConditionQuotationNo
        {
            set { conditionQuotationNo = value; }
        }

        private string conditionPlateNo;
        public string ConditionPlateNo
        {
            set { conditionPlateNo = value; }
        }

        private int conditionVehicleNo;
        public int ConditionVehicleNo
        {
            set { conditionVehicleNo = value; }
        }

        #endregion

        //============================== Constructor ==============================
        public FrmrptCalculationReport()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "Vehicle Calculation";
        }

        //============================== Property ==============================
        public CompanyInfo getCompany()
        {
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();
                string reportFileName = string.Empty;

                switch(foryear)
                {
                    case 1:
                    case 2: 
                    case 3:
                        reportFileName = (isActual) ? "rptVehicleCalculateDetail3YearActual.rpt" : "rptVehicleCalculateDetail3Year.rpt"; // Normally will be use this report -> Fixed Asset Depre. 3 yr.
                        break;
                    case 4:
                        reportFileName = (isActual) ? "rptVehicleCalculateDetail4YearActual.rpt" : "rptVehicleCalculateDetail4Year.rpt";
                        break;
                    case 5:
                        reportFileName = (isActual) ? "rptVehicleCalculateDetail5YearActual.rpt" : "rptVehicleCalculateDetail5Year.rpt";
                        break;
                }

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + reportFileName);

                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";

                if (isActual)
                {
                    rdprint1.DataDefinition.ParameterFields["@pPlateNo"].ApplyCurrentValues(CrytalParameterValue(conditionPlateNo));
                    rdprint1.DataDefinition.ParameterFields["@pQuotation"].ApplyCurrentValues(CrytalParameterValue(conditionQuotationNo));
                    rdprint1.DataDefinition.ParameterFields["@vehicleNo"].ApplyCurrentValues(CrytalParameterValue(conditionVehicleNo));
                }
                crvCost.ReportSource = rdprint1;
                //////////////////////////////////
                ReportDocument rdprint2 = new ReportDocument();

                rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleCalculateHead.rpt");
                DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";

                crvLeasing.ReportSource = rdprint2;
                //////////////////////////////////
                ReportDocument rdprint3 = new ReportDocument();

                rdprint3.Load(@ApplicationProfile.REPORT_PATH + "rptInterestCost.rpt");
                DataSourceConnections dataSourceConnections3 = rdprint3.DataSourceConnections;
                IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
                iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint3.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";

                crvInterest.ReportSource = rdprint3;
                
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
            this.crvLeasing.DisplayToolbar = true;
            this.crvCost.DisplayToolbar = true;
            this.crvInterest.DisplayToolbar = true;
            this.Cursor = Cursors.Default;
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================


        private void FrmrptCostAndProfit_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }
}