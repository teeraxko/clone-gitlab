using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using Facade.ContractFacade;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using SystemFramework.AppMessage;
using Entity.CommonEntity;
using PTB.BTS.Contract.Flow;
using ictus.Common.Entity;
using Facade.VehicleFacade;
using Facade.CommonFacade;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.ContractGUI
{
    public partial class FrmReportContractAttachment : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private AttachmentFacade facadeAttachment;

        private ContractAttachment objContractAttachment;

        private frmMain mdiParent;
        private DocumentNo attachmentNo;
        private bool addMode = false;

        private ModelTypeFacade facadeModelType = new ModelTypeFacade();

        #endregion                
              

        public FrmReportContractAttachment()
            : base()
        {
            InitializeComponent();            
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractAttachment");
        }

        #region Private method

        private void InitComboCustomer()
        {
            cboCustomerTHName.DataSource = facadeContract.DataSourceCustomerName;
        }

        private void InitComboModelType() 
        {
            cboModelType.DataSource = facadeModelType.ContractAttachmentModelTypeDataSourceName;
            cboModelType.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear data and set initial state of control
        /// </summary>
        private void ClearScreen()
        {
            addMode = false;

            InitComboCustomer();
            InitComboModelType();

            txtAttachmentNoYY.Focus();
            txtAttachmentNoYY.Text = string.Empty;
            txtAttachmentNoMM.Text = string.Empty;
            txtAttachmentNoXXX.Text = string.Empty;                      

            ControlBottomButton(addMode);            
            dgvAttachmentDetailList.Rows.Clear();
        }

        /// <summary>
        /// Set control state in search group
        /// </summary>
        /// <param name="enable"></param>
        private void EnableSearchDetail(bool enable)
        {            
            cboCustomerTHName.Enabled = enable;
            cboModelType.Enabled = enable;
            txtAttachmentNoMM.Enabled = enable;
            txtAttachmentNoXXX.Enabled = enable;
            txtAttachmentNoYY.Enabled = enable;
            btnPrint.Enabled = enable;
            btnCreateNew.Enabled = enable;           
        }        

        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            MainMenuNewStatus = false;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;

            mdiParent.EnableNewCommand(false);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);

            ClearScreen();
            EnableSearchDetail(true);
            btnPrint.Enabled = false;

            facadeAttachment = new AttachmentFacade();
            objContractAttachment = new ContractAttachment(facadeContract.GetCompany());
            objContractAttachment.AAttachmentDetailList = new AttachmentDetailList(facadeContract.GetCompany());
        }               

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {
            CreateReport();
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region - Event-

        private void FrmReportContractAttachment_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }      
     
        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintForm();
        }

        /// <summary>
        /// Show Contract Attachment Report
        /// </summary>
        private void CreateReport()
        {
            DocumentNo attachmentNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT, txtAttachmentNoYY.Text, txtAttachmentNoMM.Text, txtAttachmentNoXXX.Text);
            FrmrptContractAttachmentReport frmAttachmentReport = new FrmrptContractAttachmentReport();
            frmAttachmentReport.ConditionAttachmentNo = attachmentNo;
            frmAttachmentReport.Show();
        }
        /// <summary>
        /// Create new contract attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if (ValidateCustomer() && ValidateModelType())
            {
                addCase();
                RetriveRunningNo();
                EnableSearchDetail(false);
            }
        }

        /// <summary>
        /// Set state for new document
        /// </summary>
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
            btnCreateNew.Enabled = false;
            ControlBottomButton(addMode);
        }

        /// <summary>
        /// Set control state after retrive contract
        /// </summary>
        private void SetControlViewCase()
        {
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);

            MainMenuNewStatus = true;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;

            addMode = false;

            ControlBottomButton(addMode);
            EnableSearchDetail(false);

            btnPrint.Enabled = true;

        }

        private void txtAttachmentNoYY_TextChanged(object sender, EventArgs e)
        {
            if (txtAttachmentNoYY.Text.Length == 2)
                txtAttachmentNoMM.Focus();
        }

        private void txtAttachmentNoMM_TextChanged(object sender, EventArgs e)
        {
            if (txtAttachmentNoMM.Text.Length == 2)
                txtAttachmentNoXXX.Focus();
        }

        private void txtAttachmentNoXXX_TextChanged(object sender, EventArgs e)
        {
            if (!addMode)
            {
                if (txtAttachmentNoXXX.Text.Length == 3)
                {
                    if (validateInputContractAttachmentNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT))
                    {
                        RetriveContractAttachment(facadeAttachment.RetriveContractAttachment(GetContractAttachmentNo()));
                        SetControlViewCase();
                    }
                }
            }
        }

        /// <summary>
        /// Double click to show the attachment list according to the selected condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAttachmentNoXXX_DoubleClick(object sender, EventArgs e)
        {
            FormContractAttachmentList();
        }

        /// <summary>
        /// show the attachment list according to the selected condition
        /// </summary>
        private void FormContractAttachmentList()
        {

            FrmContractAttachmentList dialogAttachmentList = new FrmContractAttachmentList();

            if (cboCustomerTHName.Text != "")
                dialogAttachmentList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;
            DocumentNo attachmentNo = GetContractAttachmentNo();
            dialogAttachmentList.ConditionAttachmentNo = attachmentNo;

            if (cboModelType.Text != "")
                dialogAttachmentList.ConditionModelType = (ModelType)cboModelType.SelectedItem;

            dialogAttachmentList.ShowDialog();
            if (dialogAttachmentList.Selected)
                RetriveContractAttachment(dialogAttachmentList.SelectedContractAttachment);

            dialogAttachmentList = null;
            
        }

        /// <summary>
        /// Control the button at the bottom of the screen.
        /// </summary>
        /// <param name="isAddingMode"></param>
        private void ControlBottomButton(bool isAddingMode)
        {
            btnAdd.Enabled = isAddingMode;
            btnDelete.Enabled = isAddingMode;
            btnOK.Enabled = isAddingMode;
            btnCancel.Enabled = isAddingMode;

            if (!isAddingMode)
            {
                btnOK.Enabled = !isAddingMode;
                btnCancel.Enabled = !isAddingMode;                
            }
        }

        /// <summary>
        /// Retrive new running no.
        /// </summary>
        private void RetriveRunningNo()
        {
            attachmentNo = facadeAttachment.RetriveRunningNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT);
            objContractAttachment.AttachmentNo = attachmentNo;
            txtAttachmentNoYY.Text = attachmentNo.Year;
            txtAttachmentNoMM.Text = attachmentNo.Month;
            txtAttachmentNoXXX.Text = attachmentNo.No;
        }

        /// <summary>
        /// Validate Customer
        /// </summary>
        /// <returns></returns>
        private bool ValidateCustomer()
        {
            if (cboCustomerTHName.Text == "")
            {
                Message(MessageList.Error.E0005, "ลูกค้า");
                cboCustomerTHName.Focus();               
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate ModelType
        /// </summary>
        /// <returns></returns>
        private bool ValidateModelType()
        {

            if (string.IsNullOrEmpty(cboModelType.Text))
            {
                Message(MessageList.Error.E0005, "ชนิดรถ");
                cboModelType.Focus();
                return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// Show vehicle contract list match with the condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FromVehicleContractList();
        }


        /// <summary>
        /// Show vehicle contract list
        /// </summary>
        private void FromVehicleContractList()
        {
            FrmVehicleContractList dialogContractList = new FrmVehicleContractList();
            if (cboCustomerTHName.Text != "")
                dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;

            if (cboModelType.Text != "")
                dialogContractList.ConditionModelType = (ModelType)cboModelType.SelectedItem;

            dialogContractList.IsMultiSelection = true;
            dialogContractList.WindowState = FormWindowState.Normal;
            dialogContractList.StartPosition = FormStartPosition.CenterParent;
            dialogContractList.ShowDialog(this);
            if (dialogContractList.Selected)
            {
                BindVehicleContractList(dialogContractList.SelectedContractList);
            }

            dialogContractList = null;
        }


        /// <summary>
        /// Bind contract list/attachment detail to form
        /// </summary>
        /// <param name="vehicleContractList"></param>
        private void BindVehicleContractList(List<ContractBase> vehicleContractList)
        {
            if (vehicleContractList != null && vehicleContractList.Count > 0)
            {
                for (int i = 0; i < vehicleContractList.Count; i++)
                {
                    AddVehicleContractListToGrid(vehicleContractList[i]);
                }
            }
            BindAttachmentDetail(objContractAttachment.AAttachmentDetailList);
        }

        /// <summary>
        /// Add contract to grid view but ignore if exist.
        /// </summary>
        /// <param name="contract"></param>
        private void AddVehicleContractListToGrid(ContractBase contract)
        {
            if (IsContractNotInGrid(contract))
            {
                AttachmentDetail ad = new AttachmentDetail();
                ad.AContract = contract;
                ad.AVehicleContract = (VehicleContract)contract;
                ad.ContractNo = contract.ContractNo;
                objContractAttachment.AAttachmentDetailList.Add(ad);
            }
        }

        /// <summary>
        /// Check the contract already in grid or not 
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        private bool IsContractNotInGrid(ContractBase contract)
        {
            //compare contract no
            DataGridViewRow row = dgvAttachmentDetailList.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[1].Value.ToString().Equals(contract.ContractNo.ToString())).FirstOrDefault();
            return row == null;
        }
        private void txtAttachmentNoXXX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                if (!addMode)
                    if (validateInputContractAttachmentNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT))
                    {
                        RetriveContractAttachment(facadeAttachment.RetriveContractAttachment(GetContractAttachmentNo()));
                    }
        }


        /// <summary>
        /// Get contract no
        /// </summary>
        /// <returns></returns>
        private DocumentNo GetContractAttachmentNo()
        {

            attachmentNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT, txtAttachmentNoYY.Text, txtAttachmentNoMM.Text, txtAttachmentNoXXX.Text);
            return attachmentNo;
        }

        /// <summary>
        /// Show contract attachment info on form.
        /// </summary>
        /// <param name="value"></param>
        private void BindForm(ContractAttachment value)
        {
            txtAttachmentNoYY.Text = value.AttachmentNo.Year;
            txtAttachmentNoMM.Text = value.AttachmentNo.Month;
            txtAttachmentNoXXX.Text = value.AttachmentNo.No;
            txtAttachmentNoXXX.Tag = value;
            cboCustomerTHName.Text = value.ACustomer.ToString();
            cboModelType.Text = GUIFunction.GetString(value.AModelType);
            BindAttachmentDetail(value.AAttachmentDetailList);

        }

        /// <summary>
        /// Bind Contract Attachment Detail to gridview
        /// </summary>
        /// <param name="attachmentDetailList"></param>
        private void BindAttachmentDetail(AttachmentDetailList attachmentDetailList)
        {
            dgvAttachmentDetailList.Rows.Clear();

            if (attachmentDetailList.Count > 0)
            {
                dgvAttachmentDetailList.RowCount = attachmentDetailList.Count;

                for (int i = 0; i < attachmentDetailList.Count; i++)
                {
                    BindAttachmentDetail(i, attachmentDetailList[i]);
                }
            }
        }

        private void BindAttachmentDetail(int row, AttachmentDetail attachmentDetail)
        {
            dgvAttachmentDetailList[0, row].Value = GUIFunction.GetString(attachmentDetail.EntityKey);
            dgvAttachmentDetailList[1, row].Value = GUIFunction.GetString(attachmentDetail.AVehicleContract.ContractNo.ToString());
            dgvAttachmentDetailList[2, row].Value = GUIFunction.GetString(attachmentDetail.AContract.AContractType.AName.Thai);

            VehicleRoleList objVehicleRole = attachmentDetail.AVehicleContract.AVehicleRoleList;
            string vehiclePlanteNo = String.Empty;
            if (objVehicleRole != null && objVehicleRole.Count>0)
            {
                vehiclePlanteNo = attachmentDetail.AVehicleContract.AVehicleRoleList[attachmentDetail.AVehicleContract.AVehicleRoleList.Count - 1].AVehicle.PlateNumber;
            }
            dgvAttachmentDetailList[3, row].Value = vehiclePlanteNo;
            dgvAttachmentDetailList[4, row].Value = GUIFunction.GetString(attachmentDetail.AContract.APeriod.From.Date.ToShortDateString());
            dgvAttachmentDetailList[5, row].Value = GUIFunction.GetString(attachmentDetail.AContract.APeriod.To.Date.ToShortDateString());
            dgvAttachmentDetailList[6, row].Value = GUIFunction.GetString(attachmentDetail.AContract.AKindOfContract.AName.Thai);
            
        }

        private void RetriveContractAttachment(ContractAttachment contractAttachment)
        {
            BindForm(contractAttachment);            
        }

        private bool validateInputContractAttachmentNo(DOCUMENT_TYPE documentType)
        {
            return ValidatetxtContractAttachmentNoYY() &&
                    ValidatetxtContractAttachmentNoMM() &&
                    ValidatetxtContractAttachmentNoXXX() &&
                    ValidateContractAttachmentNo(documentType);
        }

        private bool ValidatetxtContractAttachmentNoYY()
        {
            if (txtAttachmentNoYY.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่เอกสารแนบ");
                txtAttachmentNoYY.Focus();
                return false;
            }
            return true;
        }

        private bool ValidatetxtContractAttachmentNoMM()
        {
            if (txtAttachmentNoMM.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่เอกสารแนบ");
                txtAttachmentNoMM.Focus();
                return false;
            }
            return true;
        }

        private bool ValidatetxtContractAttachmentNoXXX()
        {
            if (txtAttachmentNoXXX.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่เอกสารแนบ");
                txtAttachmentNoXXX.Focus();
                return false;
            }
            return true;
        }

        private bool ValidateContractAttachmentNo(DOCUMENT_TYPE documentType)
        {
            bool result = true;
            this.objContractAttachment = facadeAttachment.RetriveContractAttachment(GetContractAttachmentNo());
            if (this.objContractAttachment == null)
            {
                Message(MessageList.Error.E0004, "เลขที่เอกสารแนบ");
                txtAttachmentNoYY.Focus();
                result = false;
            }
            else
            {
                result = true;
            }
         
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (addMode)
            {
                SaveAttachment();
            }
            else
            {
                ExitForm();
            }
        }


        private void SaveAttachment()
        {
            
            //=== Do process save ===

            if (IsValidInput())
            {
                if (ModeAddContractAttachment())
                {
                    DocumentNo attachmentNo = this.objContractAttachment.AttachmentNo;
                    InitForm();
                    RetriveContractAttachment(facadeAttachment.RetriveContractAttachment(attachmentNo));
                    SetControlViewCase();
                    Message(MessageList.Information.I0001);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool IsValidInput()
        {
            bool isValid = false;

            isValid = dgvAttachmentDetailList.Rows.Count > 0;
            if (!isValid)
            {
                Message(MessageList.Error.E0005, "สัญญารถเช่า อย่างน้อย 1 รายการ");
            }

            return isValid;
        }


        /// <summary>
        /// Add contract attachment
        /// </summary>
        /// <returns></returns>
        private bool ModeAddContractAttachment()
        {
            bool result = false;

            try
            {                                
                PrepareNewContractAttachment();
                if (facadeAttachment.ModeInsertAttachment(objContractAttachment))
                {
                    result = true;
                    ClearScreen();
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

            return result;
        }

        /// <summary>
        /// Set Customer and model type to Attachment
        /// </summary>
        private void PrepareNewContractAttachment()
        {
            objContractAttachment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
            objContractAttachment.AModelType = (ModelType)cboModelType.SelectedItem;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveSelectedFromGrid();
        }
                    
        /// <summary>
        /// Remove selected from grid and datasource
        /// </summary>
        private void RemoveSelectedFromGrid()
        {
            for (int i = 0; i < dgvAttachmentDetailList.Rows.Count; i++)
            {
                DataGridViewRow dgvr = dgvAttachmentDetailList.Rows[i];
                if(dgvr.Selected){
                    string contractNo = dgvr.Cells[1].Value.ToString();
                    this.objContractAttachment.AAttachmentDetailList.Remove(contractNo);
                }
                
            }
            BindAttachmentDetail(this.objContractAttachment.AAttachmentDetailList);
        }
    }
}
