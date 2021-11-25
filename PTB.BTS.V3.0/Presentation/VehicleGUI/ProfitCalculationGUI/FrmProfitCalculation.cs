using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using SystemFramework.AppMessage;
using Facade.VehicleFacade.ProfitCalculation;
using Entity.VehicleEntities.Leasing;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.VehicleEntities.ProfitCalculation;

namespace Presentation.VehicleGUI.ProfitCalculationGUI
{
    public partial class FrmProfitCalculation : PresentationBase.CommonGUIBase.ChildFormGUIBase, IMDIChildForm
    {
        //================================= Constructor ================================
        public FrmProfitCalculation()
        {
            InitializeComponent();

            facadeProfitCalculation = new ProfitCalculationFacade();
        }

        #region - Private -
        ProfitCalculationFacade facadeProfitCalculation;
        #endregion

        //================================= Private Method ================================
        #region - Private Method -
        private void bindQuotation(Quotation value)
        {
            cmbCustomer.Text = value.Customer.ShortName;
            cmbBrand.Text = value.AnewVehicle.VehicleInfo.AModel.ABrand.AName.English;
            cmbModel.Text = value.AnewVehicle.VehicleInfo.AModel.AName.English;
            fpdBodyPrice.Value = value.AnewVehicle.VehicleCost.VehiclePrice.TotalVehiclePrice;
            fpdPercentResidual.Value = value.LeasingCalculation.PercentOfResidual;
            fpiLeaseTerm.Value = value.LeaseTerm;
            fpdPercentRateOfReturn.Value = value.LeasingCalculation.RateOfReturn;

            fpdCapitalInsurance.Value = value.AnewVehicle.VehicleCost.CapitalInsurance;
            fpdInsurancePremium.Value = value.AnewVehicle.VehicleCost.InsurancePremium;
            fpdRegister.Value = value.AnewVehicle.VehicleCost.VehicleRegister;
            fpdMaintenance.Value = value.AnewVehicle.VehicleCost.MaintenanceCharge;

            txtMonthlyCharge.Text = value.LeasingCalculation.MonthlyCharge.ToString();
            fpdMonthlyRound.Value = value.LeasingCalculation.MonthlyRoundCharge;
        }

        private void clearQuotation()
        {
            txtQuotationNoYY.Text = "";
            txtQuotationNoMM.Text = "";
            txtQuotationNoXXX.Text = "";

            cmbCustomer.Text = "Test Interest Cost";
            cmbBrand.SelectedIndex = -1;
            cmbModel.SelectedIndex = -1;
            fpdBodyPrice.Text = "";
            fpdPercentResidual.Text = "";
            fpiLeaseTerm.Text = "";
            fpdPercentRateOfReturn.Text = "";

            fpdCapitalInsurance.Text = "";
            fpdInsurancePremium.Text = "";
            fpdRegister.Text = "";
            fpdMaintenance.Text = "";

            txtMonthlyCharge.Text = "";
            fpdMonthlyRound.Text = "";

            fpdInterestRate.Text = "";
            fpdDepreciation.Value = "20";
        }

        private DocumentNo getDocumentNo()
        { 
            int year = Convert.ToInt32(txtQuotationNoYY.Text);
            int month = Convert.ToInt32(txtQuotationNoMM.Text);
            int runNo = Convert.ToInt32(txtQuotationNoXXX.Text);
            return new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, year, month, runNo);
        }

