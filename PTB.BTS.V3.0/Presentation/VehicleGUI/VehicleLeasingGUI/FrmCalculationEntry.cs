using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Input;

using Presentation.CommonGUI;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using Facade.VehicleFacade.VehicleLeasingFacade ;
using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;
using System.Data.SqlClient;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmCalculationEntry : EntryFormBase
    {
        #region Private variable

        private const double DEPRECIATION = 20;
        private const double MAX_VALUE_7 = 9999999.99;
        private const double MAX_VALUE_6 = 999999.99;
        private const double MAX_VALUE_2 = 99.99;

        private FrmCalculationSearch parentForm;
        private FrmVehicleQuotationEntry frmVehicleQuotationEntry;
        private VehicleCalculationFacade facadeVehicleCalculation;
        private VehicleCalculation calculation;
        private VehicleQuotationFacade facadeVehicleQuotation = new VehicleQuotationFacade();
        private bool btnPrintStatus;
        private bool btnQuotationStatus;

        #endregion

        #region Constructor

        public FrmCalculationEntry(FrmCalculationSearch value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            facadeVehicleCalculation = new VehicleCalculationFacade();

            btnPrintStatus = false;
            btnQuotationStatus = false;


        }

        #endregion

        #region Private Method

        /// <summary>
        /// Function    : Set control property for enable or disable
        /// Author      : Thawatchai B.
        /// Create Date : 07/10/08 
        /// </summary>
        /// <param name="enable"></param>
        private void enableKeyField(bool value)
        {
            btnQuotation.Enabled = value;
            btnCalculate.Enabled = value;

            cboCustomer.Enabled = value;
            cboBrand.Enabled = value;
            cboModel.Enabled = value;

            //Delete color from quotation : woranai 2009/02/18
            //cboColor.Enabled = value;

            txtBodyPrice.Enabled = value;
            txtModifyPrice.Enabled = value;
            txtPercentResidual.Enabled = value;
            txtLeaseTerm.Enabled = value;
            txtPercentRateOfReturn.Enabled = value;
            txtCapitalInsurance.Enabled = value;
            txtInsurancePremium.Enabled = value;
            txtRegister.Enabled = value;
            txtMaintenance.Enabled = value;
            txtInterestRate.Enabled = value;
            txtDepreciation.Enabled = value;
            txtRound.Enabled = value;
        }

        private void clearForm()
        {
            cboCustomer.SelectedIndex = -1;
            cboBrand.SelectedIndex = -1;
            cboModel.SelectedIndex = -1;

            //Delete color from quotation : woranai 2009/02/18
            //cboColor.SelectedIndex = -1;

            txtBodyPrice.Value = decimal.Zero;
            setMaxValueControl(txtBodyPrice, MAX_VALUE_7);

            txtModifyPrice.Value = decimal.Zero;
            setMaxValueControl(txtModifyPrice, MAX_VALUE_7);

            txtPercentResidual.Value = decimal.Zero;
            setMaxValueControl(txtPercentResidual, MAX_VALUE_2);

            txtLeaseTerm.Value = decimal.Zero;
            setMaxValueControl(txtLeaseTerm, MAX_VALUE_2);

            txtPercentRateOfReturn.Value = decimal.Zero;
            setMaxValueControl(txtPercentRateOfReturn, MAX_VALUE_2);            

            txtPercentRateOfReturnActual.Value = decimal.Zero;
            setMaxValueControl(txtPercentRateOfReturnActual, MAX_VALUE_2);   

            txtCapitalInsurance.Value = decimal.Zero;
            setMaxValueControl(txtCapitalInsurance, MAX_VALUE_7);

            txtInsurancePremium.Value = decimal.Zero;
            setMaxValueControl(txtInsurancePremium, MAX_VALUE_6);            

            txtRegister.Value = decimal.Zero;
            setMaxValueControl(txtRegister, MAX_VALUE_6); 

            txtMaintenance.Value = decimal.Zero;
            setMaxValueControl(txtMaintenance, MAX_VALUE_6); 

            txtMaintenanceActual.Value = decimal.Zero;
            setMaxValueControl(txtMaintenanceActual, MAX_VALUE_6);             

            txtInterestRate.Value = decimal.Zero;
            setMaxValueControl(txtInterestRate, MAX_VALUE_2);

            txtDepreciation.Value = 20;
            setMaxValueControl(txtDepreciation, MAX_VALUE_2);

            txtMonthlyCharge.Value = decimal.Zero;
            setMaxValueControl(txtMonthlyCharge, MAX_VALUE_6);            

            txtRound.Value = decimal.Zero;
            setMaxValueControl(txtRound, MAX_VALUE_6);            

            btnPrintStatus = false;
            btnQuotationStatus = false;



            if (txtLeasingXXX.Text == "")
            {
                calculation = new VehicleCalculation();
                calculation.Quotation = new VehicleQuotation();
           

                calculation.LeasingNo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.LEASING_VEHICLE).ToString();


                //txtLeasingYY.Text = calculation.Leasing.LeasingNo.Year.ToString();
                //txtLeasingMM.Text = calculation.Leasing.LeasingNo.Month.ToString();
                //txtLeasingXXX.Text = calculation.Leasing.LeasingNo.No.ToString();

            }




        }

        private void setMaxValueControl(FpDouble control, double max)
        {
            control.MaxValue = max;
            control.MinValue = 0;
        }

        private void exitForm()
        {
            this.Close();
        }

        private void initForm(VehicleCalculation value)
        {
            if (action == ActionType.ADD)
            {
                InitCalculationHeader();
                clearForm();
                
            }
            if (action == ActionType.EDIT)
            {
                clearForm();
                VehicleCalculation vehicleCalculation = new VehicleCalculation();
                vehicleCalculation = facadeVehicleCalculation.GetVehicleCalculationByCalculationNo(value);
                if (value.Quotation.QuotationNo != null)
                {
                    bindQuotationNo(value.Quotation.QuotationNo);
                    
                    enableKeyField(false);
                }
                else
                {
                    enableKeyField(true);
                }

                if (vehicleCalculation.Customer != null)
                {
                    bindVehicleCalculation(vehicleCalculation);
                }         
            }
        }

        /// <summary>
        /// Function    : Bind Quotation no. to text box
        /// Author      : Thawatchai B.
        /// Create Date : 06/11/08
        /// </summary>
        /// <param name="quotationNo"></param>
        private void bindQuotationNo(DocumentNo quotationNo)
        {
            txtQuotationYY.Text = quotationNo.Year.ToString();
            txtQuotationMM.Text = quotationNo.Month.ToString();
            txtQuotationXXX.Text = quotationNo.No.ToString();



            //Todsporn Modified 25/2/2020 PO. Discount

            txtLeasingYY.Text = quotationNo.Year.ToString();
            txtLeasingMM.Text = quotationNo.Month.ToString();
            txtLeasingXXX.Text = quotationNo.No.ToString();






        }

        /// <summary>
        /// Function    : Bind vehicle calculation to the form
        /// Author      : Thawatchai B.
        /// Create Date : 06/11/08
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        private void bindVehicleCalculation(VehicleCalculation vehicleCalculation)
        {
            cboCustomer.Text = vehicleCalculation.Customer.AName.English;
            cboBrand.Text = vehicleCalculation.Model.ABrand.ToString();
            cboModel.Text = vehicleCalculation.Model.ToString();

            //Delete color from calculation : woranai 2009/02/18
            //cboColor.Text = vehicleCalculation.Color.ToString();

            //Calculation_No
            hidCalculation_No.Text = vehicleCalculation.CalculationNo.ToString();
            //Body Cost
            if (vehicleCalculation.BodyCost.ToString("###.##") == "")
            {
                txtBodyPrice.Text = "0.00";
            }
            else
            {
                txtBodyPrice.Text = vehicleCalculation.BodyCost.ToString("###.##");
            }
            //Modify Cost
            if (vehicleCalculation.ModifyCost.ToString("###.##") == "")
            {
                txtModifyPrice.Text = "0.00";
            }
            else
            {
                txtModifyPrice.Text = vehicleCalculation.ModifyCost.ToString("###.##");
            }
            //Percent Residual
            if (vehicleCalculation.LeasingCalculation.PercentResidual.ToString("###.##") == "")
            {
                txtPercentResidual.Text = "0.00";
            }
            else
            {
                txtPercentResidual.Text = vehicleCalculation.LeasingCalculation.PercentResidual.ToString("###.##");
            }
            //Residual Value
            if (vehicleCalculation.LeasingCalculation.ResidualValue.ToString("###.##") == "")
            {
                hidResidualValue.Text = "0.00";
            }
            else
            {
                hidResidualValue.Text = vehicleCalculation.LeasingCalculation.ResidualValue.ToString("###.##");
            }
            //Lease Term
            if (vehicleCalculation.LeasingCalculation.LeaseTerm.ToString("###.##") == "")
            {
                txtLeaseTerm.Text = "0";
            }
            else
            {
                txtLeaseTerm.Text = vehicleCalculation.LeasingCalculation.LeaseTerm.ToString("###.##");
            }
            //Rate of Return Estimate
            if (vehicleCalculation.LeasingCalculation.RateOfReturnEstimate.ToString("###.##") == "")
            {
                txtPercentRateOfReturn.Text = "0.00";
            }
            else
            {
                txtPercentRateOfReturn.Text = vehicleCalculation.LeasingCalculation.RateOfReturnEstimate.ToString("###.##");
            }
            //Rate of Return Actual
            if (vehicleCalculation.LeasingCalculation.RateOfReturnActual.ToString("###.##") == "")
            {
                txtPercentRateOfReturnActual.Text = "0.00";
            }
            else
            {
                txtPercentRateOfReturnActual.Text = vehicleCalculation.LeasingCalculation.RateOfReturnActual.ToString("###.##");
            }
            //Capital Insurance
            if (vehicleCalculation.LeasingCalculation.CapitalInsurance.ToString("###.##") == "")
            {
                txtCapitalInsurance.Text = "0.00";
            }
            else
            {
                txtCapitalInsurance.Text = vehicleCalculation.LeasingCalculation.CapitalInsurance.ToString("###.##");
            }
            //Insurance Premium
            if (vehicleCalculation.LeasingCalculation.InsurancePremium.ToString("###.##") == "")
            {
                txtInsurancePremium.Text = "0.00";
            }
            else
            {
                txtInsurancePremium.Text = vehicleCalculation.LeasingCalculation.InsurancePremium.ToString("###.##");
            }
            //Tax Register
            if (vehicleCalculation.LeasingCalculation.TaxRegister.ToString("###.##") == "")
            {
                txtRegister.Text = "0.00";
            }
            else
            {
                txtRegister.Text = vehicleCalculation.LeasingCalculation.TaxRegister.ToString("###.##");
            }
            //Maintenance
            if (vehicleCalculation.LeasingCalculation.Maintenance.ToString("###.##") == "")
            {
                txtMaintenance.Text = "0.00";
            }
            else
            {
                txtMaintenance.Text = vehicleCalculation.LeasingCalculation.Maintenance.ToString("###.##");
            }
            //Maintenance Actual
            if (vehicleCalculation.LeasingCalculation.MaintenanceActual.ToString("###.##") == "")
            {
                txtMaintenanceActual.Text = "0.00";
            }
            else
            {
                txtMaintenanceActual.Text = vehicleCalculation.LeasingCalculation.MaintenanceActual.ToString("###.##");
            }
            //Interest Rate
            if (vehicleCalculation.LeasingCalculation.InterestRate.ToString("###.##") == "")
            {
                txtInterestRate.Text = "0.00";
            }
            else
            {
                txtInterestRate.Text = vehicleCalculation.LeasingCalculation.InterestRate.ToString("###.##");
            }
            //Depreciation
            if (vehicleCalculation.Depreciation.ToString("###.##") == "")
            {
                txtDepreciation.Value = DEPRECIATION;
            }
            else
            {
                txtDepreciation.Text = vehicleCalculation.Depreciation.ToString("###.##");
            }
            //Monthly Charge Actual
            if (vehicleCalculation.LeasingCalculation.MonthlyChargeActual.ToString("###,###,###.##") == "")
            {
                txtMonthlyCharge.Text = "0.00";
            }
            else
            {
                txtMonthlyCharge.Text = vehicleCalculation.LeasingCalculation.MonthlyChargeActual.ToString("###,###,###.##");
            }
            //Monthly Charge
            if (vehicleCalculation.LeasingCalculation.MonthlyCharge.ToString("###.##") == "")
            {
                txtRound.Text = "0.00";
            }
            else
            {
                txtRound.Text = vehicleCalculation.LeasingCalculation.MonthlyCharge.ToString("###.##");
            }
            //PV
            if (vehicleCalculation.LeasingCalculation.PV.ToString("###.##") == "")
            {
                hidPV.Text = "0.00";
            }
            else
            {
                hidPV.Text = vehicleCalculation.LeasingCalculation.PV.ToString("###.##");
            }
            //PMT
            if (vehicleCalculation.LeasingCalculation.PMT.ToString("###.##") == "")
            {
                hidPMT.Text = "0.00";
            }
            else
            {
                hidPMT.Text = vehicleCalculation.LeasingCalculation.PMT.ToString("###.##");
            }

            //Todsporn Modified 25/2/2020 PO. Discount

            //Discount_Amount
            if (vehicleCalculation.DiscountAmount.ToString("###.##") == "")
            {
                txtDiscountAmount.Text = "0.00";
            }
            else
            {
                txtDiscountAmount.Text = vehicleCalculation.DiscountAmount.ToString("###.##");
            }
            //Discount_total
            if (vehicleCalculation.DiscountTotal.ToString("###.##") == "")
            {
                txtDiscountTotal.Text = "0.00";
            }
            else
            {
                txtDiscountTotal.Text = vehicleCalculation.DiscountTotal.ToString("###.##");
            }




  





        }

        /// <summary>
        /// Function    : Validate value brfore calculate monthly charge
        /// Author      : Thawatchai B.
        /// Create Date : 08/10/08
        /// </summary>
        private void calculateEvent()
        {
            if (validateBodyPrice() &&
                validatePercentResidual() &&
                validateLeaseTerm() &&
                validatePercentRateOfReturn() &&
                validateInsurancePremium() &&
                validateRegister() &&
                validateMaintenance())
            { 
                calculateMonthlyCharge();
            }
        }

        /// <summary>
        /// Function    : Issue quotaion as this calculation
        /// Author      : Thawatchai B.
        /// Create Date : 08/10/08
        /// </summary>
        private void createQuotation()
        {
            if (validateMonthlyCharge() && 
                Message(MessageList.Question.Q0016, "ใบเสนอราคา") == DialogResult.Yes)
            {
                if (action == ActionType.EDIT)
                {   
                    //Update data automatic before create quotation
                    if (EditEvent())
                    {
                        this.Close();

                        frmVehicleQuotationEntry = new FrmVehicleQuotationEntry(this.getUpdateCalculation());
                        frmVehicleQuotationEntry.ShowDialog();
                        parentForm.RefreshForm();
                    }
                }
                else
                {   
                    //(Insert data automatic before create quotation
                    if (AddEvent())
                    {
                        this.Close();

                        frmVehicleQuotationEntry = new FrmVehicleQuotationEntry(this.getUpdateCalculation());
                        frmVehicleQuotationEntry.ShowDialog();
                        parentForm.RefreshForm();
                    }
                }
            }

        }
            
        /// <summary>
        /// Function    : Issue report as this leasing calculation
        /// Author      : Thawatchai B.
        /// Create Date : 08/10/08
        /// </summary>
        private void createReport()
        {
            bool printStatus = false;
            bool isActual = false;

            if (action == ActionType.ADD)
            {
                if (AddEvent()) { printStatus = true;}

            }
            else
            {
                if (EditEvent()) { printStatus = true; }
            }

            if (printStatus)
            {
                VehicleCalculation vehicleCalculation = getCalculation();

                if (validateCalculation())
                {
                    vehicleCalculation.LeasingCalculation = facadeVehicleCalculation.CalculateMonthlyCharge(vehicleCalculation);
                    txtMonthlyCharge.Value = vehicleCalculation.LeasingCalculation.MonthlyChargeActual;
                    hidResidualValue.Text = vehicleCalculation.LeasingCalculation.ResidualValue.ToString();
                    hidPV.Text = vehicleCalculation.LeasingCalculation.PV.ToString();
                    hidPMT.Text = vehicleCalculation.LeasingCalculation.PMT.ToString();
                }
                else
                {
                    return;
                }

                vehicleCalculation = getInsertCalculation();

                if (vehicleCalculation.LeasingCalculation.LeaseTerm <= 12)
                {
                    vehicleCalculation.ForYear = 1;
                }
                else if (vehicleCalculation.LeasingCalculation.LeaseTerm <= 24)
                {
                    vehicleCalculation.ForYear = 2;
                }
                else if (vehicleCalculation.LeasingCalculation.LeaseTerm <= 36)
                {
                    vehicleCalculation.ForYear = 3;
                }
                else if (vehicleCalculation.LeasingCalculation.LeaseTerm <= 48)
                {
                    vehicleCalculation.ForYear = 4;
                }
                else
                {
                    vehicleCalculation.ForYear = 5;
                }

                VehicleQuotation vehicleQuotation = new VehicleQuotation();
                VehicleInfo vehicleInfo = new VehicleInfo();
                if (txtQuotationYY.Text == "" && txtQuotationMM.Text == "" && txtQuotationXXX.Text == "")
                {
                    vehicleQuotation = null;
                }
                else
                {
                    vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, txtQuotationYY.Text, txtQuotationMM.Text, txtQuotationXXX.Text);
                    vehicleCalculation.LeasingNo = vehicleQuotation.QuotationNo.ToString().Replace("PTB", "LC"); ;
                    
                    vehicleCalculation.Quotation = vehicleQuotation;
                    vehicleInfo = facadeVehicleCalculation.GetVehicleInfoByQuotation(vehicleCalculation.Quotation.QuotationNo);   
                }

                parentForm.RefreshForm();
                FrmrptCalculationReport frmrptCalculationReport = new FrmrptCalculationReport();
                frmrptCalculationReport.ConditionPlateNo = vehicleInfo.PlateNumber;
                frmrptCalculationReport.ForYear = vehicleCalculation.ForYear;

                frmrptCalculationReport.IsActual = isActual = facadeVehicleCalculation.CalculateProfit(vehicleCalculation, vehicleInfo);

                if (isActual)
                {
                    frmrptCalculationReport.ConditionQuotationNo = vehicleCalculation.Quotation.QuotationNo.ToString();
                    frmrptCalculationReport.ConditionVehicleNo = vehicleInfo.VehicleNo;
                }

                frmrptCalculationReport.Show();
            }
        }

        /// <summary>
        /// Function    : Calculate Monthly Charge
        /// Author      : Thawatchai B.
        /// Create Date : 09/10/08
        /// </summary>
        private void calculateMonthlyCharge()
        {
            VehicleLeasingCalculation result = facadeVehicleCalculation.CalculateMonthlyCharge(getCalculation());

            txtMonthlyCharge.Value = result.MonthlyChargeActual;
            txtRound.Value = result.MonthlyCharge;
            hidResidualValue.Text = result.ResidualValue.ToString();
            hidPV.Text = result.PV.ToString();
            hidPMT.Text = result.PMT.ToString();

            result = null;
        }

        private VehicleCalculation getCalculation()
        {
            VehicleCalculation calculation = new VehicleCalculation();
            calculation.LeasingCalculation = new VehicleLeasingCalculation();

            getVehicleDetail(calculation);

            calculation.BodyCost = Convert.ToDecimal(txtBodyPrice.Value);
            calculation.ModifyCost = Convert.ToDecimal(txtModifyPrice.Value);
            calculation.LeasingCalculation.PercentResidual = Convert.ToDecimal(txtPercentResidual.Value);
            calculation.LeasingCalculation.LeaseTerm = Convert.ToInt32(txtLeaseTerm.Value);
            calculation.LeasingCalculation.RateOfReturnEstimate = Convert.ToDecimal(txtPercentRateOfReturn.Value);
            calculation.LeasingCalculation.RateOfReturnActual = Convert.ToDecimal(txtPercentRateOfReturnActual.Value);
            calculation.LeasingCalculation.CapitalInsurance = Convert.ToDecimal(txtCapitalInsurance.Value);
            calculation.LeasingCalculation.InsurancePremium = Convert.ToDecimal(txtInsurancePremium.Value);
            calculation.LeasingCalculation.TaxRegister = Convert.ToDecimal(txtRegister.Value);
            calculation.LeasingCalculation.Maintenance = Convert.ToDecimal(txtMaintenance.Value);
            calculation.LeasingCalculation.MaintenanceActual = Convert.ToDecimal(txtMaintenanceActual.Value);
            calculation.LeasingCalculation.InterestRate = Convert.ToDecimal(txtInterestRate.Value);
            calculation.Depreciation = Convert.ToDecimal(txtDepreciation.Value);
            
            
            //Todsporn Modified 25/2/2020 PO. Discount
            //calculation.Quotation = calculation.Quotation.QuotationNo;

            
            calculation.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Value);
            calculation.DiscountTotal = Convert.ToDecimal(txtDiscountTotal.Value);



            return calculation;
        }

        private VehicleCalculation getInsertCalculation()
        {
            VehicleCalculation calculation = new VehicleCalculation();
            calculation.LeasingCalculation = new VehicleLeasingCalculation();

            // Create and display the value of new GUID.
            Guid guidCalculationNo;            
            guidCalculationNo = Guid.NewGuid();
            calculation.CalculationNo = guidCalculationNo;

            getVehicleDetail(calculation);
            setCalculation(calculation);           

            return calculation;
        }

        private VehicleCalculation getUpdateCalculation()
        {
            VehicleCalculation calculation = new VehicleCalculation();
            calculation.LeasingCalculation = new VehicleLeasingCalculation();

            System.Guid guidCalculationNo = new Guid(hidCalculation_No.Text);
            calculation.CalculationNo = guidCalculationNo;

            getVehicleDetail(calculation);
            setCalculation(calculation);

            return calculation;
        }

        private void getVehicleDetail(VehicleCalculation calculation)
        {
            if (cboCustomer.SelectedValue != null)
            {
                calculation.Customer = facadeVehicleCalculation.GetCustomer(cboCustomer.SelectedValue.ToString());
            }

            if (cboBrand.SelectedValue != null)
            {
                calculation.Model = facadeVehicleCalculation.GetModel(cboModel.SelectedValue.ToString(), cboBrand.SelectedValue.ToString());
            }

            //Delete color from calculation : woranai 2009/02/18
            //if (cboColor.SelectedValue != null)
            //{
            //    calculation.Color = facadeVehicleCalculation.GetColor(cboColor.SelectedValue.ToString());
            //}
        }

        private void setCalculation(VehicleCalculation calculation)
        {
            calculation.BodyCost = Convert.ToDecimal(txtBodyPrice.Value);
            calculation.ModifyCost = Convert.ToDecimal(txtModifyPrice.Value);
            calculation.LeasingCalculation.PercentResidual = Convert.ToDecimal(txtPercentResidual.Value);
            calculation.LeasingCalculation.ResidualValue = Convert.ToDecimal(hidResidualValue.Text);
            calculation.LeasingCalculation.LeaseTerm = Convert.ToInt32(txtLeaseTerm.Value);
            calculation.LeasingCalculation.RateOfReturnEstimate = Convert.ToDecimal(txtPercentRateOfReturn.Value);
            calculation.LeasingCalculation.RateOfReturnActual = Convert.ToDecimal(txtPercentRateOfReturnActual.Value);
            calculation.LeasingCalculation.InterestRate = Convert.ToDecimal(txtInterestRate.Value);
            calculation.Depreciation = Convert.ToDecimal(txtDepreciation.Value);
            calculation.LeasingCalculation.CapitalInsurance = Convert.ToDecimal(txtCapitalInsurance.Value);
            calculation.LeasingCalculation.InsurancePremium = Convert.ToDecimal(txtInsurancePremium.Value);
            calculation.LeasingCalculation.TaxRegister = Convert.ToDecimal(txtRegister.Value);
            calculation.LeasingCalculation.Maintenance = Convert.ToDecimal(txtMaintenance.Value);
            calculation.LeasingCalculation.MaintenanceActual = Convert.ToDecimal(txtMaintenanceActual.Value);
            calculation.LeasingCalculation.PV = Convert.ToDecimal(hidPV.Text);
            calculation.LeasingCalculation.PMT = Convert.ToDecimal(hidPMT.Text);
            calculation.LeasingCalculation.MonthlyChargeActual = Convert.ToDecimal(txtMonthlyCharge.Value);
            calculation.LeasingCalculation.MonthlyCharge = Convert.ToDecimal(txtRound.Value);


            
            calculation.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Value);
            calculation.DiscountTotal = Convert.ToDecimal(txtDiscountTotal.Value);


            
        }

        #region Validate Calculation

        private bool validateCalculation()
        {
            return (validateVehicleDetails() && 
                validateBodyPrice() && 
                validatePercentResidual() &&
                validateLeaseTerm() && 
                validatePercentRateOfReturn() && 
                validateInsurancePremium() && 
                validateRegister() && 
                validateMaintenance() && 
                validateMonthlyCharge() &&
                validateRoundTo());
        }

        private bool validateVehicleDetails()
        {
            if (cboCustomer.SelectedIndex == -1)
            {
                Message(MessageList.Error.E0005, " Customer");
                cboCustomer.Focus();
                return false;
            }
            else if (cboBrand.SelectedIndex == -1)
            {
                Message(MessageList.Error.E0005, " Brand");
                cboBrand.Focus();
                return false;
            }
            else if (cboModel.SelectedIndex == -1)
            {
                Message(MessageList.Error.E0005, " Model");
                cboModel.Focus();
                return false;
            }
            //Delete color from calculation : woranai 2009/02/18
            //else if (cboColor.SelectedIndex == -1)
            //{
            //    Message(MessageList.Error.E0005, " Color");
            //    cboColor.Focus();
            //    return false;
            //}
            else
            { return true; }
        }

        private bool validateBodyPrice()
        {
            if (Convert.ToDecimal(txtBodyPrice.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtBodyPrice, "Body Price must be greater than 0");
                txtBodyPrice.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validatePercentResidual()
        {
            if (Convert.ToDecimal(txtPercentResidual.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtPercentResidual, "Percent Residual must be greater than 0");
                txtPercentResidual.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateLeaseTerm()
        {
            if (Convert.ToDecimal(txtLeaseTerm.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtLeaseTerm, "Lease Term must be greater than 0");
                txtLeaseTerm.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validatePercentRateOfReturn()
        {
            if (Convert.ToDecimal(txtPercentRateOfReturn.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtPercentRateOfReturn, "Rate of Return must be greater than 0");
                txtPercentRateOfReturn.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateInsurancePremium()
        {
            if (Convert.ToDecimal(txtInsurancePremium.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtInsurancePremium, "Insurance Premium must be greater than 0");
                txtInsurancePremium.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateRegister()
        {
            if (Convert.ToDecimal(txtRegister.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtRegister, "Tax and Register must be greater than 0");
                txtRegister.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateMaintenance()
        {
            if (Convert.ToDecimal(txtMaintenance.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtMaintenance, "Maintenance must be greater than 0");
                txtMaintenance.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateInterestRate()
        {
            //Not use for process : woranai 2008/12/19
            return true;
        }

        private bool validateDepreciation()
        {
            if (Convert.ToDecimal(txtDepreciation.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtDepreciation, "Depreciation must be greater than 0");
                txtDepreciation.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateRoundTo()
        {
            if (Convert.ToDecimal(txtRound.Value) == decimal.Zero)
            {
                erpLeasing.SetError(txtRound, "Round to must be greater than 0");
                txtRound.Focus();
                return false;
            }

            erpLeasing.Clear();
            return true;
        }

        private bool validateMonthlyCharge()
        {
            if (Convert.ToDecimal(txtMonthlyCharge.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0017);
                btnCalculate.Focus();
                return false;
            }
            return true;
        }

        private bool validateCalculateCharge()
        {
            VehicleLeasingCalculation cal = facadeVehicleCalculation.CalculateMonthlyCharge(getCalculation());

            if (decimal.Round(cal.MonthlyChargeActual, 2) != Convert.ToDecimal(txtMonthlyCharge.Value))
            {
                Message(MessageList.Error.E0017);
                btnCalculate.Focus();
                return false;
            }
            return true;
        }
         
        #endregion

        #endregion

        #region Public Method

        /// <summary>
        /// Function    : Initail form for add new calculation.
        /// Author      : Thawatchai B.
        /// Create Date : 09/10/08
        /// </summary>
        public void InitAddAction()
        {
            baseADD();
            VehicleCalculation value = new VehicleCalculation();
            initForm(value);
        }

        /// <summary>
        /// Function    : Initail form for edit existing calculation.
        /// Author      : Thawatchai B.
        /// Create Date : 09/10/08
        /// </summary>
        /// <param name="value"></param>
        public void InitEditAction(VehicleCalculation value)
        {
            baseEDIT();
            InitCalculationHeader();
            initForm(value);
        }

        /// <summary>
        /// Function    : Initial calculation header combo box(customer,brand,model,color)
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        public void InitCalculationHeader()
        {
            cboCustomer.DataSource = EntitiesProvider.CustomerDataTable();
            cboBrand.DataSource = EntitiesProvider.BrandDataTable();

            //Delete color from quotation : woranai 2009/02/18
            //cboColor.DataSource = EntitiesProvider.ColorDataTable();
        }

        public bool AddEvent()
        {
            try
            {
                if (validateCalculation() && validateCalculateCharge())
                {
                    string calculationNo = parentForm.AddRow(getInsertCalculation());

                    if (calculationNo != "")
                    {
                        action = ActionType.EDIT;
                        hidCalculation_No.Text = calculationNo;

                        if (!btnPrintStatus && !btnQuotationStatus)
                        {
                            Message(MessageList.Information.I0001);
                        }

                        btnPrintStatus = false;
                        btnQuotationStatus = false;
                        return true;
                    }
                    else
                    {
                        Message(MessageList.Error.E0014, "บันทึกข้อมูลได้");
                        return false;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
                return false;
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
                return false;
            }
            catch (Exception ex)
            {
                Message(ex);
                return false;
            }

            return false;
        }

        public bool EditEvent()
        {
            try
            {
                if (validateCalculation() 
                    && validateCalculateCharge() 
                    && parentForm.UpdateRow(getUpdateCalculation()))
                {
                    if (!btnPrintStatus && !btnQuotationStatus)
                    {
                        Message(MessageList.Information.I0001);
                    }

                    btnPrintStatus = false;
                    btnQuotationStatus = false;
                    return true;
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
                return false;
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
                return false;
            }
            catch (Exception ex)
            {
                Message(ex);
                return false;
            }

            return false;
        }       

        #endregion

        #region Form Event

        private void FrmCalculation_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            VehicleCalculation calculation = new VehicleCalculation();

            calculation.DiscountTotal = Convert.ToDecimal(txtBodyPrice.Value) - Convert.ToDecimal(txtDiscountAmount.Value);

            txtDiscountTotal.Value = Convert.ToDecimal(calculation.DiscountTotal);

            calculateEvent();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrand.SelectedIndex != -1)
            {
                cboModel.DataSource = EntitiesProvider.ModelDataTable(cboBrand.SelectedValue.ToString());
                cboModel.SelectedIndex = 0;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            exitForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    AddEvent();
                    break;
                case ActionType.EDIT:
                    EditEvent();
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrintStatus = true;
            createReport();
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            btnQuotationStatus = true;
            createQuotation();
        }
        #endregion

        private void txtDiscountAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {

                VehicleCalculation calculation = new VehicleCalculation();
                
                calculation.DiscountTotal = Convert.ToDecimal(txtBodyPrice.Value) - Convert.ToDecimal(txtDiscountAmount.Value);

                txtDiscountTotal.Value = Convert.ToDecimal(calculation.DiscountTotal);
              
                
            }
        }

     
    }
}
