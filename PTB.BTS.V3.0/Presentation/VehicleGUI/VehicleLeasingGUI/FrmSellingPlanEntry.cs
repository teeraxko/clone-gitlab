using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;
using Facade.VehicleFacade.VehicleLeasingFacade;
using ictus.Common.Entity.General;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmSellingPlanEntry : Presentation.CommonGUI.EntryFormBase
    {
        #region Variable
        private FrmSellingPlan parentForm;
        private VehicleSellingPlanFacade facade;
        public VehicleSellingPlanFacade Facade
        {
            get { return facade; }
        }

        private VehicleSelling _vehicleSelling;
        private VehicleSelling VehicleSelling
        {
            get
            {
                _vehicleSelling.BV = Convert.ToDecimal(fpdActaulBV.Value);
                _vehicleSelling.BVDate = dtpBVDate.Value;
                _vehicleSelling.SellingPrice = Convert.ToDecimal(fpdSellingPrice.Text);
                _vehicleSelling.SellingDate = dtpSellingDate.Value;
                _vehicleSelling.Bidder = (Bidder)cboBidder.Tag;
                return _vehicleSelling;
            }
            set
            {
                _vehicleSelling = value;
                lblPlateNo.Text = value.Vehicle.PlateNumber;
                lblBrand.Text = value.Vehicle.AModel.ABrand.AName.English;
                lblModel.Text = value.Vehicle.AModel.AName.English;
                fpdActaulBV.Value = value.BV;

                if (value.BVDate.HasValue)
                {
                    dtpBVDate.Checked = true;
                    dtpBVDate.Value = value.BVDate.Value.Date;
                }
                else
                {
                    dtpBVDate.Checked = false;
                    dtpBVDate.Value = DateTime.Today;
                }

                if (value.SellingDate.HasValue)
                {
                    dtpSellingDate.Checked = true;
                    dtpSellingDate.Value = value.SellingDate.Value.Date;
                }
                else
                {
                    dtpSellingDate.Checked = false;
                    dtpSellingDate.Value = DateTime.Today;
                }

                fpdSellingPrice.Value = value.SellingPrice;

                if (value.Bidder != null)
                {
                    Bidder bidder = new Bidder();
                    bidder = facade.GetBidderByBidderCode(value.Bidder.BidderCode);
                    cboBidder.DataSource = facade.DataSourceBidder;
                    cboBidder.Text = bidder.BidderName.ToString();
                    cboBidder.Tag = bidder;
                }
            }
        } 
        #endregion

        #region Constructor
        public FrmSellingPlanEntry(FrmSellingPlan form)
            : base()
        {
            InitializeComponent();
            parentForm = form;
            facade = new VehicleSellingPlanFacade();
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleSellingPlan");
        }
        #endregion

        #region Private Method
        private void ClearForm()
        {
            lblPlateNo.Text = "";
            lblBrand.Text = "";
            lblModel.Text = "";
            dtpSellingDate.Value = DateTime.Today;
            dtpSellingDate.Checked = false;
            fpdActaulBV.Value = decimal.Zero;
            fpdSellingPrice.Value = decimal.Zero;
        }

        private bool ValidateForm()
        {
            if (Convert.ToDecimal(fpdActaulBV.Value) == decimal.Zero)
            {
                Message(SystemFramework.AppMessage.MessageList.Error.E0002, " Actual BV ");
                fpdActaulBV.Focus();
                return false;
            }
            else
            {
                if (!dtpBVDate.Checked)
                {
                    Message(SystemFramework.AppMessage.MessageList.Error.E0005, " BV Date ");
                    dtpBVDate.Focus();
                    return false;
                }
            }
            //=======================================
            if (Convert.ToDecimal(fpdSellingPrice.Value) == decimal.Zero)
            {
                Message(SystemFramework.AppMessage.MessageList.Error.E0002, " Selling Price ");
                fpdSellingPrice.Focus();
                return false;
            }
            else
            {
                if (!dtpSellingDate.Checked)
                {
                    Message(SystemFramework.AppMessage.MessageList.Error.E0005, " Selling Date ");
                    dtpSellingDate.Focus();
                    return false;
                }
                else
                {
                    //if (dtpSellingDate.Value.Date < DateTime.Today.Date)
                    //{
                    //    Message(SystemFramework.AppMessage.MessageList.Error.E0018, " Selling Date", "วันนี้");
                    //    dtpSellingDate.Focus();
                    //    return false;
                    //}
                }
                if (cboBidder.SelectedIndex == -1)
                {
                    Message(SystemFramework.AppMessage.MessageList.Error.E0005, " Bidder ");
                    cboBidder.Focus();
                    return false;
                }
            }

            return true;
        }

        private void EditEvent()
        {
            try
            {
                if (ValidateForm() && parentForm.EditRow(getVehicleSelling()))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }
        }

        private VehicleSelling getVehicleSelling()
        {
            VehicleSelling vehicleSelling = new VehicleSelling();
            vehicleSelling.BV = Convert.ToDecimal(fpdActaulBV.Value);
            vehicleSelling.BVDate = dtpBVDate.Value;
            vehicleSelling.SellingPrice = Convert.ToDecimal(fpdSellingPrice.Value);
            vehicleSelling.SellingDate = dtpSellingDate.Value;
            vehicleSelling.Bidder = (Bidder)cboBidder.SelectedValue;

            return vehicleSelling;
        }

        private void initForm(VehicleSelling entity)
        {
            if (action == ActionType.ADD)
            {
                cboBidder.DataSource = facade.DataSourceBidder;
                cboBidder.SelectedIndex = -1;
            }
            else
            {
                if (entity.Bidder == null)
                {
                    cboBidder.DataSource = facade.DataSourceBidder;
                    cboBidder.SelectedIndex = -1;
                }
            }

            fpdActaulBV.MaxValue = 9999999.99;
            fpdActaulBV.MinValue = 0;
            fpdSellingPrice.MaxValue = 9999999.99;
            fpdSellingPrice.MinValue = 0;
        } 
        #endregion

        #region Public Method
        public void InitEdit(VehicleSelling entity)
        {
            ClearForm();
            baseEDIT();
            VehicleSelling = entity;
            initForm(entity);
            btnOK.Enabled = !UserProfile.IsReadOnly("miVehicle", "miVehicleSellingPlan");
        } 
        #endregion        

        #region Form Event
        private void FrmVehicleSellingPlanEntry_Load(object sender, EventArgs e)
        { }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}