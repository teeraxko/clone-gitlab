using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using System.Data.SqlClient;
using Entity.VehicleEntities;
using SystemFramework.AppMessage;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Facade.CommonFacade;

namespace Presentation.VehicleGUI.Leasing
{
    public partial class FrmLeasingEntry : EntryFormBase
    {
        private FrmLeasing parentForm;
        private bool isChange = true;
        private bool isReadOnly = true;
        private ActionType poType = ActionType.ADD;
        private string poNO = "";

        //============================== Property ==============================
        private Quotation objQuotation;
        public Quotation ObjQuotation
        {
            get
            {
                objQuotation = new Quotation();
                objQuotation.QuotationNo = (DocumentNo)lblQuotationNoXXX.Tag;
                objQuotation.Customer = (Customer)cboCustomer.SelectedItem;
                objQuotation.LeaseTerm = Convert.ToByte(fpiLeaseTerm.Value);
                objQuotation.LastIssueDate = dtpIssueDate.Value.Date;
                objQuotation.ValidityDate = dtpValidityDate.Value.Date;
                objQuotation.DeliveryDays = Convert.ToByte(fpiDeliveryDay.Value);
                objQuotation.IsCustomerAccept = chkCusAccept.Checked;
                objQuotation.Quantity = Convert.ToByte(fpiVehicleQuantity.Value);
                objQuotation.AnewVehicle.VehicleInfo.AModel = (Model)cboModel.SelectedItem;
                objQuotation.AnewVehicle.VehicleInfo.AColor = (Entity.VehicleEntities.Color)cboColor.SelectedItem;
                objQuotation.KindOfVehicle = (KindOfVehicle)cboKindOfVehicle.SelectedItem;
                objQuotation.AnewVehicle.VehicleInfo.IsSecondHand = chkNotSecondHand.Checked? SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO: SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES;
                objQuotation.IsDriverNeed = chkDriverNeed.Checked;
                objQuotation.AnewVehicle.VehicleCost = (VehicleCost)lblTotalVehiclePrice.Tag;
                objQuotation.LeasingCalculation = (LeasingCalculation)fpdMonthlyCharge.Tag;
                objQuotation.LeasingCalculation.MonthlyRoundCharge = Convert.ToDecimal(fpdMonthlyRound.Value);

                if (poNO != "")
                {
                    objQuotation.PONo = poNO;
                }
                return objQuotation;
            }
            set
            {
                isChange = false;
                objQuotation = value;
                lblQuotationNoYY.Text = value.QuotationNo.Year;
                lblQuotationNoMM.Text = value.QuotationNo.Month;
                lblQuotationNoXXX.Text = value.QuotationNo.No;
                lblQuotationNoXXX.Tag = value.QuotationNo;

                if (value.Customer != null)
                {
                    cboCustomer.Text = value.Customer.ToString();
                }
                fpiLeaseTerm.Value = value.LeaseTerm;
                dtpIssueDate.Value = value.LastIssueDate;
                dtpValidityDate.Value = value.ValidityDate;
                fpiDeliveryDay.Value = value.DeliveryDays;
                chkCusAccept.Checked = value.IsCustomerAccept;
                fpiVehicleQuantity.Value = value.Quantity;

                if (value.AnewVehicle.VehicleInfo.AModel != null)
                {
                    if (value.AnewVehicle.VehicleInfo.AModel.ABrand != null)
                    {
                        cboBrand.Text = value.AnewVehicle.VehicleInfo.AModel.ABrand.ToString();
                    }
                    cboModel.Text = value.AnewVehicle.VehicleInfo.AModel.ToString();
                }

                if (value.AnewVehicle.VehicleInfo.AColor != null)
                {
                    cboColor.Text = value.AnewVehicle.VehicleInfo.AColor.ToString();
                }

                if (value.KindOfVehicle != null)
                {
                    cboKindOfVehicle.Text = value.KindOfVehicle.ToString();
                }
                chkNotSecondHand.Checked = (value.AnewVehicle.VehicleInfo.IsSecondHand == SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO);
                chkDriverNeed.Checked = value.IsDriverNeed;

                fpdBodyPrice.Value = value.AnewVehicle.VehicleCost.VehiclePrice.BodyPrice;
                fpdModifyPrice.Value = value.AnewVehicle.VehicleCost.VehiclePrice.ModifyPrice;
                fpdOtherPrice.Value = value.AnewVehicle.VehicleCost.VehiclePrice.OtherPrice;
                txtOtherPriceDes.Text = value.AnewVehicle.VehicleCost.VehiclePrice.OtherPriceDesc;
                lblTotalVehiclePrice.Text = value.AnewVehicle.VehicleCost.TotalVehiclePrice.ToString("N");
                lblTotalVehiclePrice.Tag = value.AnewVehicle.VehicleCost;

                dtpVendorQuotationDate.Value = value.AnewVehicle.VehicleCost.VendorQuotaionDate;
                dtpVendorQuotationDate.Checked = true;
                fpdCapitalInsurance.Value = value.AnewVehicle.VehicleCost.CapitalInsurance;
                fpdInsurancePremium.Value = value.AnewVehicle.VehicleCost.InsurancePremium;
                fpdRegister.Value = value.AnewVehicle.VehicleCost.VehicleRegister;
                fpdMaintenance.Value = value.AnewVehicle.VehicleCost.MaintenanceCharge;

                fpdMonthlyCharge.Value = value.LeasingCalculation.MonthlyCharge;
                fpdMonthlyRound.Value = value.LeasingCalculation.MonthlyRoundCharge;
                fpdPercentResidual.Value = value.LeasingCalculation.PercentOfResidual;
                fpdPercentRateOfReturn.Value = value.LeasingCalculation.RateOfReturn;
                fpdMonthlyCharge.Tag = value.LeasingCalculation;
                isChange = true;
            }
        }

