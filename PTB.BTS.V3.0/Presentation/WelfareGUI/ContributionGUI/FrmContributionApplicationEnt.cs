using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using PTB.PIS.Welfare.Facade;

namespace PTB.PIS.Welfare.WindowsApp.ContributionGUI {
    public partial class FrmContributionApplicationEnt : Form {

        public delegate void SaveDataCompleteHandler();

        //an instance of the delegate
        public event SaveDataCompleteHandler SaveDataCompleted;


        private ContributionApplication app;
        private DataFormStatus status;

        private bool completed = false;
        private Control errorControl = null;



        private FrmContributionApplicationEnt() {
            InitializeComponent();
            txtAmount.MaxValue = Convert.ToDouble(999999.99);
            txtAmount.MinValue = Convert.ToDouble(0.00); 
        }

        public FrmContributionApplicationEnt(ContributionApplication app, DataFormStatus status, bool isReadOnly)
            : this() {
            this.app = app;
            this.status = status;
            this.btnOK.Enabled = !isReadOnly;
        }

        private void FrmContributionApplicationEnt_Load(object sender, EventArgs e) {
            InitForm();
            PaintData();
            LockControl();
        }

        private void InitForm() {
            // init combo contribution
            cmbContribution.DataSource = ContributionFacade.GetAllContributionList();
            cmbContribution.DisplayMember = "ThaiDescription";
            cmbContribution.ValueMember = "Code";
        }

        private void PaintData() {
            // init new data
            if (this.status == DataFormStatus.Insert) {
                this.app.AppliedDate = DateTime.Now.Date;
                if (cmbContribution.Items.Count > 0) {
                    this.app.Contribution = (Contribution)cmbContribution.Items[0];
                    this.app.AppliedAmount = this.app.Contribution.ContributionAmount;
                } else {
                    this.app.Contribution = null;
                    this.app.AppliedAmount = 0;
                }
                this.app.Remark = string.Empty;
            }

            dtpCreateDate.Value = this.app.AppliedDate;
            if (cmbContribution.Items.Count > 0)
                cmbContribution.SelectedValue = this.app.Contribution.Code;
            txtAmount.Value = this.app.AppliedAmount;

            dtpCreateDate.Focus();


        }

        private void RefeshData() {
            app.AppliedDate = dtpCreateDate.Value;
            if (cmbContribution.Items.Count > 0)
                app.Contribution = (Contribution)cmbContribution.SelectedItem;
            else
                app.Contribution = null;
            app.AppliedAmount = Convert.ToDecimal(txtAmount.Value);
        }

        private void cmbContribution_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbContribution.SelectedItem != null) {
                txtAmount.Value = ((Contribution)cmbContribution.SelectedItem).ContributionAmount;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            RefeshData();
            SaveData();
            if (completed) {
                if (status == DataFormStatus.Insert)
                    InitForNextInsert();
                else
                    this.Close();
            } else {
                if (errorControl != null) errorControl.Focus();
            }
        }

        private void SaveData() {
            if (ValidateData(this.app)) {

                try {
                    switch (status) {
                        case DataFormStatus.Idle:
                            break;
                        case DataFormStatus.Insert:
                            ContributionFacade.UpdateContributionApplication(app, FacadeBase.Status.Insert);
                            break;
                        case DataFormStatus.Update:
                            ContributionFacade.UpdateContributionApplication(app, FacadeBase.Status.Update);
                            break;
                        case DataFormStatus.Delete:
                            break;
                        default:
                            break;
                    }
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

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void LockControl() {
            bool lockUpdate = !(status == DataFormStatus.Update);

            dtpCreateDate.Enabled = lockUpdate;
            cmbContribution.Enabled = lockUpdate;
        }


        private void InitForNextInsert() {
            ContributionApplication app = new ContributionApplication();
            app.Employee = this.app.Employee;
            this.app = app;
            PaintData();
        }


        private void Control_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SendKeys.Send("{TAB}");
            }
        }


        private bool ValidateData(ContributionApplication app) {
            bool isValid = true;
            if (isValid && app.Contribution == null) {
                isValid = false;
                errorControl = cmbContribution;
                Mbox.ErrorMessage("ไม่มีข้อมูลเงินช่วยเหลือเพื่อ");
            }

            if (isValid && !(app.AppliedAmount > 0)) {
                isValid = false;
                errorControl = txtAmount;
                Mbox.ErrorMessage("จำนวนเงินต้องมากกว่า 0");
            }

            return isValid;

        }

        private void FrmContributionApplicationEnt_FormClosed(object sender, FormClosedEventArgs e) {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }


    }
}