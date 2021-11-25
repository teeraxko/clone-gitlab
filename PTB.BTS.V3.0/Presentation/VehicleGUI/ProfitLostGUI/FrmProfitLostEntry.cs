using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entity.VehicleEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using Entity.VehicleEntities.Leasing;
using System.Data.SqlClient;
using Entity.ContractEntities;
using SystemFramework.AppException;

namespace Presentation.VehicleGUI.ProfitLostGUI
{
    public partial class FrmProfitLostEntry : Presentation.CommonGUI.EntryFormBase
    {
        private FrmProfitLost parentForm;
        private bool isReadOnly = true;

        //============================== Constructor ==============================
        public FrmProfitLostEntry(FrmProfitLost value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleProfitLost");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleProfitLost");
        }

        //============================== Property ==============================
        private ProfitAndLost profitAndLost;
        public ProfitAndLost ProfitAndLost
        {
            get 
            {
                profitAndLost = new ProfitAndLost();
                profitAndLost.Vehicle = (Vehicle)txtPlatePrefix.Tag;
                profitAndLost.Rate = Convert.ToDecimal(fpdRate.Value);
                profitAndLost.Pmt = Convert.ToDecimal(fpdPmt.Value);
                profitAndLost.FV = Convert.ToDecimal(fpdFV.Value);
                profitAndLost.Contract = Convert.ToDecimal(fpiLeaseTerm.Value);
                profitAndLost.RentalAge = Convert.ToDecimal(fpiRentalAge.Value);
                profitAndLost.Rental = Convert.ToDecimal(fpdRentalPrice.Value);
                profitAndLost.Sale = Convert.ToDecimal(fpdSellPrice.Value);
                profitAndLost.Price = Convert.ToDecimal(fpdBodyPrice.Value);
                return profitAndLost;
            }
            set 
            {
                profitAndLost = value;
                VehicleInfo vehicleInfo = parentForm.FacadePL.GetVehicleInfo(profitAndLost.Vehicle.PlatePrefix, profitAndLost.Vehicle.PlateRunningNo);
                setVehicle(vehicleInfo);
                setVehiclePL(vehicleInfo);

                fpdRate.Value = profitAndLost.Rate;
                fpdPmt.Value = profitAndLost.Pmt;
                fpdFV.Value = profitAndLost.FV;
                fpiLeaseTerm.Value = profitAndLost.Contract;
                fpiRentalAge.Value = profitAndLost.RentalAge;
                fpdRentalPrice.Value = profitAndLost.Rental;
                fpdSellPrice.Value = profitAndLost.Sale;
                fpdBodyPrice.Value = profitAndLost.Price;
            }
        }

        //============================== Private Method ==============================
        private void setValue()
        {
            fpdBodyPrice.MaxValue = 99999999.99;
            fpdBodyPrice.MinValue = 0.00;
            fpdRentalPrice.MaxValue = 999999.99;
            fpdRentalPrice.MinValue = 0.00;
            fpdSellPrice.MaxValue = 9999999.99;
            fpdSellPrice.MinValue = 0.00;
            fpdRate.MaxValue = 99.99;
            fpdRate.MinValue = 0.00;
            fpdPmt.MaxValue = 999999.99;
            fpdPmt.MinValue = -999999.99;
            fpdFV.MaxValue = 9999999.99;
            fpdFV.MinValue = -9999999.99;
        }

        private void clearForm()
        {
            txtPlatePrefix.Tag = null;
            txtPlatePrefix.Text = "";
            fpiPlateRunningNo.Text = "";
            lblPlateNo.Text = "";
            lblPlatePrefix.Text = "";
            lblBrand.Text = "";
            lblModel.Text = "";
            fpiLeaseTerm.Value = 0;
            fpiRemain.Value = 0;
            fpiRentalAge.Value = 0;
            fpdBodyPrice.Value = decimal.Zero;
            fpdRentalPrice.Value = decimal.Zero;
            fpdSellPrice.Value = decimal.Zero;
            fpdRate.Value = decimal.Zero;
            fpdPmt.Value = decimal.Zero;
            fpdFV.Value = decimal.Zero;
        }

        private void formVehicleList()
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();

            dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
            dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
            dialogVehicleList.ShowDialog();

