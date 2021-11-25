using System;
using ictus.Common.Entity;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class ChargeRateByServiceStaffTypeList : CompanyStuffBase
    { 
        //============================== Constructor ==============================
        public ChargeRateByServiceStaffTypeList(Company aCompany)
            : base(aCompany)
		{}

        //============================== Public Method ==============================
        public void Add(ChargeRateByServiceStaffType value)
        { base.Add(value); }

        public void Remove(ChargeRateByServiceStaffType value)
        { base.Remove(value); }

        public ChargeRateByServiceStaffType this[int index]
		{
            get { return (ChargeRateByServiceStaffType)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
		}

        public ChargeRateByServiceStaffType this[String key]  
		{
            get { return (ChargeRateByServiceStaffType)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
		}
    }
}
