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
    public partial class FrmContractAttachmentList : ChildFormBase, IMDIChildForm
    {
        private AttachmentListFacade facadeListAttachment;
        public AttachmentListFacade FacadeListAttachment
        {
            get { return facadeListAttachment; }
        }

        private DocumentNo conditionAttachmentNo;
        public DocumentNo ConditionAttachmentNo
        {
            set { conditionAttachmentNo = value; }
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

        public ContractAttachment SelectedContractAttachment
        {
            get { return (ContractAttachment)facadeListAttachment.ObjAttachmentList[SelectedRow]; }
        }

        private int SelectedRow
        {
            get {
                return dgvAttachmentList.CurrentRow.Index;
            }
        }

        private string SelectedKey
        {
            get { return dgvAttachmentList[0, SelectedRow].Value.ToString(); }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }

        #region Constructor

        public FrmContractAttachmentList()
            : base()
        {
            InitializeComponent();
            facadeListAttachment = new AttachmentListFacade();
        }
        
        #endregion

        public void InitForm()
        {
            List<ContractAttachment> attachmentList = facadeListAttachment.SearchAttachment(conditionAttachmentNo, conditionCustomer, conditionModelType);
            bindData(attachmentList);                     
        }

        private void bindData(List<ContractAttachment> attachmentList)
        {
            dgvAttachmentList.Rows.Clear();

            if (attachmentList.Count > 0)
            {
                dgvAttachmentList.RowCount = attachmentList.Count;

                for (int i = 0; i < attachmentList.Count; i++)
                {
                    BindAttachment(i, attachmentList[i]);
                }
            }
        }

        private void BindAttachment(int row, ContractAttachment attachment)
        {
            dgvAttachmentList[0, row].Value = GUIFunction.GetString(attachment.EntityKey);
            dgvAttachmentList[1, row].Value = GUIFunction.GetString(attachment.AttachmentNo.ToString());
            dgvAttachmentList[2, row].Value = GUIFunction.GetString(attachment.ACustomer.ToString());
            dgvAttachmentList[3, row].Value = GUIFunction.GetString(attachment.AModelType.ToString());
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

        #region Event

        private void EditEvent()
        {
            selected = true;
            this.Hide();
        }

        private void FrmContractAttachmentList_Load(object sender, System.EventArgs e)
        {
            InitForm();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            selected = false;
            this.Hide();
        }

        #endregion

        private void dgvAttachmentList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            selected = true;
        }
    }
}
