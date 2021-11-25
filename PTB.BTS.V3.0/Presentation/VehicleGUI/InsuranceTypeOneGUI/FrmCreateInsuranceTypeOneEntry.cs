using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.VehicleEntities;

using ictus.Common.Entity.General;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    public partial class FrmCreateInsuranceTypeOneEntry : Presentation.CommonGUI.EntryFormBase
    {
        #region Private Variable
        private FrmCreateInsuranceTypeOne parentForm;
        private CompulsoryDocNoBase compulsoryBase;
        private bool isReadOnly = true; 
        #endregion

        #region Property
        private InsuranceTypeOne objInsuranceTypeOne;
        public InsuranceTypeOne ObjInsuranceTypeOne
        {
            set
            {
                objInsuranceTypeOne = value;
                lblPolicyNo.Text = value.PolicyNo;
                cboInsuranceCompany.SelectedText = value.AInsuranceCompany.AName.Thai;
                dtpStartDate.Value = value.APeriod.From;
                dtpEndDate.Value = value.APeriod.To;
                txtInchargeName.Text = value.InsuranceInchargeName;
                txtInchargeTelNo.Text = value.InsuranceInchargeTelNo;
                txtTaxInvoiceNo.Text = value.TaxInvoiceNo;

                if (value.TaxInvoiceDate == NullConstant.DATETIME)
                {
                    dtpTaxInvoiceDate.Value = DateTime.Today;
                    dtpTaxInvoiceDate.Checked = false;
                }
                else
                {
                    dtpTaxInvoiceDate.Value = value.TaxInvoiceDate;
                    dtpTaxInvoiceDate.Checked = true;
                }
                fpdPremiumAmount.Value = value.PremiumAmount;
                fpdRevenueStampFee.Value = value.RevenueStampFee;
                fpdVatAmount.Value = value.VatAmount;
                fpdTotalAmount.Value = value.Amount;
            }
            get
            {
                objInsuranceTypeOne = new InsuranceTypeOne();

                if (action == ActionType.ADD)
                {
                    objInsuranceTypeOne.PolicyNo = txtPolicyNo.Text.Trim();
                }
                else
                {
                    objInsuranceTypeOne.PolicyNo = lblPolicyNo.Text;
                }

                objInsuranceTypeOne.AInsuranceCompany = (InsuranceCompany)cboInsuranceCompany.SelectedItem;
                objInsuranceTypeOne.APeriod.From = dtpStartDate.Value;
                objInsuranceTypeOne.APeriod.To = dtpEndDate.Value;
                objInsuranceTypeOne.InsuranceInchargeName = txtInchargeName.Text;
                objInsuranceTypeOne.InsuranceInchargeTelNo = txtInchargeTelNo.Text;
                objInsuranceTypeOne.TaxInvoiceNo = txtTaxInvoiceNo.Text;
                objInsuranceTypeOne.TaxInvoiceDate = dtpTaxInvoiceDate.Value;
                objInsuranceTypeOne.PremiumAmount = Convert.ToDecimal(fpdPremiumAmount.Value);
                objInsuranceTypeOne.RevenueStampFee = Convert.ToDecimal(fpdRevenueStampFee.Value);
                objInsuranceTypeOne.VatAmount = Convert.ToDecimal(fpdVatAmount.Value);
                return objInsuranceTypeOne;
            }
        } 
        #endregion

        #region Constructor
        public FrmCreateInsuranceTypeOneEntry(FrmCreateInsuranceTypeOne value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            setValue();
            compulsoryBase = ObjectCreater.CreateCompulsoryDocNo();
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
            cboInsuranceCompany.DataSource = parentForm.FacadeCreateInsuranceTypeOne.DataSourceInsuranceCompName;
        }

        #endregion

        #region Private Method
        private void visibleForm(bool value)
        {
            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyPrefix.Visible = value;
            //lblPolicy01.Visible = value;
            //cboPolicyType.Visible = value;
            //lblPolicy02.Visible = value;
            //txtPolicyYear.Visible = value;
            //lblPolicy03.Visible = value;
            //lblPolicy04.Visible = value;
            //txtPolicyEndorsement.Visible = value;

            txtPolicyNo.Visible = value;
            lblPolicyNo.Visible = !value;
        }

        private void setValue()
        {
            fpdPremiumAmount.MaxValue = 99999999.99;
            fpdPremiumAmount.MinValue = 0;
            fpdRevenueStampFee.MaxValue = 99999.99;
            fpdRevenueStampFee.MinValue = 0;
            fpdVatAmount.MaxValue = 99999999.99;
            fpdVatAmount.MinValue = 0;
            fpdVatPercent.MaxValue = 99.99;
            fpdVatPercent.MinValue = 0;
        }

        private void clearForm()
        {
            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyPrefix.Text = "SMD";
            //txtPolicyYear.Text = DateTime.Today.ToString("yy");
            //txtPolicyEndorsement.Text = compulsoryBase.DefaultEndorsement;
            //cboPolicyType.Text = "";

            txtPolicyNo.Text = string.Empty;
            dtpStartDate.Value = DateTime.Today;
            txtInchargeName.Text = "";
            txtInchargeTelNo.Text = "";
            txtTaxInvoiceNo.Text = "";
            dtpTaxInvoiceDate.Value = DateTime.Today;
            dtpTaxInvoiceDate.Checked = false;

            fpdPremiumAmount.Value = 0.00m;
            fpdRevenueStampFee.Value = 0.00m;
            fpdVatAmount.Value = 0.00m;
            fpdTotalAmount.Value = 0.00m;
            fpdVatPercent.Value = parentForm.FacadeCreateInsuranceTypeOne.GetVatRate();
        }

        //User request to chage text format : Woranai 2009-07-20
        //private string getPolicyNo()
        //{
        //    return txtPolicyPrefix.Text + "/" + cboPolicyType.Text + "/" + txtPolicyYear.Text + "-" + txtPolicyNo.Text + "-" + txtPolicyEndorsement.Text;
        //}

        private void calTotalAmount()
        {
            try
            {
                InsuranceTypeOne insuranceTypeOne = new InsuranceTypeOne();
                insuranceTypeOne.PremiumAmount = Convert.ToDecimal(fpdPremiumAmount.Value);
                parentForm.FacadeCreateInsuranceTypeOne.CalculateTotalPremium(insuranceTypeOne, Convert.ToDecimal(fpdVatPercent.Value));
                fpdRevenueStampFee.Value = insuranceTypeOne.RevenueStampFee;
                fpdVatAmount.Value = insuranceTypeOne.VatAmount;
                fpdTotalAmount.Value = insuranceTypeOne.Amount;
                insuranceTypeOne = null;
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

        private bool validateForm()
        {
            //User request to chage text format : Woranai 2009-07-20
            //if (action == ActionType.ADD && cboPolicyType.Text == "")
            //{
            //    Message(MessageList.Error.E0005, "ชื่อประเภทรถกรมธรรม์");
            //    cboPolicyType.Focus();
            //    return false;
            //}
            if (action == ActionType.ADD && txtPolicyNo.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0002, "เลขที่กรมธรรม์");
                txtPolicyNo.Focus();
                return false;
            }
            if (cboInsuranceCompany.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0005, "บริษัทประกันภัย");
                cboInsuranceCompany.Focus();
                return false;
            }
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                Message(MessageList.Error.E0011, "วันเริ่มประกัน", "วันหมดอายุ");
                dtpStartDate.Focus();
                return false;
            }
            if (txtInchargeName.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0002, "ชื่อตัวแทน");
                txtInchargeName.Focus();
                return false;
            }
            if (txtInchargeTelNo.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0002, "เบอร์โทรศัพท์");
                txtInchargeTelNo.Focus();
                return false;
            }
            if (txtTaxInvoiceNo.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0002, "เลขที่ใบกำกับภาษี");
                txtTaxInvoiceNo.Focus();
                return false;
            }
            if (!dtpTaxInvoiceDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ในใบกำกับภาษี");
                dtpTaxInvoiceDate.Focus();
                return false;
            }
            if (decimal.Parse(fpdPremiumAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "เบี้ยประกัน");
                fpdPremiumAmount.Focus();
                return false;
            }
            if (decimal.Parse(fpdRevenueStampFee.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "อากรแสตมป์");
                fpdRevenueStampFee.Focus();
                return false;
            }
            if (decimal.Parse(fpdVatAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "ภาษีมูลค่าเพิ่ม");
                fpdVatAmount.Focus();
                return false;
            }
            if (decimal.Parse(fpdVatPercent.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "VAT");
                fpdVatPercent.Focus();
                return false;
            }
            if (decimal.Parse(fpdTotalAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0017);
                btnCalAmount.Focus();
                return false;
            }
            return true;
        }

        private void addEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.AddRow(ObjInsuranceTypeOne))
                    {
                        this.Close();
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

        private void editEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.UpdateRow(ObjInsuranceTypeOne))
                    {
                        this.Close();
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
        #endregion

        #region Public Method
        public void InitAddAction()
        {
            baseADD();
            clearForm();
            visibleForm(true);
            cboPolicyType.Focus();
        }

        public void InitEditAction(InsuranceTypeOne value)
        {
            baseEDIT();
            clearForm();
            visibleForm(false);
            ObjInsuranceTypeOne = value;
            cboInsuranceCompany.Focus();

            if (isReadOnly)
            {
                btnOK.Enabled = false;
                btnCalAmount.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void btnCalAmount_Click(object sender, EventArgs e)
        {
            calTotalAmount();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    addEvent();
                    break;
                case ActionType.EDIT:
                    editEvent();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = new DateTime(dtpStartDate.Value.Year, 12, 31);
        } 
        #endregion
    }
}

