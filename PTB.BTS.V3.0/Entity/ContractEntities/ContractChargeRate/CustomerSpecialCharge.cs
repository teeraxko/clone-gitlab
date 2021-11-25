using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.Time;
using Entity.ContractEntities;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class CustomerSpecialCharge : EntityBase, IKey
    {
        #region Property
        private YearMonth yearMonth;
        public YearMonth YearMonth
        {
            get { return yearMonth; }
            set { yearMonth = value; }
        }

        private ContractBase contract;
        public ContractBase Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        private string employeeNo = string.Empty;
        public string EmployeeNo
        {
            get { return employeeNo; }
            set { employeeNo = value.Trim(); }
        }

        private decimal specialAmount = 0;
        public decimal SpecialAmount
        {
            get { return specialAmount; }
            set { specialAmount = value; }
        }

        private decimal telephoneAmount = 0;
        public decimal TelephoneAmount
        {
            get { return telephoneAmount; }
            set { telephoneAmount = value; }
        }

        private CustomerDepartment assignDepartment = new CustomerDepartment();
        public CustomerDepartment AssignDepartment
        {
            get { return assignDepartment; }
            set { assignDepartment = value; }
        } 
        #endregion

        #region Constructor
        public CustomerSpecialCharge()
            : base()
        { } 
        #endregion

        #region Public Method
        public override string EntityKey
        {
            get { return string.Concat(yearMonth.Year.ToString(), yearMonth.Month.ToString(), contract.ContractNo.ToString(), assignDepartment.Code); }
        } 
        #endregion
    }
}
