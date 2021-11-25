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

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI {
    public partial class FrmHospitalEnt : Form {

        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;

        private bool completed = false;

        private Control errorControl = null;

        private FrmHospitalEnt() {
            InitializeComponent();
        }
        
        private Hospital hospital;
        private DataFormStatus status;

        public FrmHospitalEnt(Hospital value , DataFormStatus status,bool isReadonly) : this() {
            if (value == null) {
                value = new Hospital();
            }
            this.hospital = value;
            this.status = status;
            this.btnOK.Enabled = !isReadonly;
        }

        private void UpdateData() {
            if (ValidateData()) {
                try {
                    if (status == DataFormStatus.Insert)
                        MedicalAidFacade.UpdateHospital(hospital, FacadeBase.Status.Insert); 
                    else
                        MedicalAidFacade.UpdateHospital(hospital, FacadeBase.Status.Update);
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


        private void PaintData() {
            txtCode.Text = hospital.Code;
            txtThaiName.Text = hospital.ThaiName;
            txtEngName.Text = hospital.EngName;
            txtCode.Focus();
        }

        private void RefeshData() {
            try {
                hospital.Code = txtCode.Text.Trim();
                hospital.ThaiName = txtThaiName.Text;
                hospital.EngName = txtEngName.Text;
            } catch (Exception ex) {

                throw ex;
            }
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
                if (errorControl != null )errorControl.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmHospitalEnt_Load(object sender, EventArgs e) {
            InitHeader();
            PaintData();
            LockControl();
        }

        private void LockControl() {
            bool lockUpdate = !(status == DataFormStatus.Update);

            txtCode.Enabled = lockUpdate;
        }

        private void InitForNextInsert() {
            this.hospital = new Hospital();
            PaintData();
        }

        private bool ValidateData() {
            string strExc = string.Empty;
            bool isValid = true;
            if (txtCode.Text.Trim().Length != 6) {
                isValid = false;
                errorControl = txtCode;
                Mbox.ErrorMessage("กรอกรหัส  6 ตัวอักษร");
            }
            
            if (isValid && ! (txtThaiName.Text.Trim().Length > 0 )) {
                isValid = false;
                errorControl = txtThaiName;
                Mbox.ErrorMessage("กรุณากรอกชื่อภาษาไทย");
            }

            if (isValid && !(!IsDupName(this.hospital))) {
                isValid = false;
                errorControl = txtThaiName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาไทยใหม่อีกครั้ง");
            }

            if (isValid && !(!IsDupEngName(this.hospital))) {
                isValid = false;
                errorControl = txtEngName;
                Mbox.ErrorMessage("รายการนี้มีในฐานข้อมูลแล้ว กรุณากรอกข้อมูลชื่อภาษาอังกฤษใหม่อีกครั้ง");
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
                this.Text = "เพิ่มข้อมูลโรงพยาบาล";
            } else {
                this.Text = "แก้ไขข้อมูลโรงพยาบาล";
            }

        }

        private bool IsDupName(Hospital hospital) {
            bool isdup = false;
            List<Hospital> hospitals = MedicalAidFacade.GetListOfAllHospital();
            foreach (Hospital item in hospitals) {
                if (item.Code != hospital.Code && item.ThaiName == hospital.ThaiName) {
                    isdup = true;
                    break;
                }
            }
            return isdup;
        }

        private bool IsDupEngName(Hospital hospital) {
            bool isdup = false;
            List<Hospital> hospitals = MedicalAidFacade.GetListOfAllHospital();
            foreach (Hospital item in hospitals) {

                if (item.Code != hospital.Code && hospital.EngName.Trim().Length > 0 && item.EngName.ToUpper() == hospital.EngName.ToUpper()) {
                    isdup = true;
                    break;
                }

            }
            return isdup;
        }

        private void FrmHospitalEnt_FormClosed(object sender, FormClosedEventArgs e) {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }






    }
}