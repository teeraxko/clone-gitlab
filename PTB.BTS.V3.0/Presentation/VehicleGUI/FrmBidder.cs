using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Presentation.CommonGUI;
using Facade.PiFacade;
using Facade.VehicleFacade;
using Entity.VehicleEntities;

namespace Presentation.VehicleGUI
{
    public partial class FrmBidder : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmBidderEntry frmEntry;
        #endregion      

        #region Property
        //private BidderFacade facadeBidder;
        //public BidderFacade FacadeBidder
        //{
        //    get { return facadeBidder; }
        //}

        private int SelectedRow
        {
            get { return dtgBidder.CurrentRow.Index; }
        }

        private Bidder selectedBidder
        {
            get
            {
                if (dtgBidder.CurrentRow != null)
                {
                    return (Bidder)dtgBidder.CurrentRow.Tag;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Constructor
        public FrmBidder()
            : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleBidder");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleBidder");
        }

        #endregion

        #region Private Method
        private void newObject()
        {
            frmEntry = new FrmBidderEntry(this);
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            dtgBidder.RowCount = 0;
            enableAmend(false);
        }

        private void bindBidder(int row, Bidder value)
        {
            dtgBidder.Rows[row].Tag = value;
            dtgBidder["colCode", row].Value = value.BidderCode;
            dtgBidder["colName", row].Value = value.BidderName;
            dtgBidder["colAddress", row].Value = value.Address;
            dtgBidder["colTelNo", row].Value = value.TelNo;
            dtgBidder["colRemark", row].Value = value.Remark;
        }

        private void bindForm(List<Bidder> list)
        {
            dtgBidder.Rows.Clear();

            if (list.Count > 0)
            {
                foreach (Bidder entity in list)
                {
                    dtgBidder.RowCount++;
                    bindBidder(dtgBidder.RowCount - 1, entity);
                }
            }
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmBidderEntry(this);
                frmEntry.InitAddAction();
                frmEntry.ShowDialog();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void updateEvent()
        {
            try
            {
                frmEntry = new FrmBidderEntry(this);
                frmEntry.InitEditAction(selectedBidder);
                frmEntry.ShowDialog();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    using (BidderFacade facade = new BidderFacade())
                    {
                        facade.DeleteBidder(selectedBidder);                        
                    }

                    Message(MessageList.Information.I0001);
                    RefreshForm();
                    mdiParent.RefreshMasterCount();
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }
        #endregion

        #region Public Method
        public override int MasterCount()
        {
            if (dtgBidder.Rows != null)
            {
                return dtgBidder.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleBidder");
        }

        public void InitForm()
        {
            newObject();
            clearForm();
            RefreshForm();

            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
        }

        public void RefreshForm()
        {
            try
            {
                List<Bidder> list = null;

                using (BidderFacade facade = new BidderFacade())
                {
                    list = facade.GetAllBidder();
                }

                if (list.Count > 0)
                {
                    enableAmend(true);
                    bindForm(list);
                }
                else
                {
                    enableAmend(false);
                    dtgBidder.Rows.Clear();
                }

                mdiParent.RefreshMasterCount();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }

            if (isReadonly)
            {
                mniAdd.Enabled = false;
                btnAdd.Enabled = false;
                enableAmend(false);
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        public bool AddRow(Bidder value)
        {
            using (BidderFacade facade = new BidderFacade())
            {
                if (facade.ChkDupBidder(value))
                {
                    facade.InsertBidder(value);
                    dtgBidder.RowCount++;
                    bindBidder(dtgBidder.RowCount - 1, value);

                    enableAmend(true);
                    mdiParent.RefreshMasterCount();
                    return true;
                }
                else
                {
                    Message(MessageList.Error.E0003);
                    return false;
                }
            }

            
        }

        public void UpdateRow(Bidder value)
        {
            using (BidderFacade facade = new BidderFacade())
            {
                facade.UpdateBidder(value);
            }

            bindBidder(SelectedRow, value);
        } 
        #endregion

        #region Form Event
        private void FrmBidder_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void dtgBidder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        } 
        #endregion
    }
}