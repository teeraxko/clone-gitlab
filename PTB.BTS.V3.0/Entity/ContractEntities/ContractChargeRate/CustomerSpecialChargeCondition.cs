using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.ContractEntities;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class CustomerSpecialChargeCondition : EntityBase, IKey
    {
        #region Property
        private ContractBase contract;
        public ContractBase Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        private decimal specialAmount = decimal.Zero;
        public decimal SpecialAmount
        {
            get { return specialAmount; }
            set { specialAmount = value; }
        }

        private decimal telephoneAmount = decimal.Zero;
        public decimal TelephoneAmount
        {
            get { return telephoneAmount; }
            set { telephoneAmount = value; }
        }

        private ServiceStaff driverStaff;
        public ServiceStaff DriverStaff
        {
            get { return driverStaff; }
            set { driverStaff = value; }
        }

        private CustomerDepartment assignDepartment = new CustomerDepartment();
        public CustomerDepartment AssignDepartment
        {
            get { return assignDepartment; }
            set { assignDepartment = value; }
        }
        #endregion

        #region Constructor
        public CustomerSpecialChargeCondition()
            : base()
        { }

        #endregion

        #region Public Method
        public override string EntityKey
        {
            get { return string.Concat(contract.ContractNo.ToString(), assignDepartment.Code); }
        }
        #endregion
    }
}
