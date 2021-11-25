using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using Entity.VehicleEntities;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using Facade.VehicleFacade;

namespace Presentation.VehicleGUI
{
    public partial class FrmBidderEntry : EntryFormBase
    {
        private FrmBidder parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private Bidder objBidder;
        public Bidder ObjBidder
        {
            set
            {
                objBidder = value;
                txtBidderCode.Text = value.BidderCode;
                txtBidderName.Text = value.BidderName;
                txtAdderss.Text = value.Address;
                txtTel.Text = value.TelNo;
                txtRemark.Text = value.Remark;
            }
            get
            {
                objBidder = new Bidder();
                objBidder.BidderCode = txtBidderCode.Text;
                objBidder.BidderName = txtBidderName.Text;
                objBidder.Address = txtAdderss.Text;
                objBidder.TelNo = txtTel.Text;
                objBidder.Remark = txtRemark.Text;
                return objBidder;
            }
        }

        #region Constructor
        public FrmBidderEntry(FrmBidder value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleBidder");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleBidder");
        }

        #endregion

        #region Private Method
        private void enableKeyField(bool enable)
        {
            gpbHeader.Enabled = enable;
        }

        private void clearForm()
        {
            txtBidderCode.Text = "";
            txtBidderName.Text = "";
            txtAdderss.Text = "";
            txtTel.Text = "";
            txtRemark.Text = "";
        }

        private bool validateForm()
        {
            if (txtBidderCode.Text == "")
            {
                Message(MessageList.Error.E0002, "รหัส");
                txtBidderCode.Focus();
                return false;
            }
            if (txtBidderName.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อผู้ประมูล");
                txtBidderName.Focus();
                return false;
            }
            return true;
        }

        private void addEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.AddRow(ObjBidder))
                        InitAddAction();
                    else
                        txtBidderCode.Focus();
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
                    parentForm.UpdateRow(ObjBidder);
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
        #endregion

        #region Public Method
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            enableKeyField(true);
        }

        internal void InitEditAction(Bidder bidder)
        {
            baseEDIT();
            clearForm();
            ObjBidder = bidder;
            enableKeyField(false);

            if (isReadOnly)
            {
                btnOK.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void frmBidderEntry_Load(object sender, EventArgs e)
        {}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        #endregion
    }
}