            if (dialogVehicleList.Selected)
            {
                VehicleInfo vehicleInfo = parentForm.FacadePL.GetVehicleInfo(dialogVehicleList.SelectedVehicle.PlatePrefix, dialogVehicleList.SelectedVehicle.PlateRunningNo);
                setVehicle(vehicleInfo);
                setVehiclePL(vehicleInfo);
            }
        }
      
        private void setVehicle(VehicleInfo value)
        {
            txtPlatePrefix.Tag = value;
            txtPlatePrefix.Text = value.PlatePrefix;
            fpiPlateRunningNo.Text = value.PlateRunningNo;

            if (value.AModel != null)
            {
                lblModel.Text = value.AModel.AName.English;

                if (value.AModel.ABrand != null)
                {
                    lblBrand.Text = value.AModel.ABrand.AName.English;
                }
                else
                {
                    lblBrand.Text = "";
                }
            }
            else
            {
                lblModel.Text = "";
                lblBrand.Text = "";
            }
        }

        private void setVehiclePL(VehicleInfo value)
        {
            fpdBodyPrice.Value = value.VehicleAmount;

            try
            {
                VehicleAssignment vehicleAssign = parentForm.FacadePL.GetCurrentAssignment(value.VehicleNo);

                if (vehicleAssign != null && vehicleAssign.AContract.AContractStatus.Code != "1" && vehicleAssign.AContract.AContractStatus.Code != "3")
                {
                    fpiLeaseTerm.Value = ((VehicleContract)vehicleAssign.AContract).LeaseTermMonth;

                    //RentalPrice
                    if (vehicleAssign.AContract.AContractChargeList.Count > 0)
                    {
                        fpdRentalPrice.Value = vehicleAssign.AContract.AContractChargeList[0].UnitChargeAmount;
                    }
                    else
                    {
                        fpdRentalPrice.Value = decimal.Zero;
                    }

                    //Rental Age
                    Entity.CommonEntity.Age age = parentForm.FacadePL.CalculateAge(vehicleAssign.AContract.APeriod.From, vehicleAssign.AContract.APeriod.To);
                    int month = age.Month;
                    if (age.Year > 0)
                    {
                        month += (age.Year * 12);
                    }
                    fpiRentalAge.Value = month;
                }
                else
                {
                    fpiLeaseTerm.Value = 0;
                    fpdRentalPrice.Value = decimal.Zero;
                    fpiRentalAge.Value = 0;
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
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
                VehicleInfo vehicleInfo = parentForm.FacadePL.GetVehicleInfo(txtPlatePrefix.Text.Trim(), fpiPlateRunningNo.Text.Trim());
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
            if (parentForm.ListPL.Contain((VehicleInfo)txtPlatePrefix.Tag))
            {
                Message(MessageList.Error.E0013, "เพิ่มรถคันนี้ได้", "มีรถคันนี้ในรายการแล้ว");
                txtPlatePrefix.Focus();
                return false;
            }
            return true;
        }

        //============================== Public Method ==============================
        public void InitAddAction()
        {
            baseADD();
            clearForm();
            setValue();
            gpbVehicleDetail.Enabled = true;
            txtPlatePrefix.Focus();
        }

        public void InitEditAction(ProfitAndLost value)
        {
            baseEDIT();
            clearForm();
            setValue();
            ProfitAndLost = value;
            gpbVehicleDetail.Enabled = false;
            fpdRate.Focus();

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
                if (validatePlateVehicle() && validateDupVehicle())
                {
                    if (parentForm.AddRow(ProfitAndLost))
                    {
                        clearForm();
                        txtPlatePrefix.Focus();
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
                if (parentForm.UpdateRow(ProfitAndLost))
                {
                    this.Close();
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
        private void FrmProfitLostEntry_Load(object sender, EventArgs e)
        {

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
                if (validatePlateVehicle())
                {
                    setVehiclePL((VehicleInfo)txtPlatePrefix.Tag);
                }
            }
        }

        private void fpiPlateRunningNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (validatePlateVehicle())
                {
                    setVehiclePL((VehicleInfo)txtPlatePrefix.Tag);
                }
            }
        }

        private void fpiPlateRunningNo_DoubleClick(object sender, EventArgs e)
        {
            formVehicleList();
        }

        private void fpiLeaseTerm_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(fpiLeaseTerm.Value) > Convert.ToInt16(fpiRentalAge.Value))
            {
                fpiRemain.Value = Convert.ToInt16(fpiLeaseTerm.Value) - Convert.ToInt16(fpiRentalAge.Value);
            }
            else
            {
                fpiRemain.Value = 0;
            }
        }

        private void fpiRentalAge_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(fpiLeaseTerm.Value) > Convert.ToInt16(fpiRentalAge.Value))
            {
                fpiRemain.Value = Convert.ToInt16(fpiLeaseTerm.Value) - Convert.ToInt16(fpiRentalAge.Value);
            }
            else
            {
                fpiRemain.Value = 0;
            }
        }
    }
}