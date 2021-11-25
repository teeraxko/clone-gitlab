using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using Entity.VehicleEntities;
using ictus.Common.Entity.General;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI.ExcessInsurance
{
    public partial class FrmExcessInsuranceEntry : EntryFormBase
    {
        private FrmExcessInsurance parentForm;
        private bool isReadOnly = true;

        //============================== Property ==============================
        private Accident objAccident;
        private Accident ObjAccident
        {
            get 
            {
                objAccident.InsuranceClaimNo = txtClaimNo.Text.Trim();
                objAccident.InsuranceReceiptNo = txtReceiptNo.Text.Trim();
                objAccident.InsuranceReceiptDate = dtpReceiptDate.Value;
                objAccident.ActualExcessAmount = Convert.ToDecimal(fpdExcessTotalAmount.Value);
                objAccident.BillByInsuranceStatus = rdoBillInsurance.Checked;
                objAccident.AInsuranceCompany = (InsuranceCompany)cboInsuranceCompany.SelectedItem;
                
                return objAccident;
            }
            set
            {
                objAccident = value;
                txtAccidentNo.Text = objAccident.RepairingNo;
                txtPlateNo.Text = objAccident.VehicleInfo.PlateNo;
                dtpAccidentDate.Value = objAccident.HappenTime;
                txtClaimNo.Text = objAccident.InsuranceClaimNo;
                txtReceiptNo.Text = objAccident.InsuranceReceiptNo;

                if (objAccident.InsuranceReceiptDate == NullConstant.DATETIME)
                {
                    dtpReceiptDate.Value = DateTime.Today;
                    dtpReceiptDate.Checked = false;
                }
                else
                {
                    dtpReceiptDate.Value = objAccident.InsuranceReceiptDate;
                    dtpReceiptDate.Checked = true;
                }

                fpdExcessTotalAmount.Value = objAccident.ActualExcessAmount;
                rdoBillInsurance.Checked = objAccident.BillByInsuranceStatus;

                if (objAccident.AInsuranceCompany == null || objAccident.AInsuranceCompany.Code == "")
                {
                    cboInsuranceCompany.SelectedText = "";
                }
                else
                { 
                    cboInsuranceCompany.SelectedText = objAccident.AInsuranceCompany.AName.Thai;
                }
            }
        }

        //============================== Constructor ==============================
        public FrmExcessInsuranceEntry(FrmExcessInsurance value): base()
        {
            InitializeComponent();
            parentForm = value;
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceExcessInsurance");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceExcessInsurance");
            cboInsuranceCompany.DataSource = parentForm.FacadeExcessInsurance.DataSourceInsuranceCompName;
        }

        //============================== Private Method ==============================
        private bool validateForm()
        {
            if (txtClaimNo.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "Claim No.");
                txtClaimNo.Focus();
                return false;
            }
            if (txtReceiptNo.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "หมายเลขใบเสร็จ");
                txtReceiptNo.Focus();
                return false;
            }
            if (!dtpReceiptDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ใบเสร็จ");
                dtpReceiptDate.Focus();
                return false;
            }
            if (decimal.Parse(fpdExcessTotalAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "ค่า Excess");
                fpdExcessTotalAmount.Focus();
                return false;
            }
            if (rdoBillInsurance.Checked && cboInsuranceCompany.Text == "")
            {
                Message(MessageList.Error.E0005, "บริษัทประกันภัย");
                cboInsuranceCompany.Focus();
                return false;
            }
            return true;
        }

        //============================== Public method ==============================
        public void InitEditAction(Accident value)
        {
            baseEDIT();
            fpdExcessTotalAmount.MinValue = 0.00;
            fpdExcessTotalAmount.MaxValue = 9999.99;
            cboInsuranceCompany.SelectedIndex = 0;
            ObjAccident = value;

            if (isReadOnly || value.PayToInsuranceBizPacReferenceNo != "")
            {
                btnOK.Enabled = false;
            }
        }

        //============================== Base Event ==============================
        private void editEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.UpdateRow(ObjAccident))
                    {
                        this.Close();
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //============================== event ==============================
        private void FrmExcessInsuranceEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            editEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoBillInsurance_CheckedChanged(object sender, EventArgs e)
        {
            rdoBillGarage.Checked = !rdoBillInsurance.Checked;
        }
    }
}