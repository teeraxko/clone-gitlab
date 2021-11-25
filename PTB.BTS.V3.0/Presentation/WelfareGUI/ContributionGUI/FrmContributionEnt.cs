using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ictus.PIS.Welfare.Entity.ContributionEntities;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.ContributionGUI {
    public partial class FrmContributionEnt : Form {

        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;

        private DataFormStatus status;

        private bool completed = false;
        private bool isReadonly = true;
        private Control errorControl = null;


        private  FrmContributionEnt() {
            InitializeComponent();

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareSettingContribution");
            this.Text = UserProfile.GetFormName("miWelfare", "miWelfareSettingContribution");

            txtAmount.MaxValue = Convert.ToDouble(999999.99);
            txtAmount.MinValue = Convert.ToDouble(0.00); 
        }
        public FrmContributionEnt(Contribution value, DataFormStatus status, bool isReadOnly):this() {
            if (value == null) {
                value = new Contribution();
            }
            this.aContribution = value;
            this.status = status;
            this.btnOK.Enabled = !isReadonly;
        }

        private Contribution aContribution;

        private void UpdateData() {
            if (ValidateData()) {
                try {
                    if (status == DataFormStatus.Insert)
                        ContributionFacade.UpdateContribution(aContribution, FacadeBase.Status.Insert);
                    else
                        ContributionFacade.UpdateContribution(aContribution, FacadeBase.Status.Update);
                    if (SaveDataCompleted != null) SaveDataCompleted(); completed = true;
                    completed = true;
                } catch (Exception ex) {
                    completed = false;
                    Mbox.ErrorMessage(ex.Message);
                }
            } else {
                completed = false;
            }
        }

        private void PaintData() {
            txtCode.Text = aContribution.Code;
            txtThaiName.Text = aContribution.ThaiDescription;
            txtEngName.Text = aContribution.EngDescription;
            txtAmount.Value = aContribution.ContributionAmount;
            txtCode.Focus();
        }

        private void RefeshData() {
            try {
                aContribution.Code = txtCode.Text.Trim();
                aContribution.ThaiDescription = txtThaiName.Text;
                aContribution.EngDescription = txtEngName.Text;
                aContribution.ContributionAmount = Convert.ToDecimal(txtAmount.Value);
            } catch (Exception ex) {
                
                throw ex;
            }
        }



        


        #region IMDIChildForm Members

        public void ExitForm() {
            throw new Exception("The method or operation is not implemented.");
        }

        public void InitForm() {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm() {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RefreshForm() {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e) {
            RefeshData();
            UpdateData();
            if (completed) {
                if (status == DataFormStatus.Insert)
                    InitForNextInsert();
                else
                    this.Close();
            } else {
                if (errorControl != null) errorControl.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmContributionEnt_Load(object sender, EventArgs e) {
            InitHeader();
            PaintData();
            LockControl();
        }

        private void LockControl() {
            bool lockUpdate = !(status == DataFormStatus.Update);

            txtCode.Enabled = lockUpdate;
        }

        private void InitForNextInsert() {
            this.aContribution = new Contribution();
            PaintData();
        }

        private bool ValidateData() {
            string strExc = string.Empty;
            bool isValid = true;
            if (txtCode.Text.Trim().Length != 2) {
                isValid = false;
                errorControl = txtCode;
                Mbox.ErrorMessage("กรอกรหัส  2 ตัวอักษร");
            }

            if (isValid && !(txtThaiName.Text.Trim().Length > 0)) {
                isValid = false;
                errorControl = txtThaiName;
                Mbox.ErrorMessage("กรุณากรอกชื่อภาษาไทย");
            }


            if (isValid && !(!IsDupName(this.aContribution))) {
                isValid = false;
                errorControl = txtThaiName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาไทยใหม่อีกครั้ง");
            }

            if (isValid && !(!IsDupEngName(this.aContribution))) {
                isValid = false;
                errorControl = txtEngName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาอังกฤษใหม่อีกครั้ง");
            }

            if (isValid && !(Convert.ToDecimal(txtAmount.Value) > 0M)) {
                isValid = false;
                errorControl = txtAmount;
                Mbox.ErrorMessage("จำนวนเงินต้องมากกว่า 0");
            }

            return isValid;
        }


        private void Control_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SendKeys.Send("{TAB}");
            }
        }


        private void InitHeader() {
            if (status == DataFormStatus.Insert) {
                this.Text = "เพิ่มข้อมูลเงินช่วยเหลือ";
            } else {
                this.Text = "แก้ไขข้อมูลเงินช่วยเหลือ";
            }

        }

        private bool IsDupName(Contribution contribution) {
            bool isdup = false;
            List<Contribution> contributions = ContributionFacade.GetAllContributionList();
            foreach (Contribution item in contributions) {
                
                if (item.Code != contribution.Code && item.ThaiDescription == contribution.ThaiDescription) {
                    isdup = true;
                    break;
                }

            }
            return isdup;
        }

        private bool IsDupEngName(Contribution contribution) {
            bool isdup = false;
            List<Contribution> contributions = ContributionFacade.GetAllContributionList();
            foreach (Contribution item in contributions) {

                if (item.Code != contribution.Code && contribution.EngDescription.Trim().Length > 0 && item.EngDescription.ToUpper() == contribution.EngDescription.ToUpper()) {
                    isdup = true;
                    break;
                }

            }
            return isdup;
        }

        private void FrmContributionEnt_FormClosed(object sender, FormClosedEventArgs e) {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }


    }
}