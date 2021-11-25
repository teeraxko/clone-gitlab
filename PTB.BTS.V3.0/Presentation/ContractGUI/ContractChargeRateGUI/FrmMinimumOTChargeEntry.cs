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

namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    public partial class FrmMinimumOTChargeEntry : EntryFormBase
    {
        private FrmMinimumOTCharge parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private MinimumOTCharge objMinimumOTCharge;
        public MinimumOTCharge ObjMinimumOTCharge
        {
            set
            {
                objMinimumOTCharge = value;
                chkStatus.Checked = value.DriverOnlyStatus;
                fpiHour.Value = value.MinOTHour;
                fpdAmount.Value = value.MinOTAmount;               
            }
            get
            {
                objMinimumOTCharge = new MinimumOTCharge();
                objMinimumOTCharge.DriverOnlyStatus = chkStatus.Checked;
                objMinimumOTCharge.MinOTHour = Convert.ToInt16(fpiHour.Value);
                objMinimumOTCharge.MinOTAmount = Convert.ToDecimal(fpdAmount.Value);
                return objMinimumOTCharge;
            }
        }

        //============================== Constructor ==============================
        public FrmMinimumOTChargeEntry(FrmMinimumOTCharge value) : base()
        {
            InitializeComponent();
            setValue();
            parentForm = value;
            isReadOnly = UserProfile.IsReadOnly("miContract", "miContractSettingMinimumOTCharge");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingMinimumOTCharge");
        }

        //============================== Private Method ==============================
        private void setValue()
        {
            fpdAmount.MinValue = 0.00;
            fpdAmount.MaxValue = 999.99;
        }

        private void clearForm()
        {
            fpiHour.Value = 0;
            fpdAmount.Value = 0.00;
        }

        private bool validateForm()
        {
            if (int.Parse(fpiHour.Text) == 0)
            {
                Message(MessageList.Error.E0002, "จำนวนชั่วโมงขั้นต่ำ");
                fpiHour.Focus();
                return false;
            }
            if (decimal.Parse(fpdAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "ค่าบริการขั้นต่ำ");
                fpdAmount.Focus();
                return false;
            }
            return true;
        }

        //============================== Public Method ==============================
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            chkStatus.Enabled = true;
        }

        internal void InitEditAction(MinimumOTCharge selectedMinimumOTCharge)
        {
            baseEDIT();
            clearForm();
            chkStatus.Enabled = false;
            ObjMinimumOTCharge = selectedMinimumOTCharge;

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
                if (validateForm())
                {
                    if (parentForm.AddRow(ObjMinimumOTCharge))
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
                    if (parentForm.UpdateRow(ObjMinimumOTCharge))
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
        private void FrmMinimumOTChargeEntry_Load(object sender, EventArgs e)
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
    }
}