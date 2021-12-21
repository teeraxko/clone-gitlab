using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
    public partial class FrmContractDriverList : EntryFormBase
    {
        #region - Constant -
        enum ContractListType
        {
            VEHICLE,
            DRIVER_OTHER,
            AVAILABLE_STAFF,
            CONTRACT_VEHICLE,
            CONTRACT_DRIVER,
            NOT_SPECIFIC
        }
        #endregion

        #region - Private -
        private int SelectedRow
        {
            get { return dtgContractList.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgContractList[0, SelectedRow].Value.ToString(); }
        }

        public ContractBase SelectedContract
        {
            get { return (ContractBase)facadeListContract.ObjContractList[SelectedKey]; }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }
        #endregion

        //		============================== Property ==============================
        private ContractListFacade facadeListContract;
        public ContractListFacade FacadeListContract
        {
            get { return facadeListContract; }
        }

        public Customer ConditionCustomer
        {
            set { facadeListContract.ConditionContract.ACustomerDepartment.ACustomer = value; }
        }

        public ContractType ConditionCONTRACT_TYPE
        {
            set { facadeListContract.ConditionContract.AContractType = value; }
        }

        public ContractStatus ConditionContractStatus
        {
            set { facadeListContract.ConditionContract.AContractStatus = value; }
        }

        public string ConditionYY
        {
            set { facadeListContract.YY = value; }
        }

        public string ConditionMM
        {
            set { facadeListContract.MM = value; }
        }

        public string ConditionXXX
        {
            set { facadeListContract.XXX = value; }
        }

        private ContractListType contractListType = ContractListType.NOT_SPECIFIC;

        public bool IsContractDriverList
        {
            set
            {
                if (value)
                    contractListType = ContractListType.CONTRACT_DRIVER;
            }
        }

        public TimePeriod ConditionTimePeriodFrom
        {
            set { facadeListContract.ConditionContract.APeriod = value; }
        }

        //		============================== Constructor ==============================
        public FrmContractDriverList() : base()
        {
            InitializeComponent();
            facadeListContract = new ContractListFacade();
        }

        //		============================== private method ==============================
        private void bindContract(int row, VehicleContract objVehicleContract, VehicleRole objVehicleRole)
        {}

        private void bindContract(int row, ServiceStaffContract objServiceStaffContract, ServiceStaffRole objServiceStaffRole)
        {
            dtgContractList.Rows[row].Cells["entityKey"].Value = GUIFunction.GetString(objServiceStaffContract.EntityKey);
            dtgContractList.Rows[row].Cells["contractStatus"].Value = GUIFunction.GetString(objServiceStaffContract.AContractStatus);
            dtgContractList.Rows[row].Cells["contractNo"].Value = GUIFunction.GetString(objServiceStaffContract.ContractNo.ToString());

            if (objServiceStaffRole == null)
            {
                dtgContractList.Rows[row].Cells["employeeNo"].Value = "";
                dtgContractList.Rows[row].Cells["serviceStaffType"].Value = "";
            }
            else
            {
                dtgContractList.Rows[row].Cells["employeeNo"].Value = GUIFunction.GetString(objServiceStaffRole.AServiceStaff.EmployeeName);
                dtgContractList.Rows[row].Cells["serviceStaffType"].Value = GUIFunction.GetString(objServiceStaffRole.AServiceStaff.AServiceStaffType.ADescription.Thai);
            }

            dtgContractList.Rows[row].Cells["customerDepartment"].Value = GUIFunction.GetString(objServiceStaffContract.ACustomerDepartment.ShortName);
            dtgContractList.Rows[row].Cells["customerName"].Value = GUIFunction.GetString(objServiceStaffContract.ACustomerDepartment.ACustomer.ShortName);
            dtgContractList.Rows[row].Cells["periodFrom"].Value = objServiceStaffContract.APeriod.From.Date;
            dtgContractList.Rows[row].Cells["periodTo"].Value = objServiceStaffContract.APeriod.To.Date;
            dtgContractList.Rows[row].Cells["kindOfContract"].Value = GUIFunction.GetString(objServiceStaffContract.AKindOfContract.AName.Thai);
        }


        private void bindForm()
        {
            if (facadeListContract.ObjContractList != null)
            {
                int iRow = 0;
                int iCount = facadeListContract.ObjContractList.Count;

                if (contractListType.Equals(ContractListType.VEHICLE) || contractListType.Equals(ContractListType.CONTRACT_VEHICLE))
                {
                    dtgContractList.RowCount = 0;

                    for (int i = 0; i < iCount; i++)
                    {
                        VehicleContract vehicleContract = (VehicleContract)facadeListContract.ObjContractList[i];

                        if (vehicleContract.AVehicleRoleList.Count == 0)
                        {
                            dtgContractList.RowCount++;
                            bindContract(iRow, vehicleContract, null);
                            ++iRow;
                        }
                        else
                        {
                            for (int j = 0; j < vehicleContract.AVehicleRoleList.Count; j++)
                            {
                                dtgContractList.RowCount++;
                                bindContract(iRow, vehicleContract, vehicleContract.AVehicleRoleList[j]);
                                ++iRow;
                            }
                        }
                    }
                }
                else
                {
                    dtgContractList.RowCount = 0;

                    for (int i = 0; i < iCount; i++)
                    {
                        ServiceStaffContract serviceStaffContract = (ServiceStaffContract)facadeListContract.ObjContractList[i];

                        if (serviceStaffContract.ALatestServiceStaffRoleList.Count == 0)
                        {
                            dtgContractList.RowCount++;
                            bindContract(iRow, serviceStaffContract, null);
                            ++iRow;
                        }
                        else
                        {
                            for (int j = 0; j < serviceStaffContract.ALatestServiceStaffRoleList.Count; j++)
                            {
                                dtgContractList.RowCount++;
                                bindContract(iRow, serviceStaffContract, serviceStaffContract.ALatestServiceStaffRoleList[j]);
                                ++iRow;
                            }
                        }
                    }
                }
            }
        }

        private void clearForm()
        {
            dtgContractList.RowCount = 0;
            btnOK.Enabled = false;
        }

        //		============================== Base Event ==============================
        public void InitForm()
        {
            try
            {
                switch (contractListType)
                {
                    case ContractListType.CONTRACT_DRIVER:
                        {
                            //if (facadeListContract.DisplayContract())
                            if (facadeListContract.DisplayContract(DOCUMENT_TYPE.CONTRACT_DRIVER))
                            {
                                bindForm();
                            }
                            else
                            {
                                selected = false;
                                clearForm();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            Dispose(true);
        }

        private void selectEvent()
        {
            selected = true;
            this.Hide();
        }

        //		==============================Event ==============================
        private void btnOK_Click(object sender, EventArgs e)
        {
            selectEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selected = false;
            this.Hide();
        }

        private void FrmContractDriverList_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void dtgContractList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectEvent();
            }
        }

        private void dtgContractList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}