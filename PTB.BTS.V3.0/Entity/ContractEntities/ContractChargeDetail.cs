using System;
using System.Collections.Generic;
using System.Text;

using ictus.Common.Entity.Time;
using Entity.AttendanceEntities;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.ContractEntities
{
    public class ContractChargeDetail : EntityBase, IKey, IContractChargeDetail
    {
        //============================== Property ==============================
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

        //============================== Constructor ==============================
        public ContractChargeDetail() : base()
        {
        }

        #region IKey Members

        public override string EntityKey
        {
            get { return yearMonth.Year.ToString() + yearMonth.Month.ToString(); }
        }

        #endregion
    }
}
