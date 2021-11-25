using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using PTB.BTS.BTS2BizPacEntity;

using PTB.BTS.BTS2BizPacFacade;

using Presentation.CommonGUI;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;
using ictus.Common.Entity.General;
using Entity.AttendanceEntities;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public abstract partial class FrmBizPacCancelBase : ChildFormBase, IMDIChildForm
    {
        #region - private -
        protected BTS2BizPacConnectFacade facadeBTS2BizPacConnect;
        protected Presentation.frmMain mdiParent;
        protected bool isReadonly = true;
        protected const string BP_CANCEL_FILE_NAME = "Report Cancel";
        #endregion

        #region - abstract -
        public abstract string Title { get; }
        public abstract string DocNoColumnName { get; }
        public abstract string PaidToColumnName { get; }
        public abstract string RemarkColumnName { get; }
        public abstract string AmountColumnName { get; }
        public abstract string TaxInvoiceNoColumnName { get; }
        public abstract string TaxInvoiceDateColumnName { get; }
        #endregion

        //============================== Constructor ==============================
        public FrmBizPacCancelBase()
            : base()
        {
            InitializeComponent();
            initializeForm();
        }

        //============================== Private Method ==============================
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
            dtgBizPacConnect[1, row].Value = "0";
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

            dtgBizPacConnect[8, row].Value = GetSelectCheck(value);
        }

        private void bindForm()
        {
            dtgBizPacConnect.RowCount = 0;

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
                bool result = false;

                for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
                {
                    if (dtgBizPacConnect[1, i].Value.ToString() == "1")
                    {
                        result = true;
                    }
                }

                if (result)
                {
                    if (Message(MessageList.Question.Q0013) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
                        {
                            //value 0 = false, 1 = true;
                            if (dtgBizPacConnect[1, i].Value.ToString() == "0")
                            {
                                facadeBTS2BizPacConnect.ListBP.Remove(dtgBizPacConnect[0, i].Value.ToString());
                            }
                        }

                        if (facadeBTS2BizPacConnect.UpdateBizPacCancel())
                        {
                            this.Cursor = Cursors.Default;
                            Message(MessageList.Information.I0001);
                            InitForm();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            Message(MessageList.Error.E0014, "Cancel ข้อมูลได้");
                            btnClose.Focus();
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    Message(MessageList.Error.E0005, "ข้อมูลที่จะ Cancel");
                    btnClose.Focus();
                }
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

        public override int MasterCount()
        {
            return facadeBTS2BizPacConnect.ListBP.Count;
        }

        //============================== Protected Method ==============================
        protected virtual void PrintReport()
        {
        }

        protected virtual string GetSelectCheck(IBTS2BizPacHeader value)
        {
            return string.Empty;
        }

        protected virtual void SelectAll(int select)
        {
            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                dtgBizPacConnect[1, i].Value = select.ToString();
            }
        }

        protected virtual void visibleForm(bool visible)
        {
            dtgBizPacConnect.Visible = visible;
            btnCancel.Visible = visible;
            btnClose.Visible = visible;
            btnDeSelectAll.Visible = visible;
            btnSelectAll.Visible = visible;
        }

        #region IMDIChildForm Members


        //============================== Base event ==============================
        public void InitForm()
        {
            gpbSelectData.Enabled = true;
            visibleForm(false);
            dtpDateTo.Value = DateTime.Now;
            dtpDateFrom.Value = DateTime.Now;

            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
        }

        public void RefreshForm()
        {
            try
            {
                if (dtpDateFrom.Value > dtpDateTo.Value)
                {
                    Message(MessageList.Error.E0011, "วันเริ่มต้น", "วันสิ้นสุด");
                    dtpDateFrom.Focus();
                }
                else
                {
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;

                    gpbSelectData.Enabled = false;
                    visibleForm(true);

                    TimePeriod period = new TimePeriod();
                    period.From = new DateTime(dtpDateFrom.Value.Year, dtpDateFrom.Value.Month, dtpDateFrom.Value.Day, 0, 0, 0);
                    period.To = new DateTime(dtpDateTo.Value.Year, dtpDateTo.Value.Month, dtpDateTo.Value.Day, 23, 59, 59);

                    this.Cursor = Cursors.WaitCursor;                    

                    if (facadeBTS2BizPacConnect.DisplayBizPacCancel(period))
                    {
                        bindForm();
                        btnCancel.Enabled = true;
                    }
                    else
                    {
                        dtgBizPacConnect.RowCount = 0;
                        btnCancel.Enabled = false;
                    }

                    this.Cursor = Cursors.Default; 
                }

                mdiParent.RefreshMasterCount();

                if (isReadonly)
                {
                    btnCancel.Enabled = false;
                }
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

            if (isReadonly)
            {
                btnCancel.Enabled = false;
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        //============================== Event ==============================
        private void FrmBizPacCancelBase_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
            btnCancel.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll(1);
        }

        private void btnDeSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll(0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}

