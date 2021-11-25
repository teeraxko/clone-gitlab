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
    public partial class FrmChargeRateByServiceStaffTypeEntry : EntryFormBase
    {
        private FrmChargeRateByServiceStaffType parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private ChargeRateByServiceStaffType objChargeRateByServiceStaffType;
        public ChargeRateByServiceStaffType ObjChargeRateByServiceStaffType
        {
            set
            {
                objChargeRateByServiceStaffType = value;
                if (value.ServiceStaffType.Type == ServiceStaffType.DUMMYCODE)
                {
                    cboServiceStaffType.Text = "";
                }
                else
                {
                    cboServiceStaffType.Text = value.ServiceStaffType.ToString();
                }

                if (value.Customer.Code == Customer.DUMMYCODE)
                {
                    cboCustomer.Text = "";
                }
                else
                {
                    cboCustomer.Text = value.Customer.ToString();
                }

                chkDriverOnly.Checked = value.DriverOnlyStatus;
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
                objChargeRateByServiceStaffType = new ChargeRateByServiceStaffType();
                if (cboCustomer.Text == "")
                {
                    objChargeRateByServiceStaffType.Customer = new Customer(Customer.DUMMYCODE);
                }
                else
                {
                    objChargeRateByServiceStaffType.Customer = (Customer)cboCustomer.SelectedItem;
                }

                if (cboServiceStaffType.Text == "")
                {
                    objChargeRateByServiceStaffType.ServiceStaffType = new ServiceStaffType(ServiceStaffType.DUMMYCODE);
                }
                else
                { 
                    objChargeRateByServiceStaffType.ServiceStaffType = (ServiceStaffType)cboServiceStaffType.SelectedItem;
                }

                objChargeRateByServiceStaffType.DriverOnlyStatus = chkDriverOnly.Checked;
                objChargeRateByServiceStaffType.ChargeRate.OTARate = Convert.ToDecimal(fpdOTARate.Value);
                objChargeRateByServiceStaffType.ChargeRate.OTBRate = Convert.ToDecimal(fpdOTBRate.Value);
                objChargeRateByServiceStaffType.ChargeRate.OTCRate = Convert.ToDecimal(fpdOTCRate.Value);
                objChargeRateByServiceStaffType.ChargeRate.AbsenceDeduction = Convert.ToInt16(fpiAbsence.Value);
                objChargeRateByServiceStaffType.ChargeRate.OneDayTripRateFar = Convert.ToInt16(fpiOneDayFar.Value);
                //objChargeRateByServiceStaffType.ChargeRate.OneDayTripRateNear = Convert.ToInt16(fpiOneDayNear.Value);
                objChargeRateByServiceStaffType.ChargeRate.OvernightTripRate = Convert.ToInt16(fpiOvernight.Value);
                objChargeRateByServiceStaffType.ChargeRate.TaxiRate = Convert.ToInt16(fpiTaxi.Value);
                objChargeRateByServiceStaffType.ChargeRate.MinLeaveDays = Convert.ToByte(fpiMinLeave.Value);
                objChargeRateByServiceStaffType.ChargeRate.MinHolidayAmount = Convert.ToDecimal(fpdMinHolidayAmount.Value);
                return objChargeRateByServiceStaffType;
            }
        }

        //============================== Constructor ==============================
        public FrmChargeRateByServiceStaffTypeEntry(FrmChargeRateByServiceStaffType value) : base()
        {
            InitializeComponent();
            setValue();
            parentForm = value;
            isReadOnly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffCharge");

            cboServiceStaffType.DataSource = parentForm.FacadeChargeRateByServiceStaffType.DataSourceServiceStaffType;
            cboCustomer.DataSource = parentForm.FacadeChargeRateByServiceStaffType.DataSourceCustomer;
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
            cboServiceStaffType.SelectedIndex = -1;
            cboCustomer.SelectedIndex = -1;
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
            //if (Convert.ToInt32(fpiAbsence.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "Absence deduction per day");
            //    fpiAbsence.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(fpiOneDayFar.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางไป - กลับ (ไกล)");
            //    fpiOneDayFar.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(fpiOneDayNear.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางไป - กลับ (ใกล้)");
            //    fpiOneDayNear.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(fpiOvernight.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่าเดินทางค้างคืน");
            //    fpiOvernight.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(fpiTaxi.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "ค่า Taxi");
            //    fpiTaxi.Focus();
            //    return false;
            //}
            //if (Convert.ToInt32(fpiMinLeave.Value) == 0)
            //{
            //    Message(MessageList.Error.E0002, "วันลาขั้นต่ำ");
            //    fpiMinLeave.Focus();
            //    return false;
            //}
            return true;
        }

        private bool validateKey()
        {
            //if (cboServiceStaffType.Text == "" & cboCustomer.Text == "")
            //{
            //    return true;
            //}
            if (cboServiceStaffType.Text == "")
            { 
                Message(MessageList.Error.E0005, "ประเภทพนักงาน");
                cboServiceStaffType.Focus();
                return false;
            }
            //if (cboCustomer.Text == "")
            //{
            //    Message(MessageList.Error.E0005, "ชื่อลูกค้า");
            //    cboCustomer.Focus();
            //    return false;
            //}
            return true;
        }
        #endregion

        //============================== Public Method ==============================
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            gpbStaffDetail.Enabled = true;
            cboServiceStaffType.Focus();
        }

        internal void InitEditAction(ChargeRateByServiceStaffType selectedChargeRateByServiceStaffType)
        {
            baseEDIT();
            clearForm();
            gpbStaffDetail.Enabled = false;
            ObjChargeRateByServiceStaffType = selectedChargeRateByServiceStaffType;

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
                if (validateKey() && validateForm())
                {
                    if (parentForm.AddRow(ObjChargeRateByServiceStaffType))
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
                    if (parentForm.UpdateRow(ObjChargeRateByServiceStaffType))
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
        private void FrmChargeRateByServiceStaffTypeEntry_Load(object sender, EventArgs e)
        {}

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

        private void cboServiceStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServiceStaffType.SelectedItem != null)
            {
                chkDriverOnly.Checked = (((ServiceStaffType)cboServiceStaffType.SelectedItem).APosition.PositionCode == "28");
            }
        }
    }
}