        //============================== Constructor ==============================
        public FrmLeasingEntry(FrmLeasing frmLeasing)
            : base()
        {
            InitializeComponent();
            parentForm = frmLeasing;
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleLeasing");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleLeasing");

            try
            {
                cboCustomer.DataSource = parentForm.FacadeQuotation.DataSourceCustomer;
                cboBrand.DataSource = parentForm.FacadeQuotation.DataSourceBrand;
                cboColor.DataSource = parentForm.FacadeQuotation.DataSourceColor;
                cboKindOfVehicle.DataSource = parentForm.FacadeQuotation.DataSourceKindOfVehicle;
                cboVendor.DataSource = parentForm.FacadeQuotation.DataSourceVendor;
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //============================== Private Method ==============================
        #region - Quotation -
        private void setValue()
        {
            fpdPercentResidual.MinValue = 0.00;
            fpdPercentResidual.MaxValue = 99.99;
            fpdPercentRateOfReturn.MinValue = 0.00;
            fpdPercentRateOfReturn.MaxValue = 99.99;
            fpdBodyPrice.MinValue = 0.00;
            fpdBodyPrice.MaxValue = 9999999.99;
            fpdModifyPrice.MinValue = 0.00;
            fpdModifyPrice.MaxValue = 999999.99;
            fpdOtherPrice.MinValue = 0.00;
            fpdOtherPrice.MaxValue = 999999.99;
            fpdCapitalInsurance.MinValue = 0.00;
            fpdCapitalInsurance.MaxValue = 9999999.99;
            fpdInsurancePremium.MinValue = 0.00;
            fpdInsurancePremium.MaxValue = 999999.99;
            fpdRegister.MinValue = 0.00;
            fpdRegister.MaxValue = 99999.99;
            fpdMaintenance.MinValue = 0.00;
            fpdMaintenance.MaxValue = 99999.99;
            fpdMonthlyCharge.MinValue = 0.00;
            fpdMonthlyCharge.MaxValue = 999999.99;
            fpdMonthlyRound.MinValue = 0.00;
            fpdMonthlyRound.MaxValue = 999999.99;
        }

        private void clearQuotation()
        {
            lblQuotationNoYY.Text = "";
            lblQuotationNoMM.Text = "";
            lblQuotationNoXXX.Text = "";
            dtpIssueDate.Value = DateTime.Today;
            dtpVendorQuotationDate.Value = DateTime.Today;
            dtpVendorQuotationDate.Checked = false;
            fpiDeliveryDay.Value = 0;
            chkCusAccept.Checked = false;
            fpiVehicleQuantity.Value = 0;
            lblGearType.Text = "";
            lblCC.Text = "";
            lblBreakType.Text = "";
            lblTotalVehiclePrice.Text = decimal.Zero.ToString();
            txtOtherPriceDes.Text = "";
            txtQuotationRemark.Text = "";
            fpdPercentResidual.Value = decimal.Zero;
            fpdPercentRateOfReturn.Value = decimal.Zero;
            fpdBodyPrice.Value = decimal.Zero;
            fpdModifyPrice.Value = decimal.Zero;
            fpdOtherPrice.Value = decimal.Zero;
            fpdCapitalInsurance.Value = decimal.Zero;
            fpdInsurancePremium.Value = decimal.Zero;
            fpdRegister.Value = decimal.Zero;
            fpdMaintenance.Value = decimal.Zero;
            fpdMonthlyCharge.Value = decimal.Zero;
            fpdMonthlyRound.Value = decimal.Zero;

            lblQuotationNoXXX.Tag = null;
            fpdMonthlyCharge.Tag = null;
            lblTotalVehiclePrice.Tag = null;

            if (cboBrand.Items.Count > 0)
            {
                cboBrand.SelectedIndex = -1;
            }
            if (cboColor.Items.Count > 0)
            {
                cboColor.SelectedIndex = -1;
            }
            if (cboCustomer.Items.Count > 0)
            {
                cboCustomer.SelectedIndex = -1;
            }
            if (cboKindOfVehicle.Items.Count > 0)
            {
                cboKindOfVehicle.SelectedIndex = -1;
            }
            if (cboModel.Items.Count > 0)
            {
                cboModel.SelectedIndex = -1;
            }

            enablePO(false);
        }

        private void calLeasing()
        {
            if (validateCalculate())
            {
                VehiclePrice vehiclePrice = new VehiclePrice();
                vehiclePrice.BodyPrice = Convert.ToDecimal(fpdBodyPrice.Value);
                vehiclePrice.ModifyPrice = Convert.ToDecimal(fpdModifyPrice.Value);
                vehiclePrice.OtherPrice = Convert.ToDecimal(fpdOtherPrice.Value);
                vehiclePrice.OtherPriceDesc = txtOtherPriceDes.Text;

                VehicleCost vehicleCost = new VehicleCost();
                vehicleCost.VehiclePrice = vehiclePrice;
                vehicleCost.CapitalInsurance = Convert.ToDecimal(fpdCapitalInsurance.Value);
                vehicleCost.InsurancePremium = Convert.ToDecimal(fpdInsurancePremium.Value);
                vehicleCost.MaintenanceCharge = Convert.ToDecimal(fpdMaintenance.Value);
                vehicleCost.VehicleRegister = Convert.ToDecimal(fpdRegister.Value);
                vehicleCost.VendorQuotaionDate = dtpVendorQuotationDate.Value.Date;

                LeasingCalculation leasingCalculation = parentForm.FacadeQuotation.Calculate(vehicleCost, Convert.ToByte(fpiLeaseTerm.Value), Convert.ToDecimal(fpdPercentResidual.Value), Convert.ToDecimal(fpdPercentRateOfReturn.Value));

                fpdMonthlyCharge.Value = leasingCalculation.MonthlyCharge;
                fpdMonthlyRound.Value = leasingCalculation.MonthlyRoundCharge;

                lblTotalVehiclePrice.Tag = vehicleCost;
                fpdMonthlyCharge.Tag = leasingCalculation;
            }
        }

        private void getQuotationNo()
        {
            DocumentNo quotationNo = parentForm.FacadeQuotation.RetriveRunningNo(DOCUMENT_TYPE.QUOTATION_VEHICLE);
            lblQuotationNoYY.Text = quotationNo.Year;
            lblQuotationNoMM.Text = quotationNo.Month;
            lblQuotationNoXXX.Text = quotationNo.No;
            lblQuotationNoXXX.Tag = quotationNo;
        }

        private void calculateTotalVehiclePrice()
        {
            decimal total = Convert.ToDecimal(fpdBodyPrice.Value) + Convert.ToDecimal(fpdModifyPrice.Value) + Convert.ToDecimal(fpdOtherPrice.Value);
            lblTotalVehiclePrice.Text = total.ToString("N");
        }

        #endregion

        #region - PO -
        private void clearPO()
        {
            lblPONoYY.Text = "";
            lblPONoMM.Text = "";
            lblPONoXXX.Text = "";
            lblPONoXXX.Tag = null;
            if (cboVendor.Items.Count > 0)
            {
                cboVendor.SelectedIndex = -1;
            }
            dtpPOIssueDate.Value = DateTime.Today;
            lblPOVehiclePrice.Text = "";
            lblPOBrand.Text = "";
            lblPOModel.Text = "";
            lblPOCC.Text = "";
            lblPOGearType.Text = "";
            lblPOBreakType.Text = "";
            lblPOColor.Text = "";
            lblPOQuantity.Text = "";
            lblPOVendorDate.Text = "";
            txtPORemark.Text = "";
            lblPOStatus.Text = "";
            poNO = "";
        }

        private void enablePO(bool enable)
        {
            gpbPOHead.Enabled = enable;
            gpbPODetail.Enabled = enable;
            btnPOOK.Enabled = enable;
            btnPOPrint.Enabled = enable;
        }      

        private void getPONo()
        {
            DocumentNo poNo = parentForm.FacadeQuotation.RetriveRunningNo(DOCUMENT_TYPE.PURCHASING_VEHICLE);
            lblPONoYY.Text = poNo.Year;
            lblPONoMM.Text = poNo.Month;
            lblPONoXXX.Text = poNo.No;
            lblPONoXXX.Tag = poNo;
        }

        private void getPO(IPurchasing purchasing)
        {
            if (purchasing.PurchaseNo != null && purchasing.PurchaseNo.ToString() != "")
            {
                enablePO(true);
                poType = ActionType.EDIT;
                poNO = purchasing.PurchaseNo.ToString();
                lblPONoYY.Text = purchasing.PurchaseNo.Year;
                lblPONoMM.Text = purchasing.PurchaseNo.Month;
                lblPONoXXX.Text = purchasing.PurchaseNo.No;
                lblPONoXXX.Tag = purchasing.PurchaseNo;
                dtpPOIssueDate.Value = purchasing.IssueDate;
                cboVendor.Text = purchasing.Vendor.ToString();
                lblPOStatus.Tag = purchasing.PurchasStatus;

                if (purchasing.PurchasStatus == PURCHAS_STATUS_TYPE.APPROVE)
                {
                    bindPOStatus(PURCHAS_STATUS_TYPE.APPROVE);
                }
                else
                {
                    bindPOStatus(PURCHAS_STATUS_TYPE.CANCEL);
                    enablePO(false);
                    btnCreatePO.Enabled = false;
                    btnDeletePO.Enabled = false;
                }

                getPODetail(purchasing);
            }
            else
            {
                clearPO();
            }        
        }

        private void setPO(IPurchasing purchasing)
        {
            purchasing.PurchaseNo = (DocumentNo)lblPONoXXX.Tag;
            purchasing.Vendor = (Vendor)cboVendor.SelectedItem;
            purchasing.IssueDate = dtpPOIssueDate.Value;
        }

        private void getPODetail(IPurchasing purchasing)
        {
            lblPOBrand.Text = cboBrand.Text;
            lblPOModel.Text = cboModel.Text;
            lblPOCC.Text = lblCC.Text;
            lblPOGearType.Text = lblGearType.Text;
            lblPOBreakType.Text = lblBreakType.Text;
            lblPOColor.Text = cboColor.Text;
            lblPOQuantity.Text = fpiVehicleQuantity.Text;
            lblPOVendorDate.Text = dtpVendorQuotationDate.Value.ToShortDateString();
            lblPOVehiclePrice.Text = purchasing.VehiclePrice.ToString("N");
        }

        private void bindPOStatus(PURCHAS_STATUS_TYPE poStatus)
        {
            if (poStatus == PURCHAS_STATUS_TYPE.APPROVE)
            {
                lblPOStatus.Text = GUIFunction.GetString(PURCHAS_STATUS_TYPE.APPROVE);
                lblPOStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblPOStatus.Text = GUIFunction.GetString(PURCHAS_STATUS_TYPE.CANCEL);
                lblPOStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion

        #region - validate -
        #region - validate Quotation -
        private bool validateQuotationNo()
        {
            if (lblQuotationNoYY.Text == "")
            {
                Message(MessageList.Error.E0002, "Quotation No.");
                lblQuotationNoYY.Focus();
                return false;
            }
            if (lblQuotationNoMM.Text == "")
            {
                Message(MessageList.Error.E0002, "Quotation No.");
                lblQuotationNoMM.Focus();
                return false;
            }
            if(lblQuotationNoXXX.Text == "")
			{
                Message(MessageList.Error.E0002, "Quotation No.");
				lblQuotationNoXXX.Focus();
				return false;
			}            
            return true;
        }

        private bool validateCalculate()
        {
            if (cboCustomer.Text == "")
            {
                Message(MessageList.Error.E0005, "ลูกค้า");
                cboCustomer.Focus();
                return false;
            }
            if (Convert.ToDecimal(fpdBodyPrice.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0002, "ราคา Body");
                fpdBodyPrice.Focus();
                return false;
            }
            if (Convert.ToByte(fpiLeaseTerm.Value) == 0)
            {
                Message(MessageList.Error.E0002, "ระยะเวลาเช่า");
                fpiLeaseTerm.Focus();
                return false;
            }
            if (Convert.ToDecimal(fpdPercentResidual.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0002, " Residual Value ");
                fpdPercentResidual.Focus();
                return false;
            }
            if (Convert.ToDecimal(fpdPercentRateOfReturn.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0002, " Rate of Return ");
                fpdPercentRateOfReturn.Focus();
                return false;
            }
            return true;
        }

        private bool validateMonthlyCharge()
        {
            if (!dtpVendorQuotationDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ใบเสนอราคาจากตัวแทนจำหน่าย");
                dtpVendorQuotationDate.Focus();
                return false;
            }
            if (Convert.ToDecimal(fpdMonthlyCharge.Value) == decimal.Zero)
            {
                Message(MessageList.Error.E0017);
                btnCalculate.Focus();
                return false;
            }
            return true;
        }

        private bool validatePrintQuotation()
        {
            if (objQuotation == null || objQuotation.QuotationNo == null)
            {
                Message(MessageList.Error.E0004, "ข้อมูลใบเสนอราคา");
                btnQuotationOK.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region - validate PO -
        private bool validateCreatePO()
        {
            if (objQuotation == null || objQuotation.QuotationNo == null)
            {
                Message(MessageList.Error.E0013, "สร้างใบสั่งซื้อได้", "ไม่พบข้อมูลใบเสนอราคา");
                tabLeasing.SelectedTab = tabQuotation;
                btnQuotationOK.Focus();
                return false;
            }
            if (!objQuotation.IsCustomerAccept)
            {
                Message(MessageList.Error.E0005, "บันทึกสถานะลูกค้าตอบรับ");
                tabLeasing.SelectedTab = tabQuotation;
                chkCusAccept.Focus();
                return false;
            }
            if (objQuotation.AnewVehicle.VehicleInfo.AModel == null || objQuotation.AnewVehicle.VehicleInfo.AModel.ABrand == null)
            {
                Message(MessageList.Error.E0005, "ยี่ห้อรถ รุ่นรถ แล้วบันทึกข้อมูล");
                tabLeasing.SelectedTab = tabQuotation;
                cboBrand.Focus();
                return false;
            }
            if ((DocumentNo)lblPONoXXX.Tag != null)
            {
                Message(MessageList.Error.E0013, "สร้างใบสั่งซื้อได้", "มีข้อมูลใบสั่งซื้อแล้ว");
                btnDeletePO.Focus();
                return false;
            }
            return true;
        }

        private bool validateDeletePO()
        {
            if (poNO == "")
            {
                Message(MessageList.Error.E0013, "ลบใบสั่งซื้อได้", "ไม่พบข้อมูลใบสั่งซื้อ");
                btnCreatePO.Focus();
                return false;
            }
            return true;
        }

        private bool validatePrintPO()
        {
            if (poNO == "")
            {
                Message(MessageList.Error.E0013, "พิมพ์ใบสั่งซื้อได้", "ไม่พบข้อมูลใบสั่งซื้อ");
                btnCreatePO.Focus();
                return false;
            }
            return true;
        }
        #endregion
        #endregion

        //============================== Public Method ==============================
        internal void InitAddAction()
        {
            baseADD();
            clearQuotation();
            clearPO();
            setValue();
            getQuotationNo();
        }

        internal void InitEditAction(Quotation selectedQuotation, bool isUpdate)
        {
            baseEDIT();
            clearQuotation();
            clearPO();
            setValue();
            ObjQuotation = selectedQuotation;
            getPO(selectedQuotation);

            if (isReadOnly)
            {
                btnQuotationOK.Enabled = false;
                btnQuotationPrint.Enabled = false;
                btnPOOK.Enabled = false;
                btnCreatePO.Enabled = false;
                btnDeletePO.Enabled = false;
                btnPOPrint.Enabled = false;
            }

            if (!isUpdate)
            {
                btnQuotationOK.Enabled = false;
                btnPOOK.Enabled = false;
                btnCreatePO.Enabled = false;
                btnDeletePO.Enabled = false;
            }
        }

        //============================== Base Event ==============================
        #region - Quotation -
        private void addQuotation()
        {
            try
            {
                if (validateQuotationNo() && validateMonthlyCharge() && validateCalculate())
                {
                    if (parentForm.AddQuotation(ObjQuotation))
                    {
                        baseEDIT();
                        Message(MessageList.Information.I0001);
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void editQuotation()
        {
            try
            {
                if (validateMonthlyCharge() && validateCalculate())
                {
                    if (parentForm.UpdateQuotation(ObjQuotation))
                    {
                        Message(MessageList.Information.I0001);
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void printQuotation()
        {
            dtpIssueDate.Value = DateTime.Today;
            if (validatePrintQuotation() && parentForm.FacadeQuotation.UpdateQuotationIssueDate(objQuotation.QuotationNo, dtpIssueDate.Value.Date))
            {
                FrmrptLeasingQuotation rptForm = new FrmrptLeasingQuotation();
                rptForm.Remark = txtQuotationRemark.Text;
                rptForm.QuotationNo = objQuotation.QuotationNo.ToString();
                rptForm.Show();
            }
        }
        #endregion

        #region - PO -
        private void addPO()
        {
            setPO(objQuotation);

            if (parentForm.FacadeQuotation.InsertPO(objQuotation, PURCHAS_STATUS_TYPE.APPROVE))
            {
                poType = ActionType.EDIT;
                poNO = ((IPurchasing)objQuotation).PurchaseNo.ToString();
                lblPOStatus.Tag = PURCHAS_STATUS_TYPE.APPROVE;
                bindPOStatus(PURCHAS_STATUS_TYPE.APPROVE);

                parentForm.RefreshForm();

                Message(MessageList.Information.I0001);
            }
        }

        private void updatePO()
        {
            setPO(objQuotation);
            ((IPurchasing)objQuotation).PurchasStatus = (PURCHAS_STATUS_TYPE)lblPOStatus.Tag;

            if (parentForm.FacadeQuotation.UpdatePO(objQuotation))
            {
                Message(MessageList.Information.I0001);     
            }
        }

        private void deletePO()
        {
            if (validateDeletePO() && parentForm.DeletePO(objQuotation, PURCHAS_STATUS_TYPE.CANCEL))
            {
                enablePO(false);
                btnCreatePO.Enabled = false;
                btnDeletePO.Enabled = false;
                lblPOStatus.Tag = PURCHAS_STATUS_TYPE.CANCEL;
                bindPOStatus(PURCHAS_STATUS_TYPE.CANCEL);
                Message(MessageList.Information.I0001);                
            }
        }

        private void createPO()
        {
            if (validateCreatePO())
            {
                poType = ActionType.ADD;
                clearPO();
                getPONo();
                enablePO(true);
                getPODetail(objQuotation);
                bindPOStatus(PURCHAS_STATUS_TYPE.APPROVE);

                Vendor vendor = parentForm.FacadeQuotation.GetSpecificVendor(objQuotation.AnewVehicle.VehicleInfo.AModel);
                if (vendor != null)
                {
                    cboVendor.Text = vendor.ToString();
                }                
            }            
        }

        private void printPO()
        {
            dtpPOIssueDate.Value = DateTime.Today;

            if (validatePrintPO() && parentForm.FacadeQuotation.UpdatePOIssueDate(new DocumentNo(poNO), dtpPOIssueDate.Value.Date))
            {
                FrmrptLeasingPurchasing rptForm = new FrmrptLeasingPurchasing();
                rptForm.PurchasingNo = poNO;
                rptForm.Remark = txtPORemark.Text;
                rptForm.Show();
            }
        }
        #endregion

        //============================== event ==============================
        private void FrmLeasingEntry_Load(object sender, EventArgs e)
        {}
                
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            calLeasing();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrand.SelectedIndex != -1 && cboBrand.Text != "")
            {
                Brand brand = (Brand)cboBrand.SelectedItem;
                cboModel.DataSource = parentForm.FacadeQuotation.DataSourceModel(brand);
            }

            if (lblPONoXXX.Tag != null)
            {
                lblPOBrand.Text = cboBrand.Text;
            }
        }

        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            if (isChange)
            dtpValidityDate.Value = dtpIssueDate.Value.AddMonths(1);
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex != -1 && cboModel.Text != "")
            {
                Model model = (Model)cboModel.SelectedItem;
                if (model != null)
                {
                    lblCC.Text = model.EngineCC.ToString();
                    lblGearType.Text = GUIFunction.GetString(model.GearType);
                    lblBreakType.Text = GUIFunction.GetString(model.BreakType);
                }
                else
                {
                    lblBreakType.Text = "";
                    lblCC.Text = "";
                    lblGearType.Text = "";
                }
            }

            if (lblPONoXXX.Tag != null)
            {
                lblPOModel.Text = cboModel.Text;
            }
        }

        private void btnQuotationPrint_Click(object sender, EventArgs e)
        {
            printQuotation();
        }

        private void btnQuotationOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    addQuotation();
                    break;
                case ActionType.EDIT:
                    editQuotation();
                    break;
            }
        }

        private void btnQuotationCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPOOK_Click(object sender, EventArgs e)
        {
            switch (poType)
            {
                case ActionType.ADD:
                    addPO();
                    break;
                case ActionType.EDIT:
                    updatePO();
                    break;
            }
        }

        private void btnPOCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPOPrint_Click(object sender, EventArgs e)
        {
            printPO();
        }

        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            createPO();
        }

        private void btnDeletePO_Click(object sender, EventArgs e)
        {
            deletePO();
        }

        private void fpdBodyPrice_ValueChanged(object sender, EventArgs e)
        {
            calculateTotalVehiclePrice();
        }

        private void fpdModifyPrice_ValueChanged(object sender, EventArgs e)
        {
            calculateTotalVehiclePrice();
        }

        private void fpdOtherPrice_ValueChanged(object sender, EventArgs e)
        {
            calculateTotalVehiclePrice();
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblPONoXXX.Tag != null)
            {
                lblPOColor.Text = cboColor.Text;
            }
        }

        private void fpiVehicleQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (lblPONoXXX.Tag != null)
            {
                lblPOQuantity.Text = fpiVehicleQuantity.Value.ToString();
            }
        }

        private void lblGearType_TextChanged(object sender, EventArgs e)
        {
            if (lblPONoXXX.Tag != null)
            {
                lblPOGearType.Text = lblGearType.Text;
            }
        }

        private void lblBreakType_TextChanged(object sender, EventArgs e)
        {
            if (lblPONoXXX.Tag != null)
            {
                lblPOBreakType.Text = lblBreakType.Text;
            }
        }

        private void lblCC_TextChanged(object sender, EventArgs e)
        {
            if (lblPONoXXX.Tag != null)
            {
                lblPOCC.Text = lblCC.Text;
            }
        }
    }
}