        private Quotation getQuotation()
        {
            Quotation quotation = new Quotation();
            //if (cmbCustomer.SelectedIndex == -1)
            //{
            //    quotation.Customer = new Customer();
            //    quotation.Customer.ShortName = cmbCustomer.Text;
            //}
            //else
            //{
            //    quotation.Customer = (Customer)cmbCustomer.SelectedValue;
            //    if (quotation.Customer.Code == "ZZZZZZ")
            //    {
            //        quotation.Customer.ShortName = cmbCustomer.Text;
            //    }
            //}

            quotation.AnewVehicle.VehicleInfo = new Entity.VehicleEntities.VehicleInfo();
            if (cmbModel.SelectedIndex == -1)
            {
                quotation.AnewVehicle.VehicleInfo.AModel = new Model();
                quotation.AnewVehicle.VehicleInfo.AModel.AName.English = cmbModel.Text;
                quotation.AnewVehicle.VehicleInfo.AModel.ABrand.AName.English = cmbModel.Text;
            }
            else
            {
                quotation.AnewVehicle.VehicleInfo.AModel = (Model)cmbModel.SelectedValue;
            }

            quotation.AnewVehicle.VehicleCost = new VehicleCost();
            quotation.AnewVehicle.VehicleCost.VehiclePrice = new VehiclePrice();
            quotation.AnewVehicle.VehicleCost.VehiclePrice.BodyPrice = Convert.ToDecimal(fpdBodyPrice.Value);
            quotation.AnewVehicle.VehicleCost.CapitalInsurance = Convert.ToDecimal(fpdCapitalInsurance.Value);
            quotation.AnewVehicle.VehicleCost.InsurancePremium = Convert.ToDecimal(fpdInsurancePremium.Value);
            quotation.AnewVehicle.VehicleCost.VehicleRegister = Convert.ToDecimal(fpdRegister.Value);
            quotation.AnewVehicle.VehicleCost.MaintenanceCharge = Convert.ToDecimal(fpdMaintenance.Value);

            quotation.LeasingCalculation = new LeasingCalculation();
            quotation.LeasingCalculation.PercentOfResidual = Convert.ToDecimal(fpdPercentResidual.Value);
            quotation.LeasingCalculation.RateOfReturn = Convert.ToDecimal(fpdPercentRateOfReturn.Value);

            quotation.LeaseTerm = Convert.ToInt16(fpiLeaseTerm.Value);

            return quotation;
        }
        #endregion

        //=================================  public Method ================================
        #region - public Method -
        public int MasterCount()
        {
            return 0;
        }

        public string FormID()
        {
            return "";
        }
        #endregion

        //=================================   Base Event   ================================
        public void InitForm()
        {
            cmbCustomer.DataSource = facadeProfitCalculation.DataSourceCustomer;
            cmbBrand.DataSource = facadeProfitCalculation.DataSourceBrand;
            clearQuotation();
        }

        public void RefreshForm()
        {
            Quotation quotation = new Quotation();
            quotation.QuotationNo = getDocumentNo();
            if (facadeProfitCalculation.FillQuotation(quotation))
            { 
                bindQuotation(quotation);
            }
            else
            {
                Message(MessageList.Error.E0004, "Quotation");
                txtQuotationNoXXX.Focus();            
            }
            quotation = null;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        private void quotationNoChange()
        {
            if (txtQuotationNoYY.Text.Length == 2 && txtQuotationNoMM.Text.Length == 2 && txtQuotationNoXXX.Text.Length == 3)
            {
                RefreshForm();
            }
            else
            {
                if (txtQuotationNoYY.Text.Length == 2)
                {
                    if (txtQuotationNoMM.Text.Length == 2)
                    {
                        txtQuotationNoXXX.Focus();  
                    }
                    else
                    {
                        txtQuotationNoMM.Focus();   
                    }
                }
                else
                {
                    txtQuotationNoYY.Focus();   
                }
            }
        }

        private void enterQuotationNo(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                quotationNoChange();
            }
        }

        private void calculateMonthlyCharge()
        {
            LeasingCalculation result = facadeProfitCalculation.CalculateLeasing(getQuotation());
            txtMonthlyCharge.Text = result.MonthlyCharge.ToString();
            fpdMonthlyRound.Value = result.MonthlyRoundCharge;
            result = null;
        }

