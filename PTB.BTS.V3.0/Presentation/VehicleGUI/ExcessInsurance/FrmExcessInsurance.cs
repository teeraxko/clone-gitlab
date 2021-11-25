using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.VehicleEntities;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI.ExcessInsurance
{
    public partial class FrmExcessInsurance : ChildFormBase, IMDIChildForm 
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmExcessInsuranceEntry frmEntry; 
        #endregion -Private -       

        #region - Property -
        private ExcessInsuranceFacade facadeExcessInsurance;
        public ExcessInsuranceFacade FacadeExcessInsurance
        {
            get { return facadeExcessInsurance; }
        }

        private int SelectedRow
        {
            get { return dtgExcess.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgExcess[0, SelectedRow].Value.ToString(); }
        }

        public Accident selectedAccident
        {
            get { return (Accident)facadeExcessInsurance.VehicleAccident[SelectedKey]; }
        }
        #endregion

        //================================= Constructor ================================
        public FrmExcessInsurance() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceExcessInsurance");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceExcessInsurance");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceExcessInsurance");
        }

        public override int MasterCount()
        {
            return facadeExcessInsurance.VehicleAccident.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeExcessInsurance = new ExcessInsuranceFacade();
            frmEntry = new FrmExcessInsuranceEntry(this);
        }

        private void visibleForm(bool value)
        {
            dtgExcess.Visible = value;
            btnUpdate.Visible = value;
            btnDelete.Visible = value;
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            mniUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            cboToYear.SelectedIndex = -1;
            dtgExcess.RowCount = 0;
            gpbDetail.Enabled = true;
            enableAmend(false);
            visibleForm(false);
        }

        private void bindExcessInsurance(int row, Accident value)
        {
            dtgExcess[0, row].Value = value.EntityKey.ToString();
            dtgExcess[1, row].Value = value.VehicleInfo.PlateNo;
            dtgExcess[2, row].Value = value.RepairingNo;
            dtgExcess[3, row].Value = value.HappenTime;
            dtgExcess[4, row].Value = value.InsuranceClaimNo;
            dtgExcess[5, row].Value = value.InsuranceReceiptNo;

            if (value.InsuranceReceiptDate == NullConstant.DATETIME)
            {
                dtgExcess[6, row].Value = "";
            }
            else
            {
                dtgExcess[6, row].Value = value.InsuranceReceiptDate.ToShortDateString();
            }
            dtgExcess[7, row].Value = value.ActualExcessAmount;
        }

        private void bindForm()
        {
            dtgExcess.RowCount = 0;

            if (facadeExcessInsurance.VehicleAccident.Count > 0)
            {
                for (int i = 0; i < facadeExcessInsurance.VehicleAccident.Count; i++)
                {
                    dtgExcess.RowCount++;
                    bindExcessInsurance(i, (Accident)facadeExcessInsurance.VehicleAccident[i]);
                }
            }
        }

        private void setComboBox()
        {
            cboToYear.Items.Clear();
            cboToYear.Items.Add("");
            for (int i = 2005; i <= DateTime.Today.Year + 1; i++)
            {
                cboToYear.Items.Add(i);
            }
        }

        //		==========================Public Method========================
        public bool UpdateRow(Accident accident)
        {
            if (facadeExcessInsurance.UpdateTotalExcessAmount(accident))
            {
                bindExcessInsurance(SelectedRow, accident);
                return true;
            }
            return false;
        }

        private void updateEvent()
        {
            try
            {
                frmEntry = new FrmExcessInsuranceEntry(this);
                frmEntry.InitEditAction(selectedAccident);
                frmEntry.ShowDialog();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    Accident accident = selectedAccident;

                    if (accident.PayToInsuranceBizPacReferenceNo == "")
                    {
                        accident.InsuranceClaimNo = "";
                        accident.InsuranceReceiptNo = "";
                        accident.InsuranceReceiptDate = NullConstant.DATETIME;
                        accident.ActualExcessAmount = decimal.Zero;

                        if (facadeExcessInsurance.UpdateTotalExcessAmount(accident))
                        {
                            bindExcessInsurance(SelectedRow, accident);
                        }
                    }
                    else
                    {
                        Message(MessageList.Error.E0013, "ลบข้อมูลได้", "มีการถ่ายโอนข้อมูลเข้า BizPac แล้ว");
                    }

                    accident = null;
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //============================== Base Event ==============================
        public void InitForm()
        {
            newObject();
            setComboBox();
            clearForm();

            mdiParent.EnableNewCommand(true);
            mdiParent.EnableRefreshCommand(true);
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;
        }

        public void RefreshForm()
        {
            try
            {
                visibleForm(true);
                gpbDetail.Enabled = false;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (facadeExcessInsurance.DisplayAccident(cboToYear.Text))
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgExcess.RowCount = 0;
                }

                mdiParent.RefreshMasterCount();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            if (isReadonly)
            {
                enableAmend(false);
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }


        //============================== Event ==============================
        private void FrmExcessInsurance_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dtgExcess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}

