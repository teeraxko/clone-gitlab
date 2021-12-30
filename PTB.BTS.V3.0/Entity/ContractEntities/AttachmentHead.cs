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
    public class AttachmentHead : EntityBase, IKey   
    {
        private Company companyCode;
        public Company CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }

        private DocumentNo attachmentNo;
        public DocumentNo AttachmentNo
        {
            get { return attachmentNo; }
            set { attachmentNo = value; }
        }

        private Customer customerCode;
        public Customer CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        private ModelType modelVehicleType;
        public ModelType ModelVehicleType
        {
            get { return modelVehicleType; }
            set { modelVehicleType = value; }
        }

        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private DateTime processDate;
        public DateTime ProcessDate
        {
            get { return processDate; }
            set { processDate = value; }
        }

        private string processUser;
        public string ProcessUser
        {
            get { return processUser; }
            set { processUser = value; }
        }


//      ============================== Public method ==============================
        public override string EntityKey
        {
            get { return this.attachmentNo.ToString(); }
        }                 
    }
}
