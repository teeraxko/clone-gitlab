using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.Facade;
using ictus.Common.Entity.Health;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using ictus.PIS.PI.Entity;
using Presentation.PiGUI;
using System.Data.SqlClient;
using ictus.PIS.Welfare.Entity.CommonEntities;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI
{
    public partial class FrmMedicalAidEntByHospital : Form
    {

        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;

        private decimal EmployeeAmount;
        decimal TempAmount = 0;
        decimal EmployeeLimit = 20000;
        int EmployeeNo = 08046;
        DateTime SelectDate = DateTime.Now;
        List<MedicalAidApplication> apps;
        private Employee tempemp;
        private MedicalAidApplication app;
        private DataFormStatus status;
        string EmployeeDisplay = "ตนเอง";

        private Control errorControl = null;

        private FrmMedicalAidEntByHospital()
        {
            InitializeComponent();
            txtActualAmount.MaxValue = 999999.99;
            txtActualAmount.MinValue = 0.00;
            txtAppliedAmount.MaxValue = Convert.ToDouble(txtActualAmount.Value);
            txtAppliedAmount.MinValue = 0.00;
            fpdInsuranceAmt.MaxValue = 999999.99;
            fpdInsuranceAmt.MinValue = 0.00;
        }

        public FrmMedicalAidEntByHospital(MedicalAidApplication app, DataFormStatus status, bool isReadOnly)
            : this()
        {
            this.app = app;
            this.status = status;
            this.btnOK.Enabled = !isReadOnly;
            dtpAdmitDate.MaxDate = app.CreateDate;
        }


        private void InitForm()
        {
            // combo type
            cmbType.DataSource = MedicalAidFacade.GetListOfAllMedicalAidType();
            cmbType.DisplayMember = "ThaiName";
            cmbType.ValueMember = "Code";

            // combo disease
            cmbDisease.DataSource = MedicalAidFacade.GetListOfAllDisease();
            cmbDisease.DisplayMember = "Name";
            cmbDisease.ValueMember = "Name";

        }

        private void FrmMedicalAidEntByHospital_Load(object sender, EventArgs e)
        {
            InitHeader();
            InitForm();
            PaintData();
            LockControl();
        }
        private void InitHeader()
        {
            if (status == DataFormStatus.Insert)
                this.Text = "เพิ่มข้อมูลค่ารักษาพยาบาลของโรงพยาบาล";
            else
                this.Text = "แก้ไขข้อมูลค่ารักษาพยาบาลของโรงพยาบาล";
        }

        private void PaintData()
        {
            //init new data
            if (status == DataFormStatus.Insert)
            {
                //this.app.CreateDate = DateTime.Now.Date;
                this.app.ApplicationType = (MedicalAidType)cmbType.Items[0];
                MedicalAidFor mf = new MedicalAidFor();
                mf.Code = "0";
                this.app.ApplicationFor = mf;
                this.app.ADisease = (Disease)cmbDisease.Items[0];
                this.app.AdmitDate = dtpAdmitDate.MaxDate;
                this.app.ActualAmount = 0M;
                this.app.AppliedAmount = 0M;
                this.app.InsuranceAmount = 0M;
                this.app.Remark = string.Empty;
                this.app.OtherPerson = new Person();
                this.app.AttendanceLetterStatus = 'Y';
                this.app.CertificateStatus = 'Y';
                txtSumEmployee.Text = string.Empty;
                this.app.AEmployee = new Employee();
            }
            lblRefDoc.Text = this.app.InvoiceNo;
            lblHospitalName.Text = this.app.AHospital.ThaiName;
            txtEmpNo.Text = this.app.AEmployee.EmployeeNo;
            lblEmpName.Text = this.app.AEmployee.EmployeeName;
            cmbType.SelectedValue = this.app.ApplicationType.Code;
            cmbDisease.SelectedValue = this.app.ADisease.Name;
            dtpAdmitDate.Value = this.app.AdmitDate;
            txtActualAmount.Value = this.app.ActualAmount;
            txtAppliedAmount.Value = this.app.AppliedAmount;
            fpdInsuranceAmt.Value = this.app.InsuranceAmount.Value;
            txtRemark.Text = this.app.Remark;
            chkCrt.Checked = this.app.CertificateStatus == 'Y';
            TempAmount = this.app.AppliedAmount;
            txtEmpNo.Focus();
        }

        private void LockControl()
        {
            bool lockUpdate = !(status == DataFormStatus.Update);
            cmbType.Enabled = lockUpdate;
            //cmbDisease.Enabled = lockUpdate;
            dtpAdmitDate.Enabled = lockUpdate;
            txtEmpNo.Enabled = lockUpdate;
        }


        private Employee GetSelectEmployee(string empCode)
        {
            return EmployeeFacade.GetEmployeeByEmpCode(empCode);

        }

        private Employee GetSelectEmployee()
        {
            Employee emp = null;
            try
            {

                frmEmplist formEmplist = new frmEmplist();
                formEmplist.ShowDialog();
                if (formEmplist.Selected)
                {
                    emp = formEmplist.SelectedEmployee;
                }


            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            return emp;
        }

        private void RefeshData()
        {
            //this.app.CreateDate = dtpCreateDate.Value.Date;
            this.app.ApplicationType = (MedicalAidType)cmbType.SelectedItem;
            //this.app.ApplicationFor = (MedicalAidFor)cmbFor.SelectedItem;
            //this.app.ADisease = (Disease)cmbDisease.SelectedItem;

            Disease disease = new Disease();
            disease.Name = cmbDisease.Text;
            this.app.ADisease = disease;

            //this.app.AHospital = (Hospital)cmbHospital.SelectedItem;
            this.app.AEmployee = this.GetSelectEmployee(txtEmpNo.Text.Trim());
            this.app.AdmitDate = dtpAdmitDate.Value.Date;
            this.app.ActualAmount = Convert.ToDecimal(txtActualAmount.Value);
            this.app.AppliedAmount = Convert.ToDecimal(txtAppliedAmount.Value);
            this.app.InsuranceAmount = Convert.ToDecimal(fpdInsuranceAmt.Value);
            this.app.Remark = txtRemark.Text.Trim();
            //this.app.InvoiceNo = txtInvoiceNo.Text.Trim();
            this.app.CertificateStatus = chkCrt.Checked ? 'Y' : 'N';
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Trim().Length == 5)
            {
                Employee emp = GetSelectEmployee(txtEmpNo.Text.Trim());  
                RefeshEmployeeName(emp);
                tempemp = emp;
                refreshEmployeeAmount(tempemp, SelectDate);
            }

        }

        private void refreshEmployeeAmount(Employee emp, DateTime date)
        {
            decimal sumEmployee = 0M;
            int year = DateTime.Now.Year;
            apps = MedicalAidFacade.GetOfApplicationByEmp(emp);
            year = getFiscalYear(date);

            DateTime startDate = new DateTime(year, 4, 1);
            DateTime endDate = new DateTime(year + 1, 3, 31); //Next year
            List<MedicalAidApplication> filterapp = apps.FindAll(i => i.CreateDate >= startDate && i.CreateDate <= endDate);
            foreach (MedicalAidApplication app in filterapp)
            {
                if (app.ApplicationFor.ThaiName == EmployeeDisplay)
                {
                    sumEmployee += app.AppliedAmount;
                }
            }
            this.EmployeeAmount = sumEmployee;
            txtSumEmployee.Text = sumEmployee.ToString("N2");
        }

        private void dtpAdmitDate_ValueChanged(object sender, EventArgs e)
        {
            if (SelectDate != dtpAdmitDate.Value)
            {
                SelectDate = dtpAdmitDate.Value;
                if (txtEmpNo.Text.Trim().Length == 5)
                {
                    refreshEmployeeAmount(tempemp, SelectDate);
                }
            }

        }

        private int getFiscalYear(DateTime date)
        {
            int year = DateTime.Now.Year;
            if (date.Month > 0 && date.Month < 4)
            {
                year = date.Year - 1;
            }
            else
            {
                year = date.Year;
            }

            return year;
        }

        private void RefeshEmployeeName(Employee emp)
        {
            if (emp != null)
            {
                lblEmpName.Text = emp.EmployeeName;
                txtEmpNo.Text = emp.EmployeeNo;
            }
            else
            {
                lblEmpName.Text = string.Empty;
            }
        }

        private void txtEmpNo_DoubleClick(object sender, EventArgs e)
        {
            Employee emp = GetSelectEmployee();
            RefeshEmployeeName(emp);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmpNo_Validated(object sender, EventArgs e)
        {
            Employee emp = GetSelectEmployee(txtEmpNo.Text.Trim());
            RefeshEmployeeName(emp);
        }

        private void ControlText_Enter(object sender, EventArgs e)
        {
            TextBoxBase txt = (TextBoxBase)sender;
            txt.SelectionStart = 0;
            txt.SelectionLength = txt.Text.Length;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = true;
            string EmployeeLimitmessage = "วงเงินเกิน";
            RefeshData();

            //if (ValidateData() && ConfirmSave())
            if (ValidateData())
            {
                SaveData();

                if (status == DataFormStatus.Update)
                {
                    EmployeeAmount = EmployeeAmount - TempAmount;
                }

                if ((Convert.ToInt32(this.app.AEmployee.EmployeeNo.Substring(0, 1)) < 8) && (Convert.ToInt32(this.app.AEmployee.EmployeeNo) >= EmployeeNo))
                {
                    if (EmployeeAmount + app.AppliedAmount > EmployeeLimit)
                    {
                        result = MessageBox.Show(EmployeeLimitmessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK;
                    }
                }
                if (status == DataFormStatus.Insert)
                {
                    InitForNextInsert();
                }
                else
                {                    
                    this.Close();
                }
            }
            else
                if (errorControl != null) errorControl.Focus();
        }

        private Boolean ValidateData()
        {
            bool isValid = true;
            errorControl = null;
            if (isValid && this.app.AEmployee == null)
            {
                isValid = false;
                errorControl = txtEmpNo;
                Mbox.ErrorMessage("ข้อมูลพนักงานไม่ถูกต้อง");
            }
            if (isValid && (this.app.ADisease.Name.Trim().Length == 0))
            {
                isValid = false;
                errorControl = cmbDisease;
                Mbox.ErrorMessage("กรุณาเลือกข้อมูลโรค");
            }
            if (isValid && this.app.ActualAmount <= 0)
            {
                isValid = false;
                errorControl = txtActualAmount;
                Mbox.ErrorMessage("ค่ารักษาที่จ่ายจริงต้องมากกว่า 0");
            }
            //if (isValid && this.app.AppliedAmount <= 0)
            //{
            //    isValid = false;
            //    errorControl = txtAppliedAmount;
            //    Mbox.ErrorMessage("ค่ารักษาตามสิทธิ์ต้องมากกว่า 0");
            //}
            return isValid;
        }

        /// <summary>
        /// Validate staff who hire date after 1 Aug 2008
        /// </summary>
        /// <returns></returns>
        private bool ConfirmSave()
        {
            bool result = true;
            string message = "พนักงานที่ระบุ เป็นพนักงานใหม่เข้าทำงานตั้งแต่วันที่ 1 สิงหาคม 2551 \n\nคุณยืนยันที่จะการบันทึกข้อมูลหรือไม่ ?";

            if (this.app.AEmployee.HireDate.Date >= Entity.CommonEntity.Age.MedicalAidDate)
            {
                result = (MessageBox.Show(message, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK);
            }

            return result;
        }

        private void InitForNextInsert()
        {
            MedicalAidApplication app = new MedicalAidApplication();
            app = this.app;
            this.app = app;

            cmbDisease.DataSource = MedicalAidFacade.GetListOfAllDisease();
            cmbDisease.DisplayMember = "Name";
            cmbDisease.ValueMember = "Name";


            PaintData();
        }

        private void SaveData()
        {

            try
            {
                switch (status)
                {
                    case DataFormStatus.Idle:
                        break;
                    case DataFormStatus.Insert:
                        MedicalAidFacade.UpdateMedicalAidApplication(app, FacadeBase.Status.Insert);
                        break;
                    case DataFormStatus.Update:
                        MedicalAidFacade.UpdateMedicalAidApplication(app, FacadeBase.Status.Update);
                        break;
                    case DataFormStatus.Delete:
                        break;
                    default:
                        break;
                }
                if (SaveDataCompleted != null)
                    SaveDataCompleted();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtActualAmount_ValueChanged(object sender, EventArgs e)
        {
            txtAppliedAmount.MaxValue = Convert.ToDouble(txtActualAmount.Value);
        }

        private void FrmMedicalAidEntByHospital_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }

        private void txtActualAmount_Validated(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 2)
            {
                txtAppliedAmount.Value = 0.00;
            }
            else
            {
                txtAppliedAmount.Value = txtActualAmount.Value;
            }
        }

        private void cmbDisease_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) SendKeys.Send("{TAB}");
        }
    }
}