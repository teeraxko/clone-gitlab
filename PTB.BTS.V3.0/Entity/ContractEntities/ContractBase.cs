using System;
using System.Collections.Generic;
using System.Reflection;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Entity.ContractEntities
{
	public class ContractBase : EntityBase, IKey
    {
        
        #region Property
                
        protected DocumentNo contractNo;
        public DocumentNo ContractNo
        {
            get { return contractNo; }
            set 
            { 
                contractNo = value;
                //D21018 set abbreviation from Document No
                if (value != null && !String.IsNullOrEmpty(value.ToString()) && value.Recipient == "PTB")
                {
                    //support old format
                    AContractTypeAbbreviation = value.ToString().Substring(4, 1);                   
                }
            }
        }

        //D21018 กำหนด อักษรย่อของสัญญา(C, R, T, D) เพื่อใช้ในการ สร้าง Script ในการ Search        
        protected string aContractTypeAbbreviation = String.Empty;
        public string AContractTypeAbbreviation
        {
            get
            {
                return aContractTypeAbbreviation;
            }
            set
            {
                aContractTypeAbbreviation = value;
            }
        }

        protected Customer aCustomer;
        public Customer ACustomer
        {
            get { return aCustomer; }
            set { aCustomer = value; }
        }

        protected CustomerDepartment aCustomerDepartment;
        public CustomerDepartment ACustomerDepartment
        {
            get { return aCustomerDepartment; }
            set { aCustomerDepartment = value; }
        }

        protected DateTime contractDate = NullConstant.DATETIME;
        public DateTime ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        protected TimePeriod aPeriod;
        public TimePeriod APeriod
        {
            get { return aPeriod; }
            set { aPeriod = value; }
        }

        protected ContractType aContractType;
        public ContractType AContractType
        {
            get { return aContractType; }
            set { aContractType = value; }
        }

        protected int unitHire = NullConstant.INT;
        public int UnitHire
        {
            get { return unitHire; }
            set { unitHire = value; }
        }

        protected KindOfContract aKindOfContract;
        public KindOfContract AKindOfContract
        {
            get { return aKindOfContract; }
            set { aKindOfContract = value; }
        }

        protected RATE_STATUS_TYPE rateStatus = RATE_STATUS_TYPE.NULL;
        public RATE_STATUS_TYPE RateStatus
        {
            get { return rateStatus; }
            set { rateStatus = value; }
        }

        protected ContractStatus aContractStatus;
        public ContractStatus AContractStatus
        {
            get { return aContractStatus; }
            set { aContractStatus = value; }
        }

        protected DateTime cancelDate = NullConstant.DATETIME;
        public DateTime CancelDate
        {
            get { return cancelDate; }
            set { cancelDate = value; }
        }

        protected ContractCancelReason aCancelReason;
        public ContractCancelReason ACancelReason
        {
            get { return aCancelReason; }
            set { aCancelReason = value; }
        }

        protected string remark = NullConstant.STRING;
        public string Remark
        {
            get { return remark; }
            set { remark = value.Trim(); }
        }

        protected ContractChargeList aContractChargeList;
        public ContractChargeList AContractChargeList
        {
            get { return aContractChargeList; }
            set { aContractChargeList = value; }
        }

        protected DriverDeductCharge _driverDecuctCharge = new DriverDeductCharge();
        public DriverDeductCharge DriverDeductCharge
        {
            get
            { return _driverDecuctCharge; }
            set
            { _driverDecuctCharge = value; }
        }

        public List<ContractDepartmentAssignment> AssignedDepartmentList
        {
            get;
            set;
        }       

        #endregion

        #region Constructor
        public ContractBase(ictus.Common.Entity.Company company)
        {
            aCustomerDepartment = new CustomerDepartment();
            aPeriod = new TimePeriod();
            aCancelReason = new ContractCancelReason();
            aCustomer = new Customer();

            aContractChargeList = new ContractChargeList(company);
            aContractChargeList.AContract = this;
        }

        public ContractBase()
        {
            aCustomerDepartment = new CustomerDepartment();
            aPeriod = new TimePeriod();
            aCancelReason = new ContractCancelReason();
            aCustomer = new Customer();
        } 
        #endregion

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				return contractNo.ToString();
			}
		}

		#endregion

        #region Other Members
        public static bool EqualsByKey(ContractBase contract1,ContractBase contract2)
        {
            if ((contract1 == null) && (contract2 == null))
            {
                return true;
            }
            else if ((contract1 != null) && (contract2 == null))
            {
                return false;
            }
            else if ((contract1 == null) && (contract2 != null))
            {
                return false;
            }
            else if ((contract1.ContractNo == null) && (contract2.ContractNo == null))
            {
                return true;
            }
            else if ((contract1.ContractNo != null) && (contract2.ContractNo == null))
            {
                return false;
            }
            else if ((contract1.ContractNo == null) && (contract2.ContractNo != null))
            {
                return false;
            }
            else
            {
                return (contract1.EntityKey == contract1.EntityKey);
            }
        }

        public bool IsAssignCustomerDepartment
        {
            get { return AssignedDepartmentList != null && AssignedDepartmentList.Count >= 1; }
        }
        #endregion
    }
}
