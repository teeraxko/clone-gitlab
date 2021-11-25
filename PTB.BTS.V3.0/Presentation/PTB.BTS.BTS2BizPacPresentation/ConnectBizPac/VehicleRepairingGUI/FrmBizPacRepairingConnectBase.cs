using System;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using PTB.BTS.BTS2BizPacFacade;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity.General;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using Entity.VehicleEntities;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public abstract partial class FrmBizPacRepairingConnectBase : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
    {
        #region - private -
        protected BTS2BizPacConnectFacade facadeBTS2BizPacConnect;
        protected Presentation.frmMain mdiParent;
        protected bool isReadonly = true;

        protected const string BP_TEST_REPORT = "Report Test";
        protected string fileName = "";
        #endregion

        #region Abstract
        public abstract string Title { get; }
        public abstract string DocNoColumnName { get; }
        public abstract string PaidToColumnName { get; }
        public abstract string RemarkColumnName { get; }
        public abstract string AmountColumnName { get; }
        public abstract string TaxInvoiceNoColumnName { get; }
        public abstract string TaxInvoiceDateColumnName { get; }
        #endregion

        #region Constructor
        public FrmBizPacRepairingConnectBase()
            : base()
        {
            InitializeComponent();
            initializeForm();
        } 
        #endregion

        public override int MasterCount()
        {
            return facadeBTS2BizPacConnect.ListBP.Count;
        }

        protected virtual void PrintReport()
        {
        } 

        #region Private Method
        private void visibleForm(bool visible)
        {
            dtgBizPacConnect.Visible = visible;
            gpbSelect.Visible = visible;
            btnClose.Visible = visible;
            btnConnect.Visible = visible;
        }

        private void initializeForm()
        {
            this.title = Title;
            this.colDocNo.HeaderText = DocNoColumnName;
            this.colPaidTo.HeaderText = PaidToColumnName;
            this.colRemark.HeaderText = RemarkColumnName;
            this.colAmount.HeaderText = AmountColumnName;
            this.colTaxInvoiceNo.HeaderText = TaxInvoiceNoColumnName;
            this.colTaxInvoiceDate.HeaderText = TaxInvoiceDateColumnName;
        }

        private void bindBizPacConnect(int row, IBTS2BizPacHeader value)
        {
            dtgBizPacConnect[0, row].Value = value.EntityKey;
            dtgBizPacConnect[1, row].Value = value.BTSCheck.ToString();
            dtgBizPacConnect[2, row].Value = value.DocNo;
            dtgBizPacConnect[3, row].Value = value.PaidTo;
            dtgBizPacConnect[4, row].Value = value.BTSRemark;
            dtgBizPacConnect[5, row].Value = value.BTSAmount;
            dtgBizPacConnect[6, row].Value = value.AdditionalInfo;

            if (value.AdditionalDate == NullConstant.DATETIME.ToShortDateString())
            {
                dtgBizPacConnect[7, row].Value = "";
            }
            else
            {
                dtgBizPacConnect[7, row].Value = value.AdditionalDate;
            }

            Garage garage = ((RepairingBase)value).Garage;
            if (garage != null)
            {
                dtgBizPacConnect[8, row].Value = garage.Code;
            }

            dtgBizPacConnect[9, row].Value = value.BTSCheck.ToString();

            if (value.BTSCheck == 1)
            { 
                decimal tempAmount = decimal.Parse(lblTotalAmount.Text) + value.BTSAmount;
                lblTotalAmount.Text = tempAmount.ToString("#,###,###.00");
            }
        }

        private void bindForm()
        {
            dtgBizPacConnect.RowCount = 0;
            lblTotalAmount.Text = decimal.Zero.ToString();

            if (facadeBTS2BizPacConnect.ListBP != null)
            {
                for (int i = 0; i < facadeBTS2BizPacConnect.ListBP.Count; i++)
                {
                    dtgBizPacConnect.RowCount++;
                    bindBizPacConnect(i, facadeBTS2BizPacConnect.ListBP[i]);
                }
            }
        }

        private void updateEvent()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (validateForm())
                {
                    if (Message(MessageList.Question.Q0014) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
                        {
                            //value 0 = false, 1 = true;
                            if (dtgBizPacConnect[1, i].Value.ToString() == "0")
                            {
                                facadeBTS2BizPacConnect.ListBP.Remove(dtgBizPacConnect[0, i].Value.ToString());
                            }
                        }

                        facadeBTS2BizPacConnect.ListBP.ConnectDate = dtpConnectDate.Value;
                        if (facadeBTS2BizPacConnect.UpdateBizPacConnect(ref fileName))
                        {
                            PrintReport();
                            InitForm();
                        }
                        else
                        {
                            Message(MessageList.Error.E0014, "Connect ข้อมูลได้");
                            btnClose.Focus();
                        }
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (SqlException sqlex)
            {
                this.Cursor = Cursors.Default;
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                this.Cursor = Cursors.Default;
                Message(ex);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Message(ex);
            }
        }


        private void selectAll(int select)
        {
            Garage garage = new Garage();
            if (cboGarage.Text.Trim() != "")
            {
                garage = (Garage)cboGarage.SelectedItem;
            }
            else
            {
                garage = null;
            }

            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                if (garage == null)
                {
                    dtgBizPacConnect[1, i].Value = select.ToString();
                }
                else
                {
                    if (dtgBizPacConnect[8, i].Value.ToString() == garage.Code)
                    {
                        if (select == 1)
                        {
                            dtgBizPacConnect[1, i].Value = dtgBizPacConnect[9, i].Value;
                        }
                        else
                        {
                            dtgBizPacConnect[1, i].Value = select.ToString();
                        }
                    }
                }
            }

            garage = null;
        }

        private bool validateForm()
        {
            bool result = false;

            if (!dtpConnectDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ connect");
                dtpConnectDate.Focus();
                return false;
            }

            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                if (dtgBizPacConnect[1, i].Value.ToString() == "1")
                {
                    result = true;
                }
            }

            if (!result)
            {
                Message(MessageList.Error.E0005, "ข้อมูลที่จะ connect");
                btnClose.Focus();
            }

            return result;
        }

        private string TotalSelectedAmount()
        {
            decimal totalAmount = decimal.Zero;

            foreach (DataGridViewRow row in dtgBizPacConnect.Rows)
            {
                if (row.Cells[colStatus.Index].Value.ToString() == "1")
                {
                    totalAmount += Convert.ToDecimal(row.Cells[colAmount.Index].Value);
                }
            }

            return totalAmount.ToString("#,###,###.00");
        }
        #endregion

        #region IMDIChildForm Members

        //============================== Base event ==============================
        public void InitForm()
        {
            try
            {
                mdiParent.EnableRefreshCommand(true);
                MainMenuRefreshStatus = true;

                cboGarage.DataSource = facadeBTS2BizPacConnect.DataSourceGarage;
                dtpConnectDate.Value = DateTime.Now;
                dtpConnectDate.Checked = false;

                if (facadeBTS2BizPacConnect.DisplayBizPacConnect())
                {
                    bindForm();
                    btnConnect.Enabled = true;
                }
                else
                {
                    dtgBizPacConnect.RowCount = 0;
                    btnConnect.Enabled = false;
                }

                mdiParent.RefreshMasterCount();

                if (isReadonly)
                {
                    btnConnect.Enabled = false;
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

            if (isReadonly)
            {
                btnConnect.Enabled = false;
            }
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region Form Event
        private void FrmBizPacRepairingConnectBase_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
            btnConnect.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            selectAll(1);
        }

        private void btnDeSelectAll_Click(object sender, EventArgs e)
        {
            selectAll(0);
        }

        private void dtgBizPacConnect_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == colStatus.Index)
            {
                //decimal amount = Convert.ToDecimal(dtgBizPacConnect[colAmount.Index, e.RowIndex].Value);
                //decimal tempAmount = decimal.Parse(lblTotalAmount.Text);

                //if (dtgBizPacConnect[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                //{
                //    amount = tempAmount - amount;
                //}
                //else
                //{
                //    amount = tempAmount + amount;
                //}

                //lblTotalAmount.Text = amount.ToString("#,###,###.00");

                lblTotalAmount.Text = TotalSelectedAmount();
            }
        } 
        #endregion

        private void dtgBizPacConnect_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgBizPacConnect.IsCurrentCellDirty)
            {
                dtgBizPacConnect.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}

