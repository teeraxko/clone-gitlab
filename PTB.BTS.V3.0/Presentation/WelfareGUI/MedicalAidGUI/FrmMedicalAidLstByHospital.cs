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
using Presentation.CommonGUI;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI
{
    public partial class FrmMedicalAidLstByHospital : ChildFormBase, IMDIChildForm
    {
        List<MedicalAidApplication> apps;

        private bool isReadonly = true;
        private Presentation.frmMain mdiParent;

        Hospital hospital;
        DateTime period;

        int currentSelectMonth = 0;
        int currentSelectYear = 0;


        public FrmMedicalAidLstByHospital()
            : base()
        {
            InitializeComponent();

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareMedicalAidListByHospital");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareMedicalAidListByHospital");
        }
        protected virtual void LockControl()
        {
            btnInsert.Enabled = !this.isReadonly;
            //btnUpdate.Enabled = !this.isReadonly;
            btnDelete.Enabled = !this.isReadonly;
            insertToolStripMenuItem.Enabled = !this.isReadonly;
            deleteToolStripMenuItem.Enabled = !this.isReadonly;
            btnEditRefDoc.Enabled = !this.isReadonly;
        }

        protected override void From_Load(object sender, EventArgs e)
        {
            base.From_Load(sender, e);
            InitForm();
            LockControl();

        }

        #region IMDIChildForm Members

        public void ExitForm()
        {
            this.Close();
        }

        public void InitForm()
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;

            MainMenuNewStatus = false;
            MainMenuRefreshStatus = false;
            mdiParent.EnableNewCommand(false);
            mdiParent.EnableRefreshCommand(false);
            InitialForm();
        }

        public void PrintForm()
        { }

        public void RefreshForm()
        {
            FillDetail();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareMedicalAidListByHospital");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
        }
        #endregion


        private void FillDetail()
        {
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableRefreshCommand(true);



            this.hospital = (Hospital)cmbHospital.SelectedItem;
            this.period = dtpPeriod.Value;
            BindList();
            this.DisbleMenuBtn(grdData.RowCount);
        }

        private void DisbleMenuBtn(int p)
        {
            bool enableControl = p > 0;
            updateToolStripMenuItem.Enabled = enableControl;
            deleteToolStripMenuItem.Enabled = enableControl;
            btnUpdate.Enabled = enableControl;
            btnDelete.Enabled = enableControl;
        }

        private void InitialForm()
        {
            // combo hospital
            cmbHospital.DataSource = MedicalAidFacade.GetListOfAllHospital();
            cmbHospital.DisplayMember = "ThaiName";
            cmbHospital.ValueMember = "Code";

            //dtp period date
            dtpPeriod.Value = PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.EndMonthDate(DateTime.Now.Date);
            cmbRefDocumentNo.DataSource = null;
            cmbRefDocumentNo.Text = string.Empty;

            LockHeader(false);
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


        private void BindList()
        {
            // for display summary
            decimal sumActual = 0M, sumApplied = 0M, sumInsurance = 0M;

            apps = MedicalAidFacade.GetOfApplicationByHospitalPeriodRefDoc((Hospital)cmbHospital.SelectedItem, dtpPeriod.Value, cmbRefDocumentNo.Text);
            int rowIndex = 0;
            grdData.Rows.Clear();

            foreach (MedicalAidApplication app in this.apps)
            {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = app;
                grdData.Rows[rowIndex].Cells["colInvoiceNo"].Value = app.InvoiceNo;
                string disEmp = string.Format("{0} {1}", app.AEmployee.EmployeeNo, app.AEmployee.EmployeeName);
                grdData.Rows[rowIndex].Cells["colEmployee"].Value = disEmp;
                grdData.Rows[rowIndex].Cells["colType"].Value = app.ApplicationType.ThaiName;
                grdData.Rows[rowIndex].Cells["colDisease"].Value = app.ADisease.Name;
                grdData.Rows[rowIndex].Cells["colAdmitDate"].Value = app.AdmitDate.ToString("dd/MM/yyyy");
                grdData.Rows[rowIndex].Cells["colActualAmount"].Value = app.ActualAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colAppliedAmount"].Value = app.AppliedAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colInsurancePaid"].Value = app.InsuranceAmount.Value;
                //grdData.Rows[rowIndex].Cells["colAtt"].Value = app.AttendanceLetterStatus == 'Y';
                //if (app.AttendanceLetterStatus == 'Y') {
                //    grdData.Rows[rowIndex].Frozen = true;
                //}

                rowIndex++;

                // summary
                sumActual += app.ActualAmount;
                sumApplied += app.AppliedAmount;
                sumInsurance += app.InsuranceAmount.Value;
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
            //colInvoiceNo colType colDisease colAdmitDate colActualAmount colAppliedAmount
            txtSumActual.Text = sumActual.ToString("N2");
            txtSumApplied.Text = sumApplied.ToString("N2");
            txtSumInsurance.Text = sumInsurance.ToString("N2");
            txtSumCompPaid.Text = decimal.Subtract(sumApplied, sumInsurance).ToString("N2");
        }

        private void InsertData()
        {
            MedicalAidApplication app = new MedicalAidApplication();
            app.AHospital = this.hospital;
            app.CreateDate = this.dtpPeriod.Value;
            app.InvoiceNo = cmbRefDocumentNo.Text;
            FrmMedicalAidEntByHospital frm = new FrmMedicalAidEntByHospital(app, DataFormStatus.Insert, this.isReadonly);
            frm.SaveDataCompleted += new FrmMedicalAidEntByHospital.SaveDataCompleteHandler(this.SaveDataCompleted);
            frm.ShowDialog();
        }

        private void UpdateData()
        {
            MedicalAidApplication app = GetSelectData();
            if (app != null)
            {
                FrmMedicalAidEntByHospital frm = new FrmMedicalAidEntByHospital(app, DataFormStatus.Update, this.isReadonly);
                frm.SaveDataCompleted += new FrmMedicalAidEntByHospital.SaveDataCompleteHandler(this.SaveDataCompleted);
                frm.ShowDialog();
            }
        }

        private void DeleteData()
        {
            MedicalAidApplication app = GetSelectData();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (ValidateHeader())
            {
                FillDetail();
                LockHeader(true);
            }
        }

        private void LockHeader(bool isLock)
        {
            dtpPeriod.Enabled = !isLock;
            cmbHospital.Enabled = !isLock;
            cmbRefDocumentNo.Enabled = !isLock;
            btnGetData.Enabled = !isLock;
            btnEditRefDoc.Visible = isLock;
            panel1.Visible = isLock;
            btnEditRefDoc.Enabled = !this.isReadonly;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void cmbHospital_Validated(object sender, EventArgs e)
        {

        }

        private void dtpPeriod_Validated(object sender, EventArgs e)
        {
            dtpPeriod.Value = PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.EndMonthDate(dtpPeriod.Value);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void grdData_Sorted(object sender, EventArgs e)
        {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void SaveDataCompleted()
        {
            FillDetail();
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


        private void DisplayRefDocNo()
        {
            cmbRefDocumentNo.DataSource = null;
            cmbRefDocumentNo.DataSource = MedicalAidFacade.GetOfRefDocumentNoByHospitalPeriod((Hospital)cmbHospital.SelectedItem, dtpPeriod.Value);
            panel1.Visible = false;
            BindList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dtpPeriod_ValueChanged(object sender, EventArgs e)
        {
            bool valueChange = dtpPeriod.Value.Year != currentSelectYear;
            valueChange = valueChange || dtpPeriod.Value.Month != currentSelectMonth;
            if (valueChange)
            {
                DisplayRefDocNo();
                currentSelectYear = dtpPeriod.Value.Year;
                currentSelectMonth = dtpPeriod.Value.Month;
            }
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRefDocNo();
        }

        private bool ValidateHeader()
        {
            if (cmbRefDocumentNo.Text.Trim().Length > 0)
                return true;
            else
            {
                Mbox.ErrorMessage("กรุณาเลือกเลขที่เอกสาร\nหรือกรอกเลขที่เอกสารใหม่ที่ต้องการเพิ่ม");
                return false;
            }

        }

        private void btnEditRefDoc_Click(object sender, EventArgs e)
        {
            FrmMedicalAidEditRefDoc frm = new FrmMedicalAidEditRefDoc(cmbRefDocumentNo.Text);
            frm.ChangedRefDocNo += new FrmMedicalAidEditRefDoc.ChangedRefDocNoHandler(this.ChangedRefDocNo);
            frm.ShowDialog();
        }


        private void ChangedRefDocNo(object sender, string newRefNo)
        {
            try
            {
                foreach (MedicalAidApplication app in this.apps)
                {
                    app.InvoiceNo = newRefNo;
                    MedicalAidFacade.UpdateMedicalAidApplication(app, FacadeBase.Status.Update);
                }
                cmbRefDocumentNo.Text = newRefNo;
                FillDetail();
            }
            catch (Exception ex)
            {
                Mbox.ErrorMessage(ex.Message);
            }
        }

        private void cmbRefDocumentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
        }
    }
}