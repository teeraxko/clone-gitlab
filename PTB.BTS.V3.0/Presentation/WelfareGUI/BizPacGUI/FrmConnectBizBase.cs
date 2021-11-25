using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.GUI;
using PTB.PIS.Welfare.ReportApp.GUI.ConnectBizPacGUI;
using PresentationBase.CommonGUIBase;
using SystemFramework.AppConfig;
using Presentation.CommonGUI;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmConnectBizBase : ChildFormBase, IMDIChildFormGUI
    {

        protected FrmConnectBizPac reportForm;

        protected List<string> ListOfRefNo;
        protected string reportFileName;
        protected string mainTableName;
        protected string csvFileName;

        protected int itemCount = 0;
        protected bool isReadonly = true;

        protected int selectItemCount = 0;
        protected decimal itemsAmount = 0M;

        public FrmConnectBizBase()
            : base()
        {
            InitializeComponent();
            bool isHasItems = this.itemCount > 0;
            this.pnlBtn.Visible = isHasItems;
            this.pnlGrid.Visible = isHasItems;
        }
        protected virtual void RetiveData() { }
        protected virtual void PaintData() { }
        protected virtual void SelectAll() { }
        protected virtual void DeselectAll() { }
        protected virtual void Submit() { }
        protected virtual void Cancel() { }
        protected virtual void GetSelectItemDetail() { }

        protected void DispSelectItemsDetail()
        {
            lblItemCount.Text = this.selectItemCount.ToString();
            lblAmount.Text = this.itemsAmount.ToString("N2");
        }

        protected virtual void SetReport()
        {
            this.reportForm = new FrmConnectBizPac(reportFileName, mainTableName, ListOfRefNo, csvFileName);
            if (this.ListOfRefNo.Count > 0)
                this.reportForm.MdiParent = this.MdiParent;
            this.reportForm.Show();

        }




        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Application.DoEvents();

            RetiveData();
            bool isHasItems = this.itemCount > 0;
            this.pnlBtn.Visible = isHasItems;
            this.pnlGrid.Visible = isHasItems;
            PaintData();
            SelectAll();
            GetSelectItemDetail();
            DispSelectItemsDetail();

            this.Cursor = System.Windows.Forms.Cursors.Default;

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
            GetSelectItemDetail();
            DispSelectItemsDetail();

        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            DeselectAll();
            GetSelectItemDetail();
            DispSelectItemsDetail();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetSelectItemDetail();
            if (Mbox.Confirm(string.Format("จำนวน {0} รายการ", this.selectItemCount.ToString())) == DialogResult.OK)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Application.DoEvents();

                // Kriangkrai A. 21/2/2019 add try/catch
                try
                {
                    Submit();
                    RetiveData();
                    PaintData();
                    SetReport();

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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
            this.Close();
        }

        private void FrmConnectBizBase_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnOK.Enabled = !this.isReadonly;
        }


        #region IMDIChildFormGUI Members

        public void ExitForm()
        {
            this.Close();
            //throw new Exception("The method or operation is not implemented.");
        }

        public void InitForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void RefreshForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void btnDispSelectItem_Click(object sender, EventArgs e)
        {
            GetSelectItemDetail();
            DispSelectItemsDetail();
        }
    }
}