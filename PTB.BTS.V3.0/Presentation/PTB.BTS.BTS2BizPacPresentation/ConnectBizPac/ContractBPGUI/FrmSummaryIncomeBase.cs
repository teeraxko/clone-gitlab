using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using PTB.BTS.BTS2BizPacFacade;
using System.Data.SqlClient;
using SystemFramework.AppException;
using SystemFramework.AppMessage;
using Entity.ContractEntities;

namespace Presentation.PTB.BTS.BTS2BizPacPresentation.ConnectBizPac.ContractBPGUI
{
    public partial class FrmSummaryIncomeBase : ChildFormBase, IMDIChildForm
    {
        #region - private -
        protected BTS2BizPacConnectFacade facadeBTS2BizPacConnect;
        protected Presentation.frmMain mdiParent;
        protected bool isReadonly = true;
        protected DateTime forDate;

        public static string BP_RERUN_REPORT = "Report Rerun";
        #endregion

        protected virtual DateTime GetDate
        {
            get { return dtpDateFrom.Value; }
        }

        //============================== Constructor ==============================
        public FrmSummaryIncomeBase() : base()
        {
            InitializeComponent();
        }

        //============================== Private Method ==============================
        private void rerun()
        {
            try
            {
                if (!dtpDateFrom.Checked)
                {
                    Message(MessageList.Error.E0005, "วันที่ถ่ายโอนข้อมูล");
                    dtpDateFrom.Focus();
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (facadeBTS2BizPacConnect.BizPacRerun((Customer)cboCustomer.SelectedItem, GetDate))
                    {
                        PrintReport(dtpDateFrom.Value);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        Message(MessageList.Error.E0014, " Rerun ข้อมูลได้");
                        btnClose.Focus();
                    }
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

        protected virtual void PrintReport(DateTime connectDate)
        {
        }

        //============================== Base event ==============================
        public void InitForm()
        {
            try
            {
                cboCustomer.DataSource = facadeBTS2BizPacConnect.DataSourceCustomer;
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
                btnRerun.Enabled = false;
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

        //============================== Event ==============================
        private void FrmSummaryIncomeBase_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnRerun_Click(object sender, EventArgs e)
        {
            rerun();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSummaryIncomeBase_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}