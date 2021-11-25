using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentation.CommonGUI;

using Entity.VehicleEntities.VehicleLeasing;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.PiFacade;
using Facade.CommonFacade;
using Facade.VehicleFacade.VehicleLeasingFacade;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmCalculationSearch : PresentationBase.CommonGUIBase.ChildFormGUIBase, IMDIChildForm
    {        
        #region Private

        private VehicleCalculationFacade facadeVehicleCalculation;
        private frmMain mdiParent;
        private bool isReadonly = true;
        private FrmCalculationEntry frmEntry;

        #endregion

        #region Property

        /// <summary>
        /// Function    : Get object vehicle calculation facade.
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        public VehicleCalculationFacade FacadeVehicleCalculation
        {
            get { return facadeVehicleCalculation; }
        }

        private int SelectedRow
        {
            get { return dtgVehicleCalculation.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgVehicleCalculation[colCalculationNo.Index, SelectedRow].Value.ToString(); }
        }

        private string SelectedKeyField(int keyField)
        {
            return dtgVehicleCalculation[keyField, SelectedRow].Value.ToString();
        }

        /// <summary>
        /// Function    : Get selected object vehicle calculation in datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        private VehicleCalculation selectedVehicleCalculation
        {
            get
            {
                if (dtgVehicleCalculation.CurrentRow != null)
                {
                    VehicleCalculation vehicleCalculation =  new VehicleCalculation();
                    System.Guid guidCalculationNo = new Guid(SelectedKey);
                    vehicleCalculation.CalculationNo = guidCalculationNo;
                    vehicleCalculation.Quotation = new VehicleQuotation();
                    if (SelectedKeyField(4) != "")
                    {
                        vehicleCalculation.Quotation.QuotationNo = new DocumentNo(SelectedKeyField(4));
                    }
                    else { vehicleCalculation.Quotation.QuotationNo = null; }
                    return vehicleCalculation;
                }
                else
                {
                    return null;
                }
            }
            
        }

        #endregion

        #region Constructor
        public FrmCalculationSearch() : base()
        {
            InitializeComponent();
            facadeVehicleCalculation = new VehicleCalculationFacade();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleLeasingCalculation");
        }
        #endregion

        #region IMDIChildForm Members

        public int MasterCount()
        {
            return facadeVehicleCalculation.ObjVehicleCalculationList.Count;
        }

        public string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleLeasingCalculation");
        }

        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnableDeleteCommand(false);
            MainMenuDeleteStatus = false;
            mdiParent.EnablePrintCommand(false);
            MainMenuPrintStatus = false;

            InitComboxItems();
            enableAmend(false);
            visibleForm(false);
            clearForm();
        }

        public void RefreshForm()
        {
            #region Vehicle Details Condition

            Customer aCustomer = new Customer();
            Model aModel = new Model();
            Brand aBrand = new Brand();

            //customer
            if (cboCustomer.SelectedIndex == -1 || cboCustomer.SelectedIndex == 0)
            {
                aCustomer = null;
            }
            else
            {
                aCustomer.Code = (string)cboCustomer.SelectedValue;
            }
            //brand
            if (cboBrand.SelectedIndex == 0)
            {
                aBrand = null;
            }
            else
            {

                aBrand.Code = (string)cboBrand.SelectedValue;
            }
            //model
            if (cboModel.SelectedIndex == 0)
            {
                aModel = null;
            }
            else
            {
                aModel.Code = (string)cboModel.SelectedValue;
            }

            //Delete color from calculation : woranai 2009/02/18
            //color
            //if (cboColor.SelectedIndex == 0)
            //{
            //    aColor = null;
            //}
            //else
            //{
            //    aColor.Code = (string)cboColor.SelectedValue;
            //}

            #endregion

            #region Quotation No Condition

            string quotYY, quotMM, quotXXX, strQuotationNo;
            quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
            quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
            quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
            DocumentNo quotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

            if (quotYY == "" && quotMM == "" && quotXXX == "")
                strQuotationNo = "";
            else
                strQuotationNo = quotationNo.ToString();

            #endregion

            try
            {
                List<VehicleCalculation> list = null;

                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchCalculation(aCustomer, aBrand, aModel, strQuotationNo);
                }

                if (list.Count > 0)
                {
                    bindForm(list);
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

        public void PrintForm()
        {

        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region Private Method

        private void visibleForm(bool value)
        {
            dtgVehicleCalculation.Visible = value;
            gpbCalculationList.Visible = value;
            btnAdd.Visible = value;
            btnEdit.Visible = value;
            btnDelete.Visible = value;
        }

        private void enableHead(bool value)
        {
            gpbVehicleDetail.Enabled = value;
            gpbShowData.Enabled = value;
        }

        /// <summary>
        /// Function    : Set control property enable or disable
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        /// <param name="value"></param>
        private void enableAmend(bool value)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = value;
            btnDelete.Enabled = value;
        }

        /// <summary>
        /// Function    : Clear form
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        private void clearForm()
        {
            txtPlateNoPrefix.Text = "";
            txtPlateNoRunning.Text = "";

            txtQuotationYY.Text = "";
            txtQuotationMM.Text = "";
            txtQuotationXXX.Text = "";

            cboCustomer.SelectedIndex = 0;
            cboBrand.SelectedIndex = 0;
            cboModel.SelectedIndex = 0;
            //cboColor.SelectedIndex = 0;

            dtgVehicleCalculation.Rows.Clear();
            enableAmend(false);
            enableHead(true);
        }

        /// <summary>
        /// Function    : Bind object value to the datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        /// <param name="row"></param>
        /// <param name="value"></param>
        private void bindVehicleCalculation(int row, VehicleCalculation value)
        {
            dtgVehicleCalculation[colCustomer.Index, row].Value = value.Customer.ShortName.ToString();
            dtgVehicleCalculation[colBrand.Index, row].Value = value.Model.ABrand.AName.English.ToString();
            dtgVehicleCalculation[colModel.Index, row].Value = value.Model.AName.English.ToString();

            //Delete color from calculation : woranai 2009/02/18
            //dtgVehicleCalculation[colColor.Index, row].Value = value.Color.AName.English.ToString();

            if (value.Quotation.QuotationNo == null)
            { 
                dtgVehicleCalculation[colQuotation.Index, row].Value = ""; 
            }
            else
            {
                dtgVehicleCalculation[colQuotation.Index, row].Value = GUIFunction.GetString(value.Quotation.QuotationNo.ToString()); 
            }

            dtgVehicleCalculation[colIssueDate.Index, row].Value = value.IssueDate.Date;
            dtgVehicleCalculation[colCalculationNo.Index, row].Value = value.CalculationNo.ToString();
        }

        /// <summary>
        /// Function    : Bind list of object value to the datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        /// <param name="list"></param>
        private void bindForm(List<VehicleCalculation> list)
        {
            if (list.Count > 0)
            {
                dtgVehicleCalculation.RowCount = list.Count;

                int rowIndex = 0;

                foreach (VehicleCalculation entity in list)
                {
                    bindVehicleCalculation(rowIndex++, entity);
                }

                enableAmend(true);

                mdiParent.EnableNewCommand(true);
                MainMenuNewStatus = true;
                mdiParent.EnableDeleteCommand(false);
                MainMenuDeleteStatus = false;
                mdiParent.EnableRefreshCommand(true);
                MainMenuRefreshStatus = true;
                mdiParent.EnablePrintCommand(false);
                MainMenuPrintStatus = false;

                visibleForm(true);
            }
        }

        private bool validateUpdate()
        {
            return true;
        }

        /// <summary>
        /// Function    : Check text length for skip cursor
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        private void quotationNoChange()
        {
            if (txtQuotationYY.Text.Length == 2 && txtQuotationMM.Text.Length == 2 && txtQuotationXXX.Text.Length == 3)
            {
                SearchEvent();
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
        /// Function    : Validate calculation, can't delete if it has quotation issued.
        /// Author      : Thawatchai B.
        /// Create Date : 02/10/2008
        /// </summary>
        /// <returns>true if quotation no. in datagrid is null</returns>
        private bool canDelete()
        {
            if (SelectedKeyField(4) != "")
            {
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// Function    : Validate plate no prefix
        /// Author      : Thawatchai B.
        /// Create Date : 03/10/2008
        /// </summary>
        /// <returns>true if plate no prefix text box is not empty</returns>
        private bool validate1()
        {
            if (txtPlateNoPrefix.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "เลขทะเบียนรถ");
                txtPlateNoPrefix.Text = "";
                txtPlateNoPrefix.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Function    : Validate plate no running
        /// Author      : Thawatchai B.
        /// Create Date : 03/10/2008
        /// </summary>
        /// <returns>true if plate no running text box is not empty</returns>
        private bool validate2()
        {
            if (txtPlateNoRunning.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "เลขทะเบียนรถ");
                txtPlateNoRunning.Text = "";
                txtPlateNoRunning.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Initailize customer and brand combobox 
        /// Author      : Thawatchai B.
        /// Create Date : 01/10/2008
        /// </summary>
        private void InitComboxItems()
        {
            InitComboCustomer();
            InitComboBrand();
            InitComboModel("ZZ");
            InitComboColor();
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

        /// <summary>
        /// set property for color combobox
        /// Delete color from calcualtion : woranai 2009/02/18
        /// </summary>
        private void InitComboColor()
        {
            //DataTable colors = EntitiesProvider.ColorDataTable();
            //DataRow colorRow = colors.NewRow();
            //colorRow["Color_Code"] = "ZZ";
            //colorRow["English_Color_Name"] = "==All==";
            //colorRow["Thai_Color_Name"] = "==ทั้งหมด==";
            //colors.Rows.InsertAt(colorRow, 0);
            //cboColor.DataSource = colors;
        }

        private void SetCondition()
        { 
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
        /// Function    : Show form calculation entry for add new calculation
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void AddEvent()
        {
            try
            {
                frmEntry = new FrmCalculationEntry(this);
                frmEntry.InitAddAction();
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

        /// <summary>
        /// Function    : Get calculation info for search by condition
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void SearchEvent()
        {
            #region Vehicle Details Condition

            Customer aCustomer = new Customer();
            Model aModel = new Model();
            Brand aBrand = new Brand();
            Color aColor = new Color();

            //customer
            if (cboCustomer.SelectedIndex == -1 || cboCustomer.SelectedIndex == 0)
            {
                aCustomer = null;
            }
            else
            {
                aCustomer.Code = (string)cboCustomer.SelectedValue;
            }

            //brand
            if (cboBrand.SelectedIndex == 0)
            {
                aBrand = null;
            }
            else
            {

                aBrand.Code = (string)cboBrand.SelectedValue;
            }

            //model
            if (cboModel.SelectedIndex == 0)
            {
                aModel = null;
            }
            else
            {
                aModel.Code = (string)cboModel.SelectedValue;
            }

            aColor = null;

            //Delete color from calculation : woranai 2009/02/18
            //color
            //if (cboColor.SelectedIndex == 0)
            //{
            //    aColor = null;
            //}
            //else
            //{
            //    aColor.Code = (string)cboColor.SelectedValue;
            //}

            #endregion

            #region Quotation No Condition

            string quotYY, quotMM, quotXXX,strQuotationNo;
            quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
            quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
            quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
            DocumentNo quotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

            if (quotYY == "" && quotMM == "" && quotXXX == "")
                strQuotationNo = "";
            else
                strQuotationNo = quotationNo.ToString();

            #endregion

            enableHead(false);

            try
            {
                List<VehicleCalculation> list = null;
                
                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchCalculation(aCustomer, aBrand, aModel, strQuotationNo);
                }

                if (list.Count > 0)
                {
                    bindForm(list);
                }
                else
                {
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableDeleteCommand(false);
                    MainMenuDeleteStatus = false;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    mdiParent.EnablePrintCommand(false);
                    MainMenuPrintStatus = false;

                    enableAmend(false);
                    visibleForm(true);
                    dtgVehicleCalculation.Rows.Clear();
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

        /// <summary>
        /// Function    : Delete calculation from datagrid
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void DeleteEvent()
        {
            try
            {
                if (canDelete())
                {
                    if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                    {
                        using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                        {
                            if (selectedVehicleCalculation != null)
                            {
                                facade.DeleteVehicleCalculation(selectedVehicleCalculation);
                                Message(MessageList.Information.I0001);
                                RefreshForm();
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
        /// Function    : Show form calculation entry for edit existing calculation
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void EditEvent()
        {
            try
            {
                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                    {
                        if (selectedVehicleCalculation != null)
                        {
                            frmEntry = new FrmCalculationEntry(this);
                            frmEntry.InitEditAction(selectedVehicleCalculation);
				            frmEntry.ShowDialog();                          
                        }
                        else
                        {
                            Message(MessageList.Error.E0005, " Vehicle Calculation");
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

        /// <summary>
        /// Function    : The process for add new calculation to database
        /// Author      : Thawatchai B.
        /// Create Date : 06/10/2008
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>true if add row success</returns>
        public string AddRow(VehicleCalculation vehicleCalculation)
        {
            if (facadeVehicleCalculation.InsertVehicleCalculation(vehicleCalculation))
            {
                RefreshForm();
                enableAmend(true);
                return vehicleCalculation.CalculationNo.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Function    : The process for update existing calculation in database
        /// Author      : Thawatchai B.
        /// Create Date : 06/10/2008
        /// </summary>
        /// <param name="vehicleCalculation"></param>
        /// <returns>true if update row success</returns>
        public bool UpdateRow(VehicleCalculation vehicleCalculation)
        {
            if (facadeVehicleCalculation.UpdateVehicleCalculation(vehicleCalculation))
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
        /// Function    : The process for search calculation by plate no condition
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void SearchConditionByPlateNo(string plateNoPrefix, string plateNoRunning)
        {
            try
            {
                enableHead(false);

                List<VehicleCalculation> list = null;

                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchConditionByPlateNo(plateNoPrefix, plateNoRunning);
                }

                if (list.Count > 0)
                {
                    bindForm(list);
                }
                else
                {
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableDeleteCommand(false);
                    MainMenuDeleteStatus = false;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    mdiParent.EnablePrintCommand(false);
                    MainMenuPrintStatus = false;

                    visibleForm(false);
                    enableAmend(false);
                    Message(MessageList.Error.E0004, " ข้อมูลที่ค้นหา");
                    dtgVehicleCalculation.Rows.Clear();
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

        /// <summary>
        /// Function    : The process for search calculation by quotation no condition
        /// Author      : Thawatchai B.
        /// Create Date : 04/10/2008
        /// </summary>
        public void SearchConditionByQuotationNo(string quotationYY, string quotationMM, string quotationXXX )
        {
            try
            {
                List<VehicleCalculation> list = null;

                VehicleQuotation vehicleQuotation = new VehicleQuotation();
                string quotYY,quotMM,quotXXX;
                quotYY = (quotationYY == "" ? "" : quotationYY);
                quotMM = (quotationMM == "" ? "" : quotationMM);
                quotXXX = (quotationXXX == "" ? "" : quotationXXX); 
                vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE,quotYY,quotMM,quotXXX);

                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchConditionListByQuotationNo(vehicleQuotation.QuotationNo);
                }

                if (list.Count > 0)
                {
                    bindForm(list);
                }
                else
                {
                    mdiParent.EnableNewCommand(true);
                    MainMenuNewStatus = true;
                    mdiParent.EnableDeleteCommand(false);
                    MainMenuDeleteStatus = false;
                    mdiParent.EnableRefreshCommand(true);
                    MainMenuRefreshStatus = true;
                    mdiParent.EnablePrintCommand(false);
                    MainMenuPrintStatus = false;

                    visibleForm(false);
                    enableAmend(false);
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

        #endregion

        #region Form Event

        private void FrmCalculationSearch_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitComboModel((string)cboBrand.SelectedValue);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void txtPlateNoPrefix_TextChanged(object sender, EventArgs e)
        {
            if (txtPlateNoPrefix.Text.Length == txtPlateNoPrefix.MaxLength)
            {
                txtPlateNoRunning.Focus();
            }
        }

        private void txtPlateNoRunning_TextChanged(object sender, EventArgs e)
        {
            if (txtPlateNoRunning.Text.Length == 4)
            {
                SearchConditionByPlateNo(txtPlateNoPrefix.Text, txtPlateNoRunning.Text);
            }
        }

        private void txtPlateNoRunning_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtPlateNoPrefix_DoubleClick(object sender, EventArgs e)
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
            dialogVehicleList.ConditionPlateRunningNo = txtPlateNoRunning.Text;
            dialogVehicleList.ConditionPlatePrefix = txtPlateNoPrefix.Text;
            dialogVehicleList.IsVehicleCalculation = true;
            dialogVehicleList.ShowDialog();
            if (dialogVehicleList.Selected)
            {
                txtPlateNoPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
                txtPlateNoRunning.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;
            }
        }

        private void txtPlateNoRunning_DoubleClick(object sender, EventArgs e)
        {
            
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
            dialogVehicleList.ConditionPlateRunningNo = txtPlateNoRunning.Text;
            dialogVehicleList.ConditionPlatePrefix = txtPlateNoPrefix.Text;
            dialogVehicleList.IsVehicleCalculation = true;
            dialogVehicleList.ShowDialog();
            if (dialogVehicleList.Selected)
            {
                txtPlateNoPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
                txtPlateNoRunning.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;
            }
        }

        private void txtQuotationYY_DoubleClick(object sender, EventArgs e)
        {
            VehicleQuotation vehicleQuotation = new VehicleQuotation();
            string quotYY, quotMM, quotXXX;
            quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
            quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
            quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
            vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

            FrmCalculationQuotationList frmCalculationQuotation = new FrmCalculationQuotationList();
            frmCalculationQuotation.IsQuotationAvailable = true;
            frmCalculationQuotation.InitForm(vehicleQuotation);
            frmCalculationQuotation.ShowDialog();

            if (frmCalculationQuotation.Selected)
            {
                txtQuotationYY.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Year;
                txtQuotationMM.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Month;
                txtQuotationXXX.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.No;
            }
        }

        private void txtQuotationMM_DoubleClick(object sender, EventArgs e)
        {
            VehicleQuotation vehicleQuotation = new VehicleQuotation();
            string quotYY, quotMM, quotXXX;
            quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
            quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
            quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
            vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

            FrmCalculationQuotationList frmCalculationQuotation = new FrmCalculationQuotationList();
            frmCalculationQuotation.IsQuotationAvailable = true;
            frmCalculationQuotation.InitForm(vehicleQuotation);
            frmCalculationQuotation.ShowDialog();

            if (frmCalculationQuotation.Selected)
            {
                txtQuotationYY.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Year;
                txtQuotationMM.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Month;
                txtQuotationXXX.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.No;
            }
        }

        private void txtQuotationXXX_DoubleClick(object sender, EventArgs e)
        {
            VehicleQuotation vehicleQuotation = new VehicleQuotation();
            string quotYY, quotMM, quotXXX;
            quotYY = (txtQuotationYY.Text == "" ? "" : txtQuotationYY.Text);
            quotMM = (txtQuotationMM.Text == "" ? "" : txtQuotationMM.Text);
            quotXXX = (txtQuotationXXX.Text == "" ? "" : txtQuotationXXX.Text);
            vehicleQuotation.QuotationNo = new DocumentNo(DOCUMENT_TYPE.QUOTATION_VEHICLE, quotYY, quotMM, quotXXX);

            FrmCalculationQuotationList frmCalculationQuotation = new FrmCalculationQuotationList();
            frmCalculationQuotation.IsQuotationAvailable = true;
            frmCalculationQuotation.InitForm(vehicleQuotation);
            frmCalculationQuotation.ShowDialog();

            if (frmCalculationQuotation.Selected)
            {
                txtQuotationYY.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Year;
                txtQuotationMM.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.Month;
                txtQuotationXXX.Text = frmCalculationQuotation.SelectedVehicleQuotation.QuotationNo.No;
            }
        }

        private void txtQuotationXXX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtQuotationMM_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtQuotationYY_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
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

        private void dtgVehicleCalculation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled == true)
            {
                AddEvent();
            }
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled == true)
            {
                EditEvent();
            }
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled == true)
            {
                DeleteEvent();
            }
        }
        #endregion
    }
}
