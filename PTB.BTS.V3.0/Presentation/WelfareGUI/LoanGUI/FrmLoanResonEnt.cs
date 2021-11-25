using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.LoanGUI {
    public partial class FrmLoanResonEnt : Form {

        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;
        private bool completed = false;
        private bool isReadonly = true;
        private Control errorControl = null;
        private LoanReson loanReson;
        private DataFormStatus status;

        public FrmLoanResonEnt() {
            InitializeComponent();

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareSettingLoanReasonList");
            this.Text = UserProfile.GetFormName("miWelfare", "miWelfareSettingLoanReasonList");
        }

        public FrmLoanResonEnt(LoanReson value, DataFormStatus status, bool isReadOnly)
            : this() {
            if (value == null) value = new LoanReson();
            this.loanReson = value;
            this.status = status;
            this.btnOK.Enabled = !isReadOnly;
        }

        private void FrmLoanResonEnt_Load(object sender, EventArgs e) {
            InitHeader();
            PaintData();
            LockControl();
        }

        private void InitHeader() {
            if (status == DataFormStatus.Insert)
                this.Text = "เพิ่มข้อมูลเหตุผลการกู้เงิน";
            else
                this.Text = "แก้ไขข้อมูลเหตุผลการกู้เงิน";
        }

        private void PaintData() {
            txtCode.Text = loanReson.Code;
            txtThaiName.Text = loanReson.ThaiName;
            txtEngName.Text = loanReson.EngName;
            txtCode.Focus();
        }

        private void LockControl() {
            bool lockUpdate = !(status == DataFormStatus.Update);

            txtCode.Enabled = lockUpdate;
        }

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

        private void RefeshData() {
            try {
                loanReson.Code = txtCode.Text.Trim();
                loanReson.ThaiName = txtThaiName.Text;
                loanReson.EngName = txtEngName.Text;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void UpdateData() {
            if (ValidateData()) {
                try {
                    if (status == DataFormStatus.Insert)
                        LoanFacade.UpdateLoanReson(loanReson, FacadeBase.Status.Insert);
                    else
                        LoanFacade.UpdateLoanReson(loanReson, FacadeBase.Status.Update);
                    if (SaveDataCompleted != null) SaveDataCompleted();
                    completed = true;
                } catch (Exception ex) {
                    completed = false;
                    Mbox.ErrorMessage(ex.Message);
                }
            } else {
                completed = false;
            }
        }

        private bool ValidateData() {
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

            if (isValid && !(!IsDupName(this.loanReson))) {
                isValid = false;
                errorControl = txtThaiName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาไทยใหม่อีกครั้ง");
            }

            if (isValid && !(!IsDupEngName(this.loanReson))) {
                isValid = false;
                errorControl = txtEngName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาอังกฤษใหม่อีกครั้ง");
            }
            return isValid;
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) SendKeys.Send("{TAB}");
        }

        private bool IsDupName(LoanReson loanReson) {
            bool isdup = false;
            List<LoanReson> loanResons = LoanFacade.GetAllLoanReson();
            foreach (LoanReson item in loanResons) {
                if (item.Code != loanReson.Code && item.ThaiName == loanReson.ThaiName) {
                    isdup = true;
                    break;
                }
            }
            return isdup;
        }

        private bool IsDupEngName(LoanReson loanReson) {
            bool isdup = false;
            List<LoanReson> loanResons = LoanFacade.GetAllLoanReson();
            foreach (LoanReson item in loanResons) {
                if (item.Code != loanReson.Code && loanReson.EngName.Trim().Length > 0 && item.EngName.ToUpper() == loanReson.EngName.ToUpper()) {
                    isdup = true;
                    break;
                }
            }
            return isdup;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void InitForNextInsert() {
            this.loanReson = new LoanReson();
            PaintData();
        }

        private void Control_Enter(object sender, EventArgs e) {
            if (sender is TextBoxBase) {
                TextBoxBase tb = (TextBoxBase)sender;
                tb.Select(0, tb.Text.Length);
            }
        }

        private void FrmLoanResonEnt_FormClosed(object sender, FormClosedEventArgs e) {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }





    }
}