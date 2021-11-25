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
    public partial class FrmVehicleQuotationList : ChildFormBase, IMDIChildForm
    {
        #region Private
        private VehicleQuotationFacade facadeVehicleQuotation;
        private frmMain mdiParent;
        private const string VEHICLE_QUOTATION_NO = "PTB-Q-";
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

        /// <summary>
        /// Method      : Selected column of datagird by column no.
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="keyField">column of datagrid</param>
        /// <returns></returns>
        private string SelectedKeyField(int keyField)
        {
            return dtgQuotation[keyField, SelectedRow].Value.ToString(); 
        }

        /// <summary>
        /// Function    : Get selected object vehicle quotation in datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 27/10/2008
        /// </summary>
        private VehicleQuotation selectedVehicleQuotation
        {
            get
            {
                if (dtgQuotation.CurrentRow != null)
                {
                    VehicleQuotation vehicleQuotation = new VehicleQuotation();
                    vehicleQuotation.QuotationNo = new DocumentNo(SelectedKey);
                    return vehicleQuotation;
                }
                else
                {
                    return null;
                }
            }

        }

        #endregion

        #region Constructor

        public FrmVehicleQuotationList()
        {
            InitializeComponent();
            facadeVehicleQuotation = new VehicleQuotationFacade();
        }

        #endregion

        #region IMDIChildForm Members

        public override int MasterCount()
        {
            return facadeVehicleQuotation.ObjVehicleQuotationList.Count;
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miQuotation");
        }

        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnablePrintCommand(false);
            MainMenuPrintStatus = false;
            gpbShowData.Enabled = true;

            InitComboxItems();
            enableAmend(false);
            visibleForm(false);
            ClearForm();
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

        /// <summary>
        /// Method      : Set quotation control property for enable or disable
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="value"></param>
        private void enableAmend(bool value)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = value;
            btnDelete.Enabled = value;
        }

        private void visibleForm(bool value)
        {
            dtgQuotation.Visible = value;
            btnAdd.Visible = value;
            btnEdit.Visible = value;
            btnDelete.Visible = value;
        }

        private void ClearForm()
        {
            txtQuotationYY.Text = "";
            txtQuotationMM.Text = "";
            txtQuotationXXX.Text = "";

            cboCustomer.SelectedIndex = 0;
            cboBrand.SelectedIndex = 0;
            cboModel.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Today.Date;
            dtpFromDate.Checked = false;
            dtgQuotation.Rows.Clear();

            gpbShowData.Enabled = true;
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

        #endregion

        #region Private Method

        /// <summary>
        /// Method      : Skip cursor when text changed
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        private void quotationNoChange()
        {
            if (txtQuotationYY.Text.Length == 2 && txtQuotationMM.Text.Length == 2 && txtQuotationXXX.Text.Length == 3)
            {
                formQuotationList();
                //add comment by Aof for pending useful 
                //searchEvent();
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

        /// <summary>
        /// Method      : Validate quotation can edit or not 
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <returns>true if not issue quotation yet</returns>
        private bool canEdit()
        {
            if (SelectedKeyField(6) != "")
            {
                Message(MessageList.Error.E0014, "แก้ไขข้อมูลได้");
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// Method      : Validate quotation can delete or not 
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <returns>true if not issue quotation yet</returns>
        private bool canDelete()
        {
            if (SelectedKeyField(6) != "" || SelectedKeyField(8) != "")
            {
                return false;
            }
            else { return true; }
        }
        
        private void searchEvent()
        {
            gpbShowData.Enabled = false;

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
                aIssueDate = new DateTime(1900,01,01);

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

                    list = facade.SearchQuotation(aCustomer, aBrand, aModel, vehicleQuotation.QuotationNo, aIssueDate);
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
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    visibleForm(true);

                    enableAmend(true);
                    bindFrom(list,list2);
                }
                else
                {
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;

                    Message(MessageList.Error.E0004, " ข้อมูลที่ค้นหา");
                    visibleForm(true);
                    enableAmend(false);
                    dtgQuotation.Rows.Clear();
                    
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

        private void addEvent()
        {
            try
            {
                FrmVehicleQuotationEntry frmEntry = new FrmVehicleQuotationEntry(new VehicleQuotation());
                frmEntry.SaveDataCompleted += new FrmVehicleQuotationEntry.SaveDataCompleteHandler(frmEntry_SaveDataCompleted);
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

        private void editEvent()
        {
            try
            {
                if (selectedVehicleQuotation != null)
                {
                    FrmVehicleQuotationEntry frmEntry = new FrmVehicleQuotationEntry(selectedVehicleQuotation);
                    frmEntry.SaveDataCompleted += new FrmVehicleQuotationEntry.SaveDataCompleteHandler(frmEntry_SaveDataCompleted);
                    frmEntry.ShowDialog();
                }
                else
                {
                    Message(MessageList.Error.E0005, " Vehicle Quotation");
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

        void frmEntry_SaveDataCompleted(object sender, EventArgs e)
        {
            RefreshForm();
            enableAmend(true);
        }

        private void deleteEvent()
        {
            try
            {
                if (canDelete())
                {
                    if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                    {
                        using (VehicleQuotationFacade facade = new VehicleQuotationFacade())
                        {
                            if (selectedVehicleQuotation != null)
                            {
                                if (facade.DeleteVehicleQuotation(selectedVehicleQuotation))
                                {
                                    Message(MessageList.Information.I0001);
                                    RefreshForm();
                                }
                            }
                            else
                            {
                                Message(MessageList.Error.E0005, " Vehicle Calculation");
                            }
                        }
                    }
                }
                else { Message(MessageList.Error.E0014, "ลบข้อมูลได้"); }


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

        /// <summary>
        /// Function    : Bind list of object value to the datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/2008
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list2"></param>
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

        /// <summary>
        /// Function    : Bind object value to the datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/08
        /// </summary>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <param name="value2"></param>
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

        private void formQuotationList()
        {
            VehicleQuotation vehicleQuotation = new VehicleQuotation();
            vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, txtQuotationYY.Text.Trim(), txtQuotationMM.Text.Trim(), txtQuotationXXX.Text.Trim());

            FrmCalculationQuotationList frmCalculationQuotation = new FrmCalculationQuotationList();
            frmCalculationQuotation.IsQuotationAvailable = true;
            frmCalculationQuotation.InitForm(vehicleQuotation);
            frmCalculationQuotation.ShowDialog();

            if (frmCalculationQuotation.Selected)
            {
                if (frmCalculationQuotation.SelectedVehicleQuotation != null)
                {
                    txtQuotationYY.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Year;
                    txtQuotationMM.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Month;
                    txtQuotationXXX.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.No;
                    searchEvent();
                }
            }
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Event Keypress ,Check cahractor for numeric
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsNumericChar(char value)
        {
            switch (value)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                case '\b': return true;
            }
            return false;
        }

        /// <summary>
        /// Function    : The process for add new quotation to database
        /// Author      : Thawatchai B.
        /// Create Date : 07/17/2008
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>true if add row success</returns>
        public bool AddRow(VehicleCalculation vehicleCalculation)
        {
            if (facadeVehicleQuotation.InsertVehicleQuotation(vehicleCalculation))
            {
                RefreshForm();
                enableAmend(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Function    : The process for update existing quotation in database
        /// Author      : Thawatchai B.
        /// Create Date : 07/11/2008
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>true if update row success</returns>
        public bool UpdateRow(VehicleQuotation vehicleQuotation)
        {
            if (facadeVehicleQuotation.UpdateVehicleQuotation(vehicleQuotation))
            {
                RefreshForm();
                enableAmend(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Form Event
        private void frmQuotationList_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtQuotationYY_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtQuotationMM_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtQuotationXXX_DoubleClick(object sender, EventArgs e)
        {
            formQuotationList();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitComboModel((string)cboBrand.SelectedValue);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editEvent();
        }

        private void txtQuotationYY_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void txtQuotationMM_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void txtQuotationXXX_TextChanged(object sender, EventArgs e)
        {
            quotationNoChange();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void dtgQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                editEvent();
            }
        } 

        private void mniAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                addEvent();
            }
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                editEvent();
            }
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                deleteEvent();
            }
        }

        #endregion


    }
}