        private void createReport()
        {
            Quotation quotation = getQuotation();

            ProfitCal profitCal = new ProfitCal();
            profitCal.Customer = cmbCustomer.Text;
            profitCal.LeaseTerm = quotation.LeaseTerm;
            profitCal.Vehicle = quotation.AnewVehicle.VehicleInfo.AModel.ABrand.AName.English + " " + quotation.AnewVehicle.VehicleInfo.AModel.AName.English;
            profitCal.VehicleCost = quotation.AnewVehicle.VehicleCost;
            profitCal.VehiclePrice = quotation.AnewVehicle.VehicleCost.VehiclePrice.TotalVehiclePrice;

            if (validateReport(profitCal))
            {
                profitCal.LeasingCalculation = facadeProfitCalculation.CalculateLeasing(quotation);
            }
            else
            {
                return;
            }
            
            profitCal.LeasingCalculation.PercentOfResidual = Convert.ToDecimal(fpdPercentResidual.Value);
            profitCal.LeasingCalculation.RateOfReturn = Convert.ToDecimal(fpdPercentRateOfReturn.Value);
            profitCal.LeasingCalculation.MonthlyRoundCharge = Convert.ToDecimal(fpdMonthlyRound.Value);

            profitCal.InterestCostList = new InterestCostList();
            profitCal.InterestCostList.Rate = Convert.ToDecimal(fpdInterestRate.Value);
            
            profitCal.Depreciation = Convert.ToDecimal(fpdDepreciation.Value);
            if (profitCal.LeaseTerm <= 12)
            {
                profitCal.ForYear = 1;
            }
            else if (profitCal.LeaseTerm <= 24)
            {
                profitCal.ForYear = 2;
            }
            else if (profitCal.LeaseTerm <= 36)
            {
                profitCal.ForYear = 3;
            }
            else if (profitCal.LeaseTerm <= 48)
            {
                profitCal.ForYear = 4;
            }
            else
            {
                profitCal.ForYear = 5;
            }

            if (validateReport(profitCal))
            {
                if (warningReport(profitCal))
                { 
                    facadeProfitCalculation.CalculateProfit(profitCal);

                    FrmrptCostAndProfit frmrptCostAndProfit = new FrmrptCostAndProfit();
                    frmrptCostAndProfit.ForYear = profitCal.ForYear;
                    frmrptCostAndProfit.Show();                
                }
            }
            else
            {
                return;
            }

            profitCal = null;
            quotation = null;
        }

        private bool validateReport(ProfitCal value)
        {
            if (value.LeaseTerm <= 0)
            {
                Message(MessageList.Error.E0002, "Lease term");
                fpiLeaseTerm.Focus();
                return false;
            }

            return true;
        }

        private bool warningReport(ProfitCal value)
        {
            if (value.VehiclePrice <= 0)
            {
                Message(MessageList.Error.E0002, "Vehicle price");
                fpdBodyPrice.Focus();
                return false;
            }

            if (value.ResidualPercent <= 0)
            {
                Message(MessageList.Error.E0002, "Residual Value");
                fpdPercentResidual.Focus();
                return false;
            }

            if (value.RateOfReturn <= 0)
            {
                Message(MessageList.Error.E0002, "Rate of Return");
                fpdPercentRateOfReturn.Focus();
                return false;
            }

            if (value.MonthlyCharge <= 0)
            {
                Message(MessageList.Error.E0002, "Rounded to");
                fpdMonthlyRound.Focus();
                return false;
            }

            if (value.InterestRate <= 0)
            {
                Message(MessageList.Error.E0002, "Interest Rate");
                fpdInterestRate.Focus();
                return false;
            }

            if (value.Depreciation <= 0)
            {
                Message(MessageList.Error.E0002, "Depreciation");
                fpdDepreciation.Focus();
                return false;
            }

            return true;
        }

        //=================================     Event      ================================
        private void FrmProfitCalculation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            InitForm();
        }

        private void txtQuotationNoYY_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void txtQuotationNoMM_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void txtQuotationNoXXX_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void txtQuotationNoYY_KeyDown(object sender, KeyEventArgs e)
        {
            enterQuotationNo(e);
        }

        private void txtQuotationNoMM_KeyDown(object sender, KeyEventArgs e)
        {
            enterQuotationNo(e);
        }

        private void txtQuotationNoXXX_KeyDown(object sender, KeyEventArgs e)
        {
            enterQuotationNo(e);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            calculateMonthlyCharge();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex != -1)
            {
                Brand brand = (Brand)cmbBrand.SelectedItem;
                cmbModel.DataSource = facadeProfitCalculation.DataSourceModel(brand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbCustomer.Text = "Test Interest Cost";
            cmbBrand.SelectedIndex = 1;
            cmbModel.SelectedIndex = 1;
            fpdBodyPrice.Text = "1117000";
            fpdPercentResidual.Text = "45";
            fpiLeaseTerm.Text = "36";
            fpdPercentRateOfReturn.Text = "8.5";

            fpdCapitalInsurance.Text = "650000";
            fpdInsurancePremium.Text = "27500";
            fpdRegister.Text = "17000";
            fpdMaintenance.Text = "5000";

            fpdInterestRate.Text = "5.2";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            createReport();
        }
    }
}