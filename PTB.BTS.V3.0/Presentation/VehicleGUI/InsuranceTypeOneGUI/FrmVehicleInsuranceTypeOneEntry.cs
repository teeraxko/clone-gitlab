using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.VehicleEntities;
using Entity.AttendanceEntities;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    public partial class FrmVehicleInsuranceTypeOneEntry : Presentation.CommonGUI.EntryFormBase
    {
        private FrmVehicleInsuranceTypeOne parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private VehicleInsuranceTypeOne objVehicleInsuranceTypeOne;
        public VehicleInsuranceTypeOne ObjVehicleInsuranceTypeOne
        {
            set
            {
                objVehicleInsuranceTypeOne = value;
                txtPolicyNo.Text = value.PolicyNo;
                fpiOrderNo.Value = value.OrderNo;
                txtPlatePrefix.Tag = value.AVehicleInfo;
                txtPlatePrefix.Text = value.AVehicleInfo.PlatePrefix;
                fpiPlateRunningNo.Text = value.AVehicleInfo.PlateRunningNo;
                txtBrand.Text = value.AVehicleInfo.AModel.ABrand.AName.English;
                txtModel.Text = value.AVehicleInfo.AModel.AName.English;
                txtEngineNo.Text = value.AVehicleInfo.EngineNo;
                txtChassisNo.Text = value.AVehicleInfo.ChassisNo;
                if (value.AffiliateDate == NullConstant.DATETIME)
                {
                    dtpAffiliateDate.Value = DateTime.Today;
                    dtpAffiliateDate.Checked = false;
                }
                else
                {
                    dtpAffiliateDate.Value = value.AffiliateDate;
                    dtpAffiliateDate.Checked = true;
                }

                fpdSumAssured.Value = value.SumAssured;
                fpdPremiumAmount.Value = value.PremiumAmount;
                fpdRevenueStampFee.Value = value.RevenueStampFee;
                fpdVatAmount.Value = value.VatAmount;
                fpdTotalAmount.Value = value.Amount;
            }
            get
            {
                objVehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
                objVehicleInsuranceTypeOne.PolicyNo = txtPolicyNo.Text;
                objVehicleInsuranceTypeOne.APeriod.From = dtpStartDate.Value;
                objVehicleInsuranceTypeOne.APeriod.To = dtpEndDate.Value;
                objVehicleInsuranceTypeOne.OrderNo = Convert.ToInt32(fpiOrderNo.Value);
                objVehicleInsuranceTypeOne.AVehicleInfo = (VehicleInfo)txtPlatePrefix.Tag;
                objVehicleInsuranceTypeOne.AffiliateDate = dtpAffiliateDate.Value;
                objVehicleInsuranceTypeOne.SumAssured = Convert.ToDecimal(fpdSumAssured.Value);
                objVehicleInsuranceTypeOne.PremiumAmount = Convert.ToDecimal(fpdPremiumAmount.Value);
                objVehicleInsuranceTypeOne.RevenueStampFee = Convert.ToDecimal(fpdRevenueStampFee.Value);
                objVehicleInsuranceTypeOne.VatAmount = Convert.ToDecimal(fpdVatAmount.Value);
                return objVehicleInsuranceTypeOne;
            }
        }

        private VehicleInsuranceList ObjVehicleInsuranceList
        {
            get 
            {
                return parentForm.FacadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList;
            }
        }

        //============================== Constructor ==============================
        public FrmVehicleInsuranceTypeOneEntry(FrmVehicleInsuranceTypeOne value) : base()
        {
            InitializeComponent();
            parentForm = value;
            setValue();
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
        }

        //============================== Private Method ==============================
        private void setValue()
        {
            fpdSumAssured.MaxValue = 9999999.99;
            fpdSumAssured.MinValue = 0;
            fpdPremiumAmount.MaxValue = 999999.99;
            fpdPremiumAmount.MinValue = 0;
            fpdRevenueStampFee.MaxValue = 9999.99;
            fpdRevenueStampFee.MinValue = 0;
            fpdVatAmount.MaxValue = 99999.99;
            fpdVatAmount.MinValue = 0;
            fpdVatPercent.MaxValue = 99.99;
            fpdVatPercent.MinValue = 0;
        }

        private void clearForm()
        {
            txtPlatePrefix.Text = "";
            fpiPlateRunningNo.Text = "";
            lblPlateNo.Text = "";
            lblPlatePrefix.Text = "";
            dtpAffiliateDate.Value = DateTime.Today;
            dtpAffiliateDate.Checked = false;

            fpdSumAssured.Value = decimal.Zero;
            fpdPremiumAmount.Value = decimal.Zero;
            fpdRevenueStampFee.Value = decimal.Zero;
            fpdVatAmount.Value = decimal.Zero;
            fpdTotalAmount.Value = decimal.Zero;
            fpdVatPercent.Value = parentForm.FacadeVehicleInsuranceTypeOne.GetVatRate();
        }

        private void calTotalAmount()
        {
            try
            {
                VehicleInsuranceTypeOne insuranceTypeOne = new VehicleInsuranceTypeOne();
                insuranceTypeOne.PremiumAmount = Convert.ToDecimal(fpdPremiumAmount.Value);
                parentForm.FacadeVehicleInsuranceTypeOne.CalculateTotalPremium(insuranceTypeOne, Convert.ToDecimal(fpdVatPercent.Value));
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

        private void formVehicleList()
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();

            dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
            dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
            dialogVehicleList.ShowDialog();

            if (dialogVehicleList.Selected)
            {
                setVehicle(parentForm.FacadeVehicleInsuranceTypeOne.GetVehicleInfo(dialogVehicleList.SelectedVehicle.PlatePrefix, dialogVehicleList.SelectedVehicle.PlateRunningNo));
            }
        }

        private void setInsuranceHeader(InsuranceTypeOne value)
        {
            txtPolicyNo.Text = value.PolicyNo;
            dtpStartDate.Value = value.APeriod.From;
            dtpEndDate.Value = value.APeriod.To;
        }

        private void setVehicle(VehicleInfo value)
        { 
            txtPlatePrefix.Tag = value;
            txtPlatePrefix.Text = value.PlatePrefix;
            fpiPlateRunningNo.Text = value.PlateRunningNo;
            txtBrand.Text = value.AModel.ABrand.AName.English;
            txtModel.Text = value.AModel.AName.English;
            txtEngineNo.Text = value.EngineNo;
            txtChassisNo.Text = value.ChassisNo;
        }

        private int getIncreaseOrderNo()
        {
            if (ObjVehicleInsuranceList.Count > 0)
            {
                return ObjVehicleInsuranceList[ObjVehicleInsuranceList.Count - 1].OrderNo + 1;
            }
            else
            {
                return 1;
            }
        }

        private void setForm(bool value)
        {
            fpiOrderNo.Enabled = value;
            fpiPlateRunningNo.Enabled = value;
            txtPlatePrefix.Enabled = value;
        }

        #region - validate -
        private bool validateForm()
        {
            if (int.Parse(fpiOrderNo.Text) == 0)
            {
                Message(MessageList.Error.E0002, "ลำดับ");
                fpiOrderNo.Focus();
                return false;
            }
            if (txtPlatePrefix.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "เลขทะเบียนรถ");
                txtPlatePrefix.Focus();
                return false;
            }
            if (fpiPlateRunningNo.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "เลขทะเบียนรถ");
                fpiPlateRunningNo.Focus();
                return false;
            }
            if (!dtpAffiliateDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่เข้าร่วม");
                dtpAffiliateDate.Focus();
                return false;
            }
            if (decimal.Parse(fpdSumAssured.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "ทุนประกัน");
                fpdSumAssured.Focus();
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

        private bool validatePlateVehicle()
        {
            if (txtPlatePrefix.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                txtPlatePrefix.Focus();
                return false;
            }
            else if (fpiPlateRunningNo.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                fpiPlateRunningNo.Focus();
                return false;
            }
            else
            {
                VehicleInfo vehicleInfo = parentForm.FacadeVehicleInsuranceTypeOne.GetVehicleInfo(txtPlatePrefix.Text.Trim(), fpiPlateRunningNo.Text.Trim());
                if (vehicleInfo == null)
                {
                    Message(MessageList.Error.E0004, "ทะเบียนรถ");
                    txtPlatePrefix.Focus();
                    return false;
                }
                else
                {
                    setVehicle(vehicleInfo);
                    return true;
                }
            }
        }

        private bool validateDupVehicle()
        {
            if (ObjVehicleInsuranceList.Contain((VehicleInfo)txtPlatePrefix.Tag))
            {
                Message(MessageList.Error.E0013, "เพิ่มรถคันนี้ได้", "มีรถคันนี้อยู่ในกรมธรรม์แล้ว");
                txtPlatePrefix.Focus();
                return false;
            }

            if (action == ActionType.ADD && parentForm.FacadeVehicleInsuranceTypeOne.CheckOutInsurance((VehicleInfo)txtPlatePrefix.Tag, dtpStartDate.Value, dtpEndDate.Value))
            {
                if (Message(MessageList.Question.Q0012) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        private bool validateOrderNo()
        {
            for (int i = 0; i < ObjVehicleInsuranceList.Count; i++)
            {
                if (Convert.ToInt32(fpiOrderNo.Value) == ObjVehicleInsuranceList[i].OrderNo)
                {
                    Message(MessageList.Error.E0035);
                    fpiOrderNo.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool validateVehicleStatus()
        {
            string vehicleStatus = ((VehicleInfo)txtPlatePrefix.Tag).AVehicleStatus.Code;

            if (action == ActionType.ADD && (vehicleStatus == "5" || vehicleStatus == "6"))
            {
                Message(MessageList.Error.E0014, "เพิ่มรถที่สิ้นสุดการใช้งานแล้วได้");
                fpiPlateRunningNo.Focus();
                return false;
            }
            return true;
        }

        private bool validateVehicle()
        {
            return validateOrderNo() && validatePlateVehicle() && validateVehicleStatus() && validateDupVehicle();
        }
        #endregion - validate -

        //============================== Public Method ==============================
        public void InitAddAction(InsuranceTypeOne value)
        {
            baseADD();
            setForm(true);
            clearForm();
            setInsuranceHeader(value);
            fpiOrderNo.Value = getIncreaseOrderNo();
            txtPlatePrefix.Focus();
        }

        public void InitEditAction(VehicleInsuranceTypeOne value, TimePeriod period)
        {
            baseEDIT();
            setForm(false);
            clearForm();
            ObjVehicleInsuranceTypeOne = value;
            dtpStartDate.Value = period.From;
            dtpEndDate.Value = period.To;

            fpdSumAssured.Focus();

            if (isReadOnly)
            {
                btnOK.Enabled = false;
                btnCalAmount.Enabled = false;
            }
        }

        //============================== Base Event ==============================
        private void addEvent()
        {
            try
            {
                if (validateVehicle() && validateForm())
                {
                    if (parentForm.AddRow(ObjVehicleInsuranceTypeOne))
                    {
                        clearForm();
                        fpiOrderNo.Value = getIncreaseOrderNo();
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
                    if (parentForm.UpdateRow(ObjVehicleInsuranceTypeOne))
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

        //============================== event ==============================
        private void FrmVehicleInsuranceTypeOneEntry_Load(object sender, EventArgs e)
        {

        }

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


        private void txtPlatePrefix_TextChanged(object sender, EventArgs e)
        {
            lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
            {
                fpiPlateRunningNo.Focus();
            }
        }

        private void fpiPlateRunningNo_TextChanged(object sender, EventArgs e)
        {
            lblPlateNo.Text = fpiPlateRunningNo.Text;
            if (fpiPlateRunningNo.Text.Length == 4)
            {
                validatePlateVehicle();
            }
        }

        private void fpiPlateRunningNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                validatePlateVehicle();
            }
        }

        private void fpiPlateRunningNo_DoubleClick(object sender, EventArgs e)
        {
            formVehicleList();
        }
    }
}

