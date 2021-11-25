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

namespace PTB.BTS.BTS2BizPacPresentation
{
    public abstract partial class FrmBizPacConnectBase : ChildFormBase, IMDIChildForm
    {
        #region - private -
        protected BTS2BizPacConnectFacade facadeBTS2BizPacConnect;
        protected Presentation.frmMain mdiParent;
        protected bool isReadonly = true;

        protected const string BP_TEST_REPORT = "Report Test";
        protected string fileName = "";
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
        public FrmBizPacConnectBase() : base()
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

        private bool validateForm()
        {
            bool result = false;

            if (!dtpDocDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ออกเอกสาร");
                dtpDocDate.Focus();
                return false;
            }
            if (dtpDocDate.Value.Date > DateTime.Today)
            {
                Message(MessageList.Error.E0011, "วันที่ออกเอกสาร", "วันที่ปัจจุบัน");
                dtpDocDate.Focus();
                return false;
            }

            DateTime backDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
            if (dtpDocDate.Value.Date < backDate)
            {
                Message(MessageList.Error.E0019, "วันที่ออกเอกสาร");
                dtpDocDate.Focus();
                return false;
            }

            //Allow user to input date detail in item : Woranai B. 2009/08/17
            if (dtpDateDetail.Visible)
            {
                if (!dtpDateDetail.Checked)
                {
                    Message(MessageList.Error.E0005, "วันที่ถ่ายโอน");
                    dtpDateDetail.Focus();
                    return false;
                }
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


        private void updateEvent()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

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

                        facadeBTS2BizPacConnect.ListBP.ConnectDate = dtpDocDate.Value; // A/C inputing Date

                        //Allow user to input date detail in item : Woranai B. 2009/08/17
                        facadeBTS2BizPacConnect.ListBP.DocDateDetail = dtpDateDetail.Value; // Transfer date

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

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (SqlException sqlex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Message(ex);
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                Message(ex);
            }
        }

        public override int MasterCount()
        {
            return facadeBTS2BizPacConnect.ListBP.Count;
        }


        private void selectAll(int select)
        {
            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                dtgBizPacConnect[1, i].Value = select.ToString();
            }
        }

        protected virtual void PrintReport()
        { 
        }

        #region IMDIChildForm Members


        //============================== Base event ==============================
        public void InitForm()
        {
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
            dtpDocDate.Value = DateTime.Today;
            dtpDocDate.Checked = false;
            dtpDateDetail.Value = DateTime.Today;
            dtpDateDetail.Checked = false;

            try
            {
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

        //============================== Event ==============================
        private void FrmBizPacConnectBase_Load(object sender, EventArgs e)
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

        private void dtpDocDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

