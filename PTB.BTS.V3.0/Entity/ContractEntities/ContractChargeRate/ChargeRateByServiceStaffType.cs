using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class ChargeRateByServiceStaffType : EntityBase, IKey
    {
        private ChargeRate chargeRate;
        public ChargeRate ChargeRate
        {
            get{return chargeRate;}
            set{chargeRate = value;}
        }

        private ServiceStaffType serviceStaffType;
        public ServiceStaffType ServiceStaffType
        {
            get { return serviceStaffType; }
            set { serviceStaffType = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private bool driverOnlyStatus;
        public bool DriverOnlyStatus
        {
            get { return driverOnlyStatus; }
            set { driverOnlyStatus = value; }
        }

        //============================== Public Method ==============================
        public ChargeRateByServiceStaffType()
            : base()
        {
            chargeRate = new ChargeRate();
        }

        //============================== Public Method ==============================
        public override string EntityKey
        {
            get { return serviceStaffType.EntityKey + customer.EntityKey + ((driverOnlyStatus) ? "Y" : "N"); }
        }
    }
}
