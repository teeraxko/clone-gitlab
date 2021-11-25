using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using PresentationBase.CommonGUIBase;
using Presentation.CommonGUI;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmCancelBizBase : ChildFormBase, IMDIChildFormGUI
    {

        protected List<ConnectBizPacDetail> details;
        protected bool isReadonly = true;
        protected int selectRecordCount;

        protected DateTime fromDateTime
        {
            get
            {
                int fYear = dtpDateFrom.Value.Year;
                int fMonth = dtpDateFrom.Value.Month;
                int fDay = dtpDateFrom.Value.Day;
                DateTime result = new DateTime(fYear, fMonth, fDay, 0, 0, 0, 0);
                return result;
            }
        }

        protected DateTime toDateTime
        {
            get
            {
                int tYear = dtpDateTo.Value.Year;
                int tfMonth = dtpDateTo.Value.Month;
                int tDay = dtpDateTo.Value.Day;
                DateTime result = new DateTime(tYear, tfMonth, tDay, 23, 59, 59, 999);
                return result;
            }
        }

        public FrmCancelBizBase()
        {
            InitializeComponent();
        }

        protected virtual void RetiveData() { }
        protected virtual void PaintData()
        {
            if (this.details != null)
            {
                int rowIndex = 0;
                grdData.Rows.Clear();
                foreach (ConnectBizPacDetail detail in this.details)
                {
                    grdData.RowCount++;
                    grdData.Rows[rowIndex].Tag = detail;
                    grdData.Rows[rowIndex].Cells["colChk"].Value = true;
                    grdData.Rows[rowIndex].Cells["colRefNo"].Value = detail.RefNo;
                    grdData.Rows[rowIndex].Cells["colConnectDate"].Value = detail.ConnectDateTime.ToString("dd/MM/yyyy HH.mm.ss ");
                    rowIndex++;
                }
            }

        }

        protected virtual void SelectAll()
        {
            foreach (DataGridViewRow row in grdData.Rows)
            {
                row.Cells["colChk"].Value = true;
            }
        }

        protected virtual void DeselectAll()
        {
            foreach (DataGridViewRow row in grdData.Rows)
            {
                row.Cells["colChk"].Value = false;
            }
        }


        protected virtual void Submit()
        {
            RetiveData();
            PaintData();
        }
        protected virtual void Cancel()
        {
            this.Close();
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Application.DoEvents();

            RetiveData();
            PaintData();

            this.Cursor = System.Windows.Forms.Cursors.Default;

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            DeselectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CountSelectRecords();
            if (Mbox.Confirm(string.Format("จำนวน {0} รายการ", this.selectRecordCount.ToString())) == DialogResult.OK)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Application.DoEvents();
                Submit();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
            this.Close();
        }

        protected List<ConnectBizPacDetail> GetSelectData()
        {
            List<ConnectBizPacDetail> result = new List<ConnectBizPacDetail>();
            foreach (DataGridViewRow row in grdData.Rows)
            {
                if ((bool)row.Cells["colChk"].Value)
                {
                    result.Add((ConnectBizPacDetail)row.Tag);
                }
            }
            return result;
        }

        protected virtual void CountSelectRecords()
        {
            this.selectRecordCount = this.GetSelectData().Count;
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            bool enableDate = rbtnDate.Checked;
            bool enableRefNo = rbtnRefNo.Checked;

            dtpDateFrom.Enabled = enableDate;
            dtpDateTo.Enabled = enableDate;
            txtRefNo.Enabled = enableRefNo;
        }


        #region IMDIChildFormGUI Members

        public void ExitForm()
        {
            this.Close();
        }

        public void InitForm()
        {
            // throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm()
        {
            //  throw new Exception("The method or operation is not implemented.");
        }

        public void RefreshForm()
        {
            //   throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void FrmCancelBizBase_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnOK.Enabled = !this.isReadonly;
        }
    }
}