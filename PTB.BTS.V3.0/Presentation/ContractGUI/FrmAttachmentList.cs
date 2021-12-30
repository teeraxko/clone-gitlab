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

namespace Presentation.ContractGUI
{
    public partial class FrmAttachmentList : ChildFormBase, IMDIChildForm
    {
        private AttachmentListFacade facadeListAttachment;
        public AttachmentListFacade FacadeListAttachment
        {
            get { return facadeListAttachment; }
        }

        private string customerCode;
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }
        private string modelVehicleType;
        public string ModelVehicleType
        {
            get { return modelVehicleType; }
            set { modelVehicleType = value; }
        }        

        #region Constructor

        public FrmAttachmentList()
            : base()
        {
            InitializeComponent();
        }
        
        #endregion

        public void InitForm()
        {
            //if (facadeListAttachment.DisplayAttachment(customerCode,modelVehicleType))
            //{
            //    bindData();
            //}
            //else
            //{
            //    selected = false;
            //    clearForm();
            //}
            
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

        private void FrmAttachmentList_Load(object sender, System.EventArgs e)
        {
            InitForm();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
