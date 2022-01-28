using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using PTB.BTS.ContractEntities.ContractChargeRate;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmChargeRateByContractEntry : EntryFormBase
    {
        private FrmChargeRateByContract parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private ChargeRateByContract objChargeRateByContract;
        public ChargeRateByContract ObjChargeRateByContract
        {
            set
            {
                objChargeRateByContract = value;
                setContract(value.ContractBase);
                fpdOTARate.Value = value.ChargeRate.OTARate;
                fpdOTBRate.Value = value.ChargeRate.OTBRate;
                fpdOTCRate.Value = value.ChargeRate.OTCRate;
                fpiAbsence.Value = value.ChargeRate.AbsenceDeduction;
                fpiOneDayFar.Value = value.ChargeRate.OneDayTripRateFar;
                //fpiOneDayNear.Value = value.ChargeRate.OneDayTripRateNear;
                fpiOvernight.Value = value.ChargeRate.OvernightTripRate;
                fpiTaxi.Value = value.ChargeRate.TaxiRate;
                fpiMinLeave.Value = value.ChargeRate.MinLeaveDays;
                fpdMinHolidayAmount.Value = value.ChargeRate.MinHolidayAmount;
            }
            get
            {
                objChargeRateByContract = new ChargeRateByContract();
                objChargeRateByContract.ContractBase = (ContractBase)txtContractNoXXX.Tag;
                objChargeRateByContract.ChargeRate.OTARate = Convert.ToDecimal(fpdOTARate.Value);
                objChargeRateByContract.ChargeRate.OTBRate = Convert.ToDecimal(fpdOTBRate.Value);
                objChargeRateByContract.ChargeRate.OTCRate = Convert.ToDecimal(fpdOTCRate.Value);
                objChargeRateByContract.ChargeRate.AbsenceDeduction = Convert.ToInt32(fpiAbsence.Value);
                objChargeRateByContract.ChargeRate.OneDayTripRateFar = Convert.ToInt32(fpiOneDayFar.Value);
                //objChargeRateByContract.ChargeRate.OneDayTripRateNear = Convert.ToInt32(fpiOneDayNear.Value);
                objChargeRateByContract.ChargeRate.OvernightTripRate = Convert.ToInt32(fpiOvernight.Value);
                objChargeRateByContract.ChargeRate.TaxiRate = Convert.ToInt32(fpiTaxi.Value);
                objChargeRateByContract.ChargeRate.MinLeaveDays = Convert.ToByte(fpiMinLeave.Value);
                objChargeRateByContract.ChargeRate.MinHolidayAmount = Convert.ToDecimal(fpdMinHolidayAmount.Value);
                return objChargeRateByContract;
            }
        }

        //============================== Constructor ==============================
        public FrmChargeRateByContractEntry(FrmChargeRateByContract value)
        {
            InitializeComponent();
            setValue();
            parentForm = value;
            isReadOnly = false;
            isReadOnly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffChargeContract");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingServiceStaffChargeContract");
        }

        private void setContract(ContractBase value)
        {           
            txtContractNoYY.Text = value.ContractNo.Year;
            txtContractNoMM.Text = value.ContractNo.Month;
            txtContractNoXXX.Text = value.ContractNo.No;
            txtContractNoXXX.Tag = value;
            SetContractPrefix(value);
        }

        /// <summary>
        /// Set contract prefix according to contract no.
        /// </summary>
        /// <param name="contract"></param>
        private void SetContractPrefix(ContractBase contract)
        {            
            if (contract != null && contract.ContractNo != null)
            {
                lblContractPrefix.Text = contract.ContractNo.ToString().Substring(4, 1);
            }

            if (lblContractPrefix.Text.Trim().Length == 0)
            {
                lblContractPrefix.Text = "D";//default
            }
            
            
        }

        private DocumentNo getContractNo()
        {
            return new DocumentNo(DOCUMENT_TYPE.CONTRACT_DRIVER, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
        }

        private void formContractList()
        {
            frmContractVDOList dialogContractList = new frmContractVDOList();
            dialogContractList.IsDOContract = true;
            //dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_DRIVER;
           
            if (txtContractNoYY.Text != "")
                dialogContractList.ConditionYY = txtContractNoYY.Text;
            if (txtContractNoMM.Text != "")
                dialogContractList.ConditionMM = txtContractNoMM.Text;
            if (txtContractNoXXX.Text != "")
                dialogContractList.ConditionXXX = txtContractNoXXX.Text;
            dialogContractList.ShowDialog();
            if (dialogContractList.Selected)
                setContract(dialogContractList.SelectedContract);

            dialogContractList = null;
        }

        //============================== Private Method ==============================
        private void setValue()
        {
            fpdOTARate.MinValue = 0.00;
            fpdOTARate.MaxValue = 999.99;
            fpdOTBRate.MinValue = 0.00;
            fpdOTBRate.MaxValue = 999.99;
            fpdOTCRate.MinValue = 0.00;
            fpdOTCRate.MaxValue = 999.99;
            fpdMinHolidayAmount.MinValue = 0.00;
            fpdMinHolidayAmount.MaxValue = 999.99;
        }

        private void clearForm()
        {
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txtContractNoYY.Text = "";
            fpdOTARate.Value = decimal.Zero;
            fpdOTBRate.Value = decimal.Zero;
            fpdOTCRate.Value = decimal.Zero;
            fpiAbsence.Value = 0;
            fpiOneDayFar.Value = 120;
            //fpiOneDayNear.Value = 70;
            fpiOvernight.Value = 500;
            fpiTaxi.Value = 100;
            fpiMinLeave.Value = 0;
            fpdMinHolidayAmount.Value = decimal.Zero;
        }

        #region - validate -
        private bool validateForm()
        {
            //if (decimal.Parse(fpdOTARate.Text) == 0m)
            //{
            //    Message(MessageList.Error.E0002, "OT rate A");
            //    fpdOTARate.Focus();
            //    return false;
            //}
            //if (decimal.Parse(fpdOTBRate.Text) == 0m)
            //{
            //    Message(MessageList.Error.E0002, "OT rate B");
            //    fpdOTBRate.Focus();
            //    return false;
            //}
            //if (decimal.Parse(fpdOTCRate.Text) == 0m)
            //{
            //    Message(MessageList.Error.E0002, "OT rate C");
            //    fpdOTCRate.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiAbsence.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "Absence deduction per day");
            //    fpiAbsence.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiOneDayFar.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางไป - กลับ (ไกล)");
            //    fpiOneDayFar.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiOneDayNear.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางไป - กลับ (ใกล้)");
            //    fpiOneDayNear.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiOvernight.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางค้างคืน");
            //    fpiOvernight.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiTaxi.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่า Taxi");
            //    fpiTaxi.Focus();
            //    return false;
            //}
            //if (int.Parse(fpiMinLeave.Text) == 0)
            //{
            //    Message(MessageList.Error.E0002, "วันลาขั้นต่ำ");
            //    fpiMinLeave.Focus();
            //    return false;
            //}
            return true;
        }

        private bool validatetxtContractNo()
		{
			if(txtContractNoYY.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoYY.Focus();
				return false;
			}
            if (txtContractNoMM.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoMM.Focus();
                return false;
            }
            if (txtContractNoXXX.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoXXX.Focus();
                return false;
            }
			return true;
		}

		private bool validateContract()
		{
            txtContractNoXXX.Tag = parentForm.FacadeChargeRateByContract.RetriveDriverContract(getContractNo());
            if (txtContractNoXXX.Tag == null)
			{
				Message(MessageList.Error.E0004, "เลขที่สัญญา");
				txtContractNoYY.Focus();
                return false;
			}
            return true;
        }
        #endregion

        //============================== Public Method ==============================
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            gpbContractDetail.Enabled = true;
            txtContractNoYY.Focus();
        }

        internal void InitEditAction(ChargeRateByContract selectedChargeRateByContract)
        {
            baseEDIT();
            clearForm();
            gpbContractDetail.Enabled = false;
            ObjChargeRateByContract = selectedChargeRateByContract;

            if (isReadOnly)
            {
                btnOK.Enabled = false;
            }
        }

        //============================== Base Event ==============================
        private void addEvent()
        {
            try
            {
                if (validatetxtContractNo() && validateContract() && validateForm())
                {
                    if (parentForm.AddRow(ObjChargeRateByContract))
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
                    if (parentForm.UpdateRow(ObjChargeRateByContract))
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
        private void FrmChargeRateByContractEntry_Load(object sender, EventArgs e)
        { }

        private void txtContractNoYY_TextChanged(object sender, EventArgs e)
        {
            if (txtContractNoYY.Text.Length == 2)
                txtContractNoMM.Focus();
        }

        private void txtContractNoMM_TextChanged(object sender, EventArgs e)
        {
            if (txtContractNoMM.Text.Length == 2)
                txtContractNoXXX.Focus();
        }

        private void txtContractNoXXX_TextChanged(object sender, EventArgs e)
        {
            if (action == ActionType.ADD)
            {
                if (txtContractNoXXX.Text.Length == 3)
                { 

                }
            }
          
        }

        private void txtContractNoXXX_DoubleClick(object sender, EventArgs e)
        {
            formContractList();
        }

        private void txtContractNoXXX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            { 
            
            }
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
    }
}

