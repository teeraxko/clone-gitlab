using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using PTB.BTS.BTS2BizPacFacade;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity.General;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using Entity.ContractEntities;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public abstract partial class FrmBizPacChargeConnectBase : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
    {
        #region Variable
        protected BTS2BizPacConnectFacade facadeBTS2BizPacConnect;
        protected Presentation.frmMain mdiParent;
        protected bool isReadonly = true;

        public static string BP_TEST_REPORT = "Report Test";
        protected string fileName = "";
        #endregion

        #region Abstract Function
        public abstract string Title { get; }
        public abstract string DocNoColumnName { get; }
        public abstract string PaidToColumnName { get; }
        public abstract string RemarkColumnName { get; }
        public abstract string AmountColumnName { get; }
        public abstract string TaxInvoiceNoColumnName { get; }
        public abstract string TaxInvoiceDateColumnName { get; }
        #endregion

        #region Constructor
        public FrmBizPacChargeConnectBase()
            : base()
        {
            InitializeComponent();
            initializeForm();
        } 
        #endregion

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

            Customer customer = ((ContractBase)value).ACustomer;
            if (customer != null)
            {
                dtgBizPacConnect[8, row].Value = customer.Code;
            }

            dtgBizPacConnect[9, row].Value = value.BTSCheck.ToString();
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
                    if (Message(MessageList.Question.Q0014) == DialogResult.Yes)
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

                        DateTime currentDay = DateTime.Now;
                        DateTime firstDayOfMonth = new DateTime(currentDay.Year, currentDay.Month, 1);
                        DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                        
                        int currentMinusFirstDay = Convert.ToInt32((currentDay - firstDayOfMonth).TotalDays);
                        int lastMinusCurrent = Convert.ToInt32((lastDayOfMonth - currentDay).TotalDays);

                        if (currentMinusFirstDay < lastMinusCurrent)
                        {
                            facadeBTS2BizPacConnect.ListBP.ConnectDate = firstDayOfMonth;
                        }
                        else
                        {
                            facadeBTS2BizPacConnect.ListBP.ConnectDate = lastDayOfMonth;
                        }

                        if (facadeBTS2BizPacConnect.UpdateBizPacConnect(ref fileName))
                        {
                            PrintReport();
                            InitForm();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            Message(MessageList.Error.E0014, "Connect ข้อมูลได้");
                            btnClose.Focus();
                        }
                    }
                }
                else
                {
                    Message(MessageList.Error.E0005, "ข้อมูลที่จะ connect");
                    btnClose.Focus();

                }

                this.Cursor = Cursors.Default;
            }
            catch (SqlException sqlex)
            {
                this.Cursor = Cursors.Default;
                Message(sqlex);
                InitForm();
            }
            catch (AppExceptionBase ex)
            {
                this.Cursor = Cursors.Default;
                Message(ex);
                InitForm();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Message(ex);
                InitForm();
            }
        }

        private void selectAll(int select)
        {
            Customer customer = new Customer();
            if (cboCustomer.Text.Trim() != "")
            {
                customer = (Customer)cboCustomer.SelectedItem;
            }
            else
            {
                customer = null;
            }

            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                if (customer == null)
                {
                    dtgBizPacConnect[1, i].Value = select.ToString();
                }
                else
                {
                    if (dtgBizPacConnect[8, i].Value.ToString() == customer.Code)
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

            customer = null;
        }
        #endregion

        #region Public Method
        public override int MasterCount()
        {
            return facadeBTS2BizPacConnect.ListBP.Count;
        }

        #endregion

        #region Protected Method
        protected virtual void PrintReport()
        {
        }

        protected virtual bool ValidateConnect()
        {
            if (facadeBTS2BizPacConnect.ListBP != null)
            {
                foreach (ContractBase item in facadeBTS2BizPacConnect.ListBP)
                {
                    if (item.ACustomer.BizPacCode.Trim() == string.Empty)
                    {
                        Message(MessageList.Error.E0013, "ถ่ายโอนข้อมูลได้", "ไม่พบรหัสลูกค้าสำหรับ BizPac ของบริษัท " + item.ACustomer.AName.English);
                        return false;
                    }
                }
            }

            return true;
        } 
        #endregion

        #region IMDIChildForm Members
        public void InitForm()
        {
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                cboCustomer.DataSource = facadeBTS2BizPacConnect.DataSourceCustomer;

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
        private void FrmBizPacChargeConnectBase_Load(object sender, EventArgs e)
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
            if (ValidateConnect())
            {
                updateEvent();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            selectAll(1);
        }

        private void btnDeSelectAll_Click(object sender, EventArgs e)
        {
            selectAll(0);
        } 
        #endregion
    }
}

