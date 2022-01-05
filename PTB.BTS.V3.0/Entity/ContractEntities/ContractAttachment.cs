using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;
using Entity.VehicleEntities;
using ictus.Common.Entity;

namespace Entity.ContractEntities
{
    public class ContractAttachment : EntityBase, IKey
    {

        protected DocumentNo attachmentNo;
        public DocumentNo AttachmentNo
        {
            get { 
                return attachmentNo; 
            }
            set
            {
                attachmentNo = value;
            }
        }

        protected Customer aCustomer;
        public Customer ACustomer
        {
            get { 
                return aCustomer; 
            }
            set { 
                aCustomer = value; 
            }
        }

        protected ModelType aModelType;
        public ModelType AModelType
        {
            get
            {
                return aModelType;
            }
            set
            {
                aModelType = value;
            }
        }


        protected AttachmentDetailList aAttachmentDetailList;
        public AttachmentDetailList AAttachmentDetailList
        {
            get {
                return aAttachmentDetailList; 
            }
            set {
                aAttachmentDetailList = value; 
            }
        }


        protected string remark;
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        protected Company aCompany;
        public Company ACompany
        {
            get
            {
                return aCompany;
            }
            set
            {
                aCompany = value;
            }
        }


        public ContractAttachment(ictus.Common.Entity.Company company)
        {
            this.aCompany = company;
        }    

        //      ============================== Public method ==============================
        public override string EntityKey
        {
            get { return this.attachmentNo.ToString(); }
        }
    }
}
