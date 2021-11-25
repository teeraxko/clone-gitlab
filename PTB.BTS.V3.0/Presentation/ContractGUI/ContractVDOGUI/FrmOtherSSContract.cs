using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using Entity.ContractEntities;

namespace Presentation.ContractGUI.ContractVDOGUI
{
    public partial class FrmOtherSSContract : FrmContractBase
    {
        private bool isReadonly = true;

        //==============================  Constructor  ==============================
        public FrmOtherSSContract() : base()
        {
            InitializeComponent();
            visibleChild(false);
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractOtherServiceStaft");
            this.title = UserProfile.GetFormName("miContract", "miContractOtherServiceStaft");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractOtherServiceStaft");
        }
        #region - Private Method -
        private void setIsMustQuestion()
        {
            if (isReadonly)
                IsMustQuestion = false;
            else
                IsMustQuestion = true;
        }

        private int getYearMonth(DateTime value)
        {
            int result = value.Year * 100;
            result = result + value.Month;
            return result;
        }

        private bool validateContractChageInput()
        {
            if (dtpContractStart.Value.Date > dtpContractEnd.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้นสัญญา", "วันที่สิ้นสุดสัญญา");
                dtpContractStart.Focus();
                return false;
            }

            if (rdoDay.Checked)
            {
                DateTime cosiderMonth = dtpContractStart.Value.AddMonths(2);
                if (getYearMonth(dtpContractEnd.Value) > getYearMonth(cosiderMonth))
                {
                    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 3 เดือน");
                    dtpContractEnd.Focus();
                    return false;
                }
            }

            if (uctContractCharge1.RateAmount == 0)
            {
                Message(MessageList.Error.E0002, "อัตราค่าบริการ");
                uctContractCharge1.Focus();
                return false;
            }

            if (rdoDay.Checked && uctContractCharge1.RateAmount > 32000)
            {
                Message(MessageList.Error.E0041);
                uctContractCharge1.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region - Validate -
        protected override bool validateContractCharge()
        {
            bool result = validateContractChageInput();
            if (!result)
            {
                return false;
            }

            result = false;
            if (uctContractCharge1.FirstMonth != 0)
            {
                if (uctContractCharge1.RateAmountTag == uctContractCharge1.RateAmount)
                {
                    if (uctContractCharge1.DateForm == dtpContractStart.Value.Date)
                    {
                        if (uctContractCharge1.DateTo == dtpContractEnd.Value.Date)
                        {
                            if (uctContractCharge1.RateStatusByMonth == rdoMonth.Checked)
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            if (!result)
            {
                Message(MessageList.Error.E0017);
                btnCal.Focus();
                return false;
            }

            return result;
        }

        #endregion

        #region - protected Method -
        protected override void addCase()
        {
            base.addCase();
            grbServiceCharge.Visible = true;
        }

        protected override void setContractBase(ContractBase value)
        {
            base.setContractBase(value);
            bindContractCharge(uctContractCharge1, value.AContractChargeList[0]);
        }

        protected override void visibleChild(bool visible)
        {
            grbServiceCharge.Visible = visible;
        }

        protected override void enableCalculate(bool enable)
        {
            btnCal.Enabled = enable;
        }

        protected override void enableContractCharge(bool enable)
        {
            uctContractCharge1.UnitChargeEnable = enable;
        }

        protected override void addContractCharge(ContractBase value)
        {
            value.AContractChargeList.Clear();
            value.AContractChargeList.Add(getContractCharge(uctContractCharge1));
        }

        protected override void ClearContractCharge()
        {
            uctContractCharge1.Clear();
        }
        #endregion

        //============================== Event ==============================
        private void FrmOtherSSContract_Load(object sender, EventArgs e)
        {
            setPermission(isReadonly);
            InitForm();
            initCombo();
            selectContract("O");
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            setIsMustQuestion();
            if (!validateContractChageInput())
            {
                return;
            }

            uctContractCharge1.RateAmountTag = uctContractCharge1.RateAmount;

            uctContractCharge1.DateForm = dtpContractStart.Value.Date;
            uctContractCharge1.DateTo = dtpContractEnd.Value.Date;
            uctContractCharge1.RateStatusByMonth = rdoMonth.Checked;
            uctContractCharge1.UnitChargeAmountByMonthForOtherStaff();
        }
    }
}