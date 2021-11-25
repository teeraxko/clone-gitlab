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

namespace PTB.PIS.Welfare.WindowsApp.LoanGUI
{
    public partial class FrmLoanApplicationEnt : Form
    {

        public delegate void SaveDataCompleteHandler();
        public event SaveDataCompleteHandler SaveDataCompleted;

        private LoanApplication app;
        private List<LoanInstallmentDetail> details;
        private DataFormStatus status;

        private Control errorControl = null;

        private DateTime currentStartDate = Common.EndMonthDate(DateTime.MinValue.Date);

        private bool isReadOnly;
        private FrmLoanApplicationEnt()
        {
            InitializeComponent();
            txtCapitalAmount.MaxValue = 999999.99;
            txtCapitalAmount.MinValue = 0.00;
            txtInterest.MaxValue = 100;
            txtInterest.MinValue = 0.00;
        }

        public FrmLoanApplicationEnt(LoanApplication app, DataFormStatus status, bool isReadOnly)
            : this()
        {
            this.app = app;
            this.status = status;
            if (this.status == DataFormStatus.Update)
            {
                this.details = LoanFacade.GetDetailByApp(app);
            }
            else
            {
                this.details = new List<LoanInstallmentDetail>();
            }
            this.isReadOnly = isReadOnly;

            this.btnCalculate.Enabled = !isReadOnly;
            this.btnOK.Enabled = !isReadOnly;



        }

        private void InitForm()
        {
            // combo type
            cmbPurpose.DataSource = null;
            cmbPurpose.DataSource = LoanFacade.GetAllLoanReson();
            cmbPurpose.DisplayMember = "ThaiName";
            cmbPurpose.ValueMember = "Code";

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckReDetail())
            {
                RefeshData();
                if (ValidateData())
                {
                    SaveData();
                    if (status == DataFormStatus.Insert)
                        //InitForNextInsert();
                        this.Close();
                    else
                        this.Close();
                }
                else
                    if (errorControl != null) errorControl.Focus();
            }
            else
            {
                Mbox.ErrorMessage("กรุณาคลิกคำนวนตารางการผ่อนชำระ");
            }

        }

        private bool CheckReDetail()
        {
            bool result = true;
            result = result && this.app.CapitalAmount == Convert.ToDecimal(txtCapitalAmount.Value);
            result = result && this.app.StartDate == Common.EndMonthDate(dtpStartDate.Value);
            result = result && this.app.InterestRate == Convert.ToDecimal(txtInterest.Value);
            result = result && this.app.Period == Convert.ToInt32(txtPeriod.Value);
            return result;

        }

        private void InitForNextInsert()
        {
            LoanApplication app = new LoanApplication();
            app.Employee = this.app.Employee;
            this.app = app;
            PaintData();
        }



