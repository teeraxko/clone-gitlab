using System;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

namespace Entity.ContractEntities
{
    public class ServiceStaffContractCharge : ServiceStaffContract, IContractChargeDetail
    {
        #region IContractChargeDetail Members

        protected YearMonth yearMonth;
        public YearMonth YearMonth
        {
            get { return yearMonth; }
            set { yearMonth = value; }
        }

        protected Decimal chargeAmount = NullConstant.DECIMAL;
        public Decimal ChargeAmount
        {
            get { return chargeAmount; }
            set { chargeAmount = value; }
        }

        #endregion

        //=============================== Constructor ===============================
        public ServiceStaffContractCharge(Company company) : base(company)
        {

        }

        public override string EntityKey
        {
            get { return base.EntityKey + yearMonth.Year.ToString() + yearMonth.Month.ToString(); }
        }
    }
}
