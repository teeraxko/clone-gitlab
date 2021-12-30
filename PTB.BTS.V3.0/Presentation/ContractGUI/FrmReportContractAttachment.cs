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

namespace Presentation.ContractGUI
{
    public partial class FrmReportContractAttachment : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private ContractFacadeBase facadeContract = new ContractFacadeBase();
        private AttachmentFacade facadeAttachment = new AttachmentFacade();
        private AttachmentHead objAttachmentHead;
        private AttachmentDetail objAttachmentDetail;
        private frmMain mdiParent;
        private DocumentNo atttachmentNo;
        private bool addMode = false;
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
            cboCustomerName.DataSource = facadeContract.DataSourceCustomerName;
        }

        private void InitComboModelType() 
        {
            cboModelType.DataSource = facadeAttachment.ModelTypeDataSourceName();
            cboModelType.SelectedIndex = 0;
        }

        private void Clearscreen()
        {
            InitComboCustomer();
            InitComboModelType();

            txtAttachmentNoYY.Text = string.Empty;
            txtAttachmentNoMM.Text = string.Empty;
            txtAttachmentNoXXX.Text = string.Empty;
                       
            EnableSearchDetail(true);

            btnAdd.Enabled = false;
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void EnableSearchDetail(bool enable)
        {
            cboCustomerName.Enabled = enable;
            txtAttachmentNoMM.Enabled = enable;
            txtAttachmentNoXXX.Enabled = enable;
            txtAttachmentNoYY.Enabled = enable;
            btnPrint.Enabled = !enable;
            btnCreateNew.Enabled = enable;           
        }

        private void CreateNewAttachment() 
        {
            if (string.IsNullOrEmpty(cboCustomerName.Text))
            {
                Message(MessageList.Error.E0005, "ลูกค้า");
                cboCustomerName.Focus();               
            }
            else
            {
                if (string.IsNullOrEmpty(cboModelType.Text))
                {
                    Message(MessageList.Error.E0005, "ชนิดรถ");
                    cboModelType.Focus();
                }
                else 
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

                    gpbContractInfo.Enabled = false;

                    #region แปะไว้ก่อน
                    AttachmentHead objAttachmentHead = new AttachmentHead();
                    objAttachmentHead.AttachmentNo = facadeAttachment.RetriveRunningNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT);
                    objAttachmentHead.CompanyCode = facadeAttachment.GetCompany();
                    objAttachmentHead.CustomerCode = (Customer)cboCustomerName.SelectedItem;
                    objAttachmentHead.ModelVehicleType = (ModelType)cboModelType.SelectedItem;
                    objAttachmentHead.ProcessDate = DateTime.Now;
                    //objAttachmentHead.ProcessUser = GetDB(UserProfile.UserID);  
                    #endregion

                    atttachmentNo = facadeAttachment.RetriveRunningNo(DOCUMENT_TYPE.CONTRACT_ATTACHMENT);

                    FormAttachmenttList(objAttachmentHead);
                    
                }
            }
        }

        private void FormAttachmenttList(AttachmentHead value) 
        {
            FrmAttachmentList dialogAttachmentList = new FrmAttachmentList();

            dialogAttachmentList.CustomerCode = value.CustomerCode.Code;
            dialogAttachmentList.ModelVehicleType = value.ModelVehicleType.Model_Type;           

            dialogAttachmentList.ShowDialog();
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

            Clearscreen();           
        }               

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {
            //createReport();
        }

        public void ExitForm()
        {
            //this.Close();
        }

        #endregion

        #region - Event-

        private void FrmReportContractAttachment_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }      

        private void cboModelType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateNewAttachment();
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

        }

        private void txtAttachmentNoXXX_DoubleClick(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
