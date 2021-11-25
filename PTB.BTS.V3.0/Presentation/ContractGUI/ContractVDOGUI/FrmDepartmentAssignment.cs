using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entity.AttendanceEntities;
using Entity.Constants;
using Entity.ContractEntities;
using ictus.Framework.ASC.Entity.DNF20;
using Facade.ContractFacade;
using Presentation.CommonGUI;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI.ContractVDOGUI
{
    public partial class FrmDepartmentAssignment : FormBase
    {

        #region Declaration

        // === Delegate/Event

        public delegate void FinishAssignmentDepartmentEventHandler(object sender, List<ContractDepartmentAssignment> e);
        public event FinishAssignmentDepartmentEventHandler AssignmentDepartmentFinished;

        // === Constants ===

        private const int COLUMN_INDEX_FROM_DATE = 0;
        private const int COLUMN_INDEX_TO_DATE = 1;
        private const int COLUMN_INDEX_DEPARTMENT = 2;
        private const int COLUMN_INDEX_HIERER = 3;
        private const int COLUMN_INDEX_DEPARTMENT_CODE = 4;

        private const string TITLE_RESET_ASSING_MODE = "คลิ๊กขวาที่ตารางเพื่อทำการเพิ่ม แก้ไข ลบ ข้อมูล";
        private const string TITLE_ADD_ASSING_MODE = "เพิ่มการกำหนดฝ่ายลูกค้าใหม่";
        private const string TITLE_UPDATE_ASSING_MODE = "แก้ไขการกำหนดฝ่ายลูกค้า";

        private Color COLOR_RESET_ASSING_MODE = Color.Black;
        private Color COLOR_ADD_ASSING_MODE = Color.Red;
        private Color COLOR_UPDATE_ASSING_MODE = Color.Blue;

        // === Property variables ===

        private string currentContractNo;
        private string currentCustomerCode;
        private string defaultDepartmentCode;

        private DateTime currentContractStartDate;
        private DateTime currentContractEndDate;

        // === Global variables ===

        private int currentDeletingRowIndex;
        private List<ContractDepartmentAssignment> assignedDepartmentDataSource;
        private Customer currentCustomer;
        private CustomerDepartment defaultDepartment;
        private ContractBase currentContract;
        private EntryMode entryMode;
        private EntryMode contractMode;
        private ContractDepartmentAssignment currentAssignedDepartment;
        private ContractDepartmentAssignment currentDeletingObject;
        private ContractDepartmentAssignment oldAssignedDepartment;
        private ContractDepartmentAssignmentFacade facade;

        #endregion

        #region Properties

        public string CurrentContractNo
        {
            set
            {
                this.currentContractNo = value;
            }
        }
        public string CurrentCustomerCode
        {
            set
            {
                this.currentCustomerCode = value;
            }
        }
        public string DefaultDepartmentCode
        {
            set
            {
                this.defaultDepartmentCode = value;
            }
        }
        public DateTime CurrentContractStartDate
        {
            set
            {
                this.currentContractStartDate = value;
            }
        }
        public DateTime CurrentContractEndDate
        {
            set
            {
                this.currentContractEndDate = value;
            }
        }
        public Customer CurrentCustomer
        {
            set
            {
                this.currentCustomer = value;
            }
        }
        public CustomerDepartment DefaultDepartment
        {
            set
            {
                this.defaultDepartment = value;
            }
        }
        public ContractBase CurrentContract
        {
            set
            {
                this.currentContract = value;
            }
        }
        public EntryMode ContractMode
        {
            set
            {
                this.contractMode = value;
            }
        }

        #endregion

        #region Constructors

        public FrmDepartmentAssignment():base()
        {
            InitializeComponent();

            this.initializeControlProperties();
            this.initialGlobalVariables();
            this.moveToResetEntryMode();
        }

        #endregion

        #region Form Events

        private void FrmDepartmentAssignment_Load(object sender, EventArgs e)
        {
            ArrayList departmentDataSource = this.LoadDepartment(this.currentCustomer);
            this.BindDepartmentList(departmentDataSource);

            switch (this.contractMode)
            {
                case EntryMode.Add:

                    if (this.assignedDepartmentDataSource == null)
                        this.initializeDataList();

                    break;

                case EntryMode.Update:

                    this.LoadDataList();

                    break;
            }
            
            this.bindDataList();

            this.setControlOnNewMode();
        }

        #endregion

        #region Control Events

        private void btnSaveEntryData_Click(object sender, EventArgs e)
        {
            if (this.entryMode == EntryMode.Update)
            {
                this.oldAssignedDepartment = this.currentAssignedDepartment;
            }

            ContractDepartmentAssignment saveEntity = this.GetContractDepartmentAssignmentEntry();

            if (this.validEntryData())
            {
                this.onSaveEntryData(saveEntity);
                this.bindDataList();
                this.selectLastestProcessGridRow(saveEntity);

                //=== set to add mode ===
                this.moveToResetEntryMode();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //=== set to reset mode ===
            this.moveToResetEntryMode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isClose = true;
            bool valid = this.validateSaveDataList();

            if (valid)
            {
                // save data to data base when only contract mode is update
                switch (this.contractMode)
                {
                    case EntryMode.Update:
                        isClose = this.onSaveDataList();

                        break;
                }

                if (isClose)
                {
                    this.AssignmentDepartmentFinished(this, this.assignedDepartmentDataSource);
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            this.moveToAddEntryMode();
            this.setControlOnNewMode();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvDepartment.SelectedCells.Count>0)
            {
                DataGridViewCell selectedCell = this.dgvDepartment.SelectedCells[0];
                DataGridViewCellEventArgs eventArgsCell = new DataGridViewCellEventArgs(selectedCell.ColumnIndex,selectedCell.RowIndex);

                this.dgvDepartment_CellDoubleClick(this.dgvDepartment, eventArgsCell);
            }
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            // === clear entry mode ===

            this.moveToResetEntryMode();


            // === delete entry data ===

            if (this.dgvDepartment.SelectedRows.Count > 0)
            {
                this.currentDeletingRowIndex = this.dgvDepartment.SelectedRows[0].Index;

                DataGridViewRow gridRow = this.dgvDepartment.Rows[this.currentDeletingRowIndex];

                DataGridViewCell gridCell = gridRow.Cells[COLUMN_INDEX_FROM_DATE];
                DateTime fromDate = Convert.ToDateTime(gridCell.Value);

                gridCell = gridRow.Cells[COLUMN_INDEX_TO_DATE];
                DateTime toDate = Convert.ToDateTime(gridCell.Value);

                gridCell = gridRow.Cells[COLUMN_INDEX_DEPARTMENT];
                string departmentCode = gridCell.Value.ToString();

                ContractDepartmentAssignment entityCondition = new ContractDepartmentAssignment();
                entityCondition.Contract = this.currentContract;
                entityCondition.AssignPeriod = new TimePeriod();
                entityCondition.AssignPeriod.From = fromDate;
                entityCondition.AssignPeriod.To = toDate;

                List<ContractDepartmentAssignment> list = this.assignedDepartmentDataSource;

                using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
                {
                    this.currentDeletingObject = facade.GetSingleOrDefaultByKey(list, entityCondition);
                }

                this.onDeleteEntry();
            }
        }

        private void dgvDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = this.dgvDepartment.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewRow dblClickedRow = this.dgvDepartment.Rows[e.RowIndex];

            DateTime fromDate = Convert.ToDateTime(dblClickedRow.Cells[COLUMN_INDEX_FROM_DATE].Value);
            DateTime toDate = Convert.ToDateTime(dblClickedRow.Cells[COLUMN_INDEX_TO_DATE].Value);
            string shortDepartmentName = dblClickedRow.Cells[COLUMN_INDEX_DEPARTMENT_CODE].Value.ToString();
            string hiererName = (dblClickedRow.Cells[COLUMN_INDEX_HIERER].Value == null) ? null : dblClickedRow.Cells[COLUMN_INDEX_HIERER].Value.ToString();
                
            this.moveToUpdateEntryMode(fromDate,toDate,shortDepartmentName,hiererName);
        }

        #endregion

        #region Control Methods

        /// <summary>
        /// Initialize properties of controls.
        /// </summary>
        private void initializeControlProperties()
        {
            // dgvDepartment properties
            this.dgvDepartment.AutoGenerateColumns = false;
            this.dgvDepartment.Columns[COLUMN_INDEX_DEPARTMENT].DataPropertyName = ContractDepartmentAssignment.DataPropertyName.DEPARTMENT_SHORT_NAME;
            this.dgvDepartment.Columns[COLUMN_INDEX_FROM_DATE].DataPropertyName = ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE;
            this.dgvDepartment.Columns[COLUMN_INDEX_TO_DATE].DataPropertyName = ContractDepartmentAssignment.DataPropertyName.ASSIGN_TO_DATE;
            this.dgvDepartment.Columns[COLUMN_INDEX_HIERER].DataPropertyName = ContractDepartmentAssignment.DataPropertyName.HIRER_NAME;
            this.dgvDepartment.Columns[COLUMN_INDEX_DEPARTMENT_CODE].DataPropertyName = ContractDepartmentAssignment.DataPropertyName.DEPARTMENT_CODE;

            this.lblAssignModeTitle.Text = TITLE_ADD_ASSING_MODE;
            this.lblAssignModeTitle.ForeColor = COLOR_ADD_ASSING_MODE;
        }

        /// <summary>
        /// Bind list of data to grid
        /// </summary>
        private void bindDataList()
        {
            BindingSource bindingSource = new BindingSource();
            if (this.assignedDepartmentDataSource != null)
            {
                bindingSource.DataSource = this.assignedDepartmentDataSource.Where(a => a.EntityState != EntityState.Deleted);
            }
            else
            {
                bindingSource.DataSource = null;
            }

            this.dgvDepartment.DataSource = bindingSource;
            this.sortDataList(ContractDepartmentAssignment.DataPropertyName.ASSIGN_FROM_DATE);
        }

        /// <summary>
        /// Bind contract department assignment from object to control
        /// </summary>
        private void bindEntryData()
        {
            this.entryMode = EntryMode.Update;
            this.lblAssignModeTitle.Text = TITLE_UPDATE_ASSING_MODE;
            this.lblAssignModeTitle.ForeColor = COLOR_UPDATE_ASSING_MODE;

            this.dtpFrom.Value = this.currentAssignedDepartment.AssignPeriod.From;
            this.dtpTo.Value = this.currentAssignedDepartment.AssignPeriod.To;
            this.txtHirerName.Text = this.currentAssignedDepartment.HirerName;
            this.selectDepartment(this.currentAssignedDepartment.AssignDepartment.Code);

            this.enableControlOnEditMode();

            // === set control properties ===
            this.cboDepartment.Focus();
        }

        /// <summary>
        /// Disable control on edit mode
        /// </summary>
        private void enableControlOnEditMode()
        {
            this.dtpFrom.Enabled = false;
            this.dtpTo.Enabled = false;
            this.cboDepartment.Enabled = true;
            this.txtHirerName.Enabled = true;
            this.btnSaveEntryData.Enabled = true;
            this.btnCancelEntryDate.Enabled = true;
        }

        /// <summary>
        /// Enable control when new entry mode
        /// </summary>
        private void enableControlOnNewMode()
        {
            this.dtpFrom.Enabled = true;
            this.dtpTo.Enabled = true;
            this.cboDepartment.Enabled = true;
            this.txtHirerName.Enabled = true;
            this.btnSaveEntryData.Enabled = true;
            this.btnCancelEntryDate.Enabled = true;
        }

        /// <summary>
        /// Enable control when reset entry mode
        /// </summary>
        private void enableControlOnResetMode()
        {
            this.dtpFrom.Enabled = false;
            this.dtpTo.Enabled = false;
            this.cboDepartment.Enabled = false;
            this.txtHirerName.Enabled = false;
            this.btnSaveEntryData.Enabled = false;
            this.btnCancelEntryDate.Enabled = false;
        }

        /// <summary>
        /// Sort grid by specific column
        /// </summary>
        /// <param name="columnName"></param>
        private void sortDataList(string columnName)
        {
            using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
            {
                facade.Sort(this.assignedDepartmentDataSource, columnName);
            }
        }

        /// <summary>
        /// Bind data to customer department combobox
        /// </summary>
        private void BindDepartmentList(ArrayList datasource)
        {
            ArrayList departmentDataSource = datasource;
            this.cboDepartment.DataSource = departmentDataSource;
        }

        /// <summary>
        /// Select item in department combobox that depend on selectedCode
        /// </summary>
        /// <param name="selectedCode"></param>
        private void selectDepartment(string selectedCode)
        {
            ArrayList dataSource = (ArrayList)this.cboDepartment.DataSource;
            int index = 0;
            bool found = false;

            while ((index < dataSource.Count) && (!found))
            {
                CustomerDepartment department = (CustomerDepartment) dataSource[index];
                if (department.Code == selectedCode)
                {
                    this.cboDepartment.SelectedIndex = index;
                    found = true;
                }
                index++;
            }
        }

        /// <summary>
        /// Set control property when entry mode is new
        /// </summary>
        private void setControlOnNewMode()
        {
            //=== set control values ===
            this.selectDepartment(this.defaultDepartment.Code);
            this.dtpFrom.Value = this.currentContract.APeriod.From;
            this.dtpTo.Value = this.currentContract.APeriod.To;
            this.txtHirerName.Text = string.Empty;

            this.dtpFrom.Focus();
        }

        /// <summary>
        /// To set selected grid row for the lastest add/update row
        /// </summary>
        private void selectLastestProcessGridRow(ContractDepartmentAssignment processEntity)
        {
            for (int i = 0; i < this.dgvDepartment.Rows.Count;i++ )
            {
                DataGridViewRow currentRow = this.dgvDepartment.Rows[i];
                DateTime fromDate = Convert.ToDateTime(currentRow.Cells[COLUMN_INDEX_FROM_DATE].Value);
                DateTime toDate = Convert.ToDateTime(currentRow.Cells[COLUMN_INDEX_TO_DATE].Value);

                if ((fromDate == processEntity.AssignPeriod.From) && (toDate == processEntity.AssignPeriod.To))
                {
                    currentRow.Selected = true;
                }
                else
                {
                    currentRow.Selected = false;
                }
            }
        }

        #endregion

        #region Data Methods

        /// <summary>
        /// Load customer department lsit
        /// </summary>
        /// <returns></returns>
        private ArrayList LoadDepartment(Customer customer)
        {
            using (ContractFacadeBase facadeContract = new ContractFacadeBase())
            {
                ArrayList result = facadeContract.DataSourceCustomerDept(customer);

                return result;
            }
        }

        /// <summary>
        /// Load customer to object
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private Customer LoadCustomer(string customerCode)
        {
            Customer customer = new Customer(customerCode);
            return customer;
        }

        /// <summary>
        /// Initialize assigned department for new mode
        /// </summary>
        private void initializeDataList()
        {
            using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
            {
                List<ContractDepartmentAssignment> result = facade.InitializeAssignedDepartment(this.currentContract);
                
                this.assignedDepartmentDataSource = result;
            }
        }

        /// <summary>
        /// Load assigned department form database
        /// </summary>
        private void LoadDataList()
        {
            using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
            {
                List<ContractDepartmentAssignment> result = facade.GetListByContract(this.currentContract.ContractNo.EntityKey);

                this.assignedDepartmentDataSource = result;
            }
        }


        /// <summary>
        /// Show error message when valid overlap period
        /// </summary>
        private void showMessageInvalidOverlapPeriod()
        {
            Message(MessageList.Error.E0055);
            this.dtpFrom.Focus();
        }

        /// <summary>
        /// Process on save data list
        /// </summary>
        private bool onSaveDataList()
        {
            using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
            {
                List<ContractDepartmentAssignment> list = this.assignedDepartmentDataSource;

                if (facade.Save(list))
                {
                    base.Message(MessageList.Information.I0001);

                    return true;
                }
                else
                {
                    base.Message(MessageList.Error.E0014, "บันทึกข้อมูล");

                    return false;
                }
            }
        }

        /// <summary>
        /// Process on save entry data
        /// </summary>
        private void onSaveEntryData(ContractDepartmentAssignment saveEntity)
        {
            switch (this.entryMode)
            {
                case EntryMode.Add:

                    this.insertEntryDataToList(saveEntity);

                    break;

                case EntryMode.Update:

                    saveEntity = this.GetContractDepartmentAssignmentEntry();
                    this.updateEntryDataToList(saveEntity);

                    break;
            }
        }

        /// <summary>
        /// Insert entry data to data list
        /// </summary>
        private void insertEntryDataToList(ContractDepartmentAssignment entityCondition)
        {
            List<ContractDepartmentAssignment> list;

            if (this.assignedDepartmentDataSource != null)
            {
                list = this.assignedDepartmentDataSource;
                int index = 0;
                int foundIndex = -1;

                while ((index < list.Count) && (foundIndex == -1))
                {
                    ContractDepartmentAssignment currentAssigned = list[index];

                    if (ContractDepartmentAssignment.EqualByKey(currentAssigned, entityCondition))
                    {
                        foundIndex = index;
                    }

                    index++;
                }

                if (foundIndex == -1)
                {
                    entityCondition.EntityState = EntityState.Added;
                    list.Add(entityCondition);
                }
                else
                {
                    ContractDepartmentAssignment foundEntity = list[foundIndex];

                    foundEntity.AssignDepartment = entityCondition.AssignDepartment;
                    foundEntity.HirerName = entityCondition.HirerName;

                    switch (foundEntity.EntityState)
                    {
                        case EntityState.Unchanged:

                            foundEntity.EntityState = EntityState.Modified;

                            break;

                        case EntityState.Deleted:

                            foundEntity.EntityState = EntityState.Added;

                            break;
                    }
                }
            }
            else
            {
                list = new List<ContractDepartmentAssignment>();
                entityCondition.EntityState = EntityState.Added;
                list.Add(entityCondition);
            }

            this.assignedDepartmentDataSource = list;
        }

        /// <summary>
        /// Update entry data on list
        /// </summary>
        /// <param name="entityCondition"></param>
        private void updateEntryDataToList(ContractDepartmentAssignment entityCondition)
        {
            List<ContractDepartmentAssignment> list = this.assignedDepartmentDataSource;

            int index = 0;
            int foundIndex = -1;

            while ((index < list.Count) && (foundIndex == -1))
            {
                ContractDepartmentAssignment currentAssigned = list[index];

                if (ContractDepartmentAssignment.EqualByKey(currentAssigned, entityCondition))
                {
                    foundIndex = index;
                }

                index++;
            }

            if (foundIndex != -1)
            {
                ContractDepartmentAssignment foundEntity = list[foundIndex];

                foundEntity.AssignDepartment = entityCondition.AssignDepartment;
                foundEntity.HirerName = entityCondition.HirerName;
                foundEntity.EntityState = EntityState.Modified;
            }

            this.assignedDepartmentDataSource = list;
        }

        /// <summary>
        /// Process when click delete entry data
        /// </summary>
        /// <param name="deletingIndex"></param>
        private void onDeleteEntry()
        {
            if (this.currentDeletingObject != null)
            {

                // Delete entity
                switch (this.currentDeletingObject.EntityState)
                {
                    case EntityState.Unchanged:
                    case EntityState.Modified:

                        this.currentDeletingObject.EntityState = EntityState.Deleted;

                        break;

                    case EntityState.Added:

                        this.deleteEntryDataFromList();

                        break;
                }
                this.bindDataList();

            }
        }

        /// <summary>
        /// Delete object entry data from list object
        /// </summary>
        private void deleteEntryDataFromList()
        {
            List<ContractDepartmentAssignment> list = this.assignedDepartmentDataSource;
            list.Remove(this.currentDeletingObject);

            this.assignedDepartmentDataSource = list;
        }

        #endregion

        #region Validate Data Methods

        /// <summary>
        /// Validate assigned department entry data
        /// </summary>
        /// <returns></returns>
        private bool validEntryData()
        {
            using (ContractDepartmentAssignmentFacade facade = new ContractDepartmentAssignmentFacade())
            {
                if (!this.validateSelectDepartment())
                {
                    return false;
                }

                TimePeriod entryPeriod = new TimePeriod();
                entryPeriod.From = this.dtpFrom.Value;
                entryPeriod.To = this.dtpTo.Value;

                //=== Validate range ===
                if (!entryPeriod.ValidateRange())
                {
                    Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                    this.dtpFrom.Focus();
                    return false;
                }

                // === Validate contract start and end ===
                if (!entryPeriod.IsSubRange(this.currentContract.APeriod))
                {
                    Message(MessageList.Error.E0054);
                    this.dtpFrom.Focus();
                    return false;
                }

                //=== Validate with checking entry mode

                switch (this.entryMode)
                {
                    case EntryMode.Add:

                        if (!facade.ValidateOverlapPeriod(this.assignedDepartmentDataSource,entryPeriod))
                        {
                            this.showMessageInvalidOverlapPeriod();
                            return false;
                        }

                        break;

                    case EntryMode.Update:

                        if (!facade.ValidateOverlapPeriod(this.assignedDepartmentDataSource, entryPeriod, this.oldAssignedDepartment.AssignPeriod))
                        {
                            this.showMessageInvalidOverlapPeriod();
                            return false;
                        }

                        break;
                }

                return true;
            }
        }

        /// <summary>
        /// Validate selection customer department
        /// </summary>
        /// <returns></returns>
        private bool validateSelectDepartment()
        {
            CustomerDepartment department = (CustomerDepartment)this.cboDepartment.SelectedItem;
            if ((department == null) || (department.Code == string.Empty) || (department.Code == CustomerDepartmentCodeValue.DUMMY))
            {
                this.Message(MessageList.Error.E0005, "ฝ่ายลูกค้า");
                this.cboDepartment.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate assigned department data list
        /// </summary>
        /// <returns></returns>
        private bool validateSaveDataList()
        {
            //=== Validate require select assigned department ===
            if (this.dgvDepartment.Rows.Count == 0)
            {
                base.Message(MessageList.Error.E0058, "ระบุฝ่ายอย่างน้อยหนึ่งฝ่าย");
                return false;
            }

            if (!this.facade.ValidateAssignFullContractRange(this.assignedDepartmentDataSource,this.currentContract.APeriod))
            {
                base.Message(MessageList.Error.E0058, "ระบุฝ่ายให้ครบทุกช่วงเวลาในสัญญา");
                return false;
            }

            return true;
        }

        #endregion

        #region Assign Variable Methods

        /// <summary>
        /// Clear entry form to reset mode
        /// </summary>
        private void moveToResetEntryMode()
        {
            this.entryMode = EntryMode.None;
            this.lblAssignModeTitle.Text = TITLE_RESET_ASSING_MODE;
            this.lblAssignModeTitle.ForeColor = COLOR_RESET_ASSING_MODE;
            this.clearCurrentEntryData();
            this.enableControlOnResetMode();
        }

        /// <summary>
        /// Clear entry form to add mode
        /// </summary>
        private void moveToAddEntryMode()
        {
            this.entryMode = EntryMode.Add;
            this.lblAssignModeTitle.Text = TITLE_ADD_ASSING_MODE;
            this.lblAssignModeTitle.ForeColor = COLOR_ADD_ASSING_MODE;
            this.clearCurrentEntryData();
            this.enableControlOnNewMode();
        }

        /// <summary>
        /// Set edit data to controls
        /// </summary>
        private void moveToUpdateEntryMode(DateTime fromDate, DateTime toDate, string shortDepartmentName, string hirerName)
        {
            this.currentAssignedDepartment = new ContractDepartmentAssignment();
            this.currentAssignedDepartment.AssignDepartment = this.getDepartment(shortDepartmentName);

            this.currentAssignedDepartment.AssignPeriod = new TimePeriod();
            this.currentAssignedDepartment.AssignPeriod.From = fromDate;
            this.currentAssignedDepartment.AssignPeriod.To = toDate;

            if (!string.IsNullOrEmpty(hirerName))
                this.currentAssignedDepartment.HirerName = hirerName;

            this.bindEntryData();
        }

        /// <summary>
        /// Clear current entry data of contract department assignment
        /// </summary>
        private void clearCurrentEntryData()
        {
            this.currentAssignedDepartment = null;
            this.oldAssignedDepartment = null;
        }

        /// <summary>
        /// Initial global variables
        /// </summary>
        private void initialGlobalVariables()
        {
            this.entryMode = EntryMode.Add;
            this.currentDeletingRowIndex = -1;
            this.facade = new ContractDepartmentAssignmentFacade();
        }

        #endregion

        #region Get Class Object Methods

        /// <summary>
        /// Convert properties to contract object for new mode
        /// </summary>
        /// <returns></returns>
        private ContractBase convertToNewContractBase()
        {
            ContractBase contractBase = new ContractBase();

            contractBase.APeriod = new TimePeriod();
            contractBase.APeriod.From = this.currentContractStartDate;
            contractBase.APeriod.To = this.currentContractEndDate;

            contractBase.ACustomerDepartment = this.defaultDepartment;

            return contractBase;
        }

        /// <summary>
        /// Assign control properties to object
        /// </summary>
        private ContractDepartmentAssignment GetContractDepartmentAssignmentEntry()
        {
            ContractDepartmentAssignment assignedDepartment = new ContractDepartmentAssignment();
            assignedDepartment.AssignDepartment = (CustomerDepartment)this.cboDepartment.SelectedItem;

            assignedDepartment.AssignPeriod = new TimePeriod();
            assignedDepartment.AssignPeriod.From = this.dtpFrom.Value;
            assignedDepartment.AssignPeriod.To = this.dtpTo.Value;

            assignedDepartment.Contract = this.currentContract;
            assignedDepartment.HirerName = this.txtHirerName.Text;

            return assignedDepartment;
        }

        /// <summary>
        /// Get customer department object from code parameter and current customer
        /// </summary>
        /// <param name="departmentCode"></param>
        /// <returns></returns>
        private CustomerDepartment getDepartment(string departmentCode)
        {
            CustomerDepartment department = new CustomerDepartment(departmentCode, this.currentCustomer);

            return department;
        }

        #endregion

    }
}
