using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using Entity.VehicleEntities.Leasing;

namespace Presentation.VehicleGUI.ProfitLostGUI
{
    public partial class FrmVehicleSellingPlanEntry : Presentation.CommonGUI.EntryFormBase
    {
        private FrmVehicleSellingPlan parentForm;

        private VehicleSellingPlan _vehicleSellingPlan;
        private VehicleSellingPlan VehicleSellingPlan
        {
            get
            {
                _vehicleSellingPlan.EstimateSelling = Convert.ToDecimal(fpdSellingPrice.Value);
                _vehicleSellingPlan.SellingDate = dtpSellingDate.Value;
                _vehicleSellingPlan.BVDate = dtpBVDate.Value;
                return _vehicleSellingPlan;
            }
            set 
            {
                _vehicleSellingPlan = value;
                lblPlateNo.Text = value.VehicleInfo.PlateNumber;
                lblBrand.Text = value.VehicleInfo.AModel.ABrand.AName.English;
                lblModel.Text = value.VehicleInfo.AModel.AName.English;

                if (value.BVDate.HasValue)
                {
                    dtpBVDate.Checked = true;
                    dtpBVDate.Value = value.BVDate.Value;
                }
                else
                {
                    dtpBVDate.Checked = false;
                    dtpBVDate.Value = DateTime.Today;
                }

                if (value.SellingDate.HasValue)
                {
                    dtpSellingDate.Checked = true;
                    dtpSellingDate.Value = value.SellingDate.Value;
                }
                else
                {
                    dtpSellingDate.Checked = false;
                    dtpSellingDate.Value = DateTime.Today;
                }

                fpdSellingPrice.Value = value.EstimateSelling;
            }
        }
	

        //============================== Constructor ==============================
        public FrmVehicleSellingPlanEntry(FrmVehicleSellingPlan form)
        {
            InitializeComponent();
            parentForm = form;
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleSellingPlan");
        }

        //============================== Private Method ==============================
        private void ClearForm()
        {
            lblPlateNo.Text = "";
            lblBrand.Text = "";
            lblModel.Text = "";
            dtpSellingDate.Value = DateTime.Today;
            dtpSellingDate.Checked = false;
            fpdSellingPrice.Value = decimal.Zero;
            fpdSellingPrice.MaxValue = 9999999;
            fpdSellingPrice.MinValue = 0;
        }

        private bool ValidateForm()
        {
            if (!dtpBVDate.Checked)
            {
                Message(SystemFramework.AppMessage.MessageList.Error.E0005, " BV Date ");
                dtpBVDate.Focus();
                return false;
            }
            if (!dtpSellingDate.Checked)
            {
                Message(SystemFramework.AppMessage.MessageList.Error.E0005, " Selling Date ");
                dtpSellingDate.Focus();
                return false;
            }
            return true;
        }

        private void EditEvent()
        {
            try
            {
                if (ValidateForm() && parentForm.EditRow(VehicleSellingPlan))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        //============================== Public Method ==============================
        internal void InitEdit(VehicleSellingPlan entity)
        {
            ClearForm();
            VehicleSellingPlan = entity;
            btnOK.Enabled = !UserProfile.IsReadOnly("miVehicle", "miVehicleSellingPlan");
        }

        //============================== Event ==============================
        private void FrmVehicleSellingPlanEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}