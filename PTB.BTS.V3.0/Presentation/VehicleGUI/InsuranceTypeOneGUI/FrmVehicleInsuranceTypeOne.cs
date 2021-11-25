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

namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    public partial class FrmVehicleInsuranceTypeOne : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private bool isReadonly = true;
        private bool isCurrent = true;
        private frmMain mdiParent;
        private FrmVehicleInsuranceTypeOneEntry frmEntry;
        private frmInsuranceTypeOnePolicyList objfrmInsuranceTypeOnePolicyList;
        private InsuranceTypeOne objInsuranceTypeOne;
        private CompulsoryDocNoBase compulsoryBase;
        #endregion

        #region Property
        private VehicleInsuranceTypeOneFacade facadeVehicleInsuranceTypeOne;
        public VehicleInsuranceTypeOneFacade FacadeVehicleInsuranceTypeOne
        {
            get { return facadeVehicleInsuranceTypeOne; }
        }

        private int SelectedRow
        {
            get { return dtgVehicleInsurance.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgVehicleInsurance[0, SelectedRow].Value.ToString(); }
        }

        public VehicleInsuranceTypeOne selectedVehicleInsuranceTypeOne
        {
            get { return (VehicleInsuranceTypeOne)facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList[SelectedKey]; }
        }
        #endregion

        #region Constructor
        public FrmVehicleInsuranceTypeOne()
            : base()
        {
            InitializeComponent();
            setConstructor();
        }

        public FrmVehicleInsuranceTypeOne(InsuranceTypeOne value)
            : base()
        {
            InitializeComponent();
            setConstructor();
            setInsuranceTypeOne(value);
            isCurrent = false;
        } 
        #endregion        

        #region Private Method
        private void setConstructor()
        {
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
        }

        private void newObject()
        {
            facadeVehicleInsuranceTypeOne = new VehicleInsuranceTypeOneFacade();
            frmEntry = new FrmVehicleInsuranceTypeOneEntry(this);
            compulsoryBase = ObjectCreater.CreateCompulsoryDocNo();
        }

        private void visibleForm(bool value)
        {
            dtgVehicleInsurance.Visible = value;
            btnAdd.Visible = value;
            btnUpdate.Visible = value;
            btnDelete.Visible = value;
            gpbInsuranceDetail.Visible = value;
            gpbVehicleInsurance.Visible = value;
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyPrefix.Text = compulsoryBase.DefaultPrefix;
            //txtPolicyYear.Text = DateTime.Today.ToString("yy");
            //txtPolicyEndorsement.Text = compulsoryBase.DefaultEndorsement;

            txtPolicyNo.Clear();
            gpbInsuranceNo.Enabled = true;
            dtgVehicleInsurance.RowCount = 0;
            enableAmend(false);
            visibleForm(false);
        }

        private void clearInsuranceDetail()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = dtpStartDate.Value.AddYears(1);
            txtInsuranceCompany.Text = "";
            txtInchargeName.Text = "";
            txtInchargeTelNo.Text = "";
            fpdPremiumAmount.Value = decimal.Zero;
            fpdRevenueStampFee.Value = decimal.Zero;
            fpdVatAmount.Value = decimal.Zero;
        }

        private void clearVehicleInsuranceDetail()
        {
            fpdVehicleSumAssured.Value = decimal.Zero;
            fpdVehiclePremiumAmount.Value = decimal.Zero;
            fpdVehicleRevenueStampFee.Value = decimal.Zero;
            fpdVehicleVatAmount.Value = decimal.Zero;
        }

        private void bindVehicleInsuranceTypeOne(int row, VehicleInsuranceTypeOne value)
        {
            dtgVehicleInsurance[0, row].Value = value.EntityKey.ToString();
            dtgVehicleInsurance[1, row].Value = value.OrderNo.ToString();
            dtgVehicleInsurance[2, row].Value = value.AVehicleInfo.PlateNumber.ToString();
            dtgVehicleInsurance[3, row].Value = value.AVehicleInfo.AModel.ABrand.AName.English;
            dtgVehicleInsurance[4, row].Value = value.AVehicleInfo.AModel.AName.English;
            dtgVehicleInsurance[5, row].Value = value.SumAssured;
            dtgVehicleInsurance[6, row].Value = value.PremiumAmount;
            dtgVehicleInsurance[7, row].Value = value.RevenueStampFee;
            dtgVehicleInsurance[8, row].Value = value.VatAmount;
            dtgVehicleInsurance[9, row].Value = value.Amount;
            dtgVehicleInsurance[10, row].Value = value.AffiliateDate.ToShortDateString();
        }

        private void bindForm()
        {
            dtgVehicleInsurance.RowCount = 0;

            if (facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList.Count > 0)
            {
                for (int i = 0; i < facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList.Count; i++)
                {
                    dtgVehicleInsurance.RowCount++;
                    bindVehicleInsuranceTypeOne(i, facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList[i]);
                }
            }

            bindInsuranceHeader();
            bindVehicleInsuranceHeader();
        }

        private void bindInsuranceHeader()
        {
            if (objInsuranceTypeOne != null)
            {
                dtpStartDate.Value = objInsuranceTypeOne.APeriod.From;
                dtpEndDate.Value = objInsuranceTypeOne.APeriod.To;
                txtInsuranceCompany.Text = objInsuranceTypeOne.AInsuranceCompany.AName.Thai;
                txtInchargeName.Text = objInsuranceTypeOne.InsuranceInchargeName;
                txtInchargeTelNo.Text = objInsuranceTypeOne.InsuranceInchargeTelNo;
                fpdPremiumAmount.Value = objInsuranceTypeOne.PremiumAmount;
                fpdRevenueStampFee.Value = objInsuranceTypeOne.RevenueStampFee;
                fpdVatAmount.Value = objInsuranceTypeOne.VatAmount;
            }
        }

        private void bindVehicleInsuranceHeader()
        {
            VehicleInsuranceTypeOne vehicleInsurance;
            decimal sumSumAssured = decimal.Zero;
            decimal sumPremiumAmount = decimal.Zero;
            decimal sumRevenueStampFee = decimal.Zero;
            decimal sumVatAmount = decimal.Zero;

            for (int i = 0; i < facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList.Count; i++)
            {
                vehicleInsurance = facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList[i];
                sumSumAssured += vehicleInsurance.SumAssured;
                sumPremiumAmount += vehicleInsurance.PremiumAmount;
                sumRevenueStampFee += vehicleInsurance.RevenueStampFee;
                sumVatAmount += vehicleInsurance.VatAmount;
            }
            vehicleInsurance = null;

            fpdVehicleSumAssured.Value = sumSumAssured;
            fpdVehiclePremiumAmount.Value = sumPremiumAmount;
            fpdVehicleRevenueStampFee.Value = sumRevenueStampFee;
            fpdVehicleVatAmount.Value = sumVatAmount;
        }

        //User request to chage text format : Woranai 2009-07-20
        //private string getPolicyNo()
        //{
        //    return txtPolicyPrefix.Text + "/" + cboPolicyType.Text + "/" + txtPolicyYear.Text + "-" + txtPolicyNo.Text + "-" + txtPolicyEndorsement.Text;
        //}

        private void setInsuranceTypeOne(InsuranceTypeOne value)
        {
            objInsuranceTypeOne = value;
            txtPolicyNo.Text = value.PolicyNo;

            //User request to chage text format : Woranai 2009-07-20
            //CompulsoryDocNoBase compulsoryBase = ObjectCreater.CreateCompulsoryDocNo();
            //CompulsoryFragment compulsoryFrag = compulsoryBase.GetCompulsoryFragment(value.PolicyNo);
            //string[] content = compulsoryFrag.Prefix.Split('/');

            //txtPolicyPrefix.Text = content[0];
            //cboPolicyType.Text = content[1];
            //txtPolicyYear.Text = content[2];
            //txtPolicyNo.Text = compulsoryFrag.Number;
            //txtPolicyEndorsement.Text = compulsoryFrag.Endorsement;
            //compulsoryBase = null;
        }


        private void callPolicyList()
        {
            try
            {
                objfrmInsuranceTypeOnePolicyList = new frmInsuranceTypeOnePolicyList();
                objfrmInsuranceTypeOnePolicyList.ShowDialog();
                if (objfrmInsuranceTypeOnePolicyList.Selected)
                {
                    setInsuranceTypeOne(objfrmInsuranceTypeOnePolicyList.SelectedInsuranceTypeOnePolicy);
                }
                objfrmInsuranceTypeOnePolicyList = null;
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

        private bool validateData()
        {
            if (objInsuranceTypeOne == null)
            {
                objInsuranceTypeOne = facadeVehicleInsuranceTypeOne.GetInsuranceTypeOne(txtPolicyNo.Text.Trim());
            }

            if (objInsuranceTypeOne == null || txtPolicyNo.Text.Trim() == string.Empty)
            {
                Message(MessageList.Error.E0004, "àÅ¢·Õè¡ÃÁ¸ÃÃÁì");
                txtPolicyNo.Focus();
                return false;
            }
            return true;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmVehicleInsuranceTypeOneEntry(this);
                frmEntry.InitAddAction(objInsuranceTypeOne);
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

        private void updateEvent()
        {
            try
            {
                frmEntry = new FrmVehicleInsuranceTypeOneEntry(this);
                frmEntry.InitEditAction(selectedVehicleInsuranceTypeOne, objInsuranceTypeOne.APeriod);
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
                    if (facadeVehicleInsuranceTypeOne.DeleteInsuranceTypeOneDetail(selectedVehicleInsuranceTypeOne))
                    {
                        if (dtgVehicleInsurance.RowCount > 1)
                        {
                            dtgVehicleInsurance.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgVehicleInsurance.RowCount = 0;
                            enableAmend(false);
                        }

                        bindVehicleInsuranceHeader();
                        mdiParent.RefreshMasterCount();
                    }
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
        #endregion

        #region Public Method
        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
        }

        public override int MasterCount()
        {
            return facadeVehicleInsuranceTypeOne.ObjVehicleInsuranceList.Count;
        }        

        public void InitForm()
        {
            visibleForm(false);
            newObject();
            clearForm();
            gpbInsuranceNo.Enabled = true;

            mdiParent.EnableNewCommand(true);
            mdiParent.EnableRefreshCommand(true);
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;
        }

        public void RefreshForm()
        {
            try
            {
                if (objInsuranceTypeOne != null)
                {
                    visibleForm(true);
                    gpbInsuranceNo.Enabled = false;
                    bindInsuranceHeader();

                    if (facadeVehicleInsuranceTypeOne.DisplayVehicleInsurance(objInsuranceTypeOne))
                    {
                        enableAmend(true);
                        bindForm();
                    }
                    else
                    {
                        enableAmend(false);
                        dtgVehicleInsurance.RowCount = 0;
                    }
                    mdiParent.RefreshMasterCount();
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

            if (isReadonly)
            {
                mniAdd.Enabled = false;
                btnAdd.Enabled = false;
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

        public bool AddRow(VehicleInsuranceTypeOne value)
        {
            if (facadeVehicleInsuranceTypeOne.InsertInsuranceTypeOneDetail(value))
            {
                dtgVehicleInsurance.RowCount++;
                bindVehicleInsuranceTypeOne(dtgVehicleInsurance.RowCount - 1, value);
                bindVehicleInsuranceHeader();
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(VehicleInsuranceTypeOne value)
        {
            if (facadeVehicleInsuranceTypeOne.UpdateInsuranceTypeOneDetail(value))
            {
                bindVehicleInsuranceTypeOne(SelectedRow, value);
                bindVehicleInsuranceHeader();
                return true;
            }
            return false;
        }
        #endregion

        #region Form Event
        private void FrmVehicleInsuranceTypeOne_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;

            if (isCurrent)
            {
                InitForm();
            }
            else
            {
                RefreshForm();
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                RefreshForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void dtgVehicleInsurance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }

        private void txtPolicyNo_DoubleClick(object sender, EventArgs e)
        {
            callPolicyList();
        } 
        #endregion
    }
}

