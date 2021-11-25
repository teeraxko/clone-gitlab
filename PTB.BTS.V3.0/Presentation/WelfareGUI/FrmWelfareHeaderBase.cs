using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Presentation.PiGUI;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using System.Data.SqlClient;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp
{
    public partial class FrmWelfareHeaderBase : ChildFormBase
    {
        protected Presentation.frmMain mdiParent;
        protected Employee emp;

        public FrmWelfareHeaderBase()
            : base()
        {
            InitializeComponent();
            //VisibleDetailEmployee(emp != null);
        }

        #region remark


        protected bool isReadonly = true;

        protected virtual void LockControl()
        {
            btnInsert.Enabled = !this.isReadonly;
            //btnUpdate.Enabled = !this.isReadonly;
            btnDelete.Enabled = !this.isReadonly;
            insertToolStripMenuItem.Enabled = !this.isReadonly;
            deleteToolStripMenuItem.Enabled = !this.isReadonly;
        }



        private void BindEmployee(Employee value)
        {
            txtEmpNo.Text = value.EmployeeNo;
            txtEmpName.Text = value.EmployeeName;
            txtEmpSection.Text = value.ASection.AFullName.English;
            txtEmpPosition.Text = value.APosition.AName.English;
            txtPositionType.Text = value.APosition.APositionType.ADescription.English;

            //YearMonth age = facadeEmployeeAttendance.CalculateAge(value.BirthDate);
            int ageYear;
            int ageMonth;
            MonthYear.Diff(value.BirthDate, DateTime.Now.Date, out ageYear, out ageMonth);
            txtAgeYear.Text = ageYear.ToString();
            txtAgeMonth.Text = ageMonth.ToString();

            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
                System.IO.FileInfo[] files = dirInfo.GetFiles(value.EmployeeNo + ".*");
                if (files != null && files.Length == 1)
                {
                    //Old function use file always : woranai 2009/04/27
                    //pctEmployee.Image = System.Drawing.Image.FromFile(files[0].FullName);
                    pctEmployee.Load(files[0].FullName);
                }
                else
                {
                    pctEmployee.Image = null;
                }
                dirInfo = null;
                files = null;
            }
            catch
            {
                pctEmployee.Image = null;
            }
        }

        private void VisibleDetailEmployee(bool value)
        {
            if (!value) txtEmpNo.Text = string.Empty;
            txtEmpNo.Enabled = !value;
            txtEmpName.Visible = value;
            lblSection.Visible = value;
            txtEmpSection.Visible = value;
            lblPosition.Visible = value;
            txtEmpPosition.Visible = value;
            lblPositionType.Visible = value;
            txtPositionType.Visible = value;
            lblAge.Visible = value;
            txtAgeYear.Visible = value;
            lblAgeYear.Visible = value;
            txtAgeMonth.Visible = value;
            lblAgeMonth.Visible = value;
            pctEmployee.Visible = value;
            pnlDetail.Visible = value;
        }
        #endregion

        #region IMDIChildForm Members

        public virtual void RefreshForm()
        {
            FillDetail();
        }

        public virtual void InitForm()
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            VisibleDetailEmployee(false);

            MainMenuNewStatus = false;
            MainMenuRefreshStatus = false;
            mdiParent.EnableNewCommand(false);
            mdiParent.EnableRefreshCommand(false);

        }

        public void ExitForm()
        {
            this.Close();
        }

        public void PrintForm() { }
        #endregion

        public virtual void FillDetail()
        {
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableRefreshCommand(true);
        }

        private void txtEmpNo_DoubleClick(object sender, EventArgs e)
        {
            GetSelectEmployee();
        }

        private void GetSelectEmployee(string empCode)
        {
            emp = EmployeeFacade.GetEmployeeByEmpCode(empCode);
            if (emp != null)
            {
                BindEmployee(emp);
                FillDetail();
            }
            else
            {
                Mbox.ErrorMessage("ไม่พบรหัสพนักงาน");
            }
            VisibleDetailEmployee(emp != null);
        }
        private void GetSelectEmployee()
        {
            try
            {
                frmEmplist formEmplist = new frmEmplist();
                formEmplist.ShowDialog();
                if (formEmplist.Selected)
                {
                    emp = formEmplist.SelectedEmployee;
                }
                if (emp != null)
                {
                    BindEmployee(emp);
                    FillDetail();
                }
                VisibleDetailEmployee(emp != null);


            }
            catch (SqlException sqlex)
            {
                //show message error : woranai

                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                //show message error : woranai

                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }


        protected virtual void InsertData() { }
        protected virtual void UpdateData() { }
        protected virtual void DeleteData() { }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Trim().Length == 5)
            {
                GetSelectEmployee(txtEmpNo.Text.Trim());
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        protected void DisbleMenuBtn(int detailItemCount)
        {
            bool enableControl = detailItemCount > 0;
            updateToolStripMenuItem.Enabled = enableControl;
            deleteToolStripMenuItem.Enabled = enableControl;
            btnUpdate.Enabled = enableControl;
            btnDelete.Enabled = enableControl;
        }
    }
}