using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI {
    public partial class FrmMedicalAidEditRefDoc : Form {

        public delegate void ChangedRefDocNoHandler(object frm,string newRefDoc);

        public event ChangedRefDocNoHandler ChangedRefDocNo;


        
        private FrmMedicalAidEditRefDoc() {
            InitializeComponent();
        }

        public FrmMedicalAidEditRefDoc(string oldRefDocNo):this() {
            lblOldDocNo.Text = oldRefDocNo;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (txtNewDocNo.Text.Trim().Length > 0) {
                if (ChangedRefDocNo != null) ChangedRefDocNo(this, txtNewDocNo.Text.Trim());
                this.Close();
            } else {
                Mbox.ErrorMessage("กรุณากรอกเลขที่เอกสาร");
            }

        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmMedicalAidEditRefDoc_FormClosed(object sender, FormClosedEventArgs e) {

        }
    }
}