using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;
using Facade.VehicleFacade;
using Facade.VehicleFacade.VehicleLeasingFacade;
using Presentation.CommonGUI;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmVehicleQuotationEntry : EntryFormBase
    {
        #region Private Variable

        public delegate void SaveDataCompleteHandler(object sender, EventArgs e);
        public event SaveDataCompleteHandler SaveDataCompleted;
        private FrmVehicleQuotationList parentForm;
        private VehicleQuotationFacade facadeVehicleQuotation = new VehicleQuotationFacade();
        private VehicleCalculationFacade facadeVehicleCalculation = new VehicleCalculationFacade();
        private VehicleCalculation calculation;
        private VehicleInfo vehicleInfo = new VehicleInfo();
        private bool isFromCalculationScreen = false;

        //Check for disable form event when set value to control
        private bool isValueChange = true;
        //Condition to select vehicle for quotation
        private int quotationType
        {
            get { return rdbRenewType.Checked ? 0 : 1; }
        }

        #endregion

        #region Constructor
        public FrmVehicleQuotationEntry(VehicleQuotation quotation)
            : base()
        {
            InitializeComponent();
            InitControls();

            if (quotation.QuotationNo == null)
            {
                baseADD();
                LoadData(null);
            }
            else
            {
                baseEDIT();
                LoadData(quotation.QuotationNo);
            }

            PaintForm();
            SetEnableControls(true);
        }

        public FrmVehicleQuotationEntry(VehicleCalculation vehicleCalculation)
            : base()
        {
            InitializeComponent();

            parentForm = new FrmVehicleQuotationList();
            InitControls();
            calculation = vehicleCalculation;
            calculation.Quotation = new VehicleQuotation();


            //Todsporn Modified 25/2/2020 PO. Discount



            //calculation.LeasingNo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.LEASING_VEHICLE).ToString();
          
            calculation.Quotation.QuotationNo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.QUOTATION_VEHICLE);
            calculation.LeasingNo = calculation.Quotation.QuotationNo.ToString().Replace("PTB", "LC"); 
                   


        
                
                
                


            calculation.Quotation.Purchasing = new VehiclePurchasing();
            calculation.Quotation.VehicleContract = new VehicleContract();
            calculation.Quotation.KindOfVehicle = new KindOfVehicle();
            calculation.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(new ictus.Common.Entity.Company("12"));
            VehicleRole role = new VehicleRole();
            role.AVehicle = new Vehicle();
            calculation.Quotation.VehicleContract.AVehicleRoleList.Add(role);
            isFromCalculationScreen = true;
            InitForm();
            PaintForm();
            SetEnableControls(true);
        }
        #endregion

        #region Private Method
        private void InitControls()
        {
            double minValue = 0;
            double maxValuePercent = 100;
            double maxValueOther = 999999;
            txtBodyPrice.MinValue = txtModifyPrice.MinValue = minValue;
            txtBodyPrice.MaxValue = 99999999;
            txtCapitalInsurance.MinValue = 0;
            txtCapitalInsurance.MaxValue = 99999999;
            txtPercentResidual.MaxValue = txtPercentRateOfReturn.MaxValue = txtPercentRateOfReturnActual.MaxValue = txtInterestRate.MaxValue = txtDepreciation.MaxValue = txtDiscount.MaxValue = maxValuePercent;
            cboCustomer.DataSource = facadeVehicleCalculation.DataSourceCustomer;
            txtDeliveryDay.MinValue = 1;
            txtLeaseTerm.MinValue =0;
            dtpIssueDate.Value = DateTime.Today.Date;
            dtpValidityDate.Value = DateTime.Today.Date;
            dtpVendorDate.Value = DateTime.Today.Date;
            dtpValidityDate.Checked = false;
            dtpVendorDate.Checked = false;
            chkCusAccept.Checked = false;

            cboKindOfVehicle.DataSource = GetKindOfVehicleList();
            //cboKindOfVehicle.ValueMember = "Code";
        }

        private void InitForm()
        {
            //txtQuotationYY.Text = "";
            //txtQuotationMM.Text = "";
            //txtQuotationXXX.Text = "";
            

            //txtDeliveryDay.Value = 0;
            
            //cboKindOfVehicle.SelectedIndex = -1;
            //cboSecondHand.SelectedIndex = -1;

            //txtPlateNoPrefix.Text = "";
            //txtPlateNoRunning.Text = "";
            //txtBrand.Text = "";
            //txtModel.Text = "";
            //txtColor.Text = "";


            //txtBodyPrice.Value = 0;
            //txtModifyPrice.Value = 0;
            //txtPercentResidual.Value = 0;

            //txtLeaseTerm.Value = 0;
            //txtPercentRateOfReturn.Value = 0;
            //txtPercentRateOfReturnActual.Value = 0;
            //txtCapitalInsurance.Value = 0;
            //txtInsurancePremium.Value = 0;
            //txtRegister.Value = 0;
            //txtMaintenance.Value = 0;
            //txtMaintenanceActual.Value = 0;
            //txtInterestRate.Value = 0;
            //txtDepreciation.Value = 0;
            //txtMonthlyCharge.Value = 0;
            //txtRound.Value = 0;


            //txtRemark.Text = "";

        }

        private void SetEnableControls(bool isEnable)
        {
            bool isCreatedPO = !(calculation.Quotation.Purchasing.PurchasNo == null && calculation.Quotation.VehicleContract.ContractNo == null);
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;
            bool isCustomerAccept = chkCusAccept.Checked;

            gpbQTDetail.Enabled = isEnable && !isCreatedPO;
            gpbDetailOfVehicle.Enabled = isEnable && !isCreatedPO && isInsertMode;
            gpbVehicleCost.Enabled = isEnable && !isCreatedPO && isInsertMode;
            gpbLeasingDetail.Enabled = isEnable && !isCreatedPO && isInsertMode;
            gpbInterestDepre.Enabled = isEnable && !isCreatedPO && isInsertMode;
            gpbCalLeasing.Enabled = isEnable && !isCreatedPO && isInsertMode;
            gpbTypeOfLeasing.Enabled = isEnable && !isCreatedPO && !isEditMode && !isFromCalculationScreen;

            dtpIssueDate.Enabled = isEnable && !isCreatedPO && isNew;
            dtpValidityDate.Enabled = isEnable && !isCreatedPO && isNew;
            dtpVendorDate.Enabled = isEnable && !isCreatedPO && isNew;
            txtDeliveryDay.Enabled = isEnable && !isCreatedPO && isNew;
            chkCusAccept.Enabled = isEnable && !isCreatedPO && isNew;
            cboSecondHand.Enabled = isEnable && false;
            cboKindOfVehicle.Enabled = isEnable && !isCreatedPO && (isNew || (isUsed && isInsertMode));
            //dtpIssueDate.Enabled = isEnable && isInsertMode && isNew;


            btnSearchCalculation.Enabled = isEnable && isNew;
            txtPlateNoPrefix.Enabled = isEnable && !isNew;
            txtPlateNoRunning.Enabled = isEnable && !isNew;
            cboCustomer.Enabled = isEnable && isInsertMode && isUsed;
            txtBrand.Enabled = !isEnable;
            txtModel.Enabled = !isEnable;
            txtModifyPrice.Enabled = isEnable && isInsertMode && !isNew;

            txtBodyPrice.Enabled = isEnable && false;
            txtModifyPrice.Enabled = isEnable && false;
            txtPercentResidual.Enabled = isEnable && false;
            txtLeaseTerm.Enabled = isEnable && isInsertMode && !isNew;
            txtPercentRateOfReturn.Enabled = isEnable && false;
            txtPercentRateOfReturnActual.Enabled = isEnable && false;
            txtCapitalInsurance.Enabled = isEnable && false;
            txtInsurancePremium.Enabled = isEnable && false;
            txtRegister.Enabled = isEnable && false;
            txtMaintenance.Enabled = isEnable && false;
            txtMaintenanceActual.Enabled = isEnable && false;
            txtInterestRate.Enabled = isEnable && false;
            txtDepreciation.Enabled = isEnable && false;
            txtMonthlyCharge.Enabled = isEnable && isInsertMode && !isNew;
            txtRound.Enabled = isEnable && isInsertMode && !isNew;
            txtDiscount.Enabled = isEnable && isInsertMode && !isNew;
            btnCalculateDiscount.Enabled = isEnable && isInsertMode && !isNew;

            txtRemark.Enabled = isEnable;

            btnSave.Enabled = isEnable;
            btnPrint.Enabled = isEnable;
            btnPO.Enabled = isEnable && !isCreatedPO && isNew;
            btnClose.Enabled = isEnable;
        }

        private void PaintForm()
        {
            isValueChange = false;

            txtQuotationYY.Text = calculation.Quotation.QuotationNo.Year.ToString();
            txtQuotationMM.Text = calculation.Quotation.QuotationNo.Month.ToString();
            txtQuotationXXX.Text = calculation.Quotation.QuotationNo.No.ToString();

            //Todsporn Modified 25/2/2020 PO. Discount

            txtLeasingYY.Text = calculation.Quotation.QuotationNo.Year.ToString();
            txtLeasingMM.Text = calculation.Quotation.QuotationNo.Month.ToString();
            txtLeasingXXX.Text = calculation.Quotation.QuotationNo.No.ToString();


            txtDiscountAmount.Value = Convert.ToDouble(calculation.DiscountAmount);
            txtDiscountTotal.Value = Convert.ToDouble(calculation.DiscountTotal);



            dtpIssueDate.Value = calculation.Quotation.IssueDate.HasValue ? calculation.Quotation.IssueDate.Value.Date : DateTime.Now.Date;

            if (calculation.Quotation.ValidityDate.HasValue)
            {
                dtpValidityDate.Value = calculation.Quotation.ValidityDate.Value.Date;
                dtpValidityDate.Checked = true;
            }
            else
            {
                dtpValidityDate.Value = DateTime.Now.Date;
                dtpValidityDate.Checked = false;
            }

            txtDeliveryDay.Value = Convert.ToDouble(calculation.Quotation.DeliveryDays);
            chkCusAccept.Checked = calculation.Quotation.IsCustomerAccept == true ? true : false;
            cboKindOfVehicle.Text = calculation.Quotation.KindOfVehicle.AName.English;
            cboSecondHand.SelectedIndex = calculation.Quotation.IsSecondHand == true ? 0 : 1;

            if (calculation.Quotation.VendorQuotationDate.HasValue)
            {
                dtpVendorDate.Value = calculation.Quotation.VendorQuotationDate.Value.Date;
                dtpVendorDate.Checked = true;
            }
            else
            {
                dtpVendorDate.Value = DateTime.Now.Date;
                dtpVendorDate.Checked = false;
            }

            rdbNewType.Checked = calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.NEWQ;
            rdbRenewType.Checked = calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.RENEWALQ;
            rdbUsedType.Checked = calculation.Quotation.QuotationStatus == QUOTATION_STATUS_TYPE.USEDQ;

            txtBodyPrice.Value = Convert.ToDouble(calculation.BodyCost);
            txtModifyPrice.Value = Convert.ToDouble(calculation.ModifyCost);
            txtPercentResidual.Value = Convert.ToDouble(calculation.LeasingCalculation.PercentResidual);
            txtLeaseTerm.Value = Convert.ToDouble(calculation.LeasingCalculation.LeaseTerm);
            txtPercentRateOfReturn.Value = Convert.ToDouble(calculation.LeasingCalculation.RateOfReturnEstimate);
            txtPercentRateOfReturnActual.Value = Convert.ToDouble(calculation.LeasingCalculation.RateOfReturnActual);
            txtCapitalInsurance.Value = Convert.ToDouble(calculation.LeasingCalculation.CapitalInsurance);
            txtInsurancePremium.Value = Convert.ToDouble(calculation.LeasingCalculation.InsurancePremium);
            txtRegister.Value = Convert.ToDouble(calculation.LeasingCalculation.TaxRegister);
            txtMaintenance.Value = Convert.ToDouble(calculation.LeasingCalculation.Maintenance);
            txtMaintenanceActual.Value = Convert.ToDouble(calculation.LeasingCalculation.MaintenanceActual);
            txtInterestRate.Value = Convert.ToDouble(calculation.LeasingCalculation.InterestRate);
            txtDepreciation.Value = Convert.ToDouble(calculation.Depreciation);
            txtMonthlyCharge.Value = Convert.ToDouble(calculation.LeasingCalculation.MonthlyChargeActual);
            txtRound.Value = Convert.ToDouble(calculation.LeasingCalculation.MonthlyCharge);
            txtRemark.Text = calculation.Quotation.Remark;

            cboCustomer.Text = calculation.Customer.ToString();

            if (calculation.Model != null)
            {
                txtBrand.Text = calculation.Model.ABrand.ToString();
                txtModel.Text = calculation.Model.ToString();
                //txtColor.Text = calculation.Color.ToString();
            }
            else
            {
                txtBrand.Text = string.Empty;
                txtModel.Text = string.Empty;
                //txtColor.Text = string.Empty;
            }

            if (calculation.Quotation.Vehicle != null)
            {
                txtPlateNoPrefix.Text = calculation.Quotation.Vehicle.PlatePrefix;
                txtPlateNoRunning.Text = calculation.Quotation.Vehicle.PlateRunningNo;
            }
            else
            {
                txtPlateNoPrefix.Text = string.Empty;
                txtPlateNoRunning.Text = string.Empty;
            }

            isValueChange = true;
        }

        private void enableCalculation(bool enable)
        {
            gpbDetailOfVehicle.Enabled = enable;
            gpbVehicleCost.Enabled = enable;
            gpbLeasingDetail.Enabled = enable;
            gpbInterestDepre.Enabled = enable;
            gpbCalLeasing.Enabled = enable;
            gpbTypeOfLeasing.Enabled = enable;
        }


        private void exitEvent()
        {
            this.Close();
        }

        private bool SaveData(bool isPrint)
        {
            bool result = false;
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            try
            {
                if (ValidateData())
                {
                    if (isPrint)
                    {
                        result = Message(MessageList.Question.Q0017) == DialogResult.Yes;
                    }
                    else
                    {
                        if (isInsertMode)
                        {
                            if (isNew)
                            {
                                result = Message(MessageList.Question.Q0002, "ตกลง", "กลับไปแก้ไข Calculation ", "บันทึก") == DialogResult.Yes;
                            }
                            else
                            {
                                result = Message(MessageList.Question.Q0002, "ตกลง", "อนุญาติให้แก้ไขข้อมูลได้เนื่องจากมีการสร้างสัญญาในระบบ ", "บันทึก") == DialogResult.Yes;
                            }
                        }
                        else
                        {
                            result = true;
                        }
                    }

                    if (result)
                    {
                        ReadQuotation();
                        ReadCalLeasing();


                        if (isInsertMode)
                        {
                            facadeVehicleQuotation.InsertVehicleQuotation(calculation);

                            if (!isPrint)
                            {
                                Message(MessageList.Information.I0001);
                                OnSaveDataCompleted(this, new EventArgs());
                            }
                        }
                        else
                        {
                            facadeVehicleQuotation.UpdateVehicleQuotation(calculation.Quotation);
                            facadeVehicleQuotation.UpdateVehicleLeasing(calculation);



                            if (!isPrint)
                            {
                                Message(MessageList.Information.I0001);
                                OnSaveDataCompleted(this, new EventArgs());
                            }
                        }

                        action = ActionType.EDIT;
                        SetEnableControls(true);
                        result = true;
                    }
                    else
                    {
                        result = false;
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

            return result;
        }

        private bool ValidateData()
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;
           
            if (!isNew && calculation.Quotation.Vehicle == null)
            {
                Message(MessageList.Error.E0005, "รถ ก่อนทำการบันทึก");
                txtPlateNoPrefix.Focus();
                return false;
            }

            if (!dtpValidityDate.Checked)
            {
                Message(MessageList.Error.E0005, " Validity Date");
                dtpValidityDate.Focus();
                return false;
            }

            if (!dtpVendorDate.Checked)
            {
                Message(MessageList.Error.E0005, " Vendor Date");
                dtpVendorDate.Focus();
                return false;
            }

            if (dtpValidityDate.Value.Date < dtpIssueDate.Value.Date)
            {
                Message(MessageList.Error.E0018, "Validity Date", "Quotation Date");
                dtpValidityDate.Focus();
                return false;
            }

            if (cboKindOfVehicle.Text == string.Empty)
            {
                Message(MessageList.Error.E0005, " Using Type");
                cboKindOfVehicle.Focus();
                return false;
            }

            if (((Customer)cboCustomer.SelectedItem).Code == Customer.DUMMYCODE)
            {
                Message(MessageList.Error.E0005, " Customer");
                cboCustomer.Focus();
                return false;
            }

            if (isInsertMode && isNew)
            {

                if (calculation.CalculationNo == Guid.Empty)
                {
                    Message(MessageList.Error.E0005, " Calculation");
                    btnSearchCalculation.Focus();
                    return false;
                }
                calculation.Quotation.VehicleContract.ContractNo = null;
            }

            if (isInsertMode && (isRenew || isUsed))
            {
                calculation.CalculationNo = new Guid();
            }

            if (Convert.ToDecimal(txtLeaseTerm.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0025, "Lease Term ", " 0");
                txtLeaseTerm.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtRound.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0025, "Round To ", " 0");
                txtRound.Focus();
                return false;
            }

            return true;
        }

        private void searchCalculation()
        {
            FrmQuotationSearchCalculation frmCalculationSearch = new FrmQuotationSearchCalculation();
            frmCalculationSearch.SelectFinished += new FrmQuotationSearchCalculationEventHandler(frmCalculationSearch_SelectFinished);
            frmCalculationSearch.ShowDialog();
        }

        private void frmCalculationSearch_SelectFinished(object sender, FrmQuotationSearchCalculationEventArgs e)
        {
            VehicleQuotation tempQuotation = calculation.Quotation;
            calculation = e.VehicleCalculation;
            calculation.Quotation = tempQuotation;
            calculation.LeasingNo = tempQuotation.QuotationNo.ToString().Replace("PTB","LC");
            cboCustomer.Enabled = false;

            PaintForm();
        }

        private void createReport()
        {
            if (ValidateData())
            {
                if (SaveData(true))
                {
                    FrmrptQuotationReport frmrptQuotationReport = new FrmrptQuotationReport(calculation.Quotation.QuotationNo);
                    frmrptQuotationReport.Show();
                }
            }
        }

        private bool CreatePO()
        {
            if (ValidateData())
            {
                if (SaveData(false))
                {
                    FrmPurchaseOrderEntry frmPurchaseOrderEntry = new FrmPurchaseOrderEntry(calculation);
                    frmPurchaseOrderEntry.ShowDialog();
                }

                return true;
            }

            return false;
        }

        private void CalculateEvent()
        {
            decimal monthlyCharge = Convert.ToDecimal(txtMonthlyCharge.Value);
            decimal discountRate = Convert.ToDecimal(txtDiscount.Value) / 100M;
            decimal discount = monthlyCharge * discountRate;
            decimal result = monthlyCharge - discount;

            calculation.LeasingCalculation.MonthlyCharge = result;
            calculation.LeasingCalculation.MonthlyChargeActual = monthlyCharge;

            txtRound.Value = result;
            txtMonthlyCharge.Value = monthlyCharge;
        }

        private void LoadData(DocumentNo docNo)
        {
            if (docNo != null)
            {
                calculation = facadeVehicleCalculation.GetVehicleSearchConditionByQuotationNo(docNo);

                   
                calculation.Quotation = facadeVehicleQuotation.GetQuotationtByQuotationNo(docNo.ToString());
                //Todsporn Modified 25/2/2020 PO. Discount

        
                calculation.LeasingNo= calculation.Quotation.QuotationNo.ToString().Replace("PTB","LC");
          


                
       
              



            }
            else
            {
                calculation = new VehicleCalculation();
                calculation.CalculationNo = new Guid();
                calculation.Quotation = new VehicleQuotation();

                //Todsporn Modified 25/2/2020 PO. Discount
 

                //calculation.LeasingNo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.LEASING_VEHICLE).ToString();

                calculation.Quotation.QuotationNo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.QUOTATION_VEHICLE);

                calculation.LeasingNo = calculation.Quotation.QuotationNo.ToString().Replace("PTB", "LC");
     
            
                    


                calculation.Quotation.Purchasing = new VehiclePurchasing();
                calculation.Quotation.VehicleContract = new VehicleContract();
                calculation.LeasingCalculation = new VehicleLeasingCalculation();
                calculation.LeasingCalculation.LeaseTerm = 1;
                calculation.Quotation.KindOfVehicle = new KindOfVehicle();
                calculation.Quotation.KindOfVehicle.Code = string.Empty;
                calculation.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(new ictus.Common.Entity.Company("12"));
                VehicleRole role = new VehicleRole();
                role.AVehicle = new Vehicle();
                calculation.Quotation.VehicleContract.AVehicleRoleList.Add(role);
                calculation.Customer = new Customer(Customer.DUMMYCODE);
                //calculation.Quotation.Purchasing = null;
            }

        }

        private void ClearData()
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            VehicleCalculation temp = new VehicleCalculation();
            temp.Quotation = new VehicleQuotation();
            temp.Quotation.VehicleContract = new VehicleContract();
            temp.LeasingCalculation = new VehicleLeasingCalculation();
            //temp.LeasingCalculation.LeaseTerm = 1;
            temp.Quotation.KindOfVehicle = new KindOfVehicle();
            temp.Quotation.KindOfVehicle.Code = string.Empty;
            temp.Quotation.Purchasing = new VehiclePurchasing();
            temp.Quotation.VehicleContract.AVehicleRoleList = new VehicleRoleList(new ictus.Common.Entity.Company("12"));
            VehicleRole role = new VehicleRole();
            role.AVehicle = new Vehicle();
            temp.Quotation.VehicleContract.AVehicleRoleList.Add(role);
            temp.Customer = new Customer(Customer.DUMMYCODE);
            //temp.Quotation.Purchasing = null;

            temp.CalculationNo = calculation.CalculationNo;
            temp.Quotation.ValidityDate = null;
            temp.Quotation.VendorQuotationDate = null;
            temp.IssueDate = dtpIssueDate.Value.Date;
            temp.Quotation.DeliveryDays = Convert.ToInt32(txtDeliveryDay.Value);
            temp.Quotation.IsCustomerAccept = (chkCusAccept.Checked == true ? true : false);
            temp.Quotation.IsSecondHand = (cboSecondHand.SelectedIndex == 0 ? true : false);
            temp.Quotation.KindOfVehicle.Code = string.Empty;
