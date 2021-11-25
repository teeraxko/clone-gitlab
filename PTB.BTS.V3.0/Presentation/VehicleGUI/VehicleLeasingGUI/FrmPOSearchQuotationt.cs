using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentation.CommonGUI;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Facade.PiFacade;
using Facade.CommonFacade;
using Facade.VehicleFacade.VehicleLeasingFacade;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmPOSearchQuotation : EntryFormBase
    {
        #region Private
        private VehicleQuotationFacade facadeVehicleQuotation;
        private const string VEHICLE_QUOTATION_NO = "PTB-Q-";
        private FrmPurchaseOrderEntry parentForm;
        #endregion

        #region Property
        public VehicleQuotationFacade FacadeVehicleQuotation
        {
            get { return facadeVehicleQuotation; }
        }

        private int SelectedRow
        {
            get { return dtgQuotation.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgQuotation[1, SelectedRow].Value.ToString(); }
        }

        private string SelectedKeyField(int keyField)
        {
            return dtgQuotation[keyField, SelectedRow].Value.ToString(); 
        }

        private DocumentNo selectedVehicleQuotation
        {
            get
            {
                if (dtgQuotation.CurrentRow != null)
                {
                    DocumentNo quotation = new DocumentNo(SelectedKey);
                    return quotation;
                }
                else
                {
                    return null;
                }
            }

        }


        #endregion
        //================== Constructor ============================
        public FrmPOSearchQuotation()
        {
            InitializeComponent();
            facadeVehicleQuotation = new VehicleQuotationFacade();
        }

        public FrmPOSearchQuotation(FrmPurchaseOrderEntry value)
            : base()
        {
            InitializeComponent();
            parentForm = value;
            facadeVehicleQuotation = new VehicleQuotationFacade();
        }


        //================== Form Base ==============================
        #region IMDIChildForm Members

        public int MasterCount()
        {
            return 0;
            //facadeVehicleCalculation.ObjVehicleCalculationList.Count;
        }

        public string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleLeasingCalculation");
        }
        #endregion

        #region IMDIChildFormGUI Members
        public void InitForm()
        {
            InitComboxItems();
            enableAmend(false);
            clearForm();
        }

        public void RefreshForm()
        {
            searchEvent();
        }

        public void PrintForm()
        {

        }

        public void ExitForm()
        {
            this.Close();
        }

        private void enableAmend(bool value)
        {
            btnOK.Enabled = value;
            btnCencel.Enabled = true;
        }

        private void clearForm()
        {
            txtQuotationYY.Text = "";
            txtQuotationMM.Text = "";
            txtQuotationXXX.Text = "";

            cboCustomer.SelectedIndex = 0;
            cboBrand.SelectedIndex = 0;
            cboModel.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Today.Date;
            dtgQuotation.Rows.Clear();
        }

        /// <summary>
        /// Initailize customer and brand combobox 
        /// Author      : Thawatchai B.
        /// Create Date : 07/10/2008
        /// </summary>
        private void InitComboxItems()
        {
            InitComboCustomer();
            InitComboBrand();
            InitComboModel("ZZ");
        }

        /// <summary>
        /// set property for customer combobox
        /// </summary>
        private void InitComboCustomer()
        {
            DataTable customers = EntitiesProvider.CustomerDataTable();
            DataRow customerRow = customers.NewRow();
            customerRow["Customer_Code"] = "ZZ";
            customerRow["English_Name"] = "==All==";
            customerRow["Thai_Name"] = "==ทั้งหมด==";
            customers.Rows.InsertAt(customerRow, 0);
            cboCustomer.DataSource = customers;
        }

        /// <summary>
        /// set property for brand combobox
        /// </summary>
        private void InitComboBrand()
        {
            DataTable brands = EntitiesProvider.BrandDataTable();
            DataRow brandRow = brands.NewRow();
            brandRow["Brand_Code"] = "ZZ";
            brandRow["Brand_English_Name"] = "==All==";
            brandRow["Brand_Thai_Name"] = "==ทั้งหมด==";
            brands.Rows.InsertAt(brandRow, 0);
            cboBrand.DataSource = brands;
        }

        /// <summary>
        /// set property for brand combobox
        /// </summary>
        private void InitComboModel(string brandCode)
        {
            DataTable models = EntitiesProvider.ModelDataTable(brandCode);
            DataRow modelRow = models.NewRow();
            modelRow["Brand_Code"] = brandCode;
            modelRow["Model_Code"] = "ZZZZZ";
            modelRow["Model_English_Name"] = "==All==";
            modelRow["Model_Thai_Name"] = "==ทั้งหมด==";
            models.Rows.InsertAt(modelRow, 0);
            cboModel.DataSource = models;
        }

        private void visibleForm(bool value)
        {
            dtgQuotation.Visible = value;
            btnOK.Visible = value;
            btnCencel.Visible = value;
        }

        #endregion

        private void quotationNoChange()
        {
            if (txtQuotationYY.Text.Length == 2 && txtQuotationMM.Text.Length == 2 && txtQuotationXXX.Text.Length == 3)
            {
                //RefreshForm();
            }
            else
            {
                if (txtQuotationYY.Text.Length == 2)
                {
                    if (txtQuotationMM.Text.Length == 2)
                    {
                        txtQuotationXXX.Focus();
                    }
                    else
                    {
                        txtQuotationMM.Focus();
                    }
                }
                else
                {
                    txtQuotationYY.Focus();
                }
            }
        }

        private bool canDelete()
        {
            if (SelectedKeyField(6) != "")
            {
                return false;
            }
            else { return true; }
        }

        //================== Process Event ===============================
        private void searchEvent()
        {
            Customer aCustomer = new Customer();
            Model aModel = new Model();
            Brand aBrand = new Brand();
            if (cboCustomer.SelectedIndex == -1 || cboCustomer.SelectedIndex == 0)
            {
                aCustomer = null;
            }
            else
            {
                aCustomer.Code = (string)cboCustomer.SelectedValue;
            }
            if (cboBrand.SelectedIndex == 0)
            {
                aBrand = null;
            }
            else
            {
                aBrand.Code = (string)cboBrand.SelectedValue;
            }
            if (cboModel.SelectedIndex == 0)
            {
                aModel = null;
            }
            else
            {
                aModel.Code = (string)cboModel.SelectedValue;
            }
            DateTime aIssueDate;
            if (dtpFromDate.Checked)
                aIssueDate = dtpFromDate.Value.Date;
            else
                aIssueDate = new DateTime(1900, 01, 01);

            try
            {
                List<VehicleQuotation> list = null;
                List<VehicleCalculation> list2 = null;
                VehicleQuotation vehicleQuotation = new VehicleQuotation();
                string quotYY, quotMM, quotXXX;
                quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
                quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
                quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
                vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

                using (VehicleQuotationFacade facade = new VehicleQuotationFacade())
                {

                    list = facade.SearchQuotationPurchase(vehicleQuotation.QuotationNo, aIssueDate);
                    list2 = new List<VehicleCalculation>();
                    foreach (VehicleQuotation entity in list)
                    {
                        VehicleCalculation vehicleCalculation = new VehicleCalculation();
                        using (VehicleCalculationFacade facade2 = new VehicleCalculationFacade())
                        {
                            vehicleCalculation = facade2.GetVehicleConditionByQuotationNo(entity.QuotationNo, aCustomer,aBrand,aModel);
                        }
                        if (vehicleCalculation.Customer != null)
                        {
                            list2.Add(vehicleCalculation);
                        }
                    }
                }

                if (list.Count > 0 && list2.Count > 0)
                {
                    enableAmend(true);
                    bindFrom(list,list2);
                }
                else
                {
                    enableAmend(false);
                    dtgQuotation.Rows.Clear();
                    Message(MessageList.Error.E0004, " ข้อมูลที่ค้นหา");
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

        private void selectedEvent()
        {
            try
            {
                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    VehicleCalculation vehicleCalculation = new VehicleCalculation();
                    if (selectedVehicleQuotation != null)
                    {
                        vehicleCalculation = facade.GetVehicleSearchConditionByQuotationNo(selectedVehicleQuotation);
                        vehicleCalculation.Quotation.QuotationNo = selectedVehicleQuotation;
                        parentForm.SelectedVehicleQuotation(vehicleCalculation);
                        this.Close();
                    }
                    else
                    {
                        Message(MessageList.Error.E0005, " Vehicle Quotation");
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

        private void bindFrom(List<VehicleQuotation> list, List<VehicleCalculation> list2)
        {
            dtgQuotation.Rows.Clear();

            if (list.Count > 0 && list2.Count > 0)
            {
                dtgQuotation.RowCount = list.Count;

                for (int i = 0; i < list.Count; i++)
                {
                    bindQuotation(i, list[i], list2[i]);
                }
            }
        }

        private void bindQuotation(int row, VehicleQuotation value, VehicleCalculation value2)
        {
            dtgQuotation[0, row].Value = row.ToString();
            dtgQuotation[1, row].Value = value.QuotationNo.ToString();
            dtgQuotation[2, row].Value = value2.Customer.AName.English.ToString();
            dtgQuotation[3, row].Value = value2.Model.ABrand.AName.English.ToString();
            dtgQuotation[4, row].Value = value2.Model.AName.English.ToString();
            dtgQuotation[5, row].Value = value.IsCustomerAccept == true ? "Y" : "N";
            if (value.Purchasing.PurchasNo == null)
            { dtgQuotation[6, row].Value = ""; }
            else
            {
                dtgQuotation[6, row].Value = value.Purchasing.PurchasNo.ToString();
            }
            dtgQuotation[7, row].Value = value.IssueDate.Value.Day + "/" + value.IssueDate.Value.Month + "/" + value.IssueDate.Value.Year;
            if (value.VehicleContract.ContractNo == null)
            {
                dtgQuotation[8, row].Value = "";
            }
            else
            {
                dtgQuotation[8, row].Value = value.VehicleContract.ContractNo.ToString();
            }

        }

 
        //================== Form Event ==================================
        private void frmQuotationList_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void fpiQuotationYY_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
            
        }

        private void fpiQuotationMM_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void fpiQuotationXXX_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitComboModel((string)cboBrand.SelectedValue);
        }

        private void fpiQuotationYY_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void fpiQuotationMM_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void fpiQuotationXXX_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void dtgQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEvent();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selectedEvent();
        }

        private void mniOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Enabled == true)
            {
                selectedEvent();
            }
        }

        private void mniCancel_Click(object sender, EventArgs e)
        {
            if (btnCencel.Enabled == true)
            {
                ExitForm();
            }
        }

        

    }
}
