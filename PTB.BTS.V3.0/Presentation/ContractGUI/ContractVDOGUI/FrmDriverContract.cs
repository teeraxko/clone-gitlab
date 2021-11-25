using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using System.Data.SqlClient;
using SystemFramework.AppException;
using Entity.ContractEntities;
using Entity.CommonEntity;

namespace Presentation.ContractGUI.ContractVDOGUI
{
    public partial class FrmDriverContract : FrmContractBase
    {
        #region - Constant -
        const int NUMBER_OF_CONTRACT_CHARGE = 6;
        const int BEGIN_MONTH_OF_FISCAL_YEAR = 8;
        #endregion

        #region - Private -
        private struct ContractChargeControl
        {
            public Label yearLabel;
            public Button CalculateButton;
            public DateTimePicker FormDateDTP;
            public DateTimePicker ToDateDTP;
            public UCTContractCharge UCTContractCharge;
        }

        private bool isReadonly = true;
        private bool _isChange = true;
        private DateTime[] chargeDate = new DateTime[6];
        private int chargeDateIndex = 0;
        private DateTimePicker lastDateTimePicker;
        private ContractChargeDetailList listChargeDetail = null;
        #endregion

        //==============================  Constructor  ==============================
        public FrmDriverContract() : base()
        {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractDriver");
            this.title = UserProfile.GetFormName("miContract", "miContractDriver");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDriver");
        }

        #region - Validate -
        private bool validateContract()
        {
            if (dtpContractStart.Value.Date > dtpContractEnd.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้นสัญญา", "วันที่สิ้นสุดสัญญา");
                dtpContractStart.Focus();
                return false;
            }

            if (rdoDay.Checked)
            {
                //DateTime cosiderMonth = dtpContractStart.Value.AddMonths(2);
                //if (getYearMonth(dtpContractEnd.Value) > getYearMonth(cosiderMonth))
                //{
                //    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 3 เดือน");
                //    dtpContractEnd.Focus();
                //    return false;
                //}
            }
            else
            {
                int yearCount = calculateYear(dtpContractStart.Value.Date, dtpContractEnd.Value.Date);
                if (yearCount > 6)
                {
                    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 5 ปี");
                    dtpContractEnd.Focus();
                    return false;
                }
            }



            return true;
        }

        private bool validateInputContractChagre(ContractChargeControl control)
        {
            if (control.FormDateDTP.Value > control.ToDateDTP.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                control.ToDateDTP.Focus();
                return false;
            }

            if (!validateConnectBizPac(control))
            {
                return false;
            }

            if (control.UCTContractCharge.RateAmount == 0)
            {
                DialogResult dialog = Message(MessageList.Warning.W0001);

                if (dialog.Equals(DialogResult.Cancel))
                {
                    control.UCTContractCharge.Focus();
                    return false;
                }
            }

            if (rdoDay.Checked && control.UCTContractCharge.RateAmount > 32000)
            {
                Message(MessageList.Error.E0041);
                control.UCTContractCharge.Focus();
                return false;
            }
            
            return true;
        }