//            temp.Quotation.KindOfVehicle.Code = (cboKindOfVehicle.SelectedIndex == 0 ? "1" : "2");
            temp.Quotation.QuotationNo = calculation.Quotation.QuotationNo;
            temp.LeasingNo = calculation.LeasingNo;


            if (isNew)
            {
                temp.Quotation.QuotationStatus = QUOTATION_STATUS_TYPE.NEWQ;
                temp.Quotation.IsSecondHand = false;
            }
            else
            {
                temp.Quotation.IsSecondHand = true;
                temp.Quotation.ValidityDate = DateTime.Now.Date;
                temp.Quotation.VendorQuotationDate = DateTime.Now.Date;
                temp.IssueDate = DateTime.Now.Date;
                temp.Quotation.DeliveryDays = 1;
                temp.Quotation.IsSecondHand = true;
            }
            if (isRenew)
            {
                temp.Quotation.QuotationStatus = QUOTATION_STATUS_TYPE.RENEWALQ;
                temp.LeasingCalculation.LeaseTerm = 12;
            }
            else
            {
                temp.LeasingCalculation.LeaseTerm = 0;
            }
            if (isUsed) temp.Quotation.QuotationStatus = QUOTATION_STATUS_TYPE.USEDQ;

            calculation = temp;
        }

        private void ReadQuotation()
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            VehicleQuotation quotation = calculation.Quotation;
    
            //quotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, txtQuotationYY.Text, txtQuotationMM.Text, txtQuotationXXX.Text);
            quotation.ValidityDate = dtpValidityDate.Value.Date;
            quotation.IssueDate = dtpIssueDate.Value.Date;
            quotation.DeliveryDays = Convert.ToInt32(txtDeliveryDay.Value);
            quotation.IsCustomerAccept = (chkCusAccept.Checked == true ? true : false);
            quotation.IsSecondHand = (cboSecondHand.SelectedIndex == 0 ? true : false);
            quotation.KindOfVehicle = (KindOfVehicle)cboKindOfVehicle.SelectedItem;
            //            quotation.KindOfVehicle.Code = (cboKindOfVehicle.SelectedIndex == 0 ? "1" : "2");
            quotation.BodyCost = Convert.ToDecimal(txtBodyPrice.Value);
            quotation.ModifyCost = Convert.ToDecimal(txtModifyPrice.Value);
            quotation.Remark = txtRemark.Text;

            if (isNew) quotation.QuotationStatus = QUOTATION_STATUS_TYPE.NEWQ;
            if (isRenew) quotation.QuotationStatus = QUOTATION_STATUS_TYPE.RENEWALQ;
            if (isUsed) quotation.QuotationStatus = QUOTATION_STATUS_TYPE.USEDQ;

            quotation.VendorQuotationDate = dtpVendorDate.Value.Date;
            quotation.LeasingNo = calculation.LeasingNo;
          

        }

        private void ReadCalLeasing()
        {
            //For renewal doesn't get customer from combobox : woranai 2008/11/26
            if (!rdbRenewType.Checked)
            {
                calculation.Customer = (Customer)cboCustomer.SelectedItem;
            }

            //price for calculation

            calculation.BodyCost = Convert.ToDecimal(txtBodyPrice.Value);
            calculation.ModifyCost = Convert.ToDecimal(txtModifyPrice.Value);
            calculation.LeasingCalculation.PercentResidual = Convert.ToDecimal(txtPercentResidual.Value);
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
            calculation.LeasingCalculation.MonthlyCharge = Convert.ToDecimal(txtRound.Value);

           
            calculation.LeasingCalculation.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Value);
            calculation.LeasingCalculation.DiscountTotal = Convert.ToDecimal(txtDiscountTotal.Value);



        }

        private void searchVehicle(string prefix, string num)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            Vehicle vehicle = VehicleFacade.GetVehicleByPlateNo(prefix, num);

            if (vehicle != null)
            {
                calculation.Quotation.VehicleContract.AVehicleRoleList[0].AVehicle = vehicle;
                calculation.Model = vehicle.AModel;

                //Delete color from calculation : woranai 2009/02/18
                //calculation.Color = vehicle.AColor;

                calculation.Customer = getCustomerFromCurrentVehicleContract(vehicle);

                if (isInsertMode && !isNew)
                {
                    calculation.LeasingCalculation.MonthlyChargeActual = GetCurrentMonthlyCharge(vehicle);
                    calculation.Quotation.KindOfVehicle = GetKindOfVehicle(vehicle);
                }
            }
            else
            {
                Message(MessageList.Error.E0004, "เลขทะเบียนรถ");
                clearVehicleDetail();
                txtPlateNoPrefix.Focus();
            }
        }

        private decimal GetCurrentMonthlyCharge(Vehicle vehicle)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            ContractBase contract = facadeVehicleQuotation.GetCurrentVehicleContract(vehicle);

            decimal result = 0M;
            if (contract != null)
            {
                if (contract.AContractChargeList != null && contract.AContractChargeList.Count > 0)
                {
                    int maxIndex = contract.AContractChargeList.Count - 1;
                    result = contract.AContractChargeList[maxIndex].MonthlyCharge;
                }
            }
            return result;
        }

        private KindOfVehicle GetKindOfVehicle(Vehicle vehicle)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            VehicleContract contract = (VehicleContract)facadeVehicleQuotation.GetCurrentVehicleContract(vehicle);

            KindOfVehicle result = new KindOfVehicle();
            result.Code = "1";
            if (contract != null)
            {
                result = contract.AVehicleRoleList[0].AKindOfVehicle;
            }

            return result;
        }

        private Customer getCustomerFromCurrentVehicleContract(Vehicle vehicle)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            ContractBase contract = facadeVehicleQuotation.GetCurrentVehicleContract(vehicle);

            Customer result = new Customer(Customer.DUMMYCODE);
            if (contract != null && isRenew)
            {
                result = contract.ACustomer;
            }

            return result;
        }

        private bool validateVehicle(string platePrefix, string plateNo)
        {
            if (!facadeVehicleQuotation.FillVehicleForCreateQuotation(platePrefix, plateNo, quotationType))
            {
                Message(MessageList.Error.E0004, "ทะเบียนรถ");
                clearVehicleDetail();
                txtPlateNoPrefix.Focus();
                return false;
            }
            return true;
        }

        private void clearVehicleDetail()
        {
            txtPlateNoRunning.Clear();
            txtPlateNoPrefix.Clear();
        }
        #endregion

        public void SelectedVehicleCalculation(VehicleCalculation vehicleCalculation)
        {
            VehicleQuotation tempQuotation = calculation.Quotation;
            calculation = vehicleCalculation;
            calculation.Quotation = tempQuotation;
            calculation.LeasingNo = tempQuotation.QuotationNo.ToString().Replace("PTB","LC");
            cboCustomer.Enabled = false;

            PaintForm();
        }

        #region Form Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            createReport();
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;

            if (chkCusAccept.Checked)
            {
                if (Message(MessageList.Question.Q0016, "ใบสั่งซื้อ") == DialogResult.Yes)
                {
                    if (CreatePO())
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                Message(MessageList.Error.E0056);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            exitEvent();
        }

        private void btnSearchCalculation_Click(object sender, EventArgs e)
        {
            searchCalculation();
        }

        void frmSearch_SelectFinished(object sender, FrmQuotationSearchVehicleEventArgs e)
        {
            
            ReadCalLeasing();
            ReadQuotation();
            searchVehicle(e.Vehicle.PlatePrefix, e.Vehicle.PlateRunningNo);
            PaintForm();
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            bool isInsertMode = action == ActionType.ADD;
            bool isEditMode = action == ActionType.EDIT;
            bool isNew = rdbNewType.Checked;
            bool isRenew = rdbRenewType.Checked;
            bool isUsed = rdbUsedType.Checked;
            if (isInsertMode)
            {
                ClearData();
                PaintForm();
            }
            SetEnableControls(true);
        }

        private void btnCalculateDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                ReadCalLeasing();
                CalculateEvent();

                if (!rdbUsedType.Checked)
                {
                    PaintForm();
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calculation != null)
                calculation.Customer = (Customer)cboCustomer.SelectedItem;
        }

        private void txtPlateNoRunning_KeyDown(object sender, KeyEventArgs e)
        {
            if (isValueChange && e.KeyCode == Keys.Enter && txtPlateNoPrefix.Text.Trim().Length == 2)
            {
                ReadCalLeasing();
                ReadQuotation();
                searchVehicle(txtPlateNoPrefix.Text, txtPlateNoRunning.Text);

                if (calculation.Quotation.Vehicle == null)
                {
                    Message(MessageList.Error.E0004, "ทะเบียนรถ");
                    clearVehicleDetail();
                    txtPlateNoPrefix.Focus();
                }
                else
                {
                    PaintForm();
                }
            }

        }

        private void txtPlateNoRunning_DoubleClick(object sender, EventArgs e)
        {
            FrmQuotationSearchVehicle frmSearch = new FrmQuotationSearchVehicle(txtPlateNoPrefix.Text, txtPlateNoRunning.Text, quotationType);
            frmSearch.SelectFinished += new FrmQuotationSearchVehicleEventHandler(frmSearch_SelectFinished);
            frmSearch.ShowDialog();
        }

        private void txtPlateNoPrefix_TextChanged(object sender, EventArgs e)
        {
            if (isValueChange && txtPlateNoPrefix.Text.Length == txtPlateNoPrefix.MaxLength)
            {
                txtPlateNoRunning.Focus();
            }
        }

        private void txtPlateNoRunning_TextChanged(object sender, EventArgs e)
        {
            if (isValueChange && txtPlateNoRunning.Text.Length == 4 && txtPlateNoPrefix.Text.Length == txtPlateNoPrefix.MaxLength)
            {
                if (validateVehicle(txtPlateNoPrefix.Text, txtPlateNoRunning.Text))
                {
                    searchVehicle(txtPlateNoPrefix.Text.Trim(), txtPlateNoRunning.Text.Trim());
                    PaintForm();
                }
            }
        }

        private void chkCusAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (isValueChange)
            {
                ReadQuotation();
                SetEnableControls(true);
            }
        }

        private void OnSaveDataCompleted(object sender, EventArgs e)
        {
            if (SaveDataCompleted != null) SaveDataCompleted(sender, e);
        }       

        private List<KindOfVehicle> GetKindOfVehicleList()
        {
            List<KindOfVehicle> result = new List<KindOfVehicle>();
            KindOfVehicle item1 = new KindOfVehicle();
            KindOfVehicle item2 = new KindOfVehicle();
            KindOfVehicle item3 = new KindOfVehicle();

            item1.Code = "0";
            item1.AName.English = string.Empty;
            item2.Code = "1";
            item2.AName.English = "Office Car";
            item3.Code = "2";
            item3.AName.English = "Family Car";

            result.Add(item1);
            result.Add(item2);
            result.Add(item3);
             
            return result;
        }      

        #endregion

        private void txtDiscountAmount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                VehicleCalculation calculation = new VehicleCalculation();

                calculation.DiscountTotal = Convert.ToDecimal(txtBodyPrice.Value) - Convert.ToDecimal(txtDiscountAmount.Value);

                txtDiscountTotal.Value = Convert.ToDecimal(calculation.DiscountTotal);


            }



        }

        

      
    }
}
