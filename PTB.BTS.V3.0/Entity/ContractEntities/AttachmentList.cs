using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    public class AttachmentList : EntityBase, IKey  
    {
        private string contractType;
        public string ContractType
        {
            get { return contractType; }
            set { contractType = value; }
        }

        private string contractNo;
        public string ContractNo
        {
            get { return contractNo; }
            set { contractNo = value; }
        }

        private DateTime contractDate;
        public DateTime ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        private string kindOfContract;
        public string KindOfContract
        {
            get { return kindOfContract; }
            set { kindOfContract = value; }
        }

        private DateTime contractStartDate;
        public DateTime ContractStartDate
        {
            get { return contractStartDate; }
            set { contractStartDate = value; }
        }

        private DateTime contractEndDate;
        public DateTime ContractEndDate
        {
            get { return contractEndDate; }
            set { contractEndDate = value; }
        }

        private string customerCode;
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        private string customerDepartmentCode;
        public string CustomerDepartmentCode
        {
            get { return customerDepartmentCode; }
            set { customerDepartmentCode = value; }
        }

        private int unitHire;
        public int UnitHire
        {
            get { return unitHire; }
            set { unitHire = value; }
        }

        private string rateStatus;
        public string RateStatus
        {
            get { return rateStatus; }
            set { rateStatus = value; }
        }

        private int contractStatus;
        public int ContractStatus
        {
            get { return contractStatus; }
            set { contractStatus = value; }
        }

        private DateTime contractCancelDate;
        public DateTime ContractCancelDate
        {
            get { return contractCancelDate; }
            set { contractCancelDate = value; }
        }

        private string contractCancelRason;
        public string ContractCancelRason
        {
            get { return contractCancelRason; }
            set { contractCancelRason = value; }
        }

        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string driverDeductType;
        public string DriverDeductType
        {
            get { return driverDeductType; }
            set { driverDeductType = value; }
        }

        private int deductAmountPerDay;
        public int DeductAmountPerDay
        {
            get { return deductAmountPerDay; }
            set { deductAmountPerDay = value; }
        }

//      ============================== Public method ==============================
        public override string EntityKey
        {
            get { return this.contractNo.ToString(); }
        } 
    }
}
