using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entity.ContractEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using Facade.CommonFacade;
using Entity.VehicleEntities;
using Report.GUI.Contract;
using Report;

namespace Presentation.ContractGUI.ContractVDOGUI
{
    public partial class FrmVehicleContract : FrmContractBase
    {
        private bool isReadonly = true;

        //==============================  Constructor  ==============================
        public FrmVehicleContract() : base()
        {
            InitializeComponent();
            visibleChild(false);
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractVehicle");
            this.title = UserProfile.GetFormName("miContract", "miContractVehicle");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractVehicle");
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
                if (uctContractCharge1.DateTo != dtpContractEnd.Value.Date)
                {
                    Message(MessageList.Error.E0017);
                    btnCal.Focus();
                    return false;
                }

                if (Message(MessageList.Warning.W0004) == DialogResult.Cancel)
                {
                    btnCal.Focus();
                    return false;
                }
                else
                {
                    result = true;
                }
            }

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
                //[Napat C.] 18/02/2019 obsolete
                //DateTime cosiderMonth = dtpContractStart.Value.AddMonths(2);
                //if (getYearMonth(dtpContractEnd.Value) > getYearMonth(cosiderMonth))
                //{
                //    Message(MessageList.Error.E0005, "ช่วงสัญญาไม่เกิน 3 เดือน");
                //    dtpContractEnd.Focus();
                //    return false;
                //}
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

        #region - protected Method -
        protected override void addCase()
        {
            base.addCase();
            grbServiceCharge.Visible = true;
            gpbLeaseTerm.Visible = true;
        }

        protected override void setContractBase(ContractBase value)
        {
            base.setContractBase(value);
            bindContractCharge(uctContractCharge1, value.AContractChargeList[0]);
        }

        protected override void visibleChild(bool visible)
        {
            grbServiceCharge.Visible = visible;
            gpbLeaseTerm.Visible = visible;
        }

        protected override void enableCalculate(bool enable)
        {
            btnCal.Enabled = enable;
        }

        protected override void enableContractCharge(bool enable)
        {
            uctContractCharge1.UnitChargeEnable = enable;
            uctContractCharge1.fpdFirstMonth.Enabled = enable;
            uctContractCharge1.fpdLastMonth.Enabled = enable;
            uctContractCharge1.fpdNextMonth.Enabled = enable;
        }

        /// <summary>
        /// Do this function after call retrive contract for retrive special data of VehicleContract
        /// </summary>
        /// <param name="derivedContract"></param>
        protected override void RetriveDrivedContract(ContractBase vehicleContract) {

            if ((vehicleContract.AContractStatus.Code == ContractStatus.CONTRACT_STS_CREATED) && (vehicleContract.AKindOfContract.Code == KindOfContract.KIND_OF_CONTRACT_LONG))
            {

                // set enable contract charge control
                this.uctContractCharge1.UnitChargeEnable = false;
                this.uctContractCharge1.fpdFirstMonth.Enabled = true;
                this.uctContractCharge1.fpdLastMonth.Enabled = true;
                this.uctContractCharge1.fpdNextMonth.Enabled = true;
                this.btnCal.Enabled = true;
            }
        }

        protected override void addContractCharge(ContractBase value)
        {
            value.AContractChargeList.Clear();
            value.AContractChargeList.Add(getContractCharge(uctContractCharge1));
        }

        protected override void ClearContractCharge()
        {
            uctContractCharge1.Clear();
            fpiLeaseTerm.Value = 0;
            if (cboKindRental.Items.Count > 0)
            {
                cboKindRental.SelectedIndex = 0;
            }
        }

        protected override void SetLeaseTerm(VehicleContract vehicleContract)
        {
            vehicleContract.LeaseTermMonth = Convert.ToInt16(fpiLeaseTerm.Value);
            vehicleContract.KindOfRental = CTFunction.GetKindOfRentalType(cboKindRental.Text);
            vehicleContract.ContinuousStatus = chkContinueSts.Checked;
        }

        protected override void GetLeaseTerm(VehicleContract vehicleContract)
        {
            fpiLeaseTerm.Value = vehicleContract.LeaseTermMonth;
            cboKindRental.Text = GUIFunction.GetString(vehicleContract.KindOfRental);
            chkContinueSts.Checked = vehicleContract.ContinuousStatus;
        }

        protected override bool ValidateLeaseTerm()
        {
            //if (Convert.ToInt16(fpiLeaseTerm.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ระยะเวลาเช่าตามสัญญา");
            //    fpiLeaseTerm.Focus();
            //    return false;
            //}
            return true;
        }

        protected override void EnableLeasTerm(bool enable)
        {
            gpbLeaseTerm.Enabled = enable;
        }
        #endregion

        //============================== Event ==============================
        private void FrmVehicleContract_Load(object sender, EventArgs e)
        {
            setPermission(isReadonly);
            InitForm();
            initCombo();
            cboKindRental.DataSource = facadeContract.DatasourceKindOfRentalType;
            selectContract("V");
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
            uctContractCharge1.UnitChargeAmountByActualMonth();
        }

        private void cboKindRental_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}