using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;
using Facade.VehicleFacade.VehicleLeasingFacade;
using FarPoint.Win.Input;
using Presentation.CommonGUI;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmPurchaseOrderEntry : EntryFormBase
    {
        #region Private

        private const int MIN_VEHICLE_UNIT = 1;
        private const int MAX_VEHICLE_UNIT = 99;
        private const int DEFAULT_VEHICLE_UNIT = 1;

        private FrmPurchaseOrderList parentForm;
        private FrmPOSearchQuotation frmPOSearchQuotation;
        private VehiclePurchasingFacade facadeVehiclePurchasing;
        private VehicleQuotationFacade facadeVehicleQuotation;
        private VehicleCalculationFacade facadeVehicleCalculation;
        #endregion

        #region Constructor

        public FrmPurchaseOrderEntry()
        {
            InitializeComponent();
        }

        public FrmPurchaseOrderEntry(FrmPurchaseOrderList value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            facadeVehicleQuotation = new VehicleQuotationFacade();
            facadeVehiclePurchasing = new VehiclePurchasingFacade();
            facadeVehicleCalculation = new VehicleCalculationFacade();
        }

        public FrmPurchaseOrderEntry(VehicleCalculation vehicleCalculation)
            : base()
        {
            InitializeComponent();
            facadeVehicleQuotation = new VehicleQuotationFacade();
            facadeVehiclePurchasing = new VehiclePurchasingFacade();
            parentForm = new FrmPurchaseOrderList();
            addEvent(vehicleCalculation);
        }

        #endregion

        #region Private Method
        private void initControls()
        {
            txtVehiclePrice.MinValue = 0;
            txtVehiclePrice.MaxValue = 9999999.99;
            cboColor.Enabled = true;
        }

        private void initCalculationHeader()
        {
            cboCustomer.DataSource = facadeVehiclePurchasing.DataSourceCustomer;
            cboBrand.DataSource = facadeVehiclePurchasing.DataSourceBrand;
            cboColor.DataSource = facadeVehiclePurchasing.DataSourceColor;

            cboCustomer.SelectedIndex = -1;
            cboBrand.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            cboModel.SelectedIndex = -1;
        }

        private void initCalculationHeaderQuotation()
        {
            cboCustomer.DataSource = facadeVehiclePurchasing.DataSourceCustomer;
            cboBrand.DataSource = facadeVehiclePurchasing.DataSourceBrand;
            cboColor.DataSource = facadeVehiclePurchasing.DataSourceColor;
        }

        private void initPOHeader()
        {
            cboVendor.DataSource = facadeVehiclePurchasing.DataSourceVendor;
            cboVendor.SelectedIndex = -1;
        }

        private void initForm(VehicleQuotation selectedVehiclePurchasing)
        {
            if (action == ActionType.ADD)
            {
                initCalculationHeader();
            }

            if (action == ActionType.EDIT)
            {
                clearForm();
                VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
                VehicleCalculation vehicleCalculation = new VehicleCalculation();
                vehiclePurchasing = facadeVehiclePurchasing.SearchPurchaseOrderByPurchaseNo(selectedVehiclePurchasing.Purchasing.PurchasNo.ToString());
                selectedVehiclePurchasing.Purchasing = vehiclePurchasing;

                if (selectedVehiclePurchasing.QuotationNo != null)
                {
                    vehicleCalculation = facadeVehicleCalculation.GetVehicleSearchConditionByQuotationNo(selectedVehiclePurchasing.QuotationNo);
                }

                vehicleCalculation.Quotation = selectedVehiclePurchasing;

                if (vehiclePurchasing.PurchasNo != null)
                {
                    bindForm(vehicleCalculation);
                }
            }
        }

        private void bindForm(VehicleCalculation vehicleCalculation)
        {
            if (vehicleCalculation.Quotation.Purchasing != null)
            {
                txtPOYY.Text = vehicleCalculation.Quotation.Purchasing.PurchasNo.Year;
                txtPOMM.Text = vehicleCalculation.Quotation.Purchasing.PurchasNo.Month;
                txtPOXXX.Text = vehicleCalculation.Quotation.Purchasing.PurchasNo.No;

                if (vehicleCalculation.Quotation.QuotationNo != null)
                {
                    txtQuotationYY.Text = vehicleCalculation.Quotation.QuotationNo.Year;
                    txtQuotationMM.Text = vehicleCalculation.Quotation.QuotationNo.Month;
                    txtQuotationXXX.Text = vehicleCalculation.Quotation.QuotationNo.No;
                }

                if (vehicleCalculation.Quotation.Purchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE)
                {
                    lblPOStatus.Text = "Active";
                    lblPOStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblPOStatus.Text = "Cancel";
                    lblPOStatus.ForeColor = System.Drawing.Color.Red;
                }

                dtpVendorDate.Value = vehicleCalculation.Quotation.Purchasing.VendorQuotationDate.Value.Date;
                dtpVendorDate.Checked = true;
                txtUnit.Value = vehicleCalculation.Quotation.Purchasing.Quantity;
                txtUnit.Enabled = false;

                cboVendor.Text = vehicleCalculation.Quotation.Purchasing.Vendor.ToString();
                cboVendor.Tag = vehicleCalculation.Quotation.Purchasing.Vendor;

                //add by Aof 01/12/08
                if (vehicleCalculation.Customer != null)
                {
                    cboCustomer.Text = vehicleCalculation.Customer.ToString();
                }

                //end add
                cboBrand.Text = vehicleCalculation.Quotation.Purchasing.Model.ABrand.ToString();
                cboModel.Text = vehicleCalculation.Quotation.Purchasing.Model.ToString();
                cboColor.Text = vehicleCalculation.Quotation.Purchasing.Color.ToString();

                //add by Aof 01/12/08
                if (vehicleCalculation.Customer != null)
                {
                    cboCustomer.Tag = vehicleCalculation.Customer;
                }

                //end add
                cboBrand.Tag = vehicleCalculation.Quotation.Purchasing.Model.ABrand;
                cboModel.Tag = vehicleCalculation.Quotation.Purchasing.Model;
                cboColor.Tag = vehicleCalculation.Quotation.Purchasing.Color;

                txtVehiclePrice.Value = vehicleCalculation.Quotation.Purchasing.VehiclePrice;


                //Todsporn Modified 25/2/2020 PO. Discount

                txtDiscountAmount.Value = vehicleCalculation.Quotation.Purchasing.Discount_Amount;
                txtDiscountTotal.Value = vehicleCalculation.Quotation.Purchasing.Discount_Total;




                if (vehicleCalculation.Quotation.Purchasing.IsNewCar == true)
                {
                    rdbNewType.Checked = true;
                    rdbConType.Checked = false;
                }
                else
                {
                    rdbNewType.Checked = false;
                    rdbConType.Checked = true;
                }

                txtRemark.Text = vehicleCalculation.Quotation.Purchasing.Remark.ToString();
                //Todsporn Modified 25/2/2020 PO. Discount
                txtDiscountAmount.Value = vehicleCalculation.Quotation.Purchasing.Discount_Amount.ToString();
                txtDiscountTotal.Value = vehicleCalculation.Quotation.Purchasing.Discount_Total.ToString();

                if (action == ActionType.EDIT)
                {
                    if (canEdit(vehicleCalculation.Quotation.Purchasing))
                    {
                        enableAmend(true);
                        enablePODetails(true);
                    }
                    else
                    {
                        enableAmend(false);
                        enablePODetails(false);
                    }

                    //Case PO was cancelled
                    enableVehicleDetails(false);
                    enableButton(vehicleCalculation.Quotation.Purchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE);
                }
            }
        }

        private void clearForm()
        {
            txtPOYY.Text = "";
            txtPOMM.Text = "";
            txtPOXXX.Text = "";

            dtpVendorDate.Value = DateTime.Today.Date;
            dtpVendorDate.Checked = false;
            cboVendor.SelectedIndex = -1;
            txtUnit.Value = 0;

            initCalculationHeaderQuotation();
            txtVehiclePrice.Value = 0;

            txtRemark.Text = "";


          
            txtDiscountAmount.Value = 0;
            txtDiscountTotal.Value = 0;
        }

        private void exitForm()
        {
            this.Close();
        }

        private void enableAmend(bool value)
        {
            btnSearchQuotation.Enabled = value;
            rdbNewType.Enabled = value;
            rdbConType.Enabled = value;
            cboColor.Enabled = value;
        }

        private void enableVehicleDetails(bool value)
        {
            cboCustomer.Enabled = value;
            cboBrand.Enabled = value;
            cboModel.Enabled = value;
            txtVehiclePrice.Enabled = value;
        }

        private void enablePODetails(bool value)
        {
            dtpVendorDate.Enabled = value;
            cboVendor.Enabled = value;
            txtUnit.Enabled = value;
        }

        private void enableButton(bool value)
        {
            btnPrint.Enabled = value;
            btnSave.Enabled = value;
        }

        private bool canEdit(VehiclePurchasing vehiclePurchasing)
        {
            bool result = true;

            if (vehiclePurchasing != null && vehiclePurchasing.PurchasNo != null)
            {
                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    List<VehiclePurchasingContract> purchaseContractList = facade.GetPurchasingContractListByPurchase(vehiclePurchasing);

                    if (purchaseContractList.Count > 0)
                    {
                        result &= false;
                    }
                }

                result &= vehiclePurchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE;
            }

            return result;
        }

        private void getPONo()
        {
            DocumentNo PONo = facadeVehicleQuotation.RetriveRunningNo(DOCUMENT_TYPE.PURCHASING_VEHICLE);
            txtPOYY.Text = PONo.Year;
            txtPOMM.Text = PONo.Month;
            txtPOXXX.Text = PONo.No;
            txtPOXXX.Tag = PONo;
            initPOHeader();
        }

        private VehiclePurchasing getPurchasing()
        {
            VehiclePurchasing purchase = new VehiclePurchasing();
            purchase.PurchasNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, txtPOYY.Text, txtPOMM.Text, txtPOXXX.Text);

            purchase.Model = new Model();
            purchase.Model.ABrand = new Brand();
            purchase.Color = new Color();

            if (rdbNewType.Checked == true)
            {
                purchase.IsNewCar = true;
                purchase.Model = (Model)cboModel.Tag;
                purchase.Model.ABrand = (Brand)cboBrand.Tag;
            }
            else if (rdbConType.Checked == true)
            {
                purchase.IsNewCar = false;
                purchase.Model = (Model)cboModel.SelectedValue;
                purchase.Model.ABrand = (Brand)cboBrand.SelectedValue;
            }

            purchase.Color = (Color)cboColor.SelectedItem;
            purchase.IssueDate = DateTime.Today.Date;
            purchase.Quantity = Convert.ToInt32(txtUnit.Value);
            purchase.Vendor = (Vendor)(cboVendor.SelectedValue);
            purchase.VehiclePrice = Convert.ToDecimal(txtVehiclePrice.Value);
            purchase.VendorQuotationDate = dtpVendorDate.Value.Date;
            purchase.PurchaseStatus = PURCHAS_STATUS_TYPE.APPROVE;
            purchase.Remark = txtRemark.Text;

            //Todsporn Modified 25/2/2020 PO. Discount
            purchase.Discount_Amount = Convert.ToDecimal(txtDiscountAmount.Value);
            purchase.Discount_Total = Convert.ToDecimal(txtDiscountTotal.Value);




            return purchase;
        }

        private DocumentNo getUpdateQuotation()
        {
            DocumentNo quotationNo = null;
            if (txtQuotationYY.Text != "" && txtQuotationMM.Text != "" && txtQuotationXXX.Text != "")
            {
                quotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, txtQuotationYY.Text, txtQuotationMM.Text, txtQuotationXXX.Text);
            }
            return quotationNo;
        }

        private void bindVehiclePurchasing(VehicleCalculation vehicleCalculation)
        {
            txtQuotationYY.Text = vehicleCalculation.Quotation.QuotationNo.Year.ToString();
            txtQuotationMM.Text = vehicleCalculation.Quotation.QuotationNo.Month.ToString();
            txtQuotationXXX.Text = vehicleCalculation.Quotation.QuotationNo.No.ToString();

            cboCustomer.Text = vehicleCalculation.Customer.ToString();
            cboBrand.Text = vehicleCalculation.Model.ABrand.ToString();
            cboModel.Text = vehicleCalculation.Model.ToString();

            //Delete color from calculation : woranai 2009/02/18
            //cboColor.Text = vehicleCalculation.Color.ToString();
            //cboColor.Tag = vehicleCalculation.Color;

            cboCustomer.Tag = vehicleCalculation.Customer;
            cboBrand.Tag = vehicleCalculation.Model.ABrand;
            cboModel.Tag = vehicleCalculation.Model;
            txtVehiclePrice.Value = vehicleCalculation.BodyCost;

            //Todsporn Modified 25/2/2020 PO. Discount
            txtDiscountAmount.Value = vehicleCalculation.DiscountAmount;
            txtDiscountTotal.Value = vehicleCalculation.DiscountTotal;




        }

        private void addEvent(VehicleCalculation vehicleCalculation)
        {
            initAdd(vehicleCalculation);
            getPONo();
            enableAmend(false);
            enableVehicleDetails(false);
            initControls();
        }

        private void initAdd(VehicleCalculation vehicleCalculation)
        {
            initCalculationHeaderQuotation();
            bindVehiclePurchasing(vehicleCalculation);
            initControls();
        }

        #region Process Event
        private void searchQuotation()
        {
            try
            {
                frmPOSearchQuotation = new FrmPOSearchQuotation(this);
                frmPOSearchQuotation.ShowDialog();
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

        private bool saveEvent(bool isPrint)
        {
            bool result = false;

            try
            {
                if (validatePurchaseOrder())
                {
                    if (!isPrint)
                    {
                        result = Message(MessageList.Question.Q0018, "ใบสั่งซื้อ") == DialogResult.Yes;
                    }
                    else
                    {
                        result = true;
                    }

                    if (result)
                    {
                        result = false;

                        if (parentForm.AddRow(getPurchasing(), getUpdateQuotation()))
                        {
                            if (!isPrint)
                            {
                                Message(MessageList.Information.I0001);
                            }

                            VehicleQuotation vehicleQuotation = new VehicleQuotation();
                            vehicleQuotation.QuotationNo = getUpdateQuotation();
                            vehicleQuotation.Purchasing = getPurchasing();
                            InitEditAction(vehicleQuotation);
                            result = true;
                        }
                    }
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

            return result;
        }

        private bool editEvent(bool isPrint)
        {
            bool result = false;

            try
            {
                if (validatePurchaseOrder() && parentForm.UpdateRow(getPurchasing(), getUpdateQuotation()))
                {
                    if (!isPrint)
                    {
                        Message(MessageList.Information.I0001);
                    }

                    result = true;
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

            return result;
        }

        private bool validatePurchaseOrder()
        {
            if (!dtpVendorDate.Checked)
            {
                Message(MessageList.Error.E0005, " Vendor Date");
                return false;
            }

            if (Convert.ToInt32(txtUnit.Value) == 0)
            {
                Message(MessageList.Error.E0002, " Unit of Vehicle");
                txtUnit.Focus();
                return false;
            }

            if (cboVendor.SelectedIndex == -1 || cboVendor.SelectedIndex == 0)
            {
                Message(MessageList.Error.E0005, " Vendor");
                cboVendor.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtVehiclePrice.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0002, " Vehicle Price");
                txtVehiclePrice.Focus();
                return false;
            }

            if (rdbNewType.Checked == true)
            {
                if (txtQuotationYY.Text == "" && txtQuotationMM.Text == "" && txtQuotationXXX.Text == "")
                {
                    Message(MessageList.Error.E0005, "รถ ก่อนทำการบันทึกข้อมูล");
                    txtQuotationYY.Focus();
                    return false;
                }
            }
            if (cboColor.SelectedIndex < 0 || cboColor.Text == string.Empty)
            {
                Message(MessageList.Error.E0005, " Color");
                cboColor.Focus();
                return false;
            }

            return true;
        }

        private void createReport()
        {
            if (Message(MessageList.Question.Q0017) == DialogResult.Yes)
            {
                bool result = false;

                if (action == ActionType.ADD)
                {
                    result = saveEvent(true);
                }
                else
                {
                    result = editEvent(true);
                }

                if (result)
                {
                    DocumentNo purchaseNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, txtPOYY.Text, txtPOMM.Text, txtPOXXX.Text);
                    FrmrptPurchaseOrderReport frmrptPurchaseOrderReport = new FrmrptPurchaseOrderReport(purchaseNo);
                    frmrptPurchaseOrderReport.Show();
                }
            }
        }

        #endregion
        #endregion

        #region Public Method
        public void SelectedVehicleQuotation(VehicleCalculation vehicleCalculation)
        {
            initCalculationHeaderQuotation();
            bindVehiclePurchasing(vehicleCalculation);
            initControls();
        }

        public void InitAddAction()
        {
            baseADD();
            VehiclePurchasing value = new VehiclePurchasing();
            getPONo();
            initPOHeader();
            enableAmend(true);
            enableVehicleDetails(false);
            initControls();
        }

        public void InitEditAction(VehicleQuotation selectedVehiclePurchasing)
        {
            facadeVehicleCalculation = new VehicleCalculationFacade();
            baseEDIT();
            initPOHeader();
            initForm(selectedVehiclePurchasing);
            enableAmend(false);
            initControls();

            cboCustomer.Enabled = false;
            cboColor.Enabled = false;
        } 
        #endregion        


        #region Form Event
        private void rdbNewType_CheckedChanged(object sender, EventArgs e)
        {
            enableVehicleDetails(false);
            enableQuotation(true);
        }

        private void rdbConType_CheckedChanged(object sender, EventArgs e)
        {
            enableVehicleDetails(true);
            enableQuotation(false);

            if (action != ActionType.EDIT)
            {
                initCalculationHeader();
                txtVehiclePrice.Value = 0;
            }

            cboCustomer.Enabled = false;
        }

        private void enableQuotation(bool value)
        {
            btnSearchQuotation.Enabled = value;
            txtQuotationYY.Text = "";
            txtQuotationMM.Text = "";
            txtQuotationXXX.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    saveEvent(false);
                    break;
                case ActionType.EDIT:
                    editEvent(false);
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            createReport();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            exitForm();
        }

        private void btnSearchQuotation_Click(object sender, EventArgs e)
        {
            searchQuotation();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrand.SelectedIndex != -1)
            {
                Brand brand = (Brand)cboBrand.SelectedItem;
                cboModel.DataSource = facadeVehiclePurchasing.DataSourceModel(brand);
                cboModel.SelectedIndex = 0;

            }
        }

        #endregion

        #region Common Methods

        /// <summary>
        /// Validate range in maximum value
        /// </summary>
        /// <param name="fpDouble"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private bool IsValidMaxValue(FpDouble fpDouble, double maxValue)
        {
            double dblValue = Convert.ToDouble(fpDouble.Value);
            if (dblValue > maxValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validate range in minimum value
        /// </summary>
        /// <param name="fpDouble"></param>
        /// <param name="minValue"></param>
        /// <returns></returns>
        private bool IsValidMinValue(FpDouble fpDouble, double minValue)
        {
            double dblValue = Convert.ToDouble(fpDouble.Value);
            if (dblValue < minValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        private void txtDiscountAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                VehicleCalculation calculation = new VehicleCalculation();

                calculation.DiscountTotal = Convert.ToDecimal(txtVehiclePrice.Value) - Convert.ToDecimal(txtDiscountAmount.Value);

                txtDiscountTotal.Value = Convert.ToDecimal(calculation.DiscountTotal);


            }
        }
    }
}