        private void RefeshData()
        {
            if (cmbPurpose.Items.Count > 0)
                this.app.LoanReson = (LoanReson)cmbPurpose.SelectedItem;
            else
                this.app.LoanReson = null;

            this.app.AppliedDate = dtpAppliedDate.Value.Date;
            this.app.StartDate = Common.EndMonthDate(dtpStartDate.Value);
            this.app.Period = Convert.ToInt32(txtPeriod.Value);
            this.app.EndDate = Common.EndMonthDate(dtpStartDate.Value.AddMonths(this.app.Period - 1));
            this.app.InterestRate = Convert.ToDecimal(txtInterest.Value);
            this.app.CapitalAmount = Convert.ToDecimal(txtCapitalAmount.Value);
            this.app.IsOffset = chkOffset.Checked;
            if (this.app.IsOffset)
            {
                this.app.OffsetDate = dtpOffsetDate.Value.Date;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoanApplicationEnt_Load(object sender, EventArgs e)
        {
            InitHeader();
            InitForm();
            PaintData();
            LockControl();
        }

        private void InitHeader()
        {
            if (status == DataFormStatus.Insert)
                this.Text = "เพิ่มข้อมูลเงินกู้ของพนักงาน";
            else
                this.Text = "แก้ไขข้อมูลเงินกู้ของพนักงาน";
        }

        private void PaintData()
        {
            //init new data
            if (status == DataFormStatus.Insert)
            {
                this.app.AppliedDate = DateTime.Now.Date;
                if (cmbPurpose.Items.Count > 0)
                {
                    this.app.LoanReson = (LoanReson)cmbPurpose.Items[0];
                }
                else
                {
                    this.app.LoanReson = null;
                }
                this.app.StartDate = Common.EndMonthDate(DateTime.Now.Date.AddMonths(1));
                this.app.Period = 0;
                this.app.EndDate = Common.EndMonthDate(this.app.StartDate.AddMonths(this.app.Period));
                this.app.CapitalAmount = 0.00M;
                this.app.InterestRate = 4.00M;
                this.app.PaidAmount = 0.00M;
                this.app.OffsetAmount = 0.00M;
                this.app.OffsetDate = DateTime.MinValue;
                this.app.IsOffset = false;
                this.app.BalanceAmount = 0.00M;
            }
            dtpAppliedDate.Value = this.app.AppliedDate;
            if (cmbPurpose.Items.Count > 0)
                cmbPurpose.SelectedValue = this.app.LoanReson.Code;
            txtCapitalAmount.Value = this.app.CapitalAmount;
            txtInterest.Value = this.app.InterestRate;
            dtpStartDate.Value = this.app.StartDate;
            txtPeriod.Value = this.app.Period;
            lblEndDate.Tag = this.app.EndDate;
            lblEndDate.Text = this.app.EndDate.ToString("MM/yyyy");
            chkOffset.Checked = this.app.IsOffset;
            if (this.app.IsOffset)
            {
                dtpOffsetDate.Value = this.app.OffsetDate;
            }
            else
            {
                dtpOffsetDate.Value = DateTime.Now.Date;
                dtpOffsetDate.Enabled = false;
            }
            PaintInstallmentDetail();





        }

        private void PaintInstallmentDetail()
        {
            int rowIndex = 0;
            grdData.Rows.Clear();
            decimal displayCapital = 0M;
            decimal displayInterest = 0M;
            decimal displayTotalPaid = 0M;
            foreach (LoanInstallmentDetail detail in this.details)
            {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = detail;
                grdData.Rows[rowIndex].Cells["colForYearMonth"].Value = string.Format("{0}/{1}", detail.ForMonth.ToString("00"), detail.ForYear.ToString("0000"));
                grdData.Rows[rowIndex].Cells["colIntAmount"].Value = detail.InstallmentAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colInterest"].Value = detail.InterestAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colTotalAmount"].Value = detail.TotalAmount.ToString("N2");
                //grdData.Rows[rowIndex].Cells["colPaymentStatus"].Value = detail.PaymentStatus;
                char paymentStatus = detail.PaymentStatus;
                string paymentStatusDisp = string.Empty;
                switch (paymentStatus)
                {
                    case 'Y':
                        paymentStatusDisp = "Yes";
                        break;
                    case 'N':
                        paymentStatusDisp = "No";
                        break;
                    case 'O':
                        paymentStatusDisp = "Offset";
                        break;
                    default:
                        throw new Exception("Cant map payment status display");
                }
                grdData.Rows[rowIndex].Cells["colPaymentStatus"].Value = paymentStatusDisp;
                rowIndex++;

                displayCapital += detail.InstallmentAmount;
                displayInterest += detail.InterestAmount;

                if (detail.PaymentStatus != 'N')
                {
                    displayTotalPaid += detail.InstallmentAmount + detail.InterestAmount;
                }

            }
            //displayTotalAmount = displayCapital + displayInterest;
            //lblTotal.Text = displayTotalAmount.ToString("N2");
            //lblPaid.Text = displayTotalPaid.ToString("N2");
            //lblBalance.Text = (displayTotalAmount - displayTotalPaid).ToString("N2");
            Common.PaintHeaderSeq(grdData);

        }


        private void LockControl()
        {
            bool lockUpdate = !(status == DataFormStatus.Update);
            dtpAppliedDate.Enabled = lockUpdate;
            cmbPurpose.Enabled = lockUpdate;

            if (status == DataFormStatus.Update)
            {
                if (this.app.PaidAmount > 0 || this.app.IsOffset || this.app.BalanceAmount == 0)
                {
                    txtCapitalAmount.Enabled = lockUpdate;
                    txtInterest.Enabled = lockUpdate;
                    dtpStartDate.Enabled = lockUpdate;
                    txtPeriod.Enabled = lockUpdate;
                    btnCalculate.Enabled = lockUpdate;
                    this.btnCalculate.Enabled = !this.isReadOnly;
                }
                if (this.app.BalanceAmount == 0)
                {
                    chkOffset.Enabled = lockUpdate;
                    dtpOffsetDate.Enabled = lockUpdate;
                    btnOK.Enabled = lockUpdate;
                }
            }
            else
            {
                chkOffset.Enabled = false;
                dtpOffsetDate.Enabled = false;
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCapitalAmount.Value) > 0)
                CalculateInstallment();
            else
                Mbox.ErrorMessage("เงินต้นต้องมากกว่า 0");
        }

