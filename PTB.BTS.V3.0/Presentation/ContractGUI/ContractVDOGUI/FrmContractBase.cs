using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Presentation.CommonGUI;

using Entity.ContractEntities;
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.Constants;
using SystemFramework.AppException;
using SystemFramework.AppMessage;
using ictus.Common.Entity.Time;
using Presentation.VehicleGUI;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Presentation.ContractGUI.ContractVDOGUI
{
    public partial class FrmContractBase : ChildFormBase, IMDIChildForm, ISaveForm
    {
		#region Valiable

		private bool addMode = false;
		private bool updateMode = false;
		private bool isReadonly = true;
		private bool isTextChange = true;
        private bool isCanAssignDepartment;
		private frmMain mdiParent;
		protected ContractBase objContractBase;
        private DriverContract objDriverContract;
        private VehicleContract objVehicleContract;
        protected ContractFacadeBase facadeContract;
		private DocumentNo contractNo;
        private DocumentNo docMatchNo;
		private Vehicle objVehicle;
		private ServiceStaffContract objServiceStaffContract;
        private List<ContractDepartmentAssignment> assignedDepartmentList;
			
		private int SelectedRow
		{
            get { return dtgVehicleContract.CurrentRow.Index; }
		}

		private int SelectedKey
		{
            get { return Convert.ToInt32(dtgVehicleContract[0, SelectedRow].Value); }
		}

		private Vehicle SelectedVehicle()
		{
			objVehicle = facadeContract.GetVehicleGeneral(SelectedKey);
			return objVehicle;	
		}
		#endregion

        #region Property

        //D21018-BTS Contract Modification
        private DOCUMENT_TYPE documentType;
        public DOCUMENT_TYPE DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }


        /// <summary>
        /// Get contract no
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        private DocumentNo getContractNo(DOCUMENT_TYPE documentType)
        {
            contractNo = new DocumentNo(documentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;
        }

        /// <summary>
        /// Get contract no
        /// </summary>
        /// <returns></returns>
        private DocumentNo getContractNo()
        {

            //D21018 Support set contract type from dropdown
            if (cboVehicleKindContract.Visible)
            {
                SetDocumentTypeFromAbbreviation(cboVehicleKindContract.Text);
            }

            contractNo = new DocumentNo(this.DocumentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;
        }

        private DriverContract getDriverContract()
        {
            objDriverContract = new DriverContract(facadeContract.GetCompany());
            objDriverContract.ContractNo = getContractNo();
            objDriverContract.AContractType = (ContractType)cboContractType.SelectedItem;
            objDriverContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
            objDriverContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
            objDriverContract.APeriod.From = dtpContractStart.Value.Date;
            objDriverContract.APeriod.To = dtpContractEnd.Value.Date;
            objDriverContract.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objDriverContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objDriverContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
            objDriverContract.UnitHire = Convert.ToInt32(fpiUnitHire.Value);
            objDriverContract.ACancelReason.Name = "";

            if (rdoDay.Checked)
            {
                objDriverContract.RateStatus = RATE_STATUS_TYPE.DAY;
            }
            else
            {
                objDriverContract.RateStatus = RATE_STATUS_TYPE.MONTH;
            }

            objDriverContract.Remark = txtRemark.Text;
            addContractCharge(objDriverContract);

            if (this.objContractBase != null)
            {
                this.objVehicleContract.AssignedDepartmentList = this.objContractBase.AssignedDepartmentList;
            }

            return objDriverContract;
        }

        private VehicleContract getNewVehicleContract()
        {
            objVehicleContract.ContractNo = getContractNo();
            objVehicleContract.AContractType = (ContractType)cboContractType.SelectedItem;
            objVehicleContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
            objVehicleContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
            objVehicleContract.APeriod.From = dtpContractStart.Value.Date;
            objVehicleContract.APeriod.To = dtpContractEnd.Value.Date;
            objVehicleContract.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objVehicleContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objVehicleContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
            objVehicleContract.UnitHire = Convert.ToInt32(fpiUnitHire.Value);
            objVehicleContract.ACancelReason.Name = "";

            if (rdoDay.Checked)
            {
                objVehicleContract.RateStatus = RATE_STATUS_TYPE.DAY;
            }
            else
            {
                objVehicleContract.RateStatus = RATE_STATUS_TYPE.MONTH;
            }

            objVehicleContract.Remark = txtRemark.Text;

            for (int i = 0; i < objVehicleContract.AVehicleRoleList.Count; i++)
            {
                string temp = dtgVehicleContract[4, i].Value.ToString();
                objVehicleContract.AVehicleRoleList[i].AKindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];
                objVehicleContract.AVehicleRoleList[i].AVehicle.AKindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];
            }

            SetLeaseTerm(objVehicleContract);
            addContractCharge(objVehicleContract);

            if (this.objContractBase != null)
            {
                this.objVehicleContract.AssignedDepartmentList = this.objContractBase.AssignedDepartmentList;
            }

            return objVehicleContract;
        }

        private VehicleContract getVehicleContract()
        {
            objVehicleContract = (VehicleContract)facadeContract.RetriveContract(getContractNo());
            objVehicleContract.ContractNo = getContractNo();
            objVehicleContract.AContractType = (ContractType)cboContractType.SelectedItem;
            objVehicleContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
            objVehicleContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
            objVehicleContract.APeriod.From = dtpContractStart.Value.Date;
            objVehicleContract.APeriod.To = dtpContractEnd.Value.Date;
            objVehicleContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objVehicleContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
            objVehicleContract.UnitHire = Convert.ToInt32(fpiUnitHire.Value);
            objVehicleContract.ACancelReason.Name = "";

            if (rdoDay.Checked)
            {
                objVehicleContract.RateStatus = RATE_STATUS_TYPE.DAY;
            }
            else
            {
                objVehicleContract.RateStatus = RATE_STATUS_TYPE.MONTH;
            }

            objVehicleContract.Remark = txtRemark.Text;
            SetLeaseTerm(objVehicleContract);
            addContractCharge(objVehicleContract);

            return objVehicleContract;
        }

        private ServiceStaffContract getServiceStaffContract()
        {
            objServiceStaffContract = new ServiceStaffContract(facadeContract.GetCompany());
            objServiceStaffContract.ContractNo = getContractNo();
            objServiceStaffContract.AContractType = (ContractType)cboContractType.SelectedItem;
            objServiceStaffContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
            objServiceStaffContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
            objServiceStaffContract.APeriod.From = dtpContractStart.Value.Date;
            objServiceStaffContract.APeriod.To = dtpContractEnd.Value.Date;
            objServiceStaffContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objServiceStaffContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
            objServiceStaffContract.UnitHire = Convert.ToInt32(fpiUnitHire.Value);
            objServiceStaffContract.ACancelReason.Name = "";

            if (rdoDay.Checked)
            {
                objServiceStaffContract.RateStatus = RATE_STATUS_TYPE.DAY;
            }
            else
            {
                objServiceStaffContract.RateStatus = RATE_STATUS_TYPE.MONTH;
            }

            objServiceStaffContract.Remark = txtRemark.Text;
            addContractCharge(objServiceStaffContract);
            return objServiceStaffContract;
        }

        protected virtual void setContractBase(ContractBase value)
        {
            isTextChange = false;
            txtContractNoYY.Text = value.ContractNo.Year;
            txtContractNoMM.Text = value.ContractNo.Month;
            txtContractNoXXX.Text = value.ContractNo.No;
            txtContractNoXXX.Tag = value;
            cboCustomerTHName.Text = value.ACustomerDepartment.ACustomer.ToString();
            cboContractType.Text = GUIFunction.GetString(value.AContractType);
            cboContractStatus.Text = GUIFunction.GetString(value.AContractStatus);
            cboCustomerDept.Text = value.ACustomerDepartment.ToString();
            cboKindOfContract.Text = GUIFunction.GetString(value.AKindOfContract.AName.Thai);
            dtpContractStart.Value = value.APeriod.From;
            dtpContractEnd.Value = value.APeriod.To;
            dtpContractEnd.Tag = value.APeriod.To;
            fpiUnitHire.Value = value.UnitHire;

            if (value.RateStatus == RATE_STATUS_TYPE.DAY)
            {
                rdoDay.Checked = true;
            }
            else
            {
                rdoMonth.Checked = true;
            }

            txtRemark.Text = value.Remark;
            isTextChange = true;
        }

        protected void bindContractCharge(UCTContractCharge control, ContractCharge value)
        {
            if (value == null)
            {
                control.RateAmount = 0;
                control.FirstMonth = 0;
                control.NextMonth = 0;
                control.LastMonth = 0;
            }
            else
            {
                control.RateAmountTag = value.UnitChargeAmount;
                control.RateAmount = value.UnitChargeAmount;
                control.FirstMonth = value.FirstMonthCharge;
                control.NextMonth = value.MonthlyCharge;
                control.LastMonth = value.LastMonthCharge;

                control.DateForm = value.APeriod.From.Date;
                control.DateTo = value.APeriod.To.Date;
                control.RateStatusByMonth = rdoMonth.Checked;
            }
        }

        protected ContractCharge getContractCharge(UCTContractCharge control)
        {
            ContractCharge contractCharge = new ContractCharge();
            contractCharge.UnitChargeAmount = control.RateAmount;
            contractCharge.FirstMonthCharge = control.FirstMonth;
            contractCharge.MonthlyCharge = control.NextMonth;
            contractCharge.LastMonthCharge = control.LastMonth;
            contractCharge.APeriod.From = control.DateForm;
            contractCharge.APeriod.To = control.DateTo;
            return contractCharge;
        } 
        #endregion

        #region Constructor
        public FrmContractBase()
            : base()
        {
            InitializeComponent();

            hideGroupBox(false);
            hideCancelDate(false);
            cmdOK.Enabled = false;

            this.facadeContract = new ContractFacadeBase();
        }
        #endregion

        #region Private Method
        //private void formContractList()
        //{
        //    ContractType contractType = (ContractType)cboContractType.SelectedItem;

        //    if (contractType.Code.Equals(ContractType.CONTRACT_TYPE_DRIVER))
        //    {
        //        FrmContractDriverList dialogContractList = new FrmContractDriverList();

        //        if (cboCustomerTHName.Text != "")
        //            dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;

        //        dialogContractList.ConditionCONTRACT_TYPE = contractType;
        //        dialogContractList.IsContractDriverList = true;

        //        if (cboContractStatus.Text != "")
        //            dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
        //        if (txtContractNoYY.Text != "")
        //            dialogContractList.ConditionYY = txtContractNoYY.Text;
        //        if (txtContractNoMM.Text != "")
        //            dialogContractList.ConditionMM = txtContractNoMM.Text;
        //        if (txtContractNoXXX.Text != "")
        //            dialogContractList.ConditionXXX = txtContractNoXXX.Text;
        //        dialogContractList.ShowDialog();
        //        if (dialogContractList.Selected)
        //            retriveContract(dialogContractList.SelectedContract);

        //        dialogContractList = null;
        //    }
        //    else
        //    {
        //        frmContractVDOList dialogContractList = new frmContractVDOList();
        //        dialogContractList.ConditionCONTRACT_TYPE = contractType;
        //        if (cboCustomerTHName.Text != "")
        //            dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;
        //        if (cboContractType.Text != "")
        //        {
        //            switch (contractType.Code)
        //            {
        //                case ContractType.CONTRACT_TYPE_VEHICLE:
        //                    dialogContractList.IsContractVehicleList = true;
        //                    break;
        //                case ContractType.CONTRACT_TYPE_OTHER:
        //                    dialogContractList.IsContractServiceStaffList = true;
        //                    break;
        //            }
        //        }
        //        if (cboContractStatus.Text != "")
        //            dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
        //        if (txtContractNoYY.Text != "")
        //            dialogContractList.ConditionYY = txtContractNoYY.Text;
        //        if (txtContractNoMM.Text != "")
        //            dialogContractList.ConditionMM = txtContractNoMM.Text;
        //        if (txtContractNoXXX.Text != "")
        //            dialogContractList.ConditionXXX = txtContractNoXXX.Text;
        //        dialogContractList.ShowDialog();
        //        if (dialogContractList.Selected)
        //            retriveContract(dialogContractList.SelectedContract);

        //        dialogContractList = null;
        //    }
        //}
        private void formContractList()
        {
            ContractType contractType = (ContractType)cboContractType.SelectedItem;

            if (contractType.Code.Equals(ContractType.CONTRACT_TYPE_DRIVER))
            {
                FrmContractDriverList dialogContractList = new FrmContractDriverList();

                if (cboCustomerTHName.Text != "")
                    dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;

                dialogContractList.ConditionCONTRACT_TYPE = contractType;
                dialogContractList.IsContractDriverList = true;

                if (cboContractStatus.Text != "")
                    dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
                if (txtContractNoYY.Text != "")
                    dialogContractList.ConditionYY = txtContractNoYY.Text;
                if (txtContractNoMM.Text != "")
                    dialogContractList.ConditionMM = txtContractNoMM.Text;
                if (txtContractNoXXX.Text != "")
                    dialogContractList.ConditionXXX = txtContractNoXXX.Text;
                dialogContractList.ShowDialog();
                if (dialogContractList.Selected)
                    retriveContract(dialogContractList.SelectedContract);

                dialogContractList = null;
            }
            else
            {

                frmContractVDOList dialogContractList = new frmContractVDOList();
                this.contractNo = new DocumentNo(cboVehicleKindContract.Text, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
                dialogContractList.ContractNo = this.contractNo;
                dialogContractList.ConditionCONTRACT_TYPE = contractType;
                if (cboCustomerTHName.Text != "")
                    dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;
                if (cboContractType.Text != "")
                {
                    switch (contractType.Code)
                    {
                        case ContractType.CONTRACT_TYPE_VEHICLE:
                            dialogContractList.IsContractVehicleList = true;
                            break;
                        case ContractType.CONTRACT_TYPE_OTHER:
                            dialogContractList.IsContractServiceStaffList = true;
                            break;
                    }
                }
                if (cboContractStatus.Text != "")
                    dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
                if (txtContractNoYY.Text != "")
                    dialogContractList.ConditionYY = txtContractNoYY.Text;
                if (txtContractNoMM.Text != "")
                    dialogContractList.ConditionMM = txtContractNoMM.Text;
                if (txtContractNoXXX.Text != "")
                    dialogContractList.ConditionXXX = txtContractNoXXX.Text;
                dialogContractList.ShowDialog();
                if (dialogContractList.Selected)
                    retriveContract(dialogContractList.SelectedContract);

                dialogContractList = null;
            }
        }
        private void bindVehicleContract(VehicleContract value)
        {
            dtgVehicleContract.RowCount = 0;

            if (value.AVehicleRoleList.Count > 0)
            {
                if (value.AContractStatus == null)
                {
                    enableDeleteButton(true);
                }
                else if (value.AContractStatus.Code == ContractStatus.CONTRACT_STS_CREATED)
                {
                    enableDeleteButton(true);
                }
                else
                {
                    enableDeleteButton(false);                
                }

                for (int iRow = 0; iRow < value.AVehicleRoleList.Count; iRow++)
                {
                    dtgVehicleContract.RowCount++;
                    bindVehicle(iRow, value.AVehicleRoleList[iRow]);
                }
            }
            else
            { 
                enableDeleteButton(false); 
            }

            visibleChild(true);
        }

        private void bindVehicle(int row, VehicleRole value)
        {
            dtgVehicleContract[0, row].Value = GUIFunction.GetString(value.EntityKey);
            dtgVehicleContract[1, row].Value = GUIFunction.GetString(value.AVehicle.PlateNumber);
            dtgVehicleContract[2, row].Value = GUIFunction.GetString(value.AVehicle.AModel.ABrand.AName.English);
            dtgVehicleContract[3, row].Value = GUIFunction.GetString(value.AVehicle.AModel.AName.English);

            //Get kind of vehicle by contract : woranai 2008/11/22
            if (value.AKindOfVehicle != null)
            {
                dtgVehicleContract[4, row].Value = GUIFunction.GetString(value.AKindOfVehicle);
            }
            else
            {
                dtgVehicleContract[4, row].Value = GUIFunction.GetString(value.AVehicle.AKindOfVehicle);
            }
        }       

        private void retriveRunningNo(DOCUMENT_TYPE documentType)
        {
            isTextChange = false;            
            contractNo = facadeContract.RetriveContractRunningNo(documentType);
            txtContractNoYY.Text = contractNo.Year;
            txtContractNoMM.Text = contractNo.Month;
            txtContractNoXXX.Text = contractNo.No;
            cboContractStatus.Text = CTFunction.GetString("1");
            isTextChange = true;

            //D21018-BTS Contract Modification
            if (this.DocumentType == DOCUMENT_TYPE.CONTRACT_TEMPORARY)
            {
                cboVehicleKindContract.SelectedIndex = 2; //set selected item to "T"
            }

        }

        private void retriveContract(ContractBase contract)
        {
            updateCase();
            setContractBase(contract);
            hideGroupBox(true);
            enableGroupBox(true);
            cmdOK.Enabled = (contract.AContractStatus.Code == "1" || contract.AContractStatus.Code == "2");

            if (contract.AContractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                hideVehicleAssign(true);

                if (getVehicleContract() != null)
                {
                    bindVehicleContract((VehicleContract)contract);
                    GetLeaseTerm((VehicleContract)contract);
                    bindPurchaseOrder(contract);
                }
                else
                {
                    dtgVehicleContract.RowCount = 0;
                }
            }
            else
            {
                hideVehicleAssign(false);
            }

            //this.enableContractVehicleControl(!isReadonly);

            if (contract.AContractStatus.Code != "1")
            {
                gpbDeleteContract.Enabled = false;
                gpbContractInfo.Enabled = false;
                gpbAssignment.Enabled = false;
                enablegpbDetail(false);
                gpbRemark.Enabled = false;

                if (contract.AContractStatus.Code == "2")
                {
                    dtpContractEnd.Enabled = true;

                    //this.enableContractVehicleControl(false);
                }
                else
                {
                    enableCalculate(false);
                    enableContractCharge(false);
                }
            }

            if (contract.AContractStatus.Code == "3")
            {
                hideCancelDate(true);
                dtpCancelDate.Value = contract.CancelDate;
                gpbCancelReason.Visible = true;
                txtCancelReason.Text = contract.ACancelReason.Name;
            }
            else
            {
                hideCancelDate(false);
                gpbCancelReason.Visible = false;
            }

            visibleChild(true);

            //Add function for BTS Enhancement for year 2008 : woranai 2008/10/18
            enableLoadVehicleContract();

            IsMustQuestion = false;

            if (isReadonly)
            {
                cmdDeleteContract.Enabled = false;
                enableDeleteButton(false);
                enableAddButton(false);
                IsMustQuestion = false;
            }

            // check contract status
            if (contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_CREATED)
            {
                this.enableContractVehicleControl(!isReadonly);
            }
            else if (contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_APPROVED)
            {
                this.enableContractVehicleControl(false);
            }
            else if (contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_CANCELLED)
            {
                this.enableContractVehicleControl(!isReadonly);
            }
            else //contract.AContractStatus.Code == ContractStatus.CONTRACT_STS_EXPIRED
            {
                this.enableContractVehicleControl(!isReadonly);
            }

            this.RetriveDrivedContract(contract);
            this.bindAssignDepartmentControl(contract);
        }

        private void calLeasingPeriod()
        {
            DayMonthYearStructure leasingPeriod = facadeContract.CalAge(dtpContractStart.Value, dtpContractEnd.Value);
            txtLeasingYear.Text = leasingPeriod.Years.ToString();
            txtLeasingMonth.Text = leasingPeriod.Months.ToString();
            txtLeasingDay.Text = leasingPeriod.Days.ToString();
        }

        private void setIsMustQuestion()
        {
            if (!cmdCreateContract.Enabled && cmdOK.Enabled)
            {
                if (isReadonly)
                    IsMustQuestion = false;
                else
                    IsMustQuestion = true;
            }
        }

        private void enablegpbDetail(bool enable)
        {
            cboKindOfContract.Enabled = enable;
            dtpContractStart.Enabled = enable;
            dtpContractEnd.Enabled = enable;
            dtpCancelDate.Enabled = enable;
            txtLeasingYear.Enabled = enable;
            txtLeasingMonth.Enabled = enable;
            txtLeasingDay.Enabled = enable;
            fpiUnitHire.Enabled = enable;
            rdoDay.Enabled = enable;
            rdoMonth.Enabled = enable;
        }

        /// <summary>
        /// Enable/Disable control about vehicle in contract.
        /// </summary>
        /// <param name="enable"></param>
        private void enableContractVehicleControl(bool enable)
        {
            this.dtgVehicleContract.ReadOnly = !enable;
            enableAddButton(enable);
        }

        private VehicleContract GetSpecificVehicleContract(DocumentNo contractNo)
        {
            VehicleContract vehicleContract = (VehicleContract)facadeContract.RetriveContract(contractNo);

            UCTContractCharge uctCharge = new UCTContractCharge();
            uctCharge.RateAmount = vehicleContract.AContractChargeList[0].UnitChargeAmount;
            uctCharge.DateForm = vehicleContract.APeriod.From.Date;
            uctCharge.DateTo = dtpContractEnd.Value.Date;

            uctCharge.RateStatusByMonth = vehicleContract.RateStatus == RATE_STATUS_TYPE.MONTH;
            uctCharge.UnitChargeAmountByActualMonth();

            vehicleContract.AContractChargeList.Clear();
            vehicleContract.AContractChargeList.Add(getContractCharge(uctCharge));

            vehicleContract.APeriod.To = dtpContractEnd.Value.Date;
            return vehicleContract;
        }

        private void clearForm()
        {
            addMode = false;
            updateMode = false;
            cmdOK.Enabled = false;
            cmdCreateContract.Enabled = true;
            gpbRemark.Enabled = true;
            hideGroupBox(false);
            hideCancelDate(false);
            gpbContractInfo.Enabled = true;
            enableContractControl(true);
            gpbCancelReason.Visible = false;
            ClearContractCharge();
            ClearDeduct();
            dtgVehicleContract.RowCount = 0;
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txtRemark.Text = "";
            dtpContractStart.Value = DateTime.Today.Date;
            dtpContractEnd.Value = DateTime.Today.Date;
            dtpContractEnd.Tag = null;
            fpiUnitHire.Value = 0;
            fpiUnitHire.MaxValue = 255;
            fpiUnitHire.MinValue = 0;

            if (cboContractStatus.Items.Count > 0)
            {
                cboContractStatus.SelectedIndex = -1;
                cboContractStatus.SelectedIndex = -1;
                cboContractStatus.Text = "";
            }
            if (cboCustomerDept.Items.Count > 0)
            {
                cboCustomerDept.SelectedIndex = -1;
                cboCustomerDept.SelectedIndex = -1;
                cboCustomerDept.Text = "";
            }

            if (objVehicleContract != null)
            { objVehicleContract.AVehicleRoleList.Clear(); }

            visibleChild(false);
            EnableLeasTerm(true);

            assignedDepartmentList = null;

            IsMustQuestion = false;
        }

        private void clearLeasingPeriod()
        {
            txtLeasingDay.Text = "0";
            txtLeasingMonth.Text = "0";
            txtLeasingYear.Text = "0";
        }

        private void bindPurchaseOrder(ContractBase contract)
        {
            System.Collections.Generic.List<Entity.VehicleEntities.VehicleLeasing.VehiclePurchasingContract> list;
            list = facadeContract.GetPurchasingContractListByContract(contract.ContractNo);

            lblPONo.Text = list.Count > 0 ? list[0].VehiclePurchasing.PurchasNo.ToString() : "None";
        }

        private void ControlPrefix(ContractType contractType) 
        {
            if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                label25.Text = "PTB  - T -"; //Vehicle
                label25.Visible = false;
                lblContractPrefix.Visible = true;
                cboVehicleKindContract.Text = "C";
                cboVehicleKindContract.Visible = true;
            }
            else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
            {
                label25.Text = "PTB  - D -"; //Driver
                label25.Visible = true;
                lblContractPrefix.Visible = false;
                cboVehicleKindContract.Visible = false;
                cboVehicleKindContract.Text = "C";
            }
            else
            {
                label25.Text = "PTB  - C -"; //Other    
                label25.Visible = true;
                lblContractPrefix.Visible = false;
                cboVehicleKindContract.Text = "C";
                cboVehicleKindContract.Visible = false;                
            }

        }

        //D21018-BTS Contract Modification
        /// <summary>
        /// Set type of form from Abbreviation of contract no 
        /// C = Vehicle New Contract
        /// R = Vehicle Renewal Contract
        /// T = Vehicle Temporary Contract
        /// D = Driver Contract
        /// </summary>
        /// <param name="value"></param>
        protected void SetDocumentTypeFromAbbreviation(ContractBase value)
        {
            SetDocumentTypeFromAbbreviation(value.AContractTypeAbbreviation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void SetDocumentTypeFromAbbreviation(string value)
        {
            switch (value)
            {
                case "C":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
                case "R":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_RENEWAL;
                    break;
                case "T":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                    break;
                case "D":
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_DRIVER;
                    break;
                default:
                    this.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                    break;
            }
        }

        #endregion

		#region - protected virtual -


        /// <summary>
        /// Do this function after call retrive contract for retrive special data of drivied contract class e.g. VehicleContract)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="derivedContract"></param>
        protected virtual void RetriveDrivedContract(ContractBase derivedContract){}

		protected virtual void enableCalculate(bool enable)
		{}

		protected virtual void enableContractCharge(bool enable)
		{}
			
		protected virtual void addContractCharge(ContractBase value)
		{}

		protected virtual void visibleChild(bool visible)
		{}

		protected virtual bool validateContractCharge()
		{
			return true;
		}

		protected virtual void ClearContractCharge()
		{}

        protected virtual void ClearDeduct()
        { }

        protected virtual void SetLeaseTerm(VehicleContract vehicleContract)
        {}

        protected virtual void GetLeaseTerm(VehicleContract vehicleContract)
        {}

        protected virtual bool ValidateLeaseTerm()
        {
            return true;
        }

        protected virtual void EnableLeasTerm(bool enable)
        { }
		#endregion

        #region Mode Add & Update & Delete Contract
		private bool modeAddContract()
		{
			bool result = false;

			try
			{
				ContractType contractType = (ContractType)cboContractType.SelectedItem;

                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
				{
					if(facadeContract.ModeInsertContract(getNewVehicleContract()))
					{
						result = true;
						clearForm();
					}
				}
                else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
				{
					if(facadeContract.ModeInsertContract(getDriverContract()))	
					{
						result = true;
						clearForm();
					}
				}
                else if (contractType.Code == ContractType.CONTRACT_TYPE_OTHER)
				{
					if(facadeContract.ModeInsertContract(getServiceStaffContract()))
					{
						result = true;
						clearForm();
					}
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}			
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}

			return result;
		}

		private bool modeUpdateContract()
		{
			bool result = false;

			try
			{
				objContractBase = facadeContract.RetriveContract(getContractNo());		
				ContractType contractType = (ContractType)cboContractType.SelectedItem;

                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                {
                    if (facadeContract.ModeUpdateContract(getNewVehicleContract()))
                    {
                        result = true;
                        clearForm();
                    }
                }
                else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                {
                    if (docMatchNo != null)
                    {
                        if (facadeContract.ModeUpdateSpecificContract(getDriverContract(), GetSpecificVehicleContract(docMatchNo)))
                        {
                            result = true;
                            clearForm();
                        }
                    }
                    else
                    {
                        if (facadeContract.ModeUpdateContract(getDriverContract()))
                        {
                            result = true;
                            clearForm();
                        }
                    }                    
                }
                else if (contractType.Code == ContractType.CONTRACT_TYPE_OTHER)
                {
                    if (facadeContract.ModeUpdateContract(getServiceStaffContract()))
                    {
                        result = true;
                        clearForm();
                    }
                }                
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
		
			return result;
		}

		private bool modeDeleteContract()
		{
			bool result = false;

			try
			{
				ContractType contractType = (ContractType)cboContractType.SelectedItem;
                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
				{
                    //Validate vehicle purchase order : woranai 2008/12/23
					if( validateVehiclePurchasing(getContractNo()) && 
                        facadeContract.ModeDeleteContract(getVehicleContract()))
					{
						result = true;
						clearForm();
					}
				}
                else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
				{
					if(facadeContract.ModeDeleteContract(getDriverContract()))	
					{
						result = true;
						clearForm();
					}
				}
                else if (contractType.Code == ContractType.CONTRACT_TYPE_OTHER)
				{
					if(facadeContract.ModeDeleteContract(getServiceStaffContract()))
					{
						result = true;
						clearForm();
					}
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
	
			return result;
		}    		 
	    #endregion

		#region - Add & Update Mode -
		protected virtual void addCase()
		{
			mdiParent.EnableNewCommand(true);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);

			MainMenuNewStatus = true;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = false;
			MainMenuPrintStatus = false;

			addMode = true;
			hideGroupBox(true);
			gpbContractInfo.Enabled = true;
			enableContractControl(false);
            enablegpbDetail(true);
			gpbDeleteContract.Enabled = false;	
			cmdOK.Enabled = true;
			cmdCreateContract.Enabled = false;
			cboCustomerTHName.Focus();
            cboContractStatus.SelectedIndex = 0;
			cboKindOfContract.SelectedIndex = 0;
			fpiUnitHire.Value = 1;
			fpiUnitHire.BackColor = System.Drawing.Color.White;

			if(cboContractType.SelectedIndex != -1)
			{
				ContractType contractType = (ContractType)cboContractType.SelectedItem;
                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
				{
					hideVehicleAssign(true);
					enableDeleteButton(false);
				}
				else
				{
					hideVehicleAssign(false);
				}
                contractType = null;
			}
			enableCalculate(true);
			enableContractCharge(true);
			IsMustQuestion = false;

            //Add function for BTS Enhancement for year 2008 : woranai 2008/10/18
            enableNewVehicleContract();

            // clear contractType variable

            bool enable = !this.isReadonly;
            this.enableContractVehicleControl(enable);
            this.cboCustomerTHName.Enabled = enable;

            //=== init assigned department control ===
            this.enableAssignDepartmentControl(false);
		}

		private void updateCase()
		{
			mdiParent.EnableNewCommand(true);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);

			MainMenuNewStatus = true;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = false;
			MainMenuPrintStatus = false;

			updateMode = true;
			gpbContractInfo.Enabled = true;
			enableContractControl(false);
			gpbDeleteContract.Enabled = true;
            //cmdOK.Enabled = true;
			cmdCreateContract.Enabled = false;
			enableCalculate(true);
			enableContractCharge(true);
			setIsMustQuestion();
		}
		
		protected void selectContract(string contractType)
		{
			cboContractType.DataSource = facadeContract.DataSourceContractTypeList(contractType);
			cboContractType.Enabled = false;
		}

		protected void setPermission(bool value)
		{
			isReadonly = value;
		}

		#endregion - Add & Update Mode -

		#region - Add & Delete Vehicle -
		private void addVehicle()
		{
			FrmVehicleList dialogVehicleList = new FrmVehicleList();
			VehicleRole objVehicleRole = new VehicleRole();

			dialogVehicleList.IsVehicleAvailable = true;
            dialogVehicleList.ConditionStartDate = this.dtpContractStart.Value;
            dialogVehicleList.ConditionEndDate = this.dtpContractEnd.Value;

			dialogVehicleList.ShowDialog();
			if(dialogVehicleList.Selected)
			{
				objVehicle = dialogVehicleList.SelectedVehicle;
				objVehicleRole.AVehicle = objVehicle;
				if(checkConditionDuplicateVehicle(objVehicle))
				{
					objVehicleContract.AVehicleRoleList.Add(objVehicleRole);
					bindVehicleContract(objVehicleContract);
				}
			}
		}

		private void deleteVehicle()
		{
			try
			{
				VehicleRole objVehicleRole = new VehicleRole();
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					objVehicleRole.AVehicle = SelectedVehicle();
					objVehicleContract.AVehicleRoleList.Remove(objVehicleRole);
					bindVehicleContract(objVehicleContract);
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}
		#endregion - Add & Delete Vehicle -

		#region - Hide & Enable Control -
		private void hideGroupBox(bool visible)
		{
            gpbAssignment.Visible = visible;
            gpbDetail.Visible = visible;
            gpbDeleteContract.Visible = visible;
            gpbRemark.Visible = visible;
            cmdOK.Visible = visible;
            cmdCancel.Visible = visible;
		}

        private void hideCancelDate(bool visible)
		{
            lblCancelDate.Visible = visible;
            dtpCancelDate.Visible = visible;
		}

		private void hideVehicleAssign(bool enable)
		{
			gpbAssignment.Enabled = enable;
			gpbAssignment.Visible = enable;
		}

		private void enableGroupBox(bool enable)
		{
			gpbAssignment.Enabled =	enable;
            enablegpbDetail(enable);
			gpbDeleteContract.Enabled = enable;
		}

		private void enableContractControl(bool enable)
		{
			cboContractStatus.Enabled = enable;
			txtContractNoYY.Enabled = enable;
			txtContractNoMM.Enabled = enable;
			txtContractNoXXX.Enabled = enable;

            this.cboCustomerTHName.Enabled = enable;

            //D21018-BTS Contract Modification
            cboVehicleKindContract.Enabled = enable;

		}

		private void enableDeleteButton(bool enable)
		{
			cmdDelete.Enabled = enable;
			mniDelete.Enabled = enable;
		}

        private void enableAddButton(bool enable)
        {
            cmdAdd.Enabled = enable;
            mniAdd.Enabled = enable;
        }

		private void enableRadio(bool enable)
		{
			rdoDay.Enabled = enable;
			rdoMonth.Enabled = enable;
		}

		protected void initCombo()
		{
			objVehicleContract = new VehicleContract(facadeContract.GetCompany());
			cboCustomerTHName.DataSource  = facadeContract.DataSourceCustomerName;
			cboContractStatus.DataSource  = facadeContract.DataSourceContractStatus;
			cboKindOfContract.DataSource = facadeContract.DataSourceKindOfContract;

            //D21018-BTS Contract Modification
            if (documentType == DOCUMENT_TYPE.CONTRACT_TEMPORARY) 
            {
                List<string> kindContract = new List<string>() { "C", "R", "T" };
                cboVehicleKindContract.DataSource = kindContract;                
            }

			if (cboContractStatus.Items.Count>0)
			{
				cboContractStatus.SelectedIndex = -1;
				cboContractStatus.SelectedIndex = -1;
				cboContractStatus.Text = "";
			}
		}

        /// <summary>
        /// Enable screen for new temporary vehicle contract : woranai 2008/10/18
        /// </summary>
        private void enableNewVehicleContract()
        {
            ContractType contractType = this.convertToContractType();
            if (contractType != null)
            {
                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                {
                    this.selectKindOfContract(KindOfContract.KIND_OF_CONTRACT_TEMP);
                    this.cboKindOfContract.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Select item in kind of contract combobox that depend on selectedCode
        /// </summary>
        /// <param name="selectedCode"></param>
        private void selectKindOfContract(string selectedCode)
        {
            System.Collections.ArrayList dsKindOfContract = (System.Collections.ArrayList)this.cboKindOfContract.DataSource;
            int indexKindOfContractSource = 0;
            bool found = false;
            while ((indexKindOfContractSource < dsKindOfContract.Count) && (!found))
            {
                KindOfContract kind = (KindOfContract)dsKindOfContract[indexKindOfContractSource];
                if (kind.Code == selectedCode)
                {
                    this.cboKindOfContract.SelectedIndex = indexKindOfContractSource;
                    found = true;
                }
                indexKindOfContractSource++;
            }
        }

        /// <summary>
        /// Convert cboContractType selected value to ContractType object
        /// </summary>
        /// <returns></returns>
        private ContractType convertToContractType()
        {
            ContractType contractType = null;
            if (cboContractType.SelectedIndex != -1)
            {
                contractType = (ContractType)cboContractType.SelectedItem;
                if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                {
                    hideVehicleAssign(true);
                    //enableDeleteButton(false);
                }
                else
                {
                    hideVehicleAssign(false);
                }
            }
            return contractType;
        }

        /// <summary>
        /// Enable screen for update vehicle contract : woranai 2008/10/18
        /// </summary>
        private void enableLoadVehicleContract()
        {
            //TODO : Ya
            ContractType contractType = this.convertToContractType();
            if ((contractType != null) && (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE))
            {
                // check contract status
                ContractStatus contractStatus = (ContractStatus)this.cboContractStatus.SelectedItem;
                KindOfContract kindOfContract = (KindOfContract)this.cboKindOfContract.SelectedItem;

                switch (contractStatus.Code)
                {
                    case ContractStatus.CONTRACT_STS_CREATED:
                        if (kindOfContract.Code == KindOfContract.KIND_OF_CONTRACT_LONG)
                        {
                            this.cboCustomerTHName.Enabled = false;
                            this.cboKindOfContract.Enabled = false;
                            this.fpiUnitHire.Enabled = false;
                            this.gpbAssignment.Enabled = false;

                            this.enableCalculate(false);
                            this.enableContractCharge(false);
                            this.EnableLeasTerm(false);
                        }
                        else
                        {
                            this.cboKindOfContract.Enabled = false;
                        }
                        break;

                    case ContractStatus.CONTRACT_STS_APPROVED:

                        //Allow user edit data of contract is create before phase III : woranai 2009/04/09
                        //bool isEnable = (kindOfContract.Code != KindOfContract.KIND_OF_CONTRACT_LONG);
                        bool isEnable = facadeContract.GetPurchaseContractByContract(getContractNo()).Count == 0;
                        
                        this.dtpContractEnd.Enabled = isEnable;
                        this.enableContractCharge(isEnable);
                        this.EnableLeasTerm(isEnable);
                        
                        break;
                }
            }
        }
		#endregion - Hide & Enable Control -

		#region - Validate Input ContractNo -
        private bool validateInputContractNo(DOCUMENT_TYPE documentType)
        {
            return validatetxtContractNoYY() &&
                    validatetxtContractNoMM() &&
                    validatetxtContractNoXXX() &&
                    validateContractNo(documentType);
        }
        
		private bool validatetxtContractNoYY()
		{
			if(txtContractNoYY.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoYY.Focus();
				return false;
			}
			return true;
		}

		private bool validatetxtContractNoMM()
		{
			if(txtContractNoMM.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoMM.Focus();
				return false;
			}
			return true;
		}

		private bool validatetxtContractNoXXX()
		{
			if(txtContractNoXXX.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญา");
				txtContractNoXXX.Focus();
				return false;
			}
			return true;
		}

        private bool validateContractNo(DOCUMENT_TYPE documentType)
        {
            bool result = true;            
            //D21018-BTS Contract Modification
            this.objContractBase = facadeContract.RetriveContract(getContractNo());
            if (this.objContractBase == null)
            {
                Message(MessageList.Error.E0004, "เลขที่สัญญา");
                txtContractNoYY.Focus();
                result = false;
            }
            else
            {
                result = true;
            }

            if (result)
            {
                ContractType tempContractType = new ContractType();
                tempContractType = (ContractType)cboContractType.SelectedItem;
                //if(tempContract.AContractType.Code != tempContractType.Code)
                if (this.objContractBase.AContractType.Code != tempContractType.Code)
                {
                    Message(MessageList.Error.E0004, "เลขที่สัญญา");
                    txtContractNoYY.Focus();
                    result = false;
                }
                else
                {
                    result = true;
                }
                tempContractType = null;
            }
            //tempContract = null;
            return result;
        }       
		#endregion - Validate Input ContractNo -
		
		#region - Validate Input Checking -

		private bool validateInputChecking()
		{
            bool valid = validateCustomerTHName() && 
				validateContractType() && 
				validateContractStatus() && 
				validateKindOfContract() && 
				validateStartEndDate() &&
				validateUnitHire() &&
				validateContractCharge() &&
                ValidateLeaseTerm() && 
                this.validateAssignedDepartment() &&
                validateCustDept();

            if (!valid)
            {
                return false;
            }

            if (this.updateMode)
            {
                return this.validateUpdateAssignedDepartment();
            }

            return true;
		}

        /// <summary>
        /// Valdate assigned department value in update case
        /// </summary>
        /// <returns></returns>
        private bool validateUpdateAssignedDepartment()
        {
            if (facadeContract.ValidateAssignDepartmentPermission(this.objContractBase))
            {
                if (!facadeContract.ValidateMatchDepartment(this.objContractBase))
                {
                    base.Message(MessageList.Error.E0057);
                    return false;
                }
            }

            return true;
        }

		private bool validateCustomerTHName()
		{
			if(cboCustomerTHName.Text == "")
			{
				Message(MessageList.Error.E0005, "ชื่อลูกค้า");
				cboCustomerTHName.Focus();
				return false; 
			}
			return true;
		}

		private bool validateContractType()
		{
			if(cboContractType.Text == "")
			{
				Message(MessageList.Error.E0005, "ประเภทสัญญา");
				cboContractType.Focus();
				return false; 
			}
			return true;
		}

		private bool validateContractStatus()
		{
			if(cboContractStatus.Text == "")
			{
				Message(MessageList.Error.E0005, "สถานะสัญญา");
				cboContractStatus.Focus();
				return false;
			}
			return true;
		}
		
		private bool validateKindOfContract()
		{
			if(cboKindOfContract.Text == "")
			{
				Message(MessageList.Error.E0005, "ชนิดสัญญา");
				cboKindOfContract.Focus();
				return false; 
			}
			return true;
		}
		private bool validateStartEndDate()
		{
			if(dtpContractStart.Value.Date > dtpContractEnd.Value.Date)
			{
				Message(MessageList.Error.E0011,"วันที่เริ่มต้นสัญญา","วันที่สิ้นสุดสัญญา");
				dtpContractStart.Focus();
				return false; 
			}
			return true;
		}

		private bool validateUnitHire()
		{
			if(Convert.ToInt32(fpiUnitHire.Text) == 0)
			{
				Message(MessageList.Error.E0002,"จำนวน");
				fpiUnitHire.Focus();
				return false; 
			}
			return true;
		}

        private bool validateCustDept()
        {
            //if (cboCustomerDept.Items.Count > 1 && cboCustomerDept.Text == string.Empty)
            //{
            //    Message(MessageList.Error.E0005, "ฝ่าย");
            //    cboCustomerDept.Focus();
            //    return false; 
            //}

            return true;
        }


        /// <summary>
        /// Validate data when entry mode is update.
        /// </summary>
        /// <returns></returns>
        private bool validateUpdateMode()
        {
            if (!updateMode)
            {
                return false;
            }

            if (!ValidateAssignment())
            {
                return false;
            }

            if (!ValidateBizPacPeriod())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate assigned department
        /// </summary>
        /// <returns></returns>
        private bool validateAssignedDepartment()
        {
            TimePeriod contractPeriod = new TimePeriod();
            contractPeriod.From = this.dtpContractStart.Value;
            contractPeriod.To = this.dtpContractEnd.Value;

            using (ContractDepartmentAssignmentFacade facadeAssigned = new ContractDepartmentAssignmentFacade())
            {
                // === validate contract start date and end data ===
                List<ContractDepartmentAssignment> tempList = facadeAssigned.GetListByContract(objContractBase.ContractNo.ToString());

                if (tempList != null)
                {
                    if (!facadeAssigned.ValidateContractPeriodSubRange(tempList, contractPeriod))
                    {
                        base.Message(MessageList.Error.E0013, "บันทึกข้อมูล", "วันที่ในการกำหนดฝ่ายลูกค้าไม่อยู่ในช่วงสัญญา");
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Validate assigned department
        /// </summary>
        /// <returns></returns>
        private bool validateAssignedDepartment(DocumentNo contractNo)
        {
            using (ContractDepartmentAssignmentFacade facadeAssigned = new ContractDepartmentAssignmentFacade())
            {
                // === validate contract start date and end data ===
                ContractBase contractTemp = facadeContract.RetriveContract(contractNo);
                List<ContractDepartmentAssignment> listTemp = facadeAssigned.GetListByContract(contractNo.ToString());

                if (contractTemp != null && listTemp != null)
                {
                    if (!facadeAssigned.ValidateContractPeriodSubRange(listTemp, contractTemp.APeriod))
                    {
                        base.Message(MessageList.Error.E0013, "บันทึกข้อมูล", "วันที่ในการกำหนดฝ่ายลูกค้าไม่อยู่ในช่วงสัญญา");
                        return false;
                    }
                }

                return true;
            }
        }
		#endregion - Validate Input Checking -
		
		#region - Validate Condition Checking -			
		private bool checkConditionAmountVehicleContract()
		{
			ContractType contractType = (ContractType)cboContractType.SelectedItem;
			if(contractType.Code == "V" && Convert.ToInt32(fpiUnitHire.Text) != objVehicleContract.AVehicleRoleList.Count)
			{
				Message(MessageList.Error.E0015, "จำนวนรถในสัญญาไม่ถูกต้อง");
				return false;
			}
			return true;
		}

		private bool checkConditionDuplicateVehicle(Vehicle objVehicle)
		{
			if(objVehicleContract != null)
			{
				if(objVehicleContract.AVehicleRoleList.Contain(objVehicle))
				{
					Message(MessageList.Error.E0010);
					return false;
				}
				else
					return true;
			}
			return true;
		}

		private bool checkConditionVehicleAssignment(VehicleContract aVehicleContract)
		{
            if (dtgVehicleContract.RowCount != 0)
            {
                VehicleAssignment vehicleAssignment;
                Vehicle vehicle;

                for (int i = 0; i < dtgVehicleContract.RowCount; i++)
                {
                    vehicleAssignment = new VehicleAssignment();
                    vehicle = new Vehicle();

                    string strVehicleNo = dtgVehicleContract[1, i].Value.ToString();
                    vehicle.VehicleNo = int.Parse(dtgVehicleContract[0, i].Value.ToString());
                    vehicleAssignment.AAssignedVehicle = vehicle;
                    vehicleAssignment.APeriod.From = dtpContractStart.Value.Date;
                    vehicleAssignment.APeriod.To = dtpContractEnd.Value.Date;

                    if (facadeContract.FillExcludeAvailableVehicleSpareAssignment(ref vehicleAssignment))
                    {
                        if (addMode)
                        {
                            Message(MessageList.Error.E0013, "ระบุรถ " + strVehicleNo + " ในสัญญาได้", "รถคันนี้ถูกใช้งานในช่วงเวลาดังกล่าว");
                            return false;
                        }
                        else
                        {
                            if (vehicleAssignment.AContract.ContractNo.ToString() != aVehicleContract.ContractNo.ToString())
                            {
                                Message(MessageList.Error.E0013, "ระบุรถ " + strVehicleNo + " ในสัญญาได้", "รถคันนี้ถูกใช้งานในช่วงเวลาดังกล่าว");
                                return false;
                            }
                        }
                    }
                }

                vehicleAssignment = null;
                vehicle = null;
            }
			return true;
		}

		private bool checkConditionKindOfVehicle()
		{
            if (dtgVehicleContract.RowCount != 0)
            {
                for (int i = 0; i < dtgVehicleContract.RowCount; i++)
                {
                    if (dtgVehicleContract[4, i].Value.ToString() == "")
                    {
                        Message(MessageList.Error.E0005, "ประเภทรถ");
                        return false;
                    }
                }
            }
			return true;
		}

		private bool checkConditionSpareKindOfVehicle()
		{
            if (dtgVehicleContract.RowCount != 0)
            {
                KindOfVehicle kindOfVehicle;
                for (int i = 0; i < dtgVehicleContract.RowCount; i++)
                {
                    string temp = dtgVehicleContract[4, i].Value.ToString();
                    kindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];

                    if (kindOfVehicle.Code == "Z")
                    {
                        Message(MessageList.Error.E0029, "ประเภทรถ");
                        return false;
                    }
                }
            }
			return true;
		}

		private bool checkVehicleActive()
		{
            //Drop this process because user can advance assignment : woranai 2008/10/21
            //if (dtgVehicleContract.RowCount != 0)
            //{
            //    Vehicle vehicle;

            //    for (int i = 0; i < dtgVehicleContract.RowCount; i++)
            //    {
            //        string strVehicleNo = dtgVehicleContract[1, i].Value.ToString();
            //        vehicle = new Vehicle();
            //        vehicle.VehicleNo = int.Parse(dtgVehicleContract[0, i].Value.ToString());

            //        if (!facadeContract.FillVehicleActive(vehicle))
            //        {
            //            Message(MessageList.Error.E0013, "ระบุรถ " + strVehicleNo + " ในสัญญาได้", "รถคันนี้ไม่อยู่ในสถานะพร้อมใช้งาน");
            //            return false;
            //        }
            //    }
            //    vehicle = null;
            //}
			return true;
		}

        private bool ValidatePeriodAssignment(string contractType, DocumentNo contractNo)
        {
            AssignmentBase _assignment;

            _assignment = facadeContract.GetMaxAssignedByContract(contractType, contractNo);
            if (_assignment != null)
            {
                if (dtpContractEnd.Value < _assignment.APeriod.To)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateAssignment()
        {
            ContractType _contractType = (ContractType)cboContractType.SelectedItem;
            docMatchNo = null;

            if (((ContractStatus)cboContractStatus.SelectedItem).Code == "2" && ((DateTime)dtpContractEnd.Tag).Date != dtpContractEnd.Value.Date)
            {
                switch (_contractType.Code)
                {
                    case ContractType.CONTRACT_TYPE_VEHICLE:
                        docMatchNo = facadeContract.GetSpecificVDMatchByContract(_contractType, ((ContractBase)txtContractNoXXX.Tag).ContractNo);
                        if (docMatchNo != null)
                        {
                            Message(MessageList.Error.E0012, "บันทึกข้อมูลได้", "มีสัญญาพนักงานขับรถจับคู่กันอยู่", "แก้ไขระยะเวลาที่สัญญาพนักงานขับรถ");
                            return false;
                        }
                        if (!ValidatePeriodAssignment(ContractType.CONTRACT_TYPE_VEHICLE, ((ContractBase)txtContractNoXXX.Tag).ContractNo))
                        {
                            Message(MessageList.Error.E0012, "บันทึกข้อมูลได้", "ระยะเวลาของสัญญารถยนต์น้อยกว่าการจ่ายงาน", "แก้ไขการจ่ายงาน");
                            return false;
                        }
                        return true;
                    case ContractType.CONTRACT_TYPE_DRIVER:
                        if (!ValidatePeriodAssignment(ContractType.CONTRACT_TYPE_DRIVER, ((ContractBase)txtContractNoXXX.Tag).ContractNo))
                        {
                            Message(MessageList.Error.E0012, "บันทึกข้อมูลได้", "ระยะเวลาของสัญญาพนักงานขับรถน้อยกว่าการจ่ายงาน", "แก้ไขการจ่ายงาน");
                            return false;
                        }

                        docMatchNo = facadeContract.GetSpecificVDMatchByContract(_contractType, ((ContractBase)txtContractNoXXX.Tag).ContractNo);
                        if (docMatchNo != null)
                        {
                            if (Message(MessageList.Warning.W0006) == DialogResult.OK)
                            {
                                if (!ValidatePeriodAssignment(ContractType.CONTRACT_TYPE_VEHICLE, docMatchNo))
                                {
                                    Message(MessageList.Error.E0012, "บันทึกข้อมูลได้", "ระยะเวลาของสัญญารถยนต์น้อยกว่าการจ่ายงาน", "แก้ไขการจ่ายงาน");
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                    case ContractType.CONTRACT_TYPE_OTHER:
                        if (!ValidatePeriodAssignment(ContractType.CONTRACT_TYPE_OTHER, ((ContractBase)txtContractNoXXX.Tag).ContractNo))
                        {
                            Message(MessageList.Error.E0012, "บันทึกข้อมูลได้", "ระยะเวลาของสัญญาพนักงานบริการน้อยกว่าการจ่ายงาน", "แก้ไขการจ่ายงาน");
                            return false;
                        }
                        return true;
                    default:
                        return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ValidateBizPacPeriod()
        {
            if (updateMode && ((DateTime)dtpContractEnd.Tag).Date != dtpContractEnd.Value.Date)
            { 
                ContractChargeDetailList list = facadeContract.GetContractChargeDetailNoneBPNoList((ContractBase)txtContractNoXXX.Tag);

                if (list != null)
                {
                    YearMonth yearMonth = list[list.Count - 1].YearMonth;
                    DateTime toDate = new DateTime(yearMonth.Year, yearMonth.Month, DateTime.DaysInMonth(yearMonth.Year, yearMonth.Month));
                    
                    if (dtpContractEnd.Value.Date < toDate.Date)
                    {
                        Message(MessageList.Error.E0013, "บันทึกข้อมูลได้", "วันสิ้นสุดสัญญาน้อยกว่าวันที่ที่ถ่ายโอนข้อมูลเข้าสู่ BizPac");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool validateVehiclePurchasing(DocumentNo contractNo)
        {
            bool result = true;

            if (facadeContract.GetPurchasingContractListByContract(contractNo).Count > 0)
            {
                result = Message(MessageList.Question.Q0019, "สัญญาฉบับนี้ผูกกับใบสั่งซื้อ ระบบจะทำการลบรถออกจากระบบ") == DialogResult.Yes;
            }

            return result;
        }
		#endregion - Validate Condition Checking -

        #region Base Event

        public void InitForm()
        {
            bool result = true;

            try
            {
                if (this.updateMode && this.objContractBase != null)
                {
                    result = validateUpdateAssignedDepartment() && validateAssignedDepartment(this.objContractBase.ContractNo);
                }

                if (result)
                {
                    mdiParent = (frmMain)this.MdiParent;
                    clearMainMenuStatus();

                    this.KindOfVehicle.Items.Clear();
                    for (int i = 0; i < facadeContract.DataSourceKindOfVehicle.Count; i++)
                    {
                        this.KindOfVehicle.Items.Add(facadeContract.DataSourceKindOfVehicle[i].ToString());
                    }
                    clearForm();
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }

            if (isReadonly)
            {
                cmdCreateContract.Enabled = false;
            }
        }

        public void RefreshForm()
        {
            try
            {
                retriveContract(facadeContract.RetriveContract(getContractNo()));
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            bool result = true;
            IsMustQuestion = false;

            if (this.updateMode && this.objContractBase != null)
            {
                result = validateUpdateAssignedDepartment() && validateAssignedDepartment(this.objContractBase.ContractNo);
            }

            if (result)
            {
                Dispose(true);
            }
        } 
        #endregion

        #region Form Event

        private void FrmContractBase_Load(object sender, System.EventArgs e)
        {
            
        }

        private void cboCustomerTHName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            if (cboCustomerTHName.SelectedIndex != -1)
            {
                Customer customer = (Customer)cboCustomerTHName.SelectedItem;
                cboCustomerDept.DataSource = facadeContract.DataSourceCustomerDept(customer);
                cboCustomerDept.Text = "";
            }

            //=== init assigned department control ===
            bool hasAssignedDepartmentPermission = this.hasAssignDepartmentPermission();
            this.enableAssignDepartmentControl(hasAssignedDepartmentPermission);
        }

        private void cboContractType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //D21018-BTS Contract Modification
            if (cboContractType.SelectedIndex != -1)
            {
                ContractType contractType = (ContractType)cboContractType.SelectedItem;
                ControlPrefix(contractType);
            }
        }

        private void txtContractNoXXX_DoubleClick(object sender, System.EventArgs e)
        {
            formContractList();
        }

        private void txtContractNoYY_TextChanged(object sender, System.EventArgs e)
      {
            if (txtContractNoYY.Text.Length == 2)
                txtContractNoMM.Focus();
        }

        private void txtContractNoMM_TextChanged(object sender, System.EventArgs e)
        {
            if (txtContractNoMM.Text.Length == 2)
                txtContractNoXXX.Focus();
        }

        private void txtContractNoXXX_TextChanged(object sender, System.EventArgs e)
        {
            if (isTextChange)
            {
                if (!addMode)
                {
                    if (txtContractNoXXX.Text.Length == 3)
                    { 
                        if (validateInputContractNo(documentType))
                        {
                            retriveContract(facadeContract.RetriveContract(getContractNo())); 
                        }
                    }
                }
            }
        }

        private void txtContractNoXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                if (!addMode)
                    if (validateInputContractNo(documentType))
                        retriveContract(facadeContract.RetriveContract(getContractNo()));
        }

        private void cmdCreateContract_Click(object sender, System.EventArgs e)
        {             
            addCase();            
            retriveRunningNo(DocumentType);
            fpiUnitHire.BackColor = System.Drawing.Color.White;
        }

        private void cmdDeleteContract_Click(object sender, System.EventArgs e)
        {
            if (Message(MessageList.Question.Q0002, "ลบสัญญา", "คืนข้อมูล", "ลบสัญญา") == DialogResult.Yes)
            {
                modeDeleteContract(); 
            }
        }

        private void cmdAdd_Click(object sender, System.EventArgs e)
        {
            addVehicle();
        }

        private void cmdDelete_Click(object sender, System.EventArgs e)
        {
            deleteVehicle();
        }

        private void mniAdd_Click(object sender, System.EventArgs e)
        {
            addVehicle();
        }

        private void mniDelete_Click(object sender, System.EventArgs e)
        {
            deleteVehicle();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            //=== Assign vairables ===

            this.objContractBase = this.getContractBaseEntry();

            //=== Validate can assign department or not? ===

            this.isCanAssignDepartment = facadeContract.ValidateAssignDepartmentPermission(this.objContractBase);
            if (this.isCanAssignDepartment)
            {
                this.setAssignedDepartmentToContractProperty<ContractBase>(this.objContractBase);
            }

            //=== Do process save ===

            if (validateInputChecking())
            {
                if (checkConditionAmountVehicleContract() &&
                    checkConditionVehicleAssignment(objVehicleContract) &&
                    checkConditionKindOfVehicle() &&
                    checkConditionSpareKindOfVehicle())
                {
                    if (addMode && checkVehicleActive())
                    {
                        if (modeAddContract())
                        {
                            InitForm();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else if (updateMode && ValidateAssignment() && ValidateBizPacPeriod())
                    {
                        if (modeUpdateContract())
                        {
                            InitForm();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            if (cmdOK.Enabled && IsMustQuestion && !isReadonly)
            {
                DialogResult result = Message(MessageList.Question.Q0003);
                if (result == DialogResult.Yes)
                {
                    if (validateInputChecking())
                    {
                        if (checkConditionAmountVehicleContract() &&
                            checkConditionVehicleAssignment(objVehicleContract) &&
                            checkConditionKindOfVehicle() &&
                            checkConditionSpareKindOfVehicle())
                        {
                            if (addMode && checkVehicleActive())
                            {
                                if (modeAddContract())
                                {
                                    ExitForm();
                                }
                            }
                            else if (updateMode && ValidateAssignment() && ValidateBizPacPeriod())
                            {
                                if (modeUpdateContract())
                                {
                                    ExitForm();
                                }
                            }
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    ExitForm();
                }
                else if (result == DialogResult.Cancel)
                { 
                    this.Show(); 
                }
            }
            else
            {
                ExitForm();
            }
        }

        private void cboKindOfContract_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            KindOfContract kindOfContract;
            if (cboKindOfContract.SelectedIndex != -1)
            {
                kindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
                if (kindOfContract.Code == "L")
                {
                    rdoMonth.Checked = true;
                    enableRadio(false);
                }
                else
                {
                    rdoDay.Checked = true;
                    enableRadio(true);
                }
            }
        }

        private void dtpContractStart_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            if (dtpContractStart.Value <= dtpContractEnd.Value)
            {
                calLeasingPeriod();
            }
            else
            {
                clearLeasingPeriod();
            }
        }

        private void dtpContractEnd_ValueChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
            if (dtpContractStart.Value <= dtpContractEnd.Value)
            {
                calLeasingPeriod();
            }
            else
            {
                clearLeasingPeriod();
            }
        }

        private void cboCustomerDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void fpdTotalChargeAmt_TextChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void cboContractStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (updateMode)
            { setIsMustQuestion(); }
        }

        private void fpiUnitHire_TextChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void rdoDay_CheckedChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void rdoMonth_CheckedChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void txtRemark_TextChanged(object sender, System.EventArgs e)
        {
            setIsMustQuestion();
        }

        private void btnAssignedDepartment_Click(object sender, EventArgs e)
        {
            //TODO : P'Ya
            FrmDepartmentAssignment frmDepartmentAssignment = new FrmDepartmentAssignment();
            frmDepartmentAssignment.AssignmentDepartmentFinished += new FrmDepartmentAssignment.FinishAssignmentDepartmentEventHandler(FrmDepartmentAssignment_FinishAssignmentDepartmentEventHandler);


            // === assing mode and contract properties ===
            if (this.addMode)
            {
                frmDepartmentAssignment.ContractMode = EntryMode.Add;
            }
            else if (this.updateMode)
            {
                frmDepartmentAssignment.ContractMode = EntryMode.Update;
            }

            // === assign department ===
            Customer customer = (Customer)this.cboCustomerTHName.SelectedItem;
            CustomerDepartment department = (CustomerDepartment)this.cboCustomerDept.SelectedItem;

            frmDepartmentAssignment.CurrentCustomer = (Customer)this.cboCustomerTHName.SelectedItem;
            frmDepartmentAssignment.DefaultDepartment = (CustomerDepartment)this.cboCustomerDept.SelectedItem;

            this.fillAssignmentPropertiesToContract();
            frmDepartmentAssignment.CurrentContract = this.objContractBase;

            // === show dialog box
            frmDepartmentAssignment.ShowDialog();
        }

        private void FrmDepartmentAssignment_FinishAssignmentDepartmentEventHandler(object sender, List<ContractDepartmentAssignment> list)
        {
            this.assignedDepartmentList = list;
        }

        private void FrmContractBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.updateMode && this.objContractBase != null && !validateUpdateAssignedDepartment() && !validateAssignedDepartment(this.objContractBase.ContractNo))
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region ISaveForm Members
        public bool SaveForm()
		{
			if(!cmdCreateContract.Enabled && validateInputChecking())
			{
				if(	checkConditionAmountVehicleContract() &&
					checkConditionVehicleAssignment(objVehicleContract)&&
					checkConditionKindOfVehicle()&& 
					checkConditionSpareKindOfVehicle())
				{
					if(addMode && checkVehicleActive())
					{
						if(modeAddContract())
						{
							InitForm();
							return true;
						}
					}
					if(updateMode)
					{
						if(modeUpdateContract() && ValidateAssignment() && ValidateBizPacPeriod())
						{
							InitForm();
							return true;
						}
					}
				}
			}	
			return false;
		}
		#endregion

        #region Department Assignment Members

        /// <summary>
        /// Fill neccessary for assign department to contract object
        /// </summary>
        /// <returns></returns>
        private void fillAssignmentPropertiesToContract()
        {
            if (this.objContractBase == null)
            {
                this.objContractBase = new ContractBase();
            }
            if (this.objContractBase.APeriod == null)
            {
                this.objContractBase.APeriod = new TimePeriod();
            }
            this.objContractBase.APeriod.From = this.dtpContractStart.Value;
            this.objContractBase.APeriod.To = this.dtpContractEnd.Value;

            this.objContractBase.ACustomerDepartment = (CustomerDepartment)this.cboCustomerDept.SelectedItem;
            this.objContractBase.ACustomer = (Customer)this.cboCustomerTHName.SelectedItem;

            if (this.updateMode)
            {
                //D21018-BTS Contract Modification
                this.objContractBase.ContractNo = this.getContractNo(this.documentType);
            }
        }

        /// <summary>
        /// Check permission to assign department for new mode
        /// </summary>
        /// <returns></returns>
        private bool hasAssignDepartmentPermission()
        {
            return this.hasAssignDepartmentPermission(string.Empty);
        }

        /// <summary>
        /// Check permission to assign department by contract status
        /// </summary>
        /// <returns></returns>
        private bool hasAssignDepartmentPermission(string contractStatusCode)
        {
            //=== check add mode ===

            if (this.addMode)
            {
                return false;
            }

            //=== check customer ===

            Customer customer = (Customer)this.cboCustomerTHName.SelectedItem;
            if (customer.Code != CustomerCodeValue.TIS)
            {
                return false;
            }

            //=== check contract type ===

            ContractType contractType = (ContractType)cboContractType.SelectedItem;
            if (!((contractType.Code == ContractType.CONTRACT_TYPE_DRIVER) || (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)))
            {
                return false;
            }

            if ((contractStatusCode == ContractStatus.CONTRACT_STS_CANCELLED) || (contractStatusCode == ContractStatus.CONTRACT_STS_EXPIRED))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Disable/Enable contract department assignment control
        /// </summary>
        /// <param name="enable"></param>
        private void enableAssignDepartmentControl(bool enable)
        {
            this.btnAssignedDepartment.Enabled = enable;
        }

        /// <summary>
        /// Bind contract department assignment control after load contract
        /// </summary>
        /// <param name="contract"></param>
        private void bindAssignDepartmentControl(ContractBase contract)
        {
            //=== init assigned department control ===
            bool hasAssignedDepartmentPermission = this.facadeContract.ValidateAssignDepartmentPermission(contract); //this.hasAssignDepartmentPermission(contract.AContractStatus.Code);
            this.enableAssignDepartmentControl(hasAssignedDepartmentPermission);
        }

        /// <summary>
        /// Assign value to contract department assignment of contract property before save
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contract"></param>
        private void setAssignedDepartmentToContractProperty<T>(T contract) where T : ContractBase
        {
            if (this.assignedDepartmentList != null)
            {
                contract.AssignedDepartmentList = this.assignedDepartmentList;
                ContractDepartmentAssignmentFacade.SetContractBaseProperty(contract.AssignedDepartmentList, contract);
            }
            else
            {
                contract.AssignedDepartmentList = null;
            }
        }

        #endregion

        #region Controls Members

        /// <summary>
        /// Get customer department object from combo box
        /// </summary>
        /// <returns></returns>
        private CustomerDepartment GetSelectDepartment()
        {
            CustomerDepartment department =  (CustomerDepartment)this.cboCustomerDept.SelectedItem;

            return department;
        }

        #endregion

        #region Other Members

        /// <summary>
        /// Assign control properties to object
        /// </summary>
        /// <returns></returns>
        private ContractBase getContractBaseEntry()
        {
            ContractBase contractBase = new ContractBase();

            //contractBase.ContractNo = this.getContractNo();
            contractBase.ContractNo = this.getContractNo(documentType);
            contractBase.AContractType = (ContractType)this.cboContractType.SelectedItem;
            contractBase.AContractStatus = (ContractStatus)this.cboContractStatus.SelectedItem;
            contractBase.ACustomer = (Customer)this.cboCustomerTHName.SelectedItem;
            contractBase.ACustomerDepartment = (CustomerDepartment)this.cboCustomerDept.SelectedItem;
            contractBase.ACustomerDepartment.ACustomer = contractBase.ACustomer;

            if (this.objContractBase != null)
            {
                contractBase.AssignedDepartmentList = this.objContractBase.AssignedDepartmentList;
            }

            return contractBase;
        }

        #endregion
       
    }
}