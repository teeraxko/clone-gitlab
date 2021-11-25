using System;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace Entity.ContractEntities
{
    public class AssignmentList : CompanyStuffBase
    {
        //============================== Property ==============================
        private ContractBase contract;
        public ContractBase Contract
        {
            get{ return contract; }
        }

        private YearMonth yearMonth;
        public YearMonth YearMonth
        {
            get{ return yearMonth; }
        }

        //============================== Constructor ==============================
        public AssignmentList(ContractBase aContract, YearMonth aYearMonth, Company company)
            : base(company)
        {
            contract = aContract;
            yearMonth = aYearMonth;
        }

        //============================== Public Method ==============================
        public void Add(ServiceStaffAssignment value)
        {base.Add(value);}

        public void Remove(ServiceStaffAssignment value)
        {base.Remove(value);}

        public ServiceStaffAssignment this[int index]
        {
            get{return (ServiceStaffAssignment)base.BaseGet(index);}
            set{base.BaseSet(index, value);}
        }

        public ServiceStaffAssignment this[String key]
        {
            get{return (ServiceStaffAssignment)base.BaseGet(key);}
            set{base.BaseSet(key, value);}
        }
    }
}