        private void CalculateInstallment()
        {
            this.app.CapitalAmount = Convert.ToDecimal(txtCapitalAmount.Value);
            this.app.InterestRate = Convert.ToDecimal(txtInterest.Value);
            this.app.Period = Convert.ToInt32(txtPeriod.Value);
            this.app.StartDate = Common.EndMonthDate(dtpStartDate.Value);
            this.details = LoanFacade.GetNewLoanInstallmentDetail(this.app);
            PaintInstallmentDetail();

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // start date change
            if (currentStartDate != Common.EndMonthDate(dtpStartDate.Value))
            {
                currentStartDate = Common.EndMonthDate(dtpStartDate.Value);
                StartDateOrPeriodChange();
                dtpStartDate.Value = currentStartDate;
            }
        }

        private void StartDateOrPeriodChange()
        {
            lblEndDate.Text = (Common.EndMonthDate(dtpStartDate.Value)).AddMonths(Convert.ToInt32(txtPeriod.Value) - 1).ToString("MM/yyyy");
        }

        private void txtPeriod_ValueChanged(object sender, EventArgs e)
        {
            StartDateOrPeriodChange();
        }

        private void SaveData()
        {
            try
            {
                if (this.app.IsOffset)
                {

                    LoanFacade.OffsetLoanApplication(app, details);
                }
                else
                {
                    switch (status)
                    {
                        case DataFormStatus.Idle:
                            break;
                        case DataFormStatus.Insert:
                            LoanFacade.UpdateLoanApplication(app, details, FacadeBase.Status.Insert);
                            break;
                        case DataFormStatus.Update:
                            LoanFacade.UpdateLoanApplication(app, details, FacadeBase.Status.Update);
                            break;
                        case DataFormStatus.Delete:
                            break;
                        default:
                            break;
                    }
                }
                if (SaveDataCompleted != null) SaveDataCompleted();
            }
            catch (Exception ex)
            {
                Mbox.ErrorMessage(ex.Message);
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
            if (isValid && this.app.AppliedDate > this.app.StartDate)
            {
                isValid = false;
                errorControl = dtpAppliedDate;
                Mbox.ErrorMessage("วันที่เริ่มต้นต้องไม่น้อยกว่าวันที่อนุมัติ");
            }
            if (isValid && this.app.LoanReson == null)
            {
                isValid = false;
                errorControl = cmbPurpose;
                Mbox.ErrorMessage("ไม่มีข้อมูลเหตุผลการกู้เงิน");
            }

            if (isValid && this.app.CapitalAmount <= 0M)
            {
                isValid = false;
                errorControl = txtCapitalAmount;
                Mbox.ErrorMessage("เงินกู้ต้องมากกว่า 0");
            }
            if (isValid && this.app.InterestRate <= 0)
            {
                isValid = false;
                errorControl = txtInterest;
                Mbox.ErrorMessage("ดอกเบี้ยต้องมากกว่า 0");
            }
            if (isValid && this.app.Period <= 0)
            {
                isValid = false;
                errorControl = txtPeriod;
                Mbox.ErrorMessage("จำนวนงวดต้องมากกว่า 0");
            }
            return isValid;
        }

        private void chkOffset_CheckedChanged(object sender, EventArgs e)
        {
            dtpOffsetDate.Enabled = chkOffset.Checked;
            dtpOffsetDate.Value = DateTime.Now.Date;
        }

        private void FrmLoanApplicationEnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SaveDataCompleted != null) SaveDataCompleted();
        }
    }
}