        private bool validateUCTContractChagre(ContractChargeControl control)
        {
            bool result = false;

            if (control.FormDateDTP.Value.Date > control.ToDateDTP.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                control.ToDateDTP.Focus();
                return false;
            }

            if (control.UCTContractCharge.RateAmount == 0)
            {
                return true;
            }
            else
            {
                if (control.UCTContractCharge.FirstMonth != 0)
                {
                    if (control.UCTContractCharge.RateAmountTag == control.UCTContractCharge.RateAmount)
                    {
                        if (control.UCTContractCharge.DateForm == control.FormDateDTP.Value.Date)
                        {
                            if (control.UCTContractCharge.DateTo == control.ToDateDTP.Value.Date)
                            {
                                if (control.UCTContractCharge.RateStatusByMonth == rdoMonth.Checked)
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
                    control.CalculateButton.Focus();
                    return false;
                }
            }

            return result;
        }

        protected override bool validateContractCharge()
        {
            if (!validateContract())
            {
                return false;
            }

            if (flagDateForm != dtpContractStart.Value.Date)
            {
                Message(MessageList.Error.E0042, "");
                btnCreate.Focus();
                return false;
            }
            if (flagDateTo != dtpContractEnd.Value.Date)
            {
                Message(MessageList.Error.E0042, "");
                btnCreate.Focus();
                return false;
            }

            if (lastDateTimePicker.Value != dtpContractEnd.Value)
            {
                Message(MessageList.Error.E0042);
                btnCreate.Focus();
                return false;
            }

            if (uctContractCharge1.RateAmount == 0)
            {
                DialogResult dialog = Message(MessageList.Warning.W0001);

                if (dialog.Equals(DialogResult.Cancel))
                {
                    uctContractCharge1.Focus();
                    return false;
                }
            }

            ContractChargeControl control;
            for (int i = 0; i < 6; i++)
            {
                control = getControl(i);
                if (control.UCTContractCharge.UnitChargeEnable)
                {
                    if (!validateUCTContractChagre(control))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool validateConnectBizPac(ContractChargeControl control)
        {
            if (listChargeDetail != null)
            {
                bool resultCheck = false;

                for (DateTime date = control.FormDateDTP.Value; date < control.ToDateDTP.Value; date = date.AddMonths(1))
                {
                    resultCheck |= listChargeDetail.Contain(date.Year.ToString() + date.Month.ToString());
                }

                if (resultCheck)
                {
                    DialogResult dialog = Message(MessageList.Warning.W0005);

                    if (dialog.Equals(DialogResult.Cancel))
                    {
                        control.UCTContractCharge.RateAmount = control.UCTContractCharge.RateAmountTag;
                        control.UCTContractCharge.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        #endregion

        protected override void setContractBase(ContractBase driverContract)
        {
            base.setContractBase(driverContract);
            flagDateForm = driverContract.AContractChargeList[0].APeriod.From;
            flagDateTo = driverContract.AContractChargeList[driverContract.AContractChargeList.Count - 1].APeriod.To;
            setUCT(0, driverContract.AContractChargeList);
            SetDeduct(driverContract);

            listChargeDetail = facadeContract.GetContractChargeDetailNoneBPNoList(driverContract);

            if (isReadonly)
            {
                grbServiceCharge.Enabled = false;
                IsMustQuestion = false;
            }
        }        

        #region - Private -
        private void fillContractCharge(ContractChargeControl control, int index, ContractChargeList value)
        {
            visibleContractCharge(control, true);
            enableContractChargeControl(control, index, value.Count);
            //			control.CalculateButton.Enabled = true;

            ContractCharge contractCharge = value[index];

            bindContractCharge(control.UCTContractCharge, contractCharge);

            control.FormDateDTP.Value = contractCharge.APeriod.From.Date;
            control.ToDateDTP.Value = contractCharge.APeriod.To.Date;

            contractCharge = null;
        }

        private void setUCT(int index, ContractChargeList value)
        {
            ContractChargeControl control = getControl(index);
            fillContractCharge(control, index, value);

            if (index == value.Count - 1)
            {
                lastDateTimePicker = control.ToDateDTP;
                return;
            }
            else
            {
                setUCT(index + 1, value);
            }
        }

        private void fillUCTContractCharge(ContractChargeControl control)
        {
            control.UCTContractCharge.AbsentDeduct = Convert.ToInt16(fpiAbsence.Value);
            control.UCTContractCharge.RateAmountTag = control.UCTContractCharge.RateAmount;
            control.UCTContractCharge.DateForm = control.FormDateDTP.Value.Date;
            control.UCTContractCharge.DateTo = control.ToDateDTP.Value.Date;
            control.UCTContractCharge.RateStatusByMonth = rdoMonth.Checked;
            control.UCTContractCharge.UnitChargeAmountByMonthForDriver();
        }

        private void getUCT(int index, ContractChargeList value)
        {
            if (index < NUMBER_OF_CONTRACT_CHARGE)
            {
                ContractChargeControl control = getControl(index);
                if (control.UCTContractCharge.UnitChargeEnable)
                {
                    fillUCTContractCharge(control);
                    value.Add(getContractCharge(control.UCTContractCharge));
                    getUCT(index + 1, value);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

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

        private void GetDeductPerDay(DRIVER_DEDUCT_STATUS deductStatus)
        {
            try
            {
                fpiAbsence.Value = facadeContract.GetDeductChargeRate((ContractBase)txtContractNoXXX.Tag, (Customer)cboCustomerTHName.SelectedItem, deductStatus);
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private void SetDeduct(ContractBase contract)
        {
            try
            {
                _isChange = false;

                gpbDeduct.Enabled = (contract.AContractStatus.Code == "1");

                DriverDeductCharge driverDeductCharge;

                if (((ServiceStaffContract)contract).ALatestServiceStaffRoleList.Count > 0)
                {
                    driverDeductCharge = facadeContract.GetDriverDeductCharge(contract);
                }
                else
                {
                    driverDeductCharge = contract.DriverDeductCharge;
                }

                if (driverDeductCharge != null)
                {
                    switch (driverDeductCharge.DriverDeductStatus)
                    {
                        case DRIVER_DEDUCT_STATUS.DRIVERONLY:
                            rabDriverOnly.Checked = true;
                            break;
                        case DRIVER_DEDUCT_STATUS.DRIVERMATCH:
                            rabDriverCar.Checked = true;
                            break;
                        //Family only not declare : woranai

                        //case DRIVER_DEDUCT_STATUS.DRIVERFAMILYONLY:
                        //    rabFamilyOnly.Checked = true;
                        //    break;
                        case DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH:
                            rabFamilyCar.Checked = true;
                            break;
                        default:
                            rabOtherDeduct.Checked = true;
                            break;
                    }

                    fpiAbsence.Value = driverDeductCharge.DeductAmount;
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
            finally
            {
                _isChange = true;
            }
        }

        private void FillDeduct(ContractBase contract)
        {
            if (rabDriverOnly.Checked)
            {
                contract.DriverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERONLY;
            }
            else if (rabDriverCar.Checked)
            {
                contract.DriverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERMATCH;
            }
            //Family only not declare : woranai

            //else if (rabFamilyOnly.Checked)
            //{
            //    contract.DriverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERFAMILYONLY;
            //}
            else if (rabFamilyCar.Checked)
            {
                contract.DriverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH;
            }
            else 
            {
                contract.DriverDeductCharge.DriverDeductStatus = DRIVER_DEDUCT_STATUS.OTHER;
            }

            contract.DriverDeductCharge.DeductAmount = Convert.ToInt16(fpiAbsence.Value);
        }

        #region - Clear & Visible Control -
        private void clearContractCharge(ContractChargeControl control)
        {
            control.CalculateButton.Enabled = false;
            control.FormDateDTP.Value = DateTime.Today.Date;
            control.ToDateDTP.Value = DateTime.Today.Date;
            control.ToDateDTP.Enabled = false;
            control.UCTContractCharge.Clear();
            control.UCTContractCharge.UnitChargeEnable = false;

            visibleContractCharge(control, false);
        }

        private void visibleContractCharge(ContractChargeControl control, bool visible)
        {
            control.yearLabel.Visible = visible;
            control.CalculateButton.Visible = visible;
            control.FormDateDTP.Visible = visible;
            control.ToDateDTP.Visible = visible;
            control.UCTContractCharge.Visible = visible;
        }

        private void enableContractChargeControl(ContractChargeControl control, int index, int count)
        {
            control.CalculateButton.Enabled = true;
            control.UCTContractCharge.UnitChargeEnable = true;


            control.ToDateDTP.Enabled = true;
            //					if(index == count-1)
            //					{
            //						control.ToDateDTP.Enabled = false;
            //					}
            //					else
            //					{
            //						control.ToDateDTP.Enabled = true;
            //					}
        }
        #endregion

        #region - Get Control -
        private ContractChargeControl getControl(int index)
        {
            ContractChargeControl contractChargeControl = new ContractChargeControl();
            switch (index)
            {
                case 0:
                    {
                        contractChargeControl.yearLabel = lblYear1;
                        contractChargeControl.CalculateButton = btnCal1;
                        contractChargeControl.FormDateDTP = dtpCCForm1;
                        contractChargeControl.ToDateDTP = dtpCCTo1;
                        contractChargeControl.UCTContractCharge = uctContractCharge1;
                        break;
                    }
                case 1:
                    {
                        contractChargeControl.yearLabel = lblYear2;
                        contractChargeControl.CalculateButton = btnCal2;
                        contractChargeControl.FormDateDTP = dtpCCForm2;
                        contractChargeControl.ToDateDTP = dtpCCTo2;
                        contractChargeControl.UCTContractCharge = uctContractCharge2;
                        break;
                    }
                case 2:
                    {
                        contractChargeControl.yearLabel = lblYear3;
                        contractChargeControl.CalculateButton = btnCal3;
                        contractChargeControl.FormDateDTP = dtpCCForm3;
                        contractChargeControl.ToDateDTP = dtpCCTo3;
                        contractChargeControl.UCTContractCharge = uctContractCharge3;
                        break;
                    }
                case 3:
                    {
                        contractChargeControl.yearLabel = lblYear4;
                        contractChargeControl.CalculateButton = btnCal4;
                        contractChargeControl.FormDateDTP = dtpCCForm4;
                        contractChargeControl.ToDateDTP = dtpCCTo4;
                        contractChargeControl.UCTContractCharge = uctContractCharge4;
                        break;
                    }
                case 4:
                    {
                        contractChargeControl.yearLabel = lblYear5;
                        contractChargeControl.CalculateButton = btnCal5;
                        contractChargeControl.FormDateDTP = dtpCCForm5;
                        contractChargeControl.ToDateDTP = dtpCCTo5;
                        contractChargeControl.UCTContractCharge = uctContractCharge5;
                        break;
                    }
                case 5:
                    {
                        contractChargeControl.yearLabel = lblYear6;
                        contractChargeControl.CalculateButton = btnCal6;
                        contractChargeControl.FormDateDTP = dtpCCForm6;
                        contractChargeControl.ToDateDTP = dtpCCTo6;
                        contractChargeControl.UCTContractCharge = uctContractCharge6;
                        break;
                    }
            }
            return contractChargeControl;
        }
        #endregion

        #region - Calculate & Bind Year -
        private DateTime getChangeRateDate(DateTime value)
        {
            if (value.Month < BEGIN_MONTH_OF_FISCAL_YEAR)
            {
                return new DateTime(value.Year, BEGIN_MONTH_OF_FISCAL_YEAR, 1);
            }
            else
            {
                return new DateTime(value.Year + 1, BEGIN_MONTH_OF_FISCAL_YEAR, 1);
            }
        }

        private int calculateYear(DateTime value, DateTime toDate)
        {
            if (value <= toDate)
            {
                DateTime changeRateDate = getChangeRateDate(value);
                if (chargeDateIndex < NUMBER_OF_CONTRACT_CHARGE)
                {
                    chargeDate[chargeDateIndex++] = changeRateDate.AddDays(-1);
                }
                if (value < changeRateDate)
                {
                    return calculateYear(changeRateDate, toDate) + 1;
                }
                else
                {
                    return calculateYear(changeRateDate.AddYears(1), toDate) + 1;
                }
            }
            else
            {
                return 0;
            }
        }

        private void bindYear(int index, int count)
        {
            ContractChargeControl contractChargeControl = getControl(index);
            visibleContractCharge(contractChargeControl, true);
            enableContractChargeControl(contractChargeControl, index, count);

            if (index == count - 1)
            {
                dtpCCForm1.Value = dtpContractStart.Value;
                contractChargeControl.ToDateDTP.Value = dtpContractEnd.Value;
                lastDateTimePicker = contractChargeControl.ToDateDTP;
            }
            else
            {
                contractChargeControl.ToDateDTP.Value = chargeDate[index];
                bindYear(index + 1, count);
            }
        }
        #endregion
        #endregion

        #region - protected Method -
        protected override void visibleChild(bool visible)
        {
            grbServiceCharge.Visible = visible;
            gpbDeduct.Visible = visible;
        }

        protected override void addCase()
        {
            base.addCase();
            grbServiceCharge.Visible = true;
            gpbDeduct.Visible = true;
            listChargeDetail = null;
        }

        protected override void enableCalculate(bool enable)
        {
            btnCreate.Enabled = enable;
            gpbDeduct.Enabled = enable;

            if (!enable)
            {
                enableContractCharge(false);
            }
        }

        protected override void enableContractCharge(bool enable)
        {
            if (!enable)
            {
                ContractChargeControl contractChargeControl;
                for (int i = 0; i < 6; i++)
                {
                    contractChargeControl = getControl(i);
                    contractChargeControl.CalculateButton.Enabled = false;
                    contractChargeControl.ToDateDTP.Enabled = false;
                    contractChargeControl.UCTContractCharge.UnitChargeEnable = false;
                }
            }
        }

        protected override void addContractCharge(ContractBase contract)
        {
            contract.AContractChargeList.Clear();
            getUCT(0, contract.AContractChargeList);
            FillDeduct(contract);
        }

        protected override void ClearContractCharge()
        {
            clearContractCharge(getControl(0));
            clearContractCharge(getControl(1));
            clearContractCharge(getControl(2));
            clearContractCharge(getControl(3));
            clearContractCharge(getControl(4));
            clearContractCharge(getControl(5));
        }

        protected override void ClearDeduct()
        {
            _isChange = false;
            rabOtherDeduct.Checked = true;
            fpiAbsence.Value = 0;
            _isChange = true;
        }
        #endregion

        //==============================  Base Event   ==============================
        private DateTime flagDateForm;
        private DateTime flagDateTo;

        private void calculateEnableCharge()
        {
            chargeDateIndex = 0;
            try
            {
                int enableCount = calculateYear(dtpContractStart.Value.Date, dtpContractEnd.Value.Date);
                if (enableCount > 0 && enableCount < 7)
                {
                    bindYear(0, enableCount);
                }
                flagDateForm = dtpContractStart.Value.Date;
                flagDateTo = dtpContractEnd.Value.Date;
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
            finally
            { }
        }

        private void claculateClick(int index)
        {
            if (lastDateTimePicker.Value != dtpContractEnd.Value)
            {
                Message(MessageList.Error.E0042);
                btnCreate.Focus();
                return;
            }

            ContractChargeControl control = getControl(index);
            if (control.UCTContractCharge.UnitChargeEnable && !validateInputContractChagre(control))
            {
                return;
            }

            try
            {
                fillUCTContractCharge(control);
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
            finally
            { }
        }

        //==============================     event     ==============================
        private void FrmDriverContract_Load(object sender, EventArgs e)
        {
            setPermission(isReadonly);
            InitForm();
            initCombo();
            selectContract(ContractType.CONTRACT_TYPE_DRIVER);
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            if (validateContract())
            {
                if (uctContractCharge1.Visible)
                {
                    if (Message(MessageList.Question.Q0008) == DialogResult.Yes)
                    {
                        ClearContractCharge();
                        calculateEnableCharge();
                    }
                }
                else
                {
                    ClearContractCharge();
                    calculateEnableCharge();
                }
            }
        }

        #region - btnCalX_Click -
        private void btnCal1_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(0);
        }

        private void btnCal2_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(1);
        }

        private void btnCal3_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(2);
        }

        private void btnCal4_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(3);
        }

        private void btnCal5_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(4);
        }

        private void btnCal6_Click(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            claculateClick(5);
        }
        #endregion

        #region - dtpCCToX_ValueChanged -
        private void dtpCCTo1_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            dtpCCForm2.Value = dtpCCTo1.Value.AddDays(1);
        }

        private void dtpCCTo2_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            dtpCCForm3.Value = dtpCCTo2.Value.AddDays(1);
        }

        private void dtpCCTo3_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            dtpCCForm4.Value = dtpCCTo3.Value.AddDays(1);
        }

        private void dtpCCTo4_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            dtpCCForm5.Value = dtpCCTo4.Value.AddDays(1);
        }

        private void dtpCCTo5_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            dtpCCForm6.Value = dtpCCTo5.Value.AddDays(1);
        }
        #endregion

        #region - deduct checked -
        private void rabDriverOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_isChange && rabDriverOnly.Checked)
                GetDeductPerDay(DRIVER_DEDUCT_STATUS.DRIVERONLY);
        }

        private void rabDriverCar_CheckedChanged(object sender, EventArgs e)
        {
            if (_isChange && rabDriverCar.Checked)
                GetDeductPerDay(DRIVER_DEDUCT_STATUS.DRIVERMATCH);
        }

        private void rabFamilyCar_CheckedChanged(object sender, EventArgs e)
        {
            if (_isChange && rabFamilyCar.Checked)
                GetDeductPerDay(DRIVER_DEDUCT_STATUS.DRIVERFAMILYMATCH);
        }

        private void rabOtherDeduct_CheckedChanged(object sender, EventArgs e)
        {
            fpiAbsence.Enabled = rabOtherDeduct.Checked;
            if (_isChange)
            {
                fpiAbsence.Value = 0;
            }
        }
        #endregion
    }
}