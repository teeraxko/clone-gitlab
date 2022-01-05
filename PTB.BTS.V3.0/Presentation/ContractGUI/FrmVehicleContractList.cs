using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Entity.ContractEntities;
using Facade.ContractFacade;
using Entity.VehicleEntities;
using Facade.CommonFacade;

namespace Presentation.ContractGUI
{
    /// <summary>
    /// D21018 - Create new form like a frmVDOList due to it is very dificult to modify it to support the attachment
    /// </summary>
    public partial class FrmVehicleContractList : ChildFormBase, IMDIChildForm
    {
        private List<ContractBase> contractList = new List<ContractBase>();

        private ContractListFacade facadeListContract;
        public ContractListFacade FacadeListContract
        {
            get { return facadeListContract; }
        }

        private Customer conditionCustomer;
        public Customer ConditionCustomer
        {
            set { conditionCustomer = value; }
        }

        private ModelType conditionModelType;
        public ModelType ConditionModelType
        {
            get { return conditionModelType; }
            set { conditionModelType = value; }
        }


        private bool isMultiSelection = false;
        public bool IsMultiSelection
        {
            set
            {
                isMultiSelection = value;
            }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }

        /// <summary>
        /// Get the selected contract
        /// </summary>
        private List<ContractBase> selectedContractList;
        public List<ContractBase> SelectedContractList
        {
            get {
                return selectedContractList;                
            }
        }

        #region Constructor

        public FrmVehicleContractList()
            : base()
        {
            InitializeComponent();
            facadeListContract = new ContractListFacade();
            selectedContractList = new List<ContractBase>();
            contractList = new List<ContractBase>();
        }
        
        #endregion

        public void InitForm()
        {

            chkSelectAll.Visible = this.isMultiSelection;
            if (facadeListContract.DisplayVehicleContract(conditionCustomer, conditionModelType))
            {
                BindData();
            }
            else
            {
                selected = false;
                ClearForm();
            }
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Bind contract to gridview
        /// </summary>
        private void BindData()
        {
            dgvContractList.Rows.Clear();
            if (facadeListContract.ObjContractList != null)
            {
                contractList = facadeListContract.ObjContractList.Cast<ContractBase>().Select(c=>c).ToList();
                int iCount = facadeListContract.ObjContractList.Count;
                dgvContractList.RowCount = iCount;

                for (int i = 0; i < iCount; i++)
                {
                    VehicleContract vehicleContract = (VehicleContract)facadeListContract.ObjContractList[i];

                    if (vehicleContract.AVehicleRoleList.Count == 0)
                    {
                        BindContract(i, vehicleContract, null);
                    }
                    else
                    {
                        BindContract(i, vehicleContract, vehicleContract.AVehicleRoleList[vehicleContract.AVehicleRoleList.Count-1]);
                    }
                }
            }
        }

        private void BindContract(int row, VehicleContract vehicleContract, VehicleRole vehicleRole)
        {
            dgvContractList[0, row].Value = GUIFunction.GetString(vehicleContract.ContractNo.ToString());
            //dgvContractList[1, row] //Checkbox.
            dgvContractList[2, row].Value = GUIFunction.GetString(vehicleContract.ContractNo.ToString());
            dgvContractList[3, row].Value = GUIFunction.GetString(vehicleContract.AContractType.AName.Thai);

            string vehiclePlanteNo = String.Empty;
            if (vehicleRole!=null)
            {
                vehiclePlanteNo = vehicleRole.AVehicle.PlateNumber;
            }
            dgvContractList[4, row].Value = vehiclePlanteNo;
            dgvContractList[5, row].Value = GUIFunction.GetString(vehicleContract.ACustomer.ToString());
            dgvContractList[6, row].Value = GUIFunction.GetString(vehicleContract.APeriod.From.Date.ToShortDateString());
            dgvContractList[7, row].Value = GUIFunction.GetString(vehicleContract.APeriod.To.Date.ToShortDateString());
            dgvContractList[8, row].Value = GUIFunction.GetString(vehicleContract.AKindOfContract.AName.Thai);
        }

        private void ClearForm()
        {
            dgvContractList.Rows.Clear();
            btnConfirm.Enabled = false;
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {
            throw new NotImplementedException();
        }

        public void ExitForm()
        {
            this.selected = false;
            Dispose(true);
        }

        #region Event

        private void FrmAttachmentList_Load(object sender, System.EventArgs e)
        {
            InitForm();            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataGridGetSelectedRow();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        #endregion

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridChangeSelection(chkSelectAll.Checked);    
        }

        /// <summary>
        /// Set checkbox value
        /// </summary>
        /// <param name="isSelectedAll"></param>
        private void DataGridChangeSelection(bool isSelectedAll)
        {
            for (int i = 0; i < dgvContractList.Rows.Count; i++)
                {
                    dgvContractList.Rows[i].Cells[1].Value = isSelectedAll;
                }
            dgvContractList.Refresh();
            this.selected = isSelectedAll;
        }

        /// <summary>
        /// Get the selected row in gridview
        /// </summary>
        private void DataGridGetSelectedRow()
        {
                for (int i = 0; i < dgvContractList.Rows.Count; i++)
                {
                    bool isSelected = Convert.ToBoolean(dgvContractList.Rows[i].Cells[1].Value);
                    if (isSelected)
                    {
                        string contractNo = Convert.ToString(dgvContractList.Rows[i].Cells[2].Value);
                        ContractBase ct = contractList.FirstOrDefault(c => c.ContractNo.ToString() == contractNo);
                        if (ct != null)
                        {
                            this.selectedContractList.Add(ct);
                        }
                    }
                }

                if (this.selectedContractList.Count > 0)
                {
                    selected = true;
                }
        }
    }
}
