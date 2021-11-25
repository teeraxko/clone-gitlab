using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using SystemFramework.AppConfig;
using Presentation.CommonGUI;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI
{
    public partial class FrmMedicalAidLstByEmp : PTB.PIS.Welfare.WindowsApp.FrmWelfareHeaderBase, IMDIChildForm
    {
        List<MedicalAidApplication> apps;
        int currentSelectYear = DateTime.Now.Year;
        string EmployeeDisplay = "ตนเอง";
        decimal EmployeeAmount;
        decimal FamilyAmount;

        public FrmMedicalAidLstByEmp()
            : base()
        {

            InitializeComponent();
            this.grdData.ContextMenuStrip = this.cMenu;

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareMedicalAidListByEmp");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareMedicalAidListByEmp");
        }

        protected override void From_Load(object sender, EventArgs e)
        {
            base.From_Load(sender, e);
            InitForm();
            this.LockControl();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareMedicalAidListByEmp");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
        }

        public override void InitForm()
        {
            base.InitForm();
            mdiParent.RefreshMasterCount();
        }

        public override void RefreshForm()
        {
            base.RefreshForm();
        }

        public override void FillDetail()
        {
            base.FillDetail();
            apps = MedicalAidFacade.GetOfApplicationByEmp(emp);
            BindList();
            this.DisbleMenuBtn(grdData.RowCount);
        }

        protected override void InsertData()
        {
            MedicalAidApplication app = new MedicalAidApplication();
            app.AEmployee = this.emp;
            FrmMedicalAidEntByEmp frm = new FrmMedicalAidEntByEmp(app, DataFormStatus.Insert, this.isReadonly, EmployeeAmount, FamilyAmount);
            frm.SaveDataCompleted += new FrmMedicalAidEntByEmp.SaveDataCompleteHandler(this.SaveDataCompleted);
            frm.ShowDialog();

        }

        protected override void UpdateData()
        {
            MedicalAidApplication app = GetSelectData();

            if (app != null)
            {
                if (app.ApplicationFor.ThaiName == EmployeeDisplay)
                {
                    EmployeeAmount = EmployeeAmount - app.AppliedAmount;
                }
                else
                {
                    FamilyAmount = FamilyAmount - app.AppliedAmount;
                }
                FrmMedicalAidEntByEmp frm = new FrmMedicalAidEntByEmp(app, DataFormStatus.Update, this.isReadonly, EmployeeAmount, FamilyAmount);
                frm.SaveDataCompleted += new FrmMedicalAidEntByEmp.SaveDataCompleteHandler(this.SaveDataCompleted);
                frm.ShowDialog();
            }
        }

        protected override void DeleteData()
        {
            MedicalAidApplication app = GetSelectData();
            // if (!CheckAtt(app)) {
            if (app != null)
            {
                try
                {
                    if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes)
                    {
                        MedicalAidFacade.UpdateMedicalAidApplication(app, FacadeBase.Status.Delete);
                        SaveDataCompleted();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
        }

        private MedicalAidApplication GetSelectData()
        {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (MedicalAidApplication)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;
        }

        private void CheckAmount(decimal amount)
        {

        }

        private void BindList()
        {

            // for display summary
            decimal sumActual = 0M, sumApplied = 0M, sumInsurance = 0M, sumFamily = 0M, sumEmployee = 0M;

            int rowIndex = 0;
            grdData.Rows.Clear();
            DateTime startDate = new DateTime(currentSelectYear, 4, 1);
            DateTime endDate = new DateTime(currentSelectYear + 1, 3, 31); //Next year
            List<MedicalAidApplication> filterapp = apps.FindAll(i => i.CreateDate >= startDate && i.CreateDate <= endDate);
            foreach (MedicalAidApplication app in filterapp)
            {
                //if (currentSelectYear == app.CreateDate.Year)
                //{

                    // summary
                    sumActual += app.ActualAmount;
                    sumApplied += app.AppliedAmount;
                    sumInsurance += app.InsuranceAmount.Value;
                    if (app.ApplicationFor.ThaiName == EmployeeDisplay)
                    {
                        sumEmployee += app.AppliedAmount;
                    }
                    else
                    {
                        sumFamily += app.AppliedAmount;
                    }

                    grdData.RowCount++;
                    grdData.Rows[rowIndex].Tag = app;
                    grdData.Rows[rowIndex].Cells["colCreateDate"].Value = app.CreateDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colType"].Value = app.ApplicationType.ThaiName;
                    grdData.Rows[rowIndex].Cells["colFor"].Value = app.ApplicationFor.ThaiName;
                    grdData.Rows[rowIndex].Cells["colDisease"].Value = app.ADisease.Name;

                    // display hospital name
                    if (app.AHospital.Code == "ZZZZZZ")
                    {
                        grdData.Rows[rowIndex].Cells["colHospital"].Value = app.NoContractHospitalName;
                    }
                    else
                    {
                        grdData.Rows[rowIndex].Cells["colHospital"].Value = app.AHospital.ThaiName;
                    }
                    grdData.Rows[rowIndex].Cells["colAdmitDate"].Value = app.AdmitDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colActualAmount"].Value = app.ActualAmount.ToString("N2");
                    grdData.Rows[rowIndex].Cells["colAppliedAmount"].Value = app.AppliedAmount.ToString("N2");
                    grdData.Rows[rowIndex].Cells["colAtt"].Value = app.AttendanceLetterStatus == 'Y';
                    grdData.Rows[rowIndex].Cells["colInsurancePaid"].Value = app.InsuranceAmount.Value;
                    rowIndex++;
                //}
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
            txtSumActual.Text = sumActual.ToString("N2");
            txtSumApplied.Text = sumApplied.ToString("N2");
            txtSumFamily.Text = sumFamily.ToString("N2");
            txtSumEmployee.Text = sumEmployee.ToString("N2");
            txtSumInsurance.Text = sumInsurance.ToString("N2");
            txtSumCompPaid.Text = decimal.Subtract(sumApplied, sumInsurance).ToString("N2");
            EmployeeAmount = sumEmployee;
            FamilyAmount = sumFamily;
        }

        private void SaveDataCompleted()
        {
            FillDetail();
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private bool CheckAtt(MedicalAidApplication app)
        {
            if (app.AttendanceLetterStatus == 'Y') Mbox.ErrorMessage("ไม่อนุญาตให้แก้ไขรายการที่ใช้ใบส่งตัว");
            return app.AttendanceLetterStatus == 'Y';
        }

        private void dtpSelectYear_ValueChanged(object sender, EventArgs e)
        {
            if (currentSelectYear != dtpSelectYear.Value.Year)
            {
                currentSelectYear = dtpSelectYear.Value.Year;
                BindList();
            }

        }

        private void grdData_Sorted(object sender, EventArgs e)
        {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);

        }
    }
}

