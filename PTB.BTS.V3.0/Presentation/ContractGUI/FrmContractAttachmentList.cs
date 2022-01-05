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
        #region Property
        private AttachmentListFacade facadeListAttachment;
        public AttachmentListFacade FacadeListAttachment
        {
            get { return facadeListAttachment; }
        }

        /// <summary>
        /// Document no to search
        /// </summary>
        private DocumentNo conditionAttachmentNo;
        public DocumentNo ConditionAttachmentNo
        {
            set { conditionAttachmentNo = value; }
        }

        /// <summary>
        /// Customer to search
        /// </summary>
        private Customer conditionCustomer;
        public Customer ConditionCustomer
        {
            set { conditionCustomer = value; }
        }

        /// <summary>
        /// Modeltype to search
        /// </summary>
        private ModelType conditionModelType;
        public ModelType ConditionModelType
        {
            get { return conditionModelType; }
            set { conditionModelType = value; }
        }

        /// <summary>
        /// Selected Attachment
        /// </summary>
        public ContractAttachment SelectedContractAttachment
        {
            get { return (ContractAttachment)facadeListAttachment.ObjAttachmentList[SelectedRow]; }
        }

        /// <summary>
        /// Selected row index in gridview
        /// </summary>
        private int SelectedRow
        {
            get {
                return dgvAttachmentList.CurrentRow.Index;
            }
        }

        /// <summary>
        /// Attachment No
        /// </summary>
        private string SelectedKey
        {
            get { return dgvAttachmentList[0, SelectedRow].Value.ToString(); }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }

        #endregion

        #region Constructor

        public FrmContractAttachmentList()
            : base()
        {
            InitializeComponent();
            facadeListAttachment = new AttachmentListFacade();
        }
        
        #endregion

        /// <summary>
        /// Search attachment list and show on the screen.
        /// </summary>
        public void InitForm()
        {
            List<ContractAttachment> attachmentList = facadeListAttachment.SearchAttachment(conditionAttachmentNo, conditionCustomer, conditionModelType);
            bindData(attachmentList);                     
        }

        /// <summary>
        /// Bind attachment list to gridview
        /// </summary>
        /// <param name="attachmentList"></param>
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

        /// <summary>
        /// Bind attachment to gridview
        /// </summary>
        /// <param name="row"></param>
        /// <param name="attachment"></param>
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

        /// <summary>
        /// Set selected status and hide form.
        /// </summary>
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

        /// <summary>
        /// Hide form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Exit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            selected = false;
            this.Hide();
        }

        /// <summary>
        /// set selected status when row selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttachmentList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            selected = true;
        }

        #endregion
    }
}
