using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;

using Facade.VehicleFacade.VehicleLeasingFacade;
using Entity.VehicleEntities.VehicleLeasing;
using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmQuotationSearchCalculation : EntryFormBase
    {
        #region Private
        private VehicleCalculationFacade facadeVehicleCalculation = new VehicleCalculationFacade();
        #endregion

        #region Property
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
            get { return dtgVehicleCalculation[6, SelectedRow].Value.ToString(); }
        }

        private VehicleCalculation selectedVehicleCalculation
        {
            get
            {
                if (dtgVehicleCalculation.CurrentRow != null)
                {
                    VehicleCalculation vehicleCalculation = new VehicleCalculation();
                    System.Guid g = new Guid(SelectedKey);
                    vehicleCalculation.CalculationNo = g;
                    return vehicleCalculation;
                }
                else
                {
                    return null;
                }
            }

        }


        #endregion

        public event FrmQuotationSearchCalculationEventHandler SelectFinished;
        public event EventHandler SelectCanceled;

        #region Constructor
        public FrmQuotationSearchCalculation()
            : base()
        {
            InitializeComponent();
        }
        #endregion

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
            visibleForm(false);
            enableAmend(false);
        }

        public void RefreshForm()
        {
            clearForm();

            Customer aCustomer = new Customer();
            Model aModel = new Model();
            Brand aBrand = new Brand();
            Color aColor = new Color();
            //customer
            aCustomer = null;
            //brand
            aBrand = null;
            //model
            aModel = null;
            //color
            aColor = null;

            try
            {
                List<VehicleCalculation> list = null;

                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchCalculationQuotation(aCustomer, aBrand, aModel);
                }

                if (list.Count > 0)
                {
                    enableAmend(true);
                    bindForm(list);
                }
                else
                {
                    enableAmend(false);
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

        public void PrintForm()
        {

        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        //=============================== Private Method ================================	
        private void enableAmend(bool value)
        {
            btnOK.Enabled = value;
            btnCancel.Enabled = true;
        }

        private void clearForm()
        {
            dtgVehicleCalculation.RowCount = 0;
            enableAmend(false);
        }

        private void visibleForm(bool value)
        {
            dtgVehicleCalculation.Visible = value;
            btnOK.Visible = value;
            btnCancel.Visible = value;
        }

        private void bindVehicleCalculation(int row, VehicleCalculation value)
        {
            dtgVehicleCalculation.Rows[row].Tag = value;
            dtgVehicleCalculation[0, row].Value = value.Customer.ShortName.ToString();
            dtgVehicleCalculation[1, row].Value = value.Model.ABrand.AName.English.ToString();
            dtgVehicleCalculation[2, row].Value = value.Model.AName.English.ToString();

            //Delete color from calculation : woranai 2009/02/18
            //dtgVehicleCalculation[3, row].Value = value.Color.AName.English.ToString();

            if (value.Quotation.QuotationNo == null)
            {
                dtgVehicleCalculation[4, row].Value = string.Empty; ; 
            }
            else
            {
                dtgVehicleCalculation[4, row].Value = GUIFunction.GetString(value.Quotation.QuotationNo.ToString());
            }

            dtgVehicleCalculation[5, row].Value = value.IssueDate.Date.Day + "/" + value.IssueDate.Date.Month + "/" + value.IssueDate.Date.Year;
            dtgVehicleCalculation[6, row].Value = value.CalculationNo.ToString();
        }

        private void bindForm(List<VehicleCalculation> list)
        {
            dtgVehicleCalculation.Rows.Clear();

            if (list.Count > 0)
            {
                dtgVehicleCalculation.RowCount = list.Count;
                int rowIndex = 0;

                foreach (VehicleCalculation entity in list)
                {
                    bindVehicleCalculation(rowIndex++, entity);
                }


            }
        }

        //=================================   Base Event   ================================
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
        /// Delete color from calculation : woranai 2009/02/18
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

        private void searchEvent()
        {
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
            aColor = null;

            try
            {
                List<VehicleCalculation> list = null;

                using (VehicleCalculationFacade facade = new VehicleCalculationFacade())
                {
                    list = facade.GetVehicleSearchCalculationQuotation(aCustomer, aBrand, aModel);
                }

                if (list.Count > 0)
                {
                    enableAmend(true);
                    visibleForm(true);
                    bindForm(list);
                }
                else
                {
                    enableAmend(false);
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

        private void Selected(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                VehicleCalculation result = (VehicleCalculation)dtgVehicleCalculation.Rows[rowIndex].Tag;
                OnSelectFinished(new FrmQuotationSearchCalculationEventArgs(result));
                this.Close();
            }
        }

        private void OnSelectFinished(FrmQuotationSearchCalculationEventArgs e)
        {
            if (SelectFinished != null)
            {
                SelectFinished(this, e);
            }
        }

        private void OnSelectCanceled(EventArgs e)
        {
            if (SelectCanceled != null)
            {
                SelectCanceled(this, e);
            }
        }

        //=================================    Event   ================================
        private void frmCalculationSearch_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitComboModel((string)cboBrand.SelectedValue);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Selected(dtgVehicleCalculation.CurrentRow.Index);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void dtgVehicleCalculation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selected(e.RowIndex);
        }

        private void mniOK_Click(object sender, EventArgs e)
        {
            Selected(dtgVehicleCalculation.CurrentRow.Index);
        }

        private void mniCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled == true)
            {
                ExitForm();
            }
        }

        private void dtgVehicleCalculation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public delegate void FrmQuotationSearchCalculationEventHandler(object sender, FrmQuotationSearchCalculationEventArgs e);
    public class FrmQuotationSearchCalculationEventArgs : EventArgs
    {
        public FrmQuotationSearchCalculationEventArgs(VehicleCalculation calculation)
        {
            _calculation = calculation;
        }
        private VehicleCalculation _calculation;
        public VehicleCalculation VehicleCalculation { get { return _calculation; } }
    }
}
