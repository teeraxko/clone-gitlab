using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using PTB.PIS.Welfare.Facade;
using ictus.Common.Entity.Health;
using ictus.Common.Entity;
using ictus.PIS.Welfare.Entity.CommonEntities;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI
{
    public partial class FrmMedicalAidEntByEmp : Form
    {
        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;

        private MedicalAidApplication app;
        private DataFormStatus status;
        private decimal EmployeeAmount;
        private decimal FamilyAmount;

        private Control errorControl = null;

        private List<Person> spouse;
        private List<Person> children;

        string EmployeeDisplay = "ตนเอง";

        decimal EmployeeLimit = 20000;
        decimal FamilyLimit = 10000;

        int EmployeeNo = 08046;

        private FrmMedicalAidEntByEmp()
        {
            InitializeComponent();
            txtActualAmount.MaxValue = 999999.99;
            txtActualAmount.MinValue = 0.00;
            txtAppliedAmount.MaxValue = Convert.ToDouble(txtActualAmount.Value);
            txtAppliedAmount.MinValue = 0.00;
            fpdInsuranceAmt.MaxValue = 999999.99;
            fpdInsuranceAmt.MinValue = 0.00;
        }

        public FrmMedicalAidEntByEmp(MedicalAidApplication app, DataFormStatus status, bool isReadOnly, decimal EmpAmount, decimal FamAmount)
            : this()
        {
            this.app = app;
            this.status = status;
            this.btnOK.Enabled = !isReadOnly;
            this.EmployeeAmount = EmpAmount;
            this.FamilyAmount = FamAmount;
        }

        private void InitForm()
        {
            //list of spouse;
            this.spouse = EmployeeFacade.GetSpouse(this.app.AEmployee);

            //list of children
            this.children = EmployeeFacade.GetChildren(this.app.AEmployee);

            // combo type
            cmbType.DataSource = MedicalAidFacade.GetListOfAllMedicalAidType();
            cmbType.DisplayMember = "ThaiName";
            cmbType.ValueMember = "Code";

            // combo for
            cmbFor.DataSource = MedicalAidFacade.GetListOfAllMedicalAidFor();
            cmbFor.DisplayMember = "ThaiName";
            cmbFor.ValueMember = "Code";
            //List<MedicalAidFor> mfor = MedicalAidFacade.GetListOfAllMedicalAidFor();
            ////remove exist item from combo for person
            //if (this.children.Count == 0) mfor.RemoveAt(2);
            //if (this.spouse.Count == 0) mfor.RemoveAt(1);
            //cmbFor.DataSource = mfor;
            //cmbFor.DisplayMember = "ThaiName";
            //cmbFor.ValueMember = "Code";

            // combo disease
            cmbDisease.DataSource = MedicalAidFacade.GetListOfAllDisease();
            cmbDisease.DisplayMember = "Name";
            cmbDisease.ValueMember = "Name";

            // combo hospital
            cmbHospital.DataSource = MedicalAidFacade.GetListOfAllHospital();
            cmbHospital.DisplayMember = "ThaiName";
            cmbHospital.ValueMember = "Code";
        }

        private void PaintData()
        {
            //init new data
            if (status == DataFormStatus.Insert)
            {
                this.app.CreateDate = DateTime.Now.Date;
                this.app.ApplicationType = (MedicalAidType)cmbType.Items[0];
                this.app.ApplicationFor = (MedicalAidFor)cmbFor.Items[0];
                this.app.ADisease = (Disease)cmbDisease.Items[0];
                this.app.AHospital = (Hospital)cmbHospital.Items[0];
                this.app.AdmitDate = DateTime.Now.Date;
                this.app.NoContractHospitalName = string.Empty;
                this.app.ActualAmount = 0M;
                this.app.AppliedAmount = 0M;
                this.app.InsuranceAmount = 0M;
                this.app.Remark = string.Empty;
                this.app.OtherPerson = new Person();
                this.app.AttendanceLetterStatus = 'N';
                this.app.CertificateStatus = 'Y';
            }

            dtpCreateDate.Value = this.app.CreateDate;
            cmbType.SelectedValue = this.app.ApplicationType.Code;
            cmbFor.SelectedValue = this.app.ApplicationFor.Code;
            cmbDisease.SelectedValue = this.app.ADisease.Name;
            cmbHospital.SelectedValue = this.app.AHospital.Code;
            dtpAdmitDate.Value = this.app.AdmitDate;
            txtHospital.Text = this.app.NoContractHospitalName.Trim();
            txtActualAmount.Value = this.app.ActualAmount;
            txtAppliedAmount.Value = this.app.AppliedAmount;
            fpdInsuranceAmt.Value = this.app.InsuranceAmount.Value;
            txtRemark.Text = this.app.Remark;

            chkCrt.Checked = this.app.CertificateStatus == 'Y';

            cmbOtherPerson.Text = this.app.OtherPerson.FullName;

            dtpCreateDate.Focus();
        }

        private void LockControl()
        {
            bool lockUpdate = !(status == DataFormStatus.Update);

            dtpCreateDate.Enabled = lockUpdate;
            cmbType.Enabled = lockUpdate;
            cmbFor.Enabled = lockUpdate;
            //cmbDisease.Enabled = lockUpdate;
            cmbHospital.Enabled = lockUpdate;
            dtpAdmitDate.Enabled = lockUpdate;
            cmbOtherPerson.Enabled = lockUpdate;
            cmbOtherPerson.Enabled = cmbOtherPerson.Enabled && cmbOtherPerson.DataSource != null;
        }

        private void RefeshData()
        {
            this.app.CreateDate = dtpCreateDate.Value.Date;
            this.app.ApplicationType = (MedicalAidType)cmbType.SelectedItem;
            this.app.ApplicationFor = (MedicalAidFor)cmbFor.SelectedItem;
            Disease disease = new Disease();
            disease.Name = cmbDisease.Text;
            this.app.ADisease = disease;

            this.app.AHospital = (Hospital)cmbHospital.SelectedItem;
            this.app.AdmitDate = dtpAdmitDate.Value.Date;
            this.app.ActualAmount = Convert.ToDecimal(txtActualAmount.Value);
            this.app.AppliedAmount = Convert.ToDecimal(txtAppliedAmount.Value);
            this.app.InsuranceAmount = Convert.ToDecimal(fpdInsuranceAmt.Value);
            this.app.Remark = txtRemark.Text.Trim();
            this.app.CertificateStatus = chkCrt.Checked ? 'Y' : 'N';
            this.app.OtherPerson = (Person)cmbOtherPerson.SelectedItem == null ? new Person() : (Person)cmbOtherPerson.SelectedItem;
            this.app.NoContractHospitalName = ((Hospital)cmbHospital.SelectedItem).Code == "ZZZZZZ" ? txtHospital.Text : string.Empty;
        }

        private void FrmMedicalAidEntByEmp_Load(object sender, EventArgs e)
        {
            InitHeader();
            InitForm();
            PaintData();
            LockControl();
        }

        private void InitHeader()
        {
            if (status == DataFormStatus.Insert)
                this.Text = "เพิ่มข้อมูลค่ารักษาพยาบาลของพนักงาน";
            else
                this.Text = "แก้ไขข้อมูลค่ารักษาพยาบาลของพนักงาน";
        }

        private void cmbFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChildDetail();
        }

        private void ShowChildDetail()
        {
            cmbOtherPerson.DataSource = null;
            switch (((MedicalAidFor)cmbFor.SelectedItem).Code)
            {
                case "1":
                    cmbOtherPerson.DisplayMember = "FullName";
                    cmbOtherPerson.DataSource = this.spouse;
                    break;
                case "2":
                    cmbOtherPerson.DisplayMember = "FullName";
                    cmbOtherPerson.DataSource = this.children;
                    break;
                default:
                    cmbOtherPerson.DataSource = null;
                    break;
            }
            cmbOtherPerson.Enabled = cmbOtherPerson.DataSource != null;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = true;
            string EmployeeLimitmessage = "วงเงินเกิน";
            string FamilyLimitmessage = "วงเงินเกิน";

            RefeshData();

            //if (ValidateData() && ConfirmSave())
            if (ValidateData())
            {
                SaveData();

                if ((Convert.ToInt32(this.app.AEmployee.EmployeeNo.Substring(0, 1)) < 8) && (Convert.ToInt32(this.app.AEmployee.EmployeeNo) >= EmployeeNo))
                {
                    if (this.app.ApplicationFor.ThaiName == EmployeeDisplay)
                    {
                        if (EmployeeAmount + app.AppliedAmount > EmployeeLimit)
                        {
                            result = MessageBox.Show(EmployeeLimitmessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK;
                        }
                    }
                    else
                    {
                        if (FamilyAmount + app.AppliedAmount > FamilyLimit)
                        {
                            result = MessageBox.Show(FamilyLimitmessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK;
                        }
                    }
                }

                if (status == DataFormStatus.Insert)
                    InitForNextInsert();
                else
                    this.Close();
            }
            else
                if (errorControl != null) errorControl.Focus();
        }

        private void InitForNextInsert()
        {
            MedicalAidApplication app = new MedicalAidApplication();
            app.AEmployee = this.app.AEmployee;
            this.app = app;

            cmbDisease.DataSource = MedicalAidFacade.GetListOfAllDisease();
            cmbDisease.DisplayMember = "Name";
            cmbDisease.ValueMember = "Name";

            PaintData();
        }

        private void SaveData()
        {
            if (VaildateData(this.app))
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

                    if (SaveDataCompleted != null) SaveDataCompleted();
                }
                catch (Exception ex)
                {
                    Mbox.ErrorMessage(ex.Message);
                }
            }
        }

        private void DisplayOtherPersonAge(Person person)
        {
            if (person != null)
            {
                int year;
                int month;
                try
                {
                    MonthYear.Diff(person.BirthDate, DateTime.Now.Date, out year, out month);
                    lblAge.Text = string.Format("อายุ {0} ปี {1} เดือน", year.ToString(), month.ToString());
                }
                catch
                {
                    lblAge.Text = string.Empty;
                }

            }
            else
            {
                lblAge.Text = string.Empty;
            }

        }

        private bool ValidateData()
        {
            bool isValid = true;
            if (isValid)
            {
                if (app.ApplicationFor.Code == "0")
                {
                }
                else
                {
                    if (app.OtherPerson.FullName.Trim().Length == 0)
                    {
                        if (app.ApplicationFor.Code == "1")
                            Mbox.ErrorMessage("เลือกชื่อคู่สมรส");
                        else
                            Mbox.ErrorMessage("เลือกชื่อบุตร");
                        isValid = false;
                        errorControl = cmbOtherPerson;
                    }
                }
            }
            if (isValid && (this.app.ADisease.Name.Trim().Length == 0))
            {
                isValid = false;
                errorControl = cmbDisease;
                Mbox.ErrorMessage("กรุณาเลือกข้อมูลโรค");
            }

            if (isValid && (this.app.AHospital.Code == "ZZZZZZ" && this.app.NoContractHospitalName.Trim().Length == 0))
            {
                isValid = false;
                errorControl = txtHospital;
                Mbox.ErrorMessage("โรงพยาบาลนอกสัญญา\nกรุณากรอกชื่อโรงพยาบาล");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private bool VaildateData(MedicalAidApplication app)
        {
            return true;
        }

        private void txtActualAmount_ValueChanged(object sender, EventArgs e)
        {
            txtAppliedAmount.MaxValue = Convert.ToDouble(txtActualAmount.Value);
            if (cmbType.SelectedIndex == 2)
            {
                txtAppliedAmount.Value = 0.00;
            }
            else
            {
                txtAppliedAmount.Value = txtActualAmount.Value;
            }
        }

        private void cmbOtherPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayOtherPersonAge((Person)cmbOtherPerson.SelectedItem);
        }

        private void FrmMedicalAidEntByEmp_FormClosed(object sender, FormClosedEventArgs e)
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

        private void dtpCreateDate_ValueChanged(object sender, EventArgs e)
        {
            dtpAdmitDate.MaxDate = dtpCreateDate.Value;
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHospital.Text = string.Empty;
            if (cmbHospital.SelectedItem != null)
            {
                Hospital hospital = (Hospital)cmbHospital.SelectedItem;
                if (hospital.Code == "ZZZZZZ")
                {
                    txtHospital.Visible = true;
                }
                else
                {
                    txtHospital.Visible = false;
                }
            }
            else
            {
                txtHospital.Visible = false;
            }
        }

        private void cmbDisease_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) SendKeys.Send("{TAB}");
        }
    